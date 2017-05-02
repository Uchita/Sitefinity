USE [MiniJXT]
GO
/****** Object:  StoredProcedure [dbo].[ViewJobSearch_GetBySearchFilter]    Script Date: 04/21/2017 09:44:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilter]                                   
	(@Keyword NVARCHAR(2500),                                               
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
)
AS                                               
BEGIN   
	-- WARDY Local variables added by WARDY IT
	DECLARE @Keywordlocal NVARCHAR(2500)                                             
	DECLARE @SiteIdlocal INT                                     
	DECLARE @AdvertiserIdlocal INT                                   
	DECLARE @CurrencyIDlocal INT
	DECLARE @SalaryLowerBandlocal NUMERIC(15,2)
	DECLARE @SalaryUpperBandlocal NUMERIC(15,2)
	DECLARE @SalaryTypeIDlocal INT                              
	DECLARE @WorkTypeIDlocal INT
	DECLARE @ProfessionIDlocal INT
	DECLARE @RoleIDlocal VARCHAR(255)
	DECLARE @CountryIDlocal INT
	DECLARE @LocationIDlocal INT
	DECLARE @AreaIDlocal VARCHAR(255)
	DECLARE @DateFromlocal DATETIME
	DECLARE @PageIndexlocal INT                                               
	DECLARE @PageSizelocal INT          
	DECLARE @OrderBylocal VARCHAR(200)
	DECLARE @JobTypeIDslocal VARCHAR(255)

	-- Map NOT NULL parameters to local variable.
	SET @SiteIDlocal = @SiteID
	SET @PageIndexlocal = @PageIndex
	SET @PageSizelocal = @PageSize
	
	-- Set NULL inputs to 0 or '' depending on data type
	SET @Keywordlocal = CASE WHEN @Keyword IS NULL THEN '""' WHEN @Keyword = '' THEN '""' ELSE @Keyword END
	SET @AdvertiserIdlocal = CASE WHEN @AdvertiserId IS NULL THEN 0 ELSE @AdvertiserId END
	SET @CurrencyIDlocal = CASE WHEN @CurrencyID IS NULL THEN 0 ELSE @CurrencyID END
	SET @SalaryLowerBandlocal = CASE WHEN @SalaryLowerBand IS NULL THEN 0 ELSE @SalaryLowerBand END
	SET @SalaryUpperBandlocal = CASE WHEN @SalaryUpperBand IS NULL THEN 0 ELSE @SalaryUpperBand END
	SET @SalaryTypeIDlocal = CASE WHEN @SalaryTypeID IS NULL THEN 0 ELSE @SalaryTypeID END
	SET @WorkTypeIDlocal = CASE WHEN @WorkTypeID IS NULL THEN 0 ELSE @WorkTypeID END
	SET @ProfessionIDlocal = CASE WHEN @ProfessionID IS NULL THEN 0 ELSE @ProfessionID END
	SET @RoleIDlocal = CASE WHEN @RoleID IS NULL THEN '' ELSE @RoleID	 END
	SET @CountryIDlocal = CASE WHEN @CountryID IS NULL THEN '' ELSE @CountryID END
	SET @LocationIDlocal = CASE WHEN @LocationID IS NULL THEN '' ELSE @LocationID END
	SET @AreaIDLocal = CASE WHEN @AreaID IS NULL THEN '' ELSE @AreaID END
	SET @DateFromlocal = CASE WHEN @DateFrom IS NULL THEN '1900-01-01 00:00:00.000' ELSE @DateFrom END
	SET @OrderBylocal = CASE WHEN @OrderBy IS NULL THEN '' ELSE @OrderBy END
	SET @JobTypeIDslocal = CASE WHEN @JobTypeIDs IS NULL THEN '' ELSE @JobTypeIDs END
	
	-- WARDY End Wardy Changes

	/*      
	 -- 16th April       
	 -- Fix for Advertiser Filter taking lot of time to load the jobs.     
		 
	 -- 20th April    
	 -- Add countryid as parameter 
	 
	 --10 April 2017
	 -- FIX salary range search
	 
	 --21 April 2017
	 -- WARDY FIX de-duplication of jobs
	*/                
	 -- DECLARE @UseCustomProfessionRole BIT = (SELECT UseCustomProfessionRole FROM GlobalSettings WHERE SiteID = @SiteId)                   
			   
	 -- Check if the Salary sorting has the Salary type selected if not it goes to default search          
	 IF (@OrderBylocal = 'SalaryHighToLow' OR @OrderBylocal = 'SalaryLowToHigh')          
	 BEGIN           
		IF (ISNULL(@SalaryTypeIDlocal,0) = 0)          
		BEGIN
			SET @OrderBylocal = ''
		END
	 END          
			
	-- Global settings - Get if Premium jobs needs to be displayed.        
	DECLARE @DisplayPremiumJobsOnResults BIT
	
	SELECT @DisplayPremiumJobsOnResults = DisplayPremiumJobsOnResults 
	FROM GlobalSettings WITH (NOLOCK) 
	WHERE SiteID = @SiteIdlocal        
			
	-- Get the valid JOB Types of the Site excluding Premium jobs      
	IF (@JobTypeIDslocal = '')  
	BEGIN    
		SELECT @JobTypeIDslocal = COALESCE(@JobTypeIDslocal + ', ', '') + CAST(JobItemTypeParentID AS VARCHAR)        
		FROM JobItemsType WITH (NOLOCK)
		WHERE SiteID = @SiteIdlocal 
			AND Valid = 1 
			AND TotalNumberOfJobs = 1 
			AND JobItemTypeParentID <>3        
	END  
		  
	DECLARE @tmpJobIdSearch TABLE (JobID INT, RoleId INT, RowNumber INT)
	
	INSERT INTO @tmpJobIdSearch(JobID, RoleId, RowNumber)      
	SELECT JobId, RoleID, RowNumber 
	FROM       
	(      
	SELECT                   
	Jobs.JobId,         
	SiteRoles.RoleID,                        
	ROW_NUMBER() OVER (ORDER BY            
	   CASE WHEN ISNULL(@OrderBylocal,'') = '' THEN Jobs.DatePosted  END DESC,          
	   CASE WHEN @OrderBylocal ='Old' THEN Jobs.DatePosted END,          
	   CASE WHEN @OrderBylocal ='ZA' THEN Jobs.JobName  END DESC,          
	   CASE WHEN @OrderBylocal ='AZ' THEN Jobs.JobName  END,          
	   CASE WHEN @OrderBylocal ='SalaryHighToLow' THEN Jobs.SalaryUpperBand END DESC,          
	   CASE WHEN @OrderBylocal ='SalaryLowToHigh' THEN Jobs.SalaryLowerBand  END          
	   ) AS RowNumber           
	FROM [dbo].[udfSite_GetAdvertisers](@SiteIdlocal) AdvertiserFilter                                       
	INNER JOIN Jobs (NOLOCK) ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                                            
	INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                 
	LEFT JOIN SalaryType (NOLOCK) ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                 
	INNER JOIN SiteSalaryType (NOLOCK) ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID AND SiteSalaryType.SiteID = @SiteIdlocal
	INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID AND [SiteCurrencies].SiteID = Jobs.SiteID
	INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID
	INNER JOIN WorkType (NOLOCK) ON WorkType.WorkTypeID = Jobs.WorkTypeID
	LEFT JOIN SiteWorkType (NOLOCK) ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID AND SiteWorkType.SiteID = @SiteIdlocal
	-- Country Location Area                              
	INNER JOIN JobArea (NOLOCK) ON JobArea.JobID = Jobs.JobID                                             
	INNER JOIN ViewSiteAreaLocationCountry (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID 
	AND ViewSiteAreaLocationCountry.Siteid = @SiteIdlocal 
	AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteIdlocal                           
	AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteIdlocal                                           
	-- Profession Role                                             
	INNER JOIN JobRoles (NOLOCK) ON JobRoles.JobID = Jobs.JobId
	INNER JOIN SiteRoles (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID AND SiteRoles.SiteID = @SiteID
	INNER JOIN Roles (NOLOCK) ON Roles.RoleID = JobRoles.RoleID
	INNER JOIN Profession (NOLOCK) ON Profession.ProfessionID = Roles.ProfessionID
	INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteIDlocal                                               
	WHERE                                              
		Jobs.Expired = 0
		AND Jobs.ExpiryDate >= GETDATE() 
		-- WARDY Following Section altered
		AND ((@AdvertiserIdlocal = 0) OR (Jobs.AdvertiserID = @AdvertiserIdlocal))
		AND ((@CurrencyIDlocal = 0) OR (Jobs.CurrencyID = @CurrencyIDlocal)) 
		--Liam Logic update on salary search 
		AND ((@SalaryLowerBandlocal = 0) OR (@SalaryLowerBandlocal <= Jobs.SalaryUpperBand)) 
		AND ((@SalaryUpperBandlocal = 0) OR (@SalaryUpperBandlocal > =Jobs.SalaryLowerBand)) 
		AND ((@SalaryTypeIDlocal = 0) OR (Jobs.SalaryTypeID  = @SalaryTypeIDlocal)) 
		AND ((@WorkTypeIDlocal = 0) OR (Jobs.WorkTypeID = @WorkTypeIDlocal)) 
		AND ((@ProfessionIDlocal = 0) OR (Roles.ProfessionID = @ProfessionIDlocal)) 
		AND ((@RoleIDlocal = '') OR (EXISTS (Select id from ParseIntCSV(@RoleIDlocal) where id = Roles.RoleID))) 
		AND ((@CountryIDlocal = '') OR (ViewSiteAreaLocationCountry.CountryID = @CountryIDlocal))  
		AND ((@LocationIDlocal = '') OR (ViewSiteAreaLocationCountry.LocationID = @LocationIDlocal))  
		AND ((@AreaIDLocal = '') OR (EXISTS (Select id from ParseIntCSV(@AreaIDlocal) where id = ViewSiteAreaLocationCountry.AreaID)))         
		AND ((Jobs.JobItemTypeID IN (Select id from ParseIntCSV(@JobTypeIDslocal)))         
			OR (Jobs.JobItemTypeID IS NULL) -- TODO REMOVE Jobs.JobItemTypeID NULL          
			OR (@DisplayPremiumJobsOnResults = 1 AND Jobs.JobItemTypeID = 3 AND Jobs.SiteID = @SiteIdlocal))        
		AND Jobs.DatePosted <= CAST(GETDATE()+1 AS DATE)       
		AND ((@DateFromlocal = '1900-01-01 00:00:00.000') OR Jobs.DatePosted >= @DateFromlocal) -- FOR JOB ALERT - Only send new jobs - Don't REMOVE                         
		AND ((@Keywordlocal = '""') OR(CONTAINS(Jobs.[SearchField], @Keywordlocal)))
	) Job -- End WARDY IT alterations
	--WHERE                           
	--	Job.RowNumber BETWEEN (@PageIndexlocal * @PageSizelocal + 1) AND ((@PageIndexlocal * @PageSizelocal) + @PageSizelocal)                                            
	ORDER BY Job.RowNumber 
	-- WARDY Added
	OPTION (RECOMPILE)      
	--WARDY Complete alteration
 
	;WITH JobRecords AS (
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
			ViewSiteAreaLocationCountry.Currency AS CurrencySymbol, -- Currencies.CurrencySymbol,                                            
			Jobs.SalaryUpperBand,                                            
			Jobs.SalaryLowerBand,                                       
			Jobs.SalaryTypeId,                                        
			ISNULL(SiteSalaryType.SalaryTypeName, SalaryType.SalaryTypeName) AS SalaryTypeName,                                            
			ISNULL(SiteWorkType.SiteWorkTypeName, WorkType.WorkTypeName) AS WorkTypeName,            
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
			'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') AS JobFriendlyName,                       
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
			Jobs.Address,
			Jobs.PublicTransport,
			ROW_NUMBER() OVER (PARTITION BY Jobs.JobID ORDER BY Roles.ProfessionID, Roles.RoleID) AS [RN]
		FROM @tmpJobIdSearch tmpJobIdSearch
		INNER JOIN Jobs (NOLOCK) ON tmpJobIdSearch.JobID = Jobs.JobID
		INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID
		LEFT JOIN SalaryType (NOLOCK) ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID
		INNER JOIN SiteSalaryType (NOLOCK) ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID AND SiteSalaryType.SiteID = @SiteIdlocal
		INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID AND [SiteCurrencies].SiteID = Jobs.SiteID
		INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID
		INNER JOIN WorkType (NOLOCK) ON WorkType.WorkTypeID = Jobs.WorkTypeID
		LEFT JOIN SiteWorkType (NOLOCK) ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID AND SiteWorkType.SiteID = @SiteIdlocal
		-- Country Location Area
		INNER JOIN JobArea (NOLOCK) ON JobArea.JobID = Jobs.JobID
		INNER JOIN ViewSiteAreaLocationCountry (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID
			AND ViewSiteAreaLocationCountry.Siteid = @SiteIdlocal
			AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteIdlocal
			AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteIdlocal
		-- Profession Role
		INNER JOIN JobRoles (NOLOCK) ON JobRoles.JobID = Jobs.JobId
		INNER JOIN SiteRoles (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID AND SiteRoles.SiteID = @SiteIdlocal AND SiteRoles.RoleID = tmpJobIdSearch.RoleId
		INNER JOIN Roles (NOLOCK) ON Roles.RoleID = JobRoles.RoleID
		INNER JOIN Profession (NOLOCK) ON Profession.ProfessionID = Roles.ProfessionID
		INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteIdlocal
		LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID
	), FinalRecords AS (
		SELECT
			[JobId],
			[SiteID],
			[JobName],
			[Description],
			[FullDescription],
			[DatePosted],
			[Visible],
			[Expired],
			[ShowSalaryDetails],
			[ShowSalaryRange],
			[SalaryText],
			[AdvertiserID],
			[ApplicationMethod],
			[ApplicationURL],
			[AdvertiserJobTemplateLogoID],
			[CompanyName],
			[ShowLocationDetails],
			[BulletPoint1],
			[BulletPoint2],
			[BulletPoint3],
			[HotJob],
			[ApplicationEmailAddress],
			[ExpiryDate],
			[ContactDetails],
			[RefNo],
			[AdvertiserName],
			[CurrencySymbol],
			[SalaryUpperBand],
			[SalaryLowerBand],
			[SalaryTypeId],
			[SalaryTypeName],
			[WorkTypeName],
			[CountryID],
			[LocationID],
			[AreaID],
			[CountryName],
			[LocationName],
			[AreaName],
			[ProfessionID],
			[RoleID],
			[SiteProfessionName],
			[SiteRoleName],
			[BreadCrumbNavigation],
			[WorkTypeID],
			[JobFriendlyName],
			[SalaryDisplay],
			[JobItemTypeID],
			[JobLatitude],
			[JobLongitude],
			[AddressStatus],
			[HasAdvertiserLogo],	
			[CustomXML],	
			[Address],	
			[PublicTransport],
			[RN],
			ROW_NUMBER() OVER (ORDER BY            
			   CASE WHEN ISNULL(@OrderBylocal,'') = '' THEN DatePosted  END DESC,          
			   CASE WHEN @OrderBylocal ='Old' THEN DatePosted END,          
			   CASE WHEN @OrderBylocal ='ZA' THEN JobName  END DESC,          
			   CASE WHEN @OrderBylocal ='AZ' THEN JobName  END,          
			   CASE WHEN @OrderBylocal ='SalaryHighToLow' THEN SalaryUpperBand END DESC,          
			   CASE WHEN @OrderBylocal ='SalaryLowToHigh' THEN SalaryLowerBand  END          
			   ) AS RowNumber
		FROM JobRecords
		WHERE (@RoleIDlocal = '' AND [RN] = 1)
			OR (@RoleIDlocal <> '')
	)
	SELECT [JobId],
		[SiteID],
		[JobName],
		[Description],
		[FullDescription],
		[DatePosted],
		[Visible],
		[Expired],
		[ShowSalaryDetails],
		[ShowSalaryRange],
		[SalaryText],
		[AdvertiserID],
		[ApplicationMethod],
		[ApplicationURL],
		[AdvertiserJobTemplateLogoID],
		[CompanyName],
		[ShowLocationDetails],
		[BulletPoint1],
		[BulletPoint2],
		[BulletPoint3],
		[HotJob],
		[ApplicationEmailAddress],
		[ExpiryDate],
		[ContactDetails],
		[RefNo],
		[AdvertiserName],
		[CurrencySymbol],
		[SalaryUpperBand],
		[SalaryLowerBand],
		[SalaryTypeId],
		[SalaryTypeName],
		[WorkTypeName],
		[CountryID],
		[LocationID],
		[AreaID],
		[CountryName],
		[LocationName],
		[AreaName],
		[ProfessionID],
		[RoleID],
		[SiteProfessionName],
		[SiteRoleName],
		[BreadCrumbNavigation],
		[WorkTypeID],
		[JobFriendlyName],
		[SalaryDisplay],
		[JobItemTypeID],
		[JobLatitude],
		[JobLongitude],
		[AddressStatus],
		[HasAdvertiserLogo],	
		[CustomXML],	
		[Address],	
		[PublicTransport]
	FROM FinalRecords
	WHERE RowNumber BETWEEN (@PageIndexlocal * @PageSizelocal + 1) AND ((@PageIndexlocal * @PageSizelocal) + @PageSizelocal)
	ORDER BY RowNumber
END