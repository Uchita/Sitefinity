CREATE TABLE [dbo].[JobsSaved](
[JobSaveID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[JobID] [int] NULL REFERENCES Jobs(JobID),
[JobArchiveID] INT NULL REFERENCES JobsArchive(JobID),
[MemberID] [int] NOT NULL REFERENCES Members(MemberID),
LastModified DATETIME NOT NULL DEFAULT(GETDATE())
)
