using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_MedianSalaryGraphWidget", Title = "Median Salary Graph", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class MedianSalaryGraphController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string PlotLinesColour { get; set; }
        public string SeriesBarColour { get; set; }
        public string SeriesSplineColour { get; set; }

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
        private MedianSalaryGraphViewModel _GetViewModel(string templateName, object form = null)
        {
            var model = new MedianSalaryGraphViewModel();

            // populate widget properties
            model.Widget = new MedianSalaryGraphWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Median {0}" : this.Heading,
                Introduction = this.Introduction,

                PlotLinesColour = string.IsNullOrEmpty(this.PlotLinesColour) ? "#808080" : this.PlotLinesColour,
                SeriesBarColour = string.IsNullOrEmpty(this.SeriesBarColour) ? "#1dbe9b" : this.SeriesBarColour,
                SeriesSplineColour = string.IsNullOrEmpty(this.SeriesSplineColour) ? "#14725C" : this.SeriesSplineColour
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
