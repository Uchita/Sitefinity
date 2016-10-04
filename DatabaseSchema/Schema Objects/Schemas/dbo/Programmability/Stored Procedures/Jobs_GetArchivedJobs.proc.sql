CREATE PROCEDURE [dbo].[Jobs_GetArchivedJobs]    
(    
 @SiteId int,    
 @AdvertiserId int,    
 @CurrentOrderBy varchar (2000)  ,    
 @CurrentPageIndex int,    
 @CurrentPageSize int      
)    
AS    
BEGIN    
 DECLARE @PageLowerBound int    
 DECLARE @PageUpperBound int    
 DECLARE @WhereClause varchar (2000)     
    
 -- Set the page bounds    
 SET @PageLowerBound = @CurrentPageSize * @CurrentPageIndex    
 SET @PageUpperBound = @PageLowerBound + @CurrentPageSize    
    
 IF (@CurrentOrderBy IS NULL OR LEN(@CurrentOrderBy) < 1)    
 BEGIN    
  -- default order by to first column    
  SET @CurrentOrderBy = '[JobID] DESC'    
 END    
       
 SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)    
 SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)    
 SET @WhereClause = @WhereClause + ' AND Billed = 1'    
-- SET @WhereClause = @WhereClause + ' AND GETDATE() >= dbo.fnGetDate(DatePosted)'    
-- SET @WhereClause = @WhereClause + ' AND GETDATE() < dbo.fnGetDate(ExpiryDate)'    
     
     
 -- SQL Server 2005 Paging    
 DECLARE @SQL AS nvarchar(MAX)    
 SET @SQL = 'WITH PageIndex AS ('    
 SET @SQL = @SQL + ' SELECT'    
 IF @CurrentPageSize > 0    
 BEGIN    
  SET @SQL = @SQL + ' TOP ' + CONVERT(varchar, @PageUpperBound)    
 END    
 SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @CurrentOrderBy + ') as RowIndex'    
 SET @SQL = @SQL + ', [JobID]'    
 SET @SQL = @SQL + ', [JobName]'    
 SET @SQL = @SQL + ', [RefNo]'    
 SET @SQL = @SQL + ', [Views] = (SELECT COUNT(*) FROM JobViews jv WHERE jv.JobID = j.JobId)'    
 SET @SQL = @SQL + ', [Applications] = (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobId)'    
 SET @SQL = @SQL + ', [DatePosted]'    
 SET @SQL = @SQL + ', [ExpiryDate] FROM [dbo].[JobsArchive] j WITH (NOLOCK)'    
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
 IF @CurrentPageSize > 0    
 BEGIN    
  SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(varchar, @PageUpperBound)    
 END    
 SET @SQL = @SQL + ' ORDER BY ' + @CurrentOrderBy    
 EXEC sp_executesql @SQL    
 
   
 IF USER_NAME() IS NULL    
  BEGIN    
   SELECT [JobID], [JobName], [RefNo], [DatePosted]    
   FROM [dbo].[Jobs]  (NOLOCK) WHERE 1=0    
  END    
    
 -- get row count    
 SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'    
 SET @SQL = @SQL + ' FROM [dbo].[JobsArchive] (NOLOCK)'    
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