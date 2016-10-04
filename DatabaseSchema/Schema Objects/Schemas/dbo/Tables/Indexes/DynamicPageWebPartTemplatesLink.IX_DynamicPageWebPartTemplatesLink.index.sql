CREATE UNIQUE NONCLUSTERED INDEX IX_DynamicPageWebPartTemplatesLink ON dbo.DynamicPageWebPartTemplatesLink
(
	DynamicPageWebPartTemplateID, SiteWebPartID
) ON [PRIMARY]