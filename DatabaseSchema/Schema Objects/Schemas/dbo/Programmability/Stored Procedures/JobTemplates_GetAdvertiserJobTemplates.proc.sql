  
CREATE PROCEDURE [dbo].[JobTemplates_GetAdvertiserJobTemplates]  
(  
 @SiteId int,  
 @AdvertiserId int  
)  
AS  
 DECLARE @JobTemplates TABLE  
 (  
  [JobTemplateID] int,  
  [SiteID] int,  
  [JobTemplateDescription] varchar(255),  
  [JobTemplateHTML] ntext,  
  [GlobalTemplate] bit,  
  [LastModifiedBy]int,  
  [LastModified] datetime,  
  [JobTemplateLogo] image,  
  [AdvertiserID] int  
 )  
  
 INSERT INTO @JobTemplates([JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID])  
 SELECT  
  [JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID]  
 FROM  
  [dbo].[JobTemplates] (NOLOCK)  
 WHERE  
  [SiteID] = @SiteId   
  AND [AdvertiserID] = @AdvertiserId  
   
 IF @@ROWCOUNT = 0   
 BEGIN  
  INSERT INTO @JobTemplates([JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID])  
  SELECT  
   [JobTemplateID],  
   [SiteID],  
   [JobTemplateDescription],  
   [JobTemplateHTML],  
   [GlobalTemplate],  
   [LastModifiedBy],  
   [LastModified],  
   [JobTemplateLogo],  
   [AdvertiserID]  
  FROM  
   [dbo].[JobTemplates] (NOLOCK)  
  WHERE  
   [SiteID] = @SiteId  
   AND [GlobalTemplate] = 1  
 END  
  
 SELECT  
  [JobTemplateID],  
  [SiteID],  
  [JobTemplateDescription],  
  [JobTemplateHTML],  
  [GlobalTemplate],  
  [LastModifiedBy],  
  [LastModified],  
  [JobTemplateLogo],  
  [AdvertiserID]  
 FROM @JobTemplates  
  
 SELECT @@ROWCOUNT  
     