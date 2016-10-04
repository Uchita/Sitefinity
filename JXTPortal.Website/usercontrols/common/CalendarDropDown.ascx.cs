using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class CalendarDropDown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DateTime SelectedDate 
        {
            get
            {
                return DateTime.Now;
            }
            set
            { 
            
            }
        }
    }
}