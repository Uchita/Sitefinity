CREATE TABLE [dbo].[JobApplicationNotes](
    [JobApplicationNoteID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [AdvertiserUserID] [int] NOT NULL REFERENCES AdvertiserUsers(AdvertiserUserID),
    [MemberID] [int] NOT NULL REFERENCES Members(MemberID),
    [JobApplicationID] [int] NOT NULL REFERENCES JobApplication(JobApplicationID),
    [Note] [NTEXT] NOT NULL)