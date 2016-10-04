CREATE PROCEDURE dbo.GetGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteID],
   [ParameterName],
   [ParameterValue],
   [LastModified]
 FROM [GlobalSettings]
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
