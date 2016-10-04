CREATE PROCEDURE dbo.AdvertiserJobTemplateLogo_GetPagingByAdvertiserId    
(    
 @AdvertiserId INT,  
 @PageSize INT,            
 @PageNumber INT  
)    
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
   
 DECLARE @tmpGetPagingByAdvertiserId TABLE         
 (        
   AdvertiserId INT NOT NULL PRIMARY KEY,         
   RowNumber INT NOT NULL        
 )  
  
 INSERT INTO @tmpGetPagingByAdvertiserId      
  
 SELECT AdvertiserId, ROW_NUMBER() OVER (ORDER BY AdvertiserId) AS RowNumber  
 FROM   AdvertiserJobTemplateLogo WITH (NOLOCK)  
 WHERE  (AdvertiserID = @AdvertiserId)  
  
    
 SELECT AdvertiserJobTemplateLogo.AdvertiserJobTemplateLogoID, AdvertiserJobTemplateLogo.AdvertiserID,   
  AdvertiserJobTemplateLogo.JobLogoName, AdvertiserJobTemplateLogo.JobTemplateLogo,  
  GetPagingByAdvertiserId.RowNumber AS RowNumber,  
  (SELECT COUNT(1) FROM @tmpGetPagingByAdvertiserId) AS TotalCount  
 FROM AdvertiserJobTemplateLogo AdvertiserJobTemplateLogo WITH(NOLOCK)    
 INNER JOIN @tmpGetPagingByAdvertiserId GetPagingByAdvertiserId  
  ON  AdvertiserJobTemplateLogo.AdvertiserId = GetPagingByAdvertiserId.AdvertiserId  
 WHERE  AdvertiserJobTemplateLogo.AdvertiserID = @AdvertiserId    
  
  
END   
    