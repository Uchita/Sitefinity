using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_SalaryCalculatorWidget", Title = "Salary Calculator", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class SalaryCalculatorController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string AnnualSalaryLabel { get; set; }
        public string AnnualSalaryHelp { get; set; }
        public string IncreasePerYearLabel { get; set; }
        public string IncreasePerYearHelp { get; set; }
        public string SuperannuationLabel { get; set; }
        public string SuperannuationHelp { get; set; }
        public string YearsLabel { get; set; }
        public string YearsHelp { get; set; }
        public string SubmitButtonLabel { get; set; }
        public string ResultPage { get; set; }

        #endregion

        #region Controllers

        public ActionResult Index(SalaryCalculatorFormModel form)
        {
            var templateName = "Default";

            // make sure we are processing the correct form
            if (form.SalarySurveyAction != "calculate-salary")
            {
                ModelState.Clear();

                return View(templateName, _GetViewModel(templateName));
            }

            // do not proceed if we have errors
            if (!ModelState.IsValid)
            {
                if (!ModelState.Keys.Contains(FormHelper.GenericErrorKey))
                {
                    ModelState.AddModelError(FormHelper.GenericErrorKey, FormHelper.GenericErrorMessage);
                }

                Response.StatusCode = 422;

                return View(templateName, _GetViewModel(templateName, form));
            }

            var viewModel = _GetViewModel(templateName, form);

            try
            {
                _PerformCalculation(viewModel);

                viewModel.ShowResult = true;
            }
            catch (Exception err)
            {
                ModelState.AddModelError(FormHelper.GenericErrorKey, err.Message);

                while (err.InnerException != null)
                {
                    err = err.InnerException;

                    ModelState.AddModelError(FormHelper.GenericErrorKey, err.Message);
                }
            }

            return View(templateName, viewModel);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Perform the calculation on submitted data.
        /// </summary>
        /// <param name="viewModel"></param>
        private void _PerformCalculation(SalaryCalculatorViewModel viewModel)
        {
            var settingsHelper = new SettingsHelper();

            var annualSalary = (decimal)viewModel.Form.AnnualSalary;
            var superRate = viewModel.Form.SuperRate.HasValue ? Math.Round(viewModel.Form.SuperRate.Value, 2) / 100 : 0m;

            decimal lastIncrease = 0;

            SalaryCalculatorResultModel resultModel = null;

            if (settingsHelper.SalaryCalculatorIncreaseByPercentage)
            {
                // do calculation based on %                

                var currentAnnualSalary = annualSalary;

                decimal increase;

                for (var y = 1; y <= viewModel.Form.Years; y++)
                {
                    increase = Math.Round((decimal)currentAnnualSalary * viewModel.Form.IncreasePerYear / 100, 2);

                    currentAnnualSalary += increase;

                    resultModel = new SalaryCalculatorResultModel();
                    resultModel.Year = y;
                    resultModel.SalaryIncrease = increase + lastIncrease;
                    resultModel.SuperIncrease = Math.Round((currentAnnualSalary * superRate) - (annualSalary * superRate), 2);
                    resultModel.TotalIncrease = resultModel.SalaryIncrease + resultModel.SuperIncrease;

                    viewModel.Result.Add(resultModel);

                    lastIncrease = resultModel.SalaryIncrease;
                }

                if (resultModel != null)
                {
                    viewModel.ExtraSalary = resultModel.SalaryIncrease;
                    viewModel.ExtraSuper = Math.Round(viewModel.ExtraSalary * superRate, 2);
                }
            }
            else
            {
                // do calculation based amount

                var lastIncreaseInSuper = 0m;

                viewModel.ExtraSalary = viewModel.Form.IncreasePerYear * viewModel.Form.Years;
                viewModel.ExtraSuper = Math.Round(viewModel.ExtraSalary * superRate, 2);

                for (var y = 1; y <= viewModel.Form.Years; y++)
                {
                    resultModel = new SalaryCalculatorResultModel();
                    resultModel.Year = y;
                    resultModel.SalaryIncrease = viewModel.Form.IncreasePerYear + lastIncrease;
                    resultModel.SuperIncrease = Math.Round(((annualSalary + viewModel.Form.IncreasePerYear) * superRate) - (annualSalary * superRate), 2) + lastIncreaseInSuper;
                    resultModel.TotalIncrease = resultModel.SalaryIncrease + resultModel.SuperIncrease;

                    viewModel.Result.Add(resultModel);

                    lastIncrease = resultModel.SalaryIncrease;
                    lastIncreaseInSuper = resultModel.SuperIncrease;
                }
            }
        }

        /// <summary>
        /// Create and initialise the view model.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private SalaryCalculatorViewModel _GetViewModel(string templateName, SalaryCalculatorFormModel form = null)
        {
            var settingsHelper = new SettingsHelper();

            var model = new SalaryCalculatorViewModel();

            // populate widget properties
            model.Widget = new SalaryCalculatorWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Salary Calculator" : this.Heading,
                Introduction = this.Introduction,

                AnnualSalaryLabel = string.IsNullOrEmpty(this.AnnualSalaryLabel) ? "Annual Salary" : this.AnnualSalaryLabel,
                AnnualSalaryHelp = this.AnnualSalaryHelp,

                IncreasePerYearLabel = string.IsNullOrEmpty(this.IncreasePerYearLabel) ? "Increase Per Year" : this.IncreasePerYearLabel,
                IncreasePerYearHelp = this.IncreasePerYearHelp,

                YearsLabel = string.IsNullOrEmpty(this.YearsLabel) ? "How Many Years" : this.YearsLabel,
                YearsHelp = this.YearsHelp,

                SuperannuationLabel = string.IsNullOrEmpty(this.SuperannuationLabel) ? "Superannuation Rate" : this.SuperannuationLabel,
                SuperannuationHelp = this.SuperannuationHelp,

                ResultPage = string.IsNullOrEmpty(this.ResultPage) ? null : this.ResultPage,

                SubmitButtonLabel = string.IsNullOrEmpty(this.SubmitButtonLabel) ? "Calculate" : this.SubmitButtonLabel
            };

            model.Form = form;

            model.CurrencySymbol = settingsHelper.CurrencySymbol;

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
