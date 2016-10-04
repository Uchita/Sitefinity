ALTER TABLE [dbo].[Files]
	ADD CONSTRAINT [FK_Files_FileTypes] 
	FOREIGN KEY (FileTypeID)
	REFERENCES [dbo].[FileTypes] (FileTypeID)	

