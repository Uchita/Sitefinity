  
CREATE PROCEDURE [dbo].[DynamicPages_GetHierarchy]      
(      
 @SiteID INT,      
 @LanguageID INT = 0,      
 @DynamicPageID INT = 0,  
 @OnSiteMap BIT = 0,  
 @NonSystemPage BIT = 0  
)      
AS      
 SET NOCOUNT ON;      
      
 WITH DynamicPagesFamily AS      
 (      
  SELECT      
   parent.[DynamicPageID],      
   parent.[SiteID],      
   parent.[LanguageID],      
   parent.[ParentDynamicPageID],      
   parent.[PageName],      
   parent.[PageTitle],      
   '' AS [PageContent],      
   parent.[DynamicPageWebPartTemplateID],      
   parent.[HyperLink],      
   parent.[Valid],      
   parent.[OpenInNewWindow],      
   parent.[Sequence],      
   parent.[FullScreen],      
   parent.[OnTopNav],      
   parent.[OnLeftNav],      
   parent.[OnBottomNav],      
   parent.[OnSiteMap],      
   parent.[Searchable],      
   '' AS [SearchField],      
   '' AS [MetaKeywords],      
   '' AS [MetaDescription],      
   parent.[PageFriendlyName],      
   parent.[LastModified],      
   parent.[LastModifiedBy],     
 parent.[SourceID],     
   0 AS lvl,      
   CAST(parent.[DynamicPageID] AS VARCHAR(128)) AS Sort      
  FROM      
   [dbo].[DynamicPages] parent      
  WHERE      
   (ISNULL(@DynamicPageID,0) <> 0 OR parent.[ParentDynamicPageID] = @DynamicPageID)      
  AND (ISNULL(@DynamicPageID,0) = 0  OR parent.[DynamicPageID]  = @DynamicPageID)      
  AND parent.[SiteID] = @SiteID      
  AND (parent.[LanguageID] = @LanguageID OR @LanguageID = 0)    
  AND (parent.[OnSiteMap] = @OnSiteMap)  
  AND (@NonSystemPage = 0 OR (@NonSystemPage = 1 AND parent.[PageName] NOT LIKE 'SystemPage%'))  
  UNION ALL      
  SELECT      
   children.[DynamicPageID],      
   children.[SiteID],      
   children.[LanguageID],      
   children.[ParentDynamicPageID],      
   children.[PageName],      
   children.[PageTitle],      
   '' AS [PageContent],      
   children.[DynamicPageWebPartTemplateID],      
   children.[HyperLink],      
   children.[Valid],      
   children.[OpenInNewWindow],      
   children.[Sequence],      
   children.[FullScreen],      
   children.[OnTopNav],      
   children.[OnLeftNav],      
   children.[OnBottomNav],      
   children.[OnSiteMap],      
   children.[Searchable],      
   '' AS [SearchField],      
   '' AS [MetaKeywords],      
   '' AS [MetaDescription],      
   children.[PageFriendlyName],      
   children.[LastModified],      
   children.[LastModifiedBy],     
 children.[SourceID],      
   dynamicPagesFamily.lvl + 1,      
   CAST(dynamicPagesFamily.Sort + '/' + CAST(children.DynamicPageID AS VARCHAR) AS VARCHAR(128))      
  FROM      
   [dbo].[DynamicPages] children      
  INNER JOIN      
   DynamicPagesFamily dynamicPagesFamily      
  ON      
   children.[ParentDynamicPageID] = dynamicPagesFamily.DynamicPageID      
  AND children.[SiteID] = @SiteID      
  AND (children.[LanguageID] = @LanguageID  OR @LanguageID = 0)  
  AND (children.[OnSiteMap] = @OnSiteMap)  
  AND (@NonSystemPage = 0 OR (@NonSystemPage = 1 AND children.[PageName] NOT LIKE 'SystemPage%'))  
 )      
      
 SELECT      
   [DynamicPageID],      
   [SiteID],      
   [LanguageID],      
   [ParentDynamicPageID],      
   [PageName],      
   PageTitle,      
   [PageContent],      
   lvl AS [DynamicPageWebPartTemplateID],      
   [HyperLink],      
   [Valid],      
   [OpenInNewWindow],      
   [Sequence],      
   [FullScreen],      
   [OnTopNav],      
   [OnLeftNav],      
   [OnBottomNav],      
   [OnSiteMap],      
   [Searchable],      
   [MetaKeywords],      
   [MetaDescription],      
   [PageFriendlyName],      
   [LastModified],      
   [LastModifiedBy],      
   [SearchField],    
 [SourceID]      
 FROM      
  DynamicPagesFamily      
 ORDER BY Sort 