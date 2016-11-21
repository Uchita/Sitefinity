
/****** Object:  StoredProcedure [dbo].[MemberFiles_Update]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the MemberFiles table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_Update]
GO

CREATE PROCEDURE [dbo].[MemberFiles_Update]
(

	@MemberFileId int   ,

	@MemberId int   ,

	@MemberFileTypeId int   ,

	@MemberFileName nvarchar (500)  ,

	@MemberFileSearchExtension varchar (8)  ,

	@MemberFileContent image   ,

	@MemberFileTitle nvarchar (500)  ,

	@LastModifiedDate datetime   ,

	@DocumentTypeId int   ,

	@MemberFileUrl nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[MemberFiles]
				SET
					[MemberID] = @MemberId
					,[MemberFileTypeID] = @MemberFileTypeId
					,[MemberFileName] = @MemberFileName
					,[MemberFileSearchExtension] = @MemberFileSearchExtension
					,[MemberFileContent] = @MemberFileContent
					,[MemberFileTitle] = @MemberFileTitle
					,[LastModifiedDate] = @LastModifiedDate
					,[DocumentTypeID] = @DocumentTypeId
					,[MemberFileUrl] = @MemberFileUrl
				WHERE
[MemberFileID] = @MemberFileId
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Insert]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the MemberFiles table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_Insert]
GO

CREATE PROCEDURE [dbo].[MemberFiles_Insert]
(

	@MemberFileId int    OUTPUT,

	@MemberId int   ,

	@MemberFileTypeId int   ,

	@MemberFileName nvarchar (500)  ,

	@MemberFileSearchExtension varchar (8)  ,

	@MemberFileContent image   ,

	@MemberFileTitle nvarchar (500)  ,

	@LastModifiedDate datetime   ,

	@DocumentTypeId int   ,

	@MemberFileUrl nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[MemberFiles]
					(
					[MemberID]
					,[MemberFileTypeID]
					,[MemberFileName]
					,[MemberFileSearchExtension]
					,[MemberFileContent]
					,[MemberFileTitle]
					,[LastModifiedDate]
					,[DocumentTypeID]
					,[MemberFileUrl]
					)
				VALUES
					(
					@MemberId
					,@MemberFileTypeId
					,@MemberFileName
					,@MemberFileSearchExtension
					,@MemberFileContent
					,@MemberFileTitle
					,@LastModifiedDate
					,@DocumentTypeId
					,@MemberFileUrl
					)
				
				-- Get the identity value
				SET @MemberFileId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetPagingByMemberId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetPagingByMemberId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetPagingByMemberId]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetPagingByMemberId]
( 
 @MemberId INT,
 @PageSize INT,          
 @PageNumber INT      
)  
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
      
 DECLARE @tmpGetPagingByMemberId TABLE       
 (      
   MemberFileID INT NOT NULL PRIMARY KEY,       
   RowNumber INT NOT NULL      
 )

 INSERT INTO @tmpGetPagingByMemberId

 SELECT MemberFileID, ROW_NUMBER() OVER (ORDER BY MemberFileID) AS RowNumber
 FROM   MemberFiles WITH (NOLOCK)
 WHERE  (MemberId = @MemberId)


  
 SELECT MemberFiles.MemberFileID, MemberFiles.MemberID, MemberFiles.MemberFileTypeID, MemberFiles.MemberFileName, 
		MemberFiles.MemberFileSearchExtension, MemberFiles.MemberFileContent,  MemberFiles.MemberFileTitle, 
		MemberFiles.LastModifiedDate, MemberFiles.DocumentTypeID, MemberFiles.MemberFileUrl,
		GetPagingByMemberId.RowNumber AS RowNumber,
		(SELECT COUNT(1) FROM @tmpGetPagingByMemberId) AS TotalCount
 FROM   MemberFiles MemberFiles(NOLOCK)
 INNER JOIN @tmpGetPagingByMemberId GetPagingByMemberId 
 		ON MemberFiles.MemberFileID = GetPagingByMemberId.MemberFileID
 WHERE  GetPagingByMemberId.RowNumber >= @PageStart  
 AND    GetPagingByMemberId.RowNumber <= @PageEnd      
 ORDER BY GetPagingByMemberId.RowNumber

END
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the MemberFiles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetPaged]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetPaged]
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
				    [MemberFileID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([MemberFileID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [MemberFileID]'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFiles]'
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
				SELECT O.[MemberFileID], O.[MemberID], O.[MemberFileTypeID], O.[MemberFileName], O.[MemberFileSearchExtension], O.[MemberFileContent], O.[MemberFileTitle], O.[LastModifiedDate], O.[DocumentTypeID], O.[MemberFileUrl]
				FROM
				    [dbo].[MemberFiles] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[MemberFileID] = PageIndex.[MemberFileID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFiles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberIdMemberFileName]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through an index
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetByMemberIdMemberFileName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetByMemberIdMemberFileName]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberIdMemberFileName]
(

	@MemberId int   ,

	@MemberFileName nvarchar (500)  
)
AS


				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileSearchExtension],
					[MemberFileContent],
					[MemberFileTitle],
					[LastModifiedDate],
					[DocumentTypeID],
					[MemberFileUrl]
				FROM
					[dbo].[MemberFiles] (NOLOCK)
				WHERE
					[MemberID] = @MemberId
					AND [MemberFileName] = @MemberFileName
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetByMemberId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetByMemberId]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberId]
(

	@MemberId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileSearchExtension],
					[MemberFileContent],
					[MemberFileTitle],
					[LastModifiedDate],
					[DocumentTypeID],
					[MemberFileUrl]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberID] = @MemberId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberFileTypeId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetByMemberFileTypeId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetByMemberFileTypeId]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberFileTypeId]
(

	@MemberFileTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileSearchExtension],
					[MemberFileContent],
					[MemberFileTitle],
					[LastModifiedDate],
					[DocumentTypeID],
					[MemberFileUrl]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberFileTypeID] = @MemberFileTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberFileId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through an index
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_GetByMemberFileId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_GetByMemberFileId]
GO

CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberFileId]
(

	@MemberFileId int   
)
AS


				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileSearchExtension],
					[MemberFileContent],
					[MemberFileTitle],
					[LastModifiedDate],
					[DocumentTypeID],
					[MemberFileUrl]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberFileID] = @MemberFileId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the MemberFiles table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_Get_List]
GO

CREATE PROCEDURE [dbo].[MemberFiles_Get_List]

AS


				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileSearchExtension],
					[MemberFileContent],
					[MemberFileTitle],
					[LastModifiedDate],
					[DocumentTypeID],
					[MemberFileUrl]
				FROM
					[dbo].[MemberFiles]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Find]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the MemberFiles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_Find]
GO

CREATE PROCEDURE [dbo].[MemberFiles_Find]
(

	@SearchUsingOR bit   = null ,

	@MemberFileId int   = null ,

	@MemberId int   = null ,

	@MemberFileTypeId int   = null ,

	@MemberFileName nvarchar (500)  = null ,

	@MemberFileSearchExtension varchar (8)  = null ,

	@MemberFileContent image   = null ,

	@MemberFileTitle nvarchar (500)  = null ,

	@LastModifiedDate datetime   = null ,

	@DocumentTypeId int   = null ,

	@MemberFileUrl nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MemberFileID]
	, [MemberID]
	, [MemberFileTypeID]
	, [MemberFileName]
	, [MemberFileSearchExtension]
	, [MemberFileContent]
	, [MemberFileTitle]
	, [LastModifiedDate]
	, [DocumentTypeID]
	, [MemberFileUrl]
    FROM
	[dbo].[MemberFiles]
    WHERE 
	 ([MemberFileID] = @MemberFileId OR @MemberFileId IS NULL)
	AND ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([MemberFileTypeID] = @MemberFileTypeId OR @MemberFileTypeId IS NULL)
	AND ([MemberFileName] = @MemberFileName OR @MemberFileName IS NULL)
	AND ([MemberFileSearchExtension] = @MemberFileSearchExtension OR @MemberFileSearchExtension IS NULL)
	AND ([MemberFileTitle] = @MemberFileTitle OR @MemberFileTitle IS NULL)
	AND ([LastModifiedDate] = @LastModifiedDate OR @LastModifiedDate IS NULL)
	AND ([DocumentTypeID] = @DocumentTypeId OR @DocumentTypeId IS NULL)
	AND ([MemberFileUrl] = @MemberFileUrl OR @MemberFileUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MemberFileID]
	, [MemberID]
	, [MemberFileTypeID]
	, [MemberFileName]
	, [MemberFileSearchExtension]
	, [MemberFileContent]
	, [MemberFileTitle]
	, [LastModifiedDate]
	, [DocumentTypeID]
	, [MemberFileUrl]
    FROM
	[dbo].[MemberFiles]
    WHERE 
	 ([MemberFileID] = @MemberFileId AND @MemberFileId is not null)
	OR ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([MemberFileTypeID] = @MemberFileTypeId AND @MemberFileTypeId is not null)
	OR ([MemberFileName] = @MemberFileName AND @MemberFileName is not null)
	OR ([MemberFileSearchExtension] = @MemberFileSearchExtension AND @MemberFileSearchExtension is not null)
	OR ([MemberFileTitle] = @MemberFileTitle AND @MemberFileTitle is not null)
	OR ([LastModifiedDate] = @LastModifiedDate AND @LastModifiedDate is not null)
	OR ([DocumentTypeID] = @DocumentTypeId AND @DocumentTypeId is not null)
	OR ([MemberFileUrl] = @MemberFileUrl AND @MemberFileUrl is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Delete]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the MemberFiles table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberFiles_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MemberFiles_Delete]
GO

CREATE PROCEDURE [dbo].[MemberFiles_Delete]
(

	@MemberFileId int   
)
AS


				DELETE FROM [dbo].[MemberFiles] WITH (ROWLOCK) 
				WHERE
					[MemberFileID] = @MemberFileId
GO
/****** Object:  StoredProcedure [dbo].[ViewJobs_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ViewJobs view
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobs_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobs_Get_List]
GO

CREATE PROCEDURE [dbo].[ViewJobs_Get_List]

AS


                    
                    SELECT
                        [JobID],
                        [SiteID],
                        [WorkTypeID],
                        [JobName],
                        [Description],
                        [FullDescription],
                        [WebServiceProcessed],
                        [ApplicationEmailAddress],
                        [RefNo],
                        [Visible],
                        [DatePosted],
                        [ExpiryDate],
                        [Expired],
                        [JobItemPrice],
                        [Billed],
                        [LastModified],
                        [ShowSalaryDetails],
                        [ShowSalaryRange],
                        [SalaryText],
                        [AdvertiserID],
                        [LastModifiedByAdvertiserUserId],
                        [LastModifiedByAdminUserId],
                        [JobItemTypeID],
                        [ApplicationMethod],
                        [ApplicationUrl],
                        [UploadMethod],
                        [Tags],
                        [JobTemplateID],
                        [SearchField],
                        [AdvertiserJobTemplateLogoID],
                        [CompanyName],
                        [HashValue],
                        [RequireLogonForExternalApplications],
                        [ShowLocationDetails],
                        [PublicTransport],
                        [Address],
                        [ContactDetails],
                        [JobContactPhone],
                        [JobContactName],
                        [QualificationsRecognised],
                        [ResidentOnly],
                        [DocumentLink],
                        [BulletPoint1],
                        [BulletPoint2],
                        [BulletPoint3],
                        [HotJob],
                        [AdvertiserCompanyName],
                        [BusinessNumber],
                        [StreetAddress1],
                        [StreetAddress2],
                        [WebAddress],
                        [Profile],
                        [RequireLogonForExternalApplication],
                        [AdvertiserLogo],
                        [AdvertiserLogoUrl],
                        [SiteWorkTypeName],
                        [CurrencySymbol],
                        [SalaryUpperBand],
                        [SalaryLowerBand],
                        [SalaryTypeID],
                        [JobTemplateHTML],
                        [SalaryTypeName],
                        [SiteAreaName],
                        [SiteLocationName],
                        [SiteRoleName],
                        [SiteRoleCanonicalUrl],
                        [SiteProfessionName],
                        [SiteProfessionCanonicalUrl],
                        [JobFriendlyName],
                        [ProfessionID],
                        [RoleID],
                        [LocationID],
                        [AreaID],
                        [SalaryDisplay]
                    FROM
                        [dbo].[ViewJobs]
                        
                    SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[ViewJobsArchive_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ViewJobsArchive view
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobsArchive_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobsArchive_Get_List]
GO

CREATE PROCEDURE [dbo].[ViewJobsArchive_Get_List]

AS


                    
                    SELECT
                        [JobID],
                        [SiteID],
                        [WorkTypeID],
                        [JobName],
                        [Description],
                        [FullDescription],
                        [WebServiceProcessed],
                        [ApplicationEmailAddress],
                        [RefNo],
                        [Visible],
                        [DatePosted],
                        [ExpiryDate],
                        [Expired],
                        [JobItemPrice],
                        [Billed],
                        [LastModified],
                        [ShowSalaryDetails],
                        [ShowSalaryRange],
                        [SalaryText],
                        [AdvertiserID],
                        [LastModifiedByAdvertiserUserId],
                        [LastModifiedByAdminUserId],
                        [JobItemTypeID],
                        [ApplicationMethod],
                        [ApplicationUrl],
                        [UploadMethod],
                        [Tags],
                        [JobTemplateID],
                        [SearchField],
                        [AdvertiserJobTemplateLogoID],
                        [CompanyName],
                        [HashValue],
                        [RequireLogonForExternalApplications],
                        [ShowLocationDetails],
                        [PublicTransport],
                        [Address],
                        [ContactDetails],
                        [JobContactPhone],
                        [JobContactName],
                        [QualificationsRecognised],
                        [ResidentOnly],
                        [DocumentLink],
                        [BulletPoint1],
                        [BulletPoint2],
                        [BulletPoint3],
                        [HotJob],
                        [AdvertiserCompanyName],
                        [BusinessNumber],
                        [StreetAddress1],
                        [StreetAddress2],
                        [WebAddress],
                        [Profile],
                        [RequireLogonForExternalApplication],
                        [AdvertiserLogo],
                        [AdvertiserLogoUrl],
                        [SiteWorkTypeName],
                        [CurrencySymbol],
                        [SalaryUpperBand],
                        [SalaryLowerBand],
                        [SalaryTypeID],
                        [JobTemplateHTML],
                        [SalaryTypeName],
                        [SiteAreaName],
                        [SiteLocationName],
                        [SiteRoleName],
                        [SiteProfessionName],
                        [JobFriendlyName],
                        [ProfessionID],
                        [RoleID],
                        [LocationID],
                        [AreaID],
                        [SalaryDisplay]
                    FROM
                        [dbo].[ViewJobsArchive]
                        
                    SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Consultants_Update]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Consultants table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_Update]
GO

CREATE PROCEDURE [dbo].[Consultants_Update]
(

	@ConsultantId int   ,

	@SiteId int   ,

	@LanguageId int   ,

	@Title nvarchar (128)  ,

	@FirstName nvarchar (512)  ,

	@Email varchar (255)  ,

	@Phone varchar (512)  ,

	@Mobile varchar (512)  ,

	@PositionTitle nvarchar (128)  ,

	@OfficeLocation nvarchar (1024)  ,

	@Categories nvarchar (1024)  ,

	@Location nvarchar (1024)  ,

	@FriendlyUrl varchar (128)  ,

	@ShortDescription nvarchar (MAX)  ,

	@Testimonial nvarchar (MAX)  ,

	@FullDescription nvarchar (MAX)  ,

	@ConsultantData nvarchar (MAX)  ,

	@LinkedInUrl varchar (512)  ,

	@TwitterUrl varchar (512)  ,

	@FacebookUrl varchar (512)  ,

	@GoogleUrl varchar (512)  ,

	@Link varchar (512)  ,

	@WechatUrl varchar (512)  ,

	@FeaturedTeamMember int   ,

	@ImageUrl image   ,

	@VideoUrl varchar (512)  ,

	@BlogRss varchar (512)  ,

	@NewsRss varchar (512)  ,

	@JobRss varchar (512)  ,

	@TestimonialsRss varchar (512)  ,

	@Valid int   ,

	@MetaTitle nvarchar (510)  ,

	@MetaDescription nvarchar (1024)  ,

	@MetaKeywords nvarchar (510)  ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@Sequence int   ,

	@LastName nvarchar (512)  ,

	@ConsultantsXml nvarchar (MAX)  ,

	@ConsultantImageUrl nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Consultants]
				SET
					[SiteID] = @SiteId
					,[LanguageID] = @LanguageId
					,[Title] = @Title
					,[FirstName] = @FirstName
					,[Email] = @Email
					,[Phone] = @Phone
					,[Mobile] = @Mobile
					,[PositionTitle] = @PositionTitle
					,[OfficeLocation] = @OfficeLocation
					,[Categories] = @Categories
					,[Location] = @Location
					,[FriendlyUrl] = @FriendlyUrl
					,[ShortDescription] = @ShortDescription
					,[Testimonial] = @Testimonial
					,[FullDescription] = @FullDescription
					,[ConsultantData] = @ConsultantData
					,[LinkedInUrl] = @LinkedInUrl
					,[TwitterUrl] = @TwitterUrl
					,[FacebookUrl] = @FacebookUrl
					,[GoogleUrl] = @GoogleUrl
					,[Link] = @Link
					,[WechatUrl] = @WechatUrl
					,[FeaturedTeamMember] = @FeaturedTeamMember
					,[ImageUrl] = @ImageUrl
					,[VideoUrl] = @VideoUrl
					,[BlogRSS] = @BlogRss
					,[NewsRSS] = @NewsRss
					,[JobRSS] = @JobRss
					,[TestimonialsRSS] = @TestimonialsRss
					,[Valid] = @Valid
					,[MetaTitle] = @MetaTitle
					,[MetaDescription] = @MetaDescription
					,[MetaKeywords] = @MetaKeywords
					,[LastModifiedBy] = @LastModifiedBy
					,[LastModified] = @LastModified
					,[Sequence] = @Sequence
					,[LastName] = @LastName
					,[ConsultantsXML] = @ConsultantsXml
					,[ConsultantImageUrl] = @ConsultantImageUrl
				WHERE
[ConsultantID] = @ConsultantId
GO
/****** Object:  StoredProcedure [dbo].[Consultants_Insert]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Consultants table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_Insert]
GO

CREATE PROCEDURE [dbo].[Consultants_Insert]
(

	@ConsultantId int    OUTPUT,

	@SiteId int   ,

	@LanguageId int   ,

	@Title nvarchar (128)  ,

	@FirstName nvarchar (512)  ,

	@Email varchar (255)  ,

	@Phone varchar (512)  ,

	@Mobile varchar (512)  ,

	@PositionTitle nvarchar (128)  ,

	@OfficeLocation nvarchar (1024)  ,

	@Categories nvarchar (1024)  ,

	@Location nvarchar (1024)  ,

	@FriendlyUrl varchar (128)  ,

	@ShortDescription nvarchar (MAX)  ,

	@Testimonial nvarchar (MAX)  ,

	@FullDescription nvarchar (MAX)  ,

	@ConsultantData nvarchar (MAX)  ,

	@LinkedInUrl varchar (512)  ,

	@TwitterUrl varchar (512)  ,

	@FacebookUrl varchar (512)  ,

	@GoogleUrl varchar (512)  ,

	@Link varchar (512)  ,

	@WechatUrl varchar (512)  ,

	@FeaturedTeamMember int   ,

	@ImageUrl image   ,

	@VideoUrl varchar (512)  ,

	@BlogRss varchar (512)  ,

	@NewsRss varchar (512)  ,

	@JobRss varchar (512)  ,

	@TestimonialsRss varchar (512)  ,

	@Valid int   ,

	@MetaTitle nvarchar (510)  ,

	@MetaDescription nvarchar (1024)  ,

	@MetaKeywords nvarchar (510)  ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@Sequence int   ,

	@LastName nvarchar (512)  ,

	@ConsultantsXml nvarchar (MAX)  ,

	@ConsultantImageUrl nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[Consultants]
					(
					[SiteID]
					,[LanguageID]
					,[Title]
					,[FirstName]
					,[Email]
					,[Phone]
					,[Mobile]
					,[PositionTitle]
					,[OfficeLocation]
					,[Categories]
					,[Location]
					,[FriendlyUrl]
					,[ShortDescription]
					,[Testimonial]
					,[FullDescription]
					,[ConsultantData]
					,[LinkedInUrl]
					,[TwitterUrl]
					,[FacebookUrl]
					,[GoogleUrl]
					,[Link]
					,[WechatUrl]
					,[FeaturedTeamMember]
					,[ImageUrl]
					,[VideoUrl]
					,[BlogRSS]
					,[NewsRSS]
					,[JobRSS]
					,[TestimonialsRSS]
					,[Valid]
					,[MetaTitle]
					,[MetaDescription]
					,[MetaKeywords]
					,[LastModifiedBy]
					,[LastModified]
					,[Sequence]
					,[LastName]
					,[ConsultantsXML]
					,[ConsultantImageUrl]
					)
				VALUES
					(
					@SiteId
					,@LanguageId
					,@Title
					,@FirstName
					,@Email
					,@Phone
					,@Mobile
					,@PositionTitle
					,@OfficeLocation
					,@Categories
					,@Location
					,@FriendlyUrl
					,@ShortDescription
					,@Testimonial
					,@FullDescription
					,@ConsultantData
					,@LinkedInUrl
					,@TwitterUrl
					,@FacebookUrl
					,@GoogleUrl
					,@Link
					,@WechatUrl
					,@FeaturedTeamMember
					,@ImageUrl
					,@VideoUrl
					,@BlogRss
					,@NewsRss
					,@JobRss
					,@TestimonialsRss
					,@Valid
					,@MetaTitle
					,@MetaDescription
					,@MetaKeywords
					,@LastModifiedBy
					,@LastModified
					,@Sequence
					,@LastName
					,@ConsultantsXml
					,@ConsultantImageUrl
					)
				
				-- Get the identity value
				SET @ConsultantId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Consultants_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Consultants table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_GetPaged]
GO


CREATE PROCEDURE [dbo].[Consultants_GetPaged]
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
				    [ConsultantID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ConsultantID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ConsultantID]'
				SET @SQL = @SQL + ' FROM [dbo].[Consultants]'
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
				SELECT O.[ConsultantID], O.[SiteID], O.[LanguageID], O.[Title], O.[FirstName], O.[Email], O.[Phone], O.[Mobile], O.[PositionTitle], O.[OfficeLocation], O.[Categories], O.[Location], O.[FriendlyUrl], O.[ShortDescription], O.[Testimonial], O.[FullDescription], O.[ConsultantData], O.[LinkedInUrl], O.[TwitterUrl], O.[FacebookUrl], O.[GoogleUrl], O.[Link], O.[WechatUrl], O.[FeaturedTeamMember], O.[ImageUrl], O.[VideoUrl], O.[BlogRSS], O.[NewsRSS], O.[JobRSS], O.[TestimonialsRSS], O.[Valid], O.[MetaTitle], O.[MetaDescription], O.[MetaKeywords], O.[LastModifiedBy], O.[LastModified], O.[Sequence], O.[LastName], O.[ConsultantsXML], O.[ConsultantImageUrl]
				FROM
				    [dbo].[Consultants] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ConsultantID] = PageIndex.[ConsultantID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Consultants]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Consultants_GetBySiteId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Consultants table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_GetBySiteId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_GetBySiteId]
GO

CREATE PROCEDURE [dbo].[Consultants_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ConsultantID],
					[SiteID],
					[LanguageID],
					[Title],
					[FirstName],
					[Email],
					[Phone],
					[Mobile],
					[PositionTitle],
					[OfficeLocation],
					[Categories],
					[Location],
					[FriendlyUrl],
					[ShortDescription],
					[Testimonial],
					[FullDescription],
					[ConsultantData],
					[LinkedInUrl],
					[TwitterUrl],
					[FacebookUrl],
					[GoogleUrl],
					[Link],
					[WechatUrl],
					[FeaturedTeamMember],
					[ImageUrl],
					[VideoUrl],
					[BlogRSS],
					[NewsRSS],
					[JobRSS],
					[TestimonialsRSS],
					[Valid],
					[MetaTitle],
					[MetaDescription],
					[MetaKeywords],
					[LastModifiedBy],
					[LastModified],
					[Sequence],
					[LastName],
					[ConsultantsXML],
					[ConsultantImageUrl]
				FROM
					[dbo].[Consultants]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Consultants_GetByConsultantId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Consultants table through an index
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_GetByConsultantId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_GetByConsultantId]
GO

CREATE PROCEDURE [dbo].[Consultants_GetByConsultantId]
(

	@ConsultantId int   
)
AS


				SELECT
					[ConsultantID],
					[SiteID],
					[LanguageID],
					[Title],
					[FirstName],
					[Email],
					[Phone],
					[Mobile],
					[PositionTitle],
					[OfficeLocation],
					[Categories],
					[Location],
					[FriendlyUrl],
					[ShortDescription],
					[Testimonial],
					[FullDescription],
					[ConsultantData],
					[LinkedInUrl],
					[TwitterUrl],
					[FacebookUrl],
					[GoogleUrl],
					[Link],
					[WechatUrl],
					[FeaturedTeamMember],
					[ImageUrl],
					[VideoUrl],
					[BlogRSS],
					[NewsRSS],
					[JobRSS],
					[TestimonialsRSS],
					[Valid],
					[MetaTitle],
					[MetaDescription],
					[MetaKeywords],
					[LastModifiedBy],
					[LastModified],
					[Sequence],
					[LastName],
					[ConsultantsXML],
					[ConsultantImageUrl]
				FROM
					[dbo].[Consultants]
				WHERE
					[ConsultantID] = @ConsultantId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Consultants_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Consultants table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_Get_List]
GO


CREATE PROCEDURE [dbo].[Consultants_Get_List]

AS


				
				SELECT
					[ConsultantID],
					[SiteID],
					[LanguageID],
					[Title],
					[FirstName],
					[Email],
					[Phone],
					[Mobile],
					[PositionTitle],
					[OfficeLocation],
					[Categories],
					[Location],
					[FriendlyUrl],
					[ShortDescription],
					[Testimonial],
					[FullDescription],
					[ConsultantData],
					[LinkedInUrl],
					[TwitterUrl],
					[FacebookUrl],
					[GoogleUrl],
					[Link],
					[WechatUrl],
					[FeaturedTeamMember],
					[ImageUrl],
					[VideoUrl],
					[BlogRSS],
					[NewsRSS],
					[JobRSS],
					[TestimonialsRSS],
					[Valid],
					[MetaTitle],
					[MetaDescription],
					[MetaKeywords],
					[LastModifiedBy],
					[LastModified],
					[Sequence],
					[LastName],
					[ConsultantsXML],
					[ConsultantImageUrl]
				FROM
					[dbo].[Consultants]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Consultants_Find]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Consultants table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_Find]
GO

CREATE PROCEDURE [dbo].[Consultants_Find]
(

	@SearchUsingOR bit   = null ,

	@ConsultantId int   = null ,

	@SiteId int   = null ,

	@LanguageId int   = null ,

	@Title nvarchar (128)  = null ,

	@FirstName nvarchar (512)  = null ,

	@Email varchar (255)  = null ,

	@Phone varchar (512)  = null ,

	@Mobile varchar (512)  = null ,

	@PositionTitle nvarchar (128)  = null ,

	@OfficeLocation nvarchar (1024)  = null ,

	@Categories nvarchar (1024)  = null ,

	@Location nvarchar (1024)  = null ,

	@FriendlyUrl varchar (128)  = null ,

	@ShortDescription nvarchar (MAX)  = null ,

	@Testimonial nvarchar (MAX)  = null ,

	@FullDescription nvarchar (MAX)  = null ,

	@ConsultantData nvarchar (MAX)  = null ,

	@LinkedInUrl varchar (512)  = null ,

	@TwitterUrl varchar (512)  = null ,

	@FacebookUrl varchar (512)  = null ,

	@GoogleUrl varchar (512)  = null ,

	@Link varchar (512)  = null ,

	@WechatUrl varchar (512)  = null ,

	@FeaturedTeamMember int   = null ,

	@ImageUrl image   = null ,

	@VideoUrl varchar (512)  = null ,

	@BlogRss varchar (512)  = null ,

	@NewsRss varchar (512)  = null ,

	@JobRss varchar (512)  = null ,

	@TestimonialsRss varchar (512)  = null ,

	@Valid int   = null ,

	@MetaTitle nvarchar (510)  = null ,

	@MetaDescription nvarchar (1024)  = null ,

	@MetaKeywords nvarchar (510)  = null ,

	@LastModifiedBy int   = null ,

	@LastModified datetime   = null ,

	@Sequence int   = null ,

	@LastName nvarchar (512)  = null ,

	@ConsultantsXml nvarchar (MAX)  = null ,

	@ConsultantImageUrl nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ConsultantID]
	, [SiteID]
	, [LanguageID]
	, [Title]
	, [FirstName]
	, [Email]
	, [Phone]
	, [Mobile]
	, [PositionTitle]
	, [OfficeLocation]
	, [Categories]
	, [Location]
	, [FriendlyUrl]
	, [ShortDescription]
	, [Testimonial]
	, [FullDescription]
	, [ConsultantData]
	, [LinkedInUrl]
	, [TwitterUrl]
	, [FacebookUrl]
	, [GoogleUrl]
	, [Link]
	, [WechatUrl]
	, [FeaturedTeamMember]
	, [ImageUrl]
	, [VideoUrl]
	, [BlogRSS]
	, [NewsRSS]
	, [JobRSS]
	, [TestimonialsRSS]
	, [Valid]
	, [MetaTitle]
	, [MetaDescription]
	, [MetaKeywords]
	, [LastModifiedBy]
	, [LastModified]
	, [Sequence]
	, [LastName]
	, [ConsultantsXML]
	, [ConsultantImageUrl]
    FROM
	[dbo].[Consultants]
    WHERE 
	 ([ConsultantID] = @ConsultantId OR @ConsultantId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([LanguageID] = @LanguageId OR @LanguageId IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Mobile] = @Mobile OR @Mobile IS NULL)
	AND ([PositionTitle] = @PositionTitle OR @PositionTitle IS NULL)
	AND ([OfficeLocation] = @OfficeLocation OR @OfficeLocation IS NULL)
	AND ([Categories] = @Categories OR @Categories IS NULL)
	AND ([Location] = @Location OR @Location IS NULL)
	AND ([FriendlyUrl] = @FriendlyUrl OR @FriendlyUrl IS NULL)
	AND ([ShortDescription] = @ShortDescription OR @ShortDescription IS NULL)
	AND ([Testimonial] = @Testimonial OR @Testimonial IS NULL)
	AND ([FullDescription] = @FullDescription OR @FullDescription IS NULL)
	AND ([ConsultantData] = @ConsultantData OR @ConsultantData IS NULL)
	AND ([LinkedInUrl] = @LinkedInUrl OR @LinkedInUrl IS NULL)
	AND ([TwitterUrl] = @TwitterUrl OR @TwitterUrl IS NULL)
	AND ([FacebookUrl] = @FacebookUrl OR @FacebookUrl IS NULL)
	AND ([GoogleUrl] = @GoogleUrl OR @GoogleUrl IS NULL)
	AND ([Link] = @Link OR @Link IS NULL)
	AND ([WechatUrl] = @WechatUrl OR @WechatUrl IS NULL)
	AND ([FeaturedTeamMember] = @FeaturedTeamMember OR @FeaturedTeamMember IS NULL)
	AND ([VideoUrl] = @VideoUrl OR @VideoUrl IS NULL)
	AND ([BlogRSS] = @BlogRss OR @BlogRss IS NULL)
	AND ([NewsRSS] = @NewsRss OR @NewsRss IS NULL)
	AND ([JobRSS] = @JobRss OR @JobRss IS NULL)
	AND ([TestimonialsRSS] = @TestimonialsRss OR @TestimonialsRss IS NULL)
	AND ([Valid] = @Valid OR @Valid IS NULL)
	AND ([MetaTitle] = @MetaTitle OR @MetaTitle IS NULL)
	AND ([MetaDescription] = @MetaDescription OR @MetaDescription IS NULL)
	AND ([MetaKeywords] = @MetaKeywords OR @MetaKeywords IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([Sequence] = @Sequence OR @Sequence IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([ConsultantsXML] = @ConsultantsXml OR @ConsultantsXml IS NULL)
	AND ([ConsultantImageUrl] = @ConsultantImageUrl OR @ConsultantImageUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ConsultantID]
	, [SiteID]
	, [LanguageID]
	, [Title]
	, [FirstName]
	, [Email]
	, [Phone]
	, [Mobile]
	, [PositionTitle]
	, [OfficeLocation]
	, [Categories]
	, [Location]
	, [FriendlyUrl]
	, [ShortDescription]
	, [Testimonial]
	, [FullDescription]
	, [ConsultantData]
	, [LinkedInUrl]
	, [TwitterUrl]
	, [FacebookUrl]
	, [GoogleUrl]
	, [Link]
	, [WechatUrl]
	, [FeaturedTeamMember]
	, [ImageUrl]
	, [VideoUrl]
	, [BlogRSS]
	, [NewsRSS]
	, [JobRSS]
	, [TestimonialsRSS]
	, [Valid]
	, [MetaTitle]
	, [MetaDescription]
	, [MetaKeywords]
	, [LastModifiedBy]
	, [LastModified]
	, [Sequence]
	, [LastName]
	, [ConsultantsXML]
	, [ConsultantImageUrl]
    FROM
	[dbo].[Consultants]
    WHERE 
	 ([ConsultantID] = @ConsultantId AND @ConsultantId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([LanguageID] = @LanguageId AND @LanguageId is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Mobile] = @Mobile AND @Mobile is not null)
	OR ([PositionTitle] = @PositionTitle AND @PositionTitle is not null)
	OR ([OfficeLocation] = @OfficeLocation AND @OfficeLocation is not null)
	OR ([Categories] = @Categories AND @Categories is not null)
	OR ([Location] = @Location AND @Location is not null)
	OR ([FriendlyUrl] = @FriendlyUrl AND @FriendlyUrl is not null)
	OR ([ShortDescription] = @ShortDescription AND @ShortDescription is not null)
	OR ([Testimonial] = @Testimonial AND @Testimonial is not null)
	OR ([FullDescription] = @FullDescription AND @FullDescription is not null)
	OR ([ConsultantData] = @ConsultantData AND @ConsultantData is not null)
	OR ([LinkedInUrl] = @LinkedInUrl AND @LinkedInUrl is not null)
	OR ([TwitterUrl] = @TwitterUrl AND @TwitterUrl is not null)
	OR ([FacebookUrl] = @FacebookUrl AND @FacebookUrl is not null)
	OR ([GoogleUrl] = @GoogleUrl AND @GoogleUrl is not null)
	OR ([Link] = @Link AND @Link is not null)
	OR ([WechatUrl] = @WechatUrl AND @WechatUrl is not null)
	OR ([FeaturedTeamMember] = @FeaturedTeamMember AND @FeaturedTeamMember is not null)
	OR ([VideoUrl] = @VideoUrl AND @VideoUrl is not null)
	OR ([BlogRSS] = @BlogRss AND @BlogRss is not null)
	OR ([NewsRSS] = @NewsRss AND @NewsRss is not null)
	OR ([JobRSS] = @JobRss AND @JobRss is not null)
	OR ([TestimonialsRSS] = @TestimonialsRss AND @TestimonialsRss is not null)
	OR ([Valid] = @Valid AND @Valid is not null)
	OR ([MetaTitle] = @MetaTitle AND @MetaTitle is not null)
	OR ([MetaDescription] = @MetaDescription AND @MetaDescription is not null)
	OR ([MetaKeywords] = @MetaKeywords AND @MetaKeywords is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([Sequence] = @Sequence AND @Sequence is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([ConsultantsXML] = @ConsultantsXml AND @ConsultantsXml is not null)
	OR ([ConsultantImageUrl] = @ConsultantImageUrl AND @ConsultantImageUrl is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Consultants_Delete]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Consultants table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consultants_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Consultants_Delete]
GO

CREATE PROCEDURE [dbo].[Consultants_Delete]
(

	@ConsultantId int   
)
AS


				DELETE FROM [dbo].[Consultants] WITH (ROWLOCK) 
				WHERE
					[ConsultantID] = @ConsultantId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Update]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_Update]
GO

CREATE PROCEDURE [dbo].[Advertisers_Update]
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

	@AdvertiserLogoUrl nvarchar (1000)  
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
				WHERE
[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Insert]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_Insert]
GO

CREATE PROCEDURE [dbo].[Advertisers_Insert]
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

	@AdvertiserLogoUrl nvarchar (1000)  
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
					)
				
				-- Get the identity value
				SET @AdvertiserId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetPaged]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetPaged]
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
				SELECT O.[AdvertiserID], O.[SiteID], O.[AdvertiserAccountTypeID], O.[AdvertiserBusinessTypeID], O.[AdvertiserAccountStatusID], O.[CompanyName], O.[BusinessNumber], O.[StreetAddress1], O.[StreetAddress2], O.[LastModified], O.[LastModifiedBy], O.[PostalAddress1], O.[PostalAddress2], O.[WebAddress], O.[NoOfEmployees], O.[FirstApprovedDate], O.[Profile], O.[CharityNumber], O.[SearchField], O.[FreeTrialStartDate], O.[FreeTrialEndDate], O.[AccountsPayableEmail], O.[RequireLogonForExternalApplication], O.[AdvertiserLogo], O.[LinkedInLogo], O.[LinkedInCompanyId], O.[LinkedInEmail], O.[RegisterDate], O.[ExternalAdvertiserID], O.[VideoLink], O.[Industry], O.[NominatedCompanyRole], O.[NominatedCompanyFirstName], O.[NominatedCompanyLastName], O.[NominatedCompanyEmailAddress], O.[NominatedCompanyPhone], O.[PreferredContactMethod], O.[AdvertiserLogoUrl]
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
/****** Object:  StoredProcedure [dbo].[Advertisers_GetBySiteId]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetBySiteId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetBySiteId]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetBySiteId]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByLastModifiedBy]    Script Date: 11/04/2016 10:07:05 ******/
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
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByLastModifiedBy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByLastModifiedBy]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByLastModifiedBy]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserId]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByAdvertiserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByAdvertiserId]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByAdvertiserId]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserBusinessTypeId]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByAdvertiserBusinessTypeId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByAdvertiserBusinessTypeId]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByAdvertiserBusinessTypeId]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserBusinessTypeID] = @AdvertiserBusinessTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserAccountTypeId]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByAdvertiserAccountTypeId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountTypeId]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountTypeId]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserAccountTypeID] = @AdvertiserAccountTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserAccountStatusId]    Script Date: 11/04/2016 10:07:05 ******/
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
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByAdvertiserAccountStatusId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountStatusId]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByAdvertiserAccountStatusId]
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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserAccountStatusID] = @AdvertiserAccountStatusId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertiserCount]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetAdvertiserCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetAdvertiserCount]
GO


CREATE PROCEDURE [dbo].[Advertisers_GetAdvertiserCount]
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
/****** Object:  StoredProcedure [dbo].[Advertisers_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_Get_List]
GO

CREATE PROCEDURE [dbo].[Advertisers_Get_List]

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
					[AdvertiserLogoUrl]
				FROM
					[dbo].[Advertisers]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Find]    Script Date: 11/04/2016 10:07:05 ******/
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
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_Find]
GO

CREATE PROCEDURE [dbo].[Advertisers_Find]
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

	@AdvertiserLogoUrl nvarchar (1000)  = null 
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
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Delete]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_Delete]
GO

CREATE PROCEDURE [dbo].[Advertisers_Delete]
(

	@AdvertiserId int   
)
AS


				DELETE FROM [dbo].[Advertisers] WITH (ROWLOCK) 
				WHERE
					[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetAllAdvertisers]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_CustomGetAllAdvertisers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_CustomGetAllAdvertisers]
GO

CREATE PROCEDURE [dbo].[Advertisers_CustomGetAllAdvertisers]       
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
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetActivityReport]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_CustomGetActivityReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_CustomGetActivityReport]
GO

CREATE PROCEDURE  [dbo].[Advertisers_CustomGetActivityReport]      
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
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_Update]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AdvertiserJobTemplateLogo table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Update]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Update]
(

	@AdvertiserJobTemplateLogoId int   ,

	@AdvertiserId int   ,

	@JobLogoName nvarchar (255)  ,

	@JobTemplateLogo image   ,

	@JobTemplateLogoUrl nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AdvertiserJobTemplateLogo]
				SET
					[AdvertiserID] = @AdvertiserId
					,[JobLogoName] = @JobLogoName
					,[JobTemplateLogo] = @JobTemplateLogo
					,[JobTemplateLogoUrl] = @JobTemplateLogoUrl
				WHERE
[AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_Insert]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AdvertiserJobTemplateLogo table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Insert]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Insert]
(

	@AdvertiserJobTemplateLogoId int    OUTPUT,

	@AdvertiserId int   ,

	@JobLogoName nvarchar (255)  ,

	@JobTemplateLogo image   ,

	@JobTemplateLogoUrl nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[AdvertiserJobTemplateLogo]
					(
					[AdvertiserID]
					,[JobLogoName]
					,[JobTemplateLogo]
					,[JobTemplateLogoUrl]
					)
				VALUES
					(
					@AdvertiserId
					,@JobLogoName
					,@JobTemplateLogo
					,@JobTemplateLogoUrl
					)
				
				-- Get the identity value
				SET @AdvertiserJobTemplateLogoId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_GetPagingByAdvertiserId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_GetPagingByAdvertiserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetPagingByAdvertiserId]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetPagingByAdvertiserId]  
(  
 @AdvertiserId INT,
 @PageSize INT,          
 @PageNumber INT
)  
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
 
 DECLARE @tmpGetPagingByAdvertiserId TABLE       
 (      
   AdvertiserJobTemplateLogoID INT NOT NULL PRIMARY KEY,       
   RowNumber INT NOT NULL      
 )

 INSERT INTO @tmpGetPagingByAdvertiserId    

 SELECT AdvertiserJobTemplateLogoID, ROW_NUMBER() OVER (ORDER BY AdvertiserJobTemplateLogoID) AS RowNumber
 FROM   AdvertiserJobTemplateLogo WITH (NOLOCK)
 WHERE  (AdvertiserID = @AdvertiserId)

  
 SELECT	AdvertiserJobTemplateLogo.AdvertiserJobTemplateLogoID, AdvertiserJobTemplateLogo.AdvertiserID, 
		AdvertiserJobTemplateLogo.JobLogoName, AdvertiserJobTemplateLogo.JobTemplateLogo, AdvertiserJobTemplateLogo.JobTemplateLogoUrl,
		GetPagingByAdvertiserId.RowNumber AS RowNumber,
		(SELECT COUNT(1) FROM @tmpGetPagingByAdvertiserId) AS TotalCount
 FROM	AdvertiserJobTemplateLogo AdvertiserJobTemplateLogo WITH(NOLOCK)  
 INNER JOIN @tmpGetPagingByAdvertiserId GetPagingByAdvertiserId
		ON  AdvertiserJobTemplateLogo.AdvertiserJobTemplateLogoID = GetPagingByAdvertiserId.AdvertiserJobTemplateLogoID
 WHERE  GetPagingByAdvertiserId.RowNumber >= @PageStart  
 AND    GetPagingByAdvertiserId.RowNumber <= @PageEnd      
 ORDER BY GetPagingByAdvertiserId.RowNumber

END
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AdvertiserJobTemplateLogo table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetPaged]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetPaged]
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
				    [AdvertiserJobTemplateLogoID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([AdvertiserJobTemplateLogoID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [AdvertiserJobTemplateLogoID]'
				SET @SQL = @SQL + ' FROM [dbo].[AdvertiserJobTemplateLogo]'
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
				SELECT O.[AdvertiserJobTemplateLogoID], O.[AdvertiserID], O.[JobLogoName], O.[JobTemplateLogo], O.[JobTemplateLogoUrl]
				FROM
				    [dbo].[AdvertiserJobTemplateLogo] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[AdvertiserJobTemplateLogoID] = PageIndex.[AdvertiserJobTemplateLogoID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AdvertiserJobTemplateLogo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserJobTemplateLogo table through an index
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId]
(

	@AdvertiserJobTemplateLogoId int   
)
AS


				SELECT
					[AdvertiserJobTemplateLogoID],
					[AdvertiserID],
					[JobLogoName],
					[JobTemplateLogo],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[AdvertiserJobTemplateLogo]
				WHERE
					[AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserJobTemplateLogo table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserId]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserJobTemplateLogoID],
					[AdvertiserID],
					[JobLogoName],
					[JobTemplateLogo],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[AdvertiserJobTemplateLogo]
				WHERE
					[AdvertiserID] = @AdvertiserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AdvertiserJobTemplateLogo table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Get_List]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Get_List]

AS


				
				SELECT
					[AdvertiserJobTemplateLogoID],
					[AdvertiserID],
					[JobLogoName],
					[JobTemplateLogo],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[AdvertiserJobTemplateLogo] (NOLOCK)
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_Find]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AdvertiserJobTemplateLogo table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Find]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Find]
(

	@SearchUsingOR bit   = null ,

	@AdvertiserJobTemplateLogoId int   = null ,

	@AdvertiserId int   = null ,

	@JobLogoName nvarchar (255)  = null ,

	@JobTemplateLogo image   = null ,

	@JobTemplateLogoUrl nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvertiserJobTemplateLogoID]
	, [AdvertiserID]
	, [JobLogoName]
	, [JobTemplateLogo]
	, [JobTemplateLogoUrl]
    FROM
	[dbo].[AdvertiserJobTemplateLogo]
    WHERE 
	 ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId OR @AdvertiserJobTemplateLogoId IS NULL)
	AND ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([JobLogoName] = @JobLogoName OR @JobLogoName IS NULL)
	AND ([JobTemplateLogoUrl] = @JobTemplateLogoUrl OR @JobTemplateLogoUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvertiserJobTemplateLogoID]
	, [AdvertiserID]
	, [JobLogoName]
	, [JobTemplateLogo]
	, [JobTemplateLogoUrl]
    FROM
	[dbo].[AdvertiserJobTemplateLogo]
    WHERE 
	 ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId AND @AdvertiserJobTemplateLogoId is not null)
	OR ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([JobLogoName] = @JobLogoName AND @JobLogoName is not null)
	OR ([JobTemplateLogoUrl] = @JobTemplateLogoUrl AND @JobTemplateLogoUrl is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserJobTemplateLogo_Delete]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AdvertiserJobTemplateLogo table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvertiserJobTemplateLogo_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Delete]
GO

CREATE PROCEDURE [dbo].[AdvertiserJobTemplateLogo_Delete]
(

	@AdvertiserJobTemplateLogoId int   
)
AS


				DELETE FROM [dbo].[AdvertiserJobTemplateLogo] WITH (ROWLOCK) 
				WHERE
					[AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]    Script Date: 11/04/2016 10:07:05 ******/
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing]
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
  FROM dbo.[Advertisers]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[AdvertiserJobPricing] 
                WHERE dbo.[AdvertiserJobPricing].[JobItemsTypeID] = @JobItemsTypeId
                  AND dbo.[AdvertiserJobPricing].[AdvertiserID] = dbo.[Advertisers].[AdvertiserID]
                  )
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[ViewJobs_GetViewCount]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobs_GetViewCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobs_GetViewCount]
GO


CREATE PROCEDURE [dbo].[ViewJobs_GetViewCount]   
(  
 @JobID int
)  
AS  
BEGIN  

	SELECT SUM(TotalView) FROM JobViews WHERE JobID = @JobID

END
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_Update]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the JobTemplates table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_Update]
GO

CREATE PROCEDURE [dbo].[JobTemplates_Update]
(

	@JobTemplateId int   ,

	@SiteId int   ,

	@JobTemplateDescription varchar (255)  ,

	@JobTemplateHtml ntext   ,

	@GlobalTemplate bit   ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@JobTemplateLogo image   ,

	@AdvertiserId int   ,

	@JobTemplateLogoUrl nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[JobTemplates]
				SET
					[SiteID] = @SiteId
					,[JobTemplateDescription] = @JobTemplateDescription
					,[JobTemplateHTML] = @JobTemplateHtml
					,[GlobalTemplate] = @GlobalTemplate
					,[LastModifiedBy] = @LastModifiedBy
					,[LastModified] = @LastModified
					,[JobTemplateLogo] = @JobTemplateLogo
					,[AdvertiserID] = @AdvertiserId
					,[JobTemplateLogoUrl] = @JobTemplateLogoUrl
				WHERE
[JobTemplateID] = @JobTemplateId
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_Insert]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the JobTemplates table
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_Insert]
GO

CREATE PROCEDURE [dbo].[JobTemplates_Insert]
(

	@JobTemplateId int    OUTPUT,

	@SiteId int   ,

	@JobTemplateDescription varchar (255)  ,

	@JobTemplateHtml ntext   ,

	@GlobalTemplate bit   ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@JobTemplateLogo image   ,

	@AdvertiserId int   ,

	@JobTemplateLogoUrl nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[JobTemplates]
					(
					[SiteID]
					,[JobTemplateDescription]
					,[JobTemplateHTML]
					,[GlobalTemplate]
					,[LastModifiedBy]
					,[LastModified]
					,[JobTemplateLogo]
					,[AdvertiserID]
					,[JobTemplateLogoUrl]
					)
				VALUES
					(
					@SiteId
					,@JobTemplateDescription
					,@JobTemplateHtml
					,@GlobalTemplate
					,@LastModifiedBy
					,@LastModified
					,@JobTemplateLogo
					,@AdvertiserId
					,@JobTemplateLogoUrl
					)
				
				-- Get the identity value
				SET @JobTemplateId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the JobTemplates table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetPaged]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetPaged]
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
				    [JobTemplateID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobTemplateID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobTemplateID]'
				SET @SQL = @SQL + ' FROM [dbo].[JobTemplates]'
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
				SELECT O.[JobTemplateID], O.[SiteID], O.[JobTemplateDescription], O.[JobTemplateHTML], O.[GlobalTemplate], O.[LastModifiedBy], O.[LastModified], O.[JobTemplateLogo], O.[AdvertiserID], O.[JobTemplateLogoUrl]
				FROM
				    [dbo].[JobTemplates] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobTemplateID] = PageIndex.[JobTemplateID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[JobTemplates]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetBySiteId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobTemplates table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetBySiteId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetBySiteId]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobTemplateID],
					[SiteID],
					[JobTemplateDescription],
					[JobTemplateHTML],
					[GlobalTemplate],
					[LastModifiedBy],
					[LastModified],
					[JobTemplateLogo],
					[AdvertiserID],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[JobTemplates]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetByLastModifiedBy]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobTemplates table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetByLastModifiedBy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetByLastModifiedBy]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobTemplateID],
					[SiteID],
					[JobTemplateDescription],
					[JobTemplateHTML],
					[GlobalTemplate],
					[LastModifiedBy],
					[LastModified],
					[JobTemplateLogo],
					[AdvertiserID],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[JobTemplates]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetByJobTemplateId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobTemplates table through an index
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetByJobTemplateId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetByJobTemplateId]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetByJobTemplateId]
(

	@JobTemplateId int   
)
AS


				SELECT
					[JobTemplateID],
					[SiteID],
					[JobTemplateDescription],
					[JobTemplateHTML],
					[GlobalTemplate],
					[LastModifiedBy],
					[LastModified],
					[JobTemplateLogo],
					[AdvertiserID],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[JobTemplates]
				WHERE
					[JobTemplateID] = @JobTemplateId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetByAdvertiserId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobTemplates table through a foreign key
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetByAdvertiserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetByAdvertiserId]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobTemplateID],
					[SiteID],
					[JobTemplateDescription],
					[JobTemplateHTML],
					[GlobalTemplate],
					[LastModifiedBy],
					[LastModified],
					[JobTemplateLogo],
					[AdvertiserID],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[JobTemplates]
				WHERE
					[AdvertiserID] = @AdvertiserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_GetAdvertiserJobTemplates]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_GetAdvertiserJobTemplates]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_GetAdvertiserJobTemplates]
GO

CREATE PROCEDURE [dbo].[JobTemplates_GetAdvertiserJobTemplates]  
(  
 @SiteId int,  
 @AdvertiserId int  
)  
AS  
 DECLARE @JobTemplates TABLE  
 (  
  [JobTemplateID] int,  
  [SiteID] int,  
  [JobTemplateDescription] varchar(255),  
  [JobTemplateHTML] ntext,  
  [GlobalTemplate] bit,  
  [LastModifiedBy]int,  
  [LastModified] datetime,  
  [JobTemplateLogo] image,  
  [AdvertiserID] int,
  [JobTemplateLogoUrl] nvarchar(2000)  
 )  
  
 INSERT INTO @JobTemplates([JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID],
  [JobTemplateLogoUrl])  
 SELECT  
  [JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID],
  [JobTemplateLogoUrl]  
 FROM  
  [dbo].[JobTemplates] (NOLOCK)  
 WHERE  
  [SiteID] = @SiteId   
  AND [AdvertiserID] = @AdvertiserId  
   
 IF @@ROWCOUNT = 0   
 BEGIN  
  INSERT INTO @JobTemplates([JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID],
  [JobTemplateLogoUrl])  
  SELECT  
   [JobTemplateID],  
   [SiteID],  
   [JobTemplateDescription],  
   [JobTemplateHTML],  
   [GlobalTemplate],  
   [LastModifiedBy],  
   [LastModified],  
   [JobTemplateLogo],  
   [AdvertiserID],
   [JobTemplateLogoUrl]  
  FROM  
   [dbo].[JobTemplates] (NOLOCK)  
  WHERE  
   [SiteID] = @SiteId  
   AND [GlobalTemplate] = 1  
 END  
  
 SELECT  
  [JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID],
  [JobTemplateLogoUrl]  
 FROM @JobTemplates  
  
 SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the JobTemplates table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_Get_List]
GO

CREATE PROCEDURE [dbo].[JobTemplates_Get_List]

AS


				
				SELECT
					[JobTemplateID],
					[SiteID],
					[JobTemplateDescription],
					[JobTemplateHTML],
					[GlobalTemplate],
					[LastModifiedBy],
					[LastModified],
					[JobTemplateLogo],
					[AdvertiserID],
					[JobTemplateLogoUrl]
				FROM
					[dbo].[JobTemplates]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_Find]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the JobTemplates table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_Find]
GO

CREATE PROCEDURE [dbo].[JobTemplates_Find]
(

	@SearchUsingOR bit   = null ,

	@JobTemplateId int   = null ,

	@SiteId int   = null ,

	@JobTemplateDescription varchar (255)  = null ,

	@JobTemplateHtml ntext   = null ,

	@GlobalTemplate bit   = null ,

	@LastModifiedBy int   = null ,

	@LastModified datetime   = null ,

	@JobTemplateLogo image   = null ,

	@AdvertiserId int   = null ,

	@JobTemplateLogoUrl nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobTemplateID]
	, [SiteID]
	, [JobTemplateDescription]
	, [JobTemplateHTML]
	, [GlobalTemplate]
	, [LastModifiedBy]
	, [LastModified]
	, [JobTemplateLogo]
	, [AdvertiserID]
	, [JobTemplateLogoUrl]
    FROM
	[dbo].[JobTemplates]
    WHERE 
	 ([JobTemplateID] = @JobTemplateId OR @JobTemplateId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([JobTemplateDescription] = @JobTemplateDescription OR @JobTemplateDescription IS NULL)
	AND ([GlobalTemplate] = @GlobalTemplate OR @GlobalTemplate IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([JobTemplateLogoUrl] = @JobTemplateLogoUrl OR @JobTemplateLogoUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobTemplateID]
	, [SiteID]
	, [JobTemplateDescription]
	, [JobTemplateHTML]
	, [GlobalTemplate]
	, [LastModifiedBy]
	, [LastModified]
	, [JobTemplateLogo]
	, [AdvertiserID]
	, [JobTemplateLogoUrl]
    FROM
	[dbo].[JobTemplates]
    WHERE 
	 ([JobTemplateID] = @JobTemplateId AND @JobTemplateId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([JobTemplateDescription] = @JobTemplateDescription AND @JobTemplateDescription is not null)
	OR ([GlobalTemplate] = @GlobalTemplate AND @GlobalTemplate is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([JobTemplateLogoUrl] = @JobTemplateLogoUrl AND @JobTemplateLogoUrl is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[JobTemplates_Delete]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the JobTemplates table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobTemplates_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[JobTemplates_Delete]
GO

CREATE PROCEDURE [dbo].[JobTemplates_Delete]
(

	@JobTemplateId int   
)
AS


				DELETE FROM [dbo].[JobTemplates] WITH (ROWLOCK) 
				WHERE
					[JobTemplateID] = @JobTemplateId
GO
/****** Object:  StoredProcedure [dbo].[Sites_Update]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Sites table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Update]
GO

CREATE PROCEDURE [dbo].[Sites_Update]
(

	@SiteId int   ,

	@SiteName varchar (255)  ,

	@SiteUrl varchar (500)  ,

	@SiteDescription varchar (MAX)  ,

	@SiteAdminLogo image   ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@Live bit   ,

	@MobileEnabled bit   ,

	@MobileUrl varchar (255)  ,

	@SiteAdminLogoUrl nvarchar (1000)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Sites]
				SET
					[SiteName] = @SiteName
					,[SiteUrl] = @SiteUrl
					,[SiteDescription] = @SiteDescription
					,[SiteAdminLogo] = @SiteAdminLogo
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
					,[Live] = @Live
					,[MobileEnabled] = @MobileEnabled
					,[MobileUrl] = @MobileUrl
					,[SiteAdminLogoUrl] = @SiteAdminLogoUrl
				WHERE
[SiteID] = @SiteId
GO
/****** Object:  StoredProcedure [dbo].[Sites_Insert]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Sites table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Insert]
GO

CREATE PROCEDURE [dbo].[Sites_Insert]
(

	@SiteId int    OUTPUT,

	@SiteName varchar (255)  ,

	@SiteUrl varchar (500)  ,

	@SiteDescription varchar (MAX)  ,

	@SiteAdminLogo image   ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@Live bit   ,

	@MobileEnabled bit   ,

	@MobileUrl varchar (255)  ,

	@SiteAdminLogoUrl nvarchar (1000)  
)
AS


				
				INSERT INTO [dbo].[Sites]
					(
					[SiteName]
					,[SiteUrl]
					,[SiteDescription]
					,[SiteAdminLogo]
					,[LastModified]
					,[LastModifiedBy]
					,[Live]
					,[MobileEnabled]
					,[MobileUrl]
					,[SiteAdminLogoUrl]
					)
				VALUES
					(
					@SiteName
					,@SiteUrl
					,@SiteDescription
					,@SiteAdminLogo
					,@LastModified
					,@LastModifiedBy
					,@Live
					,@MobileEnabled
					,@MobileUrl
					,@SiteAdminLogoUrl
					)
				
				-- Get the identity value
				SET @SiteId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetPaging]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_GetPaging]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_GetPaging]
GO

CREATE PROCEDURE [dbo].[Sites_GetPaging]  
  @SiteID int = 0,  
  @SiteName VARCHAR(255) = '',  
  @SiteUrl VARCHAR(500) = '',  
  @pageSize int,      
  @pageNumber int      
As  
  
BEGIN    
  
 IF @PageSize IS NULL      
  SET @pageSize = 10      
  
 IF @PageNumber IS NULL      
  SET @PageNumber = 1      
  
 Declare @pageStart int      
 Declare @pageEnd int      
  
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1      
 SET @PageEnd = (@PageNumber * @PageSize)      
  
 DECLARE @tmpSiteID TABLE     
 (    
   SiteID INT NOT NULL PRIMARY KEY,     
   RowNumber INT NOT NULL    
 )    
  
  INSERT INTO @tmpSiteID    
  
  SELECT  Sites.SiteID, ROW_NUMBER() OVER (ORDER BY Sites.SiteName) AS RowNumber      
  FROM    Sites Sites WITH(NOLOCK)    
  WHERE   (ISNULL(@SiteName, '') = '' OR Sites.SiteName like '%' + @SiteName + '%')      
  AND     (ISNULL(@SiteUrl, '') = '' OR Sites.SiteUrl Like '%' + @SiteUrl + '%')      
  AND     (ISNULL(@SiteID, 0) = 0 OR Sites.SiteID = @SiteID)      
  
  SELECT  SitesSearchResult.RowNumber AS RowNumber, Sites.SiteID, Sites.SiteName, Sites.SiteUrl,  
    Sites.SiteDescription, Sites.SiteAdminLogo, Sites.LastModified, Live, Sites.MobileEnabled, Sites.MobileUrl, Sites.SiteAdminLogoUrl,   
    (SELECT COUNT(1) FROM @tmpSiteID) AS TotalCount    
  FROM   Sites Sites WITH(NOLOCK)  
  INNER JOIN @tmpSiteID SitesSearchResult ON Sites.SiteID = SitesSearchResult.SiteID  
  WHERE      SitesSearchResult.RowNumber >= @PageStart      
  AND        SitesSearchResult.RowNumber <= @PageEnd       
  ORDER BY   SitesSearchResult.RowNumber   
  
END
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Sites table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_GetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_GetPaged]
GO

CREATE PROCEDURE [dbo].[Sites_GetPaged]
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
				    [SiteID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([SiteID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [SiteID]'
				SET @SQL = @SQL + ' FROM [dbo].[Sites]'
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
				SELECT O.[SiteID], O.[SiteName], O.[SiteUrl], O.[SiteDescription], O.[SiteAdminLogo], O.[LastModified], O.[LastModifiedBy], O.[Live], O.[MobileEnabled], O.[MobileUrl], O.[SiteAdminLogoUrl]
				FROM
				    [dbo].[Sites] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[SiteID] = PageIndex.[SiteID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Sites]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetBySiteId]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Sites table through an index
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_GetBySiteId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_GetBySiteId]
GO

CREATE PROCEDURE [dbo].[Sites_GetBySiteId]
(

	@SiteId int   
)
AS


				SELECT
					[SiteID],
					[SiteName],
					[SiteUrl],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl]
				FROM
					[dbo].[Sites]
				WHERE
					[SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetByMobileUrl]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Sites table through an index
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_GetByMobileUrl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_GetByMobileUrl]
GO

CREATE PROCEDURE [dbo].[Sites_GetByMobileUrl]
(

	@MobileUrl varchar (255)  
)
AS


				SELECT
					[SiteID],
					[SiteName],
					[SiteUrl],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl]
				FROM
					[dbo].[Sites]
				WHERE
					[MobileUrl] = @MobileUrl
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetByLastModifiedBy]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Sites table through a foreign key
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_GetByLastModifiedBy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_GetByLastModifiedBy]
GO

CREATE PROCEDURE [dbo].[Sites_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteID],
					[SiteName],
					[SiteUrl],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl]
				FROM
					[dbo].[Sites]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Sites_Get_List]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Sites table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Get_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Get_List]
GO

CREATE PROCEDURE [dbo].[Sites_Get_List]

AS


				
				SELECT
					[SiteID],
					[SiteName],
					[SiteUrl],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl]
				FROM
					[dbo].[Sites]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_FindSite]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_FindSite]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_FindSite]
GO
CREATE PROCEDURE [dbo].[Sites_FindSite]    
(     
 @SiteId int   = null ,      
 @SiteUrl varchar (500)  = null    
)      
AS      
    
SELECT    
 Sites.SiteID, Sites.SiteName, Sites.SiteUrl, Sites.SiteDescription, Sites.SiteAdminLogo, Sites.SiteAdminLogoUrl, GlobalSettings.DefaultLanguageID, Live, 
	MobileEnabled, MobileUrl    
FROM     
 Sites INNER JOIN GlobalSettings     
  ON Sites.SiteID = GlobalSettings.SiteID    
WHERE       
 (Sites.[SiteID] = @SiteId OR @SiteId IS null)      
 AND (Sites.[SiteUrl] = @SiteUrl OR isNULL(@SiteUrl, '') = '')      
    
SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_Find]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Sites table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Find]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Find]
GO

CREATE PROCEDURE [dbo].[Sites_Find]
(

	@SearchUsingOR bit   = null ,

	@SiteId int   = null ,

	@SiteName varchar (255)  = null ,

	@SiteUrl varchar (500)  = null ,

	@SiteDescription varchar (MAX)  = null ,

	@SiteAdminLogo image   = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null ,

	@Live bit   = null ,

	@MobileEnabled bit   = null ,

	@MobileUrl varchar (255)  = null ,

	@SiteAdminLogoUrl nvarchar (1000)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteUrl]
	, [SiteDescription]
	, [SiteAdminLogo]
	, [LastModified]
	, [LastModifiedBy]
	, [Live]
	, [MobileEnabled]
	, [MobileUrl]
	, [SiteAdminLogoUrl]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([SiteName] = @SiteName OR @SiteName IS NULL)
	AND ([SiteUrl] = @SiteUrl OR @SiteUrl IS NULL)
	AND ([SiteDescription] = @SiteDescription OR @SiteDescription IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([Live] = @Live OR @Live IS NULL)
	AND ([MobileEnabled] = @MobileEnabled OR @MobileEnabled IS NULL)
	AND ([MobileUrl] = @MobileUrl OR @MobileUrl IS NULL)
	AND ([SiteAdminLogoUrl] = @SiteAdminLogoUrl OR @SiteAdminLogoUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteUrl]
	, [SiteDescription]
	, [SiteAdminLogo]
	, [LastModified]
	, [LastModifiedBy]
	, [Live]
	, [MobileEnabled]
	, [MobileUrl]
	, [SiteAdminLogoUrl]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([SiteName] = @SiteName AND @SiteName is not null)
	OR ([SiteUrl] = @SiteUrl AND @SiteUrl is not null)
	OR ([SiteDescription] = @SiteDescription AND @SiteDescription is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([Live] = @Live AND @Live is not null)
	OR ([MobileEnabled] = @MobileEnabled AND @MobileEnabled is not null)
	OR ([MobileUrl] = @MobileUrl AND @MobileUrl is not null)
	OR ([SiteAdminLogoUrl] = @SiteAdminLogoUrl AND @SiteAdminLogoUrl is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Sites_Delete]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Sites table
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Delete]
GO

CREATE PROCEDURE [dbo].[Sites_Delete]
(

	@SiteId int   
)
AS


				DELETE FROM [dbo].[Sites] WITH (ROWLOCK) 
				WHERE
					[SiteID] = @SiteId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_CustomGetExpiringJobAdvertiser]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--New    

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_CustomGetExpiringJobAdvertiser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_CustomGetExpiringJobAdvertiser]
GO
 
CREATE PROCEDURE [dbo].[Advertisers_CustomGetExpiringJobAdvertiser]      
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
/****** Object:  StoredProcedure [dbo].[Sites_Create]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Create]
GO

CREATE PROCEDURE [dbo].[Sites_Create]
(
	@SourceSiteID INT,
	@LanguageID INT,
	@SiteName VARCHAR(255),
	@SiteUrl VARCHAR(255),
	@SiteDescription VARCHAR(255),
	@LastModifiedBy INT
)
AS
	BEGIN TRY
		BEGIN TRANSACTION SITECOPYTRANSACTION
		
			DECLARE @NewSiteID INT
			
			INSERT INTO Sites(SiteName, SiteUrl, SiteDescription, MobileEnabled, MobileUrl, LastModified, LastModifiedBy)
			VALUES (@SiteName, @SiteUrl, @SiteDescription, 0, 'm.' + @SiteUrl, GETDATE(), @LastModifiedBy)
		     
		    SET @NewSiteID = SCOPE_IDENTITY()
		    
		    
			INSERT INTO GlobalSettings([SiteID],[DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]
									  ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]
									  ,[LastModifiedBy],[LastModified],[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]
									  ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton],[UseAdvertiserFilter],[MerchantID],[ShowTwitterButton]
									  ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol])
			SELECT					  @NewSiteID, [DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]
									  ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]
									  ,@LastModifiedBy AS LastModifiedBy, GETDATE() AS [LastModified] ,[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]
									  ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton],[UseAdvertiserFilter],[MerchantID],[ShowTwitterButton]
									  ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol]
			FROM [GlobalSettings] (NOLOCK)
			WHERE SiteID = @SourceSiteID
	
		   
			-- INSERT Site Web Parts

			INSERT INTO SiteWebParts([SiteID],
									[SiteWebPartName],[SiteWebPartTypeID],
									[SiteWebPartHTML],[SourceID])
			SELECT @NewSiteID,[SiteWebPartName],[SiteWebPartTypeID],
									[SiteWebPartHTML],[SiteWebPartID]
			FROM SiteWebParts (NOLOCK)
			WHERE SiteID = @SourceSiteID
							
			-- INSERT Web Part Template
			INSERT INTO DynamicPageWebPartTemplates([DynamicPageWebPartName],[SiteID]
													,[LastModified],[LastModifiedBy],[SourceID])
			SELECT [DynamicPageWebPartName],@NewSiteID,[LastModified],[LastModifiedBy],[DynamicPageWebPartTemplateID]
			FROM DynamicPageWebPartTemplates (NOLOCK)
			WHERE SiteID = @SourceSiteID

			-- INSERT Web Part Template Link
			
			INSERT INTO DynamicPageWebPartTemplatesLink ([DynamicPageWebPartTemplateID], [SiteWebPartID], [Sequence])
			SELECT (SELECT DynamicPageWebPartTemplateID FROM DynamicPageWebPartTemplates wpt WHERE wpt.SiteId = @NewSiteID AND wpt.SourceID = wptl.DynamicPageWebPartTemplateID), 
					(SELECT SiteWebPartID FROM SiteWebParts swp WHERE swp.SiteID = @NewSiteID AND swp.SourceID = wptl.SiteWebPartID), Sequence
			FROM DynamicPageWebPartTemplatesLink wptl
			WHERE wptl.DynamicPageWebPartTemplateID IN (SELECT DynamicPageWebPartTemplateID FROM DynamicPageWebPartTemplates WHERE SiteId = @SourceSiteID)

		
			INSERT INTO Files ([SiteID],[FolderID],[FileName],[FileSystemName],[FileTypeID],[LastModified],[LastModifiedBy],[SourceID])
			SELECT @NewSiteID,[FolderID],[FileName],[FileSystemName],[FileTypeID],[LastModified],[LastModifiedBy],FileID
			FROM Files (NOLOCK) WHERE SiteID = @SourceSiteID --AND FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles) )

			INSERT INTO SiteLanguages (SiteID, LanguageID, SiteLanguageName)
			SELECT @NewSiteID, LanguageID, SiteLanguageName 
			FROM SiteLanguages (NOLOCK)
			WHERE SiteID = @SourceSiteID
			AND LanguageID = @LanguageID

			INSERT INTO DynamicPages (SiteID,LanguageID,ParentDynamicPageID,PageName,
						PageTitle,PageContent,DynamicPageWebPartTemplateID,HyperLink,
						Valid,OpenInNewWindow,Sequence,FullScreen,OnTopNav,OnLeftNav,
						OnBottomNav,OnSiteMap,Searchable,MetaKeywords,MetaDescription,
						PageFriendlyName,LastModified,LastModifiedBy,SearchField,SourceID)
			SELECT @NewSiteID,LanguageID,ParentDynamicPageID,PageName,
						PageTitle,PageContent,wpt.DynamicPageWebPartTemplateID,HyperLink,
						Valid,OpenInNewWindow,Sequence,FullScreen,OnTopNav,OnLeftNav,
						OnBottomNav,OnSiteMap,Searchable,MetaKeywords,MetaDescription,
						PageFriendlyName,dp.LastModified,dp.LastModifiedBy,SearchField,DynamicPageID
			FROM DynamicPages dp INNER JOIN DynamicPageWebPartTemplates wpt 
			ON dp.DynamicPageWebPartTemplateID = wpt.SourceID AND wpt.SiteID = @NewSiteID
			WHERE dp.SiteID = @SourceSiteID AND dp.PageName LIKE '%SystemPage%' AND LanguageID = @LanguageID

			INSERT INTO DynamicPageFiles (SiteID, PageName, FileID)
			SELECT @NewSiteID, PageName, f.FileID 
			FROM DynamicPageFiles dpf INNER JOIN Files f 
			ON dpf.FileID = f.SourceID AND dpf.SiteID = @NewSiteID
			WHERE dpf.SiteID = @SourceSiteID --AND dpf.FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles))
			
			UPDATE DynamicPages SET DynamicPages.ParentDynamicPageID = DP2.DynamicPageID
			FROM DynamicPages
			INNER JOIN DynamicPages DP2 ON DynamicPages.ParentDynamicPageID = DP2.SourceID
			WHERE DynamicPages.ParentDynamicPageID > 0
			AND DynamicPages.SiteID = @NewSiteID
			AND DP2.SiteID = @NewSiteID	

		   --Return the new object
		   SELECT SiteName, SiteUrl, SiteDescription, LastModified, LastModifiedBy
		   FROM Sites (NOLOCK)
		   WHERE SiteID = @NewSiteID
		   
		COMMIT TRANSACTION SITECOPYTRANSACTION

		

	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION SITECOPYTRANSACTION --RollBack in case of Error
 
				-- Raise an error with the details of the exception
				DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT
				SELECT @ErrMsg = ERROR_MESSAGE(),
				@ErrSeverity = ERROR_SEVERITY()
 
				RAISERROR(@ErrMsg, @ErrSeverity, 1)
 
		END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAllJobStatistics]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Start of Job Application Draft update */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetAllJobStatistics]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetAllJobStatistics]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetAllJobStatistics]    
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
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertiserTypeStatistics]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetAdvertiserTypeStatistics]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetAdvertiserTypeStatistics]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetAdvertiserTypeStatistics]  
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
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAllAdvertisers]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetAllAdvertisers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetAllAdvertisers]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetAllAdvertisers]
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
/****** Object:  StoredProcedure [dbo].[Advertisers_GetAdvertisersNotPostedSince]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_GetAdvertisersNotPostedSince]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_GetAdvertisersNotPostedSince]
GO

CREATE PROCEDURE [dbo].[Advertisers_GetAdvertisersNotPostedSince] 
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
/****** Object:  StoredProcedure [dbo].[Advertisers_AdminGetPaged]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Advertisers_AdminGetPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Advertisers_AdminGetPaged]
GO

CREATE PROCEDURE [dbo].[Advertisers_AdminGetPaged]          
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
/****** Object:  StoredProcedure [dbo].[ViewJobsArchive_Get]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ViewJobsArchive view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobsArchive_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobsArchive_Get]
GO

CREATE PROCEDURE [dbo].[ViewJobsArchive_Get]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[ViewJobsArchive]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
GO
/****** Object:  StoredProcedure [dbo].[ViewJobs_Get]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ViewJobs view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobs_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobs_Get]
GO

CREATE PROCEDURE [dbo].[ViewJobs_Get]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[ViewJobs]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
GO
/****** Object:  StoredProcedure [dbo].[Sites_Remove]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Remove]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Remove]
GO

CREATE PROCEDURE [dbo].[Sites_Remove]  
(  
 @SiteId int     
)  
AS  
BEGIN  
 DECLARE @TransactionName varchar(20)  
 SET @TransactionName = 'SiteDelete'  
   
BEGIN TRY  
 BEGIN TRAN @TransactionName  
 DELETE FROM AdvertiserJobTemplateLogo  
 WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WITH (NOLOCK) WHERE SiteID = @SiteId)  
  
 DELETE FROM DefaultResources WHERE ResourceFileID IN (SELECT FileID FROM Files WITH (NOLOCK) WHERE SiteID = @SiteID)  
  
 DELETE FROM DynamicPageFiles WHERE FileID IN (SELECT FileID FROM Files WITH (NOLOCK) WHERE SiteID = @SiteID)  
   
 DELETE FROM Enquiries WHERE SiteID = @SiteId  
  
 DELETE FROM GlobalSettings WHERE SiteID = @SiteId   
  
 UPDATE GlobalSettings SET DefaultDynamicPageID = NULL WHERE DefaultDynamicPageID IN (SELECT DynamicPageID FROM DynamicPages WITH (NOLOCK) WHERE SiteID = @SiteID)  
   
 DELETE FROM JobAlerts WHERE SiteID = @SiteId   
   
 DELETE FROM JobApplicationNotes WHERE JobApplicationID IN (SELECT JobApplicationID FROM JobApplication WHERE SiteID_Referral = @SiteId)  
  
 DELETE FROM JobApplication WHERE SiteID_Referral = @SiteId  
   
 DELETE FROM JobApplication WHERE JobID IN (SELECT JobID FROM Jobs WHERE SiteID = @SiteId)  
  
 DELETE FROM JobApplication WHERE JobID IN (SELECT JobID FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
   
 DELETE FROM JobApplication WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE SiteID = @SiteId)  
  
 DELETE FROM JobApplication WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))   
  
 DELETE FROM JobArea WHERE JobID IN (SELECT JobID FROM Jobs WHERE SiteID = @SiteId)  
  
 DELETE FROM JobArea WHERE JobID IN (SELECT JobID FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
   
 DELETE FROM JobArea WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE SiteID = @SiteId)  
  
 DELETE FROM JobArea WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  

 DELETE FROM JobArea WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WHERE SiteID = @SiteId))  

 DELETE FROM JobArea WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobTemplateID IN (SELECT JobTemplateID FROM JobTemplates WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WHERE SiteID = @SiteId)))
  
 DELETE FROM JobRoles WHERE JobID IN (SELECT JobID FROM Jobs WHERE SiteID = @SiteId)  
  
 DELETE FROM JobRoles WHERE JobID IN (SELECT JobID FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
  
 DELETE FROM JobRoles WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE SiteID = @SiteId)  
  
 DELETE FROM JobRoles WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
  
 DELETE FROM JobsSaved WHERE JobID IN (SELECT JobID FROM Jobs WHERE SiteID = @SiteId)  
  
 DELETE FROM JobsSaved WHERE JobID IN (SELECT JobID FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
  
 DELETE FROM JobsSaved WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE SiteID = @SiteId)  
  
 DELETE FROM JobsSaved WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
   
 DELETE FROM JobViews WHERE SiteID = @SiteId

 DELETE FROM JobViews WHERE JobID IN (SELECT JobID FROM Jobs WHERE SiteID = @SiteId)  
  
 DELETE FROM JobViews WHERE JobID IN (SELECT JobID FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
  
 DELETE FROM JobViews WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE SiteID = @SiteId)  
  
 DELETE FROM JobViews WHERE JobArchiveID IN (SELECT JobID FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteID))  
  
 DELETE FROM JobsArchive WHERE SiteID = @SiteId  
  
 DELETE FROM JobsArchive WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteId)  

 DELETE FROM JobsArchive WHERE JobTemplateID IN (SELECT JobTemplateID FROM JobTemplates WHERE SiteID = @SiteId)  

 DELETE FROM JobsArchive WHERE JobTemplateID IN (SELECT JobTemplateID FROM JobTemplates WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WHERE SiteID = @SiteId))
  
 DELETE FROM Jobs WHERE SiteID = @SiteId  
   
 DELETE FROM Jobs WHERE JobItemTypeID IN (SELECT JobItemTypeID FROM JobItemsType WHERE SiteID = @SiteId)  
  
 DELETE FROM Jobs WHERE JobTemplateID IN (SELECT JobTemplateID FROM JobTemplates WHERE SiteID = @SiteId)  
   
 DELETE FROM JobItemsType WHERE SiteID = @SiteId  
  
 DELETE FROM JobTemplates WHERE SiteID = @SiteId   
  
 DELETE FROM JobTemplates WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WHERE SiteID = @SiteId)  
  
 DELETE FROM MemberFiles WHERE MemberId IN (SELECT MemberID FROM Members WHERE SiteID = @SiteId)  
  
 DELETE FROM News WHERE SiteID = @SiteId  
   
 DELETE FROM NewsCategories WHERE SiteID = @SiteId  
   
 DELETE FROM SiteAdvertiserFilter WHERE SiteID = @SiteId  
   
 DELETE FROM SiteAdvertiserFilter WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WHERE SiteID = @SiteId)  
  
 DELETE FROM SiteArea WHERE SiteID = @SiteId  
  
 DELETE FROM SiteCountries WHERE SiteID = @SiteId  
   
 DELETE FROM SiteLanguages WHERE SiteID = @SiteId  
   
 DELETE FROM SiteLocation WHERE SiteID = @SiteId  
   
 DELETE FROM SiteProfession WHERE SiteID = @SiteId  
   
 DELETE FROM SiteResources WHERE SiteID = @SiteId  
  
 DELETE FROM SiteRoles WHERE SiteID = @SiteId  
  
 DELETE FROM SiteSalary WHERE SiteID = @SiteId  
   
 DELETE FROM SiteSalaryType WHERE SiteID = @SiteId  
  
 DELETE FROM SiteWorkType WHERE SiteID = @SiteId  
   
 DELETE FROM WidgetContainers WHERE SiteID = @SiteId  
    
 DELETE FROM Files WHERE SiteID = @SiteId  
  
 DELETE FROM Files WHERE FolderID IN (SELECT FolderID FROM Folders WHERE SiteID = @SiteId)  
  
 DELETE FROM Folders WHERE SiteID = @SiteId  
  
 DELETE FROM DynamicPages  WHERE SiteID = @SiteId  
  
 DELETE FROM DynamicPageWebPartTemplatesLink WHERE DynamicPageWebPartTemplateID IN (SELECT DynamicPageWebPartTemplateID FROM DynamicPageWebPartTemplates WITH (NOLOCK) WHERE SiteId = @SiteId)  
  
 DELETE FROM DynamicPageWebPartTemplates WHERE SiteID = @SiteId  
  
 DELETE FROM SiteWebParts WHERE SiteID = @SiteId  
  
 DELETE FROM Members WHERE SiteID = @SiteId  
   
 DELETE FROM AdvertiserUsers  
 WHERE AdvertiserID IN (SELECT AdvertiserID FROM Advertisers WITH (NOLOCK) WHERE SiteID = @SiteId)  
   
 DELETE FROM  Advertisers WHERE SiteID = @SiteId  
  
 DELETE FROM EmailTemplates WHERE SiteID = @SiteId  
   
 UPDATE Sites SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE AdvertiserUsers SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE Advertisers SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE DynamicPageWebPartTemplates SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE GlobalSettings SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE Files SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE News SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE EmailTemplates SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE NewsCategories SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE JobTemplates SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE DefaultResources SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE SiteResources SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE JobItemsType SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE AvailableStatus SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE DynamicPages SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
 UPDATE Educations SET LastModifiedBy = 1 WHERE LastModifiedBy IN (SELECT AdminUserID FROM AdminUsers WHERE SiteID = @SiteId)  
  
 DELETE FROM AdminUsers  
 WHERE SiteID = @SiteId  
   
 DELETE FROM [dbo].[AvailableStatus]  
 WHERE [SiteID] = @SiteId  
  
 DELETE FROM [dbo].[Educations]  
 WHERE [SiteID] = @SiteId  
  
 DELETE FROM [dbo].[Sites]  
 WHERE [SiteID] = @SiteId  
  
 COMMIT TRAN @TransactionName  
END TRY  
BEGIN CATCH  
 SELECT ERROR_MESSAGE() AS ErrorMessage  
 ROLLBACK TRAN @TransactionName  
END CATCH  
  
   
END
GO
/****** Object:  StoredProcedure [dbo].[Sites_Copy]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sites_Copy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sites_Copy]
GO

CREATE PROCEDURE [dbo].[Sites_Copy]                          
(                          
 @SiteID INT,                          
 @SiteName VARCHAR(255),                          
 @SiteUrl VARCHAR(255),                          
 @SiteDescription VARCHAR(255),                          
 @FtpFolderLocation VARCHAR(255),                          
 @CopyGlobalSettings BIT,                          
 @CopyJobTemplates BIT,                          
 @CopySiteLocation BIT,                          
 @CopyProfessionRoles BIT,                          
 @UseCustomProfessionRole BIT,                 
 @CopySalaryTypes BIT,                          
 @CopyWorkTypes BIT,                          
 @CopyEducation BIT,                          
 @CopyAvailableStatus BIT,                          
 @CopyWebParts BIT,                          
 @CopyWidgets BIT,                          
 @CopyEmailTemplates BIT,                          
 @SelectedLanguages VARCHAR(255),                          
 @SelectedDynamicPages VARCHAR(MAX),                          
 @SelectedFiles VARCHAR(MAX),                          
 @LastModifiedBy INT                          
)                          
AS                     
--DECLARE @TempFix AS BIT = @UseCustomProfessionRole                
--SET @UseCustomProfessionRole = @CopySalaryTypes                
--SET @CopySalaryTypes = @TempFix                
                     
 BEGIN TRY                          
  BEGIN TRANSACTION SITECOPYTRANSACTION                          
                            
   DECLARE @NewSiteID INT                          
                             
   INSERT INTO Sites(SiteName, SiteUrl, SiteDescription, MobileEnabled, MobileUrl, LastModified, LastModifiedBy, Live)                          
   VALUES (@SiteName, @SiteUrl, @SiteDescription, 0, 'm.'+ @SiteUrl, GETDATE(), @LastModifiedBy, 0)                          
                                 
      SET @NewSiteID = SCOPE_IDENTITY()                          
                                
      IF (@CopyGlobalSettings = 1)                          
      BEGIN                          
  INSERT INTO GlobalSettings([SiteID],[DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]                          
    ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]                          
    ,[LastModifiedBy],[LastModified],[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]                          
    ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton],[UseAdvertiserFilter],[MerchantID],[ShowTwitterButton]                          
    ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol],[FTPFolderLocation],[MetaTags],[UseCustomProfessionRole],[GenerateJobXML],[WWWRedirect]        
 ,[IsPrivateSite],[PrivateRedirectUrl],[EnableJobCustomQuestionnaire],[JobApplicationTypeID],[JobScreeningProcess],[AdvertiserApprovalProcess],[SiteType],[EnableSSL],[GST]        
 ,[GSTLabel],[NumberOfPremiumJobs],[PremiumJobDays],[DisplayPremiumJobsOnResults],[JobExpiryNotification],[CurrencyID], [DefaultCountryID], [DefaultEmailLanguageId]      
 )                          
  SELECT       @NewSiteID,[DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]                    
    ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]                          
    ,@LastModifiedBy AS LastModifiedBy, GETDATE() AS [LastModified] ,[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]                          
    ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton], 0,[MerchantID],[ShowTwitterButton]                          
    ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol],@FtpFolderLocation,[MetaTags],@UseCustomProfessionRole,[GenerateJobXML],[WWWRedirect]        
 ,[IsPrivateSite],[PrivateRedirectUrl],[EnableJobCustomQuestionnaire],[JobApplicationTypeID],[JobScreeningProcess],[AdvertiserApprovalProcess],[SiteType],[EnableSSL],[GST]        
 ,[GSTLabel],[NumberOfPremiumJobs],[PremiumJobDays],[DisplayPremiumJobsOnResults],[JobExpiryNotification],[CurrencyID], [DefaultCountryID], [DefaultEmailLanguageId]       
  FROM [GlobalSettings] (NOLOCK)              
  WHERE SiteID = @SiteID                          
                        
  INSERT INTO JobItemsType (SiteID,JobItemTypeParentID,JobItemTypeDescription,LastModifiedBy,LastModified,TotalAmount,DaysActive,Sequence,Valid,DiscountAmount,TotalNumberOfJobs,ShortDescription)        
  SELECT @NewSiteID,JobItemTypeParentID,JobItemTypeDescription,LastModifiedBy,LastModified,TotalAmount,DaysActive,Sequence,Valid,DiscountAmount,TotalNumberOfJobs,ShortDescription        
  FROM JobItemsType WHERE SiteID = @SiteID AND (JobItemTypeParentID IN (1, 2, 3) OR Valid = 1)        
        
  IF (@UseCustomProfessionRole = 1)                    
  BEGIN                    
   UPDATE GlobalSettings SET PrivateJobs = 1 WHERE SiteID = @NewSiteID                    
  END                    
     END                          
                          
     IF (@CopyJobTemplates = 1)                          
     BEGIN                          
    INSERT INTO [JobTemplates]                          
      ([SiteID], [JobTemplateDescription],[JobTemplateHTML],[GlobalTemplate],[LastModifiedBy],[LastModified], [JobTemplateLogo])                          
    SELECT @NewSiteID, [JobTemplateDescription],[JobTemplateHTML],[GlobalTemplate],@LastModifiedBy AS LastModifiedBy, GETDATE() AS [LastModified], [JobTemplateLogo]             
    FROM JobTemplates (NOLOCK)                           
    WHERE SiteID = @SiteID                          
     END                          
                               
     IF (@CopySiteLocation = 1)                          
     BEGIN                          
    INSERT INTO [SiteLocation](SiteID, LocationID, SiteLocationName, Valid, SiteLocationFriendlyUrl)                          
    SELECT @NewSiteID, LocationID, SiteLocationName, Valid, SiteLocationFriendlyUrl                          
    FROM SiteLocation (NOLOCK)                          
    WHERE SiteID = @SiteID                          
                              
    INSERT INTO [SiteArea](SiteID, SiteAreaName, AreaID, Valid)                          
    SELECT @NewSiteID, SiteAreaName, AreaID, Valid                          
    FROM SiteArea (NOLOCK)                          
    WHERE SiteID = @SiteID                           
                              
    INSERT INTO [SiteCountries](SiteID, CountryID, SiteCountryName, SiteCountryFriendlyUrl)                          
    SELECT @NewSiteID, CountryID, SiteCountryName, SiteCountryFriendlyUrl                          
    FROM SiteCountries (NOLOCK)                          
    WHERE SiteID = @SiteID                          
     END                          
                               
     IF (@CopyProfessionRoles = 1)                          
     BEGIN                          
    INSERT INTO SiteProfession([SiteID],[ProfessionID] ,[SiteProfessionName] ,[Valid] ,[MetaTitle]                       
           ,[MetaKeywords] ,[MetaDescription] ,[Sequence], [SiteProfessionFriendlyUrl], [TotalJobs])                          
    SELECT @NewSiteID,[ProfessionID] ,[SiteProfessionName] ,[Valid] ,[MetaTitle]                           
           ,[MetaKeywords] ,[MetaDescription] ,[Sequence], [SiteProfessionFriendlyUrl], [TotalJobs]                          
    FROM [SiteProfession] (NOLOCK)                          
    WHERE SiteID = @SiteID                           
                               
    INSERT INTO [SiteRoles]([SiteID],[RoleID] ,[SiteRoleName] ,[Valid] ,[MetaTitle] ,[MetaKeywords]                           
          ,[MetaDescription] ,[Sequence], [SiteRoleFriendlyUrl], [TotalJobs])                          
    SELECT  @NewSiteID,[RoleID] ,[SiteRoleName] ,[Valid] ,[MetaTitle] ,[MetaKeywords] ,                          
       [MetaDescription] ,[Sequence], [SiteRoleFriendlyUrl], [TotalJobs]                          
    FROM SiteRoles (NOLOCK)                          
        WHERE SiteID = @SiteID                          
                           
     END                          
                               
     IF (@CopySalaryTypes = 1)                          
     BEGIN                          
                   
 INSERT INTO SiteCurrencies(SiteID, CurrencyID)                          
    SELECT @NewSiteID, CurrencyID                        
    FROM SiteCurrencies (NOLOCK)                          
    WHERE SiteID = @SiteID                          
                        
    INSERT INTO SiteSalaryType(SiteID, SalaryTypeID, SalaryTypeName, Sequence, Valid)                          
    SELECT @NewSiteID, SalaryTypeID, SalaryTypeName, Sequence, Valid                          
    FROM SiteSalaryType (NOLOCK)                          
    WHERE SiteID = @SiteID                          
                              
     END                          
                            
     IF (@CopyWorkTypes = 1)                          
     BEGIN                          
    INSERT INTO SiteWorkType(SiteID, SiteWorkTypeName, WorkTypeID, Sequence, Valid)                          
    SELECT @NewSiteID, SiteWorkTypeName, WorkTypeID, Sequence, Valid                          
    FROM SiteWorkType (NOLOCK)                          
    WHERE SiteID = @SiteID                          
     END                          
                               
     IF (@CopyEducation = 1)                          
     BEGIN                          
    INSERT INTO Educations(SiteID, EducationParentID, EducationName, GlobalTemplate, LastModifiedBy, LastModified, Sequence)                          
    SELECT @NewSiteID, EducationParentID, EducationName, GlobalTemplate, @LastModifiedBy, GETDATE(), Sequence                          
    FROM Educations (NOLOCK)                          
    WHERE SiteID = @SiteID                           
     END                          
                               
     IF (@CopyAvailableStatus = 1)                          
     BEGIN               
    INSERT INTO AvailableStatus(SiteID, AvailableStatusParentID, AvailableStatusName, GlobalTemplate, LastModified,LastModifiedBy, Sequence)                          
    SELECT @NewSiteID, AvailableStatusParentID, AvailableStatusName, GlobalTemplate, GETDATE(), @LastModifiedBy, Sequence                          
FROM AvailableStatus (NOLOCK)                          
    WHERE SiteID = @SiteID AND GlobalTemplate = 0                      
     END                          
                               
                               
     IF (@CopyWidgets = 1)                          
     BEGIN                          
    INSERT INTO [WidgetContainers]([SiteID], [LanguageID], [WidgetName], [WidgetDomain], [WidgetContainerClass]                          
              ,[WidgetContainerHeaderClass], [WidgetItemClass], [WidgetJobLinkCSS], [WidgetItemLinkImageID]                          
              ,[Valid], [ShowJobs], [ShowCompanies], [ShowSite],[ShowPeople]                          
              ,[JobHtml], [CompanyHtml],[SiteHtml], [PeopleHtml],[Javascript],[SearchCSS]                          
              ,[DefaultProfessionID],[DefaultCountryID],[DefaultLocationID],[Width],[Height],[OnAdvancedSearch])                          
    SELECT @NewSiteID, [LanguageID], [WidgetName], [WidgetDomain], [WidgetContainerClass]                          
              ,[WidgetContainerHeaderClass], [WidgetItemClass], [WidgetJobLinkCSS], [WidgetID]                          
      ,[Valid], [ShowJobs], [ShowCompanies], [ShowSite],[ShowPeople]                          
              ,[JobHtml], [CompanyHtml],[SiteHtml], [PeopleHtml],[Javascript],[SearchCSS]                          
    ,[DefaultProfessionID],[DefaultCountryID],[DefaultLocationID],[Width],[Height],[OnAdvancedSearch]                          
    FROM WidgetContainers (NOLOCK)                          
    WHERE SiteID = @SiteID AND LanguageID IN (SELECT id FROM ParseIntCSV(@SelectedLanguages))                          
                          
                        
     END                          
                               
     IF (@CopyEmailTemplates = 1)                          
     BEGIN                          
    INSERT INTO EmailTemplates([SiteID],[EmailTemplateParentID]                          
            ,[EmailCode],[EmailDescription],[EmailSubject]                          
            ,[EmailBodyText],[EmailBodyHTML],[EmailFields]                          
            ,[EmailAddressName],[EmailAddressFrom],[EmailAddressCC]                          
            ,[EmailAddressBCC],[GlobalTemplate],[LastModifiedBy],[LastModified], [EmailAddressTo], [EmailAddressToName], [EmailAddressToMandatory], [LanguageID])                          
    SELECT @NewSiteID,[EmailTemplateParentID]                          
            ,[EmailCode],[EmailDescription],[EmailSubject]                          
            ,[EmailBodyText],[EmailBodyHTML],[EmailFields]                          
            ,[EmailAddressName],[EmailAddressFrom],[EmailAddressCC]                          
            ,[EmailAddressBCC],[GlobalTemplate],[LastModifiedBy],[LastModified], [EmailAddressTo], [EmailAddressToName], [EmailAddressToMandatory], [LanguageID]                          
    FROM EmailTemplates (NOLOCK)                          
    WHERE SiteID = @SiteID AND GlobalTemplate = 0                          
     END                          
                          
   IF (@CopyWebParts = 1)                          
   BEGIN                          
    -- INSERT Site Web Parts                          
                          
    INSERT INTO SiteWebParts([SiteID],                          
          [SiteWebPartName],[SiteWebPartTypeID],                          
          [SiteWebPartHTML],[SourceID])                          
    SELECT @NewSiteID,[SiteWebPartName],[SiteWebPartTypeID],                          
          [SiteWebPartHTML],[SiteWebPartID]                          
    FROM SiteWebParts (NOLOCK)                          
    WHERE SiteID = @SiteID AND SiteWebPartID IN (                          
    SELECT swp.SiteWebPartID FROM SiteWebParts swp                           
    INNER JOIN DynamicPageWebPartTemplatesLink dpwptl ON swp.SiteWebPartID = dpwptl.SiteWebPartID                          
    INNER JOIN DynamicPages dp ON dpwptl.DynamicPageWebPartTemplateID = dp.DynamicPageWebPartTemplateID                          
    WHERE dp.DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages)) AND  dp.DynamicPageWebPartTemplateID IS NOT NULL)                          
                             
    -- INSERT Web Part Template                          
    INSERT INTO DynamicPageWebPartTemplates([DynamicPageWebPartName],[SiteID]                          
              ,[LastModified],[LastModifiedBy],[SourceID])                          
    SELECT [DynamicPageWebPartName],@NewSiteID,[LastModified],[LastModifiedBy],[DynamicPageWebPartTemplateID]                          
    FROM DynamicPageWebPartTemplates                          
    WHERE SiteID = @SiteID                          
    AND DynamicPageWebPartTemplateID IN (SELECT DynamicPageWebPartTemplateID                           
             FROM DynamicPages (NOLOCK)                           
             WHERE DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages))                           
             AND DynamicPageWebPartTemplateID IS NOT NULL)                           
                  
    -- INSERT Web Part Template Link                          
    INSERT INTO DynamicPageWebPartTemplatesLink ([DynamicPageWebPartTemplateID], [SiteWebPartID], [Sequence])          
    SELECT (SELECT DynamicPageWebPartTemplateID                           
      FROM DynamicPageWebPartTemplates wpt                           
      WHERE wpt.SiteId = @NewSiteID AND wpt.SourceID = wptl.DynamicPageWebPartTemplateID),                           
      (SELECT SiteWebPartID FROM SiteWebParts swp WHERE swp.SiteID = @NewSiteID AND swp.SourceID = wptl.SiteWebPartID), Sequence                          
    FROM DynamicPageWebPartTemplatesLink wptl                          
    WHERE wptl.DynamicPageWebPartTemplateID IN (SELECT DynamicPageWebPartTemplateID     
             FROM DynamicPages (NOLOCK)                           
             WHERE DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages))                           
             AND DynamicPageWebPartTemplateID IS NOT NULL)                           
    -- wptl.DynamicPageWebPartTemplateID IN (SELECT DynamicPageWebPartTemplateID FROM DynamicPageWebPartTemplates WHERE SiteId = @SiteID)                          
                          
   END                          
          
   INSERT INTO Folders ([ParentFolderID],[SiteID],[FolderName], [SourceID])                          
   SELECT [ParentFolderID], @NewSiteID,[FolderName], [FolderID]                          
   FROM Folders (NOLOCK) WHERE SiteID = @SiteID AND FolderID IN (SELECT FolderID FROM Files (NOLOCK) WHERE FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles)))                          
                          
   INSERT INTO Files ([SiteID],[FolderID],[FileName],[FileSystemName],[FileTypeID],[LastModified],[LastModifiedBy],[SourceID])                      
   SELECT @NewSiteID,[FolderID],[FileName],[FileSystemName],[FileTypeID],[LastModified],[LastModifiedBy],FileID                          
   FROM Files WHERE SiteID = @SiteID AND FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles) )                          
                          
   UPDATE Files SET Files.FolderID = Folders.FolderID                          
   FROM Folders WHERE Folders.SourceID = Files.FolderID AND Files.SiteID = @NewSiteID AND Folders.SiteID = @NewSiteID                          
                          
   INSERT INTO SiteLanguages (SiteID, LanguageID, SiteLanguageName)                          
   SELECT @NewSiteID, tbl.id, SiteLanguageName                           
   FROM ParseIntCSV(@SelectedLanguages) tbl INNER JOIN SiteLanguages sl                           
   ON tbl.id = sl.LanguageID AND sl.SiteID = @SiteID                          
                          
   IF (@SelectedLanguages <> '' AND @SelectedDynamicPages <> '')                          
   BEGIN                          
    INSERT INTO DynamicPages (SiteID,LanguageID,ParentDynamicPageID,PageName,                          
       PageTitle,PageContent,DynamicPageWebPartTemplateID,HyperLink,                          
       Valid,OpenInNewWindow,Sequence,FullScreen,OnTopNav,OnLeftNav,                          
       OnBottomNav,OnSiteMap,Searchable,MetaKeywords,MetaDescription,                          
       PageFriendlyName,LastModified,LastModifiedBy,SearchField,SourceID,Secured,CustomUrl)                          
    SELECT @NewSiteID,LanguageID,ParentDynamicPageID,PageName,                          
       PageTitle,PageContent,wpt.DynamicPageWebPartTemplateID,HyperLink,                          
       Valid,OpenInNewWindow,Sequence,FullScreen,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnTopNav END, CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnLeftNav END,                          
       OnBottomNav,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnSiteMap END,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE Searchable END,MetaKeywords,MetaDescription,                          
       PageFriendlyName,dp.LastModified,dp.LastModifiedBy,CASE WHEN PageName LIKE 'SystemPage%' THEN '' ELSE SearchField END,DynamicPageID,Secured,CustomUrl                  
    FROM DynamicPages dp INNER JOIN DynamicPageWebPartTemplates wpt                   
    ON dp.DynamicPageWebPartTemplateID = wpt.SourceID AND wpt.SiteID = @NewSiteID                          
    WHERE dp.SiteID = @SiteID AND dp.DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages))                          
                          
    INSERT INTO DynamicPageFiles (SiteID, PageName, FileID)                          
    SELECT @NewSiteID, PageName, f.FileID                           
    FROM DynamicPageFiles dpf INNER JOIN Files f                           
    ON dpf.FileID = f.SourceID AND dpf.SiteID = @NewSiteID                          
    WHERE dpf.SiteID = @SiteID AND dpf.FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles))                          
                              
   END                          
             
 INSERT INTO MemberStatus(SiteID,            
  MemberStatusName,            
  LastModifiedBy,            
  LastModified,            
  Sequence,            
  Valid)            
    SELECT @NewSiteID,MemberStatusName,            
  LastModifiedBy,            
  LastModified,            
  Sequence,            
  Valid            
 FROM MemberStatus            
    WHERE SiteID = @SiteID            
            
            
   UPDATE DynamicPages SET DynamicPages.ParentDynamicPageID = DP2.DynamicPageID                  
   FROM DynamicPages                          
   INNER JOIN DynamicPages DP2 ON DynamicPages.ParentDynamicPageID = DP2.SourceID                          
   WHERE DynamicPages.ParentDynamicPageID > 0                          
   AND DynamicPages.SiteID = @NewSiteID                          
   AND DP2.SiteID = @NewSiteID                          
                                 
 --Return the new object                          
 SELECT SiteID, SiteName, SiteUrl, SiteDescription, LastModified, LastModifiedBy                          
 FROM Sites (NOLOCK)                          
 WHERE SiteID = @NewSiteID                          
 
COMMIT TRANSACTION SITECOPYTRANSACTION   

-- UPDATE Dynamic Pages Widget ID
DECLARE @fromwidgetid INT
DECLARE @widgetid INT

DECLARE @strfromwidget NVARCHAR(MAX)
DECLARE @strtowidget NVARCHAR(MAX)

DECLARE db_cursor CURSOR FOR  
SELECT WidgetItemLinkImageID, WidgetID
FROM WidgetContainers WHERE SiteID = @NewSiteID

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @fromwidgetid, @widgetid   

WHILE @@FETCH_STATUS = 0   
BEGIN   

	SET @strfromwidget = N'{widget-' + CAST(@fromwidgetid as varchar(25)) + N'}'
	SET @strtowidget = N'{widget-' + CAST(@widgetid as varchar(25)) + N'}'

    UPDATE DynamicPages SET PageContent = CAST(REPLACE(CAST([PageContent] as NVarchar(MAX)),@strfromwidget, @strtowidget) AS NText) WHERE SiteID = @NewSiteID AND PageContent IS NOT NULL AND CONVERT(NVARCHAR(MAX),PageContent) <> ''
    UPDATE SiteWebParts SET SiteWebPartHTML = CAST(REPLACE(CAST([SiteWebPartHTML] as NVarchar(MAX)),@strfromwidget, @strtowidget) AS NText) WHERE SiteID = @NewSiteID AND SiteWebPartHTML IS NOT NULL AND CONVERT(NVARCHAR(MAX),SiteWebPartHTML) <> ''

	FETCH NEXT FROM db_cursor INTO @fromwidgetid, @widgetid    
END   

CLOSE db_cursor   
DEALLOCATE db_cursor

                            
 END TRY                          
  BEGIN CATCH                          
   IF @@TRANCOUNT > 0                          
    ROLLBACK TRANSACTION SITECOPYTRANSACTION --RollBack in case of Error                          
                           
    -- Raise an error with the details of the exception                          
    DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT                          
    SELECT @ErrMsg = ERROR_MESSAGE(),                          
    @ErrSeverity = ERROR_SEVERITY()                          
                           
    RAISERROR(@ErrMsg, @ErrSeverity, 1)                          
                           
  END CATCH
GO
/****** Object:  StoredProcedure [dbo].[ViewJobsArchive_GetByID]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobsArchive_GetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobsArchive_GetByID]
GO

CREATE PROCEDURE [dbo].[ViewJobsArchive_GetByID]    
 @JobID INT,        
 @SiteID INT            
AS            
SELECT JobsArchive.[JobID]            
      ,JobsArchive.[SiteID]            
      ,SiteWorkType.[WorkTypeID]          
      ,JobsArchive.[JobName]            
      ,JobsArchive.[Description]            
      ,JobsArchive.[FullDescription]            
      ,JobsArchive.[WebServiceProcessed]            
      ,JobsArchive.[ApplicationEmailAddress]            
      ,JobsArchive.[RefNo]            
      ,JobsArchive.[Visible]            
      ,JobsArchive.[DatePosted]            
      ,JobsArchive.[ExpiryDate]            
      ,JobsArchive.[Expired]            
      ,JobsArchive.[JobItemPrice]            
      ,JobsArchive.[Billed]            
      ,JobsArchive.[LastModified]            
      ,JobsArchive.[ShowSalaryDetails]    
      ,JobsArchive.[ShowSalaryRange]    
      ,JobsArchive.[SalaryText]            
      ,JobsArchive.[AdvertiserID]            
      ,JobsArchive.[LastModifiedByAdvertiserUserId]            
      ,JobsArchive.[LastModifiedByAdminUserId]            
      ,JobsArchive.[JobItemTypeID]            
      ,JobsArchive.[ApplicationMethod]            
      ,JobsArchive.[ApplicationUrl]            
      ,JobsArchive.[UploadMethod]            
      ,JobsArchive.[Tags]            
      ,JobsArchive.[JobTemplateID]            
      ,JobsArchive.[SearchField]            
      ,JobsArchive.[AdvertiserJobTemplateLogoID]            
      ,JobsArchive.[CompanyName]            
      ,JobsArchive.[HashValue]            
      ,JobsArchive.[RequireLogonForExternalApplications]            
      ,JobsArchive.[ShowLocationDetails]            
      ,JobsArchive.[PublicTransport]            
      ,JobsArchive.[Address]            
      ,JobsArchive.[ContactDetails]            
      ,JobsArchive.[JobContactPhone]            
      ,JobsArchive.[JobContactName]            
      ,JobsArchive.[QualificationsRecognised]            
      ,JobsArchive.[ResidentOnly]            
      ,JobsArchive.[DocumentLink]            
      ,JobsArchive.[BulletPoint1]            
      ,JobsArchive.[BulletPoint2]            
      ,JobsArchive.[BulletPoint3]            
      ,JobsArchive.[HotJob]            
      ,Advertisers.[CompanyName] AS AdvertiserCompanyName           
      ,Advertisers.[BusinessNumber]            
      ,Advertisers.[StreetAddress1]            
      ,Advertisers.[StreetAddress2]            
      ,Advertisers.[WebAddress]            
      ,Advertisers.[Profile]            
      ,Advertisers.[RequireLogonForExternalApplication]            
      ,Advertisers.[AdvertiserLogo]            
      ,Advertisers.[AdvertiserLogoUrl]
      ,SiteWorkType.[SiteWorkTypeName]            
      ,Currencies.[CurrencySymbol]            
      ,JobsArchive.[SalaryUpperBand]            
      ,JobsArchive.[SalaryLowerBand]    
      ,JobsArchive.[SalaryTypeId]            
      ,JobTemplates.[JobTemplateHTML]            
      ,SiteSalaryType.[SalaryTypeName]            
      ,SiteArea.[SiteAreaName]            
      ,SiteLocation.[SiteLocationName]            
      ,SiteRoles.[SiteRoleName]            
      ,SiteProfession.[SiteProfessionName]          
   ,'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(JobsArchive.JobFriendlyName, '') as 'JobFriendlyName'  
   ,Roles.[ProfessionID]    
   ,Roles.[RoleID]   
   
 ,Area.LocationID 
	 ,[JobArea].AreaID  
   ,CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay  
  
  FROM [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter        
  
  INNER JOIN [dbo].[Advertisers] Advertisers (NOLOCK)                
 ON AdvertiserFilter.AdvertiserID = Advertisers.AdvertiserID                
  
 INNER JOIN [dbo].[JobsArchive] JobsArchive (NOLOCK)  
 ON JobsArchive.AdvertiserID = AdvertiserFilter.AdvertiserId  
  
 INNER JOIN [dbo].[SiteWorkType] SiteWorkType (NOLOCK)                
 ON JobsArchive.WorkTypeID = [SiteWorkType].WorkTypeID  
 AND SiteWorkType.SiteID = @SiteID  
    
 INNER JOIN [dbo].[SiteCurrencies] SiteCurrencies (NOLOCK)    
 ON [SiteCurrencies].CurrencyID = JobsArchive.CurrencyID    
 AND [SiteCurrencies].SiteID = @SiteID  
    
 INNER JOIN [dbo].[Currencies] Currencies (NOLOCK)    
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID    
         
 INNER JOIN [dbo].[SiteSalaryType] SiteSalaryType (NOLOCK)                
 ON [SiteSalaryType].SalaryTypeID = JobsArchive.[SalaryTypeID]               
 AND [SiteSalaryType].SiteID = @SiteID  
          
 INNER JOIN [dbo].[JobTemplates] JobTemplates (NOLOCK)                
 ON [JobTemplates].[JobTemplateID] = JobsArchive.[JobTemplateID]  
          
 INNER JOIN [dbo].[JobArea] JobArea (NOLOCK)                
 ON [JobArea].[JobArchiveID] = JobsArchive.[JobID]                
   
 INNER JOIN [dbo].[SiteArea] SiteArea (NOLOCK)             
 ON [SiteArea].AreaID = [JobArea].AreaID              
  AND SiteArea.Siteid = @SiteID  
   
 INNER JOIN [dbo].[Area] Area (NOLOCK)                
 ON [Area].AreaID = [SiteArea].[AreaID]                
   
 INNER JOIN [dbo].[SiteLocation] SiteLocation (NOLOCK)                
 ON [SiteLocation].LocationID = Area.LocationID              
 AND SiteLocation.Siteid = @SiteID  
          
 INNER JOIN [dbo].[JobRoles] JobRoles (NOLOCK)                
 ON [JobRoles].[JobArchiveID] = JobsArchive.[JobID]                
   
 INNER JOIN [dbo].[SiteRoles] SiteRoles (NOLOCK)                
 ON [SiteRoles].[RoleID] = [JobRoles].[RoleID]             
 AND SiteRoles.SiteID = @SiteID  
   
 INNER JOIN [dbo].[Roles] Roles (NOLOCK)                
 ON [Roles].RoleID = [SiteRoles].RoleID                
   
 INNER JOIN [dbo].[SiteProfession] SiteProfession (NOLOCK)                
 ON [SiteProfession].ProfessionID = [Roles].ProfessionID              
 AND SiteProfession.SiteID = @SiteID  
  
 WHERE JobsArchive.[JobID] = @JobID
GO
/****** Object:  StoredProcedure [dbo].[ViewJobs_GetByID]    Script Date: 11/04/2016 10:07:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobs_GetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobs_GetByID]
GO

CREATE PROCEDURE [dbo].[ViewJobs_GetByID]  
 @JobID INT,    
 @SiteID INT        
AS        
SELECT Jobs.[JobID]        
      ,Jobs.[SiteID]        
      ,SiteWorkType.[WorkTypeID]        
      ,Jobs.[JobName]        
      ,Jobs.[Description]        
      ,Jobs.[FullDescription]        
      ,Jobs.[WebServiceProcessed]        
      ,Jobs.[ApplicationEmailAddress]        
      ,Jobs.[RefNo]        
      ,Jobs.[Visible]        
      ,Jobs.[DatePosted]        
      ,Jobs.[ExpiryDate]        
      ,Jobs.[Expired]        
      ,Jobs.[JobItemPrice]        
      ,Jobs.[Billed]        
      ,Jobs.[LastModified]        
      ,Jobs.[ShowSalaryDetails]    
      ,Jobs.[ShowSalaryRange]      
      ,Jobs.[SalaryText]        
      ,Jobs.[AdvertiserID]        
      ,Jobs.[LastModifiedByAdvertiserUserId]        
      ,Jobs.[LastModifiedByAdminUserId]        
      ,Jobs.[JobItemTypeID]        
      ,Jobs.[ApplicationMethod]        
      ,Jobs.[ApplicationUrl]        
      ,Jobs.[UploadMethod]        
      ,Jobs.[Tags]        
      ,Jobs.[JobTemplateID]        
      ,Jobs.[SearchField]        
      ,Jobs.[AdvertiserJobTemplateLogoID]        
      ,Jobs.[CompanyName]        
      ,Jobs.[HashValue]        
      ,Jobs.[RequireLogonForExternalApplications]        
      ,Jobs.[ShowLocationDetails]        
      ,Jobs.[PublicTransport]        
      ,Jobs.[Address]        
      ,Jobs.[ContactDetails]        
      ,Jobs.[JobContactPhone]        
      ,Jobs.[JobContactName]        
      ,Jobs.[QualificationsRecognised]        
      ,Jobs.[ResidentOnly]        
      ,Jobs.[DocumentLink]        
      ,Jobs.[BulletPoint1]        
      ,Jobs.[BulletPoint2]        
      ,Jobs.[BulletPoint3]        
      ,Jobs.[HotJob]        
      ,Advertisers.[CompanyName] AS AdvertiserCompanyName        
      ,Advertisers.[BusinessNumber]        
      ,Advertisers.[StreetAddress1]        
      ,Advertisers.[StreetAddress2]        
      ,Advertisers.[WebAddress]        
      ,Advertisers.[Profile]        
      ,Advertisers.[RequireLogonForExternalApplication]        
      ,Advertisers.[AdvertiserLogo]        
      ,Advertisers.[AdvertiserLogoUrl]        
      ,SiteWorkType.[SiteWorkTypeName]        
      ,Currencies.[CurrencySymbol]        
      ,Jobs.[SalaryUpperBand]        
      ,Jobs.[SalaryLowerBand]  
      ,Jobs.[SalaryTypeId]        
      ,JobTemplates.[JobTemplateHTML]        
      ,SiteSalaryType.[SalaryTypeName]        
      ,SiteArea.[SiteAreaName]        
      ,SiteLocation.[SiteLocationName]        
      ,SiteRoles.[SiteRoleName] 
	  ,SiteRoles.[CanonicalUrl] AS 'SiteRoleCanonicalUrl'
       
      ,SiteProfession.[SiteProfessionName]  
	  ,SiteProfession.[CanonicalUrl] AS 'SiteProfessionCanonicalUrl'
    
      ,'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'  
	  ,Roles.[ProfessionID]  
      ,Roles.[RoleID]  
	 ,Area.LocationID 
	 ,[JobArea].AreaID 
      ,CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay
      
  FROM [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter    
  
 INNER JOIN [dbo].[Advertisers] Advertisers (NOLOCK)              
 ON AdvertiserFilter.AdvertiserID = Advertisers.AdvertiserID              

 INNER JOIN [dbo].[Jobs] Jobs (NOLOCK)
 ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserId

 INNER JOIN [dbo].[SiteWorkType] SiteWorkType (NOLOCK)              
 ON Jobs.WorkTypeID = [SiteWorkType].WorkTypeID
 AND SiteWorkType.SiteID = @SiteID
  
 INNER JOIN [dbo].[SiteCurrencies] SiteCurrencies (NOLOCK)  
 ON [SiteCurrencies].CurrencyID = Jobs.CurrencyID  
 AND [SiteCurrencies].SiteID = @SiteID
  
 INNER JOIN [dbo].[Currencies] Currencies (NOLOCK)  
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID  
       
 INNER JOIN [dbo].[SiteSalaryType] SiteSalaryType (NOLOCK)              
 ON [SiteSalaryType].SalaryTypeID = [Jobs].[SalaryTypeID]             
 AND [SiteSalaryType].SiteID = @SiteID
        
 INNER JOIN [dbo].[JobTemplates] JobTemplates (NOLOCK)              
 ON [JobTemplates].[JobTemplateID] = [Jobs].[JobTemplateID]
        
 INNER JOIN [dbo].[JobArea] JobArea (NOLOCK)              
 ON [JobArea].[JobID] = [Jobs].[JobID]              
 
 INNER JOIN [dbo].[SiteArea] SiteArea (NOLOCK)           
 ON [SiteArea].AreaID = [JobArea].AreaID            
  AND SiteArea.Siteid = @SiteID
 
 INNER JOIN [dbo].[Area] Area (NOLOCK)              
 ON [Area].AreaID = [SiteArea].[AreaID]              
 
 INNER JOIN [dbo].[SiteLocation] SiteLocation (NOLOCK)              
 ON [SiteLocation].LocationID = Area.LocationID            
 AND SiteLocation.Siteid = @SiteID
        
 INNER JOIN [dbo].[JobRoles] JobRoles (NOLOCK)              
 ON [JobRoles].[JobID] = [Jobs].[JobID]              
 
 INNER JOIN [dbo].[SiteRoles] SiteRoles (NOLOCK)              
 ON [SiteRoles].[RoleID] = [JobRoles].[RoleID]           
 AND SiteRoles.SiteID = @SiteID
 
 INNER JOIN [dbo].[Roles] Roles (NOLOCK)              
 ON [Roles].RoleID = [SiteRoles].RoleID              
 
 INNER JOIN [dbo].[SiteProfession] SiteProfession (NOLOCK)              
 ON [SiteProfession].ProfessionID = [Roles].ProfessionID            
 AND SiteProfession.SiteID = @SiteID

 WHERE Jobs.[JobID] = @JobID
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobSearch_GetBySearchFilterGoogleMap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterGoogleMap]
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterGoogleMap]                                       
 @Keyword NVARCHAR(2500),                                                   
 @SiteId INT,                                                   
 @AdvertiserId INT = NULL,                                       
 @CurrencyID INT = NULL,                                                   
 @SalaryLowerBand NUMERIC(15,2) = NULL,                                       
 @SalaryUpperBand NUMERIC(15,2) = NULL,                                                   
 @SalaryTypeID INT = NULL,                                       
 @WorkTypeID INT = NULL,                                                   
 @ProfessionID INT = NULL,                                                    
 @RoleID VARCHAR(255) = NULL,                                                  
 @CountryID INT = NULL,                                                   
 @LocationID INT = NULL,                                                   
 @AreaID VARCHAR(255)= NULL,                            
-- @DateFrom DATETIME= NULL,                                                   
-- @PageIndex INT,                                                   
-- @PageSize INT,              
 @OrderBy VARCHAR(200) = NULL,            
 @JobTypeIDs VARCHAR(255) = NULL,        
 @NorthEastLat float = NULL,        
 @NorthEastLng float = NULL,        
 @SouthWestLat float = NULL,        
 @SouthWestLng float = NULL        
AS                                                   
          
/*          
 -- 16th April           
 -- Fix for Advertiser Filter taking lot of time to load the jobs.         
         
 -- 20th April        
 -- Add countryid as parameter          
*/                    
                     
 --SQL Server 2008 FTI Fix                                       
 IF ISNULL(@Keyword,'') = ''                                        
 SET @Keyword = '""'                                       
                          
 -- DECLARE @UseCustomProfessionRole BIT = (SELECT UseCustomProfessionRole FROM GlobalSettings WHERE SiteID = @SiteId)                       
               
 -- Check if the Salary sorting has the Salary type selected if not it goes to default search              
 IF (@OrderBy = 'SalaryHighToLow' OR @OrderBy = 'SalaryLowToHigh')              
 BEGIN               
 IF (ISNULL(@SalaryTypeID,0) = 0)              
  SET @OrderBy = ''              
 END              
            
-- Global settings - Get if Premium jobs needs to be displayed.    -- GOOGLE MAP IGNORE        
/*Declare @DisplayPremiumJobsOnResults BIT            
SELECT @DisplayPremiumJobsOnResults = DisplayPremiumJobsOnResults FROM GlobalSettings (NOLOCK) where SiteID = @SiteId    */        
            
-- Get the valid JOB Types of the Site excluding Premium jobs  - AGAIN show premium only when profession is selected.        
IF (ISNULL(@ProfessionID,0) = 0)         
BEGIN         
 SELECT @JobTypeIDs = COALESCE(@JobTypeIDs + ', ', '') + CAST(JobItemTypeParentID as Varchar)            
 FROM JobItemsType NOLOCK where SiteID = @SiteId AND Valid = 1 AND TotalNumberOfJobs = 1         
 AND JobItemTypeParentID <>3        
END        
ELSE        
BEGIN        
 SELECT @JobTypeIDs = COALESCE(@JobTypeIDs + ', ', '') + CAST(JobItemTypeParentID as Varchar)            
 FROM JobItemsType NOLOCK where SiteID = @SiteId AND Valid = 1 AND TotalNumberOfJobs = 1         
 --AND JobItemTypeParentID <>3    -- GOOGLE MAP IGNORE        
END        
          
DECLARE @tmpJobIdSearch TABLE (JobID INT, RoleId INT, RowNumber INT)              
INSERT INTO @tmpJobIdSearch(JobID, RoleId, RowNumber)          
Select JobId, RoleID, RowNumber FROM           
(          
SELECT                       
 Jobs.JobId,             
 SiteRoles.RoleID,                            
 ROW_NUMBER() OVER (ORDER BY                
       CASE WHEN ISNULL(@OrderBy,'') = '' THEN Jobs.DatePosted  END DESC,              
       CASE WHEN @OrderBy ='Old' THEN Jobs.DatePosted END,              
       CASE WHEN @OrderBy ='ZA' THEN Jobs.JobName  END DESC,              
       CASE WHEN @OrderBy ='AZ' THEN Jobs.JobName  END,              
       CASE WHEN @OrderBy ='SalaryHighToLow' THEN Jobs.SalaryUpperBand END DESC,              
       CASE WHEN @OrderBy ='SalaryLowToHigh' THEN Jobs.SalaryLowerBand  END              
    ) as RowNumber               
 FROM                                           
 [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter          
 INNER JOIN Jobs (NOLOCK)        
 ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                                                
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK)                                                      
 ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK)                                                      
 ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID                                              
 AND SiteSalaryType.SiteID = @SiteID                                         
                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies           
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID                                       
 AND [SiteCurrencies].SiteID = Jobs.SiteID                                       
        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies                                        
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
INNER JOIN WorkType (NOLOCK)                                                      
 ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK)                                                      
 ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID                                                
 AND SiteWorkType.SiteID = @SiteID                                                 
                                          
 -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK)                                                  
 ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)                                                  
 ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                            
 AND ViewSiteAreaLocationCountry.Siteid = @SiteID                                           
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID                               
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK)                                                 
 ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK)                                    
 ON SiteRoles.RoleID = JobRoles.RoleID                                             
 AND SiteRoles.SiteID = @SiteID                                                 
 INNER JOIN Roles (NOLOCK)                                                 
 ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK)                                                 
 ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK)                                                 
 ON SiteProfession.ProfessionID = Profession.ProfessionID                                              
 AND SiteProfession.SiteID = @SiteID                                       
 WHERE                                                  
 Jobs.Expired = 0 AND              
 Jobs.ExpiryDate >= GETDATE() AND                                            
 ((@AdvertiserId is NULL) OR (Jobs.AdvertiserID = @AdvertiserId)) AND                                                 
 ((@CurrencyID IS NULL) OR (Jobs.CurrencyID = @CurrencyID)) AND                                         
 ((@SalaryLowerBand IS NULL) OR (Jobs.SalaryLowerBand >= @SalaryLowerBand)) AND                                
((@SalaryUpperBand IS NULL) OR (Jobs.SalaryUpperBand <= @SalaryUpperBand)) AND                                       
 ((ISNULL(@SalaryTypeID,0) = 0 OR Jobs.SalaryTypeID  = @SalaryTypeID)) AND                     
((ISNULL(@WorkTypeID, 0) = 0) OR (Jobs.WorkTypeID = @WorkTypeID)) AND                                                 
 ((ISNULL(@ProfessionID, 0) = 0) OR (Roles.ProfessionID = @ProfessionID)) AND                    
 ((ISNULL(@RoleID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@RoleID) where id = Roles.RoleID))) AND                                               
 ((ISNULL(@CountryID, '') = '') OR (ViewSiteAreaLocationCountry.CountryID = @CountryID))  AND                                                
 ((ISNULL(@LocationID, '') = '') OR (ViewSiteAreaLocationCountry.LocationID = @LocationID))  AND                                                
 ((ISNULL(@AreaID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@AreaID) where id = ViewSiteAreaLocationCountry.AreaID)))             
  AND (--(ISNULL(@JobTypeIDs, '') = '') OR             
  (Jobs.JobItemTypeID IN (Select id from ParseIntCSV(@JobTypeIDs)))             
  OR (Jobs.JobItemTypeID IS NULL)) -- TODO REMOVE Jobs.JobItemTypeID NULL              
  --OR (@DisplayPremiumJobsOnResults = 1 AND Jobs.JobItemTypeID = 3 AND Jobs.SiteID = @SiteId)    -- GOOGLE MAP IGNORE        
 AND Jobs.DatePosted <= CAST(GETDATE()+1 AS DATE)           
 --AND ((@DateFrom IS NULL) OR Jobs.DatePosted >= @DateFrom)                   -- FOR JOB ALERT - Only send new jobs - Don't REMOVE   -- GOOGLE MAP IGNORE                                   
 AND ((ISNULL(@Keyword,'') = '""') OR CONTAINS(Jobs.[SearchField], @Keyword))                                             
 -- AND ((@UseCustomProfessionRole = 0) OR (@UseCustomProfessionRole = 1 AND Profession.ReferredSiteID = @SiteID))          
         
   --lat > @SouthWestLat AND lat < @NorthEastLat AND lng > @SouthWestLng AND lng < @NorthEastLng        
 AND ((ISNULL(@SouthWestLat, 0) = 0) OR (JobLatitude > @SouthWestLat))         
 AND ((ISNULL(@NorthEastLat, 0) = 0) OR (JobLatitude < @NorthEastLat))         
 AND ((ISNULL(@SouthWestLng, 0) = 0) OR (JobLongitude > @SouthWestLng))         
 AND ((ISNULL(@NorthEastLng, 0) = 0) OR (JobLongitude < @NorthEastLng))         
 AND AddressStatus = 1 -- Show only valid Address   -- GOOGLE MAP IGNORE            
)                                                 
Job                                                 
--WHERE Job.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex * @PageSize) + @PageSize)    -- GOOGLE MAP IGNORE                                             
ORDER BY Job.RowNumber                 
          
SELECT                       
 Jobs.JobId,                                                
 Jobs.SiteID,                                                
 Jobs.JobName,                  
 Jobs.Description,                                             
 '' as FullDescription,                                               
 Jobs.DatePosted,                                                
 Jobs.Visible,                                                
 Jobs.Expired,                                                
 Jobs.ShowSalaryDetails,                                        
 Jobs.ShowSalaryRange,                                               
 Jobs.SalaryText,                                                
 Jobs.AdvertiserID,                                                
 Jobs.ApplicationMethod,                           
 '' as ApplicationURL,                                                
 Jobs.AdvertiserJobTemplateLogoID,                                                
 Jobs.CompanyName,                                                
 Jobs.ShowLocationDetails,                                                
 '' as BulletPoint1,                                               
 '' as BulletPoint2,                                                
 '' as BulletPoint3,                                                
 Jobs.HotJob,                                   
 '' as ApplicationEmailAddress,                                  
 Jobs.ExpiryDate,                                  
 '' as ContactDetails,                                                
 Jobs.RefNo,                                                
 Advertisers.CompanyName AS AdvertiserName,                                                
 ViewSiteAreaLocationCountry.Currency as CurrencySymbol,                                                
 Jobs.SalaryUpperBand,                                                
Jobs.SalaryLowerBand,                                           
 Jobs.SalaryTypeId,                                            
 Isnull(SiteSalaryType.SalaryTypeName, SalaryType.SalaryTypeName) AS SalaryTypeName,                                                
 Isnull(SiteWorkType.SiteWorkTypeName, WorkType.WorkTypeName) AS WorkTypeName,                
 ViewSiteAreaLocationCountry.CountryID AS CountryID,             
 ViewSiteAreaLocationCountry.LocationID AS LocationID,             
 ViewSiteAreaLocationCountry.AreaID AS AreaID,             
 ViewSiteAreaLocationCountry.SiteCountryName AS CountryName,             
 ViewSiteAreaLocationCountry.SiteLocationName AS LocationName,             
 ViewSiteAreaLocationCountry.SiteAreaName AS AreaName,                                                
 Roles.ProfessionID,                                                
 Roles.RoleID,                               
 SiteProfession.SiteProfessionName,                                                
 SiteRoles.SiteRoleName,                                               
 '' AS BreadCrumbNavigation ,                                                
 Jobs.WorkTypeID,                                       
 '/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName',                           
 CAST(ViewSiteAreaLocationCountry.Currency AS NVARCHAR(10)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay,                                       
 Jobs.JobItemTypeID,        
 Jobs.JobLatitude,        
 Jobs.JobLongitude,        
 Jobs.AddressStatus,        
 CASE 
	WHEN ISNULL(Advertisers.AdvertiserLogoUrl, '') <> '' THEN 2
	WHEN Advertisers.AdvertiserLogo IS NOT NULL THEN 1
	ELSE 0  
 END as HasAdvertiserLogo,    
 JobCustomXML.CustomXML,  
 Jobs.Address                   
 FROM                                           
 @tmpJobIdSearch tmpJobIdSearch             
 INNER JOIN Jobs (NOLOCK) ON tmpJobIdSearch.JobID = Jobs.JobID                                           
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK)                                                      
 ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK)                                                      
 ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID                                              
 AND SiteSalaryType.SiteID = @SiteID                                         
                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies                                        
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID                                       
 AND [SiteCurrencies].SiteID = Jobs.SiteID                                       
        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies                                        
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
INNER JOIN WorkType (NOLOCK)                                                      
 ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK)                   
 ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID                                                
 AND SiteWorkType.SiteID = @SiteID                                                 
                                          
 -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK)                                                  
 ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)                                               
 ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                            
 AND ViewSiteAreaLocationCountry.Siteid = @SiteID                                           
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID                               
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK)                                                 
 ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK)                                     
 ON SiteRoles.RoleID = JobRoles.RoleID                                             
  AND SiteRoles.SiteID = @SiteID              
  AND SiteRoles.RoleID = tmpJobIdSearch.RoleId                                               
 INNER JOIN Roles (NOLOCK)                                                 
 ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK)                                                 
 ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK)                                                 
 ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteID               
 LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID              
 ORDER BY RowNumber 
 
 GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewJobSearch_GetBySearchFilter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilter]
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilter]                                       
 @Keyword NVARCHAR(2500),                                                   
 @SiteId INT,                                                   
 @AdvertiserId INT = NULL,                                       
 @CurrencyID INT = NULL,                                                   
 @SalaryLowerBand NUMERIC(15,2) = NULL,                                       
 @SalaryUpperBand NUMERIC(15,2) = NULL,                                                   
 @SalaryTypeID INT = NULL,                                       
 @WorkTypeID INT = NULL,                                                   
 @ProfessionID INT = NULL,                                                    
 @RoleID VARCHAR(255) = NULL,                                                  
 @CountryID INT = NULL,                                                   
 @LocationID INT = NULL,                                                   
 @AreaID VARCHAR(255)= NULL,                            
 @DateFrom DATETIME= NULL,                                                   
 @PageIndex INT,                                                   
 @PageSize INT,              
 @OrderBy VARCHAR(200) = NULL,            
 @JobTypeIDs VARCHAR(255) = NULL            
AS                                                   
          
/*          
 -- 16th April           
 -- Fix for Advertiser Filter taking lot of time to load the jobs.         
         
 -- 20th April        
 -- Add countryid as parameter          
*/                    
                     
 --SQL Server 2008 FTI Fix                                       
 IF ISNULL(@Keyword,'') = ''                                        
 SET @Keyword = '""'                                       
                          
 -- DECLARE @UseCustomProfessionRole BIT = (SELECT UseCustomProfessionRole FROM GlobalSettings WHERE SiteID = @SiteId)                       
               
 -- Check if the Salary sorting has the Salary type selected if not it goes to default search              
 IF (@OrderBy = 'SalaryHighToLow' OR @OrderBy = 'SalaryLowToHigh')              
 BEGIN               
 IF (ISNULL(@SalaryTypeID,0) = 0)              
  SET @OrderBy = ''              
 END              
            
-- Global settings - Get if Premium jobs needs to be displayed.            
Declare @DisplayPremiumJobsOnResults BIT            
SELECT @DisplayPremiumJobsOnResults = DisplayPremiumJobsOnResults FROM GlobalSettings (NOLOCK) where SiteID = @SiteId            
            
-- Get the valid JOB Types of the Site excluding Premium jobs          
IF (ISNULL(@JobTypeIDs,'') = '')      
BEGIN        
 SELECT @JobTypeIDs = COALESCE(@JobTypeIDs + ', ', '') + CAST(JobItemTypeParentID as Varchar)            
 FROM JobItemsType NOLOCK where SiteID = @SiteId AND Valid = 1 AND TotalNumberOfJobs = 1 AND JobItemTypeParentID <>3            
END      
          
DECLARE @tmpJobIdSearch TABLE (JobID INT, RoleId INT, RowNumber INT)              
INSERT INTO @tmpJobIdSearch(JobID, RoleId, RowNumber)          
Select JobId, RoleID, RowNumber FROM           
(          
SELECT                       
 Jobs.JobId,             
 SiteRoles.RoleID,                            
 ROW_NUMBER() OVER (ORDER BY                
       CASE WHEN ISNULL(@OrderBy,'') = '' THEN Jobs.DatePosted  END DESC,              
       CASE WHEN @OrderBy ='Old' THEN Jobs.DatePosted END,              
       CASE WHEN @OrderBy ='ZA' THEN Jobs.JobName  END DESC,              
       CASE WHEN @OrderBy ='AZ' THEN Jobs.JobName  END,              
       CASE WHEN @OrderBy ='SalaryHighToLow' THEN Jobs.SalaryUpperBand END DESC,              
       CASE WHEN @OrderBy ='SalaryLowToHigh' THEN Jobs.SalaryLowerBand  END              
       ) as RowNumber               
 FROM                                           
 [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter                                           
 INNER JOIN Jobs (NOLOCK)        
 ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                                                
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK)                                                      
 ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK)                                                      
 ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID                                              
 AND SiteSalaryType.SiteID = @SiteID                                         
                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies           
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID                                       
 AND [SiteCurrencies].SiteID = Jobs.SiteID                                       
        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies                                        
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
INNER JOIN WorkType (NOLOCK)                                                      
 ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK)                                                      
 ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID                                                
 AND SiteWorkType.SiteID = @SiteID                                                 
                                          
 -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK)                                                  
 ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)                                                  
 ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                            
 AND ViewSiteAreaLocationCountry.Siteid = @SiteID                                           
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID                               
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK)                                                 
 ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK)                                    
 ON SiteRoles.RoleID = JobRoles.RoleID                                             
 AND SiteRoles.SiteID = @SiteID                                                 
 INNER JOIN Roles (NOLOCK)                                                 
 ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK)                                                 
 ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK)                                                 
 ON SiteProfession.ProfessionID = Profession.ProfessionID                                              
 AND SiteProfession.SiteID = @SiteID                                                   
 WHERE                                                  
 Jobs.Expired = 0 AND              
 Jobs.ExpiryDate >= GETDATE() AND                                            
 ((@AdvertiserId is NULL) OR (Jobs.AdvertiserID = @AdvertiserId)) AND                                                 
 ((@CurrencyID IS NULL) OR (Jobs.CurrencyID = @CurrencyID)) AND                                         
 ((@SalaryLowerBand IS NULL) OR (Jobs.SalaryLowerBand >= @SalaryLowerBand)) AND                                     
((@SalaryUpperBand IS NULL) OR (Jobs.SalaryUpperBand <= @SalaryUpperBand)) AND                                       
 ((ISNULL(@SalaryTypeID,0) = 0 OR Jobs.SalaryTypeID  = @SalaryTypeID)) AND                         
((ISNULL(@WorkTypeID, 0) = 0) OR (Jobs.WorkTypeID = @WorkTypeID)) AND                                                 
 ((ISNULL(@ProfessionID, 0) = 0) OR (Roles.ProfessionID = @ProfessionID)) AND                    
 ((ISNULL(@RoleID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@RoleID) where id = Roles.RoleID))) AND                                               
 ((ISNULL(@CountryID, '') = '') OR (ViewSiteAreaLocationCountry.CountryID = @CountryID))  AND                                                
 ((ISNULL(@LocationID, '') = '') OR (ViewSiteAreaLocationCountry.LocationID = @LocationID))  AND                                                
 ((ISNULL(@AreaID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@AreaID) where id = ViewSiteAreaLocationCountry.AreaID)))             
  AND (--(ISNULL(@JobTypeIDs, '') = '') OR             
  (Jobs.JobItemTypeID IN (Select id from ParseIntCSV(@JobTypeIDs)))             
  OR (Jobs.JobItemTypeID IS NULL) -- TODO REMOVE Jobs.JobItemTypeID NULL              
  OR (@DisplayPremiumJobsOnResults = 1 AND Jobs.JobItemTypeID = 3 AND Jobs.SiteID = @SiteId))            
 AND Jobs.DatePosted <= CAST(GETDATE()+1 AS DATE)           
 AND ((@DateFrom IS NULL) OR Jobs.DatePosted >= @DateFrom)                   -- FOR JOB ALERT - Only send new jobs - Don't REMOVE                             
 AND ((ISNULL(@Keyword,'') = '""') OR CONTAINS(Jobs.[SearchField], @Keyword))                                             
 -- AND ((@UseCustomProfessionRole = 0) OR (@UseCustomProfessionRole = 1 AND Profession.ReferredSiteID = @SiteID))                          
)                                                 
Job                                                 
WHERE                               
 Job.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex * @PageSize) + @PageSize)                                                 
ORDER BY Job.RowNumber                 
          
SELECT                       
 Jobs.JobId,                                                
 Jobs.SiteID,                                                
 Jobs.JobName,                  
 Jobs.Description,                                             
 Jobs.FullDescription,                                               
 Jobs.DatePosted,                                                
 Jobs.Visible,                                                
 Jobs.Expired,                                                
 Jobs.ShowSalaryDetails,                                        
 Jobs.ShowSalaryRange,                                               
 Jobs.SalaryText,                                                
 Jobs.AdvertiserID,                                                
 Jobs.ApplicationMethod,                           
 Jobs.ApplicationURL,                                                
 Jobs.AdvertiserJobTemplateLogoID,                                                
 Jobs.CompanyName,                                                
 Jobs.ShowLocationDetails,                                                
 Jobs.BulletPoint1,                                                
 Jobs.BulletPoint2,                                                
 Jobs.BulletPoint3,                                                
 Jobs.HotJob,                                   
 Jobs.ApplicationEmailAddress,                                  
 Jobs.ExpiryDate,                                  
 Jobs.ContactDetails,                                                
 Jobs.RefNo,                                                
 Advertisers.CompanyName AS AdvertiserName,                                                
 ViewSiteAreaLocationCountry.Currency as CurrencySymbol, -- Currencies.CurrencySymbol,       
 Jobs.SalaryUpperBand,                                                
 Jobs.SalaryLowerBand,                                           
 Jobs.SalaryTypeId,                                            
 Isnull(SiteSalaryType.SalaryTypeName, SalaryType.SalaryTypeName) AS SalaryTypeName,     
 Isnull(SiteWorkType.SiteWorkTypeName, WorkType.WorkTypeName) AS WorkTypeName,                
 ViewSiteAreaLocationCountry.CountryID AS CountryID,             
 ViewSiteAreaLocationCountry.LocationID AS LocationID,             
 ViewSiteAreaLocationCountry.AreaID AS AreaID,             
 ViewSiteAreaLocationCountry.SiteCountryName AS CountryName,             
 ViewSiteAreaLocationCountry.SiteLocationName AS LocationName,             
 ViewSiteAreaLocationCountry.SiteAreaName AS AreaName,                                                
 Roles.ProfessionID,                                                
 Roles.RoleID,                               
 SiteProfession.SiteProfessionName,                                                
 SiteRoles.SiteRoleName,                                               
 '<a href="/advancedsearch.aspx?search=1&professionID=' + ISNULL(CAST(SiteProfession.ProfessionID AS VARCHAR(255)),'0') + '">' + SiteProfession.SiteProfessionName + '</a>' +                                              
 ' > ' + '<a href="/advancedsearch.aspx?search=1&professionID=' + ISNULL(CAST(SiteProfession.ProfessionID AS VARCHAR(255)),'0') + '&roleIDs='+ CAST(SiteRoles.RoleID AS VARCHAR(255)) + '">' + SiteRoles.SiteRoleName + '</a>'  COLLATE DATABASE_DEFAULT      
  
     
      
        
        
         
           
          
 AS BreadCrumbNavigation ,                                                
 Jobs.WorkTypeID,                                       
 '/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName',                           
 CAST(ViewSiteAreaLocationCountry.Currency AS NVARCHAR(10)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay,                                       
 Jobs.JobItemTypeID,        
 Jobs.JobLatitude,        
 Jobs.JobLongitude,        
 Jobs.AddressStatus,        
 CASE 
    WHEN ISNULL(Advertisers.AdvertiserLogoUrl, '') <> '' THEN 2
	WHEN Advertisers.AdvertiserLogo IS NOT NULL THEN 1
	ELSE 0  
 END as HasAdvertiserLogo,    
 JobCustomXML.CustomXML,  
 Jobs.Address        
 FROM                                           
 @tmpJobIdSearch tmpJobIdSearch             
 INNER JOIN Jobs (NOLOCK) ON tmpJobIdSearch.JobID = Jobs.JobID                                           
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK)                                                      
 ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK)                                                      
 ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID                                              
 AND SiteSalaryType.SiteID = @SiteID                                         
                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies                                        
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID                                       
 AND [SiteCurrencies].SiteID = Jobs.SiteID                                       
        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies                                        
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
INNER JOIN WorkType (NOLOCK)                                                      
 ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK)                                                      
 ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID                                             
 AND SiteWorkType.SiteID = @SiteID                                                 
                                          
 -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK)                                                  
 ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)                                                  
 ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                            
 AND ViewSiteAreaLocationCountry.Siteid = @SiteID                                           
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID                               
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK)                                                 
 ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK)                                     
 ON SiteRoles.RoleID = JobRoles.RoleID                                             
  AND SiteRoles.SiteID = @SiteID              
  AND SiteRoles.RoleID = tmpJobIdSearch.RoleId                                               
 INNER JOIN Roles (NOLOCK)                                                 
 ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK)                                                 
 ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK)                                                 
 ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteID                
 LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID    
 ORDER BY RowNumber 
 GO