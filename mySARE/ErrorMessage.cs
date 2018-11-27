using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace daikon
{
    public class ErrorMessage
    {

        public ErrorMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public static Exception LastException
        {
            get
            {
                return _LastException;
            }
            set
            {
                if (value != _LastException)
                {
                    _LastException = value;
                }
            }
        }

        private static Exception _LastException;
    }
}

