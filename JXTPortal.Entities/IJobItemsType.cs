﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'JobItemsType' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IJobItemsType 
	{
		/// <summary>			
		/// JobItemTypeID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "JobItemsType"</remarks>
		System.Int32 JobItemTypeId { get; set; }
				
		
		
		/// <summary>
		/// SiteID : 
		/// </summary>
		System.Int32  SiteId  { get; set; }
		
		/// <summary>
		/// JobItemTypeParentID : 
		/// </summary>
		System.Int32  JobItemTypeParentId  { get; set; }
		
		/// <summary>
		/// JobItemTypeDescription : 
		/// </summary>
		System.String  JobItemTypeDescription  { get; set; }
		
		/// <summary>
		/// LastModifiedBy : 
		/// </summary>
		System.Int32  LastModifiedBy  { get; set; }
		
		/// <summary>
		/// LastModified : 
		/// </summary>
		System.DateTime  LastModified  { get; set; }
		
		/// <summary>
		/// TotalAmount : 
		/// </summary>
		System.Decimal?  TotalAmount  { get; set; }
		
		/// <summary>
		/// DaysActive : 
		/// </summary>
		System.Int32  DaysActive  { get; set; }
		
		/// <summary>
		/// Sequence : 
		/// </summary>
		System.Int32  Sequence  { get; set; }
		
		/// <summary>
		/// Valid : 
		/// </summary>
		System.Boolean  Valid  { get; set; }
		
		/// <summary>
		/// DiscountAmount : 
		/// </summary>
		System.Decimal?  DiscountAmount  { get; set; }
		
		/// <summary>
		/// TotalNumberOfJobs : 
		/// </summary>
		System.Int32  TotalNumberOfJobs  { get; set; }
		
		/// <summary>
		/// ShortDescription : 
		/// </summary>
		System.String  ShortDescription  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table advertiserIdAdvertisersCollectionFromAdvertiserJobPricing
		/// </summary>	
		TList<Advertisers> AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _advertiserJobPricingJobItemsTypeId
		/// </summary>	
		TList<AdvertiserJobPricing> AdvertiserJobPricingCollection {  get;  set;}	

		#endregion Data Properties

	}
}


