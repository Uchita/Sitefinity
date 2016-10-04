﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'MemberWizard' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IMemberWizard 
	{
		/// <summary>			
		/// MemberWizardID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "MemberWizard"</remarks>
		System.Int32 MemberWizardId { get; set; }
				
		
		
		/// <summary>
		/// SiteID : 
		/// </summary>
		System.Int32?  SiteId  { get; set; }
		
		/// <summary>
		/// MemberWizardParentID : 
		/// </summary>
		System.Int32?  MemberWizardParentId  { get; set; }
		
		/// <summary>
		/// ProfileTitle : 
		/// </summary>
		System.String  ProfileTitle  { get; set; }
		
		/// <summary>
		/// CVTitle : 
		/// </summary>
		System.String  CvTitle  { get; set; }
		
		/// <summary>
		/// RolePreferencesTitle : 
		/// </summary>
		System.String  RolePreferencesTitle  { get; set; }
		
		/// <summary>
		/// EducationTitle : 
		/// </summary>
		System.String  EducationTitle  { get; set; }
		
		/// <summary>
		/// MembershipsTitle : 
		/// </summary>
		System.String  MembershipsTitle  { get; set; }
		
		/// <summary>
		/// ExperienceTitle : 
		/// </summary>
		System.String  ExperienceTitle  { get; set; }
		
		/// <summary>
		/// SkillsTitle : 
		/// </summary>
		System.String  SkillsTitle  { get; set; }
		
		/// <summary>
		/// ProfileEnable : 
		/// </summary>
		System.Boolean?  ProfileEnable  { get; set; }
		
		/// <summary>
		/// CVEnable : 
		/// </summary>
		System.Boolean?  CvEnable  { get; set; }
		
		/// <summary>
		/// RolePreferencesEnable : 
		/// </summary>
		System.Boolean?  RolePreferencesEnable  { get; set; }
		
		/// <summary>
		/// EducationEnable : 
		/// </summary>
		System.Boolean?  EducationEnable  { get; set; }
		
		/// <summary>
		/// MembershipsEnable : 
		/// </summary>
		System.Boolean?  MembershipsEnable  { get; set; }
		
		/// <summary>
		/// ExperienceEnable : 
		/// </summary>
		System.Boolean?  ExperienceEnable  { get; set; }
		
		/// <summary>
		/// SkillsEnable : 
		/// </summary>
		System.Boolean?  SkillsEnable  { get; set; }
		
		/// <summary>
		/// GlobalTemplate : 
		/// </summary>
		System.Boolean  GlobalTemplate  { get; set; }
		
		/// <summary>
		/// LastModifiedBy : 
		/// </summary>
		System.Int32  LastModifiedBy  { get; set; }
		
		/// <summary>
		/// LastModified : 
		/// </summary>
		System.DateTime  LastModified  { get; set; }
		
		/// <summary>
		/// DirectorshipTitle : 
		/// </summary>
		System.String  DirectorshipTitle  { get; set; }
		
		/// <summary>
		/// DirectorshipEnable : 
		/// </summary>
		System.Boolean?  DirectorshipEnable  { get; set; }
		
		/// <summary>
		/// Skills : 
		/// </summary>
		System.String  Skills  { get; set; }
		
		/// <summary>
		/// LicenseTypes : 
		/// </summary>
		System.String  LicenseTypes  { get; set; }
		
		/// <summary>
		/// SummaryTitle : 
		/// </summary>
		System.String  SummaryTitle  { get; set; }
		
		/// <summary>
		/// PersonalDetailsTitle : 
		/// </summary>
		System.String  PersonalDetailsTitle  { get; set; }
		
		/// <summary>
		/// LicensesTitle : 
		/// </summary>
		System.String  LicensesTitle  { get; set; }
		
		/// <summary>
		/// AttachCoverLetterTitle : 
		/// </summary>
		System.String  AttachCoverLetterTitle  { get; set; }
		
		/// <summary>
		/// LanguagesTitle : 
		/// </summary>
		System.String  LanguagesTitle  { get; set; }
		
		/// <summary>
		/// ReferencesTitle : 
		/// </summary>
		System.String  ReferencesTitle  { get; set; }
		
		/// <summary>
		/// CustomQuestionTitle : 
		/// </summary>
		System.String  CustomQuestionTitle  { get; set; }
		
		/// <summary>
		/// SummaryPoints : 
		/// </summary>
		System.Int32  SummaryPoints  { get; set; }
		
		/// <summary>
		/// PersonalDetailsPoints : 
		/// </summary>
		System.Int32  PersonalDetailsPoints  { get; set; }
		
		/// <summary>
		/// LicensesPoints : 
		/// </summary>
		System.Int32  LicensesPoints  { get; set; }
		
		/// <summary>
		/// AttachCoverLetterPoints : 
		/// </summary>
		System.Int32  AttachCoverLetterPoints  { get; set; }
		
		/// <summary>
		/// LanguagesPoints : 
		/// </summary>
		System.Int32  LanguagesPoints  { get; set; }
		
		/// <summary>
		/// ReferencesPoints : 
		/// </summary>
		System.Int32  ReferencesPoints  { get; set; }
		
		/// <summary>
		/// CustomQuestionPoints : 
		/// </summary>
		System.Int32  CustomQuestionPoints  { get; set; }
		
		/// <summary>
		/// ProfilePoints : 
		/// </summary>
		System.Int32  ProfilePoints  { get; set; }
		
		/// <summary>
		/// CVPoints : 
		/// </summary>
		System.Int32  CvPoints  { get; set; }
		
		/// <summary>
		/// RolePreferencesPoints : 
		/// </summary>
		System.Int32  RolePreferencesPoints  { get; set; }
		
		/// <summary>
		/// EducationPoints : 
		/// </summary>
		System.Int32  EducationPoints  { get; set; }
		
		/// <summary>
		/// MembershipsPoints : 
		/// </summary>
		System.Int32  MembershipsPoints  { get; set; }
		
		/// <summary>
		/// ExperiencePoints : 
		/// </summary>
		System.Int32  ExperiencePoints  { get; set; }
		
		/// <summary>
		/// SkillsPoints : 
		/// </summary>
		System.Int32  SkillsPoints  { get; set; }
		
		/// <summary>
		/// DirectorshipPoints : 
		/// </summary>
		System.Int32  DirectorshipPoints  { get; set; }
		
		/// <summary>
		/// WizardLanguageXML : 
		/// </summary>
		System.String  WizardLanguageXml  { get; set; }
		
		/// <summary>
		/// CustomQuestionsXML : 
		/// </summary>
		System.String  CustomQuestionsXml  { get; set; }
		
		/// <summary>
		/// MinExperiencesEntry : 
		/// </summary>
		System.Int16  MinExperiencesEntry  { get; set; }
		
		/// <summary>
		/// MinReferencesEntry : 
		/// </summary>
		System.Int16  MinReferencesEntry  { get; set; }
		
		/// <summary>
		/// MinEducationsEntry : 
		/// </summary>
		System.Int16  MinEducationsEntry  { get; set; }
		
		/// <summary>
		/// QualificationNames : 
		/// </summary>
		System.String  QualificationNames  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


