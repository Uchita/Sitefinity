CREATE PROCEDURE dbo.Sites_FindSite    
(     
 @SiteId int   = null ,      
 @SiteUrl varchar (500)  = null    
)      
AS      
    
SELECT    
 Sites.SiteID, Sites.SiteName, Sites.SiteURL, Sites.SiteDescription, Sites.SiteAdminLogo, GlobalSettings.DefaultLanguageID, Live    
FROM     
 Sites INNER JOIN GlobalSettings     
  ON Sites.SiteID = GlobalSettings.SiteID    
WHERE       
 (Sites.[SiteID] = @SiteId OR @SiteId IS null)      
 AND (Sites.[SiteURL] = @SiteUrl OR isNULL(@SiteUrl, '') = '')      
    
SELECT @@ROWCOUNT    

GO