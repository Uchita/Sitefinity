CREATE TABLE [dbo].[DynamicPageTemplates]
(
	DynamicPageTemplateID	INT IDENTITY(1,1) PRIMARY KEY,
	SiteID					INT, 
	DynamicPageTemplateName NVARCHAR(500),
	LastModified			DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy			INT	NOT NULL REFERENCES AdminUsers(AdminUserID)	
)
