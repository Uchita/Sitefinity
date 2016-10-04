CREATE TABLE [dbo].[DefaultResources]
(
	DefaultResourceID	INT IDENTITY(1,1) PRIMARY KEY, 
	ResourceCode		VARCHAR(255) NOT NULL,
	ResourceFileID		INT REFERENCES Files(FileID),
	ResourceText		NVARCHAR(MAX),
	ResourceDescription VARCHAR(255) NOT NULL,
	LastModified		DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy		INT NOT NULL REFERENCES AdminUsers(AdminUserID)
)
