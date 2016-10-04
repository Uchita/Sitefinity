ALTER TABLE [dbo].[DynamicPages]
	ADD CONSTRAINT [FK_DynamicPages_AdminUsers] 
	FOREIGN KEY (LastModifiedBy)
	REFERENCES [dbo].[AdminUsers] (AdminUserID)	