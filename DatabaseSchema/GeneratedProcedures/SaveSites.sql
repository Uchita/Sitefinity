CREATE PROCEDURE dbo.SaveSites
(
  @SiteID int,
  @SiteName varchar(255),
  @SiteURL varchar(500),
  @SiteDescription text,
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Sites]
   SET 
    [SiteID] = @SiteID,
    [SiteName] = @SiteName,
    [SiteURL] = @SiteURL,
    [SiteDescription] = @SiteDescription,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [SiteID] = @SiteID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Sites]
(
    [SiteID],
    [SiteName],
    [SiteURL],
    [SiteDescription],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @SiteID,
    @SiteName,
    @SiteURL,
    @SiteDescription,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
