#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using JXTPortal.Entities;
using JXTPortal.Data;

#endregion

namespace JXTPortal.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="InvoiceOrderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InvoiceOrderProviderBaseCore : EntityProviderBase<JXTPortal.Entities.InvoiceOrder, JXTPortal.Entities.InvoiceOrderKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.InvoiceOrderKey key)
		{
			return Delete(transactionManager, key.OrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _orderId)
		{
			return Delete(null, _orderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _orderId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		FK__InvoiceOr__Adver__16DB3CD9 Description: 
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		public TList<InvoiceOrder> GetByAdvertiserUserId(System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(_advertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		FK__InvoiceOr__Adver__16DB3CD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		/// <remarks></remarks>
		public TList<InvoiceOrder> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		FK__InvoiceOr__Adver__16DB3CD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		public TList<InvoiceOrder> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		fkInvoiceOrAdver16Db3Cd9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		public TList<InvoiceOrder> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		fkInvoiceOrAdver16Db3Cd9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		public TList<InvoiceOrder> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceOr__Adver__16DB3CD9 key.
		///		FK__InvoiceOr__Adver__16DB3CD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceOrder objects.</returns>
		public abstract TList<InvoiceOrder> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override JXTPortal.Entities.InvoiceOrder Get(TransactionManager transactionManager, JXTPortal.Entities.InvoiceOrderKey key, int start, int pageLength)
		{
			return GetByOrderId(transactionManager, key.OrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public JXTPortal.Entities.InvoiceOrder GetByOrderId(System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(null,_orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public JXTPortal.Entities.InvoiceOrder GetByOrderId(System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public JXTPortal.Entities.InvoiceOrder GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public JXTPortal.Entities.InvoiceOrder GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public JXTPortal.Entities.InvoiceOrder GetByOrderId(System.Int32 _orderId, int start, int pageLength, out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceO__C3905BAF14F2F467 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceOrder"/> class.</returns>
		public abstract JXTPortal.Entities.InvoiceOrder GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region InvoiceOrder_Insert 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
			/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success, ref System.Int32? orderId)
		{
			 Insert(null, 0, int.MaxValue , advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success, ref orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
			/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success, ref System.Int32? orderId)
		{
			 Insert(null, start, pageLength , advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success, ref orderId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
			/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success, ref System.Int32? orderId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success, ref orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
			/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success, ref System.Int32? orderId);
		
		#endregion
		
		#region InvoiceOrder_GetByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(int start, int pageLength, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, start, pageLength , advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(transactionManager, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region InvoiceOrder_GetByJobItemTypeId 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByJobItemTypeId(System.Int32? jobItemTypeId)
		{
			 GetByJobItemTypeId(null, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByJobItemTypeId(int start, int pageLength, System.Int32? jobItemTypeId)
		{
			 GetByJobItemTypeId(null, start, pageLength , jobItemTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByJobItemTypeId(TransactionManager transactionManager, System.Int32? jobItemTypeId)
		{
			 GetByJobItemTypeId(transactionManager, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetByJobItemTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId);
		
		#endregion
		
		#region InvoiceOrder_Get_List 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region InvoiceOrder_GetPaged 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region InvoiceOrder_Find 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			return Find(null, start, pageLength , searchUsingOr, orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success);
		
		#endregion
		
		#region InvoiceOrder_Delete 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Delete' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? orderId)
		{
			 Delete(null, 0, int.MaxValue , orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Delete' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? orderId)
		{
			 Delete(null, start, pageLength , orderId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Delete' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? orderId)
		{
			 Delete(transactionManager, 0, int.MaxValue , orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Delete' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? orderId);
		
		#endregion
		
		#region InvoiceOrder_Update 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Update' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			 Update(null, 0, int.MaxValue , orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Update' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			 Update(null, start, pageLength , orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Update' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success)
		{
			 Update(transactionManager, 0, int.MaxValue , orderId, advertiserUserId, createdDate, paymentTypeId, isPayable, isPaid, datePaid, paidByAdvertiserUserId, totalAmount, gst, currencyId, discountAmount, discountGst, responseCode, responseText, bankTransactionId, responseXml, success);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_Update' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paymentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isPayable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePaid"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="paidByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="responseCode"> A <c>System.String</c> instance.</param>
		/// <param name="responseText"> A <c>System.String</c> instance.</param>
		/// <param name="bankTransactionId"> A <c>System.String</c> instance.</param>
		/// <param name="responseXml"> A <c>System.String</c> instance.</param>
		/// <param name="success"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? orderId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.Int32? paymentTypeId, System.Boolean? isPayable, System.Boolean? isPaid, System.DateTime? datePaid, System.Int32? paidByAdvertiserUserId, System.Decimal? totalAmount, System.Decimal? gst, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst, System.String responseCode, System.String responseText, System.String bankTransactionId, System.String responseXml, System.Int32? success);
		
		#endregion
		
		#region InvoiceOrder_GetByOrderId 
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByOrderId(System.Int32? orderId)
		{
			return GetByOrderId(null, 0, int.MaxValue , orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByOrderId(int start, int pageLength, System.Int32? orderId)
		{
			return GetByOrderId(null, start, pageLength , orderId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByOrderId(TransactionManager transactionManager, System.Int32? orderId)
		{
			return GetByOrderId(transactionManager, 0, int.MaxValue , orderId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceOrder_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByOrderId(TransactionManager transactionManager, int start, int pageLength , System.Int32? orderId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;InvoiceOrder&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;InvoiceOrder&gt;"/></returns>
		public static TList<InvoiceOrder> Fill(IDataReader reader, TList<InvoiceOrder> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				JXTPortal.Entities.InvoiceOrder c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("InvoiceOrder")
					.Append("|").Append((System.Int32)reader[((int)InvoiceOrderColumn.OrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<InvoiceOrder>(
					key.ToString(), // EntityTrackingKey
					"InvoiceOrder",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.InvoiceOrder();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.OrderId = (System.Int32)reader[((int)InvoiceOrderColumn.OrderId - 1)];
					c.AdvertiserUserId = (System.Int32)reader[((int)InvoiceOrderColumn.AdvertiserUserId - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)InvoiceOrderColumn.CreatedDate - 1)];
					c.PaymentTypeId = (reader.IsDBNull(((int)InvoiceOrderColumn.PaymentTypeId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.PaymentTypeId - 1)];
					c.IsPayable = (System.Boolean)reader[((int)InvoiceOrderColumn.IsPayable - 1)];
					c.IsPaid = (System.Boolean)reader[((int)InvoiceOrderColumn.IsPaid - 1)];
					c.DatePaid = (reader.IsDBNull(((int)InvoiceOrderColumn.DatePaid - 1)))?null:(System.DateTime?)reader[((int)InvoiceOrderColumn.DatePaid - 1)];
					c.PaidByAdvertiserUserId = (reader.IsDBNull(((int)InvoiceOrderColumn.PaidByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.PaidByAdvertiserUserId - 1)];
					c.TotalAmount = (System.Decimal)reader[((int)InvoiceOrderColumn.TotalAmount - 1)];
					c.Gst = (System.Decimal)reader[((int)InvoiceOrderColumn.Gst - 1)];
					c.CurrencyId = (reader.IsDBNull(((int)InvoiceOrderColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.CurrencyId - 1)];
					c.DiscountAmount = (reader.IsDBNull(((int)InvoiceOrderColumn.DiscountAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceOrderColumn.DiscountAmount - 1)];
					c.DiscountGst = (reader.IsDBNull(((int)InvoiceOrderColumn.DiscountGst - 1)))?null:(System.Decimal?)reader[((int)InvoiceOrderColumn.DiscountGst - 1)];
					c.ResponseCode = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseCode - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseCode - 1)];
					c.ResponseText = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseText - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseText - 1)];
					c.BankTransactionId = (reader.IsDBNull(((int)InvoiceOrderColumn.BankTransactionId - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.BankTransactionId - 1)];
					c.ResponseXml = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseXml - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseXml - 1)];
					c.Success = (reader.IsDBNull(((int)InvoiceOrderColumn.Success - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.Success - 1)];
					c.CardName = (reader.IsDBNull(((int)InvoiceOrderColumn.CardName - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.CardName - 1)];
					c.CardNumber = (reader.IsDBNull(((int)InvoiceOrderColumn.CardNumber - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.CardNumber - 1)];
					c.ExpiryMonth = (reader.IsDBNull(((int)InvoiceOrderColumn.ExpiryMonth - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.ExpiryMonth - 1)];
					c.ExpiryYear = (reader.IsDBNull(((int)InvoiceOrderColumn.ExpiryYear - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.ExpiryYear - 1)];
					c.Cvv = (reader.IsDBNull(((int)InvoiceOrderColumn.Cvv - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.Cvv - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.InvoiceOrder"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceOrder"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.InvoiceOrder entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader[((int)InvoiceOrderColumn.OrderId - 1)];
			entity.AdvertiserUserId = (System.Int32)reader[((int)InvoiceOrderColumn.AdvertiserUserId - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)InvoiceOrderColumn.CreatedDate - 1)];
			entity.PaymentTypeId = (reader.IsDBNull(((int)InvoiceOrderColumn.PaymentTypeId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.PaymentTypeId - 1)];
			entity.IsPayable = (System.Boolean)reader[((int)InvoiceOrderColumn.IsPayable - 1)];
			entity.IsPaid = (System.Boolean)reader[((int)InvoiceOrderColumn.IsPaid - 1)];
			entity.DatePaid = (reader.IsDBNull(((int)InvoiceOrderColumn.DatePaid - 1)))?null:(System.DateTime?)reader[((int)InvoiceOrderColumn.DatePaid - 1)];
			entity.PaidByAdvertiserUserId = (reader.IsDBNull(((int)InvoiceOrderColumn.PaidByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.PaidByAdvertiserUserId - 1)];
			entity.TotalAmount = (System.Decimal)reader[((int)InvoiceOrderColumn.TotalAmount - 1)];
			entity.Gst = (System.Decimal)reader[((int)InvoiceOrderColumn.Gst - 1)];
			entity.CurrencyId = (reader.IsDBNull(((int)InvoiceOrderColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.CurrencyId - 1)];
			entity.DiscountAmount = (reader.IsDBNull(((int)InvoiceOrderColumn.DiscountAmount - 1)))?null:(System.Decimal?)reader[((int)InvoiceOrderColumn.DiscountAmount - 1)];
			entity.DiscountGst = (reader.IsDBNull(((int)InvoiceOrderColumn.DiscountGst - 1)))?null:(System.Decimal?)reader[((int)InvoiceOrderColumn.DiscountGst - 1)];
			entity.ResponseCode = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseCode - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseCode - 1)];
			entity.ResponseText = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseText - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseText - 1)];
			entity.BankTransactionId = (reader.IsDBNull(((int)InvoiceOrderColumn.BankTransactionId - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.BankTransactionId - 1)];
			entity.ResponseXml = (reader.IsDBNull(((int)InvoiceOrderColumn.ResponseXml - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.ResponseXml - 1)];
			entity.Success = (reader.IsDBNull(((int)InvoiceOrderColumn.Success - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.Success - 1)];
			entity.CardName = (reader.IsDBNull(((int)InvoiceOrderColumn.CardName - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.CardName - 1)];
			entity.CardNumber = (reader.IsDBNull(((int)InvoiceOrderColumn.CardNumber - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.CardNumber - 1)];
			entity.ExpiryMonth = (reader.IsDBNull(((int)InvoiceOrderColumn.ExpiryMonth - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.ExpiryMonth - 1)];
			entity.ExpiryYear = (reader.IsDBNull(((int)InvoiceOrderColumn.ExpiryYear - 1)))?null:(System.Int32?)reader[((int)InvoiceOrderColumn.ExpiryYear - 1)];
			entity.Cvv = (reader.IsDBNull(((int)InvoiceOrderColumn.Cvv - 1)))?null:(System.String)reader[((int)InvoiceOrderColumn.Cvv - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.InvoiceOrder"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceOrder"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.InvoiceOrder entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderID"];
			entity.AdvertiserUserId = (System.Int32)dataRow["AdvertiserUserID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.PaymentTypeId = Convert.IsDBNull(dataRow["PaymentTypeID"]) ? null : (System.Int32?)dataRow["PaymentTypeID"];
			entity.IsPayable = (System.Boolean)dataRow["IsPayable"];
			entity.IsPaid = (System.Boolean)dataRow["IsPaid"];
			entity.DatePaid = Convert.IsDBNull(dataRow["DatePaid"]) ? null : (System.DateTime?)dataRow["DatePaid"];
			entity.PaidByAdvertiserUserId = Convert.IsDBNull(dataRow["PaidByAdvertiserUserID"]) ? null : (System.Int32?)dataRow["PaidByAdvertiserUserID"];
			entity.TotalAmount = (System.Decimal)dataRow["TotalAmount"];
			entity.Gst = (System.Decimal)dataRow["GST"];
			entity.CurrencyId = Convert.IsDBNull(dataRow["CurrencyID"]) ? null : (System.Int32?)dataRow["CurrencyID"];
			entity.DiscountAmount = Convert.IsDBNull(dataRow["DiscountAmount"]) ? null : (System.Decimal?)dataRow["DiscountAmount"];
			entity.DiscountGst = Convert.IsDBNull(dataRow["DiscountGST"]) ? null : (System.Decimal?)dataRow["DiscountGST"];
			entity.ResponseCode = Convert.IsDBNull(dataRow["responseCode"]) ? null : (System.String)dataRow["responseCode"];
			entity.ResponseText = Convert.IsDBNull(dataRow["responseText"]) ? null : (System.String)dataRow["responseText"];
			entity.BankTransactionId = Convert.IsDBNull(dataRow["bankTransactionID"]) ? null : (System.String)dataRow["bankTransactionID"];
			entity.ResponseXml = Convert.IsDBNull(dataRow["ResponseXML"]) ? null : (System.String)dataRow["ResponseXML"];
			entity.Success = Convert.IsDBNull(dataRow["Success"]) ? null : (System.Int32?)dataRow["Success"];
			entity.CardName = Convert.IsDBNull(dataRow["CardName"]) ? null : (System.String)dataRow["CardName"];
			entity.CardNumber = Convert.IsDBNull(dataRow["CardNumber"]) ? null : (System.String)dataRow["CardNumber"];
			entity.ExpiryMonth = Convert.IsDBNull(dataRow["ExpiryMonth"]) ? null : (System.Int32?)dataRow["ExpiryMonth"];
			entity.ExpiryYear = Convert.IsDBNull(dataRow["ExpiryYear"]) ? null : (System.Int32?)dataRow["ExpiryYear"];
			entity.Cvv = Convert.IsDBNull(dataRow["CVV"]) ? null : (System.String)dataRow["CVV"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceOrder"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.InvoiceOrder Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.InvoiceOrder entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserUserIdSource	
			if (CanDeepLoad(entity, "AdvertiserUsers|AdvertiserUserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserUserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserUserId;
				AdvertiserUsers tmpEntity = EntityManager.LocateEntity<AdvertiserUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserUserIdSource = tmpEntity;
				else
					entity.AdvertiserUserIdSource = DataRepository.AdvertiserUsersProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserUserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserUsersProvider.DeepLoad(transactionManager, entity.AdvertiserUserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserUserIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOrderId methods when available
			
			#region InvoiceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Invoice>|InvoiceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceCollection = DataRepository.InvoiceProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.InvoiceCollection.Count > 0)
				{
					deepHandles.Add("InvoiceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Invoice>) DataRepository.InvoiceProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the JXTPortal.Entities.InvoiceOrder object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.InvoiceOrder instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.InvoiceOrder Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.InvoiceOrder entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdvertiserUserIdSource
			if (CanDeepSave(entity, "AdvertiserUsers|AdvertiserUserIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserUserIdSource != null)
			{
				DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUserIdSource);
				entity.AdvertiserUserId = entity.AdvertiserUserIdSource.AdvertiserUserId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Invoice>
				if (CanDeepSave(entity.InvoiceCollection, "List<Invoice>|InvoiceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Invoice child in entity.InvoiceCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.OrderId;
						}
						else
						{
							child.OrderId = entity.OrderId;
						}

					}

					if (entity.InvoiceCollection.Count > 0 || entity.InvoiceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceProvider.Save(transactionManager, entity.InvoiceCollection);
						
						deepHandles.Add("InvoiceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Invoice >) DataRepository.InvoiceProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region InvoiceOrderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.InvoiceOrder</c>
	///</summary>
	public enum InvoiceOrderChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at AdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
	
		///<summary>
		/// Collection of <c>InvoiceOrder</c> as OneToMany for InvoiceCollection
		///</summary>
		[ChildEntityType(typeof(TList<Invoice>))]
		InvoiceCollection,
	}
	
	#endregion InvoiceOrderChildEntityTypes
	
	#region InvoiceOrderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InvoiceOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceOrderFilterBuilder : SqlFilterBuilder<InvoiceOrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilterBuilder class.
		/// </summary>
		public InvoiceOrderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceOrderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceOrderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceOrderFilterBuilder
	
	#region InvoiceOrderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InvoiceOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceOrderParameterBuilder : ParameterizedSqlFilterBuilder<InvoiceOrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderParameterBuilder class.
		/// </summary>
		public InvoiceOrderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceOrderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceOrderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceOrderParameterBuilder
	
	#region InvoiceOrderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;InvoiceOrderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceOrder"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class InvoiceOrderSortBuilder : SqlSortBuilder<InvoiceOrderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderSqlSortBuilder class.
		/// </summary>
		public InvoiceOrderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion InvoiceOrderSortBuilder
	
} // end namespace
