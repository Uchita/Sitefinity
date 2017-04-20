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
	/// This class is the base class for any <see cref="JobScreeningQuestionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobScreeningQuestionsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobScreeningQuestions, JXTPortal.Entities.JobScreeningQuestionsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobScreeningQuestionsKey key)
		{
			return Delete(transactionManager, key.JobScreeningQuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobScreeningQuestionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobScreeningQuestionId)
		{
			return Delete(null, _jobScreeningQuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobScreeningQuestionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobScreeningQuestionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		FK__JobScreen__JobAr__54421D79 Description: 
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(_jobArchiveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		FK__JobScreen__JobAr__54421D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<JobScreeningQuestions> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		FK__JobScreen__JobAr__54421D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		fkJobScreenJobAr54421d79 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		fkJobScreenJobAr54421d79 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength,out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobAr__54421D79 key.
		///		FK__JobScreen__JobAr__54421D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public abstract TList<JobScreeningQuestions> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		FK__JobScreen__JobId__07A69B1E Description: 
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(_jobId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		FK__JobScreen__JobId__07A69B1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<JobScreeningQuestions> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		FK__JobScreen__JobId__07A69B1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		fkJobScreenJobId07a69b1e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobId(null, _jobId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		fkJobScreenJobId07a69b1e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByJobId(System.Int32? _jobId, int start, int pageLength,out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__JobId__07A69B1E key.
		///		FK__JobScreen__JobId__07A69B1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public abstract TList<JobScreeningQuestions> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		FK__JobScreen__Scree__098EE390 Description: 
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByScreeningQuestionId(System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(_screeningQuestionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		FK__JobScreen__Scree__098EE390 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<JobScreeningQuestions> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		FK__JobScreen__Scree__098EE390 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		fkJobScreenScree098Ee390 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		fkJobScreenScree098Ee390 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public TList<JobScreeningQuestions> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobScreen__Scree__098EE390 key.
		///		FK__JobScreen__Scree__098EE390 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobScreeningQuestions objects.</returns>
		public abstract TList<JobScreeningQuestions> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobScreeningQuestions Get(TransactionManager transactionManager, JXTPortal.Entities.JobScreeningQuestionsKey key, int start, int pageLength)
		{
			return GetByJobScreeningQuestionId(transactionManager, key.JobScreeningQuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(System.Int32 _jobScreeningQuestionId)
		{
			int count = -1;
			return GetByJobScreeningQuestionId(null,_jobScreeningQuestionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(System.Int32 _jobScreeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobScreeningQuestionId(null, _jobScreeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(TransactionManager transactionManager, System.Int32 _jobScreeningQuestionId)
		{
			int count = -1;
			return GetByJobScreeningQuestionId(transactionManager, _jobScreeningQuestionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(TransactionManager transactionManager, System.Int32 _jobScreeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobScreeningQuestionId(transactionManager, _jobScreeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(System.Int32 _jobScreeningQuestionId, int start, int pageLength, out int count)
		{
			return GetByJobScreeningQuestionId(null, _jobScreeningQuestionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobScree__24299EC705BE52AC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobScreeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> class.</returns>
		public abstract JXTPortal.Entities.JobScreeningQuestions GetByJobScreeningQuestionId(TransactionManager transactionManager, System.Int32 _jobScreeningQuestionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobScreeningQuestions_Insert 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId, ref System.Int32? jobScreeningQuestionId)
		{
			 Insert(null, 0, int.MaxValue , jobId, screeningQuestionId, jobArchiveId, ref jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId, ref System.Int32? jobScreeningQuestionId)
		{
			 Insert(null, start, pageLength , jobId, screeningQuestionId, jobArchiveId, ref jobScreeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId, ref System.Int32? jobScreeningQuestionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobId, screeningQuestionId, jobArchiveId, ref jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId, ref System.Int32? jobScreeningQuestionId);
		
		#endregion
		
		#region JobScreeningQuestions_GetByJobId 
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobId' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobScreeningQuestions_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Get_List' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobScreeningQuestions_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_GetPaged' stored procedure. 
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
		
		#region JobScreeningQuestions_GetByScreeningQuestionId 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(null, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(int start, int pageLength, System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(null, start, pageLength , screeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(transactionManager, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId);
		
		#endregion
		
		#region JobScreeningQuestions_Update 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			 Update(null, 0, int.MaxValue , jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			 Update(null, start, pageLength , jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobScreeningQuestions_Find 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobScreeningQuestionId, jobId, screeningQuestionId, jobArchiveId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobScreeningQuestionId, System.Int32? jobId, System.Int32? screeningQuestionId, System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobScreeningQuestions_Delete 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobScreeningQuestionId)
		{
			 Delete(null, 0, int.MaxValue , jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobScreeningQuestionId)
		{
			 Delete(null, start, pageLength , jobScreeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobScreeningQuestionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobScreeningQuestionId);
		
		#endregion
		
		#region JobScreeningQuestions_GetByJobArchiveId 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobArchiveId' stored procedure. 
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
		///	This method wrap the 'JobScreeningQuestions_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobScreeningQuestions_GetByJobScreeningQuestionId 
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobScreeningQuestionId(System.Int32? jobScreeningQuestionId)
		{
			return GetByJobScreeningQuestionId(null, 0, int.MaxValue , jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobScreeningQuestionId(int start, int pageLength, System.Int32? jobScreeningQuestionId)
		{
			return GetByJobScreeningQuestionId(null, start, pageLength , jobScreeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobScreeningQuestionId(TransactionManager transactionManager, System.Int32? jobScreeningQuestionId)
		{
			return GetByJobScreeningQuestionId(transactionManager, 0, int.MaxValue , jobScreeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobScreeningQuestions_GetByJobScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="jobScreeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobScreeningQuestionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobScreeningQuestionId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobScreeningQuestions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobScreeningQuestions&gt;"/></returns>
		public static TList<JobScreeningQuestions> Fill(IDataReader reader, TList<JobScreeningQuestions> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobScreeningQuestions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobScreeningQuestions")
					.Append("|").Append((System.Int32)reader[((int)JobScreeningQuestionsColumn.JobScreeningQuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobScreeningQuestions>(
					key.ToString(), // EntityTrackingKey
					"JobScreeningQuestions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobScreeningQuestions();
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
					c.JobScreeningQuestionId = (System.Int32)reader[((int)JobScreeningQuestionsColumn.JobScreeningQuestionId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobScreeningQuestionsColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobScreeningQuestionsColumn.JobId - 1)];
					c.ScreeningQuestionId = (System.Int32)reader[((int)JobScreeningQuestionsColumn.ScreeningQuestionId - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobScreeningQuestionsColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobScreeningQuestionsColumn.JobArchiveId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobScreeningQuestions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobScreeningQuestions entity)
		{
			if (!reader.Read()) return;
			
			entity.JobScreeningQuestionId = (System.Int32)reader[((int)JobScreeningQuestionsColumn.JobScreeningQuestionId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobScreeningQuestionsColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobScreeningQuestionsColumn.JobId - 1)];
			entity.ScreeningQuestionId = (System.Int32)reader[((int)JobScreeningQuestionsColumn.ScreeningQuestionId - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobScreeningQuestionsColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobScreeningQuestionsColumn.JobArchiveId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobScreeningQuestions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobScreeningQuestions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobScreeningQuestions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobScreeningQuestionId = (System.Int32)dataRow["JobScreeningQuestionId"];
			entity.JobId = Convert.IsDBNull(dataRow["JobId"]) ? null : (System.Int32?)dataRow["JobId"];
			entity.ScreeningQuestionId = (System.Int32)dataRow["ScreeningQuestionId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobScreeningQuestions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobScreeningQuestions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobScreeningQuestions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region ScreeningQuestionIdSource	
			if (CanDeepLoad(entity, "ScreeningQuestions|ScreeningQuestionIdSource", deepLoadType, innerList) 
				&& entity.ScreeningQuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ScreeningQuestionId;
				ScreeningQuestions tmpEntity = EntityManager.LocateEntity<ScreeningQuestions>(EntityLocator.ConstructKeyFromPkItems(typeof(ScreeningQuestions), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ScreeningQuestionIdSource = tmpEntity;
				else
					entity.ScreeningQuestionIdSource = DataRepository.ScreeningQuestionsProvider.GetByScreeningQuestionId(transactionManager, entity.ScreeningQuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ScreeningQuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ScreeningQuestionsProvider.DeepLoad(transactionManager, entity.ScreeningQuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ScreeningQuestionIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobScreeningQuestions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobScreeningQuestions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobScreeningQuestions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobScreeningQuestions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region ScreeningQuestionIdSource
			if (CanDeepSave(entity, "ScreeningQuestions|ScreeningQuestionIdSource", deepSaveType, innerList) 
				&& entity.ScreeningQuestionIdSource != null)
			{
				DataRepository.ScreeningQuestionsProvider.Save(transactionManager, entity.ScreeningQuestionIdSource);
				entity.ScreeningQuestionId = entity.ScreeningQuestionIdSource.ScreeningQuestionId;
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
	
	#region JobScreeningQuestionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobScreeningQuestions</c>
	///</summary>
	public enum JobScreeningQuestionsChildEntityTypes
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
		/// Composite Property for <c>ScreeningQuestions</c> at ScreeningQuestionIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestions))]
		ScreeningQuestions,
		}
	
	#endregion JobScreeningQuestionsChildEntityTypes
	
	#region JobScreeningQuestionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobScreeningQuestionsFilterBuilder : SqlFilterBuilder<JobScreeningQuestionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilterBuilder class.
		/// </summary>
		public JobScreeningQuestionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobScreeningQuestionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobScreeningQuestionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobScreeningQuestionsFilterBuilder
	
	#region JobScreeningQuestionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobScreeningQuestionsParameterBuilder : ParameterizedSqlFilterBuilder<JobScreeningQuestionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsParameterBuilder class.
		/// </summary>
		public JobScreeningQuestionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobScreeningQuestionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobScreeningQuestionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobScreeningQuestionsParameterBuilder
	
	#region JobScreeningQuestionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobScreeningQuestions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobScreeningQuestionsSortBuilder : SqlSortBuilder<JobScreeningQuestionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsSqlSortBuilder class.
		/// </summary>
		public JobScreeningQuestionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobScreeningQuestionsSortBuilder
	
} // end namespace
