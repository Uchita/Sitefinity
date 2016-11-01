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