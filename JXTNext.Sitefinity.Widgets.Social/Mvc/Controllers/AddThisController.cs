using JXTNext.Sitefinity.Widgets.Social.Mvc.Models.AddThis;
using JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    /// <summary>
    /// This class represents the controller of the AddThis widget.
    /// </summary>
    [Localization(typeof(AddThisResources))]
    [ControllerToolboxItem(Name = "AddThis_MVC", Title = "AddThis", SectionName = "Social", CssClass = AddThisController.WidgetIconCssClass)]
    public class AddThisController : Controller, ICustomWidgetVisualizationExtended, IPersonalizable
    {
        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfPageSharingIcn sfMvcIcn";
        private IAddThisModel model;

        private string templateName = "AddThis";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the widget model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual IAddThisModel Model
        {
            get
            {
                if (this.model == null)
                {
                    this.model = ControllerModelFactory.GetModel<IAddThisModel>(this.GetType());
                }

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
                return Res.Get<AddThisResources>().SetupServices;
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
        /// Gets a value indicating whether widget is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if widget has no services selected; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.Model.IsEmpty();
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
    }
}
