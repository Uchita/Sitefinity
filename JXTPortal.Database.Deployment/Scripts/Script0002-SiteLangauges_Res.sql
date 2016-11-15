IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SiteLanguages'))
BEGIN
	CREATE TABLE [dbo].[SiteLanguages](
		[SiteLanguageID] [int] IDENTITY(1,1) NOT NULL,
		[SiteID] [int] NOT NULL,
		[LanguageID] [int] NOT NULL,
		[SiteLanguageName] [nvarchar](255) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[SiteLanguageID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
	 CONSTRAINT [IX_Unique_SiteLanguages] UNIQUE NONCLUSTERED 
	(
		[SiteID] ASC,
		[LanguageID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[SiteLanguages]  WITH CHECK ADD FOREIGN KEY([LanguageID])
	REFERENCES [dbo].[Languages] ([LanguageID])

	ALTER TABLE [dbo].[SiteLanguages]  WITH CHECK ADD FOREIGN KEY([SiteID])
	REFERENCES [dbo].[Sites] ([SiteID])
END

ALTER TABLE [dbo].[SiteLanguages] 
ADD ResourceFileName nvarchar(512) NULL
GO

