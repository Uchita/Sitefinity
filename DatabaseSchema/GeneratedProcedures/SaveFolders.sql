CREATE PROCEDURE dbo.SaveFolders
(
  @FolderID int,
  @ParentFolderID int,
  @SiteID int,
  @FolderName nvarchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Folders]
   SET 
    [FolderID] = @FolderID,
    [ParentFolderID] = @ParentFolderID,
    [SiteID] = @SiteID,
    [FolderName] = @FolderName
   WHERE 
    [FolderID] = @FolderID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Folders]
(
    [FolderID],
    [ParentFolderID],
    [SiteID],
    [FolderName]
)
VALUES
(
    @FolderID,
    @ParentFolderID,
    @SiteID,
    @FolderName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
