CREATE PROCEDURE dbo.DeleteSiteWebParts
(
  @SiteWebPartID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteWebParts]
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
