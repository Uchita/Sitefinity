-- Sites

IF OBJECT_ID('dbo.Sites', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'SiteAdminLogoURL' AND OBJECT_ID = OBJECT_ID(N'Sites'))
	BEGIN
		ALTER TABLE Sites ADD SiteAdminLogoURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 
	CREATE TABLE [dbo].[Sites](
		[SiteID] [int] IDENTITY(1,1) NOT NULL,
		[SiteName] [varchar](255) NULL,
		[SiteURL] [varchar](500) NULL,
		[SiteDescription] [varchar](max) NULL,
		[SiteAdminLogo] [image] NULL,
		[LastModified] [datetime] NOT NULL,
		[LastModifiedBy] [int] NULL,
		[Live] [bit] NULL,
		[MobileEnabled] [bit] NOT NULL,
		[MobileUrl] [varchar](255) NOT NULL,
		[SiteAdminLogoURL] [nvarchar](1000) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[SiteID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	SET ANSI_PADDING ON

	ALTER TABLE [dbo].[Sites]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
	REFERENCES [dbo].[AdminUsers] ([AdminUserID])

	ALTER TABLE [dbo].[Sites] ADD  DEFAULT (getdate()) FOR [LastModified]

	ALTER TABLE [dbo].[Sites] ADD  DEFAULT ((0)) FOR [Live]
END
GO
-- Advertisers

IF OBJECT_ID('dbo.Advertisers', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'AdvertiserLogo' AND OBJECT_ID = OBJECT_ID(N'Advertisers'))
	BEGIN
		ALTER TABLE Advertisers ADD AdvertiserLogoURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 
	CREATE TABLE [dbo].[Advertisers](
	[AdvertiserID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NULL,
	[AdvertiserAccountTypeID] [int] NOT NULL,
	[AdvertiserBusinessTypeID] [int] NOT NULL,
	[AdvertiserAccountStatusID] [int] NOT NULL,
	[CompanyName] [nvarchar](510) NULL,
	[BusinessNumber] [nvarchar](255) NULL,
	[StreetAddress1] [nvarchar](255) NULL,
	[StreetAddress2] [nvarchar](255) NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
	[PostalAddress1] [nvarchar](255) NULL,
	[PostalAddress2] [nvarchar](255) NULL,
	[WebAddress] [varchar](255) NULL,
	[NoOfEmployees] [varchar](10) NULL,
	[FirstApprovedDate] [smalldatetime] NULL,
	[Profile] [ntext] NULL,
	[CharityNumber] [varchar](50) NULL,
	[SearchField] [nvarchar](max) NULL,
	[FreeTrialStartDate] [smalldatetime] NULL,
	[FreeTrialEndDate] [smalldatetime] NULL,
	[AccountsPayableEmail] [varchar](255) NULL,
	[RequireLogonForExternalApplication] [bit] NOT NULL,
	[AdvertiserLogo] [image] NULL,
	[LinkedInLogo] [varchar](255) NULL,
	[LinkedInCompanyId] [varchar](255) NULL,
	[LinkedInEmail] [varchar](255) NULL,
	[RegisterDate] [datetime] NULL,
	[ExternalAdvertiserID] [varchar](50) NULL,
	[VideoLink] [varchar](500) NULL,
	[Industry] [varchar](100) NULL,
	[NominatedCompanyRole] [varchar](500) NULL,
	[NominatedCompanyFirstName] [varchar](510) NULL,
	[NominatedCompanyLastName] [nvarchar](510) NULL,
	[NominatedCompanyEmailAddress] [nvarchar](255) NULL,
	[NominatedCompanyPhone] [varchar](40) NULL,
	[PreferredContactMethod] [int] NULL,
	[AdvertiserLogoURL] [nvarchar](1000) NULL,
 CONSTRAINT [PK__tmp_ms_xx_Advert__01892CED] PRIMARY KEY CLUSTERED 
(
	[AdvertiserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET ANSI_PADDING ON

ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__Adver__0559BDD1] FOREIGN KEY([AdvertiserAccountStatusID])
REFERENCES [dbo].[AdvertiserAccountStatus] ([AdvertiserAccountStatusID])

ALTER TABLE [dbo].[Advertisers] CHECK CONSTRAINT [FK__Advertise__Adver__0559BDD1]

ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__Adver__064DE20A] FOREIGN KEY([AdvertiserBusinessTypeID])
REFERENCES [dbo].[AdvertiserBusinessType] ([AdvertiserBusinessTypeID])

ALTER TABLE [dbo].[Advertisers] CHECK CONSTRAINT [FK__Advertise__Adver__064DE20A]

ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__Adver__07420643] FOREIGN KEY([AdvertiserAccountTypeID])
REFERENCES [dbo].[AdvertiserAccountType] ([AdvertiserAccountTypeID])

ALTER TABLE [dbo].[Advertisers] CHECK CONSTRAINT [FK__Advertise__Adver__07420643]

ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__LastM__092A4EB5] FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])

ALTER TABLE [dbo].[Advertisers] CHECK CONSTRAINT [FK__Advertise__LastM__092A4EB5]

ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__SiteI__08362A7C] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[Advertisers] CHECK CONSTRAINT [FK__Advertise__SiteI__08362A7C]

ALTER TABLE [dbo].[Advertisers] ADD  CONSTRAINT [DF__tmp_ms_xx__LastM__027D5126]  DEFAULT (getdate()) FOR [LastModified]

ALTER TABLE [dbo].[Advertisers] ADD  CONSTRAINT [DF__tmp_ms_xx__Requi__0371755F]  DEFAULT ((0)) FOR [RequireLogonForExternalApplication]

END
GO

-- JobTemplates

IF OBJECT_ID('dbo.JobTemplates', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'JobTemplateLogoURL' AND OBJECT_ID = OBJECT_ID(N'JobTemplates'))
	BEGIN
		ALTER TABLE JobTemplates ADD JobTemplateLogoURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 

CREATE TABLE [dbo].[JobTemplates](
	[JobTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NULL,
	[JobTemplateDescription] [varchar](255) NOT NULL,
	[JobTemplateHTML] [ntext] NULL,
	[GlobalTemplate] [bit] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[JobTemplateLogo] [image] NULL,
	[AdvertiserID] [int] NOT NULL,
	[JobTemplateLogoURL] [nvarchar](1000) NULL,
 CONSTRAINT [PK__JobTemplates__5F09F7B7] PRIMARY KEY CLUSTERED 
(
	[JobTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET ANSI_PADDING ON

ALTER TABLE [dbo].[JobTemplates]  WITH CHECK ADD  CONSTRAINT [FK__JobTempla__Adver__2C5C4C1E] FOREIGN KEY([AdvertiserID])
REFERENCES [dbo].[Advertisers] ([AdvertiserID])

ALTER TABLE [dbo].[JobTemplates] CHECK CONSTRAINT [FK__JobTempla__Adver__2C5C4C1E]

ALTER TABLE [dbo].[JobTemplates]  WITH CHECK ADD  CONSTRAINT [FK__JobTempla__LastM__61E66462] FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])

ALTER TABLE [dbo].[JobTemplates] CHECK CONSTRAINT [FK__JobTempla__LastM__61E66462]

ALTER TABLE [dbo].[JobTemplates]  WITH CHECK ADD  CONSTRAINT [FK__JobTempla__SiteI__5FFE1BF0] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[JobTemplates] CHECK CONSTRAINT [FK__JobTempla__SiteI__5FFE1BF0]

ALTER TABLE [dbo].[JobTemplates] ADD  CONSTRAINT [DF__JobTempla__Globa__60F24029]  DEFAULT ((0)) FOR [GlobalTemplate]

END
GO

-- AdvertiserJobTemplateLogo

IF OBJECT_ID('dbo.AdvertiserJobTemplateLogo', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'JobTemplateLogoURL' AND OBJECT_ID = OBJECT_ID(N'AdvertiserJobTemplateLogo'))
	BEGIN
		ALTER TABLE AdvertiserJobTemplateLogo ADD JobTemplateLogoURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 

CREATE TABLE [dbo].[AdvertiserJobTemplateLogo](
	[AdvertiserJobTemplateLogoID] [int] IDENTITY(1,1) NOT NULL,
	[AdvertiserID] [int] NOT NULL,
	[JobLogoName] [nvarchar](255) NOT NULL,
	[JobTemplateLogo] [image] NOT NULL,
	[JobTemplateLogoURL] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdvertiserJobTemplateLogoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[AdvertiserJobTemplateLogo]  WITH CHECK ADD  CONSTRAINT [FK__Advertise__Adver__6C9A93AD] FOREIGN KEY([AdvertiserID])
REFERENCES [dbo].[Advertisers] ([AdvertiserID])

ALTER TABLE [dbo].[AdvertiserJobTemplateLogo] CHECK CONSTRAINT [FK__Advertise__Adver__6C9A93AD]

END
GO

-- MemberFiles
IF OBJECT_ID('dbo.MemberFiles', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'MemberFileURL' AND OBJECT_ID = OBJECT_ID(N'MemberFiles'))
	BEGIN
		ALTER TABLE MemberFiles ADD MemberFileURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 

CREATE TABLE [dbo].[MemberFiles](
	[MemberFileID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[MemberFileTypeID] [int] NOT NULL,
	[MemberFileName] [nvarchar](500) NOT NULL,
	[MemberFileSearchExtension] [varchar](8) NULL,
	[MemberFileContent] [image] NULL,
	[MemberFileTitle] [nvarchar](500) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[DocumentTypeID] [int] NULL,
	[MemberFileURL] [nvarchar](1000) NULL,
 CONSTRAINT [PK__MemberFiles__267ABA7A] PRIMARY KEY CLUSTERED 
(
	[MemberFileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET ANSI_PADDING ON

ALTER TABLE [dbo].[MemberFiles]  WITH CHECK ADD  CONSTRAINT [FK__MemberFil__Membe__76969D2E] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])

ALTER TABLE [dbo].[MemberFiles] CHECK CONSTRAINT [FK__MemberFil__Membe__76969D2E]

ALTER TABLE [dbo].[MemberFiles]  WITH CHECK ADD  CONSTRAINT [FK__MemberFil__Membe__778AC167] FOREIGN KEY([MemberFileTypeID])
REFERENCES [dbo].[MemberFileTypes] ([MemberFileTypeID])

ALTER TABLE [dbo].[MemberFiles] CHECK CONSTRAINT [FK__MemberFil__Membe__778AC167]

ALTER TABLE [dbo].[MemberFiles] ADD  CONSTRAINT [DF__MemberFil__LastM__4F7CD00D]  DEFAULT (getdate()) FOR [LastModifiedDate]

END
GO
-- Consultants
IF OBJECT_ID('dbo.Consultants', 'U') IS NOT NULL
BEGIN
	-- Check if URL Column Exists
	IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'ConsultantImageURL' AND OBJECT_ID = OBJECT_ID(N'Consultants'))
	BEGIN
		ALTER TABLE Consultants ADD ConsultantImageURL NVARCHAR(1000) NULL
	END 
END
ELSE
BEGIN 

CREATE TABLE [dbo].[Consultants](
	[ConsultantID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[LanguageID] [int] NULL,
	[Title] [nvarchar](128) NULL,
	[FirstName] [nvarchar](512) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](512) NULL,
	[Mobile] [varchar](512) NULL,
	[PositionTitle] [nvarchar](128) NULL,
	[OfficeLocation] [nvarchar](1024) NULL,
	[Categories] [nvarchar](1024) NULL,
	[Location] [nvarchar](1024) NULL,
	[FriendlyURL] [varchar](128) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[Testimonial] [nvarchar](max) NULL,
	[FullDescription] [nvarchar](max) NULL,
	[ConsultantData] [nvarchar](max) NULL,
	[LinkedInURL] [varchar](512) NULL,
	[TwitterURL] [varchar](512) NULL,
	[FacebookURL] [varchar](512) NULL,
	[GoogleURL] [varchar](512) NULL,
	[Link] [varchar](512) NULL,
	[WechatURL] [varchar](512) NULL,
	[FeaturedTeamMember] [int] NOT NULL,
	[ImageURL] [image] NULL,
	[VideoURL] [varchar](512) NULL,
	[BlogRSS] [varchar](512) NULL,
	[NewsRSS] [varchar](512) NULL,
	[JobRSS] [varchar](512) NULL,
	[TestimonialsRSS] [varchar](512) NULL,
	[Valid] [int] NOT NULL,
	[MetaTitle] [nvarchar](510) NULL,
	[MetaDescription] [nvarchar](1024) NULL,
	[MetaKeywords] [nvarchar](510) NULL,
	[LastModifiedBy] [int] NULL,
	[LastModified] [datetime] NULL,
	[Sequence] [int] NOT NULL,
	[LastName] [nvarchar](512) NULL,
	[ConsultantsXML] [nvarchar](max) NULL,
	[ConsultantImageURL] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConsultantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_PADDING ON

ALTER TABLE [dbo].[Consultants]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])

ALTER TABLE [dbo].[Consultants] ADD  DEFAULT ((0)) FOR [FeaturedTeamMember]

ALTER TABLE [dbo].[Consultants] ADD  DEFAULT ((0)) FOR [Valid]

ALTER TABLE [dbo].[Consultants] ADD  DEFAULT ((0)) FOR [Sequence]

END
GO
-- ViewJobsArchive - AdvertiserLogo
IF EXISTS (SELECT * FROM sys.objects
        WHERE object_id = OBJECT_ID('dbo.ViewJobsArchive')
                AND type = 'V') 
BEGIN
	DROP VIEW dbo.ViewJobsArchive
END
GO

CREATE VIEW [dbo].[ViewJobsArchive]            
AS  
SELECT [Jobs].[JobID]            
 ,[Jobs].[SiteID]            
 ,[Jobs].[WorkTypeID]            
 ,[Jobs].[JobName]            
 ,[Jobs].[Description]            
 ,[Jobs].[FullDescription]            
 ,[Jobs].[WebServiceProcessed]            
 ,[Jobs].[ApplicationEmailAddress]            
 ,[Jobs].[RefNo]            
 ,[Jobs].[Visible]            
 ,[Jobs].[DatePosted]            
 ,[Jobs].[ExpiryDate]            
 ,[Jobs].[Expired]            
 ,[Jobs].[JobItemPrice]            
 ,[Jobs].[Billed]            
 ,[Jobs].[LastModified]            
 ,[Jobs].[ShowSalaryDetails]            
 ,[Jobs].[ShowSalaryRange]            
 ,[Jobs].[SalaryText]            
 ,[Jobs].[AdvertiserID]            
 ,[Jobs].[LastModifiedByAdvertiserUserId]            
 ,[Jobs].[LastModifiedByAdminUserId]            
 ,[Jobs].[JobItemTypeID]            
 ,[Jobs].[ApplicationMethod]            
 ,[Jobs].[ApplicationURL]            
 ,[Jobs].[UploadMethod]            
 ,[Jobs].[Tags]            
 ,[Jobs].[JobTemplateID]            
 ,[Jobs].[SearchField]            
 ,[Jobs].[AdvertiserJobTemplateLogoID]            
 ,[Jobs].[CompanyName]            
 ,[Jobs].[HashValue]            
 ,[Jobs].[RequireLogonForExternalApplications]            
 ,[Jobs].[ShowLocationDetails]            
 ,[Jobs].[PublicTransport]            
 ,[Jobs].[Address]            
 ,[Jobs].[ContactDetails]            
 ,[Jobs].[JobContactPhone]            
 ,[Jobs].[JobContactName]            
 ,[Jobs].[QualificationsRecognised]            
 ,[Jobs].[ResidentOnly]            
 ,[Jobs].[DocumentLink]            
 ,[Jobs].[BulletPoint1]            
 ,[Jobs].[BulletPoint2]            
 ,[Jobs].[BulletPoint3]            
 ,[Jobs].[HotJob]            
 ,[Advertisers].[CompanyName] AS AdvertiserCompanyName            
 ,[Advertisers].[BusinessNumber]            
 ,[Advertisers].[StreetAddress1]            
 ,[Advertisers].[StreetAddress2]            
 ,[Advertisers].[WebAddress]            
 ,[Advertisers].[Profile]            
 ,[Advertisers].[RequireLogonForExternalApplication]            
 ,[Advertisers].[AdvertiserLogo]            
 ,[Advertisers].[AdvertiserLogoURL]            
 ,[SiteWorkType].[SiteWorkTypeName]
 ,[Currencies].[CurrencySymbol]            
 ,[Jobs].[SalaryUpperBand]            
 ,[Jobs].[SalaryLowerBand]
 ,[Jobs].[SalaryTypeID]            
 ,[JobTemplates].[JobTemplateHTML]            
 ,[SiteSalaryType].[SalaryTypeName]            
 ,[SiteArea].[SiteAreaName]            
 ,[SiteLocation].[SiteLocationName]            
 ,[SiteRoles].[SiteRoleName]            
 ,[SiteProfession].SiteProfessionName            
 ,'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'    
 ,[Roles].ProfessionID    
 ,[Roles].RoleID
 ,Area.LocationID 
	 ,[JobArea].AreaID 
 ,CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay
FROM [dbo].[JobsArchive] Jobs (NOLOCK)            
 INNER JOIN [dbo].[Advertisers] Advertisers (NOLOCK)            
 ON Jobs.AdvertiserID = Advertisers.AdvertiserID            
      
 INNER JOIN [dbo].[SiteWorkType] SiteWorkType (NOLOCK)            
 ON [Jobs].WorkTypeID = [SiteWorkType].WorkTypeID              
 AND SiteWorkType.SiteID = Jobs.SiteID            

 INNER JOIN [dbo].[SiteCurrencies] SiteCurrencies (NOLOCK)
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID
 
 INNER JOIN [dbo].[Currencies] Currencies (NOLOCK)
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID
 AND [SiteCurrencies].SiteID = Jobs.SiteID
 
 INNER JOIN [dbo].[SiteSalaryType] SiteSalaryType (NOLOCK)            
 ON [SiteSalaryType].SalaryTypeID = [Jobs].[SalaryTypeID]           
 AND [SiteSalaryType].SiteID = Jobs.SiteID          
      
 INNER JOIN [dbo].[JobTemplates] JobTemplates (NOLOCK)            
 ON [JobTemplates].[JobTemplateID] = [Jobs].[JobTemplateID]            
      
 INNER JOIN [dbo].[JobArea] JobArea (NOLOCK)            
 ON [JobArea].[JobID] = [Jobs].[JobID]            
 INNER JOIN [dbo].[SiteArea] SiteArea (NOLOCK)            
 ON [SiteArea].AreaID = [JobArea].AreaID          
 AND SiteArea.Siteid = Jobs.SiteID            
 INNER JOIN [dbo].[Area] Area (NOLOCK)            
 ON [Area].AreaID = [SiteArea].[AreaID]            
 INNER JOIN [dbo].[SiteLocation] SiteLocation (NOLOCK)            
 ON [SiteLocation].LocationID = Area.LocationID          
 AND SiteLocation.Siteid = Jobs.SiteID        
      
 INNER JOIN [dbo].[JobRoles] JobRoles (NOLOCK)            
 ON [JobRoles].[JobID] = [Jobs].[JobID]            
 INNER JOIN [dbo].[SiteRoles] SiteRoles (NOLOCK)            
 ON [SiteRoles].[RoleID] = [JobRoles].[RoleID]         
 AND SiteRoles.SiteID = Jobs.SiteID              
 INNER JOIN [dbo].[Roles] Roles (NOLOCK)            
 ON [Roles].RoleID = [SiteRoles].RoleID            
 INNER JOIN [dbo].[SiteProfession] SiteProfession (NOLOCK)            
 ON [SiteProfession].ProfessionID = [Roles].ProfessionID          
 AND SiteProfession.SiteID = Jobs.SiteID    

GO

-- ViewJobs - AdvertiserLogo

IF EXISTS (SELECT * FROM sys.objects
        WHERE object_id = OBJECT_ID('dbo.ViewJobs')
                AND type = 'V') 
BEGIN
	DROP VIEW dbo.ViewJobs
END
GO

CREATE VIEW [dbo].[ViewJobs]            
AS    
SELECT [Jobs].[JobID]            
 ,[Jobs].[SiteID]            
 ,[Jobs].[WorkTypeID]            
 ,[Jobs].[JobName]            
 ,[Jobs].[Description]            
 ,[Jobs].[FullDescription]            
 ,[Jobs].[WebServiceProcessed]            
 ,[Jobs].[ApplicationEmailAddress]            
 ,[Jobs].[RefNo]            
 ,[Jobs].[Visible]            
 ,[Jobs].[DatePosted]            
 ,[Jobs].[ExpiryDate]            
 ,[Jobs].[Expired]            
 ,[Jobs].[JobItemPrice]            
 ,[Jobs].[Billed]            
 ,[Jobs].[LastModified]            
 ,[Jobs].[ShowSalaryDetails]            
 ,[Jobs].[ShowSalaryRange]            
 ,[Jobs].[SalaryText]            
 ,[Jobs].[AdvertiserID]            
 ,[Jobs].[LastModifiedByAdvertiserUserId]            
 ,[Jobs].[LastModifiedByAdminUserId]            
 ,[Jobs].[JobItemTypeID]            
 ,[Jobs].[ApplicationMethod]            
 ,[Jobs].[ApplicationURL]            
 ,[Jobs].[UploadMethod]            
 ,[Jobs].[Tags]            
 ,[Jobs].[JobTemplateID]            
 ,[Jobs].[SearchField]            
 ,[Jobs].[AdvertiserJobTemplateLogoID]            
 ,[Jobs].[CompanyName]            
 ,[Jobs].[HashValue]            
 ,[Jobs].[RequireLogonForExternalApplications]            
 ,[Jobs].[ShowLocationDetails]            
 ,[Jobs].[PublicTransport]            
 ,[Jobs].[Address]            
 ,[Jobs].[ContactDetails]            
 ,[Jobs].[JobContactPhone]            
 ,[Jobs].[JobContactName]            
 ,[Jobs].[QualificationsRecognised]            
 ,[Jobs].[ResidentOnly]            
 ,[Jobs].[DocumentLink]            
 ,[Jobs].[BulletPoint1]            
 ,[Jobs].[BulletPoint2]            
 ,[Jobs].[BulletPoint3]            
 ,[Jobs].[HotJob]            
 ,[Advertisers].[CompanyName] AS AdvertiserCompanyName            
 ,[Advertisers].[BusinessNumber]            
 ,[Advertisers].[StreetAddress1]            
 ,[Advertisers].[StreetAddress2]            
 ,[Advertisers].[WebAddress]            
 ,[Advertisers].[Profile]            
 ,[Advertisers].[RequireLogonForExternalApplication]            
 ,[Advertisers].[AdvertiserLogo]
 ,[Advertisers].[AdvertiserLogoURL]                        
 ,[SiteWorkType].[SiteWorkTypeName]
 ,[Currencies].[CurrencySymbol]            
 ,[Jobs].[SalaryUpperBand]            
 ,[Jobs].[SalaryLowerBand]
 ,[Jobs].[SalaryTypeID]            
 ,[JobTemplates].[JobTemplateHTML]            
 ,[SiteSalaryType].[SalaryTypeName]            
 ,[SiteArea].[SiteAreaName]            
 ,[SiteLocation].[SiteLocationName]            
 ,[SiteRoles].[SiteRoleName]
	  ,SiteRoles.[CanonicalUrl] AS 'SiteRoleCanonicalUrl'            
 ,[SiteProfession].SiteProfessionName
	  ,SiteProfession.[CanonicalUrl] AS 'SiteProfessionCanonicalUrl'            
 ,'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'    
 ,[Roles].ProfessionID    
 ,[Roles].RoleID
 ,Area.LocationID 
 ,[JobArea].AreaID 
-- ,CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + CAST(Jobs.SalaryLowerBand AS NVARCHAR(20)) + '-' + CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + CAST(Jobs.SalaryUpperBand AS NVARCHAR(20)) + ' ' + [SiteSalaryType].SalaryTypeName AS SalaryDisplay    
 ,CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay
FROM [dbo].[Jobs] Jobs (NOLOCK)            
 INNER JOIN [dbo].[Advertisers] Advertisers (NOLOCK)            
 ON Jobs.AdvertiserID = Advertisers.AdvertiserID            
      
 INNER JOIN [dbo].[SiteWorkType] SiteWorkType (NOLOCK)            
 ON [Jobs].WorkTypeID = [SiteWorkType].WorkTypeID              
 AND SiteWorkType.SiteID = Jobs.SiteID            

 INNER JOIN [dbo].[SiteCurrencies] SiteCurrencies (NOLOCK)
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID
 AND [SiteCurrencies].SiteID = Jobs.SiteID

 INNER JOIN [dbo].[Currencies] Currencies (NOLOCK)
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID
     
 INNER JOIN [dbo].[SiteSalaryType] SiteSalaryType (NOLOCK)            
 ON [SiteSalaryType].SalaryTypeID = [Jobs].[SalaryTypeID]           
 AND [SiteSalaryType].SiteID = Jobs.SiteID          
      
 INNER JOIN [dbo].[JobTemplates] JobTemplates (NOLOCK)            
 ON [JobTemplates].[JobTemplateID] = [Jobs].[JobTemplateID]            
      
 INNER JOIN [dbo].[JobArea] JobArea (NOLOCK)            
 ON [JobArea].[JobID] = [Jobs].[JobID]            
 INNER JOIN [dbo].[SiteArea] SiteArea (NOLOCK)         
 ON [SiteArea].AreaID = [JobArea].AreaID          
 AND SiteArea.Siteid = Jobs.SiteID            
 INNER JOIN [dbo].[Area] Area (NOLOCK)            
 ON [Area].AreaID = [SiteArea].[AreaID]            
 INNER JOIN [dbo].[SiteLocation] SiteLocation (NOLOCK)            
 ON [SiteLocation].LocationID = Area.LocationID          
 AND SiteLocation.Siteid = Jobs.SiteID        
      
 INNER JOIN [dbo].[JobRoles] JobRoles (NOLOCK)            
 ON [JobRoles].[JobID] = [Jobs].[JobID]            
 INNER JOIN [dbo].[SiteRoles] SiteRoles (NOLOCK)            
 ON [SiteRoles].[RoleID] = [JobRoles].[RoleID]         
 AND SiteRoles.SiteID = Jobs.SiteID              
 INNER JOIN [dbo].[Roles] Roles (NOLOCK)            
 ON [Roles].RoleID = [SiteRoles].RoleID            
 INNER JOIN [dbo].[SiteProfession] SiteProfession (NOLOCK)            
 ON [SiteProfession].ProfessionID = [Roles].ProfessionID          
 AND SiteProfession.SiteID = Jobs.SiteID




GO


