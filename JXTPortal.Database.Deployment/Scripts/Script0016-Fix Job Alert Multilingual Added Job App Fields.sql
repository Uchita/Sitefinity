IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'SearchKeywords' AND OBJECT_ID = OBJECT_ID(N'JobAlerts'))
	BEGIN
		ALTER TABLE JobAlerts ADD SearchKeywords NVARCHAR(1000) NULL
	END 
GO

IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'ProcessDate' AND OBJECT_ID = OBJECT_ID(N'JobApplication'))
	BEGIN
		ALTER TABLE JobApplication ADD ProcessDate DATETIME NULL
	END 
GO

IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'ProcessException' AND OBJECT_ID = OBJECT_ID(N'JobApplication'))
	BEGIN
		ALTER TABLE JobApplication ADD ProcessException VARCHAR(500) NULL
	END 
GO

IF NOT EXISTS(SELECT * FROM sys.columns
	WHERE Name = N'ExternalID' AND OBJECT_ID = OBJECT_ID(N'JobApplication'))
	BEGIN
		ALTER TABLE JobApplication ADD ExternalID VARCHAR(50) NULL
	END 
GO

ALTER PROCEDURE [dbo].[JobApplication_Update]
(

	@JobApplicationId int   ,

	@ApplicationDate smalldatetime   ,

	@JobId int   ,

	@MemberId int   ,

	@MemberResumeFile varchar (255)  ,

	@MemberCoverLetterFile varchar (255)  ,

	@ApplicationStatus int   ,

	@JobAppValidateId uniqueidentifier   ,

	@SiteIdReferral int   ,

	@UrlReferral varchar (255)  ,

	@ApplicantGrade int   ,

	@LastViewedDate datetime   ,

	@FirstName nvarchar (255)  ,

	@Surname nvarchar (255)  ,

	@EmailAddress varchar (255)  ,

	@MobilePhone char (40)  ,

	@MemberNote nvarchar (MAX)  ,

	@AdvertiserNote nvarchar (MAX)  ,

	@JobArchiveId int   ,

	@Draft bit   ,

	@JobApplicationTypeId int   ,

	@ExternalXmlFilename varchar (255)  ,

	@CustomQuestionnaireXml nvarchar (MAX)  ,

	@ExternalPdfFilename varchar (255)  ,

	@FileDownloaded bit   ,

	@AppliedWith varchar (255)  ,

	@ScreeningQuestionaireXml nvarchar (MAX)  ,

	@ScreeningQuestionsGuid uniqueidentifier   ,

	@ProcessDate datetime   ,

	@ProcessException varchar (500)  ,

	@ExternalId varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[JobApplication]
				SET
					[ApplicationDate] = @ApplicationDate
					,[JobID] = @JobId
					,[MemberID] = @MemberId
					,[MemberResumeFile] = @MemberResumeFile
					,[MemberCoverLetterFile] = @MemberCoverLetterFile
					,[ApplicationStatus] = @ApplicationStatus
					,[JobAppValidateID] = @JobAppValidateId
					,[SiteID_Referral] = @SiteIdReferral
					,[URL_Referral] = @UrlReferral
					,[ApplicantGrade] = @ApplicantGrade
					,[LastViewedDate] = @LastViewedDate
					,[FirstName] = @FirstName
					,[Surname] = @Surname
					,[EmailAddress] = @EmailAddress
					,[MobilePhone] = @MobilePhone
					,[MemberNote] = @MemberNote
					,[AdvertiserNote] = @AdvertiserNote
					,[JobArchiveID] = @JobArchiveId
					,[Draft] = @Draft
					,[JobApplicationTypeID] = @JobApplicationTypeId
					,[ExternalXMLFilename] = @ExternalXmlFilename
					,[CustomQuestionnaireXML] = @CustomQuestionnaireXml
					,[ExternalPDFFilename] = @ExternalPdfFilename
					,[FileDownloaded] = @FileDownloaded
					,[AppliedWith] = @AppliedWith
					,[ScreeningQuestionaireXML] = @ScreeningQuestionaireXml
					,[ScreeningQuestionsGuid] = @ScreeningQuestionsGuid
					,[ProcessDate] = @ProcessDate
					,[ProcessException] = @ProcessException
					,[ExternalID] = @ExternalId
				WHERE
[JobApplicationID] = @JobApplicationId
GO

ALTER PROCEDURE [dbo].[JobApplication_Insert]
(

	@JobApplicationId int    OUTPUT,

	@ApplicationDate smalldatetime   ,

	@JobId int   ,

	@MemberId int   ,

	@MemberResumeFile varchar (255)  ,

	@MemberCoverLetterFile varchar (255)  ,

	@ApplicationStatus int   ,

	@JobAppValidateId uniqueidentifier    OUTPUT,

	@SiteIdReferral int   ,

	@UrlReferral varchar (255)  ,

	@ApplicantGrade int   ,

	@LastViewedDate datetime   ,

	@FirstName nvarchar (255)  ,

	@Surname nvarchar (255)  ,

	@EmailAddress varchar (255)  ,

	@MobilePhone char (40)  ,

	@MemberNote nvarchar (MAX)  ,

	@AdvertiserNote nvarchar (MAX)  ,

	@JobArchiveId int   ,

	@Draft bit   ,

	@JobApplicationTypeId int   ,

	@ExternalXmlFilename varchar (255)  ,

	@CustomQuestionnaireXml nvarchar (MAX)  ,

	@ExternalPdfFilename varchar (255)  ,

	@FileDownloaded bit   ,

	@AppliedWith varchar (255)  ,

	@ScreeningQuestionaireXml nvarchar (MAX)  ,

	@ScreeningQuestionsGuid uniqueidentifier   ,

	@ProcessDate datetime   ,

	@ProcessException varchar (500)  ,

	@ExternalId varchar (50)  
)
AS


				
				INSERT INTO [dbo].[JobApplication]
					(
					[ApplicationDate]
					,[JobID]
					,[MemberID]
					,[MemberResumeFile]
					,[MemberCoverLetterFile]
					,[ApplicationStatus]
					,[JobAppValidateID]
					,[SiteID_Referral]
					,[URL_Referral]
					,[ApplicantGrade]
					,[LastViewedDate]
					,[FirstName]
					,[Surname]
					,[EmailAddress]
					,[MobilePhone]
					,[MemberNote]
					,[AdvertiserNote]
					,[JobArchiveID]
					,[Draft]
					,[JobApplicationTypeID]
					,[ExternalXMLFilename]
					,[CustomQuestionnaireXML]
					,[ExternalPDFFilename]
					,[FileDownloaded]
					,[AppliedWith]
					,[ScreeningQuestionaireXML]
					,[ScreeningQuestionsGuid]
					,[ProcessDate]
					,[ProcessException]
					,[ExternalID]
					)
				VALUES
					(
					@ApplicationDate
					,@JobId
					,@MemberId
					,@MemberResumeFile
					,@MemberCoverLetterFile
					,@ApplicationStatus
					,@JobAppValidateId
					,@SiteIdReferral
					,@UrlReferral
					,@ApplicantGrade
					,@LastViewedDate
					,@FirstName
					,@Surname
					,@EmailAddress
					,@MobilePhone
					,@MemberNote
					,@AdvertiserNote
					,@JobArchiveId
					,@Draft
					,@JobApplicationTypeId
					,@ExternalXmlFilename
					,@CustomQuestionnaireXml
					,@ExternalPdfFilename
					,@FileDownloaded
					,@AppliedWith
					,@ScreeningQuestionaireXml
					,@ScreeningQuestionsGuid
					,@ProcessDate
					,@ProcessException
					,@ExternalId
					)
				
				-- Get the identity value
				SET @JobApplicationId = SCOPE_IDENTITY()
GO

ALTER PROCEDURE [dbo].[JobApplication_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [JobApplicationID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobApplicationID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobApplicationID]'
				SET @SQL = @SQL + ' FROM [dbo].[JobApplication]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[JobApplicationID], O.[ApplicationDate], O.[JobID], O.[MemberID], O.[MemberResumeFile], O.[MemberCoverLetterFile], O.[ApplicationStatus], O.[JobAppValidateID], O.[SiteID_Referral], O.[URL_Referral], O.[ApplicantGrade], O.[LastViewedDate], O.[FirstName], O.[Surname], O.[EmailAddress], O.[MobilePhone], O.[MemberNote], O.[AdvertiserNote], O.[JobArchiveID], O.[Draft], O.[JobApplicationTypeID], O.[ExternalXMLFilename], O.[CustomQuestionnaireXML], O.[ExternalPDFFilename], O.[FileDownloaded], O.[AppliedWith], O.[ScreeningQuestionaireXML], O.[ScreeningQuestionsGuid], O.[ProcessDate], O.[ProcessException], O.[ExternalID]
				FROM
				    [dbo].[JobApplication] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobApplicationID] = PageIndex.[JobApplicationID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[JobApplication]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO

ALTER PROCEDURE [dbo].[JobApplication_GetJobsNameByMemberId]                      
(                      
 @MemberID INT,                  
 @PageSize INT,                            
 @PageNumber INT                         
)                      
                      
AS                    
BEGIN                  
                  
DECLARE @SiteID INT                 
                
SET @SiteID = (Select SiteID from Members (NOLOCK) where MemberID = @MemberID)                
                
 IF @PageSize IS NULL                          
  SET @pageSize = 10                          
                          
 IF @PageNumber IS NULL                          
  SET @PageNumber = 1                          
                          
 Declare @pageStart int                          
 Declare @pageEnd int                          
                          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1                          
 SET @PageEnd = (@PageNumber * @PageSize);                        
                  
 WITH JobApplicationJobNameByMember AS                   
(                   
 SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY JobApplication.JobApplicationID DESC) AS RowNumber, JobApplication.JobApplicationID AS JobApplicationID,                     
  JobApplication.ApplicationDate AS ApplicationDate, JobApplication.MemberID AS MemberID, JobApplication.ApplicationStatus AS ApplicationStatus,                     
  ISNULL(Jobs.JobID, JobsArchive.JobID) AS JobID, ISNULL(Jobs.JobName, JobsArchive.JobName) AS JobName, Jobs.RefNo, Advertisers.AdvertiserID AS AdvertiserID, Advertisers.CompanyName AS CompanyName,        
  '/' + ISNULL((SELECT TOP 1 SiteProfessionFriendlyUrl         
 FROM JobRoles (NOLOCK)                           
  INNER JOIN SiteRoles (NOLOCK)                           
  ON SiteRoles.RoleID = JobRoles.RoleID                        
  AND SiteRoles.SiteID = @SiteID                            
  INNER JOIN Roles (NOLOCK)                           
  ON Roles.RoleID = JobRoles.RoleID                          
  INNER JOIN Profession (NOLOCK)                           
  ON Profession.ProfessionID = Roles.ProfessionID                          
  INNER JOIN SiteProfession (NOLOCK)                           
  ON SiteProfession.ProfessionID = Profession.ProfessionID                         
  AND SiteProfession.SiteID = @SiteID WHERE (JobRoles.JobID = JobApplication.JobID OR JobRoles.JobArchiveID = JobApplication.JobArchiveID)),'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, JobsArchive.JobFriendlyName) as 'JobFriendlyName'                  
 FROM   JobApplication JobApplication                             
 LEFT JOIN  Jobs (NOLOCK) ON JobApplication.JobID = Jobs.JobID                      
 LEFT JOIN  JobsArchive (NOLOCK) ON JobApplication.JobArchiveID = JobsArchive.JobID  
 INNER JOIN  Advertisers (NOLOCK) ON Advertisers.AdvertiserID = Jobs.AdvertiserID OR Advertisers.AdvertiserID = JobsArchive.AdvertiserID  
                       
 WHERE  JobApplication.MemberID = @MemberID AND ISNULL(JobApplication.Draft,0) = 0   
 AND (Jobs.ExpiryDate > DATEADD(dd, -180, GETDATE()) OR JobsArchive.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 90 days from expiry  
 )                  
                  
SELECT JobApplicationID, ApplicationDate, MemberID, ApplicationStatus, JobID, JobName, RefNo, JobFriendlyName, AdvertiserID, CompanyName,                  
     (SELECT COUNT(1) FROM JobApplicationJobNameByMember) AS TotalCount                  
FROM    JobApplicationJobNameByMember WITH (NOLOCK)                   
WHERE   MemberID = @MemberID                  
 AND RowNumber >= @PageStart                        
 AND RowNumber <= @PageEnd                        
ORDER BY RowNumber                  
                  
END
GO

ALTER PROCEDURE [dbo].[JobApplication_GetBySiteIdReferral]
(

	@SiteIdReferral int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
				WHERE
					[SiteID_Referral] = @SiteIdReferral
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByMemberId]
(

	@MemberId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
				WHERE
					[MemberID] = @MemberId
				SELECT @@ROWCOUNT
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByJobId]
(

	@JobId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobID] = @JobId
				SELECT @@ROWCOUNT
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByJobArchiveId]
(

	@JobArchiveId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobArchiveID] = @JobArchiveId
				SELECT @@ROWCOUNT
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByJobApplicationId]
(

	@JobApplicationId int   
)
AS


				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
				WHERE
					[JobApplicationID] = @JobApplicationId
				SELECT @@ROWCOUNT
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserIdJobId]                  
(                  
                  
 @AdvertiserId int  ,                  
                  
 @JobId int,                  
                  
 @PageNumber int   ,                  
                  
 @PageSize int                     
)                  
AS                  
                  
    BEGIN                  
    IF @PageSize IS NULL                          
      SET @pageSize = 10                          
                              
     IF @PageNumber IS NULL                          
      SET @PageNumber = 0                          
                              
     Declare @pageStart int                          
     Declare @pageEnd int                          
                              
     SET @PageStart = (@PageNumber * @PageSize) + 1                  
     SET @PageEnd = ((@PageNumber + 1) * @PageSize);                  
                  
    -- SQL Server 2005 Paging                  
    WITH PageIndex AS (                  
    SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex                  
    , [JobApplicationID]                  
    , [ApplicationDate]                  
    , ja.JobID                  
    , ja.[MemberID]                  
    , [MemberResumeFile]                  
    , [MemberCoverLetterFile]                  
    , [ApplicationStatus]                  
    , [JobAppValidateID]                  
    , [SiteID_Referral]                  
    , [URL_Referral]                  
    , [ApplicantGrade]                  
    , [LastViewedDate]         
                   
    , m.[FirstName]                  
    , m.[Surname]                  
    , m.[EmailAddress]                  
    , m.[MobilePhone]        
                   
    , m.PostCode              
    , m.States               
    , [MemberNote]                  
    , [AdvertiserNote]                 
    , [CustomQuestionnaireXML]                     
    , ExternalPDFFilename              
    , FileDownloaded              
     FROM [dbo].[JobApplication] ja (NOLOCK)                  
     LEFT JOIN [dbo].[Jobs] j (NOLOCK) ON ja.JobID = j.JobID                  
     LEFT JOIN Members m (NOLOCK) ON m.MemberID = ja.MemberID              
     WHERE j.AdvertiserID = @AdvertiserId AND ISNULL(ja.Draft,0) = 0          
     AND ((ISNULL(@JobId,0) = 0 OR ja.JobID = @JobId))                
     ) SELECT                  
     [JobApplicationID],                  
     [ApplicationDate],                  
     [JobID],                  
     [MemberID],                  
     [MemberResumeFile],                  
     [MemberCoverLetterFile],               
    ExternalPDFFilename,                 
     [ApplicationStatus],                  
     [JobAppValidateID],                  
     [SiteID_Referral],                  
     [URL_Referral],                  
     [ApplicantGrade],                  
     [LastViewedDate],                  
     [FirstName],                  
     [Surname],                  
     [EmailAddress],                  
     [MobilePhone],                  
  PostCode,              
     States,                
     [MemberNote],                  
     [AdvertiserNote],                
     FileDownloaded,                
    [CustomQuestionnaireXML] ,                 
    (SELECT COUNT(1) FROM PageIndex) AS TotalCount                  
     FROM PageIndex                  
     WHERE RowIndex >= @PageStart                        
     AND RowIndex <= @PageEnd                        
     ORDER BY RowIndex                   
                     
    END
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserIdJobArchiveId]            
(            
            
 @AdvertiserId int  ,            
            
 @JobArchiveId int  ,            
            
 @PageNumber int   ,            
            
 @PageSize int               
)            
AS            
            
    BEGIN            
    IF @PageSize IS NULL                    
      SET @pageSize = 10                    
                        
     IF @PageNumber IS NULL                    
      SET @PageNumber = 0                    
                        
     Declare @pageStart int                    
     Declare @pageEnd int                    
                        
     SET @PageStart = (@PageNumber) * (@PageSize + 1)            
     SET @PageEnd = ((@PageNumber + 1) * @PageSize);            
            
    -- SQL Server 2005 Paging            
    WITH PageIndex AS (            
    SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex            
    , [JobApplicationID]            
    , [ApplicationDate]            
    , ja.JobID            
    , ja.[MemberID]            
    , [MemberResumeFile]            
    , [MemberCoverLetterFile]            
    , [ApplicationStatus]            
    , [JobAppValidateID]            
    , [SiteID_Referral]            
    , [URL_Referral]            
    , [ApplicantGrade]            
    , [LastViewedDate]   
               
    , m.[FirstName]            
    , m.[Surname]            
    , m.[EmailAddress]            
    , m.[MobilePhone]   
              
    , m.PostCode        
    , m.States         
    , [MemberNote]            
    , [AdvertiserNote]           
    , [CustomQuestionnaireXML]               
    , ExternalPDFFilename        
    , FileDownloaded        
     FROM [dbo].[JobApplication] ja (NOLOCK)            
     INNER JOIN [dbo].[JobsArchive] j (NOLOCK) ON ja.JobArchiveID = j.JobID             
     LEFT JOIN Members m (NOLOCK) ON m.MemberID = ja.MemberID             
     WHERE j.AdvertiserID = @AdvertiserId AND ISNULL(ja.Draft,0) = 0          
     AND ja.JobArchiveID = @JobArchiveId            
     ) SELECT            
     [JobApplicationID],            
     [ApplicationDate],            
     [JobID],            
     [MemberID],            
     [MemberResumeFile],            
     [MemberCoverLetterFile],         
    ExternalPDFFilename,           
     [ApplicationStatus],            
     [JobAppValidateID],            
     [SiteID_Referral],            
     [URL_Referral],            
     [ApplicantGrade],            
     [LastViewedDate],            
     [FirstName],            
     [Surname],            
     [EmailAddress],            
     [MobilePhone],            
  PostCode,        
     States,          
     [MemberNote],            
     [AdvertiserNote],           
     FileDownloaded,         
    [CustomQuestionnaireXML] ,          
    (SELECT COUNT(1) FROM PageIndex) AS TotalCount            
     FROM PageIndex            
     WHERE RowIndex >= @PageStart                  
     AND RowIndex <= @PageEnd                  
     ORDER BY RowIndex             
               
    END
GO

ALTER PROCEDURE [dbo].[JobApplication_GetByAdvertiserId]
(

	@AdvertiserId int  ,

	@PageNumber int   ,

	@PageSize int   
)
AS

				BEGIN
				IF @PageSize IS NULL        
				  SET @pageSize = 10        
				        
				 IF @PageNumber IS NULL        
				  SET @PageNumber = 1        
				        
				 Declare @pageStart int        
				 Declare @pageEnd int        
				        
				 SET @PageStart = (@PageNumber - 1) * @PageSize + 1        
				 SET @PageEnd = (@PageNumber * @PageSize);

				-- SQL Server 2005 Paging
				WITH PageIndex AS (
				SELECT ROW_NUMBER() OVER (ORDER BY ja.ApplicationDate DESC) as RowIndex
				, [JobApplicationID]
				, [ApplicationDate]
				, ja.JobID
				, [MemberID]
				, [MemberResumeFile]
				, [MemberCoverLetterFile]
				, [ApplicationStatus]
				, [JobAppValidateID]
				, [SiteID_Referral]
				, [URL_Referral]
				, [ApplicantGrade]
				, [LastViewedDate]
				, [FirstName]
				, [Surname]
				, [EmailAddress]
				, [MobilePhone]
				, [MemberNote]
				, [AdvertiserNote]				
				 FROM [dbo].[JobApplication] ja (NOLOCK)
				 INNER JOIN [dbo].[Jobs] j (NOLOCK)
				 ON ja.JobID = j.JobID
				 WHERE j.AdvertiserID =  + @AdvertiserId
				 ) SELECT
				 [JobApplicationID],
				 [ApplicationDate],
				 [JobID],
				 [MemberID],
				 [MemberResumeFile],
				 [MemberCoverLetterFile],
				 [ApplicationStatus],
				 [JobAppValidateID],
				 [SiteID_Referral],
				 [URL_Referral],
				 [ApplicantGrade],
				 [LastViewedDate],
				 [FirstName],
				 [Surname],
				 [EmailAddress],
				 [MobilePhone],
				 [MemberNote],
				 [AdvertiserNote], 
				(SELECT COUNT(1) FROM PageIndex) AS TotalCount
				 FROM PageIndex
				 WHERE RowIndex >= @PageStart      
				 AND	RowIndex <= @PageEnd      
				 ORDER BY RowIndex 
			
				END
GO


ALTER PROCEDURE [dbo].[JobApplication_Get_List]

AS


				
				SELECT
					[JobApplicationID],
					[ApplicationDate],
					[JobID],
					[MemberID],
					[MemberResumeFile],
					[MemberCoverLetterFile],
					[ApplicationStatus],
					[JobAppValidateID],
					[SiteID_Referral],
					[URL_Referral],
					[ApplicantGrade],
					[LastViewedDate],
					[FirstName],
					[Surname],
					[EmailAddress],
					[MobilePhone],
					[MemberNote],
					[AdvertiserNote],
					[JobArchiveID],
					[Draft],
					[JobApplicationTypeID],
					[ExternalXMLFilename],
					[CustomQuestionnaireXML],
					[ExternalPDFFilename],
					[FileDownloaded],
					[AppliedWith],
					[ScreeningQuestionaireXML],
					[ScreeningQuestionsGuid],
					[ProcessDate],
					[ProcessException],
					[ExternalID]
				FROM
					[dbo].[JobApplication]
					
				SELECT @@ROWCOUNT
GO


ALTER PROCEDURE [dbo].[JobApplication_Find]
(

	@SearchUsingOR bit   = null ,

	@JobApplicationId int   = null ,

	@ApplicationDate smalldatetime   = null ,

	@JobId int   = null ,

	@MemberId int   = null ,

	@MemberResumeFile varchar (255)  = null ,

	@MemberCoverLetterFile varchar (255)  = null ,

	@ApplicationStatus int   = null ,

	@JobAppValidateId uniqueidentifier   = null ,

	@SiteIdReferral int   = null ,

	@UrlReferral varchar (255)  = null ,

	@ApplicantGrade int   = null ,

	@LastViewedDate datetime   = null ,

	@FirstName nvarchar (255)  = null ,

	@Surname nvarchar (255)  = null ,

	@EmailAddress varchar (255)  = null ,

	@MobilePhone char (40)  = null ,

	@MemberNote nvarchar (MAX)  = null ,

	@AdvertiserNote nvarchar (MAX)  = null ,

	@JobArchiveId int   = null ,

	@Draft bit   = null ,

	@JobApplicationTypeId int   = null ,

	@ExternalXmlFilename varchar (255)  = null ,

	@CustomQuestionnaireXml nvarchar (MAX)  = null ,

	@ExternalPdfFilename varchar (255)  = null ,

	@FileDownloaded bit   = null ,

	@AppliedWith varchar (255)  = null ,

	@ScreeningQuestionaireXml nvarchar (MAX)  = null ,

	@ScreeningQuestionsGuid uniqueidentifier   = null ,

	@ProcessDate datetime   = null ,

	@ProcessException varchar (500)  = null ,

	@ExternalId varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobApplicationID]
	, [ApplicationDate]
	, [JobID]
	, [MemberID]
	, [MemberResumeFile]
	, [MemberCoverLetterFile]
	, [ApplicationStatus]
	, [JobAppValidateID]
	, [SiteID_Referral]
	, [URL_Referral]
	, [ApplicantGrade]
	, [LastViewedDate]
	, [FirstName]
	, [Surname]
	, [EmailAddress]
	, [MobilePhone]
	, [MemberNote]
	, [AdvertiserNote]
	, [JobArchiveID]
	, [Draft]
	, [JobApplicationTypeID]
	, [ExternalXMLFilename]
	, [CustomQuestionnaireXML]
	, [ExternalPDFFilename]
	, [FileDownloaded]
	, [AppliedWith]
	, [ScreeningQuestionaireXML]
	, [ScreeningQuestionsGuid]
	, [ProcessDate]
	, [ProcessException]
	, [ExternalID]
    FROM
	[dbo].[JobApplication]
    WHERE 
	 ([JobApplicationID] = @JobApplicationId OR @JobApplicationId IS NULL)
	AND ([ApplicationDate] = @ApplicationDate OR @ApplicationDate IS NULL)
	AND ([JobID] = @JobId OR @JobId IS NULL)
	AND ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([MemberResumeFile] = @MemberResumeFile OR @MemberResumeFile IS NULL)
	AND ([MemberCoverLetterFile] = @MemberCoverLetterFile OR @MemberCoverLetterFile IS NULL)
	AND ([ApplicationStatus] = @ApplicationStatus OR @ApplicationStatus IS NULL)
	AND ([JobAppValidateID] = @JobAppValidateId OR @JobAppValidateId IS NULL)
	AND ([SiteID_Referral] = @SiteIdReferral OR @SiteIdReferral IS NULL)
	AND ([URL_Referral] = @UrlReferral OR @UrlReferral IS NULL)
	AND ([ApplicantGrade] = @ApplicantGrade OR @ApplicantGrade IS NULL)
	AND ([LastViewedDate] = @LastViewedDate OR @LastViewedDate IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Surname] = @Surname OR @Surname IS NULL)
	AND ([EmailAddress] = @EmailAddress OR @EmailAddress IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([MemberNote] = @MemberNote OR @MemberNote IS NULL)
	AND ([AdvertiserNote] = @AdvertiserNote OR @AdvertiserNote IS NULL)
	AND ([JobArchiveID] = @JobArchiveId OR @JobArchiveId IS NULL)
	AND ([Draft] = @Draft OR @Draft IS NULL)
	AND ([JobApplicationTypeID] = @JobApplicationTypeId OR @JobApplicationTypeId IS NULL)
	AND ([ExternalXMLFilename] = @ExternalXmlFilename OR @ExternalXmlFilename IS NULL)
	AND ([CustomQuestionnaireXML] = @CustomQuestionnaireXml OR @CustomQuestionnaireXml IS NULL)
	AND ([ExternalPDFFilename] = @ExternalPdfFilename OR @ExternalPdfFilename IS NULL)
	AND ([FileDownloaded] = @FileDownloaded OR @FileDownloaded IS NULL)
	AND ([AppliedWith] = @AppliedWith OR @AppliedWith IS NULL)
	AND ([ScreeningQuestionaireXML] = @ScreeningQuestionaireXml OR @ScreeningQuestionaireXml IS NULL)
	AND ([ScreeningQuestionsGuid] = @ScreeningQuestionsGuid OR @ScreeningQuestionsGuid IS NULL)
	AND ([ProcessDate] = @ProcessDate OR @ProcessDate IS NULL)
	AND ([ProcessException] = @ProcessException OR @ProcessException IS NULL)
	AND ([ExternalID] = @ExternalId OR @ExternalId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobApplicationID]
	, [ApplicationDate]
	, [JobID]
	, [MemberID]
	, [MemberResumeFile]
	, [MemberCoverLetterFile]
	, [ApplicationStatus]
	, [JobAppValidateID]
	, [SiteID_Referral]
	, [URL_Referral]
	, [ApplicantGrade]
	, [LastViewedDate]
	, [FirstName]
	, [Surname]
	, [EmailAddress]
	, [MobilePhone]
	, [MemberNote]
	, [AdvertiserNote]
	, [JobArchiveID]
	, [Draft]
	, [JobApplicationTypeID]
	, [ExternalXMLFilename]
	, [CustomQuestionnaireXML]
	, [ExternalPDFFilename]
	, [FileDownloaded]
	, [AppliedWith]
	, [ScreeningQuestionaireXML]
	, [ScreeningQuestionsGuid]
	, [ProcessDate]
	, [ProcessException]
	, [ExternalID]
    FROM
	[dbo].[JobApplication]
    WHERE 
	 ([JobApplicationID] = @JobApplicationId AND @JobApplicationId is not null)
	OR ([ApplicationDate] = @ApplicationDate AND @ApplicationDate is not null)
	OR ([JobID] = @JobId AND @JobId is not null)
	OR ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([MemberResumeFile] = @MemberResumeFile AND @MemberResumeFile is not null)
	OR ([MemberCoverLetterFile] = @MemberCoverLetterFile AND @MemberCoverLetterFile is not null)
	OR ([ApplicationStatus] = @ApplicationStatus AND @ApplicationStatus is not null)
	OR ([JobAppValidateID] = @JobAppValidateId AND @JobAppValidateId is not null)
	OR ([SiteID_Referral] = @SiteIdReferral AND @SiteIdReferral is not null)
	OR ([URL_Referral] = @UrlReferral AND @UrlReferral is not null)
	OR ([ApplicantGrade] = @ApplicantGrade AND @ApplicantGrade is not null)
	OR ([LastViewedDate] = @LastViewedDate AND @LastViewedDate is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Surname] = @Surname AND @Surname is not null)
	OR ([EmailAddress] = @EmailAddress AND @EmailAddress is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([MemberNote] = @MemberNote AND @MemberNote is not null)
	OR ([AdvertiserNote] = @AdvertiserNote AND @AdvertiserNote is not null)
	OR ([JobArchiveID] = @JobArchiveId AND @JobArchiveId is not null)
	OR ([Draft] = @Draft AND @Draft is not null)
	OR ([JobApplicationTypeID] = @JobApplicationTypeId AND @JobApplicationTypeId is not null)
	OR ([ExternalXMLFilename] = @ExternalXmlFilename AND @ExternalXmlFilename is not null)
	OR ([CustomQuestionnaireXML] = @CustomQuestionnaireXml AND @CustomQuestionnaireXml is not null)
	OR ([ExternalPDFFilename] = @ExternalPdfFilename AND @ExternalPdfFilename is not null)
	OR ([FileDownloaded] = @FileDownloaded AND @FileDownloaded is not null)
	OR ([AppliedWith] = @AppliedWith AND @AppliedWith is not null)
	OR ([ScreeningQuestionaireXML] = @ScreeningQuestionaireXml AND @ScreeningQuestionaireXml is not null)
	OR ([ScreeningQuestionsGuid] = @ScreeningQuestionsGuid AND @ScreeningQuestionsGuid is not null)
	OR ([ProcessDate] = @ProcessDate AND @ProcessDate is not null)
	OR ([ProcessException] = @ProcessException AND @ProcessException is not null)
	OR ([ExternalID] = @ExternalId AND @ExternalId is not null)
	SELECT @@ROWCOUNT			
  END
GO

ALTER PROCEDURE [dbo].[JobApplication_Delete]
(

	@JobApplicationId int   
)
AS


				DELETE FROM [dbo].[JobApplication] WITH (ROWLOCK) 
				WHERE
					[JobApplicationID] = @JobApplicationId
GO

ALTER PROCEDURE [dbo].[JobApplication_CustomGetDraftJobsByMemberId]                      
(                      
 @MemberID INT,                  
 @PageSize INT,                            
 @PageNumber INT                         
)                      
                      
AS                    
BEGIN                  
                  
DECLARE @SiteID INT                 
                
SET @SiteID = (Select SiteID from Members (NOLOCK) where MemberID = @MemberID)                
                
 IF @PageSize IS NULL                          
  SET @pageSize = 10                          
                          
 IF @PageNumber IS NULL                          
  SET @PageNumber = 1                          
                          
 Declare @pageStart int                          
 Declare @pageEnd int                          
                          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1                          
 SET @PageEnd = (@PageNumber * @PageSize);                        
                  
 WITH JobApplicationJobNameByMember AS                   
(                   
 SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY JobApplication.JobApplicationID DESC) AS RowNumber, JobApplication.JobApplicationID AS JobApplicationID,                   
  Jobs.DatePosted AS DatePosted, JobApplication.MemberID AS MemberID, JobApplication.ApplicationStatus AS ApplicationStatus, JobApplication.URL_Referral AS URLReferral,               
  Jobs.JobID AS JobID, Jobs.JobName AS JobName, Advertisers.AdvertiserID AS AdvertiserID, Advertisers.CompanyName AS CompanyName,      
  '/' + ISNULL((SELECT TOP 1 SiteProfessionFriendlyUrl       
 FROM JobRoles (NOLOCK)                         
  INNER JOIN SiteRoles (NOLOCK)                         
  ON SiteRoles.RoleID = JobRoles.RoleID                      
  AND SiteRoles.SiteID = @SiteID                          
  INNER JOIN Roles (NOLOCK)                         
  ON Roles.RoleID = JobRoles.RoleID                        
  INNER JOIN Profession (NOLOCK)                         
  ON Profession.ProfessionID = Roles.ProfessionID                        
  INNER JOIN SiteProfession (NOLOCK)                         
  ON SiteProfession.ProfessionID = Profession.ProfessionID                       
  AND SiteProfession.SiteID = @SiteID WHERE JobRoles.JobID = JobApplication.JobID),'') + '-jobs/' + ISNULL(Jobs.JobFriendlyName, '') as 'JobFriendlyName'                
 FROM   JobApplication JobApplication                  
 INNER JOIN  Jobs (NOLOCK) ON JobApplication.JobID = Jobs.JobID                      
 INNER JOIN  Advertisers (NOLOCK) ON Advertisers.AdvertiserID = Jobs.AdvertiserID                    
                       
 WHERE  JobApplication.MemberID = @MemberID AND JobApplication.Draft = 1                
 )                  
                  
SELECT JobApplicationID, DatePosted, MemberID, ApplicationStatus, JobID, JobName, JobFriendlyName, AdvertiserID, CompanyName,                  
     (SELECT COUNT(*) FROM JobApplicationJobNameByMember NOLOCK) AS TotalCount                  
FROM    JobApplicationJobNameByMember WITH (NOLOCK)                   
WHERE   MemberID = @MemberID                  
 AND RowNumber >= @PageStart                        
 AND RowNumber <= @PageEnd                        
ORDER BY RowNumber                   
                  
END
GO

ALTER PROCEDURE [dbo].[JobApplication_CustomGetByJobIdMemberId]          
(          
 @JobID INT,          
 @MemberID INT          
)          
AS          
BEGIN          
          
SELECT      
[JobApplicationID],      
[ApplicationDate],      
[JobID],      
[MemberID],      
[MemberResumeFile],      
[MemberCoverLetterFile],      
[ApplicationStatus],      
[JobAppValidateID],      
[SiteID_Referral],      
[URL_Referral],      
[ApplicantGrade],      
[LastViewedDate],      
[FirstName],      
[Surname],      
[EmailAddress],      
[MobilePhone],      
[MemberNote],      
[AdvertiserNote],      
[JobArchiveID],      
[Draft],      
[JobApplicationTypeID],      
[ExternalXMLFilename],      
[ExternalPDFFilename],      
[CustomQuestionnaireXML],    
[FileDownloaded],
AppliedWith,
ScreeningQuestionaireXML,
ScreeningQuestionsGuid,
ProcessDate,
ProcessException,
ExternalID
FROM JobApplication WITH (NOLOCK)          
WHERE JobID = @JobID AND MemberID = @MemberID          
END
GO

ALTER PROCEDURE [dbo].[JobAlerts_Update]
(

	@JobAlertId int   ,

	@JobAlertName nvarchar (510)  ,

	@LastModified datetime   ,

	@SearchKeywords nvarchar (1000)  ,

	@RecurrenceType int   ,

	@DailyFrequency int   ,

	@WeeklyFrequency int   ,

	@WeeklyDayOccurence int   ,

	@DateLastRun datetime   ,

	@DateNextRun datetime   ,

	@MemberId int   ,

	@AlertActive bit   ,

	@EmailFormat int   ,

	@CustomRecurrenceType int   ,

	@LastResultCount int   ,

	@PrimaryAlert bit   ,

	@UnsubscribeValidateId uniqueidentifier   ,

	@EditValidateId uniqueidentifier   ,

	@ViewValidateId uniqueidentifier   ,

	@SiteId int   ,

	@LocationId varchar (500)  ,

	@AreaIds varchar (255)  ,

	@ProfessionId varchar (500)  ,

	@SearchRoleIds varchar (500)  ,

	@WorkTypeIds varchar (100)  ,

	@SalaryIds varchar (50)  ,

	@DaysPosted int   ,

	@GeneratedSql varchar (8000)  ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@CountryId varchar (500)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[JobAlerts]
				SET
					[JobAlertName] = @JobAlertName
					,[LastModified] = @LastModified
					,[SearchKeywords] = @SearchKeywords
					,[RecurrenceType] = @RecurrenceType
					,[DailyFrequency] = @DailyFrequency
					,[WeeklyFrequency] = @WeeklyFrequency
					,[WeeklyDayOccurence] = @WeeklyDayOccurence
					,[DateLastRun] = @DateLastRun
					,[DateNextRun] = @DateNextRun
					,[MemberID] = @MemberId
					,[AlertActive] = @AlertActive
					,[EmailFormat] = @EmailFormat
					,[CustomRecurrenceType] = @CustomRecurrenceType
					,[LastResultCount] = @LastResultCount
					,[PrimaryAlert] = @PrimaryAlert
					,[UnsubscribeValidateID] = @UnsubscribeValidateId
					,[EditValidateID] = @EditValidateId
					,[ViewValidateID] = @ViewValidateId
					,[SiteID] = @SiteId
					,[LocationID] = @LocationId
					,[AreaIDs] = @AreaIds
					,[ProfessionID] = @ProfessionId
					,[SearchRoleIDs] = @SearchRoleIds
					,[WorkTypeIDs] = @WorkTypeIds
					,[SalaryIDs] = @SalaryIds
					,[DaysPosted] = @DaysPosted
					,[GeneratedSQL] = @GeneratedSql
					,[SalaryLowerBand] = @SalaryLowerBand
					,[SalaryUpperBand] = @SalaryUpperBand
					,[CurrencyID] = @CurrencyId
					,[SalaryTypeID] = @SalaryTypeId
					,[CountryID] = @CountryId
				WHERE
[JobAlertID] = @JobAlertId
GO

ALTER PROCEDURE [dbo].[JobAlerts_Insert]
(

	@JobAlertId int    OUTPUT,

	@JobAlertName nvarchar (510)  ,

	@LastModified datetime   ,

	@SearchKeywords nvarchar (1000)  ,

	@RecurrenceType int   ,

	@DailyFrequency int   ,

	@WeeklyFrequency int   ,

	@WeeklyDayOccurence int   ,

	@DateLastRun datetime   ,

	@DateNextRun datetime   ,

	@MemberId int   ,

	@AlertActive bit   ,

	@EmailFormat int   ,

	@CustomRecurrenceType int   ,

	@LastResultCount int   ,

	@PrimaryAlert bit   ,

	@UnsubscribeValidateId uniqueidentifier   ,

	@EditValidateId uniqueidentifier   ,

	@ViewValidateId uniqueidentifier   ,

	@SiteId int   ,

	@LocationId varchar (500)  ,

	@AreaIds varchar (255)  ,

	@ProfessionId varchar (500)  ,

	@SearchRoleIds varchar (500)  ,

	@WorkTypeIds varchar (100)  ,

	@SalaryIds varchar (50)  ,

	@DaysPosted int   ,

	@GeneratedSql varchar (8000)  ,

	@SalaryLowerBand numeric (15, 2)  ,

	@SalaryUpperBand numeric (15, 2)  ,

	@CurrencyId int   ,

	@SalaryTypeId int   ,

	@CountryId varchar (500)  
)
AS


				
				INSERT INTO [dbo].[JobAlerts]
					(
					[JobAlertName]
					,[LastModified]
					,[SearchKeywords]
					,[RecurrenceType]
					,[DailyFrequency]
					,[WeeklyFrequency]
					,[WeeklyDayOccurence]
					,[DateLastRun]
					,[DateNextRun]
					,[MemberID]
					,[AlertActive]
					,[EmailFormat]
					,[CustomRecurrenceType]
					,[LastResultCount]
					,[PrimaryAlert]
					,[UnsubscribeValidateID]
					,[EditValidateID]
					,[ViewValidateID]
					,[SiteID]
					,[LocationID]
					,[AreaIDs]
					,[ProfessionID]
					,[SearchRoleIDs]
					,[WorkTypeIDs]
					,[SalaryIDs]
					,[DaysPosted]
					,[GeneratedSQL]
					,[SalaryLowerBand]
					,[SalaryUpperBand]
					,[CurrencyID]
					,[SalaryTypeID]
					,[CountryID]
					)
				VALUES
					(
					@JobAlertName
					,@LastModified
					,@SearchKeywords
					,@RecurrenceType
					,@DailyFrequency
					,@WeeklyFrequency
					,@WeeklyDayOccurence
					,@DateLastRun
					,@DateNextRun
					,@MemberId
					,@AlertActive
					,@EmailFormat
					,@CustomRecurrenceType
					,@LastResultCount
					,@PrimaryAlert
					,@UnsubscribeValidateId
					,@EditValidateId
					,@ViewValidateId
					,@SiteId
					,@LocationId
					,@AreaIds
					,@ProfessionId
					,@SearchRoleIds
					,@WorkTypeIds
					,@SalaryIds
					,@DaysPosted
					,@GeneratedSql
					,@SalaryLowerBand
					,@SalaryUpperBand
					,@CurrencyId
					,@SalaryTypeId
					,@CountryId
					)
				
				-- Get the identity value
				SET @JobAlertId = SCOPE_IDENTITY()
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [JobAlertID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([JobAlertID])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [JobAlertID]'
				SET @SQL = @SQL + ' FROM [dbo].[JobAlerts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Return paged results
				SELECT O.[JobAlertID], O.[JobAlertName], O.[LastModified], O.[SearchKeywords], O.[RecurrenceType], O.[DailyFrequency], O.[WeeklyFrequency], O.[WeeklyDayOccurence], O.[DateLastRun], O.[DateNextRun], O.[MemberID], O.[AlertActive], O.[EmailFormat], O.[CustomRecurrenceType], O.[LastResultCount], O.[PrimaryAlert], O.[UnsubscribeValidateID], O.[EditValidateID], O.[ViewValidateID], O.[SiteID], O.[LocationID], O.[AreaIDs], O.[ProfessionID], O.[SearchRoleIDs], O.[WorkTypeIDs], O.[SalaryIDs], O.[DaysPosted], O.[GeneratedSQL], O.[SalaryLowerBand], O.[SalaryUpperBand], O.[CurrencyID], O.[SalaryTypeID], O.[CountryID]
				FROM
				    [dbo].[JobAlerts] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[JobAlertID] = PageIndex.[JobAlertID]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[JobAlerts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetBySalaryTypeId]
(

	@SalaryTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[SalaryTypeID] = @SalaryTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetByProfessionId]
(

	@ProfessionId varchar(500) 
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[ProfessionID] = @ProfessionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO


ALTER PROCEDURE [dbo].[JobAlerts_GetByMemberId]
(

	@MemberId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[MemberID] = @MemberId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetByLocationId]
(

	@LocationId varchar(500)   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[LocationID] = @LocationId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO


ALTER PROCEDURE [dbo].[JobAlerts_GetByJobAlertId]
(

	@JobAlertId int   
)
AS


				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[JobAlertID] = @JobAlertId
				SELECT @@ROWCOUNT
GO


ALTER PROCEDURE [dbo].[JobAlerts_GetByCurrencyId]
(

	@CurrencyId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
				WHERE
					[CurrencyID] = @CurrencyId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetByCountryId]
(

	@CountryId varchar(500)   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts] (NOLOCK)
				WHERE
					[CountryId] = @CountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO

ALTER PROCEDURE [dbo].[JobAlerts_GetAllAlertsToRunToday]          
(              
 @SiteID INT              
)              
AS                  
BEGIN              
 DECLARE @today datetime                  
                  
 SET @today = CONVERT(dateTime, CONVERT(varchar, DATEPART(dd, getDate())) + '-' + DATENAME(month, getDate()) + '-' + CONVERT(varchar, DATEPART(yyyy, getDate())))                  
                  
SELECT JobAlertID,              
  JobAlertName,              
  LastModified,              
  SearchKeywords,              
  RecurrenceType,              
  DateNextRun,              
  DateLastRun,      
  ja.MemberID,              
  AlertActive,              
  ja.EmailFormat,              
  UnsubscribeValidateID,              
  EditValidateID,              
  ViewValidateID,              
  ja.SiteID,              
  ja.LocationID,              
  AreaIDs,              
  ProfessionID,              
  SearchRoleIDs,              
  WorkTypeIDs,              
  SalaryIDs,              
  GeneratedSQL,              
  m.FirstName,              
  m.Surname,              
  m.EmailAddress,          
  ja.SalaryLowerBand,          
  ja.SalaryUpperBand,          
  ja.SalaryTypeId,          
  ja.CurrencyID,  
  ja.CountryID,
  m.DefaultLanguageId,          
  m.ReferringSiteID          
FROM JobAlerts ja WITH (NOLOCK)              
INNER JOIN Members m  WITH (NOLOCK)              
ON ja.MemberID = m.MemberID              
WHERE (CONVERT(date, DateNextRun) <= @today OR DateNextRun IS NULL) AND AlertActive = 1 AND ja.SiteID = @SiteID AND m.Valid = 1 AND m.Validated = 1          
END
GO

ALTER PROCEDURE [dbo].[JobAlerts_Get_List]

AS


				
				SELECT
					[JobAlertID],
					[JobAlertName],
					[LastModified],
					[SearchKeywords],
					[RecurrenceType],
					[DailyFrequency],
					[WeeklyFrequency],
					[WeeklyDayOccurence],
					[DateLastRun],
					[DateNextRun],
					[MemberID],
					[AlertActive],
					[EmailFormat],
					[CustomRecurrenceType],
					[LastResultCount],
					[PrimaryAlert],
					[UnsubscribeValidateID],
					[EditValidateID],
					[ViewValidateID],
					[SiteID],
					[LocationID],
					[AreaIDs],
					[ProfessionID],
					[SearchRoleIDs],
					[WorkTypeIDs],
					[SalaryIDs],
					[DaysPosted],
					[GeneratedSQL],
					[SalaryLowerBand],
					[SalaryUpperBand],
					[CurrencyID],
					[SalaryTypeID],
					[CountryID]
				FROM
					[dbo].[JobAlerts]
					
				SELECT @@ROWCOUNT
GO

ALTER PROCEDURE [dbo].[JobAlerts_Find]
(

	@SearchUsingOR bit   = null ,

	@JobAlertId int   = null ,

	@JobAlertName nvarchar (510)  = null ,

	@LastModified datetime   = null ,

	@SearchKeywords nvarchar (1000)  = null ,

	@RecurrenceType int   = null ,

	@DailyFrequency int   = null ,

	@WeeklyFrequency int   = null ,

	@WeeklyDayOccurence int   = null ,

	@DateLastRun datetime   = null ,

	@DateNextRun datetime   = null ,

	@MemberId int   = null ,

	@AlertActive bit   = null ,

	@EmailFormat int   = null ,

	@CustomRecurrenceType int   = null ,

	@LastResultCount int   = null ,

	@PrimaryAlert bit   = null ,

	@UnsubscribeValidateId uniqueidentifier   = null ,

	@EditValidateId uniqueidentifier   = null ,

	@ViewValidateId uniqueidentifier   = null ,

	@SiteId int   = null ,

	@LocationId varchar (500)  = null ,

	@AreaIds varchar (255)  = null ,

	@ProfessionId varchar (500)  = null ,

	@SearchRoleIds varchar (500)  = null ,

	@WorkTypeIds varchar (100)  = null ,

	@SalaryIds varchar (50)  = null ,

	@DaysPosted int   = null ,

	@GeneratedSql varchar (8000)  = null ,

	@SalaryLowerBand numeric (15, 2)  = null ,

	@SalaryUpperBand numeric (15, 2)  = null ,

	@CurrencyId int   = null ,

	@SalaryTypeId int   = null ,

	@CountryId varchar (500)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [JobAlertID]
	, [JobAlertName]
	, [LastModified]
	, [SearchKeywords]
	, [RecurrenceType]
	, [DailyFrequency]
	, [WeeklyFrequency]
	, [WeeklyDayOccurence]
	, [DateLastRun]
	, [DateNextRun]
	, [MemberID]
	, [AlertActive]
	, [EmailFormat]
	, [CustomRecurrenceType]
	, [LastResultCount]
	, [PrimaryAlert]
	, [UnsubscribeValidateID]
	, [EditValidateID]
	, [ViewValidateID]
	, [SiteID]
	, [LocationID]
	, [AreaIDs]
	, [ProfessionID]
	, [SearchRoleIDs]
	, [WorkTypeIDs]
	, [SalaryIDs]
	, [DaysPosted]
	, [GeneratedSQL]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [CountryID]
    FROM
	[dbo].[JobAlerts]
    WHERE 
	 ([JobAlertID] = @JobAlertId OR @JobAlertId IS NULL)
	AND ([JobAlertName] = @JobAlertName OR @JobAlertName IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([SearchKeywords] = @SearchKeywords OR @SearchKeywords IS NULL)
	AND ([RecurrenceType] = @RecurrenceType OR @RecurrenceType IS NULL)
	AND ([DailyFrequency] = @DailyFrequency OR @DailyFrequency IS NULL)
	AND ([WeeklyFrequency] = @WeeklyFrequency OR @WeeklyFrequency IS NULL)
	AND ([WeeklyDayOccurence] = @WeeklyDayOccurence OR @WeeklyDayOccurence IS NULL)
	AND ([DateLastRun] = @DateLastRun OR @DateLastRun IS NULL)
	AND ([DateNextRun] = @DateNextRun OR @DateNextRun IS NULL)
	AND ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([AlertActive] = @AlertActive OR @AlertActive IS NULL)
	AND ([EmailFormat] = @EmailFormat OR @EmailFormat IS NULL)
	AND ([CustomRecurrenceType] = @CustomRecurrenceType OR @CustomRecurrenceType IS NULL)
	AND ([LastResultCount] = @LastResultCount OR @LastResultCount IS NULL)
	AND ([PrimaryAlert] = @PrimaryAlert OR @PrimaryAlert IS NULL)
	AND ([UnsubscribeValidateID] = @UnsubscribeValidateId OR @UnsubscribeValidateId IS NULL)
	AND ([EditValidateID] = @EditValidateId OR @EditValidateId IS NULL)
	AND ([ViewValidateID] = @ViewValidateId OR @ViewValidateId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([LocationID] = @LocationId OR @LocationId IS NULL)
	AND ([AreaIDs] = @AreaIds OR @AreaIds IS NULL)
	AND ([ProfessionID] = @ProfessionId OR @ProfessionId IS NULL)
	AND ([SearchRoleIDs] = @SearchRoleIds OR @SearchRoleIds IS NULL)
	AND ([WorkTypeIDs] = @WorkTypeIds OR @WorkTypeIds IS NULL)
	AND ([SalaryIDs] = @SalaryIds OR @SalaryIds IS NULL)
	AND ([DaysPosted] = @DaysPosted OR @DaysPosted IS NULL)
	AND ([GeneratedSQL] = @GeneratedSql OR @GeneratedSql IS NULL)
	AND ([SalaryLowerBand] = @SalaryLowerBand OR @SalaryLowerBand IS NULL)
	AND ([SalaryUpperBand] = @SalaryUpperBand OR @SalaryUpperBand IS NULL)
	AND ([CurrencyID] = @CurrencyId OR @CurrencyId IS NULL)
	AND ([SalaryTypeID] = @SalaryTypeId OR @SalaryTypeId IS NULL)
	AND ([CountryID] = @CountryId OR @CountryId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [JobAlertID]
	, [JobAlertName]
	, [LastModified]
	, [SearchKeywords]
	, [RecurrenceType]
	, [DailyFrequency]
	, [WeeklyFrequency]
	, [WeeklyDayOccurence]
	, [DateLastRun]
	, [DateNextRun]
	, [MemberID]
	, [AlertActive]
	, [EmailFormat]
	, [CustomRecurrenceType]
	, [LastResultCount]
	, [PrimaryAlert]
	, [UnsubscribeValidateID]
	, [EditValidateID]
	, [ViewValidateID]
	, [SiteID]
	, [LocationID]
	, [AreaIDs]
	, [ProfessionID]
	, [SearchRoleIDs]
	, [WorkTypeIDs]
	, [SalaryIDs]
	, [DaysPosted]
	, [GeneratedSQL]
	, [SalaryLowerBand]
	, [SalaryUpperBand]
	, [CurrencyID]
	, [SalaryTypeID]
	, [CountryID]
    FROM
	[dbo].[JobAlerts]
    WHERE 
	 ([JobAlertID] = @JobAlertId AND @JobAlertId is not null)
	OR ([JobAlertName] = @JobAlertName AND @JobAlertName is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([SearchKeywords] = @SearchKeywords AND @SearchKeywords is not null)
	OR ([RecurrenceType] = @RecurrenceType AND @RecurrenceType is not null)
	OR ([DailyFrequency] = @DailyFrequency AND @DailyFrequency is not null)
	OR ([WeeklyFrequency] = @WeeklyFrequency AND @WeeklyFrequency is not null)
	OR ([WeeklyDayOccurence] = @WeeklyDayOccurence AND @WeeklyDayOccurence is not null)
	OR ([DateLastRun] = @DateLastRun AND @DateLastRun is not null)
	OR ([DateNextRun] = @DateNextRun AND @DateNextRun is not null)
	OR ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([AlertActive] = @AlertActive AND @AlertActive is not null)
	OR ([EmailFormat] = @EmailFormat AND @EmailFormat is not null)
	OR ([CustomRecurrenceType] = @CustomRecurrenceType AND @CustomRecurrenceType is not null)
	OR ([LastResultCount] = @LastResultCount AND @LastResultCount is not null)
	OR ([PrimaryAlert] = @PrimaryAlert AND @PrimaryAlert is not null)
	OR ([UnsubscribeValidateID] = @UnsubscribeValidateId AND @UnsubscribeValidateId is not null)
	OR ([EditValidateID] = @EditValidateId AND @EditValidateId is not null)
	OR ([ViewValidateID] = @ViewValidateId AND @ViewValidateId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([LocationID] = @LocationId AND @LocationId is not null)
	OR ([AreaIDs] = @AreaIds AND @AreaIds is not null)
	OR ([ProfessionID] = @ProfessionId AND @ProfessionId is not null)
	OR ([SearchRoleIDs] = @SearchRoleIds AND @SearchRoleIds is not null)
	OR ([WorkTypeIDs] = @WorkTypeIds AND @WorkTypeIds is not null)
	OR ([SalaryIDs] = @SalaryIds AND @SalaryIds is not null)
	OR ([DaysPosted] = @DaysPosted AND @DaysPosted is not null)
	OR ([GeneratedSQL] = @GeneratedSql AND @GeneratedSql is not null)
	OR ([SalaryLowerBand] = @SalaryLowerBand AND @SalaryLowerBand is not null)
	OR ([SalaryUpperBand] = @SalaryUpperBand AND @SalaryUpperBand is not null)
	OR ([CurrencyID] = @CurrencyId AND @CurrencyId is not null)
	OR ([SalaryTypeID] = @SalaryTypeId AND @SalaryTypeId is not null)
	OR ([CountryID] = @CountryId AND @CountryId is not null)
	SELECT @@ROWCOUNT			
  END
GO

ALTER PROCEDURE [dbo].[JobAlerts_Delete]
(

	@JobAlertId int   
)
AS


				DELETE FROM [dbo].[JobAlerts] WITH (ROWLOCK) 
				WHERE
					[JobAlertID] = @JobAlertId
GO

ALTER PROCEDURE [dbo].[JobAlerts_CustomGetMemberReport]
	@siteid int,    
	@datefrom as date,    
	@dateto as date 
AS    
BEGIN

SELECT ja.SiteID , m.FirstName, m.Surname, m.EmailAddress, ja.JobAlertName, ja.SearchKeywords, sp.SiteProfessionName, ja.SearchRoleIDs, sl.SiteLocationName, ja.AreaIDs, ja.WorkTypeIDs, ja.SalaryTypeID, ja.DaysPosted, ja.LastModified FROM JobAlerts ja WITH (NOLOCK)
INNER JOIN Members m WITH (NOLOCK)
ON ja.MemberID = m.MemberID
INNER JOIN SiteProfession sp WITH (NOLOCK) ON ja.ProfessionID = sp.ProfessionID AND ja.SiteID = sp.SiteId
INNER JOIN SiteLocation sl WITH (NOLOCK) ON ja.LocationID = sl.LocationID AND ja.SiteID = sl.SiteId
WHERE (ja.SiteID = @siteid OR @siteid IS NULL) AND ja.AlertActive = 1 AND (ja.LastModified >= @datefrom OR @datefrom IS NULL) AND (ja.LastModified < DATEADD(DAY, 1, @dateto) OR @dateto IS NULL)


END
GO

ALTER PROCEDURE [dbo].[JobApplication_CustomGetJobApplicationDetails]              
(              
 @ApplicationDate datetime  ,              
 @SiteID int
)              
AS              
BEGIN            
       
	    
	--DECLARE @SiteID INT = 281
	--DECLARE @ApplicationDate datetime = '2014-11-04'           
	DECLARE @AppDate datetime     
	SET @AppDate = dbo.fnGetDate(DATEADD(dd, 0, @ApplicationDate))            
	             
	SELECT j.JobID, j.RefNo, j.JobName, a.AdvertiserID, a.CompanyName, ja.MemberID, ja.FirstName, ja.Surname, ja.URL_Referral, ja.AppliedWith,
	CONVERT(DATE, ApplicationDate) as ApplicationDate
	FROM 
		JobApplication ja (NOLOCK) INNER JOIN Jobs j (NOLOCK)            
			ON ja.JobID = j.JobID AND j.SiteID = @SiteID
		INNER JOIN Advertisers a (NOLOCK) ON a.AdvertiserID = j.AdvertiserID
	WHERE CONVERT(DATE, ApplicationDate) = @AppDate AND ISNULL(ja.Draft,0) = 0  
	
	UNION
	
	SELECT j.JobID, j.RefNo, j.JobName, a.AdvertiserID, a.CompanyName, ja.MemberID, ja.FirstName, ja.Surname, ja.URL_Referral, ja.AppliedWith,
	CONVERT(DATE, ApplicationDate) as ApplicationDate
	FROM 
		JobApplication ja (NOLOCK) INNER JOIN JobsArchive j (NOLOCK)            
			ON ja.JobArchiveID = j.JobID AND j.SiteID = @SiteID
		INNER JOIN Advertisers a (NOLOCK) ON a.AdvertiserID = j.AdvertiserID
	WHERE CONVERT(DATE, ApplicationDate) = @AppDate AND ISNULL(ja.Draft,0) = 0  
	
END
GO

ALTER PROCEDURE [dbo].[JobApplication_CustomUpdateDownloadedFileStatus]
(
	@jobappids NTEXT
)
AS
BEGIN
	UPDATE JobApplication SET FileDownloaded = 1 WHERE JobApplicationID IN (SELECT id FROM [dbo].[ParseIntCSV](@jobappids))	
END
GO

ALTER PROCEDURE [dbo].[JobApplication_CustomGetNewJobApplications]                  
(                  
 @SiteID INT,                        
 @JobApplicationID INT = 0,          
 @AdvertiserUserID INT = 0          
)                  
AS                  
BEGIN             
      
DECLARE @isPrimary BIT = 0        
 DECLARE @AdvertiserID INT = 0        
        
 IF (@AdvertiserUserID > 0)        
 BEGIN        
 SET @isPrimary = (SELECT PrimaryAccount FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)        
 IF(@isPrimary = 1)        
 BEGIN        
  SET @AdvertiserID = (SELECT AdvertiserID FROM AdvertiserUsers (NOLOCK) WHERE AdvertiserUserID = @AdvertiserUserID)         
 END        
 END        
       
 DECLARE @tmpJobApplication AS TABLE(JobApplicationID INT, RefNo VARCHAR(255), JobID INT)      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, j.RefNo, j.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN Jobs j WITH (NOLOCK)                
 ON ja.JobID = j.JobID      
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (j.Expired = 0 OR j.Expired = 1)  AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND j.AdvertiserID = @AdvertiserID) OR (@AdvertiserUserID > 0 AND (j.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (j.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 INSERT INTO @tmpJobApplication       
 SELECT ja.JobApplicationID, jarchive.RefNo, jarchive.JobID      
 FROM JobApplication ja WITH (NOLOCK)                
 INNER JOIN JobsArchive jarchive WITH (NOLOCK)                
 ON ja.JobArchiveID = jarchive.JobID                
 WHERE SiteID_Referral = @SiteID                 
 AND JobApplicationID > ISNULL(@JobApplicationID,0) AND (jarchive.Expired = 0 OR jarchive.Expired = 1) AND Draft = 0              
 AND ((ISNULL(@AdvertiserUserID,0) = 0) OR (@AdvertiserID > 0 AND (jarchive.AdvertiserID = @AdvertiserID)) OR (@AdvertiserUserID > 0 AND  (jarchive.EnteredByAdvertiserUserID = @AdvertiserUserID)))       
 AND (jarchive.ExpiryDate > DATEADD(dd, -180, GETDATE()))            -- 180 days from expiry       
      
 DECLARE @tmpJobApplicationArea AS TABLE(JobID INT, AreaID INT)      
 INSERT INTO @tmpJobApplicationArea      
 SELECT DISTINCT ja.JobID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobID IN (SELECT JobID FROM @tmpJobApplication)       
UNION      
SELECT DISTINCT ja.JobArchiveID, AreaID FROM JobArea ja WITH (NOLOCK)      
 WHERE ja.JobArchiveID IN (SELECT JobID FROM @tmpJobApplication)       
      
      
 DECLARE @tmpJobApplicationAbbr AS TABLE(JobID INT, Abbr NVARCHAR(400))      
 INSERT INTO @tmpJobApplicationAbbr      
 SELECT jaa.JobID, Abbr FROM @tmpJobApplicationArea jaa      
 INNER JOIN Area a  WITH (NOLOCK)                
 ON jaa.AreaID = a.AreaID      
 INNER JOIN Location l  WITH (NOLOCK)                
 ON a.LocationID = l.LocationID                
 INNER JOIN Countries c  WITH (NOLOCK)                
 ON l.CountryID = c.CountryID           
      
 SELECT ja.JobApplicationID, ja.ApplicationDate, m.FirstName, m.Surname, m.EmailAddress, m.MobilePhone, m.PreferredCategoryID, m.PreferredSubCategoryID, ja.MemberResumeFile, ja.MemberCoverLetterFile, ja.ApplicationStatus, c.Abbr, tja.RefNo, tja.JobID, ja.
  
Draft, ja.JobApplicationTypeID, ja.ExternalXMLFilename , ja.ExternalPDFFilename, ja.URL_Referral,ja.AppliedWith, ja.LastViewedDate, ja.MemberID               
 FROM @tmpJobApplication tja       
 INNER JOIN JobApplication ja WITH (NOLOCK)                
 ON tja.JobApplicationID = ja.JobApplicationID      
 INNER JOIN Members m WITH (NOLOCK) ON m.MemberID = ja.MemberID      
 INNER JOIN @tmpJobApplicationAbbr c      
 ON c.JobID = ja.JobID    or c.JobID = ja.JobArchiveID         
       
 ORDER BY ja.JobApplicationID        
      
END
GO
