CREATE PROCEDURE [dbo].[DynamicPages_GetBySiteIdPageName]  
(  
 @SiteId int   ,  
 @PageName varchar (255)    
)  
AS  
  
  
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
    SELECT @@ROWCOUNT  
       