using JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Controllers
{
    /// <summary>
    /// This class represents the controller of the Button widget.
    /// </summary>
    [Localization(typeof(ButtonResources))]
    [ControllerToolboxItem(Name = "Button_MVC", Title = "Button", SectionName = "JXTNext.Content", CssClass = ButtonController.WidgetIconCssClass)]
    public class ButtonController : Controller, IPersonalizable
    {
        #region Properties

        /// <summary>
        /// Gets the Button widget model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual IButtonModel Model
        {
            get
            {
                if (this.model == null)
                {
                    this.model = ControllerModelFactory.GetModel<IButtonModel>(this.GetType());
                }

                return this.model;
            }
        }

        /// <inheritdoc />
        public string WidgetCssClass
        {
            get
            {
                return WidgetIconCssClass;
            }
        }

        /// <summary>
        /// Gets the is design mode.
        /// </summary>
        /// <value>The is design mode.</value>
        protected virtual bool IsDesignMode
        {
            get
            {
                return SystemManager.IsDesignMode;
            }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Renders appropriate list view depending on the <see cref="ListTemplateName" />
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Index()
        {
            var viewModel = GetViewModel();

            return View(_templateName, viewModel);
        }

        /// <inheritDoc/>
        protected override void HandleUnknownAction(string actionName)
        {
            ActionInvoker.InvokeAction(ControllerContext, "Index");
        }

        #endregion

        #region Private methods

        private ButtonViewModel GetViewModel()
        {
            var viewModel = new ButtonViewModel()
            {
                ButtonLabel = string.IsNullOrWhiteSpace(Model.ButtonLabel) ? "Untitled Button" : Model.ButtonLabel,
                ActionUrl = Model.GetLinkedUrl(),
                ButtonAlignment = Model.ButtonAlignment,
                CssClass = Model.GetCssClasses()
            };

            return viewModel;
        }

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfButtonIcn sfMvcIcn";

        private IButtonModel model;

        private string _templateName = "Button";

        #endregion
    }
}
