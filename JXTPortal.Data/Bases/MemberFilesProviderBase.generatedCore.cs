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
	/// This class is the base class for any <see cref="MemberFilesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberFilesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberFiles, JXTPortal.Entities.MemberFilesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberFilesKey key)
		{
			return Delete(transactionManager, key.MemberFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberFileId)
		{
			return Delete(null, _memberFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberFileId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		FK__MemberFil__Membe__76969D2E Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		FK__MemberFil__Membe__76969D2E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		/// <remarks></remarks>
		public TList<MemberFiles> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		FK__MemberFil__Membe__76969D2E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		fkMemberFilMembe76969d2e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		fkMemberFilMembe76969d2e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__76969D2E key.
		///		FK__MemberFil__Membe__76969D2E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public abstract TList<MemberFiles> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		FK__MemberFil__Membe__778AC167 Description: 
		/// </summary>
		/// <param name="_memberFileTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(System.Int32 _memberFileTypeId)
		{
			int count = -1;
			return GetByMemberFileTypeId(_memberFileTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		FK__MemberFil__Membe__778AC167 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		/// <remarks></remarks>
		public TList<MemberFiles> GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId)
		{
			int count = -1;
			return GetByMemberFileTypeId(transactionManager, _memberFileTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		FK__MemberFil__Membe__778AC167 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberFileTypeId(transactionManager, _memberFileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		fkMemberFilMembe778Ac167 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberFileTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(System.Int32 _memberFileTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberFileTypeId(null, _memberFileTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		fkMemberFilMembe778Ac167 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(System.Int32 _memberFileTypeId, int start, int pageLength,out int count)
		{
			return GetByMemberFileTypeId(null, _memberFileTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberFil__Membe__778AC167 key.
		///		FK__MemberFil__Membe__778AC167 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberFiles objects.</returns>
		public abstract TList<MemberFiles> GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberFiles Get(TransactionManager transactionManager, JXTPortal.Entities.MemberFilesKey key, int start, int pageLength)
		{
			return GetByMemberFileId(transactionManager, key.MemberFileId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(System.Int32 _memberId, System.String _memberFileName)
		{
			int count = -1;
			return GetByMemberIdMemberFileName(null,_memberId, _memberFileName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(System.Int32 _memberId, System.String _memberFileName, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberIdMemberFileName(null, _memberId, _memberFileName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(TransactionManager transactionManager, System.Int32 _memberId, System.String _memberFileName)
		{
			int count = -1;
			return GetByMemberIdMemberFileName(transactionManager, _memberId, _memberFileName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(TransactionManager transactionManager, System.Int32 _memberId, System.String _memberFileName, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberIdMemberFileName(transactionManager, _memberId, _memberFileName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(System.Int32 _memberId, System.String _memberFileName, int start, int pageLength, out int count)
		{
			return GetByMemberIdMemberFileName(null, _memberId, _memberFileName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_MemberFiles index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="_memberFileName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public abstract JXTPortal.Entities.MemberFiles GetByMemberIdMemberFileName(TransactionManager transactionManager, System.Int32 _memberId, System.String _memberFileName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="_memberFileId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberFileId(System.Int32 _memberFileId)
		{
			int count = -1;
			return GetByMemberFileId(null,_memberFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="_memberFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberFileId(System.Int32 _memberFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberFileId(null, _memberFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberFileId(TransactionManager transactionManager, System.Int32 _memberFileId)
		{
			int count = -1;
			return GetByMemberFileId(transactionManager, _memberFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberFileId(TransactionManager transactionManager, System.Int32 _memberFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberFileId(transactionManager, _memberFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="_memberFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public JXTPortal.Entities.MemberFiles GetByMemberFileId(System.Int32 _memberFileId, int start, int pageLength, out int count)
		{
			return GetByMemberFileId(null, _memberFileId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFiles__267ABA7A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFiles"/> class.</returns>
		public abstract JXTPortal.Entities.MemberFiles GetByMemberFileId(TransactionManager transactionManager, System.Int32 _memberFileId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberFiles_GetByMemberFileId 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileId' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileId(System.Int32? memberFileId)
		{
			return GetByMemberFileId(null, 0, int.MaxValue , memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileId' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileId(int start, int pageLength, System.Int32? memberFileId)
		{
			return GetByMemberFileId(null, start, pageLength , memberFileId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileId' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileId(TransactionManager transactionManager, System.Int32? memberFileId)
		{
			return GetByMemberFileId(transactionManager, 0, int.MaxValue , memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileId' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> GetByMemberFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileId);
		
		#endregion
		
		#region MemberFiles_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId, ref System.Int32? memberFileId)
		{
			 Insert(null, 0, int.MaxValue , memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId, ref memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId, ref System.Int32? memberFileId)
		{
			 Insert(null, start, pageLength , memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId, ref memberFileId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId, ref System.Int32? memberFileId)
		{
			 Insert(transactionManager, 0, int.MaxValue , memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId, ref memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId, ref System.Int32? memberFileId);
		
		#endregion
		
		#region MemberFiles_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region MemberFiles_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberFiles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region MemberFiles_Update 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			 Update(null, 0, int.MaxValue , memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			 Update(null, start, pageLength , memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			 Update(transactionManager, 0, int.MaxValue , memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId);
		
		#endregion
		
		#region MemberFiles_Find 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Find(System.Boolean? searchUsingOr, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			return Find(null, start, pageLength , searchUsingOr, memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberFileId, memberId, memberFileTypeId, memberFileName, memberFileSearchExtension, memberFileContent, memberFileTitle, lastModifiedDate, documentTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileSearchExtension"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileContent"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="memberFileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="documentTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberFileId, System.Int32? memberId, System.Int32? memberFileTypeId, System.String memberFileName, System.String memberFileSearchExtension, System.Byte[] memberFileContent, System.String memberFileTitle, System.DateTime? lastModifiedDate, System.Int32? documentTypeId);
		
		#endregion
		
		#region MemberFiles_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberFileId)
		{
			 Delete(null, 0, int.MaxValue , memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberFileId)
		{
			 Delete(null, start, pageLength , memberFileId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberFileId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberFileId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileId);
		
		#endregion
		
		#region MemberFiles_GetPagingByMemberId 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPagingByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByMemberId(System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByMemberId(null, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPagingByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByMemberId(int start, int pageLength, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByMemberId(null, start, pageLength , memberId, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPagingByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByMemberId(TransactionManager transactionManager, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByMemberId(transactionManager, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetPagingByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetPagingByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region MemberFiles_GetByMemberIdMemberFileName 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberIdMemberFileName' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberIdMemberFileName(System.Int32? memberId, System.String memberFileName)
		{
			return GetByMemberIdMemberFileName(null, 0, int.MaxValue , memberId, memberFileName);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberIdMemberFileName' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberIdMemberFileName(int start, int pageLength, System.Int32? memberId, System.String memberFileName)
		{
			return GetByMemberIdMemberFileName(null, start, pageLength , memberId, memberFileName);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberIdMemberFileName' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberIdMemberFileName(TransactionManager transactionManager, System.Int32? memberId, System.String memberFileName)
		{
			return GetByMemberIdMemberFileName(transactionManager, 0, int.MaxValue , memberId, memberFileName);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberIdMemberFileName' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> GetByMemberIdMemberFileName(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.String memberFileName);
		
		#endregion
		
		#region MemberFiles_GetByMemberFileTypeId 
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(null, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(int start, int pageLength, System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(null, start, pageLength , memberFileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public TList<MemberFiles> GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(transactionManager, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFiles_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFiles&gt;"/> instance.</returns>
		public abstract TList<MemberFiles> GetByMemberFileTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileTypeId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberFiles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberFiles&gt;"/></returns>
		public static TList<MemberFiles> Fill(IDataReader reader, TList<MemberFiles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberFiles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberFiles")
					.Append("|").Append((System.Int32)reader[((int)MemberFilesColumn.MemberFileId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberFiles>(
					key.ToString(), // EntityTrackingKey
					"MemberFiles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberFiles();
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
					c.MemberFileId = (System.Int32)reader[((int)MemberFilesColumn.MemberFileId - 1)];
					c.MemberId = (System.Int32)reader[((int)MemberFilesColumn.MemberId - 1)];
					c.MemberFileTypeId = (System.Int32)reader[((int)MemberFilesColumn.MemberFileTypeId - 1)];
					c.MemberFileName = (System.String)reader[((int)MemberFilesColumn.MemberFileName - 1)];
					c.MemberFileSearchExtension = (reader.IsDBNull(((int)MemberFilesColumn.MemberFileSearchExtension - 1)))?null:(System.String)reader[((int)MemberFilesColumn.MemberFileSearchExtension - 1)];
					c.MemberFileContent = (reader.IsDBNull(((int)MemberFilesColumn.MemberFileContent - 1)))?null:(System.Byte[])reader[((int)MemberFilesColumn.MemberFileContent - 1)];
					c.MemberFileTitle = (System.String)reader[((int)MemberFilesColumn.MemberFileTitle - 1)];
					c.LastModifiedDate = (System.DateTime)reader[((int)MemberFilesColumn.LastModifiedDate - 1)];
					c.DocumentTypeId = (reader.IsDBNull(((int)MemberFilesColumn.DocumentTypeId - 1)))?null:(System.Int32?)reader[((int)MemberFilesColumn.DocumentTypeId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberFiles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFiles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberFiles entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberFileId = (System.Int32)reader[((int)MemberFilesColumn.MemberFileId - 1)];
			entity.MemberId = (System.Int32)reader[((int)MemberFilesColumn.MemberId - 1)];
			entity.MemberFileTypeId = (System.Int32)reader[((int)MemberFilesColumn.MemberFileTypeId - 1)];
			entity.MemberFileName = (System.String)reader[((int)MemberFilesColumn.MemberFileName - 1)];
			entity.MemberFileSearchExtension = (reader.IsDBNull(((int)MemberFilesColumn.MemberFileSearchExtension - 1)))?null:(System.String)reader[((int)MemberFilesColumn.MemberFileSearchExtension - 1)];
			entity.MemberFileContent = (reader.IsDBNull(((int)MemberFilesColumn.MemberFileContent - 1)))?null:(System.Byte[])reader[((int)MemberFilesColumn.MemberFileContent - 1)];
			entity.MemberFileTitle = (System.String)reader[((int)MemberFilesColumn.MemberFileTitle - 1)];
			entity.LastModifiedDate = (System.DateTime)reader[((int)MemberFilesColumn.LastModifiedDate - 1)];
			entity.DocumentTypeId = (reader.IsDBNull(((int)MemberFilesColumn.DocumentTypeId - 1)))?null:(System.Int32?)reader[((int)MemberFilesColumn.DocumentTypeId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberFiles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFiles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberFiles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberFileId = (System.Int32)dataRow["MemberFileID"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.MemberFileTypeId = (System.Int32)dataRow["MemberFileTypeID"];
			entity.MemberFileName = (System.String)dataRow["MemberFileName"];
			entity.MemberFileSearchExtension = Convert.IsDBNull(dataRow["MemberFileSearchExtension"]) ? null : (System.String)dataRow["MemberFileSearchExtension"];
			entity.MemberFileContent = Convert.IsDBNull(dataRow["MemberFileContent"]) ? null : (System.Byte[])dataRow["MemberFileContent"];
			entity.MemberFileTitle = (System.String)dataRow["MemberFileTitle"];
			entity.LastModifiedDate = (System.DateTime)dataRow["LastModifiedDate"];
			entity.DocumentTypeId = Convert.IsDBNull(dataRow["DocumentTypeID"]) ? null : (System.Int32?)dataRow["DocumentTypeID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFiles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberFiles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberFiles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MemberIdSource	
			if (CanDeepLoad(entity, "Members|MemberIdSource", deepLoadType, innerList) 
				&& entity.MemberIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MemberId;
				Members tmpEntity = EntityManager.LocateEntity<Members>(EntityLocator.ConstructKeyFromPkItems(typeof(Members), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MemberIdSource = tmpEntity;
				else
					entity.MemberIdSource = DataRepository.MembersProvider.GetByMemberId(transactionManager, entity.MemberId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MemberIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MembersProvider.DeepLoad(transactionManager, entity.MemberIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MemberIdSource

			#region MemberFileTypeIdSource	
			if (CanDeepLoad(entity, "MemberFileTypes|MemberFileTypeIdSource", deepLoadType, innerList) 
				&& entity.MemberFileTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MemberFileTypeId;
				MemberFileTypes tmpEntity = EntityManager.LocateEntity<MemberFileTypes>(EntityLocator.ConstructKeyFromPkItems(typeof(MemberFileTypes), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MemberFileTypeIdSource = tmpEntity;
				else
					entity.MemberFileTypeIdSource = DataRepository.MemberFileTypesProvider.GetByMemberFileTypeId(transactionManager, entity.MemberFileTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberFileTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MemberFileTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MemberFileTypesProvider.DeepLoad(transactionManager, entity.MemberFileTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MemberFileTypeIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberFiles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberFiles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberFiles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberFiles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MemberIdSource
			if (CanDeepSave(entity, "Members|MemberIdSource", deepSaveType, innerList) 
				&& entity.MemberIdSource != null)
			{
				DataRepository.MembersProvider.Save(transactionManager, entity.MemberIdSource);
				entity.MemberId = entity.MemberIdSource.MemberId;
			}
			#endregion 
			
			#region MemberFileTypeIdSource
			if (CanDeepSave(entity, "MemberFileTypes|MemberFileTypeIdSource", deepSaveType, innerList) 
				&& entity.MemberFileTypeIdSource != null)
			{
				DataRepository.MemberFileTypesProvider.Save(transactionManager, entity.MemberFileTypeIdSource);
				entity.MemberFileTypeId = entity.MemberFileTypeIdSource.MemberFileTypeId;
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
	
	#region MemberFilesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberFiles</c>
	///</summary>
	public enum MemberFilesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
			
		///<summary>
		/// Composite Property for <c>MemberFileTypes</c> at MemberFileTypeIdSource
		///</summary>
		[ChildEntityType(typeof(MemberFileTypes))]
		MemberFileTypes,
		}
	
	#endregion MemberFilesChildEntityTypes
	
	#region MemberFilesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesFilterBuilder : SqlFilterBuilder<MemberFilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilterBuilder class.
		/// </summary>
		public MemberFilesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFilesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFilesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFilesFilterBuilder
	
	#region MemberFilesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesParameterBuilder : ParameterizedSqlFilterBuilder<MemberFilesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesParameterBuilder class.
		/// </summary>
		public MemberFilesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFilesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFilesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFilesParameterBuilder
	
	#region MemberFilesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberFilesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberFilesSortBuilder : SqlSortBuilder<MemberFilesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesSqlSortBuilder class.
		/// </summary>
		public MemberFilesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberFilesSortBuilder
	
} // end namespace
