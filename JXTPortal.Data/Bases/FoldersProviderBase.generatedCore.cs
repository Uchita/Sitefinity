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
	/// This class is the base class for any <see cref="FoldersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FoldersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Folders, JXTPortal.Entities.FoldersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.FoldersKey key)
		{
			return Delete(transactionManager, key.FolderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_folderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _folderId)
		{
			return Delete(null, _folderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _folderId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		FK_Folders_Sites Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		public TList<Folders> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		FK_Folders_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		/// <remarks></remarks>
		public TList<Folders> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		FK_Folders_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		public TList<Folders> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		fkFoldersSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		public TList<Folders> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		fkFoldersSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		public TList<Folders> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Folders_Sites key.
		///		FK_Folders_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Folders objects.</returns>
		public abstract TList<Folders> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Folders Get(TransactionManager transactionManager, JXTPortal.Entities.FoldersKey key, int start, int pageLength)
		{
			return GetByFolderId(transactionManager, key.FolderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Folders index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId)
		{
			int count = -1;
			return GetBySiteIdFolderIdParentFolderId(null,_siteId, _folderId, _parentFolderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Folders index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdFolderIdParentFolderId(null, _siteId, _folderId, _parentFolderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Folders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId)
		{
			int count = -1;
			return GetBySiteIdFolderIdParentFolderId(transactionManager, _siteId, _folderId, _parentFolderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Folders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdFolderIdParentFolderId(transactionManager, _siteId, _folderId, _parentFolderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Folders index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId, int start, int pageLength, out int count)
		{
			return GetBySiteIdFolderIdParentFolderId(null, _siteId, _folderId, _parentFolderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Folders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_folderId"></param>
		/// <param name="_parentFolderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public abstract JXTPortal.Entities.Folders GetBySiteIdFolderIdParentFolderId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _folderId, System.Int32 _parentFolderId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetByFolderId(System.Int32 _folderId)
		{
			int count = -1;
			return GetByFolderId(null,_folderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetByFolderId(System.Int32 _folderId, int start, int pageLength)
		{
			int count = -1;
			return GetByFolderId(null, _folderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId)
		{
			int count = -1;
			return GetByFolderId(transactionManager, _folderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId, int start, int pageLength)
		{
			int count = -1;
			return GetByFolderId(transactionManager, _folderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public JXTPortal.Entities.Folders GetByFolderId(System.Int32 _folderId, int start, int pageLength, out int count)
		{
			return GetByFolderId(null, _folderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Folders__20C1E124 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Folders"/> class.</returns>
		public abstract JXTPortal.Entities.Folders GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Folders_Insert 
		
		/// <summary>
		///	This method wrap the 'Folders_Insert' stored procedure. 
		/// </summary>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId, ref System.Int32? folderId)
		{
			 Insert(null, 0, int.MaxValue , parentFolderId, siteId, folderName, sourceId, ref folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Insert' stored procedure. 
		/// </summary>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId, ref System.Int32? folderId)
		{
			 Insert(null, start, pageLength , parentFolderId, siteId, folderName, sourceId, ref folderId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_Insert' stored procedure. 
		/// </summary>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId, ref System.Int32? folderId)
		{
			 Insert(transactionManager, 0, int.MaxValue , parentFolderId, siteId, folderName, sourceId, ref folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Insert' stored procedure. 
		/// </summary>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId, ref System.Int32? folderId);
		
		#endregion
		
		#region Folders_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Folders_Get_List 
		
		/// <summary>
		///	This method wrap the 'Folders_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Folders_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Folders_GetByFolderId 
		
		/// <summary>
		///	This method wrap the 'Folders_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetByFolderId(System.Int32? folderId)
		{
			return GetByFolderId(null, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetByFolderId(int start, int pageLength, System.Int32? folderId)
		{
			return GetByFolderId(null, start, pageLength , folderId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetByFolderId(TransactionManager transactionManager, System.Int32? folderId)
		{
			return GetByFolderId(transactionManager, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> GetByFolderId(TransactionManager transactionManager, int start, int pageLength , System.Int32? folderId);
		
		#endregion
		
		#region Folders_Find 
		
		/// <summary>
		///	This method wrap the 'Folders_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Find(System.Boolean? searchUsingOr, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, folderId, parentFolderId, siteId, folderName, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, folderId, parentFolderId, siteId, folderName, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, folderId, parentFolderId, siteId, folderName, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId);
		
		#endregion
		
		#region Folders_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Folders_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Folders_Update 
		
		/// <summary>
		///	This method wrap the 'Folders_Update' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , folderId, parentFolderId, siteId, folderName, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Update' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , folderId, parentFolderId, siteId, folderName, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_Update' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , folderId, parentFolderId, siteId, folderName, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Update' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderName"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? folderId, System.Int32? parentFolderId, System.Int32? siteId, System.String folderName, System.Int32? sourceId);
		
		#endregion
		
		#region Folders_GetBySiteIdFolderIdParentFolderId 
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteIdFolderIdParentFolderId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteIdFolderIdParentFolderId(System.Int32? siteId, System.Int32? folderId, System.Int32? parentFolderId)
		{
			return GetBySiteIdFolderIdParentFolderId(null, 0, int.MaxValue , siteId, folderId, parentFolderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteIdFolderIdParentFolderId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteIdFolderIdParentFolderId(int start, int pageLength, System.Int32? siteId, System.Int32? folderId, System.Int32? parentFolderId)
		{
			return GetBySiteIdFolderIdParentFolderId(null, start, pageLength , siteId, folderId, parentFolderId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteIdFolderIdParentFolderId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public TList<Folders> GetBySiteIdFolderIdParentFolderId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? folderId, System.Int32? parentFolderId)
		{
			return GetBySiteIdFolderIdParentFolderId(transactionManager, 0, int.MaxValue , siteId, folderId, parentFolderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_GetBySiteIdFolderIdParentFolderId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentFolderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Folders&gt;"/> instance.</returns>
		public abstract TList<Folders> GetBySiteIdFolderIdParentFolderId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? folderId, System.Int32? parentFolderId);
		
		#endregion
		
		#region Folders_Delete 
		
		/// <summary>
		///	This method wrap the 'Folders_Delete' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? folderId)
		{
			 Delete(null, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Delete' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? folderId)
		{
			 Delete(null, start, pageLength , folderId);
		}
				
		/// <summary>
		///	This method wrap the 'Folders_Delete' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? folderId)
		{
			 Delete(transactionManager, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Folders_Delete' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? folderId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Folders&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Folders&gt;"/></returns>
		public static TList<Folders> Fill(IDataReader reader, TList<Folders> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Folders c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Folders")
					.Append("|").Append((System.Int32)reader[((int)FoldersColumn.FolderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Folders>(
					key.ToString(), // EntityTrackingKey
					"Folders",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Folders();
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
					c.FolderId = (System.Int32)reader[((int)FoldersColumn.FolderId - 1)];
					c.ParentFolderId = (System.Int32)reader[((int)FoldersColumn.ParentFolderId - 1)];
					c.SiteId = (System.Int32)reader[((int)FoldersColumn.SiteId - 1)];
					c.FolderName = (System.String)reader[((int)FoldersColumn.FolderName - 1)];
					c.SourceId = (reader.IsDBNull(((int)FoldersColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)FoldersColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Folders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Folders"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Folders entity)
		{
			if (!reader.Read()) return;
			
			entity.FolderId = (System.Int32)reader[((int)FoldersColumn.FolderId - 1)];
			entity.ParentFolderId = (System.Int32)reader[((int)FoldersColumn.ParentFolderId - 1)];
			entity.SiteId = (System.Int32)reader[((int)FoldersColumn.SiteId - 1)];
			entity.FolderName = (System.String)reader[((int)FoldersColumn.FolderName - 1)];
			entity.SourceId = (reader.IsDBNull(((int)FoldersColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)FoldersColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Folders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Folders"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Folders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FolderId = (System.Int32)dataRow["FolderID"];
			entity.ParentFolderId = (System.Int32)dataRow["ParentFolderID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.FolderName = (System.String)dataRow["FolderName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Folders"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Folders Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Folders entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
			// Deep load child collections  - Call GetByFolderId methods when available
			
			#region FilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Files>|FilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FilesCollection = DataRepository.FilesProvider.GetByFolderId(transactionManager, entity.FolderId);

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Folders object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Folders instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Folders Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Folders entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
			#region List<Files>
				if (CanDeepSave(entity.FilesCollection, "List<Files>|FilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Files child in entity.FilesCollection)
					{
						if(child.FolderIdSource != null)
						{
							child.FolderId = child.FolderIdSource.FolderId;
						}
						else
						{
							child.FolderId = entity.FolderId;
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
	
	#region FoldersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Folders</c>
	///</summary>
	public enum FoldersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>Folders</c> as OneToMany for FilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Files>))]
		FilesCollection,
	}
	
	#endregion FoldersChildEntityTypes
	
	#region FoldersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FoldersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersFilterBuilder : SqlFilterBuilder<FoldersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersFilterBuilder class.
		/// </summary>
		public FoldersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FoldersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FoldersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FoldersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FoldersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FoldersFilterBuilder
	
	#region FoldersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FoldersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersParameterBuilder : ParameterizedSqlFilterBuilder<FoldersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersParameterBuilder class.
		/// </summary>
		public FoldersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FoldersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FoldersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FoldersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FoldersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FoldersParameterBuilder
	
	#region FoldersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FoldersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FoldersSortBuilder : SqlSortBuilder<FoldersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersSqlSortBuilder class.
		/// </summary>
		public FoldersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FoldersSortBuilder
	
} // end namespace
