using System;
using System.Collections.Generic;
using System.Linq;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.SalarySurvey.Helpers;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Multisite;
using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using Telerik.Sitefinity.Taxonomies;
using Newtonsoft.Json;
using System.Web;
using Telerik.Sitefinity.Configuration;
using JXTNext.Sitefinity.SalarySurvey.Admin;
using JXTNext.Sitefinity.SalarySurvey.Database;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_SalaryCountWidget", Title = "Salary Count", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class SalaryCountController : Controller
    {
        #region Widget designer properties

        public bool LastWeekSalariesEnabled { get; set; } = true;
        public string LastWeekSalariesLabel { get; set; } = "Last week salaries:";

        public bool TotalSalariesEnabled { get; set; } = true;
        public string TotalSalariesLabel { get; set; } = "Total salaries:";

        #endregion

        #region GET methods        

        public ActionResult Index()
        {
            var viewModel = _GetViewModel();

            var siteId = GenericHelper.GetCurrentSiteId();

            var dbContext = SalarySurveyDbContext.CreateInstance();            

            // get salaries posted in last 7 days
            if (viewModel.Widget.LastWeekSalariesEnabled)
            {
                var sevenDaysAgo = DateTime.Now.AddDays(-7);

                viewModel.LastWeekSalaries = dbContext.Salary
                    .Count(s => s.SiteId == siteId && s.Verified == true && s.CreatedDate >= sevenDaysAgo);
            }

            // get salaries posted till date
            if (viewModel.Widget.TotalSalariesEnabled)
            {
                viewModel.TotalSalaries = dbContext.Salary
                    .Count(s => s.SiteId == siteId && s.Verified == true);
            }

            return View("Default", viewModel);
        }

        #endregion

        #region Private methods

        private SalaryCountViewModel _GetViewModel()
        {
            var model = new SalaryCountViewModel();

            // populate widget properties
            model.Widget = new SalaryCountWidgetModel
            {
                LastWeekSalariesEnabled = this.LastWeekSalariesEnabled,
                LastWeekSalariesLabel = this.LastWeekSalariesLabel,

                TotalSalariesEnabled = this.TotalSalariesEnabled,
                TotalSalariesLabel = this.TotalSalariesLabel
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
