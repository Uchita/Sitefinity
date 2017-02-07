IF EXISTS(SELECT 1 FROM sys.views 
     WHERE Name = 'ViewJobSearch')
BEGIN
    DROP VIEW ViewJobSearch
END
GO

CREATE VIEW [dbo].[ViewJobSearch]                    
AS          
SELECT DISTINCT               
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
    ViewSiteAreaLocationCountry.Currency as CurrencySymbol, --[Currencies].[CurrencySymbol],          
    Jobs.SalaryUpperBand,               
    Jobs.SalaryLowerBand,               
 Jobs.SalaryTypeID,          
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
    '<a href="/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs">' + SiteProfession.SiteProfessionName + '</a>' +             
  ' > ' + '<a href="/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(SiteRoles.SiteRoleFriendlyUrl,'') + '-jobs">' + SiteRoles.SiteRoleName + '</a>'  COLLATE DATABASE_DEFAULT             
  AS BreadCrumbNavigation ,               
    Jobs.WorkTypeID,               
    '/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName',            
 [Currencies].CurrencySymbol  + [SiteSalaryType].SalaryTypeName AS SalaryDisplay,      
 Jobs.JobItemTypeID,      
 Jobs.JobLatitude,      
 Jobs.JobLongitude,      
 Jobs.AddressStatus,  
     
 CASE WHEN Advertisers.AdvertiserLogo IS NULL THEN 0 ELSE 1  END as HasAdvertiserLogo,  
 JobCustomXML.CustomXML,
 Jobs.[Address],
 Jobs.[PublicTransport]              
FROM Jobs (NOLOCK)               
 INNER JOIN Advertisers (NOLOCK) Advertisers                    
  ON Jobs.AdvertiserID = Advertisers.AdvertiserID                    
  LEFT JOIN SalaryType (NOLOCK)                    
  ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                    
 INNER JOIN SiteSalaryType (NOLOCK)                    
  ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID             
  AND SiteSalaryType.SiteID = Jobs.SiteID                 
          
 INNER JOIN [dbo].[SiteCurrencies] SiteCurrencies (NOLOCK)          
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID          
 AND [SiteCurrencies].SiteID = Jobs.SiteID          
          
 INNER JOIN [dbo].[Currencies] Currencies (NOLOCK)          
 ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID          
                      
 INNER JOIN WorkType (NOLOCK)                    
  ON WorkType.WorkTypeID = Jobs.WorkTypeID                    
 LEFT JOIN SiteWorkType (NOLOCK)                    
  ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID               
    AND SiteWorkType.SiteID = Jobs.SiteID                
              
 INNER JOIN JobArea (NOLOCK)                
  ON JobArea.JobID = Jobs.JobID                
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)                
  ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID           
    AND ViewSiteAreaLocationCountry.Siteid = Jobs.SiteID          
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = Jobs.SiteID               
        
 -- Profession Role                
 INNER JOIN JobRoles (NOLOCK)               
  ON JobRoles.JobID = Jobs.JobId              
 INNER JOIN SiteRoles (NOLOCK)               
  ON SiteRoles.RoleID = JobRoles.RoleID            
 AND SiteRoles.SiteID = Jobs.SiteID                
 INNER JOIN Roles (NOLOCK)               
  ON Roles.RoleID = JobRoles.RoleID         INNER JOIN Profession (NOLOCK)               
  ON Profession.ProfessionID = Roles.ProfessionID              
 INNER JOIN SiteProfession (NOLOCK)               
  ON SiteProfession.ProfessionID = Profession.ProfessionID             
 AND SiteProfession.SiteID = Jobs.SiteID              
 LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID            
--WHERE  VALID Fields          
GO



IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_Get_List]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_Get_List]
END
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_Get_List]

AS


                    
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
                        [SalaryTypeID],
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
                    FROM
                        [dbo].[ViewJobSearch]
                        
                    SELECT @@ROWCOUNT
GO


IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_GetPremiumSearchFilter]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_GetPremiumSearchFilter]
END
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_GetPremiumSearchFilter]                             
 @SiteId INT,                                         
 @ProfessionID INT = NULL,                                          
 @RoleID VARCHAR(255) = NULL,                                        
 --@LocationID INT = NULL,                                         
 --@AreaID VARCHAR(255)= NULL,    
 @OrderBy VARCHAR(200) = NULL,                
 @PageSize INT  
AS                                         
     
-- Get the valid JOB Types of the Site  
  
-- Global settings - Get if Premium jobs needs to be displayed.  
--Declare @DisplayPremiumJobsOnResults BIT  
--SELECT @DisplayPremiumJobsOnResults = DisplayPremiumJobsOnResults FROM GlobalSettings (NOLOCK) where SiteID = @SiteId  
  
-- Get the JOB Types Premium jobs is enabled.  
Declare @DisplayPremiumJobs BIT = 0  
SELECT @DisplayPremiumJobs = 1  
FROM JobItemsType NOLOCK where SiteID = @SiteId AND Valid = 1 AND TotalNumberOfJobs = 1 AND JobItemTypeParentID = 3  
  
                         
 SELECT                                      
    job.JobId,                                      
    job.SiteID,                                      
    job.JobName,                                      
    job.Description,                          
    job.FullDescription,                                                 
    job.DatePosted,                                      
    job.Visible,                                      
    job.Expired,                                      
    job.ShowSalaryDetails,                             
 job.ShowSalaryRange,                                      
    job.SalaryText,                                      
    job.AdvertiserID,                                      
    job.ApplicationMethod,                                      
    job.ApplicationURL,                                      
    job.AdvertiserJobTemplateLogoID,                                      
    job.CompanyName,                                      
    job.ShowLocationDetails,                                      
    job.BulletPoint1,                                      
    job.BulletPoint2,                                      
    job.BulletPoint3,                                      
    job.HotJob,                         
 job.ApplicationEmailAddress,                        
 job.ExpiryDate,                        
 job.ContactDetails,                                     
    job.RefNo,                                      
    job.AdvertiserName,                                      
    job.CurrencySymbol,                                      
    job.SalaryUpperBand,                                      
    job.SalaryLowerBand,                              
 job.SalaryTypeId,                                     
    job.SalaryTypeName,                                      
    job.WorkTypeName,     
    job.CountryID,                                   
    job.LocationID,                                       
    job.AreaID,     
    job.CountryName,                                   
    job.LocationName,                                      
    job.AreaName,                                      
    job.ProfessionID,                                      
    job.RoleID,                                      
    job.SiteProfessionName,                                      
    job.SiteRoleName,                                     
    job.BreadCrumbNavigation,                                       
    job.WorkTypeID,                              
    job.JobFriendlyName,                             
    job.SalaryDisplay,  
    job.JobItemTypeID,  
  job.JobLatitude,  
  job.JobLongitude,  
  job.AddressStatus,  
  job.HasAdvertiserLogo,
  job.CustomXML,
  job.Address,
  job.PublicTransport                               
FROM                                           
(                
                
                                       
  SELECT             
 Jobs.JobId,                                      
 Jobs.SiteID,                                      
 Jobs.JobName,        
 Jobs.Description,                                   
 '' as FullDescription,  -- Don't need Full description  
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
 Currencies.CurrencySymbol,                                      
 Jobs.SalaryUpperBand,                                      
 Jobs.SalaryLowerBand,                                 
 Jobs.SalaryTypeId,   
 Jobs.JobItemTypeID,                                 
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
 CAST([Currencies].CurrencySymbol AS NVARCHAR(6)) + [SiteSalaryType].SalaryTypeName AS SalaryDisplay,  
 Jobs.JobLatitude,  
 Jobs.JobLongitude,  
 Jobs.AddressStatus,                             
 CASE WHEN Advertisers.AdvertiserLogo IS NULL THEN 0 ELSE 1  END as HasAdvertiserLogo,
 JobCustomXML.CustomXML,
 Jobs.Address,
 Jobs.PublicTransport,
 ROW_NUMBER() OVER (ORDER BY   
 CASE WHEN ISNULL(@OrderBy,'') = '' THEN Jobs.DatePosted  END DESC,    
 CASE WHEN @OrderBy ='Random' THEN NEWID() END   
 ) as RowNumber     
 FROM                                 
 Jobs (NOLOCK)                                  
 INNER JOIN Advertisers (NOLOCK) ON Advertisers.SiteID = @SiteId -- Display Premium jobs only from the Site    
       AND Jobs.AdvertiserID = Advertisers.AdvertiserID                                           
 LEFT JOIN SalaryType (NOLOCK)                                            
 ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                           
 INNER JOIN SiteSalaryType (NOLOCK)                                            
 ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID                                    
 AND SiteSalaryType.SiteID = @SiteID                               
                               
 INNER JOIN [SiteCurrencies] (NOLOCK)  
 ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID                             
 AND [SiteCurrencies].SiteID = Jobs.SiteID                             
        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                      
 INNER JOIN Currencies (NOLOCK)  
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
 ON SiteRoles.RoleID = JobRoles.RoleID AND SiteRoles.SiteID = @SiteID                                       
 INNER JOIN Roles (NOLOCK)                                       
 ON Roles.RoleID = JobRoles.RoleID                                     
 INNER JOIN Profession (NOLOCK)                                       
 ON Profession.ProfessionID = Roles.ProfessionID                                     
 INNER JOIN SiteProfession (NOLOCK)                                       
 ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteID          
 LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID    
   
 /*INNER JOIN JobItemsType (NOLOCK)  -- Only show premium jobs if its enabled on the site  
 ON JobItemsType.JobItemTypeParentID = Jobs.JobItemTypeID AND  
  JobItemsType.SiteID = @SiteID AND JobItemsType.GlobalTemplate = 0 AND JobItemsType.Valid = 1 AND JobItemsType.JobItemTypeParentID = 3*/   
                                       
 WHERE                                        
 Jobs.Expired = 0 AND    
 Jobs.ExpiryDate >= GETDATE() AND                                  
 ((ISNULL(@ProfessionID, 0) = 0) OR (Roles.ProfessionID = @ProfessionID)) AND          
 Jobs.DatePosted <= CAST(GETDATE()+1 AS DATE) AND   
 --((ISNULL(@RoleID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@RoleID) where id = Roles.RoleID))) AND   
 ((@DisplayPremiumJobs = 1 AND Jobs.JobItemTypeID = 3 AND Jobs.SiteID = @SiteId)) -- TODO REMOVE Jobs.JobItemTypeID NULL    
   
)                                       
Job                                       
WHERE                     
 Job.RowNumber BETWEEN 1 AND @PageSize  
ORDER BY Job.RowNumber
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_Get]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_Get]
END
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_Get]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[ViewJobSearch]'
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

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_GetBySearchFilterRedefine]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterRedefine]
END
GO

CREATE PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterRedefine]                                    
 @Keyword NVARCHAR(2500),                                          
 @SiteId INT,                                          
 @AdvertiserId INT = NULL,                                          
 @CurrencyId INT = NULL,                            
 @SalaryTypeID INT = NULL,                                 
 @SalaryLowerBand NUMERIC(15,2) = NULL,                            
 @SalaryUpperBand NUMERIC(15,2) = NULL,                                     
 @WorkTypeID INT = NULL,                                          
 @ProfessionID INT = NULL,                                          
 @RoleID VARCHAR(255) = NULL,                                          
 @CountryID INT = NULL,  
 @LocationID INT = NULL,                                          
 @AreaID VARCHAR(255)= NULL,                                      
 @DateFrom DATETIME= NULL,      
 @JobTypeIDs VARCHAR(255) = NULL                  
AS                                      

/*  

 -- 20th April
 -- Add countryid as parameter  
*/                           
                           
 --SQL Server 2008 FTI Fix                          
 IF ISNULL(@Keyword,'') = ''                           
 SET @Keyword = '""'                          
                           
DECLARE @UseCustomProfessionRole BIT = 0      
Declare @DisplayPremiumJobsOnResults BIT      
      
-- Global settings - to use Custom Profession Roles, Get if Premium jobs needs to be displayed.      
SELECT       
 @UseCustomProfessionRole = UseCustomProfessionRole, @DisplayPremiumJobsOnResults = DisplayPremiumJobsOnResults       
FROM GlobalSettings WHERE SiteID = @SiteId      
      
-- Get the valid JOB Types of the Site excluding Premium jobs      
SELECT @JobTypeIDs = COALESCE(@JobTypeIDs + ', ', '') + CAST(JobItemTypeParentID as Varchar)      
FROM JobItemsType NOLOCK where SiteID = @SiteId AND Valid = 1 AND TotalNumberOfJobs = 1 AND JobItemTypeParentID <>3      
      
-- To display Premium Jobs On Results      
if (@DisplayPremiumJobsOnResults = 1)      
 SET @JobTypeIDs = @JobTypeIDs + ', 3'      
      
                         
DECLARE @tmpJobIdSearch TABLE (JobID INT PRIMARY KEY, WorkTypeID INT, AdvertiserID INT)                                      
INSERT INTO @tmpJobIdSearch(JobID, WorkTypeID, AdvertiserID)                                      
 SELECT Jobs.[JobId], Jobs.[WorktypeID], Jobs.[AdvertiserID]                                           
   FROM                              
  [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter                              
  INNER JOIN Jobs (NOLOCK)                              
  ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                                   
  INNER JOIN Advertisers (NOLOCK) Advertisers                                         
   ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                        
                                        
  LEFT JOIN SalaryType (NOLOCK)                                        
   ON Jobs.SalaryTypeID = SalaryType.SalaryTypeID                                
  INNER JOIN SiteCurrencies (NOLOCK)                            
   ON SiteCurrencies.CurrencyID = Jobs.CurrencyID                          
              AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                      
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
 ((@CurrencyID is NULL) OR (Jobs.CurrencyID = @CurrencyID)) AND                                
((@SalaryLowerBand is NULL) OR (Jobs.SalaryLowerBand >= @SalaryLowerBand)) AND                               
((@SalaryUpperBand is NULL) OR (Jobs.SalaryUpperBand <= @SalaryUpperBand)) AND                                    
((ISNULL(@SalaryTypeID, 0) = 0) OR Jobs.SalaryTypeID = @SalaryTypeID) AND                             
 ((@WorkTypeID is NULL) OR (Jobs.WorkTypeID = @WorkTypeID)) AND                           
 ((@ProfessionID is NULL) OR (Roles.ProfessionID = @ProfessionID)) AND                                    
 ((ISNULL(@RoleID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@RoleID) where id = Roles.RoleID))) AND                                  
 ((@CountryID is NULL) OR (ViewSiteAreaLocationCountry.CountryID = @CountryID))  AND  
 ((@LocationID is NULL) OR (ViewSiteAreaLocationCountry.LocationID = @LocationID))  AND                                   
 ((ISNULL(@AreaID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@AreaID) where id = ViewSiteAreaLocationCountry.AreaID)))        
 AND (--(ISNULL(@JobTypeIDs, '') = '') OR       
  (Jobs.JobItemTypeID IN (Select id from ParseIntCSV(@JobTypeIDs)))       
  OR (Jobs.JobItemTypeID IS NULL)  -- TODO REMOVE Jobs.JobItemTypeID NULL       
  OR (@DisplayPremiumJobsOnResults = 1 AND Jobs.JobItemTypeID = 3 AND Jobs.SiteID = @SiteId)) -- Show Premium jobs of the existing site only                        
 AND ((@Keyword = '""') OR CONTAINS(Jobs.[SearchField], @Keyword))                  
 AND Jobs.DatePosted <= CAST(GETDATE()+1 AS DATE)     
 AND ((@DateFrom IS NULL) OR Jobs.DatePosted >= @DateFrom)                   -- FOR JOB ALERT Don't REMOVE            
 -- AND ((@UseCustomProfessionRole = 0) OR (@UseCustomProfessionRole = 1 AND Profession.ReferredSiteID = @SiteID))                            
  GROUP BY Jobs.[JobId], Jobs.[WorktypeID], Jobs.[AdvertiserID]                          
  OPTION (RECOMPILE)                          
                           
                                
-- Profession                                      
                                        
 SELECT 0 as RefineTypeID                                      
  ,'By Classification' as RefineTypeName                                      
  ,SiteProfession.ProfessionID as RefineID                                      
  ,[SiteProfessionName] as RefineLabel                                      
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                       
 FROM @tmpJobIdSearch tmpJobIdSearch                            
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = tmpJobIdSearch.JobId                                       
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                                
  INNER JOIN SiteProfession WITH (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID                                
 AND SiteProfession.SiteId = @SiteId                         
 WHERE (@ProfessionID IS NULL OR Roles.ProfessionID = @ProfessionID)             
 GROUP BY SiteProfession.ProfessionID, SiteProfessionName                                         
                                        
UNION                                      
                                        
-- Role                                      
 SELECT  1 as RefineTypeID                                      
  ,'By Sub Classification' as RefineTypeName                                       
  ,SiteRoles.RoleID as RefineID                                      
  ,[SiteRoleName] as RefineLabel                                      
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                       
 FROM @tmpJobIdSearch tmpJobIdSearch                                        
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = tmpJobIdSearch.JobId                                      
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                                      
  INNER JOIN SiteRoles WITH (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID                                    
 AND SiteRoles.SiteId = @SiteId                                 
 WHERE Roles.ProfessionID = @ProfessionID OR @ProfessionID IS NULL                            
 GROUP BY SiteRoles.RoleID, SiteRoleName                                        
                                        
UNION                                  
-- Location                               
 SELECT  2 as RefineTypeID                                      
  ,'By Location' as RefineTypeName                                      
  ,LocationID as RefineID                                      
  ,[SiteLocationName] as RefineLabel                              
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                       
 FROM @tmpJobIdSearch tmpJobIdSearch                         
  INNER JOIN JobArea WITH (NOLOCK) ON JobArea.JobID = tmpJobIdSearch.JobID                                         
  INNER JOIN ViewSiteAreaLocationCountry WITH (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                   
    AND ViewSiteAreaLocationCountry.Siteid = @SiteId                              
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteId        
AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID             
 GROUP BY LocationID, SiteLocationName                                              
UNION                                      
-- Area                                      
 SELECT  3 as RefineTypeID                                      
  ,'By Area' as RefineTypeName                                      
  ,JobArea.AreaID as RefineID                                      
  ,[SiteAreaName] as RefineLabel                                      
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                       
 FROM @tmpJobIdSearch tmpJobIdSearch                         
  INNER JOIN JobArea WITH (NOLOCK) ON JobArea.JobID = tmpJobIdSearch.JobId                                        
  INNER JOIN ViewSiteAreaLocationCountry WITH (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                      
 WHERE ViewSiteAreaLocationCountry.LocationID = @LocationID                                   
    AND ViewSiteAreaLocationCountry.Siteid = @SiteId                                
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteId         
AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID             
 GROUP BY JobArea.AreaID, SiteAreaName                                      
                                        
UNION                                      
-- Recruiter                                   
                                        
-- Work type                                      
                                  
 SELECT  4 as RefineTypeID                                      
  ,'By Work Type' as RefineTypeName                            
  ,SiteWorkType.WorkTypeID as RefineID                                      
 ,SiteWorkTypeName as RefineLabel                                      
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                        
 FROM @tmpJobIdSearch tmpJobIdSearch              
  INNER JOIN SiteWorkType WITH (NOLOCK) ON SiteWorkType.WorkTypeID = tmpJobIdSearch.WorkTypeID                                  
 AND SiteWorkType.SiteID = @SiteId                                       
 GROUP BY SiteWorkType.WorkTypeID, SiteWorkTypeName                                        
                                        
-- Sector                                      
UNION                                      
-- Company                                      
                                       
 SELECT  5 as RefineTypeID                           
  ,'By Company' as RefineTypeName                                      
  ,Advertisers.AdvertiserID as RefineID                                       
  ,Advertisers.CompanyName as RefineLabel                                      
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                       
 FROM @tmpJobIdSearch tmpJobIdSearch                         
  INNER JOIN Advertisers WITH (NOLOCK) ON Advertisers.AdvertiserID = tmpJobIdSearch.AdvertiserID                                        
 GROUP BY Advertisers.AdvertiserID, Advertisers.CompanyName
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_GetBySearchFilterGoogleMap]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterGoogleMap]
END
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
	-- WHEN Advertisers.AdvertiserLogo IS NOT NULL THEN 1
	ELSE 0  
 END as HasAdvertiserLogo,    
 JobCustomXML.CustomXML,  
 Jobs.Address,
 Jobs.PublicTransport                   
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

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[ViewJobSearch_GetBySearchFilter]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilter]
END
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
 INNER JOIN Jobs (NOLOCK) ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID                                                
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK) ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK) ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID AND SiteSalaryType.SiteID = @SiteID                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID AND [SiteCurrencies].SiteID = Jobs.SiteID        --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
 INNER JOIN WorkType (NOLOCK) ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK) ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID AND SiteWorkType.SiteID = @SiteID                                                 
  -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK) ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)  ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID AND ViewSiteAreaLocationCountry.Siteid = @SiteID AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK) ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID AND SiteRoles.SiteID = @SiteID                                                 
 INNER JOIN Roles (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK) ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteID                                                   
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
 Jobs.Address,
 JObs.PublicTransport        
 FROM @tmpJobIdSearch tmpJobIdSearch             
 INNER JOIN Jobs (NOLOCK) ON tmpJobIdSearch.JobID = Jobs.JobID                                           
 INNER JOIN Advertisers (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                                                     
 LEFT JOIN SalaryType (NOLOCK) ON SalaryType.SalaryTypeID = Jobs.SalaryTypeID                                                     
 INNER JOIN SiteSalaryType (NOLOCK) ON SiteSalaryType.SalaryTypeID = Jobs.SalaryTypeID AND SiteSalaryType.SiteID = @SiteID                                         
                                         
 INNER JOIN [dbo].[SiteCurrencies] (NOLOCK) SiteCurrencies ON [SiteCurrencies].CurrencyID = [Jobs].CurrencyID AND [SiteCurrencies].SiteID = Jobs.SiteID --AND SiteCurrencies.SiteID = @SiteID          --Added on 27th August 2013                                
 INNER JOIN [dbo].[Currencies] (NOLOCK) Currencies ON [Currencies].CurrencyID = [SiteCurrencies].CurrencyID                                       
 INNER JOIN WorkType (NOLOCK) ON WorkType.WorkTypeID = Jobs.WorkTypeID                                                 
 LEFT JOIN SiteWorkType (NOLOCK) ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID AND SiteWorkType.SiteID = @SiteID                                                 
                                          
 -- Country Location Area                                  
 INNER JOIN JobArea (NOLOCK) ON JobArea.JobID = Jobs.JobID                                                 
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID AND ViewSiteAreaLocationCountry.Siteid = @SiteID
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID                                               
                                              
 -- Profession Role                                                 
 INNER JOIN JobRoles (NOLOCK) ON JobRoles.JobID = Jobs.JobId                                               
 INNER JOIN SiteRoles (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID AND SiteRoles.SiteID = @SiteID AND SiteRoles.RoleID = tmpJobIdSearch.RoleId                                               
 INNER JOIN Roles (NOLOCK) ON Roles.RoleID = JobRoles.RoleID                                               
 INNER JOIN Profession (NOLOCK) ON Profession.ProfessionID = Roles.ProfessionID                                               
 INNER JOIN SiteProfession (NOLOCK) ON SiteProfession.ProfessionID = Profession.ProfessionID AND SiteProfession.SiteID = @SiteID                
 LEFT JOIN JobCustomXML WITH (NOLOCK) ON JobCustomXML.JobID = Jobs.JobID ORDER BY RowNumber
GO
