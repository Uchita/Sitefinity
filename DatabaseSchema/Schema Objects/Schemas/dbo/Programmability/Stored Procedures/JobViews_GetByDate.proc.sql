CREATE PROCEDURE [dbo].[JobViews_GetByDate]
	@SiteID INT,
	@ViewDate SMALLDATETIME
AS
	SELECT SiteID, JobID, JobArchiveID, ViewDate, COUNT(1) AS TotalView
    FROM [dbo].[JobViews] (NOLOCK)
    WHERE ViewDate = @ViewDate
    GROUP BY SiteID, JobID, ViewDate