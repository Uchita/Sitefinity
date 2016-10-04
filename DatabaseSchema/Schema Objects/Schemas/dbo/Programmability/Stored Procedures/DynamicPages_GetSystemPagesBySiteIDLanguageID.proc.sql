  
CREATE PROCEDURE DynamicPages_GetSystemPagesBySiteIDLanguageID  
 @SiteID INT,  
 @LanguageID INT,  
 @PageName VARCHAR(255)  
AS  
BEGIN  
 SELECT DynamicPageID,  
 SiteID,  
 LanguageID,  
 PageContent  
 FROM DynamicPages WHERE SiteID = @SiteID   
 AND LanguageID = @LanguageID AND PageName = @PageName  
END  