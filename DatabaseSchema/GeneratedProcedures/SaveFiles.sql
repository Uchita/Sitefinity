CREATE PROCEDURE dbo.SaveFiles
(
  @FileID int,
  @SiteID int,
  @FolderID int,
  @FileName nvarchar(500),
  @FileSystemName nvarchar(500),
  @FileTypeID int,
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Files]
   SET 
    [FileID] = @FileID,
    [SiteID] = @SiteID,
    [FolderID] = @FolderID,
    [FileName] = @FileName,
    [FileSystemName] = @FileSystemName,
    [FileTypeID] = @FileTypeID,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [FileID] = @FileID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Files]
(
    [FileID],
    [SiteID],
    [FolderID],
    [FileName],
    [FileSystemName],
    [FileTypeID],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @FileID,
    @SiteID,
    @FolderID,
    @FileName,
    @FileSystemName,
    @FileTypeID,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
