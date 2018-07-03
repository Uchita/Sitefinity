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
            if(this.IsEmpty)
            {
                return new EmptyResult();
            }

            var viewModel = this.Model.GetViewModel();

            var fullTemplateName = templatePrefix + this.TemplateName;

            return View(fullTemplateName, viewModel);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
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
