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
	/// This class is the base class for any <see cref="FilesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FilesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Files, JXTPortal.Entities.FilesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.FilesKey key)
		{
			return Delete(transactionManager, key.FileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_fileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _fileId)
		{
			return Delete(null, _fileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _fileId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		FK_Files_AdminUsers Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		FK_Files_AdminUsers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		/// <remarks></remarks>
		public TList<Files> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		FK_Files_AdminUsers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		fkFilesAdminUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		fkFilesAdminUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_AdminUsers key.
		///		FK_Files_AdminUsers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public abstract TList<Files> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		FK_Files_FileTypes Description: 
		/// </summary>
		/// <param name="_fileTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFileTypeId(System.Int32 _fileTypeId)
		{
			int count = -1;
			return GetByFileTypeId(_fileTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		FK_Files_FileTypes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		/// <remarks></remarks>
		public TList<Files> GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId)
		{
			int count = -1;
			return GetByFileTypeId(transactionManager, _fileTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		FK_Files_FileTypes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileTypeId(transactionManager, _fileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		fkFilesFileTypes Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fileTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFileTypeId(System.Int32 _fileTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFileTypeId(null, _fileTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		fkFilesFileTypes Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_fileTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFileTypeId(System.Int32 _fileTypeId, int start, int pageLength,out int count)
		{
			return GetByFileTypeId(null, _fileTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_FileTypes key.
		///		FK_Files_FileTypes Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public abstract TList<Files> GetByFileTypeId(TransactionManager transactionManager, System.Int32 _fileTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		FK_Files_Folders Description: 
		/// </summary>
		/// <param name="_folderId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFolderId(System.Int32 _folderId)
		{
			int count = -1;
			return GetByFolderId(_folderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		FK_Files_Folders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		/// <remarks></remarks>
		public TList<Files> GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId)
		{
			int count = -1;
			return GetByFolderId(transactionManager, _folderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		FK_Files_Folders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId, int start, int pageLength)
		{
			int count = -1;
			return GetByFolderId(transactionManager, _folderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		fkFilesFolders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_folderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFolderId(System.Int32 _folderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFolderId(null, _folderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		fkFilesFolders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_folderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetByFolderId(System.Int32 _folderId, int start, int pageLength,out int count)
		{
			return GetByFolderId(null, _folderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Folders key.
		///		FK_Files_Folders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public abstract TList<Files> GetByFolderId(TransactionManager transactionManager, System.Int32 _folderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		FK_Files_Sites Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		FK_Files_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		/// <remarks></remarks>
		public TList<Files> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		FK_Files_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		fkFilesSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		fkFilesSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public TList<Files> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Files_Sites key.
		///		FK_Files_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Files objects.</returns>
		public abstract TList<Files> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Files Get(TransactionManager transactionManager, JXTPortal.Entities.FilesKey key, int start, int pageLength)
		{
			return GetByFileId(transactionManager, key.FileId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Files index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(System.Int32 _folderId, System.Int32 _siteId, System.String _fileName)
		{
			int count = -1;
			return GetByFolderIdSiteIdFileName(null,_folderId, _siteId, _fileName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Files index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(System.Int32 _folderId, System.Int32 _siteId, System.String _fileName, int start, int pageLength)
		{
			int count = -1;
			return GetByFolderIdSiteIdFileName(null, _folderId, _siteId, _fileName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Files index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(TransactionManager transactionManager, System.Int32 _folderId, System.Int32 _siteId, System.String _fileName)
		{
			int count = -1;
			return GetByFolderIdSiteIdFileName(transactionManager, _folderId, _siteId, _fileName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Files index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(TransactionManager transactionManager, System.Int32 _folderId, System.Int32 _siteId, System.String _fileName, int start, int pageLength)
		{
			int count = -1;
			return GetByFolderIdSiteIdFileName(transactionManager, _folderId, _siteId, _fileName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Files index.
		/// </summary>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(System.Int32 _folderId, System.Int32 _siteId, System.String _fileName, int start, int pageLength, out int count)
		{
			return GetByFolderIdSiteIdFileName(null, _folderId, _siteId, _fileName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Files index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_folderId"></param>
		/// <param name="_siteId"></param>
		/// <param name="_fileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public abstract JXTPortal.Entities.Files GetByFolderIdSiteIdFileName(TransactionManager transactionManager, System.Int32 _folderId, System.Int32 _siteId, System.String _fileName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="_fileId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFileId(System.Int32 _fileId)
		{
			int count = -1;
			return GetByFileId(null,_fileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFileId(System.Int32 _fileId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileId(null, _fileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFileId(TransactionManager transactionManager, System.Int32 _fileId)
		{
			int count = -1;
			return GetByFileId(transactionManager, _fileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFileId(TransactionManager transactionManager, System.Int32 _fileId, int start, int pageLength)
		{
			int count = -1;
			return GetByFileId(transactionManager, _fileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public JXTPortal.Entities.Files GetByFileId(System.Int32 _fileId, int start, int pageLength, out int count)
		{
			return GetByFileId(null, _fileId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Files__1CF15040 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_fileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Files"/> class.</returns>
		public abstract JXTPortal.Entities.Files GetByFileId(TransactionManager transactionManager, System.Int32 _fileId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Files_Insert 
		
		/// <summary>
		///	This method wrap the 'Files_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? fileId)
		{
			 Insert(null, 0, int.MaxValue , siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId, ref fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? fileId)
		{
			 Insert(null, start, pageLength , siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId, ref fileId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? fileId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId, ref fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId, ref System.Int32? fileId);
		
		#endregion
		
		#region Files_GetByFolderIdSiteIdFileName 
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderIdSiteIdFileName' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderIdSiteIdFileName(System.Int32? folderId, System.Int32? siteId, System.String fileName)
		{
			return GetByFolderIdSiteIdFileName(null, 0, int.MaxValue , folderId, siteId, fileName);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderIdSiteIdFileName' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderIdSiteIdFileName(int start, int pageLength, System.Int32? folderId, System.Int32? siteId, System.String fileName)
		{
			return GetByFolderIdSiteIdFileName(null, start, pageLength , folderId, siteId, fileName);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetByFolderIdSiteIdFileName' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderIdSiteIdFileName(TransactionManager transactionManager, System.Int32? folderId, System.Int32? siteId, System.String fileName)
		{
			return GetByFolderIdSiteIdFileName(transactionManager, 0, int.MaxValue , folderId, siteId, fileName);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderIdSiteIdFileName' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetByFolderIdSiteIdFileName(TransactionManager transactionManager, int start, int pageLength , System.Int32? folderId, System.Int32? siteId, System.String fileName);
		
		#endregion
		
		#region Files_GetByFileId 
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileId(System.Int32? fileId)
		{
			return GetByFileId(null, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileId(int start, int pageLength, System.Int32? fileId)
		{
			return GetByFileId(null, start, pageLength , fileId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileId(TransactionManager transactionManager, System.Int32? fileId)
		{
			return GetByFileId(transactionManager, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileId' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetByFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileId);
		
		#endregion
		
		#region Files_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Files_Get_List 
		
		/// <summary>
		///	This method wrap the 'Files_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Files_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Files_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Files_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Files_GetBySiteIDPageNameFileTypeID 
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteIDPageNameFileTypeID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteIDPageNameFileTypeID(System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			return GetBySiteIDPageNameFileTypeID(null, 0, int.MaxValue , siteId, pageName, fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteIDPageNameFileTypeID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteIDPageNameFileTypeID(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			return GetBySiteIDPageNameFileTypeID(null, start, pageLength , siteId, pageName, fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetBySiteIDPageNameFileTypeID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetBySiteIDPageNameFileTypeID(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? fileTypeId)
		{
			return GetBySiteIDPageNameFileTypeID(transactionManager, 0, int.MaxValue , siteId, pageName, fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetBySiteIDPageNameFileTypeID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetBySiteIDPageNameFileTypeID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? fileTypeId);
		
		#endregion
		
		#region Files_GetByFolderId 
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderId(System.Int32? folderId)
		{
			return GetByFolderId(null, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderId(int start, int pageLength, System.Int32? folderId)
		{
			return GetByFolderId(null, start, pageLength , folderId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFolderId(TransactionManager transactionManager, System.Int32? folderId)
		{
			return GetByFolderId(transactionManager, 0, int.MaxValue , folderId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFolderId' stored procedure. 
		/// </summary>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetByFolderId(TransactionManager transactionManager, int start, int pageLength , System.Int32? folderId);
		
		#endregion
		
		#region Files_Update 
		
		/// <summary>
		///	This method wrap the 'Files_Update' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Update' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_Update' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Update' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region Files_Find 
		
		/// <summary>
		///	This method wrap the 'Files_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Find(System.Boolean? searchUsingOr, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, fileId, siteId, folderId, fileName, fileSystemName, fileTypeId, lastModified, lastModifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="folderId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fileName"> A <c>System.String</c> instance.</param>
		/// <param name="fileSystemName"> A <c>System.String</c> instance.</param>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? fileId, System.Int32? siteId, System.Int32? folderId, System.String fileName, System.String fileSystemName, System.Int32? fileTypeId, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region Files_Delete 
		
		/// <summary>
		///	This method wrap the 'Files_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? fileId)
		{
			 Delete(null, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? fileId)
		{
			 Delete(null, start, pageLength , fileId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? fileId)
		{
			 Delete(transactionManager, 0, int.MaxValue , fileId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_Delete' stored procedure. 
		/// </summary>
		/// <param name="fileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileId);
		
		#endregion
		
		#region Files_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Files_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Files_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'Files_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region Files_GetByFileTypeId 
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileTypeId(System.Int32? fileTypeId)
		{
			return GetByFileTypeId(null, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileTypeId(int start, int pageLength, System.Int32? fileTypeId)
		{
			return GetByFileTypeId(null, start, pageLength , fileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Files_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public TList<Files> GetByFileTypeId(TransactionManager transactionManager, System.Int32? fileTypeId)
		{
			return GetByFileTypeId(transactionManager, 0, int.MaxValue , fileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Files_GetByFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="fileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Files&gt;"/> instance.</returns>
		public abstract TList<Files> GetByFileTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? fileTypeId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Files&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Files&gt;"/></returns>
		public static TList<Files> Fill(IDataReader reader, TList<Files> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Files c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Files")
					.Append("|").Append((System.Int32)reader[((int)FilesColumn.FileId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Files>(
					key.ToString(), // EntityTrackingKey
					"Files",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Files();
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
					c.FileId = (System.Int32)reader[((int)FilesColumn.FileId - 1)];
					c.SiteId = (System.Int32)reader[((int)FilesColumn.SiteId - 1)];
					c.FolderId = (System.Int32)reader[((int)FilesColumn.FolderId - 1)];
					c.FileName = (System.String)reader[((int)FilesColumn.FileName - 1)];
					c.FileSystemName = (System.String)reader[((int)FilesColumn.FileSystemName - 1)];
					c.FileTypeId = (System.Int32)reader[((int)FilesColumn.FileTypeId - 1)];
					c.LastModified = (System.DateTime)reader[((int)FilesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)FilesColumn.LastModifiedBy - 1)];
					c.SourceId = (reader.IsDBNull(((int)FilesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)FilesColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Files"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Files"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Files entity)
		{
			if (!reader.Read()) return;
			
			entity.FileId = (System.Int32)reader[((int)FilesColumn.FileId - 1)];
			entity.SiteId = (System.Int32)reader[((int)FilesColumn.SiteId - 1)];
			entity.FolderId = (System.Int32)reader[((int)FilesColumn.FolderId - 1)];
			entity.FileName = (System.String)reader[((int)FilesColumn.FileName - 1)];
			entity.FileSystemName = (System.String)reader[((int)FilesColumn.FileSystemName - 1)];
			entity.FileTypeId = (System.Int32)reader[((int)FilesColumn.FileTypeId - 1)];
			entity.LastModified = (System.DateTime)reader[((int)FilesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)FilesColumn.LastModifiedBy - 1)];
			entity.SourceId = (reader.IsDBNull(((int)FilesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)FilesColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Files"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Files"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Files entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FileId = (System.Int32)dataRow["FileID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.FolderId = (System.Int32)dataRow["FolderID"];
			entity.FileName = (System.String)dataRow["FileName"];
			entity.FileSystemName = (System.String)dataRow["FileSystemName"];
			entity.FileTypeId = (System.Int32)dataRow["FileTypeID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Files"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Files Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Files entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region FileTypeIdSource	
			if (CanDeepLoad(entity, "FileTypes|FileTypeIdSource", deepLoadType, innerList) 
				&& entity.FileTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FileTypeId;
				FileTypes tmpEntity = EntityManager.LocateEntity<FileTypes>(EntityLocator.ConstructKeyFromPkItems(typeof(FileTypes), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FileTypeIdSource = tmpEntity;
				else
					entity.FileTypeIdSource = DataRepository.FileTypesProvider.GetByFileTypeId(transactionManager, entity.FileTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FileTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FileTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FileTypesProvider.DeepLoad(transactionManager, entity.FileTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FileTypeIdSource

			#region FolderIdSource	
			if (CanDeepLoad(entity, "Folders|FolderIdSource", deepLoadType, innerList) 
				&& entity.FolderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FolderId;
				Folders tmpEntity = EntityManager.LocateEntity<Folders>(EntityLocator.ConstructKeyFromPkItems(typeof(Folders), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FolderIdSource = tmpEntity;
				else
					entity.FolderIdSource = DataRepository.FoldersProvider.GetByFolderId(transactionManager, entity.FolderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FolderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FolderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FoldersProvider.DeepLoad(transactionManager, entity.FolderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FolderIdSource

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
			// Deep load child collections  - Call GetByFileId methods when available
			
			#region DynamicPageFilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageFiles>|DynamicPageFilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageFilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageFilesCollection = DataRepository.DynamicPageFilesProvider.GetByFileId(transactionManager, entity.FileId);

				if (deep && entity.DynamicPageFilesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageFilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageFiles>) DataRepository.DynamicPageFilesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageFilesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region GlobalSettingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalSettings>|GlobalSettingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalSettingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetBySiteFavIconId(transactionManager, entity.FileId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DefaultResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DefaultResources>|DefaultResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DefaultResourcesCollection = DataRepository.DefaultResourcesProvider.GetByResourceFileId(transactionManager, entity.FileId);

				if (deep && entity.DefaultResourcesCollection.Count > 0)
				{
					deepHandles.Add("DefaultResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DefaultResources>) DataRepository.DefaultResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.DefaultResourcesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollection = DataRepository.SiteResourcesProvider.GetByResourceFileId(transactionManager, entity.FileId);

				if (deep && entity.SiteResourcesCollection.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Files object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Files instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Files Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Files entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region FileTypeIdSource
			if (CanDeepSave(entity, "FileTypes|FileTypeIdSource", deepSaveType, innerList) 
				&& entity.FileTypeIdSource != null)
			{
				DataRepository.FileTypesProvider.Save(transactionManager, entity.FileTypeIdSource);
				entity.FileTypeId = entity.FileTypeIdSource.FileTypeId;
			}
			#endregion 
			
			#region FolderIdSource
			if (CanDeepSave(entity, "Folders|FolderIdSource", deepSaveType, innerList) 
				&& entity.FolderIdSource != null)
			{
				DataRepository.FoldersProvider.Save(transactionManager, entity.FolderIdSource);
				entity.FolderId = entity.FolderIdSource.FolderId;
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
	
			#region List<DynamicPageFiles>
				if (CanDeepSave(entity.DynamicPageFilesCollection, "List<DynamicPageFiles>|DynamicPageFilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageFiles child in entity.DynamicPageFilesCollection)
					{
						if(child.FileIdSource != null)
						{
							child.FileId = child.FileIdSource.FileId;
						}
						else
						{
							child.FileId = entity.FileId;
						}

					}

					if (entity.DynamicPageFilesCollection.Count > 0 || entity.DynamicPageFilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageFilesProvider.Save(transactionManager, entity.DynamicPageFilesCollection);
						
						deepHandles.Add("DynamicPageFilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageFiles >) DataRepository.DynamicPageFilesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageFilesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<GlobalSettings>
				if (CanDeepSave(entity.GlobalSettingsCollection, "List<GlobalSettings>|GlobalSettingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalSettings child in entity.GlobalSettingsCollection)
					{
						if(child.SiteFavIconIdSource != null)
						{
							child.SiteFavIconId = child.SiteFavIconIdSource.FileId;
						}
						else
						{
							child.SiteFavIconId = entity.FileId;
						}

					}

					if (entity.GlobalSettingsCollection.Count > 0 || entity.GlobalSettingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalSettingsProvider.Save(transactionManager, entity.GlobalSettingsCollection);
						
						deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalSettings >) DataRepository.GlobalSettingsProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalSettingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DefaultResources>
				if (CanDeepSave(entity.DefaultResourcesCollection, "List<DefaultResources>|DefaultResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DefaultResources child in entity.DefaultResourcesCollection)
					{
						if(child.ResourceFileIdSource != null)
						{
							child.ResourceFileId = child.ResourceFileIdSource.FileId;
						}
						else
						{
							child.ResourceFileId = entity.FileId;
						}

					}

					if (entity.DefaultResourcesCollection.Count > 0 || entity.DefaultResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DefaultResourcesProvider.Save(transactionManager, entity.DefaultResourcesCollection);
						
						deepHandles.Add("DefaultResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DefaultResources >) DataRepository.DefaultResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.DefaultResourcesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollection, "List<SiteResources>|SiteResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollection)
					{
						if(child.ResourceFileIdSource != null)
						{
							child.ResourceFileId = child.ResourceFileIdSource.FileId;
						}
						else
						{
							child.ResourceFileId = entity.FileId;
						}

					}

					if (entity.SiteResourcesCollection.Count > 0 || entity.SiteResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollection);
						
						deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollection, deepSaveType, childTypes, innerList }
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
	
	#region FilesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Files</c>
	///</summary>
	public enum FilesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>FileTypes</c> at FileTypeIdSource
		///</summary>
		[ChildEntityType(typeof(FileTypes))]
		FileTypes,
			
		///<summary>
		/// Composite Property for <c>Folders</c> at FolderIdSource
		///</summary>
		[ChildEntityType(typeof(Folders))]
		Folders,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>Files</c> as OneToMany for DynamicPageFilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageFiles>))]
		DynamicPageFilesCollection,

		///<summary>
		/// Collection of <c>Files</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,

		///<summary>
		/// Collection of <c>Files</c> as OneToMany for DefaultResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DefaultResources>))]
		DefaultResourcesCollection,

		///<summary>
		/// Collection of <c>Files</c> as OneToMany for SiteResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResources>))]
		SiteResourcesCollection,
	}
	
	#endregion FilesChildEntityTypes
	
	#region FilesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesFilterBuilder : SqlFilterBuilder<FilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesFilterBuilder class.
		/// </summary>
		public FilesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FilesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FilesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FilesFilterBuilder
	
	#region FilesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesParameterBuilder : ParameterizedSqlFilterBuilder<FilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesParameterBuilder class.
		/// </summary>
		public FilesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FilesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FilesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FilesParameterBuilder
	
	#region FilesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FilesSortBuilder : SqlSortBuilder<FilesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesSqlSortBuilder class.
		/// </summary>
		public FilesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FilesSortBuilder
	
} // end namespace
