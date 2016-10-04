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
	/// This class is the base class for any <see cref="SiteSummaryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteSummaryProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteSummary, JXTPortal.Entities.SiteSummaryKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteSummaryKey key)
		{
			return Delete(transactionManager, key.SiteSummaryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteSummaryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteSummaryId)
		{
			return Delete(null, _siteSummaryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSummaryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteSummaryId);		
		
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
		public override JXTPortal.Entities.SiteSummary Get(TransactionManager transactionManager, JXTPortal.Entities.SiteSummaryKey key, int start, int pageLength)
		{
			return GetBySiteSummaryId(transactionManager, key.SiteSummaryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="_siteSummaryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public JXTPortal.Entities.SiteSummary GetBySiteSummaryId(System.Int32 _siteSummaryId)
		{
			int count = -1;
			return GetBySiteSummaryId(null,_siteSummaryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="_siteSummaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public JXTPortal.Entities.SiteSummary GetBySiteSummaryId(System.Int32 _siteSummaryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteSummaryId(null, _siteSummaryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSummaryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public JXTPortal.Entities.SiteSummary GetBySiteSummaryId(TransactionManager transactionManager, System.Int32 _siteSummaryId)
		{
			int count = -1;
			return GetBySiteSummaryId(transactionManager, _siteSummaryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSummaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public JXTPortal.Entities.SiteSummary GetBySiteSummaryId(TransactionManager transactionManager, System.Int32 _siteSummaryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteSummaryId(transactionManager, _siteSummaryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="_siteSummaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public JXTPortal.Entities.SiteSummary GetBySiteSummaryId(System.Int32 _siteSummaryId, int start, int pageLength, out int count)
		{
			return GetBySiteSummaryId(null, _siteSummaryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSumm__C2159BD62691D76C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSummaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSummary"/> class.</returns>
		public abstract JXTPortal.Entities.SiteSummary GetBySiteSummaryId(TransactionManager transactionManager, System.Int32 _siteSummaryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteSummary_GetBySiteSummaryId 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_GetBySiteSummaryId' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteSummaryId(System.Int32? siteSummaryId)
		{
			return GetBySiteSummaryId(null, 0, int.MaxValue , siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_GetBySiteSummaryId' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteSummaryId(int start, int pageLength, System.Int32? siteSummaryId)
		{
			return GetBySiteSummaryId(null, start, pageLength , siteSummaryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSummary_GetBySiteSummaryId' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteSummaryId(TransactionManager transactionManager, System.Int32? siteSummaryId)
		{
			return GetBySiteSummaryId(transactionManager, 0, int.MaxValue , siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_GetBySiteSummaryId' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteSummaryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSummaryId);
		
		#endregion
		
		#region SiteSummary_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteSummaryId)
		{
			 Delete(null, 0, int.MaxValue , siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteSummaryId)
		{
			 Delete(null, start, pageLength , siteSummaryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSummary_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteSummaryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSummaryId);
		
		#endregion
		
		#region SiteSummary_Update 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			 Update(null, 0, int.MaxValue , siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			 Update(null, start, pageLength , siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSummary_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			 Update(transactionManager, 0, int.MaxValue , siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region SiteSummary_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy, ref System.Int32? siteSummaryId)
		{
			 Insert(null, 0, int.MaxValue , siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy, ref siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy, ref System.Int32? siteSummaryId)
		{
			 Insert(null, start, pageLength , siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy, ref siteSummaryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSummary_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy, ref System.Int32? siteSummaryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy, ref siteSummaryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy, ref System.Int32? siteSummaryId);
		
		#endregion
		
		#region SiteSummary_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Get_List' stored procedure. 
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
		///	This method wrap the 'SiteSummary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteSummary_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteSummary_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteSummary_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteSummary_GetPaged' stored procedure. 
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
		
		#region SiteSummary_Find 
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			return Find(null, start, pageLength , searchUsingOr, siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSummary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteSummaryId, siteId, description, modifiedBy, timeStamp, lastModifiedDate, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSummary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSummaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.String</c> instance.</param>
		/// <param name="timeStamp"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteSummaryId, System.Int32? siteId, System.String description, System.String modifiedBy, System.DateTime? timeStamp, System.DateTime? lastModifiedDate, System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteSummary&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteSummary&gt;"/></returns>
		public static TList<SiteSummary> Fill(IDataReader reader, TList<SiteSummary> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteSummary c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteSummary")
					.Append("|").Append((System.Int32)reader[((int)SiteSummaryColumn.SiteSummaryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteSummary>(
					key.ToString(), // EntityTrackingKey
					"SiteSummary",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteSummary();
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
					c.SiteSummaryId = (System.Int32)reader[((int)SiteSummaryColumn.SiteSummaryId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteSummaryColumn.SiteId - 1)];
					c.Title = (reader.IsDBNull(((int)SiteSummaryColumn.Title - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Title - 1)];
					c.Description = (reader.IsDBNull(((int)SiteSummaryColumn.Description - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Description - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)SiteSummaryColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.ModifiedBy - 1)];
					c.Url = (reader.IsDBNull(((int)SiteSummaryColumn.Url - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Url - 1)];
					c.TimeStamp = (reader.IsDBNull(((int)SiteSummaryColumn.TimeStamp - 1)))?null:(System.DateTime?)reader[((int)SiteSummaryColumn.TimeStamp - 1)];
					c.Valid = (reader.IsDBNull(((int)SiteSummaryColumn.Valid - 1)))?null:(System.Int32?)reader[((int)SiteSummaryColumn.Valid - 1)];
					c.ShowPlatformNotification = (reader.IsDBNull(((int)SiteSummaryColumn.ShowPlatformNotification - 1)))?null:(System.Boolean?)reader[((int)SiteSummaryColumn.ShowPlatformNotification - 1)];
					c.PlatformNotificationText = (reader.IsDBNull(((int)SiteSummaryColumn.PlatformNotificationText - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.PlatformNotificationText - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)SiteSummaryColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)SiteSummaryColumn.LastModifiedDate - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)SiteSummaryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SiteSummaryColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteSummary"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSummary"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteSummary entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteSummaryId = (System.Int32)reader[((int)SiteSummaryColumn.SiteSummaryId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteSummaryColumn.SiteId - 1)];
			entity.Title = (reader.IsDBNull(((int)SiteSummaryColumn.Title - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Title - 1)];
			entity.Description = (reader.IsDBNull(((int)SiteSummaryColumn.Description - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Description - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)SiteSummaryColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.ModifiedBy - 1)];
			entity.Url = (reader.IsDBNull(((int)SiteSummaryColumn.Url - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.Url - 1)];
			entity.TimeStamp = (reader.IsDBNull(((int)SiteSummaryColumn.TimeStamp - 1)))?null:(System.DateTime?)reader[((int)SiteSummaryColumn.TimeStamp - 1)];
			entity.Valid = (reader.IsDBNull(((int)SiteSummaryColumn.Valid - 1)))?null:(System.Int32?)reader[((int)SiteSummaryColumn.Valid - 1)];
			entity.ShowPlatformNotification = (reader.IsDBNull(((int)SiteSummaryColumn.ShowPlatformNotification - 1)))?null:(System.Boolean?)reader[((int)SiteSummaryColumn.ShowPlatformNotification - 1)];
			entity.PlatformNotificationText = (reader.IsDBNull(((int)SiteSummaryColumn.PlatformNotificationText - 1)))?null:(System.String)reader[((int)SiteSummaryColumn.PlatformNotificationText - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)SiteSummaryColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)SiteSummaryColumn.LastModifiedDate - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)SiteSummaryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SiteSummaryColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteSummary"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSummary"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteSummary entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteSummaryId = (System.Int32)dataRow["SiteSummaryID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["ModifiedBy"]) ? null : (System.String)dataRow["ModifiedBy"];
			entity.Url = Convert.IsDBNull(dataRow["URL"]) ? null : (System.String)dataRow["URL"];
			entity.TimeStamp = Convert.IsDBNull(dataRow["TimeStamp"]) ? null : (System.DateTime?)dataRow["TimeStamp"];
			entity.Valid = Convert.IsDBNull(dataRow["Valid"]) ? null : (System.Int32?)dataRow["Valid"];
			entity.ShowPlatformNotification = Convert.IsDBNull(dataRow["ShowPlatformNotification"]) ? null : (System.Boolean?)dataRow["ShowPlatformNotification"];
			entity.PlatformNotificationText = Convert.IsDBNull(dataRow["PlatformNotificationText"]) ? null : (System.String)dataRow["PlatformNotificationText"];
			entity.LastModifiedDate = Convert.IsDBNull(dataRow["LastModifiedDate"]) ? null : (System.DateTime?)dataRow["LastModifiedDate"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSummary"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteSummary Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteSummary entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteSummary object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteSummary instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteSummary Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteSummary entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SiteSummaryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteSummary</c>
	///</summary>
	public enum SiteSummaryChildEntityTypes
	{
	}
	
	#endregion SiteSummaryChildEntityTypes
	
	#region SiteSummaryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSummaryFilterBuilder : SqlFilterBuilder<SiteSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilterBuilder class.
		/// </summary>
		public SiteSummaryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSummaryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSummaryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSummaryFilterBuilder
	
	#region SiteSummaryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSummaryParameterBuilder : ParameterizedSqlFilterBuilder<SiteSummaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSummaryParameterBuilder class.
		/// </summary>
		public SiteSummaryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSummaryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSummaryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSummaryParameterBuilder
	
	#region SiteSummarySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteSummaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSummary"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteSummarySortBuilder : SqlSortBuilder<SiteSummaryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSummarySqlSortBuilder class.
		/// </summary>
		public SiteSummarySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteSummarySortBuilder
	
} // end namespace
