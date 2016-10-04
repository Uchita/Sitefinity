CREATE PROCEDURE dbo.SaveDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPageShell]
   SET 
    [DynamicPageTemplateID] = @DynamicPageTemplateID,
    [DynamicPageID] = @DynamicPageID
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPageShell]
(
    [DynamicPageTemplateID],
    [DynamicPageID]
)
VALUES
(
    @DynamicPageTemplateID,
    @DynamicPageID
)
 
 OnExit: 
    RETURN @returnCode 
 GO
