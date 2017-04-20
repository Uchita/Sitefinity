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
	/// This class is the base class for any <see cref="KnowledgeBaseProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KnowledgeBaseProviderBaseCore : EntityProviderBase<JXTPortal.Entities.KnowledgeBase, JXTPortal.Entities.KnowledgeBaseKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		FK_KnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		public TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(System.Int32 _knowledgeBaseCategoryId)
		{
			int count = -1;
			return GetByKnowledgeBaseCategoryId(_knowledgeBaseCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		FK_KnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		/// <remarks></remarks>
		public TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(TransactionManager transactionManager, System.Int32 _knowledgeBaseCategoryId)
		{
			int count = -1;
			return GetByKnowledgeBaseCategoryId(transactionManager, _knowledgeBaseCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		FK_KnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		public TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(TransactionManager transactionManager, System.Int32 _knowledgeBaseCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByKnowledgeBaseCategoryId(transactionManager, _knowledgeBaseCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		fkKnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		public TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(System.Int32 _knowledgeBaseCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByKnowledgeBaseCategoryId(null, _knowledgeBaseCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		fkKnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		public TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(System.Int32 _knowledgeBaseCategoryId, int start, int pageLength,out int count)
		{
			return GetByKnowledgeBaseCategoryId(null, _knowledgeBaseCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_KnowledgeBaseCategory key.
		///		FK_KnowledgeBaseCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_knowledgeBaseCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.KnowledgeBase objects.</returns>
		public abstract TList<KnowledgeBase> GetByKnowledgeBaseCategoryId(TransactionManager transactionManager, System.Int32 _knowledgeBaseCategoryId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.KnowledgeBase Get(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_KnowledgeBase index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBase GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBase index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBase GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBase GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBase GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBase index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBase GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBase index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBase"/> class.</returns>
		public abstract JXTPortal.Entities.KnowledgeBase GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region KnowledgeBase_Insert 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, ref System.Int32? id)
		{
			 Insert(null, 0, int.MaxValue , knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, ref System.Int32? id)
		{
			 Insert(null, start, pageLength , knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags, ref id);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, ref System.Int32? id)
		{
			 Insert(transactionManager, 0, int.MaxValue , knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags, ref System.Int32? id);
		
		#endregion
		
		#region KnowledgeBase_GetByKnowledgeBaseCategoryId 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetByKnowledgeBaseCategoryId' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKnowledgeBaseCategoryId(System.Int32? knowledgeBaseCategoryId)
		{
			return GetByKnowledgeBaseCategoryId(null, 0, int.MaxValue , knowledgeBaseCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetByKnowledgeBaseCategoryId' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKnowledgeBaseCategoryId(int start, int pageLength, System.Int32? knowledgeBaseCategoryId)
		{
			return GetByKnowledgeBaseCategoryId(null, start, pageLength , knowledgeBaseCategoryId);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetByKnowledgeBaseCategoryId' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKnowledgeBaseCategoryId(TransactionManager transactionManager, System.Int32? knowledgeBaseCategoryId)
		{
			return GetByKnowledgeBaseCategoryId(transactionManager, 0, int.MaxValue , knowledgeBaseCategoryId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetByKnowledgeBaseCategoryId' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByKnowledgeBaseCategoryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? knowledgeBaseCategoryId);
		
		#endregion
		
		#region KnowledgeBase_Get_List 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Get_List' stored procedure. 
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
		///	This method wrap the 'KnowledgeBase_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region KnowledgeBase_GetPaged 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBase_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBase_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBase_GetPaged' stored procedure. 
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
		
		#region KnowledgeBase_GetById 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(System.Int32? id)
		{
			return GetById(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(int start, int pageLength, System.Int32? id)
		{
			return GetById(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(TransactionManager transactionManager, System.Int32? id)
		{
			return GetById(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetById(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region KnowledgeBase_Find 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			return Find(null, start, pageLength , searchUsingOr, id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags);
		
		#endregion
		
		#region KnowledgeBase_Delete 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? id)
		{
			 Delete(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? id)
		{
			 Delete(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? id)
		{
			 Delete(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region KnowledgeBase_Update 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			 Update(null, 0, int.MaxValue , id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			 Update(null, start, pageLength , id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags)
		{
			 Update(transactionManager, 0, int.MaxValue , id, knowledgeBaseCategoryId, subject, content, valid, sequence, lastModified, lastModifiedBy, searchField, tags);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBase_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subject"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? id, System.Int32? knowledgeBaseCategoryId, System.String subject, System.String content, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.String tags);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;KnowledgeBase&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;KnowledgeBase&gt;"/></returns>
		public static TList<KnowledgeBase> Fill(IDataReader reader, TList<KnowledgeBase> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.KnowledgeBase c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("KnowledgeBase")
					.Append("|").Append((System.Int32)reader[((int)KnowledgeBaseColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<KnowledgeBase>(
					key.ToString(), // EntityTrackingKey
					"KnowledgeBase",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.KnowledgeBase();
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
					c.Id = (System.Int32)reader[((int)KnowledgeBaseColumn.Id - 1)];
					c.KnowledgeBaseCategoryId = (System.Int32)reader[((int)KnowledgeBaseColumn.KnowledgeBaseCategoryId - 1)];
					c.Subject = (System.String)reader[((int)KnowledgeBaseColumn.Subject - 1)];
					c.Content = (reader.IsDBNull(((int)KnowledgeBaseColumn.Content - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.Content - 1)];
					c.Valid = (reader.IsDBNull(((int)KnowledgeBaseColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)KnowledgeBaseColumn.Valid - 1)];
					c.Sequence = (reader.IsDBNull(((int)KnowledgeBaseColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)KnowledgeBaseColumn.Sequence - 1)];
					c.LastModified = (reader.IsDBNull(((int)KnowledgeBaseColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)KnowledgeBaseColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)KnowledgeBaseColumn.LastModifiedBy - 1)];
					c.SearchField = (reader.IsDBNull(((int)KnowledgeBaseColumn.SearchField - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.SearchField - 1)];
					c.Tags = (reader.IsDBNull(((int)KnowledgeBaseColumn.Tags - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.Tags - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.KnowledgeBase"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBase"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.KnowledgeBase entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)KnowledgeBaseColumn.Id - 1)];
			entity.KnowledgeBaseCategoryId = (System.Int32)reader[((int)KnowledgeBaseColumn.KnowledgeBaseCategoryId - 1)];
			entity.Subject = (System.String)reader[((int)KnowledgeBaseColumn.Subject - 1)];
			entity.Content = (reader.IsDBNull(((int)KnowledgeBaseColumn.Content - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.Content - 1)];
			entity.Valid = (reader.IsDBNull(((int)KnowledgeBaseColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)KnowledgeBaseColumn.Valid - 1)];
			entity.Sequence = (reader.IsDBNull(((int)KnowledgeBaseColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)KnowledgeBaseColumn.Sequence - 1)];
			entity.LastModified = (reader.IsDBNull(((int)KnowledgeBaseColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)KnowledgeBaseColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)KnowledgeBaseColumn.LastModifiedBy - 1)];
			entity.SearchField = (reader.IsDBNull(((int)KnowledgeBaseColumn.SearchField - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.SearchField - 1)];
			entity.Tags = (reader.IsDBNull(((int)KnowledgeBaseColumn.Tags - 1)))?null:(System.String)reader[((int)KnowledgeBaseColumn.Tags - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.KnowledgeBase"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBase"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.KnowledgeBase entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.KnowledgeBaseCategoryId = (System.Int32)dataRow["KnowledgeBaseCategoryID"];
			entity.Subject = (System.String)dataRow["Subject"];
			entity.Content = Convert.IsDBNull(dataRow["Content"]) ? null : (System.String)dataRow["Content"];
			entity.Valid = Convert.IsDBNull(dataRow["Valid"]) ? null : (System.Boolean?)dataRow["Valid"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.Tags = Convert.IsDBNull(dataRow["Tags"]) ? null : (System.String)dataRow["Tags"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBase"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.KnowledgeBase Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBase entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region KnowledgeBaseCategoryIdSource	
			if (CanDeepLoad(entity, "KnowledgeBaseCategories|KnowledgeBaseCategoryIdSource", deepLoadType, innerList) 
				&& entity.KnowledgeBaseCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.KnowledgeBaseCategoryId;
				KnowledgeBaseCategories tmpEntity = EntityManager.LocateEntity<KnowledgeBaseCategories>(EntityLocator.ConstructKeyFromPkItems(typeof(KnowledgeBaseCategories), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.KnowledgeBaseCategoryIdSource = tmpEntity;
				else
					entity.KnowledgeBaseCategoryIdSource = DataRepository.KnowledgeBaseCategoriesProvider.GetById(transactionManager, entity.KnowledgeBaseCategoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'KnowledgeBaseCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.KnowledgeBaseCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.KnowledgeBaseCategoriesProvider.DeepLoad(transactionManager, entity.KnowledgeBaseCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion KnowledgeBaseCategoryIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.KnowledgeBase object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.KnowledgeBase instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.KnowledgeBase Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBase entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region KnowledgeBaseCategoryIdSource
			if (CanDeepSave(entity, "KnowledgeBaseCategories|KnowledgeBaseCategoryIdSource", deepSaveType, innerList) 
				&& entity.KnowledgeBaseCategoryIdSource != null)
			{
				DataRepository.KnowledgeBaseCategoriesProvider.Save(transactionManager, entity.KnowledgeBaseCategoryIdSource);
				entity.KnowledgeBaseCategoryId = entity.KnowledgeBaseCategoryIdSource.Id;
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
	
	#region KnowledgeBaseChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.KnowledgeBase</c>
	///</summary>
	public enum KnowledgeBaseChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>KnowledgeBaseCategories</c> at KnowledgeBaseCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(KnowledgeBaseCategories))]
		KnowledgeBaseCategories,
		}
	
	#endregion KnowledgeBaseChildEntityTypes
	
	#region KnowledgeBaseFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KnowledgeBaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseFilterBuilder : SqlFilterBuilder<KnowledgeBaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilterBuilder class.
		/// </summary>
		public KnowledgeBaseFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseFilterBuilder
	
	#region KnowledgeBaseParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KnowledgeBaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseParameterBuilder : ParameterizedSqlFilterBuilder<KnowledgeBaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseParameterBuilder class.
		/// </summary>
		public KnowledgeBaseParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseParameterBuilder
	
	#region KnowledgeBaseSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;KnowledgeBaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBase"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class KnowledgeBaseSortBuilder : SqlSortBuilder<KnowledgeBaseColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseSqlSortBuilder class.
		/// </summary>
		public KnowledgeBaseSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion KnowledgeBaseSortBuilder
	
} // end namespace
