        
CREATE PROCEDURE AdvertiserUsers_AdminGetPaged          
 @SiteID INT = 0,  
 @AdvertiserID INT = 0,        
 @AdvertiserUserID INT = 0,        
 @UserName VARCHAR(255) = '',        
 @FirstName NVARCHAR(255) = '',        
 @Surname NVARCHAR(255) = '',        
 @Email VARCHAR(255) = '',        
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
        
 DECLARE @tmpAdvertiserUserID TABLE         
 (        
   AdvertiserUserID INT NOT NULL PRIMARY KEY,         
   RowNumber INT NOT NULL        
 )        
         
 INSERT INTO @tmpAdvertiserUserID         
        
 SELECT  AdvertiserUsers.AdvertiserUserID, ROW_NUMBER() OVER (ORDER BY AdvertiserUsers.UserName ) AS RowNumber        
 FROM  AdvertiserUsers AdvertiserUsers WITH(NOLOCK)        
 INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = AdvertiserUsers.LastModifiedBy        
 INNER JOIN EmailFormats EmailFormats WITH(NOLOCK) ON EmailFormats.EmailFormatID = AdvertiserUsers.EmailFormat    
 INNER JOIN Advertisers Advertisers WITH(NOLOCK) ON Advertisers.AdvertiserID = AdvertiserUsers.AdvertiserID        
 WHERE  (ISNULL(@AdvertiserID, 0) = 0 OR AdvertiserUsers.AdvertiserID = @AdvertiserID)  
 AND  (ISNULL(@SiteID, 0) = 0 OR Advertisers.SiteID = @SiteID)  
 AND  (ISNULL(@AdvertiserUserID, 0) = 0 OR AdvertiserUsers.AdvertiserUserID = @AdvertiserUserID)        
 AND  (ISNULL(@UserName, '') = '' OR AdvertiserUsers.UserName LIKE '%' + @UserName + '%')        
 AND  (ISNULL(@FirstName, '') = '' OR AdvertiserUsers.FirstName LIKE '%' + @FirstName + '%')        
 AND  (ISNULL(@Surname, '') = '' OR AdvertiserUsers.Surname LIKE '%' + @Surname + '%')        
 AND  (ISNULL(@Email, '') = '' OR AdvertiserUsers.Email LIKE '%' + @Email + '%')        
        
        
 SELECT  AdvertiserUserSearchResult.RowNumber AS RowNumber, AdvertiserUsers.AdvertiserID, AdvertiserUsers.AdvertiserUserID,        
   Advertisers.CompanyName AS CompanyName, AdvertiserUsers.PrimaryAccount, AdvertiserUsers.UserName, AdvertiserUsers.FirstName, AdvertiserUsers.Surname,     
   AdvertiserUsers.Email, EmailFormats.EmailFormatName AS EmailFormatName, AdvertiserUsers.Validated, AdvertiserUsers.LastLoginDate,        
   AdvertiserUsers.LastModified, AdminUsers.UserName AS AdminUserName, Advertisers.SiteID,  
   (SELECT COUNT(1) FROM @tmpAdvertiserUserID) AS TotalCount        
 FROM  AdvertiserUsers AdvertiserUsers WITH(NOLOCK)        
 INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = AdvertiserUsers.LastModifiedBy        
 INNER JOIN EmailFormats EmailFormats WITH(NOLOCK) ON EmailFormats.EmailFormatID = AdvertiserUsers.EmailFormat    
 INNER JOIN Advertisers Advertisers WITH(NOLOCK) ON Advertisers.AdvertiserID = AdvertiserUsers.AdvertiserID    
 INNER JOIN @tmpAdvertiserUserID AdvertiserUserSearchResult ON AdvertiserUsers.AdvertiserUserID = AdvertiserUserSearchResult.AdvertiserUserID        
 WHERE  AdvertiserUserSearchResult.RowNumber >= @PageStart        
 AND  AdvertiserUserSearchResult.RowNumber <= @PageEnd        
 ORDER BY AdvertiserUserSearchResult.RowNumber        
        
END 