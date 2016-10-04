CREATE PROCEDURE [dbo].[AdvertiserUsers_GetAdvertiserUserPassword]  
      @Username VARCHAR(255),  
      @Email VARCHAR(255),  
      @SiteId INT  
AS  
BEGIN  

	IF ISNULL(@Username, '') != '' OR ISNULL(@Email, '') != ''  
	BEGIN  
		SELECT      
			au.AdvertiserUserID,  
			au.AdvertiserID,  
			au.PrimaryAccount,  
			au.UserName,  
			au.UserPassword,  
			au.FirstName,  
			au.Surname,  
			au.Email,  
			au.ApplicationEmailAddress,  
			au.Phone,  
			au.Fax,  
			au.AccountStatus,  
			au.Newsletter,  
			au.NewsletterFormat,  
			au.EmailFormat,  
			au.Validated,  
			au.ValidateGUID,  
			au.Description,  
			au.LastLoginDate,  
			au.LastModified,  
			au.LastModifiedBy  
		FROM
			AdvertiserUsers au WITH (NOLOCK) INNER JOIN Advertisers a  WITH (NOLOCK)  
			ON au.AdvertiserId = a.AdvertiserId  
		WHERE (UserName = @Username OR Email = @Email) AND a.SiteID = @SiteId AND au.Validated = 1  
	END  
END