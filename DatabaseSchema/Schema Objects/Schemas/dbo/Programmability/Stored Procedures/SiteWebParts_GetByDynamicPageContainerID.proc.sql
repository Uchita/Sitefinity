CREATE PROCEDURE [dbo].[SiteWebParts_GetByDynamicPageContainerID]
	@DynamicPageWebPartTemplateID int
AS
SELECT  SiteWebParts.[SiteWebPartID]  
		,SiteWebParts.[SiteID]  
		,SiteWebParts.[SiteWebPartName]  
		,SiteWebParts.[SiteWebPartTypeID]  
		,SiteWebParts.[SiteWebPartHTML]
		,SiteWebParts.SourceID  
 FROM  DynamicPageWebPartTemplates (NOLOCK)  
 INNER JOIN DynamicPageWebPartTemplatesLink (NOLOCK)  
 ON DynamicPageWebPartTemplates.DynamicPageWebPartTemplateID = DynamicPageWebPartTemplatesLink.DynamicPageWebPartTemplateID   
 INNER JOIN SiteWebParts (NOLOCK)  
 ON DynamicPageWebPartTemplatesLink.SiteWebPartID = SiteWebParts.SiteWebPartID  
 WHERE  
  DynamicPageWebPartTemplates.DynamicPageWebPartTemplateID = @DynamicPageWebPartTemplateID  
 ORDER BY  
  SiteWebParts.[SiteWebPartTypeID], DynamicPageWebPartTemplatesLink.Sequence
