CREATE PROCEDURE dbo.SaveSiteWebParts
(
  @SiteWebPartID int,
  @SiteID int,
  @SiteWebPartTypeID int,
  @SiteWebPartHTML ntext
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteWebParts]
   SET 
    [SiteWebPartID] = @SiteWebPartID,
    [SiteID] = @SiteID,
    [SiteWebPartTypeID] = @SiteWebPartTypeID,
    [SiteWebPartHTML] = @SiteWebPartHTML
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteWebParts]
(
    [SiteWebPartID],
    [SiteID],
    [SiteWebPartTypeID],
    [SiteWebPartHTML]
)
VALUES
(
    @SiteWebPartID,
    @SiteID,
    @SiteWebPartTypeID,
    @SiteWebPartHTML
)
 
 OnExit: 
    RETURN @returnCode 
 GO
