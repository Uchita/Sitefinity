using JXTNext.Sitefinity.SalarySurvey.Database;
using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_AdminSalaryWidget", Title = "Salaries", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class AdminSalaryController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }

        #endregion

        #region GET methods        

        public ActionResult Index()
        {
            AdminSalaryViewModel viewModel;

            var templateName = "Default";

            viewModel = _GetViewModel(templateName);

            var siteId = GenericHelper.GetCurrentSiteId();

            var dbContext = SalarySurveyDbContext.CreateInstance();

            var totalPages = 0;
            var limit = 25;

            var page = Request.QueryString["Page"] == null ? 1 : int.Parse(Request.QueryString["Page"]);

            var records = dbContext.Salary.Where(s => s.SiteId == siteId).Count();

            if (records > 0)
            {
                totalPages = limit > 0 ? (int)Math.Ceiling((decimal)records / limit) : 1;

                if (page > totalPages)
                {
                    page = totalPages;
                }

                var start = limit * page - limit;

                var salaries = dbContext.Salary
                    .Where(s => s.SiteId == siteId)
                    .OrderByDescending(s => s.Id)
                    .Skip(start)
                    .Take(limit);

                var settings = new SettingsHelper();

                foreach (var salary in salaries)
                {
                    var salaryDetails = _CreateSalaryDetailsModel(salary, templateName);

                    viewModel.Salaries.Add(salaryDetails);
                }

                viewModel.TotalRecords = records;
                viewModel.StartRecord = start < 1 ? 1 : start;
                viewModel.EndRecord = start + limit;
                viewModel.TotalPages = totalPages;
                viewModel.CurrentPage = page;

                if (viewModel.EndRecord > records)
                {
                    viewModel.EndRecord = records;
                }
            }

            return View(templateName, viewModel);
        }

        public ActionResult Details(int SalaryId)
        {
            var templateName = "Details";

            var viewModel = _GetViewModel(templateName);

            var siteId = GenericHelper.GetCurrentSiteId();

            var dbContext = SalarySurveyDbContext.CreateInstance();

            var salary = dbContext.Salary
                .Include(s => s.Benefits)
                .Include(s => s.OtherBenefits)
                .Include(s => s.Motivators)
                .Include(s => s.OtherMotivators)
                .Include(s => s.CareerMoves)
                .Single(c => c.Id == SalaryId);

            if (salary != null && salary.SiteId == siteId)
            {
                viewModel.Salary = _CreateSalaryDetailsModel(salary, templateName);
            }

            return View(templateName, viewModel);
        }

        #endregion

        #region Private methods       

        private AdminSalaryViewModel _GetViewModel(string templateName, GrossNetCalculatorFormModel form = null)
        {
            var model = new AdminSalaryViewModel();

            // populate widget properties
            model.Widget = new AdminSalaryWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Salaries" : this.Heading
            };

            var manager = PageManager.GetManager();
            var node = SiteMapBase.GetActualCurrentNode();
            model.CurrentPageUrl = node.Url.Substring(1);

            return model;
        }

        private SalaryDetailsModel _CreateSalaryDetailsModel(Salary salary, string templateName)
        {
            var isDetails = templateName == "Details";

            var salaryDetails = new SalaryDetailsModel
            {
                Id = salary.Id,
                JobTitle = salary.JobTitle,
                AnnualSalary = salary.AnnualSalary,
                HourlyRate = salary.HourlyRate,
                BonusAmount = salary.BonusAmount,
                MoneyToLeave = salary.MoneyToLeave,
                CurrentCompany = salary.CurrentCompany,
                PreviousCompany = salary.PreviousCompany,
                ReasonForLeaving = salary.ReasonForLeaving,
                ProfessionalQualification = salary.ProfessionalQualification,
                SuperIncluded = salary.SuperIncluded,
                SuperPercentage = salary.SuperPercentage,
                SuperAmount = salary.SuperAmount,
                SalaryAlert = salary.SalaryAlert,
                JobAlert = salary.JobAlert,
                ContactRequest = salary.ContactRequest,
                Name = salary.Name,
                Phone = salary.Phone,
                Email = salary.Email,
                Verified = salary.Verified,
                CreatedDate = salary.CreatedDate,
                UpdatedDate = salary.UpdatedDate
            };

            var guidList = new List<Guid>
            {
                salary.CountryId,
                salary.LocationId,
                salary.IndustryId,
                salary.ClassificationId,
                salary.SubClassificationId,
                salary.JobTypeId
            };

            if (isDetails)
            {
                if (salary.YearsOfExperienceId != null)
                {
                    guidList.Add(salary.YearsOfExperienceId.Value);
                }

                if (salary.PeopleManagedId != null)
                {
                    guidList.Add(salary.PeopleManagedId.Value);
                }

                if (salary.GenderId != null)
                {
                    guidList.Add(salary.GenderId.Value);
                }

                if (salary.EmployerSizeId != null)
                {
                    guidList.Add(salary.EmployerSizeId.Value);
                }

                if (salary.EducationId != null)
                {
                    guidList.Add(salary.EducationId.Value);
                }
            }

            var taxons = GenericHelper.GetCategories(guidList);
            if (taxons.Count() != 0)
            {
                var classifications = new Dictionary<Guid, string>();
                foreach (var taxon in taxons)
                {
                    classifications.Add(taxon.Id, taxon.Title);
                }

                if (classifications.ContainsKey(salary.CountryId))
                {
                    salaryDetails.Country = classifications[salary.CountryId];
                }

                if (classifications.ContainsKey(salary.LocationId))
                {
                    salaryDetails.Location = classifications[salary.LocationId];
                }

                if (classifications.ContainsKey(salary.IndustryId))
                {
                    salaryDetails.Industry = classifications[salary.IndustryId];
                }

                if (classifications.ContainsKey(salary.ClassificationId))
                {
                    salaryDetails.Classification = classifications[salary.ClassificationId];
                }

                if (classifications.ContainsKey(salary.SubClassificationId))
                {
                    salaryDetails.SubClassification = classifications[salary.SubClassificationId];
                }

                if (classifications.ContainsKey(salary.JobTypeId))
                {
                    salaryDetails.JobType = classifications[salary.JobTypeId];
                }

                if (isDetails)
                {
                    if (salary.EducationId != null && classifications.ContainsKey(salary.EducationId.Value))
                    {
                        salaryDetails.Education = classifications[salary.EducationId.Value];
                    }

                    if (salary.YearsOfExperienceId != null && classifications.ContainsKey(salary.YearsOfExperienceId.Value))
                    {
                        salaryDetails.YearsOfExperience = classifications[salary.YearsOfExperienceId.Value];
                    }

                    if (salary.PeopleManagedId != null && classifications.ContainsKey(salary.PeopleManagedId.Value))
                    {
                        salaryDetails.PeopleManaged = classifications[salary.PeopleManagedId.Value];
                    }

                    if (salary.GenderId != null && classifications.ContainsKey(salary.GenderId.Value))
                    {
                        salaryDetails.Gender = classifications[salary.GenderId.Value];
                    }

                    if (salary.EmployerSizeId != null && classifications.ContainsKey(salary.EmployerSizeId.Value))
                    {
                        salaryDetails.EmployerSize = classifications[salary.EmployerSizeId.Value];
                    }
                }
            }

            if (isDetails)
            {
                var settings = new SettingsHelper();

                Dictionary<Guid, string> dictionary;

                // populate benefits
                if (salary.Benefits != null)
                {
                    // create dictionary of benefits for easy matching
                    dictionary = new Dictionary<Guid, string>();
                    foreach (var item in GenericHelper.GetCategoryItems(settings.BenefitTaxonomyId))
                    {
                        dictionary.Add(new Guid(item.Value), item.Text);
                    }

                    foreach (var item in salary.Benefits)
                    {
                        if (dictionary.ContainsKey(item.BenefitId))
                        {
                            salaryDetails.Benefits.Add(dictionary[item.BenefitId]);
                        }
                    }
                }

                // populate other benefits
                if (salary.OtherBenefits != null)
                {
                    foreach (var item in salary.OtherBenefits)
                    {
                        salaryDetails.OtherBenefits.Add(item.Name);
                    }
                }

                // populate motivators
                if (salary.Motivators != null)
                {
                    // create dictionary of motivators for easy matching
                    dictionary = new Dictionary<Guid, string>();
                    foreach (var item in GenericHelper.GetCategoryItems(settings.MotivatorTaxonomyId))
                    {
                        dictionary.Add(new Guid(item.Value), item.Text);
                    }

                    salary.Motivators = salary.Motivators.OrderBy(s => s.Position).ToList();

                    foreach (var item in salary.Motivators)
                    {
                        if (dictionary.ContainsKey(item.MotivatorId))
                        {
                            salaryDetails.Motivators.Add(dictionary[item.MotivatorId]);
                        }
                    }
                }

                // populate other motivators
                if (salary.OtherMotivators != null)
                {
                    foreach (var item in salary.OtherMotivators)
                    {
                        salaryDetails.OtherMotivators.Add(item.Name);
                    }
                }

                // populate career moves
                if (salary.CareerMoves != null)
                {
                    // create dictionary of career moves for easy matching
                    dictionary = new Dictionary<Guid, string>();
                    foreach (var item in GenericHelper.GetCategoryItems(settings.CareerMoveTaxonomyId))
                    {
                        dictionary.Add(new Guid(item.Value), item.Text);
                    }

                    foreach (var item in salary.CareerMoves)
                    {
                        if (dictionary.ContainsKey(item.CareerMoveId))
                        {
                            salaryDetails.CareerMoves.Add(dictionary[item.CareerMoveId]);
                        }
                    }
                }

                // populate best employers
                if (salary.BestEmployers != null)
                {
                    foreach (var item in salary.BestEmployers)
                    {
                        salaryDetails.BestEmployers.Add(item.Name);
                    }
                }
            }

            return salaryDetails;
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
