CREATE TABLE [dbo].[JobApplication]
(
      JobApplicationID          int IDENTITY(1,1) NOT NULL PRIMARY KEY,
      ApplicationDate           SMALLDATETIME,
	  JobID                     int NULL REFERENCES Jobs(JobID),
	  JobArchiveID				INT NULL REFERENCES JobsArchive(JobID),
	  MemberID                  int NULL REFERENCES Members(MemberID),
	  MemberResumeFile              varchar(255) NULL, 
	  MemberCoverLetterFile         varchar(255) NULL, 
	  ApplicationStatus         int NULL DEFAULT (1),
      JobAppValidateID          uniqueidentifier NOT NULL DEFAULT (newid()),
	  SiteID_Referral           int REFERENCES Sites(SiteID) NULL,
      URL_Referral              varchar(255) NULL, 
	  ApplicantGrade            int NULL,
	  LastViewedDate                datetime NULL,
	  FirstName					NVARCHAR(255) NOT NULL,
	  Surname					NVARCHAR(255) NOT NULL,
	  EmailAddress			VARCHAR(255) NOT NULL,
	  MobilePhone			   CHAR(40),
      MemberNote                NVARCHAR(max) NULL,
	 AdvertiserNote            NVARCHAR(max) NULL
)

