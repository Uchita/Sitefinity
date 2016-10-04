CREATE VIEW [dbo].[ViewJobSearch]        
AS         
SELECT DISTINCT   
 Jobs.JobId,   
    Jobs.SiteID,   
    Jobs.JobName,   
    Jobs.Description,   
    Jobs.DatePosted,   
    Jobs.Visible,   
    Jobs.Expired,   
    Jobs.ShowSalaryDetails,   
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
    Jobs.RefNo,   
    Advertisers.CompanyName AS AdvertiserName,   
    Isnull(SiteSalary.SiteSalaryName, Salary.SalaryName) AS SalaryName,   
    SiteSalary.SalaryUpperBand,   
    SiteSalary.SalaryLowerBand,   
    Isnull(SiteSalaryType.SalaryTypeName, SalaryType.SalaryTypeName) AS SalaryTypeName,   
    Isnull(SiteWorkType.SiteWorkTypeName, WorkType.WorkTypeName) AS WorkTypeName,   
    ViewSiteAreaLocationCountry.CountryID,  
    ViewSiteAreaLocationCountry.LocationID AS LocationID,   
    ViewSiteAreaLocationCountry.AreaID AS AreaID,   
    ViewSiteAreaLocationCountry.SiteLocationName AS LocationName,   
    ViewSiteAreaLocationCountry.SiteAreaName AS AreaName,   
	Roles.ProfessionID,   
    Roles.RoleID,   
    SiteProfession.SiteProfessionName,   
    SiteRoles.SiteRoleName,  
    '<a href="/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs">' + SiteProfession.SiteProfessionName + '</a>' + 
		' > ' + '<a href="/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(SiteRoles.SiteRoleFriendlyUrl,'') + '-jobs">' + SiteRoles.SiteRoleName + '</a>'  COLLATE DATABASE_DEFAULT 
		AS BreadCrumbNavigation ,   
    Jobs.SalaryID,   
    Jobs.WorkTypeID,   
    '/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'
FROM Jobs (NOLOCK)   
 INNER JOIN Advertisers (NOLOCK) Advertisers        
  ON Jobs.AdvertiserID = Advertisers.AdvertiserID        
 INNER JOIN Salary (NOLOCK)        
  ON Jobs.SalaryID = Salary.SalaryID        
 LEFT JOIN SiteSalary (NOLOCK)        
  ON SiteSalary.SalaryID = Jobs.SalaryID AND SiteSalary.SiteID = Jobs.SiteID        
 LEFT JOIN SalaryType (NOLOCK)        
  ON Salary.SalaryTypeID = SalaryType.SalaryTypeID        
 INNER JOIN SiteSalaryType (NOLOCK)        
  ON SiteSalaryType.SalaryTypeID = Salary.SalaryTypeID        
 INNER JOIN WorkType (NOLOCK)        
  ON WorkType.WorkTypeID = Jobs.WorkTypeID        
 LEFT JOIN SiteWorkType (NOLOCK)        
  ON SiteWorkType.WorkTypeID = Jobs.WorkTypeID     
  
 INNER JOIN JobArea (NOLOCK)    
  ON JobArea.JobID = Jobs.JobID    
 INNER JOIN ViewSiteAreaLocationCountry (NOLOCK)    
  ON JobArea.AreaID = ViewSiteAreaLocationCountry.AreaID    
  
 -- Profession Role    
 INNER JOIN JobRoles (NOLOCK)   
  ON JobRoles.JobID = Jobs.JobId  
 INNER JOIN SiteRoles (NOLOCK)   
  ON SiteRoles.RoleID = JobRoles.RoleID  
 INNER JOIN Roles (NOLOCK)   
  ON Roles.RoleID = JobRoles.RoleID  
 INNER JOIN Profession (NOLOCK)   
  ON Profession.ProfessionID = Roles.ProfessionID  
 INNER JOIN SiteProfession (NOLOCK)   
  ON SiteProfession.ProfessionID = Profession.ProfessionID  
--WHERE  VALID Fields  