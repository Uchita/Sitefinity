ALTER TABLE [dbo].[AdminUsers]
	ADD CONSTRAINT [FK_AdminUsers_AdminRoles] 
	FOREIGN KEY (AdminRoleID)
	REFERENCES AdminRoles (AdminRoleID)	

