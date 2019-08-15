using CsvHelper;
using JXTNext.Sitefinity.SalarySurvey.Database;
using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using JXTNext.Sitefinity.SalarySurvey.Helpers;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{

    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_AdminSalaryImportWidget", Title = "Import Salaries", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class AdminSalaryImportController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            return View("Default", _GetViewModel());
        }

        public ActionResult Import(HttpPostedFileBase file)
        {
            var response = new GenericAjaxResponseModel
            {
                success = false,
                records = 0,
                imported = 0,
                messages = new Dictionary<string, List<string>>()
            };

            response.messages.Add(GenericAjaxResponseModel.Global, new List<string>());

            // for keeping track of the row being processed
            int row = 0;

            try
            {
                if (file.ContentLength <= 0)
                {
                    throw new Exception("File size is 0");
                }

                if (!file.FileName.EndsWith(".csv"))
                {
                    throw new Exception("File must be a CSV file");
                }

                var settings = new SettingsHelper();

                // get various category items
                var jobTypes = ImportHelper.GetCategoryItems(settings.JobTypeTaxonomyId);
                var benefits = ImportHelper.GetCategoryItems(settings.BenefitTaxonomyId);
                var yearsOfExperience = ImportHelper.GetCategoryItems(settings.YearsOfExperienceTaxonomyId);
                var employerSizes = ImportHelper.GetCategoryItems(settings.EmployerSizeTaxonomyId);
                var motivators = ImportHelper.GetCategoryItems(settings.MotivatorTaxonomyId);
                var careerMoves = ImportHelper.GetCategoryItems(settings.CareerMoveTaxonomyId);
                var industries = ImportHelper.GetCategoryItems(settings.IndustryTaxonomyId);
                var genders = ImportHelper.GetCategoryItems(settings.GenderTaxonomyId);
                var peopleManaged = ImportHelper.GetCategoryItems(settings.PeopleManagedTaxonomyId);
                var educations = ImportHelper.GetCategoryItems(settings.EducationTaxonomyId);
                var countries = ImportHelper.GetCategoryItems(settings.CountryTaxonomyId);

                // get job types with annual salary
                var annualSalaryTaxonomyIds = settings.AnnualSalaryJobTypeTaxonomyIds;

                // cache following on fly; based on GUID
                var locations = new Dictionary<Guid, Dictionary<string, Guid>>();
                var classifications = new Dictionary<Guid, Dictionary<string, Guid>>();
                var subClassifications = new Dictionary<Guid, Dictionary<string, Guid>>();

                int? intVal;
                decimal? decimalVal;
                string stringVal;
                SalaryCsvRowModel recordIn;

                var manager = TaxonomyManager.GetManager();

                // open the uploaded CSV file for validation
                using (var streamReader = new StreamReader(file.InputStream, Encoding.UTF8, true, 1024, true))
                {
                    using (var csvIn = new CsvReader(streamReader))
                    {
                        csvIn.Configuration.WillThrowOnMissingField = false;

                        HierarchicalTaxon taxon;
                        Guid? countryId, industryId, classificationId;

                        row = 1;

                        // validate the records before importing them
                        while (csvIn.Read())
                        {
                            response.records++;
                            row++;

                            recordIn = csvIn.GetRecord<SalaryCsvRowModel>();

                            ImportHelper.CleanCsvRow(recordIn);

                            // check the country
                            countryId = null;
                            if (recordIn.Country == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Country)));
                            }
                            else if (!countries.ContainsKey(recordIn.Country))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Country), recordIn.Country));
                            }
                            else
                            {
                                countryId = countries[recordIn.Country];
                            }

                            // check the location
                            if (recordIn.Location == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Location)));
                            }
                            else if (countryId.HasValue)
                            {
                                if (!locations.ContainsKey(countryId.Value) || !locations[countryId.Value].ContainsKey(recordIn.Location))
                                {
                                    taxon = GenericHelper.GetCategory(countryId.Value, recordIn.Location);
                                    if (taxon == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Location), recordIn.Location));
                                    }
                                    else
                                    {
                                        // cache it for future checks

                                        if (!locations.ContainsKey(countryId.Value))
                                        {
                                            locations.Add(countryId.Value, new Dictionary<string, Guid>());
                                        }

                                        locations[countryId.Value].Add(recordIn.Location, taxon.Id);
                                    }
                                }
                            }

                            // check the industry
                            industryId = null;
                            if (recordIn.Industry == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Industry)));
                            }
                            else if (!industries.ContainsKey(recordIn.Industry))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Industry), recordIn.Industry));
                            }
                            else
                            {
                                industryId = industries[recordIn.Industry];
                            }

                            // check the classification
                            classificationId = null;
                            if (recordIn.Classification == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Classification)));
                            }
                            else if (industryId.HasValue)
                            {
                                if (classifications.ContainsKey(industryId.Value) && classifications[industryId.Value].ContainsKey(recordIn.Classification))
                                {
                                    classificationId = classifications[industryId.Value][recordIn.Classification];
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(industryId.Value, recordIn.Classification);
                                    if (taxon == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Classification), recordIn.Classification));
                                    }
                                    else
                                    {
                                        classificationId = taxon.Id;

                                        // cache it for future checks

                                        if (!classifications.ContainsKey(industryId.Value))
                                        {
                                            classifications.Add(industryId.Value, new Dictionary<string, Guid>());
                                        }

                                        classifications[industryId.Value].Add(recordIn.Classification, taxon.Id);
                                    }
                                }
                            }

                            // check the subClassification
                            if (recordIn.SubClassification == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.SubClassification)));
                            }
                            else if (classificationId.HasValue)
                            {
                                if (!subClassifications.ContainsKey(classificationId.Value) || !subClassifications[classificationId.Value].ContainsKey(recordIn.SubClassification))
                                {
                                    taxon = GenericHelper.GetCategory(classificationId.Value, recordIn.SubClassification);
                                    if (taxon == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.SubClassification), recordIn.SubClassification));
                                    }
                                    else
                                    {
                                        // cache it for future checks

                                        if (!subClassifications.ContainsKey(classificationId.Value))
                                        {
                                            subClassifications.Add(classificationId.Value, new Dictionary<string, Guid>());
                                        }

                                        subClassifications[classificationId.Value].Add(recordIn.SubClassification, taxon.Id);
                                    }
                                }
                            }

                            // check the job type
                            if (recordIn.JobType == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.JobType)));
                            }
                            else if (!jobTypes.ContainsKey(recordIn.JobType))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.JobType), recordIn.JobType));
                            }
                            else
                            {
                                // check the wages
                                if (annualSalaryTaxonomyIds.Contains(jobTypes[recordIn.JobType]))
                                {
                                    intVal = recordIn.AnnualSalary == null ? 0 : ImportHelper.ConvertToInt(recordIn.AnnualSalary);

                                    if (intVal == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.AnnualSalary), recordIn.AnnualSalary));
                                    }
                                    else if (intVal <= 0)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.AnnualSalary)));
                                    }
                                }
                                else
                                {
                                    decimalVal = recordIn.HourlyRate == null ? 0 : ImportHelper.ConvertToDecimal(recordIn.HourlyRate);

                                    if (decimalVal == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.HourlyRate), recordIn.HourlyRate));
                                    }
                                    else if (decimalVal <= 0)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.HourlyRate)));
                                    }
                                }
                            }

                            // check the bonus
                            intVal = recordIn.Bonus == null ? 0 : ImportHelper.ConvertToInt(recordIn.Bonus);
                            if (intVal == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Bonus), recordIn.Bonus));
                            }

                            // check the years of experience
                            if (recordIn.YearsOfExperience != null && !yearsOfExperience.ContainsKey(recordIn.YearsOfExperience))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.YearsOfExperience), recordIn.YearsOfExperience));
                            }

                            // check the people managed
                            if (recordIn.PeopleManaged != null && !peopleManaged.ContainsKey(recordIn.PeopleManaged))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.PeopleManaged), recordIn.PeopleManaged));
                            }

                            // check the gender
                            if (recordIn.Gender != null && !genders.ContainsKey(recordIn.Gender))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Gender), recordIn.Gender));
                            }

                            // check the employer size
                            if (recordIn.EmployerSize != null && !employerSizes.ContainsKey(recordIn.EmployerSize))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.EmployerSize), recordIn.EmployerSize));
                            }

                            // check the money to leave
                            intVal = recordIn.MoneyToLeave == null ? 0 : ImportHelper.ConvertToInt(recordIn.MoneyToLeave);
                            if (intVal == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.MoneyToLeave), recordIn.MoneyToLeave));
                            }

                            // check the education
                            if (recordIn.Education != null && !educations.ContainsKey(recordIn.Education))
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Education), recordIn.Education));
                            }

                            // check the benefits
                            if (recordIn.Benefits != null)
                            {
                                foreach (var item in recordIn.Benefits.Split(','))
                                {
                                    stringVal = item.Trim();

                                    if (stringVal != "" && !benefits.ContainsKey(stringVal) && stringVal.Length > 255)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.Benefits), 255));
                                    }
                                }
                            }

                            // check the motivators
                            if (recordIn.Motivators != null)
                            {
                                foreach (var item in recordIn.Motivators.Split(','))
                                {
                                    stringVal = item.Trim();

                                    if (stringVal != "" && !motivators.ContainsKey(stringVal) && stringVal.Length > 255)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.Motivators), 255));
                                    }
                                }
                            }

                            // check the best employers
                            if (recordIn.BestEmployers != null)
                            {
                                foreach (var item in recordIn.BestEmployers.Split(','))
                                {
                                    if (item.Trim().Length > 255)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.BestEmployers), 255));
                                    }
                                }
                            }

                            // check the career moves
                            if (recordIn.CareerMove != null)
                            {
                                foreach (var item in recordIn.CareerMove.Split(','))
                                {
                                    stringVal = item.Trim();

                                    if (stringVal != "" && !careerMoves.ContainsKey(stringVal))
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.CareerMove), stringVal));
                                    }
                                }
                            }

                            // check the job title
                            if (recordIn.JobTitle != null)
                            {
                                if (recordIn.JobTitle.Length > 255)
                                {
                                    ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.JobTitle), 255));
                                }
                            }

                            // check the name
                            if (recordIn.Name != null)
                            {
                                if (recordIn.Name.Length > 255)
                                {
                                    ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.Name), 255));
                                }
                            }

                            // check the phone
                            if (recordIn.Phone != null)
                            {
                                if (recordIn.Phone.Length > 255)
                                {
                                    ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.Phone), 255));
                                }
                            }

                            // check the email
                            if (recordIn.Email != null)
                            {
                                if (recordIn.Email.Length > 255)
                                {
                                    ImportHelper.AddResponseError(response, ImportHelper.GetInvalidLengthMessage(row, nameof(recordIn.Email), 255));
                                }
                                else if (!GenericHelper.IsValidEmail(recordIn.Email))
                                {
                                    ImportHelper.AddResponseError(response, ImportHelper.GetInvalidValueMessage(row, nameof(recordIn.Email), recordIn.Email));
                                }
                            }
                        }
                    }

                    // import the CSV records
                    if (response.messages[GenericAjaxResponseModel.Global].Count == 0)
                    {
                        // reset the filestream pointer to the beginning
                        streamReader.BaseStream.Position = 0;
                        streamReader.DiscardBufferedData();

                        // open the csv for import
                        using (var csvIn = new CsvReader(streamReader))
                        {
                            csvIn.Configuration.WillThrowOnMissingField = false;

                            using (var dbContext = SalarySurveyDbContext.CreateInstance())
                            {
                                // configuration changes to speed up the insert process
                                dbContext.Configuration.AutoDetectChangesEnabled = false;
                                dbContext.Configuration.ValidateOnSaveEnabled = false;

                                var batch = 0;
                                var currentDate = DateTime.Now;
                                var siteId = GenericHelper.GetCurrentSiteId();

                                row = 1;

                                while (csvIn.Read())
                                {
                                    row++;

                                    var record = csvIn.GetRecord<SalaryCsvRowModel>();

                                    ImportHelper.CleanCsvRow(record);

                                    var salary = new Salary
                                    {
                                        SiteId = siteId,
                                        CreatedDate = currentDate,
                                        Verified = true,

                                        JobTitle = record.JobTitle,
                                        CountryId = countries[record.Country],
                                        IndustryId = industries[record.Industry],
                                        JobTypeId = jobTypes[record.JobType],

                                        BonusAmount = ImportHelper.ConvertToInt(record.Bonus),
                                        MoneyToLeave = ImportHelper.ConvertToInt(record.MoneyToLeave),
                                        ProfessionalQualification = ImportHelper.ConvertToBoolean(record.ProfessionalQualification)
                                    };

                                    salary.LocationId = locations[salary.CountryId][record.Location];
                                    salary.ClassificationId = classifications[salary.IndustryId][record.Classification];
                                    salary.SubClassificationId = subClassifications[salary.ClassificationId][record.SubClassification];

                                    if (annualSalaryTaxonomyIds.Contains(salary.JobTypeId))
                                    {
                                        salary.AnnualSalary = ImportHelper.ConvertToInt(record.AnnualSalary);
                                    }
                                    else
                                    {
                                        // todo - make hourly rate decimal in DB
                                        salary.HourlyRate = (int)ImportHelper.ConvertToDecimal(record.HourlyRate);
                                    }

                                    if (record.YearsOfExperience != null)
                                    {
                                        salary.YearsOfExperienceId = yearsOfExperience[record.YearsOfExperience];
                                    }

                                    if (record.PeopleManaged != null)
                                    {
                                        salary.PeopleManagedId = peopleManaged[record.PeopleManaged];
                                    }

                                    if (record.Gender != null)
                                    {
                                        salary.GenderId = genders[record.Gender];
                                    }

                                    if (record.EmployerSize != null)
                                    {
                                        salary.EmployerSizeId = employerSizes[record.EmployerSize];
                                    }

                                    if (record.Education != null)
                                    {
                                        salary.EducationId = educations[record.Education];
                                    }

                                    // set benefits and other benefits
                                    if (record.Benefits != null)
                                    {
                                        salary.Benefits = new List<SalaryBenefit>();
                                        salary.OtherBenefits = new List<SalaryBenefitOther>();

                                        foreach (var item in record.Benefits.Split(','))
                                        {
                                            stringVal = item.Trim();
                                            if (stringVal == "")
                                            {
                                                continue;
                                            }

                                            if (benefits.ContainsKey(stringVal))
                                            {
                                                salary.Benefits.Add(new SalaryBenefit
                                                {
                                                    BenefitId = benefits[stringVal]
                                                });
                                            }
                                            else
                                            {
                                                salary.OtherBenefits.Add(new SalaryBenefitOther
                                                {
                                                    Name = stringVal
                                                });
                                            }
                                        }
                                    }

                                    // set motivators and other motivators
                                    if (record.Motivators != null)
                                    {
                                        salary.Motivators = new List<SalaryMotivator>();
                                        salary.OtherMotivators = new List<SalaryMotivatorOther>();

                                        var position = 1;
                                        var positionOther = 1;

                                        foreach (var item in record.Motivators.Split(','))
                                        {
                                            stringVal = item.Trim();
                                            if (stringVal == "")
                                            {
                                                continue;
                                            }

                                            if (motivators.ContainsKey(stringVal))
                                            {
                                                salary.Motivators.Add(new SalaryMotivator
                                                {
                                                    MotivatorId = motivators[stringVal],
                                                    Position = position++
                                                });
                                            }
                                            else
                                            {
                                                salary.OtherMotivators.Add(new SalaryMotivatorOther
                                                {
                                                    Name = stringVal,
                                                    Position = positionOther++
                                                });
                                            }
                                        }
                                    }

                                    // set best employers
                                    if (record.BestEmployers != null)
                                    {
                                        salary.BestEmployers = new List<SalaryBestEmployer>();

                                        foreach (var item in record.BestEmployers.Split(','))
                                        {
                                            stringVal = item.Trim();
                                            if (stringVal == "")
                                            {
                                                continue;
                                            }

                                            salary.BestEmployers.Add(new SalaryBestEmployer
                                            {
                                                Name = stringVal
                                            });
                                        }
                                    }

                                    // set career moves
                                    if (record.CareerMove != null)
                                    {
                                        salary.CareerMoves = new List<SalaryCareerMove>();

                                        foreach (var item in record.CareerMove.Split(','))
                                        {
                                            stringVal = item.Trim();
                                            if (stringVal == "")
                                            {
                                                continue;
                                            }

                                            salary.CareerMoves.Add(new SalaryCareerMove
                                            {
                                                CareerMoveId = careerMoves[stringVal]
                                            });
                                        }
                                    }

                                    dbContext.Salary.Add(salary);

                                    // insert records using batch size of 500
                                    batch++;
                                    if (batch == 500)
                                    {
                                        dbContext.SaveChanges();

                                        response.imported += batch;

                                        batch = 0;
                                    }
                                }

                                dbContext.SaveChanges();

                                response.imported += batch;
                            }
                        }

                        response.success = true;
                    }
                }
            }
            catch (Exception err)
            {
                ImportHelper.AddResponseErrorFromException(response, row, err);

                Log.Write(err);
            }

            // dispose the uploaded file
            if (file != null && file.InputStream != null)
            {
                file.InputStream.Dispose();
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = response
            };
        }

        #endregion

        #region Private methods       

        /// <summary>
        /// Get the view model.
        /// </summary>
        /// <returns></returns>
        private AdminSalaryViewModel _GetViewModel()
        {
            var model = new AdminSalaryViewModel();

            // populate widget properties
            model.Widget = new AdminSalaryWidgetModel
            {
                Heading = string.IsNullOrEmpty(this.Heading) ? "Import Salaries" : this.Heading
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
