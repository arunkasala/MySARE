using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;


namespace daikon
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public partial class login : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (Request.Params["q"] != null)
                lblMsg.Text = "Due to system inactivity we redirected to the login page.";
			// Put user code to initialize the page here
			if ((this.IsPostBack == false) && ((Request.Url.AbsoluteUri.Contains("login")) && (Request.Params.HasKeys() == false)))
				logOut();

            if (Session["resetPassword"] != null)
                lblMsg.Text = "Your password has been reset and sent to your registered e-mail address.";
		}
		public void logOut()
		{
			Session.Abandon();
			this.Dispose();
			FormsAuthentication.SignOut();
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void cmdLogin_ServerClick(object sender, System.EventArgs e)
		{
                string userSQL;
                string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
                SqlConnection userConnection;

                SqlCommand userCommand;
                SqlDataReader userDataReader;

                userConnection = new SqlConnection(userConnString);

                userConnection = new SqlConnection(userConnString);
                userSQL = "DaikonCheckAcctLockForUser";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;
                userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = txtUserName.Value;
               
                userConnection.Open();

                userDataReader = userCommand.ExecuteReader();

                if (userDataReader.HasRows == true)
                {
                    lblMsg.Text = "Account has being locked, please contact Regional Administrator.";
                    userConnection.Dispose();
                }
                else
                {
                    userConnection.Dispose();
                    userCommand.Dispose();
                    if (ValidateUser(txtUserName.Value, txtUserPass.Value))
                    {
                        FormsAuthenticationTicket tkt;
                        string cookiestr;
                        HttpCookie ck;
                        tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
                            DateTime.Now.AddMinutes(120), false, "mySARE");
                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        //				if (chkPersistCookie.Checked)
                        //					ck.Expires=tkt.Expiration;	
                        ck.Path = FormsAuthentication.FormsCookiePath;
                        Response.Cookies.Add(ck);

                        DaikonUser newUser;

                        newUser = new DaikonUser(txtUserName.Value, (int)Session["sessionkey"], txtUserName.Value);
                        Session.Add("currUser", newUser);
                        //                Session.Timeout = int.Parse(ConfigurationManager.AppSettings["edituserXslt"]);

                        string strRedirect;
                        strRedirect = Request["ReturnUrl"];
                        if (strRedirect == null)
                            strRedirect = "sare_main.aspx";
                        //if (newUser.Roles.IsAdmin())
                        Response.Redirect(strRedirect, true);
                        //else
                        //lblMsg.Text = "The MySARE system will be shut down for migration to a new site on Thursday, April 14.";
                    }
                    else
                    {
                        lblMsg.Text = "Log In Failed";
                        //Response.Redirect("login.aspx", true);
                        //Response.Write("Log In Failed");

                    }
                }
			
		}

		protected bool ValidateUser( string userName, string passWord )
		{
			string newKeySQL;
			string checkKeySQL;
			int passedKeyCheck = 0;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();
//			string userConnString = "Data Source=IF-SRV-IPSST;Initial Catalog=sareDynamic;User ID=saredev_test;pwd=sp0r315";
			SqlConnection userConnection;
			SqlCommand newKeyCommand;
			SqlCommand checkKeyCommand;
//			SqlDataReader userDataReader;

			
			int newSessionKey = 0;

			// Check for invalid userName.
			// userName must not be null and must be between 1 and 15 characters.
			if ( (  null == userName ) || ( 0 == userName.Length ) || ( userName.Length > 15 ) )
			{
				System.Diagnostics.Trace.WriteLine( "[ValidateUser] Input validation of userName failed." );
				return false;
			}

			// Check for invalid passWord.
			// passWord must not be null and must be between 1 and 25 characters.
			if ( (  null == passWord ) || ( 0 == passWord.Length ) || ( passWord.Length > 25 ) )
			{
				System.Diagnostics.Trace.WriteLine( "[ValidateUser] Input validation of passWord failed." );
				return false;
			}

			try
			{
				// Consult with your SQL Server administrator for an appropriate connection
				// string to use to connect to your local SQL Server.
				userConnection = new SqlConnection(userConnString);
				userConnection.Open();

				newKeySQL = "DaikonUserNewSessionKey";

				newKeyCommand = new SqlCommand();
				newKeyCommand.Connection = userConnection;
				newKeyCommand.CommandText = newKeySQL;
				newKeyCommand.CommandType = CommandType.StoredProcedure;

				newKeyCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
				newKeyCommand.Parameters.Add("@pw", SqlDbType.VarChar, 50);
				newKeyCommand.Parameters["@user"].Value = userName;
				newKeyCommand.Parameters["@pw"].Value = passWord;
				//Response.Write(userName);

				newSessionKey = (int)newKeyCommand.ExecuteScalar();
				Session["sessionkey"] = newSessionKey;

				//	Response.Write(newSessionKey);

				checkKeySQL = "DaikonUserCheckSessionKey";

				checkKeyCommand = new SqlCommand();
				checkKeyCommand.Connection = userConnection;
				checkKeyCommand.CommandText = checkKeySQL;
				checkKeyCommand.CommandType = CommandType.StoredProcedure;

				checkKeyCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);
				checkKeyCommand.Parameters.Add("@sKey", SqlDbType.Int);
				checkKeyCommand.Parameters["@user"].Value = userName;
				checkKeyCommand.Parameters["@sKey"].Value = newSessionKey;

				passedKeyCheck = (int)checkKeyCommand.ExecuteScalar();

				// Cleanup command and connection objects.
				newKeyCommand.Dispose();
				checkKeyCommand.Dispose();
				userConnection.Dispose();
			}
			catch ( Exception ex )
			{
				// Add error handling here for debugging.
				// This error message should not be sent back to the caller.
				System.Diagnostics.Trace.WriteLine( "[ValidateUser] Exception " + ex.Message );
			}

			// If no password found, return false.
			if (1 > newSessionKey) 
			{
				// You could write failed login attempts here to event log for additional security.
				return false;
			}

			return (1 == passedKeyCheck);

		}

		protected void cmdRegister_ServerClick(object sender, System.EventArgs e)
		{
			logOut();
			FormsAuthenticationTicket tkt;
			string cookiestr;
			HttpCookie ck;
			tkt = new FormsAuthenticationTicket(1, "newuser", DateTime.Now, 
				DateTime.Now.AddMinutes(30), false, "mySARE");
			cookiestr = FormsAuthentication.Encrypt(tkt);
			ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
//			if (chkPersistCookie.Checked)
//				ck.Expires=tkt.Expiration;	
			ck.Path = FormsAuthentication.FormsCookiePath; 
			Response.Cookies.Add(ck);
            
			Response.Redirect("newuser.aspx", true);
		}
        
	}
}
