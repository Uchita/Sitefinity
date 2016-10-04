CREATE PROCEDURE dbo.GetAdminUsers
(
  @AdminUserID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [AdminUserID],
   [AdminAdminRoleID],
   [SiteID],
   [UserName],
   [UserPassword],
   [FirstName],
   [Surname],
   [Email]
 FROM [AdminUsers]
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
