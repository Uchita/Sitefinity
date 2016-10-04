CREATE UNIQUE NONCLUSTERED INDEX IX_Unique_AdvertiserUsers ON dbo.AdvertiserUsers
(
	UserName, AdvertiserID
) ON [PRIMARY]