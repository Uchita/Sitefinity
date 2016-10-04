CREATE PROCEDURE dbo.GetDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageParentID],
   [DynamicPageID]
 FROM [DynamicPagesLinkCategories]
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
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
