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
	/// This class is the base class for any <see cref="AreaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AreaProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Area, JXTPortal.Entities.AreaKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AreaKey key)
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
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		FK__Area__LocationID__3F3159AB Description: 
		/// </summary>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		public TList<Area> GetByLocationId(System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(_locationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		FK__Area__LocationID__3F3159AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		/// <remarks></remarks>
		public TList<Area> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		FK__Area__LocationID__3F3159AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		public TList<Area> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		fkAreaLocationId3f3159Ab Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		public TList<Area> GetByLocationId(System.Int32 _locationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLocationId(null, _locationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		fkAreaLocationId3f3159Ab Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		public TList<Area> GetByLocationId(System.Int32 _locationId, int start, int pageLength,out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Area__LocationID__3F3159AB key.
		///		FK__Area__LocationID__3F3159AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Area objects.</returns>
		public abstract TList<Area> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Area Get(TransactionManager transactionManager, JXTPortal.Entities.AreaKey key, int start, int pageLength)
		{
			return GetByAreaId(transactionManager, key.AreaId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public JXTPortal.Entities.Area GetByAreaId(System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(null,_areaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public JXTPortal.Entities.Area GetByAreaId(System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(null, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public JXTPortal.Entities.Area GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public JXTPortal.Entities.Area GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public JXTPortal.Entities.Area GetByAreaId(System.Int32 _areaId, int start, int pageLength, out int count)
		{
			return GetByAreaId(null, _areaId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Area__1FB8AE52 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Area"/> class.</returns>
		public abstract JXTPortal.Entities.Area GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Area_Insert 
		
		/// <summary>
		///	This method wrap the 'Area_Insert' stored procedure. 
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
		///	This method wrap the 'Area_Insert' stored procedure. 
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
		///	This method wrap the 'Area_Insert' stored procedure. 
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
		///	This method wrap the 'Area_Insert' stored procedure. 
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
		
		#region Area_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'Area_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByLocationId(System.Int32? locationId)
		{
			return GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByLocationId(int start, int pageLength, System.Int32? locationId)
		{
			return GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'Area_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByLocationId(TransactionManager transactionManager, System.Int32? locationId)
		{
			return GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public abstract TList<Area> GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region Area_Get_List 
		
		/// <summary>
		///	This method wrap the 'Area_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Area_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Area_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Area_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public abstract TList<Area> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Area_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Area_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Area_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public abstract TList<Area> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Area_GetSiteTree 
		
		/// <summary>
		///	This method wrap the 'Area_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(System.Int32? siteId)
		{
			return GetSiteTree(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(int start, int pageLength, System.Int32? siteId)
		{
			return GetSiteTree(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Area_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetSiteTree(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSiteTree(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Area_Find 
		
		/// <summary>
		///	This method wrap the 'Area_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Find(System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Area_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, areaId, areaName, locationId, valid);
		}
				
		/// <summary>
		///	This method wrap the 'Area_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaName"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, areaId, areaName, locationId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Area_Find' stored procedure. 
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
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public abstract TList<Area> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? areaId, System.String areaName, System.Int32? locationId, System.Boolean? valid);
		
		#endregion
		
		#region Area_Delete 
		
		/// <summary>
		///	This method wrap the 'Area_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? areaId)
		{
			 Delete(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_Delete' stored procedure. 
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
		///	This method wrap the 'Area_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? areaId)
		{
			 Delete(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_Delete' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region Area_GetDetailWithSite 
		
		/// <summary>
		///	This method wrap the 'Area_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(System.Int32? siteId, System.Int32? areaId)
		{
			return GetDetailWithSite(null, 0, int.MaxValue , siteId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(int start, int pageLength, System.Int32? siteId, System.Int32? areaId)
		{
			return GetDetailWithSite(null, start, pageLength , siteId, areaId);
		}
				
		/// <summary>
		///	This method wrap the 'Area_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(TransactionManager transactionManager, System.Int32? siteId, System.Int32? areaId)
		{
			return GetDetailWithSite(transactionManager, 0, int.MaxValue , siteId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetDetailWithSite(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? areaId);
		
		#endregion
		
		#region Area_Update 
		
		/// <summary>
		///	This method wrap the 'Area_Update' stored procedure. 
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
		///	This method wrap the 'Area_Update' stored procedure. 
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
		///	This method wrap the 'Area_Update' stored procedure. 
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
		///	This method wrap the 'Area_Update' stored procedure. 
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
		
		#region Area_GetByAreaId 
		
		/// <summary>
		///	This method wrap the 'Area_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByAreaId(System.Int32? areaId)
		{
			return GetByAreaId(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByAreaId(int start, int pageLength, System.Int32? areaId)
		{
			return GetByAreaId(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'Area_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public TList<Area> GetByAreaId(TransactionManager transactionManager, System.Int32? areaId)
		{
			return GetByAreaId(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'Area_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Area&gt;"/> instance.</returns>
		public abstract TList<Area> GetByAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Area&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Area&gt;"/></returns>
		public static TList<Area> Fill(IDataReader reader, TList<Area> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Area c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Area")
					.Append("|").Append((System.Int32)reader[((int)AreaColumn.AreaId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Area>(
					key.ToString(), // EntityTrackingKey
					"Area",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Area();
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
					c.AreaId = (System.Int32)reader[((int)AreaColumn.AreaId - 1)];
					c.AreaName = (System.String)reader[((int)AreaColumn.AreaName - 1)];
					c.LocationId = (System.Int32)reader[((int)AreaColumn.LocationId - 1)];
					c.Valid = (System.Boolean)reader[((int)AreaColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Area"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Area"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Area entity)
		{
			if (!reader.Read()) return;
			
			entity.AreaId = (System.Int32)reader[((int)AreaColumn.AreaId - 1)];
			entity.AreaName = (System.String)reader[((int)AreaColumn.AreaName - 1)];
			entity.LocationId = (System.Int32)reader[((int)AreaColumn.LocationId - 1)];
			entity.Valid = (System.Boolean)reader[((int)AreaColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Area"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Area"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Area entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AreaId = (System.Int32)dataRow["AreaID"];
			entity.AreaName = (System.String)dataRow["AreaName"];
			entity.LocationId = (System.Int32)dataRow["LocationID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Area"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Area Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Area entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LocationIdSource	
			if (CanDeepLoad(entity, "Location|LocationIdSource", deepLoadType, innerList) 
				&& entity.LocationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LocationId;
				Location tmpEntity = EntityManager.LocateEntity<Location>(EntityLocator.ConstructKeyFromPkItems(typeof(Location), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LocationIdSource = tmpEntity;
				else
					entity.LocationIdSource = DataRepository.LocationProvider.GetByLocationId(transactionManager, entity.LocationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LocationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LocationProvider.DeepLoad(transactionManager, entity.LocationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LocationIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAreaId methods when available
			
			#region SiteAreaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteArea>|SiteAreaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteAreaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteAreaCollection = DataRepository.SiteAreaProvider.GetByAreaId(transactionManager, entity.AreaId);

				if (deep && entity.SiteAreaCollection.Count > 0)
				{
					deepHandles.Add("SiteAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteArea>) DataRepository.SiteAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteAreaCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobAreaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobArea>|JobAreaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobAreaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobAreaCollection = DataRepository.JobAreaProvider.GetByAreaId(transactionManager, entity.AreaId);

				if (deep && entity.JobAreaCollection.Count > 0)
				{
					deepHandles.Add("JobAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobArea>) DataRepository.JobAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.JobAreaCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Area object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Area instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Area Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Area entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LocationIdSource
			if (CanDeepSave(entity, "Location|LocationIdSource", deepSaveType, innerList) 
				&& entity.LocationIdSource != null)
			{
				DataRepository.LocationProvider.Save(transactionManager, entity.LocationIdSource);
				entity.LocationId = entity.LocationIdSource.LocationId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SiteArea>
				if (CanDeepSave(entity.SiteAreaCollection, "List<SiteArea>|SiteAreaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteArea child in entity.SiteAreaCollection)
					{
						if(child.AreaIdSource != null)
						{
							child.AreaId = child.AreaIdSource.AreaId;
						}
						else
						{
							child.AreaId = entity.AreaId;
						}

					}

					if (entity.SiteAreaCollection.Count > 0 || entity.SiteAreaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteAreaProvider.Save(transactionManager, entity.SiteAreaCollection);
						
						deepHandles.Add("SiteAreaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteArea >) DataRepository.SiteAreaProvider.DeepSave,
							new object[] { transactionManager, entity.SiteAreaCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobArea>
				if (CanDeepSave(entity.JobAreaCollection, "List<JobArea>|JobAreaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobArea child in entity.JobAreaCollection)
					{
						if(child.AreaIdSource != null)
						{
							child.AreaId = child.AreaIdSource.AreaId;
						}
						else
						{
							child.AreaId = entity.AreaId;
						}

					}

					if (entity.JobAreaCollection.Count > 0 || entity.JobAreaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobAreaProvider.Save(transactionManager, entity.JobAreaCollection);
						
						deepHandles.Add("JobAreaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobArea >) DataRepository.JobAreaProvider.DeepSave,
							new object[] { transactionManager, entity.JobAreaCollection, deepSaveType, childTypes, innerList }
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
	
	#region AreaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Area</c>
	///</summary>
	public enum AreaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Location</c> at LocationIdSource
		///</summary>
		[ChildEntityType(typeof(Location))]
		Location,
	
		///<summary>
		/// Collection of <c>Area</c> as OneToMany for SiteAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteArea>))]
		SiteAreaCollection,

		///<summary>
		/// Collection of <c>Area</c> as OneToMany for JobAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobArea>))]
		JobAreaCollection,
	}
	
	#endregion AreaChildEntityTypes
	
	#region AreaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaFilterBuilder : SqlFilterBuilder<AreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaFilterBuilder class.
		/// </summary>
		public AreaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaFilterBuilder
	
	#region AreaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaParameterBuilder : ParameterizedSqlFilterBuilder<AreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaParameterBuilder class.
		/// </summary>
		public AreaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaParameterBuilder
	
	#region AreaSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AreaSortBuilder : SqlSortBuilder<AreaColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaSqlSortBuilder class.
		/// </summary>
		public AreaSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AreaSortBuilder
	
} // end namespace
