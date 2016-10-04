ALTER TABLE [dbo].[JobViews]
    ADD CONSTRAINT [IX_UK_JobViews]
    UNIQUE (SiteID, JobID, JobArchiveID, ViewDate)
