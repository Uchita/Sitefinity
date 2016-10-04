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
