using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucCompanySearch : System.Web.UI.UserControl
    {
        #region Declarations
        private const int MaxDescriptionLength = 255;
        private AdvertisersService _advertisersservice;

        #endregion

        #region Properties

        AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }

        }

        private int TotalPageCount
        {
            get;
            set;
        }

        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods

        private void DoSearch()
        {
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;
            TotalPageCount = 0;
            string filter = string.Format("SiteID = {0} AND SearchField LIKE '%{1}%'", SessionData.Site.SiteId, tbKeyword.Text);
            TList<Entities.Advertisers> advertisers = AdvertisersService.GetPaged(filter, string.Empty, CurrentPage, sitePageCount, out totalCount);

            if (totalCount > 0)
            {
                litResultNumber.Text = totalCount.ToString();

                if (totalCount % sitePageCount == 0)
                    TotalPageCount = totalCount / sitePageCount;
                else
                    TotalPageCount = (totalCount / sitePageCount) + 1;
                if (TotalPageCount > 1)
                {
                    List<PagingClass> pagingClassList = new List<PagingClass>();
                    PagingClass pagingClass = null;
                    for (int i = 0; i < TotalPageCount; i++)
                    {
                        pagingClass = new PagingClass();
                        pagingClass.PageNo = i.ToString();
                        if (CurrentPage == i)
                            pagingClass.Enabled = false;
                        else
                            pagingClass.Enabled = true;

                        pagingClassList.Add(pagingClass);
                    }

                    rptPaging.DataSource = pagingClassList;
                    rptPaging.DataBind();
                }
                else
                {
                    rptPaging.Visible = false;
                }

                rptAdvertiserResults.DataSource = advertisers;
                rptAdvertiserResults.DataBind();
                pnlSearchResult.Visible = true;
            }
            else
            {
                litResultNumber.Text = "0";
                rptPaging.DataSource = null;
                rptPaging.DataBind();

                rptAdvertiserResults.DataSource = null;
                rptAdvertiserResults.DataBind();
            }
        }

        #endregion

        #region Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected void rptAdvertiserResults_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptAdvertiserResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlAdvertiser = e.Item.FindControl("ltlAdvertiser") as Literal;
                Entities.Advertisers advertiser = e.Item.DataItem as Entities.Advertisers;

                string strProfile = JXTPortal.Common.Utils.StripHTML(advertiser.Profile);
                if (strProfile.Length > MaxDescriptionLength)
                {
                    strProfile = strProfile.Substring(0, MaxDescriptionLength) + "...";
                }

                string strImage = string.Empty;

                if (!string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                {
                    strImage = string.Format(@"<div class='job-rightlinks'>
                    <br />
                    <span class='dateText'>
                        <img src='/media/{0}/{1}' />
                    </span>
                    </div>", ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl);
                }
                else
                {
                    if (advertiser.AdvertiserLogo != null)
                    {
                        strImage = string.Format(@"<div class='job-rightlinks'>
                    <br />
                    <span class='dateText'>
                        <img src='/getfile.aspx?advertiserid={0}' />
                    </span>
                    </div>", advertiser.AdvertiserId);
                    }
                }

                string strAdvertiser = string.Format(@"<div id='job-holder'><div class='job-toplink'>
                <a href='/advertisers/{0}/'>{1}</a></div>
                {2}<div class='description-text'>{3}<br /><br /><a href='http://{4}'>{4}</a></div></div>", advertiser.AdvertiserId, advertiser.CompanyName, strImage, strProfile,advertiser.WebAddress);
                ltlAdvertiser.Text = strAdvertiser;
            }
        }

        protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)                                         
            {
                PagingClass pagingClass = e.Item.DataItem as PagingClass;
                LinkButton lnkButtonPaging = (LinkButton)e.Item.FindControl("lnkButtonPaging");

                lnkButtonPaging.CommandArgument = (Convert.ToInt32(pagingClass.PageNo) - 1).ToString();
                lnkButtonPaging.Text = pagingClass.PageNo.ToString();

                if (!pagingClass.Enabled)
                {
                    lnkButtonPaging.CssClass = "disabled_tnt_pagination";
                    lnkButtonPaging.Enabled = false;
                }
                //
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {

                LinkButton lnkButtonPrevious = (LinkButton)e.Item.FindControl("lnkButtonPrevious");
                //Todo - Translation
                lnkButtonPrevious.Text = CommonFunction.GetResourceValue("LabelPrevious");
                if (SessionData.JobSearch.PageIndex <= 0)
                {

                    lnkButtonPrevious.CssClass = "disabled_tnt_pagination";
                    lnkButtonPrevious.Enabled = false;
                }
                else
                {
                    lnkButtonPrevious.CommandArgument = (SessionData.JobSearch.PageIndex - 1).ToString();
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                LinkButton lnkButtonNext = (LinkButton)e.Item.FindControl("lnkButtonNext");
                lnkButtonNext.Text = CommonFunction.GetResourceValue("LabelNext");

                if (SessionData.JobSearch.PageIndex >= TotalPageCount - 1)
                {

                    lnkButtonNext.CssClass = "disabled_tnt_pagination";
                    lnkButtonNext.Enabled = false;
                }
                else
                {
                    lnkButtonNext.CommandArgument = (SessionData.JobSearch.PageIndex + 1).ToString();
                }
            }
        }

        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("paging"))
            {
                SessionData.JobSearch.PageIndex = Convert.ToInt32(e.CommandArgument.ToString());

                // Search again
                DoSearch();
            }

        }

        #endregion

        #region Paging Class

        private class PagingClass
        {
            public string PageNo { get; set; }
            public string PageUrl { get; set; }
            public bool Enabled { get; set; }
        }

        #endregion
    }
}