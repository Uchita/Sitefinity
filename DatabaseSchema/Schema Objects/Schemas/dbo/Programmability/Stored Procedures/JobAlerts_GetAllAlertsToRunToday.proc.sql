CREATE PROCEDURE [dbo].[JobAlerts_GetAllAlertsToRunToday]  
(  
 @SiteID INT  
)  
AS      
BEGIN  
 DECLARE @today datetime      
      
 SET @today = CONVERT(dateTime, CONVERT(varchar, DATEPART(dd, getDate())) + '-' + DATENAME(month, getDate()) + '-' + CONVERT(varchar, DATEPART(yyyy, getDate())))      
      
SELECT JobAlertID,  
JobAlertName,  
LastModified,  
SearchKeywords,  
RecurrenceType,  
DateNextRun,  
ja.MemberID,  
AlertActive,  
ja.EmailFormat,  
UnsubscribeValidateID,  
EditValidateID,  
ViewValidateID,  
ja.SiteID,  
ja.CountryId,  
ja.LocationID,  
AreaIDs,  
ProfessionID,  
SearchRoleIDs,  
WorkTypeIDs,  
SalaryIDs,  
GeneratedSQL,  
m.FirstName,  
m.Surname,  
m.EmailAddress  
FROM JobAlerts ja WITH (NOLOCK)  
INNER JOIN Members m  WITH (NOLOCK)  
ON ja.MemberID = m.MemberID  
WHERE DateNextRun <= @today AND AlertActive = 1 AND ja.SiteID = @SiteID  
END