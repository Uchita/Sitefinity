CREATE PROCEDURE dbo.SaveSiteWebPartTypes
(
  @SiteWebPartTypeID int,
  @SiteWebPartName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteWebPartTypes]
   SET 
    [SiteWebPartTypeID] = @SiteWebPartTypeID,
    [SiteWebPartName] = @SiteWebPartName
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteWebPartTypes]
(
    [SiteWebPartTypeID],
    [SiteWebPartName]
)
VALUES
(
    @SiteWebPartTypeID,
    @SiteWebPartName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
