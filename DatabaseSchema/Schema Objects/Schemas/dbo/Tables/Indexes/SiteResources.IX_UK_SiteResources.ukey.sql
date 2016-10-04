ALTER TABLE [dbo].[SiteResources]
    ADD CONSTRAINT [IX_UK_SiteResources]
    UNIQUE (SiteID, LanguageID, ResourceCode)