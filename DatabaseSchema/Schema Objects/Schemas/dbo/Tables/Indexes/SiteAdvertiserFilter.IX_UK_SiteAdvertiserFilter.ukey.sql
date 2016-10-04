ALTER TABLE [dbo].[SiteAdvertiserFilter]
    ADD CONSTRAINT [IX_UK_SiteAdvertiserFilter]
    UNIQUE (SiteID, AdvertiserID)