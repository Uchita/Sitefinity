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
	/// This class is the base class for any <see cref="ScreeningQuestionsMappingsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ScreeningQuestionsMappingsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.ScreeningQuestionsMappings, JXTPortal.Entities.ScreeningQuestionsMappingsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsMappingsKey key)
		{
			return Delete(transactionManager, key.ScreeningQuestionsMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_screeningQuestionsMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _screeningQuestionsMappingId)
		{
			return Delete(null, _screeningQuestionsMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _screeningQuestionsMappingId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		FK__Screening__Scree__140C7203 Description: 
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(_screeningQuestionsTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		FK__Screening__Scree__140C7203 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		FK__Screening__Scree__140C7203 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		fkScreeningScree140c7203 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		fkScreeningScree140c7203 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__140C7203 key.
		///		FK__Screening__Scree__140C7203 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public abstract TList<ScreeningQuestionsMappings> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		FK__Screening__Scree__1500963C Description: 
		/// </summary>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(_screeningQuestionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		FK__Screening__Scree__1500963C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		FK__Screening__Scree__1500963C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionId(transactionManager, _screeningQuestionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		fkScreeningScree1500963c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		fkScreeningScree1500963c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(System.Int32 _screeningQuestionId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionId(null, _screeningQuestionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__1500963C key.
		///		FK__Screening__Scree__1500963C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsMappings objects.</returns>
		public abstract TList<ScreeningQuestionsMappings> GetByScreeningQuestionId(TransactionManager transactionManager, System.Int32 _screeningQuestionId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.ScreeningQuestionsMappings Get(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsMappingsKey key, int start, int pageLength)
		{
			return GetByScreeningQuestionsMappingId(transactionManager, key.ScreeningQuestionsMappingId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(System.Int32 _screeningQuestionsMappingId)
		{
			int count = -1;
			return GetByScreeningQuestionsMappingId(null,_screeningQuestionsMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(System.Int32 _screeningQuestionsMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsMappingId(null, _screeningQuestionsMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(TransactionManager transactionManager, System.Int32 _screeningQuestionsMappingId)
		{
			int count = -1;
			return GetByScreeningQuestionsMappingId(transactionManager, _screeningQuestionsMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(TransactionManager transactionManager, System.Int32 _screeningQuestionsMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsMappingId(transactionManager, _screeningQuestionsMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(System.Int32 _screeningQuestionsMappingId, int start, int pageLength, out int count)
		{
			return GetByScreeningQuestionsMappingId(null, _screeningQuestionsMappingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__F798617912242991 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> class.</returns>
		public abstract JXTPortal.Entities.ScreeningQuestionsMappings GetByScreeningQuestionsMappingId(TransactionManager transactionManager, System.Int32 _screeningQuestionsMappingId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ScreeningQuestionsMappings_Insert 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId, ref System.Int32? screeningQuestionsMappingId)
		{
			 Insert(null, 0, int.MaxValue , screeningQuestionsTemplateId, screeningQuestionId, ref screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId, ref System.Int32? screeningQuestionsMappingId)
		{
			 Insert(null, start, pageLength , screeningQuestionsTemplateId, screeningQuestionId, ref screeningQuestionsMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId, ref System.Int32? screeningQuestionsMappingId)
		{
			 Insert(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId, screeningQuestionId, ref screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId, ref System.Int32? screeningQuestionsMappingId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_GetByScreeningQuestionId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionId(System.Int32? screeningQuestionId)
		{
			return GetByScreeningQuestionId(null, 0, int.MaxValue , screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_Get_List 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Get_List' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region ScreeningQuestionsMappings_GetByScreeningQuestionsTemplateId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(null, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(int start, int pageLength, System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(null, start, pageLength , screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_GetByScreeningQuestionsMappingId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsMappingId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsMappingId(System.Int32? screeningQuestionsMappingId)
		{
			return GetByScreeningQuestionsMappingId(null, 0, int.MaxValue , screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsMappingId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsMappingId(int start, int pageLength, System.Int32? screeningQuestionsMappingId)
		{
			return GetByScreeningQuestionsMappingId(null, start, pageLength , screeningQuestionsMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsMappingId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsMappingId(TransactionManager transactionManager, System.Int32? screeningQuestionsMappingId)
		{
			return GetByScreeningQuestionsMappingId(transactionManager, 0, int.MaxValue , screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetByScreeningQuestionsMappingId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsMappingId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsMappingId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_Find 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			return Find(null, start, pageLength , searchUsingOr, screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_GetPaged 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsMappings_GetPaged' stored procedure. 
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
		
		#region ScreeningQuestionsMappings_Update 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			 Update(null, 0, int.MaxValue , screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			 Update(null, start, pageLength , screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId)
		{
			 Update(transactionManager, 0, int.MaxValue , screeningQuestionsMappingId, screeningQuestionsTemplateId, screeningQuestionId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsMappingId, System.Int32? screeningQuestionsTemplateId, System.Int32? screeningQuestionId);
		
		#endregion
		
		#region ScreeningQuestionsMappings_Delete 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? screeningQuestionsMappingId)
		{
			 Delete(null, 0, int.MaxValue , screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? screeningQuestionsMappingId)
		{
			 Delete(null, start, pageLength , screeningQuestionsMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? screeningQuestionsMappingId)
		{
			 Delete(transactionManager, 0, int.MaxValue , screeningQuestionsMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsMappingId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ScreeningQuestionsMappings&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ScreeningQuestionsMappings&gt;"/></returns>
		public static TList<ScreeningQuestionsMappings> Fill(IDataReader reader, TList<ScreeningQuestionsMappings> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.ScreeningQuestionsMappings c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ScreeningQuestionsMappings")
					.Append("|").Append((System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionsMappingId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ScreeningQuestionsMappings>(
					key.ToString(), // EntityTrackingKey
					"ScreeningQuestionsMappings",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.ScreeningQuestionsMappings();
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
					c.ScreeningQuestionsMappingId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionsMappingId - 1)];
					c.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionsTemplateId - 1)];
					c.ScreeningQuestionId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.ScreeningQuestionsMappings entity)
		{
			if (!reader.Read()) return;
			
			entity.ScreeningQuestionsMappingId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionsMappingId - 1)];
			entity.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionsTemplateId - 1)];
			entity.ScreeningQuestionId = (System.Int32)reader[((int)ScreeningQuestionsMappingsColumn.ScreeningQuestionId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.ScreeningQuestionsMappings entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ScreeningQuestionsMappingId = (System.Int32)dataRow["ScreeningQuestionsMappingId"];
			entity.ScreeningQuestionsTemplateId = (System.Int32)dataRow["ScreeningQuestionsTemplateId"];
			entity.ScreeningQuestionId = (System.Int32)dataRow["ScreeningQuestionId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsMappings"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsMappings Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsMappings entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ScreeningQuestionsTemplateIdSource	
			if (CanDeepLoad(entity, "ScreeningQuestionsTemplates|ScreeningQuestionsTemplateIdSource", deepLoadType, innerList) 
				&& entity.ScreeningQuestionsTemplateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ScreeningQuestionsTemplateId;
				ScreeningQuestionsTemplates tmpEntity = EntityManager.LocateEntity<ScreeningQuestionsTemplates>(EntityLocator.ConstructKeyFromPkItems(typeof(ScreeningQuestionsTemplates), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ScreeningQuestionsTemplateIdSource = tmpEntity;
				else
					entity.ScreeningQuestionsTemplateIdSource = DataRepository.ScreeningQuestionsTemplatesProvider.GetByScreeningQuestionsTemplateId(transactionManager, entity.ScreeningQuestionsTemplateId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionsTemplateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ScreeningQuestionsTemplateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ScreeningQuestionsTemplatesProvider.DeepLoad(transactionManager, entity.ScreeningQuestionsTemplateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ScreeningQuestionsTemplateIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.ScreeningQuestionsMappings object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.ScreeningQuestionsMappings instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsMappings Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsMappings entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ScreeningQuestionsTemplateIdSource
			if (CanDeepSave(entity, "ScreeningQuestionsTemplates|ScreeningQuestionsTemplateIdSource", deepSaveType, innerList) 
				&& entity.ScreeningQuestionsTemplateIdSource != null)
			{
				DataRepository.ScreeningQuestionsTemplatesProvider.Save(transactionManager, entity.ScreeningQuestionsTemplateIdSource);
				entity.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
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
	
	#region ScreeningQuestionsMappingsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.ScreeningQuestionsMappings</c>
	///</summary>
	public enum ScreeningQuestionsMappingsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ScreeningQuestionsTemplates</c> at ScreeningQuestionsTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestionsTemplates))]
		ScreeningQuestionsTemplates,
			
		///<summary>
		/// Composite Property for <c>ScreeningQuestions</c> at ScreeningQuestionIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestions))]
		ScreeningQuestions,
		}
	
	#endregion ScreeningQuestionsMappingsChildEntityTypes
	
	#region ScreeningQuestionsMappingsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ScreeningQuestionsMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsMappingsFilterBuilder : SqlFilterBuilder<ScreeningQuestionsMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilterBuilder class.
		/// </summary>
		public ScreeningQuestionsMappingsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsMappingsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsMappingsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsMappingsFilterBuilder
	
	#region ScreeningQuestionsMappingsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ScreeningQuestionsMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsMappingsParameterBuilder : ParameterizedSqlFilterBuilder<ScreeningQuestionsMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsParameterBuilder class.
		/// </summary>
		public ScreeningQuestionsMappingsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsMappingsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsMappingsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsMappingsParameterBuilder
	
	#region ScreeningQuestionsMappingsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ScreeningQuestionsMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsMappings"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ScreeningQuestionsMappingsSortBuilder : SqlSortBuilder<ScreeningQuestionsMappingsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsSqlSortBuilder class.
		/// </summary>
		public ScreeningQuestionsMappingsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ScreeningQuestionsMappingsSortBuilder
	
} // end namespace
