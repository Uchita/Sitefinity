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
	/// This class is the base class for any <see cref="AdvertiserBusinessTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertiserBusinessTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdvertiserBusinessType, JXTPortal.Entities.AdvertiserBusinessTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserBusinessTypeKey key)
		{
			return Delete(transactionManager, key.AdvertiserBusinessTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserBusinessTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserBusinessTypeId)
		{
			return Delete(null, _advertiserBusinessTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId);		
		
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
		public override JXTPortal.Entities.AdvertiserBusinessType Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserBusinessTypeKey key, int start, int pageLength)
		{
			return GetByAdvertiserBusinessTypeId(transactionManager, key.AdvertiserBusinessTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(null,_advertiserBusinessTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(null, _advertiserBusinessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(transactionManager, _advertiserBusinessTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(transactionManager, _advertiserBusinessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserBusinessTypeId(null, _advertiserBusinessTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserBusine__0425A276 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserBusinessType GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdvertiserBusinessType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserBusinessType_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserBusinessType_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserBusinessType_GetPaged' stored procedure. 
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
		
		#region AdvertiserBusinessType_Delete 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserBusinessTypeId)
		{
			 Delete(null, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserBusinessTypeId)
		{
			 Delete(null, start, pageLength , advertiserBusinessTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserBusinessTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserBusinessTypeId);
		
		#endregion
		
		#region AdvertiserBusinessType_Update 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			 Update(null, 0, int.MaxValue , advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			 Update(null, start, pageLength , advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName);
		
		#endregion
		
		#region AdvertiserBusinessType_Insert 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String advertiserBusinessTypeName, ref System.Int32? advertiserBusinessTypeId)
		{
			 Insert(null, 0, int.MaxValue , advertiserBusinessTypeName, ref advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String advertiserBusinessTypeName, ref System.Int32? advertiserBusinessTypeId)
		{
			 Insert(null, start, pageLength , advertiserBusinessTypeName, ref advertiserBusinessTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String advertiserBusinessTypeName, ref System.Int32? advertiserBusinessTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserBusinessTypeName, ref advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String advertiserBusinessTypeName, ref System.Int32? advertiserBusinessTypeId);
		
		#endregion
		
		#region AdvertiserBusinessType_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Get_List' stored procedure. 
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
		///	This method wrap the 'AdvertiserBusinessType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdvertiserBusinessType_GetByAdvertiserBusinessTypeId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(null, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(int start, int pageLength, System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(null, start, pageLength , advertiserBusinessTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(transactionManager, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserBusinessTypeId);
		
		#endregion
		
		#region AdvertiserBusinessType_Find 
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserBusinessTypeId, advertiserBusinessTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserBusinessType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserBusinessTypeId, System.String advertiserBusinessTypeName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdvertiserBusinessType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdvertiserBusinessType&gt;"/></returns>
		public static TList<AdvertiserBusinessType> Fill(IDataReader reader, TList<AdvertiserBusinessType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdvertiserBusinessType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdvertiserBusinessType")
					.Append("|").Append((System.Int32)reader[((int)AdvertiserBusinessTypeColumn.AdvertiserBusinessTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdvertiserBusinessType>(
					key.ToString(), // EntityTrackingKey
					"AdvertiserBusinessType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdvertiserBusinessType();
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
					c.AdvertiserBusinessTypeId = (System.Int32)reader[((int)AdvertiserBusinessTypeColumn.AdvertiserBusinessTypeId - 1)];
					c.AdvertiserBusinessTypeName = (System.String)reader[((int)AdvertiserBusinessTypeColumn.AdvertiserBusinessTypeName - 1)];
					c.SiteId = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.SiteId - 1)];
					c.BusinessTypeParentId = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.BusinessTypeParentId - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.BusinessTypeParentId - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)AdvertiserBusinessTypeColumn.GlobalTemplate - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.LastModifiedBy - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserBusinessTypeColumn.LastModifiedDate - 1)];
					c.Sequence = (System.Int32)reader[((int)AdvertiserBusinessTypeColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdvertiserBusinessType entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserBusinessTypeId = (System.Int32)reader[((int)AdvertiserBusinessTypeColumn.AdvertiserBusinessTypeId - 1)];
			entity.AdvertiserBusinessTypeName = (System.String)reader[((int)AdvertiserBusinessTypeColumn.AdvertiserBusinessTypeName - 1)];
			entity.SiteId = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.SiteId - 1)];
			entity.BusinessTypeParentId = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.BusinessTypeParentId - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.BusinessTypeParentId - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)AdvertiserBusinessTypeColumn.GlobalTemplate - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)AdvertiserBusinessTypeColumn.LastModifiedBy - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)AdvertiserBusinessTypeColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserBusinessTypeColumn.LastModifiedDate - 1)];
			entity.Sequence = (System.Int32)reader[((int)AdvertiserBusinessTypeColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdvertiserBusinessType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserBusinessTypeId = (System.Int32)dataRow["AdvertiserBusinessTypeID"];
			entity.AdvertiserBusinessTypeName = (System.String)dataRow["AdvertiserBusinessTypeName"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.BusinessTypeParentId = Convert.IsDBNull(dataRow["BusinessTypeParentID"]) ? null : (System.Int32?)dataRow["BusinessTypeParentID"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModifiedDate = Convert.IsDBNull(dataRow["LastModifiedDate"]) ? null : (System.DateTime?)dataRow["LastModifiedDate"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserBusinessType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserBusinessType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserBusinessType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAdvertiserBusinessTypeId methods when available
			
			#region AdvertisersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Advertisers>|AdvertisersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertisersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertisersCollection = DataRepository.AdvertisersProvider.GetByAdvertiserBusinessTypeId(transactionManager, entity.AdvertiserBusinessTypeId);

				if (deep && entity.AdvertisersCollection.Count > 0)
				{
					deepHandles.Add("AdvertisersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Advertisers>) DataRepository.AdvertisersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertisersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdvertiserBusinessType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdvertiserBusinessType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserBusinessType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserBusinessType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Advertisers>
				if (CanDeepSave(entity.AdvertisersCollection, "List<Advertisers>|AdvertisersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Advertisers child in entity.AdvertisersCollection)
					{
						if(child.AdvertiserBusinessTypeIdSource != null)
						{
							child.AdvertiserBusinessTypeId = child.AdvertiserBusinessTypeIdSource.AdvertiserBusinessTypeId;
						}
						else
						{
							child.AdvertiserBusinessTypeId = entity.AdvertiserBusinessTypeId;
						}

					}

					if (entity.AdvertisersCollection.Count > 0 || entity.AdvertisersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertisersProvider.Save(transactionManager, entity.AdvertisersCollection);
						
						deepHandles.Add("AdvertisersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Advertisers >) DataRepository.AdvertisersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertisersCollection, deepSaveType, childTypes, innerList }
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
	
	#region AdvertiserBusinessTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdvertiserBusinessType</c>
	///</summary>
	public enum AdvertiserBusinessTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdvertiserBusinessType</c> as OneToMany for AdvertisersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Advertisers>))]
		AdvertisersCollection,
	}
	
	#endregion AdvertiserBusinessTypeChildEntityTypes
	
	#region AdvertiserBusinessTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertiserBusinessTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeFilterBuilder : SqlFilterBuilder<AdvertiserBusinessTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilterBuilder class.
		/// </summary>
		public AdvertiserBusinessTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserBusinessTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserBusinessTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserBusinessTypeFilterBuilder
	
	#region AdvertiserBusinessTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertiserBusinessTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeParameterBuilder : ParameterizedSqlFilterBuilder<AdvertiserBusinessTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeParameterBuilder class.
		/// </summary>
		public AdvertiserBusinessTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserBusinessTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserBusinessTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserBusinessTypeParameterBuilder
	
	#region AdvertiserBusinessTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertiserBusinessTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertiserBusinessTypeSortBuilder : SqlSortBuilder<AdvertiserBusinessTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeSqlSortBuilder class.
		/// </summary>
		public AdvertiserBusinessTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertiserBusinessTypeSortBuilder
	
} // end namespace
