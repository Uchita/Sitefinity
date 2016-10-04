using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.member
{
    public partial class MemberTerms : System.Web.UI.Page
    {
        private MembersService _membersservice;
        private MembersService MembersService
        {
            get
            {
                if (_membersservice == null)
                {
                    _membersservice = new MembersService();
                }
                return _membersservice;
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
                    if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions) && dynamiccontent.Active)
                    {
                        active = true;

                        ltTitle.Text = HttpUtility.HtmlEncode(dynamiccontent.Title);
                        ltIntroduction.Text = dynamiccontent.Introduction;
                        ltDescription.Text = dynamiccontent.Description;

                        // Check if member has already accepted the TC
                        if (SessionData.Member != null)
                        {
                            if (SessionData.Member.LastTermsAndConditionsDate.HasValue)
                            {
                                if (SessionData.Member.LastTermsAndConditionsDate.Value > dynamiccontent.LastModifiedDate)
                                {
                                    if (!string.IsNullOrEmpty(Request.Params["returnurl"]))
                                    {
                                        Response.Redirect(Request.Params["returnurl"]);
                                    }
                                    else
                                    {
                                        Response.Redirect("/member/default.aspx");
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

            if (!active)
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void Accept(object sender, EventArgs e)
        {
            if (SessionData.Member != null)
            {
                // Save acccepted Date for that Member
                JXTPortal.Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);
                member.LastTermsAndConditionsDate = DateTime.Now;
                
                MembersService.Update(member);

                SessionData.Member.LastTermsAndConditionsDate = DateTime.Now;

                if (!string.IsNullOrEmpty(Request.Params["returnurl"]))
                {
                    Response.Redirect(Request.Params["returnurl"]);
                }
                else
                {
                    Response.Redirect("/member/default.aspx");
                }
            }

        }

        protected void Cancel(object sender, EventArgs e)
        {
            SessionService.RemoveMember();
            Response.Redirect("/default.aspx");
        }
    }
}