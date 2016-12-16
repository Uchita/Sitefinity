-- GlobalSettings

IF OBJECT_ID('dbo.GlobalSettings', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'EnableScreeningQuestions' AND OBJECT_ID = OBJECT_ID(N'GlobalSettings'))
	BEGIN
		ALTER TABLE GlobalSettings ADD EnableScreeningQuestions BIT NOT NULL DEFAULT 0
	END 
END
ELSE
BEGIN 
	CREATE TABLE [dbo].[GlobalSettings](
	[GlobalSettingID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[DefaultLanguageID] [int] NOT NULL,
	[DefaultDynamicPageID] [int] NULL,
	[PublicJobsSearch] [bit] NOT NULL,
	[PublicMembersSearch] [bit] NOT NULL,
	[PublicCompaniesSearch] [bit] NOT NULL,
	[PublicSponsoredAdverts] [bit] NOT NULL,
	[PrivateJobs] [bit] NOT NULL,
	[PrivateMembers] [bit] NOT NULL,
	[PrivateCompanies] [bit] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[PageTitlePrefix] [nvarchar](510) NULL,
	[PageTitleSuffix] [nvarchar](510) NULL,
	[DefaultTitle] [nvarchar](510) NULL,
	[HomeTitle] [nvarchar](510) NULL,
	[DefaultDescription] [nvarchar](510) NULL,
	[HomeDescription] [nvarchar](510) NULL,
	[DefaultKeywords] [nvarchar](510) NULL,
	[HomeKeywords] [nvarchar](510) NULL,
	[ShowFaceBookButton] [bit] NOT NULL,
	[UseAdvertiserFilter] [int] NOT NULL,
	[MerchantID] [int] NULL,
	[ShowTwitterButton] [bit] NOT NULL,
	[ShowJobAlertButton] [bit] NOT NULL,
	[ShowLinkedInButton] [bit] NOT NULL,
	[SiteFavIconID] [int] NULL,
	[SiteDocType] [varchar](512) NULL,
	[CurrencySymbol] [varchar](10) NULL,
	[FtpFolderLocation] [varchar](255) NULL,
	[MetaTags] [nvarchar](max) NULL,
	[SystemMetaTags] [nvarchar](4000) NULL,
	[MemberRegistrationNotification] [varchar](255) NULL,
	[LinkedInAPI] [varchar](255) NULL,
	[LinkedInLogo] [varchar](255) NULL,
	[LinkedInCompanyID] [int] NULL,
	[LinkedInEmail] [varchar](255) NULL,
	[PrivacySettings] [nvarchar](4000) NULL,
	[WWWRedirect] [bit] NOT NULL,
	[AllowAdvertiser] [bit] NOT NULL,
	[LinkedInAPISecret] [varchar](255) NULL,
	[GoogleClientID] [varchar](255) NULL,
	[GoogleClientSecret] [varchar](255) NULL,
	[FacebookAppID] [varchar](255) NULL,
	[FacebookAppSecret] [varchar](255) NULL,
	[LinkedInButtonSize] [int] NULL,
	[DefaultCountryID] [int] NULL,
	[PayPalUsername] [varchar](100) NULL,
	[PayPalPassword] [varchar](100) NULL,
	[PayPalSignature] [varchar](100) NULL,
	[SecurePayMerchantID] [varchar](100) NULL,
	[SecurePayPassword] [varchar](100) NULL,
	[UsingSSL] [bit] NOT NULL,
	[UseCustomProfessionRole] [bit] NOT NULL,
	[GenerateJobXML] [bit] NOT NULL,
	[IsPrivateSite] [bit] NULL,
	[PrivateRedirectUrl] [varchar](255) NULL,
	[EnableJobCustomQuestionnaire] [bit] NULL,
	[JobApplicationTypeID] [int] NULL,
	[JobScreeningProcess] [bit] NULL,
	[AdvertiserApprovalProcess] [int] NULL,
	[SiteType] [int] NOT NULL,
	[EnableSSL] [bit] NOT NULL,
	[GST] [decimal](5, 2) NOT NULL,
	[GSTLabel] [nvarchar](510) NULL,
	[NumberOfPremiumJobs] [int] NOT NULL,
	[PremiumJobDays] [int] NOT NULL,
	[DisplayPremiumJobsOnResults] [bit] NOT NULL,
	[JobExpiryNotification] [bit] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[PayPalClientID] [varchar](255) NULL,
	[PayPalClientSecret] [varchar](255) NULL,
	[PaypalUser] [varchar](255) NULL,
	[PaypalProPassword] [varchar](255) NULL,
	[PaypalVendor] [varchar](255) NULL,
	[PaypalPartner] [varchar](255) NULL,
	[InvoiceSiteInfo] [nvarchar](1000) NULL,
	[InvoiceSiteFooter] [nvarchar](1500) NULL,
	[EnableTermsAndConditions] [bit] NOT NULL,
	[DefaultEmailLanguageId] [int] NULL,
	[GoogleTagManager] [varchar](100) NULL,
	[GoogleAnalytics] [varchar](100) NULL,
	[GoogleWebMaster] [varchar](100) NULL,
	[EnablePeopleSearch] [bit] NOT NULL,
	[GlobalDateFormat] [varchar](20) NOT NULL,
	[TimeZone] [varchar](255) NOT NULL,
	[EnableScreeningQuestions] [bit] NOT NULL DEFAULT 0,
 CONSTRAINT [PK__tmp_ms_xx_Global__408F9238] PRIMARY KEY CLUSTERED 
(
	[GlobalSettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD FOREIGN KEY([DefaultCountryID])
REFERENCES [dbo].[Countries] ([CountryID])

ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__Defau__5772F790] FOREIGN KEY([DefaultLanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])

ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK__GlobalSet__Defau__5772F790]

ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__Defau__58671BC9] FOREIGN KEY([DefaultDynamicPageID])
REFERENCES [dbo].[DynamicPages] ([DynamicPageID])

ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK__GlobalSet__Defau__58671BC9]

ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__LastM__5A4F643B] FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])

ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK__GlobalSet__LastM__5A4F643B]

ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__SiteF__5C37ACAD] FOREIGN KEY([SiteFavIconID])
REFERENCES [dbo].[Files] ([FileID])

ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK__GlobalSet__SiteF__5C37ACAD]

ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK__GlobalSet__SiteI__125EB334] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK__GlobalSet__SiteI__125EB334]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Defau__4183B671]  DEFAULT ((1)) FOR [DefaultLanguageID]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Publi__4277DAAA]  DEFAULT ((0)) FOR [PublicJobsSearch]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Publi__436BFEE3]  DEFAULT ((0)) FOR [PublicMembersSearch]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Publi__4460231C]  DEFAULT ((0)) FOR [PublicCompaniesSearch]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Publi__45544755]  DEFAULT ((0)) FOR [PublicSponsoredAdverts]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Priva__46486B8E]  DEFAULT ((0)) FOR [PrivateJobs]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Priva__473C8FC7]  DEFAULT ((0)) FOR [PrivateMembers]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__Priva__4830B400]  DEFAULT ((0)) FOR [PrivateCompanies]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__LastM__4924D839]  DEFAULT (getdate()) FOR [LastModified]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__ShowF__4A18FC72]  DEFAULT ((0)) FOR [ShowFaceBookButton]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__UseAd__4C0144E4]  DEFAULT ((0)) FOR [UseAdvertiserFilter]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__ShowT__4CF5691D]  DEFAULT ((0)) FOR [ShowTwitterButton]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__ShowJ__4DE98D56]  DEFAULT ((0)) FOR [ShowJobAlertButton]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF__tmp_ms_xx__ShowL__4EDDB18F]  DEFAULT ((0)) FOR [ShowLinkedInButton]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [WWWRedirect]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [AllowAdvertiser]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [UsingSSL]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [UseCustomProfessionRole]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [GenerateJobXML]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [IsPrivateSite]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [EnableJobCustomQuestionnaire]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [JobScreeningProcess]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF_AdvertiserApprovalProcess]  DEFAULT ((0)) FOR [AdvertiserApprovalProcess]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((1)) FOR [SiteType]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [EnableSSL]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0.00)) FOR [GST]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [NumberOfPremiumJobs]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((7)) FOR [PremiumJobDays]

ALTER TABLE [dbo].[GlobalSettings] ADD  CONSTRAINT [DF_Globalettings_DisplayPremiumJobsOnResults]  DEFAULT ((0)) FOR [DisplayPremiumJobsOnResults]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [JobExpiryNotification]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((1)) FOR [CurrencyID]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [EnableTermsAndConditions]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ((0)) FOR [EnablePeopleSearch]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ('dd/MM/yyyy') FOR [GlobalDateFormat]

ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT ('AUS Eastern Standard Time') FOR [TimeZone]

END
GO

-- Jobs

IF OBJECT_ID('dbo.Jobs', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'HasScreeningQuestions' AND OBJECT_ID = OBJECT_ID(N'Jobs'))
	BEGIN
		ALTER TABLE Jobs ADD HasScreeningQuestions INT NOT NULL DEFAULT 0
	END 
END
ELSE
BEGIN 
CREATE TABLE [dbo].[Jobs](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[WorkTypeID] [int] NOT NULL,
	[JobName] [nvarchar](510) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[FullDescription] [nvarchar](max) NOT NULL,
	[WebServiceProcessed] [bit] NOT NULL,
	[ApplicationEmailAddress] [varchar](255) NOT NULL,
	[RefNo] [varchar](255) NULL,
	[Visible] [bit] NOT NULL,
	[DatePosted] [smalldatetime] NOT NULL,
	[ExpiryDate] [smalldatetime] NOT NULL,
	[Expired] [int] NULL,
	[JobItemPrice] [money] NULL,
	[Billed] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[ShowSalaryDetails] [bit] NOT NULL,
	[SalaryText] [varchar](500) NULL,
	[AdvertiserID] [int] NULL,
	[LastModifiedByAdvertiserUserId] [int] NULL,
	[LastModifiedByAdminUserId] [int] NULL,
	[JobItemTypeID] [int] NULL,
	[ApplicationMethod] [int] NULL,
	[ApplicationURL] [varchar](8000) NULL,
	[UploadMethod] [int] NULL,
	[Tags] [text] NULL,
	[JobTemplateID] [int] NULL,
	[SearchFieldExtension] [varchar](8) NOT NULL,
	[AdvertiserJobTemplateLogoID] [int] NULL,
	[CompanyName] [varchar](255) NULL,
	[HashValue] [varbinary](max) NULL,
	[RequireLogonForExternalApplications] [bit] NOT NULL,
	[ShowLocationDetails] [bit] NULL,
	[PublicTransport] [nvarchar](500) NULL,
	[Address] [varchar](255) NULL,
	[ContactDetails] [nvarchar](510) NOT NULL,
	[JobContactPhone] [varchar](50) NULL,
	[JobContactName] [varchar](255) NULL,
	[QualificationsRecognised] [bit] NOT NULL,
	[ResidentOnly] [bit] NOT NULL,
	[DocumentLink] [varchar](255) NULL,
	[BulletPoint1] [nvarchar](160) NULL,
	[BulletPoint2] [nvarchar](160) NULL,
	[BulletPoint3] [nvarchar](160) NULL,
	[HotJob] [bit] NOT NULL,
	[JobFriendlyName] [varchar](512) NULL,
	[SearchField] [nvarchar](max) NULL,
	[ShowSalaryRange] [bit] NOT NULL,
	[SalaryLowerBand] [numeric](15, 2) NOT NULL,
	[SalaryUpperBand] [numeric](15, 2) NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[SalaryTypeID] [int] NOT NULL,
	[EnteredByAdvertiserUserID] [int] NULL,
	[JobLatitude] [float] NULL,
	[JobLongitude] [float] NULL,
	[AddressStatus] [int] NULL,
	[JobExternalId] [varchar](50) NULL,
	[HasScreeningQuestions] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK__Jobs__63CEACD4] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__Advertiser__6C63F2D5] FOREIGN KEY([AdvertiserID])
REFERENCES [dbo].[Advertisers] ([AdvertiserID])

ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__Advertiser__6C63F2D5]

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__JobTemplat__703483B9] FOREIGN KEY([JobTemplateID])
REFERENCES [dbo].[JobTemplates] ([JobTemplateID])

ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__JobTemplat__703483B9]

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__LastModifi__6D58170E] FOREIGN KEY([LastModifiedByAdvertiserUserId])
REFERENCES [dbo].[AdvertiserUsers] ([AdvertiserUserID])

ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__LastModifi__6D58170E]

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__LastModifi__6E4C3B47] FOREIGN KEY([LastModifiedByAdminUserId])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__LastModifi__6E4C3B47]

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD FOREIGN KEY([SalaryTypeID])
REFERENCES [dbo].[SalaryType] ([SalaryTypeID])

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__SiteID__64C2D10D] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__SiteID__64C2D10D]

ALTER TABLE [dbo].[Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK__Jobs__WorkTypeID__65B6F546] FOREIGN KEY([WorkTypeID])
REFERENCES [dbo].[WorkType] ([WorkTypeID])

ALTER TABLE [dbo].[Jobs] NOCHECK CONSTRAINT [FK__Jobs__WorkTypeID__65B6F546]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__WebService__679F3DB8]  DEFAULT ((0)) FOR [WebServiceProcessed]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__Billed__6987862A]  DEFAULT ((1)) FOR [Billed]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__LastModifi__6A7BAA63]  DEFAULT (getdate()) FOR [LastModified]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__ShowSalary__6B6FCE9C]  DEFAULT ((1)) FOR [ShowSalaryDetails]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__RequireLog__7128A7F2]  DEFAULT ((1)) FOR [RequireLogonForExternalApplications]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__Qualificat__721CCC2B]  DEFAULT ((0)) FOR [QualificationsRecognised]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__ResidentOn__7310F064]  DEFAULT ((0)) FOR [ResidentOnly]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__BulletPoin__7405149D]  DEFAULT ('') FOR [BulletPoint1]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__BulletPoin__74F938D6]  DEFAULT ('') FOR [BulletPoint2]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__BulletPoin__75ED5D0F]  DEFAULT ('') FOR [BulletPoint3]

ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__HotJob__76E18148]  DEFAULT ((0)) FOR [HotJob]
END
GO

-- JobApplication
IF OBJECT_ID('dbo.JobApplication', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'ScreeningQuestionsGUID' AND OBJECT_ID = OBJECT_ID(N'JobApplication'))
	BEGIN
		ALTER TABLE JobApplication ADD ScreeningQuestionsGUID GUID NULL
    END
END
ELSE
BEGIN 
	
CREATE TABLE [dbo].[JobApplication](
	[JobApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationDate] [smalldatetime] NULL,
	[JobID] [int] NULL,
	[MemberID] [int] NULL,
	[MemberResumeFile] [varchar](255) NULL,
	[MemberCoverLetterFile] [varchar](255) NULL,
	[ApplicationStatus] [int] NULL,
	[JobAppValidateID] [uniqueidentifier] NOT NULL,
	[SiteID_Referral] [int] NULL,
	[URL_Referral] [varchar](255) NULL,
	[ApplicantGrade] [int] NULL,
	[LastViewedDate] [datetime] NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[Surname] [nvarchar](255) NOT NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[MobilePhone] [char](40) NULL,
	[MemberNote] [nvarchar](max) NULL,
	[AdvertiserNote] [nvarchar](max) NULL,
	[JobArchiveID] [int] NULL,
	[Draft] [bit] NULL,
	[JobApplicationTypeID] [int] NULL,
	[ExternalXMLFilename] [varchar](255) NULL,
	[CustomQuestionnaireXML] [nvarchar](max) NULL,
	[ExternalPDFFilename] [varchar](255) NULL,
	[FileDownloaded] [bit] NULL,
	[AppliedWith] [varchar](255) NULL,
	[ScreeningQuestionaireXML] [nvarchar](max) NULL,
 CONSTRAINT [PK__JobApplication__05107065] PRIMARY KEY CLUSTERED 
(
	[JobApplicationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[JobApplication]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__JobAr__612C0E5D] FOREIGN KEY([JobArchiveID])
REFERENCES [dbo].[JobsArchive] ([JobID])

ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK__JobApplic__JobAr__612C0E5D]

ALTER TABLE [dbo].[JobApplication]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__JobID__0604949E] FOREIGN KEY([JobID])
REFERENCES [dbo].[Jobs] ([JobID])

ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK__JobApplic__JobID__0604949E]

ALTER TABLE [dbo].[JobApplication]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__Membe__06F8B8D7] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])

ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK__JobApplic__Membe__06F8B8D7]

ALTER TABLE [dbo].[JobApplication]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__SiteI__09D52582] FOREIGN KEY([SiteID_Referral])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK__JobApplic__SiteI__09D52582]

ALTER TABLE [dbo].[JobApplication] ADD  CONSTRAINT [DF__JobApplic__Appli__07ECDD10]  DEFAULT ((1)) FOR [ApplicationStatus]

ALTER TABLE [dbo].[JobApplication] ADD  CONSTRAINT [DF__JobApplic__JobAp__08E10149]  DEFAULT (newid()) FOR [JobAppValidateID]

ALTER TABLE [dbo].[JobApplication] ADD  DEFAULT ((0)) FOR [Draft]

ALTER TABLE [dbo].[JobApplication] ADD  DEFAULT ((0)) FOR [FileDownloaded]


END
GO
-- ScreeningQuestions
IF OBJECT_ID('dbo.ScreeningQuestions', 'U') IS NOT NULL
BEGIN
	DROP TABLE ScreeningQuestions
END
ELSE
BEGIN 
	CREATE TABLE ScreeningQuestions
	(
	  [ScreeningQuestionId] [int] IDENTITY(1,1) NOT NULL,
	  [QuestionTitle] [nvarchar] NOT NULL,
	  [LanguageId] [int] NOT NULL,
	  [KnockoutIndex] [int] NOT NULL,
	  [Options] [nvarchar] NULL,
	  [LastModified] [datetime] NULL,
	  [LastModifiedBy] [int] NULL,
	  [LastModifiedByAdvertiserId] [int] NULL,
	)

END
GO

-- ScreeningQuestionsTemplates
IF OBJECT_ID('dbo.ScreeningQuestions', 'U') IS NOT NULL
BEGIN
	DROP TABLE ScreeningQuestions
END
ELSE
BEGIN 
	CREATE TABLE ScreeningQuestions
	(
		[ScreeningQuestionsTemplateId] [int] IDENTITY(1,1) NOT NULL,
		[TemplateName] [int] IDENTITY(1,1) NOT NULL,
		[SiteId] [int] IDENTITY(1,1) NOT NULL,
		[AdvertiserId] [int] IDENTITY(1,1) NOT NULL,
		[GlobalTemplate] [int] IDENTITY(1,1) NOT NULL,
		[Visible] [int] IDENTITY(1,1) NOT NULL
	)

END
GO
