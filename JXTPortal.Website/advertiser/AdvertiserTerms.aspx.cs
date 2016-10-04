using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class AdvertiserTerms : System.Web.UI.Page
    {
		private AdvertiserUsersService _advertiserusersservice;	
		private AdvertiserUsersService AdvertiserUsersService
		{
			get
			{
				if (_advertiserusersservice == null)
				{
					_advertiserusersservice = new AdvertiserUsersService();
				}
				return _advertiserusersservice;
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

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Terms &amp; Conditions");
        }
	
        protected void Page_Load(object sender, EventArgs e)
        {
            bool active = false;
            phAction.Visible = false;

            DynamicContentService dcservice = new DynamicContentService();
            using (TList<Entities.DynamicContent> dynamiccontents = dcservice.GetBySiteId(SessionData.Site.SiteId))
            {
                foreach (Entities.DynamicContent dynamiccontent in dynamiccontents)
                {
                    if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions) && dynamiccontent.Active)
                    {
                        active = true;

                        ltTitle.Text = HttpUtility.HtmlEncode(dynamiccontent.Title);
                        ltIntroduction.Text = dynamiccontent.Introduction;
                        ltDescription.Text = dynamiccontent.Description;
						
						// Check if advertiser user has already accepted the TC
                        if (SessionData.AdvertiserUser != null)
                        {
                            JXTPortal.Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId);
                            if (advuser != null)
                            {
                                if (advuser.LastTermsAndConditionsDate.HasValue)
                                {
                                    if (advuser.LastTermsAndConditionsDate.Value > dynamiccontent.LastModifiedDate)
                                    {
                                        if (!string.IsNullOrEmpty(Request.Params["returnurl"]))
                                        {
                                            Response.Redirect(Request.Params["returnurl"]);
                                        }
                                        else
                                        {
                                            Response.Redirect("/advertiser/default.aspx");
                                        }
                                    }
                                    else
                                    {
                                        // Show Panel
                                        phAction.Visible = true;
                                    }
                                }
                                else
                                {
                                    phAction.Visible = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!active)
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void Accept(object sender, EventArgs e)
		{
            if (SessionData.AdvertiserUser != null)
            {
                // Save acccepted Date for that AdvertiserUser
                JXTPortal.Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId);
                advuser.LastTermsAndConditionsDate = DateTime.Now;
                AdvertiserUsersService.Update(advuser);

                SessionData.AdvertiserUser.LastTermsAndConditionsDate = DateTime.Now;

                if (!string.IsNullOrEmpty(Request.Params["returnurl"]))
                {
                    Response.Redirect(Request.Params["returnurl"]);
                }
                else
                {
                    Response.Redirect("/advertiser/default.aspx");
                }
            }
            
		}

        protected void Cancel(object sender, EventArgs e)
		{
            SessionService.RemoveAdvertiserUser();
			Response.Redirect("/default.aspx");
		}
    }
}