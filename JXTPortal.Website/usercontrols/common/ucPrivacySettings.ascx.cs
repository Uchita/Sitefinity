using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucPrivacySettings : System.Web.UI.UserControl
    {
        private DynamicContentService _dynamiccontentservice;
        private DynamicContentService DynamicContentService
        {
            get
            {
                if (_dynamiccontentservice == null)
                {
                    _dynamiccontentservice = new DynamicContentService();
                }
                return _dynamiccontentservice;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalSettingsService gss = new GlobalSettingsService();
            
            using (TList<GlobalSettings> lgs = gss.GetBySiteId(SessionData.Site.SiteId))
            {
                if (lgs.Count > 0)
                {
                    GlobalSettings gs = lgs[0];
                    litContent.Text = gs.PrivacySettings;

                    using (TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        int type = ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions);
                        string url = "/member/terms/";

                        if (Request.Url.OriginalString.Contains("/advertiser/"))
                        {
                            type = ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions);
                            url = "/advertiser/terms/";
                        }


                        foreach (DynamicContent dynamiccontent in dynamiccontents)
                        {
                            if (dynamiccontent.DynamicContentType == type && dynamiccontent.Active)
                            {
                                litContent.Text = litContent.Text.Replace("[Terms&ConditionsLink]", url);
                            }
                        }
                    }
                }
            }
        }
    }
}