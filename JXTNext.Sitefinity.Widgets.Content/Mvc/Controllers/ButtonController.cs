using JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;
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
    public class ButtonController : Controller, ICustomWidgetVisualizationExtended, IPersonalizable
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
                    this.model = ControllerModelFactory.GetModel<IButtonModel>(this.GetType());

                return this.model;
            }
        }

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Gets a value indicating whether widget is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if widget has no image selected; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.Model.IsEmpty();
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

        /// <inheritdoc />
        public string EmptyLinkText
        {
            get
            {
                return Res.Get<ButtonResources>().CreateContent;
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

        /// <summary>
        /// Gets the image was not selected or has been deleted message.
        /// </summary>
        /// <value>The image was not selected or has been deleted message.</value>
        protected virtual string ImageWasNotSelectedOrHasBeenDeletedMessage
        {
            get
            {
                return Res.Get<ButtonResources>().ImageWasNotSelectedOrHasBeenDeleted;
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
            if (this.IsEmpty)
            {
                return new EmptyResult();
            }

            var viewModel = this.Model.GetViewModel();

            return View(this.TemplateName, viewModel);
        }

        /// <inheritDoc/>
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfButtonIcn sfMvcIcn";
        private IButtonModel model;

        private string templateName = "Button";

        #endregion
    }
}
