CREATE PROCEDURE [dbo].[Countries_GetDetailWithSite]    
(    
 @SiteID int,  
 @CountryId int = 0  
)    
AS    
BEGIN    
DECLARE @Countries TABLE      
(      
 [CountryID] INT,      
 [CountryName] VARCHAR(255),      
 [SiteCountryID] INT,      
 [SiteCountryName] NVARCHAR(255),   
 [SiteCountryFriendlyUrl] VARCHAR(255)    
)     
    
INSERT INTO @Countries (CountryID, CountryName)    
SELECT CountryID, CountryName FROM Countries (NOLOCK)    
WHERE (@CountryId = 0 OR CountryID = @CountryId)  
  
UPDATE @Countries     
SET SiteCountryID = sc.SiteCountryID,    
SiteCountryName = sc.SiteCountryName,    
SiteCountryFriendlyUrl = sc.SiteCountryFriendlyUrl    
FROM SiteCountries sc (NOLOCK)    
INNER JOIN @Countries c  
ON sc.CountryID = c.CountryID    
WHERE SiteID = @SiteID    
    
SELECT CountryID, CountryName, ISNULL(SiteCountryID, '') AS SiteCountryID, ISNULL(SiteCountryName, CountryName) AS SiteCountryName,      
ISNULL(SiteCountryFriendlyUrl, '') AS SiteCountryFriendlyUrl  
FROM @Countries   
ORDER BY CountryName, SiteCountryName  
    
END  