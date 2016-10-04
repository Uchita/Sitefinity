CREATE PROCEDURE dbo.MemberFiles_GetPagingByMemberId  
(   
 @MemberId INT,  
 @PageSize INT,            
 @PageNumber INT        
)    
AS    
BEGIN  
  
 IF @PageSize IS NULL          
  SET @pageSize = 10          
          
 IF @PageNumber IS NULL          
  SET @PageNumber = 1          
          
 Declare @pageStart int          
 Declare @pageEnd int          
          
 SET @PageStart = (@PageNumber - 1) * @PageSize + 1          
 SET @PageEnd = (@PageNumber * @PageSize)         
        
 DECLARE @tmpGetPagingByMemberId TABLE         
 (        
   MemberId INT NOT NULL PRIMARY KEY,         
   RowNumber INT NOT NULL        
 )  
  
 INSERT INTO @tmpGetPagingByMemberId  
  
 SELECT MemberId, ROW_NUMBER() OVER (ORDER BY MemberId) AS RowNumber  
 FROM   MemberFiles WITH (NOLOCK)  
 WHERE  (MemberId = @MemberId)  
  
    
 SELECT MemberFiles.MemberFileID, MemberFiles.MemberID, MemberFiles.MemberFileTypeID, MemberFiles.MemberFileName,   
  MemberFiles.MemberFileSearchExtension, MemberFiles.MemberFileContent,  MemberFiles.MemberFileTitle,   
  MemberFiles.LastModifiedDate, MemberFiles.DocumentTypeID,   
  GetPagingByMemberId.RowNumber AS RowNumber,  
  (SELECT COUNT(1) FROM @tmpGetPagingByMemberId) AS TotalCount  
 FROM   MemberFiles MemberFiles(NOLOCK)  
 INNER JOIN @tmpGetPagingByMemberId GetPagingByMemberId   
   ON MemberFiles.MemberID = GetPagingByMemberId.MemberID  
 WHERE  MemberFiles.MemberId = @MemberId    
   
END