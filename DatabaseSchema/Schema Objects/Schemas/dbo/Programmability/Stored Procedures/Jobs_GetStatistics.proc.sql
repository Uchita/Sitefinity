CREATE PROCEDURE [dbo].[Jobs_GetStatistics]  
(  
 @SiteId int,  
 @AdvertiserId int  
)  
AS  
BEGIN  
  
DECLARE @StatTotals TABLE  
(  
 [ReportName] VARCHAR(200),  
 [ReportURL] VARCHAR(200),  
 [Number] INT,  
 [Applications] INT,  
 [Viewed] INT  
)  
  
-- Live Jobs  
  
DECLARE @LiveNumber INT  
DECLARE @LiveApplications INT  
DECLARE @LiveViewed INT  
  
SET @LiveNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0) AND Billed = 1 AND GETDATE() >= dbo.fnGetDate(DatePosted) AND GETDATE() < dbo.fnGetDate(ExpiryDate))  
SET @LiveApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0) AND j.Billed = 1 AND GETDATE() >= dbo.fnGetDate(j.DatePosted) AND GETDATE() < dbo.fnGetDate(j.ExpiryDate))  
SET @LiveViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0) AND j.Billed = 1 AND GETDATE() >= dbo.fnGetDate(j.DatePosted) AND GETDATE() < dbo.fnGetDate(j.ExpiryDate))  
  
INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)  
VALUES ('LabelLiveJobs', 'JobsCurrent.aspx', @LiveNumber, @LiveApplications, ISNULL(@LiveViewed, 0))  
  
-- Jobs expiring in 24hrs  
  
DECLARE @ExpiringNumber INT  
DECLARE @ExpiringApplications INT  
DECLARE @ExpiringViewed INT  
  
SET @ExpiringNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND Billed = 1 AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate)) AND GETDATE() < dbo.fnGetDate(ExpiryDate))  
SET @ExpiringApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 1 AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate)) AND GETDATE() < dbo.fnGetDate(ExpiryDate))  
SET @ExpiringViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 1 AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate)) AND GETDATE() < dbo.fnGetDate(ExpiryDate))  
  
INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)  
VALUES ('LabelJobsExpiringIn24hrs', '', @ExpiringNumber, @ExpiringApplications, ISNULL(@ExpiringViewed, 0))  
  
-- Draft Jobs  
  
DECLARE @DraftNumber INT  
DECLARE @DraftApplications INT  
DECLARE @DraftViewed INT  
  
SET @DraftNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND Billed = 0)  
SET @DraftApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 0)  
SET @DraftViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 0)  
  
INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)  
VALUES ('LabelDraftJobs', 'JobsDraft.aspx', @DraftNumber, @DraftApplications, ISNULL(@DraftViewed, 0))  
  
-- Archived Jobs  
  
DECLARE @ArchivedNumber INT  
DECLARE @ArchivedApplications INT  
DECLARE @ArchivedViewed INT  
  
SET @ArchivedNumber = (SELECT COUNT(*) FROM JobsArchive WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND Billed = 1)  
SET @ArchivedApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN JobsArchive j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 1)  
SET @ArchivedViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN JobsArchive j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId AND j.Billed = 1)  
  
INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)  
VALUES ('LabelArchivedJobs', 'JobsArchived.aspx', @ArchivedNumber, @ArchivedApplications, ISNULL(@ArchivedViewed, 0))  
  
-- Total  
  
DECLARE @TotalNumber INT  
DECLARE @TotalApplications INT  
DECLARE @TotalViewed INT  
  
SET @TotalNumber = @LiveNumber + @ExpiringNumber + @DraftNumber + @ArchivedNumber  
SET @TotalApplications = @LiveApplications + @ExpiringApplications + @DraftApplications + @ArchivedApplications  
SET @TotalViewed = ISNULL(@LiveViewed, 0) + ISNULL(@ExpiringViewed, 0) + ISNULL(@DraftViewed, 0) + ISNULL(@ArchivedViewed, 0)  
  
INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)  
VALUES ('LabelTotal', '', @TotalNumber, @TotalApplications, @TotalViewed)  
  
-- Get Result  
  
SELECT ReportName, ReportURL, Number, Applications, Viewed FROM @StatTotals  
  
END 
