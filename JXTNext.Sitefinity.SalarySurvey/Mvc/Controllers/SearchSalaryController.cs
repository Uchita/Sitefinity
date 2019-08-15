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
using System.Web;
using JXTNext.Sitefinity.SalarySurvey.Database;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_SearchSalaryWidget", Title = "Search Salary", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class SearchSalaryController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }
        public string Introduction { get; set; }
        public string JobTypeLabel { get; set; }
        public string JobTypeHelp { get; set; }
        public string JobTitleLabel { get; set; }
        public string JobTitleHelp { get; set; }
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
        public string YearsOfExperienceLabel { get; set; }
        public string YearsOfExperienceHelp { get; set; }
        public string SubmitButtonLabel { get; set; }
        public string EmptyOptionLabel { get; set; }

        public string ResultPage { get; set; }

        #endregion

        private SalarySurveyDbContext _dbContext;
        private Dictionary<Guid, Taxon> _availableBenefits;

        #region Controllers

        /// <summary>
        /// Display search form/result.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Index(SearchSalaryFormModel form)
        {
            var templateName = "Default";

            // make sure we are processing the correct form
            if (form.SalarySurveyAction != "search")
            {
                if (form.SalarySurveyAction != "modify")
                {
                    ModelState.Clear();
                }

                return View(templateName, _GetViewModel(templateName, form));
            }

            string fieldKey;
            HierarchicalTaxon taxon;
            Dictionary<string, string> criteriaNames = new Dictionary<string, string>();

            var settings = new SettingsHelper();

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
                    criteriaNames[fieldKey] = taxon.Title;
                }
            }

            // validate country id
            fieldKey = "CountryId";
            if (ModelState.IsValidField(fieldKey) && form.CountryId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.CountryId.Value);
                if (taxon == null || taxon.ParentId != settings.CountryTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    criteriaNames[fieldKey] = taxon.Title;

                    // validate location id
                    fieldKey = "LocationId";
                    if (ModelState.IsValidField(fieldKey) && form.LocationId.HasValue)
                    {
                        var location = GenericHelper.GetCategory(form.LocationId.Value);

                        if (location == null || location.ParentId != taxon.Id)
                        {
                            ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                        }
                        else
                        {
                            criteriaNames[fieldKey] = location.Title;
                        }
                    }
                }
            }

            // validate industry id
            fieldKey = "IndustryId";
            if (ModelState.IsValidField(fieldKey) && form.IndustryId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.IndustryId.Value);
                if (taxon == null || taxon.ParentId != settings.IndustryTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    criteriaNames[fieldKey] = taxon.Title;

                    // validate classification id
                    fieldKey = "ClassificationId";
                    if (ModelState.IsValidField(fieldKey) && form.ClassificationId.HasValue)
                    {
                        var classification = GenericHelper.GetCategory(form.ClassificationId.Value);
                        if (classification == null || classification.ParentId != taxon.Id)
                        {
                            ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                        }
                        else
                        {
                            criteriaNames[fieldKey] = classification.Title;

                            // validate sub classification id
                            fieldKey = "SubClassificationId";
                            if (ModelState.IsValidField(fieldKey) && form.SubClassificationId.HasValue)
                            {
                                var subClassification = GenericHelper.GetCategory(form.SubClassificationId.Value);

                                if (subClassification == null || subClassification.ParentId != classification.Id)
                                {
                                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                                }
                                else
                                {
                                    criteriaNames[fieldKey] = subClassification.Title;
                                }
                            }
                        }
                    }
                }
            }

            // validate years of experience
            fieldKey = "YearsOfExperienceId";
            if (ModelState.IsValidField(fieldKey) && form.YearsOfExperienceId.HasValue)
            {
                taxon = GenericHelper.GetCategory(form.YearsOfExperienceId.Value);
                if (taxon == null || taxon.ParentId != settings.YearsOfExperienceTaxonomyId)
                {
                    ModelState.AddModelError(fieldKey, FormHelper.InvalidValueMessage);
                }
                else
                {
                    criteriaNames[fieldKey] = taxon.Title;
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

            var viewModel = _GetViewModel(templateName, form);
            viewModel.JobType = criteriaNames.ContainsKey("JobTypeId") ? criteriaNames["JobTypeId"] : null;
            viewModel.Country = criteriaNames.ContainsKey("CountryId") ? criteriaNames["CountryId"] : null;
            viewModel.Location = criteriaNames.ContainsKey("LocationId") ? criteriaNames["LocationId"] : null;
            viewModel.Industry = criteriaNames.ContainsKey("IndustryId") ? criteriaNames["IndustryId"] : null;
            viewModel.Classification = criteriaNames.ContainsKey("ClassificationId") ? criteriaNames["ClassificationId"] : null;
            viewModel.SubClassification = criteriaNames.ContainsKey("SubClassificationId") ? criteriaNames["SubClassificationId"] : null;
            viewModel.YearsOfExperience = criteriaNames.ContainsKey("YearsOfExperienceId") ? criteriaNames["YearsOfExperienceId"] : null;

            var parameters = HttpUtility.ParseQueryString(Request.Url.Query);
            parameters["SalarySurveyAction"] = "modify";

            var uri = new UriBuilder(Request.Url);
            uri.Query = parameters.ToString();
            viewModel.EditSearchUrl = uri.ToString();

            // whether to use annual salary or hourly rate
            // by default annual salary is used
            var annualSalaryTaxonomyIds = settings.AnnualSalaryJobTypeTaxonomyIds;
            if (annualSalaryTaxonomyIds.Count > 0 && !annualSalaryTaxonomyIds.Contains(form.JobTypeId))
            {
                viewModel.AnnualSalary = false;

                viewModel.SalaryLabel = "Hourly Rate";
            }

            try
            {
                _PerformSearch(viewModel);

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

        #region Private methods

        /// <summary>
        /// Prepare the various results.
        /// </summary>
        /// <param name="viewModel"></param>
        private void _PerformSearch(SearchSalaryViewModel viewModel)
        {
            using (_dbContext = SalarySurveyDbContext.CreateInstance())
            {
                var whereList = new Dictionary<string, string>();

                if (viewModel.Form.StartSalaryId > 0 && viewModel.Form.EndSalaryId > viewModel.Form.StartSalaryId)
                {
                    whereList["SalaryIdRange"] = "(s.Id BETWEEN " + viewModel.Form.StartSalaryId + " AND " + viewModel.Form.EndSalaryId + ")";
                }

                whereList["SiteId"] = "s.SiteId='" + GenericHelper.GetCurrentSiteId() + "'";
                whereList["Verified"] = "s.Verified=1";
                whereList["JobTypeId"] = "s.JobTypeId='" + viewModel.Form.JobTypeId + "'";

                if (viewModel.Form.CountryId.HasValue)
                {
                    // if LocationId is present then we do not need to include CountryId in where clause
                    // LocationId is already checked that it belongs to selected country
                    if (viewModel.Form.LocationId.HasValue)
                    {
                        whereList["LocationId"] = "s.LocationId='" + viewModel.Form.LocationId.Value + "'";
                    }
                    else
                    {
                        whereList["CountryId"] = "s.CountryId='" + viewModel.Form.CountryId.Value + "'";
                    }
                }

                if (viewModel.Form.IndustryId.HasValue)
                {
                    // if ClassificationId is present then we do not need to include IndustryId in where clause
                    // IndustryId is already checked that it belongs to selected classification
                    if (viewModel.Form.ClassificationId.HasValue)
                    {
                        // if SubClassificationId is present then we do not need to include ClassificationId in where clause
                        // SubClassificationId is already checked that it belongs to selected classification
                        if (viewModel.Form.SubClassificationId.HasValue)
                        {
                            whereList["SubClassificationId"] = "s.SubClassificationId='" + viewModel.Form.SubClassificationId.Value + "'";
                        }
                        else
                        {
                            whereList["ClassificationId"] = "s.ClassificationId='" + viewModel.Form.ClassificationId.Value + "'";
                        }
                    }
                    else
                    {
                        whereList["IndustryId"] = "s.IndustryId='" + viewModel.Form.IndustryId.Value + "'";
                    }
                }

                if (viewModel.Form.YearsOfExperienceId.HasValue)
                {
                    whereList["YearsOfExperienceId"] = "s.YearsOfExperienceId='" + viewModel.Form.YearsOfExperienceId.Value + "'";
                }

                var argsList = new Dictionary<string, string>();

                _FetchAvailableBenefits();

                _FetchTotalRowsAndLastestProfiles(viewModel, whereList, argsList);
                _CalculateBaseSalaryMedian(viewModel, whereList, argsList);
                _CalculateSalaryPackageMedian(viewModel, whereList, argsList);
                _CalculateBenefitsPercentage(viewModel, whereList, argsList);
                _CalculateMoneyToLeaveMedian(viewModel, whereList, argsList);
            }
        }

        /// <summary>
        /// Fetch the total rows and latest profiles.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="whereList"></param>
        /// <param name="argsList"></param>
        private void _FetchTotalRowsAndLastestProfiles(SearchSalaryViewModel viewModel, Dictionary<string, string> whereList, Dictionary<string, string> argsList)
        {
            var where = string.Join(" AND ", whereList.Select(list => list).Select(kvp => kvp.Value).ToList());

            var query = "SELECT COUNT(s.Id) FROM Salary AS s WHERE " + where;

            var result = _dbContext.Database.SqlQuery<int>(query).ToArray();
            if (result.Length > 0)
            {
                viewModel.Records = result[0];
            }

            // get latest profiles
            if (viewModel.Records > 0)
            {
                query = "SELECT Top 5 s.* FROM Salary s WHERE " + where + " ORDER BY s.CreatedDate DESC";

                SearchResultProfileModel profileModel;

                var classificationIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var subClassificationIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var countryIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var locationIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var yearsOfExperienceIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var educationIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var peopleManagedIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var employerSizeIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var jobTypeIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();
                var industryIdList = new Dictionary<Guid, List<SearchResultProfileModel>>();

                Guid guid;

                foreach (var salary in _dbContext.Database.SqlQuery<Salary>(query).ToList())
                {
                    profileModel = new SearchResultProfileModel
                    {
                        JobTitle = salary.JobTitle,
                        CreatedDate = salary.CreatedDate,
                        HourlyRate = salary.HourlyRate,
                        AnnualSalary = salary.AnnualSalary,
                        SuperAmount = salary.SuperAmount,
                        BonusAmount = salary.BonusAmount,
                        MoneyToLeave = salary.MoneyToLeave,
                        ProfessionalQualification = salary.ProfessionalQualification
                    };

                    if (viewModel.AnnualSalary)
                    {
                        if (profileModel.AnnualSalary.HasValue)
                        {
                            profileModel.Remuneration = profileModel.AnnualSalary;
                        }
                    }
                    else
                    {
                        if (profileModel.HourlyRate.HasValue)
                        {
                            profileModel.Remuneration = profileModel.HourlyRate;
                        }
                    }

                    // get the benefits
                    _dbContext.Salary.Attach(salary);
                    _dbContext.Entry(salary).Collection(b => b.Benefits).Load();
                    foreach (var benefit in salary.Benefits.ToList())
                    {
                        if (_availableBenefits.ContainsKey(benefit.BenefitId))
                        {
                            profileModel.Benefits.Add(_availableBenefits[benefit.BenefitId].Title);
                        }
                    }

                    // add the profile to classification list for fetching the name later
                    if (!classificationIdList.ContainsKey(salary.ClassificationId))
                    {
                        classificationIdList[salary.ClassificationId] = new List<SearchResultProfileModel>();
                    }
                    classificationIdList[salary.ClassificationId].Add(profileModel);

                    // add the profile to sub-classification list for fetching the name later
                    if (!subClassificationIdList.ContainsKey(salary.SubClassificationId))
                    {
                        subClassificationIdList[salary.SubClassificationId] = new List<SearchResultProfileModel>();
                    }
                    subClassificationIdList[salary.SubClassificationId].Add(profileModel);

                    // add the profile to country list for fetching the name later
                    if (!countryIdList.ContainsKey(salary.CountryId))
                    {
                        countryIdList[salary.CountryId] = new List<SearchResultProfileModel>();
                    }
                    countryIdList[salary.CountryId].Add(profileModel);

                    // add the profile to location list for fetching the name later
                    if (!locationIdList.ContainsKey(salary.LocationId))
                    {
                        locationIdList[salary.LocationId] = new List<SearchResultProfileModel>();
                    }
                    locationIdList[salary.LocationId].Add(profileModel);

                    // add the profile to job type list for fetching the name later
                    if (!jobTypeIdList.ContainsKey(salary.JobTypeId))
                    {
                        jobTypeIdList[salary.JobTypeId] = new List<SearchResultProfileModel>();
                    }
                    jobTypeIdList[salary.JobTypeId].Add(profileModel);

                    // add the profile to years of experience list for fetching the name later
                    if (salary.YearsOfExperienceId != null)
                    {
                        guid = (Guid)salary.YearsOfExperienceId;

                        if (!yearsOfExperienceIdList.ContainsKey(guid))
                        {
                            yearsOfExperienceIdList[guid] = new List<SearchResultProfileModel>();
                        }

                        yearsOfExperienceIdList[guid].Add(profileModel);
                    }

                    // add the profile to education list for fetching the name later
                    if (salary.EducationId != null)
                    {
                        guid = (Guid)salary.EducationId;

                        if (!educationIdList.ContainsKey(guid))
                        {
                            educationIdList[guid] = new List<SearchResultProfileModel>();
                        }

                        educationIdList[guid].Add(profileModel);
                    }

                    // add the profile to people managed list for fetching the name later
                    if (salary.PeopleManagedId != null)
                    {
                        guid = (Guid)salary.PeopleManagedId;

                        if (!peopleManagedIdList.ContainsKey(guid))
                        {
                            peopleManagedIdList[guid] = new List<SearchResultProfileModel>();
                        }

                        peopleManagedIdList[guid].Add(profileModel);
                    }

                    // add the profile to employer size list for fetching the name later
                    if (salary.EmployerSizeId != null)
                    {
                        guid = (Guid)salary.EmployerSizeId;

                        if (!employerSizeIdList.ContainsKey(guid))
                        {
                            employerSizeIdList[guid] = new List<SearchResultProfileModel>();
                        }

                        employerSizeIdList[guid].Add(profileModel);
                    }

                    // add the profile to industry list for fetching the name later
                    if (salary.IndustryId != null)
                    {
                        guid = (Guid)salary.IndustryId;

                        if (!industryIdList.ContainsKey(guid))
                        {
                            industryIdList[guid] = new List<SearchResultProfileModel>();
                        }

                        industryIdList[guid].Add(profileModel);
                    }

                    viewModel.LatestSalaries.Add(profileModel);
                }

                if (viewModel.LatestSalaries.Count > 0)
                {
                    var categoriesTaxonomy = TaxonomyManager.GetManager().GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                    // get the classification names
                    if (classificationIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => classificationIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in classificationIdList[taxon.Id])
                            {
                                profile.Classification = taxon.Title;

                                profile.ProfileTitle = profile.Classification;
                            }
                        }
                    }

                    // get the sub-classification names
                    if (subClassificationIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => subClassificationIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in subClassificationIdList[taxon.Id])
                            {
                                profile.SubClassification = taxon.Title;

                                if (profile.ProfileTitle == null)
                                {
                                    profile.ProfileTitle = profile.SubClassification;
                                }
                                else
                                {
                                    profile.ProfileTitle += "/" + profile.SubClassification;
                                }
                            }
                        }
                    }

                    // get the country names
                    if (countryIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => countryIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in countryIdList[taxon.Id])
                            {
                                profile.Country = taxon.Title;
                            }
                        }
                    }

                    // get the location names
                    if (locationIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => locationIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in locationIdList[taxon.Id])
                            {
                                profile.Location = taxon.Title;
                            }
                        }
                    }

                    // get the job type names
                    if (jobTypeIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => jobTypeIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in jobTypeIdList[taxon.Id])
                            {
                                profile.JobType = taxon.Title;
                            }
                        }
                    }

                    // get the years of experience names
                    if (yearsOfExperienceIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => yearsOfExperienceIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in yearsOfExperienceIdList[taxon.Id])
                            {
                                profile.YearsOfExperience = taxon.Title;
                            }
                        }
                    }

                    // get the people managed names
                    if (peopleManagedIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => peopleManagedIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in peopleManagedIdList[taxon.Id])
                            {
                                profile.PeopleManaged = taxon.Title;
                            }
                        }
                    }

                    // get the education names
                    if (educationIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => educationIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in educationIdList[taxon.Id])
                            {
                                profile.Education = taxon.Title;
                            }
                        }
                    }

                    // get the employer size names
                    if (employerSizeIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => employerSizeIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in employerSizeIdList[taxon.Id])
                            {
                                profile.EmployerSize = taxon.Title;
                            }
                        }
                    }

                    // get the industry names
                    if (industryIdList.Count > 0)
                    {
                        foreach (var taxon in categoriesTaxonomy.Taxa.Where(t => industryIdList.Keys.Contains(t.Id)))
                        {
                            foreach (var profile in industryIdList[taxon.Id])
                            {
                                profile.Industry = taxon.Title;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate median of base salary.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="whereList"></param>
        /// <param name="argsList"></param>
        private void _CalculateBaseSalaryMedian(SearchSalaryViewModel viewModel, Dictionary<string, string> whereList, Dictionary<string, string> argsList)
        {
            string query;
            int[] intResult;
            int?[] intResultNullable;

            var from = "Salary AS s";

            var where = string.Join(" AND ", whereList.Select(list => list).Select(kvp => kvp.Value).ToList());

            // find total people with bonus and calculate it's median
            if (viewModel.Records > 0)
            {
                query = "SELECT COUNT(s.Id) FROM " + from + " WHERE " + where + " AND (s.BonusAmount>0)";

                var medianBonus = 0;

                intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();

                var peopleWithBonus = intResult.Length > 0 ? intResult[0] : 0;

                var bmedianIndex = (int)peopleWithBonus / 2;

                if (bmedianIndex > 0 && peopleWithBonus % 2 == 0)
                {
                    var start = bmedianIndex - 1;

                    query = "SELECT s.BonusAmount FROM " + from + " WHERE " + where + " AND (s.BonusAmount>0) ORDER BY s.BonusAmount OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    var totalBonus = 0;

                    foreach (var value in _dbContext.Database.SqlQuery<int>(query))
                    {
                        totalBonus += value;
                    }

                    medianBonus = totalBonus / 2;
                }
                else
                {
                    query = "SELECT s.BonusAmount FROM " + from + " WHERE " + where + " AND (s.BonusAmount>0) ORDER BY s.BonusAmount OFFSET " + bmedianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                    intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();
                    if (intResult.Length > 0)
                    {
                        medianBonus = intResult[0];
                    }
                }

                viewModel.PeopleWithBonus = Math.Round((decimal)peopleWithBonus / viewModel.Records * 100, 2);
                viewModel.MedianBonus = medianBonus;
            }

            // find total people with super and calculate it's median
            if (viewModel.Records > 0)
            {
                var medianSuper = 0;

                query = "SELECT COUNT(s.Id) FROM " + from + " WHERE " + where + " AND (s.SuperAmount>0)";

                intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();

                var peopleWithSuper = intResult.Length > 0 ? intResult[0] : 0;

                var bmedianIndex = (int)peopleWithSuper / 2;

                if (bmedianIndex > 0 && peopleWithSuper % 2 == 0)
                {
                    var start = bmedianIndex - 1;

                    query = "SELECT s.SuperAmount FROM " + from + " WHERE " + where + " AND (s.SuperAmount>0) ORDER BY s.SuperAmount OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    var totalSuper = 0;

                    foreach (var value in _dbContext.Database.SqlQuery<int>(query))
                    {
                        totalSuper += value;
                    }

                    medianSuper = totalSuper / 2;
                }
                else
                {
                    query = "SELECT s.SuperAmount FROM " + from + " WHERE " + where + " AND (s.SuperAmount>0) ORDER BY s.SuperAmount OFFSET " + bmedianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                    intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();
                    if (intResult.Length > 0)
                    {
                        medianSuper = intResult[0];
                    }
                }

                viewModel.PeopleWithSuper = Math.Round((decimal)peopleWithSuper / viewModel.Records * 100, 2);
                viewModel.MedianSuper = medianSuper;
            }

            var medianIndex = (int)viewModel.Records / 2;

            var salaryField = viewModel.AnnualSalary ? "AnnualSalary" : "HourlyRate";

            // calculate the median
            if (viewModel.Records > 0)
            {
                var median = 0;

                if (medianIndex > 0 && viewModel.Records % 2 == 0)
                {
                    var start = medianIndex - 1;

                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    var totalSalary = 0;

                    foreach (var value in _dbContext.Database.SqlQuery<int?>(query))
                    {
                        totalSalary += value == null ? 0 : (int)value;
                    }

                    median = totalSalary / 2;
                }
                else
                {
                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + medianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + medianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                    intResultNullable = _dbContext.Database.SqlQuery<int?>(query).ToArray();
                    if (intResultNullable.Length > 0)
                    {
                        median = intResultNullable[0] == null ? 0 : (int)intResultNullable[0];
                    }
                }

                viewModel.Median = median;

                // calculate min and max salary

                // query = "SELECT MIN(s." + salaryField + ") AS MinSalary, MAX(s." + salaryField + ") AS MaxSalary FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0)";

                query = "SELECT MIN(s." + salaryField + ") AS MinSalary, MAX(s." + salaryField + ") AS MaxSalary FROM " + from + " WHERE " + where;

                var result = _dbContext.Database.SqlQuery<SearchResult>(query).ToArray();
                if (result.Length > 0)
                {
                    var searchResult = result[0];

                    viewModel.MedianMin = searchResult.MinSalary == null ? 0 : (int)searchResult.MinSalary;
                    viewModel.MedianMax = searchResult.MaxSalary == null ? 0 : (int)searchResult.MaxSalary;
                }
            }

            // calculate lower quartile
            if (viewModel.Records > 1)
            {
                var medianLower = 0;

                var countLower = medianIndex;

                var medianIndexLower = countLower / 2;

                if (medianIndexLower > 0 && countLower % 2 == 0)
                {
                    var start = medianIndexLower - 1;

                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    var totalSalary = 0;

                    foreach (var value in _dbContext.Database.SqlQuery<int?>(query))
                    {
                        totalSalary += value == null ? 0 : (int)value; ;
                    }

                    medianLower = totalSalary / 2;
                }
                else
                {
                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + medianIndexLower + " ROWS FETCH NEXT 1 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + medianIndexLower + " ROWS FETCH NEXT 1 ROWS ONLY";

                    intResultNullable = _dbContext.Database.SqlQuery<int?>(query).ToArray();
                    if (intResultNullable.Length > 0)
                    {
                        medianLower = intResultNullable[0] == null ? 0 : (int)intResultNullable[0];
                    }
                }

                viewModel.MedianLower = medianLower;
            }

            // calculate upper quartile
            if (viewModel.Records > 1)
            {
                var medianUpper = 0;
                var countUpper = 0;
                var medianIndexUpper = 0;

                if (viewModel.Records % 2 == 0)
                {
                    countUpper = viewModel.Records - medianIndex;

                    medianIndexUpper = medianIndex + (countUpper / 2);
                }
                else
                {
                    countUpper = viewModel.Records - medianIndex - 1;

                    medianIndexUpper = medianIndex + (countUpper / 2) + 1;
                }

                if (medianIndexUpper > 0 && countUpper % 2 == 0)
                {
                    var start = medianIndexUpper - 1;

                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                    var totalSalary = 0;

                    foreach (var value in _dbContext.Database.SqlQuery<int?>(query))
                    {
                        totalSalary += value == null ? 0 : (int)value; ;
                    }

                    medianUpper = totalSalary / 2;
                }
                else
                {
                    //query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY s." + salaryField + " OFFSET " + medianIndexUpper + " ROWS FETCH NEXT 1 ROWS ONLY";

                    query = "SELECT s." + salaryField + " FROM " + from + " WHERE " + where + " ORDER BY s." + salaryField + " OFFSET " + medianIndexUpper + " ROWS FETCH NEXT 1 ROWS ONLY";

                    intResultNullable = _dbContext.Database.SqlQuery<int?>(query).ToArray();
                    if (intResultNullable.Length > 0)
                    {
                        medianUpper = intResultNullable[0] == null ? 0 : (int)intResultNullable[0];
                    }
                }

                viewModel.MedianUpper = medianUpper;
            }
        }

        /// <summary>
        /// Calculate median of base salary + other amounts.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="whereList"></param>
        /// <param name="argsList"></param>
        private void _CalculateSalaryPackageMedian(SearchSalaryViewModel viewModel, Dictionary<string, string> whereList, Dictionary<string, string> argsList)
        {
            if (viewModel.Records <= 0)
            {
                return;
            }

            var salaryField = viewModel.AnnualSalary ? "AnnualSalary" : "HourlyRate";

            string query;

            var from = "Salary AS s";

            var where = string.Join(" AND ", whereList.Select(list => list).Select(kvp => kvp.Value).ToList());

            var medianIndex = viewModel.Records / 2;

            if (medianIndex > 0 && viewModel.Records % 2 == 0)
            {
                var start = medianIndex - 1;

                // query = "SELECT (s." + salaryField + " + ISNULL(s.BonusAmount, 0)) AS PackageSalary FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY PackageSalary OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                query = "SELECT (s." + salaryField + " + ISNULL(s.BonusAmount, 0)) AS PackageSalary FROM " + from + " WHERE " + where + " ORDER BY PackageSalary OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                var totalSalary = 0;

                foreach (var value in _dbContext.Database.SqlQuery<int?>(query))
                {
                    totalSalary += value == null ? 0 : (int)value; ; ;
                }

                viewModel.PackageMedian = totalSalary / 2;
            }
            else
            {
                //query = "SELECT (s." + salaryField + " + ISNULL(s.BonusAmount, 0)) AS PackageSalary FROM " + from + " WHERE " + where + " AND (s." + salaryField + ">0) ORDER BY PackageSalary OFFSET " + medianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                query = "SELECT (s." + salaryField + " + ISNULL(s.BonusAmount, 0)) AS PackageSalary FROM " + from + " WHERE " + where + " ORDER BY PackageSalary OFFSET " + medianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                var result = _dbContext.Database.SqlQuery<int?>(query).ToArray();
                if (result.Length > 0)
                {
                    viewModel.PackageMedian = result[0] == null ? 0 : (int)result[0];
                }
            }
        }

        /// <summary>
        /// Calculate benefit percentages.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="whereList"></param>
        /// <param name="argsList"></param>
        private void _CalculateBenefitsPercentage(SearchSalaryViewModel viewModel, Dictionary<string, string> whereList, Dictionary<string, string> argsList)
        {
            var settings = new SettingsHelper();

            if (settings.BenefitTaxonomyId == Guid.Empty)
            {
                return;
            }

            // create list of benefits            
            SearchResultBenefitModel model;
            foreach (var taxon in _availableBenefits.Values)
            {
                model = new SearchResultBenefitModel
                {
                    Id = taxon.Id.ToString(),
                    Name = taxon.Title
                };

                viewModel.BenefitPercentages.Add(model.Id, model);
            }

            /*var l = viewModel.BenefitPercentages["A6F07D49-5F69-4820-BD3A-ACCCE9052D7Bs"];
            if (l != null)
            {
                l.Percentage = 90;
            }*/

            var salaryField = viewModel.AnnualSalary ? "AnnualSalary" : "HourlyRate";

            if (viewModel.Records <= 0)
            {
                return;
            }

            SearchResultBenefitModel benefitModel;

            string benefitId;

            var from = "Salary AS s LEFT JOIN SalaryBenefit sb ON sb.SalaryId = s.Id";

            var where = string.Join(" AND ", whereList.Select(list => list).Select(kvp => kvp.Value).ToList());

            var query = "SELECT sb.BenefitId, COUNT(sb.BenefitId) as Records FROM " + from + " WHERE " + where + " GROUP BY sb.BenefitId HAVING COUNT(sb.BenefitId) > 0";

            foreach (var value in _dbContext.Database.SqlQuery<SearchResult>(query))
            {
                benefitId = value.BenefitId.ToString();

                if (viewModel.BenefitPercentages.ContainsKey(benefitId))
                {
                    benefitModel = viewModel.BenefitPercentages[benefitId];

                    benefitModel.Records = value.Records;
                    benefitModel.Percentage = Math.Round((decimal)value.Records / viewModel.Records * 100, 2);
                }
            }
        }

        /// <summary>
        /// Calculate median of money to leave.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="whereList"></param>
        /// <param name="argsList"></param>
        private void _CalculateMoneyToLeaveMedian(SearchSalaryViewModel viewModel, Dictionary<string, string> whereList, Dictionary<string, string> argsList)
        {
            if (viewModel.Records <= 0)
            {
                return;
            }

            var from = "Salary AS s";

            var where = string.Join(" AND ", whereList.Select(list => list).Select(kvp => kvp.Value).ToList());

            string query = "SELECT COUNT(s.Id) FROM " + from + " WHERE " + where + " AND (s.MoneyToLeave>0)";

            var intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();

            var peopleWithMoneyToLeave = intResult.Length > 0 ? intResult[0] : 0;
            if (peopleWithMoneyToLeave <= 0)
            {
                return;
            }

            var median = 0;

            var medianIndex = (int)peopleWithMoneyToLeave / 2;

            if (medianIndex > 0 && peopleWithMoneyToLeave % 2 == 0)
            {
                var start = medianIndex - 1;

                query = "SELECT s.MoneyToLeave FROM " + from + " WHERE " + where + " AND (s.MoneyToLeave>0) ORDER BY s.MoneyToLeave OFFSET " + start + " ROWS FETCH NEXT 2 ROWS ONLY";

                var total = 0;

                foreach (var value in _dbContext.Database.SqlQuery<int>(query))
                {
                    total += value;
                }

                median = total / 2;
            }
            else
            {
                query = "SELECT s.MoneyToLeave FROM " + from + " WHERE " + where + " AND (s.MoneyToLeave>0) ORDER BY s.MoneyToLeave OFFSET " + medianIndex + " ROWS FETCH NEXT 1 ROWS ONLY";

                intResult = _dbContext.Database.SqlQuery<int>(query).ToArray();
                if (intResult.Length > 0)
                {
                    median = intResult[0];
                }
            }

            viewModel.MedianMoneyToLeave = median;
        }

        /// <summary>
        /// Fetch available benefits.
        /// </summary>
        private void _FetchAvailableBenefits()
        {
            var settings = new SettingsHelper();

            _availableBenefits = new Dictionary<Guid, Taxon>();

            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                var selectedTaxa = (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.Id == settings.BenefitTaxonomyId).FirstOrDefault();
                if (selectedTaxa != null)
                {
                    foreach (var taxon in selectedTaxa.Subtaxa)
                    {
                        if (taxon != null)
                        {
                            _availableBenefits.Add(taxon.Id, taxon);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Create and initialise the view model.
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private SearchSalaryViewModel _GetViewModel(string templateName, SearchSalaryFormModel form)
        {
            var settingsHelper = new SettingsHelper();

            var model = new SearchSalaryViewModel();

            // populate widget properties
            model.Widget = new SearchSalaryWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Search Salaries" : this.Heading,
                Introduction = string.IsNullOrEmpty(this.Introduction) ? "Find out what your talents are worth to an employee!" : this.Introduction,

                JobTypeLabel = string.IsNullOrEmpty(this.JobTypeLabel) ? "Job Type" : this.JobTypeLabel,
                JobTypeHelp = this.JobTypeHelp,
                JobTitleLabel = string.IsNullOrEmpty(this.JobTitleLabel) ? "Job Title" : this.JobTitleLabel,
                JobTitleHelp = this.JobTitleHelp,
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
                YearsOfExperienceLabel = string.IsNullOrEmpty(this.YearsOfExperienceLabel) ? "Years of Experience" : this.YearsOfExperienceLabel,
                YearsOfExperienceHelp = this.YearsOfExperienceHelp,

                ResultPage = string.IsNullOrEmpty(this.ResultPage) ? null : this.ResultPage,

                EmptyOptionLabel = this.EmptyOptionLabel ?? "",

                SubmitButtonLabel = string.IsNullOrEmpty(this.SubmitButtonLabel) ? "Search" : this.SubmitButtonLabel
            };

            // populate various list for index action
            if (templateName == "Default")
            {
                var settings = new SettingsHelper();

                model.Form = form;

                model.JobTypeList = GenericHelper.GetCategoryItems(settings.JobTypeTaxonomyId);
                model.CountryList = GenericHelper.GetCategoryItems(settings.CountryTaxonomyId);
                model.IndustryList = GenericHelper.GetCategoryItems(settings.IndustryTaxonomyId);
                model.YearsOfExperienceList = GenericHelper.GetCategoryItems(settings.YearsOfExperienceTaxonomyId);

                // populate the location list if a country is available else set it to empty
                if (model.Form.CountryId.HasValue)
                {
                    model.LocationList = GenericHelper.GetCategoryItems(model.Form.CountryId.Value);
                }
                else
                {
                    model.LocationList = new List<SelectListItem>();
                }

                // populate the classification list if a industry is available else set it to empty
                if (model.Form.IndustryId.HasValue)
                {
                    model.ClassificationList = GenericHelper.GetCategoryItems(model.Form.IndustryId.Value);
                }
                else
                {
                    model.ClassificationList = new List<SelectListItem>();
                }

                // populate the sub classification list if a classification is available else set it to empty
                if (model.Form.ClassificationId.HasValue)
                {
                    var classification = GenericHelper.GetCategory(model.Form.ClassificationId.Value);
                    if (classification == null || classification.ParentId != model.Form.IndustryId.Value)
                    {
                        model.SubClassificationList = new List<SelectListItem>();
                    }
                    else
                    {
                        model.SubClassificationList = GenericHelper.GetCategoryItems(classification.Id);
                    }

                }
                else
                {
                    model.SubClassificationList = new List<SelectListItem>();
                }
            }

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
