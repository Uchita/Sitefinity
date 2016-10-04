CREATE PROCEDURE dbo.GetDynamicPageTemplates
(
  @DynamicPageTemplateID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageTemplateID],
   [DynamicPageTemplateName],
   [LastModified],
   [LastModifiedBy]
 FROM [DynamicPageTemplates]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
