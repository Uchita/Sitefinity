ALTER TABLE [dbo].[SiteLanguages]
    ADD CONSTRAINT [IX_Unique_SiteLanguages]
    UNIQUE (SiteID, LanguageID)