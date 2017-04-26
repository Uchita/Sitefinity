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
	/// This class is the base class for any <see cref="SchemaVersionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SchemaVersionsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SchemaVersions, JXTPortal.Entities.SchemaVersionsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SchemaVersionsKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
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
		public override JXTPortal.Entities.SchemaVersions Get(TransactionManager transactionManager, JXTPortal.Entities.SchemaVersionsKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public JXTPortal.Entities.SchemaVersions GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public JXTPortal.Entities.SchemaVersions GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public JXTPortal.Entities.SchemaVersions GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public JXTPortal.Entities.SchemaVersions GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public JXTPortal.Entities.SchemaVersions GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SchemaVersions_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SchemaVersions"/> class.</returns>
		public abstract JXTPortal.Entities.SchemaVersions GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SchemaVersions_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_GetPaged' stored procedure. 
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
		///	This method wrap the 'SchemaVersions_GetPaged' stored procedure. 
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
		///	This method wrap the 'SchemaVersions_GetPaged' stored procedure. 
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
		///	This method wrap the 'SchemaVersions_GetPaged' stored procedure. 
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
		
		#region SchemaVersions_Delete 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? id)
		{
			 Delete(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? id)
		{
			 Delete(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'SchemaVersions_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? id)
		{
			 Delete(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Delete' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region SchemaVersions_Update 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			 Update(null, 0, int.MaxValue , id, scriptName, applied);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			 Update(null, start, pageLength , id, scriptName, applied);
		}
				
		/// <summary>
		///	This method wrap the 'SchemaVersions_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			 Update(transactionManager, 0, int.MaxValue , id, scriptName, applied);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Update' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? id, System.String scriptName, System.DateTime? applied);
		
		#endregion
		
		#region SchemaVersions_Insert 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Insert' stored procedure. 
		/// </summary>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String scriptName, System.DateTime? applied, ref System.Int32? id)
		{
			 Insert(null, 0, int.MaxValue , scriptName, applied, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Insert' stored procedure. 
		/// </summary>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String scriptName, System.DateTime? applied, ref System.Int32? id)
		{
			 Insert(null, start, pageLength , scriptName, applied, ref id);
		}
				
		/// <summary>
		///	This method wrap the 'SchemaVersions_Insert' stored procedure. 
		/// </summary>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String scriptName, System.DateTime? applied, ref System.Int32? id)
		{
			 Insert(transactionManager, 0, int.MaxValue , scriptName, applied, ref id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Insert' stored procedure. 
		/// </summary>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String scriptName, System.DateTime? applied, ref System.Int32? id);
		
		#endregion
		
		#region SchemaVersions_Get_List 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Get_List' stored procedure. 
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
		///	This method wrap the 'SchemaVersions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SchemaVersions_GetById 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(System.Int32? id)
		{
			return GetById(null, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(int start, int pageLength, System.Int32? id)
		{
			return GetById(null, start, pageLength , id);
		}
				
		/// <summary>
		///	This method wrap the 'SchemaVersions_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetById(TransactionManager transactionManager, System.Int32? id)
		{
			return GetById(transactionManager, 0, int.MaxValue , id);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_GetById' stored procedure. 
		/// </summary>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetById(TransactionManager transactionManager, int start, int pageLength , System.Int32? id);
		
		#endregion
		
		#region SchemaVersions_Find 
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, id, scriptName, applied);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			return Find(null, start, pageLength , searchUsingOr, id, scriptName, applied);
		}
				
		/// <summary>
		///	This method wrap the 'SchemaVersions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? id, System.String scriptName, System.DateTime? applied)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, id, scriptName, applied);
		}
		
		/// <summary>
		///	This method wrap the 'SchemaVersions_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="id"> A <c>System.Int32?</c> instance.</param>
		/// <param name="scriptName"> A <c>System.String</c> instance.</param>
		/// <param name="applied"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? id, System.String scriptName, System.DateTime? applied);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SchemaVersions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SchemaVersions&gt;"/></returns>
		public static TList<SchemaVersions> Fill(IDataReader reader, TList<SchemaVersions> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SchemaVersions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SchemaVersions")
					.Append("|").Append((System.Int32)reader[((int)SchemaVersionsColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SchemaVersions>(
					key.ToString(), // EntityTrackingKey
					"SchemaVersions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SchemaVersions();
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
					c.Id = (System.Int32)reader[((int)SchemaVersionsColumn.Id - 1)];
					c.ScriptName = (System.String)reader[((int)SchemaVersionsColumn.ScriptName - 1)];
					c.Applied = (System.DateTime)reader[((int)SchemaVersionsColumn.Applied - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SchemaVersions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SchemaVersions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SchemaVersions entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)SchemaVersionsColumn.Id - 1)];
			entity.ScriptName = (System.String)reader[((int)SchemaVersionsColumn.ScriptName - 1)];
			entity.Applied = (System.DateTime)reader[((int)SchemaVersionsColumn.Applied - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SchemaVersions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SchemaVersions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SchemaVersions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.ScriptName = (System.String)dataRow["ScriptName"];
			entity.Applied = (System.DateTime)dataRow["Applied"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SchemaVersions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SchemaVersions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SchemaVersions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SchemaVersions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SchemaVersions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SchemaVersions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SchemaVersions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SchemaVersionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SchemaVersions</c>
	///</summary>
	public enum SchemaVersionsChildEntityTypes
	{
	}
	
	#endregion SchemaVersionsChildEntityTypes
	
	#region SchemaVersionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchemaVersionsFilterBuilder : SqlFilterBuilder<SchemaVersionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilterBuilder class.
		/// </summary>
		public SchemaVersionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchemaVersionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchemaVersionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchemaVersionsFilterBuilder
	
	#region SchemaVersionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchemaVersionsParameterBuilder : ParameterizedSqlFilterBuilder<SchemaVersionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsParameterBuilder class.
		/// </summary>
		public SchemaVersionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchemaVersionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchemaVersionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchemaVersionsParameterBuilder
	
	#region SchemaVersionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SchemaVersions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SchemaVersionsSortBuilder : SqlSortBuilder<SchemaVersionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsSqlSortBuilder class.
		/// </summary>
		public SchemaVersionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SchemaVersionsSortBuilder
	
} // end namespace
