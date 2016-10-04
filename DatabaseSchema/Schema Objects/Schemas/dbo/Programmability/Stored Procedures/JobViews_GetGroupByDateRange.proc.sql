CREATE PROCEDURE [dbo].[JobViews_GetGroupByDateRange]
	@SiteID INT,
	@DateFrom SMALLDATETIME,
	@DateTo SMALLDATETIME
AS
	SELECT SiteID, ViewDate, COUNT(1) AS TotalView
    FROM [dbo].[JobViews] (NOLOCK)
    WHERE ViewDate BETWEEN @DateFrom AND @DateTo
    GROUP BY SiteID, ViewDate