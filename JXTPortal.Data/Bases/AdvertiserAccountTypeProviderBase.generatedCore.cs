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
	/// This class is the base class for any <see cref="AdvertiserAccountTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertiserAccountTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdvertiserAccountType, JXTPortal.Entities.AdvertiserAccountTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserAccountTypeKey key)
		{
			return Delete(transactionManager, key.AdvertiserAccountTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserAccountTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserAccountTypeId)
		{
			return Delete(null, _advertiserAccountTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId);		
		
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
		public override JXTPortal.Entities.AdvertiserAccountType Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserAccountTypeKey key, int start, int pageLength)
		{
			return GetByAdvertiserAccountTypeId(transactionManager, key.AdvertiserAccountTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(null,_advertiserAccountTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(null, _advertiserAccountTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(transactionManager, _advertiserAccountTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(transactionManager, _advertiserAccountTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserAccountTypeId(null, _advertiserAccountTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserAccoun__023D5A04 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserAccountType GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdvertiserAccountType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public abstract TList<AdvertiserAccountType> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region AdvertiserAccountType_Delete 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserAccountTypeId)
		{
			 Delete(null, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserAccountTypeId)
		{
			 Delete(null, start, pageLength , advertiserAccountTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserAccountTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserAccountTypeId);
		
		#endregion
		
		#region AdvertiserAccountType_Update 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			 Update(null, 0, int.MaxValue , advertiserAccountTypeId, advertiserAccountTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			 Update(null, start, pageLength , advertiserAccountTypeId, advertiserAccountTypeName);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserAccountTypeId, advertiserAccountTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName);
		
		#endregion
		
		#region AdvertiserAccountType_Insert 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String advertiserAccountTypeName, ref System.Int32? advertiserAccountTypeId)
		{
			 Insert(null, 0, int.MaxValue , advertiserAccountTypeName, ref advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String advertiserAccountTypeName, ref System.Int32? advertiserAccountTypeId)
		{
			 Insert(null, start, pageLength , advertiserAccountTypeName, ref advertiserAccountTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String advertiserAccountTypeName, ref System.Int32? advertiserAccountTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserAccountTypeName, ref advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String advertiserAccountTypeName, ref System.Int32? advertiserAccountTypeId);
		
		#endregion
		
		#region AdvertiserAccountType_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public abstract TList<AdvertiserAccountType> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdvertiserAccountType_GetByAdvertiserAccountTypeId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetByAdvertiserAccountTypeId(System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(null, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetByAdvertiserAccountTypeId(int start, int pageLength, System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(null, start, pageLength , advertiserAccountTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(transactionManager, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public abstract TList<AdvertiserAccountType> GetByAdvertiserAccountTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserAccountTypeId);
		
		#endregion
		
		#region AdvertiserAccountType_Find 
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Find(System.Boolean? searchUsingOr, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserAccountTypeId, advertiserAccountTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserAccountTypeId, advertiserAccountTypeName);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public TList<AdvertiserAccountType> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserAccountTypeId, advertiserAccountTypeName);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserAccountType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserAccountType&gt;"/> instance.</returns>
		public abstract TList<AdvertiserAccountType> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserAccountTypeId, System.String advertiserAccountTypeName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdvertiserAccountType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdvertiserAccountType&gt;"/></returns>
		public static TList<AdvertiserAccountType> Fill(IDataReader reader, TList<AdvertiserAccountType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdvertiserAccountType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdvertiserAccountType")
					.Append("|").Append((System.Int32)reader[((int)AdvertiserAccountTypeColumn.AdvertiserAccountTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdvertiserAccountType>(
					key.ToString(), // EntityTrackingKey
					"AdvertiserAccountType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdvertiserAccountType();
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
					c.AdvertiserAccountTypeId = (System.Int32)reader[((int)AdvertiserAccountTypeColumn.AdvertiserAccountTypeId - 1)];
					c.AdvertiserAccountTypeName = (System.String)reader[((int)AdvertiserAccountTypeColumn.AdvertiserAccountTypeName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserAccountType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdvertiserAccountType entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserAccountTypeId = (System.Int32)reader[((int)AdvertiserAccountTypeColumn.AdvertiserAccountTypeId - 1)];
			entity.AdvertiserAccountTypeName = (System.String)reader[((int)AdvertiserAccountTypeColumn.AdvertiserAccountTypeName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserAccountType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserAccountType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdvertiserAccountType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserAccountTypeId = (System.Int32)dataRow["AdvertiserAccountTypeID"];
			entity.AdvertiserAccountTypeName = (System.String)dataRow["AdvertiserAccountTypeName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserAccountType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserAccountType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserAccountType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAdvertiserAccountTypeId methods when available
			
			#region AdvertisersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Advertisers>|AdvertisersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertisersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertisersCollection = DataRepository.AdvertisersProvider.GetByAdvertiserAccountTypeId(transactionManager, entity.AdvertiserAccountTypeId);

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdvertiserAccountType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdvertiserAccountType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserAccountType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserAccountType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.AdvertiserAccountTypeIdSource != null)
						{
							child.AdvertiserAccountTypeId = child.AdvertiserAccountTypeIdSource.AdvertiserAccountTypeId;
						}
						else
						{
							child.AdvertiserAccountTypeId = entity.AdvertiserAccountTypeId;
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
	
	#region AdvertiserAccountTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdvertiserAccountType</c>
	///</summary>
	public enum AdvertiserAccountTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdvertiserAccountType</c> as OneToMany for AdvertisersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Advertisers>))]
		AdvertisersCollection,
	}
	
	#endregion AdvertiserAccountTypeChildEntityTypes
	
	#region AdvertiserAccountTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertiserAccountTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeFilterBuilder : SqlFilterBuilder<AdvertiserAccountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilterBuilder class.
		/// </summary>
		public AdvertiserAccountTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountTypeFilterBuilder
	
	#region AdvertiserAccountTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertiserAccountTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeParameterBuilder : ParameterizedSqlFilterBuilder<AdvertiserAccountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeParameterBuilder class.
		/// </summary>
		public AdvertiserAccountTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountTypeParameterBuilder
	
	#region AdvertiserAccountTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertiserAccountTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertiserAccountTypeSortBuilder : SqlSortBuilder<AdvertiserAccountTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeSqlSortBuilder class.
		/// </summary>
		public AdvertiserAccountTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertiserAccountTypeSortBuilder
	
} // end namespace
