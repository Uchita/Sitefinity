#region Using directives
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Web.UI;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class SiteNewsIndustry : System.Web.UI.Page
    {
        #region Properties

        JXTPortal.NewsIndustryService _newsindustryService;
        JXTPortal.NewsIndustryService NewsIndustryService
        {
            get
            {
                if (_newsindustryService == null)
                {
                    _newsindustryService = new JXTPortal.NewsIndustryService();
                }
                return _newsindustryService;
            }
        }

        JXTPortal.AdminUsersService _adminusersService;
        JXTPortal.AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminusersService == null)
                {
                    _adminusersService = new JXTPortal.AdminUsersService();
                }
                return _adminusersService;
            }
        }


        private TList<JXTPortal.Entities.NewsIndustry> newsindustry;
        private TList<JXTPortal.Entities.NewsIndustry> sitenewsindustry;

        #endregion

        #region Page Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }
        }

        #endregion

        #region Methods

        protected void loadForm()
        {
            // Get all Site


            // Get all Default
            int count = 0;

            sitenewsindustry = NewsIndustryService.GetPaged("SiteID = " + SessionData.Site.SiteId.ToString() + " AND GlobalTemplate = 0", "", 0, Int32.MaxValue, out count);
            if (sitenewsindustry.Count == 0)
            {
                lblErrorMsg.Text = "Default News Industry are being used.";
                return;
            }
            rptNewIndustry.DataSource = sitenewsindustry;
            rptNewIndustry.DataBind();

        }

        protected void rptNewIndustry_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLastModifiedDate = e.Item.FindControl("ltLastModifiedDate") as Literal;
                JXTPortal.Entities.NewsIndustry newsindustry = e.Item.DataItem as JXTPortal.Entities.NewsIndustry;

                if (newsindustry.LastModifiedDate.HasValue)
                {
                    ltLastModifiedDate.Text = newsindustry.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                }
            }
        }

        #endregion

        #region Click Event handlers


        #endregion
    }
}