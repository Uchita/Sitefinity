CREATE PROCEDURE dbo.SaveAdminRoles
(
  @AdminRoleID int,
  @RoleName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [AdminRoles]
   SET 
    [AdminRoleID] = @AdminRoleID,
    [RoleName] = @RoleName
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [AdminRoles]
(
    [AdminRoleID],
    [RoleName]
)
VALUES
(
    @AdminRoleID,
    @RoleName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
