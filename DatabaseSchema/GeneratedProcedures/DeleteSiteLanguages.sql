CREATE PROCEDURE dbo.DeleteSiteLanguages
(
  @SiteLanguageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteLanguages]
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
