CREATE PROCEDURE dbo.DynamicPages_BulkUpdate      
(        
 @SiteId int,      
 @From varchar (1000),      
 @To varchar (1000),      
 @UpdateSystemPages bit = 0      
)        
AS        
      
if @UpdateSystemPages = 0      
BEGIN      
  --No System Pages      
  UPDATE      
   [dbo].[DynamicPages]      
  SET [PageContent] = CAST(REPLACE(CAST([PageContent] as NVarchar(MAX)),@From,@To) AS NText)      
  WHERE       
   [SiteID] = @SiteId       
   AND NOT PageName Like '%SystemPage%'      
END      
ELSE      
BEGIN      
  -- All pages in the Site      
  UPDATE      
   [dbo].[DynamicPages]      
  SET [PageContent] = CAST(REPLACE(CAST([PageContent] as NVarchar(MAX)),@From,@To) AS NText)      
  WHERE [SiteID] = @SiteId      
END    

-- Update Site Web Parts
UPDATE [dbo].[SiteWebParts] 
	SET [SiteWebPartHTML] = CAST(REPLACE(CAST(ISNULL([SiteWebPartHTML],'') as NVarchar(MAX)),@From,@To) AS NText)   
WHERE [SiteID] = @SiteId   

--Update the GlobalSettings
UPDATE [dbo].GlobalSettings 
	SET MetaTags = CAST(REPLACE(CAST(ISNULL(MetaTags,'') as NVarchar(MAX)),@From,@To) AS NText),
	SystemMetaTags = CAST(REPLACE(CAST(ISNULL(SystemMetaTags,'') as NVarchar(MAX)),@From,@To) AS NText)
WHERE [SiteID] = @SiteId   

Select @@ROWCOUNT   
  