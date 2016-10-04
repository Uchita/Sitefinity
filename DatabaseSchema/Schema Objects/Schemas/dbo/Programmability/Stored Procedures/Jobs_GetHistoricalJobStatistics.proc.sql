CREATE PROCEDURE [dbo].[Jobs_GetHistoricalJobStatistics]
(
	@SiteId int,
	@AdvertiserId int,
	@DateFrom datetime,	
	@DateTo datetime,
	@SortField varchar(255),
	@SortASC bit
)
As
BEGIN
	Declare @dateToday datetime
	Set @dateToday = dbo.fnGetDate(GETDATE())

	Declare @sql nvarchar(max)
	-- build the sql
	Set @sql = 'SELECT JobID, JobName, RefNo, DatePosted,'
	Set @sql = @sql + ' ISNULL((SELECT SUM(TotalView) FROM JobViews jv WHERE jv.JobID = j.JobID), 0) AS Views,'
	Set @sql = @sql + ' (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobID) AS Applications'
	Set @sql = @sql + ' FROM Jobs j'
	Set @sql = @sql + ' WHERE SiteID =  ' + CONVERT(varchar, @SiteId)
	Set @sql = @sql + ' AND AdvertiserID = '  + CONVERT(varchar, @AdvertiserId)
	Set @sql = @sql + ' AND Billed = 1'
	Set @sql = @sql + ' AND DatePosted BETWEEN ''' + CONVERT(varchar, @DateFrom, 120) + ''' AND ''' + CONVERT(varchar, @DateTo, 120)+ ''''
	Set @sql = @sql + ' Order By ' + @sortField 

	If @sortAsc = 1
	Begin
		Set @sql = @sql + ' asc'
	End
	Else
	Begin
		Set @sql = @sql + ' desc'
	End
	
	-- return results
	Exec sp_executesql @sql

	IF USER_NAME() IS NULL
		BEGIN
			SELECT [JobID], [JobName], [RefNo], [DatePosted]
			FROM [dbo].[Jobs]  (NOLOCK) WHERE 1=0
		END
END