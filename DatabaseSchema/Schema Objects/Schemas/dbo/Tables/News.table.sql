CREATE TABLE [dbo].[News]
(
	NewsID INT IDENTITY(1,1) PRIMARY KEY,
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	NewsCategoryID INT NOT NULL REFERENCES NewsCategories(NewsCategoryID),
	Subject NVARCHAR(255) NOT NULL,
	Content NTEXT,
	PostDate SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
	Valid BIT DEFAULT(0),
	Sequence INT DEFAULT(0),
	LastModified DATETIME DEFAULT(GETDATE()),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	SearchField nvarchar(max),
	Tags NVARCHAR(250),
	MetaTitle				VARCHAR(255),
	MetaKeywords			VARCHAR(255),
	MetaDescription			VARCHAR(512),
	PageFriendlyName		VARCHAR(255) NOT NULL DEFAULT(''),
	
)
