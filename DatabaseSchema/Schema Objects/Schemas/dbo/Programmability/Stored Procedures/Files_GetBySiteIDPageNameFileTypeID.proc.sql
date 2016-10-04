CREATE PROCEDURE [dbo].[Files_GetBySiteIDPageNameFileTypeID]    
 @SiteID INT,    
 @PageName VARCHAR(255),    
 @FileTypeID INT    
AS    
    
if (@PageName IS NULL) OR (@PageName = '')     
Begin    
 SELECT Files.[FileID]    
    ,Files.[SiteID]    
    ,Files.[FolderID]    
    ,Files.[FileName]    
    ,Files.[FileSystemName]    
    ,Files.[FileTypeID]    
    ,Files.[LastModified]    
    ,Files.[LastModifiedBy]
	,Files.[SourceID]
 FROM Files WITH (NOLOCK)    
 WHERE Files.SiteID = @SiteID    
  AND Files.[FileTypeID] = @FileTypeID    
End    
Else    
Begin    
 SELECT Files.[FileID]    
    ,Files.[SiteID]    
    ,Files.[FolderID]    
    ,Files.[FileName]    
    ,Files.[FileSystemName]    
    ,Files.[FileTypeID]    
    ,Files.[LastModified]    
    ,Files.[LastModifiedBy] 
	,Files.[SourceID]   
 FROM DynamicPageFiles (NOLOCK) DynamicPageFiles    
 INNER JOIN Files (NOLOCK) Files    
 ON DynamicPageFiles.FileID = Files.FileID    
 WHERE DynamicPageFiles.PageName = @PageName    
 AND DynamicPageFiles.SiteID = @SiteID    
  AND Files.[FileTypeID] = @FileTypeID   
End    
    
SET ANSI_NULLS ON    
    