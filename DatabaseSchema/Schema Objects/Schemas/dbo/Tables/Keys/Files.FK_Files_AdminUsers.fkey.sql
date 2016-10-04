ALTER TABLE [dbo].[Files]
	ADD CONSTRAINT [FK_Files_AdminUsers] 
	FOREIGN KEY (LastModifiedBy)
	REFERENCES [dbo].[AdminUsers](AdminUserID)	