USE [MiniJXT]
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetStatistics]    Script Date: 04/10/2017 09:12:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetStatistics]        
(        
 @SiteId int,        
 @AdvertiserId int,    
 @EnteredByAdvertiserUserID int        
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
     
 DECLARE @PrimaryAccount BIT     
 SET @PrimaryAccount = 0    
     
 SET @PrimaryAccount = (SELECT PrimaryAccount FROM AdvertiserUsers WHERE AdvertiserUserID = @EnteredByAdvertiserUserID)     
 IF @EnteredByAdvertiserUserID = 0    
 BEGIN    
 SET @PrimaryAccount = 1    
 END    
         
 SET @LiveNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId       
           AND (Expired = NULL OR Expired = 0)
           AND GETDATE() >= dbo.fnGetDate(DatePosted) AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
           AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))     
                 
      
 SET @LiveApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
              AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
              AND GETDATE() >= dbo.fnGetDate(j.DatePosted)       
              AND GETDATE() < dbo.fnGetDate(j.ExpiryDate)    
               AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
               AND  ISNULL(ja.Draft,0) = 0)       
                  
      
 SET @LiveViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
              AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
              AND GETDATE() >= dbo.fnGetDate(j.DatePosted)      
              AND GETDATE() < dbo.fnGetDate(j.ExpiryDate)    
               AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelLiveJobs', 'JobsCurrent.aspx', @LiveNumber, @LiveApplications, ISNULL(@LiveViewed, 0))        
         
 -- Jobs expiring in 24hrs        
         
 DECLARE @ExpiringNumber INT        
 DECLARE @ExpiringApplications INT        
 DECLARE @ExpiringViewed INT        
         
 SET @ExpiringNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
            AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))  AND (Expired = NULL OR Expired = 0)      
            AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @ExpiringApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
               AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))       
               AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @ExpiringViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)
               AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))       
               AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelJobsExpiringIn24hrs', '', @ExpiringNumber, @ExpiringApplications, ISNULL(@ExpiringViewed, 0))    

 -- Pending Jobs        
 DECLARE @JobScreeningProcess BIT
 SET @JobScreeningProcess = (SELECT JobScreeningProcess FROM GlobalSettings WHERE SiteID = @SiteID)

 DECLARE @PendingNumber INT        
 DECLARE @PendingApplications INT        
 DECLARE @PendingViewed INT   
  
 DECLARE @DeclinedNumber INT        
 DECLARE @DeclinedApplications INT        
 DECLARE @DeclinedViewed INT        
         
IF @JobScreeningProcess = 1
BEGIN

 SET @PendingNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
             AND Expired = 2
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @PendingApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId
               AND j.Expired = 2    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @PendingViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId
               AND Expired = 2
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelPendingJobs', '', @PendingNumber, @PendingApplications, ISNULL(@PendingViewed, 0))
 
 -- Declined  
 SET @DeclinedNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
             AND Expired = 4
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @DeclinedApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId
               AND j.Expired = 4    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @DeclinedViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId
               AND Expired = 4
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelDeclinedJobs', '', @DeclinedNumber, @DeclinedApplications, ISNULL(@DeclinedViewed, 0))
 
    
END
ELSE
BEGIN
	SET @PendingNumber = 0       
	SET @PendingApplications = 0  
	SET @PendingViewed = 0
	
	SET @DeclinedNumber = 0       
	SET @DeclinedApplications = 0  
	SET @DeclinedViewed = 0
END 
 -- Draft Jobs        
         
 DECLARE @DraftNumber INT        
 DECLARE @DraftApplications INT        
 DECLARE @DraftViewed INT        
         
 SET @DraftNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND Expired = 3  AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))         
 SET @DraftApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
             AND j.AdvertiserID = @AdvertiserId AND Expired = 3    
              AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)) AND ISNULL(ja.Draft,0) = 0)        
              
      
 SET @DraftViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
             AND j.AdvertiserID = @AdvertiserId AND Expired = 3   
              AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelDraftJobs', 'JobsDraft.aspx', @DraftNumber, @DraftApplications, ISNULL(@DraftViewed, 0))        
         
 -- Archived Jobs        
         
 DECLARE @ArchivedNumber INT        
 DECLARE @ArchivedApplications INT        
 DECLARE @ArchivedViewed INT        
         
 SET @ArchivedNumber = (SELECT COUNT(*) FROM JobsArchive WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))   

 
 SET @ArchivedApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN JobsArchive j ON ja.JobArchiveID = j.JobID       
         WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId 
          AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
          AND ISNULL(ja.Draft,0) = 0)        
      
 SET @ArchivedViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN JobsArchive j ON jv.JobArchiveID = j.JobID       
       WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId 
        AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES ('LabelArchivedJobs', 'JobsArchived.aspx', @ArchivedNumber, @ArchivedApplications, ISNULL(@ArchivedViewed, 0))        
 -- Total        
         
 DECLARE @TotalNumber INT        
 DECLARE @TotalApplications INT        
 DECLARE @TotalViewed INT        
         
 SET @TotalNumber = @LiveNumber + @ExpiringNumber + @PendingNumber + @DeclinedNumber + @DraftNumber + @ArchivedNumber        
 SET @TotalApplications = @LiveApplications + @ExpiringApplications + @PendingApplications + @DeclinedApplications + @DraftApplications + @ArchivedApplications        
 SET @TotalViewed = ISNULL(@LiveViewed, 0) + ISNULL(@ExpiringViewed, 0) + ISNULL(@PendingViewed, 0) + ISNULL(@DeclinedViewed, 0) + ISNULL(@DraftViewed, 0) + ISNULL(@ArchivedViewed, 0)        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)      
 VALUES ('LabelTotal', '', @TotalNumber, @TotalApplications, @TotalViewed)        
         
 -- Get Result        
         
 SELECT ReportName, ReportURL, Number, Applications, Viewed FROM @StatTotals        
         
 END