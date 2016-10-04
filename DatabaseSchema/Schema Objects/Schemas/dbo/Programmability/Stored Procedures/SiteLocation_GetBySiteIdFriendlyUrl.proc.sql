  
CREATE PROCEDURE SiteLocation_GetBySiteIdFriendlyUrl  
(  
 @SiteID INT,  
 @FriendlyUrl VARCHAR(255)  
)  
AS  
BEGIN   
 SELECT SiteLocationID, SiteID, LocationID, SiteLocationName, Valid, SiteLocationFriendlyUrl  
 FROM SiteLocation (NOLOCK)  
 WHERE SiteID = @SiteID AND SiteLocationFriendlyUrl = @FriendlyUrl  
END   