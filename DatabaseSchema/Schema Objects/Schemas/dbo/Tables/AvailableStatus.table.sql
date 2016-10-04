CREATE TABLE [dbo].[AvailableStatus]
(
	AvailableStatusID INT PRIMARY KEY IDENTITY(1,1), 
	SiteID INT REFERENCES Sites(SiteID),
	AvailableStatusParentID INT NOT NULL, 
	AvailableStatusName NVARCHAR(512) NOT NULL,
	GlobalTemplate	BIT NOT NULL DEFAULT(0),
	Sequence INT NOT NULL DEFAULT(0),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	LastModified DATETIME NOT NULL
)
