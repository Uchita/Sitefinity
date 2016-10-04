using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class CampaignEdit : System.Web.UI.Page
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


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDynamicPage();
            }
        }


        private void LoadDynamicPage()
        {
            if (!String.IsNullOrEmpty(CommonPage.PageName))
            {
                using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, CommonPage.PageName))
                {
                    if (dynamicPages.Count > 0)
                    {
                        txtPageName.Text = dynamicPages[0].PageName;
                        chkValid.Checked = dynamicPages[0].Valid;

                        string[] strPageNames2 = dynamicPages[0].PageFriendlyName.Split(new char[] { '/' });
                        string strPageName2 = strPageNames2[strPageNames2.Length - 1];
                        txtPageFriendlyName.Text = strPageName2;
                        txtCampaignUrl.Text = hypLinkViewPage.NavigateUrl = String.Format("http://{0}/page/{1}", SessionData.Site.SiteUrl, dynamicPages[0].PageFriendlyName); ;

                        txtPageContent.Text = dynamicPages[0].PageContent;
                        txtTagCode.Text = dynamicPages[0].PageTitle;

                        ltlLastModified.Text = dynamicPages[0].LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        chkValid.Checked = dynamicPages[0].Valid;

                        // Disable Page Code
                        txtPageName.Enabled = false;

                        hiddenID.Value = dynamicPages[0].DynamicPageId.ToString();

                        hypLinkViewPage.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("CampaignList.aspx");
                    }
                }
            }
        }

        #region Button Click Events

        protected void btnCampaignList_Click(object sender, EventArgs e)
        {
            Response.Redirect("CampaignList.aspx");
        }

        protected void btnCreateCampaign_Click(object sender, EventArgs e)
        {
            string strPageName = string.Empty;
            if (CommonPage.PageName.Length > 0)
                strPageName = CommonPage.PageName;
            else
                strPageName = txtPageName.Text;

            JXTPortal.Entities.DynamicPages dynamicPage = new JXTPortal.Entities.DynamicPages();

            if (!string.IsNullOrEmpty(strPageName))
            {
                dynamicPage = DynamicPagesService.GetBySiteIdLanguageIdPageFriendlyName(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, txtPageFriendlyName.Text.Trim());

                if (dynamicPage != null && hiddenID.Value.ToString() != dynamicPage.DynamicPageId.ToString())
                {
                    ltlMessage.Text = "Campaign keyword nomination with this name already exists. Please try again.";
                    return;
                }
                dynamicPage = new JXTPortal.Entities.DynamicPages();

                TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, strPageName);
                if (dynamicPages.Count > 0)
                {
                    dynamicPage = dynamicPages[0];

                    if (hiddenID.Value.ToString() != dynamicPage.DynamicPageId.ToString())
                    {
                        ltlMessage.Text = "Campaign name with this name already exists. Please try again.";
                        return;
                    }
                }
                else
                {
                    DynamicPageWebPartTemplatesService dynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesService();
                    dynamicPage.DynamicPageWebPartTemplateId = dynamicPageWebPartTemplatesService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault().DynamicPageWebPartTemplateId;
                }


                dynamicPage.SiteId = SessionData.Site.SiteId; 
                dynamicPage.PageName = txtPageName.Text.Trim();
                dynamicPage.PageTitle = txtTagCode.Text.Trim();
                dynamicPage.Valid = chkValid.Checked;
                dynamicPage.PageFriendlyName = txtPageFriendlyName.Text.Trim().ToLower();
                dynamicPage.HyperLink = "/advancedSearch.aspx?search=1&campaign=" + txtPageFriendlyName.Text;
                dynamicPage.OpenInNewWindow = false;
                dynamicPage.Sequence = CommonPage.CampaignSequenceNumber; // -99999
                dynamicPage.OnTopNav = false;
                dynamicPage.OnLeftNav = false;
                dynamicPage.OnBottomNav = false;
                dynamicPage.OnSiteMap = false;
                dynamicPage.Secured = false;
                dynamicPage.PageContent = txtPageContent.Text.Trim();
                dynamicPage.LanguageId = SessionData.Site.DefaultLanguageId;
                dynamicPage.LastModified = DateTime.Now;
                dynamicPage.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                dynamicPage.Visible = true;

                if (dynamicPage.DynamicPageId > 0)
                {
                    DynamicPagesService.Update(dynamicPage);
                    DynamicPagesService.UpdateWebPartTemplate(dynamicPage.SiteId, dynamicPage.LanguageId, dynamicPage.DynamicPageId, dynamicPage.DynamicPageWebPartTemplateId, false);

                    Response.Redirect("CampaignList.aspx");
                    ltlMessage.Text = "Campaign Updated.";
                }
                else
                {
                    DynamicPagesService.Insert(dynamicPage);

                    Response.Redirect("CampaignList.aspx");
                    ltlMessage.Text = "Campaign Saved.";
                }
            }
        }

        #endregion

    }
}