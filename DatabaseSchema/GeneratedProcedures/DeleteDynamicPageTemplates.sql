CREATE PROCEDURE dbo.DeleteDynamicPageTemplates
(
  @DynamicPageTemplateID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPageTemplates]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
