CREATE PROCEDURE dbo.DeleteAdminUsers
(
  @AdminUserID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [AdminUsers]
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
