ALTER TABLE [dbo].[SiteWebParts]
	ADD CONSTRAINT [FK_SiteWebParts_Sites] 
	FOREIGN KEY (SiteID)
	REFERENCES [dbo].[Sites] (SiteID)	



