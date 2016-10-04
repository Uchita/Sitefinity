CREATE UNIQUE NONCLUSTERED INDEX IX_Folders ON dbo.Folders
(
	SiteID, FolderID, ParentFolderID
) ON [PRIMARY]