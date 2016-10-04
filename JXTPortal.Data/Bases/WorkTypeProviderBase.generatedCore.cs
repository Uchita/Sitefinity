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
	/// This class is the base class for any <see cref="WorkTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WorkTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.WorkType, JXTPortal.Entities.WorkTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.WorkTypeKey key)
		{
			return Delete(transactionManager, key.WorkTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_workTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _workTypeId)
		{
			return Delete(null, _workTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _workTypeId);		
		
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
		public override JXTPortal.Entities.WorkType Get(TransactionManager transactionManager, JXTPortal.Entities.WorkTypeKey key, int start, int pageLength)
		{
			return GetByWorkTypeId(transactionManager, key.WorkTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public JXTPortal.Entities.WorkType GetByWorkTypeId(System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(null,_workTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public JXTPortal.Entities.WorkType GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeId(null, _workTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public JXTPortal.Entities.WorkType GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public JXTPortal.Entities.WorkType GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public JXTPortal.Entities.WorkType GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength, out int count)
		{
			return GetByWorkTypeId(null, _workTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WorkType__3E3D3572 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WorkType"/> class.</returns>
		public abstract JXTPortal.Entities.WorkType GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region WorkType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'WorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public abstract TList<WorkType> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region WorkType_Delete 
		
		/// <summary>
		///	This method wrap the 'WorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? workTypeId)
		{
			 Delete(null, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? workTypeId)
		{
			 Delete(null, start, pageLength , workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? workTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId);
		
		#endregion
		
		#region WorkType_Update 
		
		/// <summary>
		///	This method wrap the 'WorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , workTypeId, workTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			 Update(null, start, pageLength , workTypeId, workTypeName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , workTypeId, workTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid);
		
		#endregion
		
		#region WorkType_Insert 
		
		/// <summary>
		///	This method wrap the 'WorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String workTypeName, System.Boolean? valid, ref System.Int32? workTypeId)
		{
			 Insert(null, 0, int.MaxValue , workTypeName, valid, ref workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String workTypeName, System.Boolean? valid, ref System.Int32? workTypeId)
		{
			 Insert(null, start, pageLength , workTypeName, valid, ref workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String workTypeName, System.Boolean? valid, ref System.Int32? workTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , workTypeName, valid, ref workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String workTypeName, System.Boolean? valid, ref System.Int32? workTypeId);
		
		#endregion
		
		#region WorkType_Get_List 
		
		/// <summary>
		///	This method wrap the 'WorkType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public abstract TList<WorkType> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region WorkType_GetByWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'WorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetByWorkTypeId(System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetByWorkTypeId(int start, int pageLength, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, start, pageLength , workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> GetByWorkTypeId(TransactionManager transactionManager, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(transactionManager, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public abstract TList<WorkType> GetByWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId);
		
		#endregion
		
		#region WorkType_Find 
		
		/// <summary>
		///	This method wrap the 'WorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Find(System.Boolean? searchUsingOr, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, workTypeId, workTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, workTypeId, workTypeName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'WorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public TList<WorkType> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, workTypeId, workTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'WorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WorkType&gt;"/> instance.</returns>
		public abstract TList<WorkType> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? workTypeId, System.String workTypeName, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WorkType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WorkType&gt;"/></returns>
		public static TList<WorkType> Fill(IDataReader reader, TList<WorkType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.WorkType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WorkType")
					.Append("|").Append((System.Int32)reader[((int)WorkTypeColumn.WorkTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WorkType>(
					key.ToString(), // EntityTrackingKey
					"WorkType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.WorkType();
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
					c.WorkTypeId = (System.Int32)reader[((int)WorkTypeColumn.WorkTypeId - 1)];
					c.WorkTypeName = (System.String)reader[((int)WorkTypeColumn.WorkTypeName - 1)];
					c.Valid = (System.Boolean)reader[((int)WorkTypeColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WorkType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WorkType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.WorkType entity)
		{
			if (!reader.Read()) return;
			
			entity.WorkTypeId = (System.Int32)reader[((int)WorkTypeColumn.WorkTypeId - 1)];
			entity.WorkTypeName = (System.String)reader[((int)WorkTypeColumn.WorkTypeName - 1)];
			entity.Valid = (System.Boolean)reader[((int)WorkTypeColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WorkType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WorkType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.WorkType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WorkTypeId = (System.Int32)dataRow["WorkTypeID"];
			entity.WorkTypeName = (System.String)dataRow["WorkTypeName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.WorkType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.WorkType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.WorkType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByWorkTypeId methods when available
			
			#region SiteWorkTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWorkType>|SiteWorkTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWorkTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWorkTypeCollection = DataRepository.SiteWorkTypeProvider.GetByWorkTypeId(transactionManager, entity.WorkTypeId);

				if (deep && entity.SiteWorkTypeCollection.Count > 0)
				{
					deepHandles.Add("SiteWorkTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWorkType>) DataRepository.SiteWorkTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWorkTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetByWorkTypeId(transactionManager, entity.WorkTypeId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsArchiveCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsArchive>|JobsArchiveCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsArchiveCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByWorkTypeId(transactionManager, entity.WorkTypeId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.WorkType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.WorkType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.WorkType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.WorkType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SiteWorkType>
				if (CanDeepSave(entity.SiteWorkTypeCollection, "List<SiteWorkType>|SiteWorkTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWorkType child in entity.SiteWorkTypeCollection)
					{
						if(child.WorkTypeIdSource != null)
						{
							child.WorkTypeId = child.WorkTypeIdSource.WorkTypeId;
						}
						else
						{
							child.WorkTypeId = entity.WorkTypeId;
						}

					}

					if (entity.SiteWorkTypeCollection.Count > 0 || entity.SiteWorkTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWorkTypeProvider.Save(transactionManager, entity.SiteWorkTypeCollection);
						
						deepHandles.Add("SiteWorkTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWorkType >) DataRepository.SiteWorkTypeProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWorkTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.WorkTypeIdSource != null)
						{
							child.WorkTypeId = child.WorkTypeIdSource.WorkTypeId;
						}
						else
						{
							child.WorkTypeId = entity.WorkTypeId;
						}

					}

					if (entity.JobsCollection.Count > 0 || entity.JobsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsProvider.Save(transactionManager, entity.JobsCollection);
						
						deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Jobs >) DataRepository.JobsProvider.DeepSave,
							new object[] { transactionManager, entity.JobsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobsArchive>
				if (CanDeepSave(entity.JobsArchiveCollection, "List<JobsArchive>|JobsArchiveCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsArchive child in entity.JobsArchiveCollection)
					{
						if(child.WorkTypeIdSource != null)
						{
							child.WorkTypeId = child.WorkTypeIdSource.WorkTypeId;
						}
						else
						{
							child.WorkTypeId = entity.WorkTypeId;
						}

					}

					if (entity.JobsArchiveCollection.Count > 0 || entity.JobsArchiveCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobsArchiveCollection);
						
						deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsArchive >) DataRepository.JobsArchiveProvider.DeepSave,
							new object[] { transactionManager, entity.JobsArchiveCollection, deepSaveType, childTypes, innerList }
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
	
	#region WorkTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.WorkType</c>
	///</summary>
	public enum WorkTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>WorkType</c> as OneToMany for SiteWorkTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteWorkType>))]
		SiteWorkTypeCollection,

		///<summary>
		/// Collection of <c>WorkType</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>WorkType</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,
	}
	
	#endregion WorkTypeChildEntityTypes
	
	#region WorkTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeFilterBuilder : SqlFilterBuilder<WorkTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilterBuilder class.
		/// </summary>
		public WorkTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkTypeFilterBuilder
	
	#region WorkTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeParameterBuilder : ParameterizedSqlFilterBuilder<WorkTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeParameterBuilder class.
		/// </summary>
		public WorkTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkTypeParameterBuilder
	
	#region WorkTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WorkTypeSortBuilder : SqlSortBuilder<WorkTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeSqlSortBuilder class.
		/// </summary>
		public WorkTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WorkTypeSortBuilder
	
} // end namespace
