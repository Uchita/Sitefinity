CREATE PROCEDURE dbo.SaveSiteLanguages
(
  @SiteLanguageID int,
  @SiteLanguage varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteLanguages]
   SET 
    [SiteLanguageID] = @SiteLanguageID,
    [SiteLanguage] = @SiteLanguage
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteLanguages]
(
    [SiteLanguageID],
    [SiteLanguage]
)
VALUES
(
    @SiteLanguageID,
    @SiteLanguage
)
 
 OnExit: 
    RETURN @returnCode 
 GO
