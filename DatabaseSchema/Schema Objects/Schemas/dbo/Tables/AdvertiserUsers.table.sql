CREATE TABLE [dbo].[AdvertiserUsers]
(
	AdvertiserUserID INT IDENTITY(1,1) PRIMARY KEY,
	AdvertiserID INT NOT NULL REFERENCES Advertisers(AdvertiserID),
	PrimaryAccount BIT NOT NULL DEFAULT(0),
	UserName VARCHAR(255) NOT NULL,
	UserPassword VARCHAR(255) NOT NULL,
	FirstName NVARCHAR(500) NOT NULL,
	Surname NVARCHAR(500) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	ApplicationEmailAddress VARCHAR(255),
	Phone CHAR(40),
	Fax CHAR(40),
	AccountStatus INT,
	Newsletter BIT DEFAULT(0) NOT NULL,
	NewsletterFormat INT NOT NULL REFERENCES EmailFormats(EmailFormatID),
	EmailFormat INT NOT NULL REFERENCES EmailFormats(EmailFormatID),
	Validated	BIT DEFAULT(0),
	ValidateGUID UNIQUEIDENTIFIER,
	Description NTEXT,
	LastLoginDate DATETIME DEFAULT(GETDATE()),
	LastModified DATETIME DEFAULT(GETDATE()),
	LastModifiedBy INT NOT NULL REFERENCES AdminUsers(AdminUserID)
)
