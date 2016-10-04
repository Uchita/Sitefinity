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
	/// This class is the base class for any <see cref="CurrenciesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CurrenciesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Currencies, JXTPortal.Entities.CurrenciesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.CurrenciesKey key)
		{
			return Delete(transactionManager, key.CurrencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_currencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _currencyId)
		{
			return Delete(null, _currencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _currencyId);		
		
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
		public override JXTPortal.Entities.Currencies Get(TransactionManager transactionManager, JXTPortal.Entities.CurrenciesKey key, int start, int pageLength)
		{
			return GetByCurrencyId(transactionManager, key.CurrencyId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public JXTPortal.Entities.Currencies GetByCurrencyId(System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(null,_currencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public JXTPortal.Entities.Currencies GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public JXTPortal.Entities.Currencies GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public JXTPortal.Entities.Currencies GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public JXTPortal.Entities.Currencies GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength, out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Currencies__281227AE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Currencies"/> class.</returns>
		public abstract JXTPortal.Entities.Currencies GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Currencies_Insert 
		
		/// <summary>
		///	This method wrap the 'Currencies_Insert' stored procedure. 
		/// </summary>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
			/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String currencySymbol, ref System.Int32? currencyId)
		{
			 Insert(null, 0, int.MaxValue , currencySymbol, ref currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Insert' stored procedure. 
		/// </summary>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
			/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String currencySymbol, ref System.Int32? currencyId)
		{
			 Insert(null, start, pageLength , currencySymbol, ref currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_Insert' stored procedure. 
		/// </summary>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
			/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String currencySymbol, ref System.Int32? currencyId)
		{
			 Insert(transactionManager, 0, int.MaxValue , currencySymbol, ref currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Insert' stored procedure. 
		/// </summary>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
			/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String currencySymbol, ref System.Int32? currencyId);
		
		#endregion
		
		#region Currencies_Get_List 
		
		/// <summary>
		///	This method wrap the 'Currencies_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public abstract TList<Currencies> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Currencies_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Currencies_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public abstract TList<Currencies> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Currencies_Update 
		
		/// <summary>
		///	This method wrap the 'Currencies_Update' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? currencyId, System.String currencySymbol)
		{
			 Update(null, 0, int.MaxValue , currencyId, currencySymbol);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Update' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? currencyId, System.String currencySymbol)
		{
			 Update(null, start, pageLength , currencyId, currencySymbol);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_Update' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? currencyId, System.String currencySymbol)
		{
			 Update(transactionManager, 0, int.MaxValue , currencyId, currencySymbol);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Update' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId, System.String currencySymbol);
		
		#endregion
		
		#region Currencies_Find 
		
		/// <summary>
		///	This method wrap the 'Currencies_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Find(System.Boolean? searchUsingOr, System.Int32? currencyId, System.String currencySymbol)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, currencyId, currencySymbol);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? currencyId, System.String currencySymbol)
		{
			return Find(null, start, pageLength , searchUsingOr, currencyId, currencySymbol);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? currencyId, System.String currencySymbol)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, currencyId, currencySymbol);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public abstract TList<Currencies> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? currencyId, System.String currencySymbol);
		
		#endregion
		
		#region Currencies_Delete 
		
		/// <summary>
		///	This method wrap the 'Currencies_Delete' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? currencyId)
		{
			 Delete(null, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Delete' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? currencyId)
		{
			 Delete(null, start, pageLength , currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_Delete' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? currencyId)
		{
			 Delete(transactionManager, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_Delete' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#region Currencies_GetBySiteIdCustom 
		
		/// <summary>
		///	This method wrap the 'Currencies_GetBySiteIdCustom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetBySiteIdCustom(System.Int32? siteId)
		{
			return GetBySiteIdCustom(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetBySiteIdCustom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetBySiteIdCustom(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteIdCustom(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_GetBySiteIdCustom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetBySiteIdCustom(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteIdCustom(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetBySiteIdCustom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public abstract TList<Currencies> GetBySiteIdCustom(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Currencies_GetByCurrencyId 
		
		/// <summary>
		///	This method wrap the 'Currencies_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetByCurrencyId(System.Int32? currencyId)
		{
			return GetByCurrencyId(null, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetByCurrencyId(int start, int pageLength, System.Int32? currencyId)
		{
			return GetByCurrencyId(null, start, pageLength , currencyId);
		}
				
		/// <summary>
		///	This method wrap the 'Currencies_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public TList<Currencies> GetByCurrencyId(TransactionManager transactionManager, System.Int32? currencyId)
		{
			return GetByCurrencyId(transactionManager, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Currencies_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Currencies&gt;"/> instance.</returns>
		public abstract TList<Currencies> GetByCurrencyId(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Currencies&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Currencies&gt;"/></returns>
		public static TList<Currencies> Fill(IDataReader reader, TList<Currencies> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Currencies c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Currencies")
					.Append("|").Append((System.Int32)reader[((int)CurrenciesColumn.CurrencyId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Currencies>(
					key.ToString(), // EntityTrackingKey
					"Currencies",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Currencies();
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
					c.CurrencyId = (System.Int32)reader[((int)CurrenciesColumn.CurrencyId - 1)];
					c.CurrencySymbol = (System.String)reader[((int)CurrenciesColumn.CurrencySymbol - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Currencies"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Currencies"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Currencies entity)
		{
			if (!reader.Read()) return;
			
			entity.CurrencyId = (System.Int32)reader[((int)CurrenciesColumn.CurrencyId - 1)];
			entity.CurrencySymbol = (System.String)reader[((int)CurrenciesColumn.CurrencySymbol - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Currencies"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Currencies"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Currencies entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CurrencyId = (System.Int32)dataRow["CurrencyID"];
			entity.CurrencySymbol = (System.String)dataRow["CurrencySymbol"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Currencies"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Currencies Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Currencies entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCurrencyId methods when available
			
			#region SiteCurrenciesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteCurrencies>|SiteCurrenciesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteCurrenciesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteCurrenciesCollection = DataRepository.SiteCurrenciesProvider.GetByCurrencyId(transactionManager, entity.CurrencyId);

				if (deep && entity.SiteCurrenciesCollection.Count > 0)
				{
					deepHandles.Add("SiteCurrenciesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteCurrencies>) DataRepository.SiteCurrenciesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteCurrenciesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetByCurrencyId(transactionManager, entity.CurrencyId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsArchiveCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsArchive>|JobsArchiveCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsArchiveCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByCurrencyId(transactionManager, entity.CurrencyId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Currencies object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Currencies instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Currencies Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Currencies entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SiteCurrencies>
				if (CanDeepSave(entity.SiteCurrenciesCollection, "List<SiteCurrencies>|SiteCurrenciesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteCurrencies child in entity.SiteCurrenciesCollection)
					{
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.CurrencyId;
						}
						else
						{
							child.CurrencyId = entity.CurrencyId;
						}

					}

					if (entity.SiteCurrenciesCollection.Count > 0 || entity.SiteCurrenciesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteCurrenciesProvider.Save(transactionManager, entity.SiteCurrenciesCollection);
						
						deepHandles.Add("SiteCurrenciesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteCurrencies >) DataRepository.SiteCurrenciesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteCurrenciesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.CurrencyId;
						}
						else
						{
							child.CurrencyId = entity.CurrencyId;
						}

					}

					if (entity.JobsCollection.Count > 0 || entity.JobsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsProvider.Save(transactionManager, entity.JobsCollection);
						
						deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Jobs >) DataRepository.JobsProvider.DeepSave,
							new object[] { transactionManager, entity.JobsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobsArchive>
				if (CanDeepSave(entity.JobsArchiveCollection, "List<JobsArchive>|JobsArchiveCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsArchive child in entity.JobsArchiveCollection)
					{
						if(child.CurrencyIdSource != null)
						{
							child.CurrencyId = child.CurrencyIdSource.CurrencyId;
						}
						else
						{
							child.CurrencyId = entity.CurrencyId;
						}

					}

					if (entity.JobsArchiveCollection.Count > 0 || entity.JobsArchiveCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobsArchiveCollection);
						
						deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsArchive >) DataRepository.JobsArchiveProvider.DeepSave,
							new object[] { transactionManager, entity.JobsArchiveCollection, deepSaveType, childTypes, innerList }
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
	
	#region CurrenciesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Currencies</c>
	///</summary>
	public enum CurrenciesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Currencies</c> as OneToMany for SiteCurrenciesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteCurrencies>))]
		SiteCurrenciesCollection,

		///<summary>
		/// Collection of <c>Currencies</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>Currencies</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,
	}
	
	#endregion CurrenciesChildEntityTypes
	
	#region CurrenciesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrenciesFilterBuilder : SqlFilterBuilder<CurrenciesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilterBuilder class.
		/// </summary>
		public CurrenciesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrenciesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrenciesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrenciesFilterBuilder
	
	#region CurrenciesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrenciesParameterBuilder : ParameterizedSqlFilterBuilder<CurrenciesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrenciesParameterBuilder class.
		/// </summary>
		public CurrenciesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrenciesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrenciesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrenciesParameterBuilder
	
	#region CurrenciesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currencies"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CurrenciesSortBuilder : SqlSortBuilder<CurrenciesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrenciesSqlSortBuilder class.
		/// </summary>
		public CurrenciesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CurrenciesSortBuilder
	
} // end namespace
