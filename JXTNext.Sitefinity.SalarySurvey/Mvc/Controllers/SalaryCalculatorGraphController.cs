using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_SalaryCalculatorGraphWidget", Title = "Salary Calculator Graph", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class SalaryCalculatorGraphController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string PlotLinesColour { get; set; }
        public string SalaryIncreaseSplineColour { get; set; }
        public string SuperIncreaseSplineColour { get; set; }
        public string TotalIncreaseSplineColour { get; set; }

        #endregion        

        #region Controllers

        public ActionResult Index()
        {
            var templateName = "Default";

            return View(templateName, _GetViewModel(templateName));
        }

        #endregion

        #region Private methods        

        /// <summary>
        /// Create and initialise the view model.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private SalaryCalculatorGraphViewModel _GetViewModel(string templateName, object form = null)
        {
            var model = new SalaryCalculatorGraphViewModel();

            // populate widget properties
            model.Widget = new SalaryCalculatorGraphWidgetModel
            {
                Heading = this.Heading,
                Introduction = this.Introduction,

                PlotLinesColour = this.PlotLinesColour,
                SalaryIncreaseSplineColour = this.SalaryIncreaseSplineColour,
                SuperIncreaseSplineColour = this.SuperIncreaseSplineColour,
                TotalIncreaseSplineColour = this.TotalIncreaseSplineColour
            };

            return model;
        }

        #endregion

        #region Overridden methods

        protected override void HandleUnknownAction(string actionName)
        {
            ActionInvoker.InvokeAction(ControllerContext, "Index");
        }

        #endregion
    }
}
