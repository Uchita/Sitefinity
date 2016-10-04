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
	/// This class is the base class for any <see cref="GlobalLocationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GlobalLocationProviderBaseCore : EntityProviderBase<JXTPortal.Entities.GlobalLocation, JXTPortal.Entities.GlobalLocationKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.GlobalLocationKey key)
		{
			return Delete(transactionManager, key.LocationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_locationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _locationId)
		{
			return Delete(null, _locationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _locationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		FK__GlobalLoc__Count__1A3772F5 Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		public TList<GlobalLocation> GetByCountryId(System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		FK__GlobalLoc__Count__1A3772F5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalLocation> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		FK__GlobalLoc__Count__1A3772F5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		public TList<GlobalLocation> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		fkGlobalLocCount1a3772f5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		public TList<GlobalLocation> GetByCountryId(System.Int32 _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		fkGlobalLocCount1a3772f5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		public TList<GlobalLocation> GetByCountryId(System.Int32 _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalLoc__Count__1A3772F5 key.
		///		FK__GlobalLoc__Count__1A3772F5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalLocation objects.</returns>
		public abstract TList<GlobalLocation> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.GlobalLocation Get(TransactionManager transactionManager, JXTPortal.Entities.GlobalLocationKey key, int start, int pageLength)
		{
			return GetByLocationId(transactionManager, key.LocationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="_locationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public JXTPortal.Entities.GlobalLocation GetByLocationId(System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(null,_locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public JXTPortal.Entities.GlobalLocation GetByLocationId(System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(null, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public JXTPortal.Entities.GlobalLocation GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public JXTPortal.Entities.GlobalLocation GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public JXTPortal.Entities.GlobalLocation GetByLocationId(System.Int32 _locationId, int start, int pageLength, out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__GlobalLocation__184F2A83 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalLocation"/> class.</returns>
		public abstract JXTPortal.Entities.GlobalLocation GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region GlobalLocation_Insert 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String locationName, System.Int32? countryId, System.Boolean? valid, ref System.Int32? locationId)
		{
			 Insert(null, 0, int.MaxValue , locationName, countryId, valid, ref locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String locationName, System.Int32? countryId, System.Boolean? valid, ref System.Int32? locationId)
		{
			 Insert(null, start, pageLength , locationName, countryId, valid, ref locationId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String locationName, System.Int32? countryId, System.Boolean? valid, ref System.Int32? locationId)
		{
			 Insert(transactionManager, 0, int.MaxValue , locationName, countryId, valid, ref locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String locationName, System.Int32? countryId, System.Boolean? valid, ref System.Int32? locationId);
		
		#endregion
		
		#region GlobalLocation_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByLocationId(System.Int32? locationId)
		{
			return GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByLocationId(int start, int pageLength, System.Int32? locationId)
		{
			return GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByLocationId(TransactionManager transactionManager, System.Int32? locationId)
		{
			return GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public abstract TList<GlobalLocation> GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region GlobalLocation_Get_List 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public abstract TList<GlobalLocation> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region GlobalLocation_GetPaged 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public abstract TList<GlobalLocation> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region GlobalLocation_GetByCountryId 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByCountryId(System.Int32? countryId)
		{
			return GetByCountryId(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByCountryId(int start, int pageLength, System.Int32? countryId)
		{
			return GetByCountryId(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> GetByCountryId(TransactionManager transactionManager, System.Int32? countryId)
		{
			return GetByCountryId(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public abstract TList<GlobalLocation> GetByCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId);
		
		#endregion
		
		#region GlobalLocation_Find 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Find(System.Boolean? searchUsingOr, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, locationId, locationName, countryId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, locationId, locationName, countryId, valid);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public TList<GlobalLocation> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, locationId, locationName, countryId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;GlobalLocation&gt;"/> instance.</returns>
		public abstract TList<GlobalLocation> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid);
		
		#endregion
		
		#region GlobalLocation_Delete 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? locationId)
		{
			 Delete(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? locationId)
		{
			 Delete(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? locationId)
		{
			 Delete(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region GlobalLocation_Update 
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , locationId, locationName, countryId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			 Update(null, start, pageLength , locationId, locationName, countryId, valid);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , locationId, locationName, countryId, valid);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationName"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId, System.String locationName, System.Int32? countryId, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;GlobalLocation&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;GlobalLocation&gt;"/></returns>
		public static TList<GlobalLocation> Fill(IDataReader reader, TList<GlobalLocation> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.GlobalLocation c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("GlobalLocation")
					.Append("|").Append((System.Int32)reader[((int)GlobalLocationColumn.LocationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<GlobalLocation>(
					key.ToString(), // EntityTrackingKey
					"GlobalLocation",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.GlobalLocation();
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
					c.LocationId = (System.Int32)reader[((int)GlobalLocationColumn.LocationId - 1)];
					c.LocationName = (System.String)reader[((int)GlobalLocationColumn.LocationName - 1)];
					c.CountryId = (System.Int32)reader[((int)GlobalLocationColumn.CountryId - 1)];
					c.Valid = (System.Boolean)reader[((int)GlobalLocationColumn.Valid - 1)];
					c.Sequence = (reader.IsDBNull(((int)GlobalLocationColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)GlobalLocationColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalLocation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalLocation"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.GlobalLocation entity)
		{
			if (!reader.Read()) return;
			
			entity.LocationId = (System.Int32)reader[((int)GlobalLocationColumn.LocationId - 1)];
			entity.LocationName = (System.String)reader[((int)GlobalLocationColumn.LocationName - 1)];
			entity.CountryId = (System.Int32)reader[((int)GlobalLocationColumn.CountryId - 1)];
			entity.Valid = (System.Boolean)reader[((int)GlobalLocationColumn.Valid - 1)];
			entity.Sequence = (reader.IsDBNull(((int)GlobalLocationColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)GlobalLocationColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalLocation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalLocation"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.GlobalLocation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LocationId = (System.Int32)dataRow["LocationID"];
			entity.LocationName = (System.String)dataRow["LocationName"];
			entity.CountryId = (System.Int32)dataRow["CountryID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalLocation"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalLocation Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.GlobalLocation entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Countries|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CountryId;
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountriesProvider.GetByCountryId(transactionManager, entity.CountryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.CountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByLocationId methods when available
			
			#region GlobalAreaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalArea>|GlobalAreaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalAreaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalAreaCollection = DataRepository.GlobalAreaProvider.GetByLocationId(transactionManager, entity.LocationId);

				if (deep && entity.GlobalAreaCollection.Count > 0)
				{
					deepHandles.Add("GlobalAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalArea>) DataRepository.GlobalAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalAreaCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.GlobalLocation object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.GlobalLocation instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalLocation Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.GlobalLocation entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Countries|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.CountryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<GlobalArea>
				if (CanDeepSave(entity.GlobalAreaCollection, "List<GlobalArea>|GlobalAreaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalArea child in entity.GlobalAreaCollection)
					{
						if(child.LocationIdSource != null)
						{
							child.LocationId = child.LocationIdSource.LocationId;
						}
						else
						{
							child.LocationId = entity.LocationId;
						}

					}

					if (entity.GlobalAreaCollection.Count > 0 || entity.GlobalAreaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalAreaProvider.Save(transactionManager, entity.GlobalAreaCollection);
						
						deepHandles.Add("GlobalAreaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalArea >) DataRepository.GlobalAreaProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalAreaCollection, deepSaveType, childTypes, innerList }
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
	
	#region GlobalLocationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.GlobalLocation</c>
	///</summary>
	public enum GlobalLocationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
	
		///<summary>
		/// Collection of <c>GlobalLocation</c> as OneToMany for GlobalAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalArea>))]
		GlobalAreaCollection,
	}
	
	#endregion GlobalLocationChildEntityTypes
	
	#region GlobalLocationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GlobalLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalLocationFilterBuilder : SqlFilterBuilder<GlobalLocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilterBuilder class.
		/// </summary>
		public GlobalLocationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalLocationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalLocationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalLocationFilterBuilder
	
	#region GlobalLocationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GlobalLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalLocationParameterBuilder : ParameterizedSqlFilterBuilder<GlobalLocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalLocationParameterBuilder class.
		/// </summary>
		public GlobalLocationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalLocationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalLocationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalLocationParameterBuilder
	
	#region GlobalLocationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;GlobalLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalLocation"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class GlobalLocationSortBuilder : SqlSortBuilder<GlobalLocationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalLocationSqlSortBuilder class.
		/// </summary>
		public GlobalLocationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion GlobalLocationSortBuilder
	
} // end namespace
