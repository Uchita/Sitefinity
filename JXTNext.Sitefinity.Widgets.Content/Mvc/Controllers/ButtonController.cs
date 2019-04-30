using JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Services;

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
                if (this._model == null)
                {
                    this._model = ControllerModelFactory.GetModel<IButtonModel>(this.GetType());
                }

                return this._model;
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

        public ActionResult Index()
        {
            var viewModel = Model.GetViewModel();

            return View(_templateName, viewModel);
        }

        /// <inheritDoc/>
        protected override void HandleUnknownAction(string actionName)
        {
            ActionInvoker.InvokeAction(ControllerContext, "Index");
        }

        #endregion

        #region Private methods        

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfButtonIcn sfMvcIcn";

        private IButtonModel _model;

        private string _templateName = "Button";

        #endregion
    }
}
