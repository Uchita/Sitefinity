CREATE PROCEDURE dbo.GetFolders
(
  @FolderID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FolderID],
   [ParentFolderID],
   [SiteID],
   [FolderName]
 FROM [Folders]
   WHERE 
    [FolderID] = @FolderID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
