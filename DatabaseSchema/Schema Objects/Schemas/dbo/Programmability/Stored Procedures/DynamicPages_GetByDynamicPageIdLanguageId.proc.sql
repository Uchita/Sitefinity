CREATE PROCEDURE [dbo].[DynamicPages_GetByDynamicPageIdLanguageId]
(
	@SiteID INT,
	@DynamicPageId INT, 
	@LanguageID INT
)
AS  
 SET NOCOUNT ON;  
  
 SELECT  
  DynamicPages.[DynamicPageID],  
  DynamicPages.[SiteID],  
  DynamicPages.[LanguageID],  
  DynamicPages.[ParentDynamicPageID],  
  DynamicPages.[PageName],  
  DynamicPages.[PageTitle],  
  DynamicPages.[PageContent],  
  DynamicPages.[DynamicPageWebPartTemplateID],  
  DynamicPages.[HyperLink],  
  DynamicPages.[Valid],  
  DynamicPages.[OpenInNewWindow],  
  DynamicPages.[Sequence],  
  DynamicPages.[FullScreen],  
  DynamicPages.[OnTopNav],  
  DynamicPages.[OnLeftNav],  
  DynamicPages.[OnBottomNav],  
  DynamicPages.[OnSiteMap],  
  DynamicPages.[Searchable],  
  DynamicPages.[MetaKeywords],  
  DynamicPages.[MetaDescription],  
  DynamicPages.[PageFriendlyName],  
  DynamicPages.[LastModified],  
  DynamicPages.[LastModifiedBy],  
  DynamicPages.[SearchField],
  DynamicPages.[SourceID]  
 FROM  
  [dbo].[DynamicPages] DynamicPages  
 WHERE  
  DynamicPages.[SiteID] = @SiteID  
  AND DynamicPages.[LanguageID] = @LanguageID  
     AND DynamicPages.[PageName] = (SELECT PageName FROM DynamicPages WHERE DynamicPageId = @DynamicPageId)


