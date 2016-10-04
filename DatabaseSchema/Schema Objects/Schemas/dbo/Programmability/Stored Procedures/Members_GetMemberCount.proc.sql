 
CREATE PROCEDURE Members_GetMemberCount  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
 DECLARE @MemberCount TABLE  
 (  
  Title VARCHAR(255),  
  Total int  
 )  
   
 DECLARE @ValidatedMemberCount AS INT  
 SET @ValidatedMemberCount = (SELECT COUNT(*) FROM Members WITH (NOLOCK)  
         WHERE (SiteID = @SiteID OR @SiteID = 0) AND Valid = 1)  
  
 DECLARE @TotalMemberCount AS INT  
 SET @TotalMemberCount = (SELECT COUNT(*) FROM Members WITH (NOLOCK)  
         WHERE (SiteID = @SiteID OR @SiteID = 0))  
  
 INSERT INTO @MemberCount (Title, Total)  
 VALUES ('Validated Member Count', @ValidatedMemberCount)  
     
  
 INSERT INTO @MemberCount (Title, Total)  
 VALUES ('Total Member Count', @TotalMemberCount)  
  
 SELECT * FROM @MemberCount  
  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END  