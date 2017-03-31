UPDATE MemberFiles SET MemberFileURL = REPLACE(MemberFileURL, '..', '.') WHERE MemberFileURL LIKE '%..%'
GO

ALTER PROCEDURE [dbo].[ViewJobs_GetByID]    
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
  
ALTER PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterRedefine]                                      
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
-- Country                                 
 SELECT  7 as RefineTypeID                                        
  ,'By Country' as RefineTypeName                                        
  ,CountryID as RefineID                                        
  ,[SiteCountryName] as RefineLabel                                
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)                                         
 FROM @tmpJobIdSearch tmpJobIdSearch                           
  INNER JOIN JobArea WITH (NOLOCK) ON JobArea.JobID = tmpJobIdSearch.JobID                                           
  INNER JOIN ViewSiteAreaLocationCountry WITH (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID                                     
    AND ViewSiteAreaLocationCountry.Siteid = @SiteId                                
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteId          
AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID               
 GROUP BY CountryID, SiteCountryName

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