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
	/// This class is the base class for any <see cref="ScreeningQuestionsTemplateOwnersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ScreeningQuestionsTemplateOwnersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.ScreeningQuestionsTemplateOwners, JXTPortal.Entities.ScreeningQuestionsTemplateOwnersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplateOwnersKey key)
		{
			return Delete(transactionManager, key.ScreeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_screeningQuestionsTemplatesOwnerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _screeningQuestionsTemplatesOwnerId)
		{
			return Delete(null, _screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplatesOwnerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplatesOwnerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		FK__Screening__Adver__652FF0DB Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		FK__Screening__Adver__652FF0DB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		FK__Screening__Adver__652FF0DB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		fkScreeningAdver652Ff0Db Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		fkScreeningAdver652Ff0Db Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Adver__652FF0DB key.
		///		FK__Screening__Adver__652FF0DB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public abstract TList<ScreeningQuestionsTemplateOwners> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		FK__Screening__Scree__643BCCA2 Description: 
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(_screeningQuestionsTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		FK__Screening__Scree__643BCCA2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		FK__Screening__Scree__643BCCA2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		fkScreeningScree643Bcca2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		fkScreeningScree643Bcca2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Scree__643BCCA2 key.
		///		FK__Screening__Scree__643BCCA2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplateOwners objects.</returns>
		public abstract TList<ScreeningQuestionsTemplateOwners> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.ScreeningQuestionsTemplateOwners Get(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplateOwnersKey key, int start, int pageLength)
		{
			return GetByScreeningQuestionsTemplatesOwnerId(transactionManager, key.ScreeningQuestionsTemplatesOwnerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(System.Int32 _screeningQuestionsTemplatesOwnerId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplatesOwnerId(null,_screeningQuestionsTemplatesOwnerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(System.Int32 _screeningQuestionsTemplatesOwnerId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplatesOwnerId(null, _screeningQuestionsTemplatesOwnerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplatesOwnerId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplatesOwnerId(transactionManager, _screeningQuestionsTemplatesOwnerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplatesOwnerId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplatesOwnerId(transactionManager, _screeningQuestionsTemplatesOwnerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(System.Int32 _screeningQuestionsTemplatesOwnerId, int start, int pageLength, out int count)
		{
			return GetByScreeningQuestionsTemplatesOwnerId(null, _screeningQuestionsTemplatesOwnerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E3A3EC1A62538430 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplatesOwnerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> class.</returns>
		public abstract JXTPortal.Entities.ScreeningQuestionsTemplateOwners GetByScreeningQuestionsTemplatesOwnerId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplatesOwnerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ScreeningQuestionsTemplateOwners_Insert 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId, ref System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Insert(null, 0, int.MaxValue , screeningQuestionsTemplateId, advertiserId, ref screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId, ref System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Insert(null, start, pageLength , screeningQuestionsTemplateId, advertiserId, ref screeningQuestionsTemplatesOwnerId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId, ref System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Insert(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId, advertiserId, ref screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Insert' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId, ref System.Int32? screeningQuestionsTemplatesOwnerId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_Get_List 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Get_List' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplatesOwnerId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplatesOwnerId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplatesOwnerId(System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			return GetByScreeningQuestionsTemplatesOwnerId(null, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplatesOwnerId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplatesOwnerId(int start, int pageLength, System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			return GetByScreeningQuestionsTemplatesOwnerId(null, start, pageLength , screeningQuestionsTemplatesOwnerId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplatesOwnerId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplatesOwnerId(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			return GetByScreeningQuestionsTemplatesOwnerId(transactionManager, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplatesOwnerId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsTemplatesOwnerId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplatesOwnerId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplateId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(null, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplateId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplateId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(int start, int pageLength, System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, start, pageLength , advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(TransactionManager transactionManager, System.Int32? advertiserId)
		{
			return GetByAdvertiserId(transactionManager, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_Find 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			return Find(null, start, pageLength , searchUsingOr, screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_GetPaged 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_GetPaged' stored procedure. 
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
		
		#region ScreeningQuestionsTemplateOwners_Update 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			 Update(null, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			 Update(null, start, pageLength , screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId)
		{
			 Update(transactionManager, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId, screeningQuestionsTemplateId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplatesOwnerId, System.Int32? screeningQuestionsTemplateId, System.Int32? advertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwners_Delete 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Delete(null, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Delete(null, start, pageLength , screeningQuestionsTemplatesOwnerId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplatesOwnerId)
		{
			 Delete(transactionManager, 0, int.MaxValue , screeningQuestionsTemplatesOwnerId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplateOwners_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplatesOwnerId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplatesOwnerId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ScreeningQuestionsTemplateOwners&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ScreeningQuestionsTemplateOwners&gt;"/></returns>
		public static TList<ScreeningQuestionsTemplateOwners> Fill(IDataReader reader, TList<ScreeningQuestionsTemplateOwners> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.ScreeningQuestionsTemplateOwners c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ScreeningQuestionsTemplateOwners")
					.Append("|").Append((System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.ScreeningQuestionsTemplatesOwnerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ScreeningQuestionsTemplateOwners>(
					key.ToString(), // EntityTrackingKey
					"ScreeningQuestionsTemplateOwners",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.ScreeningQuestionsTemplateOwners();
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
					c.ScreeningQuestionsTemplatesOwnerId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.ScreeningQuestionsTemplatesOwnerId - 1)];
					c.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.ScreeningQuestionsTemplateId - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.AdvertiserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.ScreeningQuestionsTemplateOwners entity)
		{
			if (!reader.Read()) return;
			
			entity.ScreeningQuestionsTemplatesOwnerId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.ScreeningQuestionsTemplatesOwnerId - 1)];
			entity.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.ScreeningQuestionsTemplateId - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)ScreeningQuestionsTemplateOwnersColumn.AdvertiserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.ScreeningQuestionsTemplateOwners entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ScreeningQuestionsTemplatesOwnerId = (System.Int32)dataRow["ScreeningQuestionsTemplatesOwnerId"];
			entity.ScreeningQuestionsTemplateId = (System.Int32)dataRow["ScreeningQuestionsTemplateId"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplateOwners"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsTemplateOwners Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplateOwners entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserIdSource	
			if (CanDeepLoad(entity, "Advertisers|AdvertiserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserId;
				Advertisers tmpEntity = EntityManager.LocateEntity<Advertisers>(EntityLocator.ConstructKeyFromPkItems(typeof(Advertisers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserIdSource = tmpEntity;
				else
					entity.AdvertiserIdSource = DataRepository.AdvertisersProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertisersProvider.DeepLoad(transactionManager, entity.AdvertiserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.ScreeningQuestionsTemplateOwners object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.ScreeningQuestionsTemplateOwners instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsTemplateOwners Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplateOwners entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdvertiserIdSource
			if (CanDeepSave(entity, "Advertisers|AdvertiserIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserIdSource != null)
			{
				DataRepository.AdvertisersProvider.Save(transactionManager, entity.AdvertiserIdSource);
				entity.AdvertiserId = entity.AdvertiserIdSource.AdvertiserId;
			}
			#endregion 
			
			#region ScreeningQuestionsTemplateIdSource
			if (CanDeepSave(entity, "ScreeningQuestionsTemplates|ScreeningQuestionsTemplateIdSource", deepSaveType, innerList) 
				&& entity.ScreeningQuestionsTemplateIdSource != null)
			{
				DataRepository.ScreeningQuestionsTemplatesProvider.Save(transactionManager, entity.ScreeningQuestionsTemplateIdSource);
				entity.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
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
	
	#region ScreeningQuestionsTemplateOwnersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.ScreeningQuestionsTemplateOwners</c>
	///</summary>
	public enum ScreeningQuestionsTemplateOwnersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>ScreeningQuestionsTemplates</c> at ScreeningQuestionsTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestionsTemplates))]
		ScreeningQuestionsTemplates,
		}
	
	#endregion ScreeningQuestionsTemplateOwnersChildEntityTypes
	
	#region ScreeningQuestionsTemplateOwnersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ScreeningQuestionsTemplateOwnersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplateOwners"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplateOwnersFilterBuilder : SqlFilterBuilder<ScreeningQuestionsTemplateOwnersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilterBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplateOwnersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplateOwnersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplateOwnersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplateOwnersFilterBuilder
	
	#region ScreeningQuestionsTemplateOwnersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ScreeningQuestionsTemplateOwnersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplateOwners"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplateOwnersParameterBuilder : ParameterizedSqlFilterBuilder<ScreeningQuestionsTemplateOwnersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersParameterBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplateOwnersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplateOwnersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplateOwnersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplateOwnersParameterBuilder
	
	#region ScreeningQuestionsTemplateOwnersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ScreeningQuestionsTemplateOwnersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplateOwners"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ScreeningQuestionsTemplateOwnersSortBuilder : SqlSortBuilder<ScreeningQuestionsTemplateOwnersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersSqlSortBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplateOwnersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ScreeningQuestionsTemplateOwnersSortBuilder
	
} // end namespace
