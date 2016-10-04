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
	/// This class is the base class for any <see cref="MemberLanguagesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberLanguagesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberLanguages, JXTPortal.Entities.MemberLanguagesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberLanguagesKey key)
		{
			return Delete(transactionManager, key.MemberLanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberLanguageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberLanguageId)
		{
			return Delete(null, _memberLanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLanguageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberLanguageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		FK__MemberLan__Membe__071B8E18 Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		public TList<MemberLanguages> GetByMemberId(System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		FK__MemberLan__Membe__071B8E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		/// <remarks></remarks>
		public TList<MemberLanguages> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		FK__MemberLan__Membe__071B8E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		public TList<MemberLanguages> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		fkMemberLanMembe071b8e18 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		public TList<MemberLanguages> GetByMemberId(System.Int32? _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		fkMemberLanMembe071b8e18 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		public TList<MemberLanguages> GetByMemberId(System.Int32? _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLan__Membe__071B8E18 key.
		///		FK__MemberLan__Membe__071B8E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLanguages objects.</returns>
		public abstract TList<MemberLanguages> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberLanguages Get(TransactionManager transactionManager, JXTPortal.Entities.MemberLanguagesKey key, int start, int pageLength)
		{
			return GetByMemberLanguageId(transactionManager, key.MemberLanguageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="_memberLanguageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(System.Int32 _memberLanguageId)
		{
			int count = -1;
			return GetByMemberLanguageId(null,_memberLanguageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="_memberLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(System.Int32 _memberLanguageId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberLanguageId(null, _memberLanguageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLanguageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(TransactionManager transactionManager, System.Int32 _memberLanguageId)
		{
			int count = -1;
			return GetByMemberLanguageId(transactionManager, _memberLanguageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(TransactionManager transactionManager, System.Int32 _memberLanguageId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberLanguageId(transactionManager, _memberLanguageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="_memberLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(System.Int32 _memberLanguageId, int start, int pageLength, out int count)
		{
			return GetByMemberLanguageId(null, _memberLanguageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLa__ADB965C7053345A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLanguages"/> class.</returns>
		public abstract JXTPortal.Entities.MemberLanguages GetByMemberLanguageId(TransactionManager transactionManager, System.Int32 _memberLanguageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberLanguages_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate, ref System.Int32? memberLanguageId)
		{
			 Insert(null, 0, int.MaxValue , memberId, langauges, profieciency, lastModifiedDate, ref memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate, ref System.Int32? memberLanguageId)
		{
			 Insert(null, start, pageLength , memberId, langauges, profieciency, lastModifiedDate, ref memberLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate, ref System.Int32? memberLanguageId)
		{
			 Insert(transactionManager, 0, int.MaxValue , memberId, langauges, profieciency, lastModifiedDate, ref memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate, ref System.Int32? memberLanguageId);
		
		#endregion
		
		#region MemberLanguages_GetByMemberLanguageId 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberLanguageId' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLanguageId(System.Int32? memberLanguageId)
		{
			return GetByMemberLanguageId(null, 0, int.MaxValue , memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberLanguageId' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLanguageId(int start, int pageLength, System.Int32? memberLanguageId)
		{
			return GetByMemberLanguageId(null, start, pageLength , memberLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberLanguageId' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLanguageId(TransactionManager transactionManager, System.Int32? memberLanguageId)
		{
			return GetByMemberLanguageId(transactionManager, 0, int.MaxValue , memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberLanguageId' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLanguageId);
		
		#endregion
		
		#region MemberLanguages_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberLanguages_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLanguages_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLanguages_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLanguages_GetPaged' stored procedure. 
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
		
		#region MemberLanguages_Find 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			return Find(null, start, pageLength , searchUsingOr, memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region MemberLanguages_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberLanguageId)
		{
			 Delete(null, 0, int.MaxValue , memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberLanguageId)
		{
			 Delete(null, start, pageLength , memberLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberLanguageId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLanguageId);
		
		#endregion
		
		#region MemberLanguages_Update 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			 Update(null, 0, int.MaxValue , memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			 Update(null, start, pageLength , memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate)
		{
			 Update(transactionManager, 0, int.MaxValue , memberLanguageId, memberId, langauges, profieciency, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="langauges"> A <c>System.String</c> instance.</param>
		/// <param name="profieciency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLanguageId, System.Int32? memberId, System.String langauges, System.Int32? profieciency, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region MemberLanguages_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		
		/// <summary>
		///	This method wrap the 'MemberLanguages_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberLanguages&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberLanguages&gt;"/></returns>
		public static TList<MemberLanguages> Fill(IDataReader reader, TList<MemberLanguages> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberLanguages c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberLanguages")
					.Append("|").Append((System.Int32)reader[((int)MemberLanguagesColumn.MemberLanguageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberLanguages>(
					key.ToString(), // EntityTrackingKey
					"MemberLanguages",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberLanguages();
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
					c.MemberLanguageId = (System.Int32)reader[((int)MemberLanguagesColumn.MemberLanguageId - 1)];
					c.MemberId = (reader.IsDBNull(((int)MemberLanguagesColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberLanguagesColumn.MemberId - 1)];
					c.Langauges = (reader.IsDBNull(((int)MemberLanguagesColumn.Langauges - 1)))?null:(System.String)reader[((int)MemberLanguagesColumn.Langauges - 1)];
					c.Profieciency = (reader.IsDBNull(((int)MemberLanguagesColumn.Profieciency - 1)))?null:(System.Int32?)reader[((int)MemberLanguagesColumn.Profieciency - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)MemberLanguagesColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberLanguagesColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberLanguages"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLanguages"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberLanguages entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberLanguageId = (System.Int32)reader[((int)MemberLanguagesColumn.MemberLanguageId - 1)];
			entity.MemberId = (reader.IsDBNull(((int)MemberLanguagesColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberLanguagesColumn.MemberId - 1)];
			entity.Langauges = (reader.IsDBNull(((int)MemberLanguagesColumn.Langauges - 1)))?null:(System.String)reader[((int)MemberLanguagesColumn.Langauges - 1)];
			entity.Profieciency = (reader.IsDBNull(((int)MemberLanguagesColumn.Profieciency - 1)))?null:(System.Int32?)reader[((int)MemberLanguagesColumn.Profieciency - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)MemberLanguagesColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberLanguagesColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberLanguages"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLanguages"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberLanguages entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberLanguageId = (System.Int32)dataRow["MemberLanguageID"];
			entity.MemberId = Convert.IsDBNull(dataRow["MemberID"]) ? null : (System.Int32?)dataRow["MemberID"];
			entity.Langauges = Convert.IsDBNull(dataRow["Langauges"]) ? null : (System.String)dataRow["Langauges"];
			entity.Profieciency = Convert.IsDBNull(dataRow["Profieciency"]) ? null : (System.Int32?)dataRow["Profieciency"];
			entity.LastModifiedDate = Convert.IsDBNull(dataRow["LastModifiedDate"]) ? null : (System.DateTime?)dataRow["LastModifiedDate"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLanguages"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberLanguages Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberLanguages entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MemberIdSource	
			if (CanDeepLoad(entity, "Members|MemberIdSource", deepLoadType, innerList) 
				&& entity.MemberIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MemberId ?? (int)0);
				Members tmpEntity = EntityManager.LocateEntity<Members>(EntityLocator.ConstructKeyFromPkItems(typeof(Members), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MemberIdSource = tmpEntity;
				else
					entity.MemberIdSource = DataRepository.MembersProvider.GetByMemberId(transactionManager, (entity.MemberId ?? (int)0));		
				
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberLanguages object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberLanguages instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberLanguages Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberLanguages entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberLanguagesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberLanguages</c>
	///</summary>
	public enum MemberLanguagesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion MemberLanguagesChildEntityTypes
	
	#region MemberLanguagesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLanguagesFilterBuilder : SqlFilterBuilder<MemberLanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilterBuilder class.
		/// </summary>
		public MemberLanguagesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLanguagesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLanguagesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLanguagesFilterBuilder
	
	#region MemberLanguagesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLanguagesParameterBuilder : ParameterizedSqlFilterBuilder<MemberLanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesParameterBuilder class.
		/// </summary>
		public MemberLanguagesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLanguagesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLanguagesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLanguagesParameterBuilder
	
	#region MemberLanguagesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLanguages"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberLanguagesSortBuilder : SqlSortBuilder<MemberLanguagesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesSqlSortBuilder class.
		/// </summary>
		public MemberLanguagesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberLanguagesSortBuilder
	
} // end namespace
