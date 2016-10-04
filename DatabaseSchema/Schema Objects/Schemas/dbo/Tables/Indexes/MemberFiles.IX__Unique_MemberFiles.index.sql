CREATE UNIQUE NONCLUSTERED INDEX IX_Unique_MemberFiles ON dbo.MemberFiles
(
	MemberID, MemberFileName
) ON [PRIMARY]