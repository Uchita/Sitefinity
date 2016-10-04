CREATE TABLE [dbo].[DynamicPageWebPartTemplatesLink]
(
	DynamicPageWebPartTemplatesLinkID INT IDENTITY(1,1) PRIMARY KEY,
	DynamicPageWebPartTemplateID INT NOT NULL REFERENCES DynamicPageWebPartTemplates(DynamicPageWebPartTemplateID), 
	SiteWebPartID INT NOT NULL REFERENCES SiteWebParts(SiteWebPartID),
	Sequence INT NOT NULL DEFAULT(0)
)
