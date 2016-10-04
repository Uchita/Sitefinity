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
	/// This class is the base class for any <see cref="CountriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountriesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Countries, JXTPortal.Entities.CountriesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.CountriesKey key)
		{
			return Delete(transactionManager, key.CountryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_countryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _countryId)
		{
			return Delete(null, _countryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _countryId);		
		
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
		public override JXTPortal.Entities.Countries Get(TransactionManager transactionManager, JXTPortal.Entities.CountriesKey key, int start, int pageLength)
		{
			return GetByCountryId(transactionManager, key.CountryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public JXTPortal.Entities.Countries GetByCountryId(System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(null,_countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public JXTPortal.Entities.Countries GetByCountryId(System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(null, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public JXTPortal.Entities.Countries GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public JXTPortal.Entities.Countries GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public JXTPortal.Entities.Countries GetByCountryId(System.Int32 _countryId, int start, int pageLength, out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Countries__09DE7BCC index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Countries"/> class.</returns>
		public abstract JXTPortal.Entities.Countries GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Countries_Insert 
		
		/// <summary>
		///	This method wrap the 'Countries_Insert' stored procedure. 
		/// </summary>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
			/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency, ref System.Int32? countryId)
		{
			 Insert(null, 0, int.MaxValue , countryName, abbr, valid, sequence, currency, ref countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Insert' stored procedure. 
		/// </summary>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
			/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency, ref System.Int32? countryId)
		{
			 Insert(null, start, pageLength , countryName, abbr, valid, sequence, currency, ref countryId);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_Insert' stored procedure. 
		/// </summary>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
			/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency, ref System.Int32? countryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , countryName, abbr, valid, sequence, currency, ref countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Insert' stored procedure. 
		/// </summary>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
			/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency, ref System.Int32? countryId);
		
		#endregion
		
		#region Countries_Get_List 
		
		/// <summary>
		///	This method wrap the 'Countries_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Get_List' stored procedure. 
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
		///	This method wrap the 'Countries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Countries_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Countries_GetPaged' stored procedure. 
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
		///	This method wrap the 'Countries_GetPaged' stored procedure. 
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
		///	This method wrap the 'Countries_GetPaged' stored procedure. 
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
		///	This method wrap the 'Countries_GetPaged' stored procedure. 
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
		
		#region Countries_GetSiteTree 
		
		/// <summary>
		///	This method wrap the 'Countries_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(System.Int32? siteId)
		{
			return GetSiteTree(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(int start, int pageLength, System.Int32? siteId)
		{
			return GetSiteTree(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetSiteTree(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSiteTree(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Countries_GetByCountryId 
		
		/// <summary>
		///	This method wrap the 'Countries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(System.Int32? countryId)
		{
			return GetByCountryId(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(int start, int pageLength, System.Int32? countryId)
		{
			return GetByCountryId(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(TransactionManager transactionManager, System.Int32? countryId)
		{
			return GetByCountryId(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId);
		
		#endregion
		
		#region Countries_Find 
		
		/// <summary>
		///	This method wrap the 'Countries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, countryId, countryName, abbr, valid, sequence, currency);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			return Find(null, start, pageLength , searchUsingOr, countryId, countryName, abbr, valid, sequence, currency);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, countryId, countryName, abbr, valid, sequence, currency);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency);
		
		#endregion
		
		#region Countries_Delete 
		
		/// <summary>
		///	This method wrap the 'Countries_Delete' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? countryId)
		{
			 Delete(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Delete' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? countryId)
		{
			 Delete(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_Delete' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? countryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Delete' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId);
		
		#endregion
		
		#region Countries_GetDetailWithSite 
		
		/// <summary>
		///	This method wrap the 'Countries_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(System.Int32? siteId, System.Int32? countryId)
		{
			return GetDetailWithSite(null, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(int start, int pageLength, System.Int32? siteId, System.Int32? countryId)
		{
			return GetDetailWithSite(null, start, pageLength , siteId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId)
		{
			return GetDetailWithSite(transactionManager, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetDetailWithSite(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId);
		
		#endregion
		
		#region Countries_Update 
		
		/// <summary>
		///	This method wrap the 'Countries_Update' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			 Update(null, 0, int.MaxValue , countryId, countryName, abbr, valid, sequence, currency);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Update' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			 Update(null, start, pageLength , countryId, countryName, abbr, valid, sequence, currency);
		}
				
		/// <summary>
		///	This method wrap the 'Countries_Update' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency)
		{
			 Update(transactionManager, 0, int.MaxValue , countryId, countryName, abbr, valid, sequence, currency);
		}
		
		/// <summary>
		///	This method wrap the 'Countries_Update' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="abbr"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId, System.String countryName, System.String abbr, System.Boolean? valid, System.Int32? sequence, System.String currency);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Countries&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Countries&gt;"/></returns>
		public static TList<Countries> Fill(IDataReader reader, TList<Countries> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Countries c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Countries")
					.Append("|").Append((System.Int32)reader[((int)CountriesColumn.CountryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Countries>(
					key.ToString(), // EntityTrackingKey
					"Countries",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Countries();
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
					c.CountryId = (System.Int32)reader[((int)CountriesColumn.CountryId - 1)];
					c.CountryName = (System.String)reader[((int)CountriesColumn.CountryName - 1)];
					c.Abbr = (System.String)reader[((int)CountriesColumn.Abbr - 1)];
					c.Valid = (System.Boolean)reader[((int)CountriesColumn.Valid - 1)];
					c.Sequence = (reader.IsDBNull(((int)CountriesColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)CountriesColumn.Sequence - 1)];
					c.Currency = (reader.IsDBNull(((int)CountriesColumn.Currency - 1)))?null:(System.String)reader[((int)CountriesColumn.Currency - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Countries"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Countries"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Countries entity)
		{
			if (!reader.Read()) return;
			
			entity.CountryId = (System.Int32)reader[((int)CountriesColumn.CountryId - 1)];
			entity.CountryName = (System.String)reader[((int)CountriesColumn.CountryName - 1)];
			entity.Abbr = (System.String)reader[((int)CountriesColumn.Abbr - 1)];
			entity.Valid = (System.Boolean)reader[((int)CountriesColumn.Valid - 1)];
			entity.Sequence = (reader.IsDBNull(((int)CountriesColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)CountriesColumn.Sequence - 1)];
			entity.Currency = (reader.IsDBNull(((int)CountriesColumn.Currency - 1)))?null:(System.String)reader[((int)CountriesColumn.Currency - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Countries"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Countries"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Countries entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CountryId = (System.Int32)dataRow["CountryID"];
			entity.CountryName = (System.String)dataRow["CountryName"];
			entity.Abbr = (System.String)dataRow["Abbr"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
			entity.Currency = Convert.IsDBNull(dataRow["Currency"]) ? null : (System.String)dataRow["Currency"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Countries"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Countries Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Countries entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCountryId methods when available
			
			#region MembersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Members>|MembersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MembersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MembersCollection = DataRepository.MembersProvider.GetByCountryId(transactionManager, entity.CountryId);

				if (deep && entity.MembersCollection.Count > 0)
				{
					deepHandles.Add("MembersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Members>) DataRepository.MembersProvider.DeepLoad,
						new object[] { transactionManager, entity.MembersCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.WidgetContainersCollection = DataRepository.WidgetContainersProvider.GetByDefaultCountryId(transactionManager, entity.CountryId);

				if (deep && entity.WidgetContainersCollection.Count > 0)
				{
					deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WidgetContainers>) DataRepository.WidgetContainersProvider.DeepLoad,
						new object[] { transactionManager, entity.WidgetContainersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteCountriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteCountries>|SiteCountriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteCountriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteCountriesCollection = DataRepository.SiteCountriesProvider.GetByCountryId(transactionManager, entity.CountryId);

				if (deep && entity.SiteCountriesCollection.Count > 0)
				{
					deepHandles.Add("SiteCountriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteCountries>) DataRepository.SiteCountriesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteCountriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LocationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Location>|LocationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LocationCollection = DataRepository.LocationProvider.GetByCountryId(transactionManager, entity.CountryId);

				if (deep && entity.LocationCollection.Count > 0)
				{
					deepHandles.Add("LocationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Location>) DataRepository.LocationProvider.DeepLoad,
						new object[] { transactionManager, entity.LocationCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetByDefaultCountryId(transactionManager, entity.CountryId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region GlobalLocationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalLocation>|GlobalLocationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalLocationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalLocationCollection = DataRepository.GlobalLocationProvider.GetByCountryId(transactionManager, entity.CountryId);

				if (deep && entity.GlobalLocationCollection.Count > 0)
				{
					deepHandles.Add("GlobalLocationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalLocation>) DataRepository.GlobalLocationProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalLocationCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Countries object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Countries instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Countries Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Countries entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Members>
				if (CanDeepSave(entity.MembersCollection, "List<Members>|MembersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Members child in entity.MembersCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.CountryId;
						}
						else
						{
							child.CountryId = entity.CountryId;
						}

					}

					if (entity.MembersCollection.Count > 0 || entity.MembersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MembersProvider.Save(transactionManager, entity.MembersCollection);
						
						deepHandles.Add("MembersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Members >) DataRepository.MembersProvider.DeepSave,
							new object[] { transactionManager, entity.MembersCollection, deepSaveType, childTypes, innerList }
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
						if(child.DefaultCountryIdSource != null)
						{
							child.DefaultCountryId = child.DefaultCountryIdSource.CountryId;
						}
						else
						{
							child.DefaultCountryId = entity.CountryId;
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
				
	
			#region List<SiteCountries>
				if (CanDeepSave(entity.SiteCountriesCollection, "List<SiteCountries>|SiteCountriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteCountries child in entity.SiteCountriesCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.CountryId;
						}
						else
						{
							child.CountryId = entity.CountryId;
						}

					}

					if (entity.SiteCountriesCollection.Count > 0 || entity.SiteCountriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteCountriesProvider.Save(transactionManager, entity.SiteCountriesCollection);
						
						deepHandles.Add("SiteCountriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteCountries >) DataRepository.SiteCountriesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteCountriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Location>
				if (CanDeepSave(entity.LocationCollection, "List<Location>|LocationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Location child in entity.LocationCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.CountryId;
						}
						else
						{
							child.CountryId = entity.CountryId;
						}

					}

					if (entity.LocationCollection.Count > 0 || entity.LocationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.LocationProvider.Save(transactionManager, entity.LocationCollection);
						
						deepHandles.Add("LocationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Location >) DataRepository.LocationProvider.DeepSave,
							new object[] { transactionManager, entity.LocationCollection, deepSaveType, childTypes, innerList }
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
						if(child.DefaultCountryIdSource != null)
						{
							child.DefaultCountryId = child.DefaultCountryIdSource.CountryId;
						}
						else
						{
							child.DefaultCountryId = entity.CountryId;
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
				
	
			#region List<GlobalLocation>
				if (CanDeepSave(entity.GlobalLocationCollection, "List<GlobalLocation>|GlobalLocationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalLocation child in entity.GlobalLocationCollection)
					{
						if(child.CountryIdSource != null)
						{
							child.CountryId = child.CountryIdSource.CountryId;
						}
						else
						{
							child.CountryId = entity.CountryId;
						}

					}

					if (entity.GlobalLocationCollection.Count > 0 || entity.GlobalLocationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalLocationProvider.Save(transactionManager, entity.GlobalLocationCollection);
						
						deepHandles.Add("GlobalLocationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalLocation >) DataRepository.GlobalLocationProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalLocationCollection, deepSaveType, childTypes, innerList }
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
	
	#region CountriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Countries</c>
	///</summary>
	public enum CountriesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for MembersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Members>))]
		MembersCollection,

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for WidgetContainersCollection
		///</summary>
		[ChildEntityType(typeof(TList<WidgetContainers>))]
		WidgetContainersCollection,

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for SiteCountriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteCountries>))]
		SiteCountriesCollection,

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for LocationCollection
		///</summary>
		[ChildEntityType(typeof(TList<Location>))]
		LocationCollection,

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for GlobalLocationCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalLocation>))]
		GlobalLocationCollection,
	}
	
	#endregion CountriesChildEntityTypes
	
	#region CountriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilterBuilder : SqlFilterBuilder<CountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		public CountriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesFilterBuilder
	
	#region CountriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesParameterBuilder : ParameterizedSqlFilterBuilder<CountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		public CountriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesParameterBuilder
	
	#region CountriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CountriesSortBuilder : SqlSortBuilder<CountriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesSqlSortBuilder class.
		/// </summary>
		public CountriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CountriesSortBuilder
	
} // end namespace
