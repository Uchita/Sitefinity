CREATE PROCEDURE dbo.DeleteDynamicPages
(
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPages]
   WHERE 
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
