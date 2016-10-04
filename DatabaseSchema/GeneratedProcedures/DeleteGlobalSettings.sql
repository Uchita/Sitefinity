CREATE PROCEDURE dbo.DeleteGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [GlobalSettings]
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
