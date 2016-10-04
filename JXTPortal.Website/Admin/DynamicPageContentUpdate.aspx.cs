using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class DynamicPageContentUpdate : System.Web.UI.Page
    {
        #region Properties

        private DynamicPagesService _dynamicPagesService;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null) _dynamicPagesService = new DynamicPagesService();
                return _dynamicPagesService;
            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && !String.IsNullOrEmpty(txtFrom.Text.Trim()) && !String.IsNullOrEmpty(txtTo.Text.Trim()))
            {
                try
                {
                    DynamicPagesService.BulkUpdate(SessionData.Site.SiteId, txtFrom.Text.Trim(), txtTo.Text.Trim(), chkInclude.Checked);

                    ltlMessage.Text = "All the Paths Updated.";
                    btnSave.Enabled = false;
                }
                catch(Exception ex)
                {
                    ltlMessage.Text = String.Format("Error - {0} <br> Stack - {1}",ex.Message , ex.StackTrace);
                }

            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DynamicPages.aspx");
        }
    }
}
