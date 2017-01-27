ALTER TABLE Advertisers
ADD AllowPeopleSearchAccess BIT NOT NULL DEFAULT(0)
GO

DECLARE @tempTable table (siteID int)
INSERT INTO @tempTable
SELECT SiteID FROM GlobalSettings WHERE EnablePeopleSearch = 1

UPDATE Advertisers
SET AllowPeopleSearchAccess = 1
WHERE SiteID in (SELECT siteID FROM @tempTable)

