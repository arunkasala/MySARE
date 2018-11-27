using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using System.Threading;
using System.Net;

namespace daikon
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FakeBackgroundWorker.Begin();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex.InnerException != null)
            {
                ErrorMessage.LastException = ex.InnerException;
                Response.Redirect("ErrorReport.aspx"); 
            }               
        }

        void Session_Start(object sender, EventArgs e)
        {
            if (Request.RawUrl.Contains("ProjectReport.aspx") == false)
                Response.Redirect("login.aspx");
        }

        protected void Session_OnEnd()
        {
            

        }

        public class FakeBackgroundWorker
        {
            private static bool Initialized = false;
            public static void Begin()
            {
                if (Initialized == false)
                {
                    Thread t = new Thread(new ThreadStart(Run));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            public static void Run()
            {
                //do
                //{
                //    //Download your own website.
                //    string urlContent = new System.Net.WebClient().DownloadString("https://www.sare.org");
                //    //Every minute
                //    Thread.Sleep(60000);
                //} while (true);

            }
        }

    }
}