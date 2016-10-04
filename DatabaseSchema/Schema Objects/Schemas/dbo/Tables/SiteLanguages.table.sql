CREATE TABLE [dbo].[SiteLanguages]
(
	SiteLanguageID int IDENTITY(1,1) PRIMARY KEY, 
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	LanguageID INT NOT NULL REFERENCES Languages(LanguageID),
	SiteLanguageName NVARCHAR(255) NOT NULL
)
