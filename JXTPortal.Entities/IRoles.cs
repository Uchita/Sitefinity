﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'Roles' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IRoles 
	{
		/// <summary>			
		/// RoleID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Roles"</remarks>
		System.Int32 RoleId { get; set; }
				
		
		
		/// <summary>
		/// ProfessionID : 
		/// </summary>
		System.Int32  ProfessionId  { get; set; }
		
		/// <summary>
		/// RoleName : 
		/// </summary>
		System.String  RoleName  { get; set; }
		
		/// <summary>
		/// Valid : 
		/// </summary>
		System.Boolean  Valid  { get; set; }
		
		/// <summary>
		/// MetaTitle : 
		/// </summary>
		System.String  MetaTitle  { get; set; }
		
		/// <summary>
		/// MetaKeywords : 
		/// </summary>
		System.String  MetaKeywords  { get; set; }
		
		/// <summary>
		/// MetaDescription : 
		/// </summary>
		System.String  MetaDescription  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _siteRolesRoleId
		/// </summary>	
		TList<SiteRoles> SiteRolesCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _jobRolesRoleId
		/// </summary>	
		TList<JobRoles> JobRolesCollection {  get;  set;}	

		#endregion Data Properties

	}
}


