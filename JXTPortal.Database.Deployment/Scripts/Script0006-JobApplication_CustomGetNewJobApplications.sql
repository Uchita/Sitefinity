IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobApplication_CustomGetNewJobApplications]
GO

CREATE PROCEDURE [dbo].[JobApplication_CustomGetNewJobApplications]                  
(                  
 @SiteID INT,                        
 @JobApplicationID INT = 0,          
 @AdvertiserUserID INT = 0          
)                  
AS                  
BEGIN             
      
DECLARE @isPrimary BIT = 0        
 DECLARE @AdvertiserID INT = 0        
        
 IF (@AdvertiserUserID > 0)        
 BEGIN        
 SET @isPrimary = (SELECT PrimaryAccount FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)        
 IF(@isPrimary = 1)        
 BEGIN        
  SET @AdvertiserID = (SELECT AdvertiserID FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)         
 END        
 END        
       
 DECLARE @tmpJobApplication AS TABLE(JobApplicationID INT, RefNo VARCHAR(255), JobID INT)      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, j.RefNo, j.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN Jobs j WITH (NOLOCK)                
 ON ja.JobID = j.JobID      
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (j.Expired = 0 OR j.Expired = 1)  AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND j.AdvertiserID = @AdvertiserID) OR (@AdvertiserUserID > 0 AND (j.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (j.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, jarchive.RefNo, jarchive.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN JobsArchive jarchive WITH (NOLOCK)                
 ON ja.JobArchiveID = jarchive.JobID                
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (jarchive.Expired = 0 OR jarchive.Expired = 1) AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND (jarchive.AdvertiserID = @AdvertiserID)) OR (@AdvertiserUserID > 0 AND  (jarchive.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (jarchive.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 DECLARE @tmpJobApplicationArea AS TABLE(JobID INT, AreaID INT)      
 INSERT INTO @tmpJobApplicationArea      
 SELECT DISTINCT ja.JobID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobID IN (SELECT JobID FROM @tmpJobApplication)       
UNION      
SELECT DISTINCT ja.JobArchiveID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobArchiveID IN (SELECT JobID FROM @tmpJobApplication)       
      
      
 DECLARE @tmpJobApplicationAbbr AS TABLE(JobID INT, Abbr NVARCHAR(400))      
 INSERT INTO @tmpJobApplicationAbbr      
 SELECT jaa.JobID, Abbr FROM @tmpJobApplicationArea jaa      
 INNER JOIN Area a  WITH (NOLOCK)                
 ON jaa.AreaID = a.AreaID      
 INNER JOIN Location l  WITH (NOLOCK)                
 ON a.LocationID = l.LocationID                
 INNER JOIN Countries c  WITH (NOLOCK)                
 ON l.CountryID = c.CountryID           
      
 SELECT ja.JobApplicationID, ja.ApplicationDate, m.FirstName, m.Surname, m.EmailAddress, m.MobilePhone, m.PreferredCategoryID, m.PreferredSubCategoryID, ja.MemberResumeFile, ja.MemberCoverLetterFile, ja.ApplicationStatus, c.Abbr, tja.RefNo, tja.JobID, ja.
  
Draft, ja.JobApplicationTypeID, ja.ExternalXMLFilename , ja.ExternalPDFFilename, ja.URL_Referral,ja.AppliedWith, ja.LastViewedDate, ja.MemberID               
 FROM @tmpJobApplication tja       
 INNER JOIN JobApplication ja WITH (NOLOCK)                
 ON tja.JobApplicationID = ja.JobApplicationID      
 INNER JOIN Members m WITH (NOLOCK) ON m.MemberID = ja.MemberID      
 INNER JOIN @tmpJobApplicationAbbr c      
 ON c.JobID = ja.JobID    or c.JobID = ja.JobArchiveID         
       
 ORDER BY ja.JobApplicationID        
      
END  