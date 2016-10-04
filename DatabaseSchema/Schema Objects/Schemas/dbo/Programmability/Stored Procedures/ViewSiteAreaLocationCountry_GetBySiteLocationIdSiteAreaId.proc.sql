CREATE PROCEDURE [dbo].[ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId]
	@SiteLocationId INT = 0,
	@SiteAreaId INT  = 0
AS
	SELECT [AreaID]
      ,[CountryID]
      ,[SiteLocationID]
      ,[LocationID]
      ,[SiteAreaID]
      ,[SiteAreaName]
      ,[SiteID]
      ,[SiteLocationName]
      ,[SiteCountryName]
      ,[SiteCountryID]
  FROM [dbo].[ViewSiteAreaLocationCountry]
  WHERE ((@SiteLocationId = 0) OR (SiteLocationId = @SiteLocationId))
  AND ((@SiteAreaId = 0) OR (SiteAreaId = @SiteAreaId))