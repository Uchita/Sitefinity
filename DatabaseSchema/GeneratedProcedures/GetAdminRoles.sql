CREATE PROCEDURE dbo.GetAdminRoles
(
  @AdminRoleID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [AdminRoleID],
   [RoleName]
 FROM [AdminRoles]
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
