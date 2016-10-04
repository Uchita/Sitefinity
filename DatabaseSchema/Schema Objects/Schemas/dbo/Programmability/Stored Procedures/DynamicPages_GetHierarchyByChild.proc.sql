CREATE PROCEDURE [dbo].[DynamicPages_GetHierarchyByChild]
(
	@SiteID INT,
	@LanguageID INT,
	@DynamicPageID INT = 0
)
AS
	SET NOCOUNT ON;
	
	WITH Nodes(Id, ParentId, Depth) AS
	(
		-- Start from every node in the @ids collection.
		SELECT DynamicPageID, ParentDynamicPageID , 0 AS DEPTH
		FROM DynamicPages (NOLOCK)
		WHERE DynamicPageID = @DynamicPageID
		
		UNION ALL

		-- Recursively find parent nodes for each starting node.
		SELECT dp.DynamicPageID, dp.ParentDynamicPageID , n.Depth - 1
		FROM DynamicPages dp
		JOIN Nodes n ON dp.DynamicPageID = n.ParentId
		
	)
	SELECT TOP 1 @DynamicPageID = n.Id
	FROM Nodes n
    WHERE n.Id > 0
	GROUP BY n.Id
	ORDER BY MIN(n.Depth) ASC

	EXEC  [dbo].[DynamicPages_GetHierarchy] @SiteID, @LanguageID, @DynamicPageID
	
GO