CREATE PROCEDURE SiteProfession_GetBySiteIdFriendlyUrl  
(  
 @SiteID INT,  
 @FriendlyUrl VARCHAR(255)  
)  
AS  
BEGIN   
 SELECT SiteProfessionID, SiteID, ProfessionID, SiteProfessionName, Valid, SiteProfessionFriendlyUrl  
 FROM SiteProfession (NOLOCK)  
 WHERE SiteID = @SiteID AND SiteProfessionFriendlyUrl = @FriendlyUrl  
END   