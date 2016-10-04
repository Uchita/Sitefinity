CREATE TABLE [dbo].[DynamicPages]
(
	DynamicPageID					INT IDENTITY(1,1),
	SiteID							INT NOT NULL,
	LanguageID						INT NOT NULL REFERENCES Languages(LanguageID),
	ParentDynamicPageID				INT NOT NULL DEFAULT(0),
	PageName						VARCHAR(255) NOT NULL,
	PageTitle						VARCHAR(255) NOT NULL,
	PageContent						NTEXT NOT NULL,
	DynamicPageWebPartTemplateID	INT REFERENCES DynamicPageWebPartTemplates(DynamicPageWebPartTemplateID),
	
	HyperLink						VARCHAR(255) NOT NULL,
	Valid							BIT NOT NULL DEFAULT(1),
	OpenInNewWindow					BIT NOT NULL DEFAULT(0),
	Sequence						INT NOT NULL DEFAULT(1),
	FullScreen						BIT NOT NULL DEFAULT(0),
	
	OnTopNav						BIT NOT NULL DEFAULT(0),
	OnLeftNav						BIT NOT NULL DEFAULT(0),
	OnBottomNav						BIT NOT NULL DEFAULT(0),
	OnSiteMap						BIT NOT NULL DEFAULT(0),
	
	Searchable						BIT NOT NULL DEFAULT(0),
	SearchField						NVARCHAR(MAX) NULL,
	MetaKeywords					VARCHAR(255) NOT NULL,
	MetaDescription					VARCHAR(512) NOT NULL,
	PageFriendlyName				VARCHAR(255) NOT NULL,
	
	LastModified					DATETIME NOT NULL DEFAULT(GETDATE()),
	LastModifiedBy					INT NOT NULL REFERENCES AdminUsers(AdminUserID),
	[SourceID] [int] NULL,
	CONSTRAINT [PK_DynamicPages]	PRIMARY KEY CLUSTERED ([DynamicPageID] ASC)
)
