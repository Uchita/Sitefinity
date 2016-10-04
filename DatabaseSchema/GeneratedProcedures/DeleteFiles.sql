CREATE PROCEDURE dbo.DeleteFiles
(
  @FileID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [Files]
   WHERE 
    [FileID] = @FileID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
