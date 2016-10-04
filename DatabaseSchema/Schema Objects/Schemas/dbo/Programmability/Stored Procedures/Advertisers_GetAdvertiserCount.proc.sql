CREATE PROCEDURE Advertisers_GetAdvertiserCount  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
 DECLARE @AdvertiserCount TABLE  
 (  
  Title VARCHAR(255),  
  Total int  
 )  
   
 DECLARE @TotalAdvertiserCount AS INT  
 SET @TotalAdvertiserCount = (SELECT COUNT(*) FROM Advertisers WITH (NOLOCK)  
         WHERE (SiteID = @SiteID OR @SiteID = 0))  
  
 INSERT INTO @AdvertiserCount (Title, Total)  
 VALUES ('Total Advertiser Count', @TotalAdvertiserCount)  
  
 SELECT * FROM @AdvertiserCount   
  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END  