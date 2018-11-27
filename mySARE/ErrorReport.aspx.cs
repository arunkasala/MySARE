using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace daikon
{
	public partial class errorReportPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ErrorReportForm(sender, e);
		}     
        /*
        protected void EmailBtn_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("if-svc-sareuser@ifas.ufl.edu", "if-svc-sareuser@ifas.ufl.edu"); //"estragon@ufl.edu", "Test", "Message Text");

            string msgBody;

            message.To.Add("akasala@ufl.edu");

            message.Subject = "MySARE: Error Report";

            msgBody = "Please Enter the Steps which caused this error.\n\n\n";
            msgBody += "-------------------------------------------------------------------------------\n\n";
            msgBody += Request.Params["ErrorMsg"] +"\n";
            msgBody += Request.Params["ErrorSrc"] + "\n";
            msgBody += Request.Params["ErrorSite"] + "\n";
            msgBody += Request.Params["ErrorStack"] + "\n";
            msgBody += "-------------------------------------------------------------------------------\n\n" + ConfigurationManager.AppSettings["mailFooter"].ToString();

            message.Body = msgBody;

            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["emailserver"].ToString(), 25);

            try
            {
                mailClient.Send(message);
            }
            catch (System.Exception ex)
            {
                //Not actually being caught
                Session["statusMessage1"] = "Email could not be sent.";
            }

        }

        protected void MySAREBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("sare_main.aspx");
        }
        */

        public void ErrorReportForm(object sender, System.EventArgs e)
        {
            System.Net.Mail.MailAddress senderAddress = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["emailsender"].ToString(), ConfigurationManager.AppSettings["emailsenderfriendly"].ToString());
            System.Net.Mail.MailAddress recipientAddress = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["emailbaserecipient"].ToString(), ConfigurationManager.AppSettings["emailbaserecipientfriendly"].ToString());
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(senderAddress, recipientAddress);

            string msgBody = "";
            string ErrorMsg = "MESSAGE:     " ;
            string ErrorSrc = "SOURCE:      " ;
            string ErrorSite = "TARGETSITE:  ";
            string ErrorStack = "STACKTRACE:  ";

        
            if (ErrorMessage.LastException != null)
            {
                ErrorMsg += ErrorMessage.LastException.Message.ToString();
                ErrorSrc += ErrorMessage.LastException.Source.ToString();
                ErrorSite += ErrorMessage.LastException.TargetSite.ToString();
                ErrorStack += ErrorMessage.LastException.StackTrace.ToString();               

                //message.To.Add("info@sare.org");
                //message.CC.Add("coordinator@sare.org,akasala@ufl.edu");
                //message.CC.Add("akasala@ufl.edu");

                message.Subject = "MySARE: Application Error Report";
                msgBody = "You are receiving this message because error has happened.\n\n";

                msgBody += ErrorMsg + "\n";
                msgBody += ErrorSrc + "\n";
                msgBody += ErrorSite + "\n";
                msgBody += ErrorStack + "\n";
                msgBody += "\n\n-------------------------------------------------------------------------------";

                message.Body = msgBody + "\n\n" + ConfigurationManager.AppSettings["mailFooter"].ToString();

                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["emailserver"].ToString(), 25);

                try
                {
                    mailClient.Send(message);
                }
                catch (System.Exception ex)
                {
                    Session["statusMessage1"] = "Email could not be sent." + ex.Message;
                }               
            }

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

            htmlCache.Write(htmlHeader);

            htmlCache.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td class=\"leftnav\" style=\"width: 159px; vertical-align: top;\">");
            htmlCache.Write(htmlNavbar);
            htmlCache.Write("</td><td class=\"copy\">");

            htmlCache.Write("<form id=\"ErrorReport\" runat=\"server\">");
            htmlCache.Write("<table style=\"text-align: left; width: 82%;\" border=\"0\" cellpadding=\"2\" cellspacing=\"2\">");
            htmlCache.Write("<tbody>");

            htmlCache.Write("<tr>");           
            htmlCache.Write("<span class=\"pagetitle\">MySARE Application Error Report</span><br/>");
            htmlCache.Write("<br/><strong>We’re sorry, but your request has resulted in an error. Please help us improve MySARE. Click on the Report Error link below to email the diagnostic text below to our website administrator.</strong><br/>");
            htmlCache.Write("<br/><strong>Please provide the administrator with a description of how this error was generated. Include the url of the page you visited prior to encountering the error, the names and content of any modified field(s), and the action you took to navigate from or save the data on that page if possible.</strong><br/>");
            htmlCache.Write("</tr>");

            htmlCache.Write("<br/>");
            htmlCache.Write("<br/>");

            htmlCache.Write("<tr>");
            htmlCache.Write("<td>" + ErrorMsg + "</td>");
            htmlCache.Write("</tr>");

            htmlCache.Write("<tr>");
            htmlCache.Write("<td>" + ErrorSrc + "</td>");
            htmlCache.Write("</tr>");

            htmlCache.Write("<tr>");
            htmlCache.Write("<td>" + ErrorSite + "</td>");
            htmlCache.Write("</tr>");

            htmlCache.Write("<tr>");
            htmlCache.Write("<td>" + ErrorStack + "</td>");
            htmlCache.Write("</tr>");           

            htmlCache.Write("</tbody>");
            htmlCache.Write("</table>");
            htmlCache.Write("<br/>");
            htmlCache.Write("<br/>");
            /*
            htmlCache.Write("<a href=");
            htmlCache.Write("\"mailto:akasala@ufl.edu,tech@sare.org?");
            htmlCache.Write("subject=MySARE Error Encounter Report&");
            htmlCache.Write("body=Please Enter the Steps which leaded to to this error.\n\n\n" + Request.Params["ErrorMsg"] + "\n" + Request.Params["ErrorStack"] + ">");
            htmlCache.Write("Report Error</a>");
             */
            htmlCache.Write("<a href=\"mailto:akasala@ufl.edu?subject=MySARE Error Encounter Report&body=Thanks for helping us improve MySARE. Please provide the administrator with a detailed description of how the error was generated in the space below, then click send to submit the report. Include the url of the page you visited prior to encountering the error, the names and content of any modified field(s), and the action you took to navigate from or save the data on that page if possible.%0a%0a%0a%0a%0a" + ErrorMsg + "%0a" + ErrorStack + "\">");
            htmlCache.Write("Report Error</a>");
            htmlCache.Write("<br>");
            htmlCache.Write("</form></td></tr>");
            htmlCache.Write(htmlFooter);
            htmlCache.Write("</tbody></table>");

            htmlCache.Write("</body></html>");

            htmlCache.Close();
        }

	}
}
