  
CREATE PROCEDURE [dbo].[DynamicPages_CopySystemPage]  
(    
 @MasterSiteID INT,    
 @SiteID INT,    
 @PageName VARCHAR(255),    
 @DefaultLanguageID INT,    
 @DefaultAdminID INT    
)    
AS    
BEGIN    
    
DECLARE @SystemPages TABLE (    
DynamicPageID int,    
LanguageID int,    
ParentDynamicPageID int,    
DynamicPageWebPartTemplateID int )    
    
INSERT INTO @SystemPages (DynamicPageID, LanguageID,    
ParentDynamicPageID,    
DynamicPageWebPartTemplateID)    
SELECT DynamicPageID, LanguageID,    
ParentDynamicPageID,    
DynamicPageWebPartTemplateID     
FROM DynamicPages    
WHERE SiteId = @SiteID AND PageName = 'SystemPage' AND ParentDynamicPageID = 0    
    
DECLARE @CopySiteLanguages TABLE (    
SiteLanguageID int,    
SiteID int,    
LanguageID int )    
    
INSERT INTO @CopySiteLanguages (SiteLanguageID, SiteID, LanguageID)    
SELECT SiteLanguageID, SiteID, LanguageID     
FROM SiteLanguages     
WHERE SiteID = @SiteID    
    
DECLARE @CopyDynamicPages TABLE (    
SiteID INT,    
LanguageId INT,    
ParentDynamicPageId INT,    
PageName VARCHAR(255),    
PageTitle VARCHAR(255),    
PageContent NTEXT,    
DynamicPageWebPartTemplateId INT,    
HyperLink VARCHAR(255),    
Valid BIT,    
OpenInNewWindow BIT,    
Sequence INT,    
FullScreen BIT,    
OnTopNav BIT,    
OnLeftNav BIT,    
OnBottomNav BIT,    
OnSiteMap BIT,    
Searchable BIT,    
MetaKeywords VARCHAR(255),    
MetaDescription VARCHAR(512),    
PageFriendlyName VARCHAR(255),    
LastModified DATETIME,    
LastModifiedBy INT,  
SearchField NVARCHAR(MAX)    
)    
    
INSERT INTO @CopyDynamicPages (SiteID, LanguageId, ParentDynamicPageId, PageName, PageTitle, PageContent,    
DynamicPageWebPartTemplateId, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
MetaDescription, PageFriendlyName, LastModified, LastModifiedBy, SearchField)    
SELECT SiteID, LanguageId, ParentDynamicPageId, PageName, PageTitle, PageContent,    
DynamicPageWebPartTemplateId, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
MetaDescription, PageFriendlyName, LastModified, LastModifiedBy, SearchField     
FROM DynamicPages     
WHERE SiteID = @MasterSiteID AND PageName = @PageName AND LanguageID IN (SELECT LanguageID FROM @CopySiteLanguages)    
    
DECLARE @spDynamicPageID int    
DECLARE @spLanguageID int    
DECLARE @spParentDynamicPageID int    
DECLARE @spDynamicPageWebPartTemplateID int    
DECLARE @Result INT    
SET @Result = (SELECT COUNT(*) FROM @CopyDynamicPages)    
IF @Result = 0    
BEGIN    
 DECLARE db_cursor CURSOR FOR    
 SELECT DynamicPageID, LanguageID, ParentDynamicPageID, DynamicPageWebPartTemplateID    
    FROM @SystemPages     
    
 OPEN db_cursor    
 FETCH NEXT FROM db_cursor INTO @spDynamicPageID, @spLanguageID, @spParentDynamicPageID, @spDynamicPageWebPartTemplateID    
 WHILE @@FETCH_STATUS = 0    
 BEGIN    
 INSERT INTO DynamicPages (SiteID, LanguageId, ParentDynamicPageId, PageName, PageTitle, PageContent,    
 DynamicPageWebPartTemplateId, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
 OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
 MetaDescription, PageFriendlyName, LastModified, LastModifiedBy, SearchField)    
 SELECT @SiteID, @spLanguageID, @spDynamicPageID, PageName, PageTitle, PageContent,    
 @spDynamicPageWebPartTemplateID, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
 OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
 MetaDescription, PageFriendlyName, GETDATE(), @DefaultAdminID, SearchField    
 FROM DynamicPages     
 WHERE SiteID = @MasterSiteID AND PageName = @PageName AND LanguageID = @DefaultLanguageID    
     
 FETCH NEXT FROM db_cursor INTO @spDynamicPageID, @spLanguageID, @spParentDynamicPageID, @spDynamicPageWebPartTemplateID    
 END    
END    
ELSE    
BEGIN    
 INSERT INTO DynamicPages (SiteID, LanguageId, ParentDynamicPageId, PageName, PageTitle, PageContent,    
 DynamicPageWebPartTemplateId, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
 OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
 MetaDescription, PageFriendlyName, LastModified, LastModifiedBy, SearchField)    
 SELECT @SiteID, cdp.LanguageId, sp.DynamicPageID, PageName, PageTitle, PageContent,    
 sp.DynamicPageWebPartTemplateId, HyperLink, Valid, OpenInNewWindow, Sequence, FullScreen,    
 OnTopNav, OnLeftNav, OnBottomNav, OnSiteMap, Searchable, MetaKeywords,    
 MetaDescription, PageFriendlyName, GETDATE(), @DefaultAdminID, SearchField     
 FROM @CopyDynamicPages cdp INNER JOIN @SystemPages sp    
 ON cdp.LanguageID = sp.LanguageID    
END    
    
END    