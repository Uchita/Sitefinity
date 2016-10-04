CREATE PROCEDURE [dbo].[Members_GetMemberPassword]      
      @Username NVARCHAR(510),      
      @EmailAddress VARCHAR(255),      
      @SiteId INT      
AS      
BEGIN   
  
 IF ISNULL(@Username, '') != '' OR ISNULL(@EmailAddress, '') != ''      
 BEGIN      
  SELECT MemberID,  
  SiteID,  
  Username,  
  Password,  
  Title,  
  FirstName,  
  Surname,  
  EmailAddress,  
  '' as [Company],  
  '' as [Position],  
  '' as [HomePhone],  
  '' as [WorkPhone],  
  '' as [MobilePhone],  
  '' as [Fax],  
  '' as [Address1],  
  '' as [Address2],  
  LocationID,  
  AreaID,  
  CountryID,  
  PreferredCategoryID,  
  PreferredSubCategoryID,  
  PreferredSalaryID,  
  Subscribed,  
  MonthlyUpdate,  
  ReferringMemberID,  
  LastModifiedDate,  
  Valid,  
  EmailFormat,  
  LastLogon,  
  DateOfBirth,  
  '' as [Gender],  
  '' as [Tags],  
  Validated,  
  ValidateGUID,  
  '' as [MemberURLExtension],  
  '' as [WebsiteURL],  
  AvailabilityID,  
  AvailabilityFromDate,  
  '' as [MySpaceHeading],  
  '' as [MySpaceContent],  
  '' as [URLReferrer],  
  RequiredPasswordChange,  
  '' as [PreferredJobTitle],  
  '' as [PreferredAvailability],  
  PreferredAvailabilityType,  
  '' as [PreferredSalaryFrom],  
  '' as [PreferredSalaryTo],  
  '' as [CurrentSalaryFrom],  
  '' as [CurrentSalaryTo],  
  '' as [LookingFor],  
  '' as [Experience],  
  '' as [Skills],  
  '' as [Reasons],  
  '' as [Comments],  
  '' as [ProfileType],  
  EducationID,  
  '' as [SearchField]  
  FROM  
 Members WITH(NOLOCK)  
  WHERE (UserName = @Username OR EmailAddress = @EmailAddress) AND SiteID = @SiteId AND Validated = 1  
  
 END      
END