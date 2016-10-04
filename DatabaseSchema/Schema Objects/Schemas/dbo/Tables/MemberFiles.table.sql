CREATE TABLE [dbo].[MemberFiles]
(
	MemberFileID INT IDENTITY(1,1) PRIMARY KEY,
	MemberID INT NOT NULL REFERENCES Members(MemberID), 
	MemberFileTypeID INT NOT NULL REFERENCES MemberFileTypes(MemberFileTypeID),
	MemberFileName NVARCHAR(500) NOT NULL,
	MemberFileSearchExtension VARCHAR(8) NULL,
	MemberFileContent IMAGE,
	MemberFileTitle NVARCHAR(500) NOT NULL,
	LastModifiedDate DATETIME NOT NULL DEFAULT(GETDATE()),
	DocumentTypeID INT
)
