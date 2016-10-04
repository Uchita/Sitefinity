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
	/// This class is the base class for any <see cref="AdminRolesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminRolesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdminRoles, JXTPortal.Entities.AdminRolesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdminRolesKey key)
		{
			return Delete(transactionManager, key.AdminRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_adminRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _adminRoleId)
		{
			return Delete(null, _adminRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _adminRoleId);		
		
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
		public override JXTPortal.Entities.AdminRoles Get(TransactionManager transactionManager, JXTPortal.Entities.AdminRolesKey key, int start, int pageLength)
		{
			return GetByAdminRoleId(transactionManager, key.AdminRoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="_adminRoleId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public JXTPortal.Entities.AdminRoles GetByAdminRoleId(System.Int32 _adminRoleId)
		{
			int count = -1;
			return GetByAdminRoleId(null,_adminRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public JXTPortal.Entities.AdminRoles GetByAdminRoleId(System.Int32 _adminRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminRoleId(null, _adminRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public JXTPortal.Entities.AdminRoles GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId)
		{
			int count = -1;
			return GetByAdminRoleId(transactionManager, _adminRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public JXTPortal.Entities.AdminRoles GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminRoleId(transactionManager, _adminRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public JXTPortal.Entities.AdminRoles GetByAdminRoleId(System.Int32 _adminRoleId, int start, int pageLength, out int count)
		{
			return GetByAdminRoleId(null, _adminRoleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminRoles__7C8480AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminRoles"/> class.</returns>
		public abstract JXTPortal.Entities.AdminRoles GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdminRoles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public abstract TList<AdminRoles> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region AdminRoles_Delete 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? adminRoleId)
		{
			 Delete(null, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? adminRoleId)
		{
			 Delete(null, start, pageLength , adminRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? adminRoleId)
		{
			 Delete(transactionManager, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminRoleId);
		
		#endregion
		
		#region AdminRoles_Update 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? adminRoleId, System.String roleName)
		{
			 Update(null, 0, int.MaxValue , adminRoleId, roleName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? adminRoleId, System.String roleName)
		{
			 Update(null, start, pageLength , adminRoleId, roleName);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? adminRoleId, System.String roleName)
		{
			 Update(transactionManager, 0, int.MaxValue , adminRoleId, roleName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminRoleId, System.String roleName);
		
		#endregion
		
		#region AdminRoles_Insert 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
			/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String roleName, ref System.Int32? adminRoleId)
		{
			 Insert(null, 0, int.MaxValue , roleName, ref adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
			/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String roleName, ref System.Int32? adminRoleId)
		{
			 Insert(null, start, pageLength , roleName, ref adminRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
			/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String roleName, ref System.Int32? adminRoleId)
		{
			 Insert(transactionManager, 0, int.MaxValue , roleName, ref adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
			/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String roleName, ref System.Int32? adminRoleId);
		
		#endregion
		
		#region AdminRoles_GetByAdminRoleId 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetByAdminRoleId(System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(null, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetByAdminRoleId(int start, int pageLength, System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(null, start, pageLength , adminRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> GetByAdminRoleId(TransactionManager transactionManager, System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(transactionManager, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public abstract TList<AdminRoles> GetByAdminRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminRoleId);
		
		#endregion
		
		#region AdminRoles_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public abstract TList<AdminRoles> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdminRoles_Find 
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Find(System.Boolean? searchUsingOr, System.Int32? adminRoleId, System.String roleName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, adminRoleId, roleName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? adminRoleId, System.String roleName)
		{
			return Find(null, start, pageLength , searchUsingOr, adminRoleId, roleName);
		}
				
		/// <summary>
		///	This method wrap the 'AdminRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public TList<AdminRoles> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? adminRoleId, System.String roleName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, adminRoleId, roleName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdminRoles&gt;"/> instance.</returns>
		public abstract TList<AdminRoles> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? adminRoleId, System.String roleName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdminRoles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdminRoles&gt;"/></returns>
		public static TList<AdminRoles> Fill(IDataReader reader, TList<AdminRoles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdminRoles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdminRoles")
					.Append("|").Append((System.Int32)reader[((int)AdminRolesColumn.AdminRoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdminRoles>(
					key.ToString(), // EntityTrackingKey
					"AdminRoles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdminRoles();
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
					c.AdminRoleId = (System.Int32)reader[((int)AdminRolesColumn.AdminRoleId - 1)];
					c.RoleName = (System.String)reader[((int)AdminRolesColumn.RoleName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdminRoles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminRoles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdminRoles entity)
		{
			if (!reader.Read()) return;
			
			entity.AdminRoleId = (System.Int32)reader[((int)AdminRolesColumn.AdminRoleId - 1)];
			entity.RoleName = (System.String)reader[((int)AdminRolesColumn.RoleName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdminRoles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminRoles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdminRoles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdminRoleId = (System.Int32)dataRow["AdminRoleID"];
			entity.RoleName = (System.String)dataRow["RoleName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminRoles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdminRoles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdminRoles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAdminRoleId methods when available
			
			#region AdminUsersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdminUsers>|AdminUsersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminUsersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdminUsersCollection = DataRepository.AdminUsersProvider.GetByAdminRoleId(transactionManager, entity.AdminRoleId);

				if (deep && entity.AdminUsersCollection.Count > 0)
				{
					deepHandles.Add("AdminUsersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdminUsers>) DataRepository.AdminUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminUsersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdminRoles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdminRoles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdminRoles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdminRoles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<AdminUsers>
				if (CanDeepSave(entity.AdminUsersCollection, "List<AdminUsers>|AdminUsersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdminUsers child in entity.AdminUsersCollection)
					{
						if(child.AdminRoleIdSource != null)
						{
							child.AdminRoleId = child.AdminRoleIdSource.AdminRoleId;
						}
						else
						{
							child.AdminRoleId = entity.AdminRoleId;
						}

					}

					if (entity.AdminUsersCollection.Count > 0 || entity.AdminUsersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdminUsersProvider.Save(transactionManager, entity.AdminUsersCollection);
						
						deepHandles.Add("AdminUsersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdminUsers >) DataRepository.AdminUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdminUsersCollection, deepSaveType, childTypes, innerList }
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
	
	#region AdminRolesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdminRoles</c>
	///</summary>
	public enum AdminRolesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AdminRoles</c> as OneToMany for AdminUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminUsers>))]
		AdminUsersCollection,
	}
	
	#endregion AdminRolesChildEntityTypes
	
	#region AdminRolesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesFilterBuilder : SqlFilterBuilder<AdminRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilterBuilder class.
		/// </summary>
		public AdminRolesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminRolesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminRolesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminRolesFilterBuilder
	
	#region AdminRolesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesParameterBuilder : ParameterizedSqlFilterBuilder<AdminRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesParameterBuilder class.
		/// </summary>
		public AdminRolesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminRolesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminRolesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminRolesParameterBuilder
	
	#region AdminRolesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdminRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdminRolesSortBuilder : SqlSortBuilder<AdminRolesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesSqlSortBuilder class.
		/// </summary>
		public AdminRolesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdminRolesSortBuilder
	
} // end namespace
