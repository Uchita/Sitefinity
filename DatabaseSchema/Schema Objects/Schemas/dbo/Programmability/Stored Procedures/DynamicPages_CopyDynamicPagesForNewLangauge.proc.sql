CREATE PROCEDURE DynamicPages_CopyDynamicPagesForNewLangauge  
(  
 @SiteID INT,  
 @LanguageID INT,  
 @NewSiteID INT,  
 @NewLanguageID INT,  
 @DynamicPageWebPartTemplateID INT = 0  
)  
AS  
BEGIN  
DECLARE @TransactionName varchar(40)  
 SET @TransactionName = 'CopyDynamicPagesForNewLangauge'  
   
BEGIN TRY  
 BEGIN TRAN @TransactionName  
INSERT INTO DynamicPages (SiteID,LanguageID,ParentDynamicPageID,PageName,  
       PageTitle,PageContent,DynamicPageWebPartTemplateID,HyperLink,  
       Valid,OpenInNewWindow,Sequence,FullScreen,OnTopNav,OnLeftNav,  
       OnBottomNav,OnSiteMap,Searchable,MetaKeywords,MetaDescription,  
       PageFriendlyName,LastModified,LastModifiedBy,SearchField,SourceID)  
SELECT @NewSiteID,@NewLanguageID,ParentDynamicPageID,PageName,  
       PageTitle,PageContent, CASE WHEN @DynamicPageWebPartTemplateID > 0 THEN @DynamicPageWebPartTemplateID ELSE DynamicPageWebPartTemplateID END,HyperLink,  
       Valid,OpenInNewWindow,Sequence,FullScreen,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnTopNav END, CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnLeftNav END,  
       OnBottomNav,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnSiteMap END,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE Searchable END,MetaKeywords,MetaDescription,  
       PageFriendlyName,dp.LastModified,dp.LastModifiedBy,CASE WHEN PageName LIKE 'SystemPage%' THEN '' ELSE SearchField END,DynamicPageID  
FROM DynamicPages dp   
WHERE dp.SiteID = @SiteID AND dp.LanguageID = @LanguageID AND dp.PageName LIKE 'SystemPage%'  
  
  
UPDATE DynamicPages SET DynamicPages.ParentDynamicPageID = DP2.DynamicPageID  
FROM DynamicPages  
INNER JOIN DynamicPages DP2 ON DynamicPages.ParentDynamicPageID = DP2.SourceID  
WHERE DynamicPages.ParentDynamicPageID > 0  
AND DynamicPages.SiteID = @NewSiteID  
AND DynamicPages.LanguageID = @NewLanguageID  
AND DP2.SiteID = @NewSiteID  
  
 COMMIT TRAN @TransactionName  
END TRY  
BEGIN CATCH  
 SELECT ERROR_MESSAGE() AS ErrorMessage  
 ROLLBACK TRAN @TransactionName  
END CATCH  
  
END