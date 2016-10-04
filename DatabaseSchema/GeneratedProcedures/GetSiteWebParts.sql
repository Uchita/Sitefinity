CREATE PROCEDURE dbo.GetSiteWebParts
(
  @SiteWebPartID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteWebPartID],
   [SiteID],
   [SiteWebPartTypeID],
   [SiteWebPartHTML]
 FROM [SiteWebParts]
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
