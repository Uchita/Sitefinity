ALTER TABLE [dbo].[Files]
	ADD CONSTRAINT [FK_Files_Sites] 
	FOREIGN KEY (SiteID)
	REFERENCES Sites (SiteID)	

