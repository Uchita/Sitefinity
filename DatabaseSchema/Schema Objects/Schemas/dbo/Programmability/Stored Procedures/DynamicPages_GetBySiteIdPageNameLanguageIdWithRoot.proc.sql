CREATE PROCEDURE dbo.DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot    
(    
    
 @SiteId int   ,    
    
 @PageName varchar (255)  ,    
    
 @LanguageId int       
)    
AS    
  DECLARE @DefaultSiteID INT  
  DECLARE @DefaultLanguageID INT  
  
  SET @DefaultSiteID = 1  
  SET @DefaultLanguageID = 1  
  
  DECLARE @Result INT  
  SET @Result = (SELECT COUNT(*) FROM    
     [dbo].[DynamicPages] (NOLOCK)    
    WHERE [SiteID] = @SiteId    
     AND [PageName] = @PageName    
     AND [LanguageID] = @LanguageId )  
  IF @Result > 0  
  BEGIN  
    SELECT    
     [DynamicPageID],    
     [SiteID],    
     [LanguageID],    
     [ParentDynamicPageID],    
     [PageName],    
     [PageTitle],    
     [PageContent],    
     [DynamicPageWebPartTemplateID],    
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
     [MetaKeywords],    
     [MetaDescription],    
     [PageFriendlyName],    
     [LastModified],    
     [LastModifiedBy],    
     [SearchField],    
     [SourceID]    
    FROM    
     [dbo].[DynamicPages] (NOLOCK)    
    WHERE    
     [SiteID] = @SiteId    
     AND [PageName] = @PageName    
     AND [LanguageID] = @LanguageId    
 END  
 ELSE  
 BEGIN  
  SET @Result = (SELECT COUNT(*) FROM    
  [dbo].[DynamicPages] (NOLOCK)    
  WHERE [SiteID] = @SiteId    
  AND [PageName] = @PageName    
  AND [LanguageID] = @DefaultLanguageID )  
  IF @Result > 0  
  BEGIN  
   SELECT    
    [DynamicPageID],    
    [SiteID],    
    [LanguageID],    
    [ParentDynamicPageID],    
    [PageName],    
    [PageTitle],    
    [PageContent],    
    [DynamicPageWebPartTemplateID],    
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
    [MetaKeywords],    
    [MetaDescription],    
    [PageFriendlyName],    
    [LastModified],    
    [LastModifiedBy],    
    [SearchField],    
    [SourceID]    
   FROM    
    [dbo].[DynamicPages] (NOLOCK)    
   WHERE    
    [SiteID] = @SiteId    
    AND [PageName] = @PageName    
    AND [LanguageID] = @DefaultLanguageID   
  END  
  ELSE  
  BEGIN  
   SET @Result = (SELECT COUNT(*)  
   FROM    
    [dbo].[DynamicPages] (NOLOCK)    
   WHERE    
    [SiteID] = @DefaultSiteID    
    AND [PageName] = @PageName    
    AND [LanguageID] = @LanguageId)   
     
   IF @Result > 0  
   BEGIN  
    SELECT    
    [DynamicPageID],    
    [SiteID],    
    [LanguageID],    
    [ParentDynamicPageID],    
    [PageName],    
    [PageTitle],    
    [PageContent],    
    [DynamicPageWebPartTemplateID],    
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
    [MetaKeywords],    
    [MetaDescription],    
    [PageFriendlyName],    
    [LastModified],    
    [LastModifiedBy],    
    [SearchField],    
    [SourceID]    
   FROM    
    [dbo].[DynamicPages] (NOLOCK)    
   WHERE    
    [SiteID] = @DefaultSiteID    
    AND [PageName] = @PageName    
    AND [LanguageID] = @LanguageId   
   END  
   ELSE  
   BEGIN  
    SELECT    
    [DynamicPageID],    
    [SiteID],    
    [LanguageID],    
    [ParentDynamicPageID],    
    [PageName],    
    [PageTitle],    
    [PageContent],    
    [DynamicPageWebPartTemplateID],    
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
    [MetaKeywords],    
    [MetaDescription],    
    [PageFriendlyName],    
    [LastModified],    
    [LastModifiedBy],    
    [SearchField],    
    [SourceID]    
   FROM    
    [dbo].[DynamicPages] (NOLOCK)    
   WHERE    
    [SiteID] = @DefaultSiteID    
    AND [PageName] = @PageName    
    AND [LanguageID] = @DefaultLanguageId   
   END  
  END  
 END  
  
    SELECT @@ROWCOUNT    
         
       