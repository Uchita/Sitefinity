CREATE VIEW [dbo].[ViewSiteAreaLocationCountry]
	AS SELECT     dbo.Area.AreaID, dbo.Countries.CountryID, dbo.SiteLocation.SiteLocationID, dbo.Location.LocationID, dbo.SiteArea.SiteAreaID, 
                      dbo.SiteArea.SiteAreaName, dbo.SiteArea.SiteID, dbo.SiteLocation.SiteLocationName, dbo.SiteCountries.SiteCountryName, 
                      dbo.SiteCountries.SiteCountryID
FROM     dbo.Area (NOLOCK)
INNER JOIN dbo.Location (NOLOCK) ON dbo.Area.LocationID = dbo.Location.LocationID 
INNER JOIN dbo.Countries (NOLOCK) ON dbo.Location.CountryID = dbo.Countries.CountryID 
INNER JOIN dbo.SiteArea (NOLOCK) ON dbo.Area.AreaID = dbo.SiteArea.AreaID 
INNER JOIN dbo.SiteCountries (NOLOCK) ON dbo.Countries.CountryID = dbo.SiteCountries.CountryID 
INNER JOIN dbo.SiteLocation (NOLOCK) ON dbo.Location.LocationID = dbo.SiteLocation.LocationId