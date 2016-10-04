CREATE PROCEDURE Advertisers_GetAdvertisersNotPostedSince  
(  
 @SiteID int = 0,  
 @DaysSinceLastPost int = 0  
)  
AS  
BEGIN  
 DECLARE @DateNow DATETIME  
 DECLARE @DateStart DATETIME  
 SET @DateNow = dbo.fnGetDate(GETDATE())  
 SET @DateStart = dbo.fnGetDate(DATEADD(dd,@DaysSinceLastPost * -1, @DateNow))  
   
 SELECT DISTINCT AdvertiserID, CompanyName, AdvertiserBusinessTypeName, AccountsPayableEmail, AdvertiserAccountTypeName  
 FROM Advertisers a  WITH (NOLOCK)  
 INNER JOIN AdvertiserBusinessType abt WITH (NOLOCK)  
 ON a.AdvertiserBusinessTypeID = abt.AdvertiserBusinessTypeID  
 INNER JOIN AdvertiserAccountType aat WITH (NOLOCK)  
 ON a.AdvertiserAccountTypeID = aat.AdvertiserAccountTypeID  
 WHERE a.AdvertiserID NOT IN (SELECT DISTINCT AdvertiserID   
         FROM Jobs  WITH (NOLOCK)  
         WHERE (SiteID = @SiteID OR @SiteID = 0)   
         AND DatePosted > @DateStart   
         AND DatePosted <= @DateNow)  
  AND a.SiteID = @SiteID  
END  