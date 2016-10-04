CREATE VIEW [dbo].[ViewSiteAdvertisers]
	AS 
	SELECT     AdvertiserID, SiteID
	FROM         dbo.Advertisers WITH (NOLOCK)
	UNION
	SELECT     dbo.SiteAdvertiserFilter.AdvertiserID, dbo.SiteAdvertiserFilter.SiteID
	FROM         dbo.SiteAdvertiserFilter WITH (NOLOCK) INNER JOIN
						  dbo.GlobalSettings WITH (NOLOCK) ON dbo.SiteAdvertiserFilter.SiteID = dbo.GlobalSettings.SiteID
	WHERE     (dbo.GlobalSettings.UseAdvertiserFilter = 1)