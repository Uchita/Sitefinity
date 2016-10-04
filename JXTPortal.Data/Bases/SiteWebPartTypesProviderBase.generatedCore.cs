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
	/// This class is the base class for any <see cref="SiteWebPartTypesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteWebPartTypesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteWebPartTypes, JXTPortal.Entities.SiteWebPartTypesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartTypesKey key)
		{
			return Delete(transactionManager, key.SiteWebPartTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteWebPartTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteWebPartTypeId)
		{
			return Delete(null, _siteWebPartTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId);		
		
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
		public override JXTPortal.Entities.SiteWebPartTypes Get(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartTypesKey key, int start, int pageLength)
		{
			return GetBySiteWebPartTypeId(transactionManager, key.SiteWebPartTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="_siteWebPartTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(null,_siteWebPartTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(null, _siteWebPartTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(transactionManager, _siteWebPartTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(transactionManager, _siteWebPartTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId, int start, int pageLength, out int count)
		{
			return GetBySiteWebPartTypeId(null, _siteWebPartTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebPartTypes__35BCFE0A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> class.</returns>
		public abstract JXTPortal.Entities.SiteWebPartTypes GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteWebPartTypes_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public abstract TList<SiteWebPartTypes> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteWebPartTypes_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteWebPartTypeId)
		{
			 Delete(null, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteWebPartTypeId)
		{
			 Delete(null, start, pageLength , siteWebPartTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteWebPartTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartTypeId);
		
		#endregion
		
		#region SiteWebPartTypes_GetBySiteWebPartTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetBySiteWebPartTypeId(System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(null, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetBySiteWebPartTypeId(int start, int pageLength, System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(null, start, pageLength , siteWebPartTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(transactionManager, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public abstract TList<SiteWebPartTypes> GetBySiteWebPartTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartTypeId);
		
		#endregion
		
		#region SiteWebPartTypes_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
			/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String siteWebPartName, ref System.Int32? siteWebPartTypeId)
		{
			 Insert(null, 0, int.MaxValue , siteWebPartName, ref siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
			/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String siteWebPartName, ref System.Int32? siteWebPartTypeId)
		{
			 Insert(null, start, pageLength , siteWebPartName, ref siteWebPartTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
			/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String siteWebPartName, ref System.Int32? siteWebPartTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteWebPartName, ref siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
			/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String siteWebPartName, ref System.Int32? siteWebPartTypeId);
		
		#endregion
		
		#region SiteWebPartTypes_Update 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			 Update(null, 0, int.MaxValue , siteWebPartTypeId, siteWebPartName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			 Update(null, start, pageLength , siteWebPartTypeId, siteWebPartName);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			 Update(transactionManager, 0, int.MaxValue , siteWebPartTypeId, siteWebPartName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartTypeId, System.String siteWebPartName);
		
		#endregion
		
		#region SiteWebPartTypes_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public abstract TList<SiteWebPartTypes> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteWebPartTypes_Find 
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Find(System.Boolean? searchUsingOr, System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteWebPartTypeId, siteWebPartName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			return Find(null, start, pageLength , searchUsingOr, siteWebPartTypeId, siteWebPartName);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public TList<SiteWebPartTypes> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteWebPartTypeId, System.String siteWebPartName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteWebPartTypeId, siteWebPartName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebPartTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebPartTypes&gt;"/> instance.</returns>
		public abstract TList<SiteWebPartTypes> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteWebPartTypeId, System.String siteWebPartName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteWebPartTypes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteWebPartTypes&gt;"/></returns>
		public static TList<SiteWebPartTypes> Fill(IDataReader reader, TList<SiteWebPartTypes> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteWebPartTypes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteWebPartTypes")
					.Append("|").Append((System.Int32)reader[((int)SiteWebPartTypesColumn.SiteWebPartTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteWebPartTypes>(
					key.ToString(), // EntityTrackingKey
					"SiteWebPartTypes",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteWebPartTypes();
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
					c.SiteWebPartTypeId = (System.Int32)reader[((int)SiteWebPartTypesColumn.SiteWebPartTypeId - 1)];
					c.SiteWebPartName = (System.String)reader[((int)SiteWebPartTypesColumn.SiteWebPartName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebPartTypes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteWebPartTypes entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteWebPartTypeId = (System.Int32)reader[((int)SiteWebPartTypesColumn.SiteWebPartTypeId - 1)];
			entity.SiteWebPartName = (System.String)reader[((int)SiteWebPartTypesColumn.SiteWebPartName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWebPartTypes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebPartTypes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteWebPartTypes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteWebPartTypeId = (System.Int32)dataRow["SiteWebPartTypeID"];
			entity.SiteWebPartName = (System.String)dataRow["SiteWebPartName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebPartTypes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWebPartTypes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartTypes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySiteWebPartTypeId methods when available
			
			#region SiteWebPartsCollectionGetBySiteWebPartTypeId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteWebPartTypeId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartsCollectionGetBySiteWebPartTypeId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWebPartsCollectionGetBySiteWebPartTypeId = DataRepository.SiteWebPartsProvider.GetBySiteWebPartTypeId(transactionManager, entity.SiteWebPartTypeId);

				if (deep && entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.Count > 0)
				{
					deepHandles.Add("SiteWebPartsCollectionGetBySiteWebPartTypeId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWebParts>) DataRepository.SiteWebPartsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteWebPartsCollectionGetBySiteWebPartTypeId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteWebPartTypeId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartsCollectionGetBySiteWebPartTypeId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWebPartsCollectionGetBySiteWebPartTypeId = DataRepository.SiteWebPartsProvider.GetBySiteWebPartTypeId(transactionManager, entity.SiteWebPartTypeId);

				if (deep && entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.Count > 0)
				{
					deepHandles.Add("SiteWebPartsCollectionGetBySiteWebPartTypeId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWebParts>) DataRepository.SiteWebPartsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteWebPartTypes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteWebPartTypes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWebPartTypes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartTypes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SiteWebParts>
				if (CanDeepSave(entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteWebPartTypeId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWebParts child in entity.SiteWebPartsCollectionGetBySiteWebPartTypeId)
					{
						if(child.SiteWebPartTypeIdSource != null)
						{
							child.SiteWebPartTypeId = child.SiteWebPartTypeIdSource.SiteWebPartTypeId;
						}
						else
						{
							child.SiteWebPartTypeId = entity.SiteWebPartTypeId;
						}

					}

					if (entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.Count > 0 || entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWebPartsProvider.Save(transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId);
						
						deepHandles.Add("SiteWebPartsCollectionGetBySiteWebPartTypeId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWebParts >) DataRepository.SiteWebPartsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteWebParts>
				if (CanDeepSave(entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteWebPartTypeId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWebParts child in entity.SiteWebPartsCollectionGetBySiteWebPartTypeId)
					{
						if(child.SiteWebPartTypeIdSource != null)
						{
							child.SiteWebPartTypeId = child.SiteWebPartTypeIdSource.SiteWebPartTypeId;
						}
						else
						{
							child.SiteWebPartTypeId = entity.SiteWebPartTypeId;
						}

					}

					if (entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.Count > 0 || entity.SiteWebPartsCollectionGetBySiteWebPartTypeId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWebPartsProvider.Save(transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId);
						
						deepHandles.Add("SiteWebPartsCollectionGetBySiteWebPartTypeId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWebParts >) DataRepository.SiteWebPartsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteWebPartTypeId, deepSaveType, childTypes, innerList }
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
	
	#region SiteWebPartTypesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteWebPartTypes</c>
	///</summary>
	public enum SiteWebPartTypesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SiteWebPartTypes</c> as OneToMany for SiteWebPartsCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteWebParts>))]
		SiteWebPartsCollectionGetBySiteWebPartTypeId,

		
	}
	
	#endregion SiteWebPartTypesChildEntityTypes
	
	#region SiteWebPartTypesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteWebPartTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesFilterBuilder : SqlFilterBuilder<SiteWebPartTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilterBuilder class.
		/// </summary>
		public SiteWebPartTypesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartTypesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartTypesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartTypesFilterBuilder
	
	#region SiteWebPartTypesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteWebPartTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesParameterBuilder : ParameterizedSqlFilterBuilder<SiteWebPartTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesParameterBuilder class.
		/// </summary>
		public SiteWebPartTypesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartTypesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartTypesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartTypesParameterBuilder
	
	#region SiteWebPartTypesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteWebPartTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteWebPartTypesSortBuilder : SqlSortBuilder<SiteWebPartTypesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesSqlSortBuilder class.
		/// </summary>
		public SiteWebPartTypesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteWebPartTypesSortBuilder
	
} // end namespace
