CREATE PROCEDURE dbo.GetFileTypes
(
  @FileTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FileTypeID],
   [FileTypeName],
   [FileTypeExtension]
 FROM [FileTypes]
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
