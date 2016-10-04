CREATE PROCEDURE [dbo].[DynamicPages_GetByKeywords]    
 @SiteID INT,                
 @Keywords NVARCHAR(510),                 
 @LanguageID INT,        
 @Searhable BIT,  
 @PageSize INT,                  
 @PageNumber INT        
AS                
 SET NOCOUNT ON;                
                
 IF @PageSize IS NULL                
  SET @pageSize = 10                
                
 IF @PageNumber IS NULL                
  SET @PageNumber = 1                
                
 Declare @pageStart int                
 Declare @pageEnd int                
                
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1                
 SET @PageEnd = (@PageNumber * @PageSize)               
        
 DECLARE @FullText NVARCHAR(500)                
 SET @FullText = 'FORMSOF(INFLECTIONAL,"'+@Keywords+'")'               
        
 DECLARE @tempDynamicPagesGetByKeywords TABLE               
 (              
   DynamicPageID INT NOT NULL PRIMARY KEY,               
   RowNumber INT NOT NULL              
 )           
      
if (isNULL(@Searhable,'') = '')    
BEGIN    
 INSERT INTO @tempDynamicPagesGetByKeywords              
  SELECT DynamicPages.DynamicPageID, ROW_NUMBER() OVER (ORDER BY DynamicPages.DynamicPageID) AS RowNumber        
  FROM   DynamicPages WITH (NOLOCK)        
  WHERE DynamicPages.SiteID = @SiteID        
   AND DynamicPages.LanguageID = @LanguageID                
   AND CONTAINS (DynamicPages.SearchField, @FullText)        
END    
ELSE    
BEGIN    
    
 INSERT INTO @tempDynamicPagesGetByKeywords              
  SELECT DynamicPages.DynamicPageID, ROW_NUMBER() OVER (ORDER BY DynamicPages.DynamicPageID) AS RowNumber        
  FROM   DynamicPages WITH (NOLOCK)        
  WHERE DynamicPages.SiteID = @SiteID        
  AND DynamicPages.LanguageID = @LanguageID       
  AND DynamicPages.Searchable = @Searhable    
  AND CONTAINS (DynamicPages.SearchField, @FullText)      
    
END    
    
        
 SELECT        
  DynamicPages.DynamicPageID,        
  DynamicPages.SiteID,                
  DynamicPages.LanguageID,                
  DynamicPages.ParentDynamicPageID,                
  DynamicPages.PageName,        
  DynamicPages.PageTitle,                
  '' as 'PageContent',                
  DynamicPages.DynamicPageWebPartTemplateID,                
  DynamicPages.HyperLink,        
  DynamicPages.Valid,        
  DynamicPages.OpenInNewWindow,                
  DynamicPages.Sequence,        
  DynamicPages.FullScreen,        
  DynamicPages.OnTopNav,        
  DynamicPages.OnLeftNav,        
  DynamicPages.OnBottomNav,        
  DynamicPages.OnSiteMap,        
  DynamicPages.Searchable,        
  '' as 'MetaKeywords',        
  '' as 'MetaDescription',        
  DynamicPages.PageFriendlyName,        
  DynamicPages.LastModified,        
  DynamicPages.LastModifiedBy,        
  Left(searchfield, 200) as 'SearchField',        
 (SELECT COUNT(1) FROM @tempDynamicPagesGetByKeywords) AS 'SourceID'        
 FROM DynamicPages DynamicPages WITH (NOLOCK)         
  INNER JOIN @tempDynamicPagesGetByKeywords dynamicPagesGetByKeywords ON DynamicPages.DynamicPageID = dynamicPagesGetByKeywords.DynamicPageID        
 WHERE                
  DynamicPages.SiteID = @SiteID                
  AND DynamicPages.LanguageID = @LanguageID                
  --AND CONTAINS (DynamicPages.SearchField, @FullText)         
  AND dynamicPagesGetByKeywords.RowNumber >= @PageStart              
  AND  dynamicPagesGetByKeywords.RowNumber <= @PageEnd              
 ORDER BY dynamicPagesGetByKeywords.RowNumber        
        
 --AND                 
   --(                
   -- FREETEXT(PageTitle, @FullText)                  
    --OR FREETEXT(PageContent, @FullText)                 
    --OR FREETEXT(MetaKeywords, @FullText)                 
    --OR FREETEXT(MetaDescription, @FullText)                
   --) 