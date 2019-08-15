using JXTNext.Sitefinity.SalarySurvey.Database;
using JXTNext.Sitefinity.SalarySurvey.Database.Models;
using JXTNext.Sitefinity.SalarySurvey.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace JXTNext.Sitefinity.SalarySurvey.Helpers
{
    public class GenericHelper
    {
        /// <summary>
        /// Get current site's ID.
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentSiteId()
        {
            var host = new MultisiteContext().CurrentSite.LiveUrl;
            host = host.ToLower().Replace("www.", "");

            var dbContext = SalarySurveyDbContext.CreateInstance();

            var site = dbContext.Site.Where(s => s.Domain == host).FirstOrDefault();
            if (site == null)
            {
                return 0;
            }

            if (site.AliasOfId.HasValue)
            {
                return site.AliasOfId.Value;
            }

            return site.Id;
        }

        /// <summary>
        /// Check whether email is valid or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get a category.
        /// </summary>
        /// <param name="categoryId">Guid</param>
        /// <returns>HierarchicalTaxon</returns>
        public static HierarchicalTaxon GetCategory(Guid categoryId)
        {
            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                return (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.Id == categoryId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get a category.
        /// </summary>
        /// <param name="categoryName">string</param>
        /// <returns>HierarchicalTaxon</returns>
        public static HierarchicalTaxon GetCategory(string categoryName)
        {
            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                return (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.Title == categoryName).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get a category.
        /// </summary>
        /// <param name="parentId">Guid</param>
        /// <param name="categoryName">string</param>
        /// <returns>HierarchicalTaxon</returns>
        public static HierarchicalTaxon GetCategory(Guid parentId, string categoryName)
        {
            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                return (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.ParentId == parentId && t.Title == categoryName).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get categories of specified ids
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public static IEnumerable<Taxon> GetCategories(List<Guid> guids)
        {
            List<HierarchicalTaxon> taxons = new List<HierarchicalTaxon>();

            var manager = TaxonomyManager.GetManager();

            var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

            return categoriesTaxonomy.Taxa.Where(t => guids.Contains(t.Id));
        }

        /// <summary>
        /// Get list of items of a category.
        /// </summary>
        /// <param name="categoryId">Guid</param>
        /// <returns>List<SelectListItem></returns>
        public static List<SelectListItem> GetCategoryItems(Guid categoryId)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                var selectedTaxa = (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.Id == categoryId).FirstOrDefault();
                if (selectedTaxa != null)
                {
                    foreach (var taxon in selectedTaxa.Subtaxa)
                    {
                        if (taxon != null)
                        {
                            list.Add(new SelectListItem { Text = taxon.Title, Value = taxon.Id.ToString() });
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return list;
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="title"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static HierarchicalTaxon CreateCategory(string title, Guid parentId)
        {
            try
            {
                var manager = TaxonomyManager.GetManager();

                var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);

                var taxonSubCateg = manager.CreateTaxon<HierarchicalTaxon>();
                taxonSubCateg.Title = title;
                taxonSubCateg.UrlName = new Lstring(Regex.Replace(title, @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-").ToLower());
                taxonSubCateg.Taxonomy = categoriesTaxonomy;

                var parentTaxonomy = (HierarchicalTaxon)categoriesTaxonomy.Taxa.Where(t => t.Id == parentId).FirstOrDefault();
                if (parentTaxonomy == null)
                {
                    return null;
                }

                parentTaxonomy.Subtaxa.Add(taxonSubCateg);
                manager.SaveChanges();

                return taxonSubCateg;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Create a salary.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static long? CreateSalary(SubmitSalaryFormModel form)
        {
            var salary = new Salary
            {
                SiteId = GenericHelper.GetCurrentSiteId(),

                CountryId = form.CountryId,
                LocationId = form.LocationId,
                IndustryId = form.IndustryId,
                ClassificationId = form.ClassificationId,
                SubClassificationId = form.SubClassificationId,
                JobTypeId = form.JobTypeId,
                HourlyRate = form.HourlyRate,
                AnnualSalary = form.AnnualSalary,
                BonusAmount = form.BonusAmount,

                ProfessionalQualification = form.ProfessionalQualification,
                EducationId = form.EducationId,
                YearsOfExperienceId = form.YearsOfExperienceId,
                PeopleManagedId = form.PeopleManagedId,
                GenderId = form.GenderId,
                EmployerSizeId = form.EmployerSizeId,
                MoneyToLeave = form.MoneyToLeave,

                JobAlert = form.JobAlert,
                SalaryAlert = form.SalaryAlert,
                ContactRequest = form.ContactRequest,
                Name = form.Name,
                Email = form.Email,
                Phone = form.Phone,

                CreatedDate = DateTime.Now,
                Verified = true
            };

            using (var dbContext = SalarySurveyDbContext.CreateInstance())
            {
                using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.Salary.Add(salary);
                        dbContext.SaveChanges();

                        // add benefits
                        if (form.BenefitId != null)
                        {
                            foreach (var item in form.BenefitId)
                            {
                                dbContext.SalaryBenefit.Add(new SalaryBenefit { SalaryId = salary.Id, BenefitId = item });
                            }
                        }

                        // add other benefits
                        if (form.BenefitOther != null)
                        {
                            string val;

                            foreach (var item in form.BenefitOther.Split(','))
                            {
                                val = item.Trim();

                                if (string.IsNullOrWhiteSpace(val))
                                {
                                    continue;
                                }

                                dbContext.SalaryBenefitOther.Add(new SalaryBenefitOther { SalaryId = salary.Id, Name = val });
                            }
                        }

                        // add best employers
                        if (form.BestEmployer != null)
                        {
                            string val;

                            foreach (var item in form.BestEmployer)
                            {
                                val = item.Trim();

                                if (string.IsNullOrWhiteSpace(val))
                                {
                                    continue;
                                }

                                dbContext.SalaryBestEmployer.Add(new SalaryBestEmployer { SalaryId = salary.Id, Name = val });
                            }
                        }

                        // add career moves
                        if (form.CareerMoveId != null)
                        {
                            foreach (var item in form.CareerMoveId)
                            {
                                dbContext.SalaryCareerMove.Add(new SalaryCareerMove { SalaryId = salary.Id, CareerMoveId = item });
                            }
                        }

                        // add motivators
                        if (form.MotivatorOrder != null)
                        {
                            foreach (var item in form.MotivatorOrder)
                            {
                                dbContext.SalaryMotivator.Add(new SalaryMotivator { SalaryId = salary.Id, MotivatorId = new Guid(item.Key), Position = item.Value });
                            }
                        }

                        // add other motivators
                        if (form.MotivatorOther != null)
                        {
                            var idx = 1;

                            foreach (var item in form.MotivatorOther.Split(','))
                            {
                                dbContext.SalaryMotivatorOther.Add(new SalaryMotivatorOther { SalaryId = salary.Id, Name = item.Trim(), Position = idx });

                                idx++;
                            }
                        }

                        dbContext.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception err)
                    {
                        dbContextTransaction.Rollback();

                        throw err;
                    }
                }
            }

            return salary.Id;
        }

        /// <summary>
        /// Get IP address of the client.
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetClientIpAddress()
        {
            var context = HttpContext.Current;

            IPAddress ip = IPAddress.None;

            var clientIp = context.Request.Headers["True-Client-IP"];
            if (!string.IsNullOrEmpty(clientIp))
            {
                if (IPAddress.TryParse(clientIp, out ip))
                {
                    return ip;
                }
            }

            if (!string.IsNullOrEmpty(context.Request.UserHostAddress))
            {
                if (IPAddress.TryParse(context.Request.UserHostAddress, out ip))
                {
                    return ip;
                }
            }

            return ip;
        }

        /// <summary>
        /// Get an email template.
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static DynamicContent GetEmailTemplate(Guid templateId)
        {
            var dynamicModuleManager = DynamicModuleManager.GetManager("OpenAccessProvider");

            var emailTemplateType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate");

            var emailTemplateItem = dynamicModuleManager.GetDataItem(emailTemplateType, templateId);

            return emailTemplateItem;
        }

        /// <summary>
        /// Get a salary.
        /// </summary>
        /// <param name="salaryId"></param>
        /// <param name="postedMinutesAgo">0 for no time limit</param>
        /// <returns></returns>
        /*public static Salary GetSalary(Guid salaryId, int postedMinutesAgo = 60)
        {
            using (var dbContext = SalarySurveyDbContext.CreateInstance())
            {
                var salary = dbContext.Salary.Find(salaryId);
                if (salary == null)
                {
                    return null;
                }

                if (postedMinutesAgo > 0 && DateTime.Now.Subtract(salary.CreatedDate).TotalMinutes > postedMinutesAgo)
                {
                    return null;
                }

                return salary;
            }
        }*/

        /// <summary>
        /// Get a salary.
        /// </summary>
        /// <param name="salaryId"></param>
        /// <param name="postedMinutesAgo">0 for no time limit</param>
        /// <returns></returns>
        /*public static Salary GetSalary(string salaryId, int postedMinutesAgo = 60)
        {
            if (!Guid.TryParse(salaryId, out Guid id))
            {
                return null;
            }

            return GetSalary(id, postedMinutesAgo);
        }*/
    }
}
