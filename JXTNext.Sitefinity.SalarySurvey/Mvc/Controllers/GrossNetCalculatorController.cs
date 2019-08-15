using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_GrossNetCalculatorWidget", Title = "Gross & Net Calculator", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class GrossNetCalculatorController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string SalaryLabel { get; set; }
        public string SalaryHelp { get; set; }
        public string MedicareLabel { get; set; }
        public string MedicareHelp { get; set; }
        public string SuperannuationLabel { get; set; }
        public string SuperannuationHelp { get; set; }
        public string WeeklyHoursLabel { get; set; }
        public string WeeklyHoursHelp { get; set; }
        public string PayeLabel { get; set; }
        public string PayeHelp { get; set; }
        public string TaxThresholdLabel { get; set; }
        public string TaxRateLabel { get; set; }
        public string SubmitButtonLabel { get; set; }
        public string ResultPage { get; set; }
        public bool ShowOptions { get; set; } = true;
        public bool ShowMoreLess { get; set; } = true;

        #endregion

        #region Controllers

        public ActionResult Index(GrossNetCalculatorFormModel form)
        {
            GrossNetCalculatorViewModel viewModel;

            var templateName = "Default";

            // make sure we are processing the correct form
            if (form.SalarySurveyAction != "calculate-gross-net")
            {
                ModelState.Clear();

                viewModel = _GetViewModel(templateName);

                return View(templateName, viewModel);
            }

            // validate tax brackets
            if (ModelState.IsValidField("TaxThresholds") && ModelState.IsValidField("TaxRates"))
            {
                if (form.TaxThresholds.Length != form.TaxRates.Length)
                {
                    ModelState.AddModelError("Paye", "Number of 'Tax Threshold' and 'Tax Rates' are not same.");
                }
                else
                {
                    int lastThreshold = 0;

                    foreach (var value in form.TaxThresholds)
                    {
                        if (value < 0 || value > 9999999)
                        {
                            ModelState.AddModelError("TaxThresholds", "'Tax Threshold' value should be between 1 and 9999999");

                            break;
                        }
                        else
                        {
                            if (value <= lastThreshold)
                            {
                                ModelState.AddModelError("TaxThresholds", "'Tax Threshold' value should be greater than previous value");

                                break;
                            }

                            lastThreshold = value;
                        }
                    }

                    foreach (var value in form.TaxRates)
                    {
                        if (value < 0 || value > 100)
                        {
                            ModelState.AddModelError("TaxRates", "'Tax Rate' value should be between 0 and 100");
                        }
                    }
                }
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

            viewModel = _GetViewModel(templateName, form);

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
        private void _PerformCalculation(GrossNetCalculatorViewModel viewModel)
        {
            var weeklyHours = viewModel.Form.WeeklyHours;

            // calcute annual salary and hourly rate
            decimal salary;
            decimal hourlyRate;
            if (viewModel.Form.Salary > 1000)
            {
                salary = viewModel.Form.Salary;

                hourlyRate = viewModel.Form.Salary / 52 / weeklyHours;
            }
            else
            {
                salary = Math.Round(viewModel.Form.Salary * weeklyHours * 52, 2);

                hourlyRate = viewModel.Form.Salary;
            }

            // calculate PAYE
            decimal taxable;
            decimal paye = 0m;
            int bandLower = 0;
            var totalTaxBands = viewModel.Form.TaxThresholds.Length;
            for (var i = 0; i < totalTaxBands; i++)
            {
                if (i > 0)
                {
                    bandLower = viewModel.Form.TaxThresholds[i - 1];
                }

                if (salary > bandLower)
                {
                    taxable = Math.Min(viewModel.Form.TaxThresholds[i] - bandLower, salary - bandLower);

                    paye += taxable * viewModel.Form.TaxRates[i] / 100;
                }
            }

            // calculate before tax
            var beforeTaxH = Math.Round(hourlyRate, 2);
            var beforeTaxW = Math.Round(hourlyRate * weeklyHours, 2);
            var beforeTaxF = Math.Round(hourlyRate * weeklyHours * 2, 2);
            var beforeTaxM = Math.Round(salary / 12, 2);
            var beforeTaxY = Math.Round(salary, 2);

            // calculate tax
            var taxH = Math.Round(paye / 52 / weeklyHours, 2);
            var taxW = Math.Round(paye / 52, 2);
            var taxF = Math.Round(paye / 26, 2);
            var taxM = Math.Round(paye / 12, 2);
            var taxY = Math.Round(paye, 2);

            // calculate medicare
            var taxBandUpper1 = totalTaxBands == 0 ? 0 : viewModel.Form.TaxThresholds[0];
            var medicare = beforeTaxY > taxBandUpper1 ? ((beforeTaxY - taxBandUpper1) * viewModel.Form.MedicareRate / 100) : 0;
            var medicareH = Math.Round(medicare / 52 / weeklyHours, 2);
            var medicareW = Math.Round(medicare / 52, 2);
            var medicareF = Math.Round(medicare / 26, 2);
            var medicareM = Math.Round(medicare / 12, 2);
            var medicareY = Math.Round(medicare, 2);

            // calculate super
            var super = viewModel.Form.SuperRate > 0 ? (salary * viewModel.Form.SuperRate / 100) : 0;
            var superH = Math.Round(super / 52 / weeklyHours, 2);
            var superW = Math.Round(super / 52, 2);
            var superF = Math.Round(super / 26, 2);
            var superM = Math.Round(super / 12, 2);
            var superY = Math.Round(super, 2);

            viewModel.HourlyBeforeTax = beforeTaxH;
            viewModel.HourlyTax = taxH;
            viewModel.HourlyMedicare = medicareH;
            viewModel.HourlySuper = superH;
            viewModel.HourlyAfterTax = beforeTaxH - taxH - medicareH - superH;

            viewModel.WeeklyBeforeTax = beforeTaxW;
            viewModel.WeeklyTax = taxW;
            viewModel.WeeklyMedicare = medicareW;
            viewModel.WeeklySuper = superW;
            viewModel.WeeklyAfterTax = beforeTaxW - taxW - medicareW - superW;

            viewModel.FortnightlyBeforeTax = beforeTaxF;
            viewModel.FortnightlyTax = taxF;
            viewModel.FortnightlyMedicare = medicareF;
            viewModel.FortnightlySuper = superF;
            viewModel.FortnightlyAfterTax = beforeTaxF - taxF - medicareF - superF;

            viewModel.MonthlyBeforeTax = beforeTaxM;
            viewModel.MonthlyTax = taxM;
            viewModel.MonthlyMedicare = medicareM;
            viewModel.MonthlySuper = superM;
            viewModel.MonthlyAfterTax = beforeTaxM - taxM - medicareM - superM;

            viewModel.YearlyBeforeTax = beforeTaxY;
            viewModel.YearlyTax = taxY;
            viewModel.YearlyMedicare = medicareY;
            viewModel.YearlySuper = superY;
            viewModel.YearlyAfterTax = beforeTaxY - taxY - medicareY - superY;
        }

        /// <summary>
        /// Create and initialise the view model.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private GrossNetCalculatorViewModel _GetViewModel(string templateName, GrossNetCalculatorFormModel form = null)
        {
            var settingsHelper = new SettingsHelper();

            var model = new GrossNetCalculatorViewModel();

            // populate widget properties
            model.Widget = new GrossNetCalculatorWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Gross and Net Calculator" : this.Heading,
                Introduction = this.Introduction,

                SalaryLabel = string.IsNullOrEmpty(this.SalaryLabel) ? "Wage or Salary" : this.SalaryLabel,
                SalaryHelp = string.IsNullOrEmpty(this.SalaryHelp) ? "Values less than or equal to 1000 will be considered hourly" : this.SalaryHelp,

                MedicareLabel = string.IsNullOrEmpty(this.MedicareLabel) ? "Medicare %" : this.MedicareLabel,
                MedicareHelp = this.MedicareHelp,

                SuperannuationLabel = string.IsNullOrEmpty(this.SuperannuationLabel) ? "Superannuation %" : this.SuperannuationLabel,
                SuperannuationHelp = this.SuperannuationHelp,

                WeeklyHoursLabel = string.IsNullOrEmpty(this.WeeklyHoursLabel) ? "Work Hours Per Week" : this.WeeklyHoursLabel,
                WeeklyHoursHelp = this.WeeklyHoursHelp,

                PayeLabel = string.IsNullOrEmpty(this.PayeLabel) ? "PAYE" : this.PayeLabel,
                PayeHelp = this.PayeHelp,

                TaxThresholdLabel = string.IsNullOrEmpty(this.TaxThresholdLabel) ? "Tax Thresholds (" + settingsHelper.CurrencySymbol + ")" : this.TaxThresholdLabel,

                TaxRateLabel = string.IsNullOrEmpty(this.TaxRateLabel) ? "Tax Rates (%)" : this.TaxRateLabel,

                ResultPage = string.IsNullOrEmpty(this.ResultPage) ? null : this.ResultPage,

                SubmitButtonLabel = string.IsNullOrEmpty(this.SubmitButtonLabel) ? "Calculate" : this.SubmitButtonLabel,

                ShowOptions = this.ShowOptions,
                ShowMoreLess = this.ShowMoreLess
            };

            model.Form = form;

            model.CurrencySymbol = settingsHelper.CurrencySymbol;
            model.SuperRate = settingsHelper.SuperannuationRate;
            model.MedicareRate = settingsHelper.MedicareRate;
            model.WeeklyHours = settingsHelper.WeeklyHours;
            model.TaxBrackets = settingsHelper.TaxBrackets;

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
