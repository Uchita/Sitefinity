CREATE PROCEDURE dbo.DeleteAdminRoles
(
  @AdminRoleID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [AdminRoles]
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
