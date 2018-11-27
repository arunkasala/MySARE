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
	/// Summary description for newuser.
	/// </summary>
	public partial class newuserPage : System.Web.UI.Page
	{
        protected string errorMsg = "";    


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (Request.Form["cmdCreateNewAccount"] == "Register")
				UserCreateFormHandler(sender, e);
			else
				UserCreateForm(sender, e);
		}

        public void logOut()
        {
            Session.Abandon();
            this.Dispose();
            FormsAuthentication.SignOut();
        }

		public void UserCreateForm(object sender, System.EventArgs e)
		{
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, "newuser", DateTime.Now, DateTime.Now.AddMinutes(30), false, "mySARE");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);

			DaikonUser editingUser = new DaikonUser();
            
			//			Response.Clear();
			Response.ContentType = "text/html";
			/*
						XmlTextWriter xmlCache = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
						xmlCache.Formatting = Formatting.Indented;
			*/
			HtmlTextWriter htmlCache = new HtmlTextWriter(Response.Output);

            System.IO.StreamReader headerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\header_test.inc");
			string htmlHeader = headerFile.ReadToEnd();
			headerFile.Close();

			System.IO.StreamReader navbarFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\leftsidebar.inc");
			string htmlNavbar = navbarFile.ReadToEnd();
			navbarFile.Close();

			System.IO.StreamReader footerFile = new System.IO.StreamReader(this.MapPath(Page.TemplateSourceDirectory) + "\\includes\\footer.inc");
			string htmlFooter = footerFile.ReadToEnd();
			footerFile.Close();

			htmlCache.Write(htmlHeader);
				
			htmlCache.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td class=\"leftnav\" style=\"width: 159px; vertical-align: top;\">");
			htmlCache.Write(htmlNavbar);
			htmlCache.Write("</td><td class=\"copy\">");

            htmlCache.Write("<form onsubmit=\"return validatePassword()\" method=\"post\" action=\"newuser.aspx?do=makeNew\" name=\"userDetails\">");
			htmlCache.Write("<table style=\"text-align: left; width: 82%;\" border=\"1\" cellpadding=\"2\" cellspacing=\"2\">");
			htmlCache.Write("<tbody>");
			htmlCache.Write("<tr>");

            if (errorMsg.Length > 0)
            {
                htmlCache.Write("<p><font color=\"red\">");
                htmlCache.Write(errorMsg);
                htmlCache.Write("</font></p>");
            }
            htmlCache.Write("<span class=\"pagetitle\">MySARE Registration</span><br/>");
            htmlCache.Write("<br/>Please fill in all required fields to register for MySARE.<br/>");
            htmlCache.Write("<p><strong>Note: Fields marked with an asterisk (<font color=\"red\"><b>*</b></font>) are required</strong></p>");
			htmlCache.Write("<td width=\"30%\">Title</td>");
			htmlCache.Write("<td width=\"70%\">");
			htmlCache.Write("<select name=\"nameTitle\">");
			htmlCache.Write("<option selected></option>");
			htmlCache.Write("<option>Mr</option>");
			htmlCache.Write("<option>Ms</option>");
			htmlCache.Write("<option>Mrs</option>");
			htmlCache.Write("<option>Dr</option>");
			htmlCache.Write("</select>");
			htmlCache.Write("</td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td><font color=\"red\"><b>*</b></font> First Name</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"25\" name=\"firstName\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Last Name</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"25\" name=\"lastName\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td> Postfix (Jr., III, etc.)</td>");
			htmlCache.Write("<td><input size=\"10\" name=\"namePostfix\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td>Position</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"25\" name=\"orgPosition\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Organization</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"25\" name=\"org\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Address</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"50\" name=\"addrStreet1\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td> Address (cont.)</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"50\" name=\"addrStreet2\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> City</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"20\" name=\"addrCity\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> State</td>");
			htmlCache.Write("<td><select name=\"addrState\">");
			htmlCache.Write("<option value=\"AL\">Alabama</option>");
			htmlCache.Write("<option value=\"AK\">Alaska</option>");
			htmlCache.Write("<option value=\"AS\">American Samoa</option>");
			htmlCache.Write("<option value=\"AZ\">Arizona</option>");
			htmlCache.Write("<option value=\"AR\">Arkansas</option>");
			htmlCache.Write("<option value=\"CA\">California</option>");
			htmlCache.Write("<option value=\"CO\">Colorado</option>");
			htmlCache.Write("<option value=\"CT\">Connecticut</option>");
			htmlCache.Write("<option value=\"DE\">Delaware</option>");
			htmlCache.Write("<option value=\"DC\">District of Columbia</option>");
			htmlCache.Write("<option value=\"FL\">Florida</option>");
			htmlCache.Write("<option value=\"GA\">Georgia</option>");
			htmlCache.Write("<option value=\"GU\">Guam</option>");
			htmlCache.Write("<option value=\"HI\">Hawaii</option>");
			htmlCache.Write("<option value=\"ID\">Idaho</option>");
			htmlCache.Write("<option value=\"IL\">Illinois</option>");
			htmlCache.Write("<option value=\"IN\">Indiana</option>");
			htmlCache.Write("<option value=\"IA\">Iowa</option>");
			htmlCache.Write("<option value=\"KS\">Kansas</option>");
			htmlCache.Write("<option value=\"KY\">Kentucky</option>");
			htmlCache.Write("<option value=\"LA\">Louisiana</option>");
			htmlCache.Write("<option value=\"ME\">Maine</option>");
			htmlCache.Write("<option value=\"MD\">Maryland</option>");
			htmlCache.Write("<option value=\"MA\">Massachusetts</option>");
			htmlCache.Write("<option value=\"MI\">Michigan</option>");
			htmlCache.Write("<option value=\"FM\">Micronesia</option>");
			htmlCache.Write("<option value=\"MN\">Minnesota</option>");
			htmlCache.Write("<option value=\"MS\">Mississippi</option>");
			htmlCache.Write("<option value=\"MO\">Missouri</option>");
			htmlCache.Write("<option value=\"MT\">Montana</option>");
			htmlCache.Write("<option value=\"NE\">Nebraska</option>");
			htmlCache.Write("<option value=\"NV\">Nevada</option>");
			htmlCache.Write("<option value=\"NH\">New Hampshire</option>");
			htmlCache.Write("<option value=\"NJ\">New Jersey</option>");
			htmlCache.Write("<option value=\"NM\">New Mexico</option>");
			htmlCache.Write("<option value=\"NY\">New York</option>");
			htmlCache.Write("<option value=\"NC\">North Carolina</option>");
			htmlCache.Write("<option value=\"ND\">North Dakota</option>");
			htmlCache.Write("<option value=\"MP\">Northern Mariana Islands</option>");
			htmlCache.Write("<option value=\"OH\">Ohio</option>");
			htmlCache.Write("<option value=\"OK\">Oklahoma</option>");
			htmlCache.Write("<option value=\"OR\">Oregon</option>");
			htmlCache.Write("<option value=\"PA\">Pennsylvania</option>");
			htmlCache.Write("<option value=\"PR\">Puerto Rico</option>");
			htmlCache.Write("<option value=\"RI\">Rhode Island</option>");
			htmlCache.Write("<option value=\"SC\">South Carolina</option>");
			htmlCache.Write("<option value=\"SD\">South Dakota</option>");
			htmlCache.Write("<option value=\"TN\">Tennessee</option>");
			htmlCache.Write("<option value=\"TX\">Texas</option>");
			htmlCache.Write("<option value=\"UT\">Utah</option>");
			htmlCache.Write("<option value=\"VT\">Vermont</option>");
			htmlCache.Write("<option value=\"VI\">Virgin Islands</option>");
			htmlCache.Write("<option value=\"VA\">Virginia</option>");
			htmlCache.Write("<option value=\"WA\">Washington</option>");
			htmlCache.Write("<option value=\"WV\">West Virginia</option>");
			htmlCache.Write("<option value=\"WI\">Wisconsin</option>");
			htmlCache.Write("<option value=\"WY\">Wyoming</option>");

			htmlCache.Write("</select>");
			htmlCache.Write("</td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Zip Code</td>");
            htmlCache.Write("<td><input onKeyPress=\"return isNumberKey(event)\" maxlength=\"5\" size=\"5\" name=\"addrZip\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td> Zip +4</td>");
            htmlCache.Write("<td><input onKeyPress=\"return isNumberKey(event)\" maxlength=\"4\" size=\"4\" name=\"addrZip4\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Phone</td>");
            htmlCache.Write("<td><input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numPhone1\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numPhone2\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"4\" size=\"6\" name=\"numPhone3\"><br/>");
            htmlCache.Write("<input name=\"phoneCheck\" type=\"checkbox\">");
            htmlCache.Write("Does not have phone number");
            htmlCache.Write("</td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td>Fax</td>");
            htmlCache.Write("<td><input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numFax1\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numFax2\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"4\" size=\"6\" name=\"numFax3\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td>Cell</td>");
            htmlCache.Write("<td><input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numCell1\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"3\" size=\"5\" name=\"numCell2\">");
            htmlCache.Write("<input onKeyPress=\"return isNumberKey(event)\" maxlength=\"4\" size=\"6\" name=\"numCell3\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> E-mail Address</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"50\" name=\"email\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td>Website</td>");
			htmlCache.Write("<td><input maxlength=\"255\" size=\"50\" name=\"website\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("<td></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Username</td>");
            htmlCache.Write("<td><input maxlength=\"12\" size=\"12\" value=\" \"name=\"userName\" onblur=\"CheckMaxLength(this, 12);\">Username is limited to 12 characters</td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Password</td>");
            htmlCache.Write("<td><input value=\"\" type=\"password\" size=\"10\" name=\"password\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("<tr>");
            htmlCache.Write("<td><font color=\"red\"><b>*</b></font> Confirm Password</td>");
			htmlCache.Write("<td><input type=\"password\" size=\"10\" name=\"passconf\"></td>");
			htmlCache.Write("</tr>");
			htmlCache.Write("</tbody>");
			htmlCache.Write("</table>");
            /*
			htmlCache.Write("<p><br>");
			htmlCache.Write("<input name=\"sareMailList\" type=\"checkbox\">");
			htmlCache.Write("I'd like to be on the SARE mailing list<br>");
			htmlCache.Write("<br>");
			htmlCache.Write("We will use your e-mail address to contact you about your SARE projects, resources and/or calendar events. This box will not affect those messages. Rather, SARE occasionally sends information about new books and bulletins. If you want to receive these mailings, check the box. We do NOT share our mailing list. <br>");
			htmlCache.Write("<br>");
			htmlCache.Write("</p>");
            */
			htmlCache.Write("<input type=\"submit\" value=\"Register\" name=\"cmdCreateNewAccount\" ID=\"cmdCreateNewAccount\">");
			htmlCache.Write("<br>");
			htmlCache.Write("<input type=\"reset\" value=\"Reset Form\" name=\"cmdResetNewUserDetails\" ID=\"cmdResetNewUserDetails\">");
			//			htmlCache.Write(Session["pageURL"]);
			htmlCache.Write("</form></td></tr>");
			htmlCache.Write(htmlFooter);
			htmlCache.Write("</tbody></table>");

            htmlCache.Write("<script type=\"text/javascript\">");
            htmlCache.Write("function isNumberKey(evt) {");
            htmlCache.Write("var charCode = (evt.which) ? evt.which : event.keyCode;");
            htmlCache.Write("if (charCode > 31 && (charCode < 48 || charCode > 57))");
            htmlCache.Write("return false;");
            htmlCache.Write("return true;");
            htmlCache.Write("}");
            htmlCache.Write("function validatePassword() { ");
            htmlCache.Write("var passwd = document.userDetails.password.value;");
            htmlCache.Write("var passcnf = document.userDetails.passconf.value;");
            htmlCache.Write(" if (document.userDetails.firstName.value.length == 0 || document.userDetails.lastName.value.length == 0 || document.userDetails.org.value.length == 0 || document.userDetails.addrStreet1.value.length == 0 || document.userDetails.addrCity.value.length == 0 || document.userDetails.addrZip.value.length == 0 || document.userDetails.addrZip.value.length == 0 || document.userDetails.addrZip.value.length == 0 || ((document.userDetails.numPhone1.value.length == 0 || document.userDetails.numPhone2.value.length == 0 || document.userDetails.numPhone3.value.length == 0) && document.userDetails.phoneCheck.checked == false) || document.userDetails.email.value.length == 0 || document.userDetails.userName.value.length == 0) {");
            htmlCache.Write("   alert(\"Required Field(s) Missing.\");");
            htmlCache.Write("   return false; }");
            htmlCache.Write(" else if(document.userDetails.password.value.length == 0) {"); 
            htmlCache.Write("   alert(\"Please enter a Valid password.\");");
            htmlCache.Write("   return false; }");
            htmlCache.Write(" else if(document.userDetails.passconf.value.length == 0) {");
            htmlCache.Write("   alert(\"Please retype the password.\");");
            htmlCache.Write("   return false; }");
            htmlCache.Write(" else if(passwd != passcnf) {");
            htmlCache.Write("   alert(\"Retyped password did not match.\");");
            htmlCache.Write("   return false; }");
            htmlCache.Write(" else");
            htmlCache.Write(" return true;}");

            htmlCache.Write("function CheckMaxLength(Object, MaxLen) ");
            htmlCache.Write("{");
            htmlCache.Write("if(Object.value.length >= MaxLen)");
            htmlCache.Write("{ ");
            htmlCache.Write("alert('Username is limited to 12 characters.');");
            htmlCache.Write("return false;");
            htmlCache.Write("}");
            htmlCache.Write("else");
            htmlCache.Write("{");
            htmlCache.Write("return true;");
            htmlCache.Write("}");
            htmlCache.Write("}");

            htmlCache.Write("</script>");

			htmlCache.Write("</body></html>");

			htmlCache.Close();
		}

		public void UserCreateFormHandler(object sender, System.EventArgs e)
		{
			//			Response.Write("User Updated");
			DaikonUser editedUser;
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
			string username = Request.Form["username"].Trim();
			string nameTitle = Request.Form["nameTitle"];
			string firstName = Request.Form["firstName"];
			string lastName = Request.Form["lastName"];
			string namePostfix = Request.Form["namePostfix"];
			string org = Request.Form["org"];
			string orgPosition = Request.Form["orgPosition"];
			string addrStreet1 = Request.Form["addrStreet1"];
			string addrStreet2 = Request.Form["addrStreet2"];
			string addrCity = Request.Form["addrCity"];
			string addrState = Request.Form["addrState"];
			string addrZip = Request.Form["addrZip"];
			string addrZip4 = Request.Form["addrZip4"];
			string numPhone = Request.Form["numPhone1"] + "-" + Request.Form["numPhone2"] + "-" + Request.Form["numPhone3"];
			string numFax = Request.Form["numFax1"] + "-" + Request.Form["numFax2"] + "-" + Request.Form["numFax3"];
			string numCell = Request.Form["numCell1"] + "-" + Request.Form["numCell2"] + "-" + Request.Form["numCell3"];
			string email = Request.Form["email"];
			string website = Request.Form["website"];
            bool onEmailList = (bool)(Request.Form["sareMailList"] == "on");


            if (username.Length == 0 || firstName.Length == 0 || lastName.Length == 0 || org.Length == 0 || addrStreet1.Length == 0 || addrCity.Length == 0 ||
                addrZip.Length == 0 || email.Length == 0)
            {
                errorMsg = "Required Field(s) Missing";
                UserCreateForm(sender, e);
            }
            else
            {

                editedUser = new DaikonUser(username, nameTitle, firstName, lastName, namePostfix, org,
                    orgPosition, addrStreet1, addrStreet2, addrCity, addrState,
                    addrZip, addrZip4, numPhone, numFax, numCell, email, website, onEmailList);

                //			Response.Write(editedUser.showUser());

                //			Response.Write("Username: " + Request.Form["username"] + "Password: " + Request.Form["password"]);
                if (editedUser.saveNewUserToDB("new", Request.Form["password"], Request.Form["confpassword"]))
                {
                    Session["currUser"] = editedUser;
                    AccountCreateMailer(email, username, Request.Form["password"]);
                    //Response.Redirect("sare_main.aspx");
                    LoginToSystem(username, Request.Form["password"]);

                }
                else
                {
                    errorMsg = "The username '" + username.ToUpper() + "' and/or email address " + email + " already exists in the system. Visit " + ConfigurationManager.AppSettings["website"].ToString() + " to reset your password or retrieve your username.\n";
                    UserCreateForm(sender, e);
                }
            }

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

        private void LoginToSystem(string username, string password)
        {
            if (ValidateUser(username, password))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, username, DateTime.Now,
                    DateTime.Now.AddMinutes(120), false, "mySARE");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                //				if (chkPersistCookie.Checked)
                //					ck.Expires=tkt.Expiration;	
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "sare_main.aspx?do=confirm&confirmType=register"; 
               Session["statusMessage2"] = "You have registered successfully.";
               Response.Redirect(strRedirect, true);
            }
        }

        protected bool ValidateUser(string userName, string passWord)
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
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
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
                newKeyCommand.Parameters["@user"].Value = userName.Trim();
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
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (1 > newSessionKey)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            return (1 == passedKeyCheck);

        }

        public void AccountCreateMailer(string recipient, string username, string password)
        {
            //JUST TEST CODE--this will be integrated into the regular mailer
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("if-svc-sareuser@ifas.ufl.edu", "if-svc-sareuser@ifas.ufl.edu"); //"estragon@ufl.edu", "Test", "Message Text");

            string msgBody;

            message.To.Add(recipient);
            message.Subject = "MySARE: New User Account";

            msgBody = "Dear MySARE User:\n\n";
            msgBody += "You have successfully registered as a MySARE user. Please use your account to login to the website.\n\n";
            msgBody += "\nUsername: " + username + "\n" + "\nPassword: " + password;
            msgBody += "\nIf you are a grant recipient, visit " + ConfigurationManager.AppSettings["website"].ToString() + " to log in, retrieve and manage your project. Please save this information for future reference.\n\n";
            message.Body = msgBody + "\n\n" + ConfigurationManager.AppSettings["mailFooter"].ToString(); 

            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.ifas.ufl.edu", 25);

            mailClient.Send(message);
        }
	}
}
