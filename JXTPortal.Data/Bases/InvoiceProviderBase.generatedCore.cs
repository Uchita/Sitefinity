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
	/// This class is the base class for any <see cref="InvoiceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InvoiceProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Invoice, JXTPortal.Entities.InvoiceKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.InvoiceKey key)
		{
			return Delete(transactionManager, key.InvoiceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_invoiceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _invoiceId)
		{
			return Delete(null, _invoiceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _invoiceId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		FK__Invoice__Adverti__3710CDD7 Description: 
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByAdvertiserUserId(System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(_advertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		FK__Invoice__Adverti__3710CDD7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		/// <remarks></remarks>
		public TList<Invoice> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		FK__Invoice__Adverti__3710CDD7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		fkInvoiceAdverti3710Cdd7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		fkInvoiceAdverti3710Cdd7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__Adverti__3710CDD7 key.
		///		FK__Invoice__Adverti__3710CDD7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public abstract TList<Invoice> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		FK__Invoice__OrderID__3804F210 Description: 
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByOrderId(System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(_orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		FK__Invoice__OrderID__3804F210 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		/// <remarks></remarks>
		public TList<Invoice> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		FK__Invoice__OrderID__3804F210 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		fkInvoiceOrderId3804f210 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByOrderId(System.Int32 _orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, _orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		fkInvoiceOrderId3804f210 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public TList<Invoice> GetByOrderId(System.Int32 _orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Invoice__OrderID__3804F210 key.
		///		FK__Invoice__OrderID__3804F210 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Invoice objects.</returns>
		public abstract TList<Invoice> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Invoice Get(TransactionManager transactionManager, JXTPortal.Entities.InvoiceKey key, int start, int pageLength)
		{
			return GetByInvoiceId(transactionManager, key.InvoiceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="_invoiceId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public JXTPortal.Entities.Invoice GetByInvoiceId(System.Int32 _invoiceId)
		{
			int count = -1;
			return GetByInvoiceId(null,_invoiceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public JXTPortal.Entities.Invoice GetByInvoiceId(System.Int32 _invoiceId, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceId(null, _invoiceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public JXTPortal.Entities.Invoice GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId)
		{
			int count = -1;
			return GetByInvoiceId(transactionManager, _invoiceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public JXTPortal.Entities.Invoice GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceId(transactionManager, _invoiceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public JXTPortal.Entities.Invoice GetByInvoiceId(System.Int32 _invoiceId, int start, int pageLength, out int count)
		{
			return GetByInvoiceId(null, _invoiceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Invoice__D796AAD535288565 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Invoice"/> class.</returns>
		public abstract JXTPortal.Entities.Invoice GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Invoice_Insert 
		
		/// <summary>
		///	This method wrap the 'Invoice_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
			/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description, ref System.Int32? invoiceId)
		{
			 Insert(null, 0, int.MaxValue , advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description, ref invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
			/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description, ref System.Int32? invoiceId)
		{
			 Insert(null, start, pageLength , advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description, ref invoiceId);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
			/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description, ref System.Int32? invoiceId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description, ref invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
			/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description, ref System.Int32? invoiceId);
		
		#endregion
		
		#region Invoice_GetByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'Invoice_GetByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'Invoice_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region Invoice_GetByInvoiceId 
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceId(System.Int32? invoiceId)
		{
			return GetByInvoiceId(null, 0, int.MaxValue , invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceId(int start, int pageLength, System.Int32? invoiceId)
		{
			return GetByInvoiceId(null, start, pageLength , invoiceId);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceId(TransactionManager transactionManager, System.Int32? invoiceId)
		{
			return GetByInvoiceId(transactionManager, 0, int.MaxValue , invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByInvoiceId(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceId);
		
		#endregion
		
		#region Invoice_Get_List 
		
		/// <summary>
		///	This method wrap the 'Invoice_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Get_List' stored procedure. 
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
		///	This method wrap the 'Invoice_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Invoice_CustomGetAdvertiserInvoiceReport 
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomGetAdvertiserInvoiceReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="where"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAdvertiserInvoiceReport(System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.Int32? advertiserAccountTypeId, System.Int32? jobItemTypeId, System.String orderId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String where)
		{
			return CustomGetAdvertiserInvoiceReport(null, 0, int.MaxValue , siteId, advertiserId, advertiserUserId, advertiserAccountTypeId, jobItemTypeId, orderId, dateFrom, dateTo, pageIndex, pageSize, orderBy, where);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomGetAdvertiserInvoiceReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="where"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAdvertiserInvoiceReport(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.Int32? advertiserAccountTypeId, System.Int32? jobItemTypeId, System.String orderId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String where)
		{
			return CustomGetAdvertiserInvoiceReport(null, start, pageLength , siteId, advertiserId, advertiserUserId, advertiserAccountTypeId, jobItemTypeId, orderId, dateFrom, dateTo, pageIndex, pageSize, orderBy, where);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_CustomGetAdvertiserInvoiceReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="where"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAdvertiserInvoiceReport(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.Int32? advertiserAccountTypeId, System.Int32? jobItemTypeId, System.String orderId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String where)
		{
			return CustomGetAdvertiserInvoiceReport(transactionManager, 0, int.MaxValue , siteId, advertiserId, advertiserUserId, advertiserAccountTypeId, jobItemTypeId, orderId, dateFrom, dateTo, pageIndex, pageSize, orderBy, where);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomGetAdvertiserInvoiceReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="where"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetAdvertiserInvoiceReport(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.Int32? advertiserAccountTypeId, System.Int32? jobItemTypeId, System.String orderId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String where);
		
		#endregion
		
		#region Invoice_CustomCheckJobCreditCount 
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomCheckJobCreditCount' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomCheckJobCreditCount(System.Int32? advertiserUserId, System.Int32? jobItemTypeId)
		{
			return CustomCheckJobCreditCount(null, 0, int.MaxValue , advertiserUserId, jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomCheckJobCreditCount' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomCheckJobCreditCount(int start, int pageLength, System.Int32? advertiserUserId, System.Int32? jobItemTypeId)
		{
			return CustomCheckJobCreditCount(null, start, pageLength , advertiserUserId, jobItemTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_CustomCheckJobCreditCount' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomCheckJobCreditCount(TransactionManager transactionManager, System.Int32? advertiserUserId, System.Int32? jobItemTypeId)
		{
			return CustomCheckJobCreditCount(transactionManager, 0, int.MaxValue , advertiserUserId, jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomCheckJobCreditCount' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomCheckJobCreditCount(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId, System.Int32? jobItemTypeId);
		
		#endregion
		
		#region Invoice_Find 
		
		/// <summary>
		///	This method wrap the 'Invoice_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			return Find(null, start, pageLength , searchUsingOr, invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description);
		
		#endregion
		
		#region Invoice_Delete 
		
		/// <summary>
		///	This method wrap the 'Invoice_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? invoiceId)
		{
			 Delete(null, 0, int.MaxValue , invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? invoiceId)
		{
			 Delete(null, start, pageLength , invoiceId);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? invoiceId)
		{
			 Delete(transactionManager, 0, int.MaxValue , invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceId);
		
		#endregion
		
		#region Invoice_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Invoice_GetPaged' stored procedure. 
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
		///	This method wrap the 'Invoice_GetPaged' stored procedure. 
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
		///	This method wrap the 'Invoice_GetPaged' stored procedure. 
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
		///	This method wrap the 'Invoice_GetPaged' stored procedure. 
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
		
		#region Invoice_Update 
		
		/// <summary>
		///	This method wrap the 'Invoice_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			 Update(null, 0, int.MaxValue , invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			 Update(null, start, pageLength , invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description)
		{
			 Update(transactionManager, 0, int.MaxValue , invoiceId, advertiserUserId, orderId, jobItemTypeId, totalNumberOfJobs, totalAmount, description);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceId, System.Int32? advertiserUserId, System.Int32? orderId, System.Int32? jobItemTypeId, System.Int32? totalNumberOfJobs, System.Decimal? totalAmount, System.String description);
		
		#endregion
		
		#region Invoice_GetByOrderId 
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByOrderId(System.Int32? orderId)
		{
			return GetByOrderId(null, 0, int.MaxValue , orderId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_GetByOrderId' stored procedure. 
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
		///	This method wrap the 'Invoice_GetByOrderId' stored procedure. 
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
		///	This method wrap the 'Invoice_GetByOrderId' stored procedure. 
		/// </summary>
		/// <param name="orderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByOrderId(TransactionManager transactionManager, int start, int pageLength , System.Int32? orderId);
		
		#endregion
		
		#region Invoice_CustomJobCreditList 
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomJobCreditList' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomJobCreditList(System.Int32? advertiserUserId)
		{
			return CustomJobCreditList(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomJobCreditList' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomJobCreditList(int start, int pageLength, System.Int32? advertiserUserId)
		{
			return CustomJobCreditList(null, start, pageLength , advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'Invoice_CustomJobCreditList' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomJobCreditList(TransactionManager transactionManager, System.Int32? advertiserUserId)
		{
			return CustomJobCreditList(transactionManager, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Invoice_CustomJobCreditList' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomJobCreditList(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Invoice&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Invoice&gt;"/></returns>
		public static TList<Invoice> Fill(IDataReader reader, TList<Invoice> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Invoice c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Invoice")
					.Append("|").Append((System.Int32)reader[((int)InvoiceColumn.InvoiceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Invoice>(
					key.ToString(), // EntityTrackingKey
					"Invoice",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Invoice();
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
					c.InvoiceId = (System.Int32)reader[((int)InvoiceColumn.InvoiceId - 1)];
					c.AdvertiserUserId = (System.Int32)reader[((int)InvoiceColumn.AdvertiserUserId - 1)];
					c.OrderId = (System.Int32)reader[((int)InvoiceColumn.OrderId - 1)];
					c.JobItemTypeId = (System.Int32)reader[((int)InvoiceColumn.JobItemTypeId - 1)];
					c.TotalNumberOfJobs = (System.Int32)reader[((int)InvoiceColumn.TotalNumberOfJobs - 1)];
					c.TotalAmount = (System.Decimal)reader[((int)InvoiceColumn.TotalAmount - 1)];
					c.Description = (reader.IsDBNull(((int)InvoiceColumn.Description - 1)))?null:(System.String)reader[((int)InvoiceColumn.Description - 1)];
					c.Quantity = (System.Int32)reader[((int)InvoiceColumn.Quantity - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Invoice"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Invoice"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Invoice entity)
		{
			if (!reader.Read()) return;
			
			entity.InvoiceId = (System.Int32)reader[((int)InvoiceColumn.InvoiceId - 1)];
			entity.AdvertiserUserId = (System.Int32)reader[((int)InvoiceColumn.AdvertiserUserId - 1)];
			entity.OrderId = (System.Int32)reader[((int)InvoiceColumn.OrderId - 1)];
			entity.JobItemTypeId = (System.Int32)reader[((int)InvoiceColumn.JobItemTypeId - 1)];
			entity.TotalNumberOfJobs = (System.Int32)reader[((int)InvoiceColumn.TotalNumberOfJobs - 1)];
			entity.TotalAmount = (System.Decimal)reader[((int)InvoiceColumn.TotalAmount - 1)];
			entity.Description = (reader.IsDBNull(((int)InvoiceColumn.Description - 1)))?null:(System.String)reader[((int)InvoiceColumn.Description - 1)];
			entity.Quantity = (System.Int32)reader[((int)InvoiceColumn.Quantity - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Invoice"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Invoice"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Invoice entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.InvoiceId = (System.Int32)dataRow["InvoiceID"];
			entity.AdvertiserUserId = (System.Int32)dataRow["AdvertiserUserID"];
			entity.OrderId = (System.Int32)dataRow["OrderID"];
			entity.JobItemTypeId = (System.Int32)dataRow["JobItemTypeID"];
			entity.TotalNumberOfJobs = (System.Int32)dataRow["TotalNumberOfJobs"];
			entity.TotalAmount = (System.Decimal)dataRow["TotalAmount"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.Quantity = (System.Int32)dataRow["Quantity"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Invoice"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Invoice Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Invoice entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region OrderIdSource	
			if (CanDeepLoad(entity, "InvoiceOrder|OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderId;
				InvoiceOrder tmpEntity = EntityManager.LocateEntity<InvoiceOrder>(EntityLocator.ConstructKeyFromPkItems(typeof(InvoiceOrder), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.InvoiceOrderProvider.GetByOrderId(transactionManager, entity.OrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.InvoiceOrderProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByInvoiceId methods when available
			
			#region InvoiceItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<InvoiceItem>|InvoiceItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceItemCollection = DataRepository.InvoiceItemProvider.GetByInvoiceId(transactionManager, entity.InvoiceId);

				if (deep && entity.InvoiceItemCollection.Count > 0)
				{
					deepHandles.Add("InvoiceItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<InvoiceItem>) DataRepository.InvoiceItemProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceItemCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Invoice object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Invoice instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Invoice Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Invoice entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region OrderIdSource
			if (CanDeepSave(entity, "InvoiceOrder|OrderIdSource", deepSaveType, innerList) 
				&& entity.OrderIdSource != null)
			{
				DataRepository.InvoiceOrderProvider.Save(transactionManager, entity.OrderIdSource);
				entity.OrderId = entity.OrderIdSource.OrderId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<InvoiceItem>
				if (CanDeepSave(entity.InvoiceItemCollection, "List<InvoiceItem>|InvoiceItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(InvoiceItem child in entity.InvoiceItemCollection)
					{
						if(child.InvoiceIdSource != null)
						{
							child.InvoiceId = child.InvoiceIdSource.InvoiceId;
						}
						else
						{
							child.InvoiceId = entity.InvoiceId;
						}

					}

					if (entity.InvoiceItemCollection.Count > 0 || entity.InvoiceItemCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceItemProvider.Save(transactionManager, entity.InvoiceItemCollection);
						
						deepHandles.Add("InvoiceItemCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< InvoiceItem >) DataRepository.InvoiceItemProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceItemCollection, deepSaveType, childTypes, innerList }
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
	
	#region InvoiceChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Invoice</c>
	///</summary>
	public enum InvoiceChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at AdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
			
		///<summary>
		/// Composite Property for <c>InvoiceOrder</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(InvoiceOrder))]
		InvoiceOrder,
	
		///<summary>
		/// Collection of <c>Invoice</c> as OneToMany for InvoiceItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceItem>))]
		InvoiceItemCollection,
	}
	
	#endregion InvoiceChildEntityTypes
	
	#region InvoiceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InvoiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceFilterBuilder : SqlFilterBuilder<InvoiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceFilterBuilder class.
		/// </summary>
		public InvoiceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceFilterBuilder
	
	#region InvoiceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InvoiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceParameterBuilder : ParameterizedSqlFilterBuilder<InvoiceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceParameterBuilder class.
		/// </summary>
		public InvoiceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceParameterBuilder
	
	#region InvoiceSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;InvoiceColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class InvoiceSortBuilder : SqlSortBuilder<InvoiceColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceSqlSortBuilder class.
		/// </summary>
		public InvoiceSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion InvoiceSortBuilder
	
} // end namespace
