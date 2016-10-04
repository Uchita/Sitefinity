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
	/// This class is the base class for any <see cref="RolesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RolesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Roles, JXTPortal.Entities.RolesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.RolesKey key)
		{
			return Delete(transactionManager, key.RoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_roleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _roleId)
		{
			return Delete(null, _roleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _roleId);		
		
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
		public override JXTPortal.Entities.Roles Get(TransactionManager transactionManager, JXTPortal.Entities.RolesKey key, int start, int pageLength)
		{
			return GetByRoleId(transactionManager, key.RoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionIdRoleId(System.Int32 _professionId, System.Int32 _roleId)
		{
			int count = -1;
			return GetByProfessionIdRoleId(null,_professionId, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionIdRoleId(System.Int32 _professionId, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionIdRoleId(null, _professionId, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionIdRoleId(TransactionManager transactionManager, System.Int32 _professionId, System.Int32 _roleId)
		{
			int count = -1;
			return GetByProfessionIdRoleId(transactionManager, _professionId, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionIdRoleId(TransactionManager transactionManager, System.Int32 _professionId, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionIdRoleId(transactionManager, _professionId, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionIdRoleId(System.Int32 _professionId, System.Int32 _roleId, int start, int pageLength, out int count)
		{
			return GetByProfessionIdRoleId(null, _professionId, _roleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_Roles_7_708197573__K2_K1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public abstract TList<Roles> GetByProfessionIdRoleId(TransactionManager transactionManager, System.Int32 _professionId, System.Int32 _roleId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Roles index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionId(System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(null,_professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Roles index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionId(System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Roles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Roles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Roles index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public TList<Roles> GetByProfessionId(System.Int32 _professionId, int start, int pageLength, out int count)
		{
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Roles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Roles&gt;"/> class.</returns>
		public abstract TList<Roles> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public JXTPortal.Entities.Roles GetByRoleId(System.Int32 _roleId)
		{
			int count = -1;
			return GetByRoleId(null,_roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public JXTPortal.Entities.Roles GetByRoleId(System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(null, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public JXTPortal.Entities.Roles GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public JXTPortal.Entities.Roles GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public JXTPortal.Entities.Roles GetByRoleId(System.Int32 _roleId, int start, int pageLength, out int count)
		{
			return GetByRoleId(null, _roleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Roles__2B2A60FE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Roles"/> class.</returns>
		public abstract JXTPortal.Entities.Roles GetByRoleId(TransactionManager transactionManager, System.Int32 _roleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Roles_GetSiteTree 
		
		/// <summary>
		///	This method wrap the 'Roles_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(System.Int32? siteId)
		{
			return GetSiteTree(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetSiteTree' stored procedure. 
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
		///	This method wrap the 'Roles_GetSiteTree' stored procedure. 
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
		///	This method wrap the 'Roles_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSiteTree(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Roles_Insert 
		
		/// <summary>
		///	This method wrap the 'Roles_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
			/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, ref System.Int32? roleId)
		{
			 Insert(null, 0, int.MaxValue , professionId, roleName, valid, metaTitle, metaKeywords, metaDescription, ref roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
			/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, ref System.Int32? roleId)
		{
			 Insert(null, start, pageLength , professionId, roleName, valid, metaTitle, metaKeywords, metaDescription, ref roleId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
			/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, ref System.Int32? roleId)
		{
			 Insert(transactionManager, 0, int.MaxValue , professionId, roleName, valid, metaTitle, metaKeywords, metaDescription, ref roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
			/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, ref System.Int32? roleId);
		
		#endregion
		
		#region Roles_GetByProfessionId 
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(System.Int32? professionId)
		{
			return GetByProfessionId(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(int start, int pageLength, System.Int32? professionId)
		{
			return GetByProfessionId(null, start, pageLength , professionId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(TransactionManager transactionManager, System.Int32? professionId)
		{
			return GetByProfessionId(transactionManager, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId);
		
		#endregion
		
		#region Roles_Get_List 
		
		/// <summary>
		///	This method wrap the 'Roles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Roles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public abstract TList<Roles> Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion
		
		#region Roles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Roles_GetPaged' stored procedure. 
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
		///	This method wrap the 'Roles_GetPaged' stored procedure. 
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
		///	This method wrap the 'Roles_GetPaged' stored procedure. 
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
		///	This method wrap the 'Roles_GetPaged' stored procedure. 
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
		
		#region Roles_CustomBulkInsert 
		
		/// <summary>
		///	This method wrap the 'Roles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(null, 0, int.MaxValue , siteId, xmlText);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(int start, int pageLength, System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(null, start, pageLength , siteId, xmlText);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(TransactionManager transactionManager, System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(transactionManager, 0, int.MaxValue , siteId, xmlText);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkInsert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String xmlText);
		
		#endregion
		
		#region Roles_Update 
		
		/// <summary>
		///	This method wrap the 'Roles_Update' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			 Update(null, 0, int.MaxValue , roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Update' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			 Update(null, start, pageLength , roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_Update' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			 Update(transactionManager, 0, int.MaxValue , roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Update' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription);
		
		#endregion
		
		#region Roles_Find 
		
		/// <summary>
		///	This method wrap the 'Roles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			return Find(null, start, pageLength , searchUsingOr, roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, roleId, professionId, roleName, valid, metaTitle, metaKeywords, metaDescription);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? roleId, System.Int32? professionId, System.String roleName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription);
		
		#endregion
		
		#region Roles_Delete 
		
		/// <summary>
		///	This method wrap the 'Roles_Delete' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? roleId)
		{
			 Delete(null, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Delete' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? roleId)
		{
			 Delete(null, start, pageLength , roleId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_Delete' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? roleId)
		{
			 Delete(transactionManager, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_Delete' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? roleId);
		
		#endregion
		
		#region Roles_GetDetailWithSite 
		
		/// <summary>
		///	This method wrap the 'Roles_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(System.Int32? siteId, System.Int32? roleId)
		{
			return GetDetailWithSite(null, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(int start, int pageLength, System.Int32? siteId, System.Int32? roleId)
		{
			return GetDetailWithSite(null, start, pageLength , siteId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(TransactionManager transactionManager, System.Int32? siteId, System.Int32? roleId)
		{
			return GetDetailWithSite(transactionManager, 0, int.MaxValue , siteId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetDetailWithSite(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? roleId);
		
		#endregion
		
		#region Roles_GetByRoleId 
		
		/// <summary>
		///	This method wrap the 'Roles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> GetByRoleId(System.Int32? roleId)
		{
			return GetByRoleId(null, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> GetByRoleId(int start, int pageLength, System.Int32? roleId)
		{
			return GetByRoleId(null, start, pageLength , roleId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<Roles> GetByRoleId(TransactionManager transactionManager, System.Int32? roleId)
		{
			return GetByRoleId(transactionManager, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public abstract TList<Roles> GetByRoleId(TransactionManager transactionManager, int start, int pageLength, System.Int32? roleId);
		
		#endregion
		
		#region Roles_GetByProfessionIdRoleId 
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionIdRoleId(System.Int32? professionId, System.Int32? roleId)
		{
			return GetByProfessionIdRoleId(null, 0, int.MaxValue , professionId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionIdRoleId(int start, int pageLength, System.Int32? professionId, System.Int32? roleId)
		{
			return GetByProfessionIdRoleId(null, start, pageLength , professionId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionIdRoleId(TransactionManager transactionManager, System.Int32? professionId, System.Int32? roleId)
		{
			return GetByProfessionIdRoleId(transactionManager, 0, int.MaxValue , professionId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'Roles_GetByProfessionIdRoleId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByProfessionIdRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId, System.Int32? roleId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Roles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Roles&gt;"/></returns>
		public static TList<Roles> Fill(IDataReader reader, TList<Roles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Roles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Roles")
					.Append("|").Append((System.Int32)reader[((int)RolesColumn.RoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Roles>(
					key.ToString(), // EntityTrackingKey
					"Roles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Roles();
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
					c.RoleId = (System.Int32)reader[((int)RolesColumn.RoleId - 1)];
					c.ProfessionId = (System.Int32)reader[((int)RolesColumn.ProfessionId - 1)];
					c.RoleName = (System.String)reader[((int)RolesColumn.RoleName - 1)];
					c.Valid = (System.Boolean)reader[((int)RolesColumn.Valid - 1)];
					c.MetaTitle = (System.String)reader[((int)RolesColumn.MetaTitle - 1)];
					c.MetaKeywords = (System.String)reader[((int)RolesColumn.MetaKeywords - 1)];
					c.MetaDescription = (System.String)reader[((int)RolesColumn.MetaDescription - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Roles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Roles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Roles entity)
		{
			if (!reader.Read()) return;
			
			entity.RoleId = (System.Int32)reader[((int)RolesColumn.RoleId - 1)];
			entity.ProfessionId = (System.Int32)reader[((int)RolesColumn.ProfessionId - 1)];
			entity.RoleName = (System.String)reader[((int)RolesColumn.RoleName - 1)];
			entity.Valid = (System.Boolean)reader[((int)RolesColumn.Valid - 1)];
			entity.MetaTitle = (System.String)reader[((int)RolesColumn.MetaTitle - 1)];
			entity.MetaKeywords = (System.String)reader[((int)RolesColumn.MetaKeywords - 1)];
			entity.MetaDescription = (System.String)reader[((int)RolesColumn.MetaDescription - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Roles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Roles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Roles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RoleId = (System.Int32)dataRow["RoleID"];
			entity.ProfessionId = (System.Int32)dataRow["ProfessionID"];
			entity.RoleName = (System.String)dataRow["RoleName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.MetaTitle = (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = (System.String)dataRow["MetaDescription"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Roles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Roles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Roles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProfessionIdSource	
			if (CanDeepLoad(entity, "Profession|ProfessionIdSource", deepLoadType, innerList) 
				&& entity.ProfessionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProfessionId;
				Profession tmpEntity = EntityManager.LocateEntity<Profession>(EntityLocator.ConstructKeyFromPkItems(typeof(Profession), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProfessionIdSource = tmpEntity;
				else
					entity.ProfessionIdSource = DataRepository.ProfessionProvider.GetByProfessionId(transactionManager, entity.ProfessionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProfessionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProfessionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProfessionProvider.DeepLoad(transactionManager, entity.ProfessionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProfessionIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByRoleId methods when available
			
			#region SiteRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteRoles>|SiteRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteRolesCollection = DataRepository.SiteRolesProvider.GetByRoleId(transactionManager, entity.RoleId);

				if (deep && entity.SiteRolesCollection.Count > 0)
				{
					deepHandles.Add("SiteRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteRoles>) DataRepository.SiteRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteRolesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobRoles>|JobRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobRolesCollection = DataRepository.JobRolesProvider.GetByRoleId(transactionManager, entity.RoleId);

				if (deep && entity.JobRolesCollection.Count > 0)
				{
					deepHandles.Add("JobRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobRoles>) DataRepository.JobRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobRolesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Roles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Roles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Roles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Roles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProfessionIdSource
			if (CanDeepSave(entity, "Profession|ProfessionIdSource", deepSaveType, innerList) 
				&& entity.ProfessionIdSource != null)
			{
				DataRepository.ProfessionProvider.Save(transactionManager, entity.ProfessionIdSource);
				entity.ProfessionId = entity.ProfessionIdSource.ProfessionId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SiteRoles>
				if (CanDeepSave(entity.SiteRolesCollection, "List<SiteRoles>|SiteRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteRoles child in entity.SiteRolesCollection)
					{
						if(child.RoleIdSource != null)
						{
							child.RoleId = child.RoleIdSource.RoleId;
						}
						else
						{
							child.RoleId = entity.RoleId;
						}

					}

					if (entity.SiteRolesCollection.Count > 0 || entity.SiteRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteRolesProvider.Save(transactionManager, entity.SiteRolesCollection);
						
						deepHandles.Add("SiteRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteRoles >) DataRepository.SiteRolesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteRolesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobRoles>
				if (CanDeepSave(entity.JobRolesCollection, "List<JobRoles>|JobRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobRoles child in entity.JobRolesCollection)
					{
						if(child.RoleIdSource != null)
						{
							child.RoleId = child.RoleIdSource.RoleId;
						}
						else
						{
							child.RoleId = entity.RoleId;
						}

					}

					if (entity.JobRolesCollection.Count > 0 || entity.JobRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobRolesProvider.Save(transactionManager, entity.JobRolesCollection);
						
						deepHandles.Add("JobRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobRoles >) DataRepository.JobRolesProvider.DeepSave,
							new object[] { transactionManager, entity.JobRolesCollection, deepSaveType, childTypes, innerList }
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
	
	#region RolesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Roles</c>
	///</summary>
	public enum RolesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profession</c> at ProfessionIdSource
		///</summary>
		[ChildEntityType(typeof(Profession))]
		Profession,
	
		///<summary>
		/// Collection of <c>Roles</c> as OneToMany for SiteRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteRoles>))]
		SiteRolesCollection,

		///<summary>
		/// Collection of <c>Roles</c> as OneToMany for JobRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobRoles>))]
		JobRolesCollection,
	}
	
	#endregion RolesChildEntityTypes
	
	#region RolesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesFilterBuilder : SqlFilterBuilder<RolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesFilterBuilder class.
		/// </summary>
		public RolesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RolesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RolesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RolesFilterBuilder
	
	#region RolesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesParameterBuilder : ParameterizedSqlFilterBuilder<RolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesParameterBuilder class.
		/// </summary>
		public RolesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RolesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RolesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RolesParameterBuilder
	
	#region RolesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;RolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class RolesSortBuilder : SqlSortBuilder<RolesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesSqlSortBuilder class.
		/// </summary>
		public RolesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion RolesSortBuilder
	
} // end namespace
