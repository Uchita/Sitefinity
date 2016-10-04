CREATE PROCEDURE dbo.DeleteSiteWebPartTypes
(
  @SiteWebPartTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteWebPartTypes]
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
