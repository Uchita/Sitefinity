CREATE PROCEDURE [dbo].[Members_PeopleSearch]
(
      @SiteId INT,
      @PreferredCategoryId INT = NULL,
      @PreferredSubCategoryId INT = NULL,
      @PreferredSalaryId INT = NULL,
      @AvailabilityId INT = NULL,
      @CountryId INT = NULL,
      @LocationId INT = NULL,
      @AreaId INT = NULL,
      @SearchExpression VARCHAR(1000) = NULL,
      @OrderBy varchar (2000),
      @PageIndex int,
      @PageSize int  
)
AS
BEGIN
      DECLARE @PageLowerBound int
      DECLARE @PageUpperBound int
      DECLARE @WhereClause varchar (2000) 

      -- Set the page bounds
      SET @PageLowerBound = @PageSize * @PageIndex
      SET @PageUpperBound = @PageLowerBound + @PageSize

      IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
      BEGIN
            -- default order by to first column
            SET @OrderBy = '[FirstName]'
      END

      SET @PreferredCategoryId = ISNULL(@PreferredCategoryId, 0)
      SET @PreferredSubCategoryId = ISNULL(@PreferredSubCategoryId, 0)
      SET @PreferredSalaryId = ISNULL(@PreferredSalaryId, 0)
      SET @AvailabilityId = ISNULL(@AvailabilityId, 0)
      SET @CountryId = ISNULL(@CountryId, 0)
      SET @LocationId = ISNULL(@LocationId, 0)
      SET @AreaId = ISNULL(@AreaId, 0)
      SET @SearchExpression = ISNULL(@SearchExpression, '')

      SET @WhereClause = ' Valid = 1'
      SET @WhereClause = @WhereClause + ' AND SiteID =  ' + CONVERT(varchar, @SiteId)
      
      IF @PreferredCategoryId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (PreferredCategoryID = ' + CONVERT(varchar, @PreferredCategoryId) + ')'
      END 
      IF @PreferredSubCategoryId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (PreferredSubCategoryId = ' + CONVERT(varchar, @PreferredSubCategoryId) + ')'
      END
      IF @PreferredSalaryId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (PreferredSalaryID = ' + CONVERT(varchar, @PreferredSalaryId) + ')'
      END
      IF @AvailabilityId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (AvailabilityID = ' + CONVERT(varchar, @AvailabilityId) + ')'
      END
      IF @CountryId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (CountryId = ' + CONVERT(varchar, @CountryId) + ')'
      END 
      IF @LocationId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (LocationID = ' + CONVERT(varchar, @LocationId) + ')'
      END 
      IF @AreaId > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (AreaID = ' + CONVERT(varchar, @AreaId) + ')'
      END 
      IF LEN(@SearchExpression) > 0
      BEGIN
            SET @WhereClause = @WhereClause + ' AND (SearchField LIKE ''%' + @SearchExpression + '%'')'
      END

      -- SQL Server 2005 Paging
      DECLARE @SQL AS nvarchar(MAX)
      SET @SQL = 'WITH PageIndex AS ('
      SET @SQL = @SQL + ' SELECT'
      IF @PageSize > 0
      BEGIN
            SET @SQL = @SQL + ' TOP ' + CONVERT(varchar, @PageUpperBound)
      END
      SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
      SET @SQL = @SQL + ', [MemberID]'
      SET @SQL = @SQL + ', [FirstName]'
      SET @SQL = @SQL + ', [Surname]'
      SET @SQL = @SQL + ', [LocationID]'
      SET @SQL = @SQL + ', [AreaID]'
      SET @SQL = @SQL + ', [PreferredCategoryID]'
      SET @SQL = @SQL + ', [PreferredSubCategoryID]'
      SET @SQL = @SQL + ', [PreferredSalary] = ISNULL((SELECT SiteSalaryName FROM SiteSalary ss WHERE ss.SalaryID = m.PreferredSalaryID AND ss.SiteID = '  + CONVERT(varchar, @SiteId) + '), (SELECT SalaryName FROM Salary s WHERE s.SalaryID = m.PreferredSalaryID
))'
      SET @SQL = @SQL + ', [LastModifiedDate]'

      SET @SQL = @SQL + ' FROM Members m WITH (NOLOCK)'
      IF LEN(@WhereClause) > 0
      BEGIN
            SET @SQL = @SQL + ' WHERE ' + @WhereClause
      END
      SET @SQL = @SQL + ' ) SELECT'
      SET @SQL = @SQL + '  [MemberID]'
      SET @SQL = @SQL + ', [FirstName]'
      SET @SQL = @SQL + ', [Surname]'
      SET @SQL = @SQL + ', [LocationID]'
      SET @SQL = @SQL + ', [AreaID]'
      SET @SQL = @SQL + ', [PreferredCategoryID]'
      SET @SQL = @SQL + ', [PreferredSubCategoryID]'
      SET @SQL = @SQL + ', [PreferredSalary]'
      SET @SQL = @SQL + ', [LastModifiedDate]'
      SET @SQL = @SQL + ', [PreferredSalary] FROM PageIndex'
      SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(varchar, @PageLowerBound)
      IF @PageSize > 0
      BEGIN
            SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(varchar, @PageUpperBound)
      END
      SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
      EXEC sp_executesql @SQL

      
            IF USER_NAME() IS NULL
            BEGIN
                  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID], 
                           [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]
                  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0
            END

      -- get row count
      SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
      SET @SQL = @SQL + ' FROM [dbo].[Members] (NOLOCK)'
      IF LEN(@WhereClause) > 0
      BEGIN
            SET @SQL = @SQL + ' WHERE ' + @WhereClause
      END
      EXEC sp_executesql @SQL

            IF USER_NAME() IS NULL
            BEGIN
                  SELECT COUNT(*) AS TotalRowCount
                  FROM [dbo].[Members] (NOLOCK) WHERE 1=0
            END
END
