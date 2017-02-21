ALTER TABLE Sites ADD ArchiveDayThreshold INT NOT NULL DEFAULT 0
GO

ALTER PROCEDURE [dbo].[Jobs_JobsPurge]  
AS    
 SET NOCOUNT ON;    
    -- 21/02/17 - Updated the Purging of jobs to only purge those that expired over 30days ago
 DECLARE @iReturnCode  int,    
   @iNextRowId   int,    
   @iCurrentRowId int,    
            @iLoopControl int    
  
 SELECT @iLoopControl = 1    
    
 SELECT @iNextRowId = MIN(JobID)    
 FROM   Jobs (NOLOCK)    
 WHERE DATEADD(DD, (SELECT ArchiveDayThreshold FROM Sites NOLOCK WHERE SiteId = Jobs.SiteId), ExpiryDate) < CAST(GETDATE() AS DATE)    
     
 IF ISNULL(@iNextRowId,0) = 0    
 BEGIN    
 RETURN    
 END    
    
 SELECT  @iCurrentRowId   = JobID    
 FROM    Jobs (NOLOCK)    
 WHERE   JobID = @iNextRowId    
    
 WHILE @iLoopControl = 1    
 BEGIN    
   SELECT   @iNextRowId = NULL               
    
   -- get the next iRowId    
   SELECT   @iNextRowId = MIN(JobID)    
   FROM     Jobs (NOLOCK)    
   WHERE    JobID > @iCurrentRowId    
   AND   (DATEADD(DD, (SELECT ArchiveDayThreshold FROM Sites NOLOCK WHERE SiteId = Jobs.SiteId), ExpiryDate) < CAST(GETDATE() AS DATE) AND Expired = 0) -- Only live jobs  
      
   --Call the stored proc to archive    
   EXEC Jobs_JobArchive @iCurrentRowId    
  
 -- did we get a valid next row id?    
   IF ISNULL(@iNextRowId,0) = 0    
   BEGIN    
 BREAK    
   END    
    
   --DEBUG    
   --SELECT @iCurrentRowId    
    
   -- get the next row.    
   SELECT  @iCurrentRowId = JobID    
   FROM    Jobs (NOLOCK)    
   WHERE   JobID = @iNextRowId                
    
 END    
 RETURN  
 GO