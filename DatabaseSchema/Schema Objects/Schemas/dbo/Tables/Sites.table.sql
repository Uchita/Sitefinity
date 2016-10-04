﻿CREATE TABLE Sites
(
	SiteID			INT IDENTITY(1,1) PRIMARY KEY,
	SiteName		VARCHAR(255),
	SiteURL			VARCHAR(500),
	SiteDescription VARCHAR(MAX),
	SiteAdminLogo	IMAGE,
	Live			BIT DEFAULT(0),
	LastModified	DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy	INT REFERENCES AdminUsers(AdminUserID)
)