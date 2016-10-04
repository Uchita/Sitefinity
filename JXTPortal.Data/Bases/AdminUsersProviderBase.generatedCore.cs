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
	/// This class is the base class for any <see cref="AdminUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdminUsersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdminUsers, JXTPortal.Entities.AdminUsersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdminUsersKey key)
		{
			return Delete(transactionManager, key.AdminUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_adminUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _adminUserId)
		{
			return Delete(null, _adminUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _adminUserId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		FK_AdminUsers_AdminRoles Description: 
		/// </summary>
		/// <param name="_adminRoleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetByAdminRoleId(System.Int32 _adminRoleId)
		{
			int count = -1;
			return GetByAdminRoleId(_adminRoleId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		FK_AdminUsers_AdminRoles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdminUsers> GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId)
		{
			int count = -1;
			return GetByAdminRoleId(transactionManager, _adminRoleId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		FK_AdminUsers_AdminRoles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminRoleId(transactionManager, _adminRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		fkAdminUsersAdminRoles Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_adminRoleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetByAdminRoleId(System.Int32 _adminRoleId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdminRoleId(null, _adminRoleId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		fkAdminUsersAdminRoles Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_adminRoleId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetByAdminRoleId(System.Int32 _adminRoleId, int start, int pageLength,out int count)
		{
			return GetByAdminRoleId(null, _adminRoleId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_AdminRoles key.
		///		FK_AdminUsers_AdminRoles Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public abstract TList<AdminUsers> GetByAdminRoleId(TransactionManager transactionManager, System.Int32 _adminRoleId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		FK_AdminUsers_Sites Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		FK_AdminUsers_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdminUsers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		FK_AdminUsers_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		fkAdminUsersSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		fkAdminUsersSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public TList<AdminUsers> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_AdminUsers_Sites key.
		///		FK_AdminUsers_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdminUsers objects.</returns>
		public abstract TList<AdminUsers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.AdminUsers Get(TransactionManager transactionManager, JXTPortal.Entities.AdminUsersKey key, int start, int pageLength)
		{
			return GetByAdminUserId(transactionManager, key.AdminUserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetBySiteIdUserName(System.Int32 _siteId, System.String _userName)
		{
			int count = -1;
			return GetBySiteIdUserName(null,_siteId, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetBySiteIdUserName(System.Int32 _siteId, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUserName(null, _siteId, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetBySiteIdUserName(TransactionManager transactionManager, System.Int32 _siteId, System.String _userName)
		{
			int count = -1;
			return GetBySiteIdUserName(transactionManager, _siteId, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetBySiteIdUserName(TransactionManager transactionManager, System.Int32 _siteId, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUserName(transactionManager, _siteId, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetBySiteIdUserName(System.Int32 _siteId, System.String _userName, int start, int pageLength, out int count)
		{
			return GetBySiteIdUserName(null, _siteId, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdminUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public abstract JXTPortal.Entities.AdminUsers GetBySiteIdUserName(TransactionManager transactionManager, System.Int32 _siteId, System.String _userName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="_adminUserId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetByAdminUserId(System.Int32 _adminUserId)
		{
			int count = -1;
			return GetByAdminUserId(null,_adminUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="_adminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetByAdminUserId(System.Int32 _adminUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminUserId(null, _adminUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetByAdminUserId(TransactionManager transactionManager, System.Int32 _adminUserId)
		{
			int count = -1;
			return GetByAdminUserId(transactionManager, _adminUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetByAdminUserId(TransactionManager transactionManager, System.Int32 _adminUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdminUserId(transactionManager, _adminUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="_adminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public JXTPortal.Entities.AdminUsers GetByAdminUserId(System.Int32 _adminUserId, int start, int pageLength, out int count)
		{
			return GetByAdminUserId(null, _adminUserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdminUsers__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_adminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdminUsers"/> class.</returns>
		public abstract JXTPortal.Entities.AdminUsers GetByAdminUserId(TransactionManager transactionManager, System.Int32 _adminUserId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdminUsers_Insert 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, ref System.Int32? adminUserId)
		{
			 Insert(null, 0, int.MaxValue , adminRoleId, siteId, userName, userPassword, firstName, surname, email, ref adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, ref System.Int32? adminUserId)
		{
			 Insert(null, start, pageLength , adminRoleId, siteId, userName, userPassword, firstName, surname, email, ref adminUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, ref System.Int32? adminUserId)
		{
			 Insert(transactionManager, 0, int.MaxValue , adminRoleId, siteId, userName, userPassword, firstName, surname, email, ref adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
			/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, ref System.Int32? adminUserId);
		
		#endregion
		
		#region AdminUsers_GetByAdminUserId 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminUserId(System.Int32? adminUserId)
		{
			return GetByAdminUserId(null, 0, int.MaxValue , adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminUserId(int start, int pageLength, System.Int32? adminUserId)
		{
			return GetByAdminUserId(null, start, pageLength , adminUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminUserId(TransactionManager transactionManager, System.Int32? adminUserId)
		{
			return GetByAdminUserId(transactionManager, 0, int.MaxValue , adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdminUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminUserId);
		
		#endregion
		
		#region AdminUsers_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region AdminUsers_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Get_List' stored procedure. 
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
		///	This method wrap the 'AdminUsers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdminUsers_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdminUsers> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdminUsers> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdminUsers> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetPaged' stored procedure. 
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
        public abstract TList<AdminUsers> GetPaged(TransactionManager transactionManager, int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region AdminUsers_GetBySiteIdUserName 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteIdUserName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUserName(System.Int32? siteId, System.String userName)
		{
			return GetBySiteIdUserName(null, 0, int.MaxValue , siteId, userName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteIdUserName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUserName(int start, int pageLength, System.Int32? siteId, System.String userName)
		{
			return GetBySiteIdUserName(null, start, pageLength , siteId, userName);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteIdUserName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUserName(TransactionManager transactionManager, System.Int32? siteId, System.String userName)
		{
			return GetBySiteIdUserName(transactionManager, 0, int.MaxValue , siteId, userName);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetBySiteIdUserName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdUserName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String userName);
		
		#endregion
		
		#region AdminUsers_Find 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			return Find(null, start, pageLength , searchUsingOr, adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email);
		
		#endregion
		
		#region AdminUsers_Delete 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? adminUserId)
		{
			 Delete(null, 0, int.MaxValue , adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? adminUserId)
		{
			 Delete(null, start, pageLength , adminUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? adminUserId)
		{
			 Delete(transactionManager, 0, int.MaxValue , adminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminUserId);
		
		#endregion
		
		#region AdminUsers_Update 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			 Update(null, 0, int.MaxValue , adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			 Update(null, start, pageLength , adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email)
		{
			 Update(transactionManager, 0, int.MaxValue , adminUserId, adminRoleId, siteId, userName, userPassword, firstName, surname, email);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="adminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminUserId, System.Int32? adminRoleId, System.Int32? siteId, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email);
		
		#endregion
		
		#region AdminUsers_GetByAdminRoleId 
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminRoleId(System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(null, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminRoleId(int start, int pageLength, System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(null, start, pageLength , adminRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdminRoleId(TransactionManager transactionManager, System.Int32? adminRoleId)
		{
			return GetByAdminRoleId(transactionManager, 0, int.MaxValue , adminRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'AdminUsers_GetByAdminRoleId' stored procedure. 
		/// </summary>
		/// <param name="adminRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdminRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? adminRoleId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdminUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdminUsers&gt;"/></returns>
		public static TList<AdminUsers> Fill(IDataReader reader, TList<AdminUsers> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdminUsers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdminUsers")
					.Append("|").Append((System.Int32)reader[((int)AdminUsersColumn.AdminUserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdminUsers>(
					key.ToString(), // EntityTrackingKey
					"AdminUsers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdminUsers();
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
					c.AdminUserId = (System.Int32)reader[((int)AdminUsersColumn.AdminUserId - 1)];
					c.AdminRoleId = (System.Int32)reader[((int)AdminUsersColumn.AdminRoleId - 1)];
					c.SiteId = (System.Int32)reader[((int)AdminUsersColumn.SiteId - 1)];
					c.UserName = (System.String)reader[((int)AdminUsersColumn.UserName - 1)];
					c.UserPassword = (System.String)reader[((int)AdminUsersColumn.UserPassword - 1)];
					c.FirstName = (System.String)reader[((int)AdminUsersColumn.FirstName - 1)];
					c.Surname = (System.String)reader[((int)AdminUsersColumn.Surname - 1)];
					c.Email = (System.String)reader[((int)AdminUsersColumn.Email - 1)];
					c.LoginAttempts = (System.Int32)reader[((int)AdminUsersColumn.LoginAttempts - 1)];
					c.LastAttemptDate = (reader.IsDBNull(((int)AdminUsersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)AdminUsersColumn.LastAttemptDate - 1)];
					c.Status = (System.Int32)reader[((int)AdminUsersColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdminUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdminUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.AdminUserId = (System.Int32)reader[((int)AdminUsersColumn.AdminUserId - 1)];
			entity.AdminRoleId = (System.Int32)reader[((int)AdminUsersColumn.AdminRoleId - 1)];
			entity.SiteId = (System.Int32)reader[((int)AdminUsersColumn.SiteId - 1)];
			entity.UserName = (System.String)reader[((int)AdminUsersColumn.UserName - 1)];
			entity.UserPassword = (System.String)reader[((int)AdminUsersColumn.UserPassword - 1)];
			entity.FirstName = (System.String)reader[((int)AdminUsersColumn.FirstName - 1)];
			entity.Surname = (System.String)reader[((int)AdminUsersColumn.Surname - 1)];
			entity.Email = (System.String)reader[((int)AdminUsersColumn.Email - 1)];
			entity.LoginAttempts = (System.Int32)reader[((int)AdminUsersColumn.LoginAttempts - 1)];
			entity.LastAttemptDate = (reader.IsDBNull(((int)AdminUsersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)AdminUsersColumn.LastAttemptDate - 1)];
			entity.Status = (System.Int32)reader[((int)AdminUsersColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdminUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdminUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdminUserId = (System.Int32)dataRow["AdminUserID"];
			entity.AdminRoleId = (System.Int32)dataRow["AdminRoleID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.UserPassword = (System.String)dataRow["UserPassword"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.Surname = (System.String)dataRow["Surname"];
			entity.Email = (System.String)dataRow["Email"];
			entity.LoginAttempts = (System.Int32)dataRow["LoginAttempts"];
			entity.LastAttemptDate = Convert.IsDBNull(dataRow["LastAttemptDate"]) ? null : (System.DateTime?)dataRow["LastAttemptDate"];
			entity.Status = (System.Int32)dataRow["Status"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdminUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdminUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdminUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdminRoleIdSource	
			if (CanDeepLoad(entity, "AdminRoles|AdminRoleIdSource", deepLoadType, innerList) 
				&& entity.AdminRoleIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdminRoleId;
				AdminRoles tmpEntity = EntityManager.LocateEntity<AdminRoles>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminRoles), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdminRoleIdSource = tmpEntity;
				else
					entity.AdminRoleIdSource = DataRepository.AdminRolesProvider.GetByAdminRoleId(transactionManager, entity.AdminRoleId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminRoleIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdminRoleIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminRolesProvider.DeepLoad(transactionManager, entity.AdminRoleIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdminRoleIdSource

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
			// Deep load child collections  - Call GetByAdminUserId methods when available
			
			#region SiteResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollection = DataRepository.SiteResourcesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.SiteResourcesCollection.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region GlobalSettingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalSettings>|GlobalSettingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalSettingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmailTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmailTemplates>|EmailTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmailTemplatesCollection = DataRepository.EmailTemplatesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.EmailTemplatesCollection.Count > 0)
				{
					deepHandles.Add("EmailTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmailTemplates>) DataRepository.EmailTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmailTemplatesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByLastModifiedByAdminUserId(transactionManager, entity.AdminUserId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AvailableStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AvailableStatus>|AvailableStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AvailableStatusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AvailableStatusCollection = DataRepository.AvailableStatusProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.AvailableStatusCollection.Count > 0)
				{
					deepHandles.Add("AvailableStatusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AvailableStatus>) DataRepository.AvailableStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.AvailableStatusCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobItemsTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobItemsType>|JobItemsTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobItemsTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobItemsTypeCollection = DataRepository.JobItemsTypeProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.JobItemsTypeCollection.Count > 0)
				{
					deepHandles.Add("JobItemsTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobItemsType>) DataRepository.JobItemsTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.JobItemsTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SitesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Sites>|SitesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SitesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SitesCollection = DataRepository.SitesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.SitesCollection.Count > 0)
				{
					deepHandles.Add("SitesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Sites>) DataRepository.SitesProvider.DeepLoad,
						new object[] { transactionManager, entity.SitesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region NewsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<News>|NewsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NewsCollection = DataRepository.NewsProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.NewsCollection.Count > 0)
				{
					deepHandles.Add("NewsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<News>) DataRepository.NewsProvider.DeepLoad,
						new object[] { transactionManager, entity.NewsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberMembershipsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberMemberships>|MemberMembershipsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberMembershipsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberMembershipsCollection = DataRepository.MemberMembershipsProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.MemberMembershipsCollection.Count > 0)
				{
					deepHandles.Add("MemberMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberMemberships>) DataRepository.MemberMembershipsProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberMembershipsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobTemplates>|JobTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobTemplatesCollection = DataRepository.JobTemplatesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.JobTemplatesCollection.Count > 0)
				{
					deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobTemplates>) DataRepository.JobTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DefaultResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DefaultResources>|DefaultResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DefaultResourcesCollection = DataRepository.DefaultResourcesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.DefaultResourcesCollection.Count > 0)
				{
					deepHandles.Add("DefaultResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DefaultResources>) DataRepository.DefaultResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.DefaultResourcesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsCollection = DataRepository.JobsProvider.GetByLastModifiedByAdminUserId(transactionManager, entity.AdminUserId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region NewsCategoriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<NewsCategories>|NewsCategoriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCategoriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NewsCategoriesCollection = DataRepository.NewsCategoriesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.NewsCategoriesCollection.Count > 0)
				{
					deepHandles.Add("NewsCategoriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<NewsCategories>) DataRepository.NewsCategoriesProvider.DeepLoad,
						new object[] { transactionManager, entity.NewsCategoriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EducationsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Educations>|EducationsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EducationsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EducationsCollection = DataRepository.EducationsProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.EducationsCollection.Count > 0)
				{
					deepHandles.Add("EducationsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Educations>) DataRepository.EducationsProvider.DeepLoad,
						new object[] { transactionManager, entity.EducationsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPagesCollectionGetByLastModifiedBy
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPagesCollectionGetByLastModifiedBy", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPagesCollectionGetByLastModifiedBy' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPagesCollectionGetByLastModifiedBy = DataRepository.DynamicPagesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.DynamicPagesCollectionGetByLastModifiedBy.Count > 0)
				{
					deepHandles.Add("DynamicPagesCollectionGetByLastModifiedBy",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPageWebPartTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageWebPartTemplates>|DynamicPageWebPartTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageWebPartTemplatesCollection = DataRepository.DynamicPageWebPartTemplatesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.DynamicPageWebPartTemplatesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageWebPartTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageWebPartTemplates>) DataRepository.DynamicPageWebPartTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageWebPartTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberStatus>|MemberStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberStatusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberStatusCollection = DataRepository.MemberStatusProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.MemberStatusCollection.Count > 0)
				{
					deepHandles.Add("MemberStatusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberStatus>) DataRepository.MemberStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberStatusCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberWizardCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberWizard>|MemberWizardCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberWizardCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberWizardCollection = DataRepository.MemberWizardProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.MemberWizardCollection.Count > 0)
				{
					deepHandles.Add("MemberWizardCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberWizard>) DataRepository.MemberWizardProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberWizardCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPagesCollectionGetByLastModifiedBy
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPagesCollectionGetByLastModifiedBy", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPagesCollectionGetByLastModifiedBy' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPagesCollectionGetByLastModifiedBy = DataRepository.DynamicPagesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.DynamicPagesCollectionGetByLastModifiedBy.Count > 0)
				{
					deepHandles.Add("DynamicPagesCollectionGetByLastModifiedBy",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Files>|FilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FilesCollection = DataRepository.FilesProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.FilesCollection.Count > 0)
				{
					deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Files>) DataRepository.FilesProvider.DeepLoad,
						new object[] { transactionManager, entity.FilesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertisersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Advertisers>|AdvertisersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertisersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertisersCollection = DataRepository.AdvertisersProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.AdvertisersCollection.Count > 0)
				{
					deepHandles.Add("AdvertisersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Advertisers>) DataRepository.AdvertisersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertisersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertiserUsersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserUsers>|AdvertiserUsersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUsersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserUsersCollection = DataRepository.AdvertiserUsersProvider.GetByLastModifiedBy(transactionManager, entity.AdminUserId);

				if (deep && entity.AdvertiserUsersCollection.Count > 0)
				{
					deepHandles.Add("AdvertiserUsersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserUsers>) DataRepository.AdvertiserUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserUsersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdminUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdminUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdminUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdminUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdminRoleIdSource
			if (CanDeepSave(entity, "AdminRoles|AdminRoleIdSource", deepSaveType, innerList) 
				&& entity.AdminRoleIdSource != null)
			{
				DataRepository.AdminRolesProvider.Save(transactionManager, entity.AdminRoleIdSource);
				entity.AdminRoleId = entity.AdminRoleIdSource.AdminRoleId;
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
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollection, "List<SiteResources>|SiteResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.SiteResourcesCollection.Count > 0 || entity.SiteResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollection);
						
						deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<GlobalSettings>
				if (CanDeepSave(entity.GlobalSettingsCollection, "List<GlobalSettings>|GlobalSettingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalSettings child in entity.GlobalSettingsCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.GlobalSettingsCollection.Count > 0 || entity.GlobalSettingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalSettingsProvider.Save(transactionManager, entity.GlobalSettingsCollection);
						
						deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalSettings >) DataRepository.GlobalSettingsProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalSettingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmailTemplates>
				if (CanDeepSave(entity.EmailTemplatesCollection, "List<EmailTemplates>|EmailTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmailTemplates child in entity.EmailTemplatesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.EmailTemplatesCollection.Count > 0 || entity.EmailTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmailTemplatesProvider.Save(transactionManager, entity.EmailTemplatesCollection);
						
						deepHandles.Add("EmailTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmailTemplates >) DataRepository.EmailTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.EmailTemplatesCollection, deepSaveType, childTypes, innerList }
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
						if(child.LastModifiedByAdminUserIdSource != null)
						{
							child.LastModifiedByAdminUserId = child.LastModifiedByAdminUserIdSource.AdminUserId;
						}
						else
						{
							child.LastModifiedByAdminUserId = entity.AdminUserId;
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
				
	
			#region List<AvailableStatus>
				if (CanDeepSave(entity.AvailableStatusCollection, "List<AvailableStatus>|AvailableStatusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AvailableStatus child in entity.AvailableStatusCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.AvailableStatusCollection.Count > 0 || entity.AvailableStatusCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AvailableStatusProvider.Save(transactionManager, entity.AvailableStatusCollection);
						
						deepHandles.Add("AvailableStatusCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AvailableStatus >) DataRepository.AvailableStatusProvider.DeepSave,
							new object[] { transactionManager, entity.AvailableStatusCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobItemsType>
				if (CanDeepSave(entity.JobItemsTypeCollection, "List<JobItemsType>|JobItemsTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobItemsType child in entity.JobItemsTypeCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.JobItemsTypeCollection.Count > 0 || entity.JobItemsTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobItemsTypeProvider.Save(transactionManager, entity.JobItemsTypeCollection);
						
						deepHandles.Add("JobItemsTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobItemsType >) DataRepository.JobItemsTypeProvider.DeepSave,
							new object[] { transactionManager, entity.JobItemsTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Sites>
				if (CanDeepSave(entity.SitesCollection, "List<Sites>|SitesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Sites child in entity.SitesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.SitesCollection.Count > 0 || entity.SitesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SitesProvider.Save(transactionManager, entity.SitesCollection);
						
						deepHandles.Add("SitesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Sites >) DataRepository.SitesProvider.DeepSave,
							new object[] { transactionManager, entity.SitesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<News>
				if (CanDeepSave(entity.NewsCollection, "List<News>|NewsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(News child in entity.NewsCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.NewsCollection.Count > 0 || entity.NewsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NewsProvider.Save(transactionManager, entity.NewsCollection);
						
						deepHandles.Add("NewsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< News >) DataRepository.NewsProvider.DeepSave,
							new object[] { transactionManager, entity.NewsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberMemberships>
				if (CanDeepSave(entity.MemberMembershipsCollection, "List<MemberMemberships>|MemberMembershipsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberMemberships child in entity.MemberMembershipsCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.MemberMembershipsCollection.Count > 0 || entity.MemberMembershipsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberMembershipsProvider.Save(transactionManager, entity.MemberMembershipsCollection);
						
						deepHandles.Add("MemberMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberMemberships >) DataRepository.MemberMembershipsProvider.DeepSave,
							new object[] { transactionManager, entity.MemberMembershipsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobTemplates>
				if (CanDeepSave(entity.JobTemplatesCollection, "List<JobTemplates>|JobTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobTemplates child in entity.JobTemplatesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.JobTemplatesCollection.Count > 0 || entity.JobTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobTemplatesProvider.Save(transactionManager, entity.JobTemplatesCollection);
						
						deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobTemplates >) DataRepository.JobTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.JobTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DefaultResources>
				if (CanDeepSave(entity.DefaultResourcesCollection, "List<DefaultResources>|DefaultResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DefaultResources child in entity.DefaultResourcesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.DefaultResourcesCollection.Count > 0 || entity.DefaultResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DefaultResourcesProvider.Save(transactionManager, entity.DefaultResourcesCollection);
						
						deepHandles.Add("DefaultResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DefaultResources >) DataRepository.DefaultResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.DefaultResourcesCollection, deepSaveType, childTypes, innerList }
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
						if(child.LastModifiedByAdminUserIdSource != null)
						{
							child.LastModifiedByAdminUserId = child.LastModifiedByAdminUserIdSource.AdminUserId;
						}
						else
						{
							child.LastModifiedByAdminUserId = entity.AdminUserId;
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
				
	
			#region List<NewsCategories>
				if (CanDeepSave(entity.NewsCategoriesCollection, "List<NewsCategories>|NewsCategoriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(NewsCategories child in entity.NewsCategoriesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.NewsCategoriesCollection.Count > 0 || entity.NewsCategoriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NewsCategoriesProvider.Save(transactionManager, entity.NewsCategoriesCollection);
						
						deepHandles.Add("NewsCategoriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< NewsCategories >) DataRepository.NewsCategoriesProvider.DeepSave,
							new object[] { transactionManager, entity.NewsCategoriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Educations>
				if (CanDeepSave(entity.EducationsCollection, "List<Educations>|EducationsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Educations child in entity.EducationsCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.EducationsCollection.Count > 0 || entity.EducationsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EducationsProvider.Save(transactionManager, entity.EducationsCollection);
						
						deepHandles.Add("EducationsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Educations >) DataRepository.EducationsProvider.DeepSave,
							new object[] { transactionManager, entity.EducationsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPages>
				if (CanDeepSave(entity.DynamicPagesCollectionGetByLastModifiedBy, "List<DynamicPages>|DynamicPagesCollectionGetByLastModifiedBy", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPages child in entity.DynamicPagesCollectionGetByLastModifiedBy)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.DynamicPagesCollectionGetByLastModifiedBy.Count > 0 || entity.DynamicPagesCollectionGetByLastModifiedBy.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy);
						
						deepHandles.Add("DynamicPagesCollectionGetByLastModifiedBy",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPageWebPartTemplates>
				if (CanDeepSave(entity.DynamicPageWebPartTemplatesCollection, "List<DynamicPageWebPartTemplates>|DynamicPageWebPartTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageWebPartTemplates child in entity.DynamicPageWebPartTemplatesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.DynamicPageWebPartTemplatesCollection.Count > 0 || entity.DynamicPageWebPartTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageWebPartTemplatesProvider.Save(transactionManager, entity.DynamicPageWebPartTemplatesCollection);
						
						deepHandles.Add("DynamicPageWebPartTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageWebPartTemplates >) DataRepository.DynamicPageWebPartTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageWebPartTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberStatus>
				if (CanDeepSave(entity.MemberStatusCollection, "List<MemberStatus>|MemberStatusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberStatus child in entity.MemberStatusCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.MemberStatusCollection.Count > 0 || entity.MemberStatusCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberStatusProvider.Save(transactionManager, entity.MemberStatusCollection);
						
						deepHandles.Add("MemberStatusCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberStatus >) DataRepository.MemberStatusProvider.DeepSave,
							new object[] { transactionManager, entity.MemberStatusCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberWizard>
				if (CanDeepSave(entity.MemberWizardCollection, "List<MemberWizard>|MemberWizardCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberWizard child in entity.MemberWizardCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.MemberWizardCollection.Count > 0 || entity.MemberWizardCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberWizardProvider.Save(transactionManager, entity.MemberWizardCollection);
						
						deepHandles.Add("MemberWizardCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberWizard >) DataRepository.MemberWizardProvider.DeepSave,
							new object[] { transactionManager, entity.MemberWizardCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPages>
				if (CanDeepSave(entity.DynamicPagesCollectionGetByLastModifiedBy, "List<DynamicPages>|DynamicPagesCollectionGetByLastModifiedBy", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPages child in entity.DynamicPagesCollectionGetByLastModifiedBy)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.DynamicPagesCollectionGetByLastModifiedBy.Count > 0 || entity.DynamicPagesCollectionGetByLastModifiedBy.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy);
						
						deepHandles.Add("DynamicPagesCollectionGetByLastModifiedBy",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPagesCollectionGetByLastModifiedBy, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Files>
				if (CanDeepSave(entity.FilesCollection, "List<Files>|FilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Files child in entity.FilesCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.FilesCollection.Count > 0 || entity.FilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FilesProvider.Save(transactionManager, entity.FilesCollection);
						
						deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Files >) DataRepository.FilesProvider.DeepSave,
							new object[] { transactionManager, entity.FilesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Advertisers>
				if (CanDeepSave(entity.AdvertisersCollection, "List<Advertisers>|AdvertisersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Advertisers child in entity.AdvertisersCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
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
				
	
			#region List<AdvertiserUsers>
				if (CanDeepSave(entity.AdvertiserUsersCollection, "List<AdvertiserUsers>|AdvertiserUsersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserUsers child in entity.AdvertiserUsersCollection)
					{
						if(child.LastModifiedBySource != null)
						{
							child.LastModifiedBy = child.LastModifiedBySource.AdminUserId;
						}
						else
						{
							child.LastModifiedBy = entity.AdminUserId;
						}

					}

					if (entity.AdvertiserUsersCollection.Count > 0 || entity.AdvertiserUsersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUsersCollection);
						
						deepHandles.Add("AdvertiserUsersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserUsers >) DataRepository.AdvertiserUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserUsersCollection, deepSaveType, childTypes, innerList }
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
	
	#region AdminUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdminUsers</c>
	///</summary>
	public enum AdminUsersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminRoles</c> at AdminRoleIdSource
		///</summary>
		[ChildEntityType(typeof(AdminRoles))]
		AdminRoles,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for SiteResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResources>))]
		SiteResourcesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for EmailTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmailTemplates>))]
		EmailTemplatesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for AvailableStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<AvailableStatus>))]
		AvailableStatusCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for JobItemsTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobItemsType>))]
		JobItemsTypeCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for SitesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Sites>))]
		SitesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for NewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<News>))]
		NewsCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for MemberMembershipsCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberMemberships>))]
		MemberMembershipsCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for JobTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobTemplates>))]
		JobTemplatesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for DefaultResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DefaultResources>))]
		DefaultResourcesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for NewsCategoriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<NewsCategories>))]
		NewsCategoriesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for EducationsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Educations>))]
		EducationsCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for DynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		DynamicPagesCollectionGetByLastModifiedBy,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for DynamicPageWebPartTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageWebPartTemplates>))]
		DynamicPageWebPartTemplatesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for MemberStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberStatus>))]
		MemberStatusCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for MemberWizardCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberWizard>))]
		MemberWizardCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for FilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Files>))]
		FilesCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for AdvertisersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Advertisers>))]
		AdvertisersCollection,

		///<summary>
		/// Collection of <c>AdminUsers</c> as OneToMany for AdvertiserUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserUsers>))]
		AdvertiserUsersCollection,
	}
	
	#endregion AdminUsersChildEntityTypes
	
	#region AdminUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdminUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersFilterBuilder : SqlFilterBuilder<AdminUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		public AdminUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersFilterBuilder
	
	#region AdminUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdminUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersParameterBuilder : ParameterizedSqlFilterBuilder<AdminUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		public AdminUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersParameterBuilder
	
	#region AdminUsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdminUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdminUsersSortBuilder : SqlSortBuilder<AdminUsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersSqlSortBuilder class.
		/// </summary>
		public AdminUsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdminUsersSortBuilder
	
} // end namespace
