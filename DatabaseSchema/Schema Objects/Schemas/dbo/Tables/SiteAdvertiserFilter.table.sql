CREATE TABLE [dbo].[SiteAdvertiserFilter]
(
	SiteAdvertiserFilterID INT IDENTITY(1,1) PRIMARY KEY,
	SiteID INT NOT NULL REFERENCES Sites(SiteId),
	AdvertiserID INT NOT NULL REFERENCES Advertisers(AdvertiserID)
)
