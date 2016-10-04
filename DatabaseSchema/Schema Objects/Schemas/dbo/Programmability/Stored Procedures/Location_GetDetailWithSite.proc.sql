  
CREATE PROCEDURE [dbo].[Location_GetDetailWithSite]    
(    
 @SiteID int,  
 @LocationId int = 0  
)    
AS    
BEGIN    
DECLARE @Location TABLE      
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
 [SiteLocationFriendlyUrl] VARCHAR(255)    
)     
  
INSERT INTO @Location (CountryID, CountryName, LocationID, LocationName)  
SELECT c.CountryID, CountryName, LocationID, LocationName FROM Location l (NOLOCK)  
INNER JOIN Countries c (NOLOCK) ON l.CountryID = c.CountryID  
WHERE (@LocationId = 0 OR LocationID = @LocationId)  
  
UPDATE @Location     
SET SiteCountryID = sc.SiteCountryID,    
SiteCountryName = sc.SiteCountryName,    
SiteCountryFriendlyUrl = sc.SiteCountryFriendlyUrl    
FROM SiteCountries sc (NOLOCK)    
INNER JOIN @Location c  
ON sc.CountryID = c.CountryID    
WHERE SiteID = @SiteID    
  
UPDATE @Location     
SET SiteLocationID = sl.SiteLocationID,    
SiteLocationName = sl.SiteLocationName,    
Valid = sl.Valid,  
SiteLocationFriendlyUrl = sl.SiteLocationFriendlyUrl    
FROM SiteLocation sl (NOLOCK)    
INNER JOIN @Location l  
ON sl.LocationID = l.LocationID    
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
 ISNULL(SiteLocationFriendlyUrl, '') AS SiteLocationFriendlyUrl  
FROM @Location   
    
END  