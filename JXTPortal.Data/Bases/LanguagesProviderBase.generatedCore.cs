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
	/// This class is the base class for any <see cref="LanguagesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LanguagesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Languages, JXTPortal.Entities.LanguagesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.LanguagesKey key)
		{
			return Delete(transactionManager, key.LanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_languageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _languageId)
		{
			return Delete(null, _languageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _languageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override JXTPortal.Entities.Languages Get(TransactionManager transactionManager, JXTPortal.Entities.LanguagesKey key, int start, int pageLength)
		{
			return GetByLanguageId(transactionManager, key.LanguageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Languages__24927208 index.
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public JXTPortal.Entities.Languages GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(null,_languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Languages__24927208 index.
		/// </summary>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public JXTPortal.Entities.Languages GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(null, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Languages__24927208 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public JXTPortal.Entities.Languages GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Languages__24927208 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public JXTPortal.Entities.Languages GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Languages__24927208 index.
		/// </summary>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public JXTPortal.Entities.Languages GetByLanguageId(System.Int32 _languageId, int start, int pageLength, out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Languages__24927208 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Languages"/> class.</returns>
		public abstract JXTPortal.Entities.Languages GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Languages_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Languages_GetPaged' stored procedure. 
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
		///	This method wrap the 'Languages_GetPaged' stored procedure. 
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
		///	This method wrap the 'Languages_GetPaged' stored procedure. 
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
		///	This method wrap the 'Languages_GetPaged' stored procedure. 
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
		
		#region Languages_Delete 
		
		/// <summary>
		///	This method wrap the 'Languages_Delete' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? languageId)
		{
			 Delete(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Delete' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? languageId)
		{
			 Delete(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'Languages_Delete' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? languageId)
		{
			 Delete(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Delete' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region Languages_Update 
		
		/// <summary>
		///	This method wrap the 'Languages_Update' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? languageId, System.String languageName)
		{
			 Update(null, 0, int.MaxValue , languageId, languageName);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Update' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? languageId, System.String languageName)
		{
			 Update(null, start, pageLength , languageId, languageName);
		}
				
		/// <summary>
		///	This method wrap the 'Languages_Update' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? languageId, System.String languageName)
		{
			 Update(transactionManager, 0, int.MaxValue , languageId, languageName);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Update' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId, System.String languageName);
		
		#endregion
		
		#region Languages_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'Languages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_GetByLanguageId' stored procedure. 
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
		///	This method wrap the 'Languages_GetByLanguageId' stored procedure. 
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
		///	This method wrap the 'Languages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region Languages_Get_List 
		
		/// <summary>
		///	This method wrap the 'Languages_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Get_List' stored procedure. 
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
		///	This method wrap the 'Languages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Languages_Insert 
		
		/// <summary>
		///	This method wrap the 'Languages_Insert' stored procedure. 
		/// </summary>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
			/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String languageName, ref System.Int32? languageId)
		{
			 Insert(null, 0, int.MaxValue , languageName, ref languageId);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Insert' stored procedure. 
		/// </summary>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
			/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String languageName, ref System.Int32? languageId)
		{
			 Insert(null, start, pageLength , languageName, ref languageId);
		}
				
		/// <summary>
		///	This method wrap the 'Languages_Insert' stored procedure. 
		/// </summary>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
			/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String languageName, ref System.Int32? languageId)
		{
			 Insert(transactionManager, 0, int.MaxValue , languageName, ref languageId);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Insert' stored procedure. 
		/// </summary>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
			/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String languageName, ref System.Int32? languageId);
		
		#endregion
		
		#region Languages_Find 
		
		/// <summary>
		///	This method wrap the 'Languages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? languageId, System.String languageName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, languageId, languageName);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? languageId, System.String languageName)
		{
			return Find(null, start, pageLength , searchUsingOr, languageId, languageName);
		}
				
		/// <summary>
		///	This method wrap the 'Languages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? languageId, System.String languageName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, languageId, languageName);
		}
		
		/// <summary>
		///	This method wrap the 'Languages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? languageId, System.String languageName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Languages&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Languages&gt;"/></returns>
		public static TList<Languages> Fill(IDataReader reader, TList<Languages> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Languages c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Languages")
					.Append("|").Append((System.Int32)reader[((int)LanguagesColumn.LanguageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Languages>(
					key.ToString(), // EntityTrackingKey
					"Languages",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Languages();
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
					c.LanguageId = (System.Int32)reader[((int)LanguagesColumn.LanguageId - 1)];
					c.LanguageName = (System.String)reader[((int)LanguagesColumn.LanguageName - 1)];
					c.CharSetMetaTag = (System.String)reader[((int)LanguagesColumn.CharSetMetaTag - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Languages"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Languages"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Languages entity)
		{
			if (!reader.Read()) return;
			
			entity.LanguageId = (System.Int32)reader[((int)LanguagesColumn.LanguageId - 1)];
			entity.LanguageName = (System.String)reader[((int)LanguagesColumn.LanguageName - 1)];
			entity.CharSetMetaTag = (System.String)reader[((int)LanguagesColumn.CharSetMetaTag - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Languages"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Languages"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Languages entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.LanguageName = (System.String)dataRow["LanguageName"];
			entity.CharSetMetaTag = (System.String)dataRow["CharSetMetaTag"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Languages"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Languages Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Languages entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByLanguageId methods when available
			
			#region DynamicPagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPagesCollection = DataRepository.DynamicPagesProvider.GetByLanguageId(transactionManager, entity.LanguageId);

				if (deep && entity.DynamicPagesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPagesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region GlobalSettingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalSettings>|GlobalSettingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalSettingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetByDefaultLanguageId(transactionManager, entity.LanguageId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WidgetContainersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WidgetContainers>|WidgetContainersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WidgetContainersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WidgetContainersCollection = DataRepository.WidgetContainersProvider.GetByLanguageId(transactionManager, entity.LanguageId);

				if (deep && entity.WidgetContainersCollection.Count > 0)
				{
					deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WidgetContainers>) DataRepository.WidgetContainersProvider.DeepLoad,
						new object[] { transactionManager, entity.WidgetContainersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteLanguagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteLanguages>|SiteLanguagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteLanguagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteLanguagesCollection = DataRepository.SiteLanguagesProvider.GetByLanguageId(transactionManager, entity.LanguageId);

				if (deep && entity.SiteLanguagesCollection.Count > 0)
				{
					deepHandles.Add("SiteLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteLanguages>) DataRepository.SiteLanguagesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteLanguagesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollection = DataRepository.SiteResourcesProvider.GetByLanguageId(transactionManager, entity.LanguageId);

				if (deep && entity.SiteResourcesCollection.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Languages object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Languages instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Languages Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Languages entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<DynamicPages>
				if (CanDeepSave(entity.DynamicPagesCollection, "List<DynamicPages>|DynamicPagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPages child in entity.DynamicPagesCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.LanguageId;
						}
						else
						{
							child.LanguageId = entity.LanguageId;
						}

					}

					if (entity.DynamicPagesCollection.Count > 0 || entity.DynamicPagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPagesCollection);
						
						deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPagesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<GlobalSettings>
				if (CanDeepSave(entity.GlobalSettingsCollection, "List<GlobalSettings>|GlobalSettingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalSettings child in entity.GlobalSettingsCollection)
					{
						if(child.DefaultLanguageIdSource != null)
						{
							child.DefaultLanguageId = child.DefaultLanguageIdSource.LanguageId;
						}
						else
						{
							child.DefaultLanguageId = entity.LanguageId;
						}

					}

					if (entity.GlobalSettingsCollection.Count > 0 || entity.GlobalSettingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalSettingsProvider.Save(transactionManager, entity.GlobalSettingsCollection);
						
						deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalSettings >) DataRepository.GlobalSettingsProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalSettingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<WidgetContainers>
				if (CanDeepSave(entity.WidgetContainersCollection, "List<WidgetContainers>|WidgetContainersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WidgetContainers child in entity.WidgetContainersCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.LanguageId;
						}
						else
						{
							child.LanguageId = entity.LanguageId;
						}

					}

					if (entity.WidgetContainersCollection.Count > 0 || entity.WidgetContainersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WidgetContainersProvider.Save(transactionManager, entity.WidgetContainersCollection);
						
						deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WidgetContainers >) DataRepository.WidgetContainersProvider.DeepSave,
							new object[] { transactionManager, entity.WidgetContainersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteLanguages>
				if (CanDeepSave(entity.SiteLanguagesCollection, "List<SiteLanguages>|SiteLanguagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteLanguages child in entity.SiteLanguagesCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.LanguageId;
						}
						else
						{
							child.LanguageId = entity.LanguageId;
						}

					}

					if (entity.SiteLanguagesCollection.Count > 0 || entity.SiteLanguagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteLanguagesProvider.Save(transactionManager, entity.SiteLanguagesCollection);
						
						deepHandles.Add("SiteLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteLanguages >) DataRepository.SiteLanguagesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteLanguagesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollection, "List<SiteResources>|SiteResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollection)
					{
						if(child.LanguageIdSource != null)
						{
							child.LanguageId = child.LanguageIdSource.LanguageId;
						}
						else
						{
							child.LanguageId = entity.LanguageId;
						}

					}

					if (entity.SiteResourcesCollection.Count > 0 || entity.SiteResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollection);
						
						deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollection, deepSaveType, childTypes, innerList }
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
	
	#region LanguagesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Languages</c>
	///</summary>
	public enum LanguagesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Languages</c> as OneToMany for DynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		DynamicPagesCollection,

		///<summary>
		/// Collection of <c>Languages</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,

		///<summary>
		/// Collection of <c>Languages</c> as OneToMany for WidgetContainersCollection
		///</summary>
		[ChildEntityType(typeof(TList<WidgetContainers>))]
		WidgetContainersCollection,

		///<summary>
		/// Collection of <c>Languages</c> as OneToMany for SiteLanguagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteLanguages>))]
		SiteLanguagesCollection,

		///<summary>
		/// Collection of <c>Languages</c> as OneToMany for SiteResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResources>))]
		SiteResourcesCollection,
	}
	
	#endregion LanguagesChildEntityTypes
	
	#region LanguagesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesFilterBuilder : SqlFilterBuilder<LanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesFilterBuilder class.
		/// </summary>
		public LanguagesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguagesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguagesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguagesFilterBuilder
	
	#region LanguagesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesParameterBuilder : ParameterizedSqlFilterBuilder<LanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesParameterBuilder class.
		/// </summary>
		public LanguagesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguagesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguagesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguagesParameterBuilder
	
	#region LanguagesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LanguagesSortBuilder : SqlSortBuilder<LanguagesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesSqlSortBuilder class.
		/// </summary>
		public LanguagesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LanguagesSortBuilder
	
} // end namespace
