ALTER TABLE [dbo].[DynamicPages]
	ADD CONSTRAINT [FK_DynamicPages_Sites] 
	FOREIGN KEY (SiteID)
	REFERENCES [dbo].[Sites] (SiteID)	