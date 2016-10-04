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
	/// This class is the base class for any <see cref="SalaryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalaryProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Salary, JXTPortal.Entities.SalaryKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SalaryKey key)
		{
			return Delete(transactionManager, key.SalaryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salaryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salaryId)
		{
			return Delete(null, _salaryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salaryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		FK__Salary__Currency__1E2668BC Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetByCurrencyId(System.Int32? _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		FK__Salary__Currency__1E2668BC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		/// <remarks></remarks>
		public TList<Salary> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		FK__Salary__Currency__1E2668BC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		fkSalaryCurrency1e2668Bc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetByCurrencyId(System.Int32? _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		fkSalaryCurrency1e2668Bc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetByCurrencyId(System.Int32? _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__Currency__1E2668BC key.
		///		FK__Salary__Currency__1E2668BC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public abstract TList<Salary> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		FK__Salary__SalaryTy__1D324483 Description: 
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetBySalaryTypeId(System.Int32? _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(_salaryTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		FK__Salary__SalaryTy__1D324483 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		/// <remarks></remarks>
		public TList<Salary> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		FK__Salary__SalaryTy__1D324483 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		fkSalarySalaryTy1d324483 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetBySalaryTypeId(System.Int32? _salaryTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		fkSalarySalaryTy1d324483 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public TList<Salary> GetBySalaryTypeId(System.Int32? _salaryTypeId, int start, int pageLength,out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Salary__SalaryTy__1D324483 key.
		///		FK__Salary__SalaryTy__1D324483 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Salary objects.</returns>
		public abstract TList<Salary> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Salary Get(TransactionManager transactionManager, JXTPortal.Entities.SalaryKey key, int start, int pageLength)
		{
			return GetBySalaryId(transactionManager, key.SalaryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="_salaryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public JXTPortal.Entities.Salary GetBySalaryId(System.Int32 _salaryId)
		{
			int count = -1;
			return GetBySalaryId(null,_salaryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="_salaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public JXTPortal.Entities.Salary GetBySalaryId(System.Int32 _salaryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryId(null, _salaryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public JXTPortal.Entities.Salary GetBySalaryId(TransactionManager transactionManager, System.Int32 _salaryId)
		{
			int count = -1;
			return GetBySalaryId(transactionManager, _salaryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public JXTPortal.Entities.Salary GetBySalaryId(TransactionManager transactionManager, System.Int32 _salaryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryId(transactionManager, _salaryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="_salaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public JXTPortal.Entities.Salary GetBySalaryId(System.Int32 _salaryId, int start, int pageLength, out int count)
		{
			return GetBySalaryId(null, _salaryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Salary__1C3E204A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Salary"/> class.</returns>
		public abstract JXTPortal.Entities.Salary GetBySalaryId(TransactionManager transactionManager, System.Int32 _salaryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Salary_Insert 
		
		/// <summary>
		///	This method wrap the 'Salary_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom, ref System.Int32? salaryId)
		{
			 Insert(null, 0, int.MaxValue , salaryTypeId, currencyId, amount, isFrom, ref salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom, ref System.Int32? salaryId)
		{
			 Insert(null, start, pageLength , salaryTypeId, currencyId, amount, isFrom, ref salaryId);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom, ref System.Int32? salaryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , salaryTypeId, currencyId, amount, isFrom, ref salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Insert' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom, ref System.Int32? salaryId);
		
		#endregion
		
		#region Salary_Get_List 
		
		/// <summary>
		///	This method wrap the 'Salary_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Salary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Salary_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Salary_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Salary_Find 
		
		/// <summary>
		///	This method wrap the 'Salary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Find(System.Boolean? searchUsingOr, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			return Find(null, start, pageLength , searchUsingOr, salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom);
		
		#endregion
		
		#region Salary_Delete 
		
		/// <summary>
		///	This method wrap the 'Salary_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? salaryId)
		{
			 Delete(null, 0, int.MaxValue , salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? salaryId)
		{
			 Delete(null, start, pageLength , salaryId);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? salaryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Delete' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryId);
		
		#endregion
		
		#region Salary_GetBySalaryTypeId 
		
		
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetBySalaryTypeId(int start, int pageLength, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, start, pageLength , salaryTypeId);
		}
				
				
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region Salary_Update 
		
		/// <summary>
		///	This method wrap the 'Salary_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			 Update(null, 0, int.MaxValue , salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			 Update(null, start, pageLength , salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom)
		{
			 Update(transactionManager, 0, int.MaxValue , salaryId, salaryTypeId, currencyId, amount, isFrom);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_Update' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="isFrom"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryId, System.Int32? salaryTypeId, System.Int32? currencyId, System.Decimal? amount, System.Boolean? isFrom);
		
		#endregion
		
		#region Salary_GetBySalaryId 
		
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryId' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetBySalaryId(System.Int32? salaryId)
		{
			return GetBySalaryId(null, 0, int.MaxValue , salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryId' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetBySalaryId(int start, int pageLength, System.Int32? salaryId)
		{
			return GetBySalaryId(null, start, pageLength , salaryId);
		}
				
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryId' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetBySalaryId(TransactionManager transactionManager, System.Int32? salaryId)
		{
			return GetBySalaryId(transactionManager, 0, int.MaxValue , salaryId);
		}
		
		/// <summary>
		///	This method wrap the 'Salary_GetBySalaryId' stored procedure. 
		/// </summary>
		/// <param name="salaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> GetBySalaryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryId);
		
		#endregion
		
		#region Salary_GetByCurrencyId 
		
				
		/// <summary>
		///	This method wrap the 'Salary_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public TList<Salary> GetByCurrencyId(int start, int pageLength, System.Int32? currencyId)
		{
			return GetByCurrencyId(null, start, pageLength , currencyId);
		}
				
		
		/// <summary>
		///	This method wrap the 'Salary_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Salary&gt;"/> instance.</returns>
		public abstract TList<Salary> GetByCurrencyId(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Salary&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Salary&gt;"/></returns>
		public static TList<Salary> Fill(IDataReader reader, TList<Salary> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Salary c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Salary")
					.Append("|").Append((System.Int32)reader[((int)SalaryColumn.SalaryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Salary>(
					key.ToString(), // EntityTrackingKey
					"Salary",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Salary();
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
					c.SalaryId = (System.Int32)reader[((int)SalaryColumn.SalaryId - 1)];
					c.SalaryTypeId = (reader.IsDBNull(((int)SalaryColumn.SalaryTypeId - 1)))?null:(System.Int32?)reader[((int)SalaryColumn.SalaryTypeId - 1)];
					c.CurrencyId = (reader.IsDBNull(((int)SalaryColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)SalaryColumn.CurrencyId - 1)];
					c.Amount = (System.Decimal)reader[((int)SalaryColumn.Amount - 1)];
					c.SalaryDisplay = (System.String)reader[((int)SalaryColumn.SalaryDisplay - 1)];
					c.IsFrom = (System.Boolean)reader[((int)SalaryColumn.IsFrom - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Salary"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Salary"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Salary entity)
		{
			if (!reader.Read()) return;
			
			entity.SalaryId = (System.Int32)reader[((int)SalaryColumn.SalaryId - 1)];
			entity.SalaryTypeId = (reader.IsDBNull(((int)SalaryColumn.SalaryTypeId - 1)))?null:(System.Int32?)reader[((int)SalaryColumn.SalaryTypeId - 1)];
			entity.CurrencyId = (reader.IsDBNull(((int)SalaryColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)SalaryColumn.CurrencyId - 1)];
			entity.Amount = (System.Decimal)reader[((int)SalaryColumn.Amount - 1)];
			entity.SalaryDisplay = (System.String)reader[((int)SalaryColumn.SalaryDisplay - 1)];
			entity.IsFrom = (System.Boolean)reader[((int)SalaryColumn.IsFrom - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Salary"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Salary"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Salary entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalaryId = (System.Int32)dataRow["SalaryID"];
			entity.SalaryTypeId = Convert.IsDBNull(dataRow["SalaryTypeID"]) ? null : (System.Int32?)dataRow["SalaryTypeID"];
			entity.CurrencyId = Convert.IsDBNull(dataRow["CurrencyID"]) ? null : (System.Int32?)dataRow["CurrencyID"];
			entity.Amount = (System.Decimal)dataRow["Amount"];
			entity.SalaryDisplay = (System.String)dataRow["SalaryDisplay"];
			entity.IsFrom = (System.Boolean)dataRow["IsFrom"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Salary"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Salary Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Salary entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CurrencyIdSource	
			if (CanDeepLoad(entity, "Currencies|CurrencyIdSource", deepLoadType, innerList) 
				&& entity.CurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CurrencyId ?? (int)0);
				Currencies tmpEntity = EntityManager.LocateEntity<Currencies>(EntityLocator.ConstructKeyFromPkItems(typeof(Currencies), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyIdSource = tmpEntity;
				else
					entity.CurrencyIdSource = DataRepository.CurrenciesProvider.GetByCurrencyId(transactionManager, (entity.CurrencyId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrenciesProvider.DeepLoad(transactionManager, entity.CurrencyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurrencyIdSource

			#region SalaryTypeIdSource	
			if (CanDeepLoad(entity, "SalaryType|SalaryTypeIdSource", deepLoadType, innerList) 
				&& entity.SalaryTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SalaryTypeId ?? (int)0);
				SalaryType tmpEntity = EntityManager.LocateEntity<SalaryType>(EntityLocator.ConstructKeyFromPkItems(typeof(SalaryType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalaryTypeIdSource = tmpEntity;
				else
					entity.SalaryTypeIdSource = DataRepository.SalaryTypeProvider.GetBySalaryTypeId(transactionManager, (entity.SalaryTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalaryTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalaryTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalaryTypeProvider.DeepLoad(transactionManager, entity.SalaryTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalaryTypeIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Salary object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Salary instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Salary Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Salary entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CurrencyIdSource
			if (CanDeepSave(entity, "Currencies|CurrencyIdSource", deepSaveType, innerList) 
				&& entity.CurrencyIdSource != null)
			{
				DataRepository.CurrenciesProvider.Save(transactionManager, entity.CurrencyIdSource);
				entity.CurrencyId = entity.CurrencyIdSource.CurrencyId;
			}
			#endregion 
			
			#region SalaryTypeIdSource
			if (CanDeepSave(entity, "SalaryType|SalaryTypeIdSource", deepSaveType, innerList) 
				&& entity.SalaryTypeIdSource != null)
			{
				DataRepository.SalaryTypeProvider.Save(transactionManager, entity.SalaryTypeIdSource);
				entity.SalaryTypeId = entity.SalaryTypeIdSource.SalaryTypeId;
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
	
	#region SalaryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Salary</c>
	///</summary>
	public enum SalaryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currencies</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currencies))]
		Currencies,
			
		///<summary>
		/// Composite Property for <c>SalaryType</c> at SalaryTypeIdSource
		///</summary>
		[ChildEntityType(typeof(SalaryType))]
		SalaryType,
		}
	
	#endregion SalaryChildEntityTypes
	
	#region SalaryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Salary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryFilterBuilder : SqlFilterBuilder<SalaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryFilterBuilder class.
		/// </summary>
		public SalaryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryFilterBuilder
	
	#region SalaryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Salary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryParameterBuilder : ParameterizedSqlFilterBuilder<SalaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryParameterBuilder class.
		/// </summary>
		public SalaryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryParameterBuilder
	
	#region SalarySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalaryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Salary"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalarySortBuilder : SqlSortBuilder<SalaryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalarySqlSortBuilder class.
		/// </summary>
		public SalarySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalarySortBuilder
	
} // end namespace
