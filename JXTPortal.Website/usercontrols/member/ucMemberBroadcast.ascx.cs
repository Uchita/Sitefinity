using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using System;
using System.Text;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberBroadcast : System.Web.UI.UserControl
    {
        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            ucMemberSavedJobs.IsBroadCast = true;
            ucMemberApplicationTracker.IsBroadCast = true;
            ucMemberJobAlert.IsBroadCast = true;
            
        }

        #endregion

    }
}