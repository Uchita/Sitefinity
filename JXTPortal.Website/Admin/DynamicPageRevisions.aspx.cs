using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Website;
using System.Collections.Generic;
using SectionIO;
using System.Linq;

namespace JXTPortal.Website.Admin
{
    public partial class DynamicPageRevisions : System.Web.UI.Page
    {
        public ICacheFlusher CacheFlusher { get; set; }

        #region "Properties"

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToUpper(); }
        }

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

        public List<int> _oldSelectedCSSFiles
        {
            get
            {
                if (ViewState["OldSelectedCSSFiles"] != null)
                    return (List<int>)ViewState["OldSelectedCSSFiles"];

                return null;
            }
            set { ViewState["OldSelectedCSSFiles"] = value; }
        }

        public List<int> _oldSelectedJSFiles
        {
            get
            {
                if (ViewState["OldSelectedJSFiles"] != null)
                    return (List<int>)ViewState["OldSelectedJSFiles"];

                return null;
            }
            set { ViewState["OldSelectedJSFiles"] = value; }
        }

        public string StrPageName
        {
            get
            {
                string strPageName = "";

                if (!String.IsNullOrEmpty(CommonPage.PageName))
                {
                    string[] strPageNames = CommonPage.PageName.Split(new char[] { '/' });
                    strPageName = strPageNames[strPageNames.Length - 1];
                }

                return strPageName;
            }
        }

        public Guid RevisionCode
        {
            get
            {
                Guid strRevisionCode = Guid.Empty;

                if (!string.IsNullOrWhiteSpace(Request.Params["RevisionCode"]))
                {
                    Guid.TryParse(Request.Params["RevisionCode"], out strRevisionCode);
                }

                return strRevisionCode;
            }
        }

        public bool Revert
        {
            get
            {
                if (Request.Params["revert"] == null)
                {
                    return false;
                }
                return (Request.Params["revert"].ToString() == "1");
            }
        }


        #endregion

        #region Page Events


        private string GetSHA1String(string text)
        {
            var UE = new UTF8Encoding();// ASCIIEncoding(); // UnicodeEncoding();
            var message = UE.GetBytes(text);

            var hashString = new SHA1Managed();
            var hex = string.Empty;

            var hashValue = hashString.ComputeHash(message);
            foreach (byte b in hashValue)
            {
                hex += String.Format("{0:x2}", b);
            }

            return hex;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser == null)
            {
                Response.Redirect("~/admin/login.aspx" + "?returnurl=" + Server.UrlEncode(HttpContext.Current.Request.Url.PathAndQuery));
            }

            LoadMessageDisplays();

            DisableFieldsForSystemPage();

            List<IValidator> errored = this.Validators.Cast<IValidator>().Where(v => !v.IsValid).ToList();

            CustomPaymentService s = new CustomPaymentService();
            RelatedDynamicPagesService s2 = new RelatedDynamicPagesService();
            ltlMessage.Text = string.Empty;
            ltSiteUrl.Text = string.Format("http://www.{0}/", SessionData.Site.SiteUrl);
            if (!Page.IsPostBack)
            {
                PortalEnums.DynamicPage.Status thisPageStatus = PortalEnums.DynamicPage.Status.None;

                // - Temp pnlCSSJS.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
                LoadSiteLanguages();
                LoadStatus(PortalEnums.DynamicPage.Status.None);
                SetPanelVisiblility(true);
                //Load visibility/functions available base on user role
                InitVisiblilityBaseOnRoles();

                if (RevisionCode != Guid.Empty)
                {
                    LoadPageRevision();
                }
                else
                {
                    LoadDynamicPage();
                }
                LoadPublishedVisions();
                LoadCSSFiles();
                LoadJavascriptFiles();
                // LoadRelatedDynamicPages();
                LoadJavascript();
            }

        }

        #endregion

        #region "Methods"

        private void LoadStatus(PortalEnums.DynamicPage.Status status = PortalEnums.DynamicPage.Status.None)
        {
            ddlStatus.Items.Clear();
            if (SessionData.AdminUser != null)
            {
                if (status == PortalEnums.DynamicPage.Status.None)
                {
                    ddlStatus.Items.Add(new ListItem("Save As Draft", ((int)PortalEnums.DynamicPage.Status.Draft).ToString(), true));

                    if (SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Contributor)
                    {
                        ddlStatus.Items.Add(new ListItem("Publish Live", ((int)PortalEnums.DynamicPage.Status.Published).ToString()));
                        ddlStatus.SelectedValue = ((int)PortalEnums.DynamicPage.Status.Published).ToString();
                    }
                    else
                    {
                        ddlStatus.Items.Add(new ListItem("Submit For Review", ((int)PortalEnums.DynamicPage.Status.Pending).ToString()));
                        ddlStatus.SelectedValue = ((int)PortalEnums.DynamicPage.Status.Pending).ToString();
                    }

                    phStatus.Visible = false;
                    //lbSaveDraft.Visible = true;
                    hlPreviewChanges.Visible = false;
                }

                else if (status == PortalEnums.DynamicPage.Status.Draft)
                {
                    ddlStatus.Items.Add(new ListItem("Save As Draft", ((int)PortalEnums.DynamicPage.Status.Draft).ToString(), true));
                    if (SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Contributor)
                    {
                        ddlStatus.Items.Add(new ListItem("Publish Live", ((int)PortalEnums.DynamicPage.Status.Published).ToString()));
                    }
                    else
                    {
                        ddlStatus.Items.Add(new ListItem("Submit For Review", ((int)PortalEnums.DynamicPage.Status.Pending).ToString()));
                    }

                    ddlStatus.SelectedValue = ((int)PortalEnums.DynamicPage.Status.Draft).ToString();
                    //lbSaveDraft.Visible = true;
                    phStatus.Visible = true;
                    hlPreviewChanges.Visible = true;
                }

                else if (status == PortalEnums.DynamicPage.Status.Pending)
                {
                    if (SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Contributor)
                    {
                        ddlStatus.Items.Add(new ListItem("Pending", ((int)PortalEnums.DynamicPage.Status.Pending).ToString(), true));
                        ddlStatus.Items.Add(new ListItem("Publish Live", ((int)PortalEnums.DynamicPage.Status.Published).ToString()));
                        ddlStatus.Items.Add(new ListItem("Decline", ((int)PortalEnums.DynamicPage.Status.Decline).ToString()));
                    }
                    else
                    {
                        ddlStatus.Items.Add(new ListItem("Submit For Review", ((int)PortalEnums.DynamicPage.Status.Pending).ToString(), true));
                        lbAdminUpdate.Visible = false;
                    }

                    ddlStatus.SelectedValue = ((int)PortalEnums.DynamicPage.Status.Pending).ToString();
                    lbSaveDraft.Visible = false;
                    phStatus.Visible = true;
                    hlPreviewChanges.Visible = true;
                }

                else if (status == PortalEnums.DynamicPage.Status.Published)
                {
                    ddlStatus.Items.Add(new ListItem("Save As Draft", ((int)PortalEnums.DynamicPage.Status.Draft).ToString(), true));

                    if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                    {
                        ddlStatus.Items.Add(new ListItem("Submit For Review", ((int)PortalEnums.DynamicPage.Status.Pending).ToString(), true));
                    }
                    else
                    {
                        ddlStatus.Items.Add(new ListItem("Publish Live", ((int)PortalEnums.DynamicPage.Status.Published).ToString(), true));
                    }

                    ddlStatus.SelectedValue = ((int)PortalEnums.DynamicPage.Status.Published).ToString();
                    //lbSaveDraft.Visible = true;
                    phStatus.Visible = true;
                    hlPreviewChanges.Visible = true;
                }
            }
        }

        private void LoadPublishedVisions()
        {
            string pagecode = StrPageName;
            int total = 0;

            if (RevisionCode != Guid.Empty)
            {
                TList<Entities.DynamicPageRevisions> pagerevisions = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode);
                if (pagerevisions.Count > 0)
                {
                    pagecode = pagerevisions[0].PageName;
                }

            }

            TList<Entities.DynamicPageRevisions> ds = DynamicPageRevisionsService.GetPaged(string.Format("SiteId = '{2}' AND PageName = '{0}' AND Status = 1 AND LanguageID = {1}", pagecode.Replace("'", "''"), SessionData.Site.DefaultLanguageId, SessionData.Site.SiteId), "DynamicPageRevisionID DESC", 0, 5, out total);
            ltRevisions.Text = total.ToString();
            //if (total > 5)
            //{
            //    ltRevisions.Text = "5";
            //}
            rptRevision.DataSource = ds;
            rptRevision.DataBind();
        }

        private void DisableFieldsForSystemPage()
        {
            if (CommonPage.PageName.ToLower().StartsWith("systempage"))
            {
                txtPageFriendlyName.Enabled = false;
                tbCustomUrl.Enabled = false;
                txtHyperlink.Enabled = false;
            }
        }

        protected void rptRevision_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Revert")
            {
                Response.Redirect("/admin/dynamicpagerevisions.aspx?revisioncode=" + e.CommandArgument);
            }

        }

        protected void rptRevision_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltRevisionDate = e.Item.FindControl("ltRevisionDate") as Literal;
                Literal ltRevisionBy = e.Item.FindControl("ltRevisionBy") as Literal;
                LinkButton lbRevisionRevert = e.Item.FindControl("lbRevisionRevert") as LinkButton;
                HyperLink hlRevisionView = e.Item.FindControl("hlRevisionView") as HyperLink;
                HtmlTableRow rowItem = e.Item.FindControl("rowItem") as HtmlTableRow;

                Entities.DynamicPageRevisions drv = e.Item.DataItem as Entities.DynamicPageRevisions;
                ltRevisionDate.Text = drv.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                AdminUsersService aus = new AdminUsersService();

                using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(drv.LastModifiedBy))
                {
                    ltRevisionBy.Text = adminuser.UserName;
                }

                if (RevisionCode != null && RevisionCode == drv.MappingId)
                    rowItem.Attributes["class"] = "selected";

                lbRevisionRevert.CommandArgument = drv.MappingId.ToString();
                hlRevisionView.NavigateUrl = "/pages/preview.aspx?revisioncode=" + drv.MappingId.ToString();
            }
        }

        private void InitVisiblilityBaseOnRoles()
        {
            if (SessionData.AdminUser != null)
            {
                bool isContributor = SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor;

                if (isContributor)
                {
                    //isContributor
                    phStatus.Visible = true;
                    phPublishSettings.Visible = true;
                    phVisibility.Visible = false;

                    phWidgets.Visible = false;
                    phRevision.Visible = false;

                    lbAdminUpdate.Text = "Submit";

                }
                else
                {
                    //other admin roles
                    phComment.Visible = true;

                    phStatus.Visible = true;
                    phPublishSettings.Visible = true;

                    lbAdminUpdate.Text = "Update";

                    DateTime dtNow = DateTime.Now;
                    ltPublishedOn.Text = dtNow.ToString("MMM dd, yyyy @ HH:mm");
                    ltVisibility.Text = "Public";
                    /*tbPublishedOnDay.Text = dtNow.Day.ToString();
                    ddlPublishedOnMonth.SelectedValue = dtNow.Month.ToString();
                    tbPublishedOnYear.Text = dtNow.Year.ToString();
                    tbPublishedOnHour.Text = dtNow.Hour.ToString();
                    tbPublishedOnMinute.Text = dtNow.Minute.ToString();*/

                    //Live pages can be deleted
                    bool isSystemPage = CommonPage.PageName.ToLower().StartsWith("systempage");
                    bool isRevision = RevisionCode != Guid.Empty;
                    bool isNewPage = String.IsNullOrEmpty(CommonPage.PageName) && !isRevision;
                    if (!isSystemPage && !isRevision && !isNewPage)
                    {
                        phDelete.Visible = true;
                    }

                }
            }
        }

        private void SetPanelVisiblility(bool isEditable)
        {
            SetPanelVisiblility(isEditable, false);
        }

        private void SetPanelVisiblility(bool isEditable, bool forceDisplayPublishedOn)
        {
            ltStatus.Visible = !isEditable;
            ltVisibility.Visible = !isEditable;

            if (forceDisplayPublishedOn)
            {
                ltPublishedOn.Visible = true;
                phPublishDate.Visible = false;
            }
            else
            {
                ltPublishedOn.Visible = !isEditable;
                phPublishDate.Visible = isEditable;
            }

            ddlStatus.Visible = isEditable;
            ddlVisibility.Visible = isEditable;
        }

        //Load LIVE page
        private void LoadDynamicPage()
        {
            bool found = false;

            if (!String.IsNullOrEmpty(CommonPage.PageName))
            {
                #region Load Page Details
                using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, CommonPage.PageName))
                {
                    foreach (JXTPortal.Entities.DynamicPages dynamicPage in dynamicPages)
                    {
                        if (dynamicPage.LanguageId == SessionData.Site.DefaultLanguageId)
                        {
                            found = true;
                            hlPreviewChanges.NavigateUrl = DynamicPagesService.GetDynamicPageUrl(dynamicPage);// "/pages/page.aspx?code=" + dynamicPage.PageFriendlyName.ToString();

                            txtPageName.Text = dynamicPage.PageName;
                            chkValid.Checked = dynamicPage.Valid;

                            string[] strPageNames2 = dynamicPage.PageFriendlyName.Split(new char[] { '/' });
                            string strPageName2 = strPageNames2[strPageNames2.Length - 1];
                            txtPageFriendlyName.Text = strPageName2;
                            tbCustomUrl.Text = dynamicPage.CustomUrl;
                            txtHyperlink.Text = dynamicPage.HyperLink;
                            cbOpenNewWindow.Checked = dynamicPage.OpenInNewWindow;
                            txtSequence.Text = dynamicPage.Sequence.ToString();
                            cbOnTopNav.Checked = dynamicPage.OnTopNav;
                            cbOnLeftNav.Checked = dynamicPage.OnLeftNav;
                            cbOnBottomNav.Checked = dynamicPage.OnBottomNav;
                            cbOnSiteMap.Checked = dynamicPage.OnSiteMap;
                            chkBreadcrumb.Checked = dynamicPage.GenerateBreadcrumb;

                            if (dynamicPage.Secured)
                                ddlVisibility.SelectedValue = ((int)PortalEnums.DynamicPage.Visiblity.Secured).ToString();
                            else
                                ddlVisibility.SelectedValue = (dynamicPage.Visible) ? ((int)PortalEnums.DynamicPage.Visiblity.Public).ToString() : ((int)PortalEnums.DynamicPage.Visiblity.Private).ToString();

                            //set visibility display (this is a display type, not DDL)
                            if ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId != PortalEnums.Admin.AdminRole.Administrator)
                            {
                                phVisibilityDisplay.Visible = true;
                                ltVisibilityDisplay.Text = ((PortalEnums.DynamicPage.Visiblity)int.Parse(ddlVisibility.SelectedValue)).ToString();
                            }

                            if (dynamicPage.PublishOn.HasValue)
                            {
                                txtPublishDate.Text = dynamicPage.PublishOn.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                                ltPublishedOn.Text = dynamicPage.PublishOn.Value.ToString("MMM dd, yyyy @ HH:mm");

                                /*tbPublishedOnDay.Text = dynamicPage.PublishOn.Value.Day.ToString();
                                ddlPublishedOnMonth.Text = dynamicPage.PublishOn.Value.Month.ToString();
                                tbPublishedOnYear.Text = dynamicPage.PublishOn.Value.Year.ToString();
                                tbPublishedOnHour.Text = dynamicPage.PublishOn.Value.Hour.ToString();
                                tbPublishedOnMinute.Text = dynamicPage.PublishOn.Value.Minute.ToString();*/
                            }
                            // Disable Page Code
                            txtPageName.Enabled = false;
                            ltLastModified.Text = dynamicPage.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                            AdminUsersService aus = new AdminUsersService();
                            using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(dynamicPage.LastModifiedBy))
                            {
                                ltLastModifiedBy.Text = adminuser.UserName;
                            }
                            LoadStatus(PortalEnums.DynamicPage.Status.Published);
                            if (ddlStatus.Items.Count > 0)
                            {
                                PortalEnums.DynamicPage.Status estatus = (PortalEnums.DynamicPage.Status)Convert.ToInt32(ddlStatus.SelectedValue);
                                ltStatus.Text = estatus.ToString();
                            }

                            PortalEnums.DynamicPage.Visiblity evis = (PortalEnums.DynamicPage.Visiblity)Convert.ToInt32(ddlVisibility.SelectedValue);
                            ltVisibility.Text = evis.ToString();

                            bool currentUserIsContributor = (PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId == PortalEnums.Admin.AdminRole.Contributor;
                            
                            SetPanelVisiblility(true, currentUserIsContributor);
                        }
                    }

                    //when it is a dynamic page, the comments section should never show
                    phComment.Visible = false;

                    #region Message Display (for any revisions available/exists)

                    // Display if the Live page has a Draft or a Pending Page 
                    if (dynamicPages != null && dynamicPages.Count > 0)
                    {

                        int total = 0;

                        //grab a list of related dynamic page REVISIONS for this dynamic page
                        using (TList<JXTPortal.Entities.DynamicPageRevisions> ds = DynamicPageRevisionsService.GetPaged(
                                    string.Format("SiteId = '{4}' AND PageName = '{0}' AND (Status = {2} or Status = {3}) AND LanguageID = {1}",
                                            CommonPage.PageName.Replace("'", "''"),
                                            SessionData.Site.DefaultLanguageId,
                                            (int)PortalEnums.DynamicPage.Status.Draft,
                                            (int)PortalEnums.DynamicPage.Status.Pending,
                                            SessionData.Site.SiteId), "LastModified DESC", 0, 5, out total))
                        {
                            if (ds != null && ds.Count > 0)
                            {

                                if (ds[0].Status == (int)PortalEnums.DynamicPage.Status.Pending)
                                {
                                    ltlMessage.Text = ltlMessage.Text = string.Format("<p class=\"msg warning\">This page content is currently LIVE - \"<strong>{0}</strong>\". And contains a Pending page - <a href=\"{1}\">click here to view</a></p>", ds[0].PageName, "/admin/dynamicpagerevisions.aspx?revisioncode=" + ds[0].MappingId);

                                    if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                                    {
                                        //if there is a pending page for the current page, contributors will NOT be able to modify anymore
                                        ltStatus.Visible = true;
                                        ltStatus.Text = "LIVE";
                                        ddlStatus.Visible = false;
                                        
                                        //hide ALL buttons
                                        plButtonsHolder.Visible = false;

                                    }
                                }
                                else if (ds[0].Status == (int)PortalEnums.DynamicPage.Status.Draft)
                                {
                                    // Draft
                                    if (ds[0].DynamicPageId == 0)
                                    {
                                        ltlMessage.Text = string.Format("<p class=\"msg info\">This page is currently Draft - \"<strong>{0}</strong>\".</p>", ds[0].PageName);
                                    }
                                    else
                                    {
                                        ltlMessage.Text = string.Format("<p class=\"msg warning\">This page content is currently LIVE - \"<strong>{0}</strong>\". And contains a Draft page - <a href=\"{1}\">click here to view</a></p>", ds[0].PageName, "/admin/dynamicpagerevisions.aspx?revisioncode=" + ds[0].MappingId);
                                    }
                                }

                            }
                        }

                    }
                    #endregion

                }
                #endregion
            }
            else
            {

                // For new dynamic page .. check the below by default.
                chkValid.Checked = true;
                cbOnTopNav.Checked = true;
                cbOnSiteMap.Checked = true;

                //hide comments, published on
                phComment.Visible = false;

            }

            if (!found)
            {
                hlPreviewChanges.Visible = false;
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete Dynamic Pages for Site
                string pName = CommonPage.PageName;
                if (string.IsNullOrEmpty(pName)) pName = hfCode.Value;

                if (!String.IsNullOrEmpty(pName))
                {
                    using (TList<JXTPortal.Entities.DynamicPages> sitepages = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId))
                    using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, StrPageName))
                    {
                        if (dynamicpages.Count > 0)
                        {
                            // Check if there is any child pages
                            foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
                            {
                                sitepages.Filter = "ParentDynamicPageID = " + dynamicpage.DynamicPageId.ToString();
                                if (sitepages.Count > 0)
                                {
                                    ltlMessage.Text = "<p class=\"msg error\">This page cannot be delete as it contains child pages</p>";

                                    return;
                                }
                            }

                            for (int i = 0; i < dynamicpages.Count; i++)
                            {
                                TList<GlobalSettings> gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
                                if (gs.Count > 0 && gs[0].DefaultDynamicPageId == dynamicpages[i].DynamicPageId)
                                {
                                    dynamicpages[i].DynamicPageId = 0;
                                    DynamicPagesService.Update(dynamicpages[i]);
                                }

                                TList<DynamicpagesCustomWidget> customwidgets = DynamicpagesCustomWidgetService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
                                foreach (DynamicpagesCustomWidget customwidget in customwidgets)
                                {
                                    DynamicpagesCustomWidgetService.Delete(customwidget);
                                }

                                TList<RelatedDynamicPages> relatedpages = RelatedDynamicPagesService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
                                foreach (RelatedDynamicPages relatedpage in relatedpages)
                                {
                                    RelatedDynamicPagesService.Delete(relatedpage);
                                }

                                relatedpages = RelatedDynamicPagesService.GetByRelatedDynamicPageId(dynamicpages[i].DynamicPageId);
                                foreach (RelatedDynamicPages relatedpage in relatedpages)
                                {
                                    RelatedDynamicPagesService.Delete(relatedpage);
                                }

                                DynamicPagesService.Delete(dynamicpages[i].DynamicPageId);

                            }

                            Response.Redirect("dynamicpages.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }

        private void LoadPageRevision()
        {
            bool found = false;

            if (RevisionCode != Guid.Empty)
            {
                PortalEnums.DynamicPage.Status thisPageStatus;

                #region Set fields with revision record
                using (TList<JXTPortal.Entities.DynamicPageRevisions> dynamicPages = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode))
                {
                    //check if the revision code is valid and there is an existing page with that code
                    if (dynamicPages.Count() == 0)
                    {
                        Response.Redirect("/admin/dynamicpagerev.aspx");
                        return;
                    }

                    thisPageStatus = (PortalEnums.DynamicPage.Status)dynamicPages.First().Status;

                    foreach (JXTPortal.Entities.DynamicPageRevisions dynamicPage in dynamicPages)
                    {
                        if (dynamicPage.LanguageId == SessionData.Site.DefaultLanguageId)
                        {
                            found = true;
                            hlPreviewChanges.NavigateUrl = "/pages/preview.aspx?revisioncode=" + RevisionCode.ToString();
                            txtPageName.Text = dynamicPage.PageName;
                            chkValid.Checked = dynamicPage.Valid;

                            string[] strPageNames2 = dynamicPage.PageFriendlyName.Split(new char[] { '/' });
                            string strPageName2 = strPageNames2[strPageNames2.Length - 1];
                            txtPageFriendlyName.Text = strPageName2;
                            tbCustomUrl.Text = dynamicPage.CustomUrl;
                            txtHyperlink.Text = dynamicPage.HyperLink;
                            cbOpenNewWindow.Checked = dynamicPage.OpenInNewWindow;
                            txtSequence.Text = dynamicPage.Sequence.ToString();
                            cbOnTopNav.Checked = dynamicPage.OnTopNav;
                            cbOnLeftNav.Checked = dynamicPage.OnLeftNav;
                            cbOnBottomNav.Checked = dynamicPage.OnBottomNav;
                            cbOnSiteMap.Checked = dynamicPage.OnSiteMap;

                            chkBreadcrumb.Checked = dynamicPage.GenerateBreadcrumb;

                            if (dynamicPage.Secured)
                                ddlVisibility.SelectedValue = ((int)PortalEnums.DynamicPage.Visiblity.Secured).ToString();
                            else
                                ddlVisibility.SelectedValue = (dynamicPage.Visible) ? ((int)PortalEnums.DynamicPage.Visiblity.Public).ToString() : ((int)PortalEnums.DynamicPage.Visiblity.Private).ToString();

                            //set visibility display (this is a display type, not DDL)
                            ltVisibilityDisplay.Text = ((PortalEnums.DynamicPage.Visiblity)int.Parse(ddlVisibility.SelectedValue)).ToString();

                            if (dynamicPage.PublishOn.HasValue)
                            {
                                txtPublishDate.Text = dynamicPage.PublishOn.Value.ToString();
                                ltPublishedOn.Text = dynamicPage.PublishOn.Value.ToString("MMM dd, yyyy @ HH:mm");

                                /*tbPublishedOnDay.Text = dynamicPage.PublishOn.Value.Day.ToString();
                                ddlPublishedOnMonth.Text = dynamicPage.PublishOn.Value.Month.ToString();
                                tbPublishedOnYear.Text = dynamicPage.PublishOn.Value.Year.ToString();
                                tbPublishedOnHour.Text = dynamicPage.PublishOn.Value.Hour.ToString();
                                tbPublishedOnMinute.Text = dynamicPage.PublishOn.Value.Minute.ToString();*/
                            }

                            //display comments section if there are comments
                            if (!string.IsNullOrEmpty(dynamicPage.Comment))
                            {
                                phCommentDisplay.Visible = true;
                                ltCommentDisplay.Text = dynamicPage.Comment;
                                tbComment.Text = dynamicPage.Comment;
                            }

                            ltLastModified.Text = dynamicPage.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                            AdminUsersService aus = new AdminUsersService();
                            using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(dynamicPage.LastModifiedBy))
                            {
                                ltLastModifiedBy.Text = adminuser.UserName;
                            }

                            //set comment text box visibility
                            if (SessionData.AdminUser != null)
                            {
                                if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
                                {
                                    phComment.Visible = true;
                                }
                                else
                                {
                                    phComment.Visible = false;
                                }
                            }

                            LoadStatus((PortalEnums.DynamicPage.Status)dynamicPage.Status);


                            if (ddlStatus.Items.Count > 0)
                            {
                                PortalEnums.DynamicPage.Status estatus = (PortalEnums.DynamicPage.Status)Convert.ToInt32(ddlStatus.SelectedValue);
                                ltStatus.Text = estatus.ToString();
                            }

                            PortalEnums.DynamicPage.Visiblity evis = (PortalEnums.DynamicPage.Visiblity)Convert.ToInt32(ddlVisibility.SelectedValue);
                            ltVisibility.Text = evis.ToString();

                            // Disable Page Code
                            txtPageName.Enabled = false;


                            if (SessionData.AdminUser != null)
                            {
                                // TODO - check if the dynamicPage.DynamicPageId exists in dynamic page.

                                if (dynamicPage.Status == (int)PortalEnums.DynamicPage.Status.Published)
                                {
                                    // Published
                                    ltlMessage.Text = string.Format("<p class=\"msg info\">You are currently reviewing Revision \"<strong>{0} @ {1}</strong>\". To view the LIVE page content, <a href=\"{2}\">click here</a></p>", dynamicPage.LastModified.ToString(SessionData.Site.DateFormat), dynamicPage.LastModified.ToString("HH:mm"), "/admin/dynamicpagerevisions.aspx?code=" + HttpUtility.UrlEncode(dynamicPage.PageName));

                                    hlRevert.NavigateUrl = "/admin/dynamicpagerevisions.aspx?revisioncode=" + RevisionCode + "&revert=1";

                                    lbSaveDraft.Visible = false;
                                    ddlStatus.Enabled = false;
                                    lbAdminUpdate.Visible = false;
                                    hlRevert.Visible = true;

                                    if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                                    {
                                        // Contributor has no access to published revision
                                        Response.Redirect("/admin/DynamicPages.aspx");
                                    }
                                    else
                                    {
                                        if (Revert)
                                        {
                                            DynamicPageRevisionsService.CustomRevertPage(RevisionCode);
                                            Response.Redirect("/admin/dynamicpagerevisions.aspx?code=" + HttpUtility.UrlEncode(dynamicPage.PageName) + "&msg=2");
                                        }
                                    }

                                    SetPanelVisiblility(false);
                                }
                                else if (dynamicPage.Status == (int)PortalEnums.DynamicPage.Status.Pending)
                                {
                                    // Pending
                                    if (dynamicPage.DynamicPageId == 0)
                                    {
                                        ltlMessage.Text = ltlMessage.Text = string.Format("<p class=\"msg info\">This page is currently under review - \"<strong>{0}</strong>\".</p>", dynamicPage.PageName);
                                    }
                                    else
                                    {
                                        ltlMessage.Text = ltlMessage.Text = string.Format("<p class=\"msg info\">This page is currently under review - \"<strong>{0}</strong>\". To view the current page, <a href=\"{1}\">click here</a></p>", dynamicPage.PageName, "/admin/dynamicpagerevisions.aspx?code=" + HttpUtility.UrlEncode(dynamicPage.PageName));
                                    }

                                    if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                                    {
                                        lbSaveDraft.Visible = false;

                                        SetPanelVisiblility(false);
                                    }
                                    else
                                    {
                                        SetPanelVisiblility(true);
                                    }
                                }
                                else if (dynamicPage.Status == (int)PortalEnums.DynamicPage.Status.Draft)
                                {
                                    // Draft
                                    if (dynamicPage.DynamicPageId == 0)
                                    {
                                        ltlMessage.Text = string.Format("<p class=\"msg info\">This page is currently Draft - \"<strong>{0}</strong>\".</p>", dynamicPage.PageName);
                                    }
                                    else
                                    {
                                        ltlMessage.Text = string.Format("<p class=\"msg info\">This page is currently Draft - \"<strong>{0}</strong>\". To view the current LIVE content, <a href=\"{1}\">click here</a></p>", dynamicPage.PageName, "/admin/dynamicpagerevisions.aspx?code=" + HttpUtility.UrlEncode(dynamicPage.PageName));
                                    }
                                    SetPanelVisiblility(true);
                                }
                            }

                            break;


                        }
                    }

                    //change logs
                    plDetectedChanges.Visible = true;
                    string changes = CompareDynamicPages(dynamicPages.ToList());
                    ltDetectedChanges.Text = changes;

                }
                #endregion

                //set publish settings base on the status of this dynamic page
                switch (thisPageStatus)
                {
                    case PortalEnums.DynamicPage.Status.None:
                        phComment.Visible = false;
                        break;
                    case PortalEnums.DynamicPage.Status.Published:
                        if ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId != PortalEnums.Admin.AdminRole.Administrator)
                        {
                            phVisibilityDisplay.Visible = true;
                        }
                        phComment.Visible = false;
                        break;
                    case PortalEnums.DynamicPage.Status.Pending:
                        break;
                    case PortalEnums.DynamicPage.Status.Draft:
                        phComment.Visible = false;
                        break;
                    case PortalEnums.DynamicPage.Status.Decline:
                        break;
                    case PortalEnums.DynamicPage.Status.Approved:
                        phComment.Visible = false;
                        break;
                    default:
                        break;
                }

            }
            else
            {
                // For new dynamic page .. check the below by default.
                chkValid.Checked = true;
                cbOnTopNav.Checked = true;
                cbOnSiteMap.Checked = true;
            }

            if (!found && RevisionCode != Guid.Empty)
            {
                hlPreviewChanges.Visible = false;
                Response.Redirect("/admin/dynamicpagerevisions.aspx");
            }
        }

        private void LoadSiteLanguages()
        {
            rptDynamicPages.DataSource = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            rptDynamicPages.DataBind();
        }

        private void LoadCSSFiles()
        {
            //get by siteid and filetypeid
            // - Temp siteRepeaterCSSFile.DataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, String.Empty, Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));
            // - Temp siteRepeaterCSSFile.DataTextField = "FileName";
            // - Temp siteRepeaterCSSFile.DataValueField = "FileId";
            // - Temp siteRepeaterCSSFile.HeaderName = "Please Select CSS File";
            // - Temp 
            // - Temp siteRepeaterCSSFile.SiteDataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, txtPageName.Text,
            // - Temp Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));
            // - Temp siteRepeaterCSSFile.SiteDataValueField = "FileId";
            // - Temp siteRepeaterCSSFile.Bind();

            // - Temp _oldSelectedCSSFiles = siteRepeaterCSSFile.SelectedValues;
        }

        private void LoadJavascriptFiles()
        {
            //get by siteid and filetypeid
            // - Temp siteRepeaterJavascriptFile.DataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, String.Empty,
            // - Temp                                                                                     Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));
            // - Temp siteRepeaterJavascriptFile.DataTextField = "FileName";
            // - Temp siteRepeaterJavascriptFile.DataValueField = "FileId";
            // - Temp siteRepeaterJavascriptFile.HeaderName = "Please Select Javascript File";

            // - Temp siteRepeaterJavascriptFile.SiteDataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, txtPageName.Text,
            // - Temp                                                                                         Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));
            // - Temp siteRepeaterJavascriptFile.SiteDataValueField = "FileId";
            // - Temp siteRepeaterJavascriptFile.Bind();

            // - Temp _oldSelectedJSFiles = siteRepeaterJavascriptFile.SelectedValues;
        }

        private void LoadMessageDisplays()
        {
            if (Request["msg"] != null)
            {
                if (Request["msg"] == "1")
                {
                    ltlMessageSave.Text = "<p class=\"msg done\">Contents have been updated successfully.</p>";
                }

                if (Request["msg"] == "2")
                {
                    ltlMessageSave.Text = "<p class=\"msg done\">A new revision has been created and the live contents have been successfully reverted to the selected revision.</p>";
                }

            }


        }

        /// <summary>
        /// Load Javascript to Fix the bug Ajax-Javascript
        /// </summary>
        private void LoadJavascript()
        {
            int index = 1;
            int defaultid = 0;
            StringBuilder relateddedaultpagelist = new StringBuilder();
            StringBuilder relatedselectedpagelist = new StringBuilder();

            using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, 0, null, true, true))
            {
                foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
                {
                    if (dynamicpage.ParentDynamicPageId != 0 && dynamicpage.PageName != txtPageName.Text)
                    {
                        int lvlcount = dynamicpage.PageFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

                        for (int i = 0; i < lvlcount; i++)
                        {
                            dynamicpage.PageTitle = string.Format(" - {0}", dynamicpage.PageTitle);
                        }
                    }
                    if (dynamicpage.Valid && dynamicpage.PageName != txtPageName.Text)
                    {

                        relateddedaultpagelist.AppendLine("{id:" + dynamicpage.DynamicPageId.ToString() + ",text:\"" + dynamicpage.PageTitle.Replace("\"","\\\"") + "\"},");
                    }
                }

            }

            for (int i = 0; i < rptDynamicPages.Items.Count; i++)
            {
                if (((DynamicPageRevisionsFields)((RepeaterItem)rptDynamicPages.Items[i]).FindControl("ucDynamicPage")).LanguageID == SessionData.Site.DefaultLanguageId)
                {
                    defaultid = ((DynamicPageRevisionsFields)((RepeaterItem)rptDynamicPages.Items[i]).FindControl("ucDynamicPage")).DynamicPageID;
                    index = i + 1;
                    break;
                }
            }

            if (defaultid > 0)
            {
                DataSet ds = RelatedDynamicPagesService.CustomGetByDynamicPageID(defaultid);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    relatedselectedpagelist.Append(dr["RelatedDynamicPageID"].ToString() + ",");
                }
            }


            string relatedscript = @" var ddlRelatedDynamicPages = $('#ddlRelatedDynamicPages');
                                $(ddlRelatedDynamicPages).val([" + relatedselectedpagelist.ToString().TrimEnd(new char[] { ',' });
            relatedscript += @"]).select2({
                                data:[
                                  " + relateddedaultpagelist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
            relatedscript += @"],
                                placeholder: 'Select a Related Dynamic Page',
                                multiple: true,
                                width: ""100%""
                               
                });
                $(ddlRelatedDynamicPages).change(function() {
                                var ids = $(ddlRelatedDynamicPages).val();
                                var selections = ( JSON.stringify($(ddlRelatedDynamicPages).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";


            StringBuilder columndefaultlist = new StringBuilder();
            StringBuilder leftcolumnselectedlist = new StringBuilder();
            StringBuilder rightcolumnselectedlist = new StringBuilder();

            TList<JXTPortal.Entities.CustomWidget> customwidgets = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);
            if (customwidgets.Count > 0)
            {
                foreach (JXTPortal.Entities.CustomWidget customwidget in customwidgets)
                {
                    if (customwidget.Active)
                    {
                        columndefaultlist.AppendLine("{id:" + customwidget.CustomWidgetId.ToString() + ",text:\"" + customwidget.CustomWidgetName.Replace("\"", "\\\"") + "\"},");
                    }
                }
            }
            if (defaultid > 0)
            {
                DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(defaultid, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        leftcolumnselectedlist.Append(dr["CustomWidgetID"].ToString() + ",");
                    }
                }

                ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(defaultid, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        rightcolumnselectedlist.Append(dr["CustomWidgetID"].ToString() + ",");
                    }
                }
            }

            string leftcolumnscript = @" var ddlLeftColumn = $('#ddlLeftColumn');
                                $(ddlLeftColumn).val([" + leftcolumnselectedlist.ToString().TrimEnd(new char[] { ',' });
            leftcolumnscript += @"]).select2({
                                data:[
                                  " + columndefaultlist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
            leftcolumnscript += @"],
                                placeholder: 'Select a Custom Widget',
                                multiple: true,
                                width: ""100%""
                               
                });
                $(ddlLeftColumn).change(function() {
                                var ids = $(ddlLeftColumn).val();
                                var selections = ( JSON.stringify($(ddlLeftColumn).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";

            string rightcolumnscript = @" var ddlrightColumn = $('#ddlRightColumn');
                                $(ddlrightColumn).val([" + rightcolumnselectedlist.ToString().TrimEnd(new char[] { ',' });
            rightcolumnscript += @"]).select2({
                                data:[
                                  " + columndefaultlist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
            rightcolumnscript += @"],
                                placeholder: 'Select a Custom Widget',
                                multiple: true,
                                width: ""100%""
                               
                });
                $(ddlrightColumn).change(function() {
                                var ids = $(ddlrightColumn).val();
                                var selections = ( JSON.stringify($(ddlrightColumn).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptToWork", @"
                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                            <script type='text/javascript'>
                                $().ready(function() {
                                    $('#coda-slider-1').codaSlider({
                                        dynamicArrows: false,
                                        autoHeight: true,
                                        firstPanelToLoad: " + index + @"
                                    });

                                    " + relatedscript + @"
                                    " + leftcolumnscript + @"
                                    " + rightcolumnscript + @"
 
                                });

                            </script>

                            ", false);
        }


        #endregion

        #region Repeater DataBinds

        protected void rptDynamicPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DynamicPageRevisionsFields ucDynamicPage = (DynamicPageRevisionsFields)e.Item.FindControl("ucDynamicPage");
                Literal litLanguageName = (Literal)e.Item.FindControl("litLanguageName");

                JXTPortal.Entities.SiteLanguages siteLanguage = (JXTPortal.Entities.SiteLanguages)e.Item.DataItem;
                litLanguageName.Text = siteLanguage.SiteLanguageName;
                ucDynamicPage.LanguageID = siteLanguage.LanguageId;

                // Load the Dynamic Page of the Language 
                ucDynamicPage.LoadListAndDynamicPage();
            }
        }

        protected void rptDynamicPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //            bool valid = true;


            //            if (e.CommandName == "Save" || e.CommandName == "Apply")
            //            {
            //                JXTPortal.Entities.DynamicPages dynamicPage = new JXTPortal.Entities.DynamicPages();

            //                if (!string.IsNullOrEmpty(hfCode.Value))
            //                {
            //                    TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, hfCode.Value);
            //                    if (dynamicPages.Count > 0)
            //                    {
            //                        dynamicPage = dynamicPages[0];
            //                    }
            //                }

            //                dynamicPage.PageName = txtPageName.Text.Trim();
            //                dynamicPage.Valid = chkValid.Checked;
            //                dynamicPage.PageFriendlyName = txtPageFriendlyName.Text.Trim();
            //                dynamicPage.CustomUrl = tbCustomUrl.Text.Trim().ToLower();
            //                dynamicPage.HyperLink = txtHyperlink.Text;
            //                dynamicPage.OpenInNewWindow = cbOpenNewWindow.Checked;
            //                dynamicPage.Sequence = Convert.ToInt32(txtSequence.Text);
            //                dynamicPage.OnTopNav = cbOnTopNav.Checked;
            //                dynamicPage.OnLeftNav = cbOnLeftNav.Checked;
            //                dynamicPage.OnBottomNav = cbOnBottomNav.Checked;
            //                dynamicPage.OnSiteMap = cbOnSiteMap.Checked;
            //                dynamicPage.Secured = chkSecured.Checked;
            //                dynamicPage.GenerateBreadcrumb = chkBreadcrumb.Checked;

            //                StringBuilder relateddedaultpagelist = new StringBuilder();

            //                using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, 0, null, true))
            //                {
            //                    foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
            //                    {
            //                        if (dynamicpage.ParentDynamicPageId != 0 && dynamicpage.PageName != txtPageName.Text)
            //                        {
            //                            int lvlcount = dynamicpage.PageFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

            //                            for (int i = 0; i < lvlcount; i++)
            //                            {
            //                                dynamicpage.PageTitle = string.Format(" - {0}", dynamicpage.PageTitle);
            //                            }
            //                        }
            //                        if (dynamicpage.Valid && dynamicpage.PageName != txtPageName.Text)
            //                        {

            //                            relateddedaultpagelist.AppendLine("{id:" + dynamicpage.DynamicPageId.ToString() + ",text:\"" + dynamicpage.PageTitle + "\"},");
            //                        }
            //                    }

            //                }

            //                StringBuilder columndefaultlist = new StringBuilder();

            //                TList<JXTPortal.Entities.CustomWidget> customwidgets = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);
            //                if (customwidgets.Count > 0)
            //                {
            //                    foreach (JXTPortal.Entities.CustomWidget customwidget in customwidgets)
            //                    {
            //                        if (customwidget.Active)
            //                        {
            //                            columndefaultlist.AppendLine("{id:" + customwidget.CustomWidgetId.ToString() + ",text:\"" + customwidget.CustomWidgetName + "\"},");
            //                        }
            //                    }
            //                }

            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "AssignRelatedPages", @"
            //                                            <script type='text/javascript'>
            //                                               $('#ddlRelatedDynamicPages').val([" + ddlRelatedDynamicPages.Value + @"]).select2({ 
            //                                                data:[
            //                                                " + relateddedaultpagelist.ToString().TrimEnd(new char[] { ',' }) + @"],
            //                                                placeholder: 'Select a Related Dynamic Page', width: '500px', multiple: true});
            //                                               $(ddlRelatedDynamicPages).change(function() {
            //                                                var ids = $(ddlRelatedDynamicPages).val();
            //                                                var selections = ( JSON.stringify($(ddlRelatedDynamicPages).select2('data')) );
            //                                                console.log('Selected options: ' + selections);
            //                                                });
            //
            //                                               $('#ddlLeftColumn').val([" + ddlLeftColumn.Value + @"]).select2({ 
            //                                                data:[
            //                                                " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
            //                                                placeholder: 'Select a Related Custom Widget', width: '500px', multiple: true});
            //                                               $(ddlLeftColumn).change(function() {
            //                                                var ids = $(ddlLeftColumn).val();
            //                                                var selections = ( JSON.stringify($(ddlLeftColumn).select2('data')) );
            //                                                console.log('Selected options: ' + selections);
            //                                                });
            //
            //                                               $('#ddlRightColumn').val([" + ddlRightColumn.Value + @"]).select2({ 
            //                                                data:[
            //                                                " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
            //                                                placeholder: 'Select a Related Custom Widget', width: '500px', multiple: true});
            //                                               $(ddlRightColumn).change(function() {
            //                                                var ids = $(ddlRightColumn).val();
            //                                                var selections = ( JSON.stringify($(ddlRightColumn).select2('data')) );
            //                                                console.log('Selected options: ' + selections);
            //                                                });
            //                                            </script>
            //
            //                                            ", false);

            //                try
            //                {
            //                    int isvalidno = -1;

            //                    for (int i = 0; i < rptDynamicPages.Items.Count; i++)
            //                    {
            //                        RepeaterItem item = rptDynamicPages.Items[i];
            //                        DynamicPagesFieldsList ucDynamicPage = (DynamicPagesFieldsList)item.FindControl("ucDynamicPage");

            //                        if (!ucDynamicPage.Validate())
            //                        {
            //                            if (isvalidno == -1)
            //                            {
            //                                isvalidno = i;
            //                            }
            //                        }
            //                    }

            //                    if (isvalidno != -1)
            //                    {
            //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
            //                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
            //                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
            //                                            <script type='text/javascript'>
            //                                                     $('#coda-slider-1').codaSlider({
            //                                                        dynamicArrows: false,
            //                                                        autoHeight: true
            //                                                    });
            //
            //                                                   $('.tab" + (isvalidno + 1).ToString() + @" a').click();
            //
            //                                            </script>
            //
            //                                            ", false);
            //                        return;
            //                    }

            //                    for (int i = 0; i < rptDynamicPages.Items.Count; i++)
            //                    {
            //                        RepeaterItem item = rptDynamicPages.Items[i];
            //                        DynamicPagesFieldsList ucDynamicPage = (DynamicPagesFieldsList)item.FindControl("ucDynamicPage");

            //                        ucDynamicPage.DynamicPageEntity = dynamicPage;

            //                        // Saving Related Dynamic Pages
            //                        string selecteddynamicpages = hfRelatedDynamicPages.Value;


            //                        // Display error message if dynamic pages saving has error
            //                        string errormessage = string.Empty;
            //                        if (!ucDynamicPage.Save(out errormessage))
            //                        {
            //                            if (valid)
            //                            {
            //                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
            //                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
            //                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
            //                                            <script type='text/javascript'>
            //                                                 $('#coda-slider-1').codaSlider({
            //                                                        dynamicArrows: false,
            //                                                        autoHeight: true
            //                                                    });
            //
            //                                                   $('.tab" + (i + 1).ToString() + @" a').click();
            //
            //                                            </script>
            //
            //                                            ", false);
            //                            }
            //                            ltlMessage.Text = errormessage;
            //                            valid = false;
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            int dpid = ucDynamicPage.DynamicPageID;
            //                            int langid = ucDynamicPage.LanguageID;

            //                            RelatedDynamicPagesService.CustomModify(dpid, ddlRelatedDynamicPages.Value);


            //                            string[] splits = ddlLeftColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //                            DataSet leftcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
            //                            if (leftcolumnlist != null && leftcolumnlist.Tables[0].Rows.Count > 0)
            //                            {
            //                                foreach (DataRow dr in leftcolumnlist.Tables[0].Rows)
            //                                {
            //                                    bool found = false;
            //                                    string customwidgetid = dr["CustomWidgetID"].ToString();
            //                                    foreach (string s in splits)
            //                                    {
            //                                        if (s == customwidgetid)
            //                                        {
            //                                            found = true;
            //                                            break;
            //                                        }
            //                                    }

            //                                    if (!found)
            //                                    {
            //                                        DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
            //                                    }
            //                                }
            //                            }


            //                            for (int index = 0; index < splits.Length; index++)
            //                            {
            //                                TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
            //                                if (dpcwlist.Count > 0)
            //                                {
            //                                    DynamicpagesCustomWidget dpcw = dpcwlist[0];
            //                                    dpcw.Sequence = index + 1;
            //                                    DynamicpagesCustomWidgetService.Update(dpcw);
            //                                }
            //                                else
            //                                {
            //                                    DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
            //                                    dpcw.DynamicPageId = dpid;
            //                                    dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
            //                                    dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column;
            //                                    dpcw.Sequence = index + 1;
            //                                    DynamicpagesCustomWidgetService.Insert(dpcw);
            //                                }
            //                            }

            //                            splits = ddlRightColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //                            DataSet rightcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
            //                            if (rightcolumnlist != null && rightcolumnlist.Tables[0].Rows.Count > 0)
            //                            {
            //                                foreach (DataRow dr in rightcolumnlist.Tables[0].Rows)
            //                                {
            //                                    bool found = false;
            //                                    string customwidgetid = dr["CustomWidgetID"].ToString();
            //                                    foreach (string s in splits)
            //                                    {
            //                                        if (s == customwidgetid)
            //                                        {
            //                                            found = true;
            //                                            break;
            //                                        }
            //                                    }

            //                                    if (!found)
            //                                    {
            //                                        DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
            //                                    }
            //                                }
            //                            }

            //                            for (int index = 0; index < splits.Length; index++)
            //                            {
            //                                TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
            //                                if (dpcwlist.Count > 0)
            //                                {
            //                                    DynamicpagesCustomWidget dpcw = dpcwlist[0];
            //                                    dpcw.Sequence = index + 1;
            //                                    DynamicpagesCustomWidgetService.Update(dpcw);
            //                                }
            //                                else
            //                                {
            //                                    DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
            //                                    dpcw.DynamicPageId = dpid;
            //                                    dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
            //                                    dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column;
            //                                    dpcw.Sequence = index + 1;
            //                                    DynamicpagesCustomWidgetService.Insert(dpcw);
            //                                }
            //                            }
            //                        }

            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    ltlMessage.Text = ex.Message + "<br>" + ex.StackTrace;
            //                    return;
            //                }

            //                if (valid)
            //                {
            //                    //TODO:
            //                    //save css?or js?
            //                    //the control return List<int>
            //                    List<int> dynamicCSSList = siteRepeaterCSSFile.SelectedValues;
            //                    List<int> dynamicJavascriptList = siteRepeaterJavascriptFile.SelectedValues;

            //                    int? _tempDynamicID = 0;

            //                    // Save CSS
            //                    if (pnlCSSJS.Visible && (!CommonFunction.CompareLists(_oldSelectedCSSFiles, dynamicCSSList) || (!CommonFunction.CompareLists(_oldSelectedJSFiles, dynamicJavascriptList))))
            //                    {
            //                        string pName = CommonPage.PageName;
            //                        if (string.IsNullOrEmpty(pName)) pName = hfCode.Value;

            //                        if (!String.IsNullOrEmpty(pName))
            //                        {
            //                            using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, pName))
            //                            {
            //                                if (dynamicPages.Count > 0)
            //                                {
            //                                    // only for one language
            //                                    foreach (JXTPortal.Entities.DynamicPages dp in dynamicPages)
            //                                    {
            //                                        using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
            //                                            DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, dp.LanguageId, dp.DynamicPageId, null, null))
            //                                        {

            //                                            if (DynamicPagesList.Count > 0)
            //                                            {
            //                                                foreach (JXTPortal.Entities.DynamicPages _DynamicPagesList in DynamicPagesList)
            //                                                {
            //                                                    // Delete All CSS file links for the Dynamic Page

            //                                                    //if (_DynamicPagesList.DynamicPageId != dp.DynamicPageId)
            //                                                    {

            //                                                        if (!CommonFunction.CompareLists(_oldSelectedCSSFiles, dynamicCSSList))
            //                                                        {
            //                                                            DynamicPageFilesService.DeleteBySiteIDPageName(SessionData.Site.SiteId, _DynamicPagesList.PageName, Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));

            //                                                            foreach (int fileID in dynamicCSSList)
            //                                                            {
            //                                                                DynamicPageFilesService.Insert(SessionData.Site.SiteId, _DynamicPagesList.PageName, fileID, ref _tempDynamicID);
            //                                                            }
            //                                                        }

            //                                                        // Save Javascript
            //                                                        if (!CommonFunction.CompareLists(_oldSelectedJSFiles, dynamicJavascriptList))
            //                                                        {
            //                                                            DynamicPageFilesService.DeleteBySiteIDPageName(SessionData.Site.SiteId, _DynamicPagesList.PageName, Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));

            //                                                            foreach (int fileID in dynamicJavascriptList)
            //                                                            {
            //                                                                DynamicPageFilesService.Insert(SessionData.Site.SiteId, _DynamicPagesList.PageName, fileID, ref _tempDynamicID);
            //                                                            }
            //                                                        }
            //                                                    }

            //                                                }

            //                                                break;
            //                                            }
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }

            //                    }
            //                    hfCode.Value = txtPageName.Text;

            //                    ltlMessage.Text = "Dynamic page has been saved";

            //                    if (e.CommandName == "Save")
            //                        Response.Redirect("dynamicpages.aspx");



            //                }
            //            }
            //            else if (e.CommandName == "Delete")
            //            {
            //                // Delete Dynamic Pages for Site
            //                string pName = CommonPage.PageName;
            //                if (string.IsNullOrEmpty(pName)) pName = hfCode.Value;

            //                if (!String.IsNullOrEmpty(pName))
            //                {
            //                    using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, StrPageName))
            //                    {
            //                        if (dynamicpages.Count > 0)
            //                        {

            //                            for (int i = 0; i < dynamicpages.Count; i++)
            //                            {
            //                                TList<GlobalSettings> gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
            //                                if (gs.Count > 0 && gs[0].DefaultDynamicPageId == dynamicpages[i].DynamicPageId)
            //                                {
            //                                    dynamicpages[i].DynamicPageId = 0;
            //                                    DynamicPagesService.Update(dynamicpages[i]);
            //                                }

            //                                TList<DynamicpagesCustomWidget> customwidgets = DynamicpagesCustomWidgetService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
            //                                foreach (DynamicpagesCustomWidget customwidget in customwidgets)
            //                                {
            //                                    DynamicpagesCustomWidgetService.Delete(customwidget);
            //                                }

            //                                TList<RelatedDynamicPages> relatedpages = RelatedDynamicPagesService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
            //                                foreach (RelatedDynamicPages relatedpage in relatedpages)
            //                                {
            //                                    RelatedDynamicPagesService.Delete(relatedpage);
            //                                }

            //                                relatedpages = RelatedDynamicPagesService.GetByRelatedDynamicPageId(dynamicpages[i].DynamicPageId);
            //                                foreach (RelatedDynamicPages relatedpage in relatedpages)
            //                                {
            //                                    RelatedDynamicPagesService.Delete(relatedpage);
            //                                }

            //                                DynamicPagesService.Delete(dynamicpages[i].DynamicPageId);

            //                            }

            //                            Response.Redirect("dynamicpages.aspx");
            //                        }
            //                    }
            //                }
            //            }

            //if (valid)
            //    
        }

        #endregion

        public DynamicPageRevisions()
        {
        }

        protected void CusVal_PageName_ServerValidate(object source, ServerValidateEventArgs args)
        { 
            char[] invalidchars = new char[] { '+', '/', '?', '%', '#', '&', '\'' };

            foreach (char c in invalidchars)
            {
                if (txtPageName.Text.Contains(c.ToString()))
                {
                    CusVal_PageName.ErrorMessage = "Unique Page Code contains invalid character(s). (+ / ? % # & ')";

                    args.IsValid = false;
                    return;
                }
            }

            string sOut = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(txtPageName.Text));
            if (sOut != txtPageName.Text)
            {
                CusVal_PageName.ErrorMessage = "Unique Page Code contains non-english character(s).";

                args.IsValid = false;
                return;
            }


            if (string.IsNullOrEmpty(StrPageName) && RevisionCode == Guid.Empty && string.IsNullOrEmpty(hfCode.Value))
            {
                TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, txtPageName.Text.Trim());

                if (dynamicpages.Count > 0)
                {
                    CusVal_PageName.ErrorMessage = "Unique Page Code already exists.";

                    args.IsValid = false;
                    return;
                }
            }
        }

        protected void CusVal_tbCustomUrl_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string customurl = tbCustomUrl.Text;

            if (customurl.StartsWith("/"))
            {
                CusVal_tbCustomUrl.ErrorMessage = "Custom URL cannot start with /";
                args.IsValid = false;
                return;
            }

            char[] invalidchars = new char[] { '#', '%', '&', '*', '\'', '\\', ':', '+', '<', '>', '[', ']', '^', '`', '{', '}', '|', '?', ',', '.' };
            foreach (char c in invalidchars)
            {
                if (tbCustomUrl.Text.Contains(c.ToString()))
                {
                    CusVal_tbCustomUrl.ErrorMessage = "Custom URL cannot contain any of these characters: # % & * ' \\ : + < > [ ] ^ ` { } | ? , .";
                    args.IsValid = false;
                    return;
                }
            }
            
            if (!string.IsNullOrWhiteSpace(StrPageName))
            {
                TList<JXTPortal.Entities.DynamicPages> pages = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId);

                foreach (JXTPortal.Entities.DynamicPages page in pages)
                {
                    if (page.PageName != StrPageName)
                    {
                        if (page.CustomUrl == tbCustomUrl.Text)
                        {
                            CusVal_tbCustomUrl.ErrorMessage = "Custom URL already exists.";
                            args.IsValid = false;
                            break;
                        }
                    }
                }
            }
        }

        protected void CusVal_txtHyperLink_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(tbCustomUrl.Text))
            {
                CusVal_txtHyperLink.ErrorMessage = "You cannot have Overwrite URL .";
                args.IsValid = false;
            }
        }

        private void SaveSettings()
        {
            try
            {
                if (RevisionCode != Guid.Empty)
                {
                    using (TList<JXTPortal.Entities.DynamicPageRevisions> dynamicPages = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode))
                    {
                        foreach (JXTPortal.Entities.DynamicPageRevisions dynamicPage in dynamicPages)
                        {
                            dynamicPage.Status = Convert.ToInt32(ddlStatus.SelectedValue);

                            PortalEnums.DynamicPage.Visiblity selectedVis = (PortalEnums.DynamicPage.Visiblity)int.Parse(ddlVisibility.SelectedValue);

                            dynamicPage.Secured = (selectedVis == PortalEnums.DynamicPage.Visiblity.Secured);

                            if (selectedVis == PortalEnums.DynamicPage.Visiblity.Public || selectedVis == PortalEnums.DynamicPage.Visiblity.Secured)
                                dynamicPage.Visible = true;
                            else
                                dynamicPage.Visible = false;

                            dynamicPage.GenerateBreadcrumb = chkBreadcrumb.Checked;

                            /*
                            if (string.IsNullOrWhiteSpace(tbPublishedOnDay.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnYear.Text) == false
                                && string.IsNullOrWhiteSpace(tbPublishedOnHour.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnMinute.Text) == false)
                            {
                                dynamicPage.PublishOn = new DateTime(Convert.ToInt32(tbPublishedOnYear.Text), Convert.ToInt32(ddlPublishedOnMonth.Text), Convert.ToInt32(tbPublishedOnDay.Text), Convert.ToInt32(tbPublishedOnHour.Text), Convert.ToInt32(tbPublishedOnMinute.Text), 0);
                            }*/

                            DateTime _publishedDate = new DateTime();
                            if (!string.IsNullOrWhiteSpace(txtPublishDate.Text) && DateTime.TryParseExact(txtPublishDate.Text, SessionData.Site.DateFormat + " hh:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out _publishedDate))
                                dynamicPage.PublishOn = _publishedDate;
                            else
                                dynamicPage.PublishOn = null;
                            
                            DynamicPageRevisionsService.Update(dynamicPage);
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(CommonPage.PageName))
                    {
                        using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, CommonPage.PageName))
                        {
                            foreach (JXTPortal.Entities.DynamicPages dynamicPage in dynamicPages)
                            {

                                PortalEnums.DynamicPage.Visiblity selectedVis = (PortalEnums.DynamicPage.Visiblity)int.Parse(ddlVisibility.SelectedValue);

                                dynamicPage.Secured = (selectedVis == PortalEnums.DynamicPage.Visiblity.Secured);

                                if (selectedVis == PortalEnums.DynamicPage.Visiblity.Public || selectedVis == PortalEnums.DynamicPage.Visiblity.Secured)
                                    dynamicPage.Visible = true;
                                else
                                    dynamicPage.Visible = false;

                                dynamicPage.GenerateBreadcrumb = chkBreadcrumb.Checked;

                                /*if (string.IsNullOrWhiteSpace(tbPublishedOnDay.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnYear.Text) == false
                                    && string.IsNullOrWhiteSpace(tbPublishedOnHour.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnMinute.Text) == false)
                                {
                                    dynamicPage.PublishOn = new DateTime(Convert.ToInt32(tbPublishedOnYear.Text), Convert.ToInt32(ddlPublishedOnMonth.Text), Convert.ToInt32(tbPublishedOnDay.Text), Convert.ToInt32(tbPublishedOnHour.Text), Convert.ToInt32(tbPublishedOnMinute.Text), 0);
                                }*/

                                DateTime _publishedDate = new DateTime();
                                if (!string.IsNullOrWhiteSpace(txtPublishDate.Text) && DateTime.TryParseExact(txtPublishDate.Text, SessionData.Site.DateFormat + " hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out _publishedDate))
                                    dynamicPage.PublishOn = _publishedDate;
                                else
                                    dynamicPage.PublishOn = null;

                                DynamicPagesService.Update(dynamicPage);
                            }
                        }
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                                        <script type='text/javascript'>
                                                              $().ready(function() { $('#coda-slider-1').codaSlider({
                                                                    dynamicArrows: false,
                                                                    autoHeight: true
                                                                });});
            
                                                        </script>
            
                                                        ", false);

                ResetWidgets();

                ltlMessage.Text = "<p class=\"msg done\">Settings Updated</p>";
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "<p class=\"msg error\">" + ex.Message + "</p>";
            }

        }

        #region Send Mail Methods

        private void SendNotificationEmails(PortalEnums.DynamicPage.Status fromPageStatus, PortalEnums.DynamicPage.Status targetStatus, JXTPortal.Entities.DynamicPageRevisions pageRevision, int? lastModifiedUserIDForTheCurrentPage)
        {
            #region Email Sending
            AdminUsersService aus = new AdminUsersService();
            using (Entities.AdminUsers currentUser = aus.GetByAdminUserId(SessionData.AdminUser.AdminUserId))
            {
                if (fromPageStatus == PortalEnums.DynamicPage.Status.None) //new page
                {
                    switch (targetStatus)
                    {
                        case PortalEnums.DynamicPage.Status.None:
                        case PortalEnums.DynamicPage.Status.Draft:
                        case PortalEnums.DynamicPage.Status.Approved:
                        case PortalEnums.DynamicPage.Status.Decline:
                            //not possible
                            break;
                        case PortalEnums.DynamicPage.Status.Published:
                            //only admin can set to this status
                            //nothing needs to be done
                            break;
                        case PortalEnums.DynamicPage.Status.Pending: //only non admin can set to this status 
                            //send email to admin
                            SendEmailForPageRevisionSubmittedToAdmin(currentUser.UserName, pageRevision.PageName, pageRevision.MappingId.ToString());
                            break;
                        default:
                            break;
                    }
                }
                else //existing page
                {
                    switch (targetStatus)
                    {
                        case PortalEnums.DynamicPage.Status.None:
                        case PortalEnums.DynamicPage.Status.Draft:
                            break;
                        case PortalEnums.DynamicPage.Status.Pending:
                            //only admin can update from Pending to Pending, and when this happens, no emails should be fired
                            if( fromPageStatus != PortalEnums.DynamicPage.Status.Pending )
                                SendEmailForPageRevisionSubmittedToAdmin(currentUser.UserName, pageRevision.PageName, pageRevision.MappingId.ToString());
                            break;
                        case PortalEnums.DynamicPage.Status.Decline:
                        case PortalEnums.DynamicPage.Status.Approved:
                        case PortalEnums.DynamicPage.Status.Published:
                            //only admin/contenteditor can do this
                            using (Entities.AdminUsers lastModifiedByUser = aus.GetByAdminUserId(lastModifiedUserIDForTheCurrentPage.Value))
                            {
                                //this is to prevent admin/contenteditors to receive an email when they publish a page themselves
                                if( (PortalEnums.Admin.AdminRole) lastModifiedByUser.AdminRoleId == PortalEnums.Admin.AdminRole.Contributor)
                                    SendEmailToContributor(lastModifiedByUser.Email, lastModifiedByUser.UserName, currentUser.UserName, pageRevision.PageName, pageRevision.MappingId.ToString(), targetStatus, tbComment.Text);
                            }
                            break;
                        default:
                            break;
                    }
                }
                //if (targetStatus == PortalEnums.DynamicPage.Status.Decline)
                //{
                //    // TODO: Send Decline Email
                //    using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(pageRevision.LastModifiedBy))
                //    {
                //        if (adminuser != null)
                //        {
                //            string name = adminuser.UserName;
                //            string link = String.Format("http://{0}/admin/dynamicpagerevisions.aspx?revisioncode={1}", SessionData.Site.SiteUrl, pageRevision.MappingId);
                //            MailService.SendContributorPageRevision(adminuser.Email, pageRevision.PageName, "Decline", name, name, tbComment.Text, "", SessionData.Site.DefaultLanguageId);
                //        }
                //    }


                //}
                //// Send Published Email
                //if (pageRevision.Status == (int)PortalEnums.DynamicPage.Status.Pending
                //    && targetStatus == PortalEnums.DynamicPage.Status.Published
                //    && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Contributor)
                //{
                //    using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(pageRevision.LastModifiedBy))
                //    {
                //        if (adminuser != null)
                //        {
                //            string name = adminuser.UserName;
                //            string link = String.Format("http://{0}/admin/dynamicpagerevisions.aspx?revisioncode={1}", SessionData.Site.SiteUrl, pageRevision.MappingId);
                //            MailService.SendContributorPageRevision(adminuser.Email, pageRevision.PageName, "Published", name, name, tbComment.Text, link, SessionData.Site.DefaultLanguageId);
                //        }
                //    }
                //}
                //// Send new pending email to admin
                //if (targetStatus == PortalEnums.DynamicPage.Status.Pending
                //    && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
                //{
                //    using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(pageRevision.LastModifiedBy))
                //    {
                //        if (adminuser != null)
                //        {
                //            string name = adminuser.UserName;
                //            string adminname = aus.GetByAdminUserId(SessionData.AdminUser.AdminUserId).UserName;

                //            string link = String.Format("http://{0}/admin/dynamicpagerevisions.aspx?revisioncode={1}", SessionData.Site.SiteUrl, pageRevision.MappingId);
                //            MailService.SendAdminPageRevision("", pageRevision.PageName, adminname, name, link, SessionData.Site.DefaultLanguageId);
                //        }
                //    }
                //}


            }

            #endregion

        }


        private void SendEmailToContributor(string contributorEmail, string contributorName, string lastModifiedName, string pageName, string pageMappingID, PortalEnums.DynamicPage.Status pageNewStatus, string comments)
        {
            string linkParam;

            if (pageNewStatus == PortalEnums.DynamicPage.Status.Published)
                linkParam = "?code=" + HttpUtility.UrlEncode(pageName);
            else
                linkParam = "?revisioncode=" + pageMappingID;

            string link = String.Format("http://{0}/admin/dynamicpagerevisions.aspx", SessionData.Site.SiteUrl) + linkParam;
            MailService.SendContributorPageRevision(contributorEmail, pageName, pageNewStatus.ToString(), contributorName, lastModifiedName, comments, link, SessionData.Site.DefaultLanguageId);
        }


        private void SendEmailForPageRevisionSubmittedToAdmin(string submittedPageUserName, string pageName, string pageMappingID)
        {
            string link = String.Format("http://{0}/admin/dynamicpagerevisions.aspx?revisioncode={1}", SessionData.Site.SiteUrl, pageMappingID);
            MailService.SendAdminPageRevision(pageName, submittedPageUserName, link, SessionData.Site.DefaultLanguageId);
        }


        #endregion

        private void SubmitDynamicPages(PortalEnums.DynamicPage.Status targetStatus)
        {
            // Goes to DynamicPageRevisions
            int? lastModifiedUserIDForTheCurrentPage = null;
            bool valid = true;

            if (Page.IsValid)
            {
                try
                {
                    PortalEnums.DynamicPage.Status fromPageStatus = PortalEnums.DynamicPage.Status.None;

                    JXTPortal.Entities.DynamicPageRevisions pageRevision = new JXTPortal.Entities.DynamicPageRevisions();

                    if (RevisionCode != Guid.Empty)
                    {
                        TList<JXTPortal.Entities.DynamicPageRevisions> pageRevisions = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode);
                        if (pageRevisions.Count > 0)
                        {
                            pageRevision = pageRevisions[0];
                            fromPageStatus = (PortalEnums.DynamicPage.Status)pageRevision.Status;
                            lastModifiedUserIDForTheCurrentPage = pageRevision.LastModifiedBy;
                        }
                        else
                        {
                            //cannot be found in DynamicPageRevisions table, which means this is a NEW page created
                            pageRevision.MappingId = Guid.NewGuid();
                        }
                    }
                    else
                    {
                        pageRevision.MappingId = Guid.NewGuid();
                    }

                    pageRevision.PageName = txtPageName.Text.Trim();
                    pageRevision.Valid = chkValid.Checked;
                    pageRevision.PageFriendlyName = txtPageFriendlyName.Text.Trim();
                    pageRevision.CustomUrl = tbCustomUrl.Text.Trim().ToLower();
                    pageRevision.HyperLink = txtHyperlink.Text;
                    pageRevision.OpenInNewWindow = cbOpenNewWindow.Checked;
                    pageRevision.Sequence = Convert.ToInt32(txtSequence.Text);
                    pageRevision.OnTopNav = cbOnTopNav.Checked;
                    pageRevision.OnLeftNav = cbOnLeftNav.Checked;
                    pageRevision.OnBottomNav = cbOnBottomNav.Checked;
                    pageRevision.OnSiteMap = cbOnSiteMap.Checked;
                    pageRevision.Status = (int)targetStatus;

                    PortalEnums.DynamicPage.Visiblity selectedVis = (PortalEnums.DynamicPage.Visiblity)int.Parse(ddlVisibility.SelectedValue);

                    pageRevision.Secured = (selectedVis == PortalEnums.DynamicPage.Visiblity.Secured);

                    if (selectedVis == PortalEnums.DynamicPage.Visiblity.Public || selectedVis == PortalEnums.DynamicPage.Visiblity.Secured)
                        pageRevision.Visible = true;
                    else
                        pageRevision.Visible = false;

                    pageRevision.GenerateBreadcrumb = chkBreadcrumb.Checked;

                    /*if (string.IsNullOrWhiteSpace(tbPublishedOnDay.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnYear.Text) == false
                        && string.IsNullOrWhiteSpace(tbPublishedOnHour.Text) == false && string.IsNullOrWhiteSpace(tbPublishedOnMinute.Text) == false)
                    {
                        pageRevision.PublishOn = new DateTime(Convert.ToInt32(tbPublishedOnYear.Text), Convert.ToInt32(ddlPublishedOnMonth.Text), Convert.ToInt32(tbPublishedOnDay.Text), Convert.ToInt32(tbPublishedOnHour.Text), Convert.ToInt32(tbPublishedOnMinute.Text), 0);
                    }*/

                    DateTime _publishedDate = new DateTime();
                    if (!string.IsNullOrWhiteSpace(txtPublishDate.Text) && DateTime.TryParseExact(txtPublishDate.Text, SessionData.Site.DateFormat + " hh:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out _publishedDate))
                        pageRevision.PublishOn = _publishedDate;
                    else
                        pageRevision.PublishOn = null;

                    pageRevision.Comment = tbComment.Text;

                    ResetWidgets();

                    int isvalidno = -1;

                    for (int i = 0; i < rptDynamicPages.Items.Count; i++)
                    {
                        RepeaterItem item = rptDynamicPages.Items[i];
                        DynamicPageRevisionsFields ucDynamicPage = (DynamicPageRevisionsFields)item.FindControl("ucDynamicPage");

                        if (!ucDynamicPage.Validate())
                        {
                            if (isvalidno == -1)
                            {
                                isvalidno = i;
                            }
                        }
                    }

                    if (isvalidno != -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                                        <script type='text/javascript'>
                                                                 $().ready(function() {$('#coda-slider-1').codaSlider({
                                                                    dynamicArrows: false,
                                                                    autoHeight: true,
                                                                    firstPanelToLoad: " + (isvalidno + 1).ToString() + @"
                                                                });});

                                                               $('#spPageContentsArrow').click();
                                                               $('.tab" + (isvalidno + 1).ToString() + @" a').click();
            
                                                        </script>
            
                                                        ", false);
                        return;
                    }

                    for (int i = 0; i < rptDynamicPages.Items.Count; i++)
                    {
                        RepeaterItem item = rptDynamicPages.Items[i];
                        DynamicPageRevisionsFields ucDynamicPage = (DynamicPageRevisionsFields)item.FindControl("ucDynamicPage");

                        ucDynamicPage.PageRevisionEntity = pageRevision;

                        // Saving Related Dynamic Pages
                        string selecteddynamicpages = hfRelatedDynamicPages.Value;


                        // Display error message if dynamic pages saving has error
                        string errormessage = string.Empty;
                        if (!ucDynamicPage.SaveRevision(out errormessage))
                        {
                            if (valid)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                                        <script type='text/javascript'>
                                                              $().ready(function() { $('#coda-slider-1').codaSlider({
                                                                    dynamicArrows: false,
                                                                    autoHeight: true,
                                                                    firstPanelToLoad: " + (i + 1).ToString() + @"
                                                                });});

                                                               $('#spPageContentsArrow').click();
                                                               $('.tab" + (i + 1).ToString() + @" a').click();
            
                                                        </script>
            
                                                        ", false);


                            }
                            ltlMessage.Text = "<p class=\"msg error\">" + errormessage + "</p>";
                            valid = false;
                            return;
                        }
                    }

                    if (rptDynamicPages.Items.Count > 0)
                    {
                        RepeaterItem ri = rptDynamicPages.Items[0];
                        DynamicPageRevisionsFields dprf = (DynamicPageRevisionsFields)ri.FindControl("ucDynamicPage");

                        if (dprf.DynamicPageID > 0)
                        {
                            string urlToFlush = Request.Url.Scheme + "://" + Request.Url.Host + DynamicPagesService.GetDynamicPageUrl(DynamicPagesService.GetByDynamicPageId(dprf.DynamicPageID));
                            
                            CacheFlusher.FlushByUrl(new Uri(urlToFlush));
                        }
                    }

                    if (valid)
                    {
                        if (pageRevision.Status == (int)PortalEnums.DynamicPage.Status.Published)
                        {
                            for (int i = 0; i < rptDynamicPages.Items.Count; i++)
                            {
                                RepeaterItem item = rptDynamicPages.Items[i];
                                DynamicPageRevisionsFields ucDynamicPage = (DynamicPageRevisionsFields)item.FindControl("ucDynamicPage");

                                int dpid = ucDynamicPage.DynamicPageID;
                                int langid = ucDynamicPage.LanguageID;

                                TList<Entities.DynamicPageRevisions> revisions = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, pageRevision.MappingId);
                                revisions.Filter = "LanguageID = " + langid.ToString();
                                if (revisions.Count > 0)
                                {
                                    dpid = revisions[0].DynamicPageId;
                                }

                                RelatedDynamicPagesService.CustomModify(dpid, ddlRelatedDynamicPages.Value);


                                string[] splits = ddlLeftColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                DataSet leftcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                                if (leftcolumnlist != null && leftcolumnlist.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in leftcolumnlist.Tables[0].Rows)
                                    {
                                        bool found = false;
                                        string customwidgetid = dr["CustomWidgetID"].ToString();
                                        foreach (string s in splits)
                                        {
                                            if (s == customwidgetid)
                                            {
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (!found)
                                        {
                                            DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                                        }
                                    }
                                }


                                for (int index = 0; index < splits.Length; index++)
                                {
                                    TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                                    if (dpcwlist.Count > 0)
                                    {
                                        DynamicpagesCustomWidget dpcw = dpcwlist[0];
                                        dpcw.Sequence = index + 1;
                                        DynamicpagesCustomWidgetService.Update(dpcw);
                                    }
                                    else
                                    {
                                        DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
                                        dpcw.DynamicPageId = dpid;
                                        dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
                                        dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column;
                                        dpcw.Sequence = index + 1;
                                        DynamicpagesCustomWidgetService.Insert(dpcw);
                                    }
                                }

                                splits = ddlRightColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                DataSet rightcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                                if (rightcolumnlist != null && rightcolumnlist.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in rightcolumnlist.Tables[0].Rows)
                                    {
                                        bool found = false;
                                        string customwidgetid = dr["CustomWidgetID"].ToString();
                                        foreach (string s in splits)
                                        {
                                            if (s == customwidgetid)
                                            {
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (!found)
                                        {
                                            DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                                        }
                                    }
                                }

                                for (int index = 0; index < splits.Length; index++)
                                {
                                    TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                                    if (dpcwlist.Count > 0)
                                    {
                                        DynamicpagesCustomWidget dpcw = dpcwlist[0];
                                        dpcw.Sequence = index + 1;
                                        DynamicpagesCustomWidgetService.Update(dpcw);
                                    }
                                    else
                                    {
                                        DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
                                        dpcw.DynamicPageId = dpid;
                                        dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
                                        dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column;
                                        dpcw.Sequence = index + 1;
                                        DynamicpagesCustomWidgetService.Insert(dpcw);
                                    }
                                }
                            }

                            

                            SendNotificationEmails(fromPageStatus, targetStatus, pageRevision, lastModifiedUserIDForTheCurrentPage);

                            Response.Redirect("/admin/DynamicPageRevisions.aspx?code=" + txtPageName.Text + "&msg=1");
                        }
                        else
                        {
                            SendNotificationEmails(fromPageStatus, targetStatus, pageRevision, lastModifiedUserIDForTheCurrentPage);

                            Response.Redirect("/admin/DynamicPageRevisions.aspx?revisioncode=" + pageRevision.MappingId.ToString() + "&msg=1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = "<p class=\"msg error\">" + ex.Message + "</p>";
                    return;
                }


                if (valid)
                {
                    ltlMessage.Text = "<p class=\"msg done\">Dynamic page has been saved</p>";

                    if (targetStatus == PortalEnums.DynamicPage.Status.Pending)
                    {
                        ltlMessage.Text = "<p class=\"msg done\">Your page has been submitted for approval successfully. You will be notified via email the status of page once actioned.</p>";
                    }
                }
                //if (e.CommandName == "Save")
                //    Response.Redirect("dynamicpages.aspx");
            }

        }


        private void ResetWidgets()
        {
            StringBuilder relateddedaultpagelist = new StringBuilder();

            using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, 0, null, true, true))
            {
                foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
                {
                    if (dynamicpage.ParentDynamicPageId != 0 && dynamicpage.PageName != txtPageName.Text)
                    {
                        int lvlcount = dynamicpage.PageFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

                        for (int i = 0; i < lvlcount; i++)
                        {
                            dynamicpage.PageTitle = string.Format(" - {0}", dynamicpage.PageTitle);
                        }
                    }
                    if (dynamicpage.Valid && dynamicpage.PageName != txtPageName.Text)
                    {

                        relateddedaultpagelist.AppendLine("{id:" + dynamicpage.DynamicPageId.ToString() + ",text:\"" + dynamicpage.PageTitle + "\"},");
                    }
                }

            }

            StringBuilder columndefaultlist = new StringBuilder();

            TList<JXTPortal.Entities.CustomWidget> customwidgets = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);
            if (customwidgets.Count > 0)
            {
                foreach (JXTPortal.Entities.CustomWidget customwidget in customwidgets)
                {
                    if (customwidget.Active)
                    {
                        columndefaultlist.AppendLine("{id:" + customwidget.CustomWidgetId.ToString() + ",text:\"" + customwidget.CustomWidgetName + "\"},");
                    }
                }
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "AssignRelatedPages", @"
                                                        <script type='text/javascript'>
                                                           $('#ddlRelatedDynamicPages').val([" + ddlRelatedDynamicPages.Value + @"]).select2({ 
                                                            data:[
                                                            " + relateddedaultpagelist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                            placeholder: 'Select a Related Dynamic Page', width: '100%', multiple: true});
                                                           $(ddlRelatedDynamicPages).change(function() {
                                                            var ids = $(ddlRelatedDynamicPages).val();
                                                            var selections = ( JSON.stringify($(ddlRelatedDynamicPages).select2('data')) );
                                                            console.log('Selected options: ' + selections);
                                                            });
            
                                                           $('#ddlLeftColumn').val([" + ddlLeftColumn.Value + @"]).select2({ 
                                                            data:[
                                                            " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                            placeholder: 'Select a Related Custom Widget', width: '100%', multiple: true});
                                                           $(ddlLeftColumn).change(function() {
                                                            var ids = $(ddlLeftColumn).val();
                                                            var selections = ( JSON.stringify($(ddlLeftColumn).select2('data')) );
                                                            console.log('Selected options: ' + selections);
                                                            });
            
                                                           $('#ddlRightColumn').val([" + ddlRightColumn.Value + @"]).select2({ 
                                                            data:[
                                                            " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                            placeholder: 'Select a Related Custom Widget', width: '100%', multiple: true});
                                                           $(ddlRightColumn).change(function() {
                                                            var ids = $(ddlRightColumn).val();
                                                            var selections = ( JSON.stringify($(ddlRightColumn).select2('data')) );
                                                            console.log('Selected options: ' + selections);
                                                            });
                                                        </script>
            
                                                        ", false);

        }


        private string CompareDynamicPages(List<JXTPortal.Entities.DynamicPageRevisions> rev)
        {
            List<string> changeLog = new List<string>();
            bool hasError = false;

            #region error checking
            if (rev.Count() == 0)
            {
                changeLog.Add("No changelog available.");
                hasError = true;
            }
            #endregion

            if (!hasError)
            {
                //check commons using the first
                JXTPortal.Entities.DynamicPageRevisions firstRev = rev.First();

                //note this is getting from dynamic page (ie live page)
                using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, firstRev.PageName))
                {
                    //if there are no live page, we don't need to check for changes log
                    if (dynamicPages == null || dynamicPages.Count() == 0)
                    {
                        changeLog.Add("Not Available");
                    }
                    else
                    {

                        {
                            JXTPortal.Entities.DynamicPages useThisPage = dynamicPages.First();

                            if (firstRev.PageFriendlyName != useThisPage.PageFriendlyName)
                                changeLog.Add("Page Friendly URL");

                            if (firstRev.CustomUrl != useThisPage.CustomUrl)
                                changeLog.Add("Custom URL");

                            if (firstRev.HyperLink != useThisPage.HyperLink)
                                changeLog.Add("Overwrite Link");

                            if (firstRev.Sequence != useThisPage.Sequence)
                                changeLog.Add("Sequence");

                            if (firstRev.OpenInNewWindow != useThisPage.OpenInNewWindow)
                                changeLog.Add("Menu Display: Open In New Window");

                            if (firstRev.OnTopNav != useThisPage.OnTopNav)
                                changeLog.Add("Menu Display: Main Navigation");

                            if (firstRev.OnLeftNav != useThisPage.OnLeftNav)
                                changeLog.Add("Menu Display: Dynamic Navigation");

                            if (firstRev.Valid != useThisPage.Valid)
                                changeLog.Add("Menu Display: Left Navigation");

                            if (firstRev.OnBottomNav != useThisPage.OnBottomNav)
                                changeLog.Add("Menu Display: Footer Navigation");

                            if (firstRev.OnSiteMap != useThisPage.OnSiteMap)
                                changeLog.Add("Menu Display: On Site Map");

                            if (firstRev.GenerateBreadcrumb != useThisPage.GenerateBreadcrumb)
                                changeLog.Add("Menu Display: Generate Breadcrumb");

                        }

                        foreach (JXTPortal.Entities.DynamicPageRevisions r in rev)
                        {
                            JXTPortal.Entities.DynamicPages thisPage = dynamicPages.Where(c => c.LanguageId == r.LanguageId).FirstOrDefault();

                            if (thisPage != null)
                            {
                                string currentLanguageName = ((PortalEnums.Languages.Language)r.LanguageId).ToString();

                                if (r.ParentDynamicPageId != thisPage.ParentDynamicPageId)
                                    changeLog.Add("Language " + currentLanguageName + ": Parent Page");

                                if (r.PageTitle != thisPage.PageTitle)
                                    changeLog.Add("Language " + currentLanguageName + ": Page Title");

                                if (r.DynamicPageWebPartTemplateId != thisPage.DynamicPageWebPartTemplateId)
                                    changeLog.Add("Language " + currentLanguageName + ": Page Theme");

                                if (r.PageContent != thisPage.PageContent)
                                    changeLog.Add("Language " + currentLanguageName + ": Page Content");

                                if (r.Searchable != thisPage.Searchable)
                                    changeLog.Add("Language " + currentLanguageName + ": Searchable");

                                if (r.MetaTitle != thisPage.MetaTitle)
                                    changeLog.Add("Language " + currentLanguageName + ": Meta Title");

                                if (r.MetaKeywords != thisPage.MetaKeywords)
                                    changeLog.Add("Language " + currentLanguageName + ": Meta Keywords");

                                if (r.MetaDescription != thisPage.MetaDescription)
                                    changeLog.Add("Language " + currentLanguageName + ": Meta Description");

                            }
                        }
                    }
                }
            }

            if (changeLog.Count() == 0)
                changeLog.Add("No changes detected");

            string log_HTMLList = "<ul class='publish-detect-changes'><li>" + String.Join("</li><li>", changeLog) + "</li></ul>";
            return log_HTMLList;
        }


        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SubmitDynamicPages(PortalEnums.DynamicPage.Status.Pending);
            }
        }

        protected void lbPublish_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SubmitDynamicPages(PortalEnums.DynamicPage.Status.Published);
            }
        }

        protected void lbSaveDraft_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SubmitDynamicPages(PortalEnums.DynamicPage.Status.Draft);
            }

            ResetWidgets();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                                        <script type='text/javascript'>
                                                              $().ready(function() { $('#coda-slider-1').codaSlider({
                                                                    dynamicArrows: false,
                                                                    autoHeight: true
                                                                });});
            
                                                        </script>
            
                                                        ", false);
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/dynamicpages.aspx");
        }

        protected void lbAdminUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Contributor)
                {
                    //admin submit
                    SubmitDynamicPages((PortalEnums.DynamicPage.Status)Convert.ToInt32(ddlStatus.SelectedValue));
                }
                else
                {
                    //contributor submit
                    if (ddlStatus.SelectedValue == ((int)PortalEnums.DynamicPage.Status.Draft).ToString())
                    {
                        SubmitDynamicPages((PortalEnums.DynamicPage.Status)Convert.ToInt32(ddlStatus.SelectedValue));
                    }
                    else
                    {
                        SubmitDynamicPages(PortalEnums.DynamicPage.Status.Pending);
                    }
                }
            }

            ResetWidgets();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                                        <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                                        <script type='text/javascript'>
                                                              $().ready(function() { $('#coda-slider-1').codaSlider({
                                                                    dynamicArrows: false,
                                                                    autoHeight: true
                                                                });});
            
                                                        </script>
            
                                                        ", false);
        }

    }
}