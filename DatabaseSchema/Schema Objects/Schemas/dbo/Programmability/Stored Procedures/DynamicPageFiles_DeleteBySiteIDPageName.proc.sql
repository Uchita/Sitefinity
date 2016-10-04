CREATE PROCEDURE [dbo].[DynamicPageFiles_DeleteBySiteIDPageName]
	@SiteId int,
	@PageName varchar (255),
	@FileTypeID int
AS

	DELETE FROM 
		DynamicPageFiles FROM DynamicPageFiles INNER JOIN
		Files ON DynamicPageFiles.FileID = Files.FileID
	WHERE
		(DynamicPageFiles.SiteID = @SiteId) AND 
		(DynamicPageFiles.PageName = @PageName)	AND 
		(Files.FileTypeID = @FileTypeID)

RETURN 0