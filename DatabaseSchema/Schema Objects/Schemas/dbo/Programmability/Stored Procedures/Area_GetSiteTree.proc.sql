CREATE PROCEDURE [dbo].[Area_GetSiteTree]    
(    
 @SiteID int    
)    
AS    
BEGIN    
DECLARE @Area TABLE      
(      
 [AreaID] INT,      
 [AreaName] VARCHAR(255),      
 [LocationID] INT,  
 [SiteAreaID] INT,      
 [SiteAreaName] NVARCHAR(255),   
 [Valid] BIT  
)     
    
INSERT INTO @Area (AreaID, AreaName, LocationID)    
SELECT AreaID, AreaName, LocationID FROM Area (NOLOCK)    
    
UPDATE @Area     
SET SiteAreaID = sa.SiteAreaID,    
SiteAreaName = sa.SiteAreaName,    
Valid = sa.Valid  
FROM SiteArea sa (NOLOCK)    
INNER JOIN @Area a  
ON sa.AreaID = a.AreaID    
WHERE SiteID = @SiteID    
    
SELECT AreaID, AreaName, LocationID, ISNULL(SiteAreaID, '') AS SiteAreaID, ISNULL(SiteAreaName, '') AS SiteAreaName,      
ISNULL(Valid, '') AS Valid  
FROM @Area   
ORDER BY AreaName, SiteAreaName  
    
END  