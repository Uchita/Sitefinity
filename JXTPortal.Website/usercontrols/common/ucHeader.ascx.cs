using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucHeader : System.Web.UI.UserControl
    {
        public String SetContent
        {
            set
            {
                if (!String.IsNullOrEmpty(value.Trim()))
                    ltlContent.Text = String.Format("{0}", value);
            }
        }
    }
}