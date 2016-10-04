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
	/// This class is the base class for any <see cref="SiteResourcesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteResourcesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteResources, JXTPortal.Entities.SiteResourcesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesKey key)
		{
			return Delete(transactionManager, key.SiteResourceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteResourceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteResourceId)
		{
			return Delete(null, _siteResourceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteResourceId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		FK__SiteResou__Langu__60083D91 Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		FK__SiteResou__Langu__60083D91 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResources> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		FK__SiteResou__Langu__60083D91 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		fkSiteResouLangu60083d91 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		fkSiteResouLangu60083d91 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLanguageId(System.Int32 _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Langu__60083D91 key.
		///		FK__SiteResou__Langu__60083D91 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public abstract TList<SiteResources> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		FK__SiteResou__LastM__7FA0E47B Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		FK__SiteResou__LastM__7FA0E47B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		FK__SiteResou__LastM__7FA0E47B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		fkSiteResouLastm7Fa0e47b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		fkSiteResouLastm7Fa0e47b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__LastM__7FA0E47B key.
		///		FK__SiteResou__LastM__7FA0E47B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public abstract TList<SiteResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		FK__SiteResou__Resou__60FC61CA Description: 
		/// </summary>
		/// <param name="_resourceCode"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceCode(System.String _resourceCode)
		{
			int count = -1;
			return GetByResourceCode(_resourceCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		FK__SiteResou__Resou__60FC61CA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResources> GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode)
		{
			int count = -1;
			return GetByResourceCode(transactionManager, _resourceCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		FK__SiteResou__Resou__60FC61CA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceCode(transactionManager, _resourceCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		fkSiteResouResou60Fc61Ca Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceCode(System.String _resourceCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByResourceCode(null, _resourceCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		fkSiteResouResou60Fc61Ca Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceCode(System.String _resourceCode, int start, int pageLength,out int count)
		{
			return GetByResourceCode(null, _resourceCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__60FC61CA key.
		///		FK__SiteResou__Resou__60FC61CA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public abstract TList<SiteResources> GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		FK__SiteResou__Resou__61F08603 Description: 
		/// </summary>
		/// <param name="_resourceFileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceFileId(System.Int32? _resourceFileId)
		{
			int count = -1;
			return GetByResourceFileId(_resourceFileId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		FK__SiteResou__Resou__61F08603 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId)
		{
			int count = -1;
			return GetByResourceFileId(transactionManager, _resourceFileId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		FK__SiteResou__Resou__61F08603 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceFileId(transactionManager, _resourceFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		fkSiteResouResou61f08603 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceFileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceFileId(System.Int32? _resourceFileId, int start, int pageLength)
		{
			int count =  -1;
			return GetByResourceFileId(null, _resourceFileId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		fkSiteResouResou61f08603 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetByResourceFileId(System.Int32? _resourceFileId, int start, int pageLength,out int count)
		{
			return GetByResourceFileId(null, _resourceFileId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__Resou__61F08603 key.
		///		FK__SiteResou__Resou__61F08603 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public abstract TList<SiteResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		FK__SiteResou__SiteI__116A8EFB Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		FK__SiteResou__SiteI__116A8EFB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResources> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		FK__SiteResou__SiteI__116A8EFB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		fkSiteResouSitei116a8Efb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		fkSiteResouSitei116a8Efb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public TList<SiteResources> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__116A8EFB key.
		///		FK__SiteResou__SiteI__116A8EFB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResources objects.</returns>
		public abstract TList<SiteResources> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteResources Get(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesKey key, int start, int pageLength)
		{
			return GetBySiteResourceId(transactionManager, key.SiteResourceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_SiteResources index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode)
		{
			int count = -1;
			return GetBySiteIdLanguageIdResourceCode(null,_siteId, _languageId, _resourceCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteResources index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageIdResourceCode(null, _siteId, _languageId, _resourceCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteResources index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode)
		{
			int count = -1;
			return GetBySiteIdLanguageIdResourceCode(transactionManager, _siteId, _languageId, _resourceCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteResources index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageIdResourceCode(transactionManager, _siteId, _languageId, _resourceCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteResources index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode, int start, int pageLength, out int count)
		{
			return GetBySiteIdLanguageIdResourceCode(null, _siteId, _languageId, _resourceCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteResources index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public abstract JXTPortal.Entities.SiteResources GetBySiteIdLanguageIdResourceCode(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _resourceCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="_siteResourceId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteResourceId(System.Int32 _siteResourceId)
		{
			int count = -1;
			return GetBySiteResourceId(null,_siteResourceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="_siteResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteResourceId(System.Int32 _siteResourceId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteResourceId(null, _siteResourceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteResourceId(TransactionManager transactionManager, System.Int32 _siteResourceId)
		{
			int count = -1;
			return GetBySiteResourceId(transactionManager, _siteResourceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteResourceId(TransactionManager transactionManager, System.Int32 _siteResourceId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteResourceId(transactionManager, _siteResourceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="_siteResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public JXTPortal.Entities.SiteResources GetBySiteResourceId(System.Int32 _siteResourceId, int start, int pageLength, out int count)
		{
			return GetBySiteResourceId(null, _siteResourceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteResources__54968AE5 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResources"/> class.</returns>
		public abstract JXTPortal.Entities.SiteResources GetBySiteResourceId(TransactionManager transactionManager, System.Int32 _siteResourceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteResources_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? siteResourceId)
		{
			 Insert(null, 0, int.MaxValue , siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy, ref siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? siteResourceId)
		{
			 Insert(null, start, pageLength , siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy, ref siteResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? siteResourceId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy, ref siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? siteResourceId);
		
		#endregion
		
		#region SiteResources_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteResourceId)
		{
			 Delete(null, 0, int.MaxValue , siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteResourceId)
		{
			 Delete(null, start, pageLength , siteResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteResourceId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteResourceId);
		
		#endregion
		
		#region SiteResources_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteResources_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteResources_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteResources_GetByResourceCode 
		
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByResourceCode' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByResourceCode(int start, int pageLength, System.String resourceCode)
		{
			return GetByResourceCode(null, start, pageLength , resourceCode);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetByResourceCode' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetByResourceCode(TransactionManager transactionManager, int start, int pageLength , System.String resourceCode);
		
		#endregion
		
		#region SiteResources_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteResources_GetBySiteIdLanguageIdResourceCode 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteIdLanguageIdResourceCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteIdLanguageIdResourceCode(System.Int32? siteId, System.Int32? languageId, System.String resourceCode)
		{
			return GetBySiteIdLanguageIdResourceCode(null, 0, int.MaxValue , siteId, languageId, resourceCode);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteIdLanguageIdResourceCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteIdLanguageIdResourceCode(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String resourceCode)
		{
			return GetBySiteIdLanguageIdResourceCode(null, start, pageLength , siteId, languageId, resourceCode);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteIdLanguageIdResourceCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteIdLanguageIdResourceCode(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String resourceCode)
		{
			return GetBySiteIdLanguageIdResourceCode(transactionManager, 0, int.MaxValue , siteId, languageId, resourceCode);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteIdLanguageIdResourceCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetBySiteIdLanguageIdResourceCode(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String resourceCode);
		
		#endregion
		
		#region SiteResources_Update 
		
		/// <summary>
		///	This method wrap the 'SiteResources_Update' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, 0, int.MaxValue , siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Update' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, start, pageLength , siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_Update' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(transactionManager, 0, int.MaxValue , siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Update' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region SiteResources_Find 
		
		/// <summary>
		///	This method wrap the 'SiteResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Find(System.Boolean? searchUsingOr, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, start, pageLength , searchUsingOr, siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteResourceId, siteId, languageId, resourceCode, resourceFileId, resourceText, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteResourceId, System.Int32? siteId, System.Int32? languageId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region SiteResources_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLanguageId(int start, int pageLength, System.Int32? languageId)
		{
			return GetByLanguageId(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLanguageId(TransactionManager transactionManager, System.Int32? languageId)
		{
			return GetByLanguageId(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region SiteResources_GetBySiteResourceId 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteResourceId' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteResourceId(System.Int32? siteResourceId)
		{
			return GetBySiteResourceId(null, 0, int.MaxValue , siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteResourceId' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteResourceId(int start, int pageLength, System.Int32? siteResourceId)
		{
			return GetBySiteResourceId(null, start, pageLength , siteResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteResourceId' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetBySiteResourceId(TransactionManager transactionManager, System.Int32? siteResourceId)
		{
			return GetBySiteResourceId(transactionManager, 0, int.MaxValue , siteResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetBySiteResourceId' stored procedure. 
		/// </summary>
		/// <param name="siteResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetBySiteResourceId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteResourceId);
		
		#endregion
		
		#region SiteResources_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region SiteResources_GetByResourceFileId 
		
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByResourceFileId' stored procedure. 
		/// </summary>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public TList<SiteResources> GetByResourceFileId(int start, int pageLength, System.Int32? resourceFileId)
		{
			return GetByResourceFileId(null, start, pageLength , resourceFileId);
		}
				
		
		
		/// <summary>
		///	This method wrap the 'SiteResources_GetByResourceFileId' stored procedure. 
		/// </summary>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteResources&gt;"/> instance.</returns>
		public abstract TList<SiteResources> GetByResourceFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? resourceFileId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteResources&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteResources&gt;"/></returns>
		public static TList<SiteResources> Fill(IDataReader reader, TList<SiteResources> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteResources c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteResources")
					.Append("|").Append((System.Int32)reader[((int)SiteResourcesColumn.SiteResourceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteResources>(
					key.ToString(), // EntityTrackingKey
					"SiteResources",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteResources();
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
					c.SiteResourceId = (System.Int32)reader[((int)SiteResourcesColumn.SiteResourceId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteResourcesColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)SiteResourcesColumn.LanguageId - 1)];
					c.ResourceCode = (System.String)reader[((int)SiteResourcesColumn.ResourceCode - 1)];
					c.ResourceFileId = (reader.IsDBNull(((int)SiteResourcesColumn.ResourceFileId - 1)))?null:(System.Int32?)reader[((int)SiteResourcesColumn.ResourceFileId - 1)];
					c.ResourceText = (reader.IsDBNull(((int)SiteResourcesColumn.ResourceText - 1)))?null:(System.String)reader[((int)SiteResourcesColumn.ResourceText - 1)];
					c.LastModified = (System.DateTime)reader[((int)SiteResourcesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)SiteResourcesColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteResources"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResources"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteResources entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteResourceId = (System.Int32)reader[((int)SiteResourcesColumn.SiteResourceId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteResourcesColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)SiteResourcesColumn.LanguageId - 1)];
			entity.ResourceCode = (System.String)reader[((int)SiteResourcesColumn.ResourceCode - 1)];
			entity.ResourceFileId = (reader.IsDBNull(((int)SiteResourcesColumn.ResourceFileId - 1)))?null:(System.Int32?)reader[((int)SiteResourcesColumn.ResourceFileId - 1)];
			entity.ResourceText = (reader.IsDBNull(((int)SiteResourcesColumn.ResourceText - 1)))?null:(System.String)reader[((int)SiteResourcesColumn.ResourceText - 1)];
			entity.LastModified = (System.DateTime)reader[((int)SiteResourcesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)SiteResourcesColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteResources"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResources"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteResources entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteResourceId = (System.Int32)dataRow["SiteResourceID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.ResourceCode = (System.String)dataRow["ResourceCode"];
			entity.ResourceFileId = Convert.IsDBNull(dataRow["ResourceFileID"]) ? null : (System.Int32?)dataRow["ResourceFileID"];
			entity.ResourceText = Convert.IsDBNull(dataRow["ResourceText"]) ? null : (System.String)dataRow["ResourceText"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResources"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteResources Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteResources entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Languages|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LanguageId;
				Languages tmpEntity = EntityManager.LocateEntity<Languages>(EntityLocator.ConstructKeyFromPkItems(typeof(Languages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguagesProvider.GetByLanguageId(transactionManager, entity.LanguageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguagesProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource

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

			#region ResourceCodeSource	
			if (CanDeepLoad(entity, "DefaultResources|ResourceCodeSource", deepLoadType, innerList) 
				&& entity.ResourceCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ResourceCode;
				DefaultResources tmpEntity = EntityManager.LocateEntity<DefaultResources>(EntityLocator.ConstructKeyFromPkItems(typeof(DefaultResources), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ResourceCodeSource = tmpEntity;
				else
					entity.ResourceCodeSource = DataRepository.DefaultResourcesProvider.GetByResourceCode(transactionManager, entity.ResourceCode);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResourceCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ResourceCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DefaultResourcesProvider.DeepLoad(transactionManager, entity.ResourceCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ResourceCodeSource

			#region ResourceFileIdSource	
			if (CanDeepLoad(entity, "Files|ResourceFileIdSource", deepLoadType, innerList) 
				&& entity.ResourceFileIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ResourceFileId ?? (int)0);
				Files tmpEntity = EntityManager.LocateEntity<Files>(EntityLocator.ConstructKeyFromPkItems(typeof(Files), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ResourceFileIdSource = tmpEntity;
				else
					entity.ResourceFileIdSource = DataRepository.FilesProvider.GetByFileId(transactionManager, (entity.ResourceFileId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResourceFileIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ResourceFileIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FilesProvider.DeepLoad(transactionManager, entity.ResourceFileIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ResourceFileIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteResources object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteResources instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteResources Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteResources entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Languages|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguagesProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.LanguageId;
			}
			#endregion 
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
			}
			#endregion 
			
			#region ResourceCodeSource
			if (CanDeepSave(entity, "DefaultResources|ResourceCodeSource", deepSaveType, innerList) 
				&& entity.ResourceCodeSource != null)
			{
				DataRepository.DefaultResourcesProvider.Save(transactionManager, entity.ResourceCodeSource);
				entity.ResourceCode = entity.ResourceCodeSource.ResourceCode;
			}
			#endregion 
			
			#region ResourceFileIdSource
			if (CanDeepSave(entity, "Files|ResourceFileIdSource", deepSaveType, innerList) 
				&& entity.ResourceFileIdSource != null)
			{
				DataRepository.FilesProvider.Save(transactionManager, entity.ResourceFileIdSource);
				entity.ResourceFileId = entity.ResourceFileIdSource.FileId;
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
	
	#region SiteResourcesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteResources</c>
	///</summary>
	public enum SiteResourcesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Languages</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>DefaultResources</c> at ResourceCodeSource
		///</summary>
		[ChildEntityType(typeof(DefaultResources))]
		DefaultResources,
			
		///<summary>
		/// Composite Property for <c>Files</c> at ResourceFileIdSource
		///</summary>
		[ChildEntityType(typeof(Files))]
		Files,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteResourcesChildEntityTypes
	
	#region SiteResourcesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesFilterBuilder : SqlFilterBuilder<SiteResourcesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilterBuilder class.
		/// </summary>
		public SiteResourcesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesFilterBuilder
	
	#region SiteResourcesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesParameterBuilder : ParameterizedSqlFilterBuilder<SiteResourcesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesParameterBuilder class.
		/// </summary>
		public SiteResourcesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesParameterBuilder
	
	#region SiteResourcesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteResourcesSortBuilder : SqlSortBuilder<SiteResourcesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesSqlSortBuilder class.
		/// </summary>
		public SiteResourcesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteResourcesSortBuilder
	
} // end namespace
