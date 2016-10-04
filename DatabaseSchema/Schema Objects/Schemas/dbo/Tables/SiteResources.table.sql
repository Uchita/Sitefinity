CREATE TABLE [dbo].[SiteResources]
(
	SiteResourceID		INT IDENTITY(1,1) PRIMARY KEY, 
	SiteID				INT NOT NULL REFERENCES Sites(SiteID),
	LanguageID			INT NOT NULL REFERENCES Languages(LanguageID),
	ResourceCode		VARCHAR(255) NOT NULL REFERENCES DefaultResources(ResourceCode),
	ResourceFileID		INT REFERENCES Files(FileID),
	ResourceText		NVARCHAR(MAX),
	LastModified		DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy		INT NOT NULL REFERENCES AdminUsers(AdminUserID)
)
