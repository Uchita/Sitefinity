CREATE PROCEDURE dbo.GetDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageTemplateID],
   [DynamicPageID]
 FROM [DynamicPageShell]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
