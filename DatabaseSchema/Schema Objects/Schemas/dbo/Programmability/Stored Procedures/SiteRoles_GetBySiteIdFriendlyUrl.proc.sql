CREATE PROCEDURE SiteRoles_GetBySiteIdFriendlyUrl  
(  
 @SiteID INT,  
 @FriendlyUrl VARCHAR(255)  
)  
AS  
BEGIN   
 SELECT SiteRoleID, SiteID, RoleID, SiteRoleName, Valid, MetaTitle, MetaKeywords, MetaDescription, Sequence, SiteRoleFriendlyUrl  
 FROM SiteRoles (NOLOCK)  
 WHERE SiteID = @SiteID AND SiteRoleFriendlyUrl = @FriendlyUrl  
END   