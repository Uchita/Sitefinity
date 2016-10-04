CREATE PROCEDURE Jobs_JobUnarchive   
(  
 @JobID INT = 0  
)  
AS  
BEGIN TRY  
BEGIN TRANSACTION JobTransaction  
   
 SET IDENTITY_INSERT [Jobs] ON  
  
 INSERT INTO [dbo].[Jobs]  
      ([JobID]  
      ,[SiteID]  
      ,[WorkTypeID]  
      ,[SalaryID]  
      ,[JobName]  
      ,[Description]  
      ,[FullDescription]  
      ,[WebServiceProcessed]  
      ,[ApplicationEmailAddress]  
      ,[RefNo]  
      ,[Visible]  
      ,[DatePosted]  
      ,[ExpiryDate]  
      ,[Expired]  
      ,[JobItemPrice]  
      ,[Billed]  
      ,[LastModified]  
      ,[ShowSalaryDetails]  
      ,[SalaryText]  
      ,[AdvertiserID]  
      ,[LastModifiedByAdvertiserUserId]  
      ,[LastModifiedByAdminUserId]  
      ,[JobItemTypeID]  
      ,[ApplicationMethod]  
      ,[ApplicationURL]  
      ,[UploadMethod]  
      ,[Tags]  
      ,[JobTemplateID]  
      ,[SearchFieldExtension]  
      ,[AdvertiserJobTemplateLogoID]  
      ,[CompanyName]  
      ,[HashValue]  
      ,[RequireLogonForExternalApplications]  
      ,[ShowLocationDetails]  
      ,[PublicTransport]  
      ,[Address]  
      ,[ContactDetails]  
      ,[JobContactPhone]  
      ,[JobContactName]  
      ,[QualificationsRecognised]  
      ,[ResidentOnly]  
      ,[DocumentLink]  
      ,[BulletPoint1]  
      ,[BulletPoint2]  
      ,[BulletPoint3]  
      ,[HotJob]  
      ,[JobFriendlyName]  
      ,[SearchField])  
     SELECT [JobID]  
           ,[SiteID]  
           ,[WorkTypeID]  
           ,[SalaryID]  
           ,[JobName]  
           ,[Description]  
           ,[FullDescription]  
           ,[WebServiceProcessed]  
           ,[ApplicationEmailAddress]  
           ,[RefNo]  
           ,[Visible]  
           ,[DatePosted]  
           ,[ExpiryDate]  
           ,[Expired]  
           ,[JobItemPrice]  
           ,[Billed]  
           ,[LastModified]  
           ,[ShowSalaryDetails]  
           ,[SalaryText]  
           ,[AdvertiserID]  
           ,[LastModifiedByAdvertiserUserId]  
           ,[LastModifiedByAdminUserId]  
           ,[JobItemTypeID]  
           ,[ApplicationMethod]  
           ,[ApplicationURL]  
           ,[UploadMethod]  
           ,[Tags]  
           ,[JobTemplateID]  
           ,[SearchFieldExtension]  
           ,[AdvertiserJobTemplateLogoID]  
           ,[CompanyName]  
           ,[HashValue]  
           ,[RequireLogonForExternalApplications]  
           ,[ShowLocationDetails]  
           ,[PublicTransport]  
           ,[Address]  
           ,[ContactDetails]  
           ,[JobContactPhone]  
           ,[JobContactName]  
           ,[QualificationsRecognised]  
           ,[ResidentOnly]  
           ,[DocumentLink]  
           ,[BulletPoint1]  
           ,[BulletPoint2]  
           ,[BulletPoint3]  
           ,[HotJob]  
           ,[JobFriendlyName]  
           ,[SearchField]  
 FROM JobsArchive (NOLOCK)  
 WHERE JobID = @JobID  
   
 SET IDENTITY_INSERT [Jobs] OFF  
  
 UPDATE JobRoles SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 UPDATE JobsSaved SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 UPDATE JobViews SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 UPDATE JobApplication SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 UPDATE JobArea SET JobArchiveID = NULL, JobID = @JobID WHERE JobArchiveID = @JobID  
 DELETE FROM JobsArchive WHERE JobID = @JobID  
   
COMMIT TRANSACTION JobTransaction  
END TRY  
   
BEGIN CATCH  
IF @@TRANCOUNT > 0  
ROLLBACK TRANSACTION JobTransaction --RollBack in case of Error  
   
-- Raise an error with the details of the exception  
DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT  
SELECT @ErrMsg = ERROR_MESSAGE(),  
@ErrSeverity = ERROR_SEVERITY()  
   
RAISERROR(@ErrMsg, @ErrSeverity, 1)  
   
END CATCH  
GO