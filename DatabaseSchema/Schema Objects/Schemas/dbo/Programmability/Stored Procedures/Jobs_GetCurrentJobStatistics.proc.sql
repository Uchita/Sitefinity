CREATE PROCEDURE [dbo].[Jobs_GetCurrentJobStatistics]
(
	@SiteId int,
	@AdvertiserId int,
	@SortField varchar(255),
	@SortASC bit
)
As
BEGIN
	Declare @inError bit
	Set @inError = 0

	-- Validate advertiser id
	If IsNull(@AdvertiserID, 0) <= 0
	Begin
		RaisError('Advertiser id is a required field.', 16, 1)
		Set @inerror = 1
	End
	Else
	If Not Exists(	Select	AdvertiserID
					From	Advertisers
					Where	AdvertiserID = @AdvertiserID)
	Begin
		RaisError('Advertiser id was not found in the database.', 16, 1)
		Set @inError = 1
	End

	-- Validate sort field
	If IsNull(@sortField, '') = ''
	Begin
		Set @sortField = 'DatePosted'
	End
	Else
	If @sortField Not In('JobName', 'RefNo', 'DatePosted', 'DaysTillExpiry', 'Views', 'Applications')
	Begin
		RaisError('Sort field was not found in the database.', 16, 1)
		Set @inError = 1
	End

	If @sortAsc is null
	Begin
		Set @sortAsc = 1
	End

	If @inError <> 0
		Return

	Declare @dateToday datetime
	Set @dateToday = dbo.fnGetDate(GETDATE())

	Declare @sql nvarchar(max)
	-- build the sql
	Set @sql = 'SELECT JobID, JobName, RefNo, DatePosted, DATEDIFF(day, dbo.fnGetDate(GETDATE()), dbo.fnGetDate(ExpiryDate)) AS DaysTillExpiry, '
	Set @sql = @sql + ' ISNULL((SELECT SUM(TotalView) FROM JobViews jv WHERE jv.JobID = j.JobID), 0) AS Views,'
	Set @sql = @sql + ' (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobID) AS Applications'
	Set @sql = @sql + ' FROM Jobs j'
	Set @sql = @sql + ' WHERE SiteID =  ' + CONVERT(varchar, @SiteId)
	Set @sql = @sql + ' AND AdvertiserID = '  + CONVERT(varchar, @AdvertiserId)
	Set @sql = @sql + ' AND (Expired = NULL OR Expired = 0)'
	Set @sql = @sql + ' AND Billed = 1 AND GETDATE() >= dbo.fnGetDate(DatePosted) '
	Set @sql = @sql + ' AND GETDATE() < dbo.fnGetDate(ExpiryDate)'
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