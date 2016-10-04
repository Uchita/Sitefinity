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
	/// This class is the base class for any <see cref="SiteSalaryTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteSalaryTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteSalaryType, JXTPortal.Entities.SiteSalaryTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteSalaryTypeKey key)
		{
			return Delete(transactionManager, key.SiteSalaryTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteSalaryTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteSalaryTypeId)
		{
			return Delete(null, _siteSalaryTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSalaryTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteSalaryTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		FK__SiteSalar__Salar__55209ACA Description: 
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(_salaryTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		FK__SiteSalar__Salar__55209ACA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		/// <remarks></remarks>
		public TList<SiteSalaryType> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		FK__SiteSalar__Salar__55209ACA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		fkSiteSalarSalar55209Aca Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		fkSiteSalarSalar55209Aca Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength,out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__Salar__55209ACA key.
		///		FK__SiteSalar__Salar__55209ACA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public abstract TList<SiteSalaryType> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		FK__SiteSalar__SiteI__5614BF03 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		FK__SiteSalar__SiteI__5614BF03 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		/// <remarks></remarks>
		public TList<SiteSalaryType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		FK__SiteSalar__SiteI__5614BF03 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		fkSiteSalarSitei5614Bf03 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		fkSiteSalarSitei5614Bf03 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public TList<SiteSalaryType> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteSalar__SiteI__5614BF03 key.
		///		FK__SiteSalar__SiteI__5614BF03 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteSalaryType objects.</returns>
		public abstract TList<SiteSalaryType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteSalaryType Get(TransactionManager transactionManager, JXTPortal.Entities.SiteSalaryTypeKey key, int start, int pageLength)
		{
			return GetBySiteSalaryTypeId(transactionManager, key.SiteSalaryTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="_siteSalaryTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(System.Int32 _siteSalaryTypeId)
		{
			int count = -1;
			return GetBySiteSalaryTypeId(null,_siteSalaryTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="_siteSalaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(System.Int32 _siteSalaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteSalaryTypeId(null, _siteSalaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSalaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(TransactionManager transactionManager, System.Int32 _siteSalaryTypeId)
		{
			int count = -1;
			return GetBySiteSalaryTypeId(transactionManager, _siteSalaryTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSalaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(TransactionManager transactionManager, System.Int32 _siteSalaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteSalaryTypeId(transactionManager, _siteSalaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="_siteSalaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(System.Int32 _siteSalaryTypeId, int start, int pageLength, out int count)
		{
			return GetBySiteSalaryTypeId(null, _siteSalaryTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteSalaryType__3A6CA48E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteSalaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteSalaryType"/> class.</returns>
		public abstract JXTPortal.Entities.SiteSalaryType GetBySiteSalaryTypeId(TransactionManager transactionManager, System.Int32 _siteSalaryTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteSalaryType_GetBySiteSalaryTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteSalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteSalaryTypeId(System.Int32? siteSalaryTypeId)
		{
			return GetBySiteSalaryTypeId(null, 0, int.MaxValue , siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteSalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteSalaryTypeId(int start, int pageLength, System.Int32? siteSalaryTypeId)
		{
			return GetBySiteSalaryTypeId(null, start, pageLength , siteSalaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteSalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteSalaryTypeId(TransactionManager transactionManager, System.Int32? siteSalaryTypeId)
		{
			return GetBySiteSalaryTypeId(transactionManager, 0, int.MaxValue , siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteSalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> GetBySiteSalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSalaryTypeId);
		
		#endregion
		
		#region SiteSalaryType_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence, ref System.Int32? siteSalaryTypeId)
		{
			 Insert(null, 0, int.MaxValue , salaryTypeId, siteId, salaryTypeName, valid, sequence, ref siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence, ref System.Int32? siteSalaryTypeId)
		{
			 Insert(null, start, pageLength , salaryTypeId, siteId, salaryTypeName, valid, sequence, ref siteSalaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence, ref System.Int32? siteSalaryTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , salaryTypeId, siteId, salaryTypeName, valid, sequence, ref siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence, ref System.Int32? siteSalaryTypeId);
		
		#endregion
		
		#region SiteSalaryType_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteSalaryType_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteSalaryType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteSalaryType_Find 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Find(System.Boolean? searchUsingOr, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			return Find(null, start, pageLength , searchUsingOr, siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence);
		
		#endregion
		
		#region SiteSalaryType_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteSalaryTypeId)
		{
			 Delete(null, 0, int.MaxValue , siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteSalaryTypeId)
		{
			 Delete(null, start, pageLength , siteSalaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteSalaryTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteSalaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSalaryTypeId);
		
		#endregion
		
		#region SiteSalaryType_GetBySalaryTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(int start, int pageLength, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, start, pageLength , salaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public TList<SiteSalaryType> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(transactionManager, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteSalaryType&gt;"/> instance.</returns>
		public abstract TList<SiteSalaryType> GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region SiteSalaryType_Update 
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			 Update(null, 0, int.MaxValue , siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			 Update(null, start, pageLength , siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence)
		{
			 Update(transactionManager, 0, int.MaxValue , siteSalaryTypeId, salaryTypeId, siteId, salaryTypeName, valid, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteSalaryType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteSalaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteSalaryTypeId, System.Int32? salaryTypeId, System.Int32? siteId, System.String salaryTypeName, System.Boolean? valid, System.Int32? sequence);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteSalaryType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteSalaryType&gt;"/></returns>
		public static TList<SiteSalaryType> Fill(IDataReader reader, TList<SiteSalaryType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteSalaryType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteSalaryType")
					.Append("|").Append((System.Int32)reader[((int)SiteSalaryTypeColumn.SiteSalaryTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteSalaryType>(
					key.ToString(), // EntityTrackingKey
					"SiteSalaryType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteSalaryType();
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
					c.SiteSalaryTypeId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SiteSalaryTypeId - 1)];
					c.SalaryTypeId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SalaryTypeId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SiteId - 1)];
					c.SalaryTypeName = (System.String)reader[((int)SiteSalaryTypeColumn.SalaryTypeName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteSalaryTypeColumn.Valid - 1)];
					c.Sequence = (System.Int32)reader[((int)SiteSalaryTypeColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteSalaryType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSalaryType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteSalaryType entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteSalaryTypeId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SiteSalaryTypeId - 1)];
			entity.SalaryTypeId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SalaryTypeId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteSalaryTypeColumn.SiteId - 1)];
			entity.SalaryTypeName = (System.String)reader[((int)SiteSalaryTypeColumn.SalaryTypeName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteSalaryTypeColumn.Valid - 1)];
			entity.Sequence = (System.Int32)reader[((int)SiteSalaryTypeColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteSalaryType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSalaryType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteSalaryType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteSalaryTypeId = (System.Int32)dataRow["SiteSalaryTypeID"];
			entity.SalaryTypeId = (System.Int32)dataRow["SalaryTypeID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.SalaryTypeName = (System.String)dataRow["SalaryTypeName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteSalaryType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteSalaryType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteSalaryType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SalaryTypeIdSource	
			if (CanDeepLoad(entity, "SalaryType|SalaryTypeIdSource", deepLoadType, innerList) 
				&& entity.SalaryTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalaryTypeId;
				SalaryType tmpEntity = EntityManager.LocateEntity<SalaryType>(EntityLocator.ConstructKeyFromPkItems(typeof(SalaryType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalaryTypeIdSource = tmpEntity;
				else
					entity.SalaryTypeIdSource = DataRepository.SalaryTypeProvider.GetBySalaryTypeId(transactionManager, entity.SalaryTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalaryTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalaryTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalaryTypeProvider.DeepLoad(transactionManager, entity.SalaryTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalaryTypeIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteSalaryType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteSalaryType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteSalaryType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteSalaryType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SalaryTypeIdSource
			if (CanDeepSave(entity, "SalaryType|SalaryTypeIdSource", deepSaveType, innerList) 
				&& entity.SalaryTypeIdSource != null)
			{
				DataRepository.SalaryTypeProvider.Save(transactionManager, entity.SalaryTypeIdSource);
				entity.SalaryTypeId = entity.SalaryTypeIdSource.SalaryTypeId;
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
	
	#region SiteSalaryTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteSalaryType</c>
	///</summary>
	public enum SiteSalaryTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>SalaryType</c> at SalaryTypeIdSource
		///</summary>
		[ChildEntityType(typeof(SalaryType))]
		SalaryType,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteSalaryTypeChildEntityTypes
	
	#region SiteSalaryTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteSalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeFilterBuilder : SqlFilterBuilder<SiteSalaryTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilterBuilder class.
		/// </summary>
		public SiteSalaryTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSalaryTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSalaryTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSalaryTypeFilterBuilder
	
	#region SiteSalaryTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteSalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeParameterBuilder : ParameterizedSqlFilterBuilder<SiteSalaryTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeParameterBuilder class.
		/// </summary>
		public SiteSalaryTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSalaryTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSalaryTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSalaryTypeParameterBuilder
	
	#region SiteSalaryTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteSalaryTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteSalaryTypeSortBuilder : SqlSortBuilder<SiteSalaryTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeSqlSortBuilder class.
		/// </summary>
		public SiteSalaryTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteSalaryTypeSortBuilder
	
} // end namespace
