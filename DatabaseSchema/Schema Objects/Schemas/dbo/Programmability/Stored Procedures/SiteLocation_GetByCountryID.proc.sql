CREATE PROCEDURE [dbo].[SiteLocation_GetByCountryID]  
 @SiteID INT,   
 @CountryID INT  
AS  
 SELECT  
  [SiteLocation].[SiteLocationID],  
  [SiteLocation].[LocationID],  
  [SiteLocation].[SiteID],  
  [SiteLocation].[SiteLocationName],  
  [SiteLocation].[Valid],
  [SiteLocation].[SiteLocationFriendlyUrl]  
 FROM  
  [dbo].[SiteLocation] (NOLOCK) SiteLocation  
 INNER JOIN [dbo].[Location] (NOLOCK) Location  
 ON [SiteLocation].LocationID = [Location].LocationID  
 AND [SiteLocation].SiteID = @SiteID  
 WHERE [Location].CountryID = @CountryID