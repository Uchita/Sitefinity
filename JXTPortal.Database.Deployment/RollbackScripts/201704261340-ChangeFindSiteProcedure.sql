USE [MiniJXT]
GO
/****** Object:  StoredProcedure [dbo].[Sites_FindSite]    Script Date: 04/26/2017 13:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_FindSite]    
(     
 @SiteId int   = null ,      
 @SiteUrl varchar (500)  = null    
)      
AS      
    
SELECT    
 Sites.SiteID, Sites.SiteName, Sites.SiteUrl, Sites.SiteDescription, Sites.SiteAdminLogo, Sites.SiteAdminLogoUrl, GlobalSettings.DefaultLanguageID, Live, 
	MobileEnabled, MobileUrl    
FROM     
 Sites INNER JOIN GlobalSettings     
  ON Sites.SiteID = GlobalSettings.SiteID    
WHERE       
 (Sites.[SiteID] = @SiteId OR @SiteId IS null)      
 AND (Sites.[SiteUrl] = @SiteUrl OR isNULL(@SiteUrl, '') = '')      
    
SELECT @@ROWCOUNT