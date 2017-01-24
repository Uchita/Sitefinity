using System;
using System.Collections;
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
using JXTPortal;
using JXTPortal.Data;
using JXTPortal.Common.Extensions;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucAdvertiserPublicProfile : System.Web.UI.UserControl
    {
        private int AdvertiserID
        {
            get
            {
                int _advertiserID = -1;
                int.TryParse(Request.QueryString["AdvertiserId"], out _advertiserID);
                return _advertiserID;
            }
        }

        private AdvertisersService _advertisersservice;
        private AdvertisersService AdvertisersService
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

        private AdvertiserBusinessTypeService _advertiserbusinesstypeservice;
        private AdvertiserBusinessTypeService AdvertiserBusinessTypeService
        {
            get
            {
                if (_advertiserbusinesstypeservice == null)
                {
                    _advertiserbusinesstypeservice = new AdvertiserBusinessTypeService();
                }
                return _advertiserbusinesstypeservice;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAdvertiserProfile();
        }

        private void LoadAdvertiserProfile()
        {
            if (AdvertiserID > 0)
            {
                Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID);
                if (advertiser != null)
                {
                    litCompanyName.Text = advertiser.CompanyName;
                    hlWebAddress.NavigateUrl = "http://" + advertiser.WebAddress;
                    hlWebAddress.Text = advertiser.WebAddress;
                    if (advertiser.AdvertiserLogo != null || string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl) == false)
                    {
                        if (!string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                        {
                            imgAdvertiserLogo.ImageUrl = string.Format(@"/media/{0}/{1}", ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl);
                        }
                        else
                        {
                            imgAdvertiserLogo.ImageUrl = string.Format("/getfile.aspx?advertiserid={0}&ver={1}",AdvertiserID.ToString(), advertiser.LastModified.ToEpocTimestamp());
                        }
                    }
                    else
                    {
                        imgAdvertiserLogo.Visible = false;
                    }
                    litProfile.Text = advertiser.Profile;

                    Entities.AdvertiserBusinessType abt = AdvertiserBusinessTypeService.GetSiteBusinessTypeByParentID(SessionData.Site.SiteId, advertiser.AdvertiserBusinessTypeId);
                    litBusinessType.Text = abt.AdvertiserBusinessTypeName;

                    litNoOfEmployees.Text = advertiser.NoOfEmployees;
                }
                else
                {
                    Response.Redirect("~/companysearch.aspx");
                }
            }
            else
            {
                Response.Redirect("~/companysearch.aspx");
            }
        }

 
    }
}