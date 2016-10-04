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
	/// This class is the base class for any <see cref="DynamicPageWebPartTemplatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicPageWebPartTemplatesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicPageWebPartTemplates, JXTPortal.Entities.DynamicPageWebPartTemplatesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesKey key)
		{
			return Delete(transactionManager, key.DynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageWebPartTemplateId)
		{
			return Delete(null, _dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		FK__DynamicPa__LastM__6B24EA82 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		FK__DynamicPa__LastM__6B24EA82 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		FK__DynamicPa__LastM__6B24EA82 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		fkDynamicPaLastm6b24Ea82 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		fkDynamicPaLastm6b24Ea82 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__6B24EA82 key.
		///		FK__DynamicPa__LastM__6B24EA82 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		FK__DynamicPa__SiteI__0E8E2250 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		FK__DynamicPa__SiteI__0E8E2250 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		FK__DynamicPa__SiteI__0E8E2250 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		fkDynamicPaSitei0e8e2250 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		fkDynamicPaSitei0e8e2250 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0E8E2250 key.
		///		FK__DynamicPa__SiteI__0E8E2250 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageWebPartTemplates objects.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicPageWebPartTemplates Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplatesKey key, int start, int pageLength)
		{
			return GetByDynamicPageWebPartTemplateId(transactionManager, key.DynamicPageWebPartTemplateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(null,_dynamicPageWebPartTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageWebPa__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPageWebPartTemplates GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32 _dynamicPageWebPartTemplateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicPageWebPartTemplates_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? dynamicPageWebPartTemplateId)
		{
			 Insert(null, 0, int.MaxValue , dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId, ref dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? dynamicPageWebPartTemplateId)
		{
			 Insert(null, start, pageLength , dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId, ref dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? dynamicPageWebPartTemplateId)
		{
			 Insert(transactionManager, 0, int.MaxValue , dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId, ref dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicPageWebPartTemplates_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByDynamicPageWebPartTemplateId(System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(null, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByDynamicPageWebPartTemplateId(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageWebPartTemplateId, dynamicPageWebPartName, siteId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageWebPartTemplateId, System.String dynamicPageWebPartName, System.Int32? siteId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageWebPartTemplateId)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			 Delete(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPageWebPartTemplates_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageWebPartTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/> instance.</returns>
		public abstract TList<DynamicPageWebPartTemplates> GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicPageWebPartTemplates&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicPageWebPartTemplates&gt;"/></returns>
		public static TList<DynamicPageWebPartTemplates> Fill(IDataReader reader, TList<DynamicPageWebPartTemplates> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicPageWebPartTemplates c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicPageWebPartTemplates")
					.Append("|").Append((System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.DynamicPageWebPartTemplateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicPageWebPartTemplates>(
					key.ToString(), // EntityTrackingKey
					"DynamicPageWebPartTemplates",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicPageWebPartTemplates();
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
					c.DynamicPageWebPartTemplateId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.DynamicPageWebPartTemplateId - 1)];
					c.DynamicPageWebPartName = (System.String)reader[((int)DynamicPageWebPartTemplatesColumn.DynamicPageWebPartName - 1)];
					c.SiteId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.SiteId - 1)];
					c.LastModified = (System.DateTime)reader[((int)DynamicPageWebPartTemplatesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.LastModifiedBy - 1)];
					c.SourceId = (reader.IsDBNull(((int)DynamicPageWebPartTemplatesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPageWebPartTemplatesColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicPageWebPartTemplates entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageWebPartTemplateId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.DynamicPageWebPartTemplateId - 1)];
			entity.DynamicPageWebPartName = (System.String)reader[((int)DynamicPageWebPartTemplatesColumn.DynamicPageWebPartName - 1)];
			entity.SiteId = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.SiteId - 1)];
			entity.LastModified = (System.DateTime)reader[((int)DynamicPageWebPartTemplatesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)DynamicPageWebPartTemplatesColumn.LastModifiedBy - 1)];
			entity.SourceId = (reader.IsDBNull(((int)DynamicPageWebPartTemplatesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPageWebPartTemplatesColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicPageWebPartTemplates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageWebPartTemplateId = (System.Int32)dataRow["DynamicPageWebPartTemplateID"];
			entity.DynamicPageWebPartName = (System.String)dataRow["DynamicPageWebPartName"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.SourceId = Convert.IsDBNull(dataRow["SourceID"]) ? null : (System.Int32?)dataRow["SourceID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageWebPartTemplates"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageWebPartTemplates Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplates entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LastModifiedBy;
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, entity.LastModifiedBy);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedBySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedBySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.LastModifiedBySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedBySource

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
			// Deep load child collections  - Call GetByDynamicPageWebPartTemplateId methods when available
			
			#region DynamicPageWebPartTemplatesLinkCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageWebPartTemplatesLink>|DynamicPageWebPartTemplatesLinkCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplatesLinkCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageWebPartTemplatesLinkCollection = DataRepository.DynamicPageWebPartTemplatesLinkProvider.GetByDynamicPageWebPartTemplateId(transactionManager, entity.DynamicPageWebPartTemplateId);

				if (deep && entity.DynamicPageWebPartTemplatesLinkCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageWebPartTemplatesLinkCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageWebPartTemplatesLink>) DataRepository.DynamicPageWebPartTemplatesLinkProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPagesCollection = DataRepository.DynamicPagesProvider.GetByDynamicPageWebPartTemplateId(transactionManager, entity.DynamicPageWebPartTemplateId);

				if (deep && entity.DynamicPagesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPagesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicPageWebPartTemplates object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicPageWebPartTemplates instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageWebPartTemplates Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageWebPartTemplates entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
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
	
			#region List<DynamicPageWebPartTemplatesLink>
				if (CanDeepSave(entity.DynamicPageWebPartTemplatesLinkCollection, "List<DynamicPageWebPartTemplatesLink>|DynamicPageWebPartTemplatesLinkCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageWebPartTemplatesLink child in entity.DynamicPageWebPartTemplatesLinkCollection)
					{
						if(child.DynamicPageWebPartTemplateIdSource != null)
						{
							child.DynamicPageWebPartTemplateId = child.DynamicPageWebPartTemplateIdSource.DynamicPageWebPartTemplateId;
						}
						else
						{
							child.DynamicPageWebPartTemplateId = entity.DynamicPageWebPartTemplateId;
						}

					}

					if (entity.DynamicPageWebPartTemplatesLinkCollection.Count > 0 || entity.DynamicPageWebPartTemplatesLinkCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageWebPartTemplatesLinkProvider.Save(transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection);
						
						deepHandles.Add("DynamicPageWebPartTemplatesLinkCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageWebPartTemplatesLink >) DataRepository.DynamicPageWebPartTemplatesLinkProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPages>
				if (CanDeepSave(entity.DynamicPagesCollection, "List<DynamicPages>|DynamicPagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPages child in entity.DynamicPagesCollection)
					{
						if(child.DynamicPageWebPartTemplateIdSource != null)
						{
							child.DynamicPageWebPartTemplateId = child.DynamicPageWebPartTemplateIdSource.DynamicPageWebPartTemplateId;
						}
						else
						{
							child.DynamicPageWebPartTemplateId = entity.DynamicPageWebPartTemplateId;
						}

					}

					if (entity.DynamicPagesCollection.Count > 0 || entity.DynamicPagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPagesCollection);
						
						deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPagesCollection, deepSaveType, childTypes, innerList }
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
	
	#region DynamicPageWebPartTemplatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicPageWebPartTemplates</c>
	///</summary>
	public enum DynamicPageWebPartTemplatesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>DynamicPageWebPartTemplates</c> as OneToMany for DynamicPageWebPartTemplatesLinkCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageWebPartTemplatesLink>))]
		DynamicPageWebPartTemplatesLinkCollection,

		///<summary>
		/// Collection of <c>DynamicPageWebPartTemplates</c> as OneToMany for DynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		DynamicPagesCollection,
	}
	
	#endregion DynamicPageWebPartTemplatesChildEntityTypes
	
	#region DynamicPageWebPartTemplatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicPageWebPartTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesFilterBuilder : SqlFilterBuilder<DynamicPageWebPartTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilterBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesFilterBuilder
	
	#region DynamicPageWebPartTemplatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicPageWebPartTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesParameterBuilder : ParameterizedSqlFilterBuilder<DynamicPageWebPartTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesParameterBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesParameterBuilder
	
	#region DynamicPageWebPartTemplatesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicPageWebPartTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicPageWebPartTemplatesSortBuilder : SqlSortBuilder<DynamicPageWebPartTemplatesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesSqlSortBuilder class.
		/// </summary>
		public DynamicPageWebPartTemplatesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicPageWebPartTemplatesSortBuilder
	
} // end namespace
