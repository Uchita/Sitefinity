using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.SalarySurvey.Admin
{
    /// <summary>
    /// See https://www.progress.com/documentation/sitefinity-cms/custom-basic-settings-create-the-setting
    /// </summary>
    [ObjectInfo(typeof(ConfigDescriptions))]
    public class SalarySurveySettingsUISettings : ConfigElement
    {
        public SalarySurveySettingsUISettings(ConfigElement parent) : base(parent)
        {
        }

        [ConfigurationProperty("currencySymbol")]
        [DescriptionResource(typeof(ConfigDescriptions), "CurrencySymbol")]
        [DataMember]
        public virtual string CurrentCurrencySymbol
        {
            get
            {
                return (string)this["currencySymbol"];
            }

            set
            {
                this["currencySymbol"] = value;
            }
        }

        [ConfigurationProperty("superannuationRate")]
        [DescriptionResource(typeof(ConfigDescriptions), "SuperannuationRate")]
        [DataMember]
        public virtual Decimal CurrentSuperannuationRate
        {
            get
            {
                return (Decimal)this["superannuationRate"];
            }

            set
            {
                this["superannuationRate"] = value;
            }
        }

        [ConfigurationProperty("medicareRate")]
        [DescriptionResource(typeof(ConfigDescriptions), "MedicareRate")]
        [DataMember]
        public virtual Decimal CurrentMedicareRate
        {
            get
            {
                return (Decimal)this["medicareRate"];
            }

            set
            {
                this["medicareRate"] = value;
            }
        }

        [ConfigurationProperty("weeklyHours")]
        [DescriptionResource(typeof(ConfigDescriptions), "WeeklyHours")]
        [DataMember]
        public virtual int CurrentWeeklyHours
        {
            get
            {
                return (int)this["weeklyHours"];
            }

            set
            {
                this["weeklyHours"] = value;
            }
        }

        [ConfigurationProperty("taxBrackets")]
        [DescriptionResource(typeof(ConfigDescriptions), "TaxBrackets")]
        [DataMember]
        public virtual string CurrentTaxBrackets
        {
            get
            {
                return (string)this["taxBrackets"];
            }

            set
            {
                this["taxBrackets"] = value;
            }
        }

        [ConfigurationProperty("countryTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "CountryTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentCountryTaxonomyId
        {
            get
            {
                return (List<Guid>)this["countryTaxonomyId"];
            }

            set
            {
                this["countryTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("industryTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "IndustryTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentIndustryTaxonomyId
        {
            get
            {
                return (List<Guid>)this["industryTaxonomyId"];
            }

            set
            {
                this["industryTaxonomyId"] = value;
            }
        }        

        [ConfigurationProperty("jobTypeTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "JobTypeTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentJobTypeTaxonomyId
        {
            get
            {
                return (List<Guid>)this["jobTypeTaxonomyId"];
            }

            set
            {
                this["jobTypeTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("annualSalaryJobTypeTaxonomyIds")]
        [DescriptionResource(typeof(ConfigDescriptions), "AnnualSalaryJobTypeTaxonomyIds")]
        [DataMember]
        public virtual List<Guid> CurrentAnnualSalaryJobTypeTaxonomyIds
        {
            get
            {
                return (List<Guid>)this["annualSalaryJobTypeTaxonomyIds"];
            }

            set
            {
                this["annualSalaryJobTypeTaxonomyIds"] = value;
            }
        }

        [ConfigurationProperty("yearsOfExperienceTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "YearsOfExperienceTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentYearsOfExperienceTaxonomyId
        {
            get
            {
                return (List<Guid>)this["yearsOfExperienceTaxonomyId"];
            }

            set
            {
                this["yearsOfExperienceTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("sectorTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "SectorTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentSectorTaxonomyId
        {
            get
            {
                return (List<Guid>)this["sectorTaxonomyId"];
            }

            set
            {
                this["sectorTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("employerSizeTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "EmployerSizeTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentEmployerSizeTaxonomyId
        {
            get
            {
                return (List<Guid>)this["employerSizeTaxonomyId"];
            }

            set
            {
                this["employerSizeTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("peopleManagedTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "PeopleManagedTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentPeopleManagedTaxonomyId
        {
            get
            {
                return (List<Guid>)this["peopleManagedTaxonomyId"];
            }

            set
            {
                this["peopleManagedTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("educationTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "EducationTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentEducationTaxonomyId
        {
            get
            {
                return (List<Guid>)this["educationTaxonomyId"];
            }

            set
            {
                this["educationTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("benefitTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "BenefitTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentBenefitTaxonomyId
        {
            get
            {
                return (List<Guid>)this["benefitTaxonomyId"];
            }

            set
            {
                this["benefitTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("genderTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "GenderTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentGenderTaxonomyId
        {
            get
            {
                return (List<Guid>)this["genderTaxonomyId"];
            }

            set
            {
                this["genderTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("motivatorTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "MotivatorTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentMotivatorTaxonomyId
        {
            get
            {
                return (List<Guid>)this["motivatorTaxonomyId"];
            }

            set
            {
                this["motivatorTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("careerMoveTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "CareerMoveTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentCareerMoveTaxonomyId
        {
            get
            {
                return (List<Guid>)this["careerMoveTaxonomyId"];
            }

            set
            {
                this["careerMoveTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("annualSalariesTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "AnnualSalariesTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentAnnualSalariesTaxonomyId
        {
            get
            {
                return (List<Guid>)this["annualSalariesTaxonomyId"];
            }

            set
            {
                this["annualSalariesTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("hourlyRatesTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "HourlyRatesTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentHourlyRatesTaxonomyId
        {
            get
            {
                return (List<Guid>)this["hourlyRatesTaxonomyId"];
            }

            set
            {
                this["hourlyRatesTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("bonusAmountsTaxonomyId")]
        [DescriptionResource(typeof(ConfigDescriptions), "BonusAmountsTaxonomyId")]
        [DataMember]
        public virtual List<Guid> CurrentBonusAmountsTaxonomyId
        {
            get
            {
                return (List<Guid>)this["bonusAmountsTaxonomyId"];
            }

            set
            {
                this["bonusAmountsTaxonomyId"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertCount")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertCount")]
        [DataMember]
        public virtual int CurrentSalaryAlertCount
        {
            get
            {
                return (int)this["salaryAlertCount"];
            }

            set
            {
                this["salaryAlertCount"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertEmailTemplateId")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertEmailTemplateId")]
        [DataMember]
        public virtual Guid CurrentSalaryAlertEmailTemplateId
        {
            get
            {
                return (Guid)this["salaryAlertEmailTemplateId"];
            }

            set
            {
                this["salaryAlertEmailTemplateId"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertSalaryItemTemplate")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertSalaryItemTemplate")]
        [DataMember]
        public virtual string CurrentSalaryAlertSalaryItemTemplate
        {
            get
            {
                return (string)this["salaryAlertSalaryItemTemplate"];
            }

            set
            {
                this["salaryAlertSalaryItemTemplate"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertTaskServerIp")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertTaskServerIp")]
        [DataMember]
        public virtual string CurrentSalaryAlertTaskServerIp
        {
            get
            {
                return (string)this["salaryAlertTaskServerIp"];
            }

            set
            {
                this["salaryAlertTaskServerIp"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertEmailFromName")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertEmailFromName")]
        [DataMember]
        public virtual string CurrentSalaryAlertEmailFromName
        {
            get
            {
                return (string)this["salaryAlertEmailFromName"];
            }

            set
            {
                this["salaryAlertEmailFromName"] = value;
            }
        }

        [ConfigurationProperty("salaryAlertEmailFromAddress")]
        [DescriptionResource(typeof(ConfigDescriptions), "SalaryAlertEmailFromAddress")]
        [DataMember]
        public virtual string CurrentSalaryAlertEmailFromAddress
        {
            get
            {
                return (string)this["salaryAlertEmailFromAddress"];
            }

            set
            {
                this["salaryAlertEmailFromAddress"] = value;
            }
        }
    }
}
