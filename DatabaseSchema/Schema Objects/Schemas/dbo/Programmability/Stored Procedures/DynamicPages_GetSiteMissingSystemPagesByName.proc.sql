CREATE PROCEDURE DynamicPages_GetSiteMissingSystemPagesByName  
 @SiteID INT,  
 @PageName VARCHAR(255)  
AS  
BEGIN  
 SELECT DISTINCT s.SiteID, SiteName   
 FROM DynamicPages dp   
 INNER JOIN Sites s  
 ON dp.SiteID = s.SiteID  
 WHERE dp.SiteID NOT IN (SELECT SiteID FROM DynamicPages WHERE PageName = @PageName)  
END  