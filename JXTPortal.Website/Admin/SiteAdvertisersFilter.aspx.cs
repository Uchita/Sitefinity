using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;

namespace JXTPortal.Website.Admin
{
    public partial class SiteAdvertisersFilter : System.Web.UI.Page
    {
        #region "Properties"

        private AdvertisersService _advertisersService;

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersService == null)
                    _advertisersService = new AdvertisersService();

                return _advertisersService;
            }
        }

        private GlobalSettingsService _globalSettingsService;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                    _globalSettingsService = new GlobalSettingsService();

                return _globalSettingsService;
            }
        }

        private SiteAdvertiserFilterService _siteAdvertiserFilterService;

        private SiteAdvertiserFilterService SiteAdvertiserFilterService
        {
            get
            {
                if (_siteAdvertiserFilterService == null)
                    _siteAdvertiserFilterService = new SiteAdvertiserFilterService();

                return _siteAdvertiserFilterService;
            }
        }

        #endregion

        #region "Page Events"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (TList<Entities.GlobalSettings> settings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (settings.Count > 0 && settings[0].UseAdvertiserFilter == 1)
                    {
                        LoadSiteAdvertisers();
                    }
                    else
                    {
                        ltlMessage.Text = "*You haven't activated advertiser filter in global settings";
                    }
                }
            }
        }

        #endregion

        #region "Methods"

        private void LoadSiteAdvertisers()
        {
            DataSet dsAdvertiserFilter = SiteAdvertiserFilterService.GetNameBySiteId(SessionData.Site.SiteId);
            List<DataRow> advertiserfilters = new List<DataRow>();
            List<DataRow> blockedadvertiserfilters = new List<DataRow>();

            foreach (DataRow dr in dsAdvertiserFilter.Tables[0].Rows)
            {
                if (dr["Status"].ToString() == "1")
                {
                    advertiserfilters.Add(dr);
                }

                if (dr["Status"].ToString() == "0")
                {
                    blockedadvertiserfilters.Add(dr);
                }
            }

            phAdvertiserFilter.Visible = (advertiserfilters.Count > 0);
            phBlockedAdvertiserFilter.Visible = (blockedadvertiserfilters.Count > 0);

            rptAdvertiserFilter.DataSource = advertiserfilters;
            rptAdvertiserFilter.DataBind();

            rptBlockedAdvertiserFilter.DataSource = blockedadvertiserfilters;
            rptBlockedAdvertiserFilter.DataBind();


            //JXTPortal.Entities.SiteCountries country = new JXTPortal.Entities.SiteCountries();
            //country.count
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int advertiserId;
            if (int.TryParse(txtAdvertiserID.Text, out advertiserId))
            {
                // Check if Advertiser exist
                using (Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(advertiserId))
                {
                    if (advertisers == null)
                    {
                        ltlMessage.Text = "Error - Advertiser not found.";
                        return;
                    }
                    else
                    {
                        if (advertisers.SiteId == SessionData.Site.SiteId)
                        {
                            ltlMessage.Text = "Error - Advertiser part of existing site.";
                            return;
                        }
                    }

                    
                }

                // Check if the record already exists in filter table
                using (Entities.SiteAdvertiserFilter siteAdvertiserFilter = SiteAdvertiserFilterService.GetBySiteIdAdvertiserId(SessionData.Site.SiteId, advertiserId))
                {
                    if (siteAdvertiserFilter != null)
                    {
                        ltlMessage.Text = "Error - Advertiser already added.";
                        return;
                    }
                }


                using (Entities.SiteAdvertiserFilter advertiserFilter = new Entities.SiteAdvertiserFilter())
                {
                    advertiserFilter.AdvertiserId = advertiserId;
                    advertiserFilter.SiteId = SessionData.Site.SiteId;
                    advertiserFilter.Status = 1;
                    SiteAdvertiserFilterService.Insert(advertiserFilter);
                    ltlMessage.Text = "Advertiser saved.";
                    LoadSiteAdvertisers();

                }
            }

        }


        protected void rptAdvertiserFilter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int intID = int.Parse(e.CommandArgument.ToString());
                
                // Check if the record already exists in filter table
                using (Entities.SiteAdvertiserFilter siteAdvertiserFilter = SiteAdvertiserFilterService.GetBySiteAdvertiserFilterId(intID))
                {
                    if (siteAdvertiserFilter != null && SessionData.Site.SiteId == siteAdvertiserFilter.SiteId)
                    {
                        SiteAdvertiserFilterService.Delete(siteAdvertiserFilter.SiteAdvertiserFilterId);
                        LoadSiteAdvertisers();
                    }
                }

            }
        }

        protected void rptBlockedAdvertiserFilter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int intID = int.Parse(e.CommandArgument.ToString());

                // Check if the record already exists in filter table
                using (Entities.SiteAdvertiserFilter siteAdvertiserFilter = SiteAdvertiserFilterService.GetBySiteAdvertiserFilterId(intID))
                {
                    if (siteAdvertiserFilter != null && SessionData.Site.SiteId == siteAdvertiserFilter.SiteId)
                    {
                        SiteAdvertiserFilterService.Delete(siteAdvertiserFilter.SiteAdvertiserFilterId);
                        LoadSiteAdvertisers();
                    }
                }

            }
        }

        protected void rptAdvertiserFilter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRow dr = e.Item.DataItem as DataRow;

                LinkButton lnkSelectFile = e.Item.FindControl("lnkSelectFile") as LinkButton;
                Literal ltAdvertiserID = e.Item.FindControl("ltAdvertiserID") as Literal;
                Literal ltCompanyName = e.Item.FindControl("ltCompanyName") as Literal;

                lnkSelectFile.CommandArgument = dr["SiteAdvertiserFilterID"].ToString();
                ltAdvertiserID.Text = dr["AdvertiserID"].ToString();
                ltCompanyName.Text = HttpUtility.HtmlEncode(dr["CompanyName"].ToString());
            }
        }

        protected void rptBlockedAdvertiserFilter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRow dr = e.Item.DataItem as DataRow;

                LinkButton lnkSelectFile = e.Item.FindControl("lnkSelectFile") as LinkButton;
                Literal ltAdvertiserID = e.Item.FindControl("ltAdvertiserID") as Literal;
                Literal ltCompanyName = e.Item.FindControl("ltCompanyName") as Literal;

                lnkSelectFile.CommandArgument = dr["SiteAdvertiserFilterID"].ToString();
                ltAdvertiserID.Text = dr["AdvertiserID"].ToString();
                ltCompanyName.Text = HttpUtility.HtmlEncode(dr["CompanyName"].ToString());
            }
        }

        protected void btnBlock_Click(object sender, EventArgs e)
        {
            int advertiserId;
            if (int.TryParse(txtAdvertiserID.Text, out advertiserId))
            {
                // Check if Advertiser exist
                using (Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(advertiserId))
                {
                    if (advertisers == null)
                    {
                        ltlMessage.Text = "Error - Advertiser not found.";
                        return;
                    }
                    else
                    {
                        if (advertisers.SiteId == SessionData.Site.SiteId)
                        {
                            ltlMessage.Text = "Error - Advertiser part of existing site.";
                            return;
                        }
                    }


                }

                // Check if the record already exists in filter table
                using (Entities.SiteAdvertiserFilter siteAdvertiserFilter = SiteAdvertiserFilterService.GetBySiteIdAdvertiserId(SessionData.Site.SiteId, advertiserId))
                {
                    if (siteAdvertiserFilter != null)
                    {
                        ltlMessage.Text = "Error - Advertiser already added.";
                        return;
                    }
                }


                using (Entities.SiteAdvertiserFilter advertiserFilter = new Entities.SiteAdvertiserFilter())
                {
                    advertiserFilter.AdvertiserId = advertiserId;
                    advertiserFilter.SiteId = SessionData.Site.SiteId;
                    advertiserFilter.Status = 0;
                    SiteAdvertiserFilterService.Insert(advertiserFilter);
                    ltlMessage.Text = "Advertiser saved.";
                    LoadSiteAdvertisers();

                }
            }
        }

    }
}
