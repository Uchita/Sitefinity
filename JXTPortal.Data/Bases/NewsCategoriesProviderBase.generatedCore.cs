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
	/// This class is the base class for any <see cref="NewsCategoriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NewsCategoriesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.NewsCategories, JXTPortal.Entities.NewsCategoriesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.NewsCategoriesKey key)
		{
			return Delete(transactionManager, key.NewsCategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_newsCategoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _newsCategoryId)
		{
			return Delete(null, _newsCategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _newsCategoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		FK__NewsCateg__LastM__7EACC042 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		FK__NewsCateg__LastM__7EACC042 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		/// <remarks></remarks>
		public TList<NewsCategories> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		FK__NewsCateg__LastM__7EACC042 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		fkNewsCategLastm7Eacc042 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		fkNewsCategLastm7Eacc042 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__LastM__7EACC042 key.
		///		FK__NewsCateg__LastM__7EACC042 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public abstract TList<NewsCategories> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		FK__NewsCateg__SiteI__07E124C1 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		FK__NewsCateg__SiteI__07E124C1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		/// <remarks></remarks>
		public TList<NewsCategories> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		FK__NewsCateg__SiteI__07E124C1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		fkNewsCategSitei07e124c1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		fkNewsCategSitei07e124c1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public TList<NewsCategories> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__NewsCateg__SiteI__07E124C1 key.
		///		FK__NewsCateg__SiteI__07E124C1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.NewsCategories objects.</returns>
		public abstract TList<NewsCategories> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.NewsCategories Get(TransactionManager transactionManager, JXTPortal.Entities.NewsCategoriesKey key, int start, int pageLength)
		{
			return GetByNewsCategoryId(transactionManager, key.NewsCategoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="_newsCategoryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public JXTPortal.Entities.NewsCategories GetByNewsCategoryId(System.Int32 _newsCategoryId)
		{
			int count = -1;
			return GetByNewsCategoryId(null,_newsCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public JXTPortal.Entities.NewsCategories GetByNewsCategoryId(System.Int32 _newsCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsCategoryId(null, _newsCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public JXTPortal.Entities.NewsCategories GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId)
		{
			int count = -1;
			return GetByNewsCategoryId(transactionManager, _newsCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public JXTPortal.Entities.NewsCategories GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsCategoryId(transactionManager, _newsCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public JXTPortal.Entities.NewsCategories GetByNewsCategoryId(System.Int32 _newsCategoryId, int start, int pageLength, out int count)
		{
			return GetByNewsCategoryId(null, _newsCategoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsCategories__2E1BDC42 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsCategories"/> class.</returns>
		public abstract JXTPortal.Entities.NewsCategories GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region NewsCategories_Insert 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
			/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName, ref System.Int32? newsCategoryId)
		{
			 Insert(null, 0, int.MaxValue , newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName, ref newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
			/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName, ref System.Int32? newsCategoryId)
		{
			 Insert(null, start, pageLength , newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName, ref newsCategoryId);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
			/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName, ref System.Int32? newsCategoryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName, ref newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
			/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName, ref System.Int32? newsCategoryId);
		
		#endregion
		
		#region NewsCategories_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'NewsCategories_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'NewsCategories_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region NewsCategories_Get_List 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Get_List' stored procedure. 
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
		///	This method wrap the 'NewsCategories_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region NewsCategories_GetPaged 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'NewsCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'NewsCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'NewsCategories_GetPaged' stored procedure. 
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
		
		#region NewsCategories_Update 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			 Update(null, 0, int.MaxValue , newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			 Update(null, start, pageLength , newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			 Update(transactionManager, 0, int.MaxValue , newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName);
		
		#endregion
		
		#region NewsCategories_Find 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			return Find(null, start, pageLength , searchUsingOr, newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, newsCategoryId, newsCategoryName, siteId, valid, sequence, metaTitle, metaKeywords, metaDescription, lastModified, lastModifiedBy, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? newsCategoryId, System.String newsCategoryName, System.Int32? siteId, System.Boolean? valid, System.Int32? sequence, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String pageFriendlyName);
		
		#endregion
		
		#region NewsCategories_Delete 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? newsCategoryId)
		{
			 Delete(null, 0, int.MaxValue , newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? newsCategoryId)
		{
			 Delete(null, start, pageLength , newsCategoryId);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? newsCategoryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsCategoryId);
		
		#endregion
		
		#region NewsCategories_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region NewsCategories_GetByNewsCategoryId 
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByNewsCategoryId' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsCategoryId(System.Int32? newsCategoryId)
		{
			return GetByNewsCategoryId(null, 0, int.MaxValue , newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByNewsCategoryId' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsCategoryId(int start, int pageLength, System.Int32? newsCategoryId)
		{
			return GetByNewsCategoryId(null, start, pageLength , newsCategoryId);
		}
				
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByNewsCategoryId' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsCategoryId(TransactionManager transactionManager, System.Int32? newsCategoryId)
		{
			return GetByNewsCategoryId(transactionManager, 0, int.MaxValue , newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'NewsCategories_GetByNewsCategoryId' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByNewsCategoryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsCategoryId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;NewsCategories&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;NewsCategories&gt;"/></returns>
		public static TList<NewsCategories> Fill(IDataReader reader, TList<NewsCategories> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.NewsCategories c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("NewsCategories")
					.Append("|").Append((System.Int32)reader[((int)NewsCategoriesColumn.NewsCategoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<NewsCategories>(
					key.ToString(), // EntityTrackingKey
					"NewsCategories",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.NewsCategories();
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
					c.NewsCategoryId = (System.Int32)reader[((int)NewsCategoriesColumn.NewsCategoryId - 1)];
					c.NewsCategoryName = (reader.IsDBNull(((int)NewsCategoriesColumn.NewsCategoryName - 1)))?null:(System.String)reader[((int)NewsCategoriesColumn.NewsCategoryName - 1)];
					c.SiteId = (System.Int32)reader[((int)NewsCategoriesColumn.SiteId - 1)];
					c.Valid = (System.Boolean)reader[((int)NewsCategoriesColumn.Valid - 1)];
					c.Sequence = (System.Int32)reader[((int)NewsCategoriesColumn.Sequence - 1)];
					c.MetaTitle = (System.String)reader[((int)NewsCategoriesColumn.MetaTitle - 1)];
					c.MetaKeywords = (System.String)reader[((int)NewsCategoriesColumn.MetaKeywords - 1)];
					c.MetaDescription = (System.String)reader[((int)NewsCategoriesColumn.MetaDescription - 1)];
					c.LastModified = (System.DateTime)reader[((int)NewsCategoriesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)NewsCategoriesColumn.LastModifiedBy - 1)];
					c.PageFriendlyName = (System.String)reader[((int)NewsCategoriesColumn.PageFriendlyName - 1)];
					c.CustomXml = (reader.IsDBNull(((int)NewsCategoriesColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsCategoriesColumn.CustomXml - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsCategories"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsCategories"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.NewsCategories entity)
		{
			if (!reader.Read()) return;
			
			entity.NewsCategoryId = (System.Int32)reader[((int)NewsCategoriesColumn.NewsCategoryId - 1)];
			entity.NewsCategoryName = (reader.IsDBNull(((int)NewsCategoriesColumn.NewsCategoryName - 1)))?null:(System.String)reader[((int)NewsCategoriesColumn.NewsCategoryName - 1)];
			entity.SiteId = (System.Int32)reader[((int)NewsCategoriesColumn.SiteId - 1)];
			entity.Valid = (System.Boolean)reader[((int)NewsCategoriesColumn.Valid - 1)];
			entity.Sequence = (System.Int32)reader[((int)NewsCategoriesColumn.Sequence - 1)];
			entity.MetaTitle = (System.String)reader[((int)NewsCategoriesColumn.MetaTitle - 1)];
			entity.MetaKeywords = (System.String)reader[((int)NewsCategoriesColumn.MetaKeywords - 1)];
			entity.MetaDescription = (System.String)reader[((int)NewsCategoriesColumn.MetaDescription - 1)];
			entity.LastModified = (System.DateTime)reader[((int)NewsCategoriesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)NewsCategoriesColumn.LastModifiedBy - 1)];
			entity.PageFriendlyName = (System.String)reader[((int)NewsCategoriesColumn.PageFriendlyName - 1)];
			entity.CustomXml = (reader.IsDBNull(((int)NewsCategoriesColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsCategoriesColumn.CustomXml - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsCategories"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsCategories"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.NewsCategories entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NewsCategoryId = (System.Int32)dataRow["NewsCategoryID"];
			entity.NewsCategoryName = Convert.IsDBNull(dataRow["NewsCategoryName"]) ? null : (System.String)dataRow["NewsCategoryName"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.MetaTitle = (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = (System.String)dataRow["MetaDescription"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.PageFriendlyName = (System.String)dataRow["PageFriendlyName"];
			entity.CustomXml = Convert.IsDBNull(dataRow["CustomXML"]) ? null : (System.String)dataRow["CustomXML"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsCategories"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsCategories Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.NewsCategories entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			// Deep load child collections  - Call GetByNewsCategoryId methods when available
			
			#region NewsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<News>|NewsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NewsCollection = DataRepository.NewsProvider.GetByNewsCategoryId(transactionManager, entity.NewsCategoryId);

				if (deep && entity.NewsCollection.Count > 0)
				{
					deepHandles.Add("NewsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<News>) DataRepository.NewsProvider.DeepLoad,
						new object[] { transactionManager, entity.NewsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.NewsCategories object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.NewsCategories instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsCategories Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.NewsCategories entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<News>
				if (CanDeepSave(entity.NewsCollection, "List<News>|NewsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(News child in entity.NewsCollection)
					{
						if(child.NewsCategoryIdSource != null)
						{
							child.NewsCategoryId = child.NewsCategoryIdSource.NewsCategoryId;
						}
						else
						{
							child.NewsCategoryId = entity.NewsCategoryId;
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
	
	#region NewsCategoriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.NewsCategories</c>
	///</summary>
	public enum NewsCategoriesChildEntityTypes
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
		/// Collection of <c>NewsCategories</c> as OneToMany for NewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<News>))]
		NewsCollection,
	}
	
	#endregion NewsCategoriesChildEntityTypes
	
	#region NewsCategoriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NewsCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesFilterBuilder : SqlFilterBuilder<NewsCategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilterBuilder class.
		/// </summary>
		public NewsCategoriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsCategoriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsCategoriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsCategoriesFilterBuilder
	
	#region NewsCategoriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NewsCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesParameterBuilder : ParameterizedSqlFilterBuilder<NewsCategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesParameterBuilder class.
		/// </summary>
		public NewsCategoriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsCategoriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsCategoriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsCategoriesParameterBuilder
	
	#region NewsCategoriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NewsCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NewsCategoriesSortBuilder : SqlSortBuilder<NewsCategoriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesSqlSortBuilder class.
		/// </summary>
		public NewsCategoriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NewsCategoriesSortBuilder
	
} // end namespace
