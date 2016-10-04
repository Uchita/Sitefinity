﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'SiteResourcesXML' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISiteResourcesXml 
	{
		/// <summary>			
		/// SiteResourceXMLID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "SiteResourcesXML"</remarks>
		System.Int32 SiteResourceXmlid { get; set; }
				
		
		
		/// <summary>
		/// SiteID : 
		/// </summary>
		System.Int32  SiteId  { get; set; }
		
		/// <summary>
		/// LanguageID : 
		/// </summary>
		System.Int32  LanguageId  { get; set; }
		
		/// <summary>
		/// ResourceType : 
		/// </summary>
		System.Int32  ResourceType  { get; set; }
		
		/// <summary>
		/// ResourceXML : 
		/// </summary>
		System.String  ResourceXml  { get; set; }
		
		/// <summary>
		/// LastModified : 
		/// </summary>
		System.DateTime?  LastModified  { get; set; }
		
		/// <summary>
		/// LastModifiedBy : 
		/// </summary>
		System.Int32?  LastModifiedBy  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


