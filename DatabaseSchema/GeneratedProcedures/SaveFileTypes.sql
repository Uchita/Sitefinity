CREATE PROCEDURE dbo.SaveFileTypes
(
  @FileTypeID int,
  @FileTypeName varchar(255),
  @FileTypeExtension varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [FileTypes]
   SET 
    [FileTypeID] = @FileTypeID,
    [FileTypeName] = @FileTypeName,
    [FileTypeExtension] = @FileTypeExtension
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [FileTypes]
(
    [FileTypeID],
    [FileTypeName],
    [FileTypeExtension]
)
VALUES
(
    @FileTypeID,
    @FileTypeName,
    @FileTypeExtension
)
 
 OnExit: 
    RETURN @returnCode 
 GO
