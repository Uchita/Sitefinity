CREATE PROCEDURE dbo.DeleteFileTypes
(
  @FileTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [FileTypes]
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
