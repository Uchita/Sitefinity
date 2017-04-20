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
	/// This class is the base class for any <see cref="KnowledgeBaseCategoriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KnowledgeBaseCategoriesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.KnowledgeBaseCategories, JXTPortal.Entities.KnowledgeBaseCategoriesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseCategoriesKey key)
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
		public override JXTPortal.Entities.KnowledgeBaseCategories Get(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseCategoriesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBaseCategories GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBaseCategories GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBaseCategories GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBaseCategories GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public JXTPortal.Entities.KnowledgeBaseCategories GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_KnowledgeBaseCategories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> class.</returns>
		public abstract JXTPortal.Entities.KnowledgeBaseCategories GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region KnowledgeBaseCategories_GetPaged 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_GetPaged' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_GetPaged' stored procedure. 
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
		
		#region KnowledgeBaseCategories_Delete 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? id)
		{
			 Delete(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Delete' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? id)
		{
			 Delete(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region KnowledgeBaseCategories_Update 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			 Update(null, 0, int.MaxValue , id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			 Update(null, start, pageLength , id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			 Update(transactionManager, 0, int.MaxValue , id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId);
		
		#endregion
		
		#region KnowledgeBaseCategories_Insert 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId, ref System.Int32? id)
		{
			 Insert(null, 0, int.MaxValue , knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId, ref System.Int32? id)
		{
			 Insert(null, start, pageLength , knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId, ref id);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId, ref System.Int32? id)
		{
			 Insert(transactionManager, 0, int.MaxValue , knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Insert' stored procedure. 
		/// </summary>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId, ref System.Int32? id);
		
		#endregion
		
		#region KnowledgeBaseCategories_Get_List 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Get_List' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region KnowledgeBaseCategories_GetById 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(System.Int32? id)
		{
			return GetById(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_GetById' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_GetById' stored procedure. 
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
		///	This method wrap the 'KnowledgeBaseCategories_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetById(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region KnowledgeBaseCategories_Find 
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			return Find(null, start, pageLength , searchUsingOr, id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
				
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, id, knowledgeBaseCategoryName, valid, sequence, lastModified, lastModifiedBy, parentId);
		}
		
		/// <summary>
		///	This method wrap the 'KnowledgeBaseCategories_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knowledgeBaseCategoryName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? id, System.String knowledgeBaseCategoryName, System.Boolean? valid, System.Int32? sequence, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? parentId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;KnowledgeBaseCategories&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;KnowledgeBaseCategories&gt;"/></returns>
		public static TList<KnowledgeBaseCategories> Fill(IDataReader reader, TList<KnowledgeBaseCategories> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.KnowledgeBaseCategories c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("KnowledgeBaseCategories")
					.Append("|").Append((System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<KnowledgeBaseCategories>(
					key.ToString(), // EntityTrackingKey
					"KnowledgeBaseCategories",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.KnowledgeBaseCategories();
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
					c.Id = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.Id - 1)];
					c.KnowledgeBaseCategoryName = (reader.IsDBNull(((int)KnowledgeBaseCategoriesColumn.KnowledgeBaseCategoryName - 1)))?null:(System.String)reader[((int)KnowledgeBaseCategoriesColumn.KnowledgeBaseCategoryName - 1)];
					c.Valid = (System.Boolean)reader[((int)KnowledgeBaseCategoriesColumn.Valid - 1)];
					c.Sequence = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.Sequence - 1)];
					c.LastModified = (System.DateTime)reader[((int)KnowledgeBaseCategoriesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.LastModifiedBy - 1)];
					c.ParentId = (reader.IsDBNull(((int)KnowledgeBaseCategoriesColumn.ParentId - 1)))?null:(System.Int32?)reader[((int)KnowledgeBaseCategoriesColumn.ParentId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.KnowledgeBaseCategories entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.Id - 1)];
			entity.KnowledgeBaseCategoryName = (reader.IsDBNull(((int)KnowledgeBaseCategoriesColumn.KnowledgeBaseCategoryName - 1)))?null:(System.String)reader[((int)KnowledgeBaseCategoriesColumn.KnowledgeBaseCategoryName - 1)];
			entity.Valid = (System.Boolean)reader[((int)KnowledgeBaseCategoriesColumn.Valid - 1)];
			entity.Sequence = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.Sequence - 1)];
			entity.LastModified = (System.DateTime)reader[((int)KnowledgeBaseCategoriesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)KnowledgeBaseCategoriesColumn.LastModifiedBy - 1)];
			entity.ParentId = (reader.IsDBNull(((int)KnowledgeBaseCategoriesColumn.ParentId - 1)))?null:(System.Int32?)reader[((int)KnowledgeBaseCategoriesColumn.ParentId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.KnowledgeBaseCategories entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.KnowledgeBaseCategoryName = Convert.IsDBNull(dataRow["KnowledgeBaseCategoryName"]) ? null : (System.String)dataRow["KnowledgeBaseCategoryName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.ParentId = Convert.IsDBNull(dataRow["ParentId"]) ? null : (System.Int32?)dataRow["ParentId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.KnowledgeBaseCategories"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.KnowledgeBaseCategories Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseCategories entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region KnowledgeBaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<KnowledgeBase>|KnowledgeBaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'KnowledgeBaseCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.KnowledgeBaseCollection = DataRepository.KnowledgeBaseProvider.GetByKnowledgeBaseCategoryId(transactionManager, entity.Id);

				if (deep && entity.KnowledgeBaseCollection.Count > 0)
				{
					deepHandles.Add("KnowledgeBaseCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<KnowledgeBase>) DataRepository.KnowledgeBaseProvider.DeepLoad,
						new object[] { transactionManager, entity.KnowledgeBaseCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.KnowledgeBaseCategories object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.KnowledgeBaseCategories instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.KnowledgeBaseCategories Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.KnowledgeBaseCategories entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<KnowledgeBase>
				if (CanDeepSave(entity.KnowledgeBaseCollection, "List<KnowledgeBase>|KnowledgeBaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(KnowledgeBase child in entity.KnowledgeBaseCollection)
					{
						if(child.KnowledgeBaseCategoryIdSource != null)
						{
							child.KnowledgeBaseCategoryId = child.KnowledgeBaseCategoryIdSource.Id;
						}
						else
						{
							child.KnowledgeBaseCategoryId = entity.Id;
						}

					}

					if (entity.KnowledgeBaseCollection.Count > 0 || entity.KnowledgeBaseCollection.DeletedItems.Count > 0)
					{
						//DataRepository.KnowledgeBaseProvider.Save(transactionManager, entity.KnowledgeBaseCollection);
						
						deepHandles.Add("KnowledgeBaseCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< KnowledgeBase >) DataRepository.KnowledgeBaseProvider.DeepSave,
							new object[] { transactionManager, entity.KnowledgeBaseCollection, deepSaveType, childTypes, innerList }
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
	
	#region KnowledgeBaseCategoriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.KnowledgeBaseCategories</c>
	///</summary>
	public enum KnowledgeBaseCategoriesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>KnowledgeBaseCategories</c> as OneToMany for KnowledgeBaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<KnowledgeBase>))]
		KnowledgeBaseCollection,
	}
	
	#endregion KnowledgeBaseCategoriesChildEntityTypes
	
	#region KnowledgeBaseCategoriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KnowledgeBaseCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBaseCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseCategoriesFilterBuilder : SqlFilterBuilder<KnowledgeBaseCategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilterBuilder class.
		/// </summary>
		public KnowledgeBaseCategoriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseCategoriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseCategoriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseCategoriesFilterBuilder
	
	#region KnowledgeBaseCategoriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KnowledgeBaseCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBaseCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseCategoriesParameterBuilder : ParameterizedSqlFilterBuilder<KnowledgeBaseCategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesParameterBuilder class.
		/// </summary>
		public KnowledgeBaseCategoriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseCategoriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseCategoriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseCategoriesParameterBuilder
	
	#region KnowledgeBaseCategoriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;KnowledgeBaseCategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBaseCategories"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class KnowledgeBaseCategoriesSortBuilder : SqlSortBuilder<KnowledgeBaseCategoriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesSqlSortBuilder class.
		/// </summary>
		public KnowledgeBaseCategoriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion KnowledgeBaseCategoriesSortBuilder
	
} // end namespace
