CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByUserNameSiteId]
(
	@UserName varchar (255) = '',
	@SiteID int   
)
AS


SELECT
	  [AdvertiserUsers].[AdvertiserUserID],
	  [AdvertiserUsers].[AdvertiserID],
	  [AdvertiserUsers].[PrimaryAccount],
	  [AdvertiserUsers].[UserName],
	  [AdvertiserUsers].[UserPassword],
	  [AdvertiserUsers].[FirstName],
	  [AdvertiserUsers].[Surname],
	  [AdvertiserUsers].[Email],
	  [AdvertiserUsers].[ApplicationEmailAddress],
	  [AdvertiserUsers].[Phone],
	  [AdvertiserUsers].[Fax],
	  [AdvertiserUsers].[AccountStatus],
	  [AdvertiserUsers].[Newsletter],
	  [AdvertiserUsers].[NewsletterFormat],
	  [AdvertiserUsers].[EmailFormat],
	  [AdvertiserUsers].[Validated],
	  [AdvertiserUsers].[ValidateGUID],
	  [AdvertiserUsers].[Description],
	  [AdvertiserUsers].[LastLoginDate],
	  [AdvertiserUsers].[LastModified],
	  [AdvertiserUsers].[LastModifiedBy]
	FROM
	  [dbo].[AdvertiserUsers] (NOLOCK)
	INNER JOIN [dbo].[Advertisers] (NOLOCK)
	ON [AdvertiserUsers].[AdvertiserID] = [Advertisers].[AdvertiserID]
	WHERE
	  (
			((@UserName IS NULL) OR (@UserName = '') OR ([AdvertiserUsers].UserName = @UserName))
			AND [Advertisers].[SiteID] = @SiteID
	  )
SELECT @@ROWCOUNT

			
GO


