CREATE PROCEDURE JobRoles_GetByJobIdProfessionId  
(  
 @JobId INT,  
 @ProfessionId INT  
)  
AS  
BEGIN  
 SELECT JobRoleID, JobID, JobArchiveID, jr.RoleID   
 FROM JobRoles jr  
 INNER JOIN Roles r ON jr.RoleID = r.RoleID  
 WHERE JobID = @JobId AND r.ProfessionID = @ProfessionId  
END  