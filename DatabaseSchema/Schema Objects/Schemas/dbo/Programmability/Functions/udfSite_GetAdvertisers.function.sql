CREATE FUNCTION [dbo].[udfSite_GetAdvertisers]       
(       
 @SiteID INT      
)      
RETURNS @tbl TABLE (AdvertiserId INT PRIMARY KEY) AS       
BEGIN      
        
 IF (EXISTS(SELECT 1 FROM dbo.GlobalSettings (NOLOCK) WHERE GlobalSettings.PublicJobsSearch = 0 AND GlobalSettings.SiteID = @SiteID))    
 BEGIN    
  -- GET ONLY PRIVATE JOBS WITH Advertiser Filter  
  INSERT @tbl(AdvertiserId)       
  SELECT DISTINCT      
  SiteAdvertiserFilter.AdvertiserID       
  FROM dbo.SiteAdvertiserFilter (NOLOCK)      
  WHERE SiteAdvertiserFilter.SiteID = @SiteID      
  AND EXISTS(SELECT 1 FROM dbo.GlobalSettings (NOLOCK) WHERE GlobalSettings.UseAdvertiserFilter = 1 AND GlobalSettings.SiteID = @SiteID)      
  UNION      
  SELECT Advertisers.AdvertiserID      
  FROM Advertisers (NOLOCK)      
  WHERE Advertisers.SiteID = @SiteID      
    
    
 END    
 ELSE    
 BEGIN    
      
  -- GET ALL PUBLIC JOBS WITH Advertiser Filter  
  INSERT @tbl(AdvertiserId)       
   SELECT DISTINCT      
    SiteAdvertiserFilter.AdvertiserID       
   FROM dbo.SiteAdvertiserFilter (NOLOCK)      
   WHERE SiteAdvertiserFilter.SiteID = @SiteID      
   AND EXISTS(SELECT 1 FROM dbo.GlobalSettings (NOLOCK) WHERE GlobalSettings.UseAdvertiserFilter = 1 AND GlobalSettings.SiteID = @SiteID)      
   UNION      
   SELECT Advertisers.AdvertiserID      
   FROM Advertisers (NOLOCK)      
   WHERE Advertisers.SiteID = @SiteID      
    
  UNION    
  SELECT Advertisers.AdvertiserID      
   FROM Advertisers (NOLOCK) INNER JOIN GlobalSettings (NOLOCK) on Advertisers.SiteID = GlobalSettings.SiteID    
   WHERE GlobalSettings.PublicJobsSearch = 1  and GlobalSettings.PrivateJobs = 0 and GlobalSettings.SiteID <> @SiteID    
    
 END    
     
 RETURN       
END    
    
  