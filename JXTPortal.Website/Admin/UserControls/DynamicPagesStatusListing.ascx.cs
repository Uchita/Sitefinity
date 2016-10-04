using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class DynamicPagesStatusListing : System.Web.UI.UserControl
    {
        #region "Properties"

        private SiteLanguagesService _siteLanguagesService;

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null) _siteLanguagesService = new SiteLanguagesService();
                return _siteLanguagesService;
            }
        }

        private DynamicPagesService _dynamicPagesService;

        public DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        private DynamicPageRevisionsService _dynamicPageRevisionsService;

        public DynamicPageRevisionsService DynamicPageRevisionsService
        {
            get
            {
                if (_dynamicPageRevisionsService == null)
                {
                    _dynamicPageRevisionsService = new DynamicPageRevisionsService();
                }
                return _dynamicPageRevisionsService;
            }
        }

        private RelatedDynamicPagesService _relatedDynamicPagesService;
        public RelatedDynamicPagesService RelatedDynamicPagesService
        {
            get
            {
                if (_relatedDynamicPagesService == null)
                    _relatedDynamicPagesService = new RelatedDynamicPagesService();

                return _relatedDynamicPagesService;
            }
        }

        private FilesService _filesService;

        private FilesService FilesService
        {
            get
            {
                if (_filesService == null)
                    _filesService = new FilesService();

                return _filesService;
            }
        }

        private DynamicPageFilesService _dynamicPageFilesService;

        private DynamicPageFilesService DynamicPageFilesService
        {
            get
            {
                if (_dynamicPageFilesService == null)
                    _dynamicPageFilesService = new DynamicPageFilesService();

                return _dynamicPageFilesService;
            }
        }

        private DynamicpagesCustomWidgetService _DynamicpagesCustomWidgetService;

        private DynamicpagesCustomWidgetService DynamicpagesCustomWidgetService
        {
            get
            {
                if (_DynamicpagesCustomWidgetService == null)
                    _DynamicpagesCustomWidgetService = new DynamicpagesCustomWidgetService();

                return _DynamicpagesCustomWidgetService;
            }
        }

        private CustomWidgetService _CustomWidgetService;

        private CustomWidgetService CustomWidgetService
        {
            get
            {
                if (_CustomWidgetService == null)
                    _CustomWidgetService = new CustomWidgetService();

                return _CustomWidgetService;
            }
        }

        private GlobalSettingsService _GlobalSettingsService;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                    _GlobalSettingsService = new GlobalSettingsService();

                return _GlobalSettingsService;
            }
        }

        #endregion

        #region Models

        internal class DynamicPageRevisionDispModel
        {
            public int pageID { get; set; }
            public string pageName { get; set; }
            public string pageTitle { get; set; }
            public string submittedBy { get; set; }
            public DateTime submittedOn { get; set; }
            public string mappingID { get; set; }
            public PortalEnums.DynamicPage.Status status { get; set; }

        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDrafts();
                LoadPendings();
            }

        }

        private void LoadDrafts()
        {
            List<DynamicPageRevisionDispModel> drafts = new List<DynamicPageRevisionDispModel>();
            using (DataSet ds = DynamicPageRevisionsService.CustomGetBySiteIDStatus(SessionData.Site.SiteId, (int)PortalEnums.DynamicPage.Status.Draft))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DynamicPageRevisionDispModel thisRev = new DynamicPageRevisionDispModel
                    {
                        pageID = int.Parse(row["DynamicPageRevisionID"].ToString()),
                        pageName = row["PageName"].ToString(),
                        pageTitle = row["PageTitle"].ToString(),
                        submittedBy = row["UserName"].ToString(),
                        submittedOn = DateTime.Parse(row["LastModified"].ToString()),
                        mappingID = row["MappingID"].ToString().ToLower(),
                        status = (PortalEnums.DynamicPage.Status)int.Parse(row["status"].ToString())
                    };

                    drafts.Add(thisRev);
                }
            }
            rptDraftsList.DataSource = drafts;
            rptDraftsList.DataBind();
        }

        private void LoadPendings()
        {
            List<DynamicPageRevisionDispModel> drafts = new List<DynamicPageRevisionDispModel>();
            using (DataSet ds = DynamicPageRevisionsService.CustomGetBySiteIDStatus(SessionData.Site.SiteId, (int)PortalEnums.DynamicPage.Status.Pending))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DynamicPageRevisionDispModel thisRev = new DynamicPageRevisionDispModel
                    {
                        pageID = int.Parse(row["DynamicPageRevisionID"].ToString()),
                        pageName = row["PageName"].ToString(),
                        pageTitle = row["PageTitle"].ToString(),
                        submittedBy = row["UserName"].ToString(),
                        submittedOn = DateTime.Parse(row["LastModified"].ToString()),
                        mappingID = row["MappingID"].ToString().ToLower(),
                        status = (PortalEnums.DynamicPage.Status)int.Parse(row["status"].ToString())
                    };

                    drafts.Add(thisRev);
                }
            }
            rptPendingsList.DataSource = drafts;
            rptPendingsList.DataBind();
        }


        protected void rptDraftsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (((List<DynamicPageRevisionDispModel>)rptDraftsList.DataSource).Count() > 0)
                {
                    PlaceHolder phMsg = e.Item.FindControl("plNoDraftMsg") as PlaceHolder;
                    phMsg.Visible = false;
                }
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltPageID = e.Item.FindControl("ltPageID") as Literal;
                Literal ltPageNme = e.Item.FindControl("ltPageNme") as Literal;
                Literal ltPageTitle = e.Item.FindControl("ltPageTitle") as Literal;
                Literal ltStatus = e.Item.FindControl("ltStatus") as Literal;
                Literal ltSubmittedOn = e.Item.FindControl("ltSubmittedOn") as Literal;
                Literal ltSubmittedBy = e.Item.FindControl("ltSubmittedBy") as Literal;
                //LinkButton lbRevisionRevert = e.Item.FindControl("lbRevisionRevert") as LinkButton;
                HyperLink hlRevisionView = e.Item.FindControl("hlRevisionView") as HyperLink;

                DynamicPageRevisionDispModel drv = e.Item.DataItem as DynamicPageRevisionDispModel;

                ltPageID.Text = drv.pageID.ToString();
                ltPageNme.Text = drv.pageName;
                ltPageTitle.Text = drv.pageTitle;
                ltStatus.Text = drv.status.ToString();
                ltSubmittedBy.Text = drv.submittedBy;
                ltSubmittedOn.Text = string.Format("{0:" + SessionData.Site.DateFormat + " HH:mm:ss}", drv.submittedOn);


                //lbRevisionRevert.CommandArgument = drv.MappingId.ToString();
                hlRevisionView.NavigateUrl = "/admin/dynamicpagerevisions.aspx?revisioncode=" + drv.mappingID.ToString();
            }
        }

        protected void rptPendingsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (((List<DynamicPageRevisionDispModel>)rptPendingsList.DataSource).Count() > 0)
                {
                    PlaceHolder phMsg = e.Item.FindControl("plNoPendingMsg") as PlaceHolder;
                    phMsg.Visible = false;
                }
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltPageID = e.Item.FindControl("ltPageID") as Literal;
                Literal ltPageNme = e.Item.FindControl("ltPageNme") as Literal;
                Literal ltPageTitle = e.Item.FindControl("ltPageTitle") as Literal;
                Literal ltStatus = e.Item.FindControl("ltStatus") as Literal;
                Literal ltSubmittedOn = e.Item.FindControl("ltSubmittedOn") as Literal;
                Literal ltSubmittedBy = e.Item.FindControl("ltSubmittedBy") as Literal;
                //LinkButton lbRevisionRevert = e.Item.FindControl("lbRevisionRevert") as LinkButton;
                HyperLink hlRevisionView = e.Item.FindControl("hlRevisionView") as HyperLink;

                DynamicPageRevisionDispModel drv = e.Item.DataItem as DynamicPageRevisionDispModel;

                ltPageID.Text = drv.pageID.ToString();
                ltPageNme.Text = drv.pageName;
                ltPageTitle.Text = drv.pageTitle;
                ltStatus.Text = drv.status.ToString();
                ltSubmittedBy.Text = drv.submittedBy;
                ltSubmittedOn.Text = string.Format("{0:" + SessionData.Site.DateFormat + " HH:mm:ss}", drv.submittedOn);

                hlRevisionView.NavigateUrl = "/admin/dynamicpagerevisions.aspx?revisioncode=" + drv.mappingID.ToString();

            }
        }

        protected void rptDraftsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Revert")
            {
                Response.Redirect("/admin/dynamicpagerevisions.aspx?revisioncode=" + e.CommandArgument);
            }

        }
        protected void rptPendingsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Revert")
            {
                Response.Redirect("/admin/dynamicpagerevisions.aspx?revisioncode=" + e.CommandArgument);
            }

        }
    }
}