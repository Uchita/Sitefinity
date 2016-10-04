  
CREATE PROCEDURE [dbo].[Sites_Copy]  
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
 BEGIN TRY  
  BEGIN TRANSACTION SITECOPYTRANSACTION  
    
   DECLARE @NewSiteID INT  
     
   INSERT INTO Sites(SiteName, SiteUrl, SiteDescription, LastModified, LastModifiedBy, Live)  
   VALUES (@SiteName, @SiteUrl, @SiteDescription, GETDATE(), @LastModifiedBy, 0)  
         
      SET @NewSiteID = SCOPE_IDENTITY()  
        
      IF (@CopyGlobalSettings = 1)  
      BEGIN  
    INSERT INTO GlobalSettings([SiteID],[DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]  
            ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]  
            ,[LastModifiedBy],[LastModified],[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]  
            ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton],[UseAdvertiserFilter],[MerchantID],[ShowTwitterButton]  
            ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol],[FTPFolderLocation],[MetaTags])  
    SELECT       @NewSiteID,[DefaultLanguageID] ,[DefaultDynamicPageID],[PublicJobsSearch],[PublicMembersSearch]  
            ,[PublicCompaniesSearch],[PublicSponsoredAdverts],[PrivateJobs],[PrivateMembers],[PrivateCompanies]  
            ,@LastModifiedBy AS LastModifiedBy, GETDATE() AS [LastModified] ,[PageTitlePrefix],[PageTitleSuffix],[DefaultTitle],[HomeTitle],[DefaultDescription]  
            ,[HomeDescription],[DefaultKeywords],[HomeKeywords],[ShowFaceBookButton], 0,[MerchantID],[ShowTwitterButton]  
            ,[ShowJobAlertButton],[ShowLinkedInButton],[SiteFavIconID],[SiteDocType],[CurrencySymbol],@FtpFolderLocation,[MetaTags]  
    FROM [GlobalSettings] (NOLOCK)  
    WHERE SiteID = @SiteID  
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
           ,[MetaKeywords] ,[MetaDescription] ,[Sequence], [SiteProfessionFriendlyUrl])  
    SELECT @NewSiteID,[ProfessionID] ,[SiteProfessionName] ,[Valid] ,[MetaTitle]   
           ,[MetaKeywords] ,[MetaDescription] ,[Sequence], [SiteProfessionFriendlyUrl]  
    FROM [SiteProfession] (NOLOCK)  
    WHERE SiteID = @SiteID   
       
    INSERT INTO [SiteRoles]([SiteID],[RoleID] ,[SiteRoleName] ,[Valid] ,[MetaTitle] ,[MetaKeywords]   
          ,[MetaDescription] ,[Sequence], [SiteRoleFriendlyUrl])  
    SELECT  @NewSiteID,[RoleID] ,[SiteRoleName] ,[Valid] ,[MetaTitle] ,[MetaKeywords] ,  
       [MetaDescription] ,[Sequence], [SiteRoleFriendlyUrl]  
    FROM SiteRoles (NOLOCK)  
        WHERE SiteID = @SiteID  
  
     END  
       
     IF (@CopySalaryTypes = 1)  
     BEGIN  
    INSERT INTO SiteSalaryType(SiteID, SalaryTypeID, SalaryTypeName, Sequence, Valid)  
    SELECT @NewSiteID, SalaryTypeID, SalaryTypeName, Sequence, Valid  
    FROM SiteSalaryType (NOLOCK)  
    WHERE SiteID = @SiteID  
      
    INSERT INTO SiteSalary(SiteID, SalaryID, SalaryLowerBand, SalaryUpperBand, Sequence, SiteSalaryName, Valid)  
    SELECT @NewSiteID, SalaryID, SalaryLowerBand, SalaryUpperBand, Sequence, SiteSalaryName, Valid  
    FROM SiteSalary (NOLOCK)  
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
    WHERE SiteID = @SiteID   
     END  
       
       
     IF (@CopyWidgets = 1)  
     BEGIN  
    INSERT INTO [WidgetContainers]([SiteID], [LanguageID], [WidgetName], [WidgetDomain], [WidgetContainerClass]  
              ,[WidgetContainerHeaderClass], [WidgetItemClass], [WidgetJobLinkCSS], [WidgetItemLinkImageID]  
              ,[Valid], [ShowJobs], [ShowCompanies], [ShowSite],[ShowPeople]  
              ,[JobHtml], [CompanyHtml],[SiteHtml], [PeopleHtml],[Javascript],[SearchCSS]  
              ,[DefaultProfessionID],[DefaultCountryID],[DefaultLocationID],[Width],[Height],[OnAdvancedSearch])  
    SELECT @NewSiteID, [LanguageID], [WidgetName], [WidgetDomain], [WidgetContainerClass]  
              ,[WidgetContainerHeaderClass], [WidgetItemClass], [WidgetJobLinkCSS], [WidgetItemLinkImageID]  
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
            ,[EmailAddressBCC],[GlobalTemplate],[LastModifiedBy],[LastModified])  
    SELECT @NewSiteID,[EmailTemplateParentID]  
            ,[EmailCode],[EmailDescription],[EmailSubject]  
            ,[EmailBodyText],[EmailBodyHTML],[EmailFields]  
            ,[EmailAddressName],[EmailAddressFrom],[EmailAddressCC]  
            ,[EmailAddressBCC],[GlobalTemplate],[LastModifiedBy],[LastModified]  
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
       PageFriendlyName,LastModified,LastModifiedBy,SearchField,SourceID)  
    SELECT @NewSiteID,LanguageID,ParentDynamicPageID,PageName,  
       PageTitle,PageContent,wpt.DynamicPageWebPartTemplateID,HyperLink,  
       Valid,OpenInNewWindow,Sequence,FullScreen,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnTopNav END, CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnLeftNav END,  
       OnBottomNav,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnSiteMap END,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE Searchable END,MetaKeywords,MetaDescription,  
       PageFriendlyName,dp.LastModified,dp.LastModifiedBy,CASE WHEN PageName LIKE 'SystemPage%' THEN '' ELSE SearchField END,DynamicPageID  
    FROM DynamicPages dp INNER JOIN DynamicPageWebPartTemplates wpt   
    ON dp.DynamicPageWebPartTemplateID = wpt.SourceID AND wpt.SiteID = @NewSiteID  
    WHERE dp.SiteID = @SiteID AND dp.DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages))  
  
    INSERT INTO DynamicPageFiles (SiteID, PageName, FileID)  
    SELECT @NewSiteID, PageName, f.FileID   
    FROM DynamicPageFiles dpf INNER JOIN Files f   
    ON dpf.FileID = f.SourceID AND dpf.SiteID = @NewSiteID  
    WHERE dpf.SiteID = @SiteID AND dpf.FileID IN (SELECT id FROM ParseIntCSV(@SelectedFiles))  
      
   END  
  
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