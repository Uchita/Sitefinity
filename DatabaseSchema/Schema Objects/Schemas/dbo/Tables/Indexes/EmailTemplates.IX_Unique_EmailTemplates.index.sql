CREATE UNIQUE NONCLUSTERED INDEX IX_Unique_EmailTemplates ON dbo.EmailTemplates
(
	SiteID, EmailCode, GlobalTemplate
) ON [PRIMARY]

