USE [MiniJXT]
GO
/****** Object:  StoredProcedure [dbo].[ViewJobs_GetByID]    Script Date: 02/24/2017 12:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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

 INNER JOIN [dbo].[Location] Location (NOLOCK)
 ON [Location].LocationID = SiteLocation.LocationID
 
 INNER JOIN [dbo].[SiteCountries] SiteCountry (NOLOCK)
 ON SiteCountry.CountryID = Location.CountryID 
 AND SiteCountry.SiteID = @SiteID
          
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