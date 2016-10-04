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
	/// This class is the base class for any <see cref="JobApplicationNotesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobApplicationNotesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobApplicationNotes, JXTPortal.Entities.JobApplicationNotesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationNotesKey key)
		{
			return Delete(transactionManager, key.JobApplicationNoteId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobApplicationNoteId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobApplicationNoteId)
		{
			return Delete(null, _jobApplicationNoteId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationNoteId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobApplicationNoteId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		FK__JobApplic__Adver__67D5DE90 Description: 
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(_advertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		FK__JobApplic__Adver__67D5DE90 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		FK__JobApplic__Adver__67D5DE90 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		fkJobApplicAdver67d5De90 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		fkJobApplicAdver67d5De90 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Adver__67D5DE90 key.
		///		FK__JobApplic__Adver__67D5DE90 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public abstract TList<JobApplicationNotes> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		FK__JobApplic__JobAp__69BE2702 Description: 
		/// </summary>
		/// <param name="_jobApplicationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(_jobApplicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		FK__JobApplic__JobAp__69BE2702 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationNotes> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		FK__JobApplic__JobAp__69BE2702 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		fkJobApplicJobAp69Be2702 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		fkJobApplicJobAp69Be2702 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength,out int count)
		{
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__69BE2702 key.
		///		FK__JobApplic__JobAp__69BE2702 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public abstract TList<JobApplicationNotes> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		FK__JobApplic__Membe__68CA02C9 Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		FK__JobApplic__Membe__68CA02C9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationNotes> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		FK__JobApplic__Membe__68CA02C9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		fkJobApplicMembe68Ca02c9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		fkJobApplicMembe68Ca02c9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public TList<JobApplicationNotes> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Membe__68CA02C9 key.
		///		FK__JobApplic__Membe__68CA02C9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationNotes objects.</returns>
		public abstract TList<JobApplicationNotes> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobApplicationNotes Get(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationNotesKey key, int start, int pageLength)
		{
			return GetByJobApplicationNoteId(transactionManager, key.JobApplicationNoteId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="_jobApplicationNoteId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(System.Int32 _jobApplicationNoteId)
		{
			int count = -1;
			return GetByJobApplicationNoteId(null,_jobApplicationNoteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="_jobApplicationNoteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(System.Int32 _jobApplicationNoteId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationNoteId(null, _jobApplicationNoteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationNoteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(TransactionManager transactionManager, System.Int32 _jobApplicationNoteId)
		{
			int count = -1;
			return GetByJobApplicationNoteId(transactionManager, _jobApplicationNoteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationNoteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(TransactionManager transactionManager, System.Int32 _jobApplicationNoteId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationNoteId(transactionManager, _jobApplicationNoteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="_jobApplicationNoteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(System.Int32 _jobApplicationNoteId, int start, int pageLength, out int count)
		{
			return GetByJobApplicationNoteId(null, _jobApplicationNoteId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobApplicationNo__66E1BA57 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationNoteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationNotes"/> class.</returns>
		public abstract JXTPortal.Entities.JobApplicationNotes GetByJobApplicationNoteId(TransactionManager transactionManager, System.Int32 _jobApplicationNoteId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobApplicationNotes_Insert 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note, ref System.Int32? jobApplicationNoteId)
		{
			 Insert(null, 0, int.MaxValue , advertiserUserId, memberId, jobApplicationId, note, ref jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note, ref System.Int32? jobApplicationNoteId)
		{
			 Insert(null, start, pageLength , advertiserUserId, memberId, jobApplicationId, note, ref jobApplicationNoteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note, ref System.Int32? jobApplicationNoteId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserUserId, memberId, jobApplicationId, note, ref jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
			/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note, ref System.Int32? jobApplicationNoteId);
		
		#endregion
		
		#region JobApplicationNotes_GetByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(int start, int pageLength, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, start, pageLength , advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(transactionManager, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> GetByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region JobApplicationNotes_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region JobApplicationNotes_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobApplicationNotes_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region JobApplicationNotes_GetByJobApplicationId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(null, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(int start, int pageLength, System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(null, start, pageLength , jobApplicationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationId(TransactionManager transactionManager, System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(transactionManager, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> GetByJobApplicationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationId);
		
		#endregion
		
		#region JobApplicationNotes_Find 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Find(System.Boolean? searchUsingOr, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			return Find(null, start, pageLength , searchUsingOr, jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note);
		
		#endregion
		
		#region JobApplicationNotes_Delete 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobApplicationNoteId)
		{
			 Delete(null, 0, int.MaxValue , jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobApplicationNoteId)
		{
			 Delete(null, start, pageLength , jobApplicationNoteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobApplicationNoteId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationNoteId);
		
		#endregion
		
		#region JobApplicationNotes_GetByJobApplicationNoteId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationNoteId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationNoteId(System.Int32? jobApplicationNoteId)
		{
			return GetByJobApplicationNoteId(null, 0, int.MaxValue , jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationNoteId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationNoteId(int start, int pageLength, System.Int32? jobApplicationNoteId)
		{
			return GetByJobApplicationNoteId(null, start, pageLength , jobApplicationNoteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationNoteId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public TList<JobApplicationNotes> GetByJobApplicationNoteId(TransactionManager transactionManager, System.Int32? jobApplicationNoteId)
		{
			return GetByJobApplicationNoteId(transactionManager, 0, int.MaxValue , jobApplicationNoteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_GetByJobApplicationNoteId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobApplicationNotes&gt;"/> instance.</returns>
		public abstract TList<JobApplicationNotes> GetByJobApplicationNoteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationNoteId);
		
		#endregion
		
		#region JobApplicationNotes_Update 
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			 Update(null, 0, int.MaxValue , jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			 Update(null, start, pageLength , jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note)
		{
			 Update(transactionManager, 0, int.MaxValue , jobApplicationNoteId, advertiserUserId, memberId, jobApplicationId, note);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationNotes_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationNoteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="note"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationNoteId, System.Int32? advertiserUserId, System.Int32? memberId, System.Int32? jobApplicationId, System.String note);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobApplicationNotes&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobApplicationNotes&gt;"/></returns>
		public static TList<JobApplicationNotes> Fill(IDataReader reader, TList<JobApplicationNotes> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobApplicationNotes c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobApplicationNotes")
					.Append("|").Append((System.Int32)reader[((int)JobApplicationNotesColumn.JobApplicationNoteId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobApplicationNotes>(
					key.ToString(), // EntityTrackingKey
					"JobApplicationNotes",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobApplicationNotes();
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
					c.JobApplicationNoteId = (System.Int32)reader[((int)JobApplicationNotesColumn.JobApplicationNoteId - 1)];
					c.AdvertiserUserId = (System.Int32)reader[((int)JobApplicationNotesColumn.AdvertiserUserId - 1)];
					c.MemberId = (System.Int32)reader[((int)JobApplicationNotesColumn.MemberId - 1)];
					c.JobApplicationId = (System.Int32)reader[((int)JobApplicationNotesColumn.JobApplicationId - 1)];
					c.Note = (System.String)reader[((int)JobApplicationNotesColumn.Note - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationNotes"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationNotes"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobApplicationNotes entity)
		{
			if (!reader.Read()) return;
			
			entity.JobApplicationNoteId = (System.Int32)reader[((int)JobApplicationNotesColumn.JobApplicationNoteId - 1)];
			entity.AdvertiserUserId = (System.Int32)reader[((int)JobApplicationNotesColumn.AdvertiserUserId - 1)];
			entity.MemberId = (System.Int32)reader[((int)JobApplicationNotesColumn.MemberId - 1)];
			entity.JobApplicationId = (System.Int32)reader[((int)JobApplicationNotesColumn.JobApplicationId - 1)];
			entity.Note = (System.String)reader[((int)JobApplicationNotesColumn.Note - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationNotes"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationNotes"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobApplicationNotes entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobApplicationNoteId = (System.Int32)dataRow["JobApplicationNoteID"];
			entity.AdvertiserUserId = (System.Int32)dataRow["AdvertiserUserID"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.JobApplicationId = (System.Int32)dataRow["JobApplicationID"];
			entity.Note = (System.String)dataRow["Note"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationNotes"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationNotes Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationNotes entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserUserIdSource	
			if (CanDeepLoad(entity, "AdvertiserUsers|AdvertiserUserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserUserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserUserId;
				AdvertiserUsers tmpEntity = EntityManager.LocateEntity<AdvertiserUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserUserIdSource = tmpEntity;
				else
					entity.AdvertiserUserIdSource = DataRepository.AdvertiserUsersProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserUserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserUsersProvider.DeepLoad(transactionManager, entity.AdvertiserUserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserUserIdSource

			#region JobApplicationIdSource	
			if (CanDeepLoad(entity, "JobApplication|JobApplicationIdSource", deepLoadType, innerList) 
				&& entity.JobApplicationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.JobApplicationId;
				JobApplication tmpEntity = EntityManager.LocateEntity<JobApplication>(EntityLocator.ConstructKeyFromPkItems(typeof(JobApplication), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobApplicationIdSource = tmpEntity;
				else
					entity.JobApplicationIdSource = DataRepository.JobApplicationProvider.GetByJobApplicationId(transactionManager, entity.JobApplicationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobApplicationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobApplicationProvider.DeepLoad(transactionManager, entity.JobApplicationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobApplicationIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobApplicationNotes object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobApplicationNotes instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationNotes Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationNotes entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdvertiserUserIdSource
			if (CanDeepSave(entity, "AdvertiserUsers|AdvertiserUserIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserUserIdSource != null)
			{
				DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUserIdSource);
				entity.AdvertiserUserId = entity.AdvertiserUserIdSource.AdvertiserUserId;
			}
			#endregion 
			
			#region JobApplicationIdSource
			if (CanDeepSave(entity, "JobApplication|JobApplicationIdSource", deepSaveType, innerList) 
				&& entity.JobApplicationIdSource != null)
			{
				DataRepository.JobApplicationProvider.Save(transactionManager, entity.JobApplicationIdSource);
				entity.JobApplicationId = entity.JobApplicationIdSource.JobApplicationId;
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
	
	#region JobApplicationNotesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobApplicationNotes</c>
	///</summary>
	public enum JobApplicationNotesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at AdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
			
		///<summary>
		/// Composite Property for <c>JobApplication</c> at JobApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(JobApplication))]
		JobApplication,
			
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
		}
	
	#endregion JobApplicationNotesChildEntityTypes
	
	#region JobApplicationNotesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobApplicationNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationNotesFilterBuilder : SqlFilterBuilder<JobApplicationNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilterBuilder class.
		/// </summary>
		public JobApplicationNotesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationNotesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationNotesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationNotesFilterBuilder
	
	#region JobApplicationNotesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobApplicationNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationNotesParameterBuilder : ParameterizedSqlFilterBuilder<JobApplicationNotesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesParameterBuilder class.
		/// </summary>
		public JobApplicationNotesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationNotesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationNotesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationNotesParameterBuilder
	
	#region JobApplicationNotesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobApplicationNotesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationNotes"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobApplicationNotesSortBuilder : SqlSortBuilder<JobApplicationNotesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesSqlSortBuilder class.
		/// </summary>
		public JobApplicationNotesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobApplicationNotesSortBuilder
	
} // end namespace
