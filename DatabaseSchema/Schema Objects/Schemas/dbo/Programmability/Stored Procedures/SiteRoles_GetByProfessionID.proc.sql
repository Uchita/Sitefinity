CREATE PROCEDURE [dbo].[SiteRoles_GetByProfessionID]
	@SiteID int, 
	@ProfessionID int
AS
	SELECT [SiteRoles].[SiteRoleID]
      ,[SiteRoles].[SiteID]
      ,[SiteRoles].[RoleID]
      ,[SiteRoles].[SiteRoleName]
      ,[SiteRoles].[Valid]
      ,[SiteRoles].[MetaTitle]
      ,[SiteRoles].[MetaKeywords]
      ,[SiteRoles].[MetaDescription]
      ,[SiteRoles].[Sequence]
      ,[SiteRoles].[SiteRoleFriendlyUrl]
   FROM [dbo].[SiteRoles] (NOLOCK) SiteRoles
   INNER JOIN [dbo].[Roles] (NOLOCK)Roles
   ON [SiteRoles].[RoleID] = [Roles].[RoleID]
   AND [SiteRoles].[SiteID] = @SiteID
   WHERE [Roles].ProfessionID = @ProfessionID