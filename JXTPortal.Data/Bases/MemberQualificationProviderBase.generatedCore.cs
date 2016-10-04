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
	/// This class is the base class for any <see cref="MemberQualificationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberQualificationProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberQualification, JXTPortal.Entities.MemberQualificationKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberQualificationKey key)
		{
			return Delete(transactionManager, key.MemberQualificationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberQualificationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberQualificationId)
		{
			return Delete(null, _memberQualificationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberQualificationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberQualificationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fk_MemberQualificationMember Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		public TList<MemberQualification> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fk_MemberQualificationMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		/// <remarks></remarks>
		public TList<MemberQualification> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fk_MemberQualificationMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		public TList<MemberQualification> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fkMemberQualificationMember Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		public TList<MemberQualification> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fkMemberQualificationMember Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		public TList<MemberQualification> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberQualificationMember key.
		///		fk_MemberQualificationMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberQualification objects.</returns>
		public abstract TList<MemberQualification> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberQualification Get(TransactionManager transactionManager, JXTPortal.Entities.MemberQualificationKey key, int start, int pageLength)
		{
			return GetByMemberQualificationId(transactionManager, key.MemberQualificationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MemberQualification index.
		/// </summary>
		/// <param name="_memberQualificationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public JXTPortal.Entities.MemberQualification GetByMemberQualificationId(System.Int32 _memberQualificationId)
		{
			int count = -1;
			return GetByMemberQualificationId(null,_memberQualificationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberQualification index.
		/// </summary>
		/// <param name="_memberQualificationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public JXTPortal.Entities.MemberQualification GetByMemberQualificationId(System.Int32 _memberQualificationId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberQualificationId(null, _memberQualificationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberQualification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberQualificationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public JXTPortal.Entities.MemberQualification GetByMemberQualificationId(TransactionManager transactionManager, System.Int32 _memberQualificationId)
		{
			int count = -1;
			return GetByMemberQualificationId(transactionManager, _memberQualificationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberQualification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberQualificationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public JXTPortal.Entities.MemberQualification GetByMemberQualificationId(TransactionManager transactionManager, System.Int32 _memberQualificationId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberQualificationId(transactionManager, _memberQualificationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberQualification index.
		/// </summary>
		/// <param name="_memberQualificationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public JXTPortal.Entities.MemberQualification GetByMemberQualificationId(System.Int32 _memberQualificationId, int start, int pageLength, out int count)
		{
			return GetByMemberQualificationId(null, _memberQualificationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberQualification index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberQualificationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberQualification"/> class.</returns>
		public abstract JXTPortal.Entities.MemberQualification GetByMemberQualificationId(TransactionManager transactionManager, System.Int32 _memberQualificationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberQualification_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth, ref System.Int32? memberQualificationId)
		{
			 Insert(null, 0, int.MaxValue , linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth, ref memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth, ref System.Int32? memberQualificationId)
		{
			 Insert(null, start, pageLength , linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth, ref memberQualificationId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberQualification_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth, ref System.Int32? memberQualificationId)
		{
			 Insert(transactionManager, 0, int.MaxValue , linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth, ref memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth, ref System.Int32? memberQualificationId);
		
		#endregion
		
		#region MemberQualification_GetByMemberQualificationId 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberQualificationId' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberQualificationId(System.Int32? memberQualificationId)
		{
			return GetByMemberQualificationId(null, 0, int.MaxValue , memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberQualificationId' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberQualificationId(int start, int pageLength, System.Int32? memberQualificationId)
		{
			return GetByMemberQualificationId(null, start, pageLength , memberQualificationId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberQualificationId' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberQualificationId(TransactionManager transactionManager, System.Int32? memberQualificationId)
		{
			return GetByMemberQualificationId(transactionManager, 0, int.MaxValue , memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberQualificationId' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberQualificationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberQualificationId);
		
		#endregion
		
		#region MemberQualification_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'MemberQualification_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region MemberQualification_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberQualification_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberQualification_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberQualification_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberQualification_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberQualification_GetPaged' stored procedure. 
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
		
		#region MemberQualification_Find 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			return Find(null, start, pageLength , searchUsingOr, memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
				
		/// <summary>
		///	This method wrap the 'MemberQualification_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth);
		
		#endregion
		
		#region MemberQualification_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberQualificationId)
		{
			 Delete(null, 0, int.MaxValue , memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberQualificationId)
		{
			 Delete(null, start, pageLength , memberQualificationId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberQualification_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberQualificationId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberQualificationId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberQualificationId);
		
		#endregion
		
		#region MemberQualification_Update 
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Update' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			 Update(null, 0, int.MaxValue , memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Update' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			 Update(null, start, pageLength , memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
				
		/// <summary>
		///	This method wrap the 'MemberQualification_Update' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth)
		{
			 Update(transactionManager, 0, int.MaxValue , memberQualificationId, linkedInInternalEducationId, schoolName, fieldOfStudy, startYear, endYear, degree, activities, notes, memberId, city, countryId, qualificationLevelId, qualificationLevelOther, major, present, startMonth, endMonth);
		}
		
		/// <summary>
		///	This method wrap the 'MemberQualification_Update' stored procedure. 
		/// </summary>
		/// <param name="memberQualificationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalEducationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="schoolName"> A <c>System.String</c> instance.</param>
		/// <param name="fieldOfStudy"> A <c>System.String</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="degree"> A <c>System.String</c> instance.</param>
		/// <param name="activities"> A <c>System.String</c> instance.</param>
		/// <param name="notes"> A <c>System.String</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="qualificationLevelOther"> A <c>System.String</c> instance.</param>
		/// <param name="major"> A <c>System.String</c> instance.</param>
		/// <param name="present"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberQualificationId, System.Int32? linkedInInternalEducationId, System.String schoolName, System.String fieldOfStudy, System.Int32? startYear, System.Int32? endYear, System.String degree, System.String activities, System.String notes, System.Int32? memberId, System.String city, System.Int32? countryId, System.Int32? qualificationLevelId, System.String qualificationLevelOther, System.String major, System.Boolean? present, System.Int32? startMonth, System.Int32? endMonth);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberQualification&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberQualification&gt;"/></returns>
		public static TList<MemberQualification> Fill(IDataReader reader, TList<MemberQualification> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberQualification c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberQualification")
					.Append("|").Append((System.Int32)reader[((int)MemberQualificationColumn.MemberQualificationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberQualification>(
					key.ToString(), // EntityTrackingKey
					"MemberQualification",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberQualification();
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
					c.MemberQualificationId = (System.Int32)reader[((int)MemberQualificationColumn.MemberQualificationId - 1)];
					c.LinkedInInternalEducationId = (reader.IsDBNull(((int)MemberQualificationColumn.LinkedInInternalEducationId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.LinkedInInternalEducationId - 1)];
					c.SchoolName = (reader.IsDBNull(((int)MemberQualificationColumn.SchoolName - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.SchoolName - 1)];
					c.FieldOfStudy = (reader.IsDBNull(((int)MemberQualificationColumn.FieldOfStudy - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.FieldOfStudy - 1)];
					c.StartYear = (reader.IsDBNull(((int)MemberQualificationColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.StartYear - 1)];
					c.EndYear = (reader.IsDBNull(((int)MemberQualificationColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.EndYear - 1)];
					c.Degree = (reader.IsDBNull(((int)MemberQualificationColumn.Degree - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Degree - 1)];
					c.Activities = (reader.IsDBNull(((int)MemberQualificationColumn.Activities - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Activities - 1)];
					c.Notes = (reader.IsDBNull(((int)MemberQualificationColumn.Notes - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Notes - 1)];
					c.MemberId = (System.Int32)reader[((int)MemberQualificationColumn.MemberId - 1)];
					c.City = (reader.IsDBNull(((int)MemberQualificationColumn.City - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.City - 1)];
					c.CountryId = (reader.IsDBNull(((int)MemberQualificationColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.CountryId - 1)];
					c.QualificationLevelId = (reader.IsDBNull(((int)MemberQualificationColumn.QualificationLevelId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.QualificationLevelId - 1)];
					c.QualificationLevelOther = (reader.IsDBNull(((int)MemberQualificationColumn.QualificationLevelOther - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.QualificationLevelOther - 1)];
					c.Major = (reader.IsDBNull(((int)MemberQualificationColumn.Major - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Major - 1)];
					c.Present = (reader.IsDBNull(((int)MemberQualificationColumn.Present - 1)))?null:(System.Boolean?)reader[((int)MemberQualificationColumn.Present - 1)];
					c.StartMonth = (reader.IsDBNull(((int)MemberQualificationColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.StartMonth - 1)];
					c.EndMonth = (reader.IsDBNull(((int)MemberQualificationColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.EndMonth - 1)];
					c.Graduated = (reader.IsDBNull(((int)MemberQualificationColumn.Graduated - 1)))?null:(System.Boolean?)reader[((int)MemberQualificationColumn.Graduated - 1)];
					c.NonGraduatedCredits = (reader.IsDBNull(((int)MemberQualificationColumn.NonGraduatedCredits - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.NonGraduatedCredits - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberQualification"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberQualification"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberQualification entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberQualificationId = (System.Int32)reader[((int)MemberQualificationColumn.MemberQualificationId - 1)];
			entity.LinkedInInternalEducationId = (reader.IsDBNull(((int)MemberQualificationColumn.LinkedInInternalEducationId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.LinkedInInternalEducationId - 1)];
			entity.SchoolName = (reader.IsDBNull(((int)MemberQualificationColumn.SchoolName - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.SchoolName - 1)];
			entity.FieldOfStudy = (reader.IsDBNull(((int)MemberQualificationColumn.FieldOfStudy - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.FieldOfStudy - 1)];
			entity.StartYear = (reader.IsDBNull(((int)MemberQualificationColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.StartYear - 1)];
			entity.EndYear = (reader.IsDBNull(((int)MemberQualificationColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.EndYear - 1)];
			entity.Degree = (reader.IsDBNull(((int)MemberQualificationColumn.Degree - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Degree - 1)];
			entity.Activities = (reader.IsDBNull(((int)MemberQualificationColumn.Activities - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Activities - 1)];
			entity.Notes = (reader.IsDBNull(((int)MemberQualificationColumn.Notes - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Notes - 1)];
			entity.MemberId = (System.Int32)reader[((int)MemberQualificationColumn.MemberId - 1)];
			entity.City = (reader.IsDBNull(((int)MemberQualificationColumn.City - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.City - 1)];
			entity.CountryId = (reader.IsDBNull(((int)MemberQualificationColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.CountryId - 1)];
			entity.QualificationLevelId = (reader.IsDBNull(((int)MemberQualificationColumn.QualificationLevelId - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.QualificationLevelId - 1)];
			entity.QualificationLevelOther = (reader.IsDBNull(((int)MemberQualificationColumn.QualificationLevelOther - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.QualificationLevelOther - 1)];
			entity.Major = (reader.IsDBNull(((int)MemberQualificationColumn.Major - 1)))?null:(System.String)reader[((int)MemberQualificationColumn.Major - 1)];
			entity.Present = (reader.IsDBNull(((int)MemberQualificationColumn.Present - 1)))?null:(System.Boolean?)reader[((int)MemberQualificationColumn.Present - 1)];
			entity.StartMonth = (reader.IsDBNull(((int)MemberQualificationColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.StartMonth - 1)];
			entity.EndMonth = (reader.IsDBNull(((int)MemberQualificationColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.EndMonth - 1)];
			entity.Graduated = (reader.IsDBNull(((int)MemberQualificationColumn.Graduated - 1)))?null:(System.Boolean?)reader[((int)MemberQualificationColumn.Graduated - 1)];
			entity.NonGraduatedCredits = (reader.IsDBNull(((int)MemberQualificationColumn.NonGraduatedCredits - 1)))?null:(System.Int32?)reader[((int)MemberQualificationColumn.NonGraduatedCredits - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberQualification"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberQualification"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberQualification entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberQualificationId = (System.Int32)dataRow["MemberQualificationId"];
			entity.LinkedInInternalEducationId = Convert.IsDBNull(dataRow["LinkedInInternalEducationId"]) ? null : (System.Int32?)dataRow["LinkedInInternalEducationId"];
			entity.SchoolName = Convert.IsDBNull(dataRow["SchoolName"]) ? null : (System.String)dataRow["SchoolName"];
			entity.FieldOfStudy = Convert.IsDBNull(dataRow["FieldOfStudy"]) ? null : (System.String)dataRow["FieldOfStudy"];
			entity.StartYear = Convert.IsDBNull(dataRow["StartYear"]) ? null : (System.Int32?)dataRow["StartYear"];
			entity.EndYear = Convert.IsDBNull(dataRow["EndYear"]) ? null : (System.Int32?)dataRow["EndYear"];
			entity.Degree = Convert.IsDBNull(dataRow["Degree"]) ? null : (System.String)dataRow["Degree"];
			entity.Activities = Convert.IsDBNull(dataRow["Activities"]) ? null : (System.String)dataRow["Activities"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.QualificationLevelId = Convert.IsDBNull(dataRow["QualificationLevelID"]) ? null : (System.Int32?)dataRow["QualificationLevelID"];
			entity.QualificationLevelOther = Convert.IsDBNull(dataRow["QualificationLevelOther"]) ? null : (System.String)dataRow["QualificationLevelOther"];
			entity.Major = Convert.IsDBNull(dataRow["Major"]) ? null : (System.String)dataRow["Major"];
			entity.Present = Convert.IsDBNull(dataRow["Present"]) ? null : (System.Boolean?)dataRow["Present"];
			entity.StartMonth = Convert.IsDBNull(dataRow["StartMonth"]) ? null : (System.Int32?)dataRow["StartMonth"];
			entity.EndMonth = Convert.IsDBNull(dataRow["EndMonth"]) ? null : (System.Int32?)dataRow["EndMonth"];
			entity.Graduated = Convert.IsDBNull(dataRow["Graduated"]) ? null : (System.Boolean?)dataRow["Graduated"];
			entity.NonGraduatedCredits = Convert.IsDBNull(dataRow["NonGraduatedCredits"]) ? null : (System.Int32?)dataRow["NonGraduatedCredits"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberQualification"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberQualification Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberQualification entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberQualification object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberQualification instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberQualification Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberQualification entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberQualificationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberQualification</c>
	///</summary>
	public enum MemberQualificationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion MemberQualificationChildEntityTypes
	
	#region MemberQualificationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberQualificationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationFilterBuilder : SqlFilterBuilder<MemberQualificationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilterBuilder class.
		/// </summary>
		public MemberQualificationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberQualificationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberQualificationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberQualificationFilterBuilder
	
	#region MemberQualificationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberQualificationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationParameterBuilder : ParameterizedSqlFilterBuilder<MemberQualificationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationParameterBuilder class.
		/// </summary>
		public MemberQualificationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberQualificationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberQualificationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberQualificationParameterBuilder
	
	#region MemberQualificationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberQualificationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberQualificationSortBuilder : SqlSortBuilder<MemberQualificationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationSqlSortBuilder class.
		/// </summary>
		public MemberQualificationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberQualificationSortBuilder
	
} // end namespace
