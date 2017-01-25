
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the JobsArchive table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_Update]
(

	@JobId int   ,

	@OriginalJobId int   ,

	@SiteId int   ,

	@WorkTypeId int   ,

	@JobName nvarchar (510)  ,

	@Description nvarchar (2000)  ,

	@FullDescription nvarchar (MAX)  ,

	@WebServiceProcessed bit   ,

	@ApplicationEmailAddress varchar (255)  ,

	@RefNo varchar (255)  ,

	@Visible bit   ,

	@DatePosted smalldatetime   ,

	@ExpiryDate smalldatetime   ,

	@Expired int   ,

	@JobItemPrice money   ,

	@Billed bit   ,

	@LastModified datetime   ,

	@ShowSalaryDetails bit   ,

	@SalaryText varchar (500)  ,

	@AdvertiserId int   ,

	@LastModifiedByAdvertiserUserId int   ,

	@LastModifiedByAdminUserId int   ,

	@JobItemTypeId int   ,

	@ApplicationMethod int   ,

	@ApplicationUrl varchar (8000)  ,

	@UploadMethod int   ,

	@Tags text   ,

	@JobTemplateId int   ,

	@SearchFieldExtension varchar (8)  ,

	@AdvertiserJobTemplateLogoId int   ,

	@CompanyName varchar (255)  ,

	@HashValue varbinary (MAX)  ,

	@RequireLogonForExternalApplications bit   ,

	@ShowLocationDetails bit   ,

	@PublicTransport nvarchar (500)  ,

	@Address varchar (255)  ,

	@ContactDetails nvarchar (510)  ,

	@JobContactPhone varchar (50)  ,

	@JobContactName varchar (255)  ,

	@QualificationsRecognised bit   ,

	@ResidentOnly bit   ,

	@DocumentLink varchar (255)  ,

	@BulletPoint1 nvarchar (160)  ,

	@BulletPoint2 nvarchar (160)  ,

	@BulletPoint3 nvarchar (160)  ,

	@HotJob bit   ,

	@JobFriendlyName varchar (512)  ,

	@SearchField nvarchar (MAX)  ,

	@ShowSalaryRange bit   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@EnteredByAdvertiserUserId int   ,

	@JobLatitude float   ,

	@JobLongitude float   ,

	@AddressStatus int   ,

	@JobExternalId varchar (50)  ,

	@ScreeningQuestionsTemplateId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[JobsArchive]
				SET
					[JobID] = @JobId
					,[SiteID] = @SiteId
					,[WorkTypeID] = @WorkTypeId
					,[JobName] = @JobName
					,[Description] = @Description
					,[FullDescription] = @FullDescription
					,[WebServiceProcessed] = @WebServiceProcessed
					,[ApplicationEmailAddress] = @ApplicationEmailAddress
					,[RefNo] = @RefNo
					,[Visible] = @Visible
					,[DatePosted] = @DatePosted
					,[ExpiryDate] = @ExpiryDate
					,[Expired] = @Expired
					,[JobItemPrice] = @JobItemPrice
					,[Billed] = @Billed
					,[LastModified] = @LastModified
					,[ShowSalaryDetails] = @ShowSalaryDetails
					,[SalaryText] = @SalaryText
					,[AdvertiserID] = @AdvertiserId
					,[LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId
					,[LastModifiedByAdminUserId] = @LastModifiedByAdminUserId
					,[JobItemTypeID] = @JobItemTypeId
					,[ApplicationMethod] = @ApplicationMethod
					,[ApplicationURL] = @ApplicationUrl
					,[UploadMethod] = @UploadMethod
					,[Tags] = @Tags
					,[JobTemplateID] = @JobTemplateId
					,[SearchFieldExtension] = @SearchFieldExtension
					,[AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId
					,[CompanyName] = @CompanyName
					,[HashValue] = @HashValue
					,[RequireLogonForExternalApplications] = @RequireLogonForExternalApplications
					,[ShowLocationDetails] = @ShowLocationDetails
					,[PublicTransport] = @PublicTransport
					,[Address] = @Address
					,[ContactDetails] = @ContactDetails
					,[JobContactPhone] = @JobContactPhone
					,[JobContactName] = @JobContactName
					,[QualificationsRecognised] = @QualificationsRecognised
					,[ResidentOnly] = @ResidentOnly
					,[DocumentLink] = @DocumentLink
					,[BulletPoint1] = @BulletPoint1
					,[BulletPoint2] = @BulletPoint2
					,[BulletPoint3] = @BulletPoint3
					,[HotJob] = @HotJob
					,[JobFriendlyName] = @JobFriendlyName
					,[SearchField] = @SearchField
					,[ShowSalaryRange] = @ShowSalaryRange
					,[SalaryLowerBand] = @SalaryLowerBand
					,[SalaryUpperBand] = @SalaryUpperBand
					,[CurrencyID] = @CurrencyId
					,[SalaryTypeID] = @SalaryTypeId
					,[EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId
					,[JobLatitude] = @JobLatitude
					,[JobLongitude] = @JobLongitude
					,[AddressStatus] = @AddressStatus
					,[JobExternalId] = @JobExternalId
					,[ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId
				WHERE
[JobID] = @OriginalJobId
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_Insert]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the JobsArchive table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_Insert]
(

	@JobId int   ,

	@SiteId int   ,

	@WorkTypeId int   ,

	@JobName nvarchar (510)  ,

	@Description nvarchar (2000)  ,

	@FullDescription nvarchar (MAX)  ,

	@WebServiceProcessed bit   ,

	@ApplicationEmailAddress varchar (255)  ,

	@RefNo varchar (255)  ,

	@Visible bit   ,

	@DatePosted smalldatetime   ,

	@ExpiryDate smalldatetime   ,

	@Expired int   ,

	@JobItemPrice money   ,

	@Billed bit   ,

	@LastModified datetime   ,

	@ShowSalaryDetails bit   ,

	@SalaryText varchar (500)  ,

	@AdvertiserId int   ,

	@LastModifiedByAdvertiserUserId int   ,

	@LastModifiedByAdminUserId int   ,

	@JobItemTypeId int   ,

	@ApplicationMethod int   ,

	@ApplicationUrl varchar (8000)  ,

	@UploadMethod int   ,

	@Tags text   ,

	@JobTemplateId int   ,

	@SearchFieldExtension varchar (8)  ,

	@AdvertiserJobTemplateLogoId int   ,

	@CompanyName varchar (255)  ,

	@HashValue varbinary (MAX)  ,

	@RequireLogonForExternalApplications bit   ,

	@ShowLocationDetails bit   ,

	@PublicTransport nvarchar (500)  ,

	@Address varchar (255)  ,

	@ContactDetails nvarchar (510)  ,

	@JobContactPhone varchar (50)  ,

	@JobContactName varchar (255)  ,

	@QualificationsRecognised bit   ,

	@ResidentOnly bit   ,

	@DocumentLink varchar (255)  ,

	@BulletPoint1 nvarchar (160)  ,

	@BulletPoint2 nvarchar (160)  ,

	@BulletPoint3 nvarchar (160)  ,

	@HotJob bit   ,

	@JobFriendlyName varchar (512)  ,

	@SearchField nvarchar (MAX)  ,

	@ShowSalaryRange bit   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@EnteredByAdvertiserUserId int   ,

	@JobLatitude float   ,

	@JobLongitude float   ,

	@AddressStatus int   ,

	@JobExternalId varchar (50)  ,

	@ScreeningQuestionsTemplateId int   
)
AS


				
				INSERT INTO [dbo].[JobsArchive]
					(
					[JobID]
					,[SiteID]
					,[WorkTypeID]
					,[JobName]
					,[Description]
					,[FullDescription]
					,[WebServiceProcessed]
					,[ApplicationEmailAddress]
					,[RefNo]
					,[Visible]
					,[DatePosted]
					,[ExpiryDate]
					,[Expired]
					,[JobItemPrice]
					,[Billed]
					,[LastModified]
					,[ShowSalaryDetails]
					,[SalaryText]
					,[AdvertiserID]
					,[LastModifiedByAdvertiserUserId]
					,[LastModifiedByAdminUserId]
					,[JobItemTypeID]
					,[ApplicationMethod]
					,[ApplicationURL]
					,[UploadMethod]
					,[Tags]
					,[JobTemplateID]
					,[SearchFieldExtension]
					,[AdvertiserJobTemplateLogoID]
					,[CompanyName]
					,[HashValue]
					,[RequireLogonForExternalApplications]
					,[ShowLocationDetails]
					,[PublicTransport]
					,[Address]
					,[ContactDetails]
					,[JobContactPhone]
					,[JobContactName]
					,[QualificationsRecognised]
					,[ResidentOnly]
					,[DocumentLink]
					,[BulletPoint1]
					,[BulletPoint2]
					,[BulletPoint3]
					,[HotJob]
					,[JobFriendlyName]
					,[SearchField]
					,[ShowSalaryRange]
					,[SalaryLowerBand]
					,[SalaryUpperBand]
					,[CurrencyID]
					,[SalaryTypeID]
					,[EnteredByAdvertiserUserID]
					,[JobLatitude]
					,[JobLongitude]
					,[AddressStatus]
					,[JobExternalId]
					,[ScreeningQuestionsTemplateId]
					)
				VALUES
					(
					@JobId
					,@SiteId
					,@WorkTypeId
					,@JobName
					,@Description
					,@FullDescription
					,@WebServiceProcessed
					,@ApplicationEmailAddress
					,@RefNo
					,@Visible
					,@DatePosted
					,@ExpiryDate
					,@Expired
					,@JobItemPrice
					,@Billed
					,@LastModified
					,@ShowSalaryDetails
					,@SalaryText
					,@AdvertiserId
					,@LastModifiedByAdvertiserUserId
					,@LastModifiedByAdminUserId
					,@JobItemTypeId
					,@ApplicationMethod
					,@ApplicationUrl
					,@UploadMethod
					,@Tags
					,@JobTemplateId
					,@SearchFieldExtension
					,@AdvertiserJobTemplateLogoId
					,@CompanyName
					,@HashValue
					,@RequireLogonForExternalApplications
					,@ShowLocationDetails
					,@PublicTransport
					,@Address
					,@ContactDetails
					,@JobContactPhone
					,@JobContactName
					,@QualificationsRecognised
					,@ResidentOnly
					,@DocumentLink
					,@BulletPoint1
					,@BulletPoint2
					,@BulletPoint3
					,@HotJob
					,@JobFriendlyName
					,@SearchField
					,@ShowSalaryRange
					,@SalaryLowerBand
					,@SalaryUpperBand
					,@CurrencyId
					,@SalaryTypeId
					,@EnteredByAdvertiserUserId
					,@JobLatitude
					,@JobLongitude
					,@AddressStatus
					,@JobExternalId
					,@ScreeningQuestionsTemplateId
					)
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetPaged]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the JobsArchive table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetPaged]
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
				    [JobID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobID]'
				SET @SQL = @SQL + ' FROM [dbo].[JobsArchive]'
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
				SELECT O.[JobID], O.[SiteID], O.[WorkTypeID], O.[JobName], O.[Description], O.[FullDescription], O.[WebServiceProcessed], O.[ApplicationEmailAddress], O.[RefNo], O.[Visible], O.[DatePosted], O.[ExpiryDate], O.[Expired], O.[JobItemPrice], O.[Billed], O.[LastModified], O.[ShowSalaryDetails], O.[SalaryText], O.[AdvertiserID], O.[LastModifiedByAdvertiserUserId], O.[LastModifiedByAdminUserId], O.[JobItemTypeID], O.[ApplicationMethod], O.[ApplicationURL], O.[UploadMethod], O.[Tags], O.[JobTemplateID], O.[SearchFieldExtension], O.[AdvertiserJobTemplateLogoID], O.[CompanyName], O.[HashValue], O.[RequireLogonForExternalApplications], O.[ShowLocationDetails], O.[PublicTransport], O.[Address], O.[ContactDetails], O.[JobContactPhone], O.[JobContactName], O.[QualificationsRecognised], O.[ResidentOnly], O.[DocumentLink], O.[BulletPoint1], O.[BulletPoint2], O.[BulletPoint3], O.[HotJob], O.[JobFriendlyName], O.[SearchField], O.[ShowSalaryRange], O.[SalaryLowerBand], O.[SalaryUpperBand], O.[CurrencyID], O.[SalaryTypeID], O.[EnteredByAdvertiserUserID], O.[JobLatitude], O.[JobLongitude], O.[AddressStatus], O.[JobExternalId], O.[ScreeningQuestionsTemplateId]
				FROM
				    [dbo].[JobsArchive] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobID] = PageIndex.[JobID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[JobsArchive]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByWorkTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByWorkTypeId]
(

	@WorkTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[WorkTypeID] = @WorkTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted]
(

	@SiteId int   ,

	@Billed bit   ,

	@AdvertiserId int   ,

	@DatePosted smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[SiteID] = @SiteId
					AND [Billed] = @Billed
					AND [AdvertiserID] = @AdvertiserId
					AND [DatePosted] = @DatePosted
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetBySiteIdBilledAdvertiserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetBySiteIdBilledAdvertiserId]
(

	@SiteId int   ,

	@Billed bit   ,

	@AdvertiserId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[SiteID] = @SiteId
					AND [Billed] = @Billed
					AND [AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetBySiteId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByScreeningQuestionsTemplateId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByScreeningQuestionsTemplateId]
(

	@ScreeningQuestionsTemplateId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetBySalaryTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetBySalaryTypeId]
(

	@SalaryTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[SalaryTypeID] = @SalaryTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByLastModifiedByAdvertiserUserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByLastModifiedByAdvertiserUserId]
(

	@LastModifiedByAdvertiserUserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByLastModifiedByAdminUserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByLastModifiedByAdminUserId]
(

	@LastModifiedByAdminUserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[LastModifiedByAdminUserId] = @LastModifiedByAdminUserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByJobTemplateId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByJobTemplateId]
(

	@JobTemplateId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[JobTemplateID] = @JobTemplateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByJobItemTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByJobItemTypeId]
(

	@JobItemTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[JobItemTypeID] = @JobItemTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByJobId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByJobId]
(

	@JobId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[JobID] = @JobId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId]
(

	@Expired bit   ,

	@ExpiryDate smalldatetime   ,

	@AdvertiserId int   ,

	@CurrencyId int   ,

	@SalaryUpperBand numeric (15, 2)  ,

	@SalaryLowerBand numeric (15, 2)  ,

	@WorkTypeId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
				FROM
					[dbo].[JobsArchive] (NOLOCK)
				WHERE
					[Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
					AND [AdvertiserID] = @AdvertiserId
					AND [CurrencyID] = @CurrencyId
					AND [SalaryUpperBand] = @SalaryUpperBand
					AND [SalaryLowerBand] = @SalaryLowerBand
					AND [WorkTypeID] = @WorkTypeId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByCurrencyId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByCurrencyId]
(

	@CurrencyId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[CurrencyID] = @CurrencyId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate]
(

	@AdvertiserId int   ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@WorkTypeId int   ,

	@Expired int   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[AdvertiserID] = @AdvertiserId
					AND [CurrencyID] = @CurrencyId
					AND [SalaryTypeID] = @SalaryTypeId
					AND [SalaryLowerBand] = @SalaryLowerBand
					AND [SalaryUpperBand] = @SalaryUpperBand
					AND [WorkTypeID] = @WorkTypeId
					AND [Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByAdvertiserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[AdvertiserID] = @AdvertiserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByAddressStatus]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobsArchive table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_GetByAddressStatus]
(

	@AddressStatus int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
				WHERE
					[AddressStatus] = @AddressStatus
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_Get_List]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the JobsArchive table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_Get_List]

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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[JobsArchive]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_Find]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the JobsArchive table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_Find]
(

	@SearchUsingOR bit   = null ,

	@JobId int   = null ,

	@SiteId int   = null ,

	@WorkTypeId int   = null ,

	@JobName nvarchar (510)  = null ,

	@Description nvarchar (2000)  = null ,

	@FullDescription nvarchar (MAX)  = null ,

	@WebServiceProcessed bit   = null ,

	@ApplicationEmailAddress varchar (255)  = null ,

	@RefNo varchar (255)  = null ,

	@Visible bit   = null ,

	@DatePosted smalldatetime   = null ,

	@ExpiryDate smalldatetime   = null ,

	@Expired int   = null ,

	@JobItemPrice money   = null ,

	@Billed bit   = null ,

	@LastModified datetime   = null ,

	@ShowSalaryDetails bit   = null ,

	@SalaryText varchar (500)  = null ,

	@AdvertiserId int   = null ,

	@LastModifiedByAdvertiserUserId int   = null ,

	@LastModifiedByAdminUserId int   = null ,

	@JobItemTypeId int   = null ,

	@ApplicationMethod int   = null ,

	@ApplicationUrl varchar (8000)  = null ,

	@UploadMethod int   = null ,

	@Tags text   = null ,

	@JobTemplateId int   = null ,

	@SearchFieldExtension varchar (8)  = null ,

	@AdvertiserJobTemplateLogoId int   = null ,

	@CompanyName varchar (255)  = null ,

	@HashValue varbinary (MAX)  = null ,

	@RequireLogonForExternalApplications bit   = null ,

	@ShowLocationDetails bit   = null ,

	@PublicTransport nvarchar (500)  = null ,

	@Address varchar (255)  = null ,

	@ContactDetails nvarchar (510)  = null ,

	@JobContactPhone varchar (50)  = null ,

	@JobContactName varchar (255)  = null ,

	@QualificationsRecognised bit   = null ,

	@ResidentOnly bit   = null ,

	@DocumentLink varchar (255)  = null ,

	@BulletPoint1 nvarchar (160)  = null ,

	@BulletPoint2 nvarchar (160)  = null ,

	@BulletPoint3 nvarchar (160)  = null ,

	@HotJob bit   = null ,

	@JobFriendlyName varchar (512)  = null ,

	@SearchField nvarchar (MAX)  = null ,

	@ShowSalaryRange bit   = null ,

	@SalaryLowerBand numeric (15, 2)  = null ,

	@SalaryUpperBand numeric (15, 2)  = null ,

	@CurrencyId int   = null ,

	@SalaryTypeId int   = null ,

	@EnteredByAdvertiserUserId int   = null ,

	@JobLatitude float   = null ,

	@JobLongitude float   = null ,

	@AddressStatus int   = null ,

	@JobExternalId varchar (50)  = null ,

	@ScreeningQuestionsTemplateId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobID]
	, [SiteID]
	, [WorkTypeID]
	, [JobName]
	, [Description]
	, [FullDescription]
	, [WebServiceProcessed]
	, [ApplicationEmailAddress]
	, [RefNo]
	, [Visible]
	, [DatePosted]
	, [ExpiryDate]
	, [Expired]
	, [JobItemPrice]
	, [Billed]
	, [LastModified]
	, [ShowSalaryDetails]
	, [SalaryText]
	, [AdvertiserID]
	, [LastModifiedByAdvertiserUserId]
	, [LastModifiedByAdminUserId]
	, [JobItemTypeID]
	, [ApplicationMethod]
	, [ApplicationURL]
	, [UploadMethod]
	, [Tags]
	, [JobTemplateID]
	, [SearchFieldExtension]
	, [AdvertiserJobTemplateLogoID]
	, [CompanyName]
	, [HashValue]
	, [RequireLogonForExternalApplications]
	, [ShowLocationDetails]
	, [PublicTransport]
	, [Address]
	, [ContactDetails]
	, [JobContactPhone]
	, [JobContactName]
	, [QualificationsRecognised]
	, [ResidentOnly]
	, [DocumentLink]
	, [BulletPoint1]
	, [BulletPoint2]
	, [BulletPoint3]
	, [HotJob]
	, [JobFriendlyName]
	, [SearchField]
	, [ShowSalaryRange]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [EnteredByAdvertiserUserID]
	, [JobLatitude]
	, [JobLongitude]
	, [AddressStatus]
	, [JobExternalId]
	, [ScreeningQuestionsTemplateId]
    FROM
	[dbo].[JobsArchive]
    WHERE 
	 ([JobID] = @JobId OR @JobId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([WorkTypeID] = @WorkTypeId OR @WorkTypeId IS NULL)
	AND ([JobName] = @JobName OR @JobName IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([FullDescription] = @FullDescription OR @FullDescription IS NULL)
	AND ([WebServiceProcessed] = @WebServiceProcessed OR @WebServiceProcessed IS NULL)
	AND ([ApplicationEmailAddress] = @ApplicationEmailAddress OR @ApplicationEmailAddress IS NULL)
	AND ([RefNo] = @RefNo OR @RefNo IS NULL)
	AND ([Visible] = @Visible OR @Visible IS NULL)
	AND ([DatePosted] = @DatePosted OR @DatePosted IS NULL)
	AND ([ExpiryDate] = @ExpiryDate OR @ExpiryDate IS NULL)
	AND ([Expired] = @Expired OR @Expired IS NULL)
	AND ([JobItemPrice] = @JobItemPrice OR @JobItemPrice IS NULL)
	AND ([Billed] = @Billed OR @Billed IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([ShowSalaryDetails] = @ShowSalaryDetails OR @ShowSalaryDetails IS NULL)
	AND ([SalaryText] = @SalaryText OR @SalaryText IS NULL)
	AND ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId OR @LastModifiedByAdvertiserUserId IS NULL)
	AND ([LastModifiedByAdminUserId] = @LastModifiedByAdminUserId OR @LastModifiedByAdminUserId IS NULL)
	AND ([JobItemTypeID] = @JobItemTypeId OR @JobItemTypeId IS NULL)
	AND ([ApplicationMethod] = @ApplicationMethod OR @ApplicationMethod IS NULL)
	AND ([ApplicationURL] = @ApplicationUrl OR @ApplicationUrl IS NULL)
	AND ([UploadMethod] = @UploadMethod OR @UploadMethod IS NULL)
	AND ([JobTemplateID] = @JobTemplateId OR @JobTemplateId IS NULL)
	AND ([SearchFieldExtension] = @SearchFieldExtension OR @SearchFieldExtension IS NULL)
	AND ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId OR @AdvertiserJobTemplateLogoId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([RequireLogonForExternalApplications] = @RequireLogonForExternalApplications OR @RequireLogonForExternalApplications IS NULL)
	AND ([ShowLocationDetails] = @ShowLocationDetails OR @ShowLocationDetails IS NULL)
	AND ([PublicTransport] = @PublicTransport OR @PublicTransport IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([ContactDetails] = @ContactDetails OR @ContactDetails IS NULL)
	AND ([JobContactPhone] = @JobContactPhone OR @JobContactPhone IS NULL)
	AND ([JobContactName] = @JobContactName OR @JobContactName IS NULL)
	AND ([QualificationsRecognised] = @QualificationsRecognised OR @QualificationsRecognised IS NULL)
	AND ([ResidentOnly] = @ResidentOnly OR @ResidentOnly IS NULL)
	AND ([DocumentLink] = @DocumentLink OR @DocumentLink IS NULL)
	AND ([BulletPoint1] = @BulletPoint1 OR @BulletPoint1 IS NULL)
	AND ([BulletPoint2] = @BulletPoint2 OR @BulletPoint2 IS NULL)
	AND ([BulletPoint3] = @BulletPoint3 OR @BulletPoint3 IS NULL)
	AND ([HotJob] = @HotJob OR @HotJob IS NULL)
	AND ([JobFriendlyName] = @JobFriendlyName OR @JobFriendlyName IS NULL)
	AND ([SearchField] = @SearchField OR @SearchField IS NULL)
	AND ([ShowSalaryRange] = @ShowSalaryRange OR @ShowSalaryRange IS NULL)
	AND ([SalaryLowerBand] = @SalaryLowerBand OR @SalaryLowerBand IS NULL)
	AND ([SalaryUpperBand] = @SalaryUpperBand OR @SalaryUpperBand IS NULL)
	AND ([CurrencyID] = @CurrencyId OR @CurrencyId IS NULL)
	AND ([SalaryTypeID] = @SalaryTypeId OR @SalaryTypeId IS NULL)
	AND ([EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId OR @EnteredByAdvertiserUserId IS NULL)
	AND ([JobLatitude] = @JobLatitude OR @JobLatitude IS NULL)
	AND ([JobLongitude] = @JobLongitude OR @JobLongitude IS NULL)
	AND ([AddressStatus] = @AddressStatus OR @AddressStatus IS NULL)
	AND ([JobExternalId] = @JobExternalId OR @JobExternalId IS NULL)
	AND ([ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId OR @ScreeningQuestionsTemplateId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobID]
	, [SiteID]
	, [WorkTypeID]
	, [JobName]
	, [Description]
	, [FullDescription]
	, [WebServiceProcessed]
	, [ApplicationEmailAddress]
	, [RefNo]
	, [Visible]
	, [DatePosted]
	, [ExpiryDate]
	, [Expired]
	, [JobItemPrice]
	, [Billed]
	, [LastModified]
	, [ShowSalaryDetails]
	, [SalaryText]
	, [AdvertiserID]
	, [LastModifiedByAdvertiserUserId]
	, [LastModifiedByAdminUserId]
	, [JobItemTypeID]
	, [ApplicationMethod]
	, [ApplicationURL]
	, [UploadMethod]
	, [Tags]
	, [JobTemplateID]
	, [SearchFieldExtension]
	, [AdvertiserJobTemplateLogoID]
	, [CompanyName]
	, [HashValue]
	, [RequireLogonForExternalApplications]
	, [ShowLocationDetails]
	, [PublicTransport]
	, [Address]
	, [ContactDetails]
	, [JobContactPhone]
	, [JobContactName]
	, [QualificationsRecognised]
	, [ResidentOnly]
	, [DocumentLink]
	, [BulletPoint1]
	, [BulletPoint2]
	, [BulletPoint3]
	, [HotJob]
	, [JobFriendlyName]
	, [SearchField]
	, [ShowSalaryRange]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [EnteredByAdvertiserUserID]
	, [JobLatitude]
	, [JobLongitude]
	, [AddressStatus]
	, [JobExternalId]
	, [ScreeningQuestionsTemplateId]
    FROM
	[dbo].[JobsArchive]
    WHERE 
	 ([JobID] = @JobId AND @JobId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([WorkTypeID] = @WorkTypeId AND @WorkTypeId is not null)
	OR ([JobName] = @JobName AND @JobName is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([FullDescription] = @FullDescription AND @FullDescription is not null)
	OR ([WebServiceProcessed] = @WebServiceProcessed AND @WebServiceProcessed is not null)
	OR ([ApplicationEmailAddress] = @ApplicationEmailAddress AND @ApplicationEmailAddress is not null)
	OR ([RefNo] = @RefNo AND @RefNo is not null)
	OR ([Visible] = @Visible AND @Visible is not null)
	OR ([DatePosted] = @DatePosted AND @DatePosted is not null)
	OR ([ExpiryDate] = @ExpiryDate AND @ExpiryDate is not null)
	OR ([Expired] = @Expired AND @Expired is not null)
	OR ([JobItemPrice] = @JobItemPrice AND @JobItemPrice is not null)
	OR ([Billed] = @Billed AND @Billed is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([ShowSalaryDetails] = @ShowSalaryDetails AND @ShowSalaryDetails is not null)
	OR ([SalaryText] = @SalaryText AND @SalaryText is not null)
	OR ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId AND @LastModifiedByAdvertiserUserId is not null)
	OR ([LastModifiedByAdminUserId] = @LastModifiedByAdminUserId AND @LastModifiedByAdminUserId is not null)
	OR ([JobItemTypeID] = @JobItemTypeId AND @JobItemTypeId is not null)
	OR ([ApplicationMethod] = @ApplicationMethod AND @ApplicationMethod is not null)
	OR ([ApplicationURL] = @ApplicationUrl AND @ApplicationUrl is not null)
	OR ([UploadMethod] = @UploadMethod AND @UploadMethod is not null)
	OR ([JobTemplateID] = @JobTemplateId AND @JobTemplateId is not null)
	OR ([SearchFieldExtension] = @SearchFieldExtension AND @SearchFieldExtension is not null)
	OR ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId AND @AdvertiserJobTemplateLogoId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([RequireLogonForExternalApplications] = @RequireLogonForExternalApplications AND @RequireLogonForExternalApplications is not null)
	OR ([ShowLocationDetails] = @ShowLocationDetails AND @ShowLocationDetails is not null)
	OR ([PublicTransport] = @PublicTransport AND @PublicTransport is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([ContactDetails] = @ContactDetails AND @ContactDetails is not null)
	OR ([JobContactPhone] = @JobContactPhone AND @JobContactPhone is not null)
	OR ([JobContactName] = @JobContactName AND @JobContactName is not null)
	OR ([QualificationsRecognised] = @QualificationsRecognised AND @QualificationsRecognised is not null)
	OR ([ResidentOnly] = @ResidentOnly AND @ResidentOnly is not null)
	OR ([DocumentLink] = @DocumentLink AND @DocumentLink is not null)
	OR ([BulletPoint1] = @BulletPoint1 AND @BulletPoint1 is not null)
	OR ([BulletPoint2] = @BulletPoint2 AND @BulletPoint2 is not null)
	OR ([BulletPoint3] = @BulletPoint3 AND @BulletPoint3 is not null)
	OR ([HotJob] = @HotJob AND @HotJob is not null)
	OR ([JobFriendlyName] = @JobFriendlyName AND @JobFriendlyName is not null)
	OR ([SearchField] = @SearchField AND @SearchField is not null)
	OR ([ShowSalaryRange] = @ShowSalaryRange AND @ShowSalaryRange is not null)
	OR ([SalaryLowerBand] = @SalaryLowerBand AND @SalaryLowerBand is not null)
	OR ([SalaryUpperBand] = @SalaryUpperBand AND @SalaryUpperBand is not null)
	OR ([CurrencyID] = @CurrencyId AND @CurrencyId is not null)
	OR ([SalaryTypeID] = @SalaryTypeId AND @SalaryTypeId is not null)
	OR ([EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId AND @EnteredByAdvertiserUserId is not null)
	OR ([JobLatitude] = @JobLatitude AND @JobLatitude is not null)
	OR ([JobLongitude] = @JobLongitude AND @JobLongitude is not null)
	OR ([AddressStatus] = @AddressStatus AND @AddressStatus is not null)
	OR ([JobExternalId] = @JobExternalId AND @JobExternalId is not null)
	OR ([ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId AND @ScreeningQuestionsTemplateId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_Delete]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the JobsArchive table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobsArchive_Delete]
(

	@JobId int   
)
AS


				DELETE FROM [dbo].[JobsArchive] WITH (ROWLOCK) 
				WHERE
					[JobID] = @JobId
GO
/****** Object:  StoredProcedure [dbo].[Jobs_Update]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Jobs table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_Update]
(

	@JobId int   ,

	@SiteId int   ,

	@WorkTypeId int   ,

	@JobName nvarchar (510)  ,

	@Description nvarchar (2000)  ,

	@FullDescription nvarchar (MAX)  ,

	@WebServiceProcessed bit   ,

	@ApplicationEmailAddress varchar (255)  ,

	@RefNo varchar (255)  ,

	@Visible bit   ,

	@DatePosted smalldatetime   ,

	@ExpiryDate smalldatetime   ,

	@Expired int   ,

	@JobItemPrice money   ,

	@Billed bit   ,

	@LastModified datetime   ,

	@ShowSalaryDetails bit   ,

	@SalaryText varchar (500)  ,

	@AdvertiserId int   ,

	@LastModifiedByAdvertiserUserId int   ,

	@LastModifiedByAdminUserId int   ,

	@JobItemTypeId int   ,

	@ApplicationMethod int   ,

	@ApplicationUrl varchar (8000)  ,

	@UploadMethod int   ,

	@Tags text   ,

	@JobTemplateId int   ,

	@SearchFieldExtension varchar (8)  ,

	@AdvertiserJobTemplateLogoId int   ,

	@CompanyName varchar (255)  ,

	@HashValue varbinary (MAX)  ,

	@RequireLogonForExternalApplications bit   ,

	@ShowLocationDetails bit   ,

	@PublicTransport nvarchar (500)  ,

	@Address varchar (255)  ,

	@ContactDetails nvarchar (510)  ,

	@JobContactPhone varchar (50)  ,

	@JobContactName varchar (255)  ,

	@QualificationsRecognised bit   ,

	@ResidentOnly bit   ,

	@DocumentLink varchar (255)  ,

	@BulletPoint1 nvarchar (160)  ,

	@BulletPoint2 nvarchar (160)  ,

	@BulletPoint3 nvarchar (160)  ,

	@HotJob bit   ,

	@JobFriendlyName varchar (512)  ,

	@SearchField nvarchar (MAX)  ,

	@ShowSalaryRange bit   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@EnteredByAdvertiserUserId int   ,

	@JobLatitude float   ,

	@JobLongitude float   ,

	@AddressStatus int   ,

	@JobExternalId varchar (50)  ,

	@ScreeningQuestionsTemplateId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Jobs]
				SET
					[SiteID] = @SiteId
					,[WorkTypeID] = @WorkTypeId
					,[JobName] = @JobName
					,[Description] = @Description
					,[FullDescription] = @FullDescription
					,[WebServiceProcessed] = @WebServiceProcessed
					,[ApplicationEmailAddress] = @ApplicationEmailAddress
					,[RefNo] = @RefNo
					,[Visible] = @Visible
					,[DatePosted] = @DatePosted
					,[ExpiryDate] = @ExpiryDate
					,[Expired] = @Expired
					,[JobItemPrice] = @JobItemPrice
					,[Billed] = @Billed
					,[LastModified] = @LastModified
					,[ShowSalaryDetails] = @ShowSalaryDetails
					,[SalaryText] = @SalaryText
					,[AdvertiserID] = @AdvertiserId
					,[LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId
					,[LastModifiedByAdminUserId] = @LastModifiedByAdminUserId
					,[JobItemTypeID] = @JobItemTypeId
					,[ApplicationMethod] = @ApplicationMethod
					,[ApplicationURL] = @ApplicationUrl
					,[UploadMethod] = @UploadMethod
					,[Tags] = @Tags
					,[JobTemplateID] = @JobTemplateId
					,[SearchFieldExtension] = @SearchFieldExtension
					,[AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId
					,[CompanyName] = @CompanyName
					,[HashValue] = @HashValue
					,[RequireLogonForExternalApplications] = @RequireLogonForExternalApplications
					,[ShowLocationDetails] = @ShowLocationDetails
					,[PublicTransport] = @PublicTransport
					,[Address] = @Address
					,[ContactDetails] = @ContactDetails
					,[JobContactPhone] = @JobContactPhone
					,[JobContactName] = @JobContactName
					,[QualificationsRecognised] = @QualificationsRecognised
					,[ResidentOnly] = @ResidentOnly
					,[DocumentLink] = @DocumentLink
					,[BulletPoint1] = @BulletPoint1
					,[BulletPoint2] = @BulletPoint2
					,[BulletPoint3] = @BulletPoint3
					,[HotJob] = @HotJob
					,[JobFriendlyName] = @JobFriendlyName
					,[SearchField] = @SearchField
					,[ShowSalaryRange] = @ShowSalaryRange
					,[SalaryLowerBand] = @SalaryLowerBand
					,[SalaryUpperBand] = @SalaryUpperBand
					,[CurrencyID] = @CurrencyId
					,[SalaryTypeID] = @SalaryTypeId
					,[EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId
					,[JobLatitude] = @JobLatitude
					,[JobLongitude] = @JobLongitude
					,[AddressStatus] = @AddressStatus
					,[JobExternalId] = @JobExternalId
					,[ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId
				WHERE
[JobID] = @JobId
GO
/****** Object:  StoredProcedure [dbo].[Jobs_JobArchive]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_JobArchive]   
(  
 @JobID INT = 0  
)  
AS  
BEGIN TRY  
BEGIN TRANSACTION JobArchiveTransaction  

/*
-- Changes - Jan 2015
Archieve invoice item move from job id to archive id.

*/

 DECLARE @IsJobExpired BIT = 0
 
 -- Check if the job is expired.
 SELECT @IsJobExpired = 1 FROM Jobs NOLOCK 
	WHERE JobID = @JobID AND  
			((Expired = 0 AND ExpiryDate < CAST(GETDATE() AS DATE)) OR Expired = 1)  -- Live job which is expired or checked expired
 
 IF (@IsJobExpired = 1)
 BEGIN
   
 INSERT INTO [dbo].[JobsArchive]  
      ([JobID]  
      ,[SiteID]  
      ,[WorkTypeID]  
      ,[JobName]  
      ,[Description]  
      ,[FullDescription]  
      ,[WebServiceProcessed]  
      ,[ApplicationEmailAddress]  
      ,[RefNo]  
      ,[Visible]  
      ,[DatePosted]  
      ,[ExpiryDate]  
      ,[Expired]  
      ,[JobItemPrice]  
      ,[Billed]  
      ,[LastModified]  
      ,[ShowSalaryDetails]  
      ,[SalaryText]  
      ,[AdvertiserID]  
      ,[LastModifiedByAdvertiserUserId]  
      ,[LastModifiedByAdminUserId]  
      ,[JobItemTypeID]  
      ,[ApplicationMethod]  
      ,[ApplicationURL]  
      ,[UploadMethod]  
      ,[Tags]  
      ,[JobTemplateID]  
      ,[SearchFieldExtension]  
      ,[AdvertiserJobTemplateLogoID]  
      ,[CompanyName]  
      ,[HashValue]  
      ,[RequireLogonForExternalApplications]  
      ,[ShowLocationDetails]  
      ,[PublicTransport]  
      ,[Address]  
      ,[ContactDetails]  
      ,[JobContactPhone]  
      ,[JobContactName]  
      ,[QualificationsRecognised]  
      ,[ResidentOnly]  
      ,[DocumentLink]  
      ,[BulletPoint1]  
      ,[BulletPoint2]  
      ,[BulletPoint3]  
      ,[HotJob]  
      ,[JobFriendlyName]  
      ,[SearchField]  
      ,[ShowSalaryRange]  
      ,[CurrencyID]  
      ,[SalaryUpperBand]  
      ,[SalaryLowerBand]  
      ,[SalaryTypeID]  
      ,[EnteredByAdvertiserUserID]
      ,JobLatitude
	  ,JobLongitude
	  ,AddressStatus
	  ,JobExternalId)  
      
     SELECT [JobID]  
           ,[SiteID]  
           ,[WorkTypeID]  
           ,[JobName]  
           ,[Description]  
           ,[FullDescription]  
           ,[WebServiceProcessed]  
           ,[ApplicationEmailAddress]  
           ,[RefNo]  
           ,[Visible]  
           ,[DatePosted]  
           ,[ExpiryDate]  
           ,[Expired]  
           ,[JobItemPrice]  
           ,[Billed]  
           ,[LastModified]  
           ,[ShowSalaryDetails]  
           ,[SalaryText]  
           ,[AdvertiserID]  
           ,[LastModifiedByAdvertiserUserId]  
           ,[LastModifiedByAdminUserId]  
           ,[JobItemTypeID]  
           ,[ApplicationMethod]  
           ,[ApplicationURL]  
           ,[UploadMethod]  
           ,[Tags]  
           ,[JobTemplateID]  
           ,[SearchFieldExtension]  
           ,[AdvertiserJobTemplateLogoID]  
           ,[CompanyName]  
           ,[HashValue]  
           ,[RequireLogonForExternalApplications]  
           ,[ShowLocationDetails]  
           ,[PublicTransport]  
           ,[Address]  
           ,[ContactDetails]  
           ,[JobContactPhone]  
           ,[JobContactName]  
           ,[QualificationsRecognised]  
           ,[ResidentOnly]  
           ,[DocumentLink]  
           ,[BulletPoint1]  
           ,[BulletPoint2]  
           ,[BulletPoint3]  
           ,[HotJob]  
           ,[JobFriendlyName]  
           ,[SearchField]  
     ,[ShowSalaryRange]  
           ,[CurrencyID]  
     ,[SalaryUpperBand]  
     ,[SalaryLowerBand]  
     ,[SalaryTypeID]  
     ,[EnteredByAdvertiserUserID] 
     ,JobLatitude
	 ,JobLongitude
	 ,AddressStatus 
	 ,JobExternalId
 FROM Jobs (NOLOCK)  
 WHERE JobID = @JobID  
   
    UPDATE JobRoles SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobsSaved SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobViews SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobApplication SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobArea SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	Update InvoiceItem SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID   -- Move the InvoiceItem also
	
	DELETE FROM Jobs WHERE JobID = @JobID  
END
  
COMMIT TRANSACTION JobArchiveTransaction  
END TRY  
   
BEGIN CATCH  
IF @@TRANCOUNT > 0  
ROLLBACK TRANSACTION JobArchiveTransaction --RollBack in case of Error  
   
-- Raise an error with the details of the exception  
DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT  
SELECT @ErrMsg = ERROR_MESSAGE(),  
@ErrSeverity = ERROR_SEVERITY()  
   
RAISERROR(@ErrMsg, @ErrSeverity, 1)  
    
 IF (@IsJobExpired = 1)
 BEGIN
	IF EXISTS(SELECT 1 FROM [JobX_Live].[dbo].[Integration_JXTJobMapping] WHERE JXTJobID = @JobID)  
	BEGIN  
		DECLARE @JobXJobID INT  
		SELECT @JobXJobID = JobID FROM [JobX_Live].[dbo].[Integration_JXTJobMapping] WHERE JXTJobID = @JobID  
		UPDATE [JobX_Live].[dbo].Products SET Expired = 1 WHERE ProductID = @JobXJobID  
	END  
  END   
  
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[Jobs_JobsPurge]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_JobsPurge]  
AS    
 SET NOCOUNT ON;    
    
 DECLARE @iReturnCode  int,    
   @iNextRowId   int,    
   @iCurrentRowId int,    
            @iLoopControl int    
    
 SELECT @iLoopControl = 1    
    
 SELECT @iNextRowId = MIN(JobID)    
 FROM   Jobs (NOLOCK)    
 WHERE ExpiryDate < CAST(GETDATE() AS DATE)    
 OR Expired = 1  
     
 IF ISNULL(@iNextRowId,0) = 0    
 BEGIN    
 RETURN    
 END    
    
 SELECT  @iCurrentRowId   = JobID    
 FROM    Jobs (NOLOCK)    
 WHERE   JobID = @iNextRowId    
    
 WHILE @iLoopControl = 1    
 BEGIN    
   SELECT   @iNextRowId = NULL               
    
   -- get the next iRowId    
   SELECT   @iNextRowId = MIN(JobID)    
   FROM     Jobs (NOLOCK)    
   WHERE    JobID > @iCurrentRowId    
   AND   (ExpiryDate < CAST(GETDATE() AS DATE) AND Expired = 0) -- Only live jobs  
   OR Expired = 1  -- Or expired jobs
    
      
   --Call the stored proc to archive    
   EXEC Jobs_JobArchive @iCurrentRowId    
  
 -- did we get a valid next row id?    
   IF ISNULL(@iNextRowId,0) = 0    
   BEGIN    
 BREAK    
   END    
    
   --DEBUG    
   --SELECT @iCurrentRowId    
    
   -- get the next row.    
   SELECT  @iCurrentRowId = JobID    
   FROM    Jobs (NOLOCK)    
   WHERE   JobID = @iNextRowId                
    
 END    
 RETURN
GO
/****** Object:  StoredProcedure [dbo].[Jobs_Insert]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Jobs table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_Insert]
(

	@JobId int    OUTPUT,

	@SiteId int   ,

	@WorkTypeId int   ,

	@JobName nvarchar (510)  ,

	@Description nvarchar (2000)  ,

	@FullDescription nvarchar (MAX)  ,

	@WebServiceProcessed bit   ,

	@ApplicationEmailAddress varchar (255)  ,

	@RefNo varchar (255)  ,

	@Visible bit   ,

	@DatePosted smalldatetime   ,

	@ExpiryDate smalldatetime   ,

	@Expired int   ,

	@JobItemPrice money   ,

	@Billed bit   ,

	@LastModified datetime   ,

	@ShowSalaryDetails bit   ,

	@SalaryText varchar (500)  ,

	@AdvertiserId int   ,

	@LastModifiedByAdvertiserUserId int   ,

	@LastModifiedByAdminUserId int   ,

	@JobItemTypeId int   ,

	@ApplicationMethod int   ,

	@ApplicationUrl varchar (8000)  ,

	@UploadMethod int   ,

	@Tags text   ,

	@JobTemplateId int   ,

	@SearchFieldExtension varchar (8)  ,

	@AdvertiserJobTemplateLogoId int   ,

	@CompanyName varchar (255)  ,

	@HashValue varbinary (MAX)  ,

	@RequireLogonForExternalApplications bit   ,

	@ShowLocationDetails bit   ,

	@PublicTransport nvarchar (500)  ,

	@Address varchar (255)  ,

	@ContactDetails nvarchar (510)  ,

	@JobContactPhone varchar (50)  ,

	@JobContactName varchar (255)  ,

	@QualificationsRecognised bit   ,

	@ResidentOnly bit   ,

	@DocumentLink varchar (255)  ,

	@BulletPoint1 nvarchar (160)  ,

	@BulletPoint2 nvarchar (160)  ,

	@BulletPoint3 nvarchar (160)  ,

	@HotJob bit   ,

	@JobFriendlyName varchar (512)  ,

	@SearchField nvarchar (MAX)  ,

	@ShowSalaryRange bit   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@EnteredByAdvertiserUserId int   ,

	@JobLatitude float   ,

	@JobLongitude float   ,

	@AddressStatus int   ,

	@JobExternalId varchar (50)  ,

	@ScreeningQuestionsTemplateId int   
)
AS


				
				INSERT INTO [dbo].[Jobs]
					(
					[SiteID]
					,[WorkTypeID]
					,[JobName]
					,[Description]
					,[FullDescription]
					,[WebServiceProcessed]
					,[ApplicationEmailAddress]
					,[RefNo]
					,[Visible]
					,[DatePosted]
					,[ExpiryDate]
					,[Expired]
					,[JobItemPrice]
					,[Billed]
					,[LastModified]
					,[ShowSalaryDetails]
					,[SalaryText]
					,[AdvertiserID]
					,[LastModifiedByAdvertiserUserId]
					,[LastModifiedByAdminUserId]
					,[JobItemTypeID]
					,[ApplicationMethod]
					,[ApplicationURL]
					,[UploadMethod]
					,[Tags]
					,[JobTemplateID]
					,[SearchFieldExtension]
					,[AdvertiserJobTemplateLogoID]
					,[CompanyName]
					,[HashValue]
					,[RequireLogonForExternalApplications]
					,[ShowLocationDetails]
					,[PublicTransport]
					,[Address]
					,[ContactDetails]
					,[JobContactPhone]
					,[JobContactName]
					,[QualificationsRecognised]
					,[ResidentOnly]
					,[DocumentLink]
					,[BulletPoint1]
					,[BulletPoint2]
					,[BulletPoint3]
					,[HotJob]
					,[JobFriendlyName]
					,[SearchField]
					,[ShowSalaryRange]
					,[SalaryLowerBand]
					,[SalaryUpperBand]
					,[CurrencyID]
					,[SalaryTypeID]
					,[EnteredByAdvertiserUserID]
					,[JobLatitude]
					,[JobLongitude]
					,[AddressStatus]
					,[JobExternalId]
					,[ScreeningQuestionsTemplateId]
					)
				VALUES
					(
					@SiteId
					,@WorkTypeId
					,@JobName
					,@Description
					,@FullDescription
					,@WebServiceProcessed
					,@ApplicationEmailAddress
					,@RefNo
					,@Visible
					,@DatePosted
					,@ExpiryDate
					,@Expired
					,@JobItemPrice
					,@Billed
					,@LastModified
					,@ShowSalaryDetails
					,@SalaryText
					,@AdvertiserId
					,@LastModifiedByAdvertiserUserId
					,@LastModifiedByAdminUserId
					,@JobItemTypeId
					,@ApplicationMethod
					,@ApplicationUrl
					,@UploadMethod
					,@Tags
					,@JobTemplateId
					,@SearchFieldExtension
					,@AdvertiserJobTemplateLogoId
					,@CompanyName
					,@HashValue
					,@RequireLogonForExternalApplications
					,@ShowLocationDetails
					,@PublicTransport
					,@Address
					,@ContactDetails
					,@JobContactPhone
					,@JobContactName
					,@QualificationsRecognised
					,@ResidentOnly
					,@DocumentLink
					,@BulletPoint1
					,@BulletPoint2
					,@BulletPoint3
					,@HotJob
					,@JobFriendlyName
					,@SearchField
					,@ShowSalaryRange
					,@SalaryLowerBand
					,@SalaryUpperBand
					,@CurrencyId
					,@SalaryTypeId
					,@EnteredByAdvertiserUserId
					,@JobLatitude
					,@JobLongitude
					,@AddressStatus
					,@JobExternalId
					,@ScreeningQuestionsTemplateId
					)
				
				-- Get the identity value
				SET @JobId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetPaged]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Jobs table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetPaged]
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
				    [JobID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobID]'
				SET @SQL = @SQL + ' FROM [dbo].[Jobs]'
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
				SELECT O.[JobID], O.[SiteID], O.[WorkTypeID], O.[JobName], O.[Description], O.[FullDescription], O.[WebServiceProcessed], O.[ApplicationEmailAddress], O.[RefNo], O.[Visible], O.[DatePosted], O.[ExpiryDate], O.[Expired], O.[JobItemPrice], O.[Billed], O.[LastModified], O.[ShowSalaryDetails], O.[SalaryText], O.[AdvertiserID], O.[LastModifiedByAdvertiserUserId], O.[LastModifiedByAdminUserId], O.[JobItemTypeID], O.[ApplicationMethod], O.[ApplicationURL], O.[UploadMethod], O.[Tags], O.[JobTemplateID], O.[SearchFieldExtension], O.[AdvertiserJobTemplateLogoID], O.[CompanyName], O.[HashValue], O.[RequireLogonForExternalApplications], O.[ShowLocationDetails], O.[PublicTransport], O.[Address], O.[ContactDetails], O.[JobContactPhone], O.[JobContactName], O.[QualificationsRecognised], O.[ResidentOnly], O.[DocumentLink], O.[BulletPoint1], O.[BulletPoint2], O.[BulletPoint3], O.[HotJob], O.[JobFriendlyName], O.[SearchField], O.[ShowSalaryRange], O.[SalaryLowerBand], O.[SalaryUpperBand], O.[CurrencyID], O.[SalaryTypeID], O.[EnteredByAdvertiserUserID], O.[JobLatitude], O.[JobLongitude], O.[AddressStatus], O.[JobExternalId], O.[ScreeningQuestionsTemplateId]
				FROM
				    [dbo].[Jobs] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobID] = PageIndex.[JobID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Jobs]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate]
(

	@WorkTypeId int   ,

	@JobId int   ,

	@AdvertiserId int   ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@Expired int   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[WorkTypeID] = @WorkTypeId
					AND [JobID] = @JobId
					AND [AdvertiserID] = @AdvertiserId
					AND [CurrencyID] = @CurrencyId
					AND [SalaryTypeID] = @SalaryTypeId
					AND [SalaryLowerBand] = @SalaryLowerBand
					AND [SalaryUpperBand] = @SalaryUpperBand
					AND [Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByWorkTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByWorkTypeId]
(

	@WorkTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[WorkTypeID] = @WorkTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId]
(

	@SiteId int   ,

	@Expired int   ,

	@Billed bit   ,

	@AdvertiserId int   ,

	@EnteredByAdvertiserUserId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[SiteID] = @SiteId
					AND [Expired] = @Expired
					AND [Billed] = @Billed
					AND [AdvertiserID] = @AdvertiserId
					AND [EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetBySiteIdBilledAdvertiserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetBySiteIdBilledAdvertiserId]
(

	@SiteId int   ,

	@Billed bit   ,

	@AdvertiserId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[SiteID] = @SiteId
					AND [Billed] = @Billed
					AND [AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetBySiteId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByScreeningQuestionsTemplateId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByScreeningQuestionsTemplateId]
(

	@ScreeningQuestionsTemplateId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetBySalaryTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetBySalaryTypeId]
(

	@SalaryTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[SalaryTypeID] = @SalaryTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByLastModifiedByAdvertiserUserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByLastModifiedByAdvertiserUserId]
(

	@LastModifiedByAdvertiserUserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByLastModifiedByAdminUserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByLastModifiedByAdminUserId]
(

	@LastModifiedByAdminUserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[LastModifiedByAdminUserId] = @LastModifiedByAdminUserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByJobTemplateId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByJobTemplateId]
(

	@JobTemplateId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[JobTemplateID] = @JobTemplateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByJobItemTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByJobItemTypeId]
(

	@JobItemTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
				FROM
					[dbo].[Jobs]
				WHERE
					[JobItemTypeID] = @JobItemTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByJobIdWithArchive]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetByJobIdWithArchive]
(  
 @JobId int     
)  
AS  
  
IF NOT EXISTS(SELECT 1 FROM Jobs(NOLOCK) Where [JobID] = @JobId)
 Begin  
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
    FROM  
     [dbo].[JobsArchive] (NOLOCK)  
    WHERE  
     [JobID] = @JobId  
    SELECT @@ROWCOUNT
 END  
 ELSE
	BEGIN

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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
		FROM  
		 [dbo].[Jobs] (NOLOCK)  
		WHERE  
		 [JobID] = @JobId  
	
END

IF USER_NAME() IS NULL
BEGIN
  SELECT  [JobID],
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
					
	FROM [dbo].[Jobs] (NOLOCK) WHERE 1=0
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByJobId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByJobId]
(

	@JobId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[JobID] = @JobId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId]
(

	@Expired bit   ,

	@ExpiryDate smalldatetime   ,

	@AdvertiserId int   ,

	@CurrencyId int   ,

	@SalaryUpperBand numeric (15, 2)  ,

	@SalaryLowerBand numeric (15, 2)  ,

	@WorkTypeId int   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
				FROM
					[dbo].[Jobs] (NOLOCK)
				WHERE
					[Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
					AND [AdvertiserID] = @AdvertiserId
					AND [CurrencyID] = @CurrencyId
					AND [SalaryUpperBand] = @SalaryUpperBand
					AND [SalaryLowerBand] = @SalaryLowerBand
					AND [WorkTypeID] = @WorkTypeId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByExpiredExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByExpiredExpiryDate]
(

	@Expired int   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByExpiredBilledExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByExpiredBilledExpiryDate]
(

	@Expired int   ,

	@Billed bit   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[Expired] = @Expired
					AND [Billed] = @Billed
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByExpiredAdvertiserIdExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByExpiredAdvertiserIdExpiryDate]
(

	@Expired int   ,

	@AdvertiserId int   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[Expired] = @Expired
					AND [AdvertiserID] = @AdvertiserId
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByCurrencyId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByCurrencyId]
(

	@CurrencyId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[CurrencyID] = @CurrencyId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate]
(

	@AdvertiserId int   ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@WorkTypeId int   ,

	@Expired bit   ,

	@ExpiryDate smalldatetime   
)
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID]
				FROM
					[dbo].[Jobs] (NOLOCK)
				WHERE
					[AdvertiserID] = @AdvertiserId
					AND [CurrencyID] = @CurrencyId
					AND [SalaryTypeID] = @SalaryTypeId
					AND [SalaryLowerBand] = @SalaryLowerBand
					AND [SalaryUpperBand] = @SalaryUpperBand
					AND [WorkTypeID] = @WorkTypeId
					AND [Expired] = @Expired
					AND [ExpiryDate] = @ExpiryDate
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetByAdvertiserId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Jobs table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SET ANSI_NULLS OFF
				
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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
				WHERE
					[AdvertiserID] = @AdvertiserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetArchivedJobs]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetArchivedJobs]      
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
  SET @SQL = @SQL + ', [JobFriendlyName]'            
  SET @SQL = @SQL + ', [RefNo]'      
  SET @SQL = @SQL + ', [Views] = (SELECT COUNT(*) FROM JobViews jv WHERE jv.JobID = j.JobId)'      
  SET @SQL = @SQL + ', [Applications] = (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobId AND ISNULL(ja.Draft,0) = 0)'      
  SET @SQL = @SQL + ', [DatePosted]'   
  SET @SQL = @SQL + ', [ShowSalaryRange]'     
  SET @SQL = @SQL + ', [ExpiryDate] FROM [dbo].[JobsArchive] j WITH (NOLOCK)'      
  
 IF LEN(@WhereClause) > 0      
  BEGIN      
   SET @SQL = @SQL + ' WHERE ' + @WhereClause      
  END      
  SET @SQL = @SQL + ' ) SELECT'      
  SET @SQL = @SQL + ' [JobID]'      
  SET @SQL = @SQL + ', [JobName]'
  SET @SQL = @SQL + ', [JobFriendlyName]'
  SET @SQL = @SQL + ', (SELECT TOP 1 SiteProfessionFriendlyUrl FROM JobRoles jr INNER JOIN Roles r ON jr.RoleID = r.RoleID INNER JOIN SiteProfession sp ON sp.ProfessionID = r.ProfessionID WHERE jr.JobArchiveID = PageIndex.JobID ) AS SiteProfessionFriendlyUrl'         
  SET @SQL = @SQL + ', [RefNo]'      
  SET @SQL = @SQL + ', [Views]'      
  SET @SQL = @SQL + ', [Applications]'      
  SET @SQL = @SQL + ', [DatePosted]'  
  SET @SQL = @SQL + ', [ShowSalaryRange]'      
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
   SELECT [JobID], [JobName], [RefNo], [DatePosted], [ShowSalaryRange]  
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
GO
/****** Object:  StoredProcedure [dbo].[Jobs_Get_List]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Jobs table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_Get_List]

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
					[SalaryText],
					[AdvertiserID],
					[LastModifiedByAdvertiserUserId],
					[LastModifiedByAdminUserId],
					[JobItemTypeID],
					[ApplicationMethod],
					[ApplicationURL],
					[UploadMethod],
					[Tags],
					[JobTemplateID],
					[SearchFieldExtension],
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
					[JobFriendlyName],
					[SearchField],
					[ShowSalaryRange],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[EnteredByAdvertiserUserID],
					[JobLatitude],
					[JobLongitude],
					[AddressStatus],
					[JobExternalId],
					[ScreeningQuestionsTemplateId]
				FROM
					[dbo].[Jobs]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Jobs_Find]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Jobs table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_Find]
(

	@SearchUsingOR bit   = null ,

	@JobId int   = null ,

	@SiteId int   = null ,

	@WorkTypeId int   = null ,

	@JobName nvarchar (510)  = null ,

	@Description nvarchar (2000)  = null ,

	@FullDescription nvarchar (MAX)  = null ,

	@WebServiceProcessed bit   = null ,

	@ApplicationEmailAddress varchar (255)  = null ,

	@RefNo varchar (255)  = null ,

	@Visible bit   = null ,

	@DatePosted smalldatetime   = null ,

	@ExpiryDate smalldatetime   = null ,

	@Expired int   = null ,

	@JobItemPrice money   = null ,

	@Billed bit   = null ,

	@LastModified datetime   = null ,

	@ShowSalaryDetails bit   = null ,

	@SalaryText varchar (500)  = null ,

	@AdvertiserId int   = null ,

	@LastModifiedByAdvertiserUserId int   = null ,

	@LastModifiedByAdminUserId int   = null ,

	@JobItemTypeId int   = null ,

	@ApplicationMethod int   = null ,

	@ApplicationUrl varchar (8000)  = null ,

	@UploadMethod int   = null ,

	@Tags text   = null ,

	@JobTemplateId int   = null ,

	@SearchFieldExtension varchar (8)  = null ,

	@AdvertiserJobTemplateLogoId int   = null ,

	@CompanyName varchar (255)  = null ,

	@HashValue varbinary (MAX)  = null ,

	@RequireLogonForExternalApplications bit   = null ,

	@ShowLocationDetails bit   = null ,

	@PublicTransport nvarchar (500)  = null ,

	@Address varchar (255)  = null ,

	@ContactDetails nvarchar (510)  = null ,

	@JobContactPhone varchar (50)  = null ,

	@JobContactName varchar (255)  = null ,

	@QualificationsRecognised bit   = null ,

	@ResidentOnly bit   = null ,

	@DocumentLink varchar (255)  = null ,

	@BulletPoint1 nvarchar (160)  = null ,

	@BulletPoint2 nvarchar (160)  = null ,

	@BulletPoint3 nvarchar (160)  = null ,

	@HotJob bit   = null ,

	@JobFriendlyName varchar (512)  = null ,

	@SearchField nvarchar (MAX)  = null ,

	@ShowSalaryRange bit   = null ,

	@SalaryLowerBand numeric (15, 2)  = null ,

	@SalaryUpperBand numeric (15, 2)  = null ,

	@CurrencyId int   = null ,

	@SalaryTypeId int   = null ,

	@EnteredByAdvertiserUserId int   = null ,

	@JobLatitude float   = null ,

	@JobLongitude float   = null ,

	@AddressStatus int   = null ,

	@JobExternalId varchar (50)  = null ,

	@ScreeningQuestionsTemplateId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobID]
	, [SiteID]
	, [WorkTypeID]
	, [JobName]
	, [Description]
	, [FullDescription]
	, [WebServiceProcessed]
	, [ApplicationEmailAddress]
	, [RefNo]
	, [Visible]
	, [DatePosted]
	, [ExpiryDate]
	, [Expired]
	, [JobItemPrice]
	, [Billed]
	, [LastModified]
	, [ShowSalaryDetails]
	, [SalaryText]
	, [AdvertiserID]
	, [LastModifiedByAdvertiserUserId]
	, [LastModifiedByAdminUserId]
	, [JobItemTypeID]
	, [ApplicationMethod]
	, [ApplicationURL]
	, [UploadMethod]
	, [Tags]
	, [JobTemplateID]
	, [SearchFieldExtension]
	, [AdvertiserJobTemplateLogoID]
	, [CompanyName]
	, [HashValue]
	, [RequireLogonForExternalApplications]
	, [ShowLocationDetails]
	, [PublicTransport]
	, [Address]
	, [ContactDetails]
	, [JobContactPhone]
	, [JobContactName]
	, [QualificationsRecognised]
	, [ResidentOnly]
	, [DocumentLink]
	, [BulletPoint1]
	, [BulletPoint2]
	, [BulletPoint3]
	, [HotJob]
	, [JobFriendlyName]
	, [SearchField]
	, [ShowSalaryRange]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [EnteredByAdvertiserUserID]
	, [JobLatitude]
	, [JobLongitude]
	, [AddressStatus]
	, [JobExternalId]
	, [ScreeningQuestionsTemplateId]
    FROM
	[dbo].[Jobs]
    WHERE 
	 ([JobID] = @JobId OR @JobId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([WorkTypeID] = @WorkTypeId OR @WorkTypeId IS NULL)
	AND ([JobName] = @JobName OR @JobName IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([FullDescription] = @FullDescription OR @FullDescription IS NULL)
	AND ([WebServiceProcessed] = @WebServiceProcessed OR @WebServiceProcessed IS NULL)
	AND ([ApplicationEmailAddress] = @ApplicationEmailAddress OR @ApplicationEmailAddress IS NULL)
	AND ([RefNo] = @RefNo OR @RefNo IS NULL)
	AND ([Visible] = @Visible OR @Visible IS NULL)
	AND ([DatePosted] = @DatePosted OR @DatePosted IS NULL)
	AND ([ExpiryDate] = @ExpiryDate OR @ExpiryDate IS NULL)
	AND ([Expired] = @Expired OR @Expired IS NULL)
	AND ([JobItemPrice] = @JobItemPrice OR @JobItemPrice IS NULL)
	AND ([Billed] = @Billed OR @Billed IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([ShowSalaryDetails] = @ShowSalaryDetails OR @ShowSalaryDetails IS NULL)
	AND ([SalaryText] = @SalaryText OR @SalaryText IS NULL)
	AND ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId OR @LastModifiedByAdvertiserUserId IS NULL)
	AND ([LastModifiedByAdminUserId] = @LastModifiedByAdminUserId OR @LastModifiedByAdminUserId IS NULL)
	AND ([JobItemTypeID] = @JobItemTypeId OR @JobItemTypeId IS NULL)
	AND ([ApplicationMethod] = @ApplicationMethod OR @ApplicationMethod IS NULL)
	AND ([ApplicationURL] = @ApplicationUrl OR @ApplicationUrl IS NULL)
	AND ([UploadMethod] = @UploadMethod OR @UploadMethod IS NULL)
	AND ([JobTemplateID] = @JobTemplateId OR @JobTemplateId IS NULL)
	AND ([SearchFieldExtension] = @SearchFieldExtension OR @SearchFieldExtension IS NULL)
	AND ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId OR @AdvertiserJobTemplateLogoId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([RequireLogonForExternalApplications] = @RequireLogonForExternalApplications OR @RequireLogonForExternalApplications IS NULL)
	AND ([ShowLocationDetails] = @ShowLocationDetails OR @ShowLocationDetails IS NULL)
	AND ([PublicTransport] = @PublicTransport OR @PublicTransport IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([ContactDetails] = @ContactDetails OR @ContactDetails IS NULL)
	AND ([JobContactPhone] = @JobContactPhone OR @JobContactPhone IS NULL)
	AND ([JobContactName] = @JobContactName OR @JobContactName IS NULL)
	AND ([QualificationsRecognised] = @QualificationsRecognised OR @QualificationsRecognised IS NULL)
	AND ([ResidentOnly] = @ResidentOnly OR @ResidentOnly IS NULL)
	AND ([DocumentLink] = @DocumentLink OR @DocumentLink IS NULL)
	AND ([BulletPoint1] = @BulletPoint1 OR @BulletPoint1 IS NULL)
	AND ([BulletPoint2] = @BulletPoint2 OR @BulletPoint2 IS NULL)
	AND ([BulletPoint3] = @BulletPoint3 OR @BulletPoint3 IS NULL)
	AND ([HotJob] = @HotJob OR @HotJob IS NULL)
	AND ([JobFriendlyName] = @JobFriendlyName OR @JobFriendlyName IS NULL)
	AND ([SearchField] = @SearchField OR @SearchField IS NULL)
	AND ([ShowSalaryRange] = @ShowSalaryRange OR @ShowSalaryRange IS NULL)
	AND ([SalaryLowerBand] = @SalaryLowerBand OR @SalaryLowerBand IS NULL)
	AND ([SalaryUpperBand] = @SalaryUpperBand OR @SalaryUpperBand IS NULL)
	AND ([CurrencyID] = @CurrencyId OR @CurrencyId IS NULL)
	AND ([SalaryTypeID] = @SalaryTypeId OR @SalaryTypeId IS NULL)
	AND ([EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId OR @EnteredByAdvertiserUserId IS NULL)
	AND ([JobLatitude] = @JobLatitude OR @JobLatitude IS NULL)
	AND ([JobLongitude] = @JobLongitude OR @JobLongitude IS NULL)
	AND ([AddressStatus] = @AddressStatus OR @AddressStatus IS NULL)
	AND ([JobExternalId] = @JobExternalId OR @JobExternalId IS NULL)
	AND ([ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId OR @ScreeningQuestionsTemplateId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobID]
	, [SiteID]
	, [WorkTypeID]
	, [JobName]
	, [Description]
	, [FullDescription]
	, [WebServiceProcessed]
	, [ApplicationEmailAddress]
	, [RefNo]
	, [Visible]
	, [DatePosted]
	, [ExpiryDate]
	, [Expired]
	, [JobItemPrice]
	, [Billed]
	, [LastModified]
	, [ShowSalaryDetails]
	, [SalaryText]
	, [AdvertiserID]
	, [LastModifiedByAdvertiserUserId]
	, [LastModifiedByAdminUserId]
	, [JobItemTypeID]
	, [ApplicationMethod]
	, [ApplicationURL]
	, [UploadMethod]
	, [Tags]
	, [JobTemplateID]
	, [SearchFieldExtension]
	, [AdvertiserJobTemplateLogoID]
	, [CompanyName]
	, [HashValue]
	, [RequireLogonForExternalApplications]
	, [ShowLocationDetails]
	, [PublicTransport]
	, [Address]
	, [ContactDetails]
	, [JobContactPhone]
	, [JobContactName]
	, [QualificationsRecognised]
	, [ResidentOnly]
	, [DocumentLink]
	, [BulletPoint1]
	, [BulletPoint2]
	, [BulletPoint3]
	, [HotJob]
	, [JobFriendlyName]
	, [SearchField]
	, [ShowSalaryRange]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [EnteredByAdvertiserUserID]
	, [JobLatitude]
	, [JobLongitude]
	, [AddressStatus]
	, [JobExternalId]
	, [ScreeningQuestionsTemplateId]
    FROM
	[dbo].[Jobs]
    WHERE 
	 ([JobID] = @JobId AND @JobId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([WorkTypeID] = @WorkTypeId AND @WorkTypeId is not null)
	OR ([JobName] = @JobName AND @JobName is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([FullDescription] = @FullDescription AND @FullDescription is not null)
	OR ([WebServiceProcessed] = @WebServiceProcessed AND @WebServiceProcessed is not null)
	OR ([ApplicationEmailAddress] = @ApplicationEmailAddress AND @ApplicationEmailAddress is not null)
	OR ([RefNo] = @RefNo AND @RefNo is not null)
	OR ([Visible] = @Visible AND @Visible is not null)
	OR ([DatePosted] = @DatePosted AND @DatePosted is not null)
	OR ([ExpiryDate] = @ExpiryDate AND @ExpiryDate is not null)
	OR ([Expired] = @Expired AND @Expired is not null)
	OR ([JobItemPrice] = @JobItemPrice AND @JobItemPrice is not null)
	OR ([Billed] = @Billed AND @Billed is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([ShowSalaryDetails] = @ShowSalaryDetails AND @ShowSalaryDetails is not null)
	OR ([SalaryText] = @SalaryText AND @SalaryText is not null)
	OR ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([LastModifiedByAdvertiserUserId] = @LastModifiedByAdvertiserUserId AND @LastModifiedByAdvertiserUserId is not null)
	OR ([LastModifiedByAdminUserId] = @LastModifiedByAdminUserId AND @LastModifiedByAdminUserId is not null)
	OR ([JobItemTypeID] = @JobItemTypeId AND @JobItemTypeId is not null)
	OR ([ApplicationMethod] = @ApplicationMethod AND @ApplicationMethod is not null)
	OR ([ApplicationURL] = @ApplicationUrl AND @ApplicationUrl is not null)
	OR ([UploadMethod] = @UploadMethod AND @UploadMethod is not null)
	OR ([JobTemplateID] = @JobTemplateId AND @JobTemplateId is not null)
	OR ([SearchFieldExtension] = @SearchFieldExtension AND @SearchFieldExtension is not null)
	OR ([AdvertiserJobTemplateLogoID] = @AdvertiserJobTemplateLogoId AND @AdvertiserJobTemplateLogoId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([RequireLogonForExternalApplications] = @RequireLogonForExternalApplications AND @RequireLogonForExternalApplications is not null)
	OR ([ShowLocationDetails] = @ShowLocationDetails AND @ShowLocationDetails is not null)
	OR ([PublicTransport] = @PublicTransport AND @PublicTransport is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([ContactDetails] = @ContactDetails AND @ContactDetails is not null)
	OR ([JobContactPhone] = @JobContactPhone AND @JobContactPhone is not null)
	OR ([JobContactName] = @JobContactName AND @JobContactName is not null)
	OR ([QualificationsRecognised] = @QualificationsRecognised AND @QualificationsRecognised is not null)
	OR ([ResidentOnly] = @ResidentOnly AND @ResidentOnly is not null)
	OR ([DocumentLink] = @DocumentLink AND @DocumentLink is not null)
	OR ([BulletPoint1] = @BulletPoint1 AND @BulletPoint1 is not null)
	OR ([BulletPoint2] = @BulletPoint2 AND @BulletPoint2 is not null)
	OR ([BulletPoint3] = @BulletPoint3 AND @BulletPoint3 is not null)
	OR ([HotJob] = @HotJob AND @HotJob is not null)
	OR ([JobFriendlyName] = @JobFriendlyName AND @JobFriendlyName is not null)
	OR ([SearchField] = @SearchField AND @SearchField is not null)
	OR ([ShowSalaryRange] = @ShowSalaryRange AND @ShowSalaryRange is not null)
	OR ([SalaryLowerBand] = @SalaryLowerBand AND @SalaryLowerBand is not null)
	OR ([SalaryUpperBand] = @SalaryUpperBand AND @SalaryUpperBand is not null)
	OR ([CurrencyID] = @CurrencyId AND @CurrencyId is not null)
	OR ([SalaryTypeID] = @SalaryTypeId AND @SalaryTypeId is not null)
	OR ([EnteredByAdvertiserUserID] = @EnteredByAdvertiserUserId AND @EnteredByAdvertiserUserId is not null)
	OR ([JobLatitude] = @JobLatitude AND @JobLatitude is not null)
	OR ([JobLongitude] = @JobLongitude AND @JobLongitude is not null)
	OR ([AddressStatus] = @AddressStatus AND @AddressStatus is not null)
	OR ([JobExternalId] = @JobExternalId AND @JobExternalId is not null)
	OR ([ScreeningQuestionsTemplateId] = @ScreeningQuestionsTemplateId AND @ScreeningQuestionsTemplateId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_Delete]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Jobs table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[Jobs_Delete]
(

	@JobId int   
)
AS


				DELETE FROM [dbo].[Jobs] WITH (ROWLOCK) 
				WHERE
					[JobID] = @JobId
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomGetJobByExternalJobId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomGetJobByExternalJobId]     
(    
 @SiteId INT,  
 @AdvertiserId INT,  
 @ExternalJobId varchar(50)  
)    
AS    
BEGIN   
  
DECLARE @JobId INT = 0  
DECLARE @Expired INT = 0  
DECLARE @ExpiryDate smalldatetime = NULL  
DECLARE @JobArchiveId INT = 0  
  
;WITH _TempJobs  
AS  
(  
 Select JobId, Expired, ExpiryDate, JobExternalId FROM Jobs WITH (NOLOCK)  
 WHERE   
  SiteID = @SiteId   
  AND AdvertiserID = @AdvertiserId  
  --Jobs.Expired = 0   
  -- AND Jobs.ExpiryDate >= GETDATE()   
     
)  
  
Select @JobId = JobID, @Expired = Expired, @ExpiryDate = ExpiryDate from _TempJobs WITH (NOLOCK) WHERE JobExternalId = @ExternalJobId  
  
  
IF (ISNULL(@JobId,0) = 0)  
BEGIN  
 ;WITH _TempJobs  
 AS  
 (  
  Select   
   JobId, JobExternalId FROM JobsArchive WITH (NOLOCK)   
  WHERE   
   SiteID = @SiteId AND AdvertiserID = @AdvertiserId  
 )  
  
 Select @JobArchiveId = JobID from _TempJobs WITH (NOLOCK) WHERE JobExternalId = @ExternalJobId  
  
END  
  
Select @JobId as JobId, @Expired as Expired, @ExpiryDate as ExpiryDate, @JobArchiveId as JobArchiveId  
  
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomGetGeoAddressToUpdate]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomGetGeoAddressToUpdate]                             
AS       
BEGIN       

DECLARE @ADDRESS_IS_VALID INT = 1
DECLARE @ADDRESS_IN_QUEUE INT = 2

-- Get the Address in Queue
DECLARE @tmpAddress TABLE ([Address] Varchar(255),JobLatitude float, JobLongitude float, AddressStatus INT)   
INSERT INTO @tmpAddress([Address], JobLatitude, JobLongitude, AddressStatus)  
Select [Address], NULL, NULL, @ADDRESS_IN_QUEUE  -- QUEUE
FROM Jobs (NOLOCK) INNER JOIN Integrations (NOLOCK) ON Jobs.SiteID = Integrations.SiteID
WHERE 
	Jobs.Expired = 0 AND      
	Jobs.ExpiryDate >= GETDATE() AND
	Integrations.Valid = 1 AND 
	IntegrationType = 10 -- ONLY Google Map Type
	AND (Jobs.AddressStatus = @ADDRESS_IN_QUEUE OR Jobs.AddressStatus IS NULL)  -- Only in Queue
GROUP By [Address]

-- Get valid address from Jobs and Archive table
;WITH TempAddressTable 
AS
(
SELECT [Address], JobLatitude, JobLongitude FROM
(
SELECT [Address], JobLatitude, JobLongitude FROM Jobs (NOLOCK) where AddressStatus = @ADDRESS_IS_VALID
UNION 
SELECT [Address], JobLatitude, JobLongitude FROM JobsArchive (NOLOCK) where AddressStatus = @ADDRESS_IS_VALID
) _Job 
GROUP BY [Address], JobLatitude, JobLongitude
)	

-- Update to the temp table which 
UPDATE
    _TempAddress
SET
    _TempAddress.JobLatitude = OT.JobLatitude,
    _TempAddress.JobLongitude = OT.JobLongitude,
    _TempAddress.AddressStatus = @ADDRESS_IS_VALID
FROM
    @tmpAddress _TempAddress
INNER JOIN
    TempAddressTable OT (NOLOCK)
ON
    _TempAddress.[Address] = OT.[Address]
	

--Select * from @tmpAddress

-- Update the Jobs which are in the queue
UPDATE
    Jobs
SET
    Jobs.JobLatitude = _TempAddress.JobLatitude,
    Jobs.JobLongitude = _TempAddress.JobLongitude,
    Jobs.AddressStatus = @ADDRESS_IS_VALID
FROM
    @tmpAddress _TempAddress
INNER JOIN Jobs (NOLOCK) ON _TempAddress.[Address] = Jobs.[Address]
INNER JOIN Integrations (NOLOCK) ON Jobs.SiteID = Integrations.SiteID AND Integrations.Valid = 1 AND IntegrationType = 10 -- ONLY Google Map Type
	WHERE  (Jobs.AddressStatus = @ADDRESS_IN_QUEUE OR Jobs.AddressStatus IS NULL)	-- Jobs Address in the Queue
	AND _TempAddress.AddressStatus = @ADDRESS_IS_VALID		-- Only update valid address found

-- Get the Address which are in the queue
Select [Address], Integrations.JSONText  --JobID, Jobs.SiteID, JobLatitude, JobLongitude,
	FROM Jobs (NOLOCK) INNER JOIN Integrations (NOLOCK) ON Jobs.SiteID = Integrations.SiteID
WHERE 
	Jobs.Expired = 0 
	 AND Jobs.ExpiryDate >= GETDATE() 
	 AND Integrations.Valid = 1 
	 AND IntegrationType = 10 -- ONLY Google Map Type
	 AND (Jobs.AddressStatus = @ADDRESS_IN_QUEUE OR Jobs.AddressStatus IS NULL)		-- ONLY Address in the QUEUE
GROUP BY [Address], Integrations.JSONText	--JobID, Jobs.SiteID, JobLatitude, JobLongitude,
    
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomGetBySiteIdStatusIDs]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomGetBySiteIdStatusIDs]
(
	@SiteId int,
	@StatusIDs VARCHAR(50),      
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
         
  SET @WhereClause = ' SiteID = ' + CONVERT(varchar, @SiteId)          
  PRINT @WhereClause
  IF LEN(@StatusIDs) > 0
  BEGIN
	SET @WhereClause = @WhereClause + ' AND Expired IN (' + @StatusIDs + ') '
  END

 If @inError <> 0          
  Return          
          
 -- SQL Server 2005 Paging          
 DECLARE @SQL AS nvarchar(MAX)          
 SET @SQL = 'WITH PageIndex AS ('          
SET @SQL = @SQL + 'SELECT'
SET @SQL = @SQL + '[JobID],'
SET @SQL = @SQL + '[SiteID],'
SET @SQL = @SQL + '[WorkTypeID],'
SET @SQL = @SQL + '[JobName],'
SET @SQL = @SQL + '[Description],'
SET @SQL = @SQL + '[FullDescription],'
SET @SQL = @SQL + '[WebServiceProcessed],'
SET @SQL = @SQL + '[ApplicationEmailAddress],'
SET @SQL = @SQL + '[RefNo],'
SET @SQL = @SQL + '[Visible],'
SET @SQL = @SQL + '[DatePosted],'
SET @SQL = @SQL + '[ExpiryDate],'
SET @SQL = @SQL + '[Expired],'
SET @SQL = @SQL + '[JobItemPrice],'
SET @SQL = @SQL + '[Billed],'
SET @SQL = @SQL + '[LastModified],'
SET @SQL = @SQL + '[ShowSalaryDetails],'
SET @SQL = @SQL + '[SalaryText],'
SET @SQL = @SQL + '[AdvertiserID],'
SET @SQL = @SQL + '[LastModifiedByAdvertiserUserId],'
SET @SQL = @SQL + '[LastModifiedByAdminUserId],'
SET @SQL = @SQL + '[JobItemTypeID],'
SET @SQL = @SQL + '[ApplicationMethod],'
SET @SQL = @SQL + '[ApplicationURL],'
SET @SQL = @SQL + '[UploadMethod],'
SET @SQL = @SQL + '[Tags],'
SET @SQL = @SQL + '[JobTemplateID],'
SET @SQL = @SQL + '[SearchFieldExtension],'
SET @SQL = @SQL + '[AdvertiserJobTemplateLogoID],'
SET @SQL = @SQL + '[CompanyName],'
SET @SQL = @SQL + '[HashValue],'
SET @SQL = @SQL + '[RequireLogonForExternalApplications],'
SET @SQL = @SQL + '[ShowLocationDetails],'
SET @SQL = @SQL + '[PublicTransport],'
SET @SQL = @SQL + '[Address],'
SET @SQL = @SQL + '[ContactDetails],'
SET @SQL = @SQL + '[JobContactPhone],'
SET @SQL = @SQL + '[JobContactName],'
SET @SQL = @SQL + '[QualificationsRecognised],'
SET @SQL = @SQL + '[ResidentOnly],'
SET @SQL = @SQL + '[DocumentLink],'
SET @SQL = @SQL + '[BulletPoint1],'
SET @SQL = @SQL + '[BulletPoint2],'
SET @SQL = @SQL + '[BulletPoint3],'
SET @SQL = @SQL + '[HotJob],'
SET @SQL = @SQL + '[JobFriendlyName],'
SET @SQL = @SQL + '[SearchField],'
SET @SQL = @SQL + '[ShowSalaryRange],'
SET @SQL = @SQL + '[SalaryLowerBand],'
SET @SQL = @SQL + '[SalaryUpperBand],'
SET @SQL = @SQL + '[CurrencyID],'
SET @SQL = @SQL + '[SalaryTypeID],'
SET @SQL = @SQL + '[EnteredByAdvertiserUserID]'
SET @SQL = @SQL + 'FROM'
SET @SQL = @SQL + '[dbo].[Jobs]'       
 IF LEN(@WhereClause) > 0          
 BEGIN          
  SET @SQL = @SQL + ' WHERE ' + @WhereClause          
 END          
 SET @SQL = @SQL + ' ), PageIndex2 AS ( SELECT *, ROW_NUMBER() OVER ('      
 SET @SQL = @SQL + ' ORDER BY ' + @OrderBy      
 SET @SQL = @SQL + ') as RowIndex FROM PageIndex)'      
             
SET @SQL = @SQL + 'SELECT'
SET @SQL = @SQL + '[JobID],'
SET @SQL = @SQL + '[SiteID],'
SET @SQL = @SQL + '[WorkTypeID],'
SET @SQL = @SQL + '[JobName],'
SET @SQL = @SQL + '[Description],'
SET @SQL = @SQL + '[FullDescription],'
SET @SQL = @SQL + '[WebServiceProcessed],'
SET @SQL = @SQL + '[ApplicationEmailAddress],'
SET @SQL = @SQL + '[RefNo],'
SET @SQL = @SQL + '[Visible],'
SET @SQL = @SQL + '[DatePosted],'
SET @SQL = @SQL + '[ExpiryDate],'
SET @SQL = @SQL + '[Expired],'
SET @SQL = @SQL + '[JobItemPrice],'
SET @SQL = @SQL + '[Billed],'
SET @SQL = @SQL + '[LastModified],'
SET @SQL = @SQL + '[ShowSalaryDetails],'
SET @SQL = @SQL + '[SalaryText],'
SET @SQL = @SQL + '[AdvertiserID],'
SET @SQL = @SQL + '[LastModifiedByAdvertiserUserId],'
SET @SQL = @SQL + '[LastModifiedByAdminUserId],'
SET @SQL = @SQL + '[JobItemTypeID],'
SET @SQL = @SQL + '[ApplicationMethod],'
SET @SQL = @SQL + '[ApplicationURL],'
SET @SQL = @SQL + '[UploadMethod],'
SET @SQL = @SQL + '[Tags],'
SET @SQL = @SQL + '[JobTemplateID],'
SET @SQL = @SQL + '[SearchFieldExtension],'
SET @SQL = @SQL + '[AdvertiserJobTemplateLogoID],'
SET @SQL = @SQL + '[CompanyName],'
SET @SQL = @SQL + '[HashValue],'
SET @SQL = @SQL + '[RequireLogonForExternalApplications],'
SET @SQL = @SQL + '[ShowLocationDetails],'
SET @SQL = @SQL + '[PublicTransport],'
SET @SQL = @SQL + '[Address],'
SET @SQL = @SQL + '[ContactDetails],'
SET @SQL = @SQL + '[JobContactPhone],'
SET @SQL = @SQL + '[JobContactName],'
SET @SQL = @SQL + '[QualificationsRecognised],'
SET @SQL = @SQL + '[ResidentOnly],'
SET @SQL = @SQL + '[DocumentLink],'
SET @SQL = @SQL + '[BulletPoint1],'
SET @SQL = @SQL + '[BulletPoint2],'
SET @SQL = @SQL + '[BulletPoint3],'
SET @SQL = @SQL + '[HotJob],'
SET @SQL = @SQL + '[JobFriendlyName],'
SET @SQL = @SQL + '[SearchField],'
SET @SQL = @SQL + '[ShowSalaryRange],'
SET @SQL = @SQL + '[SalaryLowerBand],'
SET @SQL = @SQL + '[SalaryUpperBand],'
SET @SQL = @SQL + '[CurrencyID],'
SET @SQL = @SQL + '[SalaryTypeID],'
SET @SQL = @SQL + '[EnteredByAdvertiserUserID]'
SET @SQL = @SQL + 'FROM PageIndex2'          
SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(varchar, @PageLowerBound)          
 IF @PageSize > 0          
 BEGIN          
  SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(varchar, @PageUpperBound)          
 END          
           
 EXEC sp_executesql @SQL      
          
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
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetAdvertiserJobs]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetAdvertiserJobs]                
(                
 @SiteId int,                
 @AdvertiserId int,              
 @EnteredByAdvertiserUserID int,                
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
               
 DECLARE @PrimaryAccount BIT               
 SET @PrimaryAccount = 0              
               
 SET @PrimaryAccount = (SELECT PrimaryAccount FROM AdvertiserUsers WHERE AdvertiserUserID = @EnteredByAdvertiserUserID)              
 IF @EnteredByAdvertiserUserID = 0              
 BEGIN              
 SET @PrimaryAccount = 1              
 END              
                 
 IF (@Type = 'Current' OR @Type = 'Live')    
 BEGIN                
  SET @WhereClause = '(Expired = NULL OR Expired = 0)'                
  SET @WhereClause = @WhereClause + ' AND SiteID = ' + CONVERT(varchar, @SiteId)                
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND GETDATE() >= dbo.fnGetDate(DatePosted)'                
  SET @WhereClause = @WhereClause + ' AND GETDATE() <= DATEADD(DAY, 1, dbo.fnGetDate(ExpiryDate))'                  
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END              
                
 END                
 ELSE IF @Type = 'Draft'                
 BEGIN                
  SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)                
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND Expired = 3'              
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END                
 END      
 ELSE IF @Type = 'Pending'                
 BEGIN                
  SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)                
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND Expired = 2'              
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END                
 END      
 ELSE IF @Type = 'Declined'                
 BEGIN                
  SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)                
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND Expired = 4'              
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END                
 END               
 ELSE IF @Type = 'PendingAndDeclined'                
 BEGIN                
  SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)               
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND (Expired = 2 OR Expired = 4)' -- Pending, Declined    
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END                
 END    
 ELSE IF @Type = 'Suspended'                
 BEGIN                
  SET @WhereClause = 'SiteID = ' + CONVERT(varchar, @SiteId)                
  SET @WhereClause = @WhereClause + ' AND AdvertiserID = ' + CONVERT(varchar, @AdvertiserId)                
  SET @WhereClause = @WhereClause + ' AND Expired = 5'              
  IF ISNULL(@PrimaryAccount, 0) = 0              
  BEGIN              
 SET @WhereClause = @WhereClause + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)                
  END                
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
 --IF @PageSize > 0                
 --BEGIN                
 -- SET @SQL = @SQL + ' TOP ' + CONVERT(varchar, @PageUpperBound)                
 --END                
 -- SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY JobID DESC) as RowIndex'                
 SET @SQL = @SQL + ' [JobID]'                
 SET @SQL = @SQL + ', [JobName]'                
 SET @SQL = @SQL + ', [JobFriendlyName]'                
 SET @SQL = @SQL + ', [RefNo]'                
 SET @SQL = @SQL + ', (SELECT SUM(TotalView) FROM JobViews jv WHERE jv.JobID = j.JobId) AS [Views]'                
 SET @SQL = @SQL + ', (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobId AND ISNULL(Draft,0) = 0) AS [Applications]'                
 SET @SQL = @SQL + ', [DatePosted]'                
 SET @SQL = @SQL + ', [ShowSalaryRange]'                
 SET @SQL = @SQL + ', [ExpiryDate], [Expired], JobItemTypeID, [EnteredByAdvertiserUserID] FROM [dbo].[Jobs] j WITH (NOLOCK)'                
 IF LEN(@WhereClause) > 0                
 BEGIN                
  SET @SQL = @SQL + ' WHERE ' + @WhereClause                
 END                
 SET @SQL = @SQL + ' ), PageIndex2 AS ( SELECT *, ROW_NUMBER() OVER ('            
 SET @SQL = @SQL + ' ORDER BY ' + @OrderBy            
 SET @SQL = @SQL + ') as RowIndex FROM PageIndex)'            
             
 SET @SQL = @SQL + 'SELECT'                
 SET @SQL = @SQL + ' [JobID]'                
 SET @SQL = @SQL + ', [JobName]'                
 SET @SQL = @SQL + ', [JobFriendlyName]'                
 SET @SQL = @SQL + ', (SELECT TOP 1 SiteProfessionFriendlyUrl FROM JobRoles jr INNER JOIN Roles r ON jr.RoleID = r.RoleID INNER JOIN SiteProfession sp ON sp.ProfessionID = r.ProfessionID WHERE jr.JobID = PageIndex2.JobID AND sp.SiteId = ' + CONVERT(varchar, @SiteId) + ') AS SiteProfessionFriendlyUrl'  
   
 SET @SQL = @SQL + ', [RefNo]'                
 SET @SQL = @SQL + ', [Views]'                
 SET @SQL = @SQL + ', [Applications]'                
 SET @SQL = @SQL + ', [DatePosted]'                
 SET @SQL = @SQL + ', [ShowSalaryRange]'                
 SET @SQL = @SQL + ', [ExpiryDate], [Expired], JobItemTypeID, [EnteredByAdvertiserUserID] FROM PageIndex2'                
 SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(varchar, @PageLowerBound)                
 IF @PageSize > 0                
 BEGIN                
  SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(varchar, @PageUpperBound)                
 END                
                 
 EXEC sp_executesql @SQL                
                 
 IF USER_NAME() IS NULL                
  BEGIN                
   SELECT [JobID], [JobName], [RefNo], [JobFriendlyName], [DatePosted], [ShowSalaryRange]                
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
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Update]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  
----------------------------------------------------------------------------------------------------  
  
-- Created By:  ()  
-- Purpose: Updates a record in the GlobalSettings table  
----------------------------------------------------------------------------------------------------  
*/  
  
  
ALTER PROCEDURE [dbo].[GlobalSettings_Update]  
(  
  
 @GlobalSettingId int   ,  
  
 @SiteId int   ,  
  
 @DefaultLanguageId int   ,  
  
 @DefaultDynamicPageId int   ,  
  
 @PublicJobsSearch bit   ,  
  
 @PublicMembersSearch bit   ,  
  
 @PublicCompaniesSearch bit   ,  
  
 @PublicSponsoredAdverts bit   ,  
  
 @PrivateJobs bit   ,  
  
 @PrivateMembers bit   ,  
  
 @PrivateCompanies bit   ,  
  
 @LastModifiedBy int   ,  
  
 @LastModified datetime   ,  
  
 @PageTitlePrefix nvarchar (510)  ,  
  
 @PageTitleSuffix nvarchar (510)  ,  
  
 @DefaultTitle nvarchar (510)  ,  
  
 @HomeTitle nvarchar (510)  ,  
  
 @DefaultDescription nvarchar (510)  ,  
  
 @HomeDescription nvarchar (510)  ,  
  
 @DefaultKeywords nvarchar (510)  ,  
  
 @HomeKeywords nvarchar (510)  ,  
  
 @ShowFaceBookButton bit   ,  
  
 @UseAdvertiserFilter int   ,  
  
 @MerchantId int   ,  
  
 @ShowTwitterButton bit   ,  
  
 @ShowJobAlertButton bit   ,  
  
 @ShowLinkedInButton bit   ,  
  
 @SiteFavIconId int   ,  
  
 @SiteDocType varchar (512)  ,  
  
 @CurrencySymbol varchar (10)  ,  
  
 @FtpFolderLocation varchar (255)  ,  
  
 @MetaTags nvarchar (MAX)  ,  
  
 @SystemMetaTags nvarchar (4000)  ,  
  
 @MemberRegistrationNotification varchar (255)  ,  
  
 @LinkedInApi varchar (255)  ,  
  
 @LinkedInLogo varchar (255)  ,  
  
 @LinkedInCompanyId int   ,  
  
 @LinkedInEmail varchar (255)  ,  
  
 @PrivacySettings nvarchar (4000)  ,  
  
 @WwwRedirect bit   ,  
  
 @AllowAdvertiser bit   ,  
  
 @LinkedInApiSecret varchar (255)  ,  
  
 @GoogleClientId varchar (255)  ,  
  
 @GoogleClientSecret varchar (255)  ,  
  
 @FacebookAppId varchar (255)  ,  
  
 @FacebookAppSecret varchar (255)  ,  
  
 @LinkedInButtonSize int   ,  
  
 @DefaultCountryId int   ,  
  
 @PayPalUsername varchar (100)  ,  
  
 @PayPalPassword varchar (100)  ,  
  
 @PayPalSignature varchar (100)  ,  
  
 @SecurePayMerchantId varchar (100)  ,  
  
 @SecurePayPassword varchar (100)  ,  
  
 @UsingSsl bit   ,  
  
 @UseCustomProfessionRole bit   ,  
  
 @GenerateJobXml bit   ,  
  
 @IsPrivateSite bit   ,  
  
 @PrivateRedirectUrl varchar (255)  ,  
  
 @EnableJobCustomQuestionnaire bit   ,  
  
 @JobApplicationTypeId int   ,  
  
 @JobScreeningProcess bit   ,  
  
 @AdvertiserApprovalProcess int   ,  
  
 @SiteType int   ,  
  
 @EnableSsl bit   ,  
  
 @Gst decimal (5, 2)  ,  
  
 @GstLabel nvarchar (510)  ,  
  
 @NumberOfPremiumJobs int   ,  
  
 @PremiumJobDays int   ,  
  
 @DisplayPremiumJobsOnResults bit   ,  
  
 @JobExpiryNotification bit   ,  
  
 @CurrencyId int   ,  
  
 @PayPalClientId varchar (255)  ,  
  
 @PayPalClientSecret varchar (255)  ,  
  
 @PaypalUser varchar (255)  ,  
  
 @PaypalProPassword varchar (255)  ,  
  
 @PaypalVendor varchar (255)  ,  
  
 @PaypalPartner varchar (255)  ,  
  
 @InvoiceSiteInfo nvarchar (1000)  ,  
  
 @InvoiceSiteFooter nvarchar (1500)  ,  
  
 @EnableTermsAndConditions bit   ,  
  
 @DefaultEmailLanguageId int   ,  
  
 @GoogleTagManager varchar (100)  ,  
  
 @GoogleAnalytics varchar (100)  ,  
  
 @GoogleWebMaster varchar (100)  ,  
  
 @EnablePeopleSearch bit   ,  
  
 @GlobalDateFormat varchar (20)  ,  
  
 @TimeZone varchar (255)  ,  
  
 @GlobalFolder varchar (255),    
 
 @EnableScreeningQuestions bit
)  
AS  
  
  
      
      
    -- Modify the updatable columns  
    UPDATE  
     [dbo].[GlobalSettings]  
    SET  
     [SiteID] = @SiteId  
     ,[DefaultLanguageID] = @DefaultLanguageId  
     ,[DefaultDynamicPageID] = @DefaultDynamicPageId  
     ,[PublicJobsSearch] = @PublicJobsSearch  
     ,[PublicMembersSearch] = @PublicMembersSearch  
     ,[PublicCompaniesSearch] = @PublicCompaniesSearch  
     ,[PublicSponsoredAdverts] = @PublicSponsoredAdverts  
     ,[PrivateJobs] = @PrivateJobs  
     ,[PrivateMembers] = @PrivateMembers  
     ,[PrivateCompanies] = @PrivateCompanies  
     ,[LastModifiedBy] = @LastModifiedBy  
     ,[LastModified] = @LastModified  
     ,[PageTitlePrefix] = @PageTitlePrefix  
     ,[PageTitleSuffix] = @PageTitleSuffix  
     ,[DefaultTitle] = @DefaultTitle  
     ,[HomeTitle] = @HomeTitle  
     ,[DefaultDescription] = @DefaultDescription  
     ,[HomeDescription] = @HomeDescription  
     ,[DefaultKeywords] = @DefaultKeywords  
     ,[HomeKeywords] = @HomeKeywords  
     ,[ShowFaceBookButton] = @ShowFaceBookButton  
     ,[UseAdvertiserFilter] = @UseAdvertiserFilter  
     ,[MerchantID] = @MerchantId  
     ,[ShowTwitterButton] = @ShowTwitterButton  
     ,[ShowJobAlertButton] = @ShowJobAlertButton  
     ,[ShowLinkedInButton] = @ShowLinkedInButton  
     ,[SiteFavIconID] = @SiteFavIconId  
     ,[SiteDocType] = @SiteDocType  
     ,[CurrencySymbol] = @CurrencySymbol  
     ,[FtpFolderLocation] = @FtpFolderLocation  
     ,[MetaTags] = @MetaTags  
     ,[SystemMetaTags] = @SystemMetaTags  
     ,[MemberRegistrationNotification] = @MemberRegistrationNotification  
     ,[LinkedInAPI] = @LinkedInApi  
     ,[LinkedInLogo] = @LinkedInLogo  
     ,[LinkedInCompanyID] = @LinkedInCompanyId  
     ,[LinkedInEmail] = @LinkedInEmail  
     ,[PrivacySettings] = @PrivacySettings  
     ,[WWWRedirect] = @WwwRedirect  
     ,[AllowAdvertiser] = @AllowAdvertiser  
     ,[LinkedInAPISecret] = @LinkedInApiSecret  
     ,[GoogleClientID] = @GoogleClientId  
     ,[GoogleClientSecret] = @GoogleClientSecret  
     ,[FacebookAppID] = @FacebookAppId  
     ,[FacebookAppSecret] = @FacebookAppSecret  
     ,[LinkedInButtonSize] = @LinkedInButtonSize  
     ,[DefaultCountryID] = @DefaultCountryId  
     ,[PayPalUsername] = @PayPalUsername  
     ,[PayPalPassword] = @PayPalPassword  
     ,[PayPalSignature] = @PayPalSignature  
     ,[SecurePayMerchantID] = @SecurePayMerchantId  
     ,[SecurePayPassword] = @SecurePayPassword  
     ,[UsingSSL] = @UsingSsl  
     ,[UseCustomProfessionRole] = @UseCustomProfessionRole  
     ,[GenerateJobXML] = @GenerateJobXml  
     ,[IsPrivateSite] = @IsPrivateSite  
     ,[PrivateRedirectUrl] = @PrivateRedirectUrl  
     ,[EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire  
     ,[JobApplicationTypeID] = @JobApplicationTypeId  
     ,[JobScreeningProcess] = @JobScreeningProcess  
     ,[AdvertiserApprovalProcess] = @AdvertiserApprovalProcess  
     ,[SiteType] = @SiteType  
     ,[EnableSSL] = @EnableSsl  
     ,[GST] = @Gst  
     ,[GSTLabel] = @GstLabel  
     ,[NumberOfPremiumJobs] = @NumberOfPremiumJobs  
     ,[PremiumJobDays] = @PremiumJobDays  
     ,[DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults  
     ,[JobExpiryNotification] = @JobExpiryNotification  
     ,[CurrencyID] = @CurrencyId  
     ,[PayPalClientID] = @PayPalClientId  
     ,[PayPalClientSecret] = @PayPalClientSecret  
     ,[PaypalUser] = @PaypalUser  
     ,[PaypalProPassword] = @PaypalProPassword  
     ,[PaypalVendor] = @PaypalVendor  
     ,[PaypalPartner] = @PaypalPartner  
     ,[InvoiceSiteInfo] = @InvoiceSiteInfo  
     ,[InvoiceSiteFooter] = @InvoiceSiteFooter  
     ,[EnableTermsAndConditions] = @EnableTermsAndConditions  
     ,[DefaultEmailLanguageId] = @DefaultEmailLanguageId  
     ,[GoogleTagManager] = @GoogleTagManager  
     ,[GoogleAnalytics] = @GoogleAnalytics  
     ,[GoogleWebMaster] = @GoogleWebMaster  
     ,[EnablePeopleSearch] = @EnablePeopleSearch  
     ,[GlobalDateFormat] = @GlobalDateFormat  
     ,[TimeZone] = @TimeZone  
     ,[GlobalFolder] = @GlobalFolder  
     ,[EnableScreeningQuestions] = @EnableScreeningQuestions
    WHERE  
[GlobalSettingID] = @GlobalSettingId
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Insert]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Insert]
(

	@GlobalSettingId int    OUTPUT,

	@SiteId int   ,

	@DefaultLanguageId int   ,

	@DefaultDynamicPageId int   ,

	@PublicJobsSearch bit   ,

	@PublicMembersSearch bit   ,

	@PublicCompaniesSearch bit   ,

	@PublicSponsoredAdverts bit   ,

	@PrivateJobs bit   ,

	@PrivateMembers bit   ,

	@PrivateCompanies bit   ,

	@LastModifiedBy int   ,

	@LastModified datetime   ,

	@PageTitlePrefix nvarchar (510)  ,

	@PageTitleSuffix nvarchar (510)  ,

	@DefaultTitle nvarchar (510)  ,

	@HomeTitle nvarchar (510)  ,

	@DefaultDescription nvarchar (510)  ,

	@HomeDescription nvarchar (510)  ,

	@DefaultKeywords nvarchar (510)  ,

	@HomeKeywords nvarchar (510)  ,

	@ShowFaceBookButton bit   ,

	@UseAdvertiserFilter int   ,

	@MerchantId int   ,

	@ShowTwitterButton bit   ,

	@ShowJobAlertButton bit   ,

	@ShowLinkedInButton bit   ,

	@SiteFavIconId int   ,

	@SiteDocType varchar (512)  ,

	@CurrencySymbol varchar (10)  ,

	@FtpFolderLocation varchar (255)  ,

	@MetaTags nvarchar (MAX)  ,

	@SystemMetaTags nvarchar (4000)  ,

	@MemberRegistrationNotification varchar (255)  ,

	@LinkedInApi varchar (255)  ,

	@LinkedInLogo varchar (255)  ,

	@LinkedInCompanyId int   ,

	@LinkedInEmail varchar (255)  ,

	@PrivacySettings nvarchar (4000)  ,

	@WwwRedirect bit   ,

	@AllowAdvertiser bit   ,

	@LinkedInApiSecret varchar (255)  ,

	@GoogleClientId varchar (255)  ,

	@GoogleClientSecret varchar (255)  ,

	@FacebookAppId varchar (255)  ,

	@FacebookAppSecret varchar (255)  ,

	@LinkedInButtonSize int   ,

	@DefaultCountryId int   ,

	@PayPalUsername varchar (100)  ,

	@PayPalPassword varchar (100)  ,

	@PayPalSignature varchar (100)  ,

	@SecurePayMerchantId varchar (100)  ,

	@SecurePayPassword varchar (100)  ,

	@UsingSsl bit   ,

	@UseCustomProfessionRole bit   ,

	@GenerateJobXml bit   ,

	@IsPrivateSite bit   ,

	@PrivateRedirectUrl varchar (255)  ,

	@EnableJobCustomQuestionnaire bit   ,

	@JobApplicationTypeId int   ,

	@JobScreeningProcess bit   ,

	@AdvertiserApprovalProcess int   ,

	@SiteType int   ,

	@EnableSsl bit   ,

	@Gst decimal (5, 2)  ,

	@GstLabel nvarchar (510)  ,

	@NumberOfPremiumJobs int   ,

	@PremiumJobDays int   ,

	@DisplayPremiumJobsOnResults bit   ,

	@JobExpiryNotification bit   ,

	@CurrencyId int   ,

	@PayPalClientId varchar (255)  ,

	@PayPalClientSecret varchar (255)  ,

	@PaypalUser varchar (255)  ,

	@PaypalProPassword varchar (255)  ,

	@PaypalVendor varchar (255)  ,

	@PaypalPartner varchar (255)  ,

	@InvoiceSiteInfo nvarchar (1000)  ,

	@InvoiceSiteFooter nvarchar (1500)  ,

	@EnableTermsAndConditions bit   ,

	@DefaultEmailLanguageId int   ,

	@GoogleTagManager varchar (100)  ,

	@GoogleAnalytics varchar (100)  ,

	@GoogleWebMaster varchar (100)  ,

	@EnablePeopleSearch bit   ,

	@GlobalDateFormat varchar (20)  ,

	@TimeZone varchar (255)  ,

	@GlobalFolder varchar (255)  ,

	@EnableScreeningQuestions bit   
)
AS


				
				INSERT INTO [dbo].[GlobalSettings]
					(
					[SiteID]
					,[DefaultLanguageID]
					,[DefaultDynamicPageID]
					,[PublicJobsSearch]
					,[PublicMembersSearch]
					,[PublicCompaniesSearch]
					,[PublicSponsoredAdverts]
					,[PrivateJobs]
					,[PrivateMembers]
					,[PrivateCompanies]
					,[LastModifiedBy]
					,[LastModified]
					,[PageTitlePrefix]
					,[PageTitleSuffix]
					,[DefaultTitle]
					,[HomeTitle]
					,[DefaultDescription]
					,[HomeDescription]
					,[DefaultKeywords]
					,[HomeKeywords]
					,[ShowFaceBookButton]
					,[UseAdvertiserFilter]
					,[MerchantID]
					,[ShowTwitterButton]
					,[ShowJobAlertButton]
					,[ShowLinkedInButton]
					,[SiteFavIconID]
					,[SiteDocType]
					,[CurrencySymbol]
					,[FtpFolderLocation]
					,[MetaTags]
					,[SystemMetaTags]
					,[MemberRegistrationNotification]
					,[LinkedInAPI]
					,[LinkedInLogo]
					,[LinkedInCompanyID]
					,[LinkedInEmail]
					,[PrivacySettings]
					,[WWWRedirect]
					,[AllowAdvertiser]
					,[LinkedInAPISecret]
					,[GoogleClientID]
					,[GoogleClientSecret]
					,[FacebookAppID]
					,[FacebookAppSecret]
					,[LinkedInButtonSize]
					,[DefaultCountryID]
					,[PayPalUsername]
					,[PayPalPassword]
					,[PayPalSignature]
					,[SecurePayMerchantID]
					,[SecurePayPassword]
					,[UsingSSL]
					,[UseCustomProfessionRole]
					,[GenerateJobXML]
					,[IsPrivateSite]
					,[PrivateRedirectUrl]
					,[EnableJobCustomQuestionnaire]
					,[JobApplicationTypeID]
					,[JobScreeningProcess]
					,[AdvertiserApprovalProcess]
					,[SiteType]
					,[EnableSSL]
					,[GST]
					,[GSTLabel]
					,[NumberOfPremiumJobs]
					,[PremiumJobDays]
					,[DisplayPremiumJobsOnResults]
					,[JobExpiryNotification]
					,[CurrencyID]
					,[PayPalClientID]
					,[PayPalClientSecret]
					,[PaypalUser]
					,[PaypalProPassword]
					,[PaypalVendor]
					,[PaypalPartner]
					,[InvoiceSiteInfo]
					,[InvoiceSiteFooter]
					,[EnableTermsAndConditions]
					,[DefaultEmailLanguageId]
					,[GoogleTagManager]
					,[GoogleAnalytics]
					,[GoogleWebMaster]
					,[EnablePeopleSearch]
					,[GlobalDateFormat]
					,[TimeZone]
					,[GlobalFolder]
					,[EnableScreeningQuestions]
					)
				VALUES
					(
					@SiteId
					,@DefaultLanguageId
					,@DefaultDynamicPageId
					,@PublicJobsSearch
					,@PublicMembersSearch
					,@PublicCompaniesSearch
					,@PublicSponsoredAdverts
					,@PrivateJobs
					,@PrivateMembers
					,@PrivateCompanies
					,@LastModifiedBy
					,@LastModified
					,@PageTitlePrefix
					,@PageTitleSuffix
					,@DefaultTitle
					,@HomeTitle
					,@DefaultDescription
					,@HomeDescription
					,@DefaultKeywords
					,@HomeKeywords
					,@ShowFaceBookButton
					,@UseAdvertiserFilter
					,@MerchantId
					,@ShowTwitterButton
					,@ShowJobAlertButton
					,@ShowLinkedInButton
					,@SiteFavIconId
					,@SiteDocType
					,@CurrencySymbol
					,@FtpFolderLocation
					,@MetaTags
					,@SystemMetaTags
					,@MemberRegistrationNotification
					,@LinkedInApi
					,@LinkedInLogo
					,@LinkedInCompanyId
					,@LinkedInEmail
					,@PrivacySettings
					,@WwwRedirect
					,@AllowAdvertiser
					,@LinkedInApiSecret
					,@GoogleClientId
					,@GoogleClientSecret
					,@FacebookAppId
					,@FacebookAppSecret
					,@LinkedInButtonSize
					,@DefaultCountryId
					,@PayPalUsername
					,@PayPalPassword
					,@PayPalSignature
					,@SecurePayMerchantId
					,@SecurePayPassword
					,@UsingSsl
					,@UseCustomProfessionRole
					,@GenerateJobXml
					,@IsPrivateSite
					,@PrivateRedirectUrl
					,@EnableJobCustomQuestionnaire
					,@JobApplicationTypeId
					,@JobScreeningProcess
					,@AdvertiserApprovalProcess
					,@SiteType
					,@EnableSsl
					,@Gst
					,@GstLabel
					,@NumberOfPremiumJobs
					,@PremiumJobDays
					,@DisplayPremiumJobsOnResults
					,@JobExpiryNotification
					,@CurrencyId
					,@PayPalClientId
					,@PayPalClientSecret
					,@PaypalUser
					,@PaypalProPassword
					,@PaypalVendor
					,@PaypalPartner
					,@InvoiceSiteInfo
					,@InvoiceSiteFooter
					,@EnableTermsAndConditions
					,@DefaultEmailLanguageId
					,@GoogleTagManager
					,@GoogleAnalytics
					,@GoogleWebMaster
					,@EnablePeopleSearch
					,@GlobalDateFormat
					,@TimeZone
					,@GlobalFolder
					,@EnableScreeningQuestions
					)
				
				-- Get the identity value
				SET @GlobalSettingId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetPaged]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the GlobalSettings table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetPaged]
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
				    [GlobalSettingID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([GlobalSettingID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [GlobalSettingID]'
				SET @SQL = @SQL + ' FROM [dbo].[GlobalSettings]'
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
				SELECT O.[GlobalSettingID], O.[SiteID], O.[DefaultLanguageID], O.[DefaultDynamicPageID], O.[PublicJobsSearch], O.[PublicMembersSearch], O.[PublicCompaniesSearch], O.[PublicSponsoredAdverts], O.[PrivateJobs], O.[PrivateMembers], O.[PrivateCompanies], O.[LastModifiedBy], O.[LastModified], O.[PageTitlePrefix], O.[PageTitleSuffix], O.[DefaultTitle], O.[HomeTitle], O.[DefaultDescription], O.[HomeDescription], O.[DefaultKeywords], O.[HomeKeywords], O.[ShowFaceBookButton], O.[UseAdvertiserFilter], O.[MerchantID], O.[ShowTwitterButton], O.[ShowJobAlertButton], O.[ShowLinkedInButton], O.[SiteFavIconID], O.[SiteDocType], O.[CurrencySymbol], O.[FtpFolderLocation], O.[MetaTags], O.[SystemMetaTags], O.[MemberRegistrationNotification], O.[LinkedInAPI], O.[LinkedInLogo], O.[LinkedInCompanyID], O.[LinkedInEmail], O.[PrivacySettings], O.[WWWRedirect], O.[AllowAdvertiser], O.[LinkedInAPISecret], O.[GoogleClientID], O.[GoogleClientSecret], O.[FacebookAppID], O.[FacebookAppSecret], O.[LinkedInButtonSize], O.[DefaultCountryID], O.[PayPalUsername], O.[PayPalPassword], O.[PayPalSignature], O.[SecurePayMerchantID], O.[SecurePayPassword], O.[UsingSSL], O.[UseCustomProfessionRole], O.[GenerateJobXML], O.[IsPrivateSite], O.[PrivateRedirectUrl], O.[EnableJobCustomQuestionnaire], O.[JobApplicationTypeID], O.[JobScreeningProcess], O.[AdvertiserApprovalProcess], O.[SiteType], O.[EnableSSL], O.[GST], O.[GSTLabel], O.[NumberOfPremiumJobs], O.[PremiumJobDays], O.[DisplayPremiumJobsOnResults], O.[JobExpiryNotification], O.[CurrencyID], O.[PayPalClientID], O.[PayPalClientSecret], O.[PaypalUser], O.[PaypalProPassword], O.[PaypalVendor], O.[PaypalPartner], O.[InvoiceSiteInfo], O.[InvoiceSiteFooter], O.[EnableTermsAndConditions], O.[DefaultEmailLanguageId], O.[GoogleTagManager], O.[GoogleAnalytics], O.[GoogleWebMaster], O.[EnablePeopleSearch], O.[GlobalDateFormat], O.[TimeZone], O.[GlobalFolder], O.[EnableScreeningQuestions]
				FROM
				    [dbo].[GlobalSettings] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[GlobalSettingID] = PageIndex.[GlobalSettingID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[GlobalSettings]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdUseAdvertiserFilter]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdUseAdvertiserFilter]
(

	@SiteId int   ,

	@UseAdvertiserFilter int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [UseAdvertiserFilter] = @UseAdvertiserFilter
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdPublicJobsSearch]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdPublicJobsSearch]
(

	@SiteId int   ,

	@PublicJobsSearch bit   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [PublicJobsSearch] = @PublicJobsSearch
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdGlobalSettingId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteIdGlobalSettingId]
(

	@SiteId int   ,

	@GlobalSettingId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteFavIconId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetBySiteFavIconId]
(

	@SiteFavIconId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteFavIconID] = @SiteFavIconId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId]
(

	@PublicJobsSearch bit   ,

	@PrivateJobs bit   ,

	@SiteId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[PublicJobsSearch] = @PublicJobsSearch
					AND [PrivateJobs] = @PrivateJobs
					AND [SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByLastModifiedBy]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByGlobalSettingId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByGlobalSettingId]
(

	@GlobalSettingId int   
)
AS


				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultLanguageId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultLanguageId]
(

	@DefaultLanguageId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultLanguageID] = @DefaultLanguageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultDynamicPageId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultDynamicPageId]
(

	@DefaultDynamicPageId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultDynamicPageID] = @DefaultDynamicPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultCountryId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GlobalSettings table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_GetByDefaultCountryId]
(

	@DefaultCountryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultCountryID] = @DefaultCountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Get_List]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Get_List]

AS


				
				SELECT
					[GlobalSettingID],
					[SiteID],
					[DefaultLanguageID],
					[DefaultDynamicPageID],
					[PublicJobsSearch],
					[PublicMembersSearch],
					[PublicCompaniesSearch],
					[PublicSponsoredAdverts],
					[PrivateJobs],
					[PrivateMembers],
					[PrivateCompanies],
					[LastModifiedBy],
					[LastModified],
					[PageTitlePrefix],
					[PageTitleSuffix],
					[DefaultTitle],
					[HomeTitle],
					[DefaultDescription],
					[HomeDescription],
					[DefaultKeywords],
					[HomeKeywords],
					[ShowFaceBookButton],
					[UseAdvertiserFilter],
					[MerchantID],
					[ShowTwitterButton],
					[ShowJobAlertButton],
					[ShowLinkedInButton],
					[SiteFavIconID],
					[SiteDocType],
					[CurrencySymbol],
					[FtpFolderLocation],
					[MetaTags],
					[SystemMetaTags],
					[MemberRegistrationNotification],
					[LinkedInAPI],
					[LinkedInLogo],
					[LinkedInCompanyID],
					[LinkedInEmail],
					[PrivacySettings],
					[WWWRedirect],
					[AllowAdvertiser],
					[LinkedInAPISecret],
					[GoogleClientID],
					[GoogleClientSecret],
					[FacebookAppID],
					[FacebookAppSecret],
					[LinkedInButtonSize],
					[DefaultCountryID],
					[PayPalUsername],
					[PayPalPassword],
					[PayPalSignature],
					[SecurePayMerchantID],
					[SecurePayPassword],
					[UsingSSL],
					[UseCustomProfessionRole],
					[GenerateJobXML],
					[IsPrivateSite],
					[PrivateRedirectUrl],
					[EnableJobCustomQuestionnaire],
					[JobApplicationTypeID],
					[JobScreeningProcess],
					[AdvertiserApprovalProcess],
					[SiteType],
					[EnableSSL],
					[GST],
					[GSTLabel],
					[NumberOfPremiumJobs],
					[PremiumJobDays],
					[DisplayPremiumJobsOnResults],
					[JobExpiryNotification],
					[CurrencyID],
					[PayPalClientID],
					[PayPalClientSecret],
					[PaypalUser],
					[PaypalProPassword],
					[PaypalVendor],
					[PaypalPartner],
					[InvoiceSiteInfo],
					[InvoiceSiteFooter],
					[EnableTermsAndConditions],
					[DefaultEmailLanguageId],
					[GoogleTagManager],
					[GoogleAnalytics],
					[GoogleWebMaster],
					[EnablePeopleSearch],
					[GlobalDateFormat],
					[TimeZone],
					[GlobalFolder],
					[EnableScreeningQuestions]
				FROM
					[dbo].[GlobalSettings]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Find]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the GlobalSettings table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Find]
(

	@SearchUsingOR bit   = null ,

	@GlobalSettingId int   = null ,

	@SiteId int   = null ,

	@DefaultLanguageId int   = null ,

	@DefaultDynamicPageId int   = null ,

	@PublicJobsSearch bit   = null ,

	@PublicMembersSearch bit   = null ,

	@PublicCompaniesSearch bit   = null ,

	@PublicSponsoredAdverts bit   = null ,

	@PrivateJobs bit   = null ,

	@PrivateMembers bit   = null ,

	@PrivateCompanies bit   = null ,

	@LastModifiedBy int   = null ,

	@LastModified datetime   = null ,

	@PageTitlePrefix nvarchar (510)  = null ,

	@PageTitleSuffix nvarchar (510)  = null ,

	@DefaultTitle nvarchar (510)  = null ,

	@HomeTitle nvarchar (510)  = null ,

	@DefaultDescription nvarchar (510)  = null ,

	@HomeDescription nvarchar (510)  = null ,

	@DefaultKeywords nvarchar (510)  = null ,

	@HomeKeywords nvarchar (510)  = null ,

	@ShowFaceBookButton bit   = null ,

	@UseAdvertiserFilter int   = null ,

	@MerchantId int   = null ,

	@ShowTwitterButton bit   = null ,

	@ShowJobAlertButton bit   = null ,

	@ShowLinkedInButton bit   = null ,

	@SiteFavIconId int   = null ,

	@SiteDocType varchar (512)  = null ,

	@CurrencySymbol varchar (10)  = null ,

	@FtpFolderLocation varchar (255)  = null ,

	@MetaTags nvarchar (MAX)  = null ,

	@SystemMetaTags nvarchar (4000)  = null ,

	@MemberRegistrationNotification varchar (255)  = null ,

	@LinkedInApi varchar (255)  = null ,

	@LinkedInLogo varchar (255)  = null ,

	@LinkedInCompanyId int   = null ,

	@LinkedInEmail varchar (255)  = null ,

	@PrivacySettings nvarchar (4000)  = null ,

	@WwwRedirect bit   = null ,

	@AllowAdvertiser bit   = null ,

	@LinkedInApiSecret varchar (255)  = null ,

	@GoogleClientId varchar (255)  = null ,

	@GoogleClientSecret varchar (255)  = null ,

	@FacebookAppId varchar (255)  = null ,

	@FacebookAppSecret varchar (255)  = null ,

	@LinkedInButtonSize int   = null ,

	@DefaultCountryId int   = null ,

	@PayPalUsername varchar (100)  = null ,

	@PayPalPassword varchar (100)  = null ,

	@PayPalSignature varchar (100)  = null ,

	@SecurePayMerchantId varchar (100)  = null ,

	@SecurePayPassword varchar (100)  = null ,

	@UsingSsl bit   = null ,

	@UseCustomProfessionRole bit   = null ,

	@GenerateJobXml bit   = null ,

	@IsPrivateSite bit   = null ,

	@PrivateRedirectUrl varchar (255)  = null ,

	@EnableJobCustomQuestionnaire bit   = null ,

	@JobApplicationTypeId int   = null ,

	@JobScreeningProcess bit   = null ,

	@AdvertiserApprovalProcess int   = null ,

	@SiteType int   = null ,

	@EnableSsl bit   = null ,

	@Gst decimal (5, 2)  = null ,

	@GstLabel nvarchar (510)  = null ,

	@NumberOfPremiumJobs int   = null ,

	@PremiumJobDays int   = null ,

	@DisplayPremiumJobsOnResults bit   = null ,

	@JobExpiryNotification bit   = null ,

	@CurrencyId int   = null ,

	@PayPalClientId varchar (255)  = null ,

	@PayPalClientSecret varchar (255)  = null ,

	@PaypalUser varchar (255)  = null ,

	@PaypalProPassword varchar (255)  = null ,

	@PaypalVendor varchar (255)  = null ,

	@PaypalPartner varchar (255)  = null ,

	@InvoiceSiteInfo nvarchar (1000)  = null ,

	@InvoiceSiteFooter nvarchar (1500)  = null ,

	@EnableTermsAndConditions bit   = null ,

	@DefaultEmailLanguageId int   = null ,

	@GoogleTagManager varchar (100)  = null ,

	@GoogleAnalytics varchar (100)  = null ,

	@GoogleWebMaster varchar (100)  = null ,

	@EnablePeopleSearch bit   = null ,

	@GlobalDateFormat varchar (20)  = null ,

	@TimeZone varchar (255)  = null ,

	@GlobalFolder varchar (255)  = null ,

	@EnableScreeningQuestions bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GlobalSettingID]
	, [SiteID]
	, [DefaultLanguageID]
	, [DefaultDynamicPageID]
	, [PublicJobsSearch]
	, [PublicMembersSearch]
	, [PublicCompaniesSearch]
	, [PublicSponsoredAdverts]
	, [PrivateJobs]
	, [PrivateMembers]
	, [PrivateCompanies]
	, [LastModifiedBy]
	, [LastModified]
	, [PageTitlePrefix]
	, [PageTitleSuffix]
	, [DefaultTitle]
	, [HomeTitle]
	, [DefaultDescription]
	, [HomeDescription]
	, [DefaultKeywords]
	, [HomeKeywords]
	, [ShowFaceBookButton]
	, [UseAdvertiserFilter]
	, [MerchantID]
	, [ShowTwitterButton]
	, [ShowJobAlertButton]
	, [ShowLinkedInButton]
	, [SiteFavIconID]
	, [SiteDocType]
	, [CurrencySymbol]
	, [FtpFolderLocation]
	, [MetaTags]
	, [SystemMetaTags]
	, [MemberRegistrationNotification]
	, [LinkedInAPI]
	, [LinkedInLogo]
	, [LinkedInCompanyID]
	, [LinkedInEmail]
	, [PrivacySettings]
	, [WWWRedirect]
	, [AllowAdvertiser]
	, [LinkedInAPISecret]
	, [GoogleClientID]
	, [GoogleClientSecret]
	, [FacebookAppID]
	, [FacebookAppSecret]
	, [LinkedInButtonSize]
	, [DefaultCountryID]
	, [PayPalUsername]
	, [PayPalPassword]
	, [PayPalSignature]
	, [SecurePayMerchantID]
	, [SecurePayPassword]
	, [UsingSSL]
	, [UseCustomProfessionRole]
	, [GenerateJobXML]
	, [IsPrivateSite]
	, [PrivateRedirectUrl]
	, [EnableJobCustomQuestionnaire]
	, [JobApplicationTypeID]
	, [JobScreeningProcess]
	, [AdvertiserApprovalProcess]
	, [SiteType]
	, [EnableSSL]
	, [GST]
	, [GSTLabel]
	, [NumberOfPremiumJobs]
	, [PremiumJobDays]
	, [DisplayPremiumJobsOnResults]
	, [JobExpiryNotification]
	, [CurrencyID]
	, [PayPalClientID]
	, [PayPalClientSecret]
	, [PaypalUser]
	, [PaypalProPassword]
	, [PaypalVendor]
	, [PaypalPartner]
	, [InvoiceSiteInfo]
	, [InvoiceSiteFooter]
	, [EnableTermsAndConditions]
	, [DefaultEmailLanguageId]
	, [GoogleTagManager]
	, [GoogleAnalytics]
	, [GoogleWebMaster]
	, [EnablePeopleSearch]
	, [GlobalDateFormat]
	, [TimeZone]
	, [GlobalFolder]
	, [EnableScreeningQuestions]
    FROM
	[dbo].[GlobalSettings]
    WHERE 
	 ([GlobalSettingID] = @GlobalSettingId OR @GlobalSettingId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([DefaultLanguageID] = @DefaultLanguageId OR @DefaultLanguageId IS NULL)
	AND ([DefaultDynamicPageID] = @DefaultDynamicPageId OR @DefaultDynamicPageId IS NULL)
	AND ([PublicJobsSearch] = @PublicJobsSearch OR @PublicJobsSearch IS NULL)
	AND ([PublicMembersSearch] = @PublicMembersSearch OR @PublicMembersSearch IS NULL)
	AND ([PublicCompaniesSearch] = @PublicCompaniesSearch OR @PublicCompaniesSearch IS NULL)
	AND ([PublicSponsoredAdverts] = @PublicSponsoredAdverts OR @PublicSponsoredAdverts IS NULL)
	AND ([PrivateJobs] = @PrivateJobs OR @PrivateJobs IS NULL)
	AND ([PrivateMembers] = @PrivateMembers OR @PrivateMembers IS NULL)
	AND ([PrivateCompanies] = @PrivateCompanies OR @PrivateCompanies IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([PageTitlePrefix] = @PageTitlePrefix OR @PageTitlePrefix IS NULL)
	AND ([PageTitleSuffix] = @PageTitleSuffix OR @PageTitleSuffix IS NULL)
	AND ([DefaultTitle] = @DefaultTitle OR @DefaultTitle IS NULL)
	AND ([HomeTitle] = @HomeTitle OR @HomeTitle IS NULL)
	AND ([DefaultDescription] = @DefaultDescription OR @DefaultDescription IS NULL)
	AND ([HomeDescription] = @HomeDescription OR @HomeDescription IS NULL)
	AND ([DefaultKeywords] = @DefaultKeywords OR @DefaultKeywords IS NULL)
	AND ([HomeKeywords] = @HomeKeywords OR @HomeKeywords IS NULL)
	AND ([ShowFaceBookButton] = @ShowFaceBookButton OR @ShowFaceBookButton IS NULL)
	AND ([UseAdvertiserFilter] = @UseAdvertiserFilter OR @UseAdvertiserFilter IS NULL)
	AND ([MerchantID] = @MerchantId OR @MerchantId IS NULL)
	AND ([ShowTwitterButton] = @ShowTwitterButton OR @ShowTwitterButton IS NULL)
	AND ([ShowJobAlertButton] = @ShowJobAlertButton OR @ShowJobAlertButton IS NULL)
	AND ([ShowLinkedInButton] = @ShowLinkedInButton OR @ShowLinkedInButton IS NULL)
	AND ([SiteFavIconID] = @SiteFavIconId OR @SiteFavIconId IS NULL)
	AND ([SiteDocType] = @SiteDocType OR @SiteDocType IS NULL)
	AND ([CurrencySymbol] = @CurrencySymbol OR @CurrencySymbol IS NULL)
	AND ([FtpFolderLocation] = @FtpFolderLocation OR @FtpFolderLocation IS NULL)
	AND ([MetaTags] = @MetaTags OR @MetaTags IS NULL)
	AND ([SystemMetaTags] = @SystemMetaTags OR @SystemMetaTags IS NULL)
	AND ([MemberRegistrationNotification] = @MemberRegistrationNotification OR @MemberRegistrationNotification IS NULL)
	AND ([LinkedInAPI] = @LinkedInApi OR @LinkedInApi IS NULL)
	AND ([LinkedInLogo] = @LinkedInLogo OR @LinkedInLogo IS NULL)
	AND ([LinkedInCompanyID] = @LinkedInCompanyId OR @LinkedInCompanyId IS NULL)
	AND ([LinkedInEmail] = @LinkedInEmail OR @LinkedInEmail IS NULL)
	AND ([PrivacySettings] = @PrivacySettings OR @PrivacySettings IS NULL)
	AND ([WWWRedirect] = @WwwRedirect OR @WwwRedirect IS NULL)
	AND ([AllowAdvertiser] = @AllowAdvertiser OR @AllowAdvertiser IS NULL)
	AND ([LinkedInAPISecret] = @LinkedInApiSecret OR @LinkedInApiSecret IS NULL)
	AND ([GoogleClientID] = @GoogleClientId OR @GoogleClientId IS NULL)
	AND ([GoogleClientSecret] = @GoogleClientSecret OR @GoogleClientSecret IS NULL)
	AND ([FacebookAppID] = @FacebookAppId OR @FacebookAppId IS NULL)
	AND ([FacebookAppSecret] = @FacebookAppSecret OR @FacebookAppSecret IS NULL)
	AND ([LinkedInButtonSize] = @LinkedInButtonSize OR @LinkedInButtonSize IS NULL)
	AND ([DefaultCountryID] = @DefaultCountryId OR @DefaultCountryId IS NULL)
	AND ([PayPalUsername] = @PayPalUsername OR @PayPalUsername IS NULL)
	AND ([PayPalPassword] = @PayPalPassword OR @PayPalPassword IS NULL)
	AND ([PayPalSignature] = @PayPalSignature OR @PayPalSignature IS NULL)
	AND ([SecurePayMerchantID] = @SecurePayMerchantId OR @SecurePayMerchantId IS NULL)
	AND ([SecurePayPassword] = @SecurePayPassword OR @SecurePayPassword IS NULL)
	AND ([UsingSSL] = @UsingSsl OR @UsingSsl IS NULL)
	AND ([UseCustomProfessionRole] = @UseCustomProfessionRole OR @UseCustomProfessionRole IS NULL)
	AND ([GenerateJobXML] = @GenerateJobXml OR @GenerateJobXml IS NULL)
	AND ([IsPrivateSite] = @IsPrivateSite OR @IsPrivateSite IS NULL)
	AND ([PrivateRedirectUrl] = @PrivateRedirectUrl OR @PrivateRedirectUrl IS NULL)
	AND ([EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire OR @EnableJobCustomQuestionnaire IS NULL)
	AND ([JobApplicationTypeID] = @JobApplicationTypeId OR @JobApplicationTypeId IS NULL)
	AND ([JobScreeningProcess] = @JobScreeningProcess OR @JobScreeningProcess IS NULL)
	AND ([AdvertiserApprovalProcess] = @AdvertiserApprovalProcess OR @AdvertiserApprovalProcess IS NULL)
	AND ([SiteType] = @SiteType OR @SiteType IS NULL)
	AND ([EnableSSL] = @EnableSsl OR @EnableSsl IS NULL)
	AND ([GST] = @Gst OR @Gst IS NULL)
	AND ([GSTLabel] = @GstLabel OR @GstLabel IS NULL)
	AND ([NumberOfPremiumJobs] = @NumberOfPremiumJobs OR @NumberOfPremiumJobs IS NULL)
	AND ([PremiumJobDays] = @PremiumJobDays OR @PremiumJobDays IS NULL)
	AND ([DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults OR @DisplayPremiumJobsOnResults IS NULL)
	AND ([JobExpiryNotification] = @JobExpiryNotification OR @JobExpiryNotification IS NULL)
	AND ([CurrencyID] = @CurrencyId OR @CurrencyId IS NULL)
	AND ([PayPalClientID] = @PayPalClientId OR @PayPalClientId IS NULL)
	AND ([PayPalClientSecret] = @PayPalClientSecret OR @PayPalClientSecret IS NULL)
	AND ([PaypalUser] = @PaypalUser OR @PaypalUser IS NULL)
	AND ([PaypalProPassword] = @PaypalProPassword OR @PaypalProPassword IS NULL)
	AND ([PaypalVendor] = @PaypalVendor OR @PaypalVendor IS NULL)
	AND ([PaypalPartner] = @PaypalPartner OR @PaypalPartner IS NULL)
	AND ([InvoiceSiteInfo] = @InvoiceSiteInfo OR @InvoiceSiteInfo IS NULL)
	AND ([InvoiceSiteFooter] = @InvoiceSiteFooter OR @InvoiceSiteFooter IS NULL)
	AND ([EnableTermsAndConditions] = @EnableTermsAndConditions OR @EnableTermsAndConditions IS NULL)
	AND ([DefaultEmailLanguageId] = @DefaultEmailLanguageId OR @DefaultEmailLanguageId IS NULL)
	AND ([GoogleTagManager] = @GoogleTagManager OR @GoogleTagManager IS NULL)
	AND ([GoogleAnalytics] = @GoogleAnalytics OR @GoogleAnalytics IS NULL)
	AND ([GoogleWebMaster] = @GoogleWebMaster OR @GoogleWebMaster IS NULL)
	AND ([EnablePeopleSearch] = @EnablePeopleSearch OR @EnablePeopleSearch IS NULL)
	AND ([GlobalDateFormat] = @GlobalDateFormat OR @GlobalDateFormat IS NULL)
	AND ([TimeZone] = @TimeZone OR @TimeZone IS NULL)
	AND ([GlobalFolder] = @GlobalFolder OR @GlobalFolder IS NULL)
	AND ([EnableScreeningQuestions] = @EnableScreeningQuestions OR @EnableScreeningQuestions IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GlobalSettingID]
	, [SiteID]
	, [DefaultLanguageID]
	, [DefaultDynamicPageID]
	, [PublicJobsSearch]
	, [PublicMembersSearch]
	, [PublicCompaniesSearch]
	, [PublicSponsoredAdverts]
	, [PrivateJobs]
	, [PrivateMembers]
	, [PrivateCompanies]
	, [LastModifiedBy]
	, [LastModified]
	, [PageTitlePrefix]
	, [PageTitleSuffix]
	, [DefaultTitle]
	, [HomeTitle]
	, [DefaultDescription]
	, [HomeDescription]
	, [DefaultKeywords]
	, [HomeKeywords]
	, [ShowFaceBookButton]
	, [UseAdvertiserFilter]
	, [MerchantID]
	, [ShowTwitterButton]
	, [ShowJobAlertButton]
	, [ShowLinkedInButton]
	, [SiteFavIconID]
	, [SiteDocType]
	, [CurrencySymbol]
	, [FtpFolderLocation]
	, [MetaTags]
	, [SystemMetaTags]
	, [MemberRegistrationNotification]
	, [LinkedInAPI]
	, [LinkedInLogo]
	, [LinkedInCompanyID]
	, [LinkedInEmail]
	, [PrivacySettings]
	, [WWWRedirect]
	, [AllowAdvertiser]
	, [LinkedInAPISecret]
	, [GoogleClientID]
	, [GoogleClientSecret]
	, [FacebookAppID]
	, [FacebookAppSecret]
	, [LinkedInButtonSize]
	, [DefaultCountryID]
	, [PayPalUsername]
	, [PayPalPassword]
	, [PayPalSignature]
	, [SecurePayMerchantID]
	, [SecurePayPassword]
	, [UsingSSL]
	, [UseCustomProfessionRole]
	, [GenerateJobXML]
	, [IsPrivateSite]
	, [PrivateRedirectUrl]
	, [EnableJobCustomQuestionnaire]
	, [JobApplicationTypeID]
	, [JobScreeningProcess]
	, [AdvertiserApprovalProcess]
	, [SiteType]
	, [EnableSSL]
	, [GST]
	, [GSTLabel]
	, [NumberOfPremiumJobs]
	, [PremiumJobDays]
	, [DisplayPremiumJobsOnResults]
	, [JobExpiryNotification]
	, [CurrencyID]
	, [PayPalClientID]
	, [PayPalClientSecret]
	, [PaypalUser]
	, [PaypalProPassword]
	, [PaypalVendor]
	, [PaypalPartner]
	, [InvoiceSiteInfo]
	, [InvoiceSiteFooter]
	, [EnableTermsAndConditions]
	, [DefaultEmailLanguageId]
	, [GoogleTagManager]
	, [GoogleAnalytics]
	, [GoogleWebMaster]
	, [EnablePeopleSearch]
	, [GlobalDateFormat]
	, [TimeZone]
	, [GlobalFolder]
	, [EnableScreeningQuestions]
    FROM
	[dbo].[GlobalSettings]
    WHERE 
	 ([GlobalSettingID] = @GlobalSettingId AND @GlobalSettingId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([DefaultLanguageID] = @DefaultLanguageId AND @DefaultLanguageId is not null)
	OR ([DefaultDynamicPageID] = @DefaultDynamicPageId AND @DefaultDynamicPageId is not null)
	OR ([PublicJobsSearch] = @PublicJobsSearch AND @PublicJobsSearch is not null)
	OR ([PublicMembersSearch] = @PublicMembersSearch AND @PublicMembersSearch is not null)
	OR ([PublicCompaniesSearch] = @PublicCompaniesSearch AND @PublicCompaniesSearch is not null)
	OR ([PublicSponsoredAdverts] = @PublicSponsoredAdverts AND @PublicSponsoredAdverts is not null)
	OR ([PrivateJobs] = @PrivateJobs AND @PrivateJobs is not null)
	OR ([PrivateMembers] = @PrivateMembers AND @PrivateMembers is not null)
	OR ([PrivateCompanies] = @PrivateCompanies AND @PrivateCompanies is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([PageTitlePrefix] = @PageTitlePrefix AND @PageTitlePrefix is not null)
	OR ([PageTitleSuffix] = @PageTitleSuffix AND @PageTitleSuffix is not null)
	OR ([DefaultTitle] = @DefaultTitle AND @DefaultTitle is not null)
	OR ([HomeTitle] = @HomeTitle AND @HomeTitle is not null)
	OR ([DefaultDescription] = @DefaultDescription AND @DefaultDescription is not null)
	OR ([HomeDescription] = @HomeDescription AND @HomeDescription is not null)
	OR ([DefaultKeywords] = @DefaultKeywords AND @DefaultKeywords is not null)
	OR ([HomeKeywords] = @HomeKeywords AND @HomeKeywords is not null)
	OR ([ShowFaceBookButton] = @ShowFaceBookButton AND @ShowFaceBookButton is not null)
	OR ([UseAdvertiserFilter] = @UseAdvertiserFilter AND @UseAdvertiserFilter is not null)
	OR ([MerchantID] = @MerchantId AND @MerchantId is not null)
	OR ([ShowTwitterButton] = @ShowTwitterButton AND @ShowTwitterButton is not null)
	OR ([ShowJobAlertButton] = @ShowJobAlertButton AND @ShowJobAlertButton is not null)
	OR ([ShowLinkedInButton] = @ShowLinkedInButton AND @ShowLinkedInButton is not null)
	OR ([SiteFavIconID] = @SiteFavIconId AND @SiteFavIconId is not null)
	OR ([SiteDocType] = @SiteDocType AND @SiteDocType is not null)
	OR ([CurrencySymbol] = @CurrencySymbol AND @CurrencySymbol is not null)
	OR ([FtpFolderLocation] = @FtpFolderLocation AND @FtpFolderLocation is not null)
	OR ([MetaTags] = @MetaTags AND @MetaTags is not null)
	OR ([SystemMetaTags] = @SystemMetaTags AND @SystemMetaTags is not null)
	OR ([MemberRegistrationNotification] = @MemberRegistrationNotification AND @MemberRegistrationNotification is not null)
	OR ([LinkedInAPI] = @LinkedInApi AND @LinkedInApi is not null)
	OR ([LinkedInLogo] = @LinkedInLogo AND @LinkedInLogo is not null)
	OR ([LinkedInCompanyID] = @LinkedInCompanyId AND @LinkedInCompanyId is not null)
	OR ([LinkedInEmail] = @LinkedInEmail AND @LinkedInEmail is not null)
	OR ([PrivacySettings] = @PrivacySettings AND @PrivacySettings is not null)
	OR ([WWWRedirect] = @WwwRedirect AND @WwwRedirect is not null)
	OR ([AllowAdvertiser] = @AllowAdvertiser AND @AllowAdvertiser is not null)
	OR ([LinkedInAPISecret] = @LinkedInApiSecret AND @LinkedInApiSecret is not null)
	OR ([GoogleClientID] = @GoogleClientId AND @GoogleClientId is not null)
	OR ([GoogleClientSecret] = @GoogleClientSecret AND @GoogleClientSecret is not null)
	OR ([FacebookAppID] = @FacebookAppId AND @FacebookAppId is not null)
	OR ([FacebookAppSecret] = @FacebookAppSecret AND @FacebookAppSecret is not null)
	OR ([LinkedInButtonSize] = @LinkedInButtonSize AND @LinkedInButtonSize is not null)
	OR ([DefaultCountryID] = @DefaultCountryId AND @DefaultCountryId is not null)
	OR ([PayPalUsername] = @PayPalUsername AND @PayPalUsername is not null)
	OR ([PayPalPassword] = @PayPalPassword AND @PayPalPassword is not null)
	OR ([PayPalSignature] = @PayPalSignature AND @PayPalSignature is not null)
	OR ([SecurePayMerchantID] = @SecurePayMerchantId AND @SecurePayMerchantId is not null)
	OR ([SecurePayPassword] = @SecurePayPassword AND @SecurePayPassword is not null)
	OR ([UsingSSL] = @UsingSsl AND @UsingSsl is not null)
	OR ([UseCustomProfessionRole] = @UseCustomProfessionRole AND @UseCustomProfessionRole is not null)
	OR ([GenerateJobXML] = @GenerateJobXml AND @GenerateJobXml is not null)
	OR ([IsPrivateSite] = @IsPrivateSite AND @IsPrivateSite is not null)
	OR ([PrivateRedirectUrl] = @PrivateRedirectUrl AND @PrivateRedirectUrl is not null)
	OR ([EnableJobCustomQuestionnaire] = @EnableJobCustomQuestionnaire AND @EnableJobCustomQuestionnaire is not null)
	OR ([JobApplicationTypeID] = @JobApplicationTypeId AND @JobApplicationTypeId is not null)
	OR ([JobScreeningProcess] = @JobScreeningProcess AND @JobScreeningProcess is not null)
	OR ([AdvertiserApprovalProcess] = @AdvertiserApprovalProcess AND @AdvertiserApprovalProcess is not null)
	OR ([SiteType] = @SiteType AND @SiteType is not null)
	OR ([EnableSSL] = @EnableSsl AND @EnableSsl is not null)
	OR ([GST] = @Gst AND @Gst is not null)
	OR ([GSTLabel] = @GstLabel AND @GstLabel is not null)
	OR ([NumberOfPremiumJobs] = @NumberOfPremiumJobs AND @NumberOfPremiumJobs is not null)
	OR ([PremiumJobDays] = @PremiumJobDays AND @PremiumJobDays is not null)
	OR ([DisplayPremiumJobsOnResults] = @DisplayPremiumJobsOnResults AND @DisplayPremiumJobsOnResults is not null)
	OR ([JobExpiryNotification] = @JobExpiryNotification AND @JobExpiryNotification is not null)
	OR ([CurrencyID] = @CurrencyId AND @CurrencyId is not null)
	OR ([PayPalClientID] = @PayPalClientId AND @PayPalClientId is not null)
	OR ([PayPalClientSecret] = @PayPalClientSecret AND @PayPalClientSecret is not null)
	OR ([PaypalUser] = @PaypalUser AND @PaypalUser is not null)
	OR ([PaypalProPassword] = @PaypalProPassword AND @PaypalProPassword is not null)
	OR ([PaypalVendor] = @PaypalVendor AND @PaypalVendor is not null)
	OR ([PaypalPartner] = @PaypalPartner AND @PaypalPartner is not null)
	OR ([InvoiceSiteInfo] = @InvoiceSiteInfo AND @InvoiceSiteInfo is not null)
	OR ([InvoiceSiteFooter] = @InvoiceSiteFooter AND @InvoiceSiteFooter is not null)
	OR ([EnableTermsAndConditions] = @EnableTermsAndConditions AND @EnableTermsAndConditions is not null)
	OR ([DefaultEmailLanguageId] = @DefaultEmailLanguageId AND @DefaultEmailLanguageId is not null)
	OR ([GoogleTagManager] = @GoogleTagManager AND @GoogleTagManager is not null)
	OR ([GoogleAnalytics] = @GoogleAnalytics AND @GoogleAnalytics is not null)
	OR ([GoogleWebMaster] = @GoogleWebMaster AND @GoogleWebMaster is not null)
	OR ([EnablePeopleSearch] = @EnablePeopleSearch AND @EnablePeopleSearch is not null)
	OR ([GlobalDateFormat] = @GlobalDateFormat AND @GlobalDateFormat is not null)
	OR ([TimeZone] = @TimeZone AND @TimeZone is not null)
	OR ([GlobalFolder] = @GlobalFolder AND @GlobalFolder is not null)
	OR ([EnableScreeningQuestions] = @EnableScreeningQuestions AND @EnableScreeningQuestions is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Delete]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the GlobalSettings table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[GlobalSettings_Delete]
(

	@GlobalSettingId int   
)
AS


				DELETE FROM [dbo].[GlobalSettings] WITH (ROWLOCK) 
				WHERE
					[GlobalSettingID] = @GlobalSettingId
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_CustomGetPaymentDetail]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GlobalSettings_CustomGetPaymentDetail]
(
	@SiteID INT
)
AS
BEGIN
	SELECT PayPalUsername,
			PayPalPassword,
			PayPalSignature,
			SecurePayMerchantID,
			SecurePayPassword
	FROM GlobalSettings WITH (NOLOCK)
	WHERE SiteID = @SiteID
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomUpdateSiteJobCount]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomUpdateSiteJobCount]                             
 @SiteId INT             
AS       
BEGIN                   
BEGIN TRAN       
      
--UPDATE SiteRoles SET TotalJobs = 0 WHERE SiteID = @SiteID       
--UPDATE SiteProfession SET TotalJobs = 0 WHERE SiteID = @SiteID     
      
DECLARE @tmpJobIdSearch TABLE (JobID INT)                   
INSERT INTO @tmpJobIdSearch(JobID) 

      
-- Job Search       
        
 SELECT distinct Jobs.[JobId]                       
   FROM           
  [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter           
  INNER JOIN Jobs (NOLOCK)           
  ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                
  INNER JOIN Advertisers (NOLOCK) Advertisers                     
   ON Jobs.AdvertiserID = Advertisers.AdvertiserID      
   --AND Jobs.SiteID =  @SiteID                      
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
 Jobs.ExpiryDate >= GETDATE()   
                   
-- Update Site Profession                   
DECLARE @tmpProfession TABLE (ProfessionID INT, Total INT)                   
INSERT INTO @tmpProfession(ProfessionID, Total)       
SELECT SiteProfession.ProfessionID, COUNT(1) AS RefineCount        
 FROM [dbo].[Jobs] (NOLOCK)                   
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId                   
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = Jobs.JobId                   
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                   
  INNER JOIN SiteProfession WITH (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID             
 AND SiteProfession.SiteId = @SiteId           
 GROUP BY SiteProfession.ProfessionID            
   
 UPDATE SiteProfession SET TotalJobs = 0 WHERE SiteID = @SiteID 
 UPDATE SiteProfession SET TotalJobs = ISNULL(t.Total, 0) FROM @tmpProfession t WHERE t.ProfessionID = SiteProfession.ProfessionID AND SiteProfession.SiteID = @SiteID       
        
-- Update Site Role       
DECLARE @tmpRoles TABLE (RoleID INT, Total INT)                   
INSERT INTO @tmpRoles(RoleID, Total)                   
SELECT SiteRoles.RoleID, COUNT(1) AS RefineCount        
 FROM [dbo].[Jobs] (NOLOCK)                   
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId                       
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = Jobs.JobId                   
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                   
  INNER JOIN SiteRoles WITH (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID                
 AND SiteRoles.SiteId = @SiteId              
 GROUP BY SiteRoles.RoleID       
   
 UPDATE SiteRoles SET TotalJobs = 0 WHERE SiteID = @SiteID      
 UPDATE SiteRoles SET TotalJobs = ISNULL(t.Total, 0) FROM @tmpRoles t WHERE t.RoleID = SiteRoles.RoleID AND SiteRoles.SiteID = @SiteID       
COMMIT TRAN       
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomUpdateAllSiteJobCount]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomUpdateAllSiteJobCount]
AS
BEGIN
DECLARE @siteid int
 
-- Declare cursor
DECLARE cursorName 
CURSOR -- Declare 
FAST_FORWARD
FOR 
Select siteid from Sites where Live = 1
 
OPEN cursorName -- open the cursor

FETCH NEXT FROM cursorName INTO @siteid
EXEC Jobs_CustomUpdateSiteJobCount @siteid
--PRINT @siteid -- print the name
	
WHILE @@FETCH_STATUS = 0
BEGIN
 
	FETCH NEXT FROM cursorName INTO @siteid
	EXEC Jobs_CustomUpdateSiteJobCount @siteid
	--PRINT @siteid -- print the name

END
 
CLOSE cursorName -- close the cursor
DEALLOCATE cursorName -- Deallocate the cursor

END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomCalculateJobCount]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomCalculateJobCount]
 @SiteID INT,
 @JobID INT,
 @AddJob BIT
AS
BEGIN
	BEGIN TRAN

	DECLARE @NoOfJob INT

	-- Check if it is adding

	SET @NoOfJob = 1

	IF @AddJob = 0
	BEGIN
		SET @NoOfJob = -1
	END

	DECLARE @isPrivate AS BIT
	
	DECLARE @tmpSite TABLE (SiteID INT)
	DECLARE @tmpJobRoles TABLE (RoleID INT)
	DECLARE @tmpJobProfessions TABLE (ProfessionID INT)
	
	DECLARE @tmpSiteRoles TABLE (SiteRoleID INT)
	DECLARE @tmpSiteProfession TABLE (SiteProfessionID INT)

	INSERT INTO @tmpJobRoles (RoleID) SELECT RoleID FROM JobRoles (NOLOCK) WHERE JobID = @JobID
	INSERT INTO @tmpJobProfessions (ProfessionID) SELECT DISTINCT ProfessionID FROM Roles WHERE RoleID IN (SELECT RoleID FROM @tmpJobRoles)

	SET @isPrivate = (SELECT PrivateJobs FROM GlobalSettings (NOLOCK) WHERE SiteID = @SiteID)
	IF @isPrivate = 0 
	BEGIN
		-- Including Public Job Sites
		
		INSERT INTO @tmpSite(SiteID) SELECT SiteID  FROM GlobalSettings (NOLOCK) WHERE PublicJobsSearch = 1 
							UNION SELECT @SiteID 
							UNION SELECT SiteID FROM [dbo].[udfSite_GetAdvertisers](@SiteID) ga 
									INNER JOIN Advertisers a ON ga.AdvertiserID = a.AdvertiserID
	END
	ELSE
	BEGIN
		-- Only current site and site related from advertiser filter
		
		INSERT INTO @tmpSite(SiteID) SELECT @SiteID 
							UNION SELECT SiteID FROM [dbo].[udfSite_GetAdvertisers](@SiteID) ga 
									INNER JOIN Advertisers a ON ga.AdvertiserID = a.AdvertiserID
	END	
	
	-- Update Site Profession

	INSERT INTO @tmpSiteRoles (SiteRoleID) 
	SELECT sr.SiteRoleID 
	FROM @tmpSite ts
	INNER JOIN SiteRoles sr
	ON ts.SiteID = sr.SiteID
	INNER JOIN @tmpJobRoles tr
	ON sr.RoleID = tr.RoleID
		
	UPDATE SiteRoles SET TotalJobs = TotalJobs + @NoOfJob WHERE SiteRoleID IN (SELECT SiteRoleID FROM @tmpSiteRoles)
	
	-- Update Site Role

	INSERT INTO @tmpSiteProfession (SiteProfessionID) 
	SELECT sp.SiteProfessionID
	FROM @tmpSite ts
	INNER JOIN SiteProfession sp
	ON ts.SiteID = sp.SiteID
	INNER JOIN @tmpJobProfessions tp
	ON sp.ProfessionID = tp.ProfessionID
		
	UPDATE SiteProfession SET TotalJobs = TotalJobs + @NoOfJob WHERE SiteProfessionID IN (SELECT SiteProfessionID FROM @tmpSiteProfession)
	COMMIT TRAN
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomUpdateGeoLocations]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomUpdateGeoLocations]  
@XMLFeed XML 
AS       
BEGIN 

DECLARE @ADDRESS_IS_INVALID INT = 0
DECLARE @ADDRESS_IS_VALID INT = 1
DECLARE @ADDRESS_IN_QUEUE INT = 2
/*
SET @XMLFeed = '
<AddressList>
	<Job>
		<Address>156 Woodburn Rd, Berala NSW </Address>
		<JobLatitude>1.03222222</JobLatitude>
		<JobLongitude>1.23423423</JobLongitude>
	</Job>
	<Job>
		<Address>Test 23</Address>
		<JobLatitude>1.63222222</JobLatitude>
		<JobLongitude>1.63423423</JobLongitude>
	</Job>
</AddressList>
'
    */
     
 IF (@XMLFeed IS NOT NULL)          
 BEGIN 

	DECLARE @tmpAddress TABLE ([Address] Varchar(255),JobLatitude float, JobLongitude float, AddressStatus int) 

	INSERT INTO @tmpAddress([Address], JobLatitude, JobLongitude, AddressStatus) 
	 SELECT           
		  Element.value('Address[1]', 'VARCHAR(255)') AS [Address],          
		  Element.value('JobLatitude[1]', 'float') AS JobLatitude,          
		  Element.value('JobLongitude[1]', 'float') AS JobLongitude,		           
		  Element.value('AddressStatus[1]', 'int') AS AddressStatus
	   FROM   @XMLFeed.nodes('/AddressList/Job') Datalist(Element)          
	   OPTION ( OPTIMIZE FOR ( @XMLFeed = NULL ) )      

	
	UPDATE
		Jobs
	SET
		Jobs.JobLatitude = CASE WHEN _TempAddress.AddressStatus = @ADDRESS_IS_INVALID THEN NULL ELSE _TempAddress.JobLatitude END,
		Jobs.JobLongitude = CASE WHEN _TempAddress.AddressStatus = @ADDRESS_IS_INVALID THEN NULL ELSE _TempAddress.JobLongitude END,
		Jobs.AddressStatus = _TempAddress.AddressStatus
	FROM
		@tmpAddress _TempAddress
	 INNER JOIN Jobs (NOLOCK) ON _TempAddress.[Address] = Jobs.[Address]
	 INNER JOIN Integrations (NOLOCK) ON Jobs.SiteID = Integrations.SiteID
	 		
	WHERE  
		(Jobs.AddressStatus = @ADDRESS_IN_QUEUE OR Jobs.AddressStatus IS NULL)	-- Jobs Address in the Queue
		AND Integrations.Valid = 1 
		AND IntegrationType = 10 -- ONLY Google Map Type
	SELECT @@ROWCOUNT     


 END	

END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomArchiveXML]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomArchiveXML]
(
    @AdvertiserId INT,
    @AdvertiserUserName VARCHAR(255),
    @XMLFeed XML,  
    @ClientIPAddress VARCHAR(255),    
	@WebServiceLogId INT OUTPUT   
)
AS
BEGIN
/*
-- Changes - Jan 2015
	-- Todo - Need to remove Valid =1 and test not to archieve failed jobs.
*/

BEGIN TRY

    DECLARE @SiteID INT
    DECLARE @AdvertiserUserId INT
    DECLARE @DateCreated DATETIME = GETDATE()
    DECLARE @FinishedDate DATETIME
    DECLARE @TotalSent INT = 0    
     
    SELECT @AdvertiserUserId = AdvertiserUserID FROM AdvertiserUsers (NOLOCK) WHERE UserName = @AdvertiserUserName
     
     -- Get the SiteID
    SELECT @SiteID = SiteID FROM Advertisers (NOLOCK) WHERE AdvertiserID = @AdvertiserId
        
	DECLARE @SiteURL varchar(500)
	SELECT @SiteURL = 'http://' + ISNULL(SiteURL, '') + '/'  FROM Sites (NOLOCK) WHERE SiteID = @SiteID
	
  
	-- Insert the xml to the WebserviceLog
	INSERT INTO WebServiceLog
           ([ClientIPAddress]
           ,[AdvertiserId]
           ,[AdvertiserUserID]
           ,[CreatedDate]
           ,[MethodInvoked]
           ,[InputXML]
           ,[OutputResponse]
           ,[InvalidXML]
           ,[TotalSent]
           ,[TotalUpdated]
           ,[TotalArchived]
           ,[TotalFailed]
           ,[SiteId]
           ,[FinishedDate])
     VALUES
           (@ClientIPAddress
           ,@AdvertiserId
           ,@AdvertiserUserId
           ,@DateCreated
           ,'Archive'
           ,@XMLFeed
           ,NULL
           ,NULL
           ,0
           ,0
           ,0
           ,0
           ,@SiteID
           ,NULL)

	SET @WebServiceLogId = SCOPE_IDENTITY();
	
	
 BEGIN TRANSACTION PostJobsTransaction
	
    -- ****** Set all the jobs from the XML to a table ******
	CREATE TABLE #FlatXML (
				ReferenceNo VARCHAR(255),
				Valid BIT)
				
	
	-- *************** Archive Missing Jobs *********************
    
	INSERT INTO #FlatXML(ReferenceNo, Valid)
		SELECT 
		   LTRIM(RTRIM(Element.value('ReferenceNo[1]', 'VARCHAR(255)'))) AS RefNo,
		   1 -- By default the reference number is valid
		   FROM   @XMLFeed.nodes('/ArchiveJobRequest/Listings/Job') Datalist(Element)
    OPTION ( OPTIMIZE FOR ( @XMLFeed = NULL ) )
    
    SELECT * FROM #FlatXML
    
    -- Set the valid is false if REFERENCE NO. is not valid
	UPDATE #FlatXML SET Valid = 0
	FROM #FlatXML WHERE 
			NOT EXISTS 
				(SELECT 1 FROM Jobs (NOLOCK) 
						WHERE SiteID = @SiteID AND Expired = 0 AND ExpiryDate >= GETDATE() AND #FlatXML.ReferenceNo = Jobs.RefNo)
	
	-- Set the EXPIRED is true if REFERENCE NO. is valid
	UPDATE Jobs SET Expired = 1, LastModified = GETDATE() 
	FROM Jobs (NOLOCK) 
		WHERE SiteID = @SiteID AND Expired = 0 AND ExpiryDate >= GETDATE() AND 
			EXISTS 
				(SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo)
						
							
									
	
	
	/* TODO - Do we archive instantly ? Need to test performance
	IF (@TotalArchived > 0)
		EXEC Jobs_JobsPurge*/
	
    -- *************** Update the counts ***************
    DECLARE @TotalFailed INT = 0 
    DECLARE @TotalArchived INT = 0
    SELECT @TotalSent = COUNT(*) FROM #FlatXML
    SELECT @TotalArchived = COUNT(*) FROM #FlatXML WHERE Valid = 1 
    SELECT @TotalFailed = COUNT(*) FROM #FlatXML WHERE Valid = 0
    
	
	-- *************** Update the Site Profession FriendlyUrl of all the Jobs *********************	
    CREATE TABLE #TempSiteProfessions (
            ProfessionID INT,
            SiteProfessionFriendlyUrl varchar(255),
            JobID INT NOT NULL,
            RowNumber INT
            );
            
    INSERT INTO #TempSiteProfessions(ProfessionID, SiteProfessionFriendlyUrl, JobID, RowNumber)
    SELECT SiteProfession.ProfessionID, SiteProfessionFriendlyUrl, JobRoles.JobID, 
			ROW_NUMBER() Over(PARTITION BY JobRoles.JobID ORDER BY SiteProfession.SiteProfessionID ASC) as RowNumber 
		FROM 
			JobRoles (NOLOCK) INNER JOIN Roles (NOLOCK) ON JobRoles.RoleID = Roles.RoleID 
				INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID 
		WHERE 
			SiteProfession.SiteID  = @SiteID AND JobRoles.JobID IS NOT NULL
			
			
    DECLARE @JOB_XML_RESPONSE XML  
    SET @FinishedDate = GETDATE()
    
	SET @JOB_XML_RESPONSE =  
	(
		SELECT (Select @DateCreated as DateCreated, @FinishedDate as FinishedDate, 
					@TotalSent as 'Sent', 0 as 'Inserted', 0 as 'Updated', @TotalArchived as 'Archived', @TotalFailed as 'Failed'
				FOR XML PATH('SUMMARY'), type) AS 'JOBSUMMARY',
		(
			Select [ACTION], ReferenceNo, URL, Title, [Message] FROM  (
			
		
			SELECT 'ARCHIVE' as [ACTION], Jobs.RefNo as ReferenceNo, 
					@SiteURL + ISNULL(#TempSiteProfessions.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(JobFriendlyName, '') + 
						'/' + CAST(Jobs.JobID as varchar(10)) as URL, 
					Jobs.JobName as Title,
					'' as [Message]
				FROM Jobs (NOLOCK) 
					INNER JOIN #TempSiteProfessions ON #TempSiteProfessions.JobID = Jobs.JobID  AND #TempSiteProfessions.RowNumber = 1
				WHERE SiteID = @SiteID AND 
					EXISTS 
						(SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo)					
					
			UNION
				SELECT 'ERROR' as [ACTION], ReferenceNo, '' as URL, '' as Title, 'Reference Number was not found' as [Message] FROM #FlatXML WHERE Valid = 0
			
		) as XMLOUTPUT
		FOR XML PATH('JOB'), TYPE
	) AS 'JOBPOSTING' FOR XML PATH (''), ROOT('ROOT'))
	
	
    DROP TABLE #TempSiteProfessions
	
    
	-- Update the xml to the WebserviceLog with the time taken, logs and stats
	UPDATE WebServiceLog 
		SET 
			OutputResponse = @JOB_XML_RESPONSE,
			TotalSent = @TotalSent,
			TotalInserted = 0,
			TotalUpdated = 0,
			TotalArchived = @TotalArchived,
			TotalFailed = @TotalFailed,
			FinishedDate = @FinishedDate
		WHERE 
			WebServiceLogId = @WebServiceLogId
				
	-- *************** Drop the temporary table *********************
    DROP TABLE #FlatXML
    
    
COMMIT TRANSACTION PostJobsTransaction
END TRY
 
BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION PostJobsTransaction --RollBack in case of Error
	 
	-- Raise an error with the details of the exception
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT
	SELECT @ErrMsg = ERROR_MESSAGE(),
	@ErrSeverity = ERROR_SEVERITY()

	-- Update the WebserviceLog there was an error.
	UPDATE WebServiceLog 
		SET 
			TotalSent = @TotalSent,
			OutputResponse = (SELECT ERROR_MESSAGE() + ' [ ERROR_NUMBER : ' + CAST(ERROR_NUMBER() AS VARCHAR(50)) + ' ] ' +  '[ ERROR_LINE : ' + CAST(ERROR_LINE() AS VARCHAR(50)) + ' ] ' FOR XML PATH('ERROR'), ROOT ('ERRORRESULT')),
			TotalFailed = @TotalSent,
			FinishedDate = GETDATE()
		WHERE 
			WebServiceLogId = @WebServiceLogId

	/*		
	IF USER_NAME() IS NOT NULL            
	BEGIN    
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END
	*/
  
END CATCH

    -- *************** OUTPUT *********************
    SELECT WebServiceLogId, CreatedDate, OutputResponse, TotalSent, TotalInserted, TotalUpdated, TotalArchived, TotalFailed, FinishedDate
	FROM WebServiceLog (NOLOCK)
		WHERE 
			WebServiceLogId = @WebServiceLogId			
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetHistoricalJobStatistics]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetHistoricalJobStatistics]           
(           
 @SiteId int,           
 @AdvertiserId int,     
 @EnteredByAdvertiserUserID int,            
 @DateFrom datetime,            
 @DateTo datetime,           
 @SortField varchar(255),            
 @SortASC bit           
)           
As           
BEGIN           
 Declare @dateToday datetime           
 Set @dateToday = dbo.fnGetDate(GETDATE())         
       
 DECLARE @PrimaryAccount BIT      
 SET @PrimaryAccount = 0     
       
 SET @PrimaryAccount = (SELECT PrimaryAccount FROM AdvertiserUsers WHERE AdvertiserUserID = @EnteredByAdvertiserUserID)       
 IF @EnteredByAdvertiserUserID = 0     
 BEGIN     
 SET @PrimaryAccount = 1     
 END     
            
 Declare @sql nvarchar(max) = ''           
 -- build the sql               
 Set @sql = @sql + 'DECLARE @tmpJobsArchive TABLE (JobID INT, JobName NVARCHAR(1020), RefNo VARCHAR(255), DatePosted DATETIME, ExpiryDate DATETIME, JobFriendlyName VARCHAR(512))'
Set @sql = @sql + ' INSERT INTO @tmpJobsArchive'
 Set @sql = @sql + ' SELECT JobID, JobName, RefNo, DatePosted, ExpiryDate, JobFriendlyName'
 Set @sql = @sql + ' FROM JobsArchive j WITH (NOLOCK)'
 Set @sql = @sql + ' WHERE SiteID =  ' + CONVERT(varchar,@SiteId)
 Set @sql = @sql + ' AND AdvertiserID = ' + CONVERT(varchar,@AdvertiserID)
 Set @sql = @sql + ' AND DatePosted <= ''' + CONVERT(varchar,DATEADD(dd, DATEDIFF(dd,0,@DateTo+1), 0)) + ''''
 Set @sql = @sql + ' AND DatePosted >= ''' + CONVERT(varchar,DATEADD(dd, DATEDIFF(dd,0,@DateFrom), 0)) + ''''

 IF ISNULL(@PrimaryAccount, 0) = 0     
  BEGIN     
 SET  @sql = @sql + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)       
 END    

 Set @sql = @sql + ' '
 Set @sql = @sql + ' DECLARE @tmpJobsArchiveView TABLE (JobArchiveID INT, ViewCount INT)'
 Set @sql = @sql + ' INSERT INTO @tmpJobsArchiveView'
 Set @sql = @sql + ' SELECT JobArchiveID, SUM(TotalView) '
 Set @sql = @sql + ' FROM JobViews jv WITH (NOLOCK) WHERE jv.JobArchiveID IN (SELECT JobID FROM @tmpJobsArchive)'
 Set @sql = @sql + ' GROUP BY JobArchiveID'
Set @sql = @sql + ''
 
 /*Set @sql = @sql + ' DECLARE @tmpJobsArchiveApplication TABLE (JobArchiveID INT, ApplicationCount INT)'
 Set @sql = @sql + ' INSERT INTO @tmpJobsArchiveApplication'
 Set @sql = @sql + ' SELECT JobArchiveID, COUNT(*) FROM JobApplication ja WITH (NOLOCK) '
 Set @sql = @sql + ' WHERE ja.JobArchiveID IN (SELECT JobID FROM @tmpJobsArchive) ' --AND ISNULL(Draft,0) = 0
 Set @sql = @sql + ' GROUP BY JobArchiveID '*/
 Set @sql = @sql + ' DECLARE @tmpJobsArchiveApplication TABLE (JobArchiveID INT, ApplicationCount INT)'
 Set @sql = @sql + ' INSERT INTO @tmpJobsArchiveApplication'
 Set @sql = @sql + ' SELECT JobArchiveID, COUNT(*) FROM @tmpJobsArchive tmpJobsArchive'
 Set @sql = @sql + ' INNER JOIN JobApplication ja WITH (NOLOCK) ON ja.JobArchiveID = tmpJobsArchive.JobId AND ISNULL(Draft,0) = 0' --
 Set @sql = @sql + ' GROUP BY JobArchiveID '
 
Set @sql = @sql + ''
 Set @sql = @sql + ' DECLARE @tmpJobsArchiveURL TABLE (JobArchiveID INT, JobFriendlyName VARCHAR(1024))'
 Set @sql = @sql + ' INSERT INTO @tmpJobsArchiveURL'
Set @sql = @sql + ' SELECT j.JobID, ''/'' + ISNULL((SELECT TOP 1 SiteProfessionFriendlyUrl'
 Set @sql = @sql + ' FROM JobRoles (NOLOCK) '                      
 Set @sql = @sql + ' INNER JOIN SiteRoles (NOLOCK) '
 Set @sql = @sql + ' ON SiteRoles.RoleID = JobRoles.RoleID   '
 Set @sql = @sql + ' AND SiteRoles.SiteID =  ' + CONVERT(varchar,@SiteId)
 Set @sql = @sql + ' INNER JOIN Roles (NOLOCK)                         '
 Set @sql = @sql + ' ON Roles.RoleID = JobRoles.RoleID                        '
 Set @sql = @sql + ' INNER JOIN Profession (NOLOCK)                         '
 Set @sql = @sql + ' ON Profession.ProfessionID = Roles.ProfessionID                         '
 Set @sql = @sql + ' INNER JOIN SiteProfession (NOLOCK)                          '
 Set @sql = @sql + ' ON SiteProfession.ProfessionID = Profession.ProfessionID                       '
 Set @sql = @sql + ' AND SiteProfession.SiteID = ' + CONVERT(varchar,@SiteId) + ' WHERE JobRoles.JobArchiveID = j.JobID),'''') + ''-jobs/'' + j.JobFriendlyName as ''JobFriendlyName'' '
 Set @sql = @sql + ' FROM @tmpJobsArchive j'
Set @sql = @sql + ' '
Set @sql = @sql + ' SELECT JobID, JobName, RefNo, DatePosted, ExpiryDate, ISNULL(ViewCount, 0) as Views, ISNULL(ApplicationCount, 0) AS Applications, u.JobFriendlyName'
Set @sql = @sql + ' FROM @tmpJobsArchive j'
Set @sql = @sql + ' LEFT JOIN @tmpJobsArchiveView v'
Set @sql = @sql + ' ON j.JobID = v.JobArchiveID'
Set @sql = @sql + ' LEFT JOIN @tmpJobsArchiveApplication a'
Set @sql = @sql + ' ON j.JobID = a.JobArchiveID'
Set @sql = @sql + ' INNER JOIN @tmpJobsArchiveURL u'
Set @sql = @sql + ' ON j.JobID = u.JobArchiveID'
  
 Set @sql = @sql + ' Order By ' + @sortField            
            
 If @sortAsc = 1           
 Begin           
  Set @sql = @sql + ' asc'           
 End           
 Else           
 Begin           
  Set @sql = @sql + ' desc'           
 End           
     
	print @sql
 -- return results           
 Exec sp_executesql @sql           
            
 IF USER_NAME() IS NULL           
  BEGIN           
   SELECT [JobID], [JobName], [RefNo], [DatePosted]           
   FROM [dbo].[Jobs]  (NOLOCK) WHERE 1=0           
  END           
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetCurrentJobStatistics]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetCurrentJobStatistics]    
(    
 @SiteId int,    
 @AdvertiserId int,  
 @EnteredByAdvertiserUserID int,      
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
 If Not Exists( Select AdvertiserID    
     From Advertisers    
     Where AdvertiserID = @AdvertiserID)    
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
   
 DECLARE @PrimaryAccount BIT   
 SET @PrimaryAccount = 0  
   
 SET @PrimaryAccount = (SELECT PrimaryAccount FROM AdvertiserUsers WHERE AdvertiserUserID = @EnteredByAdvertiserUserID)   
 IF @EnteredByAdvertiserUserID = 0  
 BEGIN  
 SET @PrimaryAccount = 1  
 END  
    
 Declare @sql nvarchar(max)    
 -- build the sql    
 Set @sql = 'SELECT JobID, JobName, RefNo, DatePosted, DATEDIFF(day, dbo.fnGetDate(GETDATE()), dbo.fnGetDate(ExpiryDate)) AS DaysTillExpiry, '    
 Set @sql = @sql + ' ISNULL((SELECT SUM(TotalView) FROM JobViews jv WHERE jv.JobID = j.JobID), 0) AS Views,'    
 Set @sql = @sql + ' (SELECT COUNT(*) FROM JobApplication ja WHERE ja.JobID = j.JobID AND ISNULL(Draft,0) = 0) AS Applications'    
 Set @sql = @sql + ' FROM Jobs j'    
 Set @sql = @sql + ' WHERE SiteID =  ' + CONVERT(varchar, @SiteId)    
 Set @sql = @sql + ' AND AdvertiserID = '  + CONVERT(varchar, @AdvertiserId)    
 Set @sql = @sql + ' AND (Expired = NULL OR Expired = 0)'    
 Set @sql = @sql + ' AND GETDATE() >= dbo.fnGetDate(DatePosted) '    
 Set @sql = @sql + ' AND GETDATE() < dbo.fnGetDate(ExpiryDate)'    
 IF ISNULL(@PrimaryAccount, 0) = 0  
  BEGIN  
 SET  @sql = @sql + ' AND EnteredByAdvertiserUserID = ' + CONVERT(varchar, @EnteredByAdvertiserUserID)    
  END    
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
GO
/****** Object:  StoredProcedure [dbo].[Jobs_JobX_SubmitQueue]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_JobX_SubmitQueue]   
@JobID INT    
AS    
BEGIN    
          
  DECLARE @Message XML    
  CREATE TABLE #XMLMessage    
   (    
    [JobID] INT,    
    [UpdateDate] DATETIME,    
   )    
     
  INSERT INTO #XMLMessage    
    (    
     [JobID],    
     [UpdateDate]    
    )    
  VALUES (    
     @JobID,    
     GETDATE()    
    )    
     
  SELECT @Message = ( SELECT * FROM #XMLMessage    
       FOR XML PATH('Job'),    
         TYPE    
       ) ;    
  -- Above will fomulate valid XML message    
  DECLARE @Handle UNIQUEIDENTIFIER ;    
     
  -- Dialog Conversation starts here    
     
  BEGIN DIALOG CONVERSATION @Handle FROM SERVICE ServiceJobXJobFinishedProcessing TO SERVICE 'ServiceJobXJobUpdate' ON CONTRACT [JobContract] WITH ENCRYPTION = OFF ;    
     
  SEND ON CONVERSATION @Handle MESSAGE TYPE JobDetails (@Message) ;  
      
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetStatistics]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetStatistics]        
(        
 @SiteId int,        
 @AdvertiserId int,    
 @EnteredByAdvertiserUserID int        
)        
AS        
 BEGIN        
         
 DECLARE @StatTotals TABLE        
 (        
  [ReportName] VARCHAR(200),        
  [ReportURL] VARCHAR(200),        
  [Number] INT,        
  [Applications] INT,        
  [Viewed] INT        
 )        
         
 -- Live Jobs        
         
 DECLARE @LiveNumber INT        
 DECLARE @LiveApplications INT        
 DECLARE @LiveViewed INT        
     
 DECLARE @PrimaryAccount BIT     
 SET @PrimaryAccount = 0    
     
 SET @PrimaryAccount = (SELECT PrimaryAccount FROM AdvertiserUsers WHERE AdvertiserUserID = @EnteredByAdvertiserUserID)     
 IF @EnteredByAdvertiserUserID = 0    
 BEGIN    
 SET @PrimaryAccount = 1    
 END    
         
 SET @LiveNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId       
           AND (Expired = NULL OR Expired = 0)
           AND GETDATE() >= dbo.fnGetDate(DatePosted) AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
           AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))     
                 
      
 SET @LiveApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
              AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
              AND GETDATE() >= dbo.fnGetDate(j.DatePosted)       
              AND GETDATE() < dbo.fnGetDate(j.ExpiryDate)    
               AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
               AND  ISNULL(ja.Draft,0) = 0)       
                  
      
 SET @LiveViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
              AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
              AND GETDATE() >= dbo.fnGetDate(j.DatePosted)      
              AND GETDATE() < dbo.fnGetDate(j.ExpiryDate)    
               AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelLiveJobs', 'JobsCurrent.aspx', @LiveNumber, @LiveApplications, ISNULL(@LiveViewed, 0))        
         
 -- Jobs expiring in 24hrs        
         
 DECLARE @ExpiringNumber INT        
 DECLARE @ExpiringApplications INT        
 DECLARE @ExpiringViewed INT        
         
 SET @ExpiringNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
            AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))  AND (Expired = NULL OR Expired = 0)      
            AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @ExpiringApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)       
               AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))       
               AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @ExpiringViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId AND (Expired = NULL OR Expired = 0)
               AND GETDATE() >= DATEADD(DAY, -1, dbo.fnGetDate(ExpiryDate))       
               AND GETDATE() < dbo.fnGetDate(ExpiryDate)    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelJobsExpiringIn24hrs', '', @ExpiringNumber, @ExpiringApplications, ISNULL(@ExpiringViewed, 0))    

 -- Pending Jobs        
 DECLARE @JobScreeningProcess BIT
 SET @JobScreeningProcess = (SELECT JobScreeningProcess FROM GlobalSettings WHERE SiteID = @SiteID)

 DECLARE @PendingNumber INT        
 DECLARE @PendingApplications INT        
 DECLARE @PendingViewed INT   
  
 DECLARE @DeclinedNumber INT        
 DECLARE @DeclinedApplications INT        
 DECLARE @DeclinedViewed INT        
         
IF @JobScreeningProcess = 1
BEGIN

 SET @PendingNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
             AND Expired = 2
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @PendingApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId
               AND j.Expired = 2    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @PendingViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId
               AND Expired = 2
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelPendingJobs', '', @PendingNumber, @PendingApplications, ISNULL(@PendingViewed, 0))
 
 -- Declined  
 SET @DeclinedNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId
             AND Expired = 4
             AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
      
 SET @DeclinedApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
               AND j.AdvertiserID = @AdvertiserId
               AND j.Expired = 4    
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
                AND ISNULL(ja.Draft,0) = 0)                        
      
 SET @DeclinedViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
   AND j.AdvertiserID = @AdvertiserId
               AND Expired = 4
                AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelDeclinedJobs', '', @DeclinedNumber, @DeclinedApplications, ISNULL(@DeclinedViewed, 0))
 
    
END
ELSE
BEGIN
	SET @PendingNumber = 0       
	SET @PendingApplications = 0  
	SET @PendingViewed = 0
	
	SET @DeclinedNumber = 0       
	SET @DeclinedApplications = 0  
	SET @DeclinedViewed = 0
END 
 -- Draft Jobs        
         
 DECLARE @DraftNumber INT        
 DECLARE @DraftApplications INT        
 DECLARE @DraftViewed INT        
         
 SET @DraftNumber = (SELECT COUNT(*) FROM Jobs WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND Expired = 3  AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))         
 SET @DraftApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN Jobs j ON ja.JobID = j.JobID WHERE j.SiteID = @SiteId       
             AND j.AdvertiserID = @AdvertiserId AND Expired = 3    
              AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)) AND ISNULL(ja.Draft,0) = 0)        
              
      
 SET @DraftViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN Jobs j ON jv.JobID = j.JobID WHERE j.SiteID = @SiteId       
             AND j.AdvertiserID = @AdvertiserId AND Expired = 3   
              AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES     ('LabelDraftJobs', 'JobsDraft.aspx', @DraftNumber, @DraftApplications, ISNULL(@DraftViewed, 0))        
         
 -- Archived Jobs        
         
 DECLARE @ArchivedNumber INT        
 DECLARE @ArchivedApplications INT        
 DECLARE @ArchivedViewed INT        
         
 SET @ArchivedNumber = (SELECT COUNT(*) FROM JobsArchive WHERE SiteID = @SiteId AND AdvertiserID = @AdvertiserId AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))   

 
 SET @ArchivedApplications = (SELECT COUNT(*) FROM JobApplication ja INNER JOIN JobsArchive j ON ja.JobArchiveID = j.JobID       
         WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId 
          AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID))
          AND ISNULL(ja.Draft,0) = 0)        
      
 SET @ArchivedViewed = (SELECT SUM(TotalView) FROM JobViews jv INNER JOIN JobsArchive j ON jv.JobArchiveID = j.JobID       
       WHERE j.SiteID = @SiteId AND j.AdvertiserID = @AdvertiserId 
        AND (@PrimaryAccount = 1 OR ((ISNULL(@PrimaryAccount, 0) = 0) AND EnteredByAdvertiserUserID = @EnteredByAdvertiserUserID)))        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)        
 VALUES ('LabelArchivedJobs', 'JobsArchived.aspx', @ArchivedNumber, @ArchivedApplications, ISNULL(@ArchivedViewed, 0))        
 -- Total        
         
 DECLARE @TotalNumber INT        
 DECLARE @TotalApplications INT        
 DECLARE @TotalViewed INT        
         
 SET @TotalNumber = @LiveNumber + @ExpiringNumber + @PendingNumber + @DeclinedNumber + @DraftNumber + @ArchivedNumber        
 SET @TotalApplications = @LiveApplications + @ExpiringApplications + @PendingApplications + @DeclinedApplications + @DraftApplications + @ArchivedApplications        
 SET @TotalViewed = ISNULL(@LiveViewed, 0) + ISNULL(@ExpiringViewed, 0) + ISNULL(@PendingViewed, 0) + ISNULL(@DeclinedViewed, 0) + ISNULL(@DraftViewed, 0) + ISNULL(@ArchivedViewed, 0)        
         
 INSERT INTO @StatTotals (ReportName, ReportURL, Number, Applications, Viewed)      
 VALUES ('LabelTotal', '', @TotalNumber, @TotalApplications, @TotalViewed)        
         
 -- Get Result        
         
 SELECT ReportName, ReportURL, Number, Applications, Viewed FROM @StatTotals        
         
 END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByAdvertiserId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserId]
(

	@AdvertiserId int  ,

	@PageNumber int   ,

	@PageSize int   
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
				 SET @PageEnd = (@PageNumber * @PageSize);

				-- SQL Server 2005 Paging
				WITH PageIndex AS (
				SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex
				, [JobApplicationID]
				, [ApplicationDate]
				, ja.JobID
				, [MemberID]
				, [MemberResumeFile]
				, [MemberCoverLetterFile]
				, [ApplicationStatus]
				, [JobAppValidateID]
				, [SiteID_Referral]
				, [URL_Referral]
				, [ApplicantGrade]
				, [LastViewedDate]
				, [FirstName]
				, [Surname]
				, [EmailAddress]
				, [MobilePhone]
				, [MemberNote]
				, [AdvertiserNote]				
				 FROM [dbo].[JobApplication] ja (NOLOCK)
				 INNER JOIN [dbo].[Jobs] j (NOLOCK)
				 ON ja.JobID = j.JobID
				 WHERE j.AdvertiserID =  + @AdvertiserId
				 ) SELECT
				 [JobApplicationID],
				 [ApplicationDate],
				 [JobID],
				 [MemberID],
				 [MemberResumeFile],
				 [MemberCoverLetterFile],
				 [ApplicationStatus],
				 [JobAppValidateID],
				 [SiteID_Referral],
				 [URL_Referral],
				 [ApplicantGrade],
				 [LastViewedDate],
				 [FirstName],
				 [Surname],
				 [EmailAddress],
				 [MobilePhone],
				 [MemberNote],
				 [AdvertiserNote], 
				(SELECT COUNT(1) FROM PageIndex) AS TotalCount
				 FROM PageIndex
				 WHERE RowIndex >= @PageStart      
				 AND	RowIndex <= @PageEnd      
				 ORDER BY RowIndex 
			
				END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_CustomGetJobApplicationDetails]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_CustomGetJobApplicationDetails]              
(              
 @ApplicationDate datetime  ,              
 @SiteID int
)              
AS              
BEGIN            
       
	    
	--DECLARE @SiteID INT = 281
	--DECLARE @ApplicationDate datetime = '2014-11-04'           
	DECLARE @AppDate datetime     
	SET @AppDate = dbo.fnGetDate(DATEADD(dd, 0, @ApplicationDate))            
	             
	SELECT j.JobID, j.RefNo, j.JobName, a.AdvertiserID, a.CompanyName, ja.MemberID, ja.FirstName, ja.Surname, ja.URL_Referral, ja.AppliedWith,
	CONVERT(DATE, ApplicationDate) as ApplicationDate
	FROM 
		JobApplication ja (NOLOCK) INNER JOIN Jobs j (NOLOCK)            
			ON ja.JobID = j.JobID AND j.SiteID = @SiteID
		INNER JOIN Advertisers a (NOLOCK) ON a.AdvertiserID = j.AdvertiserID
	WHERE CONVERT(DATE, ApplicationDate) = @AppDate AND ISNULL(ja.Draft,0) = 0  
	
	UNION
	
	SELECT j.JobID, j.RefNo, j.JobName, a.AdvertiserID, a.CompanyName, ja.MemberID, ja.FirstName, ja.Surname, ja.URL_Referral, ja.AppliedWith,
	CONVERT(DATE, ApplicationDate) as ApplicationDate
	FROM 
		JobApplication ja (NOLOCK) INNER JOIN JobsArchive j (NOLOCK)            
			ON ja.JobArchiveID = j.JobID AND j.SiteID = @SiteID
		INNER JOIN Advertisers a (NOLOCK) ON a.AdvertiserID = j.AdvertiserID
	WHERE CONVERT(DATE, ApplicationDate) = @AppDate AND ISNULL(ja.Draft,0) = 0  
	
END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_JobUnarchive]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_JobUnarchive]  
(    
 @JobID INT = 0    
)    
AS    
BEGIN TRY    
BEGIN TRANSACTION JobTransaction    
 
 -- Before Archiving a Job, manually expiry the job = 0 .. example - update JobsArchive SET Expired = 0 where JobID= @Jobid    
 SET IDENTITY_INSERT [Jobs] ON    
    
 INSERT INTO [dbo].[Jobs]    
      ([JobID]    
      ,[SiteID]    
      ,[WorkTypeID]    
      ,[JobName]    
      ,[Description]    
      ,[FullDescription]    
      ,[WebServiceProcessed]    
      ,[ApplicationEmailAddress]    
      ,[RefNo]    
      ,[Visible]    
      ,[DatePosted]    
      ,[ExpiryDate]    
      ,[Expired]    
      ,[JobItemPrice]    
      ,[Billed]    
      ,[LastModified]    
      ,[ShowSalaryDetails]    
      ,[SalaryText]    
      ,[AdvertiserID]    
      ,[LastModifiedByAdvertiserUserId]    
      ,[LastModifiedByAdminUserId]    
      ,[JobItemTypeID]    
      ,[ApplicationMethod]    
      ,[ApplicationURL]    
      ,[UploadMethod]    
      ,[Tags]    
      ,[JobTemplateID]    
      ,[SearchFieldExtension]    
      ,[AdvertiserJobTemplateLogoID]    
      ,[CompanyName]    
      ,[HashValue]    
      ,[RequireLogonForExternalApplications]    
      ,[ShowLocationDetails]    
      ,[PublicTransport]    
      ,[Address]    
      ,[ContactDetails]    
      ,[JobContactPhone]    
      ,[JobContactName]    
      ,[QualificationsRecognised]    
      ,[ResidentOnly]    
      ,[DocumentLink]    
      ,[BulletPoint1]    
      ,[BulletPoint2]    
      ,[BulletPoint3]    
      ,[HotJob]    
      ,[JobFriendlyName]    
      ,[SearchField]  
   ,[ShowSalaryRange]  
   ,[CurrencyID]  
  ,[SalaryUpperBand]  
  ,[SalaryLowerBand]  
  ,[SalaryTypeID]  
  ,[EnteredByAdvertiserUserID])    
    
     SELECT [JobID]    
           ,[SiteID]    
           ,[WorkTypeID]    
           ,[JobName]    
           ,[Description]    
           ,[FullDescription]    
           ,[WebServiceProcessed]    
           ,[ApplicationEmailAddress]    
           ,[RefNo]    
           ,[Visible]    
           ,[DatePosted]    
           ,[ExpiryDate]    
           ,[Expired]    
           ,[JobItemPrice]    
           ,[Billed]    
           ,[LastModified]    
           ,[ShowSalaryDetails]    
           ,[SalaryText]    
           ,[AdvertiserID]    
           ,[LastModifiedByAdvertiserUserId]    
           ,[LastModifiedByAdminUserId]    
           ,[JobItemTypeID]    
           ,[ApplicationMethod]    
           ,[ApplicationURL]    
           ,[UploadMethod]    
           ,[Tags]    
           ,[JobTemplateID]    
           ,[SearchFieldExtension]    
           ,[AdvertiserJobTemplateLogoID]    
           ,[CompanyName]    
           ,[HashValue]    
           ,[RequireLogonForExternalApplications]    
           ,[ShowLocationDetails]    
           ,[PublicTransport]    
           ,[Address]    
           ,[ContactDetails]    
           ,[JobContactPhone]    
           ,[JobContactName]    
           ,[QualificationsRecognised]    
           ,[ResidentOnly]    
           ,[DocumentLink]    
           ,[BulletPoint1]    
           ,[BulletPoint2]    
           ,[BulletPoint3]    
           ,[HotJob]    
           ,[JobFriendlyName]    
           ,[SearchField]    
     ,[ShowSalaryRange]  
   ,[CurrencyID]  
     ,[SalaryUpperBand]  
     ,[SalaryLowerBand]  
     ,[SalaryTypeID]  
     ,[EnteredByAdvertiserUserID]  
       
 FROM JobsArchive (NOLOCK)    
 WHERE JobID = @JobID    
     
 SET IDENTITY_INSERT [Jobs] OFF    
    
 UPDATE JobRoles SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID    
 UPDATE JobsSaved SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID    
 UPDATE JobViews SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID    
 UPDATE JobApplication SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID    
 UPDATE JobArea SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 UPDATE InvoiceItem SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID    
 DELETE FROM JobsArchive WHERE JobID = @JobID    
     
COMMIT TRANSACTION JobTransaction    
END TRY    
     
BEGIN CATCH    
IF @@TRANCOUNT > 0    
ROLLBACK TRANSACTION JobTransaction --RollBack in case of Error    
     
-- Raise an error with the details of the exception    
DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT    
SELECT @ErrMsg = ERROR_MESSAGE(),    
@ErrSeverity = ERROR_SEVERITY()    
     
RAISERROR(@ErrMsg, @ErrSeverity, 1)    
     
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByRoleId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobsArchive_GetByRoleId]
(

	@RoleId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobID],
					[ProfessionID],
					[RoleID],
					[WorkTypeID],
					[SalaryID],
					[LocationID],
					[AreaID],
					[JobName],
					[Description],
					[FullDescription],
					[ShowSalary],
					[WebServiceProcessed],
					[ResidentOnly],
					[LastModified],
					[ApplicationEmailAddress],
					[RefNo],
					[ContactDetails],
					[Visible],
					[ExpiryDate]
				FROM
					[dbo].[Jobs-Archive] (NOLOCK)
				WHERE
					[RoleID] = @RoleId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByProfessionId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobsArchive_GetByProfessionId]
(

	@ProfessionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobID],
					[ProfessionID],
					[RoleID],
					[WorkTypeID],
					[SalaryID],
					[LocationID],
					[AreaID],
					[JobName],
					[Description],
					[FullDescription],
					[ShowSalary],
					[WebServiceProcessed],
					[ResidentOnly],
					[LastModified],
					[ApplicationEmailAddress],
					[RefNo],
					[ContactDetails],
					[Visible],
					[ExpiryDate]
				FROM
					[dbo].[Jobs-Archive] (NOLOCK)
				WHERE
					[ProfessionID] = @ProfessionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByLocationId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobsArchive_GetByLocationId]
(

	@LocationId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobID],
					[ProfessionID],
					[RoleID],
					[WorkTypeID],
					[SalaryID],
					[LocationID],
					[AreaID],
					[JobName],
					[Description],
					[FullDescription],
					[ShowSalary],
					[WebServiceProcessed],
					[ResidentOnly],
					[LastModified],
					[ApplicationEmailAddress],
					[RefNo],
					[ContactDetails],
					[Visible],
					[ExpiryDate]
				FROM
					[dbo].[Jobs-Archive] (NOLOCK)
				WHERE
					[LocationID] = @LocationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobsArchive_GetByAreaId]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobsArchive_GetByAreaId]
(

	@AreaId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobID],
					[ProfessionID],
					[RoleID],
					[WorkTypeID],
					[SalaryID],
					[LocationID],
					[AreaID],
					[JobName],
					[Description],
					[FullDescription],
					[ShowSalary],
					[WebServiceProcessed],
					[ResidentOnly],
					[LastModified],
					[ApplicationEmailAddress],
					[RefNo],
					[ContactDetails],
					[Visible],
					[ExpiryDate]
				FROM
					[dbo].[Jobs-Archive] (NOLOCK)
				WHERE
					[AreaID] = @AreaId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Jobs_GetJobApplicationAndViewsDetail]    Script Date: 01/20/2017 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_GetJobApplicationAndViewsDetail]         
(          
 @SiteID int = 0,          
 @FromDate datetime,          
 @Duration int          
)          
AS          
BEGIN 


  DECLARE @StartDate datetime          
  DECLARE @EndDate datetime   
  SET @StartDate = dbo.fnGetDate(DATEADD(dd, 0, @FromDate))          
  SET @EndDate = dbo.fnGetDate(DATEADD(dd, @Duration, @FromDate))   
  --SELECT @StartDate, @EndDate
  
SELECT CONVERT(DATE, ViewDate) as ViewDate, DomainReferral as ViewDomainReferral, SUM(TotalView) as ViewCount         
FROM 
	JobViews WITH (NOLOCK)          
WHERE 
	ViewDate >= @StartDate AND ViewDate < @EndDate AND (SiteID = @SiteID OR @SiteID = 0)    
GROUP by 
	CONVERT(DATE, ViewDate), DomainReferral 
ORDER BY ViewDate
	
Select ApplicationDate, URL_Referral, AppliedWith, Sum(ApplicationCount) as ApplicationCount FROM ( 
SELECT CONVERT(DATE, ApplicationDate) as ApplicationDate, URL_Referral, AppliedWith, COUNT(*) as ApplicationCount           
   FROM JobApplication ja  WITH (NOLOCK)          
   INNER JOIN Jobs j WITH (NOLOCK)          
   ON ja.JobID = j.JobID          
   WHERE ApplicationDate >= @StartDate AND ApplicationDate < @EndDate           
   AND (SiteID = @SiteID OR @SiteID = 0) AND ISNULL(ja.Draft,0) = 0
GROUP by CONVERT(DATE, ApplicationDate), URL_Referral, AppliedWith
UNION   
  SELECT CONVERT(DATE, ApplicationDate) as ApplicationDate, URL_Referral, AppliedWith, COUNT(*) as ApplicationCount          
   FROM JobApplication ja  WITH (NOLOCK)          
   INNER JOIN JobsArchive j WITH (NOLOCK)          
   ON ja.JobArchiveID = j.JobID          
   WHERE ApplicationDate >= @StartDate AND ApplicationDate < @EndDate           
   AND (SiteID = @SiteID OR @SiteID = 0) AND ISNULL(ja.Draft,0) = 0
GROUP by CONVERT(DATE, ApplicationDate), URL_Referral, AppliedWith  
) GG
GROUP by ApplicationDate, URL_Referral, AppliedWith
ORDER BY ApplicationDate
  
  /*
SELECT ISNULL(ViewDate, _Application.ApplicationDate) as ViewDate,ViewDomainReferral,ISNULL(ViewCount,0) as ViewCount,
	_Application.ApplicationDate,  _Application.ApplicationDomainReferral, ISNULL(_Application.ApplicationCount,0) as ApplicationCount 
FROM 
(  
	SELECT CONVERT(DATE, ViewDate) as ViewDate, DomainReferral as ViewDomainReferral, SUM(TotalView) as ViewCount         
	FROM 
		JobViews WITH (NOLOCK)          
	WHERE 
		ViewDate >= @StartDate AND ViewDate < @EndDate AND (SiteID = @SiteID OR @SiteID = 0)    
	GROUP by 
		CONVERT(DATE, ViewDate), DomainReferral     

	) _Views FULL OUTER JOIN 
	(
	Select ApplicationDate, ApplicationDomainReferral, Sum(ApplicationCount) as ApplicationCount FROM ( 
	SELECT CONVERT(DATE, ApplicationDate) as ApplicationDate, URL_Referral as ApplicationDomainReferral, COUNT(*) as ApplicationCount           
	   FROM JobApplication ja  WITH (NOLOCK)          
	   INNER JOIN Jobs j WITH (NOLOCK)          
	   ON ja.JobID = j.JobID          
	   WHERE ApplicationDate >= @StartDate AND ApplicationDate < @EndDate           
	   AND (SiteID = @SiteID OR @SiteID = 0) AND ISNULL(ja.Draft,0) = 0
	GROUP by CONVERT(DATE, ApplicationDate), URL_Referral
	UNION   
	  SELECT CONVERT(DATE, ApplicationDate) as ApplicationDate, URL_Referral as ApplicationDomainReferral, COUNT(*) as ApplicationCount          
	   FROM JobApplication ja  WITH (NOLOCK)          
	   INNER JOIN JobsArchive j WITH (NOLOCK)          
	   ON ja.JobArchiveID = j.JobID          
	   WHERE ApplicationDate >= @StartDate AND ApplicationDate < @EndDate           
	   AND (SiteID = @SiteID OR @SiteID = 0) AND ISNULL(ja.Draft,0) = 0
	GROUP by CONVERT(DATE, ApplicationDate), URL_Referral  
	) GG
	GROUP by ApplicationDate, ApplicationDomainReferral

) 
_Application ON ISNULL(ViewDate, _Application.ApplicationDate) = _Application.ApplicationDate AND ISNULL(_Views.ViewDomainReferral,'') = ISNULL(_Application.ApplicationDomainReferral,'')
ORDER BY 
	ISNULL(ViewDate, _Application.ApplicationDate), ApplicationDate, ViewDomainReferral   
*/
IF USER_NAME() IS NULL          
 BEGIN          
  SELECT [MemberID], [FirstName], [Surname], [LocationID], [AreaID], [PreferredCategoryID],           
      [PreferredSubCategoryID], [LastModifiedDate],  [PreferredSalaryID]          
  FROM [dbo].[Members]  (NOLOCK) WHERE 1=0          
 END    

END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetJobsNameByMemberId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_GetJobsNameByMemberId]                      
(                      
 @MemberID INT,                  
 @PageSize INT,                            
 @PageNumber INT                         
)                      
                      
AS                    
BEGIN                  
                  
DECLARE @SiteID INT                 
                
SET @SiteID = (Select SiteID from Members (NOLOCK) where MemberID = @MemberID)                
                
 IF @PageSize IS NULL                          
  SET @pageSize = 10                          
                          
 IF @PageNumber IS NULL                          
  SET @PageNumber = 1                          
                          
 Declare @pageStart int                          
 Declare @pageEnd int                          
                          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1                          
 SET @PageEnd = (@PageNumber * @PageSize);                        
                  
 WITH JobApplicationJobNameByMember AS                   
(                   
 SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY JobApplication.JobApplicationID DESC) AS RowNumber, JobApplication.JobApplicationID AS JobApplicationID,                     
  JobApplication.ApplicationDate AS ApplicationDate, JobApplication.MemberID AS MemberID, JobApplication.ApplicationStatus AS ApplicationStatus,                     
  ISNULL(Jobs.JobID, JobsArchive.JobID) AS JobID, ISNULL(Jobs.JobName, JobsArchive.JobName) AS JobName, Jobs.RefNo, Advertisers.AdvertiserID AS AdvertiserID, Advertisers.CompanyName AS CompanyName,        
  '/' + ISNULL((SELECT TOP 1 SiteProfessionFriendlyUrl         
 FROM JobRoles (NOLOCK)                           
  INNER JOIN SiteRoles (NOLOCK)                           
  ON SiteRoles.RoleID = JobRoles.RoleID                        
  AND SiteRoles.SiteID = @SiteID                            
  INNER JOIN Roles (NOLOCK)                           
  ON Roles.RoleID = JobRoles.RoleID                          
  INNER JOIN Profession (NOLOCK)                           
  ON Profession.ProfessionID = Roles.ProfessionID                          
  INNER JOIN SiteProfession (NOLOCK)                           
  ON SiteProfession.ProfessionID = Profession.ProfessionID                         
  AND SiteProfession.SiteID = @SiteID WHERE (JobRoles.JobID = JobApplication.JobID OR JobRoles.JobArchiveID = JobApplication.JobArchiveID)),'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, JobsArchive.JobFriendlyName) as 'JobFriendlyName'                  
 FROM   JobApplication JobApplication                             
 LEFT JOIN  Jobs (NOLOCK) ON JobApplication.JobID = Jobs.JobID                      
 LEFT JOIN  JobsArchive (NOLOCK) ON JobApplication.JobArchiveID = JobsArchive.JobID  
 INNER JOIN  Advertisers (NOLOCK) ON Advertisers.AdvertiserID = Jobs.AdvertiserID OR Advertisers.AdvertiserID = JobsArchive.AdvertiserID  
                       
 WHERE  JobApplication.MemberID = @MemberID AND ISNULL(JobApplication.Draft,0) = 0   
 AND (Jobs.ExpiryDate > DATEADD(dd, -180, GETDATE()) OR JobsArchive.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 90 days from expiry  
 )                  
                  
SELECT JobApplicationID, ApplicationDate, MemberID, ApplicationStatus, JobID, JobName, RefNo, JobFriendlyName, AdvertiserID, CompanyName,                  
     (SELECT COUNT(1) FROM JobApplicationJobNameByMember) AS TotalCount                  
FROM    JobApplicationJobNameByMember WITH (NOLOCK)                   
WHERE   MemberID = @MemberID                  
 AND RowNumber >= @PageStart                        
 AND RowNumber <= @PageEnd                        
ORDER BY RowNumber                  
                  
END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByAdvertiserIdJobId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserIdJobId]                  
(                  
                  
 @AdvertiserId int  ,                  
                  
 @JobId int,                  
                  
 @PageNumber int   ,                  
                  
 @PageSize int                     
)                  
AS                  
                  
    BEGIN                  
    IF @PageSize IS NULL                          
      SET @pageSize = 10                          
                              
     IF @PageNumber IS NULL                          
      SET @PageNumber = 0                          
                              
     Declare @pageStart int                          
     Declare @pageEnd int                          
                              
     SET @PageStart = (@PageNumber * @PageSize) + 1                  
     SET @PageEnd = ((@PageNumber + 1) * @PageSize);                  
                  
    -- SQL Server 2005 Paging                  
    WITH PageIndex AS (                  
    SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex                  
    , [JobApplicationID]                  
    , [ApplicationDate]                  
    , ja.JobID                  
    , ja.[MemberID]                  
    , [MemberResumeFile]                  
    , [MemberCoverLetterFile]                  
    , [ApplicationStatus]                  
    , [JobAppValidateID]                  
    , [SiteID_Referral]                  
    , [URL_Referral]                  
    , [ApplicantGrade]                  
    , [LastViewedDate]         
                   
    , m.[FirstName]                  
    , m.[Surname]                  
    , m.[EmailAddress]                  
    , m.[MobilePhone]        
                   
    , m.PostCode              
    , m.States               
    , [MemberNote]                  
    , [AdvertiserNote]                 
    , [CustomQuestionnaireXML]                     
    , ExternalPDFFilename              
    , FileDownloaded              
     FROM [dbo].[JobApplication] ja (NOLOCK)                  
     LEFT JOIN [dbo].[Jobs] j (NOLOCK) ON ja.JobID = j.JobID                  
     LEFT JOIN Members m (NOLOCK) ON m.MemberID = ja.MemberID              
     WHERE j.AdvertiserID = @AdvertiserId AND ISNULL(ja.Draft,0) = 0          
     AND ((ISNULL(@JobId,0) = 0 OR ja.JobID = @JobId))                
     ) SELECT                  
     [JobApplicationID],                  
     [ApplicationDate],                  
     [JobID],                  
     [MemberID],                  
     [MemberResumeFile],                  
     [MemberCoverLetterFile],               
    ExternalPDFFilename,                 
     [ApplicationStatus],                  
     [JobAppValidateID],                  
     [SiteID_Referral],                  
     [URL_Referral],                  
     [ApplicantGrade],                  
     [LastViewedDate],                  
     [FirstName],                  
     [Surname],                  
     [EmailAddress],                  
     [MobilePhone],                  
  PostCode,              
     States,                
     [MemberNote],                  
     [AdvertiserNote],                
     FileDownloaded,                
    [CustomQuestionnaireXML] ,                 
    (SELECT COUNT(1) FROM PageIndex) AS TotalCount                  
     FROM PageIndex                  
     WHERE RowIndex >= @PageStart                        
     AND RowIndex <= @PageEnd                        
     ORDER BY RowIndex                   
                     
    END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByAdvertiserIdJobArchiveId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserIdJobArchiveId]            
(            
            
 @AdvertiserId int  ,            
            
 @JobArchiveId int  ,            
            
 @PageNumber int   ,            
            
 @PageSize int               
)            
AS            
            
    BEGIN            
    IF @PageSize IS NULL                    
      SET @pageSize = 10                    
                        
     IF @PageNumber IS NULL                    
      SET @PageNumber = 0                    
                        
     Declare @pageStart int                    
     Declare @pageEnd int                    
                        
     SET @PageStart = (@PageNumber) * (@PageSize + 1)            
     SET @PageEnd = ((@PageNumber + 1) * @PageSize);            
            
    -- SQL Server 2005 Paging            
    WITH PageIndex AS (            
    SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex            
    , [JobApplicationID]            
    , [ApplicationDate]            
    , ja.JobID            
    , ja.[MemberID]            
    , [MemberResumeFile]            
    , [MemberCoverLetterFile]            
    , [ApplicationStatus]            
    , [JobAppValidateID]            
    , [SiteID_Referral]            
    , [URL_Referral]            
    , [ApplicantGrade]            
    , [LastViewedDate]   
               
    , m.[FirstName]            
    , m.[Surname]            
    , m.[EmailAddress]            
    , m.[MobilePhone]   
              
    , m.PostCode        
    , m.States         
    , [MemberNote]            
    , [AdvertiserNote]           
    , [CustomQuestionnaireXML]               
    , ExternalPDFFilename        
    , FileDownloaded        
     FROM [dbo].[JobApplication] ja (NOLOCK)            
     INNER JOIN [dbo].[JobsArchive] j (NOLOCK) ON ja.JobArchiveID = j.JobID             
     LEFT JOIN Members m (NOLOCK) ON m.MemberID = ja.MemberID             
     WHERE j.AdvertiserID = @AdvertiserId AND ISNULL(ja.Draft,0) = 0          
     AND ja.JobArchiveID = @JobArchiveId            
     ) SELECT            
     [JobApplicationID],            
     [ApplicationDate],            
     [JobID],            
     [MemberID],            
     [MemberResumeFile],            
     [MemberCoverLetterFile],         
    ExternalPDFFilename,           
     [ApplicationStatus],            
     [JobAppValidateID],            
     [SiteID_Referral],            
     [URL_Referral],            
     [ApplicantGrade],            
     [LastViewedDate],            
     [FirstName],            
     [Surname],            
     [EmailAddress],            
     [MobilePhone],            
  PostCode,        
     States,          
     [MemberNote],            
     [AdvertiserNote],           
     FileDownloaded,         
    [CustomQuestionnaireXML] ,          
    (SELECT COUNT(1) FROM PageIndex) AS TotalCount            
     FROM PageIndex            
     WHERE RowIndex >= @PageStart                  
     AND RowIndex <= @PageEnd                  
     ORDER BY RowIndex             
               
    END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_CustomGetDraftJobsByMemberId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_CustomGetDraftJobsByMemberId]                      
(                      
 @MemberID INT,                  
 @PageSize INT,                            
 @PageNumber INT                         
)                      
                      
AS                    
BEGIN                  
                  
DECLARE @SiteID INT                 
                
SET @SiteID = (Select SiteID from Members (NOLOCK) where MemberID = @MemberID)                
                
 IF @PageSize IS NULL                          
  SET @pageSize = 10                          
                          
 IF @PageNumber IS NULL                          
  SET @PageNumber = 1                          
                          
 Declare @pageStart int                          
 Declare @pageEnd int                          
                          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1                          
 SET @PageEnd = (@PageNumber * @PageSize);                        
                  
 WITH JobApplicationJobNameByMember AS                   
(                   
 SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY JobApplication.JobApplicationID DESC) AS RowNumber, JobApplication.JobApplicationID AS JobApplicationID,                   
  Jobs.DatePosted AS DatePosted, JobApplication.MemberID AS MemberID, JobApplication.ApplicationStatus AS ApplicationStatus, JobApplication.URL_Referral AS URLReferral,               
  Jobs.JobID AS JobID, Jobs.JobName AS JobName, Advertisers.AdvertiserID AS AdvertiserID, Advertisers.CompanyName AS CompanyName,      
  '/' + ISNULL((SELECT TOP 1 SiteProfessionFriendlyUrl       
 FROM JobRoles (NOLOCK)                         
  INNER JOIN SiteRoles (NOLOCK)                         
  ON SiteRoles.RoleID = JobRoles.RoleID                      
  AND SiteRoles.SiteID = @SiteID                          
  INNER JOIN Roles (NOLOCK)                         
  ON Roles.RoleID = JobRoles.RoleID                        
  INNER JOIN Profession (NOLOCK)                         
  ON Profession.ProfessionID = Roles.ProfessionID                        
  INNER JOIN SiteProfession (NOLOCK)                         
  ON SiteProfession.ProfessionID = Profession.ProfessionID                       
  AND SiteProfession.SiteID = @SiteID WHERE JobRoles.JobID = JobApplication.JobID),'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'                
 FROM   JobApplication JobApplication                  
 INNER JOIN  Jobs (NOLOCK) ON JobApplication.JobID = Jobs.JobID                      
 INNER JOIN  Advertisers (NOLOCK) ON Advertisers.AdvertiserID = Jobs.AdvertiserID                    
                       
 WHERE  JobApplication.MemberID = @MemberID AND JobApplication.Draft = 1                
 )                  
                  
SELECT JobApplicationID, DatePosted, MemberID, ApplicationStatus, JobID, JobName, JobFriendlyName, AdvertiserID, CompanyName,                  
     (SELECT COUNT(*) FROM JobApplicationJobNameByMember NOLOCK) AS TotalCount                  
FROM    JobApplicationJobNameByMember WITH (NOLOCK)                   
WHERE   MemberID = @MemberID                  
 AND RowNumber >= @PageStart                        
 AND RowNumber <= @PageEnd                        
ORDER BY RowNumber                   
                  
END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetBySiteIdReferral]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobApplication table through a foreign key
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetBySiteIdReferral]
(

	@SiteIdReferral int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
				WHERE
					[SiteID_Referral] = @SiteIdReferral
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByMemberId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobApplication table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetByMemberId]
(

	@MemberId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
				WHERE
					[MemberID] = @MemberId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByJobId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobApplication table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetByJobId]
(

	@JobId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobID] = @JobId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByJobArchiveId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobApplication table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetByJobArchiveId]
(

	@JobArchiveId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobArchiveID] = @JobArchiveId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetByJobApplicationId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the JobApplication table through an index
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetByJobApplicationId]
(

	@JobApplicationId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobApplicationID] = @JobApplicationId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_Get_List]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the JobApplication table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_Get_List]

AS


				
				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid]
				FROM
					[dbo].[JobApplication]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_Find]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the JobApplication table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_Find]
(

	@SearchUsingOR bit   = null ,

	@JobApplicationId int   = null ,

	@ApplicationDate smalldatetime   = null ,

	@JobId int   = null ,

	@MemberId int   = null ,

	@MemberResumeFile varchar (255)  = null ,

	@MemberCoverLetterFile varchar (255)  = null ,

	@ApplicationStatus int   = null ,

	@JobAppValidateId uniqueidentifier   = null ,

	@SiteIdReferral int   = null ,

	@UrlReferral varchar (255)  = null ,

	@ApplicantGrade int   = null ,

	@LastViewedDate datetime   = null ,

	@FirstName nvarchar (255)  = null ,

	@Surname nvarchar (255)  = null ,

	@EmailAddress varchar (255)  = null ,

	@MobilePhone char (40)  = null ,

	@MemberNote nvarchar (MAX)  = null ,

	@AdvertiserNote nvarchar (MAX)  = null ,

	@JobArchiveId int   = null ,

	@Draft bit   = null ,

	@JobApplicationTypeId int   = null ,

	@ExternalXmlFilename varchar (255)  = null ,

	@CustomQuestionnaireXml nvarchar (MAX)  = null ,

	@ExternalPdfFilename varchar (255)  = null ,

	@FileDownloaded bit   = null ,

	@AppliedWith varchar (255)  = null ,

	@ScreeningQuestionaireXml nvarchar (MAX)  = null ,

	@ScreeningQuestionsGuid uniqueidentifier   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobApplicationID]
	, [ApplicationDate]
	, [JobID]
	, [MemberID]
	, [MemberResumeFile]
	, [MemberCoverLetterFile]
	, [ApplicationStatus]
	, [JobAppValidateID]
	, [SiteID_Referral]
	, [URL_Referral]
	, [ApplicantGrade]
	, [LastViewedDate]
	, [FirstName]
	, [Surname]
	, [EmailAddress]
	, [MobilePhone]
	, [MemberNote]
	, [AdvertiserNote]
	, [JobArchiveID]
	, [Draft]
	, [JobApplicationTypeID]
	, [ExternalXMLFilename]
	, [CustomQuestionnaireXML]
	, [ExternalPDFFilename]
	, [FileDownloaded]
	, [AppliedWith]
	, [ScreeningQuestionaireXML]
	, [ScreeningQuestionsGuid]
    FROM
	[dbo].[JobApplication]
    WHERE 
	 ([JobApplicationID] = @JobApplicationId OR @JobApplicationId IS NULL)
	AND ([ApplicationDate] = @ApplicationDate OR @ApplicationDate IS NULL)
	AND ([JobID] = @JobId OR @JobId IS NULL)
	AND ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([MemberResumeFile] = @MemberResumeFile OR @MemberResumeFile IS NULL)
	AND ([MemberCoverLetterFile] = @MemberCoverLetterFile OR @MemberCoverLetterFile IS NULL)
	AND ([ApplicationStatus] = @ApplicationStatus OR @ApplicationStatus IS NULL)
	AND ([JobAppValidateID] = @JobAppValidateId OR @JobAppValidateId IS NULL)
	AND ([SiteID_Referral] = @SiteIdReferral OR @SiteIdReferral IS NULL)
	AND ([URL_Referral] = @UrlReferral OR @UrlReferral IS NULL)
	AND ([ApplicantGrade] = @ApplicantGrade OR @ApplicantGrade IS NULL)
	AND ([LastViewedDate] = @LastViewedDate OR @LastViewedDate IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Surname] = @Surname OR @Surname IS NULL)
	AND ([EmailAddress] = @EmailAddress OR @EmailAddress IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([MemberNote] = @MemberNote OR @MemberNote IS NULL)
	AND ([AdvertiserNote] = @AdvertiserNote OR @AdvertiserNote IS NULL)
	AND ([JobArchiveID] = @JobArchiveId OR @JobArchiveId IS NULL)
	AND ([Draft] = @Draft OR @Draft IS NULL)
	AND ([JobApplicationTypeID] = @JobApplicationTypeId OR @JobApplicationTypeId IS NULL)
	AND ([ExternalXMLFilename] = @ExternalXmlFilename OR @ExternalXmlFilename IS NULL)
	AND ([CustomQuestionnaireXML] = @CustomQuestionnaireXml OR @CustomQuestionnaireXml IS NULL)
	AND ([ExternalPDFFilename] = @ExternalPdfFilename OR @ExternalPdfFilename IS NULL)
	AND ([FileDownloaded] = @FileDownloaded OR @FileDownloaded IS NULL)
	AND ([AppliedWith] = @AppliedWith OR @AppliedWith IS NULL)
	AND ([ScreeningQuestionaireXML] = @ScreeningQuestionaireXml OR @ScreeningQuestionaireXml IS NULL)
	AND ([ScreeningQuestionsGuid] = @ScreeningQuestionsGuid OR @ScreeningQuestionsGuid IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobApplicationID]
	, [ApplicationDate]
	, [JobID]
	, [MemberID]
	, [MemberResumeFile]
	, [MemberCoverLetterFile]
	, [ApplicationStatus]
	, [JobAppValidateID]
	, [SiteID_Referral]
	, [URL_Referral]
	, [ApplicantGrade]
	, [LastViewedDate]
	, [FirstName]
	, [Surname]
	, [EmailAddress]
	, [MobilePhone]
	, [MemberNote]
	, [AdvertiserNote]
	, [JobArchiveID]
	, [Draft]
	, [JobApplicationTypeID]
	, [ExternalXMLFilename]
	, [CustomQuestionnaireXML]
	, [ExternalPDFFilename]
	, [FileDownloaded]
	, [AppliedWith]
	, [ScreeningQuestionaireXML]
	, [ScreeningQuestionsGuid]
    FROM
	[dbo].[JobApplication]
    WHERE 
	 ([JobApplicationID] = @JobApplicationId AND @JobApplicationId is not null)
	OR ([ApplicationDate] = @ApplicationDate AND @ApplicationDate is not null)
	OR ([JobID] = @JobId AND @JobId is not null)
	OR ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([MemberResumeFile] = @MemberResumeFile AND @MemberResumeFile is not null)
	OR ([MemberCoverLetterFile] = @MemberCoverLetterFile AND @MemberCoverLetterFile is not null)
	OR ([ApplicationStatus] = @ApplicationStatus AND @ApplicationStatus is not null)
	OR ([JobAppValidateID] = @JobAppValidateId AND @JobAppValidateId is not null)
	OR ([SiteID_Referral] = @SiteIdReferral AND @SiteIdReferral is not null)
	OR ([URL_Referral] = @UrlReferral AND @UrlReferral is not null)
	OR ([ApplicantGrade] = @ApplicantGrade AND @ApplicantGrade is not null)
	OR ([LastViewedDate] = @LastViewedDate AND @LastViewedDate is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Surname] = @Surname AND @Surname is not null)
	OR ([EmailAddress] = @EmailAddress AND @EmailAddress is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([MemberNote] = @MemberNote AND @MemberNote is not null)
	OR ([AdvertiserNote] = @AdvertiserNote AND @AdvertiserNote is not null)
	OR ([JobArchiveID] = @JobArchiveId AND @JobArchiveId is not null)
	OR ([Draft] = @Draft AND @Draft is not null)
	OR ([JobApplicationTypeID] = @JobApplicationTypeId AND @JobApplicationTypeId is not null)
	OR ([ExternalXMLFilename] = @ExternalXmlFilename AND @ExternalXmlFilename is not null)
	OR ([CustomQuestionnaireXML] = @CustomQuestionnaireXml AND @CustomQuestionnaireXml is not null)
	OR ([ExternalPDFFilename] = @ExternalPdfFilename AND @ExternalPdfFilename is not null)
	OR ([FileDownloaded] = @FileDownloaded AND @FileDownloaded is not null)
	OR ([AppliedWith] = @AppliedWith AND @AppliedWith is not null)
	OR ([ScreeningQuestionaireXML] = @ScreeningQuestionaireXml AND @ScreeningQuestionaireXml is not null)
	OR ([ScreeningQuestionsGuid] = @ScreeningQuestionsGuid AND @ScreeningQuestionsGuid is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_Delete]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the JobApplication table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_Delete]
(

	@JobApplicationId int   
)
AS


				DELETE FROM [dbo].[JobApplication] WITH (ROWLOCK) 
				WHERE
					[JobApplicationID] = @JobApplicationId
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_CustomUpdateDownloadedFileStatus]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_CustomUpdateDownloadedFileStatus]
(
	@jobappids NTEXT
)
AS
BEGIN
	UPDATE JobApplication SET FileDownloaded = 1 WHERE JobApplicationID IN (SELECT id FROM [dbo].[ParseIntCSV](@jobappids))	
END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_CustomGetByJobIdMemberId]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_CustomGetByJobIdMemberId]          
(          
 @JobID INT,          
 @MemberID INT          
)          
AS          
BEGIN          
          
SELECT      
[JobApplicationID],      
[ApplicationDate],      
[JobID],      
[MemberID],      
[MemberResumeFile],      
[MemberCoverLetterFile],      
[ApplicationStatus],      
[JobAppValidateID],      
[SiteID_Referral],      
[URL_Referral],      
[ApplicantGrade],      
[LastViewedDate],      
[FirstName],      
[Surname],      
[EmailAddress],      
[MobilePhone],      
[MemberNote],      
[AdvertiserNote],      
[JobArchiveID],      
[Draft],      
[JobApplicationTypeID],      
[ExternalXMLFilename],      
[ExternalPDFFilename],      
[CustomQuestionnaireXML],    
[FileDownloaded],
AppliedWith,
ScreeningQuestionaireXML,
ScreeningQuestionsGuid
FROM JobApplication WITH (NOLOCK)          
WHERE JobID = @JobID AND MemberID = @MemberID          
END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_Update]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the JobApplication table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_Update]
(

	@JobApplicationId int   ,

	@ApplicationDate smalldatetime   ,

	@JobId int   ,

	@MemberId int   ,

	@MemberResumeFile varchar (255)  ,

	@MemberCoverLetterFile varchar (255)  ,

	@ApplicationStatus int   ,

	@JobAppValidateId uniqueidentifier   ,

	@SiteIdReferral int   ,

	@UrlReferral varchar (255)  ,

	@ApplicantGrade int   ,

	@LastViewedDate datetime   ,

	@FirstName nvarchar (255)  ,

	@Surname nvarchar (255)  ,

	@EmailAddress varchar (255)  ,

	@MobilePhone char (40)  ,

	@MemberNote nvarchar (MAX)  ,

	@AdvertiserNote nvarchar (MAX)  ,

	@JobArchiveId int   ,

	@Draft bit   ,

	@JobApplicationTypeId int   ,

	@ExternalXmlFilename varchar (255)  ,

	@CustomQuestionnaireXml nvarchar (MAX)  ,

	@ExternalPdfFilename varchar (255)  ,

	@FileDownloaded bit   ,

	@AppliedWith varchar (255)  ,

	@ScreeningQuestionaireXml nvarchar (MAX)  ,

	@ScreeningQuestionsGuid uniqueidentifier   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[JobApplication]
				SET
					[ApplicationDate] = @ApplicationDate
					,[JobID] = @JobId
					,[MemberID] = @MemberId
					,[MemberResumeFile] = @MemberResumeFile
					,[MemberCoverLetterFile] = @MemberCoverLetterFile
					,[ApplicationStatus] = @ApplicationStatus
					,[JobAppValidateID] = @JobAppValidateId
					,[SiteID_Referral] = @SiteIdReferral
					,[URL_Referral] = @UrlReferral
					,[ApplicantGrade] = @ApplicantGrade
					,[LastViewedDate] = @LastViewedDate
					,[FirstName] = @FirstName
					,[Surname] = @Surname
					,[EmailAddress] = @EmailAddress
					,[MobilePhone] = @MobilePhone
					,[MemberNote] = @MemberNote
					,[AdvertiserNote] = @AdvertiserNote
					,[JobArchiveID] = @JobArchiveId
					,[Draft] = @Draft
					,[JobApplicationTypeID] = @JobApplicationTypeId
					,[ExternalXMLFilename] = @ExternalXmlFilename
					,[CustomQuestionnaireXML] = @CustomQuestionnaireXml
					,[ExternalPDFFilename] = @ExternalPdfFilename
					,[FileDownloaded] = @FileDownloaded
					,[AppliedWith] = @AppliedWith
					,[ScreeningQuestionaireXML] = @ScreeningQuestionaireXml
					,[ScreeningQuestionsGuid] = @ScreeningQuestionsGuid
				WHERE
[JobApplicationID] = @JobApplicationId
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_Insert]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the JobApplication table
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_Insert]
(

	@JobApplicationId int    OUTPUT,

	@ApplicationDate smalldatetime   ,

	@JobId int   ,

	@MemberId int   ,

	@MemberResumeFile varchar (255)  ,

	@MemberCoverLetterFile varchar (255)  ,

	@ApplicationStatus int   ,

	@JobAppValidateId uniqueidentifier    OUTPUT,

	@SiteIdReferral int   ,

	@UrlReferral varchar (255)  ,

	@ApplicantGrade int   ,

	@LastViewedDate datetime   ,

	@FirstName nvarchar (255)  ,

	@Surname nvarchar (255)  ,

	@EmailAddress varchar (255)  ,

	@MobilePhone char (40)  ,

	@MemberNote nvarchar (MAX)  ,

	@AdvertiserNote nvarchar (MAX)  ,

	@JobArchiveId int   ,

	@Draft bit   ,

	@JobApplicationTypeId int   ,

	@ExternalXmlFilename varchar (255)  ,

	@CustomQuestionnaireXml nvarchar (MAX)  ,

	@ExternalPdfFilename varchar (255)  ,

	@FileDownloaded bit   ,

	@AppliedWith varchar (255)  ,

	@ScreeningQuestionaireXml nvarchar (MAX)  ,

	@ScreeningQuestionsGuid uniqueidentifier   
)
AS


				
				INSERT INTO [dbo].[JobApplication]
					(
					[ApplicationDate]
					,[JobID]
					,[MemberID]
					,[MemberResumeFile]
					,[MemberCoverLetterFile]
					,[ApplicationStatus]
					,[JobAppValidateID]
					,[SiteID_Referral]
					,[URL_Referral]
					,[ApplicantGrade]
					,[LastViewedDate]
					,[FirstName]
					,[Surname]
					,[EmailAddress]
					,[MobilePhone]
					,[MemberNote]
					,[AdvertiserNote]
					,[JobArchiveID]
					,[Draft]
					,[JobApplicationTypeID]
					,[ExternalXMLFilename]
					,[CustomQuestionnaireXML]
					,[ExternalPDFFilename]
					,[FileDownloaded]
					,[AppliedWith]
					,[ScreeningQuestionaireXML]
					,[ScreeningQuestionsGuid]
					)
				VALUES
					(
					@ApplicationDate
					,@JobId
					,@MemberId
					,@MemberResumeFile
					,@MemberCoverLetterFile
					,@ApplicationStatus
					,@JobAppValidateId
					,@SiteIdReferral
					,@UrlReferral
					,@ApplicantGrade
					,@LastViewedDate
					,@FirstName
					,@Surname
					,@EmailAddress
					,@MobilePhone
					,@MemberNote
					,@AdvertiserNote
					,@JobArchiveId
					,@Draft
					,@JobApplicationTypeId
					,@ExternalXmlFilename
					,@CustomQuestionnaireXml
					,@ExternalPdfFilename
					,@FileDownloaded
					,@AppliedWith
					,@ScreeningQuestionaireXml
					,@ScreeningQuestionsGuid
					)
				
				-- Get the identity value
				SET @JobApplicationId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_GetPaged]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the JobApplication table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


ALTER PROCEDURE [dbo].[JobApplication_GetPaged]
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
				    [JobApplicationID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobApplicationID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobApplicationID]'
				SET @SQL = @SQL + ' FROM [dbo].[JobApplication]'
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
				SELECT O.[JobApplicationID], O.[ApplicationDate], O.[JobID], O.[MemberID], O.[MemberResumeFile], O.[MemberCoverLetterFile], O.[ApplicationStatus], O.[JobAppValidateID], O.[SiteID_Referral], O.[URL_Referral], O.[ApplicantGrade], O.[LastViewedDate], O.[FirstName], O.[Surname], O.[EmailAddress], O.[MobilePhone], O.[MemberNote], O.[AdvertiserNote], O.[JobArchiveID], O.[Draft], O.[JobApplicationTypeID], O.[ExternalXMLFilename], O.[CustomQuestionnaireXML], O.[ExternalPDFFilename], O.[FileDownloaded], O.[AppliedWith], O.[ScreeningQuestionaireXML], O.[ScreeningQuestionsGuid]
				FROM
				    [dbo].[JobApplication] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobApplicationID] = PageIndex.[JobApplicationID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[JobApplication]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Jobs_CustomPostXML]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Jobs_CustomPostXML]              
(              
    @AdvertiserId INT,              
    @AdvertiserUserName VARCHAR(255),              
    @XMLFeed XML,              
    @ErrorList XML,                
    @ClientIPAddress VARCHAR(255),              
    @ArchiveMissingJobs BIT,                  
 @WebServiceLogId INT OUTPUT              
)              
AS              
BEGIN              
               
-- Changes - 17th March            
  -- [JobItemTypeID] - is hardcoded to 1 as its not implemented yet.            
-- Changes - 19th Feb               
  -- JobArea bug on update.              
-- Changes - 26th March          
  -- On Update - ContactDetails was not able to save NULL values          
-- Changes - Jan 2015          
  -- Insert Job types which are available on the site to the Advertiser User           
  -- Throw ERROR when Job types which are not available in the site are posted.          
  -- Add Premium and Stand out jobs.          
  -- Premium expiry days          
  -- Invoice for Advertiser Account type.          
  -- Invoice Items for New Jobs           
  -- Job Ad Type cannot be updated          
  -- Get Currency from Global settings and update in the Invoice Item table for each job            
  -- Update the Invoice and InvoiceOrder Amount and GST for the new jobs.          
-- Changes - 22nd July 2015    
 -- BUG fix - Was not setting the right @AdvertiserUserId - added advertiserid in where clause            
-- Changes - Sept 2015        
 -- Multiple Custom classification sites - validation removed RefferedSiteId
-- Changes - JAN 2016
 -- Added ApplicationEmailAddress to SearchField for each field so that its searchable
-- Changes - 2016-11-04
 -- Added exec [Jobs_CustomUpdateSiteJobCount] to the very end of this SP 
  -- TODO - JobBoard advertiser can't update jobs.          
  -- Todo - Need to remove Valid =1 and test not to archieve failed jobs.           
            
                    
SET XACT_ABORT ON;              
               
DECLARE @SiteID INT              
DECLARE @AdvertiserUserId INT              
DECLARE @CompanyName nvarchar(510)              
DECLARE @DateCreated DATETIME = GETDATE()              
DECLARE @FinishedDate DATETIME              
DECLARE @TotalSent INT = 0              
          
DECLARE @PaymentTypeID_Account INT = 1 -- The Advertiser Account Payment Type id Enum value is 1          
          
DECLARE @JobTypeID_Normal INT = 1 -- The Normal job Type id Enum value is 1          
DECLARE @JobTypeID_Standout INT = 2 -- The Standout job Type id Enum value is 2          
DECLARE @JobTypeID_Premium INT = 3 -- The Premium job Type id Enum value is 3          
          
DECLARE @PremiumExpiryDays INT = 0          
               
SELECT @AdvertiserUserId = AdvertiserUserID FROM AdvertiserUsers (NOLOCK) WHERE UserName = @AdvertiserUserName AND AdvertiserID = @AdvertiserId            
               
 -- Get the SiteID              
SELECT @SiteID = SiteID, @CompanyName = CompanyName FROM Advertisers (NOLOCK) WHERE AdvertiserID = @AdvertiserId              
          
-- Get the Premium Days to be active               
SELECT @PremiumExpiryDays = DaysActive FROM [JobItemsType] (NOLOCK)           
 WHERE SiteID = @SiteID AND Valid = 1 AND TotalNumberOfJobs = 1 AND JobItemTypeParentID = @JobTypeID_Premium          
                 
 -- Insert the xml to the WebserviceLog              
 INSERT INTO WebServiceLog              
           ([ClientIPAddress]              
           ,[AdvertiserId]              
           ,[AdvertiserUserID]              
           ,[CreatedDate]              
           ,[MethodInvoked]              
           ,[InputXML]              
           ,[OutputResponse]              
           ,[InvalidXML]              
           ,[TotalSent]              
           ,[TotalUpdated]              
           ,[TotalArchived]              
           ,[TotalFailed]              
           ,[SiteId]              
           ,[FinishedDate])              
     VALUES              
           (@ClientIPAddress              
          ,@AdvertiserId              
           ,@AdvertiserUserId              
           ,@DateCreated              
           ,'POST'              
           ,@XMLFeed              
           ,NULL              
           ,NULL              
           ,0       
           ,0              
           ,0              
           ,0                 
           ,@SiteID              
           ,NULL)              
              
 SET @WebServiceLogId = SCOPE_IDENTITY();              
              
 CREATE TABLE #ErrorJobXML (              
   Id INT PRIMARY KEY IDENTITY(1,1),               
   ReferenceNo VARCHAR(255),               
   ErrorDetails NVARCHAR(MAX),              
   WarningDetails NVARCHAR(MAX),              
   Error BIT,              
   Warning BIT)              
               
BEGIN TRY                
 BEGIN TRANSACTION PostJobsTransaction              
          
            
            
 -- Set if the site is Custom Classification / Subclassification and get Currency from Global settings and update in the Invoice Item table for each job            
 DECLARE @IsCustomClassification BIT               
 DECLARE @SiteURL varchar(500)           
 DECLARE @CurrencyID INT          
 DECLARE @SiteType INT          
 DECLARE @GST Decimal(5,2)          
               
 SELECT @IsCustomClassification = ISNULL(UseCustomProfessionRole, 0), @CurrencyID = CurrencyID, @GST = GST, @SiteType = SiteType FROM Globalsettings (NOLOCK) WHERE SiteID = @SiteID              
 SELECT @SiteURL = 'http://' + ISNULL(SiteURL, '') + '/'  FROM Sites (NOLOCK) WHERE SiteID = @SiteID           
            
            
    -- ****** Set all the ERROR jobs from the XML to an error table ******              
               
 IF (@ErrorList IS NOT NULL)              
 BEGIN              
  INSERT INTO #ErrorJobXML(ReferenceNo, ErrorDetails, WarningDetails, Error, Warning)                
   SELECT               
      Element.value('ReferenceNo[1]', 'VARCHAR(255)') AS ReferenceNo,              
      Element.value('ErrorDetails[1]', 'NVARCHAR(MAX)') AS ErrorDetails,              
      Element.value('WarningDetails[1]', 'NVARCHAR(MAX)') AS WarningDetails,              
      Element.value('Error[1]', 'BIT') AS Error,              
      Element.value('Warning[1]', 'BIT') AS Warning              
                    
   FROM   @ErrorList.nodes('/ArrayOfJobErrorList/JobErrorList') Datalist(Element)              
   OPTION ( OPTIMIZE FOR ( @ErrorList = NULL ) )              
    END              
                  
                  
 DECLARE @XMLFeed_New xml (MiniJobXMLSchema)              
 SET @XMLFeed_New = @XMLFeed              
 SET @XMLFeed = NULL              
               
    -- ****** Set all the jobs from the XML to a table ******              
 CREATE TABLE #FlatXML (              
    Id INT PRIMARY KEY IDENTITY(1,1),               
    ReferenceNo VARCHAR(255),               
    JobAdType INT,               
    Title NVARCHAR(510),               
    ShortDescription NVARCHAR(2000),               
    Bulletpoint1 NVARCHAR(160), Bulletpoint2 NVARCHAR(160), Bulletpoint3 NVARCHAR(160),              
    FullDescription NVARCHAR(MAX),              
    ApplicationEmailAddress VARCHAR(255),              
    ContactDetails NVARCHAR(510),              
    CompanyName VARCHAR(255),              
    ConsultantID INT NULL,              
    ConsultantName VARCHAR(255),              
    PublicTransport NVARCHAR(500),              
    ResidentsOnly BIT,              
    IsQualificationsRecognised BIT,              
    ShowLocationDetails BIT,              
    JobTemplateID INT,              
    AdvertiserJobTemplateLogoID INT,              
    Classification1 INT,              
    SubClassification1 INT,              
    Classification2 INT,              
    SubClassification2 INT,              
    Classification3 INT,     
    SubClassification3 INT,              
    WorkType INT,              
    Sector INT,              
    StreetAddress VARCHAR(255),              
  Tags NVARCHAR(MAX),              
    Country INT,              
    Location INT,              
    Area INT,              
    SalaryTypeID INT,              
    SalaryLowerBand NUMERIC(15,2),              
    SalaryUpperBand NUMERIC(15,2),              
    AdditionalText VARCHAR(500),              
    ShowSalaryDetails BIT,              
    ApplicationMethod INT,              
    ApplicationUrl VARCHAR(8000) NULL,              
    HasReferralFee BIT,              
    ReferralAmount NUMERIC(15,2),              
    ReferralUrl VARCHAR(510),              
    JobFriendlyName VARCHAR(512),              
    Valid BIT,              
    SearchField NVARCHAR(MAX),              
    ErrorMessage NVARCHAR(MAX),              
    Warning BIT,              
    WarningMessage NVARCHAR(MAX),              
    JobID INT NULL,              
    UpdateJob BIT,  
    AddressStatus INT              
     )              
               
 INSERT INTO #FlatXML(ReferenceNo,               
    JobAdType,               
    Title,              
    ShortDescription,              
    Bulletpoint1, Bulletpoint2, Bulletpoint3,              
    FullDescription,              
    ApplicationEmailAddress,              
    ContactDetails,              
    CompanyName,              
ConsultantID,              
    ConsultantName,              
    PublicTransport,              
    ResidentsOnly,              
    IsQualificationsRecognised,              
    ShowLocationDetails,              
    JobTemplateID,              
    AdvertiserJobTemplateLogoID,              
    Classification1,              
    SubClassification1,              
    Classification2,              
    SubClassification2,              
    Classification3,              
    SubClassification3,              
    WorkType,              
    Sector,              
    StreetAddress,              
    Tags,              
    Country,              
    Location,              
    Area,              
    SalaryTypeID,              
    SalaryLowerBand,              
    SalaryUpperBand,              
    AdditionalText,              
    ShowSalaryDetails,              
    ApplicationMethod,              
    ApplicationUrl,              
    HasReferralFee,              
    ReferralAmount,              
    ReferralUrl,              
    JobFriendlyName,              
    Valid,            
    SearchField,              
    ErrorMessage,              
    Warning,                  
    WarningMessage,              
    JobID,              
    UpdateJob)              
 SELECT               
     LTRIM(RTRIM(Element.value('ReferenceNo[1]', 'VARCHAR(255)'))) AS RefNo,              
     Element.value('JobAdType[1]', 'INT') AS JobAdType,              
     LTRIM(RTRIM(Element.value('JobTitle[1]', 'NVARCHAR(510)'))) AS Title,              
     Element.value('ShortDescription[1]', 'NVARCHAR(2000)') AS ShortDescription,              
     Element.value('Bulletpoints[1]/BulletPoint1[1]', 'NVARCHAR(160)') AS Bulletpoint1,              
     Element.value('Bulletpoints[1]/BulletPoint2[1]', 'NVARCHAR(160)') AS Bulletpoint2,              
     Element.value('Bulletpoints[1]/BulletPoint3[1]', 'NVARCHAR(160)') AS Bulletpoint3,              
     Element.value('JobFullDescription[1]', 'NVARCHAR(max)') AS FullDescription,              
     Element.value('ApplicationMethod[1]/ApplicationEmail[1]', 'VARCHAR(255)') AS ApplicationEmailAddress,              
     Element.value('ContactDetails[1]', 'NVARCHAR(510)') AS ContactDetails,              
     Element.value('CompanyName[1]', 'VARCHAR(255)') AS CompanyName,              
     Element.value('ConsultantID[1]', 'INT') AS ConsultantID,              
     '' AS JobContactName, --Element.value('ConsultantName[1]', 'VARCHAR(255)')              
     Element.value('PublicTransport[1]', 'NVARCHAR(500)') AS PublicTransport,              
     Element.value('ResidentsOnly[1]', 'BIT') AS ResidentsOnly,              
     Element.value('IsQualificationsRecognised[1]', 'BIT') AS IsQualificationsRecognised,              
     Element.value('ShowLocationDetails[1]', 'BIT') AS ShowLocationDetails,              
     Element.value('JobTemplateID[1]', 'INT') AS JobTemplateID,              
     Element.value('AdvertiserJobTemplateLogoID[1]', 'INT') AS AdvertiserJobTemplateLogoID,              
     Element.value('Categories[1]/Category[1]/Classification[1]', 'INT') AS Classification1,              
     Element.value('Categories[1]/Category[1]/SubClassification[1]', 'INT') AS SubClassification1,              
     Element.value('Categories[1]/Category[2]/Classification[1]', 'INT') AS Classification2,              
     Element.value('Categories[1]/Category[2]/SubClassification[1]', 'INT') AS SubClassification2,              
     Element.value('Categories[1]/Category[3]/Classification[1]', 'INT') AS Classification3,              
     Element.value('Categories[1]/Category[3]/SubClassification[1]', 'INT') AS SubClassification3,              
     Element.value('ListingClassification[1]/WorkType[1]', 'INT') AS WorkType,              
     Element.value('ListingClassification[1]/Sector[1]', 'INT') AS Sector,              
     Element.value('ListingClassification[1]/StreetAddress[1]', 'VARCHAR(255)') AS StreetAddress,              
     Element.value('ListingClassification[1]/Tags[1]', 'NVARCHAR(MAX)') AS Tags,              
     Element.value('ListingClassification[1]/Country[1]', 'INT') AS Country,              
     Element.value('ListingClassification[1]/Location[1]', 'INT') AS Location,              
     Element.value('ListingClassification[1]/Area[1]', 'INT') AS Area,              
     Element.value('Salary[1]/SalaryType[1]', 'INT') AS SalaryTypeID,              
     Element.value('Salary[1]/Min[1]', 'NUMERIC(15,2)') AS SalaryLowerBand,              
     Element.value('Salary[1]/Max[1]', 'NUMERIC(15,2)') AS SalaryUpperBand,              
     Element.value('Salary[1]/AdditionalText[1]', 'VARCHAR(500)') AS AdditionalText,              
     Element.value('Salary[1]/ShowSalaryDetails[1]', 'BIT') AS ShowSalaryDetails,              
     Element.value('ApplicationMethod[1]/JobApplicationType[1]', 'INT') AS ApplicationMethod,           
     Element.value('ApplicationMethod[1]/ApplicationUrl[1]', 'VARCHAR(8000)') AS ApplicationUrl,              
     Element.value('Referral[1]/HasReferralFee[1]', 'BIT') AS HasReferralFee,              
     Element.value('Referral[1]/Amount[1]', 'NUMERIC(15,2)') AS ReferralAmount,              
     Element.value('Referral[1]/ReferralUrl[1]', 'VARCHAR(510)') AS ReferralUrl,              
     Element.value('JobUrl[1]', 'NVARCHAR(510)') AS JobFriendlyName,              
     1,  -- By default its valid              
     '',  -- SearchField              
     '',  -- By default No Errors              
     0,  -- By default no warnings              
     '',  -- By default No Warnings              
     NULL, -- By default Job ID is NULL              
     0  -- By default the Job is Inserted              
    FROM   @XMLFeed_New.nodes('/JobPostRequest/Listings/JobListing') Datalist(Element)              
    --OPTION ( OPTIMIZE FOR ( @XMLFeed_New = NULL ) )              
                  
    -- Get the Count               
    SELECT @TotalSent = COUNT(*) FROM #FlatXML              
                  
    -- *************** Update the FlatXML which are not valid from the backend ***************              
    UPDATE #FlatXML SET Valid = 0, ErrorMessage = ' -> Reference no. is required.' WHERE ReferenceNo IS NULL OR ReferenceNo = ''              
                  
    UPDATE #FlatXML SET Valid = 0, ErrorMessage = ISNULL(#ErrorJobXML.ErrorDetails, '')              
  FROM               
   #ErrorJobXML INNER JOIN #FlatXML ON #ErrorJobXML.ReferenceNo = #FlatXML.ReferenceNo              
  WHERE               
   #ErrorJobXML.Error = 1              
                 
    UPDATE #FlatXML SET Warning = 1, WarningMessage = #ErrorJobXML.WarningDetails               
  FROM               
   #ErrorJobXML INNER JOIN #FlatXML ON #ErrorJobXML.ReferenceNo = #FlatXML.ReferenceNo               
  WHERE               
   #ErrorJobXML.Warning = 1              
                     
                  
 -- *************** SET DEFAULT VALUES from here *********************              
    -- Get the default job template ID              
    DECLARE @DefaultTemplateID INT              
    -- Check if the advertiser has a job template else get the default globaltemplate of the site.              
  IF EXISTS(SELECT 1 FROM [JobTemplates] (NOLOCK) WHERE AdvertiserID = @AdvertiserId)                      
  BEGIN                       
   SELECT TOP 1 @DefaultTemplateID = JobTemplateID FROM [JobTemplates] (NOLOCK) WHERE AdvertiserID = @AdvertiserId --AND GlobalTemplate = 1              
  END                    
  ELSE                    
  BEGIN                     
   SELECT @DefaultTemplateID = JobTemplateID FROM [JobTemplates] (NOLOCK) WHERE SiteID = @SiteID AND GlobalTemplate = 1                   
  END               
       
                   
 -- *************** WARNING checks from here *********************              
    -- WARNING - for invalid Job template for the site, set the default job template id of the site              
    UPDATE #FlatXML SET JobTemplateID = @DefaultTemplateID WHERE JobTemplateID IS NULL OR JobTemplateID = 0   --               
                  
    UPDATE #FlatXML              
  SET                 
   #FlatXML.Warning = 1,              
   #FlatXML.JobTemplateID = @DefaultTemplateID,              
   #FlatXML.WarningMessage = #FlatXML.WarningMessage + ' -> Job Template doesn''t exists - ' + Cast(#FlatXML.JobTemplateID as varchar(10))               
  FROM               
   #FlatXML              
  WHERE               
   #FlatXML.JobTemplateID NOT IN (SELECT JobTemplateID FROM JobTemplates (NOLOCK) WHERE JobTemplates.SiteID = @SiteID)              
                  
    -- WARNING - for invalid Job template logo id for the site              
                  
    UPDATE #FlatXML              
  SET                 
   #FlatXML.Warning = 1,              
   #FlatXML.AdvertiserJobTemplateLogoID = null,              
   #FlatXML.WarningMessage = #FlatXML.WarningMessage + ' -> Advertiser Job Template Logo ID was not valid - ' + Cast(#FlatXML.AdvertiserJobTemplateLogoID as varchar(10))              
  FROM               
   #FlatXML              
  WHERE               
   #FlatXML.AdvertiserJobTemplateLogoID NOT IN               
    (SELECT AdvertiserJobTemplateLogoID FROM AdvertiserJobTemplateLogo (NOLOCK) WHERE AdvertiserJobTemplateLogo.AdvertiserID = @AdvertiserId)              
   OR #FlatXML.AdvertiserJobTemplateLogoID = 0              
                   
               
 -- *************** ERROR checks from here *********************              
 -- ERROR - Check if Classification and Sub are valid              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') + ' -> ClassificationID1 doesn''t exists - ' + Cast(#FlatXML.Classification1 as varchar(10))               
  FROM               
   #FlatXML               
  WHERE               
   #FlatXML.Classification1 NOT IN               
    (SELECT ProfessionID FROM SiteProfession (NOLOCK) WHERE SiteID = @SiteID)              
   --AND #FlatXML.Valid = 1              
                
                   
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> ClassificationID2 doesn''t exists - ' + Cast(#FlatXML.Classification2 as varchar(10))               
  FROM               
   #FlatXML               
  WHERE               
   #FlatXML.Classification2 NOT IN               
    (SELECT ProfessionID FROM SiteProfession (NOLOCK) WHERE SiteID = @SiteID)              
   --AND #FlatXML.Valid = 1              
                 
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> ClassificationID3 doesn''t exists - ' + Cast(#FlatXML.Classification3 as varchar(10))               
  FROM               
   #FlatXML              
  WHERE               
   #FlatXML.Classification3 NOT IN               
    (SELECT ProfessionID FROM SiteProfession (NOLOCK) WHERE SiteID = @SiteID)                 
   --AND #FlatXML.Valid = 1              
               
 -- ERROR - Checks if the roles are under the profession and if part of the site              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(FlatXML.ErrorMessage,'') +  ' -> SubClassificationID1 doesn''t exists - ' + Cast(FlatXML.SubClassification1 as varchar(10))        
  FROM               
    #FlatXML as FlatXML              
  WHERE               
   ISNULL(FlatXML.SubClassification1, '') != ''  AND              
   NOT EXISTS              
    (SELECT 1 FROM SiteProfession (NOLOCK) INNER JOIN Roles (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID               
     AND FlatXML.Classification1 = SiteProfession.ProfessionID AND FlatXML.SubClassification1 = Roles.RoleID              
     AND SiteProfession.SiteID = @SiteID)              
               
               
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(FlatXML.ErrorMessage,'') +  ' -> SubClassificationID2 doesn''t exists - ' + Cast(FlatXML.SubClassification2 as varchar(10))               
  FROM               
   #FlatXML as FlatXML              
  WHERE               
   ISNULL(FlatXML.SubClassification2, '') != ''  AND              
   NOT EXISTS              
    (SELECT 1 FROM SiteProfession (NOLOCK) INNER JOIN Roles (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID               
     AND FlatXML.Classification2 = SiteProfession.ProfessionID AND FlatXML.SubClassification2 = Roles.RoleID              
     AND SiteProfession.SiteID = @SiteID)                 
                
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(FlatXML.ErrorMessage,'') +  ' -> SubClassificationID3 doesn''t exists - ' + Cast(FlatXML.SubClassification3 as varchar(10))               
  FROM               
   #FlatXML as FlatXML              
  WHERE               
   ISNULL(FlatXML.SubClassification3, '') != ''  AND              
   NOT EXISTS              
    (SELECT 1 FROM SiteProfession (NOLOCK) INNER JOIN Roles (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID               
     AND FlatXML.Classification3 = SiteProfession.ProfessionID AND FlatXML.SubClassification3 = Roles.RoleID              
     AND SiteProfession.SiteID = @SiteID)                
                 
 -- ERROR - Checks if the Worktypes are part of the site                
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> WorkTypeID doesn''t exists - ' + Cast(#FlatXML.WorkType as varchar(10))               
  FROM               
   #FlatXML WHERE WorkType NOT IN (SELECT WorkTypeID FROM SiteWorkType (NOLOCK) WHERE SiteWorkType.SiteID = @SiteID)              
                
 -- ERROR - Checks if the SalaryType are part of the site                
 UPDATE #FlatXML           
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> SalaryType doesn''t exists - ' + Cast(#FlatXML.SalaryTypeID as varchar(10))               
  FROM               
   #FlatXML WHERE SalaryTypeID NOT IN (SELECT SalaryTypeID FROM SiteSalaryType (NOLOCK) WHERE SiteSalaryType.SiteID = @SiteID)                  
                
 -- ERROR TODO - For Sector - Structure doesn't exists yet. Don't worry about it for now.              
                 
              
 -- ERROR - Check if Countrys are valid              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> CountryID doesn''t exists - ' + Cast(#FlatXML.Country as varchar(10))               
  FROM               
   #FlatXML WHERE #FlatXML.Country NOT IN (SELECT CountryID FROM SiteCountries (NOLOCK) WHERE SiteID = @SiteID)              
              
              
 -- ERROR - Check if Locations are valid              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> LocationID doesn''t exists - ' + Cast(#FlatXML.Location as varchar(10))               
  FROM               
   #FlatXML WHERE #FlatXML.Location NOT IN (SELECT LocationID FROM SiteLocation (NOLOCK) WHERE SiteID = @SiteID)              
              
              
 -- ERROR - Check if Areas are valid              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> AreaID doesn''t exists - ' + Cast(#FlatXML.Area as varchar(10))               
  FROM               
   #FlatXML WHERE Area NOT IN (SELECT AreaID FROM SiteArea (NOLOCK) WHERE SiteArea.SiteID = @SiteID)              
                 
                 
 -- ERROR - Check if the combination Country/Location/Area are valid                
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> The combination for country/location/area doesn''t exists - ' +               
      Cast(ISNULL(#FlatXML.Country,'') as varchar(10)) + ' / ' + Cast(ISNULL(#FlatXML.Location,'') as varchar(10)) +               
    ' / ' + Cast(ISNULL(#FlatXML.Area,'') as varchar(10))                
  FROM #FlatXML              
  WHERE NOT EXISTS (              
  Select 1 FROM               
   Countries (NOLOCK) INNER JOIN              
   Location (NOLOCK) ON Countries.CountryID = Location.CountryID INNER JOIN              
   Area (NOLOCK) ON Location.LocationID = Area.LocationID INNER JOIN              
   SiteArea (NOLOCK) ON Area.AreaID = SiteArea.AreaID INNER JOIN              
   SiteCountries (NOLOCK) ON Countries.CountryID = SiteCountries.CountryID INNER JOIN              
   SiteLocation (NOLOCK) ON Location.LocationID = SiteLocation.LocationID INNER JOIN #FlatXML               
  ON               
   (SiteCountries.SiteID = @SiteID) AND (SiteLocation.SiteID = @SiteID) AND (SiteArea.SiteID = @SiteID) AND              
   #FlatXML.Country = SiteCountries.CountryID AND #FlatXML.Location = SiteLocation.LocationID AND #FlatXML.Area = SiteArea.AreaID                 
  )              
              
                
 -- ERROR - Check if Consultant are part of the Current Advertiser               
 UPDATE #FlatXML SET ConsultantID = @AdvertiserUserId WHERE ConsultantID = 0   --               
                
    UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> ConsultantID doesn''t exists - ' + Cast(ISNULL(#FlatXML.ConsultantID,'') as varchar(10))           
  FROM               
   #FlatXML WHERE ConsultantID NOT IN               
    (SELECT AdvertiserUserID FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserID = @AdvertiserId)              
                  
              
 -- ERROR - Check if Job Types are valid              
 UPDATE #FlatXML              
  SET                 
   #FlatXML.Valid = 0,              
   #FlatXML.ErrorMessage = ISNULL(#FlatXML.ErrorMessage,'') +  ' -> JobAdType not allowed on this site - ' + Cast(#FlatXML.JobAdType as varchar(10))               
  FROM               
   #FlatXML WHERE JobAdType NOT IN (SELECT JobItemTypeParentID FROM JobItemsType (NOLOCK) WHERE JobItemsType.SiteID = @SiteID AND Valid = 1 AND TotalNumberOfJobs = 1)           
                 
                  
 -- *************** INSERT / UPDATE / Archive Jobs *********************              
               
 -- Update temp table with the Consultant names              
 UPDATE #FlatXML SET ConsultantName = ISNULL(AdvertiserUsers.FirstName,'') + ' ' + ISNULL(AdvertiserUsers.Surname,'')              
  FROM               
   #FlatXML INNER JOIN AdvertiserUsers (NOLOCK) ON #FlatXML.ConsultantID = AdvertiserUsers.AdvertiserUserID                  
  WHERE               
   Valid = 1               
                 
                 
 -- Update temp table which ones will be UPDATED.   
  UPDATE #FlatXML SET UpdateJob = 1, #FlatXML.JobID = Jobs.JobID              
  FROM               
   #FlatXML INNER JOIN Jobs (NOLOCK) ON #FlatXML.ReferenceNo = Jobs.RefNo AND           
   Jobs.SiteID = @SiteID AND Jobs.Expired = 0 AND Jobs.ExpiryDate >= GETDATE()              
  WHERE               
   Valid = 1               
                      
     
 -- Google Map - Check if integration is enabled  
 DECLARE @GoogleMapIntegration INT = ISNULL((SELECT 1 FROM Integrations (NOLOCK) WHERE SiteID = @SiteID AND Integrations.Valid = 1 AND IntegrationType = 10),0)  
              
 INSERT INTO Jobs              
   (JobItemTypeID,SiteID, WorkTypeID, JobName, [Description], FullDescription, WebServiceProcessed, ApplicationEmailAddress, Visible,                       
      DatePosted, ExpiryDate, Billed, LastModified, ShowSalaryDetails, SearchFieldExtension, RequireLogonForExternalApplications,                       
      ContactDetails, QualificationsRecognised, ResidentOnly, HotJob, RefNo, SalaryText, AdvertiserID, ApplicationMethod,                       
      ApplicationURL, UploadMethod, JobContactName, ShowLocationDetails, [Address], AdvertiserJobTemplateLogoID, CompanyName,               
      PublicTransport, BulletPoint1, BulletPoint2, BulletPoint3, Tags, JobFriendlyName, JobTemplateID, LastModifiedByAdminUserId,                     
      Expired, ShowSalaryRange, SalaryUpperBand, SalaryLowerBand, SalaryTypeID, CurrencyID, EnteredByAdvertiserUserID, AddressStatus)                  
 Select #FlatXML.JobAdType, -- JobAdType NOT IMPLEMENTED YET              
   @SiteID, WorkType, Title, ShortDescription, FullDescription,               
   1, -- WebServiceProcessed              
   ISNULL(ApplicationEmailAddress,''),               
   1, -- Visible              
   GETDATE(), -- DatePosted              
   CASE WHEN (#FlatXML.JobAdType = @JobTypeID_Premium) THEN DATEADD(DAY,@PremiumExpiryDays,GETDATE()) ELSE DATEADD(DAY,30,GETDATE()) END,           
    -- If Premium set from the JobItemType table else default for Normal/Stand out          
   1, -- Billed              
   GETDATE(), -- LastModified              
   CASE WHEN (#FlatXML.SalaryTypeID = 3) THEN 0 ELSE ISNULL(ShowSalaryDetails,1) END,               
   '',                       
   0, --RequireLogonForExternalApplications              
   ISNULL(ContactDetails,''), IsQualificationsRecognised,                       
   ResidentsOnly,               
   0, -- HotJob              
   ReferenceNo, ISNULL(AdditionalText,''), @AdvertiserId, ApplicationMethod,        
   ISNULL(ApplicationUrl,''),               
   2, -- UploadMethod - Webservice = 2              
   ISNULL(ConsultantName,''), ISNULL(ShowLocationDetails,1), ISNULL(StreetAddress,''), AdvertiserJobTemplateLogoID, @CompanyName, ISNULL(PublicTransport,''),               
   ISNULL(BulletPoint1,''), ISNULL(BulletPoint2,''), ISNULL(BulletPoint3,''), ISNULL(Tags,''),                     
   JobFriendlyName, JobTemplateID,               
   1, --LastModifiedByAdminUserId              
   0, -- Expired              
   CASE WHEN (#FlatXML.SalaryTypeID = 3 OR ISNULL(#FlatXML.ShowSalaryDetails,1) = 0) THEN 0 ELSE 1 END, -- ShowSalaryRange              
   SalaryUpperBand, SalaryLowerBand, SalaryTypeID,               
   1, --CurrencyID              
   @AdvertiserUserId,   
   CASE WHEN   
 (@GoogleMapIntegration > 0 AND ISNULL(StreetAddress,'') <> '') THEN 2 ELSE NULL END -- Add to the Google map queue if site has integration & ADDRESS not empty  
 FROM               
  #FlatXML              
 WHERE              
  UpdateJob = 0 AND Valid = 1              
                
 -- *************** Update the Temp table with "JobId's" which were INSERTED / UPDATED *********************               
 UPDATE #FlatXML SET #FlatXML.JobID = Jobs.JobID               
  FROM #FlatXML INNER JOIN Jobs (NOLOCK) ON #FlatXML.ReferenceNo = Jobs.RefNo AND #FlatXML.Valid = 1 AND               
   Jobs.SiteID = @SiteID AND Jobs.Expired = 0 AND Jobs.ExpiryDate >= GETDATE()              
   
   
   -- Check if Google Map integration is Enabled  
   IF (@GoogleMapIntegration > 0)   
   BEGIN  
     
   -- CHECK if the Address is NOT SAME for the updated else submit to queue  
   UPDATE #FlatXML SET AddressStatus = 2              
   FROM               
  #FlatXML INNER JOIN Jobs (NOLOCK) ON Jobs.SiteID = @SiteID AND Jobs.JobID = #FlatXML.JobID  
   WHERE               
  UpdateJob = 1 AND Valid = 1   
   AND #FlatXML.StreetAddress <> Jobs.[Address]   
       
   END  
               
 UPDATE Jobs SET              
  --JobItemTypeID = 1, -- Job Ad Type cannot be updated          
  SiteID = @SiteID, WorkTypeID = WorkType, JobName = Title, [Description] = ShortDescription, FullDescription = #FlatXML.FullDescription,               
   WebServiceProcessed = 1, ApplicationEmailAddress = ISNULL(#FlatXML.ApplicationEmailAddress,''), Visible = 1,                       
      LastModified = GETDATE(), ShowSalaryDetails = CASE WHEN (#FlatXML.SalaryTypeID = 3) THEN 0 ELSE ISNULL(#FlatXML.ShowSalaryDetails,1) END,                        
      ContactDetails = ISNULL(#FlatXML.ContactDetails,''), QualificationsRecognised = IsQualificationsRecognised, ResidentOnly = #FlatXML.ResidentsOnly,               
      SalaryText = ISNULL(AdditionalText,''), AdvertiserID = @AdvertiserId, ApplicationMethod = #FlatXML.ApplicationMethod,                       
      ApplicationURL = ISNULL(#FlatXML.ApplicationUrl,''), UploadMethod = 2, JobContactName = ISNULL(ConsultantName,''),               
      ShowLocationDetails = #FlatXML.ShowLocationDetails, [Address] = ISNULL(StreetAddress,''), AdvertiserJobTemplateLogoID = #FlatXML.AdvertiserJobTemplateLogoID, CompanyName = @CompanyName,               
      PublicTransport = ISNULL(#FlatXML.PublicTransport,''), BulletPoint1 = ISNULL(#FlatXML.BulletPoint1,''), BulletPoint2 = ISNULL(#FlatXML.BulletPoint2,''), BulletPoint3 = ISNULL(#FlatXML.BulletPoint3,''),               
      Tags = ISNULL(#FlatXML.Tags,''), JobTemplateID = #FlatXML.JobTemplateID, LastModifiedByAdminUserId = 1,                     
      ShowSalaryRange = CASE WHEN (#FlatXML.SalaryTypeID = 3 OR ISNULL(#FlatXML.ShowSalaryDetails,1) = 0) THEN 0 ELSE 1 END,  -- ShowSalaryRange              
      SalaryUpperBand = #FlatXML.SalaryUpperBand, SalaryLowerBand = #FlatXML.SalaryLowerBand, SalaryTypeID = #FlatXML.SalaryTypeID,               
      CurrencyID = 1, EnteredByAdvertiserUserID = @AdvertiserUserId  
 FROM               
  #FlatXML INNER JOIN Jobs (NOLOCK) ON       
   Jobs.JobID = #FlatXML.JobID AND Jobs.Expired = 0 AND Jobs.ExpiryDate >= GETDATE()              
 WHERE               
  UpdateJob = 1 AND Valid = 1              
               
   
   -- Google Map - if integration is enabled -- Add the updated jobs to the Google map address queue.  
   IF (@GoogleMapIntegration > 0)   
   BEGIN  
 UPDATE Jobs SET Jobs.AddressStatus = 2        
 FROM               
   #FlatXML INNER JOIN Jobs (NOLOCK) ON Jobs.JobID = #FlatXML.JobID         
  WHERE               
   UpdateJob = 1 AND Valid = 1 AND #FlatXML.AddressStatus = 2    
     
     
 -- invalid address if they are empty  
 UPDATE Jobs SET Jobs.AddressStatus = 0        
 FROM               
   #FlatXML INNER JOIN Jobs (NOLOCK) ON Jobs.JobID = #FlatXML.JobID         
  WHERE               
   UpdateJob = 1 AND Valid = 1 AND ISNULL(#FlatXML.StreetAddress, '') = ''   
     
   END  
                 
                     
 -- *************** INSERT the Job Roles and Area of the Jobs which are Valid and which needs to be INSERTED *********************               
 INSERT INTO JobRoles(JobID, RoleID)               
 (              
  SELECT JobID, SubClassification1 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 0              
  UNION              
  SELECT JobID, SubClassification2 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 0 AND SubClassification2 IS NOT NULL              
  UNION              
  SELECT JobID, SubClassification3 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 0 AND SubClassification3 IS NOT NULL              
 )              
               
 INSERT INTO JobArea(JobID, AreaID) SELECT JobID, Area FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1              
          
 -- Create Invoices only for New jobs and if the site is a JOB BOARD        
 IF (EXISTS(SELECT 1 FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1) AND @SiteType = 2)           
 BEGIN          
           
           
 DECLARE @Normal_TotalAmount Decimal, @StandOut_TotalAmount Decimal, @Premium_TotalAmount Decimal          
 DECLARE @Normal_TotalJobs Decimal, @StandOut_TotalJobs Decimal, @Premium_TotalJobs Decimal          
           
 -- ****** INSERT into InvoiceItem for the Advertiser User NEW jobs ******          
 --Select @NormalInvoiceID, @StandOutInvoiceID, @PremiumInvoiceID          
 SELECT @Normal_TotalJobs = Count(*) FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1 AND JobAdType = @JobTypeID_Normal          
 SELECT @StandOut_TotalJobs = Count(*) FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1 AND JobAdType = @JobTypeID_Standout          
 SELECT @Premium_TotalJobs = Count(*) FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1 AND JobAdType = @JobTypeID_Premium          
           
 /*select JobAdType, CASE #FlatXML.JobAdType           
     WHEN @JobTypeID_Normal THEN @NormalInvoiceID           
     WHEN @JobTypeID_Standout THEN @StandOutInvoiceID          
     WHEN @JobTypeID_Premium THEN @PremiumInvoiceID END, * from #FlatXML (NOLOCK)*/          
           
           
           
    -- ****** Advertiser User invoice ******            
    DECLARE @InvoiceOrderID INT          
 INSERT INTO [InvoiceOrder] ([AdvertiserUserID],[CreatedDate],[PaymentTypeID],[IsPayable],[IsPaid],[DatePaid],          
         [PaidByAdvertiserUserID],[TotalAmount],[GST],[CurrencyID],[DiscountAmount],[DiscountGST],          
         [responseCode],[responseText],[bankTransactionID],[ResponseXML],[Success])          
 VALUES          
   (@AdvertiserUserId, GETDATE(), @PaymentTypeID_Account          
       ,1 -- IsPayable          
       ,0 -- IsPaid          
       ,null -- DatePaid          
       ,null -- [PaidByAdvertiserUserID]          
       ,0 -- TotalAmount          
       ,0 -- GST          
       ,@CurrencyID, 0, 0, '', '', '', ''          
       ,2 -- Success - Webservice = 2          
       )          
                 
 SET @InvoiceOrderID = SCOPE_IDENTITY();          
          
          
    -- ****** Insert all the invoices for Job Types of the site for Advertiser User ******          
    INSERT INTO [Invoice] ([AdvertiserUserID],[OrderID],[JobItemTypeID],[TotalNumberOfJobs], Quantity, TotalAmount, [Description])           
     SELECT @AdvertiserUserId, @InvoiceOrderID, @JobTypeID_Normal,@Normal_TotalJobs, @Normal_TotalJobs, 0, 'Webservice' Where @Normal_TotalJobs > 0          
    UNION             
     SELECT @AdvertiserUserId, @InvoiceOrderID, @JobTypeID_Standout,@Standout_TotalJobs, @Standout_TotalJobs, 0, 'Webservice' Where @Standout_TotalJobs > 0          
    UNION          
     SELECT @AdvertiserUserId, @InvoiceOrderID, @JobTypeID_Premium,@Premium_TotalJobs, @Premium_TotalJobs, 0, 'Webservice' Where @Premium_TotalJobs > 0          
          
 -- Update the Invoice and InvoiceOrder Amount and GST for the new jobs.          
 Update Invoice SET TotalAmount = (i.TotalNumberOfJobs * JobPricings.TotalAmount)  FROM Invoice i INNER JOIN           
  (SELECT JobItemTypeParentID, JobItemTypeDescription, ISNULL(ajp.TotalAmount, jit.TotalAmount) AS 'TotalAmount'          
   FROM JobItemsType jit (NOLOCK) LEFT JOIN AdvertiserJobPricing ajp (NOLOCK)          
   ON jit.JobItemTypeParentID = ajp.JobItemsTypeID AND ajp.AdvertiserID = @AdvertiserID AND           
    GETDATE() BETWEEN StartDate AND CONVERT(DATE,DATEADD(dd, 1, ExpiryDate), 101)          
   WHERE           
    SiteID = @SiteID AND VALID = 1 AND TotalNumberOfJobs = 1) JobPricings ON i.OrderID = @InvoiceOrderID AND i.JobItemTypeID = JobPricings.JobItemTypeParentID          
          
 Update InvoiceOrder SET TotalAmount = InvoiceSum.TotalAmount, GST = InvoiceSum.GST          
  FROM InvoiceOrder (NOLOCK) INNER JOIN           
   (Select OrderID, Sum(TotalAmount) as TotalAmount, (SUM(TotalAmount) * @GST) as GST FROM Invoice (NOLOCK)          
   WHERE Invoice.OrderID = @InvoiceOrderID  GROUP BY OrderID ) InvoiceSum ON InvoiceOrder.OrderID = InvoiceSum.OrderID           
           
           
    /*INSERT INTO [Invoice]          
   ([AdvertiserUserID],[JobItemTypeID],[CreatedDate],[PaymentTypeID],[IsPayable],[IsPaid],[DatePaid],[PaidByAdvertiserUserID],          
    [TotalNumberOfJobs],[Amount],[GST],[CurrencyID],[DiscountAmount],[DiscountGST])          
  SELECT @AdvertiserUserId, JobItemTypeParentID, GETDATE(), @PaymentTypeID_Account, 0, 0, null, null, 0, 0,0, @CurrencyID, null, null           
   FROM [JobItemsType] (NOLOCK) where SiteID = @SiteID AND Valid = 1          
    AND JobItemTypeParentID NOT IN (Select Invoice.JobItemTypeID FROM Invoice (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserId)*/          
              
 -- Get the Job Type Invoice IDs from the Invoice Table          
 DECLARE @NormalInvoiceID INT = 0          
 DECLARE @StandOutInvoiceID INT = 0          
 DECLARE @PremiumInvoiceID INT = 0          
    Select @NormalInvoiceID = InvoiceID from Invoice (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserId AND JobItemTypeID = @JobTypeID_Normal          
    Select @StandOutInvoiceID = InvoiceID from Invoice (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserId AND JobItemTypeID = @JobTypeID_Standout          
    Select @PremiumInvoiceID = InvoiceID from Invoice (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserId AND JobItemTypeID = @JobTypeID_Premium          
           
 -- Insert the Invoice Items for the Jobs           
 INSERT INTO [InvoiceItem]           
 ([InvoiceID],[JobID],[JobArchiveID],[CreatedDate],[AdvertiserUserID])          
  SELECT CASE #FlatXML.JobAdType           
     WHEN @JobTypeID_Normal THEN @NormalInvoiceID           
     WHEN @JobTypeID_Standout THEN @StandOutInvoiceID          
     WHEN @JobTypeID_Premium THEN @PremiumInvoiceID END,           
   [JobID], NULL, GETDATE(), @AdvertiserUserId FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1              
           
 END          
           
               
 -- *************** UPDATE the Job Roles and Area of the Jobs *********************               
 CREATE TABLE #XMLJobRoles(              
  JobID INT,              
  RoleID INT              
 )               
 INSERT INTO #XMLJobRoles(JobID, RoleID)              
  SELECT JobID, SubClassification1 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 1              
  UNION            
  SELECT JobID, SubClassification2 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 1 AND SubClassification2 IS NOT NULL              
  UNION              
  SELECT JobID, SubClassification3 FROM #FlatXML WHERE #FlatXML.Valid = 1 AND UpdateJob = 1 AND SubClassification3 IS NOT NULL              
                
 DELETE JobRoles FROM JobRoles (NOLOCK) INNER JOIN #XMLJobRoles ON #XMLJobRoles.JobID = JobRoles.JobID              
            WHERE JobRoles.RoleID not in              
                  (SELECT RoleID FROM #XMLJobRoles xmlJobRoles WHERE #XMLJobRoles.JobID = xmlJobRoles.JobID)              
            
 INSERT INTO JobRoles (JobID, RoleID)              
 SELECT #XMLJobRoles.JobID, #XMLJobRoles.RoleID from #XMLJobRoles LEFT JOIN JobRoles (NOLOCK) on #XMLJobRoles.JobID = JobRoles.JobID AND #XMLJobRoles.RoleID = JobRoles.RoleID               
 WHERE JobRoles.JobID IS NULL              
               
               
 UPDATE JobArea SET AreaID = #FlatXML.Area               
  FROM               
   #FlatXML INNER JOIN Jobs (NOLOCK) ON #FlatXML.JobID = Jobs.JobID AND Jobs.SiteID = @SiteID              
   INNER JOIN JobArea (NOLOCK) ON Jobs.JobID = JobArea.JobID  -- This line added on Feb 19th to fix the area bug              
  WHERE               
   UpdateJob = 1 AND Valid = 1              
              
                  
 -- *************** Update the SEARCH FIELD of all the Jobs *********************               
 ;WITH SearchFieldTemp              
 AS                
 (              
  Select #FlatXML.JobID, #FlatXML.WorkType,              
                
   STUFF((              
    Select ISNULL(SiteLocation.SiteLocationName, '') + ' ' +               
      ISNULL(SiteArea.SiteAreaName, '') + ' ' +               
      ISNULL(SiteProfession.SiteProfessionName, '') + ' ' +               
      ISNULL(SiteRoles.SiteRoleName , '')              
    FROM               
              
     JobArea (NOLOCK) INNER JOIN SiteArea (NOLOCK)                         
      ON [SiteArea].AreaID = [JobArea].AreaID AND [JobArea].[JobID] = #FlatXML.[JobID] AND SiteArea.Siteid = @SiteID                  
     INNER JOIN Area (NOLOCK) ON [Area].AreaID = [SiteArea].[AreaID]                           
     INNER JOIN SiteLocation (NOLOCK) ON [SiteLocation].LocationID = Area.LocationID AND SiteLocation.Siteid = @SiteID                
     INNER JOIN JobRoles (NOLOCK) ON [JobRoles].[JobID] = #FlatXML.[JobID]                            
     INNER JOIN SiteRoles (NOLOCK) ON [SiteRoles].[RoleID] = [JobRoles].[RoleID] AND SiteRoles.SiteID = @SiteID                              
     INNER JOIN Roles (NOLOCK) ON [Roles].RoleID = [SiteRoles].RoleID                            
     INNER JOIN SiteProfession (NOLOCK) ON [SiteProfession].ProfessionID = [Roles].ProfessionID AND SiteProfession.SiteID = @SiteID               
     FOR XML PATH ('')              
   ), 1, 1, '')  AS LocationAreaProfessionRoles              
                 
  FROM #FlatXML              
  Group by #FlatXML.JobID, #FlatXML.WorkType              
 )              
               
 -- Strips HTML AND REMOVE SPECIAL CHARACTERS for SearchField Column              
 UPDATE Jobs SET SearchField = [dbo].[Job_GetSearhFieldString](CAST(#FlatXML.JobID AS VARCHAR(10)) + ' ' + ISNULL(Title, '') + ' ' + ISNULL(ShortDescription, '') + ' ' + ISNULL(#FlatXML.FullDescription, '') + ' ' +               
   ISNULL(@CompanyName, '') + ' ' + ISNULL(ReferenceNo, '') + ' ' + ISNULL(AdditionalText, '') + ' ' + ISNULL(#FlatXML.PublicTransport, '') + ' ' +               
   ISNULL(StreetAddress, '') + ' ' + ISNULL(#FlatXML.ContactDetails, '') + ' ' + ISNULL(#FlatXML.BulletPoint1, '') + ' ' +               
   ISNULL(#FlatXML.BulletPoint2, '') + ' ' + ISNULL(#FlatXML.BulletPoint3, '') + ' ' +                     
   ISNULL(SiteWorkType.SiteWorkTypeName, '') + ' ' + ISNULL(#FlatXML.Tags, '') + ' ' + ISNULL(SearchFieldTemp.LocationAreaProfessionRoles,'') + 
   ' ' + ISNULL(#FlatXML.ApplicationEmailAddress,''))              
 FROM SearchFieldTemp INNER JOIN SiteWorkType (NOLOCK)                   
  ON SearchFieldTemp.WorkType = SiteWorkType.WorkTypeID INNER JOIN #FlatXML ON #FlatXML.JobID = SearchFieldTemp.JobID INNER JOIN Jobs ON Jobs.JobID = #FlatXML.JobID              
               
               
               
 -- *************** Archive Missing Jobs *********************              
    DECLARE @TotalArchived INT = 0              
                  
    IF (@ArchiveMissingJobs = 1)              
    BEGIN              
                
  -- Todo - Archive the below jobs - Invalid (ERRORS) ones should not be archived               
  SELECT @TotalArchived = COUNT(*) FROM Jobs (NOLOCK)                
   WHERE SiteID = @SiteID AND Expired = 0 AND ExpiryDate >= GETDATE() AND AdvertiserID = @AdvertiserId AND               
    NOT EXISTS               
     (SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo)              
                
                
  /*SELECT * FROM Jobs WHERE SiteID = @SiteID AND Expired = 0 AND Billed = 1 AND ExpiryDate >= GETDATE() AND               
   NOT EXISTS (SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo)*/              
       
 -- Archive only the advertiser jobs      
  UPDATE Jobs SET Expired = 1, LastModified = GETDATE()               
  FROM Jobs (NOLOCK)               
   WHERE SiteID = @SiteID AND Expired = 0 AND ExpiryDate >= GETDATE() AND AdvertiserID = @AdvertiserId AND               
    NOT EXISTS               
 (SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo) -- Todo - Need to remove Valid =1 and test not to archieve failed jobs.             
                
  /* TODO - Do we archive instantly ? Need to test performance              
  IF (@TotalArchived > 0)              
   EXEC Jobs_JobsPurge*/              
                 
    END              
                    
               
    -- *************** UPDATE THE COUNTS *********************              
    DECLARE @TotalInserted INT = 0              
    DECLARE @TotalUpdated INT = 0              
    DECLARE @TotalFailed INT = 0              
                  
    SELECT @TotalUpdated = COUNT(*) FROM #FlatXML WHERE UpdateJob = 1 AND Valid = 1              
    SELECT @TotalInserted = COUNT(*) FROM #FlatXML WHERE UpdateJob = 0 AND Valid = 1              
    SELECT @TotalFailed = COUNT(*) FROM #FlatXML WHERE Valid = 0              
                  
                  
 -- *************** Update the Site Profession FriendlyUrl of all the Jobs *********************               
    CREATE TABLE #TempSiteProfessions (              
            ProfessionID INT,              
            SiteProfessionFriendlyUrl varchar(255),              
            JobID INT NOT NULL,              
            RowNumber INT              
            );              
                                   
    INSERT INTO #TempSiteProfessions(ProfessionID, SiteProfessionFriendlyUrl, JobID, RowNumber)              
    SELECT SiteProfession.ProfessionID, SiteProfessionFriendlyUrl, JobRoles.JobID,               
   ROW_NUMBER() Over(PARTITION BY JobRoles.JobID ORDER BY SiteProfession.SiteProfessionID ASC) as RowNumber               
  FROM               
   JobRoles (NOLOCK) INNER JOIN Roles (NOLOCK) ON JobRoles.RoleID = Roles.RoleID               
    INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID               
  WHERE               
   SiteProfession.SiteID  = @SiteID AND JobRoles.JobID IS NOT NULL              
                  
  /*               
    UPDATE #FlatXML SET #FlatXML.SiteProfessionFriendlyUrl = TempSiteProfessions.SiteProfessionFriendlyUrl               
  FROM               
   #FlatXML INNER JOIN TempSiteProfessions ON TempSiteProfessions.JobID = #FlatXML.JobID  AND TempSiteProfessions.RowNumber = 1               
  WHERE               
   Valid = 1               
    */              
                         
               
                 
    -- ********************* Save this in the Response *********************              
    DECLARE @JOB_XML_RESPONSE XML                
                  
    SET @FinishedDate = GETDATE()              
                  
    SET @JOB_XML_RESPONSE = (              
  SELECT (Select @DateCreated as DateCreated, @FinishedDate as FinishedDate,               
     @TotalSent as 'Sent', @TotalInserted as 'Inserted', @TotalUpdated as 'Updated', @TotalArchived as 'Archived', @TotalFailed as 'Failed'              
    FOR XML PATH('SUMMARY'), type) AS 'JOBSUMMARY',             
  (              
   Select [ACTION], ReferenceNo, URL, Title, [Message] FROM  (              
    SELECT CASE WHEN UpdateJob = 1 THEN 'UPDATE' ELSE 'INSERT' END as [ACTION], ReferenceNo,               
      @SiteURL + ISNULL(#TempSiteProfessions.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') +               
       '/' + CAST(Jobs.JobID as varchar(10)) as URL,               
      Jobs.JobName as Title,              
      CASE WHEN Warning = 1 THEN WarningMessage ELSE '' END as [Message]              
     FROM #FlatXML INNER JOIN Jobs (NOLOCK) ON Jobs.JobID = #FlatXML.JobID               
       INNER JOIN #TempSiteProfessions ON #TempSiteProfessions.JobID = #FlatXML.JobID  AND #TempSiteProfessions.RowNumber = 1              
     WHERE Valid = 1 -- AND UpdateJob = 0              
    /*UNION              
    SELECT 'UPDATE' as [ACTION], ReferenceNo,               
      @SiteURL + ISNULL(#TempSiteProfessions.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') + '/' + CAST(Jobs.JobID as varchar(10)) as URL,               
      '' as [Message]              
     FROM #FlatXML INNER JOIN Jobs (NOLOCK) ON Jobs.JobID = #FlatXML.JobID               
       INNER JOIN #TempSiteProfessions ON #TempSiteProfessions.JobID = #FlatXML.JobID  AND #TempSiteProfessions.RowNumber = 1              
     WHERE Valid = 1 AND UpdateJob = 1*/              
    UNION              
     SELECT 'ARCHIVE' as [ACTION], Jobs.RefNo,               
       @SiteURL + ISNULL(#TempSiteProfessions.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(JobFriendlyName, '') +               
        '/' + CAST(Jobs.JobID as varchar(10)) as URL,               
       Jobs.JobName as Title,              
       '' as [Message]              
      FROM Jobs (NOLOCK)               
       INNER JOIN #TempSiteProfessions ON #TempSiteProfessions.JobID = Jobs.JobID  AND #TempSiteProfessions.RowNumber = 1              
      WHERE SiteID = @SiteID AND Expired = 0 AND ExpiryDate >= GETDATE() AND AdvertiserID = @AdvertiserId AND               
       NOT EXISTS               
        (SELECT 1 FROM #FlatXML WHERE Valid = 1 AND #FlatXML.ReferenceNo = Jobs.RefNo)              
                    
      AND @ArchiveMissingJobs = 1 -- ONLY DISPLAY If Parameter is enabled              
    UNION              
     SELECT 'ERROR' as [ACTION], ReferenceNo, '' as URL, ISNULL(#FlatXML.Title,'') as Title, ErrorMessage as [Message] FROM #FlatXML WHERE Valid = 0              
    /*UNION              
     SELECT 'WARNING' as [ACTION], ReferenceNo, '' as URL, WarningMessage as [Message] FROM #FlatXML WHERE Warning = 1*/              
   ) as XMLOUTPUT              
  FOR XML PATH('JOB'), TYPE              
 ) AS 'JOBPOSTING' FOR XML PATH (''), ROOT('ROOT'))              
                 
                 
    DROP TABLE #TempSiteProfessions              
                      
 -- Update the xml to the WebserviceLog with the time taken, logs and stats              
 UPDATE WebServiceLog               
  SET               
   OutputResponse = @JOB_XML_RESPONSE,              
   TotalSent = @TotalSent,              
   TotalInserted = @TotalInserted,              
   TotalUpdated = @TotalUpdated,              
   TotalArchived = @TotalArchived,              
   TotalFailed = @TotalFailed,              
   FinishedDate = @FinishedDate              
  WHERE               
   WebServiceLogId = @WebServiceLogId              
                
                
    SELECT JobID, * FROM #FlatXML               
                  
                
 -- *************** Drop the temporary table *********************              
    DROP TABLE #FlatXML              
    --DROP TABLE #ErrorJobXML              
              
COMMIT TRANSACTION PostJobsTransaction              
END TRY              
               
BEGIN CATCH              
                
 IF @@TRANCOUNT > 0              
 --BEGIN              
  ROLLBACK TRANSACTION --PostJobsTransaction --RollBack in case of Error              
--ROLLBACK TRAN              
  --SET @@TRANCOUNT = 1              
 --END              
               
 -- Raise an error with the details of the exception              
 DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT              
 SELECT @ErrMsg = ERROR_MESSAGE(),              
 @ErrSeverity = ERROR_SEVERITY()              
              
 -- Update the WebserviceLog there was an error.              
 UPDATE WebServiceLog               
  SET               
   TotalSent = @TotalSent,              
   OutputResponse = (SELECT ERROR_MESSAGE() + ' [ ERROR_NUMBER : ' + CAST(ERROR_NUMBER() AS VARCHAR(50)) + ' ] ' +  '[ ERROR_LINE : ' + CAST(ERROR_LINE() AS VARCHAR(50)) + ' ] ' FOR XML PATH('ERROR'), ROOT ('ERRORRESULT')),              
   TotalFailed = @TotalSent,              
   FinishedDate = GETDATE()              
  WHERE               
   WebServiceLogId = @WebServiceLogId              
              
 /*                
 IF USER_NAME() IS NOT NULL                          
 BEGIN                  
  RAISERROR(@ErrMsg, @ErrSeverity, 1)              
 END              
 */               
                
END CATCH             
              
    -- *************** OUTPUT ********************* TODO REMOVE THIS              
 SELECT WebServiceLogId, CreatedDate, OutputResponse, TotalSent, TotalInserted, TotalUpdated, TotalArchived, TotalFailed, FinishedDate              
 FROM WebServiceLog (NOLOCK)              
  WHERE               
   WebServiceLogId = @WebServiceLogId              
              
            
-- Finally runs the site job count
exec [dbo].[Jobs_CustomUpdateSiteJobCount] @SiteID
              
END
GO
/****** Object:  StoredProcedure [dbo].[JobApplication_CustomGetNewJobApplications]    Script Date: 01/20/2017 11:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[JobApplication_CustomGetNewJobApplications]                  
(                  
 @SiteID INT,                        
 @JobApplicationID INT = 0,          
 @AdvertiserUserID INT = 0          
)                  
AS                  
BEGIN             
      
DECLARE @isPrimary BIT = 0        
 DECLARE @AdvertiserID INT = 0        
        
 IF (@AdvertiserUserID > 0)        
 BEGIN        
 SET @isPrimary = (SELECT PrimaryAccount FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)        
 IF(@isPrimary = 1)        
 BEGIN        
  SET @AdvertiserID = (SELECT AdvertiserID FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)         
 END        
 END        
       
 DECLARE @tmpJobApplication AS TABLE(JobApplicationID INT, RefNo VARCHAR(255), JobID INT)      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, j.RefNo, j.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN Jobs j WITH (NOLOCK)                
 ON ja.JobID = j.JobID      
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (j.Expired = 0 OR j.Expired = 1)  AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND j.AdvertiserID = @AdvertiserID) OR (@AdvertiserUserID > 0 AND (j.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (j.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, jarchive.RefNo, jarchive.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN JobsArchive jarchive WITH (NOLOCK)                
 ON ja.JobArchiveID = jarchive.JobID                
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (jarchive.Expired = 0 OR jarchive.Expired = 1) AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND (jarchive.AdvertiserID = @AdvertiserID)) OR (@AdvertiserUserID > 0 AND  (jarchive.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (jarchive.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 DECLARE @tmpJobApplicationArea AS TABLE(JobID INT, AreaID INT)      
 INSERT INTO @tmpJobApplicationArea      
 SELECT DISTINCT ja.JobID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobID IN (SELECT JobID FROM @tmpJobApplication)       
UNION      
SELECT DISTINCT ja.JobArchiveID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobArchiveID IN (SELECT JobID FROM @tmpJobApplication)       
      
      
 DECLARE @tmpJobApplicationAbbr AS TABLE(JobID INT, Abbr NVARCHAR(400))      
 INSERT INTO @tmpJobApplicationAbbr      
 SELECT jaa.JobID, Abbr FROM @tmpJobApplicationArea jaa      
 INNER JOIN Area a  WITH (NOLOCK)                
 ON jaa.AreaID = a.AreaID      
 INNER JOIN Location l  WITH (NOLOCK)                
 ON a.LocationID = l.LocationID                
 INNER JOIN Countries c  WITH (NOLOCK)                
 ON l.CountryID = c.CountryID           
      
 SELECT ja.JobApplicationID, ja.ApplicationDate, m.FirstName, m.Surname, m.EmailAddress, m.MobilePhone, m.PreferredCategoryID, m.PreferredSubCategoryID, ja.MemberResumeFile, ja.MemberCoverLetterFile, ja.ApplicationStatus, c.Abbr, tja.RefNo, tja.JobID, ja.
  
Draft, ja.JobApplicationTypeID, ja.ExternalXMLFilename , ja.ExternalPDFFilename, ja.URL_Referral,ja.AppliedWith, ja.LastViewedDate, ja.MemberID               
 FROM @tmpJobApplication tja       
 INNER JOIN JobApplication ja WITH (NOLOCK)                
 ON tja.JobApplicationID = ja.JobApplicationID      
 INNER JOIN Members m WITH (NOLOCK) ON m.MemberID = ja.MemberID      
 INNER JOIN @tmpJobApplicationAbbr c      
 ON c.JobID = ja.JobID    or c.JobID = ja.JobArchiveID         
       
 ORDER BY ja.JobApplicationID        
      
END
GO
