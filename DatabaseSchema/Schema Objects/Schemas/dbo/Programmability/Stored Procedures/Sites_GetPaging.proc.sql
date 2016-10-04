 
CREATE PROCEDURE Sites_GetPaging  
  @SiteID int = 0,  
  @SiteName VARCHAR(255) = '',  
  @SiteURL VARCHAR(500) = '',  
  @pageSize int,      
  @pageNumber int      
As  
  
BEGIN    
  
 IF @PageSize IS NULL      
  SET @pageSize = 10      
  
 IF @PageNumber IS NULL      
  SET @PageNumber = 1      
  
 Declare @pageStart int      
 Declare @pageEnd int      
  
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1      
 SET @PageEnd = (@PageNumber * @PageSize)      
  
 DECLARE @tmpSiteID TABLE     
 (    
   SiteID INT NOT NULL PRIMARY KEY,     
   RowNumber INT NOT NULL    
 )    
  
  INSERT INTO @tmpSiteID    
  
  SELECT  Sites.SiteID, ROW_NUMBER() OVER (ORDER BY Sites.SiteName) AS RowNumber      
  FROM    Sites Sites WITH(NOLOCK)    
  WHERE   (ISNULL(@SiteName, '') = '' OR Sites.SiteName like '%' + @SiteName + '%')      
  AND     (ISNULL(@SiteURL, '') = '' OR Sites.SiteURL Like '%' + @SiteURL + '%')      
  AND     (ISNULL(@SiteID, 0) = 0 OR Sites.SiteID = @SiteID)      
  
  SELECT  SitesSearchResult.RowNumber AS RowNumber, Sites.SiteID, Sites.SiteName, Sites.SiteURL,  
    Sites.SiteDescription, Sites.SiteAdminLogo, Sites.LastModified, Sites.LastModified, Live     
    --(SELECT COUNT(1) FROM @tmpSiteID) AS TotalCount    
  FROM   Sites Sites WITH(NOLOCK)  
  INNER JOIN @tmpSiteID SitesSearchResult ON Sites.SiteID = SitesSearchResult.SiteID  
  WHERE      SitesSearchResult.RowNumber >= @PageStart      
  AND        SitesSearchResult.RowNumber <= @PageEnd       
  ORDER BY   SitesSearchResult.RowNumber   
  
END  
    