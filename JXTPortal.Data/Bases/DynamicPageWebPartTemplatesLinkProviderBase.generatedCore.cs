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
	/// This class is the base class for any <see cref="DynamicPageWebPartTemplatesLinkProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicPageWebPartTemplatesLinkProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicPageWebPartTemplatesLink, JXTPortal.Entities.DynamicPageWebPartTemplatesLinkKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesLinkKey key)
		{
			return Delete(transactionManager, key.DynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplatesLinkId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageWebPartTemplatesLinkId)
		{
			return Delete(null, _dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplatesLinkId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplatesLinkId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		FK__DynamicPa__Dynam__6C190EBB Description: 
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(_dynamicPageWebPartTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		FK__DynamicPa__Dynam__6C190EBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		FK__DynamicPa__Dynam__6C190EBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		fkDynamicPaDynam6c190Ebb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		fkDynamicPaDynam6c190Ebb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength,out int count)
		{
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__6C190EBB key.
		///		FK__DynamicPa__Dynam__6C190EBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		FK__DynamicPa__SiteW__6D0D32F4 Description: 
		/// </summary>
		/// <param name="_siteWebPartId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetBySiteWebPartId(_siteWebPartId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		FK__DynamicPa__SiteW__6D0D32F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetBySiteWebPartId(transactionManager, _siteWebPartId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		FK__DynamicPa__SiteW__6D0D32F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartId(transactionManager, _siteWebPartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		fkDynamicPaSitew6d0d32f4 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteWebPartId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteWebPartId(null, _siteWebPartId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		fkDynamicPaSitew6d0d32f4 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(System.Int32 _siteWebPartId, int start, int pageLength,out int count)
		{
			return GetBySiteWebPartId(null, _siteWebPartId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteW__6D0D32F4 key.
		///		FK__DynamicPa__SiteW__6D0D32F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplatesLink objects.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicPageWebPartTemplatesLink Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesLinkKey key, int start, int pageLength)
		{
			return GetByDynamicPageWebPartTemplatesLinkId(transactionManager, key.DynamicPageWebPartTemplatesLinkId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(null,_dynamicPageWebPartTemplateId, _siteWebPartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(null, _dynamicPageWebPartTemplateId, _siteWebPartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(transactionManager, _dynamicPageWebPartTemplateId, _siteWebPartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(transactionManager, _dynamicPageWebPartTemplateId, _siteWebPartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(null, _dynamicPageWebPartTemplateId, _siteWebPartId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageWebPartTemplatesLink index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplateIdSiteWebPartId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, System.Int32 _siteWebPartId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(System.Int32 _dynamicPageWebPartTemplatesLinkId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplatesLinkId(null,_dynamicPageWebPartTemplatesLinkId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(System.Int32 _dynamicPageWebPartTemplatesLinkId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplatesLinkId(null, _dynamicPageWebPartTemplatesLinkId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplatesLinkId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplatesLinkId(transactionManager, _dynamicPageWebPartTemplatesLinkId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplatesLinkId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplatesLinkId(transactionManager, _dynamicPageWebPartTemplatesLinkId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(System.Int32 _dynamicPageWebPartTemplatesLinkId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageWebPartTemplatesLinkId(null, _dynamicPageWebPartTemplatesLinkId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__15502E78 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplatesLinkId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPageWebPartTemplatesLink GetByDynamicPageWebPartTemplatesLinkId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplatesLinkId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicPageWebPartTemplatesLink_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence, ref System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Insert(null, 0, int.MaxValue , dynamicPageWebPartTemplateId, siteWebPartId, sequence, ref dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence, ref System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Insert(null, start, pageLength , dynamicPageWebPartTemplateId, siteWebPartId, sequence, ref dynamicPageWebPartTemplatesLinkId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence, ref System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Insert(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId, siteWebPartId, sequence, ref dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence, ref System.Int32? dynamicPageWebPartTemplatesLinkId);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateIdSiteWebPartId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateIdSiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateIdSiteWebPartId(System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId)
		{
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(null, 0, int.MaxValue , dynamicPageWebPartTemplateId, siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateIdSiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateIdSiteWebPartId(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId)
		{
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(null, start, pageLength , dynamicPageWebPartTemplateId, siteWebPartId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateIdSiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateIdSiteWebPartId(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId)
		{
			return GetByDynamicPageWebPartTemplateIdSiteWebPartId(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId, siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateIdSiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateIdSiteWebPartId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplatesLinkId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplatesLinkId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplatesLinkId(System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			return GetByDynamicPageWebPartTemplatesLinkId(null, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplatesLinkId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplatesLinkId(int start, int pageLength, System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			return GetByDynamicPageWebPartTemplatesLinkId(null, start, pageLength , dynamicPageWebPartTemplatesLinkId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplatesLinkId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplatesLinkId(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			return GetByDynamicPageWebPartTemplatesLinkId(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplatesLinkId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplatesLinkId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplatesLinkId);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(null, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_GetBySiteWebPartId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(null, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(int start, int pageLength, System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(null, start, pageLength , siteWebPartId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(TransactionManager transactionManager, System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(transactionManager, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplatesLink> GetBySiteWebPartId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartId);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			 Update(null, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			 Update(null, start, pageLength , dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId, dynamicPageWebPartTemplateId, siteWebPartId, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplatesLinkId, System.Int32? dynamicPageWebPartTemplateId, System.Int32? siteWebPartId, System.Int32? sequence);
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLink_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Delete(null, start, pageLength , dynamicPageWebPartTemplatesLinkId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplatesLinkId)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplatesLinkId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplatesLink_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplatesLinkId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplatesLinkId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicPageWebPartTemplatesLink&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicPageWebPartTemplatesLink&gt;"/></returns>
		public static TList<DynamicPageWebPartTemplatesLink> Fill(IDataReader reader, TList<DynamicPageWebPartTemplatesLink> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicPageWebPartTemplatesLink c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicPageWebPartTemplatesLink")
					.Append("|").Append((System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.DynamicPageWebPartTemplatesLinkId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicPageWebPartTemplatesLink>(
					key.ToString(), // EntityTrackingKey
					"DynamicPageWebPartTemplatesLink",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicPageWebPartTemplatesLink();
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
					c.DynamicPageWebPartTemplatesLinkId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.DynamicPageWebPartTemplatesLinkId - 1)];
					c.DynamicPageWebPartTemplateId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.DynamicPageWebPartTemplateId - 1)];
					c.SiteWebPartId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.SiteWebPartId - 1)];
					c.Sequence = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicPageWebPartTemplatesLink entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageWebPartTemplatesLinkId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.DynamicPageWebPartTemplatesLinkId - 1)];
			entity.DynamicPageWebPartTemplateId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.DynamicPageWebPartTemplateId - 1)];
			entity.SiteWebPartId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.SiteWebPartId - 1)];
			entity.Sequence = (System.Int32)reader[((int)DynamicPageWebPartTemplatesLinkColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicPageWebPartTemplatesLink entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageWebPartTemplatesLinkId = (System.Int32)dataRow["DynamicPageWebPartTemplatesLinkID"];
			entity.DynamicPageWebPartTemplateId = (System.Int32)dataRow["DynamicPageWebPartTemplateID"];
			entity.SiteWebPartId = (System.Int32)dataRow["SiteWebPartID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplatesLink"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageWebPartTemplatesLink Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesLink entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DynamicPageWebPartTemplateIdSource	
			if (CanDeepLoad(entity, "DynamicPageWebPartTemplates|DynamicPageWebPartTemplateIdSource", deepLoadType, innerList) 
				&& entity.DynamicPageWebPartTemplateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DynamicPageWebPartTemplateId;
				DynamicPageWebPartTemplates tmpEntity = EntityManager.LocateEntity<DynamicPageWebPartTemplates>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPageWebPartTemplates), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DynamicPageWebPartTemplateIdSource = tmpEntity;
				else
					entity.DynamicPageWebPartTemplateIdSource = DataRepository.DynamicPageWebPartTemplatesProvider.GetByDynamicPageWebPartTemplateId(transactionManager, entity.DynamicPageWebPartTemplateId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DynamicPageWebPartTemplateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPageWebPartTemplatesProvider.DeepLoad(transactionManager, entity.DynamicPageWebPartTemplateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DynamicPageWebPartTemplateIdSource

			#region SiteWebPartIdSource	
			if (CanDeepLoad(entity, "SiteWebParts|SiteWebPartIdSource", deepLoadType, innerList) 
				&& entity.SiteWebPartIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SiteWebPartId;
				SiteWebParts tmpEntity = EntityManager.LocateEntity<SiteWebParts>(EntityLocator.ConstructKeyFromPkItems(typeof(SiteWebParts), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteWebPartIdSource = tmpEntity;
				else
					entity.SiteWebPartIdSource = DataRepository.SiteWebPartsProvider.GetBySiteWebPartId(transactionManager, entity.SiteWebPartId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteWebPartIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SiteWebPartsProvider.DeepLoad(transactionManager, entity.SiteWebPartIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteWebPartIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicPageWebPartTemplatesLink object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicPageWebPartTemplatesLink instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageWebPartTemplatesLink Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesLink entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DynamicPageWebPartTemplateIdSource
			if (CanDeepSave(entity, "DynamicPageWebPartTemplates|DynamicPageWebPartTemplateIdSource", deepSaveType, innerList) 
				&& entity.DynamicPageWebPartTemplateIdSource != null)
			{
				DataRepository.DynamicPageWebPartTemplatesProvider.Save(transactionManager, entity.DynamicPageWebPartTemplateIdSource);
				entity.DynamicPageWebPartTemplateId = entity.DynamicPageWebPartTemplateIdSource.DynamicPageWebPartTemplateId;
			}
			#endregion 
			
			#region SiteWebPartIdSource
			if (CanDeepSave(entity, "SiteWebParts|SiteWebPartIdSource", deepSaveType, innerList) 
				&& entity.SiteWebPartIdSource != null)
			{
				DataRepository.SiteWebPartsProvider.Save(transactionManager, entity.SiteWebPartIdSource);
				entity.SiteWebPartId = entity.SiteWebPartIdSource.SiteWebPartId;
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
	
	#region DynamicPageWebPartTemplatesLinkChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicPageWebPartTemplatesLink</c>
	///</summary>
	public enum DynamicPageWebPartTemplatesLinkChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DynamicPageWebPartTemplates</c> at DynamicPageWebPartTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(DynamicPageWebPartTemplates))]
		DynamicPageWebPartTemplates,
			
		///<summary>
		/// Composite Property for <c>SiteWebParts</c> at SiteWebPartIdSource
		///</summary>
		[ChildEntityType(typeof(SiteWebParts))]
		SiteWebParts,
		}
	
	#endregion DynamicPageWebPartTemplatesLinkChildEntityTypes
	
	#region DynamicPageWebPartTemplatesLinkFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicPageWebPartTemplatesLinkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkFilterBuilder : SqlFilterBuilder<DynamicPageWebPartTemplatesLinkColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilterBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesLinkFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesLinkFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesLinkFilterBuilder
	
	#region DynamicPageWebPartTemplatesLinkParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicPageWebPartTemplatesLinkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkParameterBuilder : ParameterizedSqlFilterBuilder<DynamicPageWebPartTemplatesLinkColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkParameterBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesLinkParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesLinkParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesLinkParameterBuilder
	
	#region DynamicPageWebPartTemplatesLinkSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicPageWebPartTemplatesLinkColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicPageWebPartTemplatesLinkSortBuilder : SqlSortBuilder<DynamicPageWebPartTemplatesLinkColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkSqlSortBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicPageWebPartTemplatesLinkSortBuilder
	
} // end namespace
