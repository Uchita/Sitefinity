﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'SiteLocation' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISiteLocation 
	{
		/// <summary>			
		/// SiteLocationID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "SiteLocation"</remarks>
		System.Int32 SiteLocationId { get; set; }
				
		
		
		/// <summary>
		/// LocationID : 
		/// </summary>
		System.Int32  LocationId  { get; set; }
		
		/// <summary>
		/// SiteID : 
		/// </summary>
		System.Int32  SiteId  { get; set; }
		
		/// <summary>
		/// SiteLocationName : 
		/// </summary>
		System.String  SiteLocationName  { get; set; }
		
		/// <summary>
		/// Valid : 
		/// </summary>
		System.Boolean  Valid  { get; set; }
		
		/// <summary>
		/// SiteLocationFriendlyUrl : 
		/// </summary>
		System.String  SiteLocationFriendlyUrl  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


