using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;

namespace JXTNext.Sitefinity.SalarySurvey.Admin
{
    /// <summary>
    /// See https://www.progress.com/documentation/sitefinity-cms/custom-basic-settings-create-the-code-behind
    /// </summary>
    public class SalarySurveySettings : SimpleView
    {
        #region Properties

        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //we use div wrapper tag to make easier common styling
                return HtmlTextWriterTag.Div;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                {
                    return SalarySurveySettings.layoutTemplatePath;
                }

                return base.LayoutTemplatePath;
            }

            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        #endregion

        #region Control References

        protected virtual TextField CurrencySymbol
        {
            get
            {
                return this.Container.GetControl<TextField>("currencySymbol", false);
            }
        }

        protected virtual TextField SuperannuationRate
        {
            get
            {
                return this.Container.GetControl<TextField>("superannuationRate", false);
            }
        }

        protected virtual TextField MedicareRate
        {
            get
            {
                return this.Container.GetControl<TextField>("medicareRate", false);
            }
        }

        protected virtual TextField WeeklyHours
        {
            get
            {
                return this.Container.GetControl<TextField>("weeklyHours", false);
            }
        }

        protected virtual MultilineTextField TaxBrackets
        {
            get
            {
                return this.Container.GetControl<MultilineTextField>("taxBrackets", false);
            }
        }

        protected virtual HierarchicalTaxonField LocationTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("locationTaxonomyId", false);
            }
        }        

        protected virtual HierarchicalTaxonField JobTypeTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("jobTypeTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField AnnualSalaryJobTypeTaxonomyIds
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("annualSalaryJobTypeTaxonomyIds", false);
            }
        }

        protected virtual HierarchicalTaxonField YearsOfExperienceTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("yearsOfExperienceTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField SectorTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("sectorTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField EmployerSizeTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("employerSizeTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField PeopleManagedTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("peopleManagedTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField EducationTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("educationTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField BenefitTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("benefitTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField AnnualSalariesTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("annualSalariesTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField HourlyRatesTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("hourlyRatesTaxonomyId", false);
            }
        }

        protected virtual HierarchicalTaxonField BonusAmountsTaxonomyId
        {
            get
            {
                return this.Container.GetControl<HierarchicalTaxonField>("bonusAmountsTaxonomyId", false);
            }
        }

        protected virtual TextField SalaryAlertCount
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertCount", false);
            }
        }

        protected virtual TextField SalaryAlertEmailTemplateId
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertEmailTemplateId", false);
            }
        }

        protected virtual TextField SalaryAlertSalaryItemTemplate
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertSalaryItemTemplate", false);
            }
        }

        protected virtual TextField SalaryAlertTaskServerIp
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertTaskServerIp", false);
            }
        }

        protected virtual TextField SalaryAlertEmailFromName
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertEmailFromName", false);
            }
        }

        protected virtual TextField SalaryAlertEmailFromAddress
        {
            get
            {
                return this.Container.GetControl<TextField>("salaryAlertEmailFromAddress", false);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container)
        {

        }

        #endregion

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/Views/SalarySurveySettings/SalarySurveySettings.ascx";

        #endregion
    }
}
