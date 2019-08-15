using JXTNext.Sitefinity.SalarySurvey.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.SiteSettings.Web.Services;

namespace JXTNext.Sitefinity.SalarySurvey.Helpers
{
    /// <summary>
    /// Helper to retrieve values of admin settings.
    /// </summary>
    public class SettingsHelper
    {
        private const string _itemType = "JXTNext.Sitefinity.SalarySurvey.Admin.SalarySurveySettingsContract";

        private SalarySurveySettingsContract _settingsContract = null;

        public SettingsHelper()
        {
            var basicSettingsSerivce = new BasicSettingsService();
            var multiSiteContext = new MultisiteContext();
            var currSite = multiSiteContext.CurrentSite;

            SettingsItemContext siteSetting = null;
            SystemManager.RunWithElevatedPrivilege(d => { siteSetting = basicSettingsSerivce.GetSettings(_itemType, currSite.Id.ToString()); });

            if (siteSetting != null)
            {
                _settingsContract = (SalarySurveySettingsContract)siteSetting.Item;
            }

            if (_settingsContract == null)
            {
                _settingsContract = new SalarySurveySettingsContract();
            }
        }

        public string CurrencySymbol
        {
            get
            {
                return _settingsContract.CurrencySymbol;
            }
        }

        public decimal SuperannuationRate
        {
            get
            {
                return _settingsContract.SuperannuationRate;
            }
        }

        public decimal MedicareRate
        {
            get
            {
                return _settingsContract.MedicareRate;
            }
        }

        public int WeeklyHours
        {
            get
            {
                return _settingsContract.WeeklyHours;
            }
        }

        public int SalaryAlertCount
        {
            get
            {
                return _settingsContract.SalaryAlertCount < 1 ? 10 : _settingsContract.SalaryAlertCount;
            }
        }

        public IPAddress SalaryAlertTaskServerIp
        {
            get
            {
                IPAddress.TryParse(_settingsContract.SalaryAlertTaskServerIp, out IPAddress address);

                return address;
            }
        }

        public Guid SalaryAlertEmailTemplateId
        {
            get
            {
                return _settingsContract.SalaryAlertEmailTemplateId;
            }
        }

        public string SalaryAlertSalaryItemTemplate
        {
            get
            {
                return _settingsContract.SalaryAlertSalaryItemTemplate;
            }
        }

        public string SalaryAlertEmailFromName
        {
            get
            {
                return _settingsContract.SalaryAlertEmailFromName;
            }
        }

        public string SalaryAlertEmailFromAddress
        {
            get
            {
                return _settingsContract.SalaryAlertEmailFromAddress;
            }
        }

        public Dictionary<int, decimal> TaxBrackets
        {
            get
            {
                var brackets = new Dictionary<int, decimal>();

                string[] bracket;
                int amount;
                decimal rate;

                if (!string.IsNullOrWhiteSpace(_settingsContract.TaxBrackets))
                {
                    foreach (var item in _settingsContract.TaxBrackets.Split('|'))
                    {
                        bracket = item.Split(',');

                        if (bracket.Length == 2)
                        {
                            if (Int32.TryParse(bracket[0], out amount) && Decimal.TryParse(bracket[1], out rate))
                            {
                                brackets[amount] = rate;
                            }
                        }
                    }
                }

                return brackets;
            }
        }

        public Guid CountryTaxonomyId
        {
            get
            {
                return _settingsContract.CountryTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.CountryTaxonomyId.FirstOrDefault();
            }
        }

        public Guid IndustryTaxonomyId
        {
            get
            {
                return _settingsContract.IndustryTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.IndustryTaxonomyId.FirstOrDefault();
            }
        }        

        public Guid JobTypeTaxonomyId
        {
            get
            {
                return _settingsContract.JobTypeTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.JobTypeTaxonomyId.FirstOrDefault();
            }
        }

        public List<Guid> AnnualSalaryJobTypeTaxonomyIds
        {
            get
            {
                return _settingsContract.AnnualSalaryJobTypeTaxonomyIds == null
                    ? new List<Guid>()
                    : _settingsContract.AnnualSalaryJobTypeTaxonomyIds;
            }
        }

        public Guid YearsOfExperienceTaxonomyId
        {
            get
            {
                return _settingsContract.YearsOfExperienceTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.YearsOfExperienceTaxonomyId.FirstOrDefault();
            }
        }

        public Guid SectorTaxonomyId
        {
            get
            {
                return _settingsContract.SectorTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.SectorTaxonomyId.FirstOrDefault();
            }
        }

        public Guid EmployerSizeTaxonomyId
        {
            get
            {
                return _settingsContract.EmployerSizeTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.EmployerSizeTaxonomyId.FirstOrDefault();
            }
        }

        public Guid PeopleManagedTaxonomyId
        {
            get
            {
                return _settingsContract.PeopleManagedTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.PeopleManagedTaxonomyId.FirstOrDefault();
            }
        }

        public Guid GenderTaxonomyId
        {
            get
            {
                return _settingsContract.GenderTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.GenderTaxonomyId.FirstOrDefault();
            }
        }

        public Guid EducationTaxonomyId
        {
            get
            {
                return _settingsContract.EducationTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.EducationTaxonomyId.FirstOrDefault();
            }
        }

        public Guid BenefitTaxonomyId
        {
            get
            {
                return _settingsContract.BenefitTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.BenefitTaxonomyId.FirstOrDefault();
            }
        }

        public Guid MotivatorTaxonomyId
        {
            get
            {
                return _settingsContract.MotivatorTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.MotivatorTaxonomyId.FirstOrDefault();
            }
        }

        public Guid CareerMoveTaxonomyId
        {
            get
            {
                return _settingsContract.CareerMoveTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.CareerMoveTaxonomyId.FirstOrDefault();
            }
        }

        public Guid AnnualSalariesTaxonomyId
        {
            get
            {
                return _settingsContract.AnnualSalariesTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.AnnualSalariesTaxonomyId.FirstOrDefault();
            }
        }

        public Guid HourlyRatesTaxonomyId
        {
            get
            {
                return _settingsContract.HourlyRatesTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.HourlyRatesTaxonomyId.FirstOrDefault();
            }
        }

        public Guid BonusAmountsTaxonomyId
        {
            get
            {
                return _settingsContract.BonusAmountsTaxonomyId == null
                    ? Guid.Empty
                    : _settingsContract.BonusAmountsTaxonomyId.FirstOrDefault();
            }
        }

        public bool SalaryCalculatorIncreaseByPercentage
        {
            get
            {
                return false;
            }
        }

    }
}
