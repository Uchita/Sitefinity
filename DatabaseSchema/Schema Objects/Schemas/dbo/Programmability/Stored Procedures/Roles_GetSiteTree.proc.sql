CREATE PROCEDURE [dbo].[Roles_GetSiteTree]    
(    
 @SiteID int    
)    
AS    
BEGIN    
DECLARE @Roles TABLE      
(      
 [RoleID] INT,      
 [ProfessionID] INT,      
 [RoleName] VARCHAR(255),      
 [SiteRoleID] INT,      
 [SiteRoleName] NVARCHAR(510),      
 [Valid] BIT,    
 [Sequence] INT,    
 [SiteRoleFriendlyUrl] VARCHAR(255)    
)     
    
INSERT INTO @Roles (RoleID, ProfessionID, RoleName)    
SELECT RoleID, ProfessionID, RoleName FROM Roles (NOLOCK)    
    
UPDATE @Roles     
SET SiteRoleID = sr.SiteRoleID,    
SiteRoleName = sr.SiteRoleName,    
Valid = sr.Valid,    
Sequence = sr.Sequence,    
SiteRoleFriendlyUrl = sr.SiteRoleFriendlyUrl    
FROM SiteRoles sr (NOLOCK)    
INNER JOIN @Roles r     
ON sr.RoleID = r.RoleID    
WHERE SiteID = @SiteID    
    
SELECT RoleID, ProfessionID, RoleName, SiteRoleID,      
SiteRoleName, Valid, Sequence, SiteRoleFriendlyUrl   
FROM @Roles   
ORDER BY Sequence    
    
END    