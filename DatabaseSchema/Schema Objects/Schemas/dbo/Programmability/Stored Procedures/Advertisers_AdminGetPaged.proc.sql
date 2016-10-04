CREATE PROCEDURE Advertisers_AdminGetPaged      
 @AdvertiserID INT = 0,  
 @SiteID INT = 0,   
 @AdvertiserAccountTypeID INT = 0,  
 @AdvertiserBusinessTypeID INT = 0,  
 @AdvertiserAccountStatusID INT = 0,  
 @CompanyName NVARCHAR(255) = '',  
 @PageSize INT,    
 @PageNumber INT    
AS  
BEGIN   
  
 IF @PageSize IS NULL    
  SET @pageSize = 10    
    
 IF @PageNumber IS NULL    
  SET @PageNumber = 1    
    
 Declare @pageStart int    
 Declare @pageEnd int    
    
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1    
 SET @PageEnd = (@PageNumber * @PageSize)   
  
 DECLARE @tmpAdvertiserID TABLE   
 (  
   AdvertiserID INT NOT NULL PRIMARY KEY,   
   RowNumber INT NOT NULL  
 )  
   
 INSERT INTO @tmpAdvertiserID  
  
SELECT  Advertisers.AdvertiserID, ROW_NUMBER() OVER (ORDER BY Advertisers.CompanyName) AS RowNumber  
FROM  Advertisers Advertisers WITH(NOLOCK)  
	INNER JOIN AdvertiserAccountType AdvertiserAccountType WITH(NOLOCK) ON AdvertiserAccountType.AdvertiserAccountTypeID = Advertisers.AdvertiserAccountTypeID   
	INNER JOIN AdvertiserBusinessType AdvertiserBusinessType WITH(NOLOCK) ON AdvertiserBusinessType.AdvertiserBusinessTypeID = Advertisers.AdvertiserBusinessTypeID  
	INNER JOIN AdvertiserAccountStatus AdvertiserAccountStatus WITH(NOLOCK) ON AdvertiserAccountStatus.AdvertiserAccountStatusID = Advertisers.AdvertiserAccountStatusID  
	INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = Advertisers.LastModifiedBy  
WHERE  (ISNULL(@AdvertiserID, 0) = 0 OR Advertisers.AdvertiserID = @AdvertiserID)  
	AND  (ISNULL(@SiteID, 0) = 0 OR Advertisers.SiteID = @SiteID)  
	AND  (ISNULL(@AdvertiserAccountTypeID, 0) = 0 OR Advertisers.AdvertiserAccountTypeID = @AdvertiserAccountTypeID)  
	AND  (ISNULL(@AdvertiserBusinessTypeID, 0) = 0 OR Advertisers.AdvertiserBusinessTypeID = @AdvertiserBusinessTypeID)  
	AND  (ISNULL(@AdvertiserAccountStatusID, 0) = 0 OR Advertisers.AdvertiserAccountStatusID = @AdvertiserAccountStatusID)  
	AND  (ISNULL(@CompanyName, '') = '' OR Advertisers.CompanyName LIKE '%' + @CompanyName + '%')  
  
   
SELECT  AdvertiserSearchtResult.RowNumber AS RowNumber, Advertisers.AdvertiserID, Advertisers.SiteID,  
	AdvertiserAccountType.AdvertiserAccountTypeName AS AdvertiserAccountTypeName,  
	AdvertiserBusinessType.AdvertiserBusinessTypeName AS AdvertiserBusinessTypeName,  
	AdvertiserAccountStatus.AdvertiserAccountStatusName AS AdvertiserAccountStatusName,  
	Advertisers.CompanyName, Advertisers.NoOfEmployees, Advertisers.FirstApprovedDate, Advertisers.LastModified,  
	AdminUsers.UserName AS LastModifiedBy, (SELECT COUNT(1) FROM @tmpAdvertiserID) AS TotalCount  
FROM  Advertisers Advertisers WITH(NOLOCK)  
	INNER JOIN AdvertiserAccountType AdvertiserAccountType WITH(NOLOCK) ON AdvertiserAccountType.AdvertiserAccountTypeID = Advertisers.AdvertiserAccountTypeID   
	INNER JOIN AdvertiserBusinessType AdvertiserBusinessType WITH(NOLOCK) ON AdvertiserBusinessType.AdvertiserBusinessTypeID = Advertisers.AdvertiserBusinessTypeID  
	INNER JOIN AdvertiserAccountStatus AdvertiserAccountStatus WITH(NOLOCK) ON AdvertiserAccountStatus.AdvertiserAccountStatusID = Advertisers.AdvertiserAccountStatusID  
	INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = Advertisers.LastModifiedBy  
	INNER JOIN @tmpAdvertiserID AdvertiserSearchtResult ON Advertisers.AdvertiserID = AdvertiserSearchtResult.AdvertiserID   
WHERE  
	AdvertiserSearchtResult.RowNumber >= @PageStart AND  AdvertiserSearchtResult.RowNumber <= @PageEnd  
ORDER BY AdvertiserSearchtResult.RowNumber  
  
END