
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using JXTPortal.Entities;

#endregion

namespace JXTPortal.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current GlobalLocationProviderBase instance.
		///</summary>
		public virtual GlobalLocationProviderBase GlobalLocationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteWebPartTypesProviderBase instance.
		///</summary>
		public virtual SiteWebPartTypesProviderBase SiteWebPartTypesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GlobalAreaProviderBase instance.
		///</summary>
		public virtual GlobalAreaProviderBase GlobalAreaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobCustomQuestionnaireProviderBase instance.
		///</summary>
		public virtual JobCustomQuestionnaireProviderBase JobCustomQuestionnaireProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmailFormatsProviderBase instance.
		///</summary>
		public virtual EmailFormatsProviderBase EmailFormatsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FileTypesProviderBase instance.
		///</summary>
		public virtual FileTypesProviderBase FileTypesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdminRolesProviderBase instance.
		///</summary>
		public virtual AdminRolesProviderBase AdminRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ExceptionTableProviderBase instance.
		///</summary>
		public virtual ExceptionTableProviderBase ExceptionTableProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LanguagesProviderBase instance.
		///</summary>
		public virtual LanguagesProviderBase LanguagesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalaryTypeProviderBase instance.
		///</summary>
		public virtual SalaryTypeProviderBase SalaryTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LocationProviderBase instance.
		///</summary>
		public virtual LocationProviderBase LocationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalaryProviderBase instance.
		///</summary>
		public virtual SalaryProviderBase SalaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteSummaryProviderBase instance.
		///</summary>
		public virtual SiteSummaryProviderBase SiteSummaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberFileTypesProviderBase instance.
		///</summary>
		public virtual MemberFileTypesProviderBase MemberFileTypesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NewsTypeProviderBase instance.
		///</summary>
		public virtual NewsTypeProviderBase NewsTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicPageRevisionsProviderBase instance.
		///</summary>
		public virtual DynamicPageRevisionsProviderBase DynamicPageRevisionsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NewsIndustryProviderBase instance.
		///</summary>
		public virtual NewsIndustryProviderBase NewsIndustryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserBusinessTypeProviderBase instance.
		///</summary>
		public virtual AdvertiserBusinessTypeProviderBase AdvertiserBusinessTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SitesProviderBase instance.
		///</summary>
		public virtual SitesProviderBase SitesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdminUsersProviderBase instance.
		///</summary>
		public virtual AdminUsersProviderBase AdminUsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserJobPricingProviderBase instance.
		///</summary>
		public virtual AdvertiserJobPricingProviderBase AdvertiserJobPricingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NewsCategoriesProviderBase instance.
		///</summary>
		public virtual NewsCategoriesProviderBase NewsCategoriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DefaultResourcesProviderBase instance.
		///</summary>
		public virtual DefaultResourcesProviderBase DefaultResourcesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountriesProviderBase instance.
		///</summary>
		public virtual CountriesProviderBase CountriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserAccountTypeProviderBase instance.
		///</summary>
		public virtual AdvertiserAccountTypeProviderBase AdvertiserAccountTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RolesProviderBase instance.
		///</summary>
		public virtual RolesProviderBase RolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RelatedDynamicPagesProviderBase instance.
		///</summary>
		public virtual RelatedDynamicPagesProviderBase RelatedDynamicPagesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProfessionProviderBase instance.
		///</summary>
		public virtual ProfessionProviderBase ProfessionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NewsProviderBase instance.
		///</summary>
		public virtual NewsProviderBase NewsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MembersProviderBase instance.
		///</summary>
		public virtual MembersProviderBase MembersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberWizardProviderBase instance.
		///</summary>
		public virtual MemberWizardProviderBase MemberWizardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberLanguagesProviderBase instance.
		///</summary>
		public virtual MemberLanguagesProviderBase MemberLanguagesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberLicensesProviderBase instance.
		///</summary>
		public virtual MemberLicensesProviderBase MemberLicensesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberMembershipsProviderBase instance.
		///</summary>
		public virtual MemberMembershipsProviderBase MemberMembershipsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberPositionsProviderBase instance.
		///</summary>
		public virtual MemberPositionsProviderBase MemberPositionsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberStatusProviderBase instance.
		///</summary>
		public virtual MemberStatusProviderBase MemberStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberQualificationProviderBase instance.
		///</summary>
		public virtual MemberQualificationProviderBase MemberQualificationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserAccountStatusProviderBase instance.
		///</summary>
		public virtual AdvertiserAccountStatusProviderBase AdvertiserAccountStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberReferencesProviderBase instance.
		///</summary>
		public virtual MemberReferencesProviderBase MemberReferencesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteAdvertiserFilterProviderBase instance.
		///</summary>
		public virtual SiteAdvertiserFilterProviderBase SiteAdvertiserFilterProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteSalaryTypeProviderBase instance.
		///</summary>
		public virtual SiteSalaryTypeProviderBase SiteSalaryTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteAreaProviderBase instance.
		///</summary>
		public virtual SiteAreaProviderBase SiteAreaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteWebPartsProviderBase instance.
		///</summary>
		public virtual SiteWebPartsProviderBase SiteWebPartsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EducationsProviderBase instance.
		///</summary>
		public virtual EducationsProviderBase EducationsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WorkTypeProviderBase instance.
		///</summary>
		public virtual WorkTypeProviderBase WorkTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WidgetContainersProviderBase instance.
		///</summary>
		public virtual WidgetContainersProviderBase WidgetContainersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteWorkTypeProviderBase instance.
		///</summary>
		public virtual SiteWorkTypeProviderBase SiteWorkTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteRolesProviderBase instance.
		///</summary>
		public virtual SiteRolesProviderBase SiteRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WebServiceLogProviderBase instance.
		///</summary>
		public virtual WebServiceLogProviderBase WebServiceLogProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteResourcesXmlProviderBase instance.
		///</summary>
		public virtual SiteResourcesXmlProviderBase SiteResourcesXmlProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteCurrenciesProviderBase instance.
		///</summary>
		public virtual SiteCurrenciesProviderBase SiteCurrenciesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteResourcesProviderBase instance.
		///</summary>
		public virtual SiteResourcesProviderBase SiteResourcesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteCustomMappingProviderBase instance.
		///</summary>
		public virtual SiteCustomMappingProviderBase SiteCustomMappingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteCountriesProviderBase instance.
		///</summary>
		public virtual SiteCountriesProviderBase SiteCountriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteLanguagesProviderBase instance.
		///</summary>
		public virtual SiteLanguagesProviderBase SiteLanguagesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteProfessionProviderBase instance.
		///</summary>
		public virtual SiteProfessionProviderBase SiteProfessionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteLocationProviderBase instance.
		///</summary>
		public virtual SiteLocationProviderBase SiteLocationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserJobTemplateLogoProviderBase instance.
		///</summary>
		public virtual AdvertiserJobTemplateLogoProviderBase AdvertiserJobTemplateLogoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SiteMappingsProviderBase instance.
		///</summary>
		public virtual SiteMappingsProviderBase SiteMappingsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberFilesProviderBase instance.
		///</summary>
		public virtual MemberFilesProviderBase MemberFilesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FilesProviderBase instance.
		///</summary>
		public virtual FilesProviderBase FilesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MemberCertificateMembershipsProviderBase instance.
		///</summary>
		public virtual MemberCertificateMembershipsProviderBase MemberCertificateMembershipsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomPaymentProviderBase instance.
		///</summary>
		public virtual CustomPaymentProviderBase CustomPaymentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurrenciesProviderBase instance.
		///</summary>
		public virtual CurrenciesProviderBase CurrenciesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EnquiriesProviderBase instance.
		///</summary>
		public virtual EnquiriesProviderBase EnquiriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomWidgetCssSelectorProviderBase instance.
		///</summary>
		public virtual CustomWidgetCssSelectorProviderBase CustomWidgetCssSelectorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FoldersProviderBase instance.
		///</summary>
		public virtual FoldersProviderBase FoldersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GlobalSettingsProviderBase instance.
		///</summary>
		public virtual GlobalSettingsProviderBase GlobalSettingsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ConsultantsProviderBase instance.
		///</summary>
		public virtual ConsultantsProviderBase ConsultantsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmailTemplatesProviderBase instance.
		///</summary>
		public virtual EmailTemplatesProviderBase EmailTemplatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceOrderProviderBase instance.
		///</summary>
		public virtual InvoiceOrderProviderBase InvoiceOrderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertiserUsersProviderBase instance.
		///</summary>
		public virtual AdvertiserUsersProviderBase AdvertiserUsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomWidgetProviderBase instance.
		///</summary>
		public virtual CustomWidgetProviderBase CustomWidgetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicPageWebPartTemplatesProviderBase instance.
		///</summary>
		public virtual DynamicPageWebPartTemplatesProviderBase DynamicPageWebPartTemplatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicContentProviderBase instance.
		///</summary>
		public virtual DynamicContentProviderBase DynamicContentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdvertisersProviderBase instance.
		///</summary>
		public virtual AdvertisersProviderBase AdvertisersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicPageFilesProviderBase instance.
		///</summary>
		public virtual DynamicPageFilesProviderBase DynamicPageFilesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicPageWebPartTemplatesLinkProviderBase instance.
		///</summary>
		public virtual DynamicPageWebPartTemplatesLinkProviderBase DynamicPageWebPartTemplatesLinkProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicPagesProviderBase instance.
		///</summary>
		public virtual DynamicPagesProviderBase DynamicPagesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DynamicpagesCustomWidgetProviderBase instance.
		///</summary>
		public virtual DynamicpagesCustomWidgetProviderBase DynamicpagesCustomWidgetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IndustryProviderBase instance.
		///</summary>
		public virtual IndustryProviderBase IndustryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IntegrationMappingsProviderBase instance.
		///</summary>
		public virtual IntegrationMappingsProviderBase IntegrationMappingsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobTemplatesProviderBase instance.
		///</summary>
		public virtual JobTemplatesProviderBase JobTemplatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IntegrationsProviderBase instance.
		///</summary>
		public virtual IntegrationsProviderBase IntegrationsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobsProviderBase instance.
		///</summary>
		public virtual JobsProviderBase JobsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AreaProviderBase instance.
		///</summary>
		public virtual AreaProviderBase AreaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobsArchiveProviderBase instance.
		///</summary>
		public virtual JobsArchiveProviderBase JobsArchiveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobViewsProviderBase instance.
		///</summary>
		public virtual JobViewsProviderBase JobViewsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobsSavedProviderBase instance.
		///</summary>
		public virtual JobsSavedProviderBase JobsSavedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobCustomXmlProviderBase instance.
		///</summary>
		public virtual JobCustomXmlProviderBase JobCustomXmlProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobRolesProviderBase instance.
		///</summary>
		public virtual JobRolesProviderBase JobRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AvailableStatusProviderBase instance.
		///</summary>
		public virtual AvailableStatusProviderBase AvailableStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceProviderBase instance.
		///</summary>
		public virtual InvoiceProviderBase InvoiceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobAlertsProviderBase instance.
		///</summary>
		public virtual JobAlertsProviderBase JobAlertsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoiceItemProviderBase instance.
		///</summary>
		public virtual InvoiceItemProviderBase InvoiceItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobApplicationProviderBase instance.
		///</summary>
		public virtual JobApplicationProviderBase JobApplicationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobAreaProviderBase instance.
		///</summary>
		public virtual JobAreaProviderBase JobAreaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobApplicationNotesProviderBase instance.
		///</summary>
		public virtual JobApplicationNotesProviderBase JobApplicationNotesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobItemsTypeProviderBase instance.
		///</summary>
		public virtual JobItemsTypeProviderBase JobItemsTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobApplicationTypeProviderBase instance.
		///</summary>
		public virtual JobApplicationTypeProviderBase JobApplicationTypeProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current ViewJobsProviderBase instance.
		///</summary>
		public virtual ViewJobsProviderBase ViewJobsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ViewJobsArchiveProviderBase instance.
		///</summary>
		public virtual ViewJobsArchiveProviderBase ViewJobsArchiveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ViewJobSearchProviderBase instance.
		///</summary>
		public virtual ViewJobSearchProviderBase ViewJobSearchProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ViewSalaryProviderBase instance.
		///</summary>
		public virtual ViewSalaryProviderBase ViewSalaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ViewSiteAdvertisersProviderBase instance.
		///</summary>
		public virtual ViewSiteAdvertisersProviderBase ViewSiteAdvertisersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ViewSiteAreaLocationCountryProviderBase instance.
		///</summary>
		public virtual ViewSiteAreaLocationCountryProviderBase ViewSiteAreaLocationCountryProvider{get {throw new NotImplementedException();}}
		
	}
}
