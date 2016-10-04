CREATE TABLE [dbo].[SiteCountries]
(
	SiteCountryID INT PRIMARY KEY IDENTITY(1,1),
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	CountryID INT NOT NULL REFERENCES Countries(CountryID),
	SiteCountryName VARCHAR(255) NOT NULL,
	SiteCountryFriendlyUrl  VARCHAR(255) NULL
)
