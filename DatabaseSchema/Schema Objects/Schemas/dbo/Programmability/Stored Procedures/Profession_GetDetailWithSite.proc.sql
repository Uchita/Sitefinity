  
CREATE PROCEDURE [dbo].[Profession_GetDetailWithSite]    
(    
 @SiteID int,  
 @ProfessionID int  
)    
AS    
BEGIN    
DECLARE @Professions TABLE      
(      
 [ProfessionID] INT,      
 [ProfessionName] VARCHAR(255),      
 [SiteProfessionID] INT,      
 [SiteProfessionName] NVARCHAR(510),      
 [Valid] BIT,    
 [Sequence] INT,    
 [SiteProfessionFriendlyUrl] VARCHAR(255)    
)     
    
INSERT INTO @Professions (ProfessionID, ProfessionName)    
SELECT ProfessionID, ProfessionName FROM Profession (NOLOCK)    
WHERE ProfessionID = @ProfessionID  
    
UPDATE @Professions     
SET SiteProfessionID = sp.SiteProfessionID,    
SiteProfessionName = sp.SiteProfessionName,    
Valid = sp.Valid,    
Sequence = sp.Sequence,    
SiteProfessionFriendlyUrl = sp.SiteProfessionFriendlyUrl    
FROM SiteProfession sp (NOLOCK)    
INNER JOIN @Professions p     
ON sp.ProfessionID = p.ProfessionID    
WHERE SiteID = @SiteID    
    
SELECT ProfessionID, ProfessionName, ISNULL(SiteProfessionID, '') AS SiteProfessionID, ISNULL(SiteProfessionName, ProfessionName) AS SiteProfessionName,      
ISNULL(Valid, '') AS Valid, ISNULL(Sequence, 0) AS Sequence, ISNULL(SiteProfessionFriendlyUrl, '') AS SiteProfessionFriendlyUrl  
FROM @Professions   
ORDER BY Sequence, ProfessionName, SiteProfessionName  
    
END    