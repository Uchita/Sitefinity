CREATE PROCEDURE [dbo].[Jobs_GetAdvertiserJobs]
(
	@SiteId int,
	@AdvertiserId int,
	@Type varchar (2000),
	@OrderBy varchar (2000),
	@PageIndex int,
	@PageSize int  
)
AS
BEGIN 
	DECLARE @PageLowerBound int
	DECLARE @PageUpperBound int
	DECLARE @WhereClause varchar (2000)	
	Declare @inError bit
	Set @inError = 0

	-- Set the page bounds
	SET @PageLowerBound = @PageSize * @PageIndex
	SET @PageUpperBound = @PageLowerBound + @PageSize

	IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
	BEGIN
		-- default order by to first column
		SET @OrderBy = '[JobID] DESC'
	END
	
	IF @Type = 'Current'
	BEGIN
		SET @WhereClause = '(Expired = NULL OR Expired = 0)'
		SET @WhereClause = @WhereClause + ' AND SiteID = ' + CONVERT(varchar, @SiteId)
		SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)
		SET @WhereClause = @WhereClause + ' AND Billed = 1'
		SET @WhereClause = @WhereClause + ' AND GETDATE() >= dbo.fnGetDate(DatePosted)'
		SET @WhereClause = @WhereClause + ' AND GETDATE() <= DATEADD(DAY, 1, dbo.fnGetDate(ExpiryDate))'		
	END
	ELSE IF @Type = 'Draft'
	BEGIN
		SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)
		SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)
		SET @WhereClause = @WhereClause + ' AND Billed = 0'
	END
	ELSE
	BEGIN
		RaisError('Invalid Job Report Type.', 16, 1)
		Set @inError = 1
	END

	

	If @inError <> 0
		Return

	-- SQL Server 2005 Paging
	DECLARE @SQL AS nvarchar(MAX)
	SET @SQL = 'WITH PageIndex AS ('
	SET @SQL = @SQL + ' SELECT'
	IF @PageSize > 0
	BEGIN
		SET @SQL = @SQL + ' TOP ' + CONVERT(varchar, @PageUpperBound)
	END
	SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
	SET @SQL = @SQL + ', [JobID]'
	SET @SQL = @SQL + ', [JobName]'
	SET @SQL = @SQL + ', [RefNo]'
	SET @SQL = @SQL + ', [Views] = (SELECT COUNT(*) FROM JobViews jv WHERE jv.JobID = j.JobId)'
	SET @SQL = @SQL + ', [Applications] = (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobId)'
	SET @SQL = @SQL + ', [DatePosted]'
	SET @SQL = @SQL + ', [ExpiryDate] FROM [dbo].[Jobs] j WITH (NOLOCK)'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	SET @SQL = @SQL + ' ) SELECT'
	SET @SQL = @SQL + ' [JobID]'
	SET @SQL = @SQL + ', [JobName]'
	SET @SQL = @SQL + ', [RefNo]'
	SET @SQL = @SQL + ', [Views]'
	SET @SQL = @SQL + ', [Applications]'
	SET @SQL = @SQL + ', [DatePosted]'
	SET @SQL = @SQL + ', [ExpiryDate] FROM PageIndex'
	SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(varchar, @PageLowerBound)
	IF @PageSize > 0
	BEGIN
		SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(varchar, @PageUpperBound)
	END
	SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
	EXEC sp_executesql @SQL
	
	IF USER_NAME() IS NULL
		BEGIN
			SELECT [JobID], [JobName], [RefNo], [DatePosted]
			FROM [dbo].[Jobs]  (NOLOCK) WHERE 1=0
		END


	-- get row count
	SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
	SET @SQL = @SQL + ' FROM [dbo].[Jobs] (NOLOCK)'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	EXEC sp_executesql @SQL

	IF USER_NAME() IS NULL
		BEGIN
			SELECT COUNT(*) AS TotalRowCount
			FROM [dbo].[Jobs] (NOLOCK) WHERE 1=0
		END

END