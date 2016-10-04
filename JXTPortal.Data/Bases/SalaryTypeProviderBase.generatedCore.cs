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
	/// This class is the base class for any <see cref="SalaryTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalaryTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SalaryType, JXTPortal.Entities.SalaryTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SalaryTypeKey key)
		{
			return Delete(transactionManager, key.SalaryTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salaryTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salaryTypeId)
		{
			return Delete(null, _salaryTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salaryTypeId);		
		
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
		public override JXTPortal.Entities.SalaryType Get(TransactionManager transactionManager, JXTPortal.Entities.SalaryTypeKey key, int start, int pageLength)
		{
			return GetBySalaryTypeId(transactionManager, key.SalaryTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public JXTPortal.Entities.SalaryType GetBySalaryTypeId(System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(null,_salaryTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public JXTPortal.Entities.SalaryType GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public JXTPortal.Entities.SalaryType GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public JXTPortal.Entities.SalaryType GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public JXTPortal.Entities.SalaryType GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength, out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SalaryType__2EFAF1E2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SalaryType"/> class.</returns>
		public abstract JXTPortal.Entities.SalaryType GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SalaryType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public abstract TList<SalaryType> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SalaryType_Delete 
		
		/// <summary>
		///	This method wrap the 'SalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? salaryTypeId)
		{
			 Delete(null, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? salaryTypeId)
		{
			 Delete(null, start, pageLength , salaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? salaryTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region SalaryType_Update 
		
		/// <summary>
		///	This method wrap the 'SalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , salaryTypeId, salaryTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			 Update(null, start, pageLength , salaryTypeId, salaryTypeName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , salaryTypeId, salaryTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid);
		
		#endregion
		
		#region SalaryType_Insert 
		
		/// <summary>
		///	This method wrap the 'SalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String salaryTypeName, System.Boolean? valid, ref System.Int32? salaryTypeId)
		{
			 Insert(null, 0, int.MaxValue , salaryTypeName, valid, ref salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String salaryTypeName, System.Boolean? valid, ref System.Int32? salaryTypeId)
		{
			 Insert(null, start, pageLength , salaryTypeName, valid, ref salaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String salaryTypeName, System.Boolean? valid, ref System.Int32? salaryTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , salaryTypeName, valid, ref salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String salaryTypeName, System.Boolean? valid, ref System.Int32? salaryTypeId);
		
		#endregion
		
		#region SalaryType_Get_List 
		
		/// <summary>
		///	This method wrap the 'SalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public abstract TList<SalaryType> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SalaryType_GetBySalaryTypeId 
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetBySalaryTypeId(System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetBySalaryTypeId(int start, int pageLength, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, start, pageLength , salaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(transactionManager, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public abstract TList<SalaryType> GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region SalaryType_Find 
		
		/// <summary>
		///	This method wrap the 'SalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Find(System.Boolean? searchUsingOr, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, salaryTypeId, salaryTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, salaryTypeId, salaryTypeName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'SalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public TList<SalaryType> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, salaryTypeId, salaryTypeName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SalaryType&gt;"/> instance.</returns>
		public abstract TList<SalaryType> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? salaryTypeId, System.String salaryTypeName, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalaryType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalaryType&gt;"/></returns>
		public static TList<SalaryType> Fill(IDataReader reader, TList<SalaryType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SalaryType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalaryType")
					.Append("|").Append((System.Int32)reader[((int)SalaryTypeColumn.SalaryTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalaryType>(
					key.ToString(), // EntityTrackingKey
					"SalaryType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SalaryType();
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
					c.SalaryTypeId = (System.Int32)reader[((int)SalaryTypeColumn.SalaryTypeId - 1)];
					c.SalaryTypeName = (System.String)reader[((int)SalaryTypeColumn.SalaryTypeName - 1)];
					c.Valid = (System.Boolean)reader[((int)SalaryTypeColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SalaryType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SalaryType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SalaryType entity)
		{
			if (!reader.Read()) return;
			
			entity.SalaryTypeId = (System.Int32)reader[((int)SalaryTypeColumn.SalaryTypeId - 1)];
			entity.SalaryTypeName = (System.String)reader[((int)SalaryTypeColumn.SalaryTypeName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SalaryTypeColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SalaryType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SalaryType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SalaryType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalaryTypeId = (System.Int32)dataRow["SalaryTypeID"];
			entity.SalaryTypeName = (System.String)dataRow["SalaryTypeName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SalaryType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SalaryType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SalaryType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySalaryTypeId methods when available
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetBySalaryTypeId(transactionManager, entity.SalaryTypeId);

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

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetBySalaryTypeId(transactionManager, entity.SalaryTypeId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteSalaryTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteSalaryType>|SiteSalaryTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteSalaryTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteSalaryTypeCollection = DataRepository.SiteSalaryTypeProvider.GetBySalaryTypeId(transactionManager, entity.SalaryTypeId);

				if (deep && entity.SiteSalaryTypeCollection.Count > 0)
				{
					deepHandles.Add("SiteSalaryTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteSalaryType>) DataRepository.SiteSalaryTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteSalaryTypeCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SalaryType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SalaryType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SalaryType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SalaryType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.SalaryTypeIdSource != null)
						{
							child.SalaryTypeId = child.SalaryTypeIdSource.SalaryTypeId;
						}
						else
						{
							child.SalaryTypeId = entity.SalaryTypeId;
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
						if(child.SalaryTypeIdSource != null)
						{
							child.SalaryTypeId = child.SalaryTypeIdSource.SalaryTypeId;
						}
						else
						{
							child.SalaryTypeId = entity.SalaryTypeId;
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
				
	
			#region List<SiteSalaryType>
				if (CanDeepSave(entity.SiteSalaryTypeCollection, "List<SiteSalaryType>|SiteSalaryTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteSalaryType child in entity.SiteSalaryTypeCollection)
					{
						if(child.SalaryTypeIdSource != null)
						{
							child.SalaryTypeId = child.SalaryTypeIdSource.SalaryTypeId;
						}
						else
						{
							child.SalaryTypeId = entity.SalaryTypeId;
						}

					}

					if (entity.SiteSalaryTypeCollection.Count > 0 || entity.SiteSalaryTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteSalaryTypeProvider.Save(transactionManager, entity.SiteSalaryTypeCollection);
						
						deepHandles.Add("SiteSalaryTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteSalaryType >) DataRepository.SiteSalaryTypeProvider.DeepSave,
							new object[] { transactionManager, entity.SiteSalaryTypeCollection, deepSaveType, childTypes, innerList }
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
	
	#region SalaryTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SalaryType</c>
	///</summary>
	public enum SalaryTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SalaryType</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>SalaryType</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,

		///<summary>
		/// Collection of <c>SalaryType</c> as OneToMany for SiteSalaryTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteSalaryType>))]
		SiteSalaryTypeCollection,
	}
	
	#endregion SalaryTypeChildEntityTypes
	
	#region SalaryTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeFilterBuilder : SqlFilterBuilder<SalaryTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilterBuilder class.
		/// </summary>
		public SalaryTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryTypeFilterBuilder
	
	#region SalaryTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeParameterBuilder : ParameterizedSqlFilterBuilder<SalaryTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeParameterBuilder class.
		/// </summary>
		public SalaryTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryTypeParameterBuilder
	
	#region SalaryTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalaryTypeSortBuilder : SqlSortBuilder<SalaryTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeSqlSortBuilder class.
		/// </summary>
		public SalaryTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalaryTypeSortBuilder
	
} // end namespace
