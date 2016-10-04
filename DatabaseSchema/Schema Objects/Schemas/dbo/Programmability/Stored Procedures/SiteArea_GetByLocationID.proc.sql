CREATE PROCEDURE [dbo].[SiteArea_GetByLocationID]
	@SiteId INT,
	@LocationId INT
AS
	SET ANSI_NULLS OFF
				
		SELECT
			[SiteArea].[SiteAreaID],
			[SiteArea].[AreaID],
			[SiteArea].[SiteID],
			[SiteArea].[SiteAreaName],
			[SiteArea].[Valid]
		FROM
			[dbo].[SiteArea] (NOLOCK) SiteArea
		INNER JOIN [dbo].[Area] (NOLOCK) Area
		ON [Area].[AreaID] = [SiteArea].[AreaID]
		WHERE
			[SiteArea].[SiteID] = @SiteId
		AND [Area].[LocationID] = @LocationId
		
		SELECT @@ROWCOUNT
		SET ANSI_NULLS ON
			


