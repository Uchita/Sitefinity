﻿CREATE TABLE [dbo].[SiteRoles]
(
	SiteRoleID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	RoleID INT NOT NULL REFERENCES Roles(RoleID),
	SiteRoleName NVARCHAR(510) NOT NULL,
	Valid BIT NOT NULL DEFAULT(1),
	MetaTitle				VARCHAR(255) NOT NULL,
	MetaKeywords			VARCHAR(255) NOT NULL,
	MetaDescription			VARCHAR(512) NOT NULL,
	Sequence INT NOT NULL DEFAULT(0),
	SiteRoleFriendlyUrl VARCHAR(255) NULL
)
