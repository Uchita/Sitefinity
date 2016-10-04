CREATE PROCEDURE dbo.SaveAdminUsers
(
  @AdminUserID int,
  @AdminAdminRoleID int,
  @SiteID int,
  @UserName varchar(255),
  @UserPassword varchar(255),
  @FirstName varchar(255),
  @Surname varchar(255),
  @Email varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [AdminUsers]
   SET 
    [AdminUserID] = @AdminUserID,
    [AdminAdminRoleID] = @AdminAdminRoleID,
    [SiteID] = @SiteID,
    [UserName] = @UserName,
    [UserPassword] = @UserPassword,
    [FirstName] = @FirstName,
    [Surname] = @Surname,
    [Email] = @Email
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [AdminUsers]
(
    [AdminUserID],
    [AdminAdminRoleID],
    [SiteID],
    [UserName],
    [UserPassword],
    [FirstName],
    [Surname],
    [Email]
)
VALUES
(
    @AdminUserID,
    @AdminAdminRoleID,
    @SiteID,
    @UserName,
    @UserPassword,
    @FirstName,
    @Surname,
    @Email
)
 
 OnExit: 
    RETURN @returnCode 
 GO
