CREATE PROCEDURE DynamicPages_GetSystemPagesNameBySiteID  
 @SiteID INT  
AS  
BEGIN  
 SELECT DISTINCT SiteID, PageName   
 FROM DynamicPages WHERE SiteID = @SiteID   
 AND PageName LIKE 'SystemPage_%'  
END  