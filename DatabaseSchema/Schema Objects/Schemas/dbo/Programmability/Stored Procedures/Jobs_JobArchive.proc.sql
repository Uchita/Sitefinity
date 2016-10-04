CREATE PROCEDURE Jobs_JobArchive
(
	@JobID INT = 0
)
AS
BEGIN TRY
BEGIN TRANSACTION JobArchiveTransaction
 
	INSERT INTO [dbo].[JobsArchive]
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
	FROM Jobs (NOLOCK)
	WHERE JobID = @JobID
 
    UPDATE JobRoles SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID
	UPDATE JobsSaved SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID
	UPDATE JobViews SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID
	UPDATE JobApplication SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID
	UPDATE JobArea SET JobID = NULL, JobArchiveID = @JobID WHERE JobID = @JobID
	DELETE FROM Jobs WHERE JobID = @JobID

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
 
END CATCH
GO