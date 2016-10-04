CREATE TABLE [dbo].[MemberFileTypes]
(
	MemberFileTypeID INT IDENTITY(1,1) PRIMARY KEY, 
	MemberFileTypeName VARCHAR(255) NOT NULL,
	MemberFileExtensions VARCHAR(255) NOT NULL
)
