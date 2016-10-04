CREATE PROCEDURE [dbo].[DynamicPages_UpdateWebPartTemplate]      
(      
 @SiteID INT,      
 @LanguageID INT = 0,      
 @DynamicPageID INT = 0,  
 @DynamicPageWebPartTemplateID INT   
)      
AS      
BEGIN  
 WITH DynamicPagesFamily AS      
 (      
  SELECT      
   parent.[DynamicPageID],  
   0 AS lvl  
  FROM      
   [dbo].[DynamicPages] parent      
  WHERE      
   (ISNULL(@DynamicPageID,0) <> 0 OR parent.[ParentDynamicPageID] = @DynamicPageID)      
  AND (ISNULL(@DynamicPageID,0) = 0  OR parent.[DynamicPageID]  = @DynamicPageID)      
  AND parent.[SiteID] = @SiteID      
  AND (parent.[LanguageID] = @LanguageID OR @LanguageID = 0)    
  UNION ALL      
  SELECT      
   children.[DynamicPageID],     
   dynamicPagesFamily.lvl + 1      
  FROM      
   [dbo].[DynamicPages] children      
  INNER JOIN      
   DynamicPagesFamily dynamicPagesFamily      
  ON      
   children.[ParentDynamicPageID] = dynamicPagesFamily.DynamicPageID      
  AND children.[SiteID] = @SiteID      
  AND (children.[LanguageID] = @LanguageID  OR @LanguageID = 0)  
 )      
  
UPDATE DynamicPages SET DynamicPageWebPartTemplateID = @DynamicPageWebPartTemplateID  
WHERE DynamicPageID IN (  
 SELECT [DynamicPageID]  
 FROM DynamicPagesFamily  
)    
  
END 