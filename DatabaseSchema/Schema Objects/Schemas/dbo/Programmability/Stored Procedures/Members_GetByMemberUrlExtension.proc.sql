CREATE PROCEDURE [dbo].[Members_GetByKeyword]
(
	@SiteId int,
	@Keyword NVARCHAR(MAX)
)
AS
BEGIN
	SET ANSI_NULLS OFF
	
	SELECT
		[MemberID],
		[SiteID],
		[Username],
		[Password],
		[Title],
		[FirstName],
		[Surname],
		[EmailAddress],
		[Company],
		[Position],
		[HomePhone],
		[WorkPhone],
		[MobilePhone],
		[Fax],
		[Address1],
		[Address2],
		[LocationID],
		[AreaID],
		[CountryID],
		[PreferredCategoryID],
		[PreferredSubCategoryID],
		[PreferredSalaryID],
		[Subscribed],
		[MonthlyUpdate],
		[ReferringMemberID],
		[LastModifiedDate],
		[Valid],
		[EmailFormat],
		[LastLogon],
		[DateOfBirth],
		[Gender],
		[Tags],
		[Validated],
		[ValidateGUID],
		[WebsiteURL],
		[AvailabilityID],
		[AvailabilityFromDate],
		[MySpaceHeading],
		[MySpaceContent],
		[URLReferrer],
		[RequiredPasswordChange],
		[PreferredJobTitle],
		[PreferredAvailability],
		[PreferredAvailabilityType],
		[PreferredSalaryFrom],
		[PreferredSalaryTo],
		[CurrentSalaryFrom],
		[CurrentSalaryTo],
		[LookingFor],
		[Experience],
		[Skills],
		[Reasons],
		[Comments],
		[ProfileType],
		[EducationID]
	FROM
		[dbo].[Members] (NOLOCK)
	WHERE
		[SiteID] = @SiteID
		--AND [MemberURLExtension] = @MemberUrlExtension
END