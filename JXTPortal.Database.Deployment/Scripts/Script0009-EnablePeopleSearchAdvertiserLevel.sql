ALTER TABLE Advertisers
ADD AllowPeopleSearchAccess BIT NOT NULL DEFAULT(0)
GO

DECLARE @tempTable table (siteID int)
INSERT INTO @tempTable
SELECT SiteID FROM GlobalSettings WHERE EnablePeopleSearch = 1

UPDATE Advertisers
SET AllowPeopleSearchAccess = 1
WHERE SiteID in (SELECT siteID FROM @tempTable)


/****** Object:  StoredProcedure [dbo].[Advertisers_Update]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Advertisers table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_Update]
(

	@AdvertiserId int   ,

	@SiteId int   ,

	@AdvertiserAccountTypeId int   ,

	@AdvertiserBusinessTypeId int   ,

	@AdvertiserAccountStatusId int   ,

	@CompanyName nvarchar (510)  ,

	@BusinessNumber nvarchar (255)  ,

	@StreetAddress1 nvarchar (255)  ,

	@StreetAddress2 nvarchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@PostalAddress1 nvarchar (255)  ,

	@PostalAddress2 nvarchar (255)  ,

	@WebAddress varchar (255)  ,

	@NoOfEmployees varchar (10)  ,

	@FirstApprovedDate smalldatetime   ,

	@Profile ntext   ,

	@CharityNumber varchar (50)  ,

	@SearchField nvarchar (MAX)  ,

	@FreeTrialStartDate smalldatetime   ,

	@FreeTrialEndDate smalldatetime   ,

	@AccountsPayableEmail varchar (255)  ,

	@RequireLogonForExternalApplication bit   ,

	@AdvertiserLogo image   ,

	@LinkedInLogo varchar (255)  ,

	@LinkedInCompanyId varchar (255)  ,

	@LinkedInEmail varchar (255)  ,

	@RegisterDate datetime   ,

	@ExternalAdvertiserId varchar (50)  ,

	@VideoLink varchar (500)  ,

	@Industry varchar (100)  ,

	@NominatedCompanyRole varchar (500)  ,

	@NominatedCompanyFirstName varchar (510)  ,

	@NominatedCompanyLastName nvarchar (510)  ,

	@NominatedCompanyEmailAddress nvarchar (255)  ,

	@NominatedCompanyPhone varchar (40)  ,

	@PreferredContactMethod int   ,

	@AdvertiserLogoUrl nvarchar (1000)  ,

	@AllowPeopleSearchAccess bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Advertisers]
				SET
					[SiteID] = @SiteId
					,[AdvertiserAccountTypeID] = @AdvertiserAccountTypeId
					,[AdvertiserBusinessTypeID] = @AdvertiserBusinessTypeId
					,[AdvertiserAccountStatusID] = @AdvertiserAccountStatusId
					,[CompanyName] = @CompanyName
					,[BusinessNumber] = @BusinessNumber
					,[StreetAddress1] = @StreetAddress1
					,[StreetAddress2] = @StreetAddress2
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
					,[PostalAddress1] = @PostalAddress1
					,[PostalAddress2] = @PostalAddress2
					,[WebAddress] = @WebAddress
					,[NoOfEmployees] = @NoOfEmployees
					,[FirstApprovedDate] = @FirstApprovedDate
					,[Profile] = @Profile
					,[CharityNumber] = @CharityNumber
					,[SearchField] = @SearchField
					,[FreeTrialStartDate] = @FreeTrialStartDate
					,[FreeTrialEndDate] = @FreeTrialEndDate
					,[AccountsPayableEmail] = @AccountsPayableEmail
					,[RequireLogonForExternalApplication] = @RequireLogonForExternalApplication
					,[AdvertiserLogo] = @AdvertiserLogo
					,[LinkedInLogo] = @LinkedInLogo
					,[LinkedInCompanyId] = @LinkedInCompanyId
					,[LinkedInEmail] = @LinkedInEmail
					,[RegisterDate] = @RegisterDate
					,[ExternalAdvertiserID] = @ExternalAdvertiserId
					,[VideoLink] = @VideoLink
					,[Industry] = @Industry
					,[NominatedCompanyRole] = @NominatedCompanyRole
					,[NominatedCompanyFirstName] = @NominatedCompanyFirstName
					,[NominatedCompanyLastName] = @NominatedCompanyLastName
					,[NominatedCompanyEmailAddress] = @NominatedCompanyEmailAddress
					,[NominatedCompanyPhone] = @NominatedCompanyPhone
					,[PreferredContactMethod] = @PreferredContactMethod
					,[AdvertiserLogoUrl] = @AdvertiserLogoUrl
					,[AllowPeopleSearchAccess] = @AllowPeopleSearchAccess
				WHERE
[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Insert]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Advertisers table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_Insert]
(

	@AdvertiserId int    OUTPUT,

	@SiteId int   ,

	@AdvertiserAccountTypeId int   ,

	@AdvertiserBusinessTypeId int   ,

	@AdvertiserAccountStatusId int   ,

	@CompanyName nvarchar (510)  ,

	@BusinessNumber nvarchar (255)  ,

	@StreetAddress1 nvarchar (255)  ,

	@StreetAddress2 nvarchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@PostalAddress1 nvarchar (255)  ,

	@PostalAddress2 nvarchar (255)  ,

	@WebAddress varchar (255)  ,

	@NoOfEmployees varchar (10)  ,

	@FirstApprovedDate smalldatetime   ,

	@Profile ntext   ,

	@CharityNumber varchar (50)  ,

	@SearchField nvarchar (MAX)  ,

	@FreeTrialStartDate smalldatetime   ,

	@FreeTrialEndDate smalldatetime   ,

	@AccountsPayableEmail varchar (255)  ,

	@RequireLogonForExternalApplication bit   ,

	@AdvertiserLogo image   ,

	@LinkedInLogo varchar (255)  ,

	@LinkedInCompanyId varchar (255)  ,

	@LinkedInEmail varchar (255)  ,

	@RegisterDate datetime   ,

	@ExternalAdvertiserId varchar (50)  ,

	@VideoLink varchar (500)  ,

	@Industry varchar (100)  ,

	@NominatedCompanyRole varchar (500)  ,

	@NominatedCompanyFirstName varchar (510)  ,

	@NominatedCompanyLastName nvarchar (510)  ,

	@NominatedCompanyEmailAddress nvarchar (255)  ,

	@NominatedCompanyPhone varchar (40)  ,

	@PreferredContactMethod int   ,

	@AdvertiserLogoUrl nvarchar (1000)  ,

	@AllowPeopleSearchAccess bit   
)
AS


				
				INSERT INTO [dbo].[Advertisers]
					(
					[SiteID]
					,[AdvertiserAccountTypeID]
					,[AdvertiserBusinessTypeID]
					,[AdvertiserAccountStatusID]
					,[CompanyName]
					,[BusinessNumber]
					,[StreetAddress1]
					,[StreetAddress2]
					,[LastModified]
					,[LastModifiedBy]
					,[PostalAddress1]
					,[PostalAddress2]
					,[WebAddress]
					,[NoOfEmployees]
					,[FirstApprovedDate]
					,[Profile]
					,[CharityNumber]
					,[SearchField]
					,[FreeTrialStartDate]
					,[FreeTrialEndDate]
					,[AccountsPayableEmail]
					,[RequireLogonForExternalApplication]
					,[AdvertiserLogo]
					,[LinkedInLogo]
					,[LinkedInCompanyId]
					,[LinkedInEmail]
					,[RegisterDate]
					,[ExternalAdvertiserID]
					,[VideoLink]
					,[Industry]
					,[NominatedCompanyRole]
					,[NominatedCompanyFirstName]
					,[NominatedCompanyLastName]
					,[NominatedCompanyEmailAddress]
					,[NominatedCompanyPhone]
					,[PreferredContactMethod]
					,[AdvertiserLogoUrl]
					,[AllowPeopleSearchAccess]
					)
				VALUES
					(
					@SiteId
					,@AdvertiserAccountTypeId
					,@AdvertiserBusinessTypeId
					,@AdvertiserAccountStatusId
					,@CompanyName
					,@BusinessNumber
					,@StreetAddress1
					,@StreetAddress2
					,@LastModified
					,@LastModifiedBy
					,@PostalAddress1
					,@PostalAddress2
					,@WebAddress
					,@NoOfEmployees
					,@FirstApprovedDate
					,@Profile
					,@CharityNumber
					,@SearchField
					,@FreeTrialStartDate
					,@FreeTrialEndDate
					,@AccountsPayableEmail
					,@RequireLogonForExternalApplication
					,@AdvertiserLogo
					,@LinkedInLogo
					,@LinkedInCompanyId
					,@LinkedInEmail
					,@RegisterDate
					,@ExternalAdvertiserId
					,@VideoLink
					,@Industry
					,@NominatedCompanyRole
					,@NominatedCompanyFirstName
					,@NominatedCompanyLastName
					,@NominatedCompanyEmailAddress
					,@NominatedCompanyPhone
					,@PreferredContactMethod
					,@AdvertiserLogoUrl
					,@AllowPeopleSearchAccess
					)
				
				-- Get the identity value
				SET @AdvertiserId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetPaged]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Advertisers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [AdvertiserID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([AdvertiserID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [AdvertiserID]'
				SET @SQL = @SQL + ' FROM [dbo].[Advertisers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[AdvertiserID], O.[SiteID], O.[AdvertiserAccountTypeID], O.[AdvertiserBusinessTypeID], O.[AdvertiserAccountStatusID], O.[CompanyName], O.[BusinessNumber], O.[StreetAddress1], O.[StreetAddress2], O.[LastModified], O.[LastModifiedBy], O.[PostalAddress1], O.[PostalAddress2], O.[WebAddress], O.[NoOfEmployees], O.[FirstApprovedDate], O.[Profile], O.[CharityNumber], O.[SearchField], O.[FreeTrialStartDate], O.[FreeTrialEndDate], O.[AccountsPayableEmail], O.[RequireLogonForExternalApplication], O.[AdvertiserLogo], O.[LinkedInLogo], O.[LinkedInCompanyId], O.[LinkedInEmail], O.[RegisterDate], O.[ExternalAdvertiserID], O.[VideoLink], O.[Industry], O.[NominatedCompanyRole], O.[NominatedCompanyFirstName], O.[NominatedCompanyLastName], O.[NominatedCompanyEmailAddress], O.[NominatedCompanyPhone], O.[PreferredContactMethod], O.[AdvertiserLogoUrl], O.[AllowPeopleSearchAccess]
				FROM
				    [dbo].[Advertisers] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[AdvertiserID] = PageIndex.[AdvertiserID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Advertisers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetBySiteId]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByLastModifiedBy]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserId]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserBusinessTypeId]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByAdvertiserBusinessTypeId]
(

	@AdvertiserBusinessTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserBusinessTypeID] = @AdvertiserBusinessTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserAccountTypeId]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountTypeId]
(

	@AdvertiserAccountTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserAccountTypeID] = @AdvertiserAccountTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserAccountStatusId]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountStatusId]
(

	@AdvertiserAccountStatusId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserAccountStatusID] = @AdvertiserAccountStatusId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Get_List]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Advertisers table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_Get_List]

AS


				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AdvertiserAccountTypeID],
					[AdvertiserBusinessTypeID],
					[AdvertiserAccountStatusID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[LastModifiedBy],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication],
					[AdvertiserLogo],
					[LinkedInLogo],
					[LinkedInCompanyId],
					[LinkedInEmail],
					[RegisterDate],
					[ExternalAdvertiserID],
					[VideoLink],
					[Industry],
					[NominatedCompanyRole],
					[NominatedCompanyFirstName],
					[NominatedCompanyLastName],
					[NominatedCompanyEmailAddress],
					[NominatedCompanyPhone],
					[PreferredContactMethod],
					[AdvertiserLogoUrl],
					[AllowPeopleSearchAccess]
				FROM
					[dbo].[Advertisers]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Find]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Advertisers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_Find]
(

	@SearchUsingOR bit   = null ,

	@AdvertiserId int   = null ,

	@SiteId int   = null ,

	@AdvertiserAccountTypeId int   = null ,

	@AdvertiserBusinessTypeId int   = null ,

	@AdvertiserAccountStatusId int   = null ,

	@CompanyName nvarchar (510)  = null ,

	@BusinessNumber nvarchar (255)  = null ,

	@StreetAddress1 nvarchar (255)  = null ,

	@StreetAddress2 nvarchar (255)  = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null ,

	@PostalAddress1 nvarchar (255)  = null ,

	@PostalAddress2 nvarchar (255)  = null ,

	@WebAddress varchar (255)  = null ,

	@NoOfEmployees varchar (10)  = null ,

	@FirstApprovedDate smalldatetime   = null ,

	@Profile ntext   = null ,

	@CharityNumber varchar (50)  = null ,

	@SearchField nvarchar (MAX)  = null ,

	@FreeTrialStartDate smalldatetime   = null ,

	@FreeTrialEndDate smalldatetime   = null ,

	@AccountsPayableEmail varchar (255)  = null ,

	@RequireLogonForExternalApplication bit   = null ,

	@AdvertiserLogo image   = null ,

	@LinkedInLogo varchar (255)  = null ,

	@LinkedInCompanyId varchar (255)  = null ,

	@LinkedInEmail varchar (255)  = null ,

	@RegisterDate datetime   = null ,

	@ExternalAdvertiserId varchar (50)  = null ,

	@VideoLink varchar (500)  = null ,

	@Industry varchar (100)  = null ,

	@NominatedCompanyRole varchar (500)  = null ,

	@NominatedCompanyFirstName varchar (510)  = null ,

	@NominatedCompanyLastName nvarchar (510)  = null ,

	@NominatedCompanyEmailAddress nvarchar (255)  = null ,

	@NominatedCompanyPhone varchar (40)  = null ,

	@PreferredContactMethod int   = null ,

	@AdvertiserLogoUrl nvarchar (1000)  = null ,

	@AllowPeopleSearchAccess bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvertiserID]
	, [SiteID]
	, [AdvertiserAccountTypeID]
	, [AdvertiserBusinessTypeID]
	, [AdvertiserAccountStatusID]
	, [CompanyName]
	, [BusinessNumber]
	, [StreetAddress1]
	, [StreetAddress2]
	, [LastModified]
	, [LastModifiedBy]
	, [PostalAddress1]
	, [PostalAddress2]
	, [WebAddress]
	, [NoOfEmployees]
	, [FirstApprovedDate]
	, [Profile]
	, [CharityNumber]
	, [SearchField]
	, [FreeTrialStartDate]
	, [FreeTrialEndDate]
	, [AccountsPayableEmail]
	, [RequireLogonForExternalApplication]
	, [AdvertiserLogo]
	, [LinkedInLogo]
	, [LinkedInCompanyId]
	, [LinkedInEmail]
	, [RegisterDate]
	, [ExternalAdvertiserID]
	, [VideoLink]
	, [Industry]
	, [NominatedCompanyRole]
	, [NominatedCompanyFirstName]
	, [NominatedCompanyLastName]
	, [NominatedCompanyEmailAddress]
	, [NominatedCompanyPhone]
	, [PreferredContactMethod]
	, [AdvertiserLogoUrl]
	, [AllowPeopleSearchAccess]
    FROM
	[dbo].[Advertisers]
    WHERE 
	 ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([AdvertiserAccountTypeID] = @AdvertiserAccountTypeId OR @AdvertiserAccountTypeId IS NULL)
	AND ([AdvertiserBusinessTypeID] = @AdvertiserBusinessTypeId OR @AdvertiserBusinessTypeId IS NULL)
	AND ([AdvertiserAccountStatusID] = @AdvertiserAccountStatusId OR @AdvertiserAccountStatusId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([BusinessNumber] = @BusinessNumber OR @BusinessNumber IS NULL)
	AND ([StreetAddress1] = @StreetAddress1 OR @StreetAddress1 IS NULL)
	AND ([StreetAddress2] = @StreetAddress2 OR @StreetAddress2 IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([PostalAddress1] = @PostalAddress1 OR @PostalAddress1 IS NULL)
	AND ([PostalAddress2] = @PostalAddress2 OR @PostalAddress2 IS NULL)
	AND ([WebAddress] = @WebAddress OR @WebAddress IS NULL)
	AND ([NoOfEmployees] = @NoOfEmployees OR @NoOfEmployees IS NULL)
	AND ([FirstApprovedDate] = @FirstApprovedDate OR @FirstApprovedDate IS NULL)
	AND ([CharityNumber] = @CharityNumber OR @CharityNumber IS NULL)
	AND ([SearchField] = @SearchField OR @SearchField IS NULL)
	AND ([FreeTrialStartDate] = @FreeTrialStartDate OR @FreeTrialStartDate IS NULL)
	AND ([FreeTrialEndDate] = @FreeTrialEndDate OR @FreeTrialEndDate IS NULL)
	AND ([AccountsPayableEmail] = @AccountsPayableEmail OR @AccountsPayableEmail IS NULL)
	AND ([RequireLogonForExternalApplication] = @RequireLogonForExternalApplication OR @RequireLogonForExternalApplication IS NULL)
	AND ([LinkedInLogo] = @LinkedInLogo OR @LinkedInLogo IS NULL)
	AND ([LinkedInCompanyId] = @LinkedInCompanyId OR @LinkedInCompanyId IS NULL)
	AND ([LinkedInEmail] = @LinkedInEmail OR @LinkedInEmail IS NULL)
	AND ([RegisterDate] = @RegisterDate OR @RegisterDate IS NULL)
	AND ([ExternalAdvertiserID] = @ExternalAdvertiserId OR @ExternalAdvertiserId IS NULL)
	AND ([VideoLink] = @VideoLink OR @VideoLink IS NULL)
	AND ([Industry] = @Industry OR @Industry IS NULL)
	AND ([NominatedCompanyRole] = @NominatedCompanyRole OR @NominatedCompanyRole IS NULL)
	AND ([NominatedCompanyFirstName] = @NominatedCompanyFirstName OR @NominatedCompanyFirstName IS NULL)
	AND ([NominatedCompanyLastName] = @NominatedCompanyLastName OR @NominatedCompanyLastName IS NULL)
	AND ([NominatedCompanyEmailAddress] = @NominatedCompanyEmailAddress OR @NominatedCompanyEmailAddress IS NULL)
	AND ([NominatedCompanyPhone] = @NominatedCompanyPhone OR @NominatedCompanyPhone IS NULL)
	AND ([PreferredContactMethod] = @PreferredContactMethod OR @PreferredContactMethod IS NULL)
	AND ([AdvertiserLogoUrl] = @AdvertiserLogoUrl OR @AdvertiserLogoUrl IS NULL)
	AND ([AllowPeopleSearchAccess] = @AllowPeopleSearchAccess OR @AllowPeopleSearchAccess IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvertiserID]
	, [SiteID]
	, [AdvertiserAccountTypeID]
	, [AdvertiserBusinessTypeID]
	, [AdvertiserAccountStatusID]
	, [CompanyName]
	, [BusinessNumber]
	, [StreetAddress1]
	, [StreetAddress2]
	, [LastModified]
	, [LastModifiedBy]
	, [PostalAddress1]
	, [PostalAddress2]
	, [WebAddress]
	, [NoOfEmployees]
	, [FirstApprovedDate]
	, [Profile]
	, [CharityNumber]
	, [SearchField]
	, [FreeTrialStartDate]
	, [FreeTrialEndDate]
	, [AccountsPayableEmail]
	, [RequireLogonForExternalApplication]
	, [AdvertiserLogo]
	, [LinkedInLogo]
	, [LinkedInCompanyId]
	, [LinkedInEmail]
	, [RegisterDate]
	, [ExternalAdvertiserID]
	, [VideoLink]
	, [Industry]
	, [NominatedCompanyRole]
	, [NominatedCompanyFirstName]
	, [NominatedCompanyLastName]
	, [NominatedCompanyEmailAddress]
	, [NominatedCompanyPhone]
	, [PreferredContactMethod]
	, [AdvertiserLogoUrl]
	, [AllowPeopleSearchAccess]
    FROM
	[dbo].[Advertisers]
    WHERE 
	 ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([AdvertiserAccountTypeID] = @AdvertiserAccountTypeId AND @AdvertiserAccountTypeId is not null)
	OR ([AdvertiserBusinessTypeID] = @AdvertiserBusinessTypeId AND @AdvertiserBusinessTypeId is not null)
	OR ([AdvertiserAccountStatusID] = @AdvertiserAccountStatusId AND @AdvertiserAccountStatusId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([BusinessNumber] = @BusinessNumber AND @BusinessNumber is not null)
	OR ([StreetAddress1] = @StreetAddress1 AND @StreetAddress1 is not null)
	OR ([StreetAddress2] = @StreetAddress2 AND @StreetAddress2 is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([PostalAddress1] = @PostalAddress1 AND @PostalAddress1 is not null)
	OR ([PostalAddress2] = @PostalAddress2 AND @PostalAddress2 is not null)
	OR ([WebAddress] = @WebAddress AND @WebAddress is not null)
	OR ([NoOfEmployees] = @NoOfEmployees AND @NoOfEmployees is not null)
	OR ([FirstApprovedDate] = @FirstApprovedDate AND @FirstApprovedDate is not null)
	OR ([CharityNumber] = @CharityNumber AND @CharityNumber is not null)
	OR ([SearchField] = @SearchField AND @SearchField is not null)
	OR ([FreeTrialStartDate] = @FreeTrialStartDate AND @FreeTrialStartDate is not null)
	OR ([FreeTrialEndDate] = @FreeTrialEndDate AND @FreeTrialEndDate is not null)
	OR ([AccountsPayableEmail] = @AccountsPayableEmail AND @AccountsPayableEmail is not null)
	OR ([RequireLogonForExternalApplication] = @RequireLogonForExternalApplication AND @RequireLogonForExternalApplication is not null)
	OR ([LinkedInLogo] = @LinkedInLogo AND @LinkedInLogo is not null)
	OR ([LinkedInCompanyId] = @LinkedInCompanyId AND @LinkedInCompanyId is not null)
	OR ([LinkedInEmail] = @LinkedInEmail AND @LinkedInEmail is not null)
	OR ([RegisterDate] = @RegisterDate AND @RegisterDate is not null)
	OR ([ExternalAdvertiserID] = @ExternalAdvertiserId AND @ExternalAdvertiserId is not null)
	OR ([VideoLink] = @VideoLink AND @VideoLink is not null)
	OR ([Industry] = @Industry AND @Industry is not null)
	OR ([NominatedCompanyRole] = @NominatedCompanyRole AND @NominatedCompanyRole is not null)
	OR ([NominatedCompanyFirstName] = @NominatedCompanyFirstName AND @NominatedCompanyFirstName is not null)
	OR ([NominatedCompanyLastName] = @NominatedCompanyLastName AND @NominatedCompanyLastName is not null)
	OR ([NominatedCompanyEmailAddress] = @NominatedCompanyEmailAddress AND @NominatedCompanyEmailAddress is not null)
	OR ([NominatedCompanyPhone] = @NominatedCompanyPhone AND @NominatedCompanyPhone is not null)
	OR ([PreferredContactMethod] = @PreferredContactMethod AND @PreferredContactMethod is not null)
	OR ([AdvertiserLogoUrl] = @AdvertiserLogoUrl AND @AdvertiserLogoUrl is not null)
	OR ([AllowPeopleSearchAccess] = @AllowPeopleSearchAccess AND @AllowPeopleSearchAccess is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Delete]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Advertisers table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_Delete]
(

	@AdvertiserId int   
)
AS


				DELETE FROM [dbo].[Advertisers] WITH (ROWLOCK) 
				WHERE
					[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetActivityReport]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[Advertisers_CustomGetActivityReport]      
(      
 @SiteID int,    
 @Keyword nvarchar(510) = NULL,    
 @DateFrom datetime = NULL, -- = '2015-03-05'    
 @DateTo datetime = NULL, -- = '2015-03-06'    
 @PageIndex int, -- = 0    
 @PageSize int,-- = 400    
 @OrderBy varchar(1000) = NULL,
 @IsDESC BIT 
)      
AS      
BEGIN      
      
DECLARE @PageLowerBound int    
DECLARE @PageUpperBound int    
    
-- Set the page bounds    
SET @PageLowerBound = @PageSize * @PageIndex    
SET @PageUpperBound = @PageLowerBound + @PageSize    

IF @OrderBy = 'LastJobPost'
BEGIN
	SET @OrderBy = '(SELECT MAX(DatePosted) FROM #tblJobs job WHERE job.AdvertiserUserID = tbl.AdvertiserUserID )'
END
IF @OrderBy = 'JobsLive'
BEGIN
	SET @OrderBy = '(SELECT COUNT(*) FROM #tblJobs job WHERE Expired = 0 AND job.AdvertiserUserID = tbl.AdvertiserUserID  AND GETDATE() >= dbo.fnGetDate(DatePosted) AND GETDATE() <= DATEADD(DAY, 1, dbo.fnGetDate(ExpiryDate)))'
END

IF @OrderBy = 'TotalJobs'
BEGIN
	SET @OrderBy = '(SELECT COUNT(*) FROM #tblJobs job WHERE job.AdvertiserUserID = tbl.AdvertiserUserID)'
END


IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)    
BEGIN    
 -- default order by to first column    
 SET @OrderBy = 'AdvertiserID'    
END    


IF @IsDESC = 1   
BEGIN
	SET @OrderBy = @OrderBy + ' DESC'
END
    
    
    
-- SQL Server 2005 Paging    

DECLARE @SQL AS nvarchar(MAX)    
CREATE TABLE #tblAdvertiser(AdvertiserUserID INT, Email VARCHAR(255), LastLoginDate DATETIME, AdvertiserID INT, CompanyName NVARCHAR(510), RegisterDate DATETIME, AdvertiserAccountStatusID INT)
CREATE TABLE #tblJobs(AdvertiserUserID INT, JobID INT, Expired INT, DatePosted smalldatetime, ExpiryDate smalldatetime)

SET @SQL = 'INSERT INTO #tblAdvertiser (AdvertiserUserID, Email, LastLoginDate, AdvertiserID, CompanyName, RegisterDate, AdvertiserAccountStatusID) '
SET @SQL = @SQL + 'SELECT AdvertiserUserID, Email, LastLoginDate, adv.AdvertiserID, CompanyName, RegisterDate, AdvertiserAccountStatusID FROM Advertisers adv WITH (NOLOCK) '
SET @SQL = @SQL + 'INNER JOIN AdvertiserUsers advuser WITH (NOLOCK) ON advuser.AdvertiserID = adv.AdvertiserID '
SET @SQL = @SQL + 'WHERE SiteID = ' + CONVERT(varchar, @SiteID) 

 
IF ISNULL(@Keyword , '') <> ''
BEGIN
	SET @SQL = @SQL + ' AND (CompanyName LIKE ''%'+@Keyword+'%'' OR CONVERT(nvarchar(510), adv.AdvertiserID) = '''+@Keyword+''')'
END


IF @DateFrom IS NOT NULL
BEGIN
	SET @SQL = @SQL + ' AND RegisterDate >= ''' +convert( varchar(8), convert( date, @DateFrom) , 112) + ''''
END

IF @DateTo IS NOT NULL
BEGIN
	SET @SQL = @SQL + ' AND RegisterDate < ''' +convert( varchar(8), convert( date, DATEADD(DD, 1,@DateTo)) , 112) + ''''
END

SET @SQL = @SQL + ' INSERT INTO #tblJobs(AdvertiserUserID, JobID, Expired, DatePosted, ExpiryDate)'
SET @SQL = @SQL + ' SELECT EnteredByAdvertiserUserID, JobID, Expired, DatePosted, ExpiryDate FROM Jobs WHERE EnteredByAdvertiserUserID IN (SELECT AdvertiserUserID FROM #tblAdvertiser) AND (Expired = 0 OR Expired = 1) '

SET @SQL = @SQL + ' INSERT INTO #tblJobs(AdvertiserUserID, JobID, Expired, DatePosted, ExpiryDate)'
SET @SQL = @SQL + ' SELECT EnteredByAdvertiserUserID, JobID, Expired, DatePosted, ExpiryDate FROM JobsArchive WHERE EnteredByAdvertiserUserID IN (SELECT AdvertiserUserID FROM #tblAdvertiser) AND (Expired = 0 OR Expired = 1) '

PRINT @SQL    
EXEC sp_executesql @SQL   

SET @SQL = ' WITH PageIndex AS ('    
SET @SQL = @SQL + ' SELECT'    
--IF @PageSize > 0    
--BEGIN    
-- SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageSize)    
--END    
    
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'    
SET @SQL = @SQL + ', AdvertiserUserID, AdvertiserID, CompanyName, Email, RegisterDate, AdvertiserAccountStatusID'     
SET @SQL = @SQL + ', (SELECT MAX(DatePosted) FROM #tblJobs job WHERE job.AdvertiserUserID = tbl.AdvertiserUserID ) AS LastJobPost'     
SET @SQL = @SQL + ', (SELECT COUNT(*) FROM #tblJobs job WHERE Expired = 0 AND job.AdvertiserUserID = tbl.AdvertiserUserID  AND GETDATE() >= dbo.fnGetDate(DatePosted) AND GETDATE() <= DATEADD(DAY, 1, dbo.fnGetDate(ExpiryDate))) AS JobsLive'
SET @SQL = @SQL + ', (SELECT COUNT(*) FROM #tblJobs job WHERE job.AdvertiserUserID = tbl.AdvertiserUserID) AS TotalJobs'
SET @SQL = @SQL + ', LastLoginDate'
SET @SQL = @SQL + '    
 FROM #tblAdvertiser tbl
 '       
 
SET @SQL = @SQL + ' ) SELECT'    
SET @SQL = @SQL + ' AdvertiserUserID, AdvertiserID, CompanyName, Email, RegisterDate, AdvertiserAccountStatusID, LastJobPost, JobsLive, TotalJobs, LastLoginDate'    
SET @SQL = @SQL + ' FROM PageIndex'    
SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)    
IF @PageSize > 0    
BEGIN    
 SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)    
END    

-- SET @SQL = @SQL + ' ORDER BY ' + @OrderBy    
PRINT @SQL    
EXEC sp_executesql @SQL    
    
-- get row count    
SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'    
SET @SQL = @SQL + ' FROM Advertisers adv (NOLOCK) '
SET @SQL = @SQL + ' INNER JOIN AdvertiserUsers advuser WITH (NOLOCK) ON advuser.AdvertiserID = adv.AdvertiserID '
SET @SQL = @SQL + ' WHERE SiteID = ' + CONVERT(varchar, @SiteID) 
IF ISNULL(@Keyword , '') <> ''
BEGIN
	SET @SQL = @SQL + ' AND (CompanyName LIKE ''%'+@Keyword+'%'' OR CONVERT(nvarchar(510), adv.AdvertiserID) = '''+@Keyword+''')'
END

IF @DateFrom IS NOT NULL
BEGIN
	SET @SQL = @SQL + ' AND RegisterDate >= ''' +convert( varchar(8), convert( date, @DateFrom) , 112) + ''''
END

IF @DateTo IS NOT NULL
BEGIN
	SET @SQL = @SQL + ' AND RegisterDate < ''' +convert( varchar(8), convert( date, DATEADD(DD, 1,@DateTo)) , 112) + ''''
END



PRINT @SQL    
EXEC sp_executesql @SQL    

DROP TABLE #tblAdvertiser
DROP TABLE #tblJobs

 IF USER_NAME() IS NULL               
  BEGIN               
   SELECT AdvertiserID,
		SiteID,
		AdvertiserAccountTypeID,
		AdvertiserBusinessTypeID,
		AdvertiserAccountStatusID,
		CompanyName,
		BusinessNumber,
		StreetAddress1,
		StreetAddress2,
		LastModified,
		LastModifiedBy,
		PostalAddress1,
		PostalAddress2,
		WebAddress,
		NoOfEmployees,
		FirstApprovedDate,
		Profile,
		CharityNumber,
		SearchField,
		FreeTrialStartDate,
		FreeTrialEndDate,
		AccountsPayableEmail,
		RequireLogonForExternalApplication,
		AdvertiserLogo,
		LinkedInLogo,
		LinkedInCompanyId,
		LinkedInEmail,
		RegisterDate,
		AdvertiserLogoUrl
   FROM Advertisers  (NOLOCK) WHERE 1=0               
  END                 
    
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]
(

	@JobItemsTypeId int   
)
AS


SELECT dbo.[Advertisers].[AdvertiserID]
       ,dbo.[Advertisers].[SiteID]
       ,dbo.[Advertisers].[AdvertiserAccountTypeID]
       ,dbo.[Advertisers].[AdvertiserBusinessTypeID]
       ,dbo.[Advertisers].[AdvertiserAccountStatusID]
       ,dbo.[Advertisers].[CompanyName]
       ,dbo.[Advertisers].[BusinessNumber]
       ,dbo.[Advertisers].[StreetAddress1]
       ,dbo.[Advertisers].[StreetAddress2]
       ,dbo.[Advertisers].[LastModified]
       ,dbo.[Advertisers].[LastModifiedBy]
       ,dbo.[Advertisers].[PostalAddress1]
       ,dbo.[Advertisers].[PostalAddress2]
       ,dbo.[Advertisers].[WebAddress]
       ,dbo.[Advertisers].[NoOfEmployees]
       ,dbo.[Advertisers].[FirstApprovedDate]
       ,dbo.[Advertisers].[Profile]
       ,dbo.[Advertisers].[CharityNumber]
       ,dbo.[Advertisers].[SearchField]
       ,dbo.[Advertisers].[FreeTrialStartDate]
       ,dbo.[Advertisers].[FreeTrialEndDate]
       ,dbo.[Advertisers].[AccountsPayableEmail]
       ,dbo.[Advertisers].[RequireLogonForExternalApplication]
       ,dbo.[Advertisers].[AdvertiserLogo]
       ,dbo.[Advertisers].[LinkedInLogo]
       ,dbo.[Advertisers].[LinkedInCompanyId]
       ,dbo.[Advertisers].[LinkedInEmail]
       ,dbo.[Advertisers].[RegisterDate]
       ,dbo.[Advertisers].[ExternalAdvertiserID]
       ,dbo.[Advertisers].[VideoLink]
       ,dbo.[Advertisers].[Industry]
       ,dbo.[Advertisers].[NominatedCompanyRole]
       ,dbo.[Advertisers].[NominatedCompanyFirstName]
       ,dbo.[Advertisers].[NominatedCompanyLastName]
       ,dbo.[Advertisers].[NominatedCompanyEmailAddress]
       ,dbo.[Advertisers].[NominatedCompanyPhone]
       ,dbo.[Advertisers].[PreferredContactMethod]
       ,dbo.[Advertisers].[AdvertiserLogoUrl]
       ,dbo.[Advertisers].[AllowPeopleSearchAccess]
  FROM dbo.[Advertisers]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[AdvertiserJobPricing] 
                WHERE dbo.[AdvertiserJobPricing].[JobItemsTypeID] = @JobItemsTypeId
                  AND dbo.[AdvertiserJobPricing].[AdvertiserID] = dbo.[Advertisers].[AdvertiserID]
                  )
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertiserCount]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_GetAdvertiserCount]
(
	@SiteID int = 0
)
AS
BEGIN
	DECLARE @AdvertiserCount TABLE
	(
		Title VARCHAR(255),
		Total int
	)
	
	DECLARE @TotalAdvertiserCount AS INT
	SET @TotalAdvertiserCount = (SELECT COUNT(*) FROM Advertisers WITH (NOLOCK)
									WHERE (SiteID = @SiteID OR @SiteID = 0))

	INSERT INTO @AdvertiserCount (Title, Total)
	VALUES ('Total Advertiser Count', @TotalAdvertiserCount)

	SELECT * FROM @AdvertiserCount 

	IF USER_NAME() IS NULL
	BEGIN
		SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID], 
			   [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]
		FROM [dbo].[Members]  (NOLOCK) WHERE 1=0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetAllAdvertisers]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_CustomGetAllAdvertisers]       
 @SiteID INT,
 @AdvertiserId INT = NULL      
AS
BEGIN    

IF (ISNULL(@AdvertiserId,0) > 0)
BEGIN
	SELECT * from udfSite_GetAdvertisers(@SiteID) WHERE AdvertiserId = @AdvertiserId
END
ELSE
BEGIN
	SELECT * from udfSite_GetAdvertisers(@SiteID)      
END	

IF USER_NAME() IS NULL  
BEGIN  
	SELECT AdvertiserId FROM Advertisers (NOLOCK) WHERE 1 = 0 
END
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetExpiringJobAdvertiser]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_CustomGetExpiringJobAdvertiser]      
(      
 @SiteID INT = 0,      
 @WithInDays INT      
)      
AS  
DECLARE @SiteIDs table(SiteID INT, SiteName Varchar(255), SiteUrl Varchar(500), EmailAddressFrom VARCHAR(255), EmailAddressName NVARCHAR(510), EmailSubject NVARCHAR(510), EmailBodyHTML NTEXT, WwwRedirect BIT)    
     
INSERT INTO @SiteIDs    
Select Sites.SiteID, Sitename, Siteurl, EmailTemplates.EmailAddressFrom, EmailTemplates.EmailAddressName, EmailTemplates.EmailSubject,EmailTemplates.EmailBodyHTML, WwwRedirect    
      FROM GlobalSettings (NOLOCK) INNER JOIN Sites (NOLOCK)    
            ON GlobalSettings.SiteID = Sites.SiteID AND Globalsettings.JobExpiryNotification = 1 AND Sites.Live = 1    
      INNER JOIN EmailTemplates (NOLOCK)    
            ON Sites.SiteID = EmailTemplates.SiteID and Emailtemplates.EmailCode = 'JOBEXPIRY'    
     
SELECT DISTINCT a.siteid, au.AdvertiserUserID, au.Username, au.FirstName, au.Surname, au.Email, au.PrimaryAccount, au.AdvertiserID    
FROM @SiteIDs s       
 INNER JOIN Advertisers (NOLOCK) a       
 ON a.SiteID = s.SiteID      
 INNER JOIN AdvertiserUsers  (NOLOCK) au       
 ON au.AdvertiserID = a.AdvertiserID       
 WHERE au.JobExpiryNotification = 1 AND au.Validated = 1 AND a.AdvertiserAccountStatusID = 2 -- Approved    
select * FROM @SiteIDs     
DECLARE @ExpiringJobs table(JobID INT, JobName VARCHAR(1024), JobFriendlyName VARCHAR(1024), ExpiryDate DATETIME, AdvertiserUserID INT, AdvertiserID INT, CompanyName VARCHAR(255), SitesID INT, SiteName VARCHAR(255), SiteUrl VARCHAR(255))         
        
 INSERT INTO @ExpiringJobs 


select DISTINCT j.JobID, j.JobName, '/' + ISNULL(sp.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(j.JobFriendlyName, '') as 'JobFriendlyName',    
            ExpiryDate, EnteredByAdvertiserUserID, a.AdvertiserID, a.CompanyName, j.SiteID, s.SiteName, s.SiteUrl 
FROM @SiteIDs   s     
INNER JOIN Jobs j  (NOLOCK)     
 ON j.SiteID = s.SiteID     
INNER JOIN Advertisers (NOLOCK) a       
 ON j.AdvertiserID = a.AdvertiserID AND a.SiteID = s.SiteID    
 INNER JOIN AdvertiserUsers  (NOLOCK) au       
 ON au.AdvertiserID = a.AdvertiserID       
  
 INNER JOIN --JobRoles jr (NOLOCK)   
 
(SELECT JobID, min(RoleID) as RoleID 
FROM JobRoles (NOLOCK)  
GROUP BY JobID) jr
   
 ON j.JobID = jr.JobID       
 INNER JOIN Roles r  (NOLOCK)      
 ON jr.RoleID = r.RoleID       
 INNER JOIN SiteProfession sp (NOLOCK)       
 ON sp.ProfessionID = r.ProfessionID AND sp.SiteID = j.SiteID          
 WHERE  j.Expired = 0 AND ExpiryDate >= GETDATE() AND ExpiryDate <= DATEADD(DD, @WithInDays, GETDATE()) 
 AND au.JobExpiryNotification = 1 AND au.Validated = 1 AND a.AdvertiserAccountStatusID = 2 -- Approved  
-- AND s.SiteID IN (441)
 ORDER BY j.SiteID, a.AdvertiserID,EnteredByAdvertiserUserID    
 select * from @ExpiringJobs
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAllJobStatistics]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_GetAllJobStatistics]    
(    
 @SiteID int = 0    
)    
AS    
BEGIN    
    
 DECLARE @JobsStatistics TABLE    
 (    
  JobStatus varchar(255),    
  TotalView int,    
  TotalApplication int    
 )    
     
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)    
 VALUES ('Current', 0, 0)    
    
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)    
 VALUES ('Archived', 0, 0)    
    
 INSERT INTO @JobsStatistics (JobStatus, TotalView, TotalApplication)    
 VALUES ('Draft', 0, 0)    
    
 -- Current    
 UPDATE @JobsStatistics     
 SET TotalView = ISNULL((SELECT SUM(TotalView)     
       FROM JobViews jv  WITH (NOLOCK)    
       INNER JOIN Jobs j  WITH (NOLOCK)    
       ON jv.JobID = j.JobID    
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)    
       AND (Expired = NULL OR Expired = 0)    
       AND GETDATE() >= dbo.fnGetDate(DatePosted)    
       AND GETDATE() < dbo.fnGetDate(ExpiryDate)), 0)    
 WHERE JobStatus = 'Current'    
    
 UPDATE @JobsStatistics     
 SET TotalApplication = (SELECT COUNT(*)     
       FROM JobApplication ja WITH (NOLOCK)    
       INNER JOIN Jobs j  WITH (NOLOCK)    
       ON ja.JobID = j.JobID    
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)    
       AND (Expired = NULL OR Expired = 0)    
       AND GETDATE() >= dbo.fnGetDate(DatePosted)    
       AND GETDATE() < dbo.fnGetDate(ExpiryDate) AND ISNULL(ja.Draft,0) = 0)    
 WHERE JobStatus = 'Current'    
    
 -- Archived    
 UPDATE @JobsStatistics     
 SET TotalView = ISNULL((SELECT SUM(TotalView)     
       FROM JobViews jv WITH (NOLOCK)    
       INNER JOIN JobsArchive ja WITH (NOLOCK)    
       ON jv.JobArchiveID = ja.JobID    
       WHERE (ja.SiteID = @SiteID OR @SiteID = 0)), 0)    
 WHERE JobStatus = 'Archived'    
    
 UPDATE @JobsStatistics     
 SET TotalApplication = (SELECT COUNT(*)     
       FROM JobApplication ja WITH (NOLOCK)    
       INNER JOIN JobsArchive j WITH (NOLOCK)    
       ON ja.JobArchiveID = j.JobID    
       WHERE (j.SiteID = @SiteID OR @SiteID = 0) AND ISNULL(Draft,0) = 0)   
 WHERE JobStatus = 'Archived'    
     
 -- Draft    
 UPDATE @JobsStatistics     
 SET TotalView = ISNULL((SELECT SUM(TotalView)     
       FROM JobViews jv  WITH (NOLOCK)    
       INNER JOIN Jobs j  WITH (NOLOCK)    
       ON jv.JobID = j.JobID    
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)    
       AND Expired = 3), 0)    
 WHERE JobStatus = 'Draft'    
    
 UPDATE @JobsStatistics     
 SET TotalApplication = (SELECT COUNT(*)     
       FROM JobApplication ja WITH (NOLOCK)    
       INNER JOIN Jobs j  WITH (NOLOCK)    
       ON ja.JobID  = j.JobID  
       WHERE (j.SiteID = @SiteID OR @SiteID = 0)    
       AND Expired = 3 AND ISNULL(Draft,0) = 0)    
 WHERE JobStatus = 'Draft'    
          
 SELECT * FROM @JobsStatistics    
    
 IF USER_NAME() IS NULL    
 BEGIN    
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],     
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]    
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0    
 END    
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertiserTypeStatistics]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_GetAdvertiserTypeStatistics]  
(  
 @SiteID int = 0  
)  
AS  
BEGIN  
 DECLARE @AdvertiserTypeStatistics TABLE  
 (  
  BusinessType int,  
  BusinessName varchar(255),  
  TotalJob int,  
  TotalApplication int,  
  TotalView int  
 )  
   
 INSERT INTO @AdvertiserTypeStatistics (BusinessType, BusinessName, TotalJob, TotalApplication, TotalView)  
 SELECT AdvertiserBusinessTypeID, AdvertiserBusinessTypeName, 0, 0, 0 FROM AdvertiserBusinessType WITH (NOLOCK)  
 -- Total Job  
   
  
 UPDATE @AdvertiserTypeStatistics SET TotalJob = (SELECT COUNT(*)   
           FROM Jobs j  WITH (NOLOCK) INNER JOIN Advertisers a  WITH (NOLOCK)  
           ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0))  
  
 -- Total Applications  
  
 UPDATE @AdvertiserTypeStatistics SET TotalApplication = (SELECT COUNT(*)   
           FROM JobApplication ja  WITH (NOLOCK)   
           INNER JOIN Jobs j  WITH (NOLOCK)   
           ON ja.JobID = j.JobID   
           INNER JOIN Advertisers a  WITH (NOLOCK)  
           ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0) AND ISNULL(ja.Draft,0) = 0)  
  
 -- Total View  
  
 UPDATE @AdvertiserTypeStatistics SET TotalView = ISNULL((SELECT SUM(TotalView)   
           FROM JobViews jv  WITH (NOLOCK)  
           INNER JOIN Jobs j  WITH (NOLOCK) ON jv.JobID = j.JobID   
           INNER JOIN Advertisers a  WITH (NOLOCK) ON j.AdvertiserID = a.AdvertiserID   
           WHERE AdvertiserBusinessTypeID = BusinessType  
           AND (a.SiteID = @SiteID OR @SiteID = 0)), 0)  
  
 SELECT * FROM @AdvertiserTypeStatistics  
  
 IF USER_NAME() IS NULL  
 BEGIN  
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],   
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]  
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0  
 END  
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAllAdvertisers]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_GetAllAdvertisers]
(
	@SiteID int = 0
)
AS
BEGIN
	SELECT AdvertiserID, CompanyName, AdvertiserBusinessTypeName, AccountsPayableEmail, AdvertiserAccountTypeName
	FROM Advertisers a  WITH (NOLOCK)
	INNER JOIN AdvertiserBusinessType abt WITH (NOLOCK)	
	ON a.AdvertiserBusinessTypeID = abt.AdvertiserBusinessTypeID
	INNER JOIN AdvertiserAccountType aat WITH (NOLOCK)
	ON a.AdvertiserAccountTypeID = aat.AdvertiserAccountTypeID
	WHERE (a.SiteID = @SiteID OR @SiteID = 0)
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertisersNotPostedSince]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_GetAdvertisersNotPostedSince] 
(@SiteID int = 0,   
 @DaysSinceLastPost int = 0)   
AS   
BEGIN   
 DECLARE @DateNow DATETIME   
 DECLARE @DateStart DATETIME   
 SET @DateNow = dbo.fnGetDate(GETDATE())   
 SET @DateStart = dbo.fnGetDate(DATEADD(dd,@DaysSinceLastPost * -1, @DateNow))   
     
 SELECT DISTINCT AdvertiserID, CompanyName, AdvertiserBusinessTypeName, AccountsPayableEmail, AdvertiserAccountTypeName, AdvertiserAccountStatusName  
FROM Advertisers a  WITH (NOLOCK)   
   INNER JOIN AdvertiserBusinessType abt WITH (NOLOCK) ON a.AdvertiserBusinessTypeID = abt.AdvertiserBusinessTypeID   
   INNER JOIN AdvertiserAccountType aat WITH (NOLOCK) ON a.AdvertiserAccountTypeID = aat.AdvertiserAccountTypeID  
   INNER JOIN AdvertiserAccountStatus WITH(NOLOCK) ON AdvertiserAccountStatus.AdvertiserAccountStatusID = a.AdvertiserAccountStatusID   
 WHERE a.AdvertiserID NOT IN (SELECT DISTINCT AdvertiserID    
         FROM Jobs  WITH (NOLOCK)   
         WHERE (SiteID = @SiteID OR @SiteID = 0)    
         AND DatePosted > @DateStart    
         AND DatePosted <= @DateNow)   
  AND a.SiteID = @SiteID   
END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_AdminGetPaged]    Script Date: 01/30/2017 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Advertisers_AdminGetPaged]          
 @AdvertiserID INT = 0,      
 @SiteID INT = 0,       
 @AdvertiserAccountTypeID INT = 0,      
 @AdvertiserBusinessTypeID INT = 0,      
 @AdvertiserAccountStatusID INT = 0,      
 @CompanyName NVARCHAR(255) = '',      
 @PageSize INT,        
 @PageNumber INT        
AS      
BEGIN       
      
 IF @PageSize IS NULL        
  SET @pageSize = 10        
        
 IF @PageNumber IS NULL        
  SET @PageNumber = 1        
        
 Declare @pageStart int        
 Declare @pageEnd int        
        
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1        
 SET @PageEnd = (@PageNumber * @PageSize)       
      
 DECLARE @tmpAdvertiserID TABLE       
 (      
   AdvertiserID INT NOT NULL PRIMARY KEY,       
   RowNumber INT NOT NULL      
 )      
       
 INSERT INTO @tmpAdvertiserID      
      
SELECT  Advertisers.AdvertiserID, ROW_NUMBER() OVER (ORDER BY Advertisers.CompanyName) AS RowNumber      
FROM  Advertisers Advertisers WITH(NOLOCK)      
 INNER JOIN AdvertiserAccountType AdvertiserAccountType WITH(NOLOCK) ON AdvertiserAccountType.AdvertiserAccountTypeID = Advertisers.AdvertiserAccountTypeID       
 INNER JOIN AdvertiserBusinessType AdvertiserBusinessType WITH(NOLOCK) ON AdvertiserBusinessType.AdvertiserBusinessTypeID = Advertisers.AdvertiserBusinessTypeID      
 INNER JOIN AdvertiserAccountStatus AdvertiserAccountStatus WITH(NOLOCK) ON AdvertiserAccountStatus.AdvertiserAccountStatusID = Advertisers.AdvertiserAccountStatusID      
 INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = Advertisers.LastModifiedBy      
    
WHERE  (ISNULL(@AdvertiserID, 0) = 0 OR Advertisers.AdvertiserID = @AdvertiserID)      
 AND  (ISNULL(@SiteID, 0) = 0 OR Advertisers.SiteID = @SiteID)      
 AND  (ISNULL(@AdvertiserAccountTypeID, 0) = 0 OR Advertisers.AdvertiserAccountTypeID = @AdvertiserAccountTypeID)      
 AND  (ISNULL(@AdvertiserBusinessTypeID, 0) = 0 OR Advertisers.AdvertiserBusinessTypeID = @AdvertiserBusinessTypeID)      
 AND  (ISNULL(@AdvertiserAccountStatusID, 0) = 0 OR Advertisers.AdvertiserAccountStatusID = @AdvertiserAccountStatusID)      
 AND  (ISNULL(@CompanyName, '') = '' OR Advertisers.CompanyName LIKE '%' + @CompanyName + '%')      
      
       
SELECT  AdvertiserSearchtResult.RowNumber AS RowNumber, Advertisers.AdvertiserID, Advertisers.SiteID,      
 AdvertiserAccountType.AdvertiserAccountTypeName AS AdvertiserAccountTypeName,      
 AdvertiserBusinessType.AdvertiserBusinessTypeName AS AdvertiserBusinessTypeName,      
 AdvertiserAccountStatus.AdvertiserAccountStatusName AS AdvertiserAccountStatusName,      
 Advertisers.CompanyName, Advertisers.AccountsPayableEmail, Advertisers.NoOfEmployees, Advertisers.FirstApprovedDate, Advertisers.LastModified,      
 AdminUsers.UserName AS LastModifiedBy, Advertisers.registerdate, (SELECT COUNT(1) FROM @tmpAdvertiserID) AS TotalCount      
FROM  Advertisers Advertisers WITH(NOLOCK)      
    
 INNER JOIN AdvertiserAccountType AdvertiserAccountType WITH(NOLOCK) ON AdvertiserAccountType.AdvertiserAccountTypeID = Advertisers.AdvertiserAccountTypeID       
 INNER JOIN AdvertiserBusinessType AdvertiserBusinessType WITH(NOLOCK) ON AdvertiserBusinessType.AdvertiserBusinessTypeID = Advertisers.AdvertiserBusinessTypeID      
 INNER JOIN AdvertiserAccountStatus AdvertiserAccountStatus WITH(NOLOCK) ON AdvertiserAccountStatus.AdvertiserAccountStatusID = Advertisers.AdvertiserAccountStatusID      
 INNER JOIN AdminUsers AdminUsers WITH(NOLOCK) ON AdminUsers.AdminUserID = Advertisers.LastModifiedBy      
 INNER JOIN @tmpAdvertiserID AdvertiserSearchtResult ON Advertisers.AdvertiserID = AdvertiserSearchtResult.AdvertiserID       
WHERE      
 AdvertiserSearchtResult.RowNumber >= @PageStart AND  AdvertiserSearchtResult.RowNumber <= @PageEnd      
ORDER BY AdvertiserSearchtResult.RowNumber      
      
END
GO


