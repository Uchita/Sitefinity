CREATE TABLE [dbo].[SiteWebParts]
(
	SiteWebPartID		INT IDENTITY(1,1) PRIMARY KEY,
	SiteID				INT NOT NULL REFERENCES Sites(SiteID),
	SiteWebPartName		VARCHAR(255) NOT NULL,
	SiteWebPartTypeID	INT NOT NULL REFERENCES SiteWebPartTypes(SiteWebPartTypeID),
	SiteWebPartHTML		NTEXT,
	SourceID			INT NULL
)
