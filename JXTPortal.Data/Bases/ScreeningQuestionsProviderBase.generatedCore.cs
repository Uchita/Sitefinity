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
	/// This class is the base class for any <see cref="ScreeningQuestionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ScreeningQuestionsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.ScreeningQuestions, JXTPortal.Entities.ScreeningQuestionsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsKey key)
		{
			return Delete(transactionManager, key.ScreeningQuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_screeningQuestionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _screeningQuestionId)
		{
			return Delete(null, _screeningQuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _screeningQuestionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		FK__Screening__Langu__00057956 Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		FK__Screening__Langu__00057956 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestions> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		FK__Screening__Langu__00057956 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		fkScreeningLangu00057956 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		fkScreeningLangu00057956 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLanguageId(System.Int32 _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Langu__00057956 key.
		///		FK__Screening__Langu__00057956 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public abstract TList<ScreeningQuestions> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		FK__Screening__LastM__01EDC1C8 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedBy(System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		FK__Screening__LastM__01EDC1C8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestions> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		FK__Screening__LastM__01EDC1C8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		fkScreeningLastm01Edc1c8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		fkScreeningLastm01Edc1c8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__01EDC1C8 key.
		///		FK__Screening__LastM__01EDC1C8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public abstract TList<ScreeningQuestions> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		FK__Screening__LastM__02E1E601 Description: 
		/// </summary>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(_lastModifiedByAdvertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		FK__Screening__LastM__02E1E601 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		FK__Screening__LastM__02E1E601 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		fkScreeningLastm02e1e601 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		fkScreeningLastm02e1e601 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength,out int count)
		{
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__02E1E601 key.
		///		FK__Screening__LastM__02E1E601 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestions objects.</returns>
		public abstract TList<ScreeningQuestions> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.ScreeningQuestions Get(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsKey key, int start, int pageLength)
		{
			return GetByScreeningQuestionId(transactionManager, key.ScreeningQuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(null,_screeningQuestionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength, out int count)
		{
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__519C8EEE7D290CAB index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestions"/> class.</returns>
		public abstract JXTPortal.Entities.ScreeningQuestions GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ScreeningQuestions_Insert 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId, ref System.Int32? screeningQuestionId)
		{
			 Insert(null, 0, int.MaxValue , screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId, ref screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId, ref System.Int32? screeningQuestionId)
		{
			 Insert(null, start, pageLength , screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId, ref screeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId, ref System.Int32? screeningQuestionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId, ref screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId, ref System.Int32? screeningQuestionId);
		
		#endregion
		
		#region ScreeningQuestions_GetByScreeningQuestionId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(null, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId);
		
		#endregion
		
		#region ScreeningQuestions_Get_List 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Get_List' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region ScreeningQuestions_GetPaged 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetPaged' stored procedure. 
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
		
		#region ScreeningQuestions_GetByLastModifiedByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLastModifiedByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedByAdvertiserUserId(int start, int pageLength, System.Int32? lastModifiedByAdvertiserUserId)
		{
			return GetByLastModifiedByAdvertiserUserId(null, start, pageLength , lastModifiedByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLastModifiedByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedByAdvertiserUserId);
		
		#endregion
		
		#region ScreeningQuestions_Update 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			 Update(null, 0, int.MaxValue , screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			 Update(null, start, pageLength , screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			 Update(transactionManager, 0, int.MaxValue , screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId);
		
		#endregion
		
		#region ScreeningQuestions_Find 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			return Find(null, start, pageLength , searchUsingOr, screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, screeningQuestionId, screeningQuestionIndex, questionTitle, questionType, mandatory, languageId, knockoutValue, options, visible, lastModified, lastModifiedBy, lastModifiedByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="questionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="questionType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="mandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="knockoutValue"> A <c>System.String</c> instance.</param>
		/// <param name="options"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? screeningQuestionId, System.Int32? screeningQuestionIndex, System.String questionTitle, System.Int32? questionType, System.Boolean? mandatory, System.Int32? languageId, System.String knockoutValue, System.String options, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? lastModifiedByAdvertiserUserId);
		
		#endregion
		
		#region ScreeningQuestions_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(int start, int pageLength, System.Int32? languageId)
		{
			return GetByLanguageId(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(TransactionManager transactionManager, System.Int32? languageId)
		{
			return GetByLanguageId(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region ScreeningQuestions_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestions_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region ScreeningQuestions_Delete 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? screeningQuestionId)
		{
			 Delete(null, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? screeningQuestionId)
		{
			 Delete(null, start, pageLength , screeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? screeningQuestionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestions_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ScreeningQuestions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ScreeningQuestions&gt;"/></returns>
		public static TList<ScreeningQuestions> Fill(IDataReader reader, TList<ScreeningQuestions> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.ScreeningQuestions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ScreeningQuestions")
					.Append("|").Append((System.Int32)reader[((int)ScreeningQuestionsColumn.ScreeningQuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ScreeningQuestions>(
					key.ToString(), // EntityTrackingKey
					"ScreeningQuestions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.ScreeningQuestions();
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
					c.ScreeningQuestionId = (System.Int32)reader[((int)ScreeningQuestionsColumn.ScreeningQuestionId - 1)];
					c.ScreeningQuestionIndex = (System.Int32)reader[((int)ScreeningQuestionsColumn.ScreeningQuestionIndex - 1)];
					c.QuestionTitle = (System.String)reader[((int)ScreeningQuestionsColumn.QuestionTitle - 1)];
					c.QuestionType = (System.Int32)reader[((int)ScreeningQuestionsColumn.QuestionType - 1)];
					c.Mandatory = (System.Boolean)reader[((int)ScreeningQuestionsColumn.Mandatory - 1)];
					c.LanguageId = (System.Int32)reader[((int)ScreeningQuestionsColumn.LanguageId - 1)];
					c.KnockoutValue = (reader.IsDBNull(((int)ScreeningQuestionsColumn.KnockoutValue - 1)))?null:(System.String)reader[((int)ScreeningQuestionsColumn.KnockoutValue - 1)];
					c.Options = (reader.IsDBNull(((int)ScreeningQuestionsColumn.Options - 1)))?null:(System.String)reader[((int)ScreeningQuestionsColumn.Options - 1)];
					c.Visible = (System.Boolean)reader[((int)ScreeningQuestionsColumn.Visible - 1)];
					c.LastModified = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ScreeningQuestionsColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsColumn.LastModifiedBy - 1)];
					c.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsColumn.LastModifiedByAdvertiserUserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.ScreeningQuestions entity)
		{
			if (!reader.Read()) return;
			
			entity.ScreeningQuestionId = (System.Int32)reader[((int)ScreeningQuestionsColumn.ScreeningQuestionId - 1)];
			entity.ScreeningQuestionIndex = (System.Int32)reader[((int)ScreeningQuestionsColumn.ScreeningQuestionIndex - 1)];
			entity.QuestionTitle = (System.String)reader[((int)ScreeningQuestionsColumn.QuestionTitle - 1)];
			entity.QuestionType = (System.Int32)reader[((int)ScreeningQuestionsColumn.QuestionType - 1)];
			entity.Mandatory = (System.Boolean)reader[((int)ScreeningQuestionsColumn.Mandatory - 1)];
			entity.LanguageId = (System.Int32)reader[((int)ScreeningQuestionsColumn.LanguageId - 1)];
			entity.KnockoutValue = (reader.IsDBNull(((int)ScreeningQuestionsColumn.KnockoutValue - 1)))?null:(System.String)reader[((int)ScreeningQuestionsColumn.KnockoutValue - 1)];
			entity.Options = (reader.IsDBNull(((int)ScreeningQuestionsColumn.Options - 1)))?null:(System.String)reader[((int)ScreeningQuestionsColumn.Options - 1)];
			entity.Visible = (System.Boolean)reader[((int)ScreeningQuestionsColumn.Visible - 1)];
			entity.LastModified = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ScreeningQuestionsColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsColumn.LastModifiedBy - 1)];
			entity.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)ScreeningQuestionsColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsColumn.LastModifiedByAdvertiserUserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.ScreeningQuestions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ScreeningQuestionId = (System.Int32)dataRow["ScreeningQuestionId"];
			entity.ScreeningQuestionIndex = (System.Int32)dataRow["ScreeningQuestionIndex"];
			entity.QuestionTitle = (System.String)dataRow["QuestionTitle"];
			entity.QuestionType = (System.Int32)dataRow["QuestionType"];
			entity.Mandatory = (System.Boolean)dataRow["Mandatory"];
			entity.LanguageId = (System.Int32)dataRow["LanguageId"];
			entity.KnockoutValue = Convert.IsDBNull(dataRow["KnockoutValue"]) ? null : (System.String)dataRow["KnockoutValue"];
			entity.Options = Convert.IsDBNull(dataRow["Options"]) ? null : (System.String)dataRow["Options"];
			entity.Visible = (System.Boolean)dataRow["Visible"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModifiedByAdvertiserUserId = Convert.IsDBNull(dataRow["LastModifiedByAdvertiserUserId"]) ? null : (System.Int32?)dataRow["LastModifiedByAdvertiserUserId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Languages|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LanguageId;
				Languages tmpEntity = EntityManager.LocateEntity<Languages>(EntityLocator.ConstructKeyFromPkItems(typeof(Languages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguagesProvider.GetByLanguageId(transactionManager, entity.LanguageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguagesProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastModifiedBy ?? (int)0);
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, (entity.LastModifiedBy ?? (int)0));		
				
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

			#region LastModifiedByAdvertiserUserIdSource	
			if (CanDeepLoad(entity, "AdvertiserUsers|LastModifiedByAdvertiserUserIdSource", deepLoadType, innerList) 
				&& entity.LastModifiedByAdvertiserUserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastModifiedByAdvertiserUserId ?? (int)0);
				AdvertiserUsers tmpEntity = EntityManager.LocateEntity<AdvertiserUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedByAdvertiserUserIdSource = tmpEntity;
				else
					entity.LastModifiedByAdvertiserUserIdSource = DataRepository.AdvertiserUsersProvider.GetByAdvertiserUserId(transactionManager, (entity.LastModifiedByAdvertiserUserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedByAdvertiserUserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedByAdvertiserUserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserUsersProvider.DeepLoad(transactionManager, entity.LastModifiedByAdvertiserUserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedByAdvertiserUserIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByScreeningQuestionId methods when available
			
			#region JobApplicationScreeningAnswersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplicationScreeningAnswers>|JobApplicationScreeningAnswersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationScreeningAnswersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationScreeningAnswersCollection = DataRepository.JobApplicationScreeningAnswersProvider.GetByScreeningQuestionId(transactionManager, entity.ScreeningQuestionId);

				if (deep && entity.JobApplicationScreeningAnswersCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationScreeningAnswersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplicationScreeningAnswers>) DataRepository.JobApplicationScreeningAnswersProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationScreeningAnswersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ScreeningQuestionsMappingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ScreeningQuestionsMappings>|ScreeningQuestionsMappingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionsMappingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ScreeningQuestionsMappingsCollection = DataRepository.ScreeningQuestionsMappingsProvider.GetByScreeningQuestionId(transactionManager, entity.ScreeningQuestionId);

				if (deep && entity.ScreeningQuestionsMappingsCollection.Count > 0)
				{
					deepHandles.Add("ScreeningQuestionsMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ScreeningQuestionsMappings>) DataRepository.ScreeningQuestionsMappingsProvider.DeepLoad,
						new object[] { transactionManager, entity.ScreeningQuestionsMappingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobScreeningQuestionsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobScreeningQuestions>|JobScreeningQuestionsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobScreeningQuestionsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobScreeningQuestionsCollection = DataRepository.JobScreeningQuestionsProvider.GetByScreeningQuestionId(transactionManager, entity.ScreeningQuestionId);

				if (deep && entity.JobScreeningQuestionsCollection.Count > 0)
				{
					deepHandles.Add("JobScreeningQuestionsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobScreeningQuestions>) DataRepository.JobScreeningQuestionsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobScreeningQuestionsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.ScreeningQuestions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.ScreeningQuestions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Languages|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguagesProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.LanguageId;
			}
			#endregion 
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
			}
			#endregion 
			
			#region LastModifiedByAdvertiserUserIdSource
			if (CanDeepSave(entity, "AdvertiserUsers|LastModifiedByAdvertiserUserIdSource", deepSaveType, innerList) 
				&& entity.LastModifiedByAdvertiserUserIdSource != null)
			{
				DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.LastModifiedByAdvertiserUserIdSource);
				entity.LastModifiedByAdvertiserUserId = entity.LastModifiedByAdvertiserUserIdSource.AdvertiserUserId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<JobApplicationScreeningAnswers>
				if (CanDeepSave(entity.JobApplicationScreeningAnswersCollection, "List<JobApplicationScreeningAnswers>|JobApplicationScreeningAnswersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplicationScreeningAnswers child in entity.JobApplicationScreeningAnswersCollection)
					{
						if(child.ScreeningQuestionIdSource != null)
						{
							child.ScreeningQuestionId = child.ScreeningQuestionIdSource.ScreeningQuestionId;
						}
						else
						{
							child.ScreeningQuestionId = entity.ScreeningQuestionId;
						}

					}

					if (entity.JobApplicationScreeningAnswersCollection.Count > 0 || entity.JobApplicationScreeningAnswersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationScreeningAnswersProvider.Save(transactionManager, entity.JobApplicationScreeningAnswersCollection);
						
						deepHandles.Add("JobApplicationScreeningAnswersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplicationScreeningAnswers >) DataRepository.JobApplicationScreeningAnswersProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationScreeningAnswersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ScreeningQuestionsMappings>
				if (CanDeepSave(entity.ScreeningQuestionsMappingsCollection, "List<ScreeningQuestionsMappings>|ScreeningQuestionsMappingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ScreeningQuestionsMappings child in entity.ScreeningQuestionsMappingsCollection)
					{
						if(child.ScreeningQuestionIdSource != null)
						{
							child.ScreeningQuestionId = child.ScreeningQuestionIdSource.ScreeningQuestionId;
						}
						else
						{
							child.ScreeningQuestionId = entity.ScreeningQuestionId;
						}

					}

					if (entity.ScreeningQuestionsMappingsCollection.Count > 0 || entity.ScreeningQuestionsMappingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ScreeningQuestionsMappingsProvider.Save(transactionManager, entity.ScreeningQuestionsMappingsCollection);
						
						deepHandles.Add("ScreeningQuestionsMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ScreeningQuestionsMappings >) DataRepository.ScreeningQuestionsMappingsProvider.DeepSave,
							new object[] { transactionManager, entity.ScreeningQuestionsMappingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobScreeningQuestions>
				if (CanDeepSave(entity.JobScreeningQuestionsCollection, "List<JobScreeningQuestions>|JobScreeningQuestionsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobScreeningQuestions child in entity.JobScreeningQuestionsCollection)
					{
						if(child.ScreeningQuestionIdSource != null)
						{
							child.ScreeningQuestionId = child.ScreeningQuestionIdSource.ScreeningQuestionId;
						}
						else
						{
							child.ScreeningQuestionId = entity.ScreeningQuestionId;
						}

					}

					if (entity.JobScreeningQuestionsCollection.Count > 0 || entity.JobScreeningQuestionsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobScreeningQuestionsProvider.Save(transactionManager, entity.JobScreeningQuestionsCollection);
						
						deepHandles.Add("JobScreeningQuestionsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobScreeningQuestions >) DataRepository.JobScreeningQuestionsProvider.DeepSave,
							new object[] { transactionManager, entity.JobScreeningQuestionsCollection, deepSaveType, childTypes, innerList }
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
	
	#region ScreeningQuestionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.ScreeningQuestions</c>
	///</summary>
	public enum ScreeningQuestionsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Languages</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at LastModifiedByAdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
	
		///<summary>
		/// Collection of <c>ScreeningQuestions</c> as OneToMany for JobApplicationScreeningAnswersCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplicationScreeningAnswers>))]
		JobApplicationScreeningAnswersCollection,

		///<summary>
		/// Collection of <c>ScreeningQuestions</c> as OneToMany for ScreeningQuestionsMappingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<ScreeningQuestionsMappings>))]
		ScreeningQuestionsMappingsCollection,

		///<summary>
		/// Collection of <c>ScreeningQuestions</c> as OneToMany for JobScreeningQuestionsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobScreeningQuestions>))]
		JobScreeningQuestionsCollection,
	}
	
	#endregion ScreeningQuestionsChildEntityTypes
	
	#region ScreeningQuestionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsFilterBuilder : SqlFilterBuilder<ScreeningQuestionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilterBuilder class.
		/// </summary>
		public ScreeningQuestionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsFilterBuilder
	
	#region ScreeningQuestionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsParameterBuilder : ParameterizedSqlFilterBuilder<ScreeningQuestionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsParameterBuilder class.
		/// </summary>
		public ScreeningQuestionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsParameterBuilder
	
	#region ScreeningQuestionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ScreeningQuestionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ScreeningQuestionsSortBuilder : SqlSortBuilder<ScreeningQuestionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsSqlSortBuilder class.
		/// </summary>
		public ScreeningQuestionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ScreeningQuestionsSortBuilder
	
} // end namespace
