  
CREATE PROCEDURE SiteCountries_GetBySiteIdFriendlyUrl  
(  
 @SiteID INT,  
 @FriendlyUrl VARCHAR(255)  
)  
AS  
BEGIN   
 SELECT SiteCountryID, SiteID, CountryID, SiteCountryName  
 FROM SiteCountries (NOLOCK)  
 WHERE SiteID = @SiteID AND SiteCountryFriendlyUrl = @FriendlyUrl  
END   