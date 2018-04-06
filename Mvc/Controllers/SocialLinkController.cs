using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SocialLink_MVC", Title = "Social link", SectionName = "Social", CssClass = SocialLinkController.WidgetIconCssClass)]
    public class SocialLinkController : Controller
    {
        // All these properties are bind to the designer form 
        // Same will be displayed in the Advanced section of the designer form as text boxes
        [Category("Twitter Link")]
        public bool IsTwitterEnabled { get; set; }
        public string TwitterUrl { get; set; }

        [Category("Facebook Link")]
        public bool IsFbEnabled { get; set; }
        public string FbUrl { get; set; }

        [Category("LinkedIn Link")]
        public bool IsLinkedInEnabled { get; set; }
        public string LinkedInUrl { get; set; }

        [Category("Google+ Link")]
        public bool IsGooglePlusEnabled { get; set; }
        public string GooglePlusUrl { get; set; }

        [Category("YouTube Link")]
        public bool IsYouTubeEnabled { get; set; }
        public string YouTubeUrl { get; set; }

        [Category("Instagram Link")]
        public bool IsInstagramEnabled { get; set; }
        public string InstagramUrl { get; set; }

        [Category("MailTo Link")]
        public bool IsMailToEnabled { get; set; }
        public string MailToUrl { get; set; }

        [Category("CSS Class")]
        public string CssClass { get; set; }

        // GET: SocialLink
        public ActionResult Index()
        {
            // We need to return the model as a list of items
            List<SocialLinkModel> socialLinkModelList = new List<SocialLinkModel>();

            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;

            // We need display the links when the check box is selected and text box is not empty
            if (this.IsTwitterEnabled && !this.TwitterUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsTwitterEnabled,
                    DisplayName = "Twitter",
                    UrlPath = this.TwitterUrl,
                    EMCssClass = "fab fa-twitter"

                });
            }

            if (this.IsFbEnabled && !this.FbUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsFbEnabled,
                    DisplayName = "Facebook",
                    UrlPath = this.FbUrl,
                    EMCssClass = "fab fa-facebook"

                });
            }

            if (this.IsLinkedInEnabled && !this.LinkedInUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsLinkedInEnabled,
                    DisplayName = "LinkedIn",
                    UrlPath = this.LinkedInUrl,
                    EMCssClass = "fab fa-linkedin"

                });
            }

            if (this.IsGooglePlusEnabled && !this.GooglePlusUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsGooglePlusEnabled,
                    DisplayName = "Google+",
                    UrlPath = this.GooglePlusUrl,
                    EMCssClass = "fab fa-google-plus"

                });
            }

            if (this.IsYouTubeEnabled && !this.YouTubeUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsYouTubeEnabled,
                    DisplayName = "YouTube",
                    UrlPath = this.YouTubeUrl,
                    EMCssClass = "fab fa-youtube"

                });
            }

            if (this.IsInstagramEnabled && !this.InstagramUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsInstagramEnabled,
                    DisplayName = "Instagram",
                    UrlPath = this.InstagramUrl,
                    EMCssClass = "fab fa-instagram"

                });
            }

            if (this.IsMailToEnabled && !this.MailToUrl.IsNullOrEmpty())
            {
                socialLinkModelList.Add(new SocialLinkModel()
                {
                    IsSelected = this.IsMailToEnabled,
                    DisplayName = "MailTo",
                    UrlPath = this.MailToUrl,
                    EMCssClass = "fas fa-envelope"

                });
            }

            return View("Simple", socialLinkModelList);
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}