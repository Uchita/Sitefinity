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
	/// This class is the base class for any <see cref="ExceptionTableProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ExceptionTableProviderBaseCore : EntityProviderBase<JXTPortal.Entities.ExceptionTable, JXTPortal.Entities.ExceptionTableKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ExceptionTableKey key)
		{
			return Delete(transactionManager, key.ExceptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_exceptionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _exceptionId)
		{
			return Delete(null, _exceptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_exceptionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _exceptionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override JXTPortal.Entities.ExceptionTable Get(TransactionManager transactionManager, JXTPortal.Entities.ExceptionTableKey key, int start, int pageLength)
		{
			return GetByExceptionId(transactionManager, key.ExceptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="_exceptionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public JXTPortal.Entities.ExceptionTable GetByExceptionId(System.Int32 _exceptionId)
		{
			int count = -1;
			return GetByExceptionId(null,_exceptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="_exceptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public JXTPortal.Entities.ExceptionTable GetByExceptionId(System.Int32 _exceptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByExceptionId(null, _exceptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_exceptionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public JXTPortal.Entities.ExceptionTable GetByExceptionId(TransactionManager transactionManager, System.Int32 _exceptionId)
		{
			int count = -1;
			return GetByExceptionId(transactionManager, _exceptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_exceptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public JXTPortal.Entities.ExceptionTable GetByExceptionId(TransactionManager transactionManager, System.Int32 _exceptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByExceptionId(transactionManager, _exceptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="_exceptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public JXTPortal.Entities.ExceptionTable GetByExceptionId(System.Int32 _exceptionId, int start, int pageLength, out int count)
		{
			return GetByExceptionId(null, _exceptionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Except__2116E6DF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_exceptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ExceptionTable"/> class.</returns>
		public abstract JXTPortal.Entities.ExceptionTable GetByExceptionId(TransactionManager transactionManager, System.Int32 _exceptionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ExceptionTable_GetPaged 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public abstract TList<ExceptionTable> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region ExceptionTable_Delete 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Delete' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? exceptionId)
		{
			 Delete(null, 0, int.MaxValue , exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Delete' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? exceptionId)
		{
			 Delete(null, start, pageLength , exceptionId);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_Delete' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? exceptionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Delete' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? exceptionId);
		
		#endregion
		
		#region ExceptionTable_Update 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Update' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			 Update(null, 0, int.MaxValue , exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Update' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			 Update(null, start, pageLength , exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_Update' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			 Update(transactionManager, 0, int.MaxValue , exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Update' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage);
		
		#endregion
		
		#region ExceptionTable_Insert 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Insert' stored procedure. 
		/// </summary>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
			/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage, ref System.Int32? exceptionId)
		{
			 Insert(null, 0, int.MaxValue , dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage, ref exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Insert' stored procedure. 
		/// </summary>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
			/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage, ref System.Int32? exceptionId)
		{
			 Insert(null, start, pageLength , dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage, ref exceptionId);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_Insert' stored procedure. 
		/// </summary>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
			/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage, ref System.Int32? exceptionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage, ref exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Insert' stored procedure. 
		/// </summary>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
			/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage, ref System.Int32? exceptionId);
		
		#endregion
		
		#region ExceptionTable_GetByExceptionId 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetByExceptionId' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetByExceptionId(System.Int32? exceptionId)
		{
			return GetByExceptionId(null, 0, int.MaxValue , exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetByExceptionId' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetByExceptionId(int start, int pageLength, System.Int32? exceptionId)
		{
			return GetByExceptionId(null, start, pageLength , exceptionId);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetByExceptionId' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> GetByExceptionId(TransactionManager transactionManager, System.Int32? exceptionId)
		{
			return GetByExceptionId(transactionManager, 0, int.MaxValue , exceptionId);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_GetByExceptionId' stored procedure. 
		/// </summary>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public abstract TList<ExceptionTable> GetByExceptionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? exceptionId);
		
		#endregion
		
		#region ExceptionTable_Get_List 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public abstract TList<ExceptionTable> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region ExceptionTable_Find 
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Find(System.Boolean? searchUsingOr, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			return Find(null, start, pageLength , searchUsingOr, exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
				
		/// <summary>
		///	This method wrap the 'ExceptionTable_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public TList<ExceptionTable> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, exceptionId, dateEntered, exceptionApplicationSource, clientIpAddress, hostIpAddress, exceptionUrl, exceptionMessage, exceptionStackTrace, errorParamsMessage);
		}
		
		/// <summary>
		///	This method wrap the 'ExceptionTable_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="exceptionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateEntered"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="exceptionApplicationSource"> A <c>System.String</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="hostIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionUrl"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionMessage"> A <c>System.String</c> instance.</param>
		/// <param name="exceptionStackTrace"> A <c>System.String</c> instance.</param>
		/// <param name="errorParamsMessage"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;ExceptionTable&gt;"/> instance.</returns>
		public abstract TList<ExceptionTable> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? exceptionId, System.DateTime? dateEntered, System.String exceptionApplicationSource, System.String clientIpAddress, System.String hostIpAddress, System.String exceptionUrl, System.String exceptionMessage, System.String exceptionStackTrace, System.String errorParamsMessage);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ExceptionTable&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ExceptionTable&gt;"/></returns>
		public static TList<ExceptionTable> Fill(IDataReader reader, TList<ExceptionTable> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.ExceptionTable c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ExceptionTable")
					.Append("|").Append((System.Int32)reader[((int)ExceptionTableColumn.ExceptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ExceptionTable>(
					key.ToString(), // EntityTrackingKey
					"ExceptionTable",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.ExceptionTable();
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
					c.ExceptionId = (System.Int32)reader[((int)ExceptionTableColumn.ExceptionId - 1)];
					c.DateEntered = (System.DateTime)reader[((int)ExceptionTableColumn.DateEntered - 1)];
					c.ExceptionApplicationSource = (System.String)reader[((int)ExceptionTableColumn.ExceptionApplicationSource - 1)];
					c.ClientIpAddress = (System.String)reader[((int)ExceptionTableColumn.ClientIpAddress - 1)];
					c.HostIpAddress = (System.String)reader[((int)ExceptionTableColumn.HostIpAddress - 1)];
					c.ExceptionUrl = (System.String)reader[((int)ExceptionTableColumn.ExceptionUrl - 1)];
					c.ExceptionMessage = (System.String)reader[((int)ExceptionTableColumn.ExceptionMessage - 1)];
					c.ExceptionStackTrace = (reader.IsDBNull(((int)ExceptionTableColumn.ExceptionStackTrace - 1)))?null:(System.String)reader[((int)ExceptionTableColumn.ExceptionStackTrace - 1)];
					c.ErrorParamsMessage = (reader.IsDBNull(((int)ExceptionTableColumn.ErrorParamsMessage - 1)))?null:(System.String)reader[((int)ExceptionTableColumn.ErrorParamsMessage - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ExceptionTable"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ExceptionTable"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.ExceptionTable entity)
		{
			if (!reader.Read()) return;
			
			entity.ExceptionId = (System.Int32)reader[((int)ExceptionTableColumn.ExceptionId - 1)];
			entity.DateEntered = (System.DateTime)reader[((int)ExceptionTableColumn.DateEntered - 1)];
			entity.ExceptionApplicationSource = (System.String)reader[((int)ExceptionTableColumn.ExceptionApplicationSource - 1)];
			entity.ClientIpAddress = (System.String)reader[((int)ExceptionTableColumn.ClientIpAddress - 1)];
			entity.HostIpAddress = (System.String)reader[((int)ExceptionTableColumn.HostIpAddress - 1)];
			entity.ExceptionUrl = (System.String)reader[((int)ExceptionTableColumn.ExceptionUrl - 1)];
			entity.ExceptionMessage = (System.String)reader[((int)ExceptionTableColumn.ExceptionMessage - 1)];
			entity.ExceptionStackTrace = (reader.IsDBNull(((int)ExceptionTableColumn.ExceptionStackTrace - 1)))?null:(System.String)reader[((int)ExceptionTableColumn.ExceptionStackTrace - 1)];
			entity.ErrorParamsMessage = (reader.IsDBNull(((int)ExceptionTableColumn.ErrorParamsMessage - 1)))?null:(System.String)reader[((int)ExceptionTableColumn.ErrorParamsMessage - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ExceptionTable"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ExceptionTable"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.ExceptionTable entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ExceptionId = (System.Int32)dataRow["ExceptionID"];
			entity.DateEntered = (System.DateTime)dataRow["DateEntered"];
			entity.ExceptionApplicationSource = (System.String)dataRow["ExceptionApplicationSource"];
			entity.ClientIpAddress = (System.String)dataRow["ClientIPAddress"];
			entity.HostIpAddress = (System.String)dataRow["HostIPAddress"];
			entity.ExceptionUrl = (System.String)dataRow["ExceptionUrl"];
			entity.ExceptionMessage = (System.String)dataRow["ExceptionMessage"];
			entity.ExceptionStackTrace = Convert.IsDBNull(dataRow["ExceptionStackTrace"]) ? null : (System.String)dataRow["ExceptionStackTrace"];
			entity.ErrorParamsMessage = Convert.IsDBNull(dataRow["ErrorParamsMessage"]) ? null : (System.String)dataRow["ErrorParamsMessage"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.ExceptionTable"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.ExceptionTable Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.ExceptionTable entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.ExceptionTable object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.ExceptionTable instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.ExceptionTable Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.ExceptionTable entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
	
	#region ExceptionTableChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.ExceptionTable</c>
	///</summary>
	public enum ExceptionTableChildEntityTypes
	{
	}
	
	#endregion ExceptionTableChildEntityTypes
	
	#region ExceptionTableFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ExceptionTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableFilterBuilder : SqlFilterBuilder<ExceptionTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilterBuilder class.
		/// </summary>
		public ExceptionTableFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExceptionTableFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExceptionTableFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExceptionTableFilterBuilder
	
	#region ExceptionTableParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ExceptionTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableParameterBuilder : ParameterizedSqlFilterBuilder<ExceptionTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableParameterBuilder class.
		/// </summary>
		public ExceptionTableParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExceptionTableParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExceptionTableParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExceptionTableParameterBuilder
	
	#region ExceptionTableSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ExceptionTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ExceptionTableSortBuilder : SqlSortBuilder<ExceptionTableColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableSqlSortBuilder class.
		/// </summary>
		public ExceptionTableSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ExceptionTableSortBuilder
	
} // end namespace
