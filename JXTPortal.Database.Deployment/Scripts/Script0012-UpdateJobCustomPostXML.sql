
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
-- 2017-02-21 - Updated proc to ensure the "unarchiving" of jobs doesn't create a new job if it currenly exists in the jobs table
                    
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
    AddressStatus INT,
	ExpiryDate DATE NULL
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
    UpdateJob,
	ExpiryDate)
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
     0,  -- By default the Job is Inserted	
	 Element.value('ExpiryDate[1]', 'DATE') AS ExpiryDate
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
   Jobs.SiteID = @SiteID
    -- AND Jobs.Expired = 0 AND Jobs.ExpiryDate >= GETDATE() -- 2017-02-21 Removed to ensure that jobs can be unexpired
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
   CASE WHEN (#FlatXML.ExpiryDate IS NOT NULL AND #FlatXML.ExpiryDate > '1900-01-01')
   THEN #FlatXML.ExpiryDate              
   ELSE CASE WHEN (#FlatXML.JobAdType = @JobTypeID_Premium) THEN DATEADD(DAY,@PremiumExpiryDays,GETDATE()) ELSE DATEADD(DAY,30,GETDATE()) END END,           
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
      CurrencyID = 1, EnteredByAdvertiserUserID = @AdvertiserUserId,
      Expired = CASE WHEN ISNULL(#FlatXML.ExpiryDate, CAST('2001-01-01' AS DATE)) > GETDATE() THEN 0 ELSE Expired END, 
	  ExpiryDate = CASE WHEN ISNULL(#FlatXML.ExpiryDate, CAST('2001-01-01' AS DATE)) = CAST('2001-01-01' AS DATE) THEN Jobs.ExpiryDate ELSE #FlatXML.ExpiryDate END
 FROM               
  #FlatXML INNER JOIN Jobs (NOLOCK) ON       
   Jobs.JobID = #FlatXML.JobID
   -- AND Jobs.Expired = 0 AND Jobs.ExpiryDate >= GETDATE()  -- 2017-02-21 Removed to ensure that jobs can be unexpired             
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

	SELECT * FROM Jobs
	Where JobID = JobID
                
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