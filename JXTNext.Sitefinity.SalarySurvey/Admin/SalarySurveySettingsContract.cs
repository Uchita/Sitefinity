using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.SiteSettings;

namespace JXTNext.Sitefinity.SalarySurvey.Admin
{
    /// <summary>
    /// See https://www.progress.com/documentation/sitefinity-cms/custom-basic-settings-create-the-settings-contract
    /// </summary>
    [DataContract]
    public class SalarySurveySettingsContract : ISettingsDataContract
    {
        [DataMember]
        public string CurrencySymbol { get; set; }

        [DataMember]
        public Decimal SuperannuationRate { get; set; }

        [DataMember]
        public Decimal MedicareRate { get; set; }

        [DataMember]
        public int WeeklyHours { get; set; }

        [DataMember]
        public string TaxBrackets { get; set; }

        [DataMember]
        public List<Guid> CountryTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> IndustryTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> JobTypeTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> AnnualSalaryJobTypeTaxonomyIds { get; set; }

        [DataMember]
        public List<Guid> YearsOfExperienceTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> SectorTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> EmployerSizeTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> PeopleManagedTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> GenderTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> EducationTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> BenefitTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> MotivatorTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> CareerMoveTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> AnnualSalariesTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> HourlyRatesTaxonomyId { get; set; }

        [DataMember]
        public List<Guid> BonusAmountsTaxonomyId { get; set; }

        [DataMember]
        public int SalaryAlertCount { get; set; }

        [DataMember]
        public Guid SalaryAlertEmailTemplateId { get; set; }

        [DataMember]
        public string SalaryAlertSalaryItemTemplate { get; set; }

        [DataMember]
        public string SalaryAlertTaskServerIp { get; set; }

        [DataMember]
        public string SalaryAlertEmailFromName { get; set; }

        [DataMember]
        public string SalaryAlertEmailFromAddress { get; set; }

        public void LoadDefaults(bool forEdit = false)
        {
            SalarySurveyConfig section;

            if (forEdit)
            {
                section = ConfigManager.GetManager().GetSection<SalarySurveyConfig>();
            }
            else
            {
                section = Config.Get<SalarySurveyConfig>();
            }

            this.CurrencySymbol = section.UISalarySurveySettings.CurrentCurrencySymbol;
            this.SuperannuationRate = section.UISalarySurveySettings.CurrentSuperannuationRate;
            this.CountryTaxonomyId = section.UISalarySurveySettings.CurrentCountryTaxonomyId;
            this.IndustryTaxonomyId = section.UISalarySurveySettings.CurrentIndustryTaxonomyId;
            this.JobTypeTaxonomyId = section.UISalarySurveySettings.CurrentJobTypeTaxonomyId;
            this.AnnualSalaryJobTypeTaxonomyIds = section.UISalarySurveySettings.CurrentAnnualSalaryJobTypeTaxonomyIds;
            this.YearsOfExperienceTaxonomyId = section.UISalarySurveySettings.CurrentYearsOfExperienceTaxonomyId;
            this.SectorTaxonomyId = section.UISalarySurveySettings.CurrentSectorTaxonomyId;
            this.EmployerSizeTaxonomyId = section.UISalarySurveySettings.CurrentEmployerSizeTaxonomyId;
            this.PeopleManagedTaxonomyId = section.UISalarySurveySettings.CurrentPeopleManagedTaxonomyId;
            this.EducationTaxonomyId = section.UISalarySurveySettings.CurrentEducationTaxonomyId;
            this.BenefitTaxonomyId = section.UISalarySurveySettings.CurrentBenefitTaxonomyId;
            this.GenderTaxonomyId = section.UISalarySurveySettings.CurrentGenderTaxonomyId;
            this.MotivatorTaxonomyId = section.UISalarySurveySettings.CurrentMotivatorTaxonomyId;
            this.CareerMoveTaxonomyId = section.UISalarySurveySettings.CurrentCareerMoveTaxonomyId;
            this.AnnualSalariesTaxonomyId = section.UISalarySurveySettings.CurrentAnnualSalariesTaxonomyId;
            this.HourlyRatesTaxonomyId = section.UISalarySurveySettings.CurrentHourlyRatesTaxonomyId;
            this.BonusAmountsTaxonomyId = section.UISalarySurveySettings.CurrentBonusAmountsTaxonomyId;
            this.MedicareRate = section.UISalarySurveySettings.CurrentMedicareRate;
            this.WeeklyHours = section.UISalarySurveySettings.CurrentWeeklyHours;
            this.TaxBrackets = section.UISalarySurveySettings.CurrentTaxBrackets;
            this.SalaryAlertCount = section.UISalarySurveySettings.CurrentSalaryAlertCount;
            this.SalaryAlertEmailTemplateId = section.UISalarySurveySettings.CurrentSalaryAlertEmailTemplateId;
            this.SalaryAlertSalaryItemTemplate = section.UISalarySurveySettings.CurrentSalaryAlertSalaryItemTemplate;
            this.SalaryAlertTaskServerIp = section.UISalarySurveySettings.CurrentSalaryAlertTaskServerIp;
            this.SalaryAlertEmailFromName = section.UISalarySurveySettings.CurrentSalaryAlertEmailFromName;
            this.SalaryAlertEmailFromAddress = section.UISalarySurveySettings.CurrentSalaryAlertEmailFromAddress;
        }

