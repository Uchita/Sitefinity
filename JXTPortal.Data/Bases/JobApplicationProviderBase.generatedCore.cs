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
	/// This class is the base class for any <see cref="JobApplicationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobApplicationProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobApplication, JXTPortal.Entities.JobApplicationKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationKey key)
		{
			return Delete(transactionManager, key.JobApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobApplicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobApplicationId)
		{
			return Delete(null, _jobApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobApplicationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		FK__JobApplic__SiteI__09D52582 Description: 
		/// </summary>
		/// <param name="_siteIdReferral"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		public TList<JobApplication> GetBySiteIdReferral(System.Int32? _siteIdReferral)
		{
			int count = -1;
			return GetBySiteIdReferral(_siteIdReferral, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		FK__JobApplic__SiteI__09D52582 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteIdReferral"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplication> GetBySiteIdReferral(TransactionManager transactionManager, System.Int32? _siteIdReferral)
		{
			int count = -1;
			return GetBySiteIdReferral(transactionManager, _siteIdReferral, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		FK__JobApplic__SiteI__09D52582 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteIdReferral"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		public TList<JobApplication> GetBySiteIdReferral(TransactionManager transactionManager, System.Int32? _siteIdReferral, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdReferral(transactionManager, _siteIdReferral, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		fkJobApplicSitei09d52582 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteIdReferral"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		public TList<JobApplication> GetBySiteIdReferral(System.Int32? _siteIdReferral, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteIdReferral(null, _siteIdReferral, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		fkJobApplicSitei09d52582 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteIdReferral"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		public TList<JobApplication> GetBySiteIdReferral(System.Int32? _siteIdReferral, int start, int pageLength,out int count)
		{
			return GetBySiteIdReferral(null, _siteIdReferral, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__09D52582 key.
		///		FK__JobApplic__SiteI__09D52582 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteIdReferral"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplication objects.</returns>
		public abstract TList<JobApplication> GetBySiteIdReferral(TransactionManager transactionManager, System.Int32? _siteIdReferral, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobApplication Get(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationKey key, int start, int pageLength)
		{
			return GetByJobApplicationId(transactionManager, key.JobApplicationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(null,_jobArchiveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength, out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public abstract TList<JobApplication> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(null,_jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByJobId(System.Int32? _jobId, int start, int pageLength, out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobApplication_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public abstract TList<JobApplication> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key JobApplication_MemberID index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByMemberId(System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(null,_memberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the JobApplication_MemberID index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByMemberId(System.Int32? _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(null, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the JobApplication_MemberID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the JobApplication_MemberID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the JobApplication_MemberID index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public TList<JobApplication> GetByMemberId(System.Int32? _memberId, int start, int pageLength, out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the JobApplication_MemberID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobApplication&gt;"/> class.</returns>
		public abstract TList<JobApplication> GetByMemberId(TransactionManager transactionManager, System.Int32? _memberId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="_jobApplicationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public JXTPortal.Entities.JobApplication GetByJobApplicationId(System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(null,_jobApplicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public JXTPortal.Entities.JobApplication GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public JXTPortal.Entities.JobApplication GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public JXTPortal.Entities.JobApplication GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public JXTPortal.Entities.JobApplication GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength, out int count)
		{
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplication__05107065 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplication"/> class.</returns>
		public abstract JXTPortal.Entities.JobApplication GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobApplication_GetByAdvertiserIdJobId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobId(System.Int32? advertiserId, System.Int32? jobId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobId(null, 0, int.MaxValue , advertiserId, jobId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobId(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobId(null, start, pageLength , advertiserId, jobId, pageNumber, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobId(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobId(transactionManager, 0, int.MaxValue , advertiserId, jobId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobId, System.Int32? pageNumber, System.Int32? pageSize);
		
		#endregion
		
		#region JobApplication_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByMemberId' stored procedure. 
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
		///	This method wrap the 'JobApplication_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region JobApplication_CustomGetByJobIdMemberId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetByJobIdMemberId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplication&gt;"/> instance.</returns>
		public TList<JobApplication> CustomGetByJobIdMemberId(System.Int32? jobId, System.Int32? memberId)
		{
			return CustomGetByJobIdMemberId(null, 0, int.MaxValue , jobId, memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetByJobIdMemberId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplication&gt;"/> instance.</returns>
		public TList<JobApplication> CustomGetByJobIdMemberId(int start, int pageLength, System.Int32? jobId, System.Int32? memberId)
		{
			return CustomGetByJobIdMemberId(null, start, pageLength , jobId, memberId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetByJobIdMemberId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplication&gt;"/> instance.</returns>
		public TList<JobApplication> CustomGetByJobIdMemberId(TransactionManager transactionManager, System.Int32? jobId, System.Int32? memberId)
		{
			return CustomGetByJobIdMemberId(transactionManager, 0, int.MaxValue , jobId, memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetByJobIdMemberId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplication&gt;"/> instance.</returns>
		public abstract TList<JobApplication> CustomGetByJobIdMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? memberId);
		
		#endregion
		
		#region JobApplication_Find 
		
		/// <summary>
		///	This method wrap the 'JobApplication_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId);
		
		#endregion
		
		#region JobApplication_Update 
		
		/// <summary>
		///	This method wrap the 'JobApplication_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			 Update(null, 0, int.MaxValue , jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			 Update(null, start, pageLength , jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobApplicationId, applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, jobAppValidateId, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationId, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Guid? jobAppValidateId, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId);
		
		#endregion
		
		#region JobApplication_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobApplication_GetByJobApplicationId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationId(System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(null, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationId(int start, int pageLength, System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(null, start, pageLength , jobApplicationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationId(TransactionManager transactionManager, System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(transactionManager, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobApplicationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationId);
		
		#endregion
		
		#region JobApplication_CustomGetJobApplicationDetails 
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetJobApplicationDetails' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobApplicationDetails(System.DateTime? applicationDate, System.Int32? siteId)
		{
			return CustomGetJobApplicationDetails(null, 0, int.MaxValue , applicationDate, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetJobApplicationDetails' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobApplicationDetails(int start, int pageLength, System.DateTime? applicationDate, System.Int32? siteId)
		{
			return CustomGetJobApplicationDetails(null, start, pageLength , applicationDate, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetJobApplicationDetails' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobApplicationDetails(TransactionManager transactionManager, System.DateTime? applicationDate, System.Int32? siteId)
		{
			return CustomGetJobApplicationDetails(transactionManager, 0, int.MaxValue , applicationDate, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetJobApplicationDetails' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetJobApplicationDetails(TransactionManager transactionManager, int start, int pageLength , System.DateTime? applicationDate, System.Int32? siteId);
		
		#endregion
		
		#region JobApplication_Delete 
		
		/// <summary>
		///	This method wrap the 'JobApplication_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobApplicationId)
		{
			 Delete(null, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobApplicationId)
		{
			 Delete(null, start, pageLength , jobApplicationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobApplicationId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationId);
		
		#endregion
		
		#region JobApplication_GetByAdvertiserIdJobArchiveId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobArchiveId(System.Int32? advertiserId, System.Int32? jobArchiveId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobArchiveId(null, 0, int.MaxValue , advertiserId, jobArchiveId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobArchiveId(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobArchiveId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobArchiveId(null, start, pageLength , advertiserId, jobArchiveId, pageNumber, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobArchiveId(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobArchiveId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserIdJobArchiveId(transactionManager, 0, int.MaxValue , advertiserId, jobArchiveId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserIdJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobArchiveId, System.Int32? pageNumber, System.Int32? pageSize);
		
		#endregion
		
		#region JobApplication_GetJobsNameByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetJobsNameByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobsNameByMemberId(System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobsNameByMemberId(null, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetJobsNameByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobsNameByMemberId(int start, int pageLength, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobsNameByMemberId(null, start, pageLength , memberId, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_GetJobsNameByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobsNameByMemberId(TransactionManager transactionManager, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobsNameByMemberId(transactionManager, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetJobsNameByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetJobsNameByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region JobApplication_Insert 
		
		/// <summary>
		///	This method wrap the 'JobApplication_Insert' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId, ref System.Int32? jobApplicationId, ref System.Guid? jobAppValidateId)
		{
			 Insert(null, 0, int.MaxValue , applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId, ref jobApplicationId, ref jobAppValidateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Insert' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId, ref System.Int32? jobApplicationId, ref System.Guid? jobAppValidateId)
		{
			 Insert(null, start, pageLength , applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId, ref jobApplicationId, ref jobAppValidateId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_Insert' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId, ref System.Int32? jobApplicationId, ref System.Guid? jobAppValidateId)
		{
			 Insert(transactionManager, 0, int.MaxValue , applicationDate, jobId, memberId, memberResumeFile, memberCoverLetterFile, applicationStatus, siteIdReferral, urlReferral, applicantGrade, lastViewedDate, firstName, surname, emailAddress, mobilePhone, memberNote, advertiserNote, jobArchiveId, draft, jobApplicationTypeId, externalXmlFilename, customQuestionnaireXml, externalPdfFilename, fileDownloaded, appliedWith, screeningQuestionaireXml, screeningQuestionsGuid, processDate, processException, externalId, ref jobApplicationId, ref jobAppValidateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Insert' stored procedure. 
		/// </summary>
		/// <param name="applicationDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberResumeFile"> A <c>System.String</c> instance.</param>
		/// <param name="memberCoverLetterFile"> A <c>System.String</c> instance.</param>
		/// <param name="applicationStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="urlReferral"> A <c>System.String</c> instance.</param>
		/// <param name="applicantGrade"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastViewedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="memberNote"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserNote"> A <c>System.String</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="draft"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalXmlFilename"> A <c>System.String</c> instance.</param>
		/// <param name="customQuestionnaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="externalPdfFilename"> A <c>System.String</c> instance.</param>
		/// <param name="fileDownloaded"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="appliedWith"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionaireXml"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="processDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="processException"> A <c>System.String</c> instance.</param>
		/// <param name="externalId"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAppValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.DateTime? applicationDate, System.Int32? jobId, System.Int32? memberId, System.String memberResumeFile, System.String memberCoverLetterFile, System.Int32? applicationStatus, System.Int32? siteIdReferral, System.String urlReferral, System.Int32? applicantGrade, System.DateTime? lastViewedDate, System.String firstName, System.String surname, System.String emailAddress, System.String mobilePhone, System.String memberNote, System.String advertiserNote, System.Int32? jobArchiveId, System.Boolean? draft, System.Int32? jobApplicationTypeId, System.String externalXmlFilename, System.String customQuestionnaireXml, System.String externalPdfFilename, System.Boolean? fileDownloaded, System.String appliedWith, System.String screeningQuestionaireXml, System.Guid? screeningQuestionsGuid, System.DateTime? processDate, System.String processException, System.String externalId, ref System.Int32? jobApplicationId, ref System.Guid? jobAppValidateId);
		
		#endregion
		
		#region JobApplication_GetBySiteIdReferral 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetBySiteIdReferral' stored procedure. 
		/// </summary>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdReferral(int start, int pageLength, System.Int32? siteIdReferral)
		{
			return GetBySiteIdReferral(null, start, pageLength , siteIdReferral);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetBySiteIdReferral' stored procedure. 
		/// </summary>
		/// <param name="siteIdReferral"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdReferral(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteIdReferral);
		
		#endregion
		
		#region JobApplication_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(int start, int pageLength, System.Int32? advertiserId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserId(null, start, pageLength , advertiserId, pageNumber, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? pageNumber, System.Int32? pageSize)
		{
			return GetByAdvertiserId(transactionManager, 0, int.MaxValue , advertiserId, pageNumber, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? pageNumber, System.Int32? pageSize);
		
		#endregion
		
		#region JobApplication_GetByJobArchiveId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobApplication_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobApplication_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplication_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplication_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplication_GetPaged' stored procedure. 
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
		
		#region JobApplication_CustomGetDraftJobsByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetDraftJobsByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetDraftJobsByMemberId(System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetDraftJobsByMemberId(null, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetDraftJobsByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetDraftJobsByMemberId(int start, int pageLength, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetDraftJobsByMemberId(null, start, pageLength , memberId, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetDraftJobsByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetDraftJobsByMemberId(TransactionManager transactionManager, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetDraftJobsByMemberId(transactionManager, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetDraftJobsByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetDraftJobsByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region JobApplication_CustomGetNewJobApplications 
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetNewJobApplications' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewJobApplications(System.Int32? siteId, System.Int32? jobApplicationId, System.Int32? advertiserUserId)
		{
			return CustomGetNewJobApplications(null, 0, int.MaxValue , siteId, jobApplicationId, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetNewJobApplications' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewJobApplications(int start, int pageLength, System.Int32? siteId, System.Int32? jobApplicationId, System.Int32? advertiserUserId)
		{
			return CustomGetNewJobApplications(null, start, pageLength , siteId, jobApplicationId, advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetNewJobApplications' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewJobApplications(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobApplicationId, System.Int32? advertiserUserId)
		{
			return CustomGetNewJobApplications(transactionManager, 0, int.MaxValue , siteId, jobApplicationId, advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomGetNewJobApplications' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetNewJobApplications(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobApplicationId, System.Int32? advertiserUserId);
		
		#endregion
		
		#region JobApplication_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobApplication_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Get_List' stored procedure. 
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
		///	This method wrap the 'JobApplication_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobApplication_CustomUpdateDownloadedFileStatus 
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomUpdateDownloadedFileStatus' stored procedure. 
		/// </summary>
		/// <param name="jobappids"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateDownloadedFileStatus(System.String jobappids)
		{
			 CustomUpdateDownloadedFileStatus(null, 0, int.MaxValue , jobappids);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomUpdateDownloadedFileStatus' stored procedure. 
		/// </summary>
		/// <param name="jobappids"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateDownloadedFileStatus(int start, int pageLength, System.String jobappids)
		{
			 CustomUpdateDownloadedFileStatus(null, start, pageLength , jobappids);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplication_CustomUpdateDownloadedFileStatus' stored procedure. 
		/// </summary>
		/// <param name="jobappids"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateDownloadedFileStatus(TransactionManager transactionManager, System.String jobappids)
		{
			 CustomUpdateDownloadedFileStatus(transactionManager, 0, int.MaxValue , jobappids);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplication_CustomUpdateDownloadedFileStatus' stored procedure. 
		/// </summary>
		/// <param name="jobappids"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomUpdateDownloadedFileStatus(TransactionManager transactionManager, int start, int pageLength , System.String jobappids);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobApplication&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobApplication&gt;"/></returns>
		public static TList<JobApplication> Fill(IDataReader reader, TList<JobApplication> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobApplication c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobApplication")
					.Append("|").Append((System.Int32)reader[((int)JobApplicationColumn.JobApplicationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobApplication>(
					key.ToString(), // EntityTrackingKey
					"JobApplication",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobApplication();
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
					c.JobApplicationId = (System.Int32)reader[((int)JobApplicationColumn.JobApplicationId - 1)];
					c.ApplicationDate = (reader.IsDBNull(((int)JobApplicationColumn.ApplicationDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.ApplicationDate - 1)];
					c.JobId = (reader.IsDBNull(((int)JobApplicationColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobId - 1)];
					c.MemberId = (reader.IsDBNull(((int)JobApplicationColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.MemberId - 1)];
					c.MemberResumeFile = (reader.IsDBNull(((int)JobApplicationColumn.MemberResumeFile - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberResumeFile - 1)];
					c.MemberCoverLetterFile = (reader.IsDBNull(((int)JobApplicationColumn.MemberCoverLetterFile - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberCoverLetterFile - 1)];
					c.ApplicationStatus = (reader.IsDBNull(((int)JobApplicationColumn.ApplicationStatus - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.ApplicationStatus - 1)];
					c.JobAppValidateId = (System.Guid)reader[((int)JobApplicationColumn.JobAppValidateId - 1)];
					c.SiteIdReferral = (reader.IsDBNull(((int)JobApplicationColumn.SiteIdReferral - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.SiteIdReferral - 1)];
					c.UrlReferral = (reader.IsDBNull(((int)JobApplicationColumn.UrlReferral - 1)))?null:(System.String)reader[((int)JobApplicationColumn.UrlReferral - 1)];
					c.ApplicantGrade = (reader.IsDBNull(((int)JobApplicationColumn.ApplicantGrade - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.ApplicantGrade - 1)];
					c.LastViewedDate = (reader.IsDBNull(((int)JobApplicationColumn.LastViewedDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.LastViewedDate - 1)];
					c.FirstName = (System.String)reader[((int)JobApplicationColumn.FirstName - 1)];
					c.Surname = (System.String)reader[((int)JobApplicationColumn.Surname - 1)];
					c.EmailAddress = (System.String)reader[((int)JobApplicationColumn.EmailAddress - 1)];
					c.MobilePhone = (reader.IsDBNull(((int)JobApplicationColumn.MobilePhone - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MobilePhone - 1)];
					c.MemberNote = (reader.IsDBNull(((int)JobApplicationColumn.MemberNote - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberNote - 1)];
					c.AdvertiserNote = (reader.IsDBNull(((int)JobApplicationColumn.AdvertiserNote - 1)))?null:(System.String)reader[((int)JobApplicationColumn.AdvertiserNote - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobApplicationColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobArchiveId - 1)];
					c.Draft = (reader.IsDBNull(((int)JobApplicationColumn.Draft - 1)))?null:(System.Boolean?)reader[((int)JobApplicationColumn.Draft - 1)];
					c.JobApplicationTypeId = (reader.IsDBNull(((int)JobApplicationColumn.JobApplicationTypeId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobApplicationTypeId - 1)];
					c.ExternalXmlFilename = (reader.IsDBNull(((int)JobApplicationColumn.ExternalXmlFilename - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalXmlFilename - 1)];
					c.CustomQuestionnaireXml = (reader.IsDBNull(((int)JobApplicationColumn.CustomQuestionnaireXml - 1)))?null:(System.String)reader[((int)JobApplicationColumn.CustomQuestionnaireXml - 1)];
					c.ExternalPdfFilename = (reader.IsDBNull(((int)JobApplicationColumn.ExternalPdfFilename - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalPdfFilename - 1)];
					c.FileDownloaded = (reader.IsDBNull(((int)JobApplicationColumn.FileDownloaded - 1)))?null:(System.Boolean?)reader[((int)JobApplicationColumn.FileDownloaded - 1)];
					c.AppliedWith = (reader.IsDBNull(((int)JobApplicationColumn.AppliedWith - 1)))?null:(System.String)reader[((int)JobApplicationColumn.AppliedWith - 1)];
					c.ScreeningQuestionaireXml = (reader.IsDBNull(((int)JobApplicationColumn.ScreeningQuestionaireXml - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ScreeningQuestionaireXml - 1)];
					c.ScreeningQuestionsGuid = (reader.IsDBNull(((int)JobApplicationColumn.ScreeningQuestionsGuid - 1)))?null:(System.Guid?)reader[((int)JobApplicationColumn.ScreeningQuestionsGuid - 1)];
					c.ProcessDate = (reader.IsDBNull(((int)JobApplicationColumn.ProcessDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.ProcessDate - 1)];
					c.ProcessException = (reader.IsDBNull(((int)JobApplicationColumn.ProcessException - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ProcessException - 1)];
					c.ExternalId = (reader.IsDBNull(((int)JobApplicationColumn.ExternalId - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplication"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplication"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobApplication entity)
		{
			if (!reader.Read()) return;
			
			entity.JobApplicationId = (System.Int32)reader[((int)JobApplicationColumn.JobApplicationId - 1)];
			entity.ApplicationDate = (reader.IsDBNull(((int)JobApplicationColumn.ApplicationDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.ApplicationDate - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobApplicationColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobId - 1)];
			entity.MemberId = (reader.IsDBNull(((int)JobApplicationColumn.MemberId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.MemberId - 1)];
			entity.MemberResumeFile = (reader.IsDBNull(((int)JobApplicationColumn.MemberResumeFile - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberResumeFile - 1)];
			entity.MemberCoverLetterFile = (reader.IsDBNull(((int)JobApplicationColumn.MemberCoverLetterFile - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberCoverLetterFile - 1)];
			entity.ApplicationStatus = (reader.IsDBNull(((int)JobApplicationColumn.ApplicationStatus - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.ApplicationStatus - 1)];
			entity.JobAppValidateId = (System.Guid)reader[((int)JobApplicationColumn.JobAppValidateId - 1)];
			entity.SiteIdReferral = (reader.IsDBNull(((int)JobApplicationColumn.SiteIdReferral - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.SiteIdReferral - 1)];
			entity.UrlReferral = (reader.IsDBNull(((int)JobApplicationColumn.UrlReferral - 1)))?null:(System.String)reader[((int)JobApplicationColumn.UrlReferral - 1)];
			entity.ApplicantGrade = (reader.IsDBNull(((int)JobApplicationColumn.ApplicantGrade - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.ApplicantGrade - 1)];
			entity.LastViewedDate = (reader.IsDBNull(((int)JobApplicationColumn.LastViewedDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.LastViewedDate - 1)];
			entity.FirstName = (System.String)reader[((int)JobApplicationColumn.FirstName - 1)];
			entity.Surname = (System.String)reader[((int)JobApplicationColumn.Surname - 1)];
			entity.EmailAddress = (System.String)reader[((int)JobApplicationColumn.EmailAddress - 1)];
			entity.MobilePhone = (reader.IsDBNull(((int)JobApplicationColumn.MobilePhone - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MobilePhone - 1)];
			entity.MemberNote = (reader.IsDBNull(((int)JobApplicationColumn.MemberNote - 1)))?null:(System.String)reader[((int)JobApplicationColumn.MemberNote - 1)];
			entity.AdvertiserNote = (reader.IsDBNull(((int)JobApplicationColumn.AdvertiserNote - 1)))?null:(System.String)reader[((int)JobApplicationColumn.AdvertiserNote - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobApplicationColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobArchiveId - 1)];
			entity.Draft = (reader.IsDBNull(((int)JobApplicationColumn.Draft - 1)))?null:(System.Boolean?)reader[((int)JobApplicationColumn.Draft - 1)];
			entity.JobApplicationTypeId = (reader.IsDBNull(((int)JobApplicationColumn.JobApplicationTypeId - 1)))?null:(System.Int32?)reader[((int)JobApplicationColumn.JobApplicationTypeId - 1)];
			entity.ExternalXmlFilename = (reader.IsDBNull(((int)JobApplicationColumn.ExternalXmlFilename - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalXmlFilename - 1)];
			entity.CustomQuestionnaireXml = (reader.IsDBNull(((int)JobApplicationColumn.CustomQuestionnaireXml - 1)))?null:(System.String)reader[((int)JobApplicationColumn.CustomQuestionnaireXml - 1)];
			entity.ExternalPdfFilename = (reader.IsDBNull(((int)JobApplicationColumn.ExternalPdfFilename - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalPdfFilename - 1)];
			entity.FileDownloaded = (reader.IsDBNull(((int)JobApplicationColumn.FileDownloaded - 1)))?null:(System.Boolean?)reader[((int)JobApplicationColumn.FileDownloaded - 1)];
			entity.AppliedWith = (reader.IsDBNull(((int)JobApplicationColumn.AppliedWith - 1)))?null:(System.String)reader[((int)JobApplicationColumn.AppliedWith - 1)];
			entity.ScreeningQuestionaireXml = (reader.IsDBNull(((int)JobApplicationColumn.ScreeningQuestionaireXml - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ScreeningQuestionaireXml - 1)];
			entity.ScreeningQuestionsGuid = (reader.IsDBNull(((int)JobApplicationColumn.ScreeningQuestionsGuid - 1)))?null:(System.Guid?)reader[((int)JobApplicationColumn.ScreeningQuestionsGuid - 1)];
			entity.ProcessDate = (reader.IsDBNull(((int)JobApplicationColumn.ProcessDate - 1)))?null:(System.DateTime?)reader[((int)JobApplicationColumn.ProcessDate - 1)];
			entity.ProcessException = (reader.IsDBNull(((int)JobApplicationColumn.ProcessException - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ProcessException - 1)];
			entity.ExternalId = (reader.IsDBNull(((int)JobApplicationColumn.ExternalId - 1)))?null:(System.String)reader[((int)JobApplicationColumn.ExternalId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplication"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplication"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobApplication entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobApplicationId = (System.Int32)dataRow["JobApplicationID"];
			entity.ApplicationDate = Convert.IsDBNull(dataRow["ApplicationDate"]) ? null : (System.DateTime?)dataRow["ApplicationDate"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.MemberId = Convert.IsDBNull(dataRow["MemberID"]) ? null : (System.Int32?)dataRow["MemberID"];
			entity.MemberResumeFile = Convert.IsDBNull(dataRow["MemberResumeFile"]) ? null : (System.String)dataRow["MemberResumeFile"];
			entity.MemberCoverLetterFile = Convert.IsDBNull(dataRow["MemberCoverLetterFile"]) ? null : (System.String)dataRow["MemberCoverLetterFile"];
			entity.ApplicationStatus = Convert.IsDBNull(dataRow["ApplicationStatus"]) ? null : (System.Int32?)dataRow["ApplicationStatus"];
			entity.JobAppValidateId = (System.Guid)dataRow["JobAppValidateID"];
			entity.SiteIdReferral = Convert.IsDBNull(dataRow["SiteID_Referral"]) ? null : (System.Int32?)dataRow["SiteID_Referral"];
			entity.UrlReferral = Convert.IsDBNull(dataRow["URL_Referral"]) ? null : (System.String)dataRow["URL_Referral"];
			entity.ApplicantGrade = Convert.IsDBNull(dataRow["ApplicantGrade"]) ? null : (System.Int32?)dataRow["ApplicantGrade"];
			entity.LastViewedDate = Convert.IsDBNull(dataRow["LastViewedDate"]) ? null : (System.DateTime?)dataRow["LastViewedDate"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.Surname = (System.String)dataRow["Surname"];
			entity.EmailAddress = (System.String)dataRow["EmailAddress"];
			entity.MobilePhone = Convert.IsDBNull(dataRow["MobilePhone"]) ? null : (System.String)dataRow["MobilePhone"];
			entity.MemberNote = Convert.IsDBNull(dataRow["MemberNote"]) ? null : (System.String)dataRow["MemberNote"];
			entity.AdvertiserNote = Convert.IsDBNull(dataRow["AdvertiserNote"]) ? null : (System.String)dataRow["AdvertiserNote"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.Draft = Convert.IsDBNull(dataRow["Draft"]) ? null : (System.Boolean?)dataRow["Draft"];
			entity.JobApplicationTypeId = Convert.IsDBNull(dataRow["JobApplicationTypeID"]) ? null : (System.Int32?)dataRow["JobApplicationTypeID"];
			entity.ExternalXmlFilename = Convert.IsDBNull(dataRow["ExternalXMLFilename"]) ? null : (System.String)dataRow["ExternalXMLFilename"];
			entity.CustomQuestionnaireXml = Convert.IsDBNull(dataRow["CustomQuestionnaireXML"]) ? null : (System.String)dataRow["CustomQuestionnaireXML"];
			entity.ExternalPdfFilename = Convert.IsDBNull(dataRow["ExternalPDFFilename"]) ? null : (System.String)dataRow["ExternalPDFFilename"];
			entity.FileDownloaded = Convert.IsDBNull(dataRow["FileDownloaded"]) ? null : (System.Boolean?)dataRow["FileDownloaded"];
			entity.AppliedWith = Convert.IsDBNull(dataRow["AppliedWith"]) ? null : (System.String)dataRow["AppliedWith"];
			entity.ScreeningQuestionaireXml = Convert.IsDBNull(dataRow["ScreeningQuestionaireXML"]) ? null : (System.String)dataRow["ScreeningQuestionaireXML"];
			entity.ScreeningQuestionsGuid = Convert.IsDBNull(dataRow["ScreeningQuestionsGuid"]) ? null : (System.Guid?)dataRow["ScreeningQuestionsGuid"];
			entity.ProcessDate = Convert.IsDBNull(dataRow["ProcessDate"]) ? null : (System.DateTime?)dataRow["ProcessDate"];
			entity.ProcessException = Convert.IsDBNull(dataRow["ProcessException"]) ? null : (System.String)dataRow["ProcessException"];
			entity.ExternalId = Convert.IsDBNull(dataRow["ExternalID"]) ? null : (System.String)dataRow["ExternalID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplication"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplication Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobApplication entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region JobArchiveIdSource	
			if (CanDeepLoad(entity, "JobsArchive|JobArchiveIdSource", deepLoadType, innerList) 
				&& entity.JobArchiveIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobArchiveId ?? (int)0);
				JobsArchive tmpEntity = EntityManager.LocateEntity<JobsArchive>(EntityLocator.ConstructKeyFromPkItems(typeof(JobsArchive), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobArchiveIdSource = tmpEntity;
				else
					entity.JobArchiveIdSource = DataRepository.JobsArchiveProvider.GetByJobId(transactionManager, (entity.JobArchiveId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobArchiveIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobArchiveIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsArchiveProvider.DeepLoad(transactionManager, entity.JobArchiveIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobArchiveIdSource

			#region JobIdSource	
			if (CanDeepLoad(entity, "Jobs|JobIdSource", deepLoadType, innerList) 
				&& entity.JobIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobId ?? (int)0);
				Jobs tmpEntity = EntityManager.LocateEntity<Jobs>(EntityLocator.ConstructKeyFromPkItems(typeof(Jobs), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobIdSource = tmpEntity;
				else
					entity.JobIdSource = DataRepository.JobsProvider.GetByJobId(transactionManager, (entity.JobId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsProvider.DeepLoad(transactionManager, entity.JobIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobIdSource

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

			#region SiteIdReferralSource	
			if (CanDeepLoad(entity, "Sites|SiteIdReferralSource", deepLoadType, innerList) 
				&& entity.SiteIdReferralSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SiteIdReferral ?? (int)0);
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdReferralSource = tmpEntity;
				else
					entity.SiteIdReferralSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, (entity.SiteIdReferral ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteIdReferralSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteIdReferralSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SitesProvider.DeepLoad(transactionManager, entity.SiteIdReferralSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteIdReferralSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByJobApplicationId methods when available
			
			#region JobApplicationNotesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationNotesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationNotesCollection = DataRepository.JobApplicationNotesProvider.GetByJobApplicationId(transactionManager, entity.JobApplicationId);

				if (deep && entity.JobApplicationNotesCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplicationNotes>) DataRepository.JobApplicationNotesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationNotesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobApplication object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobApplication instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplication Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobApplication entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region JobArchiveIdSource
			if (CanDeepSave(entity, "JobsArchive|JobArchiveIdSource", deepSaveType, innerList) 
				&& entity.JobArchiveIdSource != null)
			{
				DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobArchiveIdSource);
				entity.JobArchiveId = entity.JobArchiveIdSource.JobId;
			}
			#endregion 
			
			#region JobIdSource
			if (CanDeepSave(entity, "Jobs|JobIdSource", deepSaveType, innerList) 
				&& entity.JobIdSource != null)
			{
				DataRepository.JobsProvider.Save(transactionManager, entity.JobIdSource);
				entity.JobId = entity.JobIdSource.JobId;
			}
			#endregion 
			
			#region MemberIdSource
			if (CanDeepSave(entity, "Members|MemberIdSource", deepSaveType, innerList) 
				&& entity.MemberIdSource != null)
			{
				DataRepository.MembersProvider.Save(transactionManager, entity.MemberIdSource);
				entity.MemberId = entity.MemberIdSource.MemberId;
			}
			#endregion 
			
			#region SiteIdReferralSource
			if (CanDeepSave(entity, "Sites|SiteIdReferralSource", deepSaveType, innerList) 
				&& entity.SiteIdReferralSource != null)
			{
				DataRepository.SitesProvider.Save(transactionManager, entity.SiteIdReferralSource);
				entity.SiteIdReferral = entity.SiteIdReferralSource.SiteId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<JobApplicationNotes>
				if (CanDeepSave(entity.JobApplicationNotesCollection, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplicationNotes child in entity.JobApplicationNotesCollection)
					{
						if(child.JobApplicationIdSource != null)
						{
							child.JobApplicationId = child.JobApplicationIdSource.JobApplicationId;
						}
						else
						{
							child.JobApplicationId = entity.JobApplicationId;
						}

					}

					if (entity.JobApplicationNotesCollection.Count > 0 || entity.JobApplicationNotesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationNotesProvider.Save(transactionManager, entity.JobApplicationNotesCollection);
						
						deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplicationNotes >) DataRepository.JobApplicationNotesProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationNotesCollection, deepSaveType, childTypes, innerList }
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
	
	#region JobApplicationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobApplication</c>
	///</summary>
	public enum JobApplicationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>JobsArchive</c> at JobArchiveIdSource
		///</summary>
		[ChildEntityType(typeof(JobsArchive))]
		JobsArchive,
			
		///<summary>
		/// Composite Property for <c>Jobs</c> at JobIdSource
		///</summary>
		[ChildEntityType(typeof(Jobs))]
		Jobs,
			
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdReferralSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>JobApplication</c> as OneToMany for JobApplicationNotesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplicationNotes>))]
		JobApplicationNotesCollection,
	}
	
	#endregion JobApplicationChildEntityTypes
	
	#region JobApplicationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobApplicationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationFilterBuilder : SqlFilterBuilder<JobApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilterBuilder class.
		/// </summary>
		public JobApplicationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationFilterBuilder
	
	#region JobApplicationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobApplicationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationParameterBuilder : ParameterizedSqlFilterBuilder<JobApplicationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationParameterBuilder class.
		/// </summary>
		public JobApplicationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationParameterBuilder
	
	#region JobApplicationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobApplicationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplication"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobApplicationSortBuilder : SqlSortBuilder<JobApplicationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationSqlSortBuilder class.
		/// </summary>
		public JobApplicationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobApplicationSortBuilder
	
} // end namespace
