CREATE TABLE [dbo].[SiteLocation]
(
	SiteLocationID INT IDENTITY(1,1) PRIMARY KEY,
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	LocationID INT NOT NULL REFERENCES Location(LocationID),
	SiteLocationName NVARCHAR(510) NOT NULL,
	Valid BIT NOT NULL DEFAULT(1),
	SiteLocationFriendlyUrl VARCHAR(255) NULL
)
