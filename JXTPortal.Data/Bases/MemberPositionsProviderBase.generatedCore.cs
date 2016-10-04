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
	/// This class is the base class for any <see cref="MemberPositionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberPositionsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberPositions, JXTPortal.Entities.MemberPositionsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberPositionsKey key)
		{
			return Delete(transactionManager, key.MemberPositionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberPositionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberPositionId)
		{
			return Delete(null, _memberPositionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberPositionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberPositionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fk_MemberPositionsMember Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		public TList<MemberPositions> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fk_MemberPositionsMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		/// <remarks></remarks>
		public TList<MemberPositions> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fk_MemberPositionsMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		public TList<MemberPositions> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fkMemberPositionsMember Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		public TList<MemberPositions> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fkMemberPositionsMember Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		public TList<MemberPositions> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_MemberPositionsMember key.
		///		fk_MemberPositionsMember Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberPositions objects.</returns>
		public abstract TList<MemberPositions> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberPositions Get(TransactionManager transactionManager, JXTPortal.Entities.MemberPositionsKey key, int start, int pageLength)
		{
			return GetByMemberPositionId(transactionManager, key.MemberPositionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MemberPositions index.
		/// </summary>
		/// <param name="_memberPositionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public JXTPortal.Entities.MemberPositions GetByMemberPositionId(System.Int32 _memberPositionId)
		{
			int count = -1;
			return GetByMemberPositionId(null,_memberPositionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberPositions index.
		/// </summary>
		/// <param name="_memberPositionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public JXTPortal.Entities.MemberPositions GetByMemberPositionId(System.Int32 _memberPositionId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberPositionId(null, _memberPositionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberPositions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberPositionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public JXTPortal.Entities.MemberPositions GetByMemberPositionId(TransactionManager transactionManager, System.Int32 _memberPositionId)
		{
			int count = -1;
			return GetByMemberPositionId(transactionManager, _memberPositionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberPositions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberPositionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public JXTPortal.Entities.MemberPositions GetByMemberPositionId(TransactionManager transactionManager, System.Int32 _memberPositionId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberPositionId(transactionManager, _memberPositionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberPositions index.
		/// </summary>
		/// <param name="_memberPositionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public JXTPortal.Entities.MemberPositions GetByMemberPositionId(System.Int32 _memberPositionId, int start, int pageLength, out int count)
		{
			return GetByMemberPositionId(null, _memberPositionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MemberPositions index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberPositionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberPositions"/> class.</returns>
		public abstract JXTPortal.Entities.MemberPositions GetByMemberPositionId(TransactionManager transactionManager, System.Int32 _memberPositionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberPositions_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId, ref System.Int32? memberPositionId)
		{
			 Insert(null, 0, int.MaxValue , linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId, ref memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId, ref System.Int32? memberPositionId)
		{
			 Insert(null, start, pageLength , linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId, ref memberPositionId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberPositions_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId, ref System.Int32? memberPositionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId, ref memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Insert' stored procedure. 
		/// </summary>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId, ref System.Int32? memberPositionId);
		
		#endregion
		
		#region MemberPositions_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'MemberPositions_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'MemberPositions_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region MemberPositions_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberPositions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberPositions_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberPositions_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberPositions_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberPositions_GetPaged' stored procedure. 
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
		
		#region MemberPositions_GetByMemberPositionId 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberPositionId' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberPositionId(System.Int32? memberPositionId)
		{
			return GetByMemberPositionId(null, 0, int.MaxValue , memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberPositionId' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberPositionId(int start, int pageLength, System.Int32? memberPositionId)
		{
			return GetByMemberPositionId(null, start, pageLength , memberPositionId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberPositionId' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberPositionId(TransactionManager transactionManager, System.Int32? memberPositionId)
		{
			return GetByMemberPositionId(transactionManager, 0, int.MaxValue , memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_GetByMemberPositionId' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberPositionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberPositionId);
		
		#endregion
		
		#region MemberPositions_Find 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			return Find(null, start, pageLength , searchUsingOr, memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberPositions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId);
		
		#endregion
		
		#region MemberPositions_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberPositionId)
		{
			 Delete(null, 0, int.MaxValue , memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberPositionId)
		{
			 Delete(null, start, pageLength , memberPositionId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberPositions_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberPositionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberPositionId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberPositionId);
		
		#endregion
		
		#region MemberPositions_Update 
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Update' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			 Update(null, 0, int.MaxValue , memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Update' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			 Update(null, start, pageLength , memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberPositions_Update' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId)
		{
			 Update(transactionManager, 0, int.MaxValue , memberPositionId, linkedInInternalPositionId, title, summary, companyId, companyName, companyIndustry, startMonth, startYear, endMonth, endYear, isCurrent, memberId, organisationWebsite, responsibilitiesAndAchievements, typeOfDirectorship, additionalRolesAndResponsibilities, isDirectorship, city, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberPositions_Update' stored procedure. 
		/// </summary>
		/// <param name="memberPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInInternalPositionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="summary"> A <c>System.String</c> instance.</param>
		/// <param name="companyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="companyIndustry"> A <c>System.String</c> instance.</param>
		/// <param name="startMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="startYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endMonth"> A <c>System.Int32?</c> instance.</param>
		/// <param name="endYear"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isCurrent"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="organisationWebsite"> A <c>System.String</c> instance.</param>
		/// <param name="responsibilitiesAndAchievements"> A <c>System.String</c> instance.</param>
		/// <param name="typeOfDirectorship"> A <c>System.String</c> instance.</param>
		/// <param name="additionalRolesAndResponsibilities"> A <c>System.String</c> instance.</param>
		/// <param name="isDirectorship"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="city"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberPositionId, System.Int32? linkedInInternalPositionId, System.String title, System.String summary, System.Int32? companyId, System.String companyName, System.String companyIndustry, System.Int32? startMonth, System.Int32? startYear, System.Int32? endMonth, System.Int32? endYear, System.Boolean? isCurrent, System.Int32? memberId, System.String organisationWebsite, System.String responsibilitiesAndAchievements, System.String typeOfDirectorship, System.String additionalRolesAndResponsibilities, System.Boolean? isDirectorship, System.String city, System.Int32? countryId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberPositions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberPositions&gt;"/></returns>
		public static TList<MemberPositions> Fill(IDataReader reader, TList<MemberPositions> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberPositions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberPositions")
					.Append("|").Append((System.Int32)reader[((int)MemberPositionsColumn.MemberPositionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberPositions>(
					key.ToString(), // EntityTrackingKey
					"MemberPositions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberPositions();
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
					c.MemberPositionId = (System.Int32)reader[((int)MemberPositionsColumn.MemberPositionId - 1)];
					c.LinkedInInternalPositionId = (reader.IsDBNull(((int)MemberPositionsColumn.LinkedInInternalPositionId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.LinkedInInternalPositionId - 1)];
					c.Title = (reader.IsDBNull(((int)MemberPositionsColumn.Title - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.Title - 1)];
					c.Summary = (reader.IsDBNull(((int)MemberPositionsColumn.Summary - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.Summary - 1)];
					c.CompanyId = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.CompanyId - 1)];
					c.CompanyName = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyName - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.CompanyName - 1)];
					c.CompanyIndustry = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyIndustry - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.CompanyIndustry - 1)];
					c.StartMonth = (reader.IsDBNull(((int)MemberPositionsColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.StartMonth - 1)];
					c.StartYear = (reader.IsDBNull(((int)MemberPositionsColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.StartYear - 1)];
					c.EndMonth = (reader.IsDBNull(((int)MemberPositionsColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.EndMonth - 1)];
					c.EndYear = (reader.IsDBNull(((int)MemberPositionsColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.EndYear - 1)];
					c.IsCurrent = (System.Boolean)reader[((int)MemberPositionsColumn.IsCurrent - 1)];
					c.MemberId = (System.Int32)reader[((int)MemberPositionsColumn.MemberId - 1)];
					c.OrganisationWebsite = (reader.IsDBNull(((int)MemberPositionsColumn.OrganisationWebsite - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.OrganisationWebsite - 1)];
					c.ResponsibilitiesAndAchievements = (reader.IsDBNull(((int)MemberPositionsColumn.ResponsibilitiesAndAchievements - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.ResponsibilitiesAndAchievements - 1)];
					c.TypeOfDirectorship = (reader.IsDBNull(((int)MemberPositionsColumn.TypeOfDirectorship - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.TypeOfDirectorship - 1)];
					c.AdditionalRolesAndResponsibilities = (reader.IsDBNull(((int)MemberPositionsColumn.AdditionalRolesAndResponsibilities - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.AdditionalRolesAndResponsibilities - 1)];
					c.IsDirectorship = (System.Boolean)reader[((int)MemberPositionsColumn.IsDirectorship - 1)];
					c.City = (reader.IsDBNull(((int)MemberPositionsColumn.City - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.City - 1)];
					c.CountryId = (reader.IsDBNull(((int)MemberPositionsColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.CountryId - 1)];
					c.State = (reader.IsDBNull(((int)MemberPositionsColumn.State - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.State - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberPositions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberPositions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberPositions entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberPositionId = (System.Int32)reader[((int)MemberPositionsColumn.MemberPositionId - 1)];
			entity.LinkedInInternalPositionId = (reader.IsDBNull(((int)MemberPositionsColumn.LinkedInInternalPositionId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.LinkedInInternalPositionId - 1)];
			entity.Title = (reader.IsDBNull(((int)MemberPositionsColumn.Title - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.Title - 1)];
			entity.Summary = (reader.IsDBNull(((int)MemberPositionsColumn.Summary - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.Summary - 1)];
			entity.CompanyId = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.CompanyId - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyName - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.CompanyName - 1)];
			entity.CompanyIndustry = (reader.IsDBNull(((int)MemberPositionsColumn.CompanyIndustry - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.CompanyIndustry - 1)];
			entity.StartMonth = (reader.IsDBNull(((int)MemberPositionsColumn.StartMonth - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.StartMonth - 1)];
			entity.StartYear = (reader.IsDBNull(((int)MemberPositionsColumn.StartYear - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.StartYear - 1)];
			entity.EndMonth = (reader.IsDBNull(((int)MemberPositionsColumn.EndMonth - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.EndMonth - 1)];
			entity.EndYear = (reader.IsDBNull(((int)MemberPositionsColumn.EndYear - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.EndYear - 1)];
			entity.IsCurrent = (System.Boolean)reader[((int)MemberPositionsColumn.IsCurrent - 1)];
			entity.MemberId = (System.Int32)reader[((int)MemberPositionsColumn.MemberId - 1)];
			entity.OrganisationWebsite = (reader.IsDBNull(((int)MemberPositionsColumn.OrganisationWebsite - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.OrganisationWebsite - 1)];
			entity.ResponsibilitiesAndAchievements = (reader.IsDBNull(((int)MemberPositionsColumn.ResponsibilitiesAndAchievements - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.ResponsibilitiesAndAchievements - 1)];
			entity.TypeOfDirectorship = (reader.IsDBNull(((int)MemberPositionsColumn.TypeOfDirectorship - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.TypeOfDirectorship - 1)];
			entity.AdditionalRolesAndResponsibilities = (reader.IsDBNull(((int)MemberPositionsColumn.AdditionalRolesAndResponsibilities - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.AdditionalRolesAndResponsibilities - 1)];
			entity.IsDirectorship = (System.Boolean)reader[((int)MemberPositionsColumn.IsDirectorship - 1)];
			entity.City = (reader.IsDBNull(((int)MemberPositionsColumn.City - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.City - 1)];
			entity.CountryId = (reader.IsDBNull(((int)MemberPositionsColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)MemberPositionsColumn.CountryId - 1)];
			entity.State = (reader.IsDBNull(((int)MemberPositionsColumn.State - 1)))?null:(System.String)reader[((int)MemberPositionsColumn.State - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberPositions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberPositions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberPositions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberPositionId = (System.Int32)dataRow["MemberPositionId"];
			entity.LinkedInInternalPositionId = Convert.IsDBNull(dataRow["LinkedInInternalPositionId"]) ? null : (System.Int32?)dataRow["LinkedInInternalPositionId"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.Summary = Convert.IsDBNull(dataRow["Summary"]) ? null : (System.String)dataRow["Summary"];
			entity.CompanyId = Convert.IsDBNull(dataRow["CompanyId"]) ? null : (System.Int32?)dataRow["CompanyId"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.CompanyIndustry = Convert.IsDBNull(dataRow["CompanyIndustry"]) ? null : (System.String)dataRow["CompanyIndustry"];
			entity.StartMonth = Convert.IsDBNull(dataRow["StartMonth"]) ? null : (System.Int32?)dataRow["StartMonth"];
			entity.StartYear = Convert.IsDBNull(dataRow["StartYear"]) ? null : (System.Int32?)dataRow["StartYear"];
			entity.EndMonth = Convert.IsDBNull(dataRow["EndMonth"]) ? null : (System.Int32?)dataRow["EndMonth"];
			entity.EndYear = Convert.IsDBNull(dataRow["EndYear"]) ? null : (System.Int32?)dataRow["EndYear"];
			entity.IsCurrent = (System.Boolean)dataRow["IsCurrent"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.OrganisationWebsite = Convert.IsDBNull(dataRow["OrganisationWebsite"]) ? null : (System.String)dataRow["OrganisationWebsite"];
			entity.ResponsibilitiesAndAchievements = Convert.IsDBNull(dataRow["ResponsibilitiesAndAchievements"]) ? null : (System.String)dataRow["ResponsibilitiesAndAchievements"];
			entity.TypeOfDirectorship = Convert.IsDBNull(dataRow["TypeOfDirectorship"]) ? null : (System.String)dataRow["TypeOfDirectorship"];
			entity.AdditionalRolesAndResponsibilities = Convert.IsDBNull(dataRow["AdditionalRolesAndResponsibilities"]) ? null : (System.String)dataRow["AdditionalRolesAndResponsibilities"];
			entity.IsDirectorship = (System.Boolean)dataRow["IsDirectorship"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.State = Convert.IsDBNull(dataRow["State"]) ? null : (System.String)dataRow["State"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberPositions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberPositions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberPositions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberPositions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberPositions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberPositions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberPositions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberPositionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberPositions</c>
	///</summary>
	public enum MemberPositionsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion MemberPositionsChildEntityTypes
	
	#region MemberPositionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberPositionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsFilterBuilder : SqlFilterBuilder<MemberPositionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilterBuilder class.
		/// </summary>
		public MemberPositionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberPositionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberPositionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberPositionsFilterBuilder
	
	#region MemberPositionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberPositionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsParameterBuilder : ParameterizedSqlFilterBuilder<MemberPositionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsParameterBuilder class.
		/// </summary>
		public MemberPositionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberPositionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberPositionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberPositionsParameterBuilder
	
	#region MemberPositionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberPositionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberPositionsSortBuilder : SqlSortBuilder<MemberPositionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsSqlSortBuilder class.
		/// </summary>
		public MemberPositionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberPositionsSortBuilder
	
} // end namespace
