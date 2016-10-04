CREATE PROCEDURE [dbo].[JobsSaved_GetJobNameByMemberID]      
(  
 @MemberID INT,  
 @PageSize INT,            
 @PageNumber INT    
)      
AS    
BEGIN   
  
 IF @PageSize IS NULL          
  SET @pageSize = 10          
          
 IF @PageNumber IS NULL          
  SET @PageNumber = 1          
          
 Declare @pageStart int          
 Declare @pageEnd int          
          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1          
 SET @PageEnd = (@PageNumber * @PageSize);  
  
 WITH JobSavedJobNameByMember AS   
(   
 SELECT ROW_NUMBER() OVER (ORDER BY JobsSaved.JobSaveID DESC) AS RowNumber, JobsSaved.JobSaveID AS JobSaveID, JobsSaved.JobID AS JobID,   
  JobsSaved.MemberID AS MemberID, JobsSaved.LastModified AS LastModified, Jobs.JobName AS JobName , Jobs.JobFriendlyName AS JobFriendlyName,  
  SiteProfessionName   
 FROM JobsSaved JobsSaved WITH (NOLOCK)  
 INNER JOIN Jobs WITH(NOLOCK) ON JobsSaved.JobID = Jobs.JobID   
 INNER JOIN dbo.JobRoles WITH (NOLOCK) ON dbo.JobRoles.JobID = dbo.Jobs.JobID   
 INNER JOIN dbo.SiteRoles WITH (NOLOCK) ON dbo.SiteRoles.RoleID = dbo.JobRoles.RoleID AND dbo.SiteRoles.SiteID = dbo.Jobs.SiteID   
 INNER JOIN dbo.Roles WITH (NOLOCK) ON dbo.Roles.RoleID = dbo.JobRoles.RoleID   
 INNER JOIN dbo.Profession WITH (NOLOCK) ON dbo.Profession.ProfessionID = dbo.Roles.ProfessionID   
 INNER JOIN dbo.SiteProfession WITH (NOLOCK) ON dbo.SiteProfession.ProfessionID = dbo.Profession.ProfessionID   
 AND dbo.SiteProfession.SiteID = dbo.Jobs.SiteID  
  
 WHERE  JobsSaved.MemberID = @MemberID  
 )   
  
SELECT JobSaveID, JobID, MemberID, LastModified, JobName, JobFriendlyName, SiteProfessionName, (SELECT COUNT(1) FROM JobSavedJobNameByMember) AS TotalCount  
FROM   JobSavedJobNameByMember WITH (NOLOCK)   
WHERE  MemberID = @MemberID  
 AND RowNumber >= @PageStart        
 AND RowNumber <= @PageEnd        
ORDER BY RowNumber   
  
END  
        
  