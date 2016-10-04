CREATE PROCEDURE DynamicPages_GetMissingSystemPagesBySiteID  
 @DefaultSiteID INT,  
 @SiteID INT  
AS  
BEGIN  
 SELECT DISTINCT PageName   
 FROM DynamicPages WHERE SiteID = @DefaultSiteID   
 AND PageName NOT IN (SELECT PageName FROM DynamicPages WHERE PageName LIKE 'SystemPage_%' AND SiteID = @SiteID)  
 AND PageName LIKE 'SystemPage_%'  
END  