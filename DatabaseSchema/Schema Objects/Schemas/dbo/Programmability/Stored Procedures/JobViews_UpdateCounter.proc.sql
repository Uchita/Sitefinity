CREATE PROCEDURE [dbo].[JobViews_UpdateCounter]
	@JobID INT,
	@SiteID INT,
	@ViewDate SMALLDATETIME
AS
	IF EXISTS(SELECT 1 FROM JobViews(NOLOCK) WHERE JobID = @JobID AND SiteID = @SiteID AND ViewDate = @ViewDate)
	BEGIN
		UPDATE JobViews SET TotalView = TotalView + 1
		WHERE JobID = @JobID AND SiteID = @SiteID AND ViewDate = @ViewDate 
	END
	ELSE
	BEGIN
		INSERT INTO JobViews(JobID, SiteID, ViewDate, TotalView)
		VALUES (@JobID, @SiteID, @ViewDate, 1)
	END