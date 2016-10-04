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
	/// This class is the base class for any <see cref="SiteAreaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteAreaProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteArea, JXTPortal.Entities.SiteAreaKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteAreaKey key)
		{
			return Delete(transactionManager, key.SiteAreaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteAreaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteAreaId)
		{
			return Delete(null, _siteAreaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAreaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteAreaId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		FK__SiteArea__AreaID__4E739D3B Description: 
		/// </summary>
		/// <param name="_areaId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetByAreaId(System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(_areaId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		FK__SiteArea__AreaID__4E739D3B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		/// <remarks></remarks>
		public TList<SiteArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		FK__SiteArea__AreaID__4E739D3B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		fkSiteAreaAreaId4e739d3b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_areaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetByAreaId(System.Int32 _areaId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAreaId(null, _areaId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		fkSiteAreaAreaId4e739d3b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_areaId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetByAreaId(System.Int32 _areaId, int start, int pageLength,out int count)
		{
			return GetByAreaId(null, _areaId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__AreaID__4E739D3B key.
		///		FK__SiteArea__AreaID__4E739D3B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public abstract TList<SiteArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		FK__SiteArea__SiteID__4F67C174 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		FK__SiteArea__SiteID__4F67C174 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		/// <remarks></remarks>
		public TList<SiteArea> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		FK__SiteArea__SiteID__4F67C174 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		fkSiteAreaSiteId4f67c174 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		fkSiteAreaSiteId4f67c174 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public TList<SiteArea> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteArea__SiteID__4F67C174 key.
		///		FK__SiteArea__SiteID__4F67C174 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteArea objects.</returns>
		public abstract TList<SiteArea> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteArea Get(TransactionManager transactionManager, JXTPortal.Entities.SiteAreaKey key, int start, int pageLength)
		{
			return GetBySiteAreaId(transactionManager, key.SiteAreaId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="_siteAreaId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public JXTPortal.Entities.SiteArea GetBySiteAreaId(System.Int32 _siteAreaId)
		{
			int count = -1;
			return GetBySiteAreaId(null,_siteAreaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="_siteAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public JXTPortal.Entities.SiteArea GetBySiteAreaId(System.Int32 _siteAreaId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteAreaId(null, _siteAreaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAreaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public JXTPortal.Entities.SiteArea GetBySiteAreaId(TransactionManager transactionManager, System.Int32 _siteAreaId)
		{
			int count = -1;
			return GetBySiteAreaId(transactionManager, _siteAreaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public JXTPortal.Entities.SiteArea GetBySiteAreaId(TransactionManager transactionManager, System.Int32 _siteAreaId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteAreaId(transactionManager, _siteAreaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="_siteAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public JXTPortal.Entities.SiteArea GetBySiteAreaId(System.Int32 _siteAreaId, int start, int pageLength, out int count)
		{
			return GetBySiteAreaId(null, _siteAreaId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteArea__30E33A54 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteArea"/> class.</returns>
		public abstract JXTPortal.Entities.SiteArea GetBySiteAreaId(TransactionManager transactionManager, System.Int32 _siteAreaId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteArea_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid, ref System.Int32? siteAreaId)
		{
			 Insert(null, 0, int.MaxValue , areaId, siteId, siteAreaName, valid, ref siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid, ref System.Int32? siteAreaId)
		{
			 Insert(null, start, pageLength , areaId, siteId, siteAreaName, valid, ref siteAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid, ref System.Int32? siteAreaId)
		{
			 Insert(transactionManager, 0, int.MaxValue , areaId, siteId, siteAreaName, valid, ref siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid, ref System.Int32? siteAreaId);
		
		#endregion
		
		#region SiteArea_GetByLocationID 
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByLocationID(System.Int32? siteId, System.Int32? locationId)
		{
			return GetByLocationID(null, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByLocationID(int start, int pageLength, System.Int32? siteId, System.Int32? locationId)
		{
			return GetByLocationID(null, start, pageLength , siteId, locationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_GetByLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByLocationID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? locationId)
		{
			return GetByLocationID(transactionManager, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> GetByLocationID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? locationId);
		
		#endregion
		
		#region SiteArea_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteArea_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteArea_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteArea_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteArea_GetBySiteAreaId 
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteAreaId(System.Int32? siteAreaId)
		{
			return GetBySiteAreaId(null, 0, int.MaxValue , siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteAreaId(int start, int pageLength, System.Int32? siteAreaId)
		{
			return GetBySiteAreaId(null, start, pageLength , siteAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetBySiteAreaId(TransactionManager transactionManager, System.Int32? siteAreaId)
		{
			return GetBySiteAreaId(transactionManager, 0, int.MaxValue , siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetBySiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> GetBySiteAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAreaId);
		
		#endregion
		
		#region SiteArea_Find 
		
		/// <summary>
		///	This method wrap the 'SiteArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Find(System.Boolean? searchUsingOr, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteAreaId, areaId, siteId, siteAreaName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, siteAreaId, areaId, siteId, siteAreaName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteAreaId, areaId, siteId, siteAreaName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid);
		
		#endregion
		
		#region SiteArea_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteAreaId)
		{
			 Delete(null, 0, int.MaxValue , siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteAreaId)
		{
			 Delete(null, start, pageLength , siteAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteAreaId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAreaId);
		
		#endregion
		
		#region SiteArea_GetByAreaId 
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByAreaId(System.Int32? areaId)
		{
			return GetByAreaId(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByAreaId(int start, int pageLength, System.Int32? areaId)
		{
			return GetByAreaId(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public TList<SiteArea> GetByAreaId(TransactionManager transactionManager, System.Int32? areaId)
		{
			return GetByAreaId(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteArea&gt;"/> instance.</returns>
		public abstract TList<SiteArea> GetByAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region SiteArea_Update 
		
		/// <summary>
		///	This method wrap the 'SiteArea_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , siteAreaId, areaId, siteId, siteAreaName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			 Update(null, start, pageLength , siteAreaId, areaId, siteId, siteAreaName, valid);
		}
				
		/// <summary>
		///	This method wrap the 'SiteArea_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , siteAreaId, areaId, siteId, siteAreaName, valid);
		}
		
		/// <summary>
		///	This method wrap the 'SiteArea_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAreaId, System.Int32? areaId, System.Int32? siteId, System.String siteAreaName, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteArea&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteArea&gt;"/></returns>
		public static TList<SiteArea> Fill(IDataReader reader, TList<SiteArea> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteArea c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteArea")
					.Append("|").Append((System.Int32)reader[((int)SiteAreaColumn.SiteAreaId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteArea>(
					key.ToString(), // EntityTrackingKey
					"SiteArea",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteArea();
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
					c.SiteAreaId = (System.Int32)reader[((int)SiteAreaColumn.SiteAreaId - 1)];
					c.AreaId = (System.Int32)reader[((int)SiteAreaColumn.AreaId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteAreaColumn.SiteId - 1)];
					c.SiteAreaName = (reader.IsDBNull(((int)SiteAreaColumn.SiteAreaName - 1)))?null:(System.String)reader[((int)SiteAreaColumn.SiteAreaName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteAreaColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteArea"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteArea"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteArea entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteAreaId = (System.Int32)reader[((int)SiteAreaColumn.SiteAreaId - 1)];
			entity.AreaId = (System.Int32)reader[((int)SiteAreaColumn.AreaId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteAreaColumn.SiteId - 1)];
			entity.SiteAreaName = (reader.IsDBNull(((int)SiteAreaColumn.SiteAreaName - 1)))?null:(System.String)reader[((int)SiteAreaColumn.SiteAreaName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteAreaColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteArea"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteArea"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteArea entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteAreaId = (System.Int32)dataRow["SiteAreaID"];
			entity.AreaId = (System.Int32)dataRow["AreaID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.SiteAreaName = Convert.IsDBNull(dataRow["SiteAreaName"]) ? null : (System.String)dataRow["SiteAreaName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteArea"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteArea Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteArea entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AreaIdSource	
			if (CanDeepLoad(entity, "Area|AreaIdSource", deepLoadType, innerList) 
				&& entity.AreaIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AreaId;
				Area tmpEntity = EntityManager.LocateEntity<Area>(EntityLocator.ConstructKeyFromPkItems(typeof(Area), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AreaIdSource = tmpEntity;
				else
					entity.AreaIdSource = DataRepository.AreaProvider.GetByAreaId(transactionManager, entity.AreaId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AreaIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AreaIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AreaProvider.DeepLoad(transactionManager, entity.AreaIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AreaIdSource

			#region SiteIdSource	
			if (CanDeepLoad(entity, "Sites|SiteIdSource", deepLoadType, innerList) 
				&& entity.SiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SiteId;
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdSource = tmpEntity;
				else
					entity.SiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, entity.SiteId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SitesProvider.DeepLoad(transactionManager, entity.SiteIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteArea object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteArea instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteArea Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteArea entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AreaIdSource
			if (CanDeepSave(entity, "Area|AreaIdSource", deepSaveType, innerList) 
				&& entity.AreaIdSource != null)
			{
				DataRepository.AreaProvider.Save(transactionManager, entity.AreaIdSource);
				entity.AreaId = entity.AreaIdSource.AreaId;
			}
			#endregion 
			
			#region SiteIdSource
			if (CanDeepSave(entity, "Sites|SiteIdSource", deepSaveType, innerList) 
				&& entity.SiteIdSource != null)
			{
				DataRepository.SitesProvider.Save(transactionManager, entity.SiteIdSource);
				entity.SiteId = entity.SiteIdSource.SiteId;
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
	
	#region SiteAreaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteArea</c>
	///</summary>
	public enum SiteAreaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Area</c> at AreaIdSource
		///</summary>
		[ChildEntityType(typeof(Area))]
		Area,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteAreaChildEntityTypes
	
	#region SiteAreaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaFilterBuilder : SqlFilterBuilder<SiteAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilterBuilder class.
		/// </summary>
		public SiteAreaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAreaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAreaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAreaFilterBuilder
	
	#region SiteAreaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaParameterBuilder : ParameterizedSqlFilterBuilder<SiteAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaParameterBuilder class.
		/// </summary>
		public SiteAreaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAreaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAreaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAreaParameterBuilder
	
	#region SiteAreaSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteAreaSortBuilder : SqlSortBuilder<SiteAreaColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaSqlSortBuilder class.
		/// </summary>
		public SiteAreaSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteAreaSortBuilder
	
} // end namespace
