CREATE PROCEDURE [dbo].[SiteWebParts_GetByDynamicPageWebPartTemplatesLink]
      @DynamicPageWebPartTemplateID int
AS
	SELECT
		DynamicPageWebPartTemplates.DynamicPageWebPartTemplateID
		,DynamicPageWebPartTemplatesLink.DynamicPageWebPartTemplatesLinkID
		,DynamicPageWebPartTemplates.DynamicPageWebPartName
		,SiteWebParts.[SiteWebPartID]
		,SiteWebParts.[SiteWebPartTypeID]
		,SiteWebParts.[SiteWebPartName]
		,DynamicPageWebPartTemplatesLink.Sequence
	FROM  DynamicPageWebPartTemplates (NOLOCK)
	INNER JOIN DynamicPageWebPartTemplatesLink (NOLOCK)
	ON DynamicPageWebPartTemplates.DynamicPageWebPartTemplateID = DynamicPageWebPartTemplatesLink.DynamicPageWebPartTemplateID 
	INNER JOIN SiteWebParts (NOLOCK)
	ON DynamicPageWebPartTemplatesLink.SiteWebPartID = SiteWebParts.SiteWebPartID
	WHERE
		  DynamicPageWebPartTemplates.DynamicPageWebPartTemplateID = @DynamicPageWebPartTemplateID
	ORDER BY
		  SiteWebParts.[SiteWebPartTypeID], DynamicPageWebPartTemplatesLink.Sequence
