ALTER TABLE Sites ADD SiteURLAlias VARCHAR(500) NULL
GO

ALTER TABLE GlobalSettings ADD JobApplicationPageID INT NULL
GO

ALTER TABLE GlobalSettings ADD FOREIGN KEY (JobApplicationPageID) REFERENCES DynamicPages(DynamicPageID)
GO

/****** Object:  StoredProcedure [dbo].[Sites_Update]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_Update]
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

	@SiteAdminLogoUrl nvarchar (1000)  ,

	@SiteUrlAlias varchar (500)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Sites]
				SET
					[SiteName] = @SiteName
					,[SiteURL] = @SiteUrl
					,[SiteDescription] = @SiteDescription
					,[SiteAdminLogo] = @SiteAdminLogo
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
					,[Live] = @Live
					,[MobileEnabled] = @MobileEnabled
					,[MobileUrl] = @MobileUrl
					,[SiteAdminLogoUrl] = @SiteAdminLogoUrl
					,[SiteURLAlias] = @SiteUrlAlias
				WHERE
[SiteID] = @SiteId
GO
/****** Object:  StoredProcedure [dbo].[Sites_Insert]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_Insert]
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

	@SiteAdminLogoUrl nvarchar (1000)  ,

	@SiteUrlAlias varchar (500)  
)
AS


				
				INSERT INTO [dbo].[Sites]
					(
					[SiteName]
					,[SiteURL]
					,[SiteDescription]
					,[SiteAdminLogo]
					,[LastModified]
					,[LastModifiedBy]
					,[Live]
					,[MobileEnabled]
					,[MobileUrl]
					,[SiteAdminLogoUrl]
					,[SiteURLAlias]
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
					,@SiteUrlAlias
					)
				
				-- Get the identity value
				SET @SiteId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetPaging]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_GetPaging]  
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
/****** Object:  StoredProcedure [dbo].[Sites_GetPaged]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_GetPaged]
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
				SELECT O.[SiteID], O.[SiteName], O.[SiteURL], O.[SiteDescription], O.[SiteAdminLogo], O.[LastModified], O.[LastModifiedBy], O.[Live], O.[MobileEnabled], O.[MobileUrl], O.[SiteAdminLogoUrl], O.[SiteURLAlias]
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
/****** Object:  StoredProcedure [dbo].[Sites_GetBySiteId]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_GetBySiteId]
(

	@SiteId int   
)
AS


				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl],
					[SiteURLAlias]
				FROM
					[dbo].[Sites]
				WHERE
					[SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetByMobileUrl]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_GetByMobileUrl]
(

	@MobileUrl varchar (255)  
)
AS


				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl],
					[SiteURLAlias]
				FROM
					[dbo].[Sites]
				WHERE
					[MobileUrl] = @MobileUrl
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetByLastModifiedBy]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl],
					[SiteURLAlias]
				FROM
					[dbo].[Sites]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Sites_Get_List]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_Get_List]

AS


				
				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[SiteAdminLogo],
					[LastModified],
					[LastModifiedBy],
					[Live],
					[MobileEnabled],
					[MobileUrl],
					[SiteAdminLogoUrl],
					[SiteURLAlias]
				FROM
					[dbo].[Sites]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_Find]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_Find]
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

	@SiteAdminLogoUrl nvarchar (1000)  = null ,

	@SiteUrlAlias varchar (500)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteURL]
	, [SiteDescription]
	, [SiteAdminLogo]
	, [LastModified]
	, [LastModifiedBy]
	, [Live]
	, [MobileEnabled]
	, [MobileUrl]
	, [SiteAdminLogoUrl]
	, [SiteURLAlias]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([SiteName] = @SiteName OR @SiteName IS NULL)
	AND ([SiteURL] = @SiteUrl OR @SiteUrl IS NULL)
	AND ([SiteDescription] = @SiteDescription OR @SiteDescription IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([Live] = @Live OR @Live IS NULL)
	AND ([MobileEnabled] = @MobileEnabled OR @MobileEnabled IS NULL)
	AND ([MobileUrl] = @MobileUrl OR @MobileUrl IS NULL)
	AND ([SiteAdminLogoUrl] = @SiteAdminLogoUrl OR @SiteAdminLogoUrl IS NULL)
	AND ([SiteURLAlias] = @SiteUrlAlias OR @SiteUrlAlias IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteURL]
	, [SiteDescription]
	, [SiteAdminLogo]
	, [LastModified]
	, [LastModifiedBy]
	, [Live]
	, [MobileEnabled]
	, [MobileUrl]
	, [SiteAdminLogoUrl]
	, [SiteURLAlias]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([SiteName] = @SiteName AND @SiteName is not null)
	OR ([SiteURL] = @SiteUrl AND @SiteUrl is not null)
	OR ([SiteDescription] = @SiteDescription AND @SiteDescription is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([Live] = @Live AND @Live is not null)
	OR ([MobileEnabled] = @MobileEnabled AND @MobileEnabled is not null)
	OR ([MobileUrl] = @MobileUrl AND @MobileUrl is not null)
	OR ([SiteAdminLogoUrl] = @SiteAdminLogoUrl AND @SiteAdminLogoUrl is not null)
	OR ([SiteURLAlias] = @SiteUrlAlias AND @SiteUrlAlias is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Sites_Delete]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[Sites_Delete]
(

	@SiteId int   
)
AS


				DELETE FROM [dbo].[Sites] WITH (ROWLOCK) 
				WHERE
					[SiteID] = @SiteId
GO
/****** Object:  StoredProcedure [dbo].[Sites_FindSite]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_FindSite]    
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
/****** Object:  StoredProcedure [dbo].[Sites_Create]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_Create]
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
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Update]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS OFF
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

	@GlobalFolder varchar (255)  ,

	@EnableScreeningQuestions bit   ,

	@EnableExpiryDate bit   ,

	@MemberRegisterPageId int   ,

	@JobApplicationPageId int   
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
					,[EnableExpiryDate] = @EnableExpiryDate
					,[MemberRegisterPageID] = @MemberRegisterPageId
					,[JobApplicationPageID] = @JobApplicationPageId
				WHERE
[GlobalSettingID] = @GlobalSettingId
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Insert]    Script Date: 04/20/2017 14:04:04 ******/
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

	@EnableScreeningQuestions bit   ,

	@EnableExpiryDate bit   ,

	@MemberRegisterPageId int   ,

	@JobApplicationPageId int   
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
					,[EnableExpiryDate]
					,[MemberRegisterPageID]
					,[JobApplicationPageID]
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
					,@EnableExpiryDate
					,@MemberRegisterPageId
					,@JobApplicationPageId
					)
				
				-- Get the identity value
				SET @GlobalSettingId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetPaged]    Script Date: 04/20/2017 14:04:04 ******/
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
				SELECT O.[GlobalSettingID], O.[SiteID], O.[DefaultLanguageID], O.[DefaultDynamicPageID], O.[PublicJobsSearch], O.[PublicMembersSearch], O.[PublicCompaniesSearch], O.[PublicSponsoredAdverts], O.[PrivateJobs], O.[PrivateMembers], O.[PrivateCompanies], O.[LastModifiedBy], O.[LastModified], O.[PageTitlePrefix], O.[PageTitleSuffix], O.[DefaultTitle], O.[HomeTitle], O.[DefaultDescription], O.[HomeDescription], O.[DefaultKeywords], O.[HomeKeywords], O.[ShowFaceBookButton], O.[UseAdvertiserFilter], O.[MerchantID], O.[ShowTwitterButton], O.[ShowJobAlertButton], O.[ShowLinkedInButton], O.[SiteFavIconID], O.[SiteDocType], O.[CurrencySymbol], O.[FtpFolderLocation], O.[MetaTags], O.[SystemMetaTags], O.[MemberRegistrationNotification], O.[LinkedInAPI], O.[LinkedInLogo], O.[LinkedInCompanyID], O.[LinkedInEmail], O.[PrivacySettings], O.[WWWRedirect], O.[AllowAdvertiser], O.[LinkedInAPISecret], O.[GoogleClientID], O.[GoogleClientSecret], O.[FacebookAppID], O.[FacebookAppSecret], O.[LinkedInButtonSize], O.[DefaultCountryID], O.[PayPalUsername], O.[PayPalPassword], O.[PayPalSignature], O.[SecurePayMerchantID], O.[SecurePayPassword], O.[UsingSSL], O.[UseCustomProfessionRole], O.[GenerateJobXML], O.[IsPrivateSite], O.[PrivateRedirectUrl], O.[EnableJobCustomQuestionnaire], O.[JobApplicationTypeID], O.[JobScreeningProcess], O.[AdvertiserApprovalProcess], O.[SiteType], O.[EnableSSL], O.[GST], O.[GSTLabel], O.[NumberOfPremiumJobs], O.[PremiumJobDays], O.[DisplayPremiumJobsOnResults], O.[JobExpiryNotification], O.[CurrencyID], O.[PayPalClientID], O.[PayPalClientSecret], O.[PaypalUser], O.[PaypalProPassword], O.[PaypalVendor], O.[PaypalPartner], O.[InvoiceSiteInfo], O.[InvoiceSiteFooter], O.[EnableTermsAndConditions], O.[DefaultEmailLanguageId], O.[GoogleTagManager], O.[GoogleAnalytics], O.[GoogleWebMaster], O.[EnablePeopleSearch], O.[GlobalDateFormat], O.[TimeZone], O.[GlobalFolder], O.[EnableScreeningQuestions], O.[EnableExpiryDate], O.[MemberRegisterPageID], O.[JobApplicationPageID]
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
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdUseAdvertiserFilter]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [UseAdvertiserFilter] = @UseAdvertiserFilter
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdPublicJobsSearch]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [PublicJobsSearch] = @PublicJobsSearch
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteIdGlobalSettingId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
					AND [GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetBySiteFavIconId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[SiteFavIconID] = @SiteFavIconId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[PublicJobsSearch] = @PublicJobsSearch
					AND [PrivateJobs] = @PrivateJobs
					AND [SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByMemberRegisterPageId]    Script Date: 04/20/2017 14:04:04 ******/
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


ALTER PROCEDURE [dbo].[GlobalSettings_GetByMemberRegisterPageId]
(

	@MemberRegisterPageId int   
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[MemberRegisterPageID] = @MemberRegisterPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByLastModifiedBy]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByJobApplicationPageId]    Script Date: 04/20/2017 14:04:04 ******/
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


CREATE PROCEDURE [dbo].[GlobalSettings_GetByJobApplicationPageId]
(

	@JobApplicationPageId int   
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[JobApplicationPageID] = @JobApplicationPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByGlobalSettingId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[GlobalSettingID] = @GlobalSettingId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultLanguageId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultLanguageID] = @DefaultLanguageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultDynamicPageId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultDynamicPageID] = @DefaultDynamicPageId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_GetByDefaultCountryId]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
				WHERE
					[DefaultCountryID] = @DefaultCountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Get_List]    Script Date: 04/20/2017 14:04:04 ******/
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
					[EnableScreeningQuestions],
					[EnableExpiryDate],
					[MemberRegisterPageID],
					[JobApplicationPageID]
				FROM
					[dbo].[GlobalSettings]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Find]    Script Date: 04/20/2017 14:04:04 ******/
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

	@EnableScreeningQuestions bit   = null ,

	@EnableExpiryDate bit   = null ,

	@MemberRegisterPageId int   = null ,

	@JobApplicationPageId int   = null 
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
	, [EnableExpiryDate]
	, [MemberRegisterPageID]
	, [JobApplicationPageID]
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
	AND ([EnableExpiryDate] = @EnableExpiryDate OR @EnableExpiryDate IS NULL)
	AND ([MemberRegisterPageID] = @MemberRegisterPageId OR @MemberRegisterPageId IS NULL)
	AND ([JobApplicationPageID] = @JobApplicationPageId OR @JobApplicationPageId IS NULL)
						
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
	, [EnableExpiryDate]
	, [MemberRegisterPageID]
	, [JobApplicationPageID]
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
	OR ([EnableExpiryDate] = @EnableExpiryDate AND @EnableExpiryDate is not null)
	OR ([MemberRegisterPageID] = @MemberRegisterPageId AND @MemberRegisterPageId is not null)
	OR ([JobApplicationPageID] = @JobApplicationPageId AND @JobApplicationPageId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[GlobalSettings_Delete]    Script Date: 04/20/2017 14:04:04 ******/
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
/****** Object:  StoredProcedure [dbo].[GlobalSettings_CustomGetPaymentDetail]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS OFF
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
/****** Object:  StoredProcedure [dbo].[Sites_Remove]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_Remove]  
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
/****** Object:  StoredProcedure [dbo].[Sites_Copy]    Script Date: 04/20/2017 14:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sites_Copy]                          
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
