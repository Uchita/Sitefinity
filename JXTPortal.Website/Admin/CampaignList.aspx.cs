using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class CampaignList : System.Web.UI.Page
    {
        
        #region Properties

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
            if (!Page.IsPostBack)
            {


                SetDynamicPages();

            }

        }

        protected void SetDynamicPages()
        {

            using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                        DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, Convert.ToInt32(SessionData.Site.DefaultLanguageId), 0, null, false, false))
            {
                string strPageLink = string.Empty;

                TList<JXTPortal.Entities.DynamicPages> DynamicPagesListNew = new TList<Entities.DynamicPages>();

                for (int i = 0; i < DynamicPagesList.Count; i++)
                {
                    if (DynamicPagesList[i].ParentDynamicPageId == 0 && DynamicPagesList[i].Sequence == CommonPage.CampaignSequenceNumber)
                    {
                        DynamicPagesListNew.Add(DynamicPagesList[i]);

                    }                    
                }
                
                rptCampaignList.DataSource = DynamicPagesListNew;
                rptCampaignList.DataBind();

                DynamicPagesListNew.Clear();
                DynamicPagesListNew.Dispose();
            }

        }

        protected void rptCampaignList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hiddenID = e.Item.FindControl("hiddenID") as HiddenField;
                HyperLink hypCampaignName = e.Item.FindControl("hypCampaignName") as HyperLink;
                HyperLink hypLinkUrl = e.Item.FindControl("hypLinkUrl") as HyperLink;
                Literal ltlTagCode = e.Item.FindControl("ltlTagCode") as Literal;
                Literal ltlDateCreated = e.Item.FindControl("ltlDateCreated") as Literal;
                Literal ltlStatus = e.Item.FindControl("ltlStatus") as Literal;

                JXTPortal.Entities.DynamicPages _dynamicPage = (JXTPortal.Entities.DynamicPages)e.Item.DataItem;
                hiddenID.Value = _dynamicPage.DynamicPageId.ToString();
                hypCampaignName.Text = _dynamicPage.PageName;
                hypCampaignName.NavigateUrl = "CampaignEdit.aspx?code=" + _dynamicPage.PageName;
                ltlTagCode.Text = _dynamicPage.PageTitle;
                hypLinkUrl.NavigateUrl = hypLinkUrl.Text = String.Format("http://{0}/page/{1}", SessionData.Site.SiteUrl, _dynamicPage.PageFriendlyName);
                hypLinkUrl.Target = "_blank";
                ltlDateCreated.Text = _dynamicPage.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                ltlStatus.Text = _dynamicPage.Valid ? "Active" : "Not Active";
            }
        }

        #region Button Click Events

        protected void btnCreateCampaign_Click(object sender, EventArgs e)
        {
            Response.Redirect("CampaignEdit.aspx");
        }

        protected void btnMakeActive_Click(object sender, EventArgs e)
        {
            SaveList(true);
        }

        protected void btnMakeInActive_Click(object sender, EventArgs e)
        {
            SaveList(false);
        }

        #endregion

        #region Methods

        protected void SaveList(bool valid)
        {
            List<int> _dynamicList = new List<int>();
            int _dynamicPageID = 0;
            foreach (RepeaterItem item in rptCampaignList.Items)
            {
                if (((CheckBox)item.FindControl("chkSelect")).Checked)
                {
                    _dynamicPageID = int.Parse(((HiddenField)item.FindControl("hiddenID")).Value);

                    using (Entities.DynamicPages page = DynamicPagesService.GetByDynamicPageId(_dynamicPageID))
                    {
                        // Campaign to identify is the same sequence number
                        if (page != null && page.SiteId == SessionData.Site.SiteId && page.Sequence == CommonPage.CampaignSequenceNumber)
                        {
                            _dynamicList.Add(_dynamicPageID);
                        }
                    }
                }
            }

            
            if (_dynamicList.Count > 0)
            {
                TList<Entities.DynamicPages> DynamicPagesList = new TList<Entities.DynamicPages>();

                Entities.DynamicPages DynamicPages = new Entities.DynamicPages();

                foreach (int _dynamicID in _dynamicList)
                {
                    DynamicPages =  DynamicPagesService.GetByDynamicPageId(_dynamicID);
                    DynamicPages.Valid = valid;
                    DynamicPagesList.Add(DynamicPages);
                }

                DynamicPagesService.Save(DynamicPagesList);

                SetDynamicPages();
            }

        }

        #endregion

    }
}