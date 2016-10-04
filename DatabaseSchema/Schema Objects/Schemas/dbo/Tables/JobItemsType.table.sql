CREATE TABLE [dbo].[JobItemsType]
(
	JobItemTypeID INT PRIMARY KEY IDENTITY(1,1),
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	JobItemTypeParentID INT NOT NULL,
	JobItemTypeDescription VARCHAR(255) NOT NULL,		
	GlobalTemplate	BIT NOT NULL DEFAULT(0),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	LastModified DATETIME NOT NULL
)
