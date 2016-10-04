CREATE PROCEDURE dbo.SiteAdvertiserFilter_GetNameBySiteId
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteAdvertiserFilter].[SiteAdvertiserFilterID],
					[SiteAdvertiserFilter].[SiteID],
					[SiteAdvertiserFilter].[AdvertiserID],
					[Advertisers].[CompanyName]
				FROM
					[dbo].[SiteAdvertiserFilter] (NOLOCK)
				INNER JOIN [dbo].[Advertisers] (NOLOCK) 
				ON [SiteAdvertiserFilter].[AdvertiserID] = [Advertisers].[AdvertiserID]
				WHERE
					[SiteAdvertiserFilter].[SiteID] = @SiteId