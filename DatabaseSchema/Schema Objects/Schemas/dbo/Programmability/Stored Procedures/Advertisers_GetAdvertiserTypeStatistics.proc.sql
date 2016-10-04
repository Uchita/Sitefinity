CREATE PROCEDURE Advertisers_GetAdvertiserTypeStatistics  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
 DECLARE @AdvertiserTypeStatistics TABLE  
 (  
  BusinessType int,  
  BusinessName varchar(255),  
  TotalJob int,  
  TotalApplication int,  
  TotalView int  
 )  
   
 INSERT INTO @AdvertiserTypeStatistics (BusinessType, BusinessName, TotalJob, TotalApplication, TotalView)  
 SELECT AdvertiserBusinessTypeID, AdvertiserBusinessTypeName, 0, 0, 0 FROM AdvertiserBusinessType WITH (NOLOCK)  
 -- Total Job  
   
  
 UPDATE @AdvertiserTypeStatistics SET TotalJob = (SELECT COUNT(*)   
           FROM Jobs j  WITH (NOLOCK) INNER JOIN Advertisers a  WITH (NOLOCK)  
           ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0))  
  
 -- Total Applications  
  
 UPDATE @AdvertiserTypeStatistics SET TotalApplication = (SELECT COUNT(*)   
           FROM JobApplication ja  WITH (NOLOCK)   
           INNER JOIN Jobs j  WITH (NOLOCK)   
           ON ja.JobID = j.JobID   
           INNER JOIN Advertisers a  WITH (NOLOCK)  
           ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0))  
  
 -- Total View  
  
 UPDATE @AdvertiserTypeStatistics SET TotalView = ISNULL((SELECT SUM(TotalView)   
           FROM JobViews jv  WITH (NOLOCK)  
           INNER JOIN Jobs j  WITH (NOLOCK) ON jv.JobID = j.JobID   
           INNER JOIN Advertisers a  WITH (NOLOCK) ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0)), 0)  
  
 SELECT * FROM @AdvertiserTypeStatistics  
  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END  