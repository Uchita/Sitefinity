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
    public partial class SiteNewsType : System.Web.UI.Page
    {
        #region Properties

        JXTPortal.NewsTypeService _newstypeService;
        JXTPortal.NewsTypeService NewsTypeService
        {
            get
            {
                if (_newstypeService == null)
                {
                    _newstypeService = new JXTPortal.NewsTypeService();
                }
                return _newstypeService;
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


        private TList<JXTPortal.Entities.NewsType> newstype;
        private TList<JXTPortal.Entities.NewsType> sitenewstype;

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

            sitenewstype = NewsTypeService.GetPaged("SiteID = " + SessionData.Site.SiteId.ToString() + " AND GlobalTemplate = 0", "", 0, Int32.MaxValue, out count);
            if (sitenewstype.Count == 0)
            {
                lblErrorMsg.Text = "Default News Type are being used.";
                return;
            }
            rptNewsType.DataSource = sitenewstype;
            rptNewsType.DataBind();
        }

        protected void rptNewsType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLastModifiedDate = e.Item.FindControl("ltLastModifiedDate") as Literal;
                JXTPortal.Entities.NewsType newstype = e.Item.DataItem as JXTPortal.Entities.NewsType;

                if (newstype.LastModifiedDate.HasValue)
                {
                    ltLastModifiedDate.Text = newstype.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                }
            }
        }

        #endregion

        #region Click Event handlers


        #endregion
    }
}