using CsvHelper;
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

namespace JXTNext.Sitefinity.SalarySurvey.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "SalarySurvey_AdminTaxonomyImportWidget", Title = "Import Taxonomies", SectionName = "Salary Survey", ModuleName = SalarySurveyModule.ModuleName)]
    public class AdminTaxonomyImportController : Controller
    {
        #region Widget designer properties

        public string Heading { get; set; }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            return View("Default", _GetViewModel());
        }

        public ActionResult Import(AdminImportTaxonomyFormModel form)
        {
            var response = new GenericAjaxResponseModel
            {
                success = false,
                records = 0,
                imported = 0,
                messages = new Dictionary<string, List<string>>()
            };

            response.messages.Add(GenericAjaxResponseModel.Global, new List<string>());

            // check file before proceeding to import
            if (form.file.ContentLength <= 0)
            {
                ImportHelper.AddResponseError(response, "File size is 0.");
            }
            else if (!form.file.FileName.EndsWith(".csv"))
            {
                ImportHelper.AddResponseError(response, "File must be a CSV file.");
            }
            else
            {
                if (form.Taxonomy == "industry")
                {
                    _ImportIndustry(form.file, response);
                }
                else if (form.Taxonomy == "country")
                {
                    _ImportCountry(form.file, response);
                }
                else
                {
                    ImportHelper.AddResponseError(response, "Invalid taxonomy '" + form.Taxonomy + "' specified.");
                }
            }

            // dispose the uploaded file
            if (form.file != null && form.file.InputStream != null)
            {
                form.file.InputStream.Dispose();
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
        /// Import industry, classification and sub-classification
        /// </summary>
        /// <param name="file"></param>
        /// <param name="response"></param>
        private void _ImportIndustry(HttpPostedFileBase file, GenericAjaxResponseModel response)
        {
            var settings = new SettingsHelper();

            // category for industry must be set to proceed
            if (settings.IndustryTaxonomyId == null || settings.IndustryTaxonomyId == Guid.Empty)
            {
                ImportHelper.AddResponseError(response, "Category to use for industry is not set.");

                return;
            }

            // check whether set industry exist or not
            var taxon = GenericHelper.GetCategory(settings.IndustryTaxonomyId);
            if (taxon == null)
            {
                ImportHelper.AddResponseError(response, "Category set for industry does not exist.");

                return;
            }

            // for keeping track of the row being processed
            int row = 0;

            try
            {
                // cache following on fly
                var industries = new Dictionary<string, Guid>();
                var classifications = new Dictionary<Guid, Dictionary<string, Guid>>();

                IndustryCsvRowModel recordIn;

                // open the uploaded CSV file for validation
                using (var streamReader = new StreamReader(file.InputStream, Encoding.UTF8, true, 1024, true))
                {
                    // validate the records before importing them
                    using (var csvIn = new CsvReader(streamReader))
                    {
                        csvIn.Configuration.WillThrowOnMissingField = false;

                        row = 1;

                        while (csvIn.Read())
                        {
                            response.records++;
                            row++;

                            recordIn = csvIn.GetRecord<IndustryCsvRowModel>();

                            ImportHelper.CleanCsvRow(recordIn);

                            // check the industry
                            if (recordIn.Industry == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Industry)));
                            }

                            // check the classification
                            if (recordIn.Classification == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Classification)));
                            }

                            // check the subClassification
                            if (recordIn.SubClassification == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.SubClassification)));
                            }
                        }
                    }

                    // import the CSV records if there was no validation errors
                    if (response.messages[GenericAjaxResponseModel.Global].Count == 0)
                    {
                        // reset the filestream pointer to the beginning
                        streamReader.BaseStream.Position = 0;
                        streamReader.DiscardBufferedData();

                        using (var csvIn = new CsvReader(streamReader))
                        {
                            csvIn.Configuration.WillThrowOnMissingField = false;

                            Guid? industryId, classificationId;

                            row = 1;

                            while (csvIn.Read())
                            {
                                row++;

                                recordIn = csvIn.GetRecord<IndustryCsvRowModel>();

                                ImportHelper.CleanCsvRow(recordIn);

                                // create industry if does not exist
                                industryId = null;
                                if (industries.ContainsKey(recordIn.Industry))
                                {
                                    industryId = industries[recordIn.Industry];
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(settings.IndustryTaxonomyId, recordIn.Industry);
                                    if (taxon == null)
                                    {
                                        taxon = GenericHelper.CreateCategory(recordIn.Industry, settings.IndustryTaxonomyId);
                                        if (taxon == null)
                                        {
                                            ImportHelper.AddResponseError(response, ImportHelper.GetCreateFailedMessage(row, nameof(recordIn.Industry), recordIn.Industry));

                                            continue;
                                        }
                                    }

                                    industryId = taxon.Id;

                                    industries.Add(recordIn.Industry, taxon.Id);
                                }

                                // create classification if does not exist
                                classificationId = null;
                                if (classifications.ContainsKey(industryId.Value) && classifications[industryId.Value].ContainsKey(recordIn.Classification))
                                {
                                    classificationId = classifications[industryId.Value][recordIn.Classification];
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(industryId.Value, recordIn.Classification);
                                    if (taxon == null)
                                    {
                                        taxon = GenericHelper.CreateCategory(recordIn.Classification, industryId.Value);
                                        if (taxon == null)
                                        {
                                            ImportHelper.AddResponseError(response, ImportHelper.GetCreateFailedMessage(row, nameof(recordIn.Classification), recordIn.Classification));

                                            continue;
                                        }
                                    }

                                    classificationId = taxon.Id;

                                    if (!classifications.ContainsKey(industryId.Value))
                                    {
                                        classifications.Add(industryId.Value, new Dictionary<string, Guid>());
                                    }

                                    classifications[industryId.Value].Add(recordIn.Classification, taxon.Id);
                                }

                                // create sub-classification if does not exist
                                // no caching used here assuming the uploaded CSV file contains unique sub-classifications
                                taxon = GenericHelper.GetCategory(classificationId.Value, recordIn.SubClassification);
                                if (taxon == null)
                                {
                                    taxon = GenericHelper.CreateCategory(recordIn.SubClassification, classificationId.Value);
                                    if (taxon == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetCreateFailedMessage(row, nameof(recordIn.SubClassification), recordIn.SubClassification));

                                        continue;
                                    }
                                }

                                response.imported++;
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
        }

        /// <summary>
        /// Import country and location
        /// </summary>
        /// <param name="file"></param>
        /// <param name="response"></param>
        private void _ImportCountry(HttpPostedFileBase file, GenericAjaxResponseModel response)
        {
            var settings = new SettingsHelper();

            // category for location must be set to proceed
            if (settings.CountryTaxonomyId == null || settings.CountryTaxonomyId == Guid.Empty)
            {
                ImportHelper.AddResponseError(response, "Category to use for location is not set.");

                return;
            }

            // check whether set location exist or not
            var taxon = GenericHelper.GetCategory(settings.CountryTaxonomyId);
            if (taxon == null)
            {
                ImportHelper.AddResponseError(response, "Category set for location does not exist.");

                return;
            }

            // for keeping track of the row being processed
            int row = 0;

            try
            {
                // cache following on fly
                var countries = new Dictionary<string, Guid>();

                CountryCsvRowModel recordIn;

                // open the uploaded CSV file for validation
                using (var streamReader = new StreamReader(file.InputStream, Encoding.UTF8, true, 1024, true))
                {
                    // validate the records before importing them
                    using (var csvIn = new CsvReader(streamReader))
                    {
                        csvIn.Configuration.WillThrowOnMissingField = false;

                        row = 1;

                        while (csvIn.Read())
                        {
                            response.records++;
                            row++;

                            recordIn = csvIn.GetRecord<CountryCsvRowModel>();

                            ImportHelper.CleanCsvRow(recordIn);

                            // check the country
                            if (recordIn.Country == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Country)));
                            }

                            // check the location
                            if (recordIn.Location == null)
                            {
                                ImportHelper.AddResponseError(response, ImportHelper.GetRequiredMessage(row, nameof(recordIn.Location)));
                            }
                        }
                    }

                    // import the CSV records if there was no validation errors
                    if (response.messages[GenericAjaxResponseModel.Global].Count == 0)
                    {
                        // reset the filestream pointer to the beginning
                        streamReader.BaseStream.Position = 0;
                        streamReader.DiscardBufferedData();

                        using (var csvIn = new CsvReader(streamReader))
                        {
                            csvIn.Configuration.WillThrowOnMissingField = false;

                            Guid? countryId;

                            row = 1;

                            while (csvIn.Read())
                            {
                                row++;

                                recordIn = csvIn.GetRecord<CountryCsvRowModel>();

                                ImportHelper.CleanCsvRow(recordIn);

                                // create country if does not exist
                                countryId = null;
                                if (countries.ContainsKey(recordIn.Country))
                                {
                                    countryId = countries[recordIn.Country];
                                }
                                else
                                {
                                    taxon = GenericHelper.GetCategory(settings.CountryTaxonomyId, recordIn.Country);
                                    if (taxon == null)
                                    {
                                        taxon = GenericHelper.CreateCategory(recordIn.Country, settings.CountryTaxonomyId);
                                        if (taxon == null)
                                        {
                                            ImportHelper.AddResponseError(response, ImportHelper.GetCreateFailedMessage(row, nameof(recordIn.Country), recordIn.Country));

                                            continue;
                                        }
                                    }

                                    countryId = taxon.Id;

                                    countries.Add(recordIn.Country, taxon.Id);
                                }

                                // create location if does not exist
                                // no caching used here assuming the uploaded CSV file contains unique locations
                                taxon = GenericHelper.GetCategory(countryId.Value, recordIn.Location);
                                if (taxon == null)
                                {
                                    taxon = GenericHelper.CreateCategory(recordIn.Location, countryId.Value);
                                    if (taxon == null)
                                    {
                                        ImportHelper.AddResponseError(response, ImportHelper.GetCreateFailedMessage(row, nameof(recordIn.Location), recordIn.Location));

                                        continue;
                                    }
                                }

                                response.imported++;
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
        }

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
                Heading = string.IsNullOrEmpty(this.Heading) ? "Import Taxonomies" : this.Heading
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
