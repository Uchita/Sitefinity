CREATE PROCEDURE [dbo].[ViewJobSearch_GetBySearchFilter]          
 @Keyword NVARCHAR(510),          
 @SiteId INT,          
 @AdvertiserId INT = NULL,          
 @SalaryId INT = NULL,          
 @WorkTypeID INT = NULL,          
 @ProfessionID INT = NULL,          
 @RoleID VARCHAR(255) = NULL,         
 @CountryID INT = NULL,       
 @LocationID INT = NULL,          
 @AreaID VARCHAR(255)= NULL,          
 @PageIndex INT,          
 @PageSize INT          
AS          
 SELECT       
	job.JobId,       
    job.SiteID,       
    job.JobName,       
    job.Description,       
    job.DatePosted,       
    job.Visible,       
    job.Expired,       
    job.ShowSalaryDetails,       
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
    job.RefNo,       
    job.AdvertiserName,       
    job.SalaryName,       
    job.SalaryUpperBand,       
    job.SalaryLowerBand,       
    job.SalaryTypeName,       
    job.WorkTypeName,       
    job.CountryID,      
    job.LocationID,       
    job.AreaID,       
    job.LocationName,       
    job.AreaName,       
	job.ProfessionID,       
    job.RoleID,       
    job.SiteProfessionName,       
    job.SiteRoleName,      
    job.BreadCrumbNavigation,       
    job.SalaryID,       
    job.WorkTypeID,       
    job.JobFriendlyName      
FROM            
(        
  SELECT        
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
	'/' + ISNULL(SiteProfession.SiteProfessionFriendlyUrl,'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName',      
	ROW_NUMBER() OVER (ORDER BY Jobs.DatePosted DESC) as RowNumber       
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
)        
Job        
WHERE        
	Job.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex * @PageSize) + @PageSize)        
ORDER BY Job.RowNumber   
  