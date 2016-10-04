CREATE PROCEDURE DynamicPages_GetSystemPagesBySiteIDPageName  
 @SiteID INT,  
 @PageName VARCHAR(255)  
AS  
BEGIN  
 SELECT DynamicPageID,  
     SiteID,  
     LanguageID,  
     ParentDynamicPageID,  
     PageName,  
     PageTitle,  
     PageContent,  
     DynamicPageWebPartTemplateID,  
     HyperLink,  
     Valid,  
     OpenInNewWindow,  
     Sequence,  
     FullScreen,  
     OnTopNav,  
     OnLeftNav,  
     OnBottomNav,  
     OnSiteMap,  
     Searchable,  
     MetaKeywords,  
     MetaDescription,  
     PageFriendlyName  
 FROM DynamicPages WHERE SiteID = @SiteID   
 AND PageName = @PageName  
END  