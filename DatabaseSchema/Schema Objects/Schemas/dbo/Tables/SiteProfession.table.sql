CREATE TABLE [dbo].[SiteProfession]
(
	SiteProfessionID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	ProfessionID INT NOT NULL REFERENCES Profession(ProfessionID),
	SiteProfessionName NVARCHAR(510) NOT NULL,
	Valid BIT NOT NULL DEFAULT(1),
	MetaTitle				VARCHAR(255) NOT NULL,
	MetaKeywords			VARCHAR(255) NOT NULL,
	MetaDescription			VARCHAR(512) NOT NULL,
	Sequence INT NOT NULL DEFAULT(0),
	SiteProfessionFriendlyUrl VARCHAR(255) NULL
)
