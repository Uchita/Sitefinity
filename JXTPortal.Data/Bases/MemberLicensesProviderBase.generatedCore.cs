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
	/// This class is the base class for any <see cref="MemberLicensesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberLicensesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberLicenses, JXTPortal.Entities.MemberLicensesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberLicensesKey key)
		{
			return Delete(transactionManager, key.MemberLicenseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberLicenseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberLicenseId)
		{
			return Delete(null, _memberLicenseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLicenseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberLicenseId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		FK__MemberLic__Membe__7D9223DE Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		public TList<MemberLicenses> GetByMemberId(System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		FK__MemberLic__Membe__7D9223DE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		/// <remarks></remarks>
		public TList<MemberLicenses> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		FK__MemberLic__Membe__7D9223DE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		public TList<MemberLicenses> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		fkMemberLicMembe7d9223De Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		public TList<MemberLicenses> GetByMemberId(System.Int32? _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		fkMemberLicMembe7d9223De Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		public TList<MemberLicenses> GetByMemberId(System.Int32? _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberLic__Membe__7D9223DE key.
		///		FK__MemberLic__Membe__7D9223DE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberLicenses objects.</returns>
		public abstract TList<MemberLicenses> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberLicenses Get(TransactionManager transactionManager, JXTPortal.Entities.MemberLicensesKey key, int start, int pageLength)
		{
			return GetByMemberLicenseId(transactionManager, key.MemberLicenseId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="_memberLicenseId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(System.Int32 _memberLicenseId)
		{
			int count = -1;
			return GetByMemberLicenseId(null,_memberLicenseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="_memberLicenseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(System.Int32 _memberLicenseId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberLicenseId(null, _memberLicenseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLicenseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(TransactionManager transactionManager, System.Int32 _memberLicenseId)
		{
			int count = -1;
			return GetByMemberLicenseId(transactionManager, _memberLicenseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLicenseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(TransactionManager transactionManager, System.Int32 _memberLicenseId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberLicenseId(transactionManager, _memberLicenseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="_memberLicenseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(System.Int32 _memberLicenseId, int start, int pageLength, out int count)
		{
			return GetByMemberLicenseId(null, _memberLicenseId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberLi__9351502B7BA9DB6C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberLicenseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberLicenses"/> class.</returns>
		public abstract JXTPortal.Entities.MemberLicenses GetByMemberLicenseId(TransactionManager transactionManager, System.Int32 _memberLicenseId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberLicenses_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberLicenseId)
		{
			 Insert(null, 0, int.MaxValue , memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate, ref memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberLicenseId)
		{
			 Insert(null, start, pageLength , memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate, ref memberLicenseId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLicenses_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberLicenseId)
		{
			 Insert(transactionManager, 0, int.MaxValue , memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate, ref memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberLicenseId);
		
		#endregion
		
		#region MemberLicenses_GetByMemberId 
		
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'MemberLicenses_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region MemberLicenses_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberLicenses_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberLicenses_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLicenses_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLicenses_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberLicenses_GetPaged' stored procedure. 
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
		
		#region MemberLicenses_GetByMemberLicenseId 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetByMemberLicenseId' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLicenseId(System.Int32? memberLicenseId)
		{
			return GetByMemberLicenseId(null, 0, int.MaxValue , memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetByMemberLicenseId' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLicenseId(int start, int pageLength, System.Int32? memberLicenseId)
		{
			return GetByMemberLicenseId(null, start, pageLength , memberLicenseId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetByMemberLicenseId' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberLicenseId(TransactionManager transactionManager, System.Int32? memberLicenseId)
		{
			return GetByMemberLicenseId(transactionManager, 0, int.MaxValue , memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_GetByMemberLicenseId' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberLicenseId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLicenseId);
		
		#endregion
		
		#region MemberLicenses_Find 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(null, start, pageLength , searchUsingOr, memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLicenses_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region MemberLicenses_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberLicenseId)
		{
			 Delete(null, 0, int.MaxValue , memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberLicenseId)
		{
			 Delete(null, start, pageLength , memberLicenseId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLicenses_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberLicenseId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberLicenseId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLicenseId);
		
		#endregion
		
		#region MemberLicenses_Update 
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(null, 0, int.MaxValue , memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(null, start, pageLength , memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberLicenses_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(transactionManager, 0, int.MaxValue , memberLicenseId, memberId, memberLicenseName, licenseType, issueDate, expiryDate, countryId, state, doesNotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberLicenses_Update' stored procedure. 
		/// </summary>
		/// <param name="memberLicenseId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberLicenseName"> A <c>System.String</c> instance.</param>
		/// <param name="licenseType"> A <c>System.String</c> instance.</param>
		/// <param name="issueDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="state"> A <c>System.String</c> instance.</param>
		/// <param name="doesNotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberLicenseId, System.Int32? memberId, System.String memberLicenseName, System.String licenseType, System.DateTime? issueDate, System.DateTime? expiryDate, System.Int32? countryId, System.String state, System.Boolean? doesNotExpire, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberLicenses&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberLicenses&gt;"/></returns>
		public static TList<MemberLicenses> Fill(IDataReader reader, TList<MemberLicenses> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberLicenses c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberLicenses")
					.Append("|").Append((System.Int32)reader[((int)MemberLicensesColumn.MemberLicenseId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberLicenses>(
					key.ToString(), // EntityTrackingKey
					"MemberLicenses",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberLicenses();
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
					c.MemberLicenseId = (System.Int32)reader[((int)MemberLicensesColumn.MemberLicenseId - 1)];
					c.MemberId = (reader.IsDBNull(((int)MemberLicensesColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberLicensesColumn.MemberId - 1)];
					c.MemberLicenseName = (reader.IsDBNull(((int)MemberLicensesColumn.MemberLicenseName - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.MemberLicenseName - 1)];
					c.LicenseType = (reader.IsDBNull(((int)MemberLicensesColumn.LicenseType - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.LicenseType - 1)];
					c.IssueDate = (reader.IsDBNull(((int)MemberLicensesColumn.IssueDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.IssueDate - 1)];
					c.ExpiryDate = (reader.IsDBNull(((int)MemberLicensesColumn.ExpiryDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.ExpiryDate - 1)];
					c.CountryId = (reader.IsDBNull(((int)MemberLicensesColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberLicensesColumn.CountryId - 1)];
					c.State = (reader.IsDBNull(((int)MemberLicensesColumn.State - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.State - 1)];
					c.DoesNotExpire = (reader.IsDBNull(((int)MemberLicensesColumn.DoesNotExpire - 1)))?null:(System.Boolean?)reader[((int)MemberLicensesColumn.DoesNotExpire - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)MemberLicensesColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberLicenses"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLicenses"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberLicenses entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberLicenseId = (System.Int32)reader[((int)MemberLicensesColumn.MemberLicenseId - 1)];
			entity.MemberId = (reader.IsDBNull(((int)MemberLicensesColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberLicensesColumn.MemberId - 1)];
			entity.MemberLicenseName = (reader.IsDBNull(((int)MemberLicensesColumn.MemberLicenseName - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.MemberLicenseName - 1)];
			entity.LicenseType = (reader.IsDBNull(((int)MemberLicensesColumn.LicenseType - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.LicenseType - 1)];
			entity.IssueDate = (reader.IsDBNull(((int)MemberLicensesColumn.IssueDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.IssueDate - 1)];
			entity.ExpiryDate = (reader.IsDBNull(((int)MemberLicensesColumn.ExpiryDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.ExpiryDate - 1)];
			entity.CountryId = (reader.IsDBNull(((int)MemberLicensesColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberLicensesColumn.CountryId - 1)];
			entity.State = (reader.IsDBNull(((int)MemberLicensesColumn.State - 1)))?null:(System.String)reader[((int)MemberLicensesColumn.State - 1)];
			entity.DoesNotExpire = (reader.IsDBNull(((int)MemberLicensesColumn.DoesNotExpire - 1)))?null:(System.Boolean?)reader[((int)MemberLicensesColumn.DoesNotExpire - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)MemberLicensesColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberLicensesColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberLicenses"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLicenses"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberLicenses entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberLicenseId = (System.Int32)dataRow["MemberLicenseID"];
			entity.MemberId = Convert.IsDBNull(dataRow["MemberID"]) ? null : (System.Int32?)dataRow["MemberID"];
			entity.MemberLicenseName = Convert.IsDBNull(dataRow["MemberLicenseName"]) ? null : (System.String)dataRow["MemberLicenseName"];
			entity.LicenseType = Convert.IsDBNull(dataRow["LicenseType"]) ? null : (System.String)dataRow["LicenseType"];
			entity.IssueDate = Convert.IsDBNull(dataRow["IssueDate"]) ? null : (System.DateTime?)dataRow["IssueDate"];
			entity.ExpiryDate = Convert.IsDBNull(dataRow["ExpiryDate"]) ? null : (System.DateTime?)dataRow["ExpiryDate"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.State = Convert.IsDBNull(dataRow["State"]) ? null : (System.String)dataRow["State"];
			entity.DoesNotExpire = Convert.IsDBNull(dataRow["DoesNotExpire"]) ? null : (System.Boolean?)dataRow["DoesNotExpire"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberLicenses"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberLicenses Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberLicenses entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberLicenses object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberLicenses instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberLicenses Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberLicenses entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberLicensesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberLicenses</c>
	///</summary>
	public enum MemberLicensesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion MemberLicensesChildEntityTypes
	
	#region MemberLicensesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberLicensesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLicenses"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLicensesFilterBuilder : SqlFilterBuilder<MemberLicensesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilterBuilder class.
		/// </summary>
		public MemberLicensesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLicensesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLicensesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLicensesFilterBuilder
	
	#region MemberLicensesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberLicensesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLicenses"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLicensesParameterBuilder : ParameterizedSqlFilterBuilder<MemberLicensesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLicensesParameterBuilder class.
		/// </summary>
		public MemberLicensesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLicensesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLicensesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLicensesParameterBuilder
	
	#region MemberLicensesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberLicensesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLicenses"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberLicensesSortBuilder : SqlSortBuilder<MemberLicensesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLicensesSqlSortBuilder class.
		/// </summary>
		public MemberLicensesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberLicensesSortBuilder
	
} // end namespace