        public void SaveDefaults()
        {
            var manager = ConfigManager.GetManager();
            var section = manager.GetSection<SalarySurveyConfig>();

            section.UISalarySurveySettings.CurrentCurrencySymbol = this.CurrencySymbol;
            section.UISalarySurveySettings.CurrentSuperannuationRate = this.SuperannuationRate;
            section.UISalarySurveySettings.CurrentIndustryTaxonomyId = this.IndustryTaxonomyId;
            section.UISalarySurveySettings.CurrentJobTypeTaxonomyId = this.JobTypeTaxonomyId;
            section.UISalarySurveySettings.CurrentAnnualSalaryJobTypeTaxonomyIds = this.AnnualSalaryJobTypeTaxonomyIds;
            section.UISalarySurveySettings.CurrentYearsOfExperienceTaxonomyId = this.YearsOfExperienceTaxonomyId;
            section.UISalarySurveySettings.CurrentSectorTaxonomyId = this.SectorTaxonomyId;
            section.UISalarySurveySettings.CurrentEmployerSizeTaxonomyId = this.EmployerSizeTaxonomyId;
            section.UISalarySurveySettings.CurrentPeopleManagedTaxonomyId = this.PeopleManagedTaxonomyId;
            section.UISalarySurveySettings.CurrentEducationTaxonomyId = this.EducationTaxonomyId;
            section.UISalarySurveySettings.CurrentBenefitTaxonomyId = this.BenefitTaxonomyId;
            section.UISalarySurveySettings.CurrentGenderTaxonomyId = this.GenderTaxonomyId;
            section.UISalarySurveySettings.CurrentMotivatorTaxonomyId = this.MotivatorTaxonomyId;
            section.UISalarySurveySettings.CurrentCareerMoveTaxonomyId = this.CareerMoveTaxonomyId;
            section.UISalarySurveySettings.CurrentAnnualSalariesTaxonomyId = this.AnnualSalariesTaxonomyId;
            section.UISalarySurveySettings.CurrentHourlyRatesTaxonomyId = this.HourlyRatesTaxonomyId;
            section.UISalarySurveySettings.CurrentBonusAmountsTaxonomyId = this.BonusAmountsTaxonomyId;
            section.UISalarySurveySettings.CurrentMedicareRate = this.MedicareRate;
            section.UISalarySurveySettings.CurrentWeeklyHours = this.WeeklyHours;
            section.UISalarySurveySettings.CurrentTaxBrackets = this.TaxBrackets;
            section.UISalarySurveySettings.CurrentSalaryAlertCount = this.SalaryAlertCount;
            section.UISalarySurveySettings.CurrentSalaryAlertEmailTemplateId = this.SalaryAlertEmailTemplateId;
            section.UISalarySurveySettings.CurrentSalaryAlertSalaryItemTemplate = this.SalaryAlertSalaryItemTemplate;
            section.UISalarySurveySettings.CurrentSalaryAlertTaskServerIp = this.SalaryAlertTaskServerIp;
            section.UISalarySurveySettings.CurrentSalaryAlertEmailFromName = this.SalaryAlertEmailFromName;
            section.UISalarySurveySettings.CurrentSalaryAlertEmailFromAddress = this.SalaryAlertEmailFromAddress;

            manager.SaveSection(section);
        }
    }
}
