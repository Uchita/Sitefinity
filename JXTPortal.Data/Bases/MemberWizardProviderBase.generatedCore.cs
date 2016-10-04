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
	/// This class is the base class for any <see cref="MemberWizardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberWizardProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberWizard, JXTPortal.Entities.MemberWizardKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberWizardKey key)
		{
			return Delete(transactionManager, key.MemberWizardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberWizardId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberWizardId)
		{
			return Delete(null, _memberWizardId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberWizardId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberWizardId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		FK__MemberWiz__LastM__2847DBB7 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		FK__MemberWiz__LastM__2847DBB7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		/// <remarks></remarks>
		public TList<MemberWizard> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		FK__MemberWiz__LastM__2847DBB7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		fkMemberWizLastm2847Dbb7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		fkMemberWizLastm2847Dbb7 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__LastM__2847DBB7 key.
		///		FK__MemberWiz__LastM__2847DBB7 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public abstract TList<MemberWizard> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		FK__MemberWiz__SiteI__293BFFF0 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetBySiteId(System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		FK__MemberWiz__SiteI__293BFFF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		/// <remarks></remarks>
		public TList<MemberWizard> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		FK__MemberWiz__SiteI__293BFFF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		fkMemberWizSitei293Bfff0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetBySiteId(System.Int32? _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		fkMemberWizSitei293Bfff0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public TList<MemberWizard> GetBySiteId(System.Int32? _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberWiz__SiteI__293BFFF0 key.
		///		FK__MemberWiz__SiteI__293BFFF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberWizard objects.</returns>
		public abstract TList<MemberWizard> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberWizard Get(TransactionManager transactionManager, JXTPortal.Entities.MemberWizardKey key, int start, int pageLength)
		{
			return GetByMemberWizardId(transactionManager, key.MemberWizardId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="_memberWizardId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public JXTPortal.Entities.MemberWizard GetByMemberWizardId(System.Int32 _memberWizardId)
		{
			int count = -1;
			return GetByMemberWizardId(null,_memberWizardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="_memberWizardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public JXTPortal.Entities.MemberWizard GetByMemberWizardId(System.Int32 _memberWizardId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberWizardId(null, _memberWizardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberWizardId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public JXTPortal.Entities.MemberWizard GetByMemberWizardId(TransactionManager transactionManager, System.Int32 _memberWizardId)
		{
			int count = -1;
			return GetByMemberWizardId(transactionManager, _memberWizardId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberWizardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public JXTPortal.Entities.MemberWizard GetByMemberWizardId(TransactionManager transactionManager, System.Int32 _memberWizardId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberWizardId(transactionManager, _memberWizardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="_memberWizardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public JXTPortal.Entities.MemberWizard GetByMemberWizardId(System.Int32 _memberWizardId, int start, int pageLength, out int count)
		{
			return GetByMemberWizardId(null, _memberWizardId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberWi__53348B031FB295B6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberWizardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberWizard"/> class.</returns>
		public abstract JXTPortal.Entities.MemberWizard GetByMemberWizardId(TransactionManager transactionManager, System.Int32 _memberWizardId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberWizard_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml, ref System.Int32? memberWizardId)
		{
			 Insert(null, 0, int.MaxValue , siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml, ref memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml, ref System.Int32? memberWizardId)
		{
			 Insert(null, start, pageLength , siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml, ref memberWizardId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml, ref System.Int32? memberWizardId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml, ref memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml, ref System.Int32? memberWizardId);
		
		#endregion
		
		#region MemberWizard_GetBySiteId 
		
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region MemberWizard_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberWizard_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberWizard_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberWizard_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberWizard_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberWizard_GetPaged' stored procedure. 
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
		
		#region MemberWizard_GetByMemberWizardId 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByMemberWizardId' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberWizardId(System.Int32? memberWizardId)
		{
			return GetByMemberWizardId(null, 0, int.MaxValue , memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByMemberWizardId' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberWizardId(int start, int pageLength, System.Int32? memberWizardId)
		{
			return GetByMemberWizardId(null, start, pageLength , memberWizardId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByMemberWizardId' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberWizardId(TransactionManager transactionManager, System.Int32? memberWizardId)
		{
			return GetByMemberWizardId(transactionManager, 0, int.MaxValue , memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByMemberWizardId' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberWizardId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberWizardId);
		
		#endregion
		
		#region MemberWizard_Update 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Update' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			 Update(null, 0, int.MaxValue , memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Update' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			 Update(null, start, pageLength , memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_Update' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			 Update(transactionManager, 0, int.MaxValue , memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Update' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml);
		
		#endregion
		
		#region MemberWizard_CustomGetMemberPoints 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_CustomGetMemberPoints' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPoints"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetMemberPoints(System.Int32? siteId, System.Int32? memberId, ref System.Int32? memberPoints)
		{
			 CustomGetMemberPoints(null, 0, int.MaxValue , siteId, memberId, ref memberPoints);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_CustomGetMemberPoints' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetMemberPoints(int start, int pageLength, System.Int32? siteId, System.Int32? memberId, ref System.Int32? memberPoints)
		{
			 CustomGetMemberPoints(null, start, pageLength , siteId, memberId, ref memberPoints);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_CustomGetMemberPoints' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetMemberPoints(TransactionManager transactionManager, System.Int32? siteId, System.Int32? memberId, ref System.Int32? memberPoints)
		{
			 CustomGetMemberPoints(transactionManager, 0, int.MaxValue , siteId, memberId, ref memberPoints);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_CustomGetMemberPoints' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="memberPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomGetMemberPoints(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? memberId, ref System.Int32? memberPoints);
		
		#endregion
		
		#region MemberWizard_Find 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			return Find(null, start, pageLength , searchUsingOr, memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberWizardId, siteId, memberWizardParentId, profileTitle, cvTitle, rolePreferencesTitle, educationTitle, membershipsTitle, experienceTitle, skillsTitle, profileEnable, cvEnable, rolePreferencesEnable, educationEnable, membershipsEnable, experienceEnable, skillsEnable, globalTemplate, lastModifiedBy, lastModified, directorshipTitle, directorshipEnable, skills, licenseTypes, summaryTitle, personalDetailsTitle, licensesTitle, attachCoverLetterTitle, languagesTitle, referencesTitle, customQuestionTitle, summaryPoints, personalDetailsPoints, licensesPoints, attachCoverLetterPoints, languagesPoints, referencesPoints, customQuestionPoints, profilePoints, cvPoints, rolePreferencesPoints, educationPoints, membershipsPoints, experiencePoints, skillsPoints, directorshipPoints, wizardLanguageXml, customQuestionsXml);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberWizardParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profileTitle"> A <c>System.String</c> instance.</param>
		/// <param name="cvTitle"> A <c>System.String</c> instance.</param>
		/// <param name="rolePreferencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="educationTitle"> A <c>System.String</c> instance.</param>
		/// <param name="membershipsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="experienceTitle"> A <c>System.String</c> instance.</param>
		/// <param name="skillsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="profileEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="cvEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="rolePreferencesEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="educationEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="membershipsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="experienceEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skillsEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="directorshipTitle"> A <c>System.String</c> instance.</param>
		/// <param name="directorshipEnable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="licenseTypes"> A <c>System.String</c> instance.</param>
		/// <param name="summaryTitle"> A <c>System.String</c> instance.</param>
		/// <param name="personalDetailsTitle"> A <c>System.String</c> instance.</param>
		/// <param name="licensesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="attachCoverLetterTitle"> A <c>System.String</c> instance.</param>
		/// <param name="languagesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="referencesTitle"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="summaryPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="personalDetailsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="licensesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="attachCoverLetterPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languagesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customQuestionPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="profilePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="cvPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="rolePreferencesPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="educationPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="membershipsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="experiencePoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="skillsPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="directorshipPoints"> A <c>System.Int32?</c> instance.</param>
		/// <param name="wizardLanguageXml"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionsXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberWizardId, System.Int32? siteId, System.Int32? memberWizardParentId, System.String profileTitle, System.String cvTitle, System.String rolePreferencesTitle, System.String educationTitle, System.String membershipsTitle, System.String experienceTitle, System.String skillsTitle, System.Boolean? profileEnable, System.Boolean? cvEnable, System.Boolean? rolePreferencesEnable, System.Boolean? educationEnable, System.Boolean? membershipsEnable, System.Boolean? experienceEnable, System.Boolean? skillsEnable, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String directorshipTitle, System.Boolean? directorshipEnable, System.String skills, System.String licenseTypes, System.String summaryTitle, System.String personalDetailsTitle, System.String licensesTitle, System.String attachCoverLetterTitle, System.String languagesTitle, System.String referencesTitle, System.String customQuestionTitle, System.Int32? summaryPoints, System.Int32? personalDetailsPoints, System.Int32? licensesPoints, System.Int32? attachCoverLetterPoints, System.Int32? languagesPoints, System.Int32? referencesPoints, System.Int32? customQuestionPoints, System.Int32? profilePoints, System.Int32? cvPoints, System.Int32? rolePreferencesPoints, System.Int32? educationPoints, System.Int32? membershipsPoints, System.Int32? experiencePoints, System.Int32? skillsPoints, System.Int32? directorshipPoints, System.String wizardLanguageXml, System.String customQuestionsXml);
		
		#endregion
		
		#region MemberWizard_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberWizardId)
		{
			 Delete(null, 0, int.MaxValue , memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberWizardId)
		{
			 Delete(null, start, pageLength , memberWizardId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberWizardId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberWizardId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberWizardId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberWizardId);
		
		#endregion
		
		#region MemberWizard_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'MemberWizard_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberWizard&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberWizard&gt;"/></returns>
		public static TList<MemberWizard> Fill(IDataReader reader, TList<MemberWizard> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberWizard c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberWizard")
					.Append("|").Append((System.Int32)reader[((int)MemberWizardColumn.MemberWizardId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberWizard>(
					key.ToString(), // EntityTrackingKey
					"MemberWizard",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberWizard();
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
					c.MemberWizardId = (System.Int32)reader[((int)MemberWizardColumn.MemberWizardId - 1)];
					c.SiteId = (reader.IsDBNull(((int)MemberWizardColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)MemberWizardColumn.SiteId - 1)];
					c.MemberWizardParentId = (reader.IsDBNull(((int)MemberWizardColumn.MemberWizardParentId - 1)))?null:(System.Int32?)reader[((int)MemberWizardColumn.MemberWizardParentId - 1)];
					c.ProfileTitle = (System.String)reader[((int)MemberWizardColumn.ProfileTitle - 1)];
					c.CvTitle = (System.String)reader[((int)MemberWizardColumn.CvTitle - 1)];
					c.RolePreferencesTitle = (System.String)reader[((int)MemberWizardColumn.RolePreferencesTitle - 1)];
					c.EducationTitle = (System.String)reader[((int)MemberWizardColumn.EducationTitle - 1)];
					c.MembershipsTitle = (System.String)reader[((int)MemberWizardColumn.MembershipsTitle - 1)];
					c.ExperienceTitle = (System.String)reader[((int)MemberWizardColumn.ExperienceTitle - 1)];
					c.SkillsTitle = (System.String)reader[((int)MemberWizardColumn.SkillsTitle - 1)];
					c.ProfileEnable = (reader.IsDBNull(((int)MemberWizardColumn.ProfileEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.ProfileEnable - 1)];
					c.CvEnable = (reader.IsDBNull(((int)MemberWizardColumn.CvEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.CvEnable - 1)];
					c.RolePreferencesEnable = (reader.IsDBNull(((int)MemberWizardColumn.RolePreferencesEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.RolePreferencesEnable - 1)];
					c.EducationEnable = (reader.IsDBNull(((int)MemberWizardColumn.EducationEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.EducationEnable - 1)];
					c.MembershipsEnable = (reader.IsDBNull(((int)MemberWizardColumn.MembershipsEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.MembershipsEnable - 1)];
					c.ExperienceEnable = (reader.IsDBNull(((int)MemberWizardColumn.ExperienceEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.ExperienceEnable - 1)];
					c.SkillsEnable = (reader.IsDBNull(((int)MemberWizardColumn.SkillsEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.SkillsEnable - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)MemberWizardColumn.GlobalTemplate - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)MemberWizardColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)MemberWizardColumn.LastModified - 1)];
					c.DirectorshipTitle = (System.String)reader[((int)MemberWizardColumn.DirectorshipTitle - 1)];
					c.DirectorshipEnable = (reader.IsDBNull(((int)MemberWizardColumn.DirectorshipEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.DirectorshipEnable - 1)];
					c.Skills = (reader.IsDBNull(((int)MemberWizardColumn.Skills - 1)))?null:(System.String)reader[((int)MemberWizardColumn.Skills - 1)];
					c.LicenseTypes = (reader.IsDBNull(((int)MemberWizardColumn.LicenseTypes - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LicenseTypes - 1)];
					c.SummaryTitle = (reader.IsDBNull(((int)MemberWizardColumn.SummaryTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.SummaryTitle - 1)];
					c.PersonalDetailsTitle = (reader.IsDBNull(((int)MemberWizardColumn.PersonalDetailsTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.PersonalDetailsTitle - 1)];
					c.LicensesTitle = (reader.IsDBNull(((int)MemberWizardColumn.LicensesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LicensesTitle - 1)];
					c.AttachCoverLetterTitle = (reader.IsDBNull(((int)MemberWizardColumn.AttachCoverLetterTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.AttachCoverLetterTitle - 1)];
					c.LanguagesTitle = (reader.IsDBNull(((int)MemberWizardColumn.LanguagesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LanguagesTitle - 1)];
					c.ReferencesTitle = (reader.IsDBNull(((int)MemberWizardColumn.ReferencesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.ReferencesTitle - 1)];
					c.CustomQuestionTitle = (reader.IsDBNull(((int)MemberWizardColumn.CustomQuestionTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.CustomQuestionTitle - 1)];
					c.SummaryPoints = (System.Int32)reader[((int)MemberWizardColumn.SummaryPoints - 1)];
					c.PersonalDetailsPoints = (System.Int32)reader[((int)MemberWizardColumn.PersonalDetailsPoints - 1)];
					c.LicensesPoints = (System.Int32)reader[((int)MemberWizardColumn.LicensesPoints - 1)];
					c.AttachCoverLetterPoints = (System.Int32)reader[((int)MemberWizardColumn.AttachCoverLetterPoints - 1)];
					c.LanguagesPoints = (System.Int32)reader[((int)MemberWizardColumn.LanguagesPoints - 1)];
					c.ReferencesPoints = (System.Int32)reader[((int)MemberWizardColumn.ReferencesPoints - 1)];
					c.CustomQuestionPoints = (System.Int32)reader[((int)MemberWizardColumn.CustomQuestionPoints - 1)];
					c.ProfilePoints = (System.Int32)reader[((int)MemberWizardColumn.ProfilePoints - 1)];
					c.CvPoints = (System.Int32)reader[((int)MemberWizardColumn.CvPoints - 1)];
					c.RolePreferencesPoints = (System.Int32)reader[((int)MemberWizardColumn.RolePreferencesPoints - 1)];
					c.EducationPoints = (System.Int32)reader[((int)MemberWizardColumn.EducationPoints - 1)];
					c.MembershipsPoints = (System.Int32)reader[((int)MemberWizardColumn.MembershipsPoints - 1)];
					c.ExperiencePoints = (System.Int32)reader[((int)MemberWizardColumn.ExperiencePoints - 1)];
					c.SkillsPoints = (System.Int32)reader[((int)MemberWizardColumn.SkillsPoints - 1)];
					c.DirectorshipPoints = (System.Int32)reader[((int)MemberWizardColumn.DirectorshipPoints - 1)];
					c.WizardLanguageXml = (reader.IsDBNull(((int)MemberWizardColumn.WizardLanguageXml - 1)))?null:(System.String)reader[((int)MemberWizardColumn.WizardLanguageXml - 1)];
					c.CustomQuestionsXml = (reader.IsDBNull(((int)MemberWizardColumn.CustomQuestionsXml - 1)))?null:(System.String)reader[((int)MemberWizardColumn.CustomQuestionsXml - 1)];
					c.MinExperiencesEntry = (System.Int16)reader[((int)MemberWizardColumn.MinExperiencesEntry - 1)];
					c.MinReferencesEntry = (System.Int16)reader[((int)MemberWizardColumn.MinReferencesEntry - 1)];
					c.MinEducationsEntry = (System.Int16)reader[((int)MemberWizardColumn.MinEducationsEntry - 1)];
					c.QualificationNames = (reader.IsDBNull(((int)MemberWizardColumn.QualificationNames - 1)))?null:(System.String)reader[((int)MemberWizardColumn.QualificationNames - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberWizard"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberWizard"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberWizard entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberWizardId = (System.Int32)reader[((int)MemberWizardColumn.MemberWizardId - 1)];
			entity.SiteId = (reader.IsDBNull(((int)MemberWizardColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)MemberWizardColumn.SiteId - 1)];
			entity.MemberWizardParentId = (reader.IsDBNull(((int)MemberWizardColumn.MemberWizardParentId - 1)))?null:(System.Int32?)reader[((int)MemberWizardColumn.MemberWizardParentId - 1)];
			entity.ProfileTitle = (System.String)reader[((int)MemberWizardColumn.ProfileTitle - 1)];
			entity.CvTitle = (System.String)reader[((int)MemberWizardColumn.CvTitle - 1)];
			entity.RolePreferencesTitle = (System.String)reader[((int)MemberWizardColumn.RolePreferencesTitle - 1)];
			entity.EducationTitle = (System.String)reader[((int)MemberWizardColumn.EducationTitle - 1)];
			entity.MembershipsTitle = (System.String)reader[((int)MemberWizardColumn.MembershipsTitle - 1)];
			entity.ExperienceTitle = (System.String)reader[((int)MemberWizardColumn.ExperienceTitle - 1)];
			entity.SkillsTitle = (System.String)reader[((int)MemberWizardColumn.SkillsTitle - 1)];
			entity.ProfileEnable = (reader.IsDBNull(((int)MemberWizardColumn.ProfileEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.ProfileEnable - 1)];
			entity.CvEnable = (reader.IsDBNull(((int)MemberWizardColumn.CvEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.CvEnable - 1)];
			entity.RolePreferencesEnable = (reader.IsDBNull(((int)MemberWizardColumn.RolePreferencesEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.RolePreferencesEnable - 1)];
			entity.EducationEnable = (reader.IsDBNull(((int)MemberWizardColumn.EducationEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.EducationEnable - 1)];
			entity.MembershipsEnable = (reader.IsDBNull(((int)MemberWizardColumn.MembershipsEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.MembershipsEnable - 1)];
			entity.ExperienceEnable = (reader.IsDBNull(((int)MemberWizardColumn.ExperienceEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.ExperienceEnable - 1)];
			entity.SkillsEnable = (reader.IsDBNull(((int)MemberWizardColumn.SkillsEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.SkillsEnable - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)MemberWizardColumn.GlobalTemplate - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)MemberWizardColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)MemberWizardColumn.LastModified - 1)];
			entity.DirectorshipTitle = (System.String)reader[((int)MemberWizardColumn.DirectorshipTitle - 1)];
			entity.DirectorshipEnable = (reader.IsDBNull(((int)MemberWizardColumn.DirectorshipEnable - 1)))?null:(System.Boolean?)reader[((int)MemberWizardColumn.DirectorshipEnable - 1)];
			entity.Skills = (reader.IsDBNull(((int)MemberWizardColumn.Skills - 1)))?null:(System.String)reader[((int)MemberWizardColumn.Skills - 1)];
			entity.LicenseTypes = (reader.IsDBNull(((int)MemberWizardColumn.LicenseTypes - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LicenseTypes - 1)];
			entity.SummaryTitle = (reader.IsDBNull(((int)MemberWizardColumn.SummaryTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.SummaryTitle - 1)];
			entity.PersonalDetailsTitle = (reader.IsDBNull(((int)MemberWizardColumn.PersonalDetailsTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.PersonalDetailsTitle - 1)];
			entity.LicensesTitle = (reader.IsDBNull(((int)MemberWizardColumn.LicensesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LicensesTitle - 1)];
			entity.AttachCoverLetterTitle = (reader.IsDBNull(((int)MemberWizardColumn.AttachCoverLetterTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.AttachCoverLetterTitle - 1)];
			entity.LanguagesTitle = (reader.IsDBNull(((int)MemberWizardColumn.LanguagesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.LanguagesTitle - 1)];
			entity.ReferencesTitle = (reader.IsDBNull(((int)MemberWizardColumn.ReferencesTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.ReferencesTitle - 1)];
			entity.CustomQuestionTitle = (reader.IsDBNull(((int)MemberWizardColumn.CustomQuestionTitle - 1)))?null:(System.String)reader[((int)MemberWizardColumn.CustomQuestionTitle - 1)];
			entity.SummaryPoints = (System.Int32)reader[((int)MemberWizardColumn.SummaryPoints - 1)];
			entity.PersonalDetailsPoints = (System.Int32)reader[((int)MemberWizardColumn.PersonalDetailsPoints - 1)];
			entity.LicensesPoints = (System.Int32)reader[((int)MemberWizardColumn.LicensesPoints - 1)];
			entity.AttachCoverLetterPoints = (System.Int32)reader[((int)MemberWizardColumn.AttachCoverLetterPoints - 1)];
			entity.LanguagesPoints = (System.Int32)reader[((int)MemberWizardColumn.LanguagesPoints - 1)];
			entity.ReferencesPoints = (System.Int32)reader[((int)MemberWizardColumn.ReferencesPoints - 1)];
			entity.CustomQuestionPoints = (System.Int32)reader[((int)MemberWizardColumn.CustomQuestionPoints - 1)];
			entity.ProfilePoints = (System.Int32)reader[((int)MemberWizardColumn.ProfilePoints - 1)];
			entity.CvPoints = (System.Int32)reader[((int)MemberWizardColumn.CvPoints - 1)];
			entity.RolePreferencesPoints = (System.Int32)reader[((int)MemberWizardColumn.RolePreferencesPoints - 1)];
			entity.EducationPoints = (System.Int32)reader[((int)MemberWizardColumn.EducationPoints - 1)];
			entity.MembershipsPoints = (System.Int32)reader[((int)MemberWizardColumn.MembershipsPoints - 1)];
			entity.ExperiencePoints = (System.Int32)reader[((int)MemberWizardColumn.ExperiencePoints - 1)];
			entity.SkillsPoints = (System.Int32)reader[((int)MemberWizardColumn.SkillsPoints - 1)];
			entity.DirectorshipPoints = (System.Int32)reader[((int)MemberWizardColumn.DirectorshipPoints - 1)];
			entity.WizardLanguageXml = (reader.IsDBNull(((int)MemberWizardColumn.WizardLanguageXml - 1)))?null:(System.String)reader[((int)MemberWizardColumn.WizardLanguageXml - 1)];
			entity.CustomQuestionsXml = (reader.IsDBNull(((int)MemberWizardColumn.CustomQuestionsXml - 1)))?null:(System.String)reader[((int)MemberWizardColumn.CustomQuestionsXml - 1)];
			entity.MinExperiencesEntry = (System.Int16)reader[((int)MemberWizardColumn.MinExperiencesEntry - 1)];
			entity.MinReferencesEntry = (System.Int16)reader[((int)MemberWizardColumn.MinReferencesEntry - 1)];
			entity.MinEducationsEntry = (System.Int16)reader[((int)MemberWizardColumn.MinEducationsEntry - 1)];
			entity.QualificationNames = (reader.IsDBNull(((int)MemberWizardColumn.QualificationNames - 1)))?null:(System.String)reader[((int)MemberWizardColumn.QualificationNames - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberWizard"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberWizard"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberWizard entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberWizardId = (System.Int32)dataRow["MemberWizardID"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.MemberWizardParentId = Convert.IsDBNull(dataRow["MemberWizardParentID"]) ? null : (System.Int32?)dataRow["MemberWizardParentID"];
			entity.ProfileTitle = (System.String)dataRow["ProfileTitle"];
			entity.CvTitle = (System.String)dataRow["CVTitle"];
			entity.RolePreferencesTitle = (System.String)dataRow["RolePreferencesTitle"];
			entity.EducationTitle = (System.String)dataRow["EducationTitle"];
			entity.MembershipsTitle = (System.String)dataRow["MembershipsTitle"];
			entity.ExperienceTitle = (System.String)dataRow["ExperienceTitle"];
			entity.SkillsTitle = (System.String)dataRow["SkillsTitle"];
			entity.ProfileEnable = Convert.IsDBNull(dataRow["ProfileEnable"]) ? null : (System.Boolean?)dataRow["ProfileEnable"];
			entity.CvEnable = Convert.IsDBNull(dataRow["CVEnable"]) ? null : (System.Boolean?)dataRow["CVEnable"];
			entity.RolePreferencesEnable = Convert.IsDBNull(dataRow["RolePreferencesEnable"]) ? null : (System.Boolean?)dataRow["RolePreferencesEnable"];
			entity.EducationEnable = Convert.IsDBNull(dataRow["EducationEnable"]) ? null : (System.Boolean?)dataRow["EducationEnable"];
			entity.MembershipsEnable = Convert.IsDBNull(dataRow["MembershipsEnable"]) ? null : (System.Boolean?)dataRow["MembershipsEnable"];
			entity.ExperienceEnable = Convert.IsDBNull(dataRow["ExperienceEnable"]) ? null : (System.Boolean?)dataRow["ExperienceEnable"];
			entity.SkillsEnable = Convert.IsDBNull(dataRow["SkillsEnable"]) ? null : (System.Boolean?)dataRow["SkillsEnable"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.DirectorshipTitle = (System.String)dataRow["DirectorshipTitle"];
			entity.DirectorshipEnable = Convert.IsDBNull(dataRow["DirectorshipEnable"]) ? null : (System.Boolean?)dataRow["DirectorshipEnable"];
			entity.Skills = Convert.IsDBNull(dataRow["Skills"]) ? null : (System.String)dataRow["Skills"];
			entity.LicenseTypes = Convert.IsDBNull(dataRow["LicenseTypes"]) ? null : (System.String)dataRow["LicenseTypes"];
			entity.SummaryTitle = Convert.IsDBNull(dataRow["SummaryTitle"]) ? null : (System.String)dataRow["SummaryTitle"];
			entity.PersonalDetailsTitle = Convert.IsDBNull(dataRow["PersonalDetailsTitle"]) ? null : (System.String)dataRow["PersonalDetailsTitle"];
			entity.LicensesTitle = Convert.IsDBNull(dataRow["LicensesTitle"]) ? null : (System.String)dataRow["LicensesTitle"];
			entity.AttachCoverLetterTitle = Convert.IsDBNull(dataRow["AttachCoverLetterTitle"]) ? null : (System.String)dataRow["AttachCoverLetterTitle"];
			entity.LanguagesTitle = Convert.IsDBNull(dataRow["LanguagesTitle"]) ? null : (System.String)dataRow["LanguagesTitle"];
			entity.ReferencesTitle = Convert.IsDBNull(dataRow["ReferencesTitle"]) ? null : (System.String)dataRow["ReferencesTitle"];
			entity.CustomQuestionTitle = Convert.IsDBNull(dataRow["CustomQuestionTitle"]) ? null : (System.String)dataRow["CustomQuestionTitle"];
			entity.SummaryPoints = (System.Int32)dataRow["SummaryPoints"];
			entity.PersonalDetailsPoints = (System.Int32)dataRow["PersonalDetailsPoints"];
			entity.LicensesPoints = (System.Int32)dataRow["LicensesPoints"];
			entity.AttachCoverLetterPoints = (System.Int32)dataRow["AttachCoverLetterPoints"];
			entity.LanguagesPoints = (System.Int32)dataRow["LanguagesPoints"];
			entity.ReferencesPoints = (System.Int32)dataRow["ReferencesPoints"];
			entity.CustomQuestionPoints = (System.Int32)dataRow["CustomQuestionPoints"];
			entity.ProfilePoints = (System.Int32)dataRow["ProfilePoints"];
			entity.CvPoints = (System.Int32)dataRow["CVPoints"];
			entity.RolePreferencesPoints = (System.Int32)dataRow["RolePreferencesPoints"];
			entity.EducationPoints = (System.Int32)dataRow["EducationPoints"];
			entity.MembershipsPoints = (System.Int32)dataRow["MembershipsPoints"];
			entity.ExperiencePoints = (System.Int32)dataRow["ExperiencePoints"];
			entity.SkillsPoints = (System.Int32)dataRow["SkillsPoints"];
			entity.DirectorshipPoints = (System.Int32)dataRow["DirectorshipPoints"];
			entity.WizardLanguageXml = Convert.IsDBNull(dataRow["WizardLanguageXML"]) ? null : (System.String)dataRow["WizardLanguageXML"];
			entity.CustomQuestionsXml = Convert.IsDBNull(dataRow["CustomQuestionsXML"]) ? null : (System.String)dataRow["CustomQuestionsXML"];
			entity.MinExperiencesEntry = (System.Int16)dataRow["MinExperiencesEntry"];
			entity.MinReferencesEntry = (System.Int16)dataRow["MinReferencesEntry"];
			entity.MinEducationsEntry = (System.Int16)dataRow["MinEducationsEntry"];
			entity.QualificationNames = Convert.IsDBNull(dataRow["QualificationNames"]) ? null : (System.String)dataRow["QualificationNames"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberWizard"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberWizard Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberWizard entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region SiteIdSource	
			if (CanDeepLoad(entity, "Sites|SiteIdSource", deepLoadType, innerList) 
				&& entity.SiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SiteId ?? (int)0);
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdSource = tmpEntity;
				else
					entity.SiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, (entity.SiteId ?? (int)0));		
				
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberWizard object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberWizard instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberWizard Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberWizard entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region MemberWizardChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberWizard</c>
	///</summary>
	public enum MemberWizardChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion MemberWizardChildEntityTypes
	
	#region MemberWizardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberWizardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardFilterBuilder : SqlFilterBuilder<MemberWizardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilterBuilder class.
		/// </summary>
		public MemberWizardFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberWizardFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberWizardFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberWizardFilterBuilder
	
	#region MemberWizardParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberWizardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardParameterBuilder : ParameterizedSqlFilterBuilder<MemberWizardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardParameterBuilder class.
		/// </summary>
		public MemberWizardParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberWizardParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberWizardParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberWizardParameterBuilder
	
	#region MemberWizardSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberWizardColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberWizardSortBuilder : SqlSortBuilder<MemberWizardColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardSqlSortBuilder class.
		/// </summary>
		public MemberWizardSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberWizardSortBuilder
	
} // end namespace
