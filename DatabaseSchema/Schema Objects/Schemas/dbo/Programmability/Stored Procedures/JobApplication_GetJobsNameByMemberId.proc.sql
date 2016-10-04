CREATE PROCEDURE [dbo].[JobApplication_GetJobsNameByMemberId]        
(        
 @MemberID INT,    
 @PageSize INT,              
 @PageNumber INT           
)        
        
AS      
BEGIN    
    
DECLARE @SiteID INT   
  
SET @SiteID = (Select SiteID from Members (NOLOCK) where MemberID = @MemberID)  
  
 IF @PageSize IS NULL            
  SET @pageSize = 10            
            
 IF @PageNumber IS NULL            
  SET @PageNumber = 1            
            
 Declare @pageStart int            
 Declare @pageEnd int            
            
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1            
 SET @PageEnd = (@PageNumber * @PageSize);          
    
 WITH JobApplicationJobNameByMember AS     
(     
 SELECT ROW_NUMBER() OVER (ORDER BY JobApplication.JobApplicationID DESC) AS RowNumber, JobApplication.JobApplicationID AS JobApplicationID,     
  JobApplication.ApplicationDate AS ApplicationDate, JobApplication.MemberID AS MemberID, JobApplication.ApplicationStatus AS ApplicationStatus,     
  Jobs.JobID AS JobID, Jobs.JobName AS JobName, Advertisers.AdvertiserID AS AdvertiserID, Advertisers.CompanyName AS CompanyName,  
  '/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'  
 FROM   JobApplication JobApplication    
 INNER JOIN  Jobs (NOLOCK) ON JobApplication.JobID = Jobs.JobID        
 INNER JOIN  Advertisers (NOLOCK) ON Advertisers.AdvertiserID = Jobs.AdvertiserID   
   
 INNER JOIN JobRoles (NOLOCK)           
 ON JobRoles.JobID = Jobs.JobId          
 INNER JOIN SiteRoles (NOLOCK)           
 ON SiteRoles.RoleID = JobRoles.RoleID        
 AND SiteRoles.SiteID = @SiteID            
 INNER JOIN Roles (NOLOCK)           
 ON Roles.RoleID = JobRoles.RoleID          
 INNER JOIN Profession (NOLOCK)           
 ON Profession.ProfessionID = Roles.ProfessionID          
 INNER JOIN SiteProfession (NOLOCK)           
 ON SiteProfession.ProfessionID = Profession.ProfessionID         
 AND SiteProfession.SiteID = @SiteID      
         
 WHERE  JobApplication.MemberID = @MemberID    
 )    
    
SELECT  JobApplicationID, ApplicationDate, MemberID, ApplicationStatus, JobID, JobName, JobFriendlyName, AdvertiserID, CompanyName,    
     (SELECT COUNT(1) FROM JobApplicationJobNameByMember) AS TotalCount    
FROM    JobApplicationJobNameByMember WITH (NOLOCK)     
WHERE   MemberID = @MemberID    
 AND RowNumber >= @PageStart          
 AND RowNumber <= @PageEnd          
ORDER BY RowNumber     
    
END    