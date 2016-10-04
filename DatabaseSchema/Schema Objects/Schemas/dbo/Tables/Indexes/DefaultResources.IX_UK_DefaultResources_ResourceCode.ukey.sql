ALTER TABLE [dbo].[DefaultResources]
    ADD CONSTRAINT [IX_UK_DefaultResources_ResourceCode]
    UNIQUE (ResourceCode)