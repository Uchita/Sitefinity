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
	/// This class is the base class for any <see cref="InvoiceItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class InvoiceItemProviderBaseCore : EntityProviderBase<JXTPortal.Entities.InvoiceItem, JXTPortal.Entities.InvoiceItemKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.InvoiceItemKey key)
		{
			return Delete(transactionManager, key.InvoiceItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_invoiceItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _invoiceItemId)
		{
			return Delete(null, _invoiceItemId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceItemId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _invoiceItemId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		FK__InvoiceIt__Adver__2F5CD1E0 Description: 
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByAdvertiserUserId(System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(_advertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		FK__InvoiceIt__Adver__2F5CD1E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		/// <remarks></remarks>
		public TList<InvoiceItem> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		FK__InvoiceIt__Adver__2F5CD1E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		fkInvoiceItAdver2f5Cd1e0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		fkInvoiceItAdver2f5Cd1e0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Adver__2F5CD1E0 key.
		///		FK__InvoiceIt__Adver__2F5CD1E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public abstract TList<InvoiceItem> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		FK__InvoiceIt__Invoi__2C806535 Description: 
		/// </summary>
		/// <param name="_invoiceId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByInvoiceId(System.Int32 _invoiceId)
		{
			int count = -1;
			return GetByInvoiceId(_invoiceId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		FK__InvoiceIt__Invoi__2C806535 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		/// <remarks></remarks>
		public TList<InvoiceItem> GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId)
		{
			int count = -1;
			return GetByInvoiceId(transactionManager, _invoiceId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		FK__InvoiceIt__Invoi__2C806535 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceId(transactionManager, _invoiceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		fkInvoiceItInvoi2c806535 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_invoiceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByInvoiceId(System.Int32 _invoiceId, int start, int pageLength)
		{
			int count =  -1;
			return GetByInvoiceId(null, _invoiceId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		fkInvoiceItInvoi2c806535 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_invoiceId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByInvoiceId(System.Int32 _invoiceId, int start, int pageLength,out int count)
		{
			return GetByInvoiceId(null, _invoiceId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__Invoi__2C806535 key.
		///		FK__InvoiceIt__Invoi__2C806535 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public abstract TList<InvoiceItem> GetByInvoiceId(TransactionManager transactionManager, System.Int32 _invoiceId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		FK__InvoiceIt__JobAr__2E68ADA7 Description: 
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(_jobArchiveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		FK__InvoiceIt__JobAr__2E68ADA7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		/// <remarks></remarks>
		public TList<InvoiceItem> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		FK__InvoiceIt__JobAr__2E68ADA7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		fkInvoiceItJobAr2e68Ada7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		fkInvoiceItJobAr2e68Ada7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength,out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobAr__2E68ADA7 key.
		///		FK__InvoiceIt__JobAr__2E68ADA7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public abstract TList<InvoiceItem> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		FK__InvoiceIt__JobID__2D74896E Description: 
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(_jobId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		FK__InvoiceIt__JobID__2D74896E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		/// <remarks></remarks>
		public TList<InvoiceItem> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		FK__InvoiceIt__JobID__2D74896E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		fkInvoiceItJobId2d74896e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobId(null, _jobId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		fkInvoiceItJobId2d74896e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public TList<InvoiceItem> GetByJobId(System.Int32? _jobId, int start, int pageLength,out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__InvoiceIt__JobID__2D74896E key.
		///		FK__InvoiceIt__JobID__2D74896E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.InvoiceItem objects.</returns>
		public abstract TList<InvoiceItem> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.InvoiceItem Get(TransactionManager transactionManager, JXTPortal.Entities.InvoiceItemKey key, int start, int pageLength)
		{
			return GetByInvoiceItemId(transactionManager, key.InvoiceItemId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="_invoiceItemId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(System.Int32 _invoiceItemId)
		{
			int count = -1;
			return GetByInvoiceItemId(null,_invoiceItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="_invoiceItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(System.Int32 _invoiceItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceItemId(null, _invoiceItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceItemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(TransactionManager transactionManager, System.Int32 _invoiceItemId)
		{
			int count = -1;
			return GetByInvoiceItemId(transactionManager, _invoiceItemId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(TransactionManager transactionManager, System.Int32 _invoiceItemId, int start, int pageLength)
		{
			int count = -1;
			return GetByInvoiceItemId(transactionManager, _invoiceItemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="_invoiceItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(System.Int32 _invoiceItemId, int start, int pageLength, out int count)
		{
			return GetByInvoiceItemId(null, _invoiceItemId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__InvoiceI__478FE0FC2A981CC3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_invoiceItemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.InvoiceItem"/> class.</returns>
		public abstract JXTPortal.Entities.InvoiceItem GetByInvoiceItemId(TransactionManager transactionManager, System.Int32 _invoiceItemId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region InvoiceItem_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
			
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region InvoiceItem_GetByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region InvoiceItem_GetByInvoiceId 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceId(System.Int32? invoiceId)
		{
			return GetByInvoiceId(null, 0, int.MaxValue , invoiceId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceId' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetByInvoiceId' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetByInvoiceId' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByInvoiceId(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceId);
		
		#endregion
		
		#region InvoiceItem_Insert 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Insert' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId, ref System.Int32? invoiceItemId)
		{
			 Insert(null, 0, int.MaxValue , invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId, ref invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Insert' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId, ref System.Int32? invoiceItemId)
		{
			 Insert(null, start, pageLength , invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId, ref invoiceItemId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_Insert' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId, ref System.Int32? invoiceItemId)
		{
			 Insert(transactionManager, 0, int.MaxValue , invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId, ref invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Insert' stored procedure. 
		/// </summary>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId, ref System.Int32? invoiceItemId);
		
		#endregion
		
		#region InvoiceItem_Get_List 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Get_List' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region InvoiceItem_GetPaged 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetPaged' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetPaged' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetPaged' stored procedure. 
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
		///	This method wrap the 'InvoiceItem_GetPaged' stored procedure. 
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
		
		#region InvoiceItem_GetByInvoiceItemId 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceItemId' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceItemId(System.Int32? invoiceItemId)
		{
			return GetByInvoiceItemId(null, 0, int.MaxValue , invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceItemId' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceItemId(int start, int pageLength, System.Int32? invoiceItemId)
		{
			return GetByInvoiceItemId(null, start, pageLength , invoiceItemId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceItemId' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByInvoiceItemId(TransactionManager transactionManager, System.Int32? invoiceItemId)
		{
			return GetByInvoiceItemId(transactionManager, 0, int.MaxValue , invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByInvoiceItemId' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByInvoiceItemId(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceItemId);
		
		#endregion
		
		#region InvoiceItem_Update 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			 Update(null, 0, int.MaxValue , invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			 Update(null, start, pageLength , invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			 Update(transactionManager, 0, int.MaxValue , invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Update' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId);
		
		#endregion
		
		#region InvoiceItem_CustomJobBoardAccountPostJob 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomJobBoardAccountPostJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="taxRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomJobBoardAccountPostJob(System.Int32? jobId, System.Int32? advertiserUserId, System.Int32? jobItemTypeId, System.Decimal? taxRate, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst)
		{
			 CustomJobBoardAccountPostJob(null, 0, int.MaxValue , jobId, advertiserUserId, jobItemTypeId, taxRate, currencyId, discountAmount, discountGst);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomJobBoardAccountPostJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="taxRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomJobBoardAccountPostJob(int start, int pageLength, System.Int32? jobId, System.Int32? advertiserUserId, System.Int32? jobItemTypeId, System.Decimal? taxRate, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst)
		{
			 CustomJobBoardAccountPostJob(null, start, pageLength , jobId, advertiserUserId, jobItemTypeId, taxRate, currencyId, discountAmount, discountGst);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomJobBoardAccountPostJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="taxRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomJobBoardAccountPostJob(TransactionManager transactionManager, System.Int32? jobId, System.Int32? advertiserUserId, System.Int32? jobItemTypeId, System.Decimal? taxRate, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst)
		{
			 CustomJobBoardAccountPostJob(transactionManager, 0, int.MaxValue , jobId, advertiserUserId, jobItemTypeId, taxRate, currencyId, discountAmount, discountGst);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomJobBoardAccountPostJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="taxRate"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="discountGst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomJobBoardAccountPostJob(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? advertiserUserId, System.Int32? jobItemTypeId, System.Decimal? taxRate, System.Int32? currencyId, System.Decimal? discountAmount, System.Decimal? discountGst);
		
		#endregion
		
		#region InvoiceItem_Find 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			return Find(null, start, pageLength , searchUsingOr, invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, invoiceItemId, invoiceId, jobId, jobArchiveId, createdDate, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="invoiceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? invoiceItemId, System.Int32? invoiceId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? createdDate, System.Int32? advertiserUserId);
		
		#endregion
		
		#region InvoiceItem_Delete 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? invoiceItemId)
		{
			 Delete(null, 0, int.MaxValue , invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? invoiceItemId)
		{
			 Delete(null, start, pageLength , invoiceItemId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? invoiceItemId)
		{
			 Delete(transactionManager, 0, int.MaxValue , invoiceItemId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_Delete' stored procedure. 
		/// </summary>
		/// <param name="invoiceItemId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? invoiceItemId);
		
		#endregion
		
		#region InvoiceItem_GetByJobArchiveId 
		
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
				
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region InvoiceItem_CustomPayJob 
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomPayJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPayJob(System.Int32? jobId)
		{
			return CustomPayJob(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomPayJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPayJob(int start, int pageLength, System.Int32? jobId)
		{
			return CustomPayJob(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomPayJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPayJob(TransactionManager transactionManager, System.Int32? jobId)
		{
			return CustomPayJob(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'InvoiceItem_CustomPayJob' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomPayJob(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;InvoiceItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;InvoiceItem&gt;"/></returns>
		public static TList<InvoiceItem> Fill(IDataReader reader, TList<InvoiceItem> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.InvoiceItem c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("InvoiceItem")
					.Append("|").Append((System.Int32)reader[((int)InvoiceItemColumn.InvoiceItemId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<InvoiceItem>(
					key.ToString(), // EntityTrackingKey
					"InvoiceItem",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.InvoiceItem();
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
					c.InvoiceItemId = (System.Int32)reader[((int)InvoiceItemColumn.InvoiceItemId - 1)];
					c.InvoiceId = (System.Int32)reader[((int)InvoiceItemColumn.InvoiceId - 1)];
					c.JobId = (reader.IsDBNull(((int)InvoiceItemColumn.JobId - 1)))?null:(System.Int32?)reader[((int)InvoiceItemColumn.JobId - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)InvoiceItemColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)InvoiceItemColumn.JobArchiveId - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)InvoiceItemColumn.CreatedDate - 1)];
					c.AdvertiserUserId = (System.Int32)reader[((int)InvoiceItemColumn.AdvertiserUserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.InvoiceItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.InvoiceItem entity)
		{
			if (!reader.Read()) return;
			
			entity.InvoiceItemId = (System.Int32)reader[((int)InvoiceItemColumn.InvoiceItemId - 1)];
			entity.InvoiceId = (System.Int32)reader[((int)InvoiceItemColumn.InvoiceId - 1)];
			entity.JobId = (reader.IsDBNull(((int)InvoiceItemColumn.JobId - 1)))?null:(System.Int32?)reader[((int)InvoiceItemColumn.JobId - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)InvoiceItemColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)InvoiceItemColumn.JobArchiveId - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)InvoiceItemColumn.CreatedDate - 1)];
			entity.AdvertiserUserId = (System.Int32)reader[((int)InvoiceItemColumn.AdvertiserUserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.InvoiceItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.InvoiceItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.InvoiceItemId = (System.Int32)dataRow["InvoiceItemID"];
			entity.InvoiceId = (System.Int32)dataRow["InvoiceID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.AdvertiserUserId = (System.Int32)dataRow["AdvertiserUserID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.InvoiceItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.InvoiceItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.InvoiceItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region InvoiceIdSource	
			if (CanDeepLoad(entity, "Invoice|InvoiceIdSource", deepLoadType, innerList) 
				&& entity.InvoiceIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.InvoiceId;
				Invoice tmpEntity = EntityManager.LocateEntity<Invoice>(EntityLocator.ConstructKeyFromPkItems(typeof(Invoice), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.InvoiceIdSource = tmpEntity;
				else
					entity.InvoiceIdSource = DataRepository.InvoiceProvider.GetByInvoiceId(transactionManager, entity.InvoiceId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.InvoiceIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.InvoiceProvider.DeepLoad(transactionManager, entity.InvoiceIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion InvoiceIdSource

			#region JobArchiveIdSource	
			if (CanDeepLoad(entity, "JobsArchive|JobArchiveIdSource", deepLoadType, innerList) 
				&& entity.JobArchiveIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobArchiveId ?? (int)0);
				JobsArchive tmpEntity = EntityManager.LocateEntity<JobsArchive>(EntityLocator.ConstructKeyFromPkItems(typeof(JobsArchive), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobArchiveIdSource = tmpEntity;
				else
					entity.JobArchiveIdSource = DataRepository.JobsArchiveProvider.GetByJobId(transactionManager, (entity.JobArchiveId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobArchiveIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobArchiveIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsArchiveProvider.DeepLoad(transactionManager, entity.JobArchiveIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobArchiveIdSource

			#region JobIdSource	
			if (CanDeepLoad(entity, "Jobs|JobIdSource", deepLoadType, innerList) 
				&& entity.JobIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobId ?? (int)0);
				Jobs tmpEntity = EntityManager.LocateEntity<Jobs>(EntityLocator.ConstructKeyFromPkItems(typeof(Jobs), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobIdSource = tmpEntity;
				else
					entity.JobIdSource = DataRepository.JobsProvider.GetByJobId(transactionManager, (entity.JobId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsProvider.DeepLoad(transactionManager, entity.JobIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.InvoiceItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.InvoiceItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.InvoiceItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.InvoiceItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region InvoiceIdSource
			if (CanDeepSave(entity, "Invoice|InvoiceIdSource", deepSaveType, innerList) 
				&& entity.InvoiceIdSource != null)
			{
				DataRepository.InvoiceProvider.Save(transactionManager, entity.InvoiceIdSource);
				entity.InvoiceId = entity.InvoiceIdSource.InvoiceId;
			}
			#endregion 
			
			#region JobArchiveIdSource
			if (CanDeepSave(entity, "JobsArchive|JobArchiveIdSource", deepSaveType, innerList) 
				&& entity.JobArchiveIdSource != null)
			{
				DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobArchiveIdSource);
				entity.JobArchiveId = entity.JobArchiveIdSource.JobId;
			}
			#endregion 
			
			#region JobIdSource
			if (CanDeepSave(entity, "Jobs|JobIdSource", deepSaveType, innerList) 
				&& entity.JobIdSource != null)
			{
				DataRepository.JobsProvider.Save(transactionManager, entity.JobIdSource);
				entity.JobId = entity.JobIdSource.JobId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region InvoiceItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.InvoiceItem</c>
	///</summary>
	public enum InvoiceItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at AdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
			
		///<summary>
		/// Composite Property for <c>Invoice</c> at InvoiceIdSource
		///</summary>
		[ChildEntityType(typeof(Invoice))]
		Invoice,
			
		///<summary>
		/// Composite Property for <c>JobsArchive</c> at JobArchiveIdSource
		///</summary>
		[ChildEntityType(typeof(JobsArchive))]
		JobsArchive,
			
		///<summary>
		/// Composite Property for <c>Jobs</c> at JobIdSource
		///</summary>
		[ChildEntityType(typeof(Jobs))]
		Jobs,
		}
	
	#endregion InvoiceItemChildEntityTypes
	
	#region InvoiceItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;InvoiceItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceItemFilterBuilder : SqlFilterBuilder<InvoiceItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilterBuilder class.
		/// </summary>
		public InvoiceItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceItemFilterBuilder
	
	#region InvoiceItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;InvoiceItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceItemParameterBuilder : ParameterizedSqlFilterBuilder<InvoiceItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceItemParameterBuilder class.
		/// </summary>
		public InvoiceItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceItemParameterBuilder
	
	#region InvoiceItemSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;InvoiceItemColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceItem"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class InvoiceItemSortBuilder : SqlSortBuilder<InvoiceItemColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceItemSqlSortBuilder class.
		/// </summary>
		public InvoiceItemSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion InvoiceItemSortBuilder
	
} // end namespace
