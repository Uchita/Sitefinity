ALTER TABLE [dbo].[SiteWebParts]
	ADD CONSTRAINT [FK_SiteWebParts_SiteWebPartTypes] 
	FOREIGN KEY (SiteWebPartTypeID)
	REFERENCES SiteWebPartTypes (SiteWebPartTypeID)	

