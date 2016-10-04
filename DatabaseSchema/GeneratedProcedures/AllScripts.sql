CREATE PROCEDURE dbo.DeleteAdminRoles
(
  @AdminRoleID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [AdminRoles]
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetAdminRoles
(
  @AdminRoleID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [AdminRoleID],
   [RoleName]
 FROM [AdminRoles]
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveAdminRoles
(
  @AdminRoleID int,
  @RoleName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [AdminRoles]
   SET 
    [AdminRoleID] = @AdminRoleID,
    [RoleName] = @RoleName
   WHERE 
    [AdminRoleID] = @AdminRoleID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [AdminRoles]
(
    [AdminRoleID],
    [RoleName]
)
VALUES
(
    @AdminRoleID,
    @RoleName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteAdminUsers
(
  @AdminUserID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [AdminUsers]
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetAdminUsers
(
  @AdminUserID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [AdminUserID],
   [AdminAdminRoleID],
   [SiteID],
   [UserName],
   [UserPassword],
   [FirstName],
   [Surname],
   [Email]
 FROM [AdminUsers]
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveAdminUsers
(
  @AdminUserID int,
  @AdminAdminRoleID int,
  @SiteID int,
  @UserName varchar(255),
  @UserPassword varchar(255),
  @FirstName varchar(255),
  @Surname varchar(255),
  @Email varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [AdminUsers]
   SET 
    [AdminUserID] = @AdminUserID,
    [AdminAdminRoleID] = @AdminAdminRoleID,
    [SiteID] = @SiteID,
    [UserName] = @UserName,
    [UserPassword] = @UserPassword,
    [FirstName] = @FirstName,
    [Surname] = @Surname,
    [Email] = @Email
   WHERE 
    [AdminUserID] = @AdminUserID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [AdminUsers]
(
    [AdminUserID],
    [AdminAdminRoleID],
    [SiteID],
    [UserName],
    [UserPassword],
    [FirstName],
    [Surname],
    [Email]
)
VALUES
(
    @AdminUserID,
    @AdminAdminRoleID,
    @SiteID,
    @UserName,
    @UserPassword,
    @FirstName,
    @Surname,
    @Email
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteDynamicPages
(
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPages]
   WHERE 
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetDynamicPages
(
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageID],
   [SiteID],
   [ParentDynamicPageID],
   [PageName],
   [PageTitle],
   [PageContent],
   [HyperLink],
   [Valid],
   [OpenInNewWindow],
   [Sequence],
   [FullScreen],
   [OnTopNav],
   [OnLeftNav],
   [OnBottomNav],
   [OnSiteMap],
   [Searchable],
   [SearchField],
   [SearchFieldExtension],
   [MetaKeywords],
   [MetaDescription],
   [PageFriendlyName],
   [LastModified],
   [LastModifiedBy]
 FROM [DynamicPages]
   WHERE 
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveDynamicPages
(
  @DynamicPageID int,
  @SiteID int,
  @ParentDynamicPageID int,
  @PageName varchar(255),
  @PageTitle varchar(255),
  @PageContent ntext,
  @HyperLink varchar(255),
  @Valid bit,
  @OpenInNewWindow bit,
  @Sequence int,
  @FullScreen bit,
  @OnTopNav bit,
  @OnLeftNav bit,
  @OnBottomNav bit,
  @OnSiteMap bit,
  @Searchable bit,
  @SearchField image,
  @SearchFieldExtension varchar(8),
  @MetaKeywords varchar(255),
  @MetaDescription varchar(512),
  @PageFriendlyName varchar(255),
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPages]
   SET 
    [DynamicPageID] = @DynamicPageID,
    [SiteID] = @SiteID,
    [ParentDynamicPageID] = @ParentDynamicPageID,
    [PageName] = @PageName,
    [PageTitle] = @PageTitle,
    [PageContent] = @PageContent,
    [HyperLink] = @HyperLink,
    [Valid] = @Valid,
    [OpenInNewWindow] = @OpenInNewWindow,
    [Sequence] = @Sequence,
    [FullScreen] = @FullScreen,
    [OnTopNav] = @OnTopNav,
    [OnLeftNav] = @OnLeftNav,
    [OnBottomNav] = @OnBottomNav,
    [OnSiteMap] = @OnSiteMap,
    [Searchable] = @Searchable,
    [SearchField] = @SearchField,
    [SearchFieldExtension] = @SearchFieldExtension,
    [MetaKeywords] = @MetaKeywords,
    [MetaDescription] = @MetaDescription,
    [PageFriendlyName] = @PageFriendlyName,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [DynamicPageID] = @DynamicPageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPages]
(
    [DynamicPageID],
    [SiteID],
    [ParentDynamicPageID],
    [PageName],
    [PageTitle],
    [PageContent],
    [HyperLink],
    [Valid],
    [OpenInNewWindow],
    [Sequence],
    [FullScreen],
    [OnTopNav],
    [OnLeftNav],
    [OnBottomNav],
    [OnSiteMap],
    [Searchable],
    [SearchField],
    [SearchFieldExtension],
    [MetaKeywords],
    [MetaDescription],
    [PageFriendlyName],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @DynamicPageID,
    @SiteID,
    @ParentDynamicPageID,
    @PageName,
    @PageTitle,
    @PageContent,
    @HyperLink,
    @Valid,
    @OpenInNewWindow,
    @Sequence,
    @FullScreen,
    @OnTopNav,
    @OnLeftNav,
    @OnBottomNav,
    @OnSiteMap,
    @Searchable,
    @SearchField,
    @SearchFieldExtension,
    @MetaKeywords,
    @MetaDescription,
    @PageFriendlyName,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPageShell]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageTemplateID],
   [DynamicPageID]
 FROM [DynamicPageShell]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveDynamicPageShell
(
  @DynamicPageTemplateID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPageShell]
   SET 
    [DynamicPageTemplateID] = @DynamicPageTemplateID,
    [DynamicPageID] = @DynamicPageID
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPageShell]
(
    [DynamicPageTemplateID],
    [DynamicPageID]
)
VALUES
(
    @DynamicPageTemplateID,
    @DynamicPageID
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPagesLinkCategories]
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageParentID],
   [DynamicPageID]
 FROM [DynamicPagesLinkCategories]
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveDynamicPagesLinkCategories
(
  @DynamicPageParentID int,
  @DynamicPageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPagesLinkCategories]
   SET 
    [DynamicPageParentID] = @DynamicPageParentID,
    [DynamicPageID] = @DynamicPageID
   WHERE 
    [DynamicPageParentID] = @DynamicPageParentID
   AND  
    [DynamicPageID] = @DynamicPageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPagesLinkCategories]
(
    [DynamicPageParentID],
    [DynamicPageID]
)
VALUES
(
    @DynamicPageParentID,
    @DynamicPageID
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteDynamicPageTemplates
(
  @DynamicPageTemplateID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [DynamicPageTemplates]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetDynamicPageTemplates
(
  @DynamicPageTemplateID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [DynamicPageTemplateID],
   [DynamicPageTemplateName],
   [LastModified],
   [LastModifiedBy]
 FROM [DynamicPageTemplates]
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveDynamicPageTemplates
(
  @DynamicPageTemplateID int,
  @DynamicPageTemplateName nvarchar(255),
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [DynamicPageTemplates]
   SET 
    [DynamicPageTemplateID] = @DynamicPageTemplateID,
    [DynamicPageTemplateName] = @DynamicPageTemplateName,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [DynamicPageTemplateID] = @DynamicPageTemplateID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [DynamicPageTemplates]
(
    [DynamicPageTemplateID],
    [DynamicPageTemplateName],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @DynamicPageTemplateID,
    @DynamicPageTemplateName,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteFiles
(
  @FileID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [Files]
   WHERE 
    [FileID] = @FileID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetFiles
(
  @FileID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FileID],
   [SiteID],
   [FolderID],
   [FileName],
   [FileSystemName],
   [FileTypeID],
   [LastModified],
   [LastModifiedBy]
 FROM [Files]
   WHERE 
    [FileID] = @FileID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveFiles
(
  @FileID int,
  @SiteID int,
  @FolderID int,
  @FileName nvarchar(500),
  @FileSystemName nvarchar(500),
  @FileTypeID int,
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Files]
   SET 
    [FileID] = @FileID,
    [SiteID] = @SiteID,
    [FolderID] = @FolderID,
    [FileName] = @FileName,
    [FileSystemName] = @FileSystemName,
    [FileTypeID] = @FileTypeID,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [FileID] = @FileID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Files]
(
    [FileID],
    [SiteID],
    [FolderID],
    [FileName],
    [FileSystemName],
    [FileTypeID],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @FileID,
    @SiteID,
    @FolderID,
    @FileName,
    @FileSystemName,
    @FileTypeID,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteFileTypes
(
  @FileTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [FileTypes]
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetFileTypes
(
  @FileTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FileTypeID],
   [FileTypeName],
   [FileTypeExtension]
 FROM [FileTypes]
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveFileTypes
(
  @FileTypeID int,
  @FileTypeName varchar(255),
  @FileTypeExtension varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [FileTypes]
   SET 
    [FileTypeID] = @FileTypeID,
    [FileTypeName] = @FileTypeName,
    [FileTypeExtension] = @FileTypeExtension
   WHERE 
    [FileTypeID] = @FileTypeID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [FileTypes]
(
    [FileTypeID],
    [FileTypeName],
    [FileTypeExtension]
)
VALUES
(
    @FileTypeID,
    @FileTypeName,
    @FileTypeExtension
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteFolders
(
  @FolderID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [Folders]
   WHERE 
    [FolderID] = @FolderID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetFolders
(
  @FolderID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [FolderID],
   [ParentFolderID],
   [SiteID],
   [FolderName]
 FROM [Folders]
   WHERE 
    [FolderID] = @FolderID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveFolders
(
  @FolderID int,
  @ParentFolderID int,
  @SiteID int,
  @FolderName nvarchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Folders]
   SET 
    [FolderID] = @FolderID,
    [ParentFolderID] = @ParentFolderID,
    [SiteID] = @SiteID,
    [FolderName] = @FolderName
   WHERE 
    [FolderID] = @FolderID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Folders]
(
    [FolderID],
    [ParentFolderID],
    [SiteID],
    [FolderName]
)
VALUES
(
    @FolderID,
    @ParentFolderID,
    @SiteID,
    @FolderName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [GlobalSettings]
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteID],
   [ParameterName],
   [ParameterValue],
   [LastModified]
 FROM [GlobalSettings]
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveGlobalSettings
(
  @SiteID int,
  @ParameterName varchar(255),
  @ParameterValue varchar(255),
  @LastModified datetime
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [GlobalSettings]
   SET 
    [SiteID] = @SiteID,
    [ParameterName] = @ParameterName,
    [ParameterValue] = @ParameterValue,
    [LastModified] = @LastModified
   WHERE 
    [SiteID] = @SiteID
   AND  
    [ParameterName] = @ParameterName
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [GlobalSettings]
(
    [SiteID],
    [ParameterName],
    [ParameterValue],
    [LastModified]
)
VALUES
(
    @SiteID,
    @ParameterName,
    @ParameterValue,
    @LastModified
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteSiteLanguages
(
  @SiteLanguageID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteLanguages]
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetSiteLanguages
(
  @SiteLanguageID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteLanguageID],
   [SiteLanguage]
 FROM [SiteLanguages]
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveSiteLanguages
(
  @SiteLanguageID int,
  @SiteLanguage varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteLanguages]
   SET 
    [SiteLanguageID] = @SiteLanguageID,
    [SiteLanguage] = @SiteLanguage
   WHERE 
    [SiteLanguageID] = @SiteLanguageID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteLanguages]
(
    [SiteLanguageID],
    [SiteLanguage]
)
VALUES
(
    @SiteLanguageID,
    @SiteLanguage
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteSites
(
  @SiteID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [Sites]
   WHERE 
    [SiteID] = @SiteID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetSites
(
  @SiteID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteID],
   [SiteName],
   [SiteURL],
   [SiteDescription],
   [LastModified],
   [LastModifiedBy]
 FROM [Sites]
   WHERE 
    [SiteID] = @SiteID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveSites
(
  @SiteID int,
  @SiteName varchar(255),
  @SiteURL varchar(500),
  @SiteDescription text,
  @LastModified datetime,
  @LastModifiedBy int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [Sites]
   SET 
    [SiteID] = @SiteID,
    [SiteName] = @SiteName,
    [SiteURL] = @SiteURL,
    [SiteDescription] = @SiteDescription,
    [LastModified] = @LastModified,
    [LastModifiedBy] = @LastModifiedBy
   WHERE 
    [SiteID] = @SiteID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [Sites]
(
    [SiteID],
    [SiteName],
    [SiteURL],
    [SiteDescription],
    [LastModified],
    [LastModifiedBy]
)
VALUES
(
    @SiteID,
    @SiteName,
    @SiteURL,
    @SiteDescription,
    @LastModified,
    @LastModifiedBy
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteSiteWebParts
(
  @SiteWebPartID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteWebParts]
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetSiteWebParts
(
  @SiteWebPartID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteWebPartID],
   [SiteID],
   [SiteWebPartTypeID],
   [SiteWebPartHTML]
 FROM [SiteWebParts]
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveSiteWebParts
(
  @SiteWebPartID int,
  @SiteID int,
  @SiteWebPartTypeID int,
  @SiteWebPartHTML ntext
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteWebParts]
   SET 
    [SiteWebPartID] = @SiteWebPartID,
    [SiteID] = @SiteID,
    [SiteWebPartTypeID] = @SiteWebPartTypeID,
    [SiteWebPartHTML] = @SiteWebPartHTML
   WHERE 
    [SiteWebPartID] = @SiteWebPartID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteWebParts]
(
    [SiteWebPartID],
    [SiteID],
    [SiteWebPartTypeID],
    [SiteWebPartHTML]
)
VALUES
(
    @SiteWebPartID,
    @SiteID,
    @SiteWebPartTypeID,
    @SiteWebPartHTML
)
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.DeleteSiteWebPartTypes
(
  @SiteWebPartTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 DELETE FROM [SiteWebPartTypes]
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.GetSiteWebPartTypes
(
  @SiteWebPartTypeID int
)
 AS
 
--Date Developer Init Rev 
 
 
 SET NOCOUNT ON
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 SELECT 
   [SiteWebPartTypeID],
   [SiteWebPartName]
 FROM [SiteWebPartTypes]
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
 END 
 
 OnExit: 
    SET NOCOUNT OFF 
    RETURN @returnCode 
 GO
CREATE PROCEDURE dbo.SaveSiteWebPartTypes
(
  @SiteWebPartTypeID int,
  @SiteWebPartName varchar(255)
)
 AS
 
--Date Developer Init Rev 
 
 declare @returnCode int 
 
 select @returnCode = 0
 
 UPDATE [SiteWebPartTypes]
   SET 
    [SiteWebPartTypeID] = @SiteWebPartTypeID,
    [SiteWebPartName] = @SiteWebPartName
   WHERE 
    [SiteWebPartTypeID] = @SiteWebPartTypeID
 
 if (@@rowcount > 0) 
 BEGIN 
    GOTO OnExit
 END 
 if (@@ERROR <> 0) 
 BEGIN 
    select @returnCode = @@ERROR 
    GOTO OnExit
 END 
 
INSERT INTO [SiteWebPartTypes]
(
    [SiteWebPartTypeID],
    [SiteWebPartName]
)
VALUES
(
    @SiteWebPartTypeID,
    @SiteWebPartName
)
 
 OnExit: 
    RETURN @returnCode 
 GO
