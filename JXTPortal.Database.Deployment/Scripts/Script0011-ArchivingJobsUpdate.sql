ALTER PROCEDURE [dbo].[Jobs_JobArchive]   
(  
 @JobID INT = 0  
)  
AS
  
BEGIN TRY  
BEGIN TRANSACTION JobArchiveTransaction  

/*
-- Changes - Jan 2015
Archieve invoice item move from job id to archive id.

-- 21/02/17 - Updated the Archiving of jobs to only Archiving those that expired over 30days ago

*/

 DECLARE @IsJobExpired BIT = 0
 
 -- Check if the job is expired.
 SELECT @IsJobExpired = 1 FROM Jobs j WITH (NOLOCK)
	WHERE JobID = @JobID AND  
			(Expired = 0 AND DATEADD(DD, (SELECT ArchiveDayThreshold FROM Sites NOLOCK WHERE SiteId = j.SiteId), ExpiryDate) < CAST(GETDATE() AS DATE))  -- Live job which is expired or checked expired
 
 IF (@IsJobExpired = 1)
 BEGIN
   
 INSERT INTO [dbo].[JobsArchive]  
      ([JobID]  
      ,[SiteID]  
      ,[WorkTypeID]  
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
      ,[ShowSalaryRange]  
      ,[CurrencyID]  
      ,[SalaryUpperBand]  
      ,[SalaryLowerBand]  
      ,[SalaryTypeID]  
      ,[EnteredByAdvertiserUserID]
      ,JobLatitude
	  ,JobLongitude
	  ,AddressStatus
	  ,JobExternalId)  
      
     SELECT [JobID]  
           ,[SiteID]  
           ,[WorkTypeID]  
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
     ,[ShowSalaryRange]  
           ,[CurrencyID]  
     ,[SalaryUpperBand]  
     ,[SalaryLowerBand]  
     ,[SalaryTypeID]  
     ,[EnteredByAdvertiserUserID] 
     ,JobLatitude
	 ,JobLongitude
	 ,AddressStatus 
	 ,JobExternalId
 FROM Jobs (NOLOCK)  
 WHERE JobID = @JobID  
   
    UPDATE JobRoles SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobsSaved SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobViews SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobApplication SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	UPDATE JobArea SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID  
	Update InvoiceItem SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID   -- Move the InvoiceItem also
	
	DELETE FROM Jobs WHERE JobID = @JobID  
END
  
COMMIT TRANSACTION JobArchiveTransaction  
END TRY  
   
BEGIN CATCH  
IF @@TRANCOUNT > 0  
ROLLBACK TRANSACTION JobArchiveTransaction --RollBack in case of Error  
   
-- Raise an error with the details of the exception  
DECLARE @ErrMsg nvarchar(4000), @ErrSeverity INT  
SELECT @ErrMsg = ERROR_MESSAGE(),  
@ErrSeverity = ERROR_SEVERITY()  
   
RAISERROR(@ErrMsg, @ErrSeverity, 1)  
    
 IF (@IsJobExpired = 1)
 BEGIN
	IF EXISTS(SELECT 1 FROM [JobX_Live].[dbo].[Integration_JXTJobMapping] WHERE JXTJobID = @JobID)  
	BEGIN  
		DECLARE @JobXJobID INT  
		SELECT @JobXJobID = JobID FROM [JobX_Live].[dbo].[Integration_JXTJobMapping] WHERE JXTJobID = @JobID  
		UPDATE [JobX_Live].[dbo].Products SET Expired = 1 WHERE ProductID = @JobXJobID  
	END  
  END   
  
END CATCH
GO