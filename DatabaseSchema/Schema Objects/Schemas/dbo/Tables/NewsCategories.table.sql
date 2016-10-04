CREATE TABLE [dbo].[NewsCategories]
(
	NewsCategoryID		INT IDENTITY(1,1) PRIMARY KEY,
	NewsCategoryName	NVARCHAR(500),
	SiteID				INT NOT NULL REFERENCES Sites(SiteID),
	Valid				BIT NOT NULL DEFAULT(0),
	Sequence			INT NOT NULL DEFAULT(0),
	MetaTitle				VARCHAR(255) NOT NULL,
	MetaKeywords			VARCHAR(255) NOT NULL,
	MetaDescription			VARCHAR(512) NOT NULL,
	PageFriendlyName				VARCHAR(255) NOT NULL DEFAULT(''),
	LastModified		DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy		INT NOT NULL REFERENCES AdminUsers(AdminUserID)
)
