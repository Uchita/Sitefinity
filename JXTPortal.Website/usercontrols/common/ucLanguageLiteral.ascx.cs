using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucLanguageLiteral : System.Web.UI.UserControl
    {
        private string _languagecode = string.Empty;

        public string SetLanguageCode
        {
            set {
                _languagecode = value;
                ltlLanguageField.Text = CommonFunction.GetResourceValue(value);
            }
        }

        public string GetLanguageCode
        {
            get
            {
                return _languagecode;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}