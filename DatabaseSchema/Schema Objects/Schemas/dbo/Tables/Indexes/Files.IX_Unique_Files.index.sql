CREATE UNIQUE INDEX IX_Files ON dbo.Files
(
	FolderID, SiteID, FileName
) ON [PRIMARY]