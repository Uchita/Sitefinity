CREATE PROCEDURE dbo.GetSiteLanguages
(
  @SiteLanguageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteLanguageID],
   [SiteLanguage]
 FROM [SiteLanguages]
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
