ALTER TABLE [dbo].[Folders]
	ADD CONSTRAINT [FK_Folders_Sites] 
	FOREIGN KEY (SiteID)
	REFERENCES [dbo].[Sites] (SiteID)	

