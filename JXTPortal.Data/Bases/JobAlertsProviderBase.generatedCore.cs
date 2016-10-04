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
	/// This class is the base class for any <see cref="JobAlertsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobAlertsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobAlerts, JXTPortal.Entities.JobAlertsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobAlertsKey key)
		{
			return Delete(transactionManager, key.JobAlertId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobAlertId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobAlertId)
		{
			return Delete(null, _jobAlertId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAlertId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobAlertId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		FK__JobAlerts__Curre__4FD2D2E9 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByCurrencyId(System.Int32? _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		FK__JobAlerts__Curre__4FD2D2E9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		/// <remarks></remarks>
		public TList<JobAlerts> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		FK__JobAlerts__Curre__4FD2D2E9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		fkJobAlertsCurre4Fd2d2e9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByCurrencyId(System.Int32? _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		fkJobAlertsCurre4Fd2d2e9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByCurrencyId(System.Int32? _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Curre__4FD2D2E9 key.
		///		FK__JobAlerts__Curre__4FD2D2E9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public abstract TList<JobAlerts> GetByCurrencyId(TransactionManager transactionManager, System.Int32? _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		FK__JobAlerts__Membe__1D07F587 Description: 
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(_memberId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		FK__JobAlerts__Membe__1D07F587 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		/// <remarks></remarks>
		public TList<JobAlerts> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		FK__JobAlerts__Membe__1D07F587 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		fkJobAlertsMembe1d07f587 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberId(null, _memberId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		fkJobAlertsMembe1d07f587 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetByMemberId(System.Int32 _memberId, int start, int pageLength,out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Membe__1D07F587 key.
		///		FK__JobAlerts__Membe__1D07F587 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public abstract TList<JobAlerts> GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		FK__JobAlerts__Salar__50C6F722 Description: 
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySalaryTypeId(System.Int32? _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(_salaryTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		FK__JobAlerts__Salar__50C6F722 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		/// <remarks></remarks>
		public TList<JobAlerts> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		FK__JobAlerts__Salar__50C6F722 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		fkJobAlertsSalar50c6f722 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySalaryTypeId(System.Int32? _salaryTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		fkJobAlertsSalar50c6f722 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySalaryTypeId(System.Int32? _salaryTypeId, int start, int pageLength,out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__Salar__50C6F722 key.
		///		FK__JobAlerts__Salar__50C6F722 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public abstract TList<JobAlerts> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? _salaryTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		FK__JobAlerts__SiteI__1EF03DF9 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		FK__JobAlerts__SiteI__1EF03DF9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		/// <remarks></remarks>
		public TList<JobAlerts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		FK__JobAlerts__SiteI__1EF03DF9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		fkJobAlertsSitei1Ef03Df9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		fkJobAlertsSitei1Ef03Df9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public TList<JobAlerts> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobAlerts__SiteI__1EF03DF9 key.
		///		FK__JobAlerts__SiteI__1EF03DF9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobAlerts objects.</returns>
		public abstract TList<JobAlerts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobAlerts Get(TransactionManager transactionManager, JXTPortal.Entities.JobAlertsKey key, int start, int pageLength)
		{
			return GetByJobAlertId(transactionManager, key.JobAlertId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="_jobAlertId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public JXTPortal.Entities.JobAlerts GetByJobAlertId(System.Int32 _jobAlertId)
		{
			int count = -1;
			return GetByJobAlertId(null,_jobAlertId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="_jobAlertId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public JXTPortal.Entities.JobAlerts GetByJobAlertId(System.Int32 _jobAlertId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobAlertId(null, _jobAlertId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAlertId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public JXTPortal.Entities.JobAlerts GetByJobAlertId(TransactionManager transactionManager, System.Int32 _jobAlertId)
		{
			int count = -1;
			return GetByJobAlertId(transactionManager, _jobAlertId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAlertId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public JXTPortal.Entities.JobAlerts GetByJobAlertId(TransactionManager transactionManager, System.Int32 _jobAlertId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobAlertId(transactionManager, _jobAlertId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="_jobAlertId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public JXTPortal.Entities.JobAlerts GetByJobAlertId(System.Int32 _jobAlertId, int start, int pageLength, out int count)
		{
			return GetByJobAlertId(null, _jobAlertId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAlerts__1B1FAD15 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAlertId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobAlerts"/> class.</returns>
		public abstract JXTPortal.Entities.JobAlerts GetByJobAlertId(TransactionManager transactionManager, System.Int32 _jobAlertId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobAlerts_GetByProfessionId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(System.String professionId)
		{
			return GetByProfessionId(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(int start, int pageLength, System.String professionId)
		{
			return GetByProfessionId(null, start, pageLength , professionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(TransactionManager transactionManager, System.String professionId)
		{
			return GetByProfessionId(transactionManager, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByProfessionId(TransactionManager transactionManager, int start, int pageLength , System.String professionId);
		
		#endregion
		
		#region JobAlerts_GetByJobAlertId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByJobAlertId' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobAlertId(System.Int32? jobAlertId)
		{
			return GetByJobAlertId(null, 0, int.MaxValue , jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByJobAlertId' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobAlertId(int start, int pageLength, System.Int32? jobAlertId)
		{
			return GetByJobAlertId(null, start, pageLength , jobAlertId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByJobAlertId' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobAlertId(TransactionManager transactionManager, System.Int32? jobAlertId)
		{
			return GetByJobAlertId(transactionManager, 0, int.MaxValue , jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByJobAlertId' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobAlertId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAlertId);
		
		#endregion
		
		#region JobAlerts_Insert 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
			/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId, ref System.Int32? jobAlertId)
		{
			 Insert(null, 0, int.MaxValue , jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId, ref jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
			/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId, ref System.Int32? jobAlertId)
		{
			 Insert(null, start, pageLength , jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId, ref jobAlertId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
			/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId, ref System.Int32? jobAlertId)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId, ref jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
			/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId, ref System.Int32? jobAlertId);
		
		#endregion
		
		#region JobAlerts_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region JobAlerts_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLocationId(System.String locationId)
		{
			return GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLocationId(int start, int pageLength, System.String locationId)
		{
			return GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLocationId(TransactionManager transactionManager, System.String locationId)
		{
			return GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.String locationId);
		
		#endregion
		
		#region JobAlerts_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Get_List' stored procedure. 
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
		///	This method wrap the 'JobAlerts_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobAlerts_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobAlerts_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobAlerts_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobAlerts_GetPaged' stored procedure. 
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
		
		#region JobAlerts_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobAlerts_GetByCountryId 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(System.String countryId)
		{
			return GetByCountryId(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(int start, int pageLength, System.String countryId)
		{
			return GetByCountryId(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(TransactionManager transactionManager, System.String countryId)
		{
			return GetByCountryId(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCountryId(TransactionManager transactionManager, int start, int pageLength , System.String countryId);
		
		#endregion
		
		#region JobAlerts_GetAllAlertsToRunToday 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetAllAlertsToRunToday' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAlertsToRunToday(System.Int32? siteId)
		{
			return GetAllAlertsToRunToday(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetAllAlertsToRunToday' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAlertsToRunToday(int start, int pageLength, System.Int32? siteId)
		{
			return GetAllAlertsToRunToday(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_GetAllAlertsToRunToday' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAlertsToRunToday(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetAllAlertsToRunToday(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetAllAlertsToRunToday' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAllAlertsToRunToday(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobAlerts_Find 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId);
		
		#endregion
		
		#region JobAlerts_Delete 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobAlertId)
		{
			 Delete(null, 0, int.MaxValue , jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobAlertId)
		{
			 Delete(null, start, pageLength , jobAlertId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobAlertId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobAlertId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAlertId);
		
		#endregion
		
		#region JobAlerts_GetBySalaryTypeId 
		
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySalaryTypeId(int start, int pageLength, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, start, pageLength , salaryTypeId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region JobAlerts_Update 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			 Update(null, 0, int.MaxValue , jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			 Update(null, start, pageLength , jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobAlertId, jobAlertName, lastModified, searchKeywords, recurrenceType, dailyFrequency, weeklyFrequency, weeklyDayOccurence, dateLastRun, dateNextRun, memberId, alertActive, emailFormat, customRecurrenceType, lastResultCount, primaryAlert, unsubscribeValidateId, editValidateId, viewValidateId, siteId, locationId, areaIds, professionId, searchRoleIds, workTypeIds, salaryIds, daysPosted, generatedSql, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAlertId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobAlertName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="searchKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="recurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dailyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyFrequency"> A <c>System.Int32?</c> instance.</param>
		/// <param name="weeklyDayOccurence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateLastRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateNextRun"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="alertActive"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customRecurrenceType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastResultCount"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAlert"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="unsubscribeValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="editValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="viewValidateId"> A <c>System.Guid?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaIds"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="searchRoleIds"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="salaryIds"> A <c>System.String</c> instance.</param>
		/// <param name="daysPosted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="generatedSql"> A <c>System.String</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAlertId, System.String jobAlertName, System.DateTime? lastModified, System.String searchKeywords, System.Int32? recurrenceType, System.Int32? dailyFrequency, System.Int32? weeklyFrequency, System.Int32? weeklyDayOccurence, System.DateTime? dateLastRun, System.DateTime? dateNextRun, System.Int32? memberId, System.Boolean? alertActive, System.Int32? emailFormat, System.Int32? customRecurrenceType, System.Int32? lastResultCount, System.Boolean? primaryAlert, System.Guid? unsubscribeValidateId, System.Guid? editValidateId, System.Guid? viewValidateId, System.Int32? siteId, System.String locationId, System.String areaIds, System.String professionId, System.String searchRoleIds, System.String workTypeIds, System.String salaryIds, System.Int32? daysPosted, System.String generatedSql, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.String countryId);
		
		#endregion
		
		#region JobAlerts_CustomGetMemberReport 
		
		/// <summary>
		///	This method wrap the 'JobAlerts_CustomGetMemberReport' stored procedure. 
		/// </summary>
		/// <param name="siteid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datefrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateto"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetMemberReport(System.Int32? siteid, System.DateTime? datefrom, System.DateTime? dateto)
		{
			return CustomGetMemberReport(null, 0, int.MaxValue , siteid, datefrom, dateto);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_CustomGetMemberReport' stored procedure. 
		/// </summary>
		/// <param name="siteid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datefrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateto"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetMemberReport(int start, int pageLength, System.Int32? siteid, System.DateTime? datefrom, System.DateTime? dateto)
		{
			return CustomGetMemberReport(null, start, pageLength , siteid, datefrom, dateto);
		}
				
		/// <summary>
		///	This method wrap the 'JobAlerts_CustomGetMemberReport' stored procedure. 
		/// </summary>
		/// <param name="siteid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datefrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateto"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetMemberReport(TransactionManager transactionManager, System.Int32? siteid, System.DateTime? datefrom, System.DateTime? dateto)
		{
			return CustomGetMemberReport(transactionManager, 0, int.MaxValue , siteid, datefrom, dateto);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_CustomGetMemberReport' stored procedure. 
		/// </summary>
		/// <param name="siteid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datefrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateto"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetMemberReport(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteid, System.DateTime? datefrom, System.DateTime? dateto);
		
		#endregion
		
		#region JobAlerts_GetByCurrencyId 
		
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCurrencyId(int start, int pageLength, System.Int32? currencyId)
		{
			return GetByCurrencyId(null, start, pageLength , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'JobAlerts_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCurrencyId(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobAlerts&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobAlerts&gt;"/></returns>
		public static TList<JobAlerts> Fill(IDataReader reader, TList<JobAlerts> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobAlerts c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobAlerts")
					.Append("|").Append((System.Int32)reader[((int)JobAlertsColumn.JobAlertId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobAlerts>(
					key.ToString(), // EntityTrackingKey
					"JobAlerts",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobAlerts();
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
					c.JobAlertId = (System.Int32)reader[((int)JobAlertsColumn.JobAlertId - 1)];
					c.JobAlertName = (reader.IsDBNull(((int)JobAlertsColumn.JobAlertName - 1)))?null:(System.String)reader[((int)JobAlertsColumn.JobAlertName - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobAlertsColumn.LastModified - 1)];
					c.SearchKeywords = (reader.IsDBNull(((int)JobAlertsColumn.SearchKeywords - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SearchKeywords - 1)];
					c.RecurrenceType = (reader.IsDBNull(((int)JobAlertsColumn.RecurrenceType - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.RecurrenceType - 1)];
					c.DailyFrequency = (reader.IsDBNull(((int)JobAlertsColumn.DailyFrequency - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.DailyFrequency - 1)];
					c.WeeklyFrequency = (reader.IsDBNull(((int)JobAlertsColumn.WeeklyFrequency - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.WeeklyFrequency - 1)];
					c.WeeklyDayOccurence = (reader.IsDBNull(((int)JobAlertsColumn.WeeklyDayOccurence - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.WeeklyDayOccurence - 1)];
					c.DateLastRun = (reader.IsDBNull(((int)JobAlertsColumn.DateLastRun - 1)))?null:(System.DateTime?)reader[((int)JobAlertsColumn.DateLastRun - 1)];
					c.DateNextRun = (reader.IsDBNull(((int)JobAlertsColumn.DateNextRun - 1)))?null:(System.DateTime?)reader[((int)JobAlertsColumn.DateNextRun - 1)];
					c.MemberId = (System.Int32)reader[((int)JobAlertsColumn.MemberId - 1)];
					c.AlertActive = (reader.IsDBNull(((int)JobAlertsColumn.AlertActive - 1)))?null:(System.Boolean?)reader[((int)JobAlertsColumn.AlertActive - 1)];
					c.EmailFormat = (reader.IsDBNull(((int)JobAlertsColumn.EmailFormat - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.EmailFormat - 1)];
					c.CustomRecurrenceType = (reader.IsDBNull(((int)JobAlertsColumn.CustomRecurrenceType - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.CustomRecurrenceType - 1)];
					c.LastResultCount = (reader.IsDBNull(((int)JobAlertsColumn.LastResultCount - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.LastResultCount - 1)];
					c.PrimaryAlert = (reader.IsDBNull(((int)JobAlertsColumn.PrimaryAlert - 1)))?null:(System.Boolean?)reader[((int)JobAlertsColumn.PrimaryAlert - 1)];
					c.UnsubscribeValidateId = (reader.IsDBNull(((int)JobAlertsColumn.UnsubscribeValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.UnsubscribeValidateId - 1)];
					c.EditValidateId = (reader.IsDBNull(((int)JobAlertsColumn.EditValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.EditValidateId - 1)];
					c.ViewValidateId = (reader.IsDBNull(((int)JobAlertsColumn.ViewValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.ViewValidateId - 1)];
					c.SiteId = (System.Int32)reader[((int)JobAlertsColumn.SiteId - 1)];
					c.LocationId = (reader.IsDBNull(((int)JobAlertsColumn.LocationId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.LocationId - 1)];
					c.AreaIds = (reader.IsDBNull(((int)JobAlertsColumn.AreaIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.AreaIds - 1)];
					c.ProfessionId = (reader.IsDBNull(((int)JobAlertsColumn.ProfessionId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.ProfessionId - 1)];
					c.SearchRoleIds = (reader.IsDBNull(((int)JobAlertsColumn.SearchRoleIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SearchRoleIds - 1)];
					c.WorkTypeIds = (reader.IsDBNull(((int)JobAlertsColumn.WorkTypeIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.WorkTypeIds - 1)];
					c.SalaryIds = (reader.IsDBNull(((int)JobAlertsColumn.SalaryIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SalaryIds - 1)];
					c.DaysPosted = (reader.IsDBNull(((int)JobAlertsColumn.DaysPosted - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.DaysPosted - 1)];
					c.GeneratedSql = (reader.IsDBNull(((int)JobAlertsColumn.GeneratedSql - 1)))?null:(System.String)reader[((int)JobAlertsColumn.GeneratedSql - 1)];
					c.SalaryLowerBand = (reader.IsDBNull(((int)JobAlertsColumn.SalaryLowerBand - 1)))?null:(System.Decimal?)reader[((int)JobAlertsColumn.SalaryLowerBand - 1)];
					c.SalaryUpperBand = (reader.IsDBNull(((int)JobAlertsColumn.SalaryUpperBand - 1)))?null:(System.Decimal?)reader[((int)JobAlertsColumn.SalaryUpperBand - 1)];
					c.CurrencyId = (reader.IsDBNull(((int)JobAlertsColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.CurrencyId - 1)];
					c.SalaryTypeId = (reader.IsDBNull(((int)JobAlertsColumn.SalaryTypeId - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.SalaryTypeId - 1)];
					c.CountryId = (reader.IsDBNull(((int)JobAlertsColumn.CountryId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.CountryId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobAlerts"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobAlerts"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobAlerts entity)
		{
			if (!reader.Read()) return;
			
			entity.JobAlertId = (System.Int32)reader[((int)JobAlertsColumn.JobAlertId - 1)];
			entity.JobAlertName = (reader.IsDBNull(((int)JobAlertsColumn.JobAlertName - 1)))?null:(System.String)reader[((int)JobAlertsColumn.JobAlertName - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobAlertsColumn.LastModified - 1)];
			entity.SearchKeywords = (reader.IsDBNull(((int)JobAlertsColumn.SearchKeywords - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SearchKeywords - 1)];
			entity.RecurrenceType = (reader.IsDBNull(((int)JobAlertsColumn.RecurrenceType - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.RecurrenceType - 1)];
			entity.DailyFrequency = (reader.IsDBNull(((int)JobAlertsColumn.DailyFrequency - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.DailyFrequency - 1)];
			entity.WeeklyFrequency = (reader.IsDBNull(((int)JobAlertsColumn.WeeklyFrequency - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.WeeklyFrequency - 1)];
			entity.WeeklyDayOccurence = (reader.IsDBNull(((int)JobAlertsColumn.WeeklyDayOccurence - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.WeeklyDayOccurence - 1)];
			entity.DateLastRun = (reader.IsDBNull(((int)JobAlertsColumn.DateLastRun - 1)))?null:(System.DateTime?)reader[((int)JobAlertsColumn.DateLastRun - 1)];
			entity.DateNextRun = (reader.IsDBNull(((int)JobAlertsColumn.DateNextRun - 1)))?null:(System.DateTime?)reader[((int)JobAlertsColumn.DateNextRun - 1)];
			entity.MemberId = (System.Int32)reader[((int)JobAlertsColumn.MemberId - 1)];
			entity.AlertActive = (reader.IsDBNull(((int)JobAlertsColumn.AlertActive - 1)))?null:(System.Boolean?)reader[((int)JobAlertsColumn.AlertActive - 1)];
			entity.EmailFormat = (reader.IsDBNull(((int)JobAlertsColumn.EmailFormat - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.EmailFormat - 1)];
			entity.CustomRecurrenceType = (reader.IsDBNull(((int)JobAlertsColumn.CustomRecurrenceType - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.CustomRecurrenceType - 1)];
			entity.LastResultCount = (reader.IsDBNull(((int)JobAlertsColumn.LastResultCount - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.LastResultCount - 1)];
			entity.PrimaryAlert = (reader.IsDBNull(((int)JobAlertsColumn.PrimaryAlert - 1)))?null:(System.Boolean?)reader[((int)JobAlertsColumn.PrimaryAlert - 1)];
			entity.UnsubscribeValidateId = (reader.IsDBNull(((int)JobAlertsColumn.UnsubscribeValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.UnsubscribeValidateId - 1)];
			entity.EditValidateId = (reader.IsDBNull(((int)JobAlertsColumn.EditValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.EditValidateId - 1)];
			entity.ViewValidateId = (reader.IsDBNull(((int)JobAlertsColumn.ViewValidateId - 1)))?null:(System.Guid?)reader[((int)JobAlertsColumn.ViewValidateId - 1)];
			entity.SiteId = (System.Int32)reader[((int)JobAlertsColumn.SiteId - 1)];
			entity.LocationId = (reader.IsDBNull(((int)JobAlertsColumn.LocationId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.LocationId - 1)];
			entity.AreaIds = (reader.IsDBNull(((int)JobAlertsColumn.AreaIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.AreaIds - 1)];
			entity.ProfessionId = (reader.IsDBNull(((int)JobAlertsColumn.ProfessionId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.ProfessionId - 1)];
			entity.SearchRoleIds = (reader.IsDBNull(((int)JobAlertsColumn.SearchRoleIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SearchRoleIds - 1)];
			entity.WorkTypeIds = (reader.IsDBNull(((int)JobAlertsColumn.WorkTypeIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.WorkTypeIds - 1)];
			entity.SalaryIds = (reader.IsDBNull(((int)JobAlertsColumn.SalaryIds - 1)))?null:(System.String)reader[((int)JobAlertsColumn.SalaryIds - 1)];
			entity.DaysPosted = (reader.IsDBNull(((int)JobAlertsColumn.DaysPosted - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.DaysPosted - 1)];
			entity.GeneratedSql = (reader.IsDBNull(((int)JobAlertsColumn.GeneratedSql - 1)))?null:(System.String)reader[((int)JobAlertsColumn.GeneratedSql - 1)];
			entity.SalaryLowerBand = (reader.IsDBNull(((int)JobAlertsColumn.SalaryLowerBand - 1)))?null:(System.Decimal?)reader[((int)JobAlertsColumn.SalaryLowerBand - 1)];
			entity.SalaryUpperBand = (reader.IsDBNull(((int)JobAlertsColumn.SalaryUpperBand - 1)))?null:(System.Decimal?)reader[((int)JobAlertsColumn.SalaryUpperBand - 1)];
			entity.CurrencyId = (reader.IsDBNull(((int)JobAlertsColumn.CurrencyId - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.CurrencyId - 1)];
			entity.SalaryTypeId = (reader.IsDBNull(((int)JobAlertsColumn.SalaryTypeId - 1)))?null:(System.Int32?)reader[((int)JobAlertsColumn.SalaryTypeId - 1)];
			entity.CountryId = (reader.IsDBNull(((int)JobAlertsColumn.CountryId - 1)))?null:(System.String)reader[((int)JobAlertsColumn.CountryId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobAlerts"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobAlerts"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobAlerts entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobAlertId = (System.Int32)dataRow["JobAlertID"];
			entity.JobAlertName = Convert.IsDBNull(dataRow["JobAlertName"]) ? null : (System.String)dataRow["JobAlertName"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.SearchKeywords = Convert.IsDBNull(dataRow["SearchKeywords"]) ? null : (System.String)dataRow["SearchKeywords"];
			entity.RecurrenceType = Convert.IsDBNull(dataRow["RecurrenceType"]) ? null : (System.Int32?)dataRow["RecurrenceType"];
			entity.DailyFrequency = Convert.IsDBNull(dataRow["DailyFrequency"]) ? null : (System.Int32?)dataRow["DailyFrequency"];
			entity.WeeklyFrequency = Convert.IsDBNull(dataRow["WeeklyFrequency"]) ? null : (System.Int32?)dataRow["WeeklyFrequency"];
			entity.WeeklyDayOccurence = Convert.IsDBNull(dataRow["WeeklyDayOccurence"]) ? null : (System.Int32?)dataRow["WeeklyDayOccurence"];
			entity.DateLastRun = Convert.IsDBNull(dataRow["DateLastRun"]) ? null : (System.DateTime?)dataRow["DateLastRun"];
			entity.DateNextRun = Convert.IsDBNull(dataRow["DateNextRun"]) ? null : (System.DateTime?)dataRow["DateNextRun"];
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.AlertActive = Convert.IsDBNull(dataRow["AlertActive"]) ? null : (System.Boolean?)dataRow["AlertActive"];
			entity.EmailFormat = Convert.IsDBNull(dataRow["EmailFormat"]) ? null : (System.Int32?)dataRow["EmailFormat"];
			entity.CustomRecurrenceType = Convert.IsDBNull(dataRow["CustomRecurrenceType"]) ? null : (System.Int32?)dataRow["CustomRecurrenceType"];
			entity.LastResultCount = Convert.IsDBNull(dataRow["LastResultCount"]) ? null : (System.Int32?)dataRow["LastResultCount"];
			entity.PrimaryAlert = Convert.IsDBNull(dataRow["PrimaryAlert"]) ? null : (System.Boolean?)dataRow["PrimaryAlert"];
			entity.UnsubscribeValidateId = Convert.IsDBNull(dataRow["UnsubscribeValidateID"]) ? null : (System.Guid?)dataRow["UnsubscribeValidateID"];
			entity.EditValidateId = Convert.IsDBNull(dataRow["EditValidateID"]) ? null : (System.Guid?)dataRow["EditValidateID"];
			entity.ViewValidateId = Convert.IsDBNull(dataRow["ViewValidateID"]) ? null : (System.Guid?)dataRow["ViewValidateID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LocationId = Convert.IsDBNull(dataRow["LocationID"]) ? null : (System.String)dataRow["LocationID"];
			entity.AreaIds = Convert.IsDBNull(dataRow["AreaIDs"]) ? null : (System.String)dataRow["AreaIDs"];
			entity.ProfessionId = Convert.IsDBNull(dataRow["ProfessionID"]) ? null : (System.String)dataRow["ProfessionID"];
			entity.SearchRoleIds = Convert.IsDBNull(dataRow["SearchRoleIDs"]) ? null : (System.String)dataRow["SearchRoleIDs"];
			entity.WorkTypeIds = Convert.IsDBNull(dataRow["WorkTypeIDs"]) ? null : (System.String)dataRow["WorkTypeIDs"];
			entity.SalaryIds = Convert.IsDBNull(dataRow["SalaryIDs"]) ? null : (System.String)dataRow["SalaryIDs"];
			entity.DaysPosted = Convert.IsDBNull(dataRow["DaysPosted"]) ? null : (System.Int32?)dataRow["DaysPosted"];
			entity.GeneratedSql = Convert.IsDBNull(dataRow["GeneratedSQL"]) ? null : (System.String)dataRow["GeneratedSQL"];
			entity.SalaryLowerBand = Convert.IsDBNull(dataRow["SalaryLowerBand"]) ? null : (System.Decimal?)dataRow["SalaryLowerBand"];
			entity.SalaryUpperBand = Convert.IsDBNull(dataRow["SalaryUpperBand"]) ? null : (System.Decimal?)dataRow["SalaryUpperBand"];
			entity.CurrencyId = Convert.IsDBNull(dataRow["CurrencyID"]) ? null : (System.Int32?)dataRow["CurrencyID"];
			entity.SalaryTypeId = Convert.IsDBNull(dataRow["SalaryTypeID"]) ? null : (System.Int32?)dataRow["SalaryTypeID"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.String)dataRow["CountryID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobAlerts"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobAlerts Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobAlerts entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region MemberIdSource	
			if (CanDeepLoad(entity, "Members|MemberIdSource", deepLoadType, innerList) 
				&& entity.MemberIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MemberId;
				Members tmpEntity = EntityManager.LocateEntity<Members>(EntityLocator.ConstructKeyFromPkItems(typeof(Members), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MemberIdSource = tmpEntity;
				else
					entity.MemberIdSource = DataRepository.MembersProvider.GetByMemberId(transactionManager, entity.MemberId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MemberIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MembersProvider.DeepLoad(transactionManager, entity.MemberIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MemberIdSource

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

			#region SiteIdSource	
			if (CanDeepLoad(entity, "Sites|SiteIdSource", deepLoadType, innerList) 
				&& entity.SiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SiteId;
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdSource = tmpEntity;
				else
					entity.SiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, entity.SiteId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SitesProvider.DeepLoad(transactionManager, entity.SiteIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobAlerts object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobAlerts instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobAlerts Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobAlerts entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region MemberIdSource
			if (CanDeepSave(entity, "Members|MemberIdSource", deepSaveType, innerList) 
				&& entity.MemberIdSource != null)
			{
				DataRepository.MembersProvider.Save(transactionManager, entity.MemberIdSource);
				entity.MemberId = entity.MemberIdSource.MemberId;
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
			
			#region SiteIdSource
			if (CanDeepSave(entity, "Sites|SiteIdSource", deepSaveType, innerList) 
				&& entity.SiteIdSource != null)
			{
				DataRepository.SitesProvider.Save(transactionManager, entity.SiteIdSource);
				entity.SiteId = entity.SiteIdSource.SiteId;
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
	
	#region JobAlertsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobAlerts</c>
	///</summary>
	public enum JobAlertsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currencies</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currencies))]
		Currencies,
			
		///<summary>
		/// Composite Property for <c>Members</c> at MemberIdSource
		///</summary>
		[ChildEntityType(typeof(Members))]
		Members,
			
		///<summary>
		/// Composite Property for <c>SalaryType</c> at SalaryTypeIdSource
		///</summary>
		[ChildEntityType(typeof(SalaryType))]
		SalaryType,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion JobAlertsChildEntityTypes
	
	#region JobAlertsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobAlertsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsFilterBuilder : SqlFilterBuilder<JobAlertsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilterBuilder class.
		/// </summary>
		public JobAlertsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAlertsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAlertsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAlertsFilterBuilder
	
	#region JobAlertsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobAlertsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsParameterBuilder : ParameterizedSqlFilterBuilder<JobAlertsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsParameterBuilder class.
		/// </summary>
		public JobAlertsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAlertsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAlertsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAlertsParameterBuilder
	
	#region JobAlertsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobAlertsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobAlertsSortBuilder : SqlSortBuilder<JobAlertsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsSqlSortBuilder class.
		/// </summary>
		public JobAlertsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobAlertsSortBuilder
	
} // end namespace
