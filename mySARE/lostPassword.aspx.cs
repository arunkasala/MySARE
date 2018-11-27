using System;
using System.Collections;
using System.Configuration;
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
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace daikon
{
	/// <summary>
	/// Summary description for newuser.
	/// </summary>
	public partial class lostPasswordPage : System.Web.UI.Page
	{
        protected DaikonUser currUser;
        protected string xslTemplate;
        protected string outputMessage1;
        protected string outputMessage2;

        protected StringWriter writerString;
        protected XmlTextWriter xmlWriter;
        protected XsltArgumentList xsltArgs;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            currUser = (DaikonUser)(Session["currUser"]);
            writerString = new StringWriter();
            xmlWriter = new XmlTextWriter(writerString);
            xsltArgs = new XsltArgumentList();

            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, "newuser", DateTime.Now,
                DateTime.Now.AddMinutes(30), false, "your custom data");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            //			if (chkPersistCookie.Checked)
            //				ck.Expires=tkt.Expiration;	
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);

//            Response.Redirect("newuser.aspx", true);

			// Put user code to initialize the page here
			if ( Request.Form["cmdRetrievePass"] != null )
				UserLostPasswordFormHandler(sender, e);
			else
                UserLostPasswordForm(sender, e);
		}

        public void UserLostPasswordForm(object sender, System.EventArgs e)
		{
            DaikonUser editingUser = new DaikonUser();

            xslTemplate = ConfigurationManager.AppSettings["mainpageXslt"].ToString();
            string navbarXslTemplate = ConfigurationManager.AppSettings["navbarXslt"].ToString();

            if (Session["statusMessage1"] != null)
                outputMessage1 = Session["statusMessage1"].ToString();
            else
                outputMessage1 = "";
            if (Session["statusMessage2"] != null)
                outputMessage2 = Session["statusMessage2"].ToString();
            else
                outputMessage2 = "";

            StringReader readerString;
            XmlDocument xmlDoc = new XmlDocument();
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            XslCompiledTransform xslTransformNavbar = new XslCompiledTransform();

            StringWriter writerStringNavbar;
            XmlTextWriter xmlWriterNavbar;
            XsltArgumentList xsltArgsNavbar;
            StringReader readerStringNavbar;
            XmlDocument xmlDocNavbar = new XmlDocument();

            writerStringNavbar = new StringWriter();
            xmlWriterNavbar = new XmlTextWriter(writerStringNavbar);
            xsltArgsNavbar = new XsltArgumentList();

            xmlWriter.Formatting = Formatting.Indented;
            xmlWriterNavbar.Formatting = Formatting.Indented;
            //            xmlWriter.Settings.ConformanceLevel = ConformanceLevel.Fragment;
            //            xmlWriter.Settings.Encoding = Encoding.UTF8;

            //            xmlWriter.WriteStartDocument();
            //            xmlWriterNavbar.WriteStartDocument();

            xmlWriter.WriteStartElement("SAREroot");
            xmlWriterNavbar.WriteStartElement("SAREroot");

            DaikonGrantFieldValues staticVals = new DaikonGrantFieldValues();

            staticVals.DaikonGrantFieldValues(ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString());

//            currUser.toXML(xmlWriter, "current");
//            currUser.toXML(xmlWriterNavbar, "current");

            xmlWriterNavbar.WriteEndElement();

            readerStringNavbar = new StringReader(writerStringNavbar.ToString());
            xmlDocNavbar.Load(readerStringNavbar);

			//			Response.Clear();
			Response.ContentType = "text/html";
			/*
						XmlTextWriter xmlCache = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
						xmlCache.Formatting = Formatting.Indented;
			*/
			HtmlTextWriter htmlCache = new HtmlTextWriter(Response.Output);

			System.IO.StreamReader headerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\header.inc");
			string htmlHeader = headerFile.ReadToEnd();
			headerFile.Close();

			System.IO.StreamReader navbarFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\leftsidebar.inc");
			string htmlNavbar = navbarFile.ReadToEnd();
			navbarFile.Close();

			System.IO.StreamReader footerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\footer.inc");
			string htmlFooter = footerFile.ReadToEnd();
			footerFile.Close();

            xslTemplate = ConfigurationManager.AppSettings["retrievepassXslt"].ToString();
/*
			htmlCache.Write(htmlHeader);
				
			htmlCache.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td class=\"leftnav\" style=\"width: 159px; vertical-align: top;\">");
			htmlCache.Write(htmlNavbar);
			htmlCache.Write("</td><td class=\"copy\">");

			htmlCache.Write("<form method=\"post\" action=\"\" name=\"userInfo\">");
			htmlCache.Write("<table style=\"text-align: left; width: 82%;\" border=\"1\" cellpadding=\"2\" cellspacing=\"2\">");
			htmlCache.Write("<tbody>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td>Username or email address</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"20\" name=\"userName\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("</tbody>");
			htmlCache.Write("</table>");
			htmlCache.Write("<p><br>");
			htmlCache.Write("</p>");
            htmlCache.Write("<input type=\"submit\" value=\"Retrieve Username or Password\" name=\"cmdRetrievePass\" ID=\"cmdRetrievePass\">");
			//			htmlCache.Write(Session["pageURL"]);
			htmlCache.Write("</form></td></tr>");
			htmlCache.Write(htmlFooter);
			htmlCache.Write("</tbody></table>");
			htmlCache.Write("</body></html>");

			htmlCache.Close();
 * */

            xmlWriter.WriteEndElement();

            xmlWriter.Flush();

            xsltArgs.AddParam("message", "", outputMessage1);
            xsltArgs.AddParam("message2", "", outputMessage2);

            readerString = new StringReader(writerString.ToString());
            xmlDoc.Load(readerString);

            htmlCache.Write(htmlHeader);

            htmlCache.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td class=\"leftnav\" style=\"width: 159px; vertical-align: top;\">");

            xslTransformNavbar.Load(MapPath(Page.TemplateSourceDirectory) + navbarXslTemplate);
            xslTransformNavbar.Transform(xmlDocNavbar, xsltArgsNavbar, htmlCache);

            //htmlCache.Write(htmlNavbar);

            htmlCache.Write("</td><td class=\"copy\">");
            ///////

            //xslTransform.Load(MapPath(Page.TemplateSourceDirectory) + xslTemplate);
            string xsltFilePath = MapPath(Page.TemplateSourceDirectory);
            xslTransform.Load(xsltFilePath + xslTemplate);

            xslTransform.Transform(xmlDoc, xsltArgs, htmlCache);

            htmlCache.Write("</td></tr>");
            htmlCache.Write(htmlFooter);
            htmlCache.Write("</tbody></table>");
            htmlCache.Write("</body></html>");

            htmlCache.Close();
		}

        public void UserLostPasswordFormHandler(object sender, System.EventArgs e)
		{
			/*
						string username;
						string firstName;
						string lastName;
						string org;
						string position;
						string addrStreet;
						string addrCity;
						string addrState;
						string addrZip;
						string numPhone;
						string email;
						string website;
			*/
			string username = Request.Form["username"];
            string retUsername;
            string retEmail;
            string retPass;
            string retFirstName;
            string retLastName;

            retUsername = string.Empty;
            retEmail = string.Empty;

            string userSQL;
            string userConnString = ConfigurationManager.ConnectionStrings["sareDaikonConnectionString"].ToString();

            SqlConnection userConnection;
            SqlCommand userCommand;
            SqlDataReader userDataReader;

            userConnection = new SqlConnection(userConnString);

            if (username.Contains("@") && username.Contains("."))
            {

                if (IsValidEmailAddress(username))
                {

                    userSQL = "DaikonUserEmailResetPassword";
                    userCommand = new SqlCommand(userSQL, userConnection);
                    userCommand.CommandType = CommandType.StoredProcedure;

                    userCommand.Parameters.Add("@email", SqlDbType.VarChar, 255);

                    userCommand.Parameters["@email"].Value = username;

                    userConnection.Open();

                    userDataReader = userCommand.ExecuteReader();

                    if (userDataReader.HasRows)
                    {

                        while (userDataReader.Read())
                        {
                            if (userDataReader.FieldCount > 2)
                            {
                                retUsername = userDataReader["username"].ToString();
                                retEmail = userDataReader["email"].ToString();
                                retFirstName = userDataReader["firstName"].ToString();
                                retLastName = userDataReader["lastName"].ToString();
                            }
                            else
                            {
                                retUsername = retUsername + userDataReader["username"].ToString() + '\n';
                                retEmail = userDataReader["email"].ToString();
                                retFirstName = userDataReader["firstName"].ToString();
                                retLastName = userDataReader["lastName"].ToString();
                            }

                            mailer(retEmail, retUsername, userDataReader["temppass"].ToString(), retFirstName, retLastName);

                            userConnection.Dispose();
                            Response.Write("A new password will be sent for user: " + username);                            
                            Response.Redirect("login.aspx", true);
                        }                        

                    }
                    else
                    {
                        Session["statusMessage1"] = "Entered Email Id couldn't be found.";
                        UserLostPasswordForm(sender, e);
                    }
                }
                else
                {
                    Session["statusMessage1"] = "Please Enter Correct Email Address.";
                    UserLostPasswordForm(sender, e);
                }

                retPass = null;
            }
            else if (username.Length == 0)
            {
                //Response.Write("Retrieval User Email Id is required.");
                Session["statusMessage1"] = "Please Enter Username or Email Address for retrieval.";
                UserLostPasswordForm(sender, e);
                retPass = null;
            }
            else
            {
                userSQL = "DaikonUserResetPassword";
                userCommand = new SqlCommand(userSQL, userConnection);
                userCommand.CommandType = CommandType.StoredProcedure;

                userCommand.Parameters.Add("@user", SqlDbType.VarChar, 12);

                userCommand.Parameters["@user"].Value = username;

                userConnection.Open();

                userDataReader = userCommand.ExecuteReader();

                userDataReader.Read();

                if (userDataReader.HasRows)
                {

                    retUsername = userDataReader["username"].ToString();
                    retEmail = userDataReader["email"].ToString();
                    retPass = userDataReader["temppass"].ToString();
                    retFirstName = userDataReader["firstName"].ToString();
                    retLastName = userDataReader["lastName"].ToString();

                    mailer(retEmail, retUsername, retPass, retFirstName, retLastName);
                    userConnection.Close();
                    userConnection.Dispose();
                    Response.Write("A new password will be sent for user: " + username);
                    Response.Redirect("login.aspx", true);
                }
                else
                {
                    Session["statusMessage1"] = "Entered Username couldn't be found.";
                    UserLostPasswordForm(sender, e);
                    retPass = null;

                }
            }           


		}
        public void mailer(string recipient, string username, string password, string firstName, string lastName)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("if-svc-sareuser@ifas.ufl.edu", "if-svc-sareuser@ifas.ufl.edu"); //"estragon@ufl.edu", "Test", "Message Text");

            //            message.Sender = "if-svc-sareuser@ufl.edu";
            message.To.Add(recipient);
            message.Subject = "MySARE: Password Retrieval";
            if (password == null)
            {
                message.Body = "This email address might be associated with multiple accounts--please choose an account from the list below and retrieve the password for it individually." + '\n' + username;
            }
            else
            {
                string msgBody = "Hi " + firstName + " " + lastName + ",\n";
                msgBody += "\nThank you for your cooperation in maintaining the security of the MySARE system. Your username and newly generated password are below. We recommend that you log in and change your password.\n";
                msgBody += "\nUsername: " + username + "\nPassword: " + password;
                msgBody += "\nTo sign in, visit " + ConfigurationManager.AppSettings["website"].ToString();

                msgBody += "\n\nHow to change your password:\n";

                msgBody += "\n1) Log in to the MySARE website at " + ConfigurationManager.AppSettings["website"].ToString() + "/MySare/login.aspx";
                msgBody += "\n2) Click on \"Edit User Info page\"";

                message.Body = msgBody + "\n\n" + ConfigurationManager.AppSettings["mailFooter"].ToString();;

                Session["resetPassword"] = "reset";
            }

            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.ifas.ufl.edu", 25);

            mailClient.Send(message);
            // Response.Write("Mail should've been sent.");
        }

        public static bool IsValidEmailAddress(string sEmail)
        {
            if (sEmail == null)
            {
                return false;
            }
            /*
            else
            {
                return Regex.IsMatch(sEmail, @"
                                            ^
                                            [-a-zA-Z0-9][-.a-zA-Z0-9]*
                                            @
                                            [-.a-zA-Z0-9]+
                                            (\.[-.a-zA-Z0-9]+)*
                                            \.
                                            (
                                            com|edu|info|gov|int|mil|net|org|biz|
                                            name|museum|coop|aero|pro
                                            |
                                            [a-zA-Z]{2}
                                            )
                                            $",
                RegexOptions.IgnorePatternWhitespace);
            }
            */

            //Valid Email Addresses according to RFC2822:

            int atSym = sEmail.LastIndexOf("@");
            if (atSym < 1) { return false; } // no local-part
            if (atSym == sEmail.Length - 1) { return false; } // no domain
            if (atSym > 64) { return false; } // there may only be 64 octets in the local-part
            if (sEmail.Length - atSym > 255) { return false; } // there may only be 255 octets in the domain

            // Is the domain plausible?
            int lastDot = sEmail.LastIndexOf(".");
            // Check if it is a dot-atom such as example.com
            if (lastDot > atSym + 1 && lastDot < sEmail.Length - 1) { return true; }
            //  Check if could be a domain-literal.
            if (sEmail[atSym + 1] == '[' && sEmail[sEmail.Length - 1] == ']') { return true; }
            return false;
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
	}
}
