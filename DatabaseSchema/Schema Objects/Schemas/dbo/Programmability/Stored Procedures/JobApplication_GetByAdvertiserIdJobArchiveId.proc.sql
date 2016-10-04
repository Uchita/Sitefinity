  
CREATE PROCEDURE [dbo].[JobApplication_GetByAdvertiserIdJobArchiveId]  
(  
  
 @AdvertiserId int  ,  
  
 @JobArchiveId int  ,  
  
 @PageNumber int   ,  
  
 @PageSize int     
)  
AS  
  
    BEGIN  
    IF @PageSize IS NULL          
      SET @pageSize = 10          
              
     IF @PageNumber IS NULL          
      SET @PageNumber = 0          
              
     Declare @pageStart int          
     Declare @pageEnd int          
              
     SET @PageStart = (@PageNumber) * (@PageSize + 1)  
     SET @PageEnd = ((@PageNumber + 1) * @PageSize);  
  
    -- SQL Server 2005 Paging  
    WITH PageIndex AS (  
    SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex  
    , [JobApplicationID]  
    , [ApplicationDate]  
    , ja.JobID  
    , [MemberID]  
    , [MemberResumeFile]  
    , [MemberCoverLetterFile]  
    , [ApplicationStatus]  
    , [JobAppValidateID]  
    , [SiteID_Referral]  
    , [URL_Referral]  
    , [ApplicantGrade]  
    , [LastViewedDate]  
    , [FirstName]  
    , [Surname]  
    , [EmailAddress]  
    , [MobilePhone]  
    , [MemberNote]  
    , [AdvertiserNote]      
     FROM [dbo].[JobApplication] ja (NOLOCK)  
     INNER JOIN [dbo].[JobsArchive] j (NOLOCK)  
     ON ja.JobID = j.JobID  
     WHERE j.AdvertiserID = @AdvertiserId  
     AND ja.JobArchiveID = @JobArchiveId  
     ) SELECT  
     [JobApplicationID],  
     [ApplicationDate],  
     [JobID],  
     [MemberID],  
     [MemberResumeFile],  
     [MemberCoverLetterFile],  
     [ApplicationStatus],  
     [JobAppValidateID],  
     [SiteID_Referral],  
     [URL_Referral],  
     [ApplicantGrade],  
     [LastViewedDate],  
     [FirstName],  
     [Surname],  
     [EmailAddress],  
     [MobilePhone],  
     [MemberNote],  
     [AdvertiserNote],   
    (SELECT COUNT(1) FROM PageIndex) AS TotalCount  
     FROM PageIndex  
     WHERE RowIndex >= @PageStart        
     AND RowIndex <= @PageEnd        
     ORDER BY RowIndex   
     
    END  