CREATE PROCEDURE dbo.GetSites
(
  @SiteID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteID],
   [SiteName],
   [SiteURL],
   [SiteDescription],
   [LastModified],
   [LastModifiedBy]
 FROM [Sites]
   WHERE 
    [SiteID] = @SiteID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
