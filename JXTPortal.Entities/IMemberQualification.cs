﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'MemberQualification' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IMemberQualification 
	{
		/// <summary>			
		/// MemberQualificationId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "MemberQualification"</remarks>
		System.Int32 MemberQualificationId { get; set; }
				
		
		
		/// <summary>
		/// LinkedInInternalEducationId : 
		/// </summary>
		System.Int32?  LinkedInInternalEducationId  { get; set; }
		
		/// <summary>
		/// SchoolName : 
		/// </summary>
		System.String  SchoolName  { get; set; }
		
		/// <summary>
		/// FieldOfStudy : 
		/// </summary>
		System.String  FieldOfStudy  { get; set; }
		
		/// <summary>
		/// StartYear : 
		/// </summary>
		System.Int32?  StartYear  { get; set; }
		
		/// <summary>
		/// EndYear : 
		/// </summary>
		System.Int32?  EndYear  { get; set; }
		
		/// <summary>
		/// Degree : 
		/// </summary>
		System.String  Degree  { get; set; }
		
		/// <summary>
		/// Activities : 
		/// </summary>
		System.String  Activities  { get; set; }
		
		/// <summary>
		/// Notes : 
		/// </summary>
		System.String  Notes  { get; set; }
		
		/// <summary>
		/// MemberID : 
		/// </summary>
		System.Int32  MemberId  { get; set; }
		
		/// <summary>
		/// City : 
		/// </summary>
		System.String  City  { get; set; }
		
		/// <summary>
		/// CountryID : 
		/// </summary>
		System.Int32?  CountryId  { get; set; }
		
		/// <summary>
		/// QualificationLevelID : 
		/// </summary>
		System.Int32?  QualificationLevelId  { get; set; }
		
		/// <summary>
		/// QualificationLevelOther : 
		/// </summary>
		System.String  QualificationLevelOther  { get; set; }
		
		/// <summary>
		/// Major : 
		/// </summary>
		System.String  Major  { get; set; }
		
		/// <summary>
		/// Present : 
		/// </summary>
		System.Boolean?  Present  { get; set; }
		
		/// <summary>
		/// StartMonth : 
		/// </summary>
		System.Int32?  StartMonth  { get; set; }
		
		/// <summary>
		/// EndMonth : 
		/// </summary>
		System.Int32?  EndMonth  { get; set; }
		
		/// <summary>
		/// Graduated : 
		/// </summary>
		System.Boolean?  Graduated  { get; set; }
		
		/// <summary>
		/// NonGraduatedCredits : 
		/// </summary>
		System.Int32?  NonGraduatedCredits  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


