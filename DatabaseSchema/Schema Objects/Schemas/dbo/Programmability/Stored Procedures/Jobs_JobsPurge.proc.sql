CREATE PROCEDURE dbo.Jobs_JobsPurge  
AS  
 SET NOCOUNT ON;  
  
 DECLARE	@iReturnCode  int,  
			@iNextRowId   int,  
			@iCurrentRowId int,  
            @iLoopControl int  
  
 SELECT @iLoopControl = 1  
  
 SELECT @iNextRowId = MIN(JobID)  
 FROM   Jobs (NOLOCK)  
 WHERE ExpiryDate < GETDATE()  
  
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
   AND   ExpiryDate < GETDATE()  
   OR Expired = 1
  
    
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