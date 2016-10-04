CREATE TABLE [dbo].[EmailTemplates]
(
	EmailTemplateID INT PRIMARY KEY IDENTITY(1,1),
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	EmailTemplateParentID INT NOT NULL, 
	EmailCode VARCHAR(255) NOT NULL,
	EmailDescription VARCHAR(255) NOT NULL,		
	EmailSubject NVARCHAR(510) NOT NULL,
	EmailBodyText NTEXT,
	EmailBodyHTML NTEXT,
	EmailFields NTEXT,
	EmailAddressName VARCHAR(255),
	EmailAddressFrom VARCHAR(255),
	EmailAddressCC  VARCHAR(512),
	EmailAddressBCC VARCHAR(512), 
	GlobalTemplate	BIT NOT NULL DEFAULT(0),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	LastModified DATETIME NOT NULL
)
