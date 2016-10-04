CREATE PROCEDURE Advertisers_GetAllJobStatistics  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
  
 DECLARE @JobsStatistics TABLE  
 (  
  JobStatus varchar(255),  
  TotalView int,  
  TotalApplication int  
 )  
   
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)  
 VALUES ('Current', 0, 0)  
  
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)  
 VALUES ('Archived', 0, 0)  
  
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)  
 VALUES ('Draft', 0, 0)  
  
 -- Current  
 UPDATE @JobsStatistics   
 SET TotalView = ISNULL((SELECT SUM(TotalView)   
       FROM JobViews jv  WITH (NOLOCK)  
       INNER JOIN Jobs j  WITH (NOLOCK)  
       ON jv.JobID = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)  
       AND (Expired = NULL OR Expired = 0)  
       AND Billed = 1 AND GETDATE() >= dbo.fnGetDate(DatePosted)  
       AND GETDATE() < dbo.fnGetDate(ExpiryDate)), 0)  
 WHERE JobStatus = 'Current'  
  
 UPDATE @JobsStatistics   
 SET TotalApplication = (SELECT COUNT(*)   
       FROM JobApplication ja WITH (NOLOCK)  
       INNER JOIN Jobs j  WITH (NOLOCK)  
       ON ja.JobID = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)  
       AND (Expired = NULL OR Expired = 0)  
       AND Billed = 1 AND GETDATE() >= dbo.fnGetDate(DatePosted)  
       AND GETDATE() < dbo.fnGetDate(ExpiryDate))  
 WHERE JobStatus = 'Current'  
  
 -- Archived  
 UPDATE @JobsStatistics   
 SET TotalView = ISNULL((SELECT SUM(TotalView)   
       FROM JobViews jv WITH (NOLOCK)  
       INNER JOIN JobsArchive ja WITH (NOLOCK)  
       ON jv.JobID = ja.JobID  
       WHERE (ja.SiteID = @SiteID OR @SiteID = 0)), 0)  
 WHERE JobStatus = 'Archived'  
  
 UPDATE @JobsStatistics   
 SET TotalApplication = (SELECT COUNT(*)   
       FROM JobApplication ja WITH (NOLOCK)  
       INNER JOIN JobsArchive j WITH (NOLOCK)  
       ON ja.JobID = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0))  
 WHERE JobStatus = 'Archived'  
   
 -- Archived  
 UPDATE @JobsStatistics   
 SET TotalView = ISNULL((SELECT SUM(TotalView)   
       FROM JobViews jv  WITH (NOLOCK)  
       INNER JOIN Jobs j  WITH (NOLOCK)  
       ON jv.JobID = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)  
       AND Billed = 0), 0)  
 WHERE JobStatus = 'Draft'  
  
 UPDATE @JobsStatistics   
 SET TotalApplication = (SELECT COUNT(*)   
       FROM JobApplication ja WITH (NOLOCK)  
       INNER JOIN Jobs j  WITH (NOLOCK)  
       ON ja.JobID = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)  
       AND Billed = 0)  
 WHERE JobStatus = 'Draft'  
        
 SELECT * FROM @JobsStatistics  
  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END  