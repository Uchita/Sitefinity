CREATE TABLE [dbo].[DynamicPageWebPartTemplates]
(
	[DynamicPageWebPartTemplateID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DynamicPageWebPartName] [nvarchar](255) NOT NULL,
	[SiteID] [int] NOT NULL REFERENCES Sites(SiteId),
	[LastModified] [datetime] NOT NULL DEFAULT (getdate()),
	[LastModifiedBy] [int] NOT NULL REFERENCES AdminUsers(AdminUserID),
	[SourceID] [int] NULL,
)