ALTER TABLE [dbo].[Files]
	ADD CONSTRAINT [FK_Files_Folders] 
	FOREIGN KEY (FolderID)
	REFERENCES Folders (FolderID)	

