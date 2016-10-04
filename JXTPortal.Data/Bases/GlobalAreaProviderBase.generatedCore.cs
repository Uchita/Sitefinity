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
	/// This class is the base class for any <see cref="GlobalAreaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GlobalAreaProviderBaseCore : EntityProviderBase<JXTPortal.Entities.GlobalArea, JXTPortal.Entities.GlobalAreaKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.GlobalAreaKey key)
		{
			return Delete(transactionManager, key.AreaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_areaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _areaId)
		{
			return Delete(null, _areaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _areaId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		FK__GlobalAre__Locat__1E0803D9 Description: 
		/// </summary>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		public TList<GlobalArea> GetByLocationId(System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(_locationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		FK__GlobalAre__Locat__1E0803D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalArea> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		FK__GlobalAre__Locat__1E0803D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		public TList<GlobalArea> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		fkGlobalAreLocat1e0803d9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		public TList<GlobalArea> GetByLocationId(System.Int32 _locationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLocationId(null, _locationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		fkGlobalAreLocat1e0803d9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		public TList<GlobalArea> GetByLocationId(System.Int32 _locationId, int start, int pageLength,out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalAre__Locat__1E0803D9 key.
		///		FK__GlobalAre__Locat__1E0803D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalArea objects.</returns>
		public abstract TList<GlobalArea> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.GlobalArea Get(TransactionManager transactionManager, JXTPortal.Entities.GlobalAreaKey key, int start, int pageLength)
		{
			return GetByAreaId(transactionManager, key.AreaId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public JXTPortal.Entities.GlobalArea GetByAreaId(System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(null,_areaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public JXTPortal.Entities.GlobalArea GetByAreaId(System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(null, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public JXTPortal.Entities.GlobalArea GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public JXTPortal.Entities.GlobalArea GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public JXTPortal.Entities.GlobalArea GetByAreaId(System.Int32 _areaId, int start, int pageLength, out int count)
		{
			return GetByAreaId(null, _areaId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalArea__1C1FBB67 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalArea"/> class.</returns>
		public abstract JXTPortal.Entities.GlobalArea GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region GlobalArea_Insert 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String areaName, System.Int32? locationId, System.Boolean? valid, ref System.Int32? areaId)
		{
			 Insert(null, 0, int.MaxValue , areaName, locationId, valid, ref areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String areaName, System.Int32? locationId, System.Boolean? valid, ref System.Int32? areaId)
		{
			 Insert(null, start, pageLength , areaName, locationId, valid, ref areaId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String areaName, System.Int32? locationId, System.Boolean? valid, ref System.Int32? areaId)
		{
			 Insert(transactionManager, 0, int.MaxValue , areaName, locationId, valid, ref areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String areaName, System.Int32? locationId, System.Boolean? valid, ref System.Int32? areaId);
		
		#endregion
		
		#region GlobalArea_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByLocationId(System.Int32? locationId)
		{
			return GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByLocationId(int start, int pageLength, System.Int32? locationId)
		{
			return GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByLocationId(TransactionManager transactionManager, System.Int32? locationId)
		{
			return GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public abstract TList<GlobalArea> GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region GlobalArea_Get_List 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public abstract TList<GlobalArea> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region GlobalArea_GetPaged 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public abstract TList<GlobalArea> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region GlobalArea_Find 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Find(System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, areaId, areaName, locationId, valid);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public abstract TList<GlobalArea> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid);
		
		#endregion
		
		#region GlobalArea_Delete 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? areaId)
		{
			 Delete(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? areaId)
		{
			 Delete(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? areaId)
		{
			 Delete(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region GlobalArea_GetByAreaId 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByAreaId(System.Int32? areaId)
		{
			return GetByAreaId(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByAreaId(int start, int pageLength, System.Int32? areaId)
		{
			return GetByAreaId(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public TList<GlobalArea> GetByAreaId(TransactionManager transactionManager, System.Int32? areaId)
		{
			return GetByAreaId(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalArea&gt;"/> instance.</returns>
		public abstract TList<GlobalArea> GetByAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region GlobalArea_Update 
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Update' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Update' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			 Update(null, start, pageLength , areaId, areaName, locationId, valid);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalArea_Update' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalArea_Update' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;GlobalArea&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;GlobalArea&gt;"/></returns>
		public static TList<GlobalArea> Fill(IDataReader reader, TList<GlobalArea> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.GlobalArea c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("GlobalArea")
					.Append("|").Append((System.Int32)reader[((int)GlobalAreaColumn.AreaId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<GlobalArea>(
					key.ToString(), // EntityTrackingKey
					"GlobalArea",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.GlobalArea();
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
					c.AreaId = (System.Int32)reader[((int)GlobalAreaColumn.AreaId - 1)];
					c.AreaName = (System.String)reader[((int)GlobalAreaColumn.AreaName - 1)];
					c.LocationId = (System.Int32)reader[((int)GlobalAreaColumn.LocationId - 1)];
					c.Valid = (System.Boolean)reader[((int)GlobalAreaColumn.Valid - 1)];
					c.Sequence = (reader.IsDBNull(((int)GlobalAreaColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)GlobalAreaColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalArea"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalArea"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.GlobalArea entity)
		{
			if (!reader.Read()) return;
			
			entity.AreaId = (System.Int32)reader[((int)GlobalAreaColumn.AreaId - 1)];
			entity.AreaName = (System.String)reader[((int)GlobalAreaColumn.AreaName - 1)];
			entity.LocationId = (System.Int32)reader[((int)GlobalAreaColumn.LocationId - 1)];
			entity.Valid = (System.Boolean)reader[((int)GlobalAreaColumn.Valid - 1)];
			entity.Sequence = (reader.IsDBNull(((int)GlobalAreaColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)GlobalAreaColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalArea"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalArea"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.GlobalArea entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AreaId = (System.Int32)dataRow["AreaID"];
			entity.AreaName = (System.String)dataRow["AreaName"];
			entity.LocationId = (System.Int32)dataRow["LocationID"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalArea"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalArea Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.GlobalArea entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LocationIdSource	
			if (CanDeepLoad(entity, "GlobalLocation|LocationIdSource", deepLoadType, innerList) 
				&& entity.LocationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LocationId;
				GlobalLocation tmpEntity = EntityManager.LocateEntity<GlobalLocation>(EntityLocator.ConstructKeyFromPkItems(typeof(GlobalLocation), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LocationIdSource = tmpEntity;
				else
					entity.LocationIdSource = DataRepository.GlobalLocationProvider.GetByLocationId(transactionManager, entity.LocationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LocationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.GlobalLocationProvider.DeepLoad(transactionManager, entity.LocationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LocationIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.GlobalArea object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.GlobalArea instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalArea Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.GlobalArea entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LocationIdSource
			if (CanDeepSave(entity, "GlobalLocation|LocationIdSource", deepSaveType, innerList) 
				&& entity.LocationIdSource != null)
			{
				DataRepository.GlobalLocationProvider.Save(transactionManager, entity.LocationIdSource);
				entity.LocationId = entity.LocationIdSource.LocationId;
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
	
	#region GlobalAreaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.GlobalArea</c>
	///</summary>
	public enum GlobalAreaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>GlobalLocation</c> at LocationIdSource
		///</summary>
		[ChildEntityType(typeof(GlobalLocation))]
		GlobalLocation,
		}
	
	#endregion GlobalAreaChildEntityTypes
	
	#region GlobalAreaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GlobalAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalAreaFilterBuilder : SqlFilterBuilder<GlobalAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilterBuilder class.
		/// </summary>
		public GlobalAreaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalAreaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalAreaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalAreaFilterBuilder
	
	#region GlobalAreaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GlobalAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalAreaParameterBuilder : ParameterizedSqlFilterBuilder<GlobalAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalAreaParameterBuilder class.
		/// </summary>
		public GlobalAreaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalAreaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalAreaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalAreaParameterBuilder
	
	#region GlobalAreaSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;GlobalAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalArea"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class GlobalAreaSortBuilder : SqlSortBuilder<GlobalAreaColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalAreaSqlSortBuilder class.
		/// </summary>
		public GlobalAreaSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion GlobalAreaSortBuilder
	
} // end namespace
