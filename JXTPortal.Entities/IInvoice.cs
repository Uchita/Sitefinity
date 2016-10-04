﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'Invoice' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IInvoice 
	{
		/// <summary>			
		/// InvoiceID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Invoice"</remarks>
		System.Int32 InvoiceId { get; set; }
				
		
		
		/// <summary>
		/// AdvertiserUserID : 
		/// </summary>
		System.Int32  AdvertiserUserId  { get; set; }
		
		/// <summary>
		/// OrderID : 
		/// </summary>
		System.Int32  OrderId  { get; set; }
		
		/// <summary>
		/// JobItemTypeID : 
		/// </summary>
		System.Int32  JobItemTypeId  { get; set; }
		
		/// <summary>
		/// TotalNumberOfJobs : 
		/// </summary>
		System.Int32  TotalNumberOfJobs  { get; set; }
		
		/// <summary>
		/// TotalAmount : 
		/// </summary>
		System.Decimal  TotalAmount  { get; set; }
		
		/// <summary>
		/// Description : 
		/// </summary>
		System.String  Description  { get; set; }
		
		/// <summary>
		/// Quantity : 
		/// </summary>
		System.Int32  Quantity  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _invoiceItemInvoiceId
		/// </summary>	
		TList<InvoiceItem> InvoiceItemCollection {  get;  set;}	

		#endregion Data Properties

	}
}


