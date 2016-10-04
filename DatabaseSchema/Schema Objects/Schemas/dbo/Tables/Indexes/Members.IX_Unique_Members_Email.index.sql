CREATE UNIQUE NONCLUSTERED INDEX IX_Unique_Members_Email ON dbo.Members
(
	SiteID, Username
) ON [PRIMARY]