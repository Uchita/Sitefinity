/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT 1 FROM SiteWebPartTypes WHERE SiteWebPartName = 'Header')
BEGIN
	INSERT INTO SiteWebPartTypes(SiteWebPartName) VALUES ('Header')
END
GO
IF NOT EXISTS(SELECT 1 FROM SiteWebPartTypes WHERE SiteWebPartName = 'Footer')
BEGIN
	INSERT INTO SiteWebPartTypes(SiteWebPartName) VALUES ('Footer')
END
GO
IF NOT EXISTS(SELECT 1 FROM SiteWebPartTypes WHERE SiteWebPartName = 'Left Navigation')
BEGIN
	INSERT INTO SiteWebPartTypes(SiteWebPartName) VALUES ('Left Navigation')
END
GO