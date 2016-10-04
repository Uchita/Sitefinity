CREATE PROCEDURE Advertisers_GetAllAdvertisers  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
 SELECT AdvertiserID, CompanyName, AdvertiserBusinessTypeName, AccountsPayableEmail, AdvertiserAccountTypeName  
 FROM Advertisers a  WITH (NOLOCK)  
 INNER JOIN AdvertiserBusinessType abt WITH (NOLOCK)   
 ON a.AdvertiserBusinessTypeID = abt.AdvertiserBusinessTypeID  
 INNER JOIN AdvertiserAccountType aat WITH (NOLOCK)  
 ON a.AdvertiserAccountTypeID = aat.AdvertiserAccountTypeID  
 WHERE (SiteID = @SiteID OR @SiteID = 0)  
END  