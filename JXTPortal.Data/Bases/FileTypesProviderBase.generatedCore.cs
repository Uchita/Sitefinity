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
	/// This class is the base class for any <see cref="FileTypesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FileTypesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.FileTypes, JXTPortal.Entities.FileTypesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.FileTypesKey key)
		{
			return Delete(transactionManager, key.FileTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_fileTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _fileTypeId)
		{
			return Delete(null, _fileTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _fileTypeId);		
		
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
		public override JXTPortal.Entities.FileTypes Get(TransactionManager transactionManager, JXTPortal.Entities.FileTypesKey key, int start, int pageLength)
		{
			return GetByFileTypeId(transactionManager, key.FileTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="_fileTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public JXTPortal.Entities.FileTypes GetByFileTypeId(System.Int32 _fileTypeId)
		{
			int count = -1;
			return GetByFileTypeId(null,_fileTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public JXTPortal.Entities.FileTypes GetByFileTypeId(System.Int32 _fileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileTypeId(null, _fileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public JXTPortal.Entities.FileTypes GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId)
		{
			int count = -1;
			return GetByFileTypeId(transactionManager, _fileTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public JXTPortal.Entities.FileTypes GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileTypeId(transactionManager, _fileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public JXTPortal.Entities.FileTypes GetByFileTypeId(System.Int32 _fileTypeId, int start, int pageLength, out int count)
		{
			return GetByFileTypeId(null, _fileTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__FileTypes__1ED998B2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.FileTypes"/> class.</returns>
		public abstract JXTPortal.Entities.FileTypes GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region FileTypes_GetPaged 
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public abstract TList<FileTypes> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region FileTypes_Delete 
		
		/// <summary>
		///	This method wrap the 'FileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? fileTypeId)
		{
			 Delete(null, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? fileTypeId)
		{
			 Delete(null, start, pageLength , fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? fileTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileTypeId);
		
		#endregion
		
		#region FileTypes_GetByFileTypeId 
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetByFileTypeId(System.Int32? fileTypeId)
		{
			return GetByFileTypeId(null, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetByFileTypeId(int start, int pageLength, System.Int32? fileTypeId)
		{
			return GetByFileTypeId(null, start, pageLength , fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> GetByFileTypeId(TransactionManager transactionManager, System.Int32? fileTypeId)
		{
			return GetByFileTypeId(transactionManager, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public abstract TList<FileTypes> GetByFileTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileTypeId);
		
		#endregion
		
		#region FileTypes_Insert 
		
		/// <summary>
		///	This method wrap the 'FileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
			/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String fileTypeName, System.String fileTypeExtension, ref System.Int32? fileTypeId)
		{
			 Insert(null, 0, int.MaxValue , fileTypeName, fileTypeExtension, ref fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
			/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String fileTypeName, System.String fileTypeExtension, ref System.Int32? fileTypeId)
		{
			 Insert(null, start, pageLength , fileTypeName, fileTypeExtension, ref fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
			/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String fileTypeName, System.String fileTypeExtension, ref System.Int32? fileTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , fileTypeName, fileTypeExtension, ref fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
			/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String fileTypeName, System.String fileTypeExtension, ref System.Int32? fileTypeId);
		
		#endregion
		
		#region FileTypes_Update 
		
		/// <summary>
		///	This method wrap the 'FileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			 Update(null, 0, int.MaxValue , fileTypeId, fileTypeName, fileTypeExtension);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			 Update(null, start, pageLength , fileTypeId, fileTypeName, fileTypeExtension);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			 Update(transactionManager, 0, int.MaxValue , fileTypeId, fileTypeName, fileTypeExtension);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension);
		
		#endregion
		
		#region FileTypes_Get_List 
		
		/// <summary>
		///	This method wrap the 'FileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public abstract TList<FileTypes> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region FileTypes_Find 
		
		/// <summary>
		///	This method wrap the 'FileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Find(System.Boolean? searchUsingOr, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, fileTypeId, fileTypeName, fileTypeExtension);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			return Find(null, start, pageLength , searchUsingOr, fileTypeId, fileTypeName, fileTypeExtension);
		}
				
		/// <summary>
		///	This method wrap the 'FileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public TList<FileTypes> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, fileTypeId, fileTypeName, fileTypeExtension);
		}
		
		/// <summary>
		///	This method wrap the 'FileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeExtension"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;FileTypes&gt;"/> instance.</returns>
		public abstract TList<FileTypes> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? fileTypeId, System.String fileTypeName, System.String fileTypeExtension);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;FileTypes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;FileTypes&gt;"/></returns>
		public static TList<FileTypes> Fill(IDataReader reader, TList<FileTypes> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.FileTypes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("FileTypes")
					.Append("|").Append((System.Int32)reader[((int)FileTypesColumn.FileTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<FileTypes>(
					key.ToString(), // EntityTrackingKey
					"FileTypes",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.FileTypes();
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
					c.FileTypeId = (System.Int32)reader[((int)FileTypesColumn.FileTypeId - 1)];
					c.FileTypeName = (System.String)reader[((int)FileTypesColumn.FileTypeName - 1)];
					c.FileTypeExtension = (System.String)reader[((int)FileTypesColumn.FileTypeExtension - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.FileTypes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.FileTypes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.FileTypes entity)
		{
			if (!reader.Read()) return;
			
			entity.FileTypeId = (System.Int32)reader[((int)FileTypesColumn.FileTypeId - 1)];
			entity.FileTypeName = (System.String)reader[((int)FileTypesColumn.FileTypeName - 1)];
			entity.FileTypeExtension = (System.String)reader[((int)FileTypesColumn.FileTypeExtension - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.FileTypes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.FileTypes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.FileTypes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FileTypeId = (System.Int32)dataRow["FileTypeID"];
			entity.FileTypeName = (System.String)dataRow["FileTypeName"];
			entity.FileTypeExtension = (System.String)dataRow["FileTypeExtension"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.FileTypes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.FileTypes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.FileTypes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByFileTypeId methods when available
			
			#region FilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Files>|FilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FilesCollection = DataRepository.FilesProvider.GetByFileTypeId(transactionManager, entity.FileTypeId);

				if (deep && entity.FilesCollection.Count > 0)
				{
					deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Files>) DataRepository.FilesProvider.DeepLoad,
						new object[] { transactionManager, entity.FilesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.FileTypes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.FileTypes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.FileTypes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.FileTypes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Files>
				if (CanDeepSave(entity.FilesCollection, "List<Files>|FilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Files child in entity.FilesCollection)
					{
						if(child.FileTypeIdSource != null)
						{
							child.FileTypeId = child.FileTypeIdSource.FileTypeId;
						}
						else
						{
							child.FileTypeId = entity.FileTypeId;
						}

					}

					if (entity.FilesCollection.Count > 0 || entity.FilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FilesProvider.Save(transactionManager, entity.FilesCollection);
						
						deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Files >) DataRepository.FilesProvider.DeepSave,
							new object[] { transactionManager, entity.FilesCollection, deepSaveType, childTypes, innerList }
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
	
	#region FileTypesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.FileTypes</c>
	///</summary>
	public enum FileTypesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>FileTypes</c> as OneToMany for FilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Files>))]
		FilesCollection,
	}
	
	#endregion FileTypesChildEntityTypes
	
	#region FileTypesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesFilterBuilder : SqlFilterBuilder<FileTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesFilterBuilder class.
		/// </summary>
		public FileTypesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FileTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FileTypesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FileTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FileTypesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FileTypesFilterBuilder
	
	#region FileTypesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesParameterBuilder : ParameterizedSqlFilterBuilder<FileTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesParameterBuilder class.
		/// </summary>
		public FileTypesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FileTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FileTypesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FileTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FileTypesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FileTypesParameterBuilder
	
	#region FileTypesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FileTypesSortBuilder : SqlSortBuilder<FileTypesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesSqlSortBuilder class.
		/// </summary>
		public FileTypesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FileTypesSortBuilder
	
} // end namespace
