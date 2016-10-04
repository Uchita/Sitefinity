CREATE PROCEDURE dbo.DeleteDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPageShell]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
