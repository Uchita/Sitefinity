CREATE TABLE [dbo].[AdvertiserJobTemplateLogo](
	[AdvertiserJobTemplateLogoID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[AdvertiserID] [int] NOT NULL REFERENCES Advertisers(AdvertiserID),
	[JobLogoName] [nvarchar](255) NOT NULL,
	[JobTemplateLogo] [image] NOT NULL
)