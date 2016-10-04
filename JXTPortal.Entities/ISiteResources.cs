﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'SiteResources' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISiteResources 
	{
		/// <summary>			
		/// SiteResourceID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "SiteResources"</remarks>
		System.Int32 SiteResourceId { get; set; }
				
		
		
		/// <summary>
		/// SiteID : 
		/// </summary>
		System.Int32  SiteId  { get; set; }
		
		/// <summary>
		/// LanguageID : 
		/// </summary>
		System.Int32  LanguageId  { get; set; }
		
		/// <summary>
		/// ResourceCode : 
		/// </summary>
		System.String  ResourceCode  { get; set; }
		
		/// <summary>
		/// ResourceFileID : 
		/// </summary>
		System.Int32?  ResourceFileId  { get; set; }
		
		/// <summary>
		/// ResourceText : 
		/// </summary>
		System.String  ResourceText  { get; set; }
		
		/// <summary>
		/// LastModified : 
		/// </summary>
		System.DateTime  LastModified  { get; set; }
		
		/// <summary>
		/// LastModifiedBy : 
		/// </summary>
		System.Int32  LastModifiedBy  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


