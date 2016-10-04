CREATE PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilterRedefine]          
 @Keyword NVARCHAR(510),              
 @SiteId INT,              
 @AdvertiserId INT = NULL,              
 @SalaryId INT = NULL,              
 @WorkTypeID INT = NULL,              
 @ProfessionID INT = NULL,              
 @RoleID VARCHAR(255) = NULL,             
 @CountryID INT = NULL,           
 @LocationID INT = NULL,              
 @AreaID VARCHAR(255)= NULL          
AS          
           
DECLARE @tmpJobIdSearch TABLE (JobID INT)          
INSERT INTO @tmpJobIdSearch(JobID)          
 SELECT distinct Jobs.[JobId]              
   FROM  
  [dbo].[udfSite_GetAdvertisers](@SiteID) AdvertiserFilter  
  INNER JOIN Jobs (NOLOCK)  
  ON Jobs.AdvertiserID = AdvertiserFilter.AdvertiserID       
  INNER JOIN Advertisers (NOLOCK) Advertisers            
   ON Jobs.AdvertiserID = Advertisers.AdvertiserID            
  INNER JOIN Salary (NOLOCK)            
   ON Jobs.SalaryID = Salary.SalaryID            
  LEFT JOIN SiteSalary (NOLOCK)            
   ON SiteSalary.SalaryID = Jobs.SalaryID AND SiteSalary.SiteID = @SiteID           
  LEFT JOIN SalaryType (NOLOCK)            
   ON Salary.SalaryTypeID = SalaryType.SalaryTypeID            
  INNER JOIN SiteSalaryType (NOLOCK)            
   ON SiteSalaryType.SalaryTypeID = Salary.SalaryTypeID     
   AND SiteSalaryType.SiteID = @SiteID                
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
  AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteID  
  AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteID      
       
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
 ((@CountryID is NULL) OR (ViewSiteAreaLocationCountry.CountryID = @CountryID)) AND        
 ((@AdvertiserId is NULL) OR (Jobs.AdvertiserID = @AdvertiserId)) AND        
 ((@SalaryId is NULL) OR (Jobs.SalaryId = @SalaryId)) AND        
 ((@WorkTypeID is NULL) OR (Jobs.WorkTypeID = @WorkTypeID)) AND        
 ((@ProfessionID is NULL) OR (Roles.ProfessionID = @ProfessionID)) AND        
 ((ISNULL(@RoleID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@RoleID) where id = Roles.RoleID))) AND      
 ((@LocationID is NULL) OR (ViewSiteAreaLocationCountry.LocationID = @LocationID))  AND       
 ((ISNULL(@AreaID,'') = '') OR (EXISTS (Select id from ParseIntCSV(@AreaID) where id = ViewSiteAreaLocationCountry.AreaID)))      
 AND ((ISNULL(@Keyword,'') = '') OR CONTAINS(Jobs.[SearchField], @Keyword))     
  
-- Profession          
          
 SELECT 0 as RefineTypeID          
  ,'By Classification' as RefineTypeName          
  ,SiteProfession.ProfessionID as RefineID          
  ,[SiteProfessionName] as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId          
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = Jobs.JobId          
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID          
  INNER JOIN SiteProfession WITH (NOLOCK) ON SiteProfession.ProfessionID = Roles.ProfessionID    
 AND SiteProfession.SiteId = @SiteId  
 GROUP BY SiteProfession.ProfessionID, SiteProfessionName            
          
UNION          
          
-- Role          
 SELECT  1 as RefineTypeID          
  ,'By Sub Classification' as RefineTypeName          
  ,SiteRoles.RoleID as RefineID          
  ,[SiteRoleName] as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId              
  INNER JOIN JobRoles WITH (NOLOCK) ON JobRoles.JobID = Jobs.JobId          
  INNER JOIN Roles WITH (NOLOCK) ON Roles.RoleID = JobRoles.RoleID          
  INNER JOIN SiteRoles WITH (NOLOCK) ON SiteRoles.RoleID = JobRoles.RoleID       
 AND SiteRoles.SiteId = @SiteId     
 WHERE Roles.ProfessionID = @ProfessionID          
 GROUP BY SiteRoles.RoleID, SiteRoleName            
          
UNION          
-- Location          
 SELECT  2 as RefineTypeID          
  ,'By Location' as RefineTypeName          
  ,LocationID as RefineID          
  ,[SiteLocationName] as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId          
  INNER JOIN JobArea WITH (NOLOCK) ON JobArea.JobID = Jobs.JobID            
  INNER JOIN ViewSiteAreaLocationCountry WITH (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID       
    AND ViewSiteAreaLocationCountry.Siteid = @SiteId  
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteId  
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteId      
 GROUP BY LocationID, SiteLocationName                  
UNION          
-- Area          
 SELECT  3 as RefineTypeID          
  ,'By Area' as RefineTypeName          
  ,JobArea.AreaID as RefineID          
  ,[SiteAreaName] as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId          
  INNER JOIN JobArea WITH (NOLOCK) ON JobArea.JobID = Jobs.JobID            
  INNER JOIN ViewSiteAreaLocationCountry WITH (NOLOCK) ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID           
 WHERE ViewSiteAreaLocationCountry.LocationID = @LocationID       
    AND ViewSiteAreaLocationCountry.Siteid = @SiteId    
 AND ViewSiteAreaLocationCountry.SiteCountrySiteId = @SiteId  
 AND ViewSiteAreaLocationCountry.SiteLocationSiteId = @SiteId     
 GROUP BY JobArea.AreaID, SiteAreaName          
          
UNION          
-- Recruiter          
          
-- Work type          
          
 SELECT  4 as RefineTypeID          
  ,'By Work Type' as RefineTypeName          
  ,SiteWorkType.WorkTypeID as RefineID          
  ,SiteWorkTypeName as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId          
  INNER JOIN SiteWorkType WITH (NOLOCK) ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID      
 AND SiteWorkType.SiteID = @SiteId           
 GROUP BY SiteWorkType.WorkTypeID, SiteWorkTypeName            
          
-- Sector          
UNION          
-- Salary              
 SELECT  5 as RefineTypeID          
  ,'By Salary' as RefineTypeName          
  ,Jobs.SalaryID as RefineID          
  ,[SiteSalaryName] as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId          
  INNER JOIN SiteSalary WITH (NOLOCK) on SiteSalary.SalaryID = Jobs.SalaryID      
 AND SiteSalary.SiteID = @SiteId                     
 GROUP BY Jobs.SalaryID, SiteSalaryName                
          
UNION          
-- Company          
          
 SELECT  6 as RefineTypeID          
  ,'By Company' as RefineTypeName          
  ,Advertisers.AdvertiserID as RefineID          
  ,Advertisers.CompanyName as RefineLabel          
  ,COUNT(1) AS RefineCount --Count(distinct Products.productID)           
 FROM [dbo].[Jobs] (NOLOCK)          
  INNER JOIN @tmpJobIdSearch tmpJobIdSearch on Jobs.JobID = tmpJobIdSearch.JobId            
  INNER JOIN Advertisers WITH (NOLOCK) ON Jobs.AdvertiserID = Advertisers.AdvertiserID                
 GROUP BY Advertisers.AdvertiserID, Advertisers.CompanyName            