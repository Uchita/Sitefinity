CREATE PROCEDURE dbo.SaveDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPagesLinkCategories]
   SET 
    [DynamicPageParentID] = @DynamicPageParentID,
    [DynamicPageID] = @DynamicPageID
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
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
 
INSERT INTO [DynamicPagesLinkCategories]
(
    [DynamicPageParentID],
    [DynamicPageID]
)
VALUES
(
    @DynamicPageParentID,
    @DynamicPageID
)
 
 OnExit: 
    RETURN @returnCode 
 GO
