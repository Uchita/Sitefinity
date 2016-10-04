  
CREATE PROCEDURE [dbo].[Roles_GetDetailWithSite]    
(    
 @SiteID int,  
 @RoleID int  
)    
AS    
BEGIN    
DECLARE @Roles TABLE      
(      
 [ProfessionID] INT,      
 [ProfessionName] VARCHAR(255),      
 [SiteProfessionID] INT,      
 [SiteProfessionName] NVARCHAR(510),      
 [Valid] BIT,    
 [SiteProfessionFriendlyUrl] VARCHAR(255),  
 [RoleID] INT,      
 [RoleName] VARCHAR(255),      
 [SiteRoleID] INT,      
 [SiteRoleName] NVARCHAR(510),      
 [RoleValid] BIT,    
 [Sequence] INT,    
 [SiteRoleFriendlyUrl] VARCHAR(255)    
)     
    
INSERT INTO @Roles (ProfessionID, ProfessionName, RoleID, RoleName)    
SELECT p.ProfessionID, ProfessionName, RoleID, RoleName   
FROM Profession p (NOLOCK)    
INNER JOIN Roles r ON p.ProfessionID = r.ProfessionID  
WHERE RoleID = @RoleID  
    
UPDATE @Roles     
SET SiteProfessionID = sp.SiteProfessionID,    
SiteProfessionName = sp.SiteProfessionName,    
Valid = sp.Valid,    
Sequence = sp.Sequence,    
SiteProfessionFriendlyUrl = sp.SiteProfessionFriendlyUrl    
FROM SiteProfession sp (NOLOCK)    
INNER JOIN @Roles p     
ON sp.ProfessionID = p.ProfessionID    
WHERE SiteID = @SiteID    
  
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
    
SELECT ProfessionID, ProfessionName, ISNULL(SiteProfessionID, '') AS SiteProfessionID, ISNULL(SiteProfessionName, '') AS SiteProfessionName,      
ISNULL(Valid, '') AS Valid, ISNULL(SiteProfessionFriendlyUrl, '') AS SiteProfessionFriendlyUrl,  
 RoleID, RoleName, ISNULL(SiteRoleID, '') AS SiteRoleID,      
 ISNULL(SiteRoleName, RoleName) AS SiteRoleName,      
 ISNULL(RoleValid, '') AS RoleValid,  ISNULL(Sequence, '') AS Sequence,    
 ISNULL(SiteRoleFriendlyUrl, '') AS SiteRoleFriendlyUrl  
FROM @Roles   
ORDER BY Sequence, RoleName, SiteRoleName  
    
END    