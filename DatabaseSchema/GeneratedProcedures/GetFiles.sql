CREATE PROCEDURE dbo.GetFiles
(
  @FileID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FileID],
   [SiteID],
   [FolderID],
   [FileName],
   [FileSystemName],
   [FileTypeID],
   [LastModified],
   [LastModifiedBy]
 FROM [Files]
   WHERE 
    [FileID] = @FileID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
