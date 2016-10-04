CREATE PROCEDURE dbo.DeleteDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPagesLinkCategories]
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
