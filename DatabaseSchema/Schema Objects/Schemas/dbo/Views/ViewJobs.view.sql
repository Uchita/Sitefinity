  
CREATE VIEW [dbo].[ViewJobs]          
AS          
SELECT [Jobs].[JobID]          
 ,[Jobs].[SiteID]          
 ,[Jobs].[WorkTypeID]          
 ,[Jobs].[SalaryID]          
 ,[Jobs].[JobName]          
 ,[Jobs].[Description]          
 ,[Jobs].[FullDescription]          
 ,[Jobs].[WebServiceProcessed]          
 ,[Jobs].[ApplicationEmailAddress]          
 ,[Jobs].[RefNo]          
 ,[Jobs].[Visible]          
 ,[Jobs].[DatePosted]          
 ,[Jobs].[ExpiryDate]          
 ,[Jobs].[Expired]          
 ,[Jobs].[JobItemPrice]          
 ,[Jobs].[Billed]          
 ,[Jobs].[LastModified]          
 ,[Jobs].[ShowSalaryDetails]          
 ,[Jobs].[SalaryText]          
 ,[Jobs].[AdvertiserID]          
 ,[Jobs].[LastModifiedByAdvertiserUserId]          
 ,[Jobs].[LastModifiedByAdminUserId]          
 ,[Jobs].[JobItemTypeID]          
 ,[Jobs].[ApplicationMethod]          
 ,[Jobs].[ApplicationURL]          
 ,[Jobs].[UploadMethod]          
 ,[Jobs].[Tags]          
 ,[Jobs].[JobTemplateID]          
 ,[Jobs].[SearchField]          
 ,[Jobs].[AdvertiserJobTemplateLogoID]          
 ,[Jobs].[CompanyName]          
 ,[Jobs].[HashValue]          
 ,[Jobs].[RequireLogonForExternalApplications]          
 ,[Jobs].[ShowLocationDetails]          
 ,[Jobs].[PublicTransport]          
 ,[Jobs].[Address]          
 ,[Jobs].[ContactDetails]          
 ,[Jobs].[JobContactPhone]          
 ,[Jobs].[JobContactName]          
 ,[Jobs].[QualificationsRecognised]          
 ,[Jobs].[ResidentOnly]          
 ,[Jobs].[DocumentLink]          
 ,[Jobs].[BulletPoint1]          
 ,[Jobs].[BulletPoint2]          
 ,[Jobs].[BulletPoint3]          
 ,[Jobs].[HotJob]          
 ,[Advertisers].[CompanyName] AS AdvertiserCompanyName          
 ,[Advertisers].[BusinessNumber]          
 ,[Advertisers].[StreetAddress1]          
 ,[Advertisers].[StreetAddress2]          
 ,[Advertisers].[WebAddress]          
 ,[Advertisers].[Profile]          
 ,[Advertisers].[RequireLogonForExternalApplication]          
 ,[Advertisers].[AdvertiserLogo]          
 ,[SiteWorkType].[SiteWorkTypeName]          
 ,[SiteSalary].[SiteSalaryName]          
 ,[SiteSalary].[SalaryUpperBand]          
 ,[SiteSalary].[SalaryLowerBand]          
 ,[JobTemplates].[JobTemplateHTML]          
 ,[SiteSalaryType].[SalaryTypeName]          
 ,[SiteArea].[SiteAreaName]          
 ,[SiteLocation].[SiteLocationName]          
 ,[SiteRoles].[SiteRoleName]          
 ,[SiteProfession].SiteProfessionName          
 ,'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'  
 ,[Roles].ProfessionID  
 ,[Roles].RoleID  
FROM [dbo].[Jobs] Jobs (NOLOCK)          
 INNER JOIN [dbo].[Advertisers] Advertisers (NOLOCK)          
 ON Jobs.AdvertiserID = Advertisers.AdvertiserID          
    
 INNER JOIN [dbo].[SiteWorkType] SiteWorkType (NOLOCK)          
 ON [Jobs].WorkTypeID = [SiteWorkType].WorkTypeID            
 AND SiteWorkType.SiteID = Jobs.SiteID          
    
 INNER JOIN [dbo].[SiteSalary] SiteSalary (NOLOCK)          
 ON [SiteSalary].[SalaryID] = [Jobs].[SalaryID]         
 AND [SiteSalary].SiteID = Jobs.SiteID         
 INNER JOIN [dbo].[Salary] Salary (NOLOCK)          
 ON [Salary].[SalaryID] = [Jobs].[SalaryID]          
 INNER JOIN [dbo].[SiteSalaryType] SiteSalaryType (NOLOCK)          
 ON [SiteSalaryType].SalaryTypeID = [Salary].[SalaryTypeID]         
 AND [SiteSalaryType].SiteID = Jobs.SiteID        
    
 INNER JOIN [dbo].[JobTemplates] JobTemplates (NOLOCK)          
 ON [JobTemplates].[JobTemplateID] = [Jobs].[JobTemplateID]          
    
 INNER JOIN [dbo].[JobArea] JobArea (NOLOCK)          
 ON [JobArea].[JobID] = [Jobs].[JobID]          
 INNER JOIN [dbo].[SiteArea] SiteArea (NOLOCK)          
 ON [SiteArea].AreaID = [JobArea].AreaID        
 AND SiteArea.Siteid = Jobs.SiteID          
 INNER JOIN [dbo].[Area] Area (NOLOCK)          
 ON [Area].AreaID = [SiteArea].[AreaID]          
 INNER JOIN [dbo].[SiteLocation] SiteLocation (NOLOCK)          
 ON [SiteLocation].LocationID = Area.LocationID        
 AND SiteLocation.Siteid = Jobs.SiteID      
    
 INNER JOIN [dbo].[JobRoles] JobRoles (NOLOCK)          
 ON [JobRoles].[JobID] = [Jobs].[JobID]          
 INNER JOIN [dbo].[SiteRoles] SiteRoles (NOLOCK)          
 ON [SiteRoles].[RoleID] = [JobRoles].[RoleID]       
 AND SiteRoles.SiteID = Jobs.SiteID            
 INNER JOIN [dbo].[Roles] Roles (NOLOCK)          
 ON [Roles].RoleID = [SiteRoles].RoleID          
 INNER JOIN [dbo].[SiteProfession] SiteProfession (NOLOCK)          
 ON [SiteProfession].ProfessionID = [Roles].ProfessionID        
 AND SiteProfession.SiteID = Jobs.SiteID 