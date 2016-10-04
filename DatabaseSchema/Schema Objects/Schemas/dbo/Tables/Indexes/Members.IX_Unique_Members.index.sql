CREATE UNIQUE NONCLUSTERED INDEX IX_Unique_Members ON dbo.Members
(
	SiteID, EmailAddress
) ON [PRIMARY]