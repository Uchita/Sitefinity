CREATE PROCEDURE dbo.SaveGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255),
  @ParameterValue varchar(255),
  @LastModified datetime
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [GlobalSettings]
   SET 
    [SiteID] = @SiteID,
    [ParameterName] = @ParameterName,
    [ParameterValue] = @ParameterValue,
    [LastModified] = @LastModified
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [GlobalSettings]
(
    [SiteID],
    [ParameterName],
    [ParameterValue],
    [LastModified]
)
VALUES
(
    @SiteID,
    @ParameterName,
    @ParameterValue,
    @LastModified
)
 
 OnExit: 
    RETURN @returnCode 
 GO
