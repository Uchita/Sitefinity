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
	/// This class is the base class for any <see cref="DynamicPageRevisionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicPageRevisionsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicPageRevisions, JXTPortal.Entities.DynamicPageRevisionsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageRevisionsKey key)
		{
			return Delete(transactionManager, key.DynamicPageRevisionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageRevisionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageRevisionId)
		{
			return Delete(null, _dynamicPageRevisionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageRevisionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageRevisionId);		
		
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
		public override JXTPortal.Entities.DynamicPageRevisions Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageRevisionsKey key, int start, int pageLength)
		{
			return GetByDynamicPageRevisionId(transactionManager, key.DynamicPageRevisionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(System.Int32 _dynamicPageRevisionId)
		{
			int count = -1;
			return GetByDynamicPageRevisionId(null,_dynamicPageRevisionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(System.Int32 _dynamicPageRevisionId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageRevisionId(null, _dynamicPageRevisionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(TransactionManager transactionManager, System.Int32 _dynamicPageRevisionId)
		{
			int count = -1;
			return GetByDynamicPageRevisionId(transactionManager, _dynamicPageRevisionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(TransactionManager transactionManager, System.Int32 _dynamicPageRevisionId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageRevisionId(transactionManager, _dynamicPageRevisionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(System.Int32 _dynamicPageRevisionId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageRevisionId(null, _dynamicPageRevisionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DynamicPageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageRevisionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPageRevisions GetByDynamicPageRevisionId(TransactionManager transactionManager, System.Int32 _dynamicPageRevisionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicPageRevisions_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
			/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog, ref System.Int32? dynamicPageRevisionId)
		{
			 Insert(null, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog, ref dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
			/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog, ref System.Int32? dynamicPageRevisionId)
		{
			 Insert(null, start, pageLength , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog, ref dynamicPageRevisionId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
			/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog, ref System.Int32? dynamicPageRevisionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog, ref dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
			/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog, ref System.Int32? dynamicPageRevisionId);
		
		#endregion
		
		#region DynamicPageRevisions_CustomGetBySiteIDMappingID 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDMappingID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageRevisions&gt;"/> instance.</returns>
		public TList<DynamicPageRevisions> CustomGetBySiteIDMappingID(System.Int32? siteId, System.Guid? mappingId)
		{
			return CustomGetBySiteIDMappingID(null, 0, int.MaxValue , siteId, mappingId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDMappingID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageRevisions&gt;"/> instance.</returns>
		public TList<DynamicPageRevisions> CustomGetBySiteIDMappingID(int start, int pageLength, System.Int32? siteId, System.Guid? mappingId)
		{
			return CustomGetBySiteIDMappingID(null, start, pageLength , siteId, mappingId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDMappingID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageRevisions&gt;"/> instance.</returns>
		public TList<DynamicPageRevisions> CustomGetBySiteIDMappingID(TransactionManager transactionManager, System.Int32? siteId, System.Guid? mappingId)
		{
			return CustomGetBySiteIDMappingID(transactionManager, 0, int.MaxValue , siteId, mappingId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDMappingID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageRevisions&gt;"/> instance.</returns>
		public abstract TList<DynamicPageRevisions> CustomGetBySiteIDMappingID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Guid? mappingId);
		
		#endregion
		
		#region DynamicPageRevisions_CustomSaveRevision 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomSaveRevision' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomSaveRevision(System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 CustomSaveRevision(null, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomSaveRevision' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomSaveRevision(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 CustomSaveRevision(null, start, pageLength , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomSaveRevision' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomSaveRevision(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 CustomSaveRevision(transactionManager, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomSaveRevision' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomSaveRevision(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog);
		
		#endregion
		
		#region DynamicPageRevisions_GetByDynamicPageId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(int start, int pageLength, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPageRevisions_GetByDynamicPageRevisionId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageRevisionId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageRevisionId(System.Int32? dynamicPageRevisionId)
		{
			return GetByDynamicPageRevisionId(null, 0, int.MaxValue , dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageRevisionId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageRevisionId(int start, int pageLength, System.Int32? dynamicPageRevisionId)
		{
			return GetByDynamicPageRevisionId(null, start, pageLength , dynamicPageRevisionId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageRevisionId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageRevisionId(TransactionManager transactionManager, System.Int32? dynamicPageRevisionId)
		{
			return GetByDynamicPageRevisionId(transactionManager, 0, int.MaxValue , dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetByDynamicPageRevisionId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageRevisionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageRevisionId);
		
		#endregion
		
		#region DynamicPageRevisions_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Get_List' stored procedure. 
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
		///	This method wrap the 'DynamicPageRevisions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicPageRevisions_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog);
		
		#endregion
		
		#region DynamicPageRevisions_CustomGetBySiteIDStatus 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDStatus' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDStatus(System.Int32? siteId, System.Int32? status)
		{
			return CustomGetBySiteIDStatus(null, 0, int.MaxValue , siteId, status);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDStatus' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDStatus(int start, int pageLength, System.Int32? siteId, System.Int32? status)
		{
			return CustomGetBySiteIDStatus(null, start, pageLength , siteId, status);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDStatus' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDStatus(TransactionManager transactionManager, System.Int32? siteId, System.Int32? status)
		{
			return CustomGetBySiteIDStatus(transactionManager, 0, int.MaxValue , siteId, status);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomGetBySiteIDStatus' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteIDStatus(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? status);
		
		#endregion
		
		#region DynamicPageRevisions_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPageRevisions_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPageRevisions_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPageRevisions_GetPaged' stored procedure. 
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
		
		#region DynamicPageRevisions_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 Update(null, 0, int.MaxValue , dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 Update(null, start, pageLength , dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageRevisionId, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, status, visible, publishOn, mappingId, comment, pageLog);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="comment"> A <c>System.String</c> instance.</param>
		/// <param name="pageLog"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageRevisionId, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.Int32? status, System.Boolean? visible, System.DateTime? publishOn, System.Guid? mappingId, System.String comment, System.String pageLog);
		
		#endregion
		
		#region DynamicPageRevisions_CustomRevertPage 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomRevertPage' stored procedure. 
		/// </summary>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomRevertPage(System.Guid? mappingId)
		{
			 CustomRevertPage(null, 0, int.MaxValue , mappingId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomRevertPage' stored procedure. 
		/// </summary>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomRevertPage(int start, int pageLength, System.Guid? mappingId)
		{
			 CustomRevertPage(null, start, pageLength , mappingId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomRevertPage' stored procedure. 
		/// </summary>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomRevertPage(TransactionManager transactionManager, System.Guid? mappingId)
		{
			 CustomRevertPage(transactionManager, 0, int.MaxValue , mappingId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_CustomRevertPage' stored procedure. 
		/// </summary>
		/// <param name="mappingId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomRevertPage(TransactionManager transactionManager, int start, int pageLength , System.Guid? mappingId);
		
		#endregion
		
		#region DynamicPageRevisions_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageRevisionId)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageRevisionId)
		{
			 Delete(null, start, pageLength , dynamicPageRevisionId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageRevisionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageRevisionId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageRevisions_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageRevisionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageRevisionId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicPageRevisions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicPageRevisions&gt;"/></returns>
		public static TList<DynamicPageRevisions> Fill(IDataReader reader, TList<DynamicPageRevisions> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicPageRevisions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicPageRevisions")
					.Append("|").Append((System.Int32)reader[((int)DynamicPageRevisionsColumn.DynamicPageRevisionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicPageRevisions>(
					key.ToString(), // EntityTrackingKey
					"DynamicPageRevisions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicPageRevisions();
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
					c.DynamicPageRevisionId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.DynamicPageRevisionId - 1)];
					c.DynamicPageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.DynamicPageId - 1)];
					c.SiteId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.LanguageId - 1)];
					c.ParentDynamicPageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.ParentDynamicPageId - 1)];
					c.PageName = (System.String)reader[((int)DynamicPageRevisionsColumn.PageName - 1)];
					c.PageTitle = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PageTitle - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.PageTitle - 1)];
					c.PageContent = (System.String)reader[((int)DynamicPageRevisionsColumn.PageContent - 1)];
					c.DynamicPageWebPartTemplateId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.DynamicPageWebPartTemplateId - 1)))?null:(System.Int32?)reader[((int)DynamicPageRevisionsColumn.DynamicPageWebPartTemplateId - 1)];
					c.HyperLink = (System.String)reader[((int)DynamicPageRevisionsColumn.HyperLink - 1)];
					c.Valid = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Valid - 1)];
					c.OpenInNewWindow = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OpenInNewWindow - 1)];
					c.Sequence = (System.Int32)reader[((int)DynamicPageRevisionsColumn.Sequence - 1)];
					c.FullScreen = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.FullScreen - 1)];
					c.OnTopNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnTopNav - 1)];
					c.OnLeftNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnLeftNav - 1)];
					c.OnBottomNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnBottomNav - 1)];
					c.OnSiteMap = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnSiteMap - 1)];
					c.Searchable = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Searchable - 1)];
					c.MetaKeywords = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaKeywords - 1)];
					c.MetaDescription = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaDescription - 1)];
					c.PageFriendlyName = (System.String)reader[((int)DynamicPageRevisionsColumn.PageFriendlyName - 1)];
					c.LastModified = (System.DateTime)reader[((int)DynamicPageRevisionsColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)DynamicPageRevisionsColumn.LastModifiedBy - 1)];
					c.SearchField = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.SearchField - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.SearchField - 1)];
					c.SourceId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPageRevisionsColumn.SourceId - 1)];
					c.Secured = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Secured - 1)];
					c.CustomUrl = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.CustomUrl - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.CustomUrl - 1)];
					c.MetaTitle = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaTitle - 1)];
					c.GenerateBreadcrumb = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.GenerateBreadcrumb - 1)];
					c.Status = (System.Int32)reader[((int)DynamicPageRevisionsColumn.Status - 1)];
					c.Visible = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Visible - 1)];
					c.PublishOn = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PublishOn - 1)))?null:(System.DateTime?)reader[((int)DynamicPageRevisionsColumn.PublishOn - 1)];
					c.MappingId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MappingId - 1)))?null:(System.Guid?)reader[((int)DynamicPageRevisionsColumn.MappingId - 1)];
					c.Comment = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.Comment - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.Comment - 1)];
					c.PageLog = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PageLog - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.PageLog - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageRevisions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicPageRevisions entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageRevisionId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.DynamicPageRevisionId - 1)];
			entity.DynamicPageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.DynamicPageId - 1)];
			entity.SiteId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.LanguageId - 1)];
			entity.ParentDynamicPageId = (System.Int32)reader[((int)DynamicPageRevisionsColumn.ParentDynamicPageId - 1)];
			entity.PageName = (System.String)reader[((int)DynamicPageRevisionsColumn.PageName - 1)];
			entity.PageTitle = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PageTitle - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.PageTitle - 1)];
			entity.PageContent = (System.String)reader[((int)DynamicPageRevisionsColumn.PageContent - 1)];
			entity.DynamicPageWebPartTemplateId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.DynamicPageWebPartTemplateId - 1)))?null:(System.Int32?)reader[((int)DynamicPageRevisionsColumn.DynamicPageWebPartTemplateId - 1)];
			entity.HyperLink = (System.String)reader[((int)DynamicPageRevisionsColumn.HyperLink - 1)];
			entity.Valid = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Valid - 1)];
			entity.OpenInNewWindow = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OpenInNewWindow - 1)];
			entity.Sequence = (System.Int32)reader[((int)DynamicPageRevisionsColumn.Sequence - 1)];
			entity.FullScreen = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.FullScreen - 1)];
			entity.OnTopNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnTopNav - 1)];
			entity.OnLeftNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnLeftNav - 1)];
			entity.OnBottomNav = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnBottomNav - 1)];
			entity.OnSiteMap = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.OnSiteMap - 1)];
			entity.Searchable = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Searchable - 1)];
			entity.MetaKeywords = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaKeywords - 1)];
			entity.MetaDescription = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaDescription - 1)];
			entity.PageFriendlyName = (System.String)reader[((int)DynamicPageRevisionsColumn.PageFriendlyName - 1)];
			entity.LastModified = (System.DateTime)reader[((int)DynamicPageRevisionsColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)DynamicPageRevisionsColumn.LastModifiedBy - 1)];
			entity.SearchField = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.SearchField - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.SearchField - 1)];
			entity.SourceId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPageRevisionsColumn.SourceId - 1)];
			entity.Secured = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Secured - 1)];
			entity.CustomUrl = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.CustomUrl - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.CustomUrl - 1)];
			entity.MetaTitle = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.MetaTitle - 1)];
			entity.GenerateBreadcrumb = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.GenerateBreadcrumb - 1)];
			entity.Status = (System.Int32)reader[((int)DynamicPageRevisionsColumn.Status - 1)];
			entity.Visible = (System.Boolean)reader[((int)DynamicPageRevisionsColumn.Visible - 1)];
			entity.PublishOn = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PublishOn - 1)))?null:(System.DateTime?)reader[((int)DynamicPageRevisionsColumn.PublishOn - 1)];
			entity.MappingId = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.MappingId - 1)))?null:(System.Guid?)reader[((int)DynamicPageRevisionsColumn.MappingId - 1)];
			entity.Comment = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.Comment - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.Comment - 1)];
			entity.PageLog = (reader.IsDBNull(((int)DynamicPageRevisionsColumn.PageLog - 1)))?null:(System.String)reader[((int)DynamicPageRevisionsColumn.PageLog - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageRevisions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageRevisions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicPageRevisions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageRevisionId = (System.Int32)dataRow["DynamicPageRevisionID"];
			entity.DynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.ParentDynamicPageId = (System.Int32)dataRow["ParentDynamicPageID"];
			entity.PageName = (System.String)dataRow["PageName"];
			entity.PageTitle = Convert.IsDBNull(dataRow["PageTitle"]) ? null : (System.String)dataRow["PageTitle"];
			entity.PageContent = (System.String)dataRow["PageContent"];
			entity.DynamicPageWebPartTemplateId = Convert.IsDBNull(dataRow["DynamicPageWebPartTemplateID"]) ? null : (System.Int32?)dataRow["DynamicPageWebPartTemplateID"];
			entity.HyperLink = (System.String)dataRow["HyperLink"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.OpenInNewWindow = (System.Boolean)dataRow["OpenInNewWindow"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.FullScreen = (System.Boolean)dataRow["FullScreen"];
			entity.OnTopNav = (System.Boolean)dataRow["OnTopNav"];
			entity.OnLeftNav = (System.Boolean)dataRow["OnLeftNav"];
			entity.OnBottomNav = (System.Boolean)dataRow["OnBottomNav"];
			entity.OnSiteMap = (System.Boolean)dataRow["OnSiteMap"];
			entity.Searchable = (System.Boolean)dataRow["Searchable"];
			entity.MetaKeywords = Convert.IsDBNull(dataRow["MetaKeywords"]) ? null : (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = Convert.IsDBNull(dataRow["MetaDescription"]) ? null : (System.String)dataRow["MetaDescription"];
			entity.PageFriendlyName = (System.String)dataRow["PageFriendlyName"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.SourceId = Convert.IsDBNull(dataRow["SourceID"]) ? null : (System.Int32?)dataRow["SourceID"];
			entity.Secured = (System.Boolean)dataRow["Secured"];
			entity.CustomUrl = Convert.IsDBNull(dataRow["CustomUrl"]) ? null : (System.String)dataRow["CustomUrl"];
			entity.MetaTitle = Convert.IsDBNull(dataRow["MetaTitle"]) ? null : (System.String)dataRow["MetaTitle"];
			entity.GenerateBreadcrumb = (System.Boolean)dataRow["GenerateBreadcrumb"];
			entity.Status = (System.Int32)dataRow["Status"];
			entity.Visible = (System.Boolean)dataRow["Visible"];
			entity.PublishOn = Convert.IsDBNull(dataRow["PublishOn"]) ? null : (System.DateTime?)dataRow["PublishOn"];
			entity.MappingId = Convert.IsDBNull(dataRow["MappingID"]) ? null : (System.Guid?)dataRow["MappingID"];
			entity.Comment = Convert.IsDBNull(dataRow["Comment"]) ? null : (System.String)dataRow["Comment"];
			entity.PageLog = Convert.IsDBNull(dataRow["PageLog"]) ? null : (System.String)dataRow["PageLog"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageRevisions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageRevisions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageRevisions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicPageRevisions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicPageRevisions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageRevisions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageRevisions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DynamicPageRevisionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicPageRevisions</c>
	///</summary>
	public enum DynamicPageRevisionsChildEntityTypes
	{
	}
	
	#endregion DynamicPageRevisionsChildEntityTypes
	
	#region DynamicPageRevisionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicPageRevisionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageRevisions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageRevisionsFilterBuilder : SqlFilterBuilder<DynamicPageRevisionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilterBuilder class.
		/// </summary>
		public DynamicPageRevisionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageRevisionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageRevisionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageRevisionsFilterBuilder
	
	#region DynamicPageRevisionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicPageRevisionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageRevisions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageRevisionsParameterBuilder : ParameterizedSqlFilterBuilder<DynamicPageRevisionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsParameterBuilder class.
		/// </summary>
		public DynamicPageRevisionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageRevisionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageRevisionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageRevisionsParameterBuilder
	
	#region DynamicPageRevisionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicPageRevisionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageRevisions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicPageRevisionsSortBuilder : SqlSortBuilder<DynamicPageRevisionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsSqlSortBuilder class.
		/// </summary>
		public DynamicPageRevisionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicPageRevisionsSortBuilder
	
} // end namespace
