CREATE PROCEDURE SiteWorkType_GetBySiteIdFriendlyUrl  
(  
 @SiteID INT,  
 @FriendlyUrl VARCHAR(255)  
)  
AS  
BEGIN   
 SELECT SiteWorkTypeID, SiteID, WorkTypeID, SiteWorkTypeName, Valid, Sequence, SiteWorkTypeFriendlyUrl  
 FROM SiteWorkType (NOLOCK)  
 WHERE SiteID = @SiteID AND SiteWorkTypeFriendlyUrl = @FriendlyUrl  
END   