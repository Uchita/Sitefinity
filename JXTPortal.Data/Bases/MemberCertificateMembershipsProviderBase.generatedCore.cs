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
	/// This class is the base class for any <see cref="MemberCertificateMembershipsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberCertificateMembershipsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberCertificateMemberships, JXTPortal.Entities.MemberCertificateMembershipsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberCertificateMembershipsKey key)
		{
			return Delete(transactionManager, key.MemberCertificateMembershipId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberCertificateMembershipId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberCertificateMembershipId)
		{
			return Delete(null, _memberCertificateMembershipId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberCertificateMembershipId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberCertificateMembershipId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		FK__MemberCer__Membe__0256D8FB Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		public TList<MemberCertificateMemberships> GetByMemberId(System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		FK__MemberCer__Membe__0256D8FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		/// <remarks></remarks>
		public TList<MemberCertificateMemberships> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		FK__MemberCer__Membe__0256D8FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		public TList<MemberCertificateMemberships> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		fkMemberCerMembe0256d8Fb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		public TList<MemberCertificateMemberships> GetByMemberId(System.Int32? _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		fkMemberCerMembe0256d8Fb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		public TList<MemberCertificateMemberships> GetByMemberId(System.Int32? _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberCer__Membe__0256D8FB key.
		///		FK__MemberCer__Membe__0256D8FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberCertificateMemberships objects.</returns>
		public abstract TList<MemberCertificateMemberships> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberCertificateMemberships Get(TransactionManager transactionManager, JXTPortal.Entities.MemberCertificateMembershipsKey key, int start, int pageLength)
		{
			return GetByMemberCertificateMembershipId(transactionManager, key.MemberCertificateMembershipId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(System.Int32 _memberCertificateMembershipId)
		{
			int count = -1;
			return GetByMemberCertificateMembershipId(null,_memberCertificateMembershipId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(System.Int32 _memberCertificateMembershipId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberCertificateMembershipId(null, _memberCertificateMembershipId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(TransactionManager transactionManager, System.Int32 _memberCertificateMembershipId)
		{
			int count = -1;
			return GetByMemberCertificateMembershipId(transactionManager, _memberCertificateMembershipId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(TransactionManager transactionManager, System.Int32 _memberCertificateMembershipId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberCertificateMembershipId(transactionManager, _memberCertificateMembershipId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(System.Int32 _memberCertificateMembershipId, int start, int pageLength, out int count)
		{
			return GetByMemberCertificateMembershipId(null, _memberCertificateMembershipId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberCe__7107F296006E9089 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberCertificateMembershipId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> class.</returns>
		public abstract JXTPortal.Entities.MemberCertificateMemberships GetByMemberCertificateMembershipId(TransactionManager transactionManager, System.Int32 _memberCertificateMembershipId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberCertificateMemberships_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberCertificateMembershipId)
		{
			 Insert(null, 0, int.MaxValue , memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate, ref memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberCertificateMembershipId)
		{
			 Insert(null, start, pageLength , memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate, ref memberCertificateMembershipId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberCertificateMembershipId)
		{
			 Insert(transactionManager, 0, int.MaxValue , memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate, ref memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Insert' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate, ref System.Int32? memberCertificateMembershipId);
		
		#endregion
		
		#region MemberCertificateMemberships_GetByMemberId 
		
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region MemberCertificateMemberships_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberCertificateMemberships_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberCertificateMemberships_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberCertificateMemberships_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberCertificateMemberships_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberCertificateMemberships_GetPaged' stored procedure. 
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
		
		#region MemberCertificateMemberships_GetByMemberCertificateMembershipId 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberCertificateMembershipId' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberCertificateMembershipId(System.Int32? memberCertificateMembershipId)
		{
			return GetByMemberCertificateMembershipId(null, 0, int.MaxValue , memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberCertificateMembershipId' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberCertificateMembershipId(int start, int pageLength, System.Int32? memberCertificateMembershipId)
		{
			return GetByMemberCertificateMembershipId(null, start, pageLength , memberCertificateMembershipId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberCertificateMembershipId' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberCertificateMembershipId(TransactionManager transactionManager, System.Int32? memberCertificateMembershipId)
		{
			return GetByMemberCertificateMembershipId(transactionManager, 0, int.MaxValue , memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_GetByMemberCertificateMembershipId' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberCertificateMembershipId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberCertificateMembershipId);
		
		#endregion
		
		#region MemberCertificateMemberships_Find 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(null, start, pageLength , searchUsingOr, memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region MemberCertificateMemberships_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberCertificateMembershipId)
		{
			 Delete(null, 0, int.MaxValue , memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberCertificateMembershipId)
		{
			 Delete(null, start, pageLength , memberCertificateMembershipId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberCertificateMembershipId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberCertificateMembershipId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberCertificateMembershipId);
		
		#endregion
		
		#region MemberCertificateMemberships_Update 
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Update' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(null, 0, int.MaxValue , memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Update' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(null, start, pageLength , memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Update' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate)
		{
			 Update(transactionManager, 0, int.MaxValue , memberCertificateMembershipId, memberId, memberCertificateMembershipName, certificationAuthority, licenseNumber, certificationUrl, startMonth, startYear, endMonth, endYear, doesnotExpire, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'MemberCertificateMemberships_Update' stored procedure. 
		/// </summary>
		/// <param name="memberCertificateMembershipId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberCertificateMembershipName"> A <c>System.String</c> instance.</param>
		/// <param name="certificationAuthority"> A <c>System.String</c> instance.</param>
		/// <param name="licenseNumber"> A <c>System.String</c> instance.</param>
		/// <param name="certificationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="doesnotExpire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberCertificateMembershipId, System.Int32? memberId, System.String memberCertificateMembershipName, System.String certificationAuthority, System.String licenseNumber, System.String certificationUrl, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? doesnotExpire, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberCertificateMemberships&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberCertificateMemberships&gt;"/></returns>
		public static TList<MemberCertificateMemberships> Fill(IDataReader reader, TList<MemberCertificateMemberships> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberCertificateMemberships c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberCertificateMemberships")
					.Append("|").Append((System.Int32)reader[((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberCertificateMemberships>(
					key.ToString(), // EntityTrackingKey
					"MemberCertificateMemberships",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberCertificateMemberships();
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
					c.MemberCertificateMembershipId = (System.Int32)reader[((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipId - 1)];
					c.MemberId = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.MemberId - 1)];
					c.MemberCertificateMembershipName = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipName - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipName - 1)];
					c.CertificationAuthority = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.CertificationAuthority - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.CertificationAuthority - 1)];
					c.LicenseNumber = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.LicenseNumber - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.LicenseNumber - 1)];
					c.CertificationUrl = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.CertificationUrl - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.CertificationUrl - 1)];
					c.StartMonth = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.StartMonth - 1)];
					c.StartYear = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.StartYear - 1)];
					c.EndMonth = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.EndMonth - 1)];
					c.EndYear = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.EndYear - 1)];
					c.DoesnotExpire = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.DoesnotExpire - 1)))?null:(System.Boolean?)reader[((int)MemberCertificateMembershipsColumn.DoesnotExpire - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberCertificateMembershipsColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberCertificateMemberships entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberCertificateMembershipId = (System.Int32)reader[((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipId - 1)];
			entity.MemberId = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.MemberId - 1)];
			entity.MemberCertificateMembershipName = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipName - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.MemberCertificateMembershipName - 1)];
			entity.CertificationAuthority = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.CertificationAuthority - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.CertificationAuthority - 1)];
			entity.LicenseNumber = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.LicenseNumber - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.LicenseNumber - 1)];
			entity.CertificationUrl = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.CertificationUrl - 1)))?null:(System.String)reader[((int)MemberCertificateMembershipsColumn.CertificationUrl - 1)];
			entity.StartMonth = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.StartMonth - 1)];
			entity.StartYear = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.StartYear - 1)];
			entity.EndMonth = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.EndMonth - 1)];
			entity.EndYear = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberCertificateMembershipsColumn.EndYear - 1)];
			entity.DoesnotExpire = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.DoesnotExpire - 1)))?null:(System.Boolean?)reader[((int)MemberCertificateMembershipsColumn.DoesnotExpire - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)MemberCertificateMembershipsColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MemberCertificateMembershipsColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberCertificateMemberships entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberCertificateMembershipId = (System.Int32)dataRow["MemberCertificateMembershipID"];
			entity.MemberId = Convert.IsDBNull(dataRow["MemberID"]) ? null : (System.Int32?)dataRow["MemberID"];
			entity.MemberCertificateMembershipName = Convert.IsDBNull(dataRow["MemberCertificateMembershipName"]) ? null : (System.String)dataRow["MemberCertificateMembershipName"];
			entity.CertificationAuthority = Convert.IsDBNull(dataRow["CertificationAuthority"]) ? null : (System.String)dataRow["CertificationAuthority"];
			entity.LicenseNumber = Convert.IsDBNull(dataRow["LicenseNumber"]) ? null : (System.String)dataRow["LicenseNumber"];
			entity.CertificationUrl = Convert.IsDBNull(dataRow["CertificationURL"]) ? null : (System.String)dataRow["CertificationURL"];
			entity.StartMonth = Convert.IsDBNull(dataRow["StartMonth"]) ? null : (System.Int32?)dataRow["StartMonth"];
			entity.StartYear = Convert.IsDBNull(dataRow["StartYear"]) ? null : (System.Int32?)dataRow["StartYear"];
			entity.EndMonth = Convert.IsDBNull(dataRow["EndMonth"]) ? null : (System.Int32?)dataRow["EndMonth"];
			entity.EndYear = Convert.IsDBNull(dataRow["EndYear"]) ? null : (System.Int32?)dataRow["EndYear"];
			entity.DoesnotExpire = Convert.IsDBNull(dataRow["DoesnotExpire"]) ? null : (System.Boolean?)dataRow["DoesnotExpire"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberCertificateMemberships"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberCertificateMemberships Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberCertificateMemberships entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberCertificateMemberships object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberCertificateMemberships instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberCertificateMemberships Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberCertificateMemberships entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberCertificateMembershipsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberCertificateMemberships</c>
	///</summary>
	public enum MemberCertificateMembershipsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion MemberCertificateMembershipsChildEntityTypes
	
	#region MemberCertificateMembershipsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberCertificateMembershipsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberCertificateMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberCertificateMembershipsFilterBuilder : SqlFilterBuilder<MemberCertificateMembershipsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilterBuilder class.
		/// </summary>
		public MemberCertificateMembershipsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberCertificateMembershipsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberCertificateMembershipsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberCertificateMembershipsFilterBuilder
	
	#region MemberCertificateMembershipsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberCertificateMembershipsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberCertificateMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberCertificateMembershipsParameterBuilder : ParameterizedSqlFilterBuilder<MemberCertificateMembershipsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsParameterBuilder class.
		/// </summary>
		public MemberCertificateMembershipsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberCertificateMembershipsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberCertificateMembershipsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberCertificateMembershipsParameterBuilder
	
	#region MemberCertificateMembershipsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberCertificateMembershipsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberCertificateMemberships"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberCertificateMembershipsSortBuilder : SqlSortBuilder<MemberCertificateMembershipsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsSqlSortBuilder class.
		/// </summary>
		public MemberCertificateMembershipsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberCertificateMembershipsSortBuilder
	
} // end namespace
