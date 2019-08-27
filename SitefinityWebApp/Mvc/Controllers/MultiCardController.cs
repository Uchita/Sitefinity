using SitefinityWebApp.Mvc.Models.MultiCard;
using SitefinityWebApp.Mvc.StringResources;
using System;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using System.Linq;
using JXTNext.Telemetry;
using Telerik.Sitefinity.Data.ContentLinks;
using Telerik.Sitefinity.Modules.Libraries;

namespace SitefinityWebApp.Mvc.Controllers
{
    [Localization(typeof(CardsWidgetResources))]
    [ControllerToolboxItem(Name = "MultiCard_Mvc", Title = "Multi Card", SectionName = ToolboxesConfig.ContentToolboxSectionName, CssClass = MultiCardController.WidgetIconCssClass)]
    public class MultiCardController : Controller, ICustomWidgetVisualizationExtended, IPersonalizable
    {
        #region Properties

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual MultiCardModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = ControllerModelFactory.GetModel<MultiCardModel>(this.GetType());

                return this.model;
            }
        }

        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.Model.IsEmpty();
            }
        }

        public string WidgetCssClass
        {
            get
            {
                return WidgetIconCssClass;
            }
        }

        public string EmptyLinkText
        {
            get
            {
                return Res.Get<CardsWidgetResources>().CreateContent;
            }
        }

        protected virtual bool IsDesignMode
        {
            get
            {
                return SystemManager.IsDesignMode;
            }
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            //Telerik.Sitefinity.Security.UserManager userManager = Telerik.Sitefinity.Security.UserManager.GetManager();
            //Telerik.Sitefinity.Security.UserProfileManager userProfileManager = Telerik.Sitefinity.Security.UserProfileManager.GetManager();
            //Telerik.Sitefinity.Security.Model.User user = userManager.GetUserByEmail("careers@nzme.co.nz");
            //var consultantProfile = userProfileManager.GetUserProfiles(user).Where(c => c.GetType().FullName.ToUpper().Contains("CONSULTANTPROFILE")).FirstOrDefault();
            //Telerik.Sitefinity.Model.ContentLinks.ContentLink contentLink = (Telerik.Sitefinity.Model.ContentLinks.ContentLink) (Telerik.Sitefinity.Model.DataExtensions.GetValue(consultantProfile, "Banner"));

            //var image = LibrariesManager.GetManager().GetImage(contentLink.ChildItemId);

            //if (this.IsEmpty)
            //{
            //    return new EmptyResult();
            //}

            using (new StatsDPerformanceMeasure("MultiCardController.Index"))
            {
                var viewModel = this.Model.GetViewModel();

                var fullTemplateName = templatePrefix + this.TemplateName;

                return View(fullTemplateName, viewModel);
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            using (new StatsDPerformanceMeasure("MultiCardController.HandleUnknownAction"))
            {
                this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
            }
        }

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfMultiCardIcn sfMvcIcn";
        private MultiCardModel model;

        private string templateName = "Icons";
        private string templatePrefix = "Cards.";

        #endregion
    }
}
