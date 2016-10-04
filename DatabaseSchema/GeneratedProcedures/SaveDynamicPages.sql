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
