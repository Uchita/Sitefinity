ALTER TABLE GlobalSettings ADD MemberRegisterPageID INT NULL 
GO

ALTER TABLE GlobalSettings ADD FOREIGN KEY (MemberRegisterPageID ) REFERENCES DynamicPages(DynamicPageID)
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Update]
(

	@GlobalSettingId int   ,

	@SiteId int   ,

	@DefaultLanguageId int   ,

	@DefaultDynamicPageId int   ,

	@PublicJobsSearch bit   ,

	@PublicMembersSearch bit   ,

	@PublicCompaniesSearch bit   ,

	@PublicSponsoredAdverts bit   ,

	@PrivateJobs bit   ,

	@PrivateMembers bit   ,

	@PrivateCompanies bit   ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@PageTitlePrefix nvarchar (510)  ,

	@PageTitleSuffix nvarchar (510)  ,

	@DefaultTitle nvarchar (510)  ,

	@HomeTitle nvarchar (510)  ,

	@DefaultDescription nvarchar (510)  ,

	@HomeDescription nvarchar (510)  ,

	@DefaultKeywords nvarchar (510)  ,

	@HomeKeywords nvarchar (510)  ,

	@ShowFaceBookButton bit   ,

	@UseAdvertiserFilter int   ,

	@MerchantId int   ,

	@ShowTwitterButton bit   ,

	@ShowJobAlertButton bit   ,

	@ShowLinkedInButton bit   ,

	@SiteFavIconId int   ,

	@SiteDocType varchar (512)  ,

	@CurrencySymbol varchar (10)  ,

	@FtpFolderLocation varchar (255)  ,

	@MetaTags nvarchar (MAX)  ,

	@SystemMetaTags nvarchar (4000)  ,

	@MemberRegistrationNotification varchar (255)  ,

	@LinkedInApi varchar (255)  ,

	@LinkedInLogo varchar (255)  ,

	@LinkedInCompanyId int   ,

	@LinkedInEmail varchar (255)  ,

	@PrivacySettings nvarchar (4000)  ,

	@WwwRedirect bit   ,

	@AllowAdvertiser bit   ,

	@LinkedInApiSecret varchar (255)  ,

	@GoogleClientId varchar (255)  ,

	@GoogleClientSecret varchar (255)  ,

	@FacebookAppId varchar (255)  ,

	@FacebookAppSecret varchar (255)  ,

	@LinkedInButtonSize int   ,

	@DefaultCountryId int   ,

	@PayPalUsername varchar (100)  ,

	@PayPalPassword varchar (100)  ,

	@PayPalSignature varchar (100)  ,

	@SecurePayMerchantId varchar (100)  ,

	@SecurePayPassword varchar (100)  ,

	@UsingSsl bit   ,

	@UseCustomProfessionRole bit   ,

	@GenerateJobXml bit   ,

	@IsPrivateSite bit   ,

	@PrivateRedirectUrl varchar (255)  ,

	@EnableJobCustomQuestionnaire bit   ,

	@JobApplicationTypeId int   ,

	@JobScreeningProcess bit   ,

	@AdvertiserApprovalProcess int   ,

	@SiteType int   ,

	@EnableSsl bit   ,

	@Gst decimal (5, 2)  ,

	@GstLabel nvarchar (510)  ,

	@NumberOfPremiumJobs int   ,

	@PremiumJobDays int   ,

	@DisplayPremiumJobsOnResults bit   ,

	@JobExpiryNotification bit   ,

	@CurrencyId int   ,

	@PayPalClientId varchar (255)  ,

	@PayPalClientSecret varchar (255)  ,

	@PaypalUser varchar (255)  ,

	@PaypalProPassword varchar (255)  ,

	@PaypalVendor varchar (255)  ,

	@PaypalPartner varchar (255)  ,

	@InvoiceSiteInfo nvarchar (1000)  ,

	@InvoiceSiteFooter nvarchar (1500)  ,

	@EnableTermsAndConditions bit   ,

	@DefaultEmailLanguageId int   ,

	@GoogleTagManager varchar (100)  ,

	@GoogleAnalytics varchar (100)  ,

	@GoogleWebMaster varchar (100)  ,

	@EnablePeopleSearch bit   ,

	@GlobalDateFormat varchar (20)  ,

	@TimeZone varchar (255)  ,

	@GlobalFolder varchar (255)  ,

	@EnableScreeningQuestions bit   ,

	@EnableExpiryDate bit   ,

	@MemberRegisterPageId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[GlobalSettings]
				SET
					[SiteID] = @SiteId
					,[DefaultLanguageID] = @DefaultLanguageId
					,[DefaultDynamicPageID] = @DefaultDynamicPageId
					,[PublicJobsSearch] = @PublicJobsSearch
					,[PublicMembersSearch] = @PublicMembersSearch
					,[PublicCompaniesSearch] = @PublicCompaniesSearch
					,[PublicSponsoredAdverts] = @PublicSponsoredAdverts
					,[PrivateJobs] = @PrivateJobs
					,[PrivateMembers] = @PrivateMembers
					,[PrivateCompanies] = @PrivateCompanies
					,[LastModifiedBy] = @LastModifiedBy
					,[LastModified] = @LastModified
					,[PageTitlePrefix] = @PageTitlePrefix
					,[PageTitleSuffix] = @PageTitleSuffix
					,[DefaultTitle] = @DefaultTitle
					,[HomeTitle] = @HomeTitle
					,[DefaultDescription] = @DefaultDescription
					,[HomeDescription] = @HomeDescription
					,[DefaultKeywords] = @DefaultKeywords
					,[HomeKeywords] = @HomeKeywords
					,[ShowFaceBookButton] = @ShowFaceBookButton
					,[UseAdvertiserFilter] = @UseAdvertiserFilter
					,[MerchantID] = @MerchantId
					,[ShowTwitterButton] = @ShowTwitterButton
					,[ShowJobAlertButton] = @ShowJobAlertButton
					,[ShowLinkedInButton] = @ShowLinkedInButton
					,[SiteFavIconID] = @SiteFavIconId
					,[SiteDocType] = @SiteDocType
					,[CurrencySymbol] = @CurrencySymbol
					,[FtpFolderLocation] = @FtpFolderLocation
					,[MetaTags] = @MetaTags
					,[SystemMetaTags] = @SystemMetaTags
					,[MemberRegistrationNotification] = @MemberRegistrationNotification
					,[LinkedInAPI] = @LinkedInApi
					,[LinkedInLogo] = @LinkedInLogo
					,[LinkedInCompanyID] = @LinkedInCompanyId
					,[LinkedInEmail] = @LinkedInEmail
					,[PrivacySettings] = @PrivacySettings
					,[WWWRedirect] = @WwwRedirect
					,[AllowAdvertiser] = @AllowAdvertiser
					,[LinkedInAPISecret] = @LinkedInApiSecret
					,[GoogleClientID] = @GoogleClientId
					,[GoogleClientSecret] = @GoogleClientSecret
					,[FacebookAppID] = @FacebookAppId
					,[FacebookAppSecret] = @FacebookAppSecret
					,[LinkedInButtonSize] = @LinkedInButtonSize
					,[DefaultCountryID] = @DefaultCountryId
					,[PayPalUsername] = @PayPalUsername
					,[PayPalPassword] = @PayPalPassword
					,[PayPalSignature] = @PayPalSignature
					,[SecurePayMerchantID] = @SecurePayMerchantId
					,[SecurePayPassword] = @SecurePayPassword
					,[UsingSSL] = @UsingSsl
					,[UseCustomProfessionRole] = @UseCustomProfessionRole
					,[GenerateJobXML] = @GenerateJobXml
					,[IsPrivateSite] = @IsPrivateSite
					,[PrivateRedirectUrl] = @PrivateRedirectUrl
					,[EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire
					,[JobApplicationTypeID] = @JobApplicationTypeId
					,[JobScreeningProcess] = @JobScreeningProcess
					,[AdvertiserApprovalProcess] = @AdvertiserApprovalProcess
					,[SiteType] = @SiteType
					,[EnableSSL] = @EnableSsl
					,[GST] = @Gst
					,[GSTLabel] = @GstLabel
					,[NumberOfPremiumJobs] = @NumberOfPremiumJobs
					,[PremiumJobDays] = @PremiumJobDays
					,[DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults
					,[JobExpiryNotification] = @JobExpiryNotification
					,[CurrencyID] = @CurrencyId
					,[PayPalClientID] = @PayPalClientId
					,[PayPalClientSecret] = @PayPalClientSecret
					,[PaypalUser] = @PaypalUser
					,[PaypalProPassword] = @PaypalProPassword
					,[PaypalVendor] = @PaypalVendor
					,[PaypalPartner] = @PaypalPartner
					,[InvoiceSiteInfo] = @InvoiceSiteInfo
					,[InvoiceSiteFooter] = @InvoiceSiteFooter
					,[EnableTermsAndConditions] = @EnableTermsAndConditions
					,[DefaultEmailLanguageId] = @DefaultEmailLanguageId
					,[GoogleTagManager] = @GoogleTagManager
					,[GoogleAnalytics] = @GoogleAnalytics
					,[GoogleWebMaster] = @GoogleWebMaster
					,[EnablePeopleSearch] = @EnablePeopleSearch
					,[GlobalDateFormat] = @GlobalDateFormat
					,[TimeZone] = @TimeZone
					,[GlobalFolder] = @GlobalFolder
					,[EnableScreeningQuestions] = @EnableScreeningQuestions
					,[EnableExpiryDate] = @EnableExpiryDate
					,[MemberRegisterPageID] = @MemberRegisterPageId
				WHERE
[GlobalSettingID] = @GlobalSettingId
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Insert]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Insert]
(

	@GlobalSettingId int    OUTPUT,

	@SiteId int   ,

	@DefaultLanguageId int   ,

	@DefaultDynamicPageId int   ,

	@PublicJobsSearch bit   ,

	@PublicMembersSearch bit   ,

	@PublicCompaniesSearch bit   ,

	@PublicSponsoredAdverts bit   ,

	@PrivateJobs bit   ,

	@PrivateMembers bit   ,

	@PrivateCompanies bit   ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@PageTitlePrefix nvarchar (510)  ,

	@PageTitleSuffix nvarchar (510)  ,

	@DefaultTitle nvarchar (510)  ,

	@HomeTitle nvarchar (510)  ,

	@DefaultDescription nvarchar (510)  ,

	@HomeDescription nvarchar (510)  ,

	@DefaultKeywords nvarchar (510)  ,

	@HomeKeywords nvarchar (510)  ,

	@ShowFaceBookButton bit   ,

	@UseAdvertiserFilter int   ,

	@MerchantId int   ,

	@ShowTwitterButton bit   ,

	@ShowJobAlertButton bit   ,

	@ShowLinkedInButton bit   ,

	@SiteFavIconId int   ,

	@SiteDocType varchar (512)  ,

	@CurrencySymbol varchar (10)  ,

	@FtpFolderLocation varchar (255)  ,

	@MetaTags nvarchar (MAX)  ,

	@SystemMetaTags nvarchar (4000)  ,

	@MemberRegistrationNotification varchar (255)  ,

	@LinkedInApi varchar (255)  ,

	@LinkedInLogo varchar (255)  ,

	@LinkedInCompanyId int   ,

	@LinkedInEmail varchar (255)  ,

	@PrivacySettings nvarchar (4000)  ,

	@WwwRedirect bit   ,

	@AllowAdvertiser bit   ,

	@LinkedInApiSecret varchar (255)  ,

	@GoogleClientId varchar (255)  ,

	@GoogleClientSecret varchar (255)  ,

	@FacebookAppId varchar (255)  ,

	@FacebookAppSecret varchar (255)  ,

	@LinkedInButtonSize int   ,

	@DefaultCountryId int   ,

	@PayPalUsername varchar (100)  ,

	@PayPalPassword varchar (100)  ,

	@PayPalSignature varchar (100)  ,

	@SecurePayMerchantId varchar (100)  ,

	@SecurePayPassword varchar (100)  ,

	@UsingSsl bit   ,

	@UseCustomProfessionRole bit   ,

	@GenerateJobXml bit   ,

	@IsPrivateSite bit   ,

	@PrivateRedirectUrl varchar (255)  ,

	@EnableJobCustomQuestionnaire bit   ,

	@JobApplicationTypeId int   ,

	@JobScreeningProcess bit   ,

	@AdvertiserApprovalProcess int   ,

	@SiteType int   ,

	@EnableSsl bit   ,

	@Gst decimal (5, 2)  ,

	@GstLabel nvarchar (510)  ,

	@NumberOfPremiumJobs int   ,

	@PremiumJobDays int   ,

	@DisplayPremiumJobsOnResults bit   ,

	@JobExpiryNotification bit   ,

	@CurrencyId int   ,

	@PayPalClientId varchar (255)  ,

	@PayPalClientSecret varchar (255)  ,

	@PaypalUser varchar (255)  ,

	@PaypalProPassword varchar (255)  ,

	@PaypalVendor varchar (255)  ,

	@PaypalPartner varchar (255)  ,

	@InvoiceSiteInfo nvarchar (1000)  ,

	@InvoiceSiteFooter nvarchar (1500)  ,

	@EnableTermsAndConditions bit   ,

	@DefaultEmailLanguageId int   ,

	@GoogleTagManager varchar (100)  ,

	@GoogleAnalytics varchar (100)  ,

	@GoogleWebMaster varchar (100)  ,

	@EnablePeopleSearch bit   ,

	@GlobalDateFormat varchar (20)  ,

	@TimeZone varchar (255)  ,

	@GlobalFolder varchar (255)  ,

	@EnableScreeningQuestions bit   ,

	@EnableExpiryDate bit   ,

	@MemberRegisterPageId int   
)
AS


				
				INSERT INTO [dbo].[GlobalSettings]
					(
					[SiteID]
					,[DefaultLanguageID]
					,[DefaultDynamicPageID]
					,[PublicJobsSearch]
					,[PublicMembersSearch]
					,[PublicCompaniesSearch]
					,[PublicSponsoredAdverts]
					,[PrivateJobs]
					,[PrivateMembers]
					,[PrivateCompanies]
					,[LastModifiedBy]
					,[LastModified]
					,[PageTitlePrefix]
					,[PageTitleSuffix]
					,[DefaultTitle]
					,[HomeTitle]
					,[DefaultDescription]
					,[HomeDescription]
					,[DefaultKeywords]
					,[HomeKeywords]
					,[ShowFaceBookButton]
					,[UseAdvertiserFilter]
					,[MerchantID]
					,[ShowTwitterButton]
					,[ShowJobAlertButton]
					,[ShowLinkedInButton]
					,[SiteFavIconID]
					,[SiteDocType]
					,[CurrencySymbol]
					,[FtpFolderLocation]
					,[MetaTags]
					,[SystemMetaTags]
					,[MemberRegistrationNotification]
					,[LinkedInAPI]
					,[LinkedInLogo]
					,[LinkedInCompanyID]
					,[LinkedInEmail]
					,[PrivacySettings]
					,[WWWRedirect]
					,[AllowAdvertiser]
					,[LinkedInAPISecret]
					,[GoogleClientID]
					,[GoogleClientSecret]
					,[FacebookAppID]
					,[FacebookAppSecret]
					,[LinkedInButtonSize]
					,[DefaultCountryID]
					,[PayPalUsername]
					,[PayPalPassword]
					,[PayPalSignature]
					,[SecurePayMerchantID]
					,[SecurePayPassword]
					,[UsingSSL]
					,[UseCustomProfessionRole]
					,[GenerateJobXML]
					,[IsPrivateSite]
					,[PrivateRedirectUrl]
					,[EnableJobCustomQuestionnaire]
					,[JobApplicationTypeID]
					,[JobScreeningProcess]
					,[AdvertiserApprovalProcess]
					,[SiteType]
					,[EnableSSL]
					,[GST]
					,[GSTLabel]
					,[NumberOfPremiumJobs]
					,[PremiumJobDays]
					,[DisplayPremiumJobsOnResults]
					,[JobExpiryNotification]
					,[CurrencyID]
					,[PayPalClientID]
					,[PayPalClientSecret]
					,[PaypalUser]
					,[PaypalProPassword]
					,[PaypalVendor]
					,[PaypalPartner]
					,[InvoiceSiteInfo]
					,[InvoiceSiteFooter]
					,[EnableTermsAndConditions]
					,[DefaultEmailLanguageId]
					,[GoogleTagManager]
					,[GoogleAnalytics]
					,[GoogleWebMaster]
					,[EnablePeopleSearch]
					,[GlobalDateFormat]
					,[TimeZone]
					,[GlobalFolder]
					,[EnableScreeningQuestions]
					,[EnableExpiryDate]
					,[MemberRegisterPageID]
					)
				VALUES
					(
					@SiteId
					,@DefaultLanguageId
					,@DefaultDynamicPageId
					,@PublicJobsSearch
					,@PublicMembersSearch
					,@PublicCompaniesSearch
					,@PublicSponsoredAdverts
					,@PrivateJobs
					,@PrivateMembers
					,@PrivateCompanies
					,@LastModifiedBy
					,@LastModified
					,@PageTitlePrefix
					,@PageTitleSuffix
					,@DefaultTitle
					,@HomeTitle
					,@DefaultDescription
					,@HomeDescription
					,@DefaultKeywords
					,@HomeKeywords
					,@ShowFaceBookButton
					,@UseAdvertiserFilter
					,@MerchantId
					,@ShowTwitterButton
					,@ShowJobAlertButton
					,@ShowLinkedInButton
					,@SiteFavIconId
					,@SiteDocType
					,@CurrencySymbol
					,@FtpFolderLocation
					,@MetaTags
					,@SystemMetaTags
					,@MemberRegistrationNotification
					,@LinkedInApi
					,@LinkedInLogo
					,@LinkedInCompanyId
					,@LinkedInEmail
					,@PrivacySettings
					,@WwwRedirect
					,@AllowAdvertiser
					,@LinkedInApiSecret
					,@GoogleClientId
					,@GoogleClientSecret
					,@FacebookAppId
					,@FacebookAppSecret
					,@LinkedInButtonSize
					,@DefaultCountryId
					,@PayPalUsername
					,@PayPalPassword
					,@PayPalSignature
					,@SecurePayMerchantId
					,@SecurePayPassword
					,@UsingSsl
					,@UseCustomProfessionRole
					,@GenerateJobXml
					,@IsPrivateSite
					,@PrivateRedirectUrl
					,@EnableJobCustomQuestionnaire
					,@JobApplicationTypeId
					,@JobScreeningProcess
					,@AdvertiserApprovalProcess
					,@SiteType
					,@EnableSsl
					,@Gst
					,@GstLabel
					,@NumberOfPremiumJobs
					,@PremiumJobDays
					,@DisplayPremiumJobsOnResults
					,@JobExpiryNotification
					,@CurrencyId
					,@PayPalClientId
					,@PayPalClientSecret
					,@PaypalUser
					,@PaypalProPassword
					,@PaypalVendor
					,@PaypalPartner
					,@InvoiceSiteInfo
					,@InvoiceSiteFooter
					,@EnableTermsAndConditions
					,@DefaultEmailLanguageId
					,@GoogleTagManager
					,@GoogleAnalytics
					,@GoogleWebMaster
					,@EnablePeopleSearch
					,@GlobalDateFormat
					,@TimeZone
					,@GlobalFolder
					,@EnableScreeningQuestions
					,@EnableExpiryDate
					,@MemberRegisterPageId
					)
				
				-- Get the identity value
				SET @GlobalSettingId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetPaged]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the GlobalSettings table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [GlobalSettingID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([GlobalSettingID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [GlobalSettingID]'
				SET @SQL = @SQL + ' FROM [dbo].[GlobalSettings]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[GlobalSettingID], O.[SiteID], O.[DefaultLanguageID], O.[DefaultDynamicPageID], O.[PublicJobsSearch], O.[PublicMembersSearch], O.[PublicCompaniesSearch], O.[PublicSponsoredAdverts], O.[PrivateJobs], O.[PrivateMembers], O.[PrivateCompanies], O.[LastModifiedBy], O.[LastModified], O.[PageTitlePrefix], O.[PageTitleSuffix], O.[DefaultTitle], O.[HomeTitle], O.[DefaultDescription], O.[HomeDescription], O.[DefaultKeywords], O.[HomeKeywords], O.[ShowFaceBookButton], O.[UseAdvertiserFilter], O.[MerchantID], O.[ShowTwitterButton], O.[ShowJobAlertButton], O.[ShowLinkedInButton], O.[SiteFavIconID], O.[SiteDocType], O.[CurrencySymbol], O.[FtpFolderLocation], O.[MetaTags], O.[SystemMetaTags], O.[MemberRegistrationNotification], O.[LinkedInAPI], O.[LinkedInLogo], O.[LinkedInCompanyID], O.[LinkedInEmail], O.[PrivacySettings], O.[WWWRedirect], O.[AllowAdvertiser], O.[LinkedInAPISecret], O.[GoogleClientID], O.[GoogleClientSecret], O.[FacebookAppID], O.[FacebookAppSecret], O.[LinkedInButtonSize], O.[DefaultCountryID], O.[PayPalUsername], O.[PayPalPassword], O.[PayPalSignature], O.[SecurePayMerchantID], O.[SecurePayPassword], O.[UsingSSL], O.[UseCustomProfessionRole], O.[GenerateJobXML], O.[IsPrivateSite], O.[PrivateRedirectUrl], O.[EnableJobCustomQuestionnaire], O.[JobApplicationTypeID], O.[JobScreeningProcess], O.[AdvertiserApprovalProcess], O.[SiteType], O.[EnableSSL], O.[GST], O.[GSTLabel], O.[NumberOfPremiumJobs], O.[PremiumJobDays], O.[DisplayPremiumJobsOnResults], O.[JobExpiryNotification], O.[CurrencyID], O.[PayPalClientID], O.[PayPalClientSecret], O.[PaypalUser], O.[PaypalProPassword], O.[PaypalVendor], O.[PaypalPartner], O.[InvoiceSiteInfo], O.[InvoiceSiteFooter], O.[EnableTermsAndConditions], O.[DefaultEmailLanguageId], O.[GoogleTagManager], O.[GoogleAnalytics], O.[GoogleWebMaster], O.[EnablePeopleSearch], O.[GlobalDateFormat], O.[TimeZone], O.[GlobalFolder], O.[EnableScreeningQuestions], O.[EnableExpiryDate], O.[MemberRegisterPageID]
				FROM
				    [dbo].[GlobalSettings] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[GlobalSettingID] = PageIndex.[GlobalSettingID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[GlobalSettings]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdUseAdvertiserFilter]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdUseAdvertiserFilter]
(

	@SiteId int   ,

	@UseAdvertiserFilter int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [UseAdvertiserFilter] = @UseAdvertiserFilter
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdPublicJobsSearch]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdPublicJobsSearch]
(

	@SiteId int   ,

	@PublicJobsSearch bit   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [PublicJobsSearch] = @PublicJobsSearch
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdGlobalSettingId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdGlobalSettingId]
(

	@SiteId int   ,

	@GlobalSettingId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteFavIconId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteFavIconId]
(

	@SiteFavIconId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteFavIconID] = @SiteFavIconId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId]
(

	@PublicJobsSearch bit   ,

	@PrivateJobs bit   ,

	@SiteId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[PublicJobsSearch] = @PublicJobsSearch
					AND [PrivateJobs] = @PrivateJobs
					AND [SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByMemberRegisterPageId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[GlobalSettings_GetByMemberRegisterPageId]
(

	@MemberRegisterPageId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[MemberRegisterPageID] = @MemberRegisterPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByLastModifiedBy]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByGlobalSettingId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByGlobalSettingId]
(

	@GlobalSettingId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultLanguageId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultLanguageId]
(

	@DefaultLanguageId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultLanguageID] = @DefaultLanguageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultDynamicPageId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultDynamicPageId]
(

	@DefaultDynamicPageId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultDynamicPageID] = @DefaultDynamicPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultCountryId]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultCountryId]
(

	@DefaultCountryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultCountryID] = @DefaultCountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Get_List]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Get_List]

AS


				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID]
				FROM
					[dbo].[GlobalSettings]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Find]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the GlobalSettings table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Find]
(

	@SearchUsingOR bit   = null ,

	@GlobalSettingId int   = null ,

	@SiteId int   = null ,

	@DefaultLanguageId int   = null ,

	@DefaultDynamicPageId int   = null ,

	@PublicJobsSearch bit   = null ,

	@PublicMembersSearch bit   = null ,

	@PublicCompaniesSearch bit   = null ,

	@PublicSponsoredAdverts bit   = null ,

	@PrivateJobs bit   = null ,

	@PrivateMembers bit   = null ,

	@PrivateCompanies bit   = null ,

	@LastModifiedBy int   = null ,

	@LastModified datetime   = null ,

	@PageTitlePrefix nvarchar (510)  = null ,

	@PageTitleSuffix nvarchar (510)  = null ,

	@DefaultTitle nvarchar (510)  = null ,

	@HomeTitle nvarchar (510)  = null ,

	@DefaultDescription nvarchar (510)  = null ,

	@HomeDescription nvarchar (510)  = null ,

	@DefaultKeywords nvarchar (510)  = null ,

	@HomeKeywords nvarchar (510)  = null ,

	@ShowFaceBookButton bit   = null ,

	@UseAdvertiserFilter int   = null ,

	@MerchantId int   = null ,

	@ShowTwitterButton bit   = null ,

	@ShowJobAlertButton bit   = null ,

	@ShowLinkedInButton bit   = null ,

	@SiteFavIconId int   = null ,

	@SiteDocType varchar (512)  = null ,

	@CurrencySymbol varchar (10)  = null ,

	@FtpFolderLocation varchar (255)  = null ,

	@MetaTags nvarchar (MAX)  = null ,

	@SystemMetaTags nvarchar (4000)  = null ,

	@MemberRegistrationNotification varchar (255)  = null ,

	@LinkedInApi varchar (255)  = null ,

	@LinkedInLogo varchar (255)  = null ,

	@LinkedInCompanyId int   = null ,

	@LinkedInEmail varchar (255)  = null ,

	@PrivacySettings nvarchar (4000)  = null ,

	@WwwRedirect bit   = null ,

	@AllowAdvertiser bit   = null ,

	@LinkedInApiSecret varchar (255)  = null ,

	@GoogleClientId varchar (255)  = null ,

	@GoogleClientSecret varchar (255)  = null ,

	@FacebookAppId varchar (255)  = null ,

	@FacebookAppSecret varchar (255)  = null ,

	@LinkedInButtonSize int   = null ,

	@DefaultCountryId int   = null ,

	@PayPalUsername varchar (100)  = null ,

	@PayPalPassword varchar (100)  = null ,

	@PayPalSignature varchar (100)  = null ,

	@SecurePayMerchantId varchar (100)  = null ,

	@SecurePayPassword varchar (100)  = null ,

	@UsingSsl bit   = null ,

	@UseCustomProfessionRole bit   = null ,

	@GenerateJobXml bit   = null ,

	@IsPrivateSite bit   = null ,

	@PrivateRedirectUrl varchar (255)  = null ,

	@EnableJobCustomQuestionnaire bit   = null ,

	@JobApplicationTypeId int   = null ,

	@JobScreeningProcess bit   = null ,

	@AdvertiserApprovalProcess int   = null ,

	@SiteType int   = null ,

	@EnableSsl bit   = null ,

	@Gst decimal (5, 2)  = null ,

	@GstLabel nvarchar (510)  = null ,

	@NumberOfPremiumJobs int   = null ,

	@PremiumJobDays int   = null ,

	@DisplayPremiumJobsOnResults bit   = null ,

	@JobExpiryNotification bit   = null ,

	@CurrencyId int   = null ,

	@PayPalClientId varchar (255)  = null ,

	@PayPalClientSecret varchar (255)  = null ,

	@PaypalUser varchar (255)  = null ,

	@PaypalProPassword varchar (255)  = null ,

	@PaypalVendor varchar (255)  = null ,

	@PaypalPartner varchar (255)  = null ,

	@InvoiceSiteInfo nvarchar (1000)  = null ,

	@InvoiceSiteFooter nvarchar (1500)  = null ,

	@EnableTermsAndConditions bit   = null ,

	@DefaultEmailLanguageId int   = null ,

	@GoogleTagManager varchar (100)  = null ,

	@GoogleAnalytics varchar (100)  = null ,

	@GoogleWebMaster varchar (100)  = null ,

	@EnablePeopleSearch bit   = null ,

	@GlobalDateFormat varchar (20)  = null ,

	@TimeZone varchar (255)  = null ,

	@GlobalFolder varchar (255)  = null ,

	@EnableScreeningQuestions bit   = null ,

	@EnableExpiryDate bit   = null ,

	@MemberRegisterPageId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GlobalSettingID]
	, [SiteID]
	, [DefaultLanguageID]
	, [DefaultDynamicPageID]
	, [PublicJobsSearch]
	, [PublicMembersSearch]
	, [PublicCompaniesSearch]
	, [PublicSponsoredAdverts]
	, [PrivateJobs]
	, [PrivateMembers]
	, [PrivateCompanies]
	, [LastModifiedBy]
	, [LastModified]
	, [PageTitlePrefix]
	, [PageTitleSuffix]
	, [DefaultTitle]
	, [HomeTitle]
	, [DefaultDescription]
	, [HomeDescription]
	, [DefaultKeywords]
	, [HomeKeywords]
	, [ShowFaceBookButton]
	, [UseAdvertiserFilter]
	, [MerchantID]
	, [ShowTwitterButton]
	, [ShowJobAlertButton]
	, [ShowLinkedInButton]
	, [SiteFavIconID]
	, [SiteDocType]
	, [CurrencySymbol]
	, [FtpFolderLocation]
	, [MetaTags]
	, [SystemMetaTags]
	, [MemberRegistrationNotification]
	, [LinkedInAPI]
	, [LinkedInLogo]
	, [LinkedInCompanyID]
	, [LinkedInEmail]
	, [PrivacySettings]
	, [WWWRedirect]
	, [AllowAdvertiser]
	, [LinkedInAPISecret]
	, [GoogleClientID]
	, [GoogleClientSecret]
	, [FacebookAppID]
	, [FacebookAppSecret]
	, [LinkedInButtonSize]
	, [DefaultCountryID]
	, [PayPalUsername]
	, [PayPalPassword]
	, [PayPalSignature]
	, [SecurePayMerchantID]
	, [SecurePayPassword]
	, [UsingSSL]
	, [UseCustomProfessionRole]
	, [GenerateJobXML]
	, [IsPrivateSite]
	, [PrivateRedirectUrl]
	, [EnableJobCustomQuestionnaire]
	, [JobApplicationTypeID]
	, [JobScreeningProcess]
	, [AdvertiserApprovalProcess]
	, [SiteType]
	, [EnableSSL]
	, [GST]
	, [GSTLabel]
	, [NumberOfPremiumJobs]
	, [PremiumJobDays]
	, [DisplayPremiumJobsOnResults]
	, [JobExpiryNotification]
	, [CurrencyID]
	, [PayPalClientID]
	, [PayPalClientSecret]
	, [PaypalUser]
	, [PaypalProPassword]
	, [PaypalVendor]
	, [PaypalPartner]
	, [InvoiceSiteInfo]
	, [InvoiceSiteFooter]
	, [EnableTermsAndConditions]
	, [DefaultEmailLanguageId]
	, [GoogleTagManager]
	, [GoogleAnalytics]
	, [GoogleWebMaster]
	, [EnablePeopleSearch]
	, [GlobalDateFormat]
	, [TimeZone]
	, [GlobalFolder]
	, [EnableScreeningQuestions]
	, [EnableExpiryDate]
	, [MemberRegisterPageID]
    FROM
	[dbo].[GlobalSettings]
    WHERE 
	 ([GlobalSettingID] = @GlobalSettingId OR @GlobalSettingId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([DefaultLanguageID] = @DefaultLanguageId OR @DefaultLanguageId IS NULL)
	AND ([DefaultDynamicPageID] = @DefaultDynamicPageId OR @DefaultDynamicPageId IS NULL)
	AND ([PublicJobsSearch] = @PublicJobsSearch OR @PublicJobsSearch IS NULL)
	AND ([PublicMembersSearch] = @PublicMembersSearch OR @PublicMembersSearch IS NULL)
	AND ([PublicCompaniesSearch] = @PublicCompaniesSearch OR @PublicCompaniesSearch IS NULL)
	AND ([PublicSponsoredAdverts] = @PublicSponsoredAdverts OR @PublicSponsoredAdverts IS NULL)
	AND ([PrivateJobs] = @PrivateJobs OR @PrivateJobs IS NULL)
	AND ([PrivateMembers] = @PrivateMembers OR @PrivateMembers IS NULL)
	AND ([PrivateCompanies] = @PrivateCompanies OR @PrivateCompanies IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([PageTitlePrefix] = @PageTitlePrefix OR @PageTitlePrefix IS NULL)
	AND ([PageTitleSuffix] = @PageTitleSuffix OR @PageTitleSuffix IS NULL)
	AND ([DefaultTitle] = @DefaultTitle OR @DefaultTitle IS NULL)
	AND ([HomeTitle] = @HomeTitle OR @HomeTitle IS NULL)
	AND ([DefaultDescription] = @DefaultDescription OR @DefaultDescription IS NULL)
	AND ([HomeDescription] = @HomeDescription OR @HomeDescription IS NULL)
	AND ([DefaultKeywords] = @DefaultKeywords OR @DefaultKeywords IS NULL)
	AND ([HomeKeywords] = @HomeKeywords OR @HomeKeywords IS NULL)
	AND ([ShowFaceBookButton] = @ShowFaceBookButton OR @ShowFaceBookButton IS NULL)
	AND ([UseAdvertiserFilter] = @UseAdvertiserFilter OR @UseAdvertiserFilter IS NULL)
	AND ([MerchantID] = @MerchantId OR @MerchantId IS NULL)
	AND ([ShowTwitterButton] = @ShowTwitterButton OR @ShowTwitterButton IS NULL)
	AND ([ShowJobAlertButton] = @ShowJobAlertButton OR @ShowJobAlertButton IS NULL)
	AND ([ShowLinkedInButton] = @ShowLinkedInButton OR @ShowLinkedInButton IS NULL)
	AND ([SiteFavIconID] = @SiteFavIconId OR @SiteFavIconId IS NULL)
	AND ([SiteDocType] = @SiteDocType OR @SiteDocType IS NULL)
	AND ([CurrencySymbol] = @CurrencySymbol OR @CurrencySymbol IS NULL)
	AND ([FtpFolderLocation] = @FtpFolderLocation OR @FtpFolderLocation IS NULL)
	AND ([MetaTags] = @MetaTags OR @MetaTags IS NULL)
	AND ([SystemMetaTags] = @SystemMetaTags OR @SystemMetaTags IS NULL)
	AND ([MemberRegistrationNotification] = @MemberRegistrationNotification OR @MemberRegistrationNotification IS NULL)
	AND ([LinkedInAPI] = @LinkedInApi OR @LinkedInApi IS NULL)
	AND ([LinkedInLogo] = @LinkedInLogo OR @LinkedInLogo IS NULL)
	AND ([LinkedInCompanyID] = @LinkedInCompanyId OR @LinkedInCompanyId IS NULL)
	AND ([LinkedInEmail] = @LinkedInEmail OR @LinkedInEmail IS NULL)
	AND ([PrivacySettings] = @PrivacySettings OR @PrivacySettings IS NULL)
	AND ([WWWRedirect] = @WwwRedirect OR @WwwRedirect IS NULL)
	AND ([AllowAdvertiser] = @AllowAdvertiser OR @AllowAdvertiser IS NULL)
	AND ([LinkedInAPISecret] = @LinkedInApiSecret OR @LinkedInApiSecret IS NULL)
	AND ([GoogleClientID] = @GoogleClientId OR @GoogleClientId IS NULL)
	AND ([GoogleClientSecret] = @GoogleClientSecret OR @GoogleClientSecret IS NULL)
	AND ([FacebookAppID] = @FacebookAppId OR @FacebookAppId IS NULL)
	AND ([FacebookAppSecret] = @FacebookAppSecret OR @FacebookAppSecret IS NULL)
	AND ([LinkedInButtonSize] = @LinkedInButtonSize OR @LinkedInButtonSize IS NULL)
	AND ([DefaultCountryID] = @DefaultCountryId OR @DefaultCountryId IS NULL)
	AND ([PayPalUsername] = @PayPalUsername OR @PayPalUsername IS NULL)
	AND ([PayPalPassword] = @PayPalPassword OR @PayPalPassword IS NULL)
	AND ([PayPalSignature] = @PayPalSignature OR @PayPalSignature IS NULL)
	AND ([SecurePayMerchantID] = @SecurePayMerchantId OR @SecurePayMerchantId IS NULL)
	AND ([SecurePayPassword] = @SecurePayPassword OR @SecurePayPassword IS NULL)
	AND ([UsingSSL] = @UsingSsl OR @UsingSsl IS NULL)
	AND ([UseCustomProfessionRole] = @UseCustomProfessionRole OR @UseCustomProfessionRole IS NULL)
	AND ([GenerateJobXML] = @GenerateJobXml OR @GenerateJobXml IS NULL)
	AND ([IsPrivateSite] = @IsPrivateSite OR @IsPrivateSite IS NULL)
	AND ([PrivateRedirectUrl] = @PrivateRedirectUrl OR @PrivateRedirectUrl IS NULL)
	AND ([EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire OR @EnableJobCustomQuestionnaire IS NULL)
	AND ([JobApplicationTypeID] = @JobApplicationTypeId OR @JobApplicationTypeId IS NULL)
	AND ([JobScreeningProcess] = @JobScreeningProcess OR @JobScreeningProcess IS NULL)
	AND ([AdvertiserApprovalProcess] = @AdvertiserApprovalProcess OR @AdvertiserApprovalProcess IS NULL)
	AND ([SiteType] = @SiteType OR @SiteType IS NULL)
	AND ([EnableSSL] = @EnableSsl OR @EnableSsl IS NULL)
	AND ([GST] = @Gst OR @Gst IS NULL)
	AND ([GSTLabel] = @GstLabel OR @GstLabel IS NULL)
	AND ([NumberOfPremiumJobs] = @NumberOfPremiumJobs OR @NumberOfPremiumJobs IS NULL)
	AND ([PremiumJobDays] = @PremiumJobDays OR @PremiumJobDays IS NULL)
	AND ([DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults OR @DisplayPremiumJobsOnResults IS NULL)
	AND ([JobExpiryNotification] = @JobExpiryNotification OR @JobExpiryNotification IS NULL)
	AND ([CurrencyID] = @CurrencyId OR @CurrencyId IS NULL)
	AND ([PayPalClientID] = @PayPalClientId OR @PayPalClientId IS NULL)
	AND ([PayPalClientSecret] = @PayPalClientSecret OR @PayPalClientSecret IS NULL)
	AND ([PaypalUser] = @PaypalUser OR @PaypalUser IS NULL)
	AND ([PaypalProPassword] = @PaypalProPassword OR @PaypalProPassword IS NULL)
	AND ([PaypalVendor] = @PaypalVendor OR @PaypalVendor IS NULL)
	AND ([PaypalPartner] = @PaypalPartner OR @PaypalPartner IS NULL)
	AND ([InvoiceSiteInfo] = @InvoiceSiteInfo OR @InvoiceSiteInfo IS NULL)
	AND ([InvoiceSiteFooter] = @InvoiceSiteFooter OR @InvoiceSiteFooter IS NULL)
	AND ([EnableTermsAndConditions] = @EnableTermsAndConditions OR @EnableTermsAndConditions IS NULL)
	AND ([DefaultEmailLanguageId] = @DefaultEmailLanguageId OR @DefaultEmailLanguageId IS NULL)
	AND ([GoogleTagManager] = @GoogleTagManager OR @GoogleTagManager IS NULL)
	AND ([GoogleAnalytics] = @GoogleAnalytics OR @GoogleAnalytics IS NULL)
	AND ([GoogleWebMaster] = @GoogleWebMaster OR @GoogleWebMaster IS NULL)
	AND ([EnablePeopleSearch] = @EnablePeopleSearch OR @EnablePeopleSearch IS NULL)
	AND ([GlobalDateFormat] = @GlobalDateFormat OR @GlobalDateFormat IS NULL)
	AND ([TimeZone] = @TimeZone OR @TimeZone IS NULL)
	AND ([GlobalFolder] = @GlobalFolder OR @GlobalFolder IS NULL)
	AND ([EnableScreeningQuestions] = @EnableScreeningQuestions OR @EnableScreeningQuestions IS NULL)
	AND ([EnableExpiryDate] = @EnableExpiryDate OR @EnableExpiryDate IS NULL)
	AND ([MemberRegisterPageID] = @MemberRegisterPageId OR @MemberRegisterPageId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GlobalSettingID]
	, [SiteID]
	, [DefaultLanguageID]
	, [DefaultDynamicPageID]
	, [PublicJobsSearch]
	, [PublicMembersSearch]
	, [PublicCompaniesSearch]
	, [PublicSponsoredAdverts]
	, [PrivateJobs]
	, [PrivateMembers]
	, [PrivateCompanies]
	, [LastModifiedBy]
	, [LastModified]
	, [PageTitlePrefix]
	, [PageTitleSuffix]
	, [DefaultTitle]
	, [HomeTitle]
	, [DefaultDescription]
	, [HomeDescription]
	, [DefaultKeywords]
	, [HomeKeywords]
	, [ShowFaceBookButton]
	, [UseAdvertiserFilter]
	, [MerchantID]
	, [ShowTwitterButton]
	, [ShowJobAlertButton]
	, [ShowLinkedInButton]
	, [SiteFavIconID]
	, [SiteDocType]
	, [CurrencySymbol]
	, [FtpFolderLocation]
	, [MetaTags]
	, [SystemMetaTags]
	, [MemberRegistrationNotification]
	, [LinkedInAPI]
	, [LinkedInLogo]
	, [LinkedInCompanyID]
	, [LinkedInEmail]
	, [PrivacySettings]
	, [WWWRedirect]
	, [AllowAdvertiser]
	, [LinkedInAPISecret]
	, [GoogleClientID]
	, [GoogleClientSecret]
	, [FacebookAppID]
	, [FacebookAppSecret]
	, [LinkedInButtonSize]
	, [DefaultCountryID]
	, [PayPalUsername]
	, [PayPalPassword]
	, [PayPalSignature]
	, [SecurePayMerchantID]
	, [SecurePayPassword]
	, [UsingSSL]
	, [UseCustomProfessionRole]
	, [GenerateJobXML]
	, [IsPrivateSite]
	, [PrivateRedirectUrl]
	, [EnableJobCustomQuestionnaire]
	, [JobApplicationTypeID]
	, [JobScreeningProcess]
	, [AdvertiserApprovalProcess]
	, [SiteType]
	, [EnableSSL]
	, [GST]
	, [GSTLabel]
	, [NumberOfPremiumJobs]
	, [PremiumJobDays]
	, [DisplayPremiumJobsOnResults]
	, [JobExpiryNotification]
	, [CurrencyID]
	, [PayPalClientID]
	, [PayPalClientSecret]
	, [PaypalUser]
	, [PaypalProPassword]
	, [PaypalVendor]
	, [PaypalPartner]
	, [InvoiceSiteInfo]
	, [InvoiceSiteFooter]
	, [EnableTermsAndConditions]
	, [DefaultEmailLanguageId]
	, [GoogleTagManager]
	, [GoogleAnalytics]
	, [GoogleWebMaster]
	, [EnablePeopleSearch]
	, [GlobalDateFormat]
	, [TimeZone]
	, [GlobalFolder]
	, [EnableScreeningQuestions]
	, [EnableExpiryDate]
	, [MemberRegisterPageID]
    FROM
	[dbo].[GlobalSettings]
    WHERE 
	 ([GlobalSettingID] = @GlobalSettingId AND @GlobalSettingId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([DefaultLanguageID] = @DefaultLanguageId AND @DefaultLanguageId is not null)
	OR ([DefaultDynamicPageID] = @DefaultDynamicPageId AND @DefaultDynamicPageId is not null)
	OR ([PublicJobsSearch] = @PublicJobsSearch AND @PublicJobsSearch is not null)
	OR ([PublicMembersSearch] = @PublicMembersSearch AND @PublicMembersSearch is not null)
	OR ([PublicCompaniesSearch] = @PublicCompaniesSearch AND @PublicCompaniesSearch is not null)
	OR ([PublicSponsoredAdverts] = @PublicSponsoredAdverts AND @PublicSponsoredAdverts is not null)
	OR ([PrivateJobs] = @PrivateJobs AND @PrivateJobs is not null)
	OR ([PrivateMembers] = @PrivateMembers AND @PrivateMembers is not null)
	OR ([PrivateCompanies] = @PrivateCompanies AND @PrivateCompanies is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([PageTitlePrefix] = @PageTitlePrefix AND @PageTitlePrefix is not null)
	OR ([PageTitleSuffix] = @PageTitleSuffix AND @PageTitleSuffix is not null)
	OR ([DefaultTitle] = @DefaultTitle AND @DefaultTitle is not null)
	OR ([HomeTitle] = @HomeTitle AND @HomeTitle is not null)
	OR ([DefaultDescription] = @DefaultDescription AND @DefaultDescription is not null)
	OR ([HomeDescription] = @HomeDescription AND @HomeDescription is not null)
	OR ([DefaultKeywords] = @DefaultKeywords AND @DefaultKeywords is not null)
	OR ([HomeKeywords] = @HomeKeywords AND @HomeKeywords is not null)
	OR ([ShowFaceBookButton] = @ShowFaceBookButton AND @ShowFaceBookButton is not null)
	OR ([UseAdvertiserFilter] = @UseAdvertiserFilter AND @UseAdvertiserFilter is not null)
	OR ([MerchantID] = @MerchantId AND @MerchantId is not null)
	OR ([ShowTwitterButton] = @ShowTwitterButton AND @ShowTwitterButton is not null)
	OR ([ShowJobAlertButton] = @ShowJobAlertButton AND @ShowJobAlertButton is not null)
	OR ([ShowLinkedInButton] = @ShowLinkedInButton AND @ShowLinkedInButton is not null)
	OR ([SiteFavIconID] = @SiteFavIconId AND @SiteFavIconId is not null)
	OR ([SiteDocType] = @SiteDocType AND @SiteDocType is not null)
	OR ([CurrencySymbol] = @CurrencySymbol AND @CurrencySymbol is not null)
	OR ([FtpFolderLocation] = @FtpFolderLocation AND @FtpFolderLocation is not null)
	OR ([MetaTags] = @MetaTags AND @MetaTags is not null)
	OR ([SystemMetaTags] = @SystemMetaTags AND @SystemMetaTags is not null)
	OR ([MemberRegistrationNotification] = @MemberRegistrationNotification AND @MemberRegistrationNotification is not null)
	OR ([LinkedInAPI] = @LinkedInApi AND @LinkedInApi is not null)
	OR ([LinkedInLogo] = @LinkedInLogo AND @LinkedInLogo is not null)
	OR ([LinkedInCompanyID] = @LinkedInCompanyId AND @LinkedInCompanyId is not null)
	OR ([LinkedInEmail] = @LinkedInEmail AND @LinkedInEmail is not null)
	OR ([PrivacySettings] = @PrivacySettings AND @PrivacySettings is not null)
	OR ([WWWRedirect] = @WwwRedirect AND @WwwRedirect is not null)
	OR ([AllowAdvertiser] = @AllowAdvertiser AND @AllowAdvertiser is not null)
	OR ([LinkedInAPISecret] = @LinkedInApiSecret AND @LinkedInApiSecret is not null)
	OR ([GoogleClientID] = @GoogleClientId AND @GoogleClientId is not null)
	OR ([GoogleClientSecret] = @GoogleClientSecret AND @GoogleClientSecret is not null)
	OR ([FacebookAppID] = @FacebookAppId AND @FacebookAppId is not null)
	OR ([FacebookAppSecret] = @FacebookAppSecret AND @FacebookAppSecret is not null)
	OR ([LinkedInButtonSize] = @LinkedInButtonSize AND @LinkedInButtonSize is not null)
	OR ([DefaultCountryID] = @DefaultCountryId AND @DefaultCountryId is not null)
	OR ([PayPalUsername] = @PayPalUsername AND @PayPalUsername is not null)
	OR ([PayPalPassword] = @PayPalPassword AND @PayPalPassword is not null)
	OR ([PayPalSignature] = @PayPalSignature AND @PayPalSignature is not null)
	OR ([SecurePayMerchantID] = @SecurePayMerchantId AND @SecurePayMerchantId is not null)
	OR ([SecurePayPassword] = @SecurePayPassword AND @SecurePayPassword is not null)
	OR ([UsingSSL] = @UsingSsl AND @UsingSsl is not null)
	OR ([UseCustomProfessionRole] = @UseCustomProfessionRole AND @UseCustomProfessionRole is not null)
	OR ([GenerateJobXML] = @GenerateJobXml AND @GenerateJobXml is not null)
	OR ([IsPrivateSite] = @IsPrivateSite AND @IsPrivateSite is not null)
	OR ([PrivateRedirectUrl] = @PrivateRedirectUrl AND @PrivateRedirectUrl is not null)
	OR ([EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire AND @EnableJobCustomQuestionnaire is not null)
	OR ([JobApplicationTypeID] = @JobApplicationTypeId AND @JobApplicationTypeId is not null)
	OR ([JobScreeningProcess] = @JobScreeningProcess AND @JobScreeningProcess is not null)
	OR ([AdvertiserApprovalProcess] = @AdvertiserApprovalProcess AND @AdvertiserApprovalProcess is not null)
	OR ([SiteType] = @SiteType AND @SiteType is not null)
	OR ([EnableSSL] = @EnableSsl AND @EnableSsl is not null)
	OR ([GST] = @Gst AND @Gst is not null)
	OR ([GSTLabel] = @GstLabel AND @GstLabel is not null)
	OR ([NumberOfPremiumJobs] = @NumberOfPremiumJobs AND @NumberOfPremiumJobs is not null)
	OR ([PremiumJobDays] = @PremiumJobDays AND @PremiumJobDays is not null)
	OR ([DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults AND @DisplayPremiumJobsOnResults is not null)
	OR ([JobExpiryNotification] = @JobExpiryNotification AND @JobExpiryNotification is not null)
	OR ([CurrencyID] = @CurrencyId AND @CurrencyId is not null)
	OR ([PayPalClientID] = @PayPalClientId AND @PayPalClientId is not null)
	OR ([PayPalClientSecret] = @PayPalClientSecret AND @PayPalClientSecret is not null)
	OR ([PaypalUser] = @PaypalUser AND @PaypalUser is not null)
	OR ([PaypalProPassword] = @PaypalProPassword AND @PaypalProPassword is not null)
	OR ([PaypalVendor] = @PaypalVendor AND @PaypalVendor is not null)
	OR ([PaypalPartner] = @PaypalPartner AND @PaypalPartner is not null)
	OR ([InvoiceSiteInfo] = @InvoiceSiteInfo AND @InvoiceSiteInfo is not null)
	OR ([InvoiceSiteFooter] = @InvoiceSiteFooter AND @InvoiceSiteFooter is not null)
	OR ([EnableTermsAndConditions] = @EnableTermsAndConditions AND @EnableTermsAndConditions is not null)
	OR ([DefaultEmailLanguageId] = @DefaultEmailLanguageId AND @DefaultEmailLanguageId is not null)
	OR ([GoogleTagManager] = @GoogleTagManager AND @GoogleTagManager is not null)
	OR ([GoogleAnalytics] = @GoogleAnalytics AND @GoogleAnalytics is not null)
	OR ([GoogleWebMaster] = @GoogleWebMaster AND @GoogleWebMaster is not null)
	OR ([EnablePeopleSearch] = @EnablePeopleSearch AND @EnablePeopleSearch is not null)
	OR ([GlobalDateFormat] = @GlobalDateFormat AND @GlobalDateFormat is not null)
	OR ([TimeZone] = @TimeZone AND @TimeZone is not null)
	OR ([GlobalFolder] = @GlobalFolder AND @GlobalFolder is not null)
	OR ([EnableScreeningQuestions] = @EnableScreeningQuestions AND @EnableScreeningQuestions is not null)
	OR ([EnableExpiryDate] = @EnableExpiryDate AND @EnableExpiryDate is not null)
	OR ([MemberRegisterPageID] = @MemberRegisterPageId AND @MemberRegisterPageId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Delete]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Delete]
(

	@GlobalSettingId int   
)
AS


				DELETE FROM [dbo].[GlobalSettings] WITH (ROWLOCK) 
				WHERE
					[GlobalSettingID] = @GlobalSettingId
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_CustomGetPaymentDetail]    Script Date: 04/11/2017 15:53:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GlobalSettings_CustomGetPaymentDetail]
(
	@SiteID INT
)
AS
BEGIN
	SELECT PayPalUsername,
			PayPalPassword,
			PayPalSignature,
			SecurePayMerchantID,
			SecurePayPassword
	FROM GlobalSettings WITH (NOLOCK)
	WHERE SiteID = @SiteID
END
GO
