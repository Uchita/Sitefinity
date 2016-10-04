CREATE PROCEDURE dbo.SaveDynamicPageTemplates
(
  @DynamicPageTemplateID int,
  @DynamicPageTemplateName nvarchar(255),
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPageTemplates]
   SET 
    [DynamicPageTemplateID] = @DynamicPageTemplateID,
    [DynamicPageTemplateName] = @DynamicPageTemplateName,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPageTemplates]
(
    [DynamicPageTemplateID],
    [DynamicPageTemplateName],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @DynamicPageTemplateID,
    @DynamicPageTemplateName,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
