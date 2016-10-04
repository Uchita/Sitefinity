CREATE PROCEDURE [dbo].[DynamicPages_GetBySiteIdPageFriendlyName]  
( 
 @SiteId int,  
 @PageFriendlyName varchar (255)    
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
     AND [PageFriendlyName] = @PageFriendlyName  
    SELECT @@ROWCOUNT  