CREATE PROCEDURE dbo.GetSiteWebPartTypes
(
  @SiteWebPartTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteWebPartTypeID],
   [SiteWebPartName]
 FROM [SiteWebPartTypes]
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
