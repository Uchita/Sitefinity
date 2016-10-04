CREATE TABLE [dbo].[JobTemplates]
(
	JobTemplateID INT PRIMARY KEY IDENTITY(1,1),
	SiteID INT NULL REFERENCES Sites(SiteID),
	JobTemplateDescription VARCHAR(255) NOT NULL,		
	JobTemplateHTML NTEXT,
	JobTemplateLogo IMAGE NULL,
	GlobalTemplate	BIT NOT NULL DEFAULT(0),
	AdvertiserID INT NOT NULL REFERENCES Advertisers(AdvertiserID),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	LastModified DATETIME NOT NULL
)
