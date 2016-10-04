CREATE PROCEDURE [dbo].[Location_GetSiteTree]    
(    
 @SiteID int    
)    
AS    
BEGIN    
DECLARE @Location TABLE      
(      
 [LocationID] INT,      
 [LocationName] VARCHAR(255),      
 [CountryID] INT,  
 [SiteLocationID] INT,      
 [SiteLocationName] NVARCHAR(255),   
 [Valid] BIT,      
 [SiteLocationFriendlyUrl] VARCHAR(255)    
)     
    
INSERT INTO @Location (LocationID, LocationName, CountryID)    
SELECT LocationID, LocationName, CountryID FROM Location (NOLOCK)    
    
UPDATE @Location     
SET SiteLocationID = sl.SiteLocationID,    
SiteLocationName = sl.SiteLocationName,    
Valid = sl.Valid,  
SiteLocationFriendlyUrl = sl.SiteLocationFriendlyUrl    
FROM SiteLocation sl (NOLOCK)    
INNER JOIN @Location l  
ON sl.LocationID = l.LocationID    
WHERE SiteID = @SiteID    
    
SELECT LocationID, LocationName, CountryID, ISNULL(SiteLocationID, '') AS SiteLocationID, ISNULL(SiteLocationName, '') AS SiteLocationName,      
ISNULL(Valid, '') AS Valid, ISNULL(SiteLocationFriendlyUrl, '') AS SiteLocationFriendlyUrl  
FROM @Location   
ORDER BY LocationName, SiteLocationName  
    
END  