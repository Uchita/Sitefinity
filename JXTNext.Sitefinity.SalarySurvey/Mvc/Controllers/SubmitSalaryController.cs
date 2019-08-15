using System;
using System.Collections.Generic;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Taxonomies.Model;
using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Multisite;
using System.Linq;
using JXTNext.Sitefinity.SalarySurvey.Database;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using JXTNext.Sitefinity.Connector.Options;
using System.Web;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SalarySurvey_SubmitSalaryWidget", Title = "Submit Salary", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class SubmitSalaryController : Controller
    {
        const int MaxAnnualMoneyToLeave = 200000;
        const int MaxHourlyMoneyToLeave = 200;

        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string CurrentJobHeading { get; set; }
        public string CurrentJobIntroduction { get; set; }
        public string CurrentEmployerHeading { get; set; }
        public string CurrentEmployerIntroduction { get; set; }
        public string NextCareerHeading { get; set; }
        public string NextCareerIntroduction { get; set; }
        public string OptionalHeading { get; set; }
        public string OptionalIntroduction { get; set; }
        public string SubmitButtonLabel { get; set; }
        public string ThankYouPage { get; set; }
        public string ThankYouMessage { get; set; }
        public string ResultPage { get; set; }
        public string CountryLabel { get; set; }
        public string CountryHelp { get; set; }
        public string LocationLabel { get; set; }
        public string LocationHelp { get; set; }
        public string IndustryLabel { get; set; }
        public string IndustryHelp { get; set; }
        public string ClassificationLabel { get; set; }
        public string ClassificationHelp { get; set; }
        public string SubClassificationLabel { get; set; }
        public string SubClassificationHelp { get; set; }
        public string JobTypeLabel { get; set; }
        public string JobTypeHelp { get; set; }
        public string AnnualSalaryLabel { get; set; }
        public string AnnualSalaryHelp { get; set; }
        public string HourlyRateLabel { get; set; }
        public string HourlyRateHelp { get; set; }
        public string BonusLabel { get; set; }
        public string BonusHelp { get; set; }
        public string BenefitLabel { get; set; }
        public string BenefitHelp { get; set; }
        public string BenefitOtherLabel { get; set; }
        public string BenefitOtherPlaceholder { get; set; }
        public string BenefitOtherHelp { get; set; }
        public string ProfessionalQualificationLabel { get; set; }
        public string ProfessionalQualificationHelp { get; set; }
        public string EducationLabel { get; set; }
        public string EducationHelp { get; set; }
        public string YearsOfExperienceLabel { get; set; }
        public string YearsOfExperienceHelp { get; set; }
        public string PeopleManagedLabel { get; set; }
        public string PeopleManagedHelp { get; set; }
        public string GenderLabel { get; set; }
        public string GenderHelp { get; set; }
        public string EmployerSizeLabel { get; set; }
        public string EmployerSizeHelp { get; set; }
        public string MoneyToLeaveLabel { get; set; }
        public string MoneyToLeaveHelp { get; set; }
        public string MotivatorPlaceHolder { get; set; }
        public string MotivatorOtherLabel { get; set; }
        public string MotivatorOtherPlaceHolder { get; set; }
        public string BestEmployerLabel { get; set; }
        public string BestEmployerHelp { get; set; }
        public string BestEmployerPlaceholder { get; set; }
        public int BestEmployerRows { get; set; }
        public string CareerMoveLabel { get; set; }
        public string CareerMoveHelp { get; set; }
        public string JobAlertIntroduction { get; set; }
        public string JobAlertLabel { get; set; }
        public string JobAlertHelp { get; set; }
        public string SalaryAlertIntroduction { get; set; }
        public string SalaryAlertLabel { get; set; }
        public string SalaryAlertHelp { get; set; }
        public string ContactRequestLabel { get; set; }
        public string ContactRequestHelp { get; set; }
        public string NameLabel { get; set; }
        public string NamePlaceholder { get; set; }
        public string NameHelp { get; set; }
        public string EmailLabel { get; set; }
        public string EmailPlaceholder { get; set; }
        public string EmailHelp { get; set; }
        public string PhoneLabel { get; set; }
        public string PhonePlaceholder { get; set; }
        public string PhoneHelp { get; set; }
        public string EmptyOptionLabel { get; set; }

        #endregion

        #region Constructors / dependency injection methods

        IOptionsConnector _OConnector;
        IJobAlertService _jobAlertService;

        public SubmitSalaryController(IEnumerable<IOptionsConnector> _oConnectors, IJobAlertService jobAlertService)
        {
            _jobAlertService = jobAlertService;
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        #endregion

        #region GET methods

        /// <summary>
        /// Display the submit form / thank you page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var action = Request.QueryString.Get("salary_survey_action");
            if (action == "thank-you")
            {
                return ThankYou();
            }

            var templateName = "Default";

            return View(templateName, _GetViewModel(templateName));
        }

        /// <summary>
        /// Display thank you page.
        /// </summary>
        /// <returns></returns>
        public ActionResult ThankYou()
        {
            var templateName = "ThankYou";

            return View(templateName, _GetViewModel(templateName));
        }

        /// <summary>
        /// Get list of locations of specified country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public ActionResult GetLocations(Guid countryId)
        {
            var result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            var settings = new SettingsHelper();

            // fetch locations only if country id is valid
            var taxon = GenericHelper.GetCategory(countryId);
            if (taxon == null || taxon.ParentId != settings.CountryTaxonomyId)
            {
                result.Data = new List<SelectListItem>();
            }
            else
            {
                result.Data = GenericHelper.GetCategoryItems(countryId);
            }

            return result;
        }

        /// <summary>
        /// Get list of classifications of specified industry.
        /// </summary>
        /// <param name="industryId"></param>
        /// <returns></returns>
        public ActionResult GetClassifications(Guid industryId)
        {
            var result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            var settings = new SettingsHelper();

            // fetch classifications only if industry id is valid
            var industry = GenericHelper.GetCategory(industryId);
            if (industry == null || industry.ParentId != settings.IndustryTaxonomyId)
            {
                result.Data = new List<SelectListItem>();
            }
            else
            {
                result.Data = GenericHelper.GetCategoryItems(industry.Id);
            }

            return result;
        }

        /// <summary>
        /// Get list of sub-classifications of specifed classification.
        /// </summary>
        /// <param name="industryId"></param>
        /// <param name="classificationId"></param>
        /// <returns></returns>
        public ActionResult GetSubClassifications(Guid industryId, Guid classificationId)
        {
            var result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            var settings = new SettingsHelper();

            // fetch sub-classifications only if industry id and classification id are valid
            var industry = GenericHelper.GetCategory(industryId);
            if (industry == null || industry.ParentId != settings.IndustryTaxonomyId)
            {
                result.Data = new List<SelectListItem>();
            }
            else
            {
                var classification = GenericHelper.GetCategory(classificationId);
                if (classification == null || classification.ParentId != industry.Id)
                {
                    result.Data = new List<SelectListItem>();
                }
                else
                {
                    result.Data = GenericHelper.GetCategoryItems(classification.Id);
                }
            }

            return result;
        }

        #endregion

        #region POST methods

        [HttpPost]
        public ActionResult Index(SubmitSalaryFormModel form)
        {
            var templateName = "Default";

            // make sure we are processing the correct form
            if (form.SalarySurveyAction != "submit")
            {
                ModelState.Clear();

                return View(templateName, _GetViewModel(templateName));
            }

            string fieldKey;
            HierarchicalTaxon taxon;

            var settings = new SettingsHelper();

            // validate country id
            fieldKey = "CountryId";
            if (ModelState.IsValidField(fieldKey))
            {
                taxon = GenericHelper.GetCategory(form.CountryId);
                if (taxon == null || taxon.ParentId != settings.CountryTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    // validate location id
                    fieldKey = "LocationId";
                    if (ModelState.IsValidField(fieldKey))
                    {
                        var location = GenericHelper.GetCategory(form.LocationId);

                        if (location == null || location.ParentId != taxon.Id)
                        {
                            ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                        }
                    }
                }
            }

            // validate industry id
            fieldKey = "IndustryId";
            if (ModelState.IsValidField(fieldKey))
            {
                taxon = GenericHelper.GetCategory(form.IndustryId);
                if (taxon == null || taxon.ParentId != settings.IndustryTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    // validate classification id
                    fieldKey = "ClassificationId";
                    if (ModelState.IsValidField(fieldKey))
                    {
                        var classification = GenericHelper.GetCategory(form.ClassificationId);
                        if (classification == null || classification.ParentId != taxon.Id)
                        {
                            ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                        }
                        else
                        {
                            // validate sub classification id
                            fieldKey = "SubClassificationId";
                            if (ModelState.IsValidField(fieldKey))
                            {
                                var subClassification = GenericHelper.GetCategory(form.SubClassificationId);

                                if (subClassification == null || subClassification.ParentId != classification.Id)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                }
                            }
                        }
                    }
                }
            }

            // validate job type
            fieldKey = "JobTypeId";
            if (ModelState.IsValidField(fieldKey))
            {
                taxon = GenericHelper.GetCategory(form.JobTypeId);
                if (taxon == null || taxon.ParentId != settings.JobTypeTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    // check whether to validate annual salary or hourly rate
                    bool annualSalary = true;
                    var annualSalaryTaxonomyIds = settings.AnnualSalaryJobTypeTaxonomyIds;
                    if (annualSalaryTaxonomyIds.Count > 0 && !annualSalaryTaxonomyIds.Contains(form.JobTypeId))
                    {
                        annualSalary = false;
                    }

                    // validate salary/rate
                    if (annualSalary)
                    {
                        if (settings.AnnualSalariesTaxonomyId == Guid.Empty)
                        {
                            fieldKey = "AnnualSalary";
                            if (ModelState.IsValidField(fieldKey))
                            {
                                if (form.AnnualSalary == null)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                                }
                            }
                        }
                        else
                        {
                            fieldKey = "AnnualSalaryId";
                            if (ModelState.IsValidField(fieldKey))
                            {
                                if (form.AnnualSalaryId == null)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(form.AnnualSalaryId.Value);
                                    if (taxon == null || taxon.ParentId != settings.AnnualSalariesTaxonomyId)
                                    {
                                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                    }
                                    else if (string.IsNullOrWhiteSpace(taxon.Name) || !int.TryParse(taxon.Name, out int parsedInt))
                                    {
                                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                    }
                                    else
                                    {
                                        form.AnnualSalary = parsedInt;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (settings.HourlyRatesTaxonomyId == Guid.Empty)
                        {
                            fieldKey = "HourlyRate";
                            if (ModelState.IsValidField(fieldKey))
                            {
                                if (form.HourlyRate == null)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                                }
                            }
                        }
                        else
                        {
                            fieldKey = "HourlyRateId";
                            if (ModelState.IsValidField(fieldKey))
                            {
                                if (form.HourlyRateId == null)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(form.HourlyRateId.Value);
                                    if (taxon == null || taxon.ParentId != settings.HourlyRatesTaxonomyId)
                                    {
                                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                    }
                                    else if (string.IsNullOrWhiteSpace(taxon.Name) || !int.TryParse(taxon.Name, out int parsedInt))
                                    {
                                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                    }
                                    else
                                    {
                                        form.HourlyRate = parsedInt;
                                    }
                                }
                            }
                        }
                    }

                    // validate money to leave
                    fieldKey = "MoneyToLeave";
                    if (ModelState.IsValidField(fieldKey) && form.MoneyToLeave.HasValue)
                    {
                        int value = form.MoneyToLeave.Value;

                        if (annualSalary)
                        {
                            if (value > 200000 || (value != -1 && value != 100 && value % 500 != 0))
                            {
                                ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                            }
                        }
                        else
                        {
                            if (value > 200 || (value != -1 && value > 50 && value % 10 != 0))
                            {
                                ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                            }
                        }
                    }
                }
            }

            // validate bonus amount
            if (settings.BonusAmountsTaxonomyId != Guid.Empty)
            {
                fieldKey = "BonusAmountId";
                if (ModelState.IsValidField(fieldKey) && form.BonusAmountId != null)
                {
                    taxon = GenericHelper.GetCategory(form.BonusAmountId.Value);
                    if (taxon == null || taxon.ParentId != settings.BonusAmountsTaxonomyId)
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                    }
                    else if (string.IsNullOrWhiteSpace(taxon.Name) || !int.TryParse(taxon.Name, out int parsedInt))
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                    }
                    else
                    {
                        form.BonusAmount = parsedInt;
                    }
                }
            }

            // validate benefit id
            fieldKey = "BenefitId";
            if (ModelState.IsValidField(fieldKey) && form.BenefitId != null)
            {
                foreach (var item in form.BenefitId)
                {
                    taxon = GenericHelper.GetCategory(item);
                    if (taxon == null || taxon.ParentId != settings.BenefitTaxonomyId)
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);

                        break;
                    }
                }
            }

            // validate education
            fieldKey = "EducationId";
            if (ModelState.IsValidField(fieldKey) && form.EducationId != null)
            {
                taxon = GenericHelper.GetCategory(form.EducationId.Value);
                if (taxon == null || taxon.ParentId != settings.EducationTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
            }

            // validate years of experience
            fieldKey = "YearsOfExperienceId";
            if (ModelState.IsValidField(fieldKey) && form.YearsOfExperienceId != null)
            {
                taxon = GenericHelper.GetCategory(form.YearsOfExperienceId.Value);
                if (taxon == null || taxon.ParentId != settings.YearsOfExperienceTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
            }

            // validate people managed id
            fieldKey = "PeopleManagedId";
            if (ModelState.IsValidField(fieldKey) && form.PeopleManagedId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.PeopleManagedId.Value);
                if (taxon == null || taxon.ParentId != settings.PeopleManagedTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
            }

            // validate gender id
            fieldKey = "GenderId";
            if (ModelState.IsValidField(fieldKey) && form.GenderId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.GenderId.Value);
                if (taxon == null || taxon.ParentId != settings.GenderTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
            }

            // validate employer size id
            fieldKey = "EmployerSizeId";
            if (ModelState.IsValidField(fieldKey) && form.EmployerSizeId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.EmployerSizeId.Value);
                if (taxon == null || taxon.ParentId != settings.EmployerSizeTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
            }

            // validate motivator order
            fieldKey = "MotivatorOrder";
            if (ModelState.IsValidField(fieldKey) && form.MotivatorOrder != null)
            {
                foreach (var item in form.MotivatorOrder)
                {
                    taxon = GenericHelper.GetCategory(new Guid(item.Key));
                    if (taxon == null || taxon.ParentId != settings.MotivatorTaxonomyId)
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);

                        break;
                    }
                }
            }

            // validate best employer
            fieldKey = "BestEmployer";
            if (ModelState.IsValidField(fieldKey))
            {
                foreach (var item in form.BestEmployer)
                {
                    if (item.Length > 255)
                    {
                        ModelState.AddModelError(fieldKey, "Value length must not be greater than 255");

                        break;
                    }
                }
            }

            // validate career move
            fieldKey = "CareerMoveId";
            if (ModelState.IsValidField(fieldKey) && form.CareerMoveId != null)
            {
                foreach (var item in form.CareerMoveId)
                {
                    taxon = GenericHelper.GetCategory(item);
                    if (taxon == null || taxon.ParentId != settings.CareerMoveTaxonomyId)
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);

                        break;
                    }
                }
            }

            // validate name and phone
            if (form.ContactRequest)
            {
                fieldKey = "Name";
                if (ModelState.IsValidField(fieldKey))
                {
                    if (string.IsNullOrWhiteSpace(form.Name))
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                    }
                }

                fieldKey = "Phone";
                if (ModelState.IsValidField(fieldKey))
                {
                    if (string.IsNullOrWhiteSpace(form.Name))
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                    }
                }
            }

            // validate email
            if (form.JobAlert || form.SalaryAlert)
            {
                fieldKey = "Email";
                if (ModelState.IsValidField(fieldKey))
                {
                    if (string.IsNullOrWhiteSpace(form.Email))
                    {
                        ModelState.AddModelError(fieldKey, FormHelper.RequiredFieldMessage);
                    }
                }
            }

            var isAjaxRequest = Request.IsAjaxRequest();

            // do not proceed if we have errors
            if (!ModelState.IsValid)
            {
                if (!ModelState.Keys.Contains(FormHelper.GenericErrorKey))
                {
                    ModelState.AddModelError(FormHelper.GenericErrorKey, FormHelper.GenericErrorMessage);
                }

                Response.StatusCode = 422;

                if (isAjaxRequest)
                {
                    return Json(new { errors = FormHelper.ModelStateErrors(ModelState) });
                }

                return View(templateName, _GetViewModel(templateName, form));
            }

            try
            {
                // create the salary
                var salaryId = GenericHelper.CreateSalary(form);
                if (salaryId == null)
                {
                    ModelState.AddModelError(FormHelper.GenericErrorKey, "Unable to save the salary due to an unknown error. Please try again.");
                }
                else
                {
                    // create job alert
                    if (form.JobAlert)
                    {
                        _CreateJobAlert(form);
                    }

                    // show thank you message or matching results
                    if (string.IsNullOrWhiteSpace(ResultPage))
                    {
                        return _RedirectToThankYouPage();
                    }
                    else
                    {
                        return _RedirectToResultsPage(form);
                    }
                }
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

            return View(templateName, _GetViewModel(templateName, form));
        }

        #endregion

        #region Private methods        

        /// <summary>
        /// Redirect to set thank you page.
        /// If none set the use current page.
        /// </summary>
        /// <returns></returns>
        private ActionResult _RedirectToThankYouPage()
        {
            if (string.IsNullOrWhiteSpace(ThankYouPage))
            {
                var manager = PageManager.GetManager();
                var node = SiteMapBase.GetActualCurrentNode();

                return new RedirectResult(node.Url + "?salary_survey_action=thank-you");
            }
            else
            {
                return new RedirectResult(ThankYouPage + "?salary_survey_action=thank-you");
            }
        }

        /// <summary>
        /// Redirect to set results page.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private ActionResult _RedirectToResultsPage(SubmitSalaryFormModel form)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters["JobTypeId"] = form.JobTypeId.ToString();
            parameters["CountryId"] = form.CountryId.ToString();
            parameters["LocationId"] = form.LocationId.ToString();
            parameters["IndustryId"] = form.IndustryId.ToString();
            parameters["ClassificationId"] = form.ClassificationId.ToString();
            parameters["SubClassificationId"] = form.SubClassificationId.ToString();

            //## Temporary fix to exclude years of exp from search filter ##

            //if (form.YearsOfExperienceId.HasValue)
            //{
            //    parameters["YearsOfExperienceId"] = form.YearsOfExperienceId.Value.ToString();
            //}

            parameters["SalarySurveyAction"] = "search";

            return new RedirectResult(ResultPage + "?" + parameters.ToString());
        }

        /// <summary>
        /// Create a job alert based on the submitted data.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private bool _CreateJobAlert(SubmitSalaryFormModel form)
        {
            var jobAlertData = new JobAlertViewModel();

            jobAlertData.Name = "Job Alert";
            jobAlertData.Email = form.Email;
            jobAlertData.EmailAlerts = true;

            var response = _jobAlertService.MemberJobAlertUpsert(jobAlertData);

            return response == null ? false : response.Success;
        }

        /// <summary>
        /// Create and initialise the view model.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private SubmitSalaryViewModel _GetViewModel(string templateName, SubmitSalaryFormModel form = null)
        {
            var settings = new SettingsHelper();

            var model = new SubmitSalaryViewModel();

            // populate widget properties
            model.Widget = new SubmitSalaryWidgetModel
            {
                Heading = this.Heading,
                Introduction = this.Introduction,
                ThankYouMessage = string.IsNullOrEmpty(this.ThankYouMessage) ? "Thank you for submitting your salary." : this.ThankYouMessage,
                CurrentJobHeading = string.IsNullOrEmpty(this.CurrentJobHeading) ? "Current Job" : this.CurrentJobHeading,
                CurrentJobIntroduction = this.CurrentJobIntroduction,
                CurrentEmployerHeading = string.IsNullOrEmpty(this.CurrentEmployerHeading) ? "Current Employer" : this.CurrentEmployerHeading,
                CurrentEmployerIntroduction = this.CurrentEmployerIntroduction,
                NextCareerHeading = string.IsNullOrEmpty(this.NextCareerHeading) ? "Next Career Move" : this.NextCareerHeading,
                NextCareerIntroduction = this.NextCareerIntroduction,
                OptionalHeading = string.IsNullOrEmpty(this.OptionalHeading) ? "Optional" : this.OptionalHeading,
                OptionalIntroduction = this.OptionalIntroduction,

                CountryLabel = string.IsNullOrEmpty(this.CountryLabel) ? "Country" : this.CountryLabel,
                CountryHelp = this.CountryHelp,
                LocationLabel = string.IsNullOrEmpty(this.LocationLabel) ? "Location" : this.LocationLabel,
                LocationHelp = this.LocationHelp,
                IndustryLabel = string.IsNullOrEmpty(this.IndustryLabel) ? "Industry" : this.IndustryLabel,
                IndustryHelp = this.IndustryHelp,
                ClassificationLabel = string.IsNullOrEmpty(this.ClassificationLabel) ? "Classification" : this.ClassificationLabel,
                ClassificationHelp = this.ClassificationHelp,
                SubClassificationLabel = string.IsNullOrEmpty(this.SubClassificationLabel) ? "Sub-Classification" : this.SubClassificationLabel,
                SubClassificationHelp = this.SubClassificationHelp,
                JobTypeLabel = string.IsNullOrEmpty(this.JobTypeLabel) ? "Job Type" : this.JobTypeLabel,
                JobTypeHelp = this.JobTypeHelp,
                HourlyRateLabel = string.IsNullOrEmpty(this.HourlyRateLabel) ? "Hourly Rate" : this.HourlyRateLabel,
                HourlyRateHelp = this.HourlyRateHelp,
                AnnualSalaryLabel = string.IsNullOrEmpty(this.AnnualSalaryLabel) ? "Annual Salary" : this.AnnualSalaryLabel,
                AnnualSalaryHelp = this.AnnualSalaryHelp,
                BonusLabel = string.IsNullOrEmpty(this.BonusLabel) ? "Bonus" : this.BonusLabel,
                BonusHelp = this.BonusHelp,
                BenefitLabel = string.IsNullOrEmpty(this.BenefitLabel) ? "Benefits Received" : this.BenefitLabel,
                BenefitHelp = this.BenefitHelp,
                BenefitOtherLabel = string.IsNullOrEmpty(this.BenefitOtherLabel) ? "Other Benefits" : this.BenefitOtherLabel,
                BenefitOtherPlaceholder = this.BenefitOtherPlaceholder,
                BenefitOtherHelp = this.BenefitOtherHelp,

                ProfessionalQualificationLabel = string.IsNullOrEmpty(this.ProfessionalQualificationLabel) ? "Professional Qualification" : this.ProfessionalQualificationLabel,
                ProfessionalQualificationHelp = this.ProfessionalQualificationHelp,
                EducationLabel = string.IsNullOrEmpty(this.EducationLabel) ? "Education" : this.EducationLabel,
                EducationHelp = this.EducationHelp,
                YearsOfExperienceLabel = string.IsNullOrEmpty(this.YearsOfExperienceLabel) ? "Years of Experience" : this.YearsOfExperienceLabel,
                YearsOfExperienceHelp = this.YearsOfExperienceHelp,
                PeopleManagedLabel = string.IsNullOrEmpty(this.PeopleManagedLabel) ? "People Managed" : this.PeopleManagedLabel,
                PeopleManagedHelp = this.PeopleManagedHelp,
                GenderLabel = string.IsNullOrEmpty(this.GenderLabel) ? "Gender" : this.GenderLabel,
                GenderHelp = this.GenderHelp,
                EmployerSizeLabel = string.IsNullOrEmpty(this.EmployerSizeLabel) ? "Employer Size" : this.EmployerSizeLabel,
                EmployerSizeHelp = this.EmployerSizeHelp,
                MoneyToLeaveLabel = string.IsNullOrEmpty(this.MoneyToLeaveLabel) ? "How much more would you move for?" : this.MoneyToLeaveLabel,
                MoneyToLeaveHelp = this.MoneyToLeaveHelp,

                MotivatorPlaceHolder = this.MotivatorPlaceHolder,
                MotivatorOtherLabel = string.IsNullOrEmpty(this.MotivatorOtherLabel) ? "Other" : this.MotivatorOtherLabel,
                MotivatorOtherPlaceHolder = this.MotivatorOtherPlaceHolder,
                BestEmployerLabel = string.IsNullOrEmpty(this.BestEmployerLabel) ? "Best Employers" : this.BestEmployerLabel,
                BestEmployerHelp = this.BestEmployerHelp,
                BestEmployerPlaceholder = this.BestEmployerPlaceholder,
                BestEmployerRows = this.BestEmployerRows > 0 ? this.BestEmployerRows : 3,
                CareerMoveLabel = string.IsNullOrEmpty(this.CareerMoveLabel) ? "Next Career Move" : this.CareerMoveLabel,
                CareerMoveHelp = this.CareerMoveHelp,

                JobAlertIntroduction = this.JobAlertIntroduction,
                JobAlertLabel = string.IsNullOrEmpty(this.JobAlertLabel) ? "I would like to be alerted by email of new job vacancies that match my profile above." : this.JobAlertLabel,
                JobAlertHelp = this.JobAlertHelp,
                SalaryAlertIntroduction = this.SalaryAlertIntroduction,
                SalaryAlertLabel = string.IsNullOrEmpty(this.SalaryAlertLabel) ? "I would like to be alerted by email every time {0} new salary entries are added that match my profile above." : this.SalaryAlertLabel,
                SalaryAlertHelp = this.SalaryAlertHelp,
                SalaryAlertCount = settings.SalaryAlertCount,
                ContactRequestLabel = string.IsNullOrEmpty(this.ContactRequestLabel) ? "Would you like us to contact you to discuss your potential salary and careers opporunities?" : this.ContactRequestLabel,
                ContactRequestHelp = this.ContactRequestHelp,
                NameLabel = string.IsNullOrEmpty(this.NameLabel) ? "Name" : this.NameLabel,
                NamePlaceholder = this.NamePlaceholder,
                NameHelp = this.NameHelp,
                EmailLabel = string.IsNullOrEmpty(this.EmailLabel) ? "Email" : this.EmailLabel,
                EmailPlaceholder = this.EmailPlaceholder,
                EmailHelp = this.EmailHelp,
                PhoneLabel = string.IsNullOrEmpty(this.PhoneLabel) ? "Phone" : this.PhoneLabel,
                PhonePlaceholder = this.PhonePlaceholder,
                PhoneHelp = this.PhoneHelp,

                EmptyOptionLabel = this.EmptyOptionLabel ?? "",

                SubmitButtonLabel = string.IsNullOrEmpty(this.SubmitButtonLabel) ? "Submit" : this.SubmitButtonLabel
            };

            model.Form = form ?? new SubmitSalaryFormModel();

            model.CountryList = GenericHelper.GetCategoryItems(settings.CountryTaxonomyId);
            model.IndustryList = GenericHelper.GetCategoryItems(settings.IndustryTaxonomyId);
            model.JobTypesList = GenericHelper.GetCategoryItems(settings.JobTypeTaxonomyId);
            model.YearsOfExperienceList = GenericHelper.GetCategoryItems(settings.YearsOfExperienceTaxonomyId);
            model.EmployerSizeList = GenericHelper.GetCategoryItems(settings.EmployerSizeTaxonomyId);
            model.PeopleManagedList = GenericHelper.GetCategoryItems(settings.PeopleManagedTaxonomyId);
            model.GenderList = GenericHelper.GetCategoryItems(settings.GenderTaxonomyId);
            model.BenefitList = GenericHelper.GetCategoryItems(settings.BenefitTaxonomyId);
            model.MotivatorList = GenericHelper.GetCategoryItems(settings.MotivatorTaxonomyId);
            model.CareerMoveList = GenericHelper.GetCategoryItems(settings.CareerMoveTaxonomyId);
            model.EducationList = GenericHelper.GetCategoryItems(settings.EducationTaxonomyId);

            model.AnnualSalaryJobTypeList = settings.AnnualSalaryJobTypeTaxonomyIds;

            // populate the location list if a country is available else set it to empty
            if (model.Form.CountryId == Guid.Empty)
            {
                model.LocationList = new List<SelectListItem>();
            }
            else
            {
                model.LocationList = GenericHelper.GetCategoryItems(model.Form.CountryId);
            }

            // populate the classification list if a industry is available else set it to empty
            if (model.Form.IndustryId == Guid.Empty)
            {
                model.ClassificationList = new List<SelectListItem>();
            }
            else
            {
                model.ClassificationList = GenericHelper.GetCategoryItems(model.Form.IndustryId);
            }

            // populate the sub classification list if a classification is available else set it to empty
            if (model.Form.ClassificationId == Guid.Empty)
            {
                model.SubClassificationList = new List<SelectListItem>();
            }
            else
            {
                var classification = GenericHelper.GetCategory(model.Form.ClassificationId);
                if (classification == null || classification.ParentId != model.Form.IndustryId)
                {
                    model.SubClassificationList = new List<SelectListItem>();
                }
                else
                {
                    model.SubClassificationList = GenericHelper.GetCategoryItems(classification.Id);
                }
            }

            if (settings.AnnualSalariesTaxonomyId != Guid.Empty)
            {
                model.AnnualSalariesDropdown = true;
                model.AnnualSalariesList = GenericHelper.GetCategoryItems(settings.AnnualSalariesTaxonomyId);
            }

            if (settings.HourlyRatesTaxonomyId != Guid.Empty)
            {
                model.HourlyRatesDropdown = true;
                model.HourlyRatesList = GenericHelper.GetCategoryItems(settings.HourlyRatesTaxonomyId);
            }

            if (settings.BonusAmountsTaxonomyId != Guid.Empty)
            {
                model.BonusAmountsDropdown = true;
                model.BonusAmountsList = GenericHelper.GetCategoryItems(settings.BonusAmountsTaxonomyId);
            }

            model.MaxAnnualMoneyToLeave = MaxAnnualMoneyToLeave;
            model.MaxHourlyMoneyToLeave = MaxHourlyMoneyToLeave;
            model.CurrencySymbol = settings.CurrencySymbol;

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
