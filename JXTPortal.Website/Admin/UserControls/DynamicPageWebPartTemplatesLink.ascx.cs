
#region Imports
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
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
#endregion

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class DynamicPageWebPartTemplatesLink : System.Web.UI.UserControl
    {
        #region Declare variables

        private DynamicPageWebPartTemplatesService _dynamicPageWebPartTemplatesService = null;

        #endregion

        #region Properties

        int _dynamicPageWebPartTemplateId = 0;

        public int DynamicPageWebPartTemplateId
        {
            get
            {

                if (Request.QueryString["DynamicPageWebPartTemplateId"] != null && Int32.TryParse(Request.QueryString["DynamicPageWebPartTemplateId"], 
                    out _dynamicPageWebPartTemplateId))
                {
                    _dynamicPageWebPartTemplateId = Convert.ToInt32(Request.QueryString["DynamicPageWebPartTemplateId"]);
                }

                return _dynamicPageWebPartTemplateId;
            }
            set
            {
                _dynamicPageWebPartTemplateId = value;
            }
        }

        private DynamicPageWebPartTemplatesService DynamicPageWebPartTemplatesService
        {
            get
            {
                if (_dynamicPageWebPartTemplatesService == null)
                    _dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesService();
                return _dynamicPageWebPartTemplatesService;
            }
        }

        private DynamicPageWebPartTemplatesLinkService _dynamicPageWebPartTemplatesLinkService;

        private DynamicPageWebPartTemplatesLinkService DynamicPageWebPartTemplatesLinkService
        {
            get
            {
                if (_dynamicPageWebPartTemplatesLinkService == null)
                {
                    _dynamicPageWebPartTemplatesLinkService = new DynamicPageWebPartTemplatesLinkService();
                }
                return _dynamicPageWebPartTemplatesLinkService;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGridSiteWebParts();
            }
        }

        #endregion

        #region Methods
        
        public void LoadGridSiteWebParts()
        {
            SiteWebPartsService siteWebPartsService = new SiteWebPartsService();
            using (DataSet dataSetDynamicPage =
                            siteWebPartsService.GetByDynamicPageWebPartTemplatesLink(DynamicPageWebPartTemplateId))
            {
                rptWebParts.DataSource = dataSetDynamicPage.Tables[0];
                rptWebParts.DataBind();
            }

        }

        #endregion

        #region Click Event handlers

        protected void lnkDeleteFile_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;

            string ids = lb.CommandArgument;
            string[] arg = new string[2];
            char[] splitter = { ',' };
            arg = ids.Split(splitter);

            using (JXTPortal.Entities.DynamicPageWebPartTemplatesLink dynamicPageWebPartTemplatesLink =
                DynamicPageWebPartTemplatesLinkService.GetByDynamicPageWebPartTemplateIdSiteWebPartId(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1])))
            {
                DynamicPageWebPartTemplatesLinkService dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesLinkService();
                dynamicPageWebPartTemplatesService.Delete(dynamicPageWebPartTemplatesLink);
            }

            LoadGridSiteWebParts();
        }

        #endregion

    }
}