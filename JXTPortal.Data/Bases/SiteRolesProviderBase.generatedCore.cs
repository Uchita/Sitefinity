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
	/// This class is the base class for any <see cref="SiteRolesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteRolesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteRoles, JXTPortal.Entities.SiteRolesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteRolesKey key)
		{
			return Delete(transactionManager, key.SiteRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteRoleId)
		{
			return Delete(null, _siteRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteRoleId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		FK__SiteRoles__RoleI__1CA7377D Description: 
		/// </summary>
		/// <param name="_roleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		public TList<SiteRoles> GetByRoleId(System.Int32 _roleId)
		{
			int count = -1;
			return GetByRoleId(_roleId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		FK__SiteRoles__RoleI__1CA7377D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		/// <remarks></remarks>
		public TList<SiteRoles> GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		FK__SiteRoles__RoleI__1CA7377D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		public TList<SiteRoles> GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		fkSiteRolesRolei1Ca7377d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		public TList<SiteRoles> GetByRoleId(System.Int32 _roleId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRoleId(null, _roleId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		fkSiteRolesRolei1Ca7377d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		public TList<SiteRoles> GetByRoleId(System.Int32 _roleId, int start, int pageLength,out int count)
		{
			return GetByRoleId(null, _roleId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteRoles__RoleI__1CA7377D key.
		///		FK__SiteRoles__RoleI__1CA7377D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteRoles objects.</returns>
		public abstract TList<SiteRoles> GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteRoles Get(TransactionManager transactionManager, JXTPortal.Entities.SiteRolesKey key, int start, int pageLength)
		{
			return GetBySiteRoleId(transactionManager, key.SiteRoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(null,_siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteId(System.Int32 _siteId, int start, int pageLength, out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public abstract TList<SiteRoles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="_siteRoleId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public JXTPortal.Entities.SiteRoles GetBySiteRoleId(System.Int32 _siteRoleId)
		{
			int count = -1;
			return GetBySiteRoleId(null,_siteRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="_siteRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public JXTPortal.Entities.SiteRoles GetBySiteRoleId(System.Int32 _siteRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteRoleId(null, _siteRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteRoleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public JXTPortal.Entities.SiteRoles GetBySiteRoleId(TransactionManager transactionManager, System.Int32 _siteRoleId)
		{
			int count = -1;
			return GetBySiteRoleId(transactionManager, _siteRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public JXTPortal.Entities.SiteRoles GetBySiteRoleId(TransactionManager transactionManager, System.Int32 _siteRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteRoleId(transactionManager, _siteRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="_siteRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public JXTPortal.Entities.SiteRoles GetBySiteRoleId(System.Int32 _siteRoleId, int start, int pageLength, out int count)
		{
			return GetBySiteRoleId(null, _siteRoleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteRo__113584D1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteRoles"/> class.</returns>
		public abstract JXTPortal.Entities.SiteRoles GetBySiteRoleId(TransactionManager transactionManager, System.Int32 _siteRoleId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key wit_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(System.Int32 _siteId, System.String _siteRoleFriendlyUrl)
		{
			int count = -1;
			return GetBySiteIdSiteRoleFriendlyUrl(null,_siteId, _siteRoleFriendlyUrl, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(System.Int32 _siteId, System.String _siteRoleFriendlyUrl, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdSiteRoleFriendlyUrl(null, _siteId, _siteRoleFriendlyUrl, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(TransactionManager transactionManager, System.Int32 _siteId, System.String _siteRoleFriendlyUrl)
		{
			int count = -1;
			return GetBySiteIdSiteRoleFriendlyUrl(transactionManager, _siteId, _siteRoleFriendlyUrl, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(TransactionManager transactionManager, System.Int32 _siteId, System.String _siteRoleFriendlyUrl, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdSiteRoleFriendlyUrl(transactionManager, _siteId, _siteRoleFriendlyUrl, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(System.Int32 _siteId, System.String _siteRoleFriendlyUrl, int start, int pageLength, out int count)
		{
			return GetBySiteIdSiteRoleFriendlyUrl(null, _siteId, _siteRoleFriendlyUrl, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_siteRoleFriendlyUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public abstract TList<SiteRoles> GetBySiteIdSiteRoleFriendlyUrl(TransactionManager transactionManager, System.Int32 _siteId, System.String _siteRoleFriendlyUrl, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdRoleId(System.Int32 _siteId, System.Int32 _roleId)
		{
			int count = -1;
			return GetBySiteIdRoleId(null,_siteId, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdRoleId(System.Int32 _siteId, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdRoleId(null, _siteId, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdRoleId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _roleId)
		{
			int count = -1;
			return GetBySiteIdRoleId(transactionManager, _siteId, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdRoleId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdRoleId(transactionManager, _siteId, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public TList<SiteRoles> GetBySiteIdRoleId(System.Int32 _siteId, System.Int32 _roleId, int start, int pageLength, out int count)
		{
			return GetBySiteIdRoleId(null, _siteId, _roleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the wit_SiteRoles_2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteRoles&gt;"/> class.</returns>
		public abstract TList<SiteRoles> GetBySiteIdRoleId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _roleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteRoles_CustomGetBySiteIDRoleID 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomGetBySiteIDRoleID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDRoleID(System.Int32? siteId, System.Int32? roleId)
		{
			return CustomGetBySiteIDRoleID(null, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomGetBySiteIDRoleID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDRoleID(int start, int pageLength, System.Int32? siteId, System.Int32? roleId)
		{
			return CustomGetBySiteIDRoleID(null, start, pageLength , siteId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomGetBySiteIDRoleID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDRoleID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? roleId)
		{
			return CustomGetBySiteIDRoleID(transactionManager, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomGetBySiteIDRoleID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteIDRoleID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? roleId);
		
		#endregion
		
		#region SiteRoles_GetBySiteIdSiteRoleFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdSiteRoleFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdSiteRoleFriendlyUrl(System.Int32? siteId, System.String siteRoleFriendlyUrl)
		{
			return GetBySiteIdSiteRoleFriendlyUrl(null, 0, int.MaxValue , siteId, siteRoleFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdSiteRoleFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdSiteRoleFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String siteRoleFriendlyUrl)
		{
			return GetBySiteIdSiteRoleFriendlyUrl(null, start, pageLength , siteId, siteRoleFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdSiteRoleFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdSiteRoleFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String siteRoleFriendlyUrl)
		{
			return GetBySiteIdSiteRoleFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, siteRoleFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdSiteRoleFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdSiteRoleFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteRoleFriendlyUrl);
		
		#endregion
		
		#region SiteRoles_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteRoleId)
		{
			 Insert(null, 0, int.MaxValue , siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl, ref siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteRoleId)
		{
			 Insert(null, start, pageLength , siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl, ref siteRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteRoleId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl, ref siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteRoleId);
		
		#endregion
		
		#region SiteRoles_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteRoles_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteRoles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteRoles_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Get_List' stored procedure. 
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
		///	This method wrap the 'SiteRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteRoles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteRoles_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteRoles_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteRoles_GetPaged' stored procedure. 
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
		
		#region SiteRoles_Update 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(null, 0, int.MaxValue , siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(null, start, pageLength , siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl);
		
		#endregion
		
		#region SiteRoles_GetBySiteIdFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetBySiteIdFriendlyUrl(System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetBySiteIdFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, start, pageLength , siteId, friendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public abstract TList<SiteRoles> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String friendlyUrl);
		
		#endregion
		
		#region SiteRoles_CustomBulkInsert 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(System.String values)
		{
			 CustomBulkInsert(null, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(int start, int pageLength, System.String values)
		{
			 CustomBulkInsert(null, start, pageLength , values);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(TransactionManager transactionManager, System.String values)
		{
			 CustomBulkInsert(transactionManager, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkInsert(TransactionManager transactionManager, int start, int pageLength , System.String values);
		
		#endregion
		
		#region SiteRoles_CustomBulkDelete 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(System.String values)
		{
			 CustomBulkDelete(null, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(int start, int pageLength, System.String values)
		{
			 CustomBulkDelete(null, start, pageLength , values);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(TransactionManager transactionManager, System.String values)
		{
			 CustomBulkDelete(transactionManager, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkDelete(TransactionManager transactionManager, int start, int pageLength , System.String values);
		
		#endregion
		
		#region SiteRoles_GetByProfessionID 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetByProfessionID(System.Int32? siteId, System.Int32? professionId)
		{
			return GetByProfessionID(null, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetByProfessionID(int start, int pageLength, System.Int32? siteId, System.Int32? professionId)
		{
			return GetByProfessionID(null, start, pageLength , siteId, professionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public TList<SiteRoles> GetByProfessionID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId)
		{
			return GetByProfessionID(transactionManager, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteRoles&gt;"/> instance.</returns>
		public abstract TList<SiteRoles> GetByProfessionID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? professionId);
		
		#endregion
		
		#region SiteRoles_GetBySiteIdRoleId 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdRoleId(System.Int32? siteId, System.Int32? roleId)
		{
			return GetBySiteIdRoleId(null, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdRoleId(int start, int pageLength, System.Int32? siteId, System.Int32? roleId)
		{
			return GetBySiteIdRoleId(null, start, pageLength , siteId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdRoleId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? roleId)
		{
			return GetBySiteIdRoleId(transactionManager, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? roleId);
		
		#endregion
		
		#region SiteRoles_GetBySiteRoleId 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteRoleId(System.Int32? siteRoleId)
		{
			return GetBySiteRoleId(null, 0, int.MaxValue , siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteRoleId(int start, int pageLength, System.Int32? siteRoleId)
		{
			return GetBySiteRoleId(null, start, pageLength , siteRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteRoleId(TransactionManager transactionManager, System.Int32? siteRoleId)
		{
			return GetBySiteRoleId(transactionManager, 0, int.MaxValue , siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetBySiteRoleId' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteRoleId);
		
		#endregion
		
		#region SiteRoles_Find 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteRoleId, siteId, roleId, siteRoleName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteRoleFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteRoleFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteRoleId, System.Int32? siteId, System.Int32? roleId, System.String siteRoleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteRoleFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl);
		
		#endregion
		
		#region SiteRoles_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteRoleId)
		{
			 Delete(null, 0, int.MaxValue , siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteRoleId)
		{
			 Delete(null, start, pageLength , siteRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteRoleId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteRoleId);
		
		#endregion
		
		#region SiteRoles_GetByRoleId 
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRoleId(System.Int32? roleId)
		{
			return GetByRoleId(null, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRoleId(int start, int pageLength, System.Int32? roleId)
		{
			return GetByRoleId(null, start, pageLength , roleId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRoleId(TransactionManager transactionManager, System.Int32? roleId)
		{
			return GetByRoleId(transactionManager, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? roleId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteRoles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteRoles&gt;"/></returns>
		public static TList<SiteRoles> Fill(IDataReader reader, TList<SiteRoles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteRoles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteRoles")
					.Append("|").Append((System.Int32)reader[((int)SiteRolesColumn.SiteRoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteRoles>(
					key.ToString(), // EntityTrackingKey
					"SiteRoles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteRoles();
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
					c.SiteRoleId = (System.Int32)reader[((int)SiteRolesColumn.SiteRoleId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteRolesColumn.SiteId - 1)];
					c.RoleId = (System.Int32)reader[((int)SiteRolesColumn.RoleId - 1)];
					c.SiteRoleName = (reader.IsDBNull(((int)SiteRolesColumn.SiteRoleName - 1)))?null:(System.String)reader[((int)SiteRolesColumn.SiteRoleName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteRolesColumn.Valid - 1)];
					c.MetaTitle = (System.String)reader[((int)SiteRolesColumn.MetaTitle - 1)];
					c.MetaKeywords = (System.String)reader[((int)SiteRolesColumn.MetaKeywords - 1)];
					c.MetaDescription = (System.String)reader[((int)SiteRolesColumn.MetaDescription - 1)];
					c.Sequence = (System.Int32)reader[((int)SiteRolesColumn.Sequence - 1)];
					c.SiteRoleFriendlyUrl = (reader.IsDBNull(((int)SiteRolesColumn.SiteRoleFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteRolesColumn.SiteRoleFriendlyUrl - 1)];
					c.TotalJobs = (System.Int32)reader[((int)SiteRolesColumn.TotalJobs - 1)];
					c.CanonicalUrl = (reader.IsDBNull(((int)SiteRolesColumn.CanonicalUrl - 1)))?null:(System.String)reader[((int)SiteRolesColumn.CanonicalUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteRoles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteRoles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteRoles entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteRoleId = (System.Int32)reader[((int)SiteRolesColumn.SiteRoleId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteRolesColumn.SiteId - 1)];
			entity.RoleId = (System.Int32)reader[((int)SiteRolesColumn.RoleId - 1)];
			entity.SiteRoleName = (reader.IsDBNull(((int)SiteRolesColumn.SiteRoleName - 1)))?null:(System.String)reader[((int)SiteRolesColumn.SiteRoleName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteRolesColumn.Valid - 1)];
			entity.MetaTitle = (System.String)reader[((int)SiteRolesColumn.MetaTitle - 1)];
			entity.MetaKeywords = (System.String)reader[((int)SiteRolesColumn.MetaKeywords - 1)];
			entity.MetaDescription = (System.String)reader[((int)SiteRolesColumn.MetaDescription - 1)];
			entity.Sequence = (System.Int32)reader[((int)SiteRolesColumn.Sequence - 1)];
			entity.SiteRoleFriendlyUrl = (reader.IsDBNull(((int)SiteRolesColumn.SiteRoleFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteRolesColumn.SiteRoleFriendlyUrl - 1)];
			entity.TotalJobs = (System.Int32)reader[((int)SiteRolesColumn.TotalJobs - 1)];
			entity.CanonicalUrl = (reader.IsDBNull(((int)SiteRolesColumn.CanonicalUrl - 1)))?null:(System.String)reader[((int)SiteRolesColumn.CanonicalUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteRoles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteRoles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteRoles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteRoleId = (System.Int32)dataRow["SiteRoleID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.RoleId = (System.Int32)dataRow["RoleID"];
			entity.SiteRoleName = Convert.IsDBNull(dataRow["SiteRoleName"]) ? null : (System.String)dataRow["SiteRoleName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.MetaTitle = (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = (System.String)dataRow["MetaDescription"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.SiteRoleFriendlyUrl = Convert.IsDBNull(dataRow["SiteRoleFriendlyUrl"]) ? null : (System.String)dataRow["SiteRoleFriendlyUrl"];
			entity.TotalJobs = (System.Int32)dataRow["TotalJobs"];
			entity.CanonicalUrl = Convert.IsDBNull(dataRow["CanonicalUrl"]) ? null : (System.String)dataRow["CanonicalUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteRoles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteRoles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteRoles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region RoleIdSource	
			if (CanDeepLoad(entity, "Roles|RoleIdSource", deepLoadType, innerList) 
				&& entity.RoleIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RoleId;
				Roles tmpEntity = EntityManager.LocateEntity<Roles>(EntityLocator.ConstructKeyFromPkItems(typeof(Roles), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RoleIdSource = tmpEntity;
				else
					entity.RoleIdSource = DataRepository.RolesProvider.GetByRoleId(transactionManager, entity.RoleId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RoleIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RoleIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RolesProvider.DeepLoad(transactionManager, entity.RoleIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RoleIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteRoles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteRoles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteRoles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteRoles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region RoleIdSource
			if (CanDeepSave(entity, "Roles|RoleIdSource", deepSaveType, innerList) 
				&& entity.RoleIdSource != null)
			{
				DataRepository.RolesProvider.Save(transactionManager, entity.RoleIdSource);
				entity.RoleId = entity.RoleIdSource.RoleId;
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
	
	#region SiteRolesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteRoles</c>
	///</summary>
	public enum SiteRolesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Roles</c> at RoleIdSource
		///</summary>
		[ChildEntityType(typeof(Roles))]
		Roles,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteRolesChildEntityTypes
	
	#region SiteRolesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesFilterBuilder : SqlFilterBuilder<SiteRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilterBuilder class.
		/// </summary>
		public SiteRolesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteRolesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteRolesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteRolesFilterBuilder
	
	#region SiteRolesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesParameterBuilder : ParameterizedSqlFilterBuilder<SiteRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesParameterBuilder class.
		/// </summary>
		public SiteRolesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteRolesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteRolesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteRolesParameterBuilder
	
	#region SiteRolesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteRolesSortBuilder : SqlSortBuilder<SiteRolesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesSqlSortBuilder class.
		/// </summary>
		public SiteRolesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteRolesSortBuilder
	
} // end namespace
