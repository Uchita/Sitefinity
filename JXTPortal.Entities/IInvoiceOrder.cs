﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'InvoiceOrder' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IInvoiceOrder 
	{
		/// <summary>			
		/// OrderID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "InvoiceOrder"</remarks>
		System.Int32 OrderId { get; set; }
				
		
		
		/// <summary>
		/// AdvertiserUserID : 
		/// </summary>
		System.Int32  AdvertiserUserId  { get; set; }
		
		/// <summary>
		/// CreatedDate : 
		/// </summary>
		System.DateTime  CreatedDate  { get; set; }
		
		/// <summary>
		/// PaymentTypeID : 
		/// </summary>
		System.Int32?  PaymentTypeId  { get; set; }
		
		/// <summary>
		/// IsPayable : 
		/// </summary>
		System.Boolean  IsPayable  { get; set; }
		
		/// <summary>
		/// IsPaid : 
		/// </summary>
		System.Boolean  IsPaid  { get; set; }
		
		/// <summary>
		/// DatePaid : 
		/// </summary>
		System.DateTime?  DatePaid  { get; set; }
		
		/// <summary>
		/// PaidByAdvertiserUserID : 
		/// </summary>
		System.Int32?  PaidByAdvertiserUserId  { get; set; }
		
		/// <summary>
		/// TotalAmount : 
		/// </summary>
		System.Decimal  TotalAmount  { get; set; }
		
		/// <summary>
		/// GST : 
		/// </summary>
		System.Decimal  Gst  { get; set; }
		
		/// <summary>
		/// CurrencyID : 
		/// </summary>
		System.Int32?  CurrencyId  { get; set; }
		
		/// <summary>
		/// DiscountAmount : 
		/// </summary>
		System.Decimal?  DiscountAmount  { get; set; }
		
		/// <summary>
		/// DiscountGST : 
		/// </summary>
		System.Decimal?  DiscountGst  { get; set; }
		
		/// <summary>
		/// responseCode : 
		/// </summary>
		System.String  ResponseCode  { get; set; }
		
		/// <summary>
		/// responseText : 
		/// </summary>
		System.String  ResponseText  { get; set; }
		
		/// <summary>
		/// bankTransactionID : 
		/// </summary>
		System.String  BankTransactionId  { get; set; }
		
		/// <summary>
		/// ResponseXML : 
		/// </summary>
		System.String  ResponseXml  { get; set; }
		
		/// <summary>
		/// Success : 
		/// </summary>
		System.Int32?  Success  { get; set; }
		
		/// <summary>
		/// CardName : 
		/// </summary>
		System.String  CardName  { get; set; }
		
		/// <summary>
		/// CardNumber : 
		/// </summary>
		System.String  CardNumber  { get; set; }
		
		/// <summary>
		/// ExpiryMonth : 
		/// </summary>
		System.Int32?  ExpiryMonth  { get; set; }
		
		/// <summary>
		/// ExpiryYear : 
		/// </summary>
		System.Int32?  ExpiryYear  { get; set; }
		
		/// <summary>
		/// CVV : 
		/// </summary>
		System.String  Cvv  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _invoiceOrderId
		/// </summary>	
		TList<Invoice> InvoiceCollection {  get;  set;}	

		#endregion Data Properties

	}
}


