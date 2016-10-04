ALTER TABLE [dbo].[AdminUsers]
	ADD CONSTRAINT [FK_AdminUsers_Sites] 
	FOREIGN KEY (SiteID)
	REFERENCES [dbo].[Sites] (SiteID)	

