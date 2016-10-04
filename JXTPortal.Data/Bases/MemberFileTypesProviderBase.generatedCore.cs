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
	/// This class is the base class for any <see cref="MemberFileTypesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberFileTypesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberFileTypes, JXTPortal.Entities.MemberFileTypesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberFileTypesKey key)
		{
			return Delete(transactionManager, key.MemberFileTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberFileTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberFileTypeId)
		{
			return Delete(null, _memberFileTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberFileTypeId);		
		
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
		public override JXTPortal.Entities.MemberFileTypes Get(TransactionManager transactionManager, JXTPortal.Entities.MemberFileTypesKey key, int start, int pageLength)
		{
			return GetByMemberFileTypeId(transactionManager, key.MemberFileTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="_memberFileTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(System.Int32 _memberFileTypeId)
		{
			int count = -1;
			return GetByMemberFileTypeId(null,_memberFileTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(System.Int32 _memberFileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberFileTypeId(null, _memberFileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId)
		{
			int count = -1;
			return GetByMemberFileTypeId(transactionManager, _memberFileTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberFileTypeId(transactionManager, _memberFileTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(System.Int32 _memberFileTypeId, int start, int pageLength, out int count)
		{
			return GetByMemberFileTypeId(null, _memberFileTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberFileTypes__286302EC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberFileTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberFileTypes"/> class.</returns>
		public abstract JXTPortal.Entities.MemberFileTypes GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32 _memberFileTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberFileTypes_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public abstract TList<MemberFileTypes> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region MemberFileTypes_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberFileTypeId)
		{
			 Delete(null, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberFileTypeId)
		{
			 Delete(null, start, pageLength , memberFileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberFileTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileTypeId);
		
		#endregion
		
		#region MemberFileTypes_Update 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			 Update(null, 0, int.MaxValue , memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			 Update(null, start, pageLength , memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			 Update(transactionManager, 0, int.MaxValue , memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Update' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions);
		
		#endregion
		
		#region MemberFileTypes_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
			/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String memberFileTypeName, System.String memberFileExtensions, ref System.Int32? memberFileTypeId)
		{
			 Insert(null, 0, int.MaxValue , memberFileTypeName, memberFileExtensions, ref memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
			/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String memberFileTypeName, System.String memberFileExtensions, ref System.Int32? memberFileTypeId)
		{
			 Insert(null, start, pageLength , memberFileTypeName, memberFileExtensions, ref memberFileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
			/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String memberFileTypeName, System.String memberFileExtensions, ref System.Int32? memberFileTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , memberFileTypeName, memberFileExtensions, ref memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
			/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String memberFileTypeName, System.String memberFileExtensions, ref System.Int32? memberFileTypeId);
		
		#endregion
		
		#region MemberFileTypes_GetByMemberFileTypeId 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetByMemberFileTypeId(System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(null, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetByMemberFileTypeId(int start, int pageLength, System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(null, start, pageLength , memberFileTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> GetByMemberFileTypeId(TransactionManager transactionManager, System.Int32? memberFileTypeId)
		{
			return GetByMemberFileTypeId(transactionManager, 0, int.MaxValue , memberFileTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_GetByMemberFileTypeId' stored procedure. 
		/// </summary>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public abstract TList<MemberFileTypes> GetByMemberFileTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberFileTypeId);
		
		#endregion
		
		#region MemberFileTypes_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public abstract TList<MemberFileTypes> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberFileTypes_Find 
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Find(System.Boolean? searchUsingOr, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			return Find(null, start, pageLength , searchUsingOr, memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
				
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public TList<MemberFileTypes> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberFileTypeId, memberFileTypeName, memberFileExtensions);
		}
		
		/// <summary>
		///	This method wrap the 'MemberFileTypes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberFileTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberFileTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="memberFileExtensions"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberFileTypes&gt;"/> instance.</returns>
		public abstract TList<MemberFileTypes> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberFileTypeId, System.String memberFileTypeName, System.String memberFileExtensions);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberFileTypes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberFileTypes&gt;"/></returns>
		public static TList<MemberFileTypes> Fill(IDataReader reader, TList<MemberFileTypes> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberFileTypes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberFileTypes")
					.Append("|").Append((System.Int32)reader[((int)MemberFileTypesColumn.MemberFileTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberFileTypes>(
					key.ToString(), // EntityTrackingKey
					"MemberFileTypes",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberFileTypes();
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
					c.MemberFileTypeId = (System.Int32)reader[((int)MemberFileTypesColumn.MemberFileTypeId - 1)];
					c.MemberFileTypeName = (System.String)reader[((int)MemberFileTypesColumn.MemberFileTypeName - 1)];
					c.MemberFileExtensions = (System.String)reader[((int)MemberFileTypesColumn.MemberFileExtensions - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberFileTypes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFileTypes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberFileTypes entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberFileTypeId = (System.Int32)reader[((int)MemberFileTypesColumn.MemberFileTypeId - 1)];
			entity.MemberFileTypeName = (System.String)reader[((int)MemberFileTypesColumn.MemberFileTypeName - 1)];
			entity.MemberFileExtensions = (System.String)reader[((int)MemberFileTypesColumn.MemberFileExtensions - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberFileTypes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFileTypes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberFileTypes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberFileTypeId = (System.Int32)dataRow["MemberFileTypeID"];
			entity.MemberFileTypeName = (System.String)dataRow["MemberFileTypeName"];
			entity.MemberFileExtensions = (System.String)dataRow["MemberFileExtensions"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberFileTypes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberFileTypes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberFileTypes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMemberFileTypeId methods when available
			
			#region MemberFilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberFiles>|MemberFilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberFilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberFilesCollection = DataRepository.MemberFilesProvider.GetByMemberFileTypeId(transactionManager, entity.MemberFileTypeId);

				if (deep && entity.MemberFilesCollection.Count > 0)
				{
					deepHandles.Add("MemberFilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberFiles>) DataRepository.MemberFilesProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberFilesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberFileTypes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberFileTypes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberFileTypes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberFileTypes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<MemberFiles>
				if (CanDeepSave(entity.MemberFilesCollection, "List<MemberFiles>|MemberFilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberFiles child in entity.MemberFilesCollection)
					{
						if(child.MemberFileTypeIdSource != null)
						{
							child.MemberFileTypeId = child.MemberFileTypeIdSource.MemberFileTypeId;
						}
						else
						{
							child.MemberFileTypeId = entity.MemberFileTypeId;
						}

					}

					if (entity.MemberFilesCollection.Count > 0 || entity.MemberFilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberFilesProvider.Save(transactionManager, entity.MemberFilesCollection);
						
						deepHandles.Add("MemberFilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberFiles >) DataRepository.MemberFilesProvider.DeepSave,
							new object[] { transactionManager, entity.MemberFilesCollection, deepSaveType, childTypes, innerList }
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
	
	#region MemberFileTypesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberFileTypes</c>
	///</summary>
	public enum MemberFileTypesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>MemberFileTypes</c> as OneToMany for MemberFilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberFiles>))]
		MemberFilesCollection,
	}
	
	#endregion MemberFileTypesChildEntityTypes
	
	#region MemberFileTypesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberFileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesFilterBuilder : SqlFilterBuilder<MemberFileTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilterBuilder class.
		/// </summary>
		public MemberFileTypesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFileTypesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFileTypesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFileTypesFilterBuilder
	
	#region MemberFileTypesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberFileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesParameterBuilder : ParameterizedSqlFilterBuilder<MemberFileTypesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesParameterBuilder class.
		/// </summary>
		public MemberFileTypesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFileTypesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFileTypesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFileTypesParameterBuilder
	
	#region MemberFileTypesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberFileTypesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberFileTypesSortBuilder : SqlSortBuilder<MemberFileTypesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesSqlSortBuilder class.
		/// </summary>
		public MemberFileTypesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberFileTypesSortBuilder
	
} // end namespace
