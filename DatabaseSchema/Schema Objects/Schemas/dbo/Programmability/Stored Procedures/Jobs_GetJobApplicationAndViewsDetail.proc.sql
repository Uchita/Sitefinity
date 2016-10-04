CREATE PROCEDURE Jobs_GetJobApplicationAndViewsDetail  
(  
 @SiteID int = 0,  
 @FromDate datetime,  
 @Duration int  
)  
AS  
BEGIN  
 DECLARE @ViewsApplication TABLE  
 (  
  ReportDate datetime,  
  ViewsTotal int,  
  ApplicationTotal int  
 )  
  
 DECLARE @count INT  
 SET @count = 0  
 WHILE (@count < @Duration)  
 BEGIN  
  DECLARE @StartDate datetime  
  DECLARE @EndDate datetime  
  
  SET @StartDate = dbo.fnGetDate(DATEADD(dd, @count * -1, @FromDate))  
  SET @EndDate = dbo.fnGetDate(DATEADD(dd, (@count * -1) + 1, @FromDate))  
    
  INSERT INTO @ViewsApplication (ReportDate) VALUES (@StartDate)  
    
  UPDATE @ViewsApplication SET ViewsTotal = ISNULL((SELECT SUM(TotalView)   
             FROM JobViews WITH (NOLOCK)  
             WHERE ViewDate >= @StartDate AND ViewDate < @EndDate   
             AND (SiteID = @SiteID OR @SiteID = 0)), 0)  
  WHERE ReportDate = @StartDate  
  
  UPDATE @ViewsApplication SET ApplicationTotal = (SELECT COUNT(*)   
             FROM JobApplication ja  WITH (NOLOCK)  
             INNER JOIN Jobs j WITH (NOLOCK)  
             ON ja.JobID = j.JobID  
             WHERE ApplicationDate >= @StartDate AND ApplicationDate < @EndDate   
             AND (SiteID = @SiteID OR @SiteID = 0))  
  WHERE ReportDate = @StartDate  
  
  SET @count = (@count + 1)  
 END  
  
 SELECT * FROM @ViewsApplication  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END  