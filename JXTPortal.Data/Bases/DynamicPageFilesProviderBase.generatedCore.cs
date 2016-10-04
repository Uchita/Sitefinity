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
	/// This class is the base class for any <see cref="DynamicPageFilesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicPageFilesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicPageFiles, JXTPortal.Entities.DynamicPageFilesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageFilesKey key)
		{
			return Delete(transactionManager, key.DynamicPageFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageFileId)
		{
			return Delete(null, _dynamicPageFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageFileId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		FK__DynamicPa__FileI__0B679CE2 Description: 
		/// </summary>
		/// <param name="_fileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetByFileId(System.Int32 _fileId)
		{
			int count = -1;
			return GetByFileId(_fileId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		FK__DynamicPa__FileI__0B679CE2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageFiles> GetByFileId(TransactionManager transactionManager, System.Int32 _fileId)
		{
			int count = -1;
			return GetByFileId(transactionManager, _fileId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		FK__DynamicPa__FileI__0B679CE2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetByFileId(TransactionManager transactionManager, System.Int32 _fileId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileId(transactionManager, _fileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		fkDynamicPaFilei0b679Ce2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetByFileId(System.Int32 _fileId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFileId(null, _fileId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		fkDynamicPaFilei0b679Ce2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fileId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetByFileId(System.Int32 _fileId, int start, int pageLength,out int count)
		{
			return GetByFileId(null, _fileId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__FileI__0B679CE2 key.
		///		FK__DynamicPa__FileI__0B679CE2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public abstract TList<DynamicPageFiles> GetByFileId(TransactionManager transactionManager, System.Int32 _fileId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		FK__DynamicPa__SiteI__0A7378A9 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		FK__DynamicPa__SiteI__0A7378A9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPageFiles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		FK__DynamicPa__SiteI__0A7378A9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		fkDynamicPaSitei0a7378a9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		fkDynamicPaSitei0a7378a9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public TList<DynamicPageFiles> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__SiteI__0A7378A9 key.
		///		FK__DynamicPa__SiteI__0A7378A9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPageFiles objects.</returns>
		public abstract TList<DynamicPageFiles> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicPageFiles Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageFilesKey key, int start, int pageLength)
		{
			return GetByDynamicPageFileId(transactionManager, key.DynamicPageFileId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(System.Int32 _siteId, System.String _pageName, System.Int32 _fileId)
		{
			int count = -1;
			return GetBySiteIdPageNameFileId(null,_siteId, _pageName, _fileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(System.Int32 _siteId, System.String _pageName, System.Int32 _fileId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPageNameFileId(null, _siteId, _pageName, _fileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _fileId)
		{
			int count = -1;
			return GetBySiteIdPageNameFileId(transactionManager, _siteId, _pageName, _fileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _fileId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPageNameFileId(transactionManager, _siteId, _pageName, _fileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(System.Int32 _siteId, System.String _pageName, System.Int32 _fileId, int start, int pageLength, out int count)
		{
			return GetBySiteIdPageNameFileId(null, _siteId, _pageName, _fileId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_DynamicPageFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;DynamicPageFiles&gt;"/> class.</returns>
		public abstract TList<DynamicPageFiles> GetBySiteIdPageNameFileId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _fileId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="_dynamicPageFileId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(System.Int32 _dynamicPageFileId)
		{
			int count = -1;
			return GetByDynamicPageFileId(null,_dynamicPageFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="_dynamicPageFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(System.Int32 _dynamicPageFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageFileId(null, _dynamicPageFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageFileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(TransactionManager transactionManager, System.Int32 _dynamicPageFileId)
		{
			int count = -1;
			return GetByDynamicPageFileId(transactionManager, _dynamicPageFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(TransactionManager transactionManager, System.Int32 _dynamicPageFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageFileId(transactionManager, _dynamicPageFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="_dynamicPageFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(System.Int32 _dynamicPageFileId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageFileId(null, _dynamicPageFileId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPageFiles__07970BFE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPageFiles"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPageFiles GetByDynamicPageFileId(TransactionManager transactionManager, System.Int32 _dynamicPageFileId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicPageFiles_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String pageName, System.Int32? fileId, ref System.Int32? dynamicPageFileId)
		{
			 Insert(null, 0, int.MaxValue , siteId, pageName, fileId, ref dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? fileId, ref System.Int32? dynamicPageFileId)
		{
			 Insert(null, start, pageLength , siteId, pageName, fileId, ref dynamicPageFileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? fileId, ref System.Int32? dynamicPageFileId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, pageName, fileId, ref dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? fileId, ref System.Int32? dynamicPageFileId);
		
		#endregion
		
		#region DynamicPageFiles_DeleteBySiteIDPageName 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_DeleteBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySiteIDPageName(System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			 DeleteBySiteIDPageName(null, 0, int.MaxValue , siteId, pageName, fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_DeleteBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySiteIDPageName(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			 DeleteBySiteIDPageName(null, start, pageLength , siteId, pageName, fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_DeleteBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void DeleteBySiteIDPageName(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			 DeleteBySiteIDPageName(transactionManager, 0, int.MaxValue , siteId, pageName, fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_DeleteBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void DeleteBySiteIDPageName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? fileTypeId);
		
		#endregion
		
		#region DynamicPageFiles_GetByFileId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByFileId(System.Int32? fileId)
		{
			return GetByFileId(null, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByFileId(int start, int pageLength, System.Int32? fileId)
		{
			return GetByFileId(null, start, pageLength , fileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByFileId(TransactionManager transactionManager, System.Int32? fileId)
		{
			return GetByFileId(transactionManager, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> GetByFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileId);
		
		#endregion
		
		#region DynamicPageFiles_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region DynamicPageFiles_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicPageFiles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region DynamicPageFiles_GetByDynamicPageFileId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByDynamicPageFileId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByDynamicPageFileId(System.Int32? dynamicPageFileId)
		{
			return GetByDynamicPageFileId(null, 0, int.MaxValue , dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByDynamicPageFileId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByDynamicPageFileId(int start, int pageLength, System.Int32? dynamicPageFileId)
		{
			return GetByDynamicPageFileId(null, start, pageLength , dynamicPageFileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByDynamicPageFileId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetByDynamicPageFileId(TransactionManager transactionManager, System.Int32? dynamicPageFileId)
		{
			return GetByDynamicPageFileId(transactionManager, 0, int.MaxValue , dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetByDynamicPageFileId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> GetByDynamicPageFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageFileId);
		
		#endregion
		
		#region DynamicPageFiles_GetBySiteIdPageNameFileId 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteIdPageNameFileId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return GetBySiteIdPageNameFileId(null, 0, int.MaxValue , siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteIdPageNameFileId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return GetBySiteIdPageNameFileId(null, start, pageLength , siteId, pageName, fileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteIdPageNameFileId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> GetBySiteIdPageNameFileId(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return GetBySiteIdPageNameFileId(transactionManager, 0, int.MaxValue , siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_GetBySiteIdPageNameFileId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> GetBySiteIdPageNameFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? fileId);
		
		#endregion
		
		#region DynamicPageFiles_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageFileId, siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageFileId, siteId, pageName, fileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public TList<DynamicPageFiles> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageFileId, siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPageFiles&gt;"/> instance.</returns>
		public abstract TList<DynamicPageFiles> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId);
		
		#endregion
		
		#region DynamicPageFiles_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageFileId)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageFileId)
		{
			 Delete(null, start, pageLength , dynamicPageFileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageFileId)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageFileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageFileId);
		
		#endregion
		
		#region DynamicPageFiles_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			 Update(null, 0, int.MaxValue , dynamicPageFileId, siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			 Update(null, start, pageLength , dynamicPageFileId, siteId, pageName, fileId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageFileId, siteId, pageName, fileId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPageFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageFileId, System.Int32? siteId, System.String pageName, System.Int32? fileId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicPageFiles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicPageFiles&gt;"/></returns>
		public static TList<DynamicPageFiles> Fill(IDataReader reader, TList<DynamicPageFiles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicPageFiles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicPageFiles")
					.Append("|").Append((System.Int32)reader[((int)DynamicPageFilesColumn.DynamicPageFileId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicPageFiles>(
					key.ToString(), // EntityTrackingKey
					"DynamicPageFiles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicPageFiles();
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
					c.DynamicPageFileId = (System.Int32)reader[((int)DynamicPageFilesColumn.DynamicPageFileId - 1)];
					c.SiteId = (System.Int32)reader[((int)DynamicPageFilesColumn.SiteId - 1)];
					c.PageName = (System.String)reader[((int)DynamicPageFilesColumn.PageName - 1)];
					c.FileId = (System.Int32)reader[((int)DynamicPageFilesColumn.FileId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageFiles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageFiles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicPageFiles entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageFileId = (System.Int32)reader[((int)DynamicPageFilesColumn.DynamicPageFileId - 1)];
			entity.SiteId = (System.Int32)reader[((int)DynamicPageFilesColumn.SiteId - 1)];
			entity.PageName = (System.String)reader[((int)DynamicPageFilesColumn.PageName - 1)];
			entity.FileId = (System.Int32)reader[((int)DynamicPageFilesColumn.FileId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPageFiles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageFiles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicPageFiles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageFileId = (System.Int32)dataRow["DynamicPageFileID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.PageName = (System.String)dataRow["PageName"];
			entity.FileId = (System.Int32)dataRow["FileID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPageFiles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageFiles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageFiles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FileIdSource	
			if (CanDeepLoad(entity, "Files|FileIdSource", deepLoadType, innerList) 
				&& entity.FileIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FileId;
				Files tmpEntity = EntityManager.LocateEntity<Files>(EntityLocator.ConstructKeyFromPkItems(typeof(Files), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FileIdSource = tmpEntity;
				else
					entity.FileIdSource = DataRepository.FilesProvider.GetByFileId(transactionManager, entity.FileId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FileIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FileIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FilesProvider.DeepLoad(transactionManager, entity.FileIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FileIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicPageFiles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicPageFiles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPageFiles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicPageFiles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FileIdSource
			if (CanDeepSave(entity, "Files|FileIdSource", deepSaveType, innerList) 
				&& entity.FileIdSource != null)
			{
				DataRepository.FilesProvider.Save(transactionManager, entity.FileIdSource);
				entity.FileId = entity.FileIdSource.FileId;
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
	
	#region DynamicPageFilesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicPageFiles</c>
	///</summary>
	public enum DynamicPageFilesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Files</c> at FileIdSource
		///</summary>
		[ChildEntityType(typeof(Files))]
		Files,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion DynamicPageFilesChildEntityTypes
	
	#region DynamicPageFilesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicPageFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesFilterBuilder : SqlFilterBuilder<DynamicPageFilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilterBuilder class.
		/// </summary>
		public DynamicPageFilesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageFilesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageFilesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageFilesFilterBuilder
	
	#region DynamicPageFilesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicPageFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesParameterBuilder : ParameterizedSqlFilterBuilder<DynamicPageFilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesParameterBuilder class.
		/// </summary>
		public DynamicPageFilesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageFilesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageFilesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageFilesParameterBuilder
	
	#region DynamicPageFilesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicPageFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicPageFilesSortBuilder : SqlSortBuilder<DynamicPageFilesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesSqlSortBuilder class.
		/// </summary>
		public DynamicPageFilesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicPageFilesSortBuilder
	
} // end namespace
