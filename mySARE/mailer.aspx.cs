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
using System.Xml;
using System.Xml.XPath;

namespace daikon
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			string rec;
			XPathNodeIterator allRec;

			allRec = determineMailRecipients(1, 1, "NC");
			while (allRec.MoveNext())
			{
				rec = allRec.Current.Value;
				Response.Write(rec);
			}
        }

		public XPathNodeIterator determineMailRecipients(int coreType, int subType, string region)
		{
			XPathNavigator recipientNav;
			XPathDocument recipientsList = new XPathDocument(MapPath(Page.TemplateSourceDirectory) + ConfigurationManager.AppSettings["mailRecipientsXml"].ToString());
			String navExpression;
			//XPathNodeIterator recipients;


			if (subType == 0)
			{
				navExpression = "/SAREroot/user[emailrecipient/recipientfor@region='" + region + "'/core@type='" + coreType.ToString() + "]/contact/email";
			}
			else
			{
				navExpression = "/SAREroot/user[emailrecipient/recipientfor@region='" + region + "'/core@type='" + coreType.ToString() + "'/subtype='" + subType.ToString() + "']/contact/email";
			}

			navExpression = "/SAREroot/user/contact/email[../../emailrecipient/recipientfor@region='" + region + "']";

			recipientNav = recipientsList.CreateNavigator();
			return recipientNav.Select(navExpression);
		}
    }
}
