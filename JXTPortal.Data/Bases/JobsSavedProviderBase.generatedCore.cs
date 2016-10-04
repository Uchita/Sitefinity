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
	/// This class is the base class for any <see cref="JobsSavedProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobsSavedProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobsSaved, JXTPortal.Entities.JobsSavedKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobsSavedKey key)
		{
			return Delete(transactionManager, key.JobSaveId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobSaveId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobSaveId)
		{
			return Delete(null, _jobSaveId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobSaveId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobSaveId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		FK__JobsSaved__JobAr__5F43C5EB Description: 
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(_jobArchiveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		FK__JobsSaved__JobAr__5F43C5EB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		/// <remarks></remarks>
		public TList<JobsSaved> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		FK__JobsSaved__JobAr__5F43C5EB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		fkJobsSavedJobAr5f43c5Eb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		fkJobsSavedJobAr5f43c5Eb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength,out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobAr__5F43C5EB key.
		///		FK__JobsSaved__JobAr__5F43C5EB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public abstract TList<JobsSaved> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		FK__JobsSaved__JobID__63112973 Description: 
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(_jobId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		FK__JobsSaved__JobID__63112973 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		/// <remarks></remarks>
		public TList<JobsSaved> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		FK__JobsSaved__JobID__63112973 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		fkJobsSavedJobId63112973 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobId(null, _jobId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		fkJobsSavedJobId63112973 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByJobId(System.Int32? _jobId, int start, int pageLength,out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__JobID__63112973 key.
		///		FK__JobsSaved__JobID__63112973 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public abstract TList<JobsSaved> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		FK__JobsSaved__Membe__64054DAC Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		FK__JobsSaved__Membe__64054DAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		/// <remarks></remarks>
		public TList<JobsSaved> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		FK__JobsSaved__Membe__64054DAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		fkJobsSavedMembe64054Dac Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		fkJobsSavedMembe64054Dac Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public TList<JobsSaved> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsSaved__Membe__64054DAC key.
		///		FK__JobsSaved__Membe__64054DAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsSaved objects.</returns>
		public abstract TList<JobsSaved> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobsSaved Get(TransactionManager transactionManager, JXTPortal.Entities.JobsSavedKey key, int start, int pageLength)
		{
			return GetByJobSaveId(transactionManager, key.JobSaveId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="_jobSaveId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public JXTPortal.Entities.JobsSaved GetByJobSaveId(System.Int32 _jobSaveId)
		{
			int count = -1;
			return GetByJobSaveId(null,_jobSaveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="_jobSaveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public JXTPortal.Entities.JobsSaved GetByJobSaveId(System.Int32 _jobSaveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobSaveId(null, _jobSaveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobSaveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public JXTPortal.Entities.JobsSaved GetByJobSaveId(TransactionManager transactionManager, System.Int32 _jobSaveId)
		{
			int count = -1;
			return GetByJobSaveId(transactionManager, _jobSaveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobSaveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public JXTPortal.Entities.JobsSaved GetByJobSaveId(TransactionManager transactionManager, System.Int32 _jobSaveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobSaveId(transactionManager, _jobSaveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="_jobSaveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public JXTPortal.Entities.JobsSaved GetByJobSaveId(System.Int32 _jobSaveId, int start, int pageLength, out int count)
		{
			return GetByJobSaveId(null, _jobSaveId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsSaved__621D053A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobSaveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsSaved"/> class.</returns>
		public abstract JXTPortal.Entities.JobsSaved GetByJobSaveId(TransactionManager transactionManager, System.Int32 _jobSaveId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobsSaved_Insert 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId, ref System.Int32? jobSaveId)
		{
			 Insert(null, 0, int.MaxValue , jobId, memberId, lastModified, jobArchiveId, ref jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId, ref System.Int32? jobSaveId)
		{
			 Insert(null, start, pageLength , jobId, memberId, lastModified, jobArchiveId, ref jobSaveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId, ref System.Int32? jobSaveId)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobId, memberId, lastModified, jobArchiveId, ref jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId, ref System.Int32? jobSaveId);
		
		#endregion
		
		#region JobsSaved_GetByJobId 
		
        /// <summary>
		///	This method wrap the 'JobsSaved_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobsSaved_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region JobsSaved_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobsSaved_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region JobsSaved_GetByJobSaveId 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobSaveId' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByJobSaveId(System.Int32? jobSaveId)
		{
			return GetByJobSaveId(null, 0, int.MaxValue , jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobSaveId' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByJobSaveId(int start, int pageLength, System.Int32? jobSaveId)
		{
			return GetByJobSaveId(null, start, pageLength , jobSaveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobSaveId' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByJobSaveId(TransactionManager transactionManager, System.Int32? jobSaveId)
		{
			return GetByJobSaveId(transactionManager, 0, int.MaxValue , jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobSaveId' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> GetByJobSaveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobSaveId);
		
		#endregion
		
		#region JobsSaved_Update 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Update' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			 Update(null, 0, int.MaxValue , jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Update' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			 Update(null, start, pageLength , jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_Update' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Update' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobsSaved_Find 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Find(System.Boolean? searchUsingOr, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobSaveId, jobId, memberId, lastModified, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobSaveId, System.Int32? jobId, System.Int32? memberId, System.DateTime? lastModified, System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobsSaved_Delete 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobSaveId)
		{
			 Delete(null, 0, int.MaxValue , jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobSaveId)
		{
			 Delete(null, start, pageLength , jobSaveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobSaveId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobSaveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobSaveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobSaveId);
		
		#endregion
		
		#region JobsSaved_GetByJobArchiveId 
		
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public TList<JobsSaved> GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
				
	    /// <summary>
		///	This method wrap the 'JobsSaved_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobsSaved&gt;"/> instance.</returns>
		public abstract TList<JobsSaved> GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobsSaved_GetJobNameByMemberID 
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetJobNameByMemberID' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobNameByMemberID(System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobNameByMemberID(null, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetJobNameByMemberID' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobNameByMemberID(int start, int pageLength, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobNameByMemberID(null, start, pageLength , memberId, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'JobsSaved_GetJobNameByMemberID' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobNameByMemberID(TransactionManager transactionManager, System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetJobNameByMemberID(transactionManager, 0, int.MaxValue , memberId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'JobsSaved_GetJobNameByMemberID' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetJobNameByMemberID(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobsSaved&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobsSaved&gt;"/></returns>
		public static TList<JobsSaved> Fill(IDataReader reader, TList<JobsSaved> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobsSaved c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobsSaved")
					.Append("|").Append((System.Int32)reader[((int)JobsSavedColumn.JobSaveId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobsSaved>(
					key.ToString(), // EntityTrackingKey
					"JobsSaved",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobsSaved();
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
					c.JobSaveId = (System.Int32)reader[((int)JobsSavedColumn.JobSaveId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobsSavedColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobsSavedColumn.JobId - 1)];
					c.MemberId = (System.Int32)reader[((int)JobsSavedColumn.MemberId - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobsSavedColumn.LastModified - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobsSavedColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobsSavedColumn.JobArchiveId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobsSaved"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsSaved"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobsSaved entity)
		{
			if (!reader.Read()) return;
			
			entity.JobSaveId = (System.Int32)reader[((int)JobsSavedColumn.JobSaveId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobsSavedColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobsSavedColumn.JobId - 1)];
			entity.MemberId = (System.Int32)reader[((int)JobsSavedColumn.MemberId - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobsSavedColumn.LastModified - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobsSavedColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobsSavedColumn.JobArchiveId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobsSaved"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsSaved"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobsSaved entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobSaveId = (System.Int32)dataRow["JobSaveID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsSaved"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobsSaved Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobsSaved entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobsSaved object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobsSaved instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobsSaved Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobsSaved entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region JobsSavedChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobsSaved</c>
	///</summary>
	public enum JobsSavedChildEntityTypes
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
		}
	
	#endregion JobsSavedChildEntityTypes
	
	#region JobsSavedFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobsSavedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsSaved"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsSavedFilterBuilder : SqlFilterBuilder<JobsSavedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilterBuilder class.
		/// </summary>
		public JobsSavedFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsSavedFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsSavedFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsSavedFilterBuilder
	
	#region JobsSavedParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobsSavedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsSaved"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsSavedParameterBuilder : ParameterizedSqlFilterBuilder<JobsSavedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSavedParameterBuilder class.
		/// </summary>
		public JobsSavedParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsSavedParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsSavedParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsSavedParameterBuilder
	
	#region JobsSavedSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobsSavedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsSaved"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobsSavedSortBuilder : SqlSortBuilder<JobsSavedColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSavedSqlSortBuilder class.
		/// </summary>
		public JobsSavedSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobsSavedSortBuilder
	
} // end namespace
