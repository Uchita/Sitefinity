  
CREATE PROCEDURE [dbo].[Area_GetDetailWithSite]    
(    
 @SiteID int,  
 @AreaId int = 0  
)    
AS    
BEGIN    
DECLARE @Area TABLE      
(      
 [CountryID] INT,      
 [CountryName] VARCHAR(255),      
 [SiteCountryID] INT,      
 [SiteCountryName] NVARCHAR(255),   
 [SiteCountryFriendlyUrl] VARCHAR(255),  
 [LocationID] INT,      
 [LocationName] VARCHAR(255),      
 [SiteLocationID] INT,      
 [SiteLocationName] NVARCHAR(255),   
 [Valid] BIT,      
 [SiteLocationFriendlyUrl] VARCHAR(255),  
 [AreaID] INT,      
 [AreaName] VARCHAR(255),      
 [SiteAreaID] INT,      
 [SiteAreaName] NVARCHAR(255),   
 [AreaValid] BIT    
)     
  
INSERT INTO @Area (CountryID, CountryName, LocationID, LocationName, AreaID, AreaName)  
SELECT c.CountryID, CountryName, l.LocationID, LocationName, AreaID, AreaName  
FROM Area a (NOLOCK)  
INNER JOIN Location l (NOLOCK) ON a.LocationID = l.LocationID  
INNER JOIN Countries c (NOLOCK) ON l.CountryID = c.CountryID  
WHERE (@AreaId = 0 OR AreaID = @AreaId)  
  
UPDATE @Area     
SET SiteCountryID = sc.SiteCountryID,    
SiteCountryName = sc.SiteCountryName,    
SiteCountryFriendlyUrl = sc.SiteCountryFriendlyUrl    
FROM SiteCountries sc (NOLOCK)    
INNER JOIN @Area c  
ON sc.CountryID = c.CountryID    
WHERE SiteID = @SiteID    
  
UPDATE @Area     
SET SiteLocationID = sl.SiteLocationID,    
SiteLocationName = sl.SiteLocationName,    
Valid = sl.Valid,  
SiteLocationFriendlyUrl = sl.SiteLocationFriendlyUrl    
FROM SiteLocation sl (NOLOCK)    
INNER JOIN @Area l  
ON sl.LocationID = l.LocationID    
WHERE SiteID = @SiteID    
  
UPDATE @Area     
SET SiteAreaID = sa.SiteAreaID,    
SiteAreaName = sa.SiteAreaName,    
AreaValid = sa.Valid  
FROM SiteArea sa (NOLOCK)    
INNER JOIN @Area a  
ON sa.AreaID = a.AreaID    
WHERE SiteID = @SiteID    
    
SELECT CountryID,      
 CountryName,      
 ISNULL(SiteCountryID, '') AS SiteCountryID,      
 ISNULL(SiteCountryName, CountryName) AS SiteCountryName,   
 ISNULL(SiteCountryFriendlyUrl, '') AS SiteCountryFriendlyUrl,  
 LocationID,      
 LocationName,      
 ISNULL(SiteLocationID, '') AS SiteLocationID,      
 ISNULL(SiteLocationName, LocationName) AS SiteLocationName,   
 ISNULL(Valid, '') AS Valid,      
 ISNULL(SiteLocationFriendlyUrl, '') AS SiteLocationFriendlyUrl,  
 AreaID,      
 AreaName,      
 ISNULL(SiteAreaID, '') AS SiteAreaID,  
 ISNULL(SiteAreaName, AreaName) AS SiteAreaName,   
 ISNULL(AreaValid, '') AS AreaValid  
FROM @Area   
    
END  