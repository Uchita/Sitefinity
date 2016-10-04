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
	/// This class is the base class for any <see cref="NewsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NewsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.News, JXTPortal.Entities.NewsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.NewsKey key)
		{
			return Delete(transactionManager, key.NewsId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_newsId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _newsId)
		{
			return Delete(null, _newsId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _newsId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		FK__News__LastModifi__7D439ABD Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		FK__News__LastModifi__7D439ABD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		/// <remarks></remarks>
		public TList<News> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		FK__News__LastModifi__7D439ABD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		fkNewsLastModifi7d439Abd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		fkNewsLastModifi7d439Abd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__LastModifi__7D439ABD key.
		///		FK__News__LastModifi__7D439ABD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public abstract TList<News> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		FK__News__NewsCatego__7C4F7684 Description: 
		/// </summary>
		/// <param name="_newsCategoryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByNewsCategoryId(System.Int32 _newsCategoryId)
		{
			int count = -1;
			return GetByNewsCategoryId(_newsCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		FK__News__NewsCatego__7C4F7684 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		/// <remarks></remarks>
		public TList<News> GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId)
		{
			int count = -1;
			return GetByNewsCategoryId(transactionManager, _newsCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		FK__News__NewsCatego__7C4F7684 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsCategoryId(transactionManager, _newsCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		fkNewsNewsCatego7c4f7684 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_newsCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByNewsCategoryId(System.Int32 _newsCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByNewsCategoryId(null, _newsCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		fkNewsNewsCatego7c4f7684 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_newsCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetByNewsCategoryId(System.Int32 _newsCategoryId, int start, int pageLength,out int count)
		{
			return GetByNewsCategoryId(null, _newsCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__NewsCatego__7C4F7684 key.
		///		FK__News__NewsCatego__7C4F7684 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public abstract TList<News> GetByNewsCategoryId(TransactionManager transactionManager, System.Int32 _newsCategoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		FK__News__SiteID__09C96D33 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		FK__News__SiteID__09C96D33 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		/// <remarks></remarks>
		public TList<News> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		FK__News__SiteID__09C96D33 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		fkNewsSiteId09c96d33 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		fkNewsSiteId09c96d33 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public TList<News> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__News__SiteID__09C96D33 key.
		///		FK__News__SiteID__09C96D33 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.News objects.</returns>
		public abstract TList<News> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.News Get(TransactionManager transactionManager, JXTPortal.Entities.NewsKey key, int start, int pageLength)
		{
			return GetByNewsId(transactionManager, key.NewsId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="_newsId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public JXTPortal.Entities.News GetByNewsId(System.Int32 _newsId)
		{
			int count = -1;
			return GetByNewsId(null,_newsId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="_newsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public JXTPortal.Entities.News GetByNewsId(System.Int32 _newsId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsId(null, _newsId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public JXTPortal.Entities.News GetByNewsId(TransactionManager transactionManager, System.Int32 _newsId)
		{
			int count = -1;
			return GetByNewsId(transactionManager, _newsId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public JXTPortal.Entities.News GetByNewsId(TransactionManager transactionManager, System.Int32 _newsId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsId(transactionManager, _newsId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="_newsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public JXTPortal.Entities.News GetByNewsId(System.Int32 _newsId, int start, int pageLength, out int count)
		{
			return GetByNewsId(null, _newsId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__News__2C3393D0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.News"/> class.</returns>
		public abstract JXTPortal.Entities.News GetByNewsId(TransactionManager transactionManager, System.Int32 _newsId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region News_CustomGetNews 
		
		/// <summary>
		///	This method wrap the 'News_CustomGetNews' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;News&gt;"/> instance.</returns>
		public TList<News> CustomGetNews(System.Int32? siteId, System.Int32? newsCategoryId, System.String keyword, System.String orderBy)
		{
			return CustomGetNews(null, 0, int.MaxValue , siteId, newsCategoryId, keyword, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'News_CustomGetNews' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;News&gt;"/> instance.</returns>
		public TList<News> CustomGetNews(int start, int pageLength, System.Int32? siteId, System.Int32? newsCategoryId, System.String keyword, System.String orderBy)
		{
			return CustomGetNews(null, start, pageLength , siteId, newsCategoryId, keyword, orderBy);
		}
				
		/// <summary>
		///	This method wrap the 'News_CustomGetNews' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;News&gt;"/> instance.</returns>
		public TList<News> CustomGetNews(TransactionManager transactionManager, System.Int32? siteId, System.Int32? newsCategoryId, System.String keyword, System.String orderBy)
		{
			return CustomGetNews(transactionManager, 0, int.MaxValue , siteId, newsCategoryId, keyword, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'News_CustomGetNews' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;News&gt;"/> instance.</returns>
		public abstract TList<News> CustomGetNews(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? newsCategoryId, System.String keyword, System.String orderBy);
		
		#endregion
		
		#region News_Insert 
		
		/// <summary>
		///	This method wrap the 'News_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
			/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author, ref System.Int32? newsId)
		{
			 Insert(null, 0, int.MaxValue , siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author, ref newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
			/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author, ref System.Int32? newsId)
		{
			 Insert(null, start, pageLength , siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author, ref newsId);
		}
				
		/// <summary>
		///	This method wrap the 'News_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
			/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author, ref System.Int32? newsId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author, ref newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
			/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author, ref System.Int32? newsId);
		
		#endregion
		
		#region News_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'News_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'News_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'News_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'News_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region News_Get_List 
		
		/// <summary>
		///	This method wrap the 'News_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'News_Get_List' stored procedure. 
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
		///	This method wrap the 'News_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'News_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region News_GetPaged 
		
		/// <summary>
		///	This method wrap the 'News_GetPaged' stored procedure. 
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
		///	This method wrap the 'News_GetPaged' stored procedure. 
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
		///	This method wrap the 'News_GetPaged' stored procedure. 
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
		///	This method wrap the 'News_GetPaged' stored procedure. 
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
		
		#region News_Update 
		
		/// <summary>
		///	This method wrap the 'News_Update' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			 Update(null, 0, int.MaxValue , newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
		
		/// <summary>
		///	This method wrap the 'News_Update' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			 Update(null, start, pageLength , newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
				
		/// <summary>
		///	This method wrap the 'News_Update' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			 Update(transactionManager, 0, int.MaxValue , newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
		
		/// <summary>
		///	This method wrap the 'News_Update' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author);
		
		#endregion
		
		#region News_GetByNewsId 
		
		/// <summary>
		///	This method wrap the 'News_GetByNewsId' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsId(System.Int32? newsId)
		{
			return GetByNewsId(null, 0, int.MaxValue , newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_GetByNewsId' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsId(int start, int pageLength, System.Int32? newsId)
		{
			return GetByNewsId(null, start, pageLength , newsId);
		}
				
		/// <summary>
		///	This method wrap the 'News_GetByNewsId' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsId(TransactionManager transactionManager, System.Int32? newsId)
		{
			return GetByNewsId(transactionManager, 0, int.MaxValue , newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_GetByNewsId' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByNewsId(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsId);
		
		#endregion
		
		#region News_Find 
		
		/// <summary>
		///	This method wrap the 'News_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
		
		/// <summary>
		///	This method wrap the 'News_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			return Find(null, start, pageLength , searchUsingOr, newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
				
		/// <summary>
		///	This method wrap the 'News_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, newsId, siteId, newsCategoryId, subject, content, postDate, valid, sequence, lastModified, lastModifiedBy, searchField, tags, metaTitle, metaKeywords, metaDescription, pageFriendlyName, newsIndustryId, newsTypeIds, customXml, imageUrl, author);
		}
		
		/// <summary>
		///	This method wrap the 'News_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="postDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="newsIndustryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="author"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? newsId, System.Int32? siteId, System.Int32? newsCategoryId, System.String subject, System.String content, System.DateTime? postDate, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.Int32? newsIndustryId, System.String newsTypeIds, System.String customXml, System.String imageUrl, System.String author);
		
		#endregion
		
		#region News_Delete 
		
		/// <summary>
		///	This method wrap the 'News_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? newsId)
		{
			 Delete(null, 0, int.MaxValue , newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? newsId)
		{
			 Delete(null, start, pageLength , newsId);
		}
				
		/// <summary>
		///	This method wrap the 'News_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? newsId)
		{
			 Delete(transactionManager, 0, int.MaxValue , newsId);
		}
		
		/// <summary>
		///	This method wrap the 'News_Delete' stored procedure. 
		/// </summary>
		/// <param name="newsId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsId);
		
		#endregion
		
		#region News_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'News_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'News_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'News_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'News_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region News_GetByNewsCategoryId 
		
		/// <summary>
		///	This method wrap the 'News_GetByNewsCategoryId' stored procedure. 
		/// </summary>
		/// <param name="newsCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsCategoryId(System.Int32? newsCategoryId)
		{
			return GetByNewsCategoryId(null, 0, int.MaxValue , newsCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'News_GetByNewsCategoryId' stored procedure. 
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
		///	This method wrap the 'News_GetByNewsCategoryId' stored procedure. 
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
		///	This method wrap the 'News_GetByNewsCategoryId' stored procedure. 
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
		/// Fill a TList&lt;News&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;News&gt;"/></returns>
		public static TList<News> Fill(IDataReader reader, TList<News> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.News c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("News")
					.Append("|").Append((System.Int32)reader[((int)NewsColumn.NewsId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<News>(
					key.ToString(), // EntityTrackingKey
					"News",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.News();
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
					c.NewsId = (System.Int32)reader[((int)NewsColumn.NewsId - 1)];
					c.SiteId = (System.Int32)reader[((int)NewsColumn.SiteId - 1)];
					c.NewsCategoryId = (System.Int32)reader[((int)NewsColumn.NewsCategoryId - 1)];
					c.Subject = (System.String)reader[((int)NewsColumn.Subject - 1)];
					c.Content = (reader.IsDBNull(((int)NewsColumn.Content - 1)))?null:(System.String)reader[((int)NewsColumn.Content - 1)];
					c.PostDate = (System.DateTime)reader[((int)NewsColumn.PostDate - 1)];
					c.Valid = (reader.IsDBNull(((int)NewsColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)NewsColumn.Valid - 1)];
					c.Sequence = (reader.IsDBNull(((int)NewsColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)NewsColumn.Sequence - 1)];
					c.LastModified = (reader.IsDBNull(((int)NewsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)NewsColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)NewsColumn.LastModifiedBy - 1)];
					c.SearchField = (reader.IsDBNull(((int)NewsColumn.SearchField - 1)))?null:(System.String)reader[((int)NewsColumn.SearchField - 1)];
					c.Tags = (reader.IsDBNull(((int)NewsColumn.Tags - 1)))?null:(System.String)reader[((int)NewsColumn.Tags - 1)];
					c.MetaTitle = (reader.IsDBNull(((int)NewsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)NewsColumn.MetaTitle - 1)];
					c.MetaKeywords = (reader.IsDBNull(((int)NewsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)NewsColumn.MetaKeywords - 1)];
					c.MetaDescription = (reader.IsDBNull(((int)NewsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)NewsColumn.MetaDescription - 1)];
					c.PageFriendlyName = (System.String)reader[((int)NewsColumn.PageFriendlyName - 1)];
					c.NewsIndustryId = (reader.IsDBNull(((int)NewsColumn.NewsIndustryId - 1)))?null:(System.Int32?)reader[((int)NewsColumn.NewsIndustryId - 1)];
					c.NewsTypeIds = (reader.IsDBNull(((int)NewsColumn.NewsTypeIds - 1)))?null:(System.String)reader[((int)NewsColumn.NewsTypeIds - 1)];
					c.CustomXml = (reader.IsDBNull(((int)NewsColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsColumn.CustomXml - 1)];
					c.ImageUrl = (reader.IsDBNull(((int)NewsColumn.ImageUrl - 1)))?null:(System.String)reader[((int)NewsColumn.ImageUrl - 1)];
					c.Author = (reader.IsDBNull(((int)NewsColumn.Author - 1)))?null:(System.String)reader[((int)NewsColumn.Author - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.News"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.News"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.News entity)
		{
			if (!reader.Read()) return;
			
			entity.NewsId = (System.Int32)reader[((int)NewsColumn.NewsId - 1)];
			entity.SiteId = (System.Int32)reader[((int)NewsColumn.SiteId - 1)];
			entity.NewsCategoryId = (System.Int32)reader[((int)NewsColumn.NewsCategoryId - 1)];
			entity.Subject = (System.String)reader[((int)NewsColumn.Subject - 1)];
			entity.Content = (reader.IsDBNull(((int)NewsColumn.Content - 1)))?null:(System.String)reader[((int)NewsColumn.Content - 1)];
			entity.PostDate = (System.DateTime)reader[((int)NewsColumn.PostDate - 1)];
			entity.Valid = (reader.IsDBNull(((int)NewsColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)NewsColumn.Valid - 1)];
			entity.Sequence = (reader.IsDBNull(((int)NewsColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)NewsColumn.Sequence - 1)];
			entity.LastModified = (reader.IsDBNull(((int)NewsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)NewsColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)NewsColumn.LastModifiedBy - 1)];
			entity.SearchField = (reader.IsDBNull(((int)NewsColumn.SearchField - 1)))?null:(System.String)reader[((int)NewsColumn.SearchField - 1)];
			entity.Tags = (reader.IsDBNull(((int)NewsColumn.Tags - 1)))?null:(System.String)reader[((int)NewsColumn.Tags - 1)];
			entity.MetaTitle = (reader.IsDBNull(((int)NewsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)NewsColumn.MetaTitle - 1)];
			entity.MetaKeywords = (reader.IsDBNull(((int)NewsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)NewsColumn.MetaKeywords - 1)];
			entity.MetaDescription = (reader.IsDBNull(((int)NewsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)NewsColumn.MetaDescription - 1)];
			entity.PageFriendlyName = (System.String)reader[((int)NewsColumn.PageFriendlyName - 1)];
			entity.NewsIndustryId = (reader.IsDBNull(((int)NewsColumn.NewsIndustryId - 1)))?null:(System.Int32?)reader[((int)NewsColumn.NewsIndustryId - 1)];
			entity.NewsTypeIds = (reader.IsDBNull(((int)NewsColumn.NewsTypeIds - 1)))?null:(System.String)reader[((int)NewsColumn.NewsTypeIds - 1)];
			entity.CustomXml = (reader.IsDBNull(((int)NewsColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsColumn.CustomXml - 1)];
			entity.ImageUrl = (reader.IsDBNull(((int)NewsColumn.ImageUrl - 1)))?null:(System.String)reader[((int)NewsColumn.ImageUrl - 1)];
			entity.Author = (reader.IsDBNull(((int)NewsColumn.Author - 1)))?null:(System.String)reader[((int)NewsColumn.Author - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.News"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.News"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.News entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NewsId = (System.Int32)dataRow["NewsID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.NewsCategoryId = (System.Int32)dataRow["NewsCategoryID"];
			entity.Subject = (System.String)dataRow["Subject"];
			entity.Content = Convert.IsDBNull(dataRow["Content"]) ? null : (System.String)dataRow["Content"];
			entity.PostDate = (System.DateTime)dataRow["PostDate"];
			entity.Valid = Convert.IsDBNull(dataRow["Valid"]) ? null : (System.Boolean?)dataRow["Valid"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.Tags = Convert.IsDBNull(dataRow["Tags"]) ? null : (System.String)dataRow["Tags"];
			entity.MetaTitle = Convert.IsDBNull(dataRow["MetaTitle"]) ? null : (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = Convert.IsDBNull(dataRow["MetaKeywords"]) ? null : (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = Convert.IsDBNull(dataRow["MetaDescription"]) ? null : (System.String)dataRow["MetaDescription"];
			entity.PageFriendlyName = (System.String)dataRow["PageFriendlyName"];
			entity.NewsIndustryId = Convert.IsDBNull(dataRow["NewsIndustryID"]) ? null : (System.Int32?)dataRow["NewsIndustryID"];
			entity.NewsTypeIds = Convert.IsDBNull(dataRow["NewsTypeIDs"]) ? null : (System.String)dataRow["NewsTypeIDs"];
			entity.CustomXml = Convert.IsDBNull(dataRow["CustomXML"]) ? null : (System.String)dataRow["CustomXML"];
			entity.ImageUrl = Convert.IsDBNull(dataRow["ImageURL"]) ? null : (System.String)dataRow["ImageURL"];
			entity.Author = Convert.IsDBNull(dataRow["Author"]) ? null : (System.String)dataRow["Author"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.News"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.News Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.News entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region NewsCategoryIdSource	
			if (CanDeepLoad(entity, "NewsCategories|NewsCategoryIdSource", deepLoadType, innerList) 
				&& entity.NewsCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.NewsCategoryId;
				NewsCategories tmpEntity = EntityManager.LocateEntity<NewsCategories>(EntityLocator.ConstructKeyFromPkItems(typeof(NewsCategories), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.NewsCategoryIdSource = tmpEntity;
				else
					entity.NewsCategoryIdSource = DataRepository.NewsCategoriesProvider.GetByNewsCategoryId(transactionManager, entity.NewsCategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.NewsCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.NewsCategoriesProvider.DeepLoad(transactionManager, entity.NewsCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion NewsCategoryIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.News object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.News instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.News Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.News entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region NewsCategoryIdSource
			if (CanDeepSave(entity, "NewsCategories|NewsCategoryIdSource", deepSaveType, innerList) 
				&& entity.NewsCategoryIdSource != null)
			{
				DataRepository.NewsCategoriesProvider.Save(transactionManager, entity.NewsCategoryIdSource);
				entity.NewsCategoryId = entity.NewsCategoryIdSource.NewsCategoryId;
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
	
	#region NewsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.News</c>
	///</summary>
	public enum NewsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>NewsCategories</c> at NewsCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(NewsCategories))]
		NewsCategories,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion NewsChildEntityTypes
	
	#region NewsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsFilterBuilder : SqlFilterBuilder<NewsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsFilterBuilder class.
		/// </summary>
		public NewsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsFilterBuilder
	
	#region NewsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsParameterBuilder : ParameterizedSqlFilterBuilder<NewsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsParameterBuilder class.
		/// </summary>
		public NewsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsParameterBuilder
	
	#region NewsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NewsSortBuilder : SqlSortBuilder<NewsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsSqlSortBuilder class.
		/// </summary>
		public NewsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NewsSortBuilder
	
} // end namespace
