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
	/// This class is the base class for any <see cref="JobApplicationScreeningAnswersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobApplicationScreeningAnswersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobApplicationScreeningAnswers, JXTPortal.Entities.JobApplicationScreeningAnswersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationScreeningAnswersKey key)
		{
			return Delete(transactionManager, key.JobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobApplicationScreeningAnswerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobApplicationScreeningAnswerId)
		{
			return Delete(null, _jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationScreeningAnswerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobApplicationScreeningAnswerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		FK__JobApplic__JobAp__0F47BCE6 Description: 
		/// </summary>
		/// <param name="_jobApplicationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByJobApplicationId(System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(_jobApplicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		FK__JobApplic__JobAp__0F47BCE6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationScreeningAnswers> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		FK__JobApplic__JobAp__0F47BCE6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationId(transactionManager, _jobApplicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		fkJobApplicJobAp0f47Bce6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		fkJobApplicJobAp0f47Bce6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByJobApplicationId(System.Int32 _jobApplicationId, int start, int pageLength,out int count)
		{
			return GetByJobApplicationId(null, _jobApplicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__JobAp__0F47BCE6 key.
		///		FK__JobApplic__JobAp__0F47BCE6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public abstract TList<JobApplicationScreeningAnswers> GetByJobApplicationId(TransactionManager transactionManager, System.Int32 _jobApplicationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		FK__JobApplic__Scree__0E5398AD Description: 
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(_screeningQuestionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		FK__JobApplic__Scree__0E5398AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		FK__JobApplic__Scree__0E5398AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		fkJobApplicScree0e5398Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		fkJobApplicScree0e5398Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__Scree__0E5398AD key.
		///		FK__JobApplic__Scree__0E5398AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationScreeningAnswers objects.</returns>
		public abstract TList<JobApplicationScreeningAnswers> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobApplicationScreeningAnswers Get(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationScreeningAnswersKey key, int start, int pageLength)
		{
			return GetByJobApplicationScreeningAnswerId(transactionManager, key.JobApplicationScreeningAnswerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(System.Int32 _jobApplicationScreeningAnswerId)
		{
			int count = -1;
			return GetByJobApplicationScreeningAnswerId(null,_jobApplicationScreeningAnswerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(System.Int32 _jobApplicationScreeningAnswerId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationScreeningAnswerId(null, _jobApplicationScreeningAnswerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(TransactionManager transactionManager, System.Int32 _jobApplicationScreeningAnswerId)
		{
			int count = -1;
			return GetByJobApplicationScreeningAnswerId(transactionManager, _jobApplicationScreeningAnswerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(TransactionManager transactionManager, System.Int32 _jobApplicationScreeningAnswerId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationScreeningAnswerId(transactionManager, _jobApplicationScreeningAnswerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(System.Int32 _jobApplicationScreeningAnswerId, int start, int pageLength, out int count)
		{
			return GetByJobApplicationScreeningAnswerId(null, _jobApplicationScreeningAnswerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__4E3C49980C6B503B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationScreeningAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> class.</returns>
		public abstract JXTPortal.Entities.JobApplicationScreeningAnswers GetByJobApplicationScreeningAnswerId(TransactionManager transactionManager, System.Int32 _jobApplicationScreeningAnswerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobApplicationScreeningAnswers_Insert 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId, ref System.Int32? jobApplicationScreeningAnswerId)
		{
			 Insert(null, 0, int.MaxValue , screeningQuestionId, answer, jobApplicationId, ref jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId, ref System.Int32? jobApplicationScreeningAnswerId)
		{
			 Insert(null, start, pageLength , screeningQuestionId, answer, jobApplicationId, ref jobApplicationScreeningAnswerId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId, ref System.Int32? jobApplicationScreeningAnswerId)
		{
			 Insert(transactionManager, 0, int.MaxValue , screeningQuestionId, answer, jobApplicationId, ref jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId, ref System.Int32? jobApplicationScreeningAnswerId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_GetByJobApplicationScreeningAnswerId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationScreeningAnswerId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationScreeningAnswerId(System.Int32? jobApplicationScreeningAnswerId)
		{
			return GetByJobApplicationScreeningAnswerId(null, 0, int.MaxValue , jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationScreeningAnswerId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationScreeningAnswerId(int start, int pageLength, System.Int32? jobApplicationScreeningAnswerId)
		{
			return GetByJobApplicationScreeningAnswerId(null, start, pageLength , jobApplicationScreeningAnswerId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationScreeningAnswerId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationScreeningAnswerId(TransactionManager transactionManager, System.Int32? jobApplicationScreeningAnswerId)
		{
			return GetByJobApplicationScreeningAnswerId(transactionManager, 0, int.MaxValue , jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationScreeningAnswerId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobApplicationScreeningAnswerId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationScreeningAnswerId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Get_List' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobApplicationScreeningAnswers_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetPaged' stored procedure. 
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
		
		#region JobApplicationScreeningAnswers_GetByScreeningQuestionId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(null, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_GetByJobApplicationId 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobApplicationId(System.Int32? jobApplicationId)
		{
			return GetByJobApplicationId(null, 0, int.MaxValue , jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationId' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationId' stored procedure. 
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
		///	This method wrap the 'JobApplicationScreeningAnswers_GetByJobApplicationId' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobApplicationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_Find 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_Delete 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobApplicationScreeningAnswerId)
		{
			 Delete(null, 0, int.MaxValue , jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobApplicationScreeningAnswerId)
		{
			 Delete(null, start, pageLength , jobApplicationScreeningAnswerId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobApplicationScreeningAnswerId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobApplicationScreeningAnswerId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationScreeningAnswerId);
		
		#endregion
		
		#region JobApplicationScreeningAnswers_Update 
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			 Update(null, 0, int.MaxValue , jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			 Update(null, start, pageLength , jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobApplicationScreeningAnswerId, screeningQuestionId, answer, jobApplicationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobApplicationScreeningAnswers_Update' stored procedure. 
		/// </summary>
		/// <param name="jobApplicationScreeningAnswerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="answer"> A <c>System.String</c> instance.</param>
		/// <param name="jobApplicationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobApplicationScreeningAnswerId, System.Int32? screeningQuestionId, System.String answer, System.Int32? jobApplicationId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobApplicationScreeningAnswers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobApplicationScreeningAnswers&gt;"/></returns>
		public static TList<JobApplicationScreeningAnswers> Fill(IDataReader reader, TList<JobApplicationScreeningAnswers> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobApplicationScreeningAnswers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobApplicationScreeningAnswers")
					.Append("|").Append((System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.JobApplicationScreeningAnswerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobApplicationScreeningAnswers>(
					key.ToString(), // EntityTrackingKey
					"JobApplicationScreeningAnswers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobApplicationScreeningAnswers();
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
					c.JobApplicationScreeningAnswerId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.JobApplicationScreeningAnswerId - 1)];
					c.ScreeningQuestionId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.ScreeningQuestionId - 1)];
					c.Answer = (reader.IsDBNull(((int)JobApplicationScreeningAnswersColumn.Answer - 1)))?null:(System.String)reader[((int)JobApplicationScreeningAnswersColumn.Answer - 1)];
					c.JobApplicationId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.JobApplicationId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobApplicationScreeningAnswers entity)
		{
			if (!reader.Read()) return;
			
			entity.JobApplicationScreeningAnswerId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.JobApplicationScreeningAnswerId - 1)];
			entity.ScreeningQuestionId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.ScreeningQuestionId - 1)];
			entity.Answer = (reader.IsDBNull(((int)JobApplicationScreeningAnswersColumn.Answer - 1)))?null:(System.String)reader[((int)JobApplicationScreeningAnswersColumn.Answer - 1)];
			entity.JobApplicationId = (System.Int32)reader[((int)JobApplicationScreeningAnswersColumn.JobApplicationId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobApplicationScreeningAnswers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobApplicationScreeningAnswerId = (System.Int32)dataRow["JobApplicationScreeningAnswerId"];
			entity.ScreeningQuestionId = (System.Int32)dataRow["ScreeningQuestionId"];
			entity.Answer = Convert.IsDBNull(dataRow["Answer"]) ? null : (System.String)dataRow["Answer"];
			entity.JobApplicationId = (System.Int32)dataRow["JobApplicationId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationScreeningAnswers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationScreeningAnswers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationScreeningAnswers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobApplicationScreeningAnswers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobApplicationScreeningAnswers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationScreeningAnswers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationScreeningAnswers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region JobApplicationIdSource
			if (CanDeepSave(entity, "JobApplication|JobApplicationIdSource", deepSaveType, innerList) 
				&& entity.JobApplicationIdSource != null)
			{
				DataRepository.JobApplicationProvider.Save(transactionManager, entity.JobApplicationIdSource);
				entity.JobApplicationId = entity.JobApplicationIdSource.JobApplicationId;
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
	
	#region JobApplicationScreeningAnswersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobApplicationScreeningAnswers</c>
	///</summary>
	public enum JobApplicationScreeningAnswersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>JobApplication</c> at JobApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(JobApplication))]
		JobApplication,
			
		///<summary>
		/// Composite Property for <c>ScreeningQuestions</c> at ScreeningQuestionIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestions))]
		ScreeningQuestions,
		}
	
	#endregion JobApplicationScreeningAnswersChildEntityTypes
	
	#region JobApplicationScreeningAnswersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobApplicationScreeningAnswersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationScreeningAnswers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationScreeningAnswersFilterBuilder : SqlFilterBuilder<JobApplicationScreeningAnswersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilterBuilder class.
		/// </summary>
		public JobApplicationScreeningAnswersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationScreeningAnswersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationScreeningAnswersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationScreeningAnswersFilterBuilder
	
	#region JobApplicationScreeningAnswersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobApplicationScreeningAnswersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationScreeningAnswers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationScreeningAnswersParameterBuilder : ParameterizedSqlFilterBuilder<JobApplicationScreeningAnswersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersParameterBuilder class.
		/// </summary>
		public JobApplicationScreeningAnswersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationScreeningAnswersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationScreeningAnswersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationScreeningAnswersParameterBuilder
	
	#region JobApplicationScreeningAnswersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobApplicationScreeningAnswersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationScreeningAnswers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobApplicationScreeningAnswersSortBuilder : SqlSortBuilder<JobApplicationScreeningAnswersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersSqlSortBuilder class.
		/// </summary>
		public JobApplicationScreeningAnswersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobApplicationScreeningAnswersSortBuilder
	
} // end namespace
