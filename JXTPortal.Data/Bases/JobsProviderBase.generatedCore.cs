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
	/// This class is the base class for any <see cref="JobsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Jobs, JXTPortal.Entities.JobsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobsKey key)
		{
			return Delete(transactionManager, key.JobId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobId)
		{
			return Delete(null, _jobId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		FK__Jobs__Advertiser__6C63F2D5 Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByAdvertiserId(System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		FK__Jobs__Advertiser__6C63F2D5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		FK__Jobs__Advertiser__6C63F2D5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		fkJobsAdvertiser6c63f2d5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		fkJobsAdvertiser6c63f2d5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__Advertiser__6C63F2D5 key.
		///		FK__Jobs__Advertiser__6C63F2D5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		FK__Jobs__CurrencyID__45554476 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByCurrencyId(System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		FK__Jobs__CurrencyID__45554476 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		FK__Jobs__CurrencyID__45554476 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		fkJobsCurrencyId45554476 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		fkJobsCurrencyId45554476 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__CurrencyID__45554476 key.
		///		FK__Jobs__CurrencyID__45554476 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		FK__Jobs__JobTemplat__703483B9 Description: 
		/// </summary>
		/// <param name="_jobTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByJobTemplateId(System.Int32? _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(_jobTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		FK__Jobs__JobTemplat__703483B9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		FK__Jobs__JobTemplat__703483B9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		fkJobsJobTemplat703483b9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByJobTemplateId(System.Int32? _jobTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		fkJobsJobTemplat703483b9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByJobTemplateId(System.Int32? _jobTemplateId, int start, int pageLength,out int count)
		{
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__JobTemplat__703483B9 key.
		///		FK__Jobs__JobTemplat__703483B9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		FK__Jobs__LastModifi__6D58170E Description: 
		/// </summary>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(_lastModifiedByAdvertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		FK__Jobs__LastModifi__6D58170E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		FK__Jobs__LastModifi__6D58170E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		fkJobsLastModifi6d58170e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		fkJobsLastModifi6d58170e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength,out int count)
		{
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6D58170E key.
		///		FK__Jobs__LastModifi__6D58170E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		FK__Jobs__LastModifi__6E4C3B47 Description: 
		/// </summary>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(_lastModifiedByAdminUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		FK__Jobs__LastModifi__6E4C3B47 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(transactionManager, _lastModifiedByAdminUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		FK__Jobs__LastModifi__6E4C3B47 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(transactionManager, _lastModifiedByAdminUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		fkJobsLastModifi6e4c3b47 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedByAdminUserId(null, _lastModifiedByAdminUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		fkJobsLastModifi6e4c3b47 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId, int start, int pageLength,out int count)
		{
			return GetByLastModifiedByAdminUserId(null, _lastModifiedByAdminUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__LastModifi__6E4C3B47 key.
		///		FK__Jobs__LastModifi__6E4C3B47 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		FK__Jobs__SalaryType__464968AF Description: 
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySalaryTypeId(System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(_salaryTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		FK__Jobs__SalaryType__464968AF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		FK__Jobs__SalaryType__464968AF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		fkJobsSalaryType464968Af Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		fkJobsSalaryType464968Af Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength,out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SalaryType__464968AF key.
		///		FK__Jobs__SalaryType__464968AF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		FK__Jobs__ScreeningQ__43CEFD10 Description: 
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByScreeningQuestionsTemplateId(System.Int32? _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(_screeningQuestionsTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		FK__Jobs__ScreeningQ__43CEFD10 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32? _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		FK__Jobs__ScreeningQ__43CEFD10 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32? _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		fkJobsScreeningq43Cefd10 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByScreeningQuestionsTemplateId(System.Int32? _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		fkJobsScreeningq43Cefd10 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByScreeningQuestionsTemplateId(System.Int32? _screeningQuestionsTemplateId, int start, int pageLength,out int count)
		{
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__ScreeningQ__43CEFD10 key.
		///		FK__Jobs__ScreeningQ__43CEFD10 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32? _screeningQuestionsTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		FK__Jobs__SiteID__64C2D10D Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		FK__Jobs__SiteID__64C2D10D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		FK__Jobs__SiteID__64C2D10D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		fkJobsSiteId64c2d10d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		fkJobsSiteId64c2d10d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__SiteID__64C2D10D key.
		///		FK__Jobs__SiteID__64C2D10D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		FK__Jobs__WorkTypeID__65B6F546 Description: 
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByWorkTypeId(System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(_workTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		FK__Jobs__WorkTypeID__65B6F546 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		/// <remarks></remarks>
		public TList<Jobs> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		FK__Jobs__WorkTypeID__65B6F546 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		fkJobsWorkTypeId65b6f546 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWorkTypeId(null, _workTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		fkJobsWorkTypeId65b6f546 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public TList<Jobs> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength,out int count)
		{
			return GetByWorkTypeId(null, _workTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Jobs__WorkTypeID__65B6F546 key.
		///		FK__Jobs__WorkTypeID__65B6F546 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Jobs objects.</returns>
		public abstract TList<Jobs> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Jobs Get(TransactionManager transactionManager, JXTPortal.Entities.JobsKey key, int start, int pageLength)
		{
			return GetByJobId(transactionManager, key.JobId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredAdvertiserIdExpiryDate(null,_expired, _advertiserId, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredAdvertiserIdExpiryDate(null, _expired, _advertiserId, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredAdvertiserIdExpiryDate(transactionManager, _expired, _advertiserId, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredAdvertiserIdExpiryDate(transactionManager, _expired, _advertiserId, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate, int start, int pageLength, out int count)
		{
			return GetByExpiredAdvertiserIdExpiryDate(null, _expired, _advertiserId, _expiryDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_AdvertiserID_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetByExpiredAdvertiserIdExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Int32? _advertiserId, System.DateTime _expiryDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredBilledExpiryDate(System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredBilledExpiryDate(null,_expired, _billed, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredBilledExpiryDate(System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredBilledExpiryDate(null, _expired, _billed, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredBilledExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredBilledExpiryDate(transactionManager, _expired, _billed, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredBilledExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredBilledExpiryDate(transactionManager, _expired, _billed, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredBilledExpiryDate(System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate, int start, int pageLength, out int count)
		{
			return GetByExpiredBilledExpiryDate(null, _expired, _billed, _expiryDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_Bill_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetByExpiredBilledExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.Boolean _billed, System.DateTime _expiryDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredExpiryDate(System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredExpiryDate(null,_expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredExpiryDate(System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredExpiryDate(null, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByExpiredExpiryDate(transactionManager, _expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByExpiredExpiryDate(transactionManager, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByExpiredExpiryDate(System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count)
		{
			return GetByExpiredExpiryDate(null, _expired, _expiryDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Expired_ExpiryDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetByExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_Search index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(null,_workTypeId, _jobId, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Search index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(null, _workTypeId, _jobId, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(TransactionManager transactionManager, System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(transactionManager, _workTypeId, _jobId, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(TransactionManager transactionManager, System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(transactionManager, _workTypeId, _jobId, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Search index.
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count)
		{
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(null, _workTypeId, _jobId, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired, _expiryDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(TransactionManager transactionManager, System.Int32 _workTypeId, System.Int32 _jobId, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(null,_siteId, _billed, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(null, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(transactionManager, _siteId, _billed, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(transactionManager, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength, out int count)
		{
			return GetBySiteIdBilledAdvertiserId(null, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId)
		{
			int count = -1;
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(null,_siteId, _expired, _billed, _advertiserId, _enteredByAdvertiserUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(null, _siteId, _expired, _billed, _advertiserId, _enteredByAdvertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId)
		{
			int count = -1;
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(transactionManager, _siteId, _expired, _billed, _advertiserId, _enteredByAdvertiserUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(transactionManager, _siteId, _expired, _billed, _advertiserId, _enteredByAdvertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId, int start, int pageLength, out int count)
		{
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(null, _siteId, _expired, _billed, _advertiserId, _enteredByAdvertiserUserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Jobs_SiteID_Expired_Billed_AdvertiserID_EnteredByAdvertiserUserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_expired"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_enteredByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Jobs&gt;"/> class.</returns>
		public abstract TList<Jobs> GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _expired, System.Boolean _billed, System.Int32? _advertiserId, System.Int32? _enteredByAdvertiserUserId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public JXTPortal.Entities.Jobs GetByJobId(System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(null,_jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public JXTPortal.Entities.Jobs GetByJobId(System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public JXTPortal.Entities.Jobs GetByJobId(TransactionManager transactionManager, System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public JXTPortal.Entities.Jobs GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public JXTPortal.Entities.Jobs GetByJobId(System.Int32 _jobId, int start, int pageLength, out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Jobs__63CEACD4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Jobs"/> class.</returns>
		public abstract JXTPortal.Entities.Jobs GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Jobs_CustomUpdateAllSiteJobCount 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateAllSiteJobCount' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateAllSiteJobCount()
		{
			 CustomUpdateAllSiteJobCount(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateAllSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateAllSiteJobCount(int start, int pageLength)
		{
			 CustomUpdateAllSiteJobCount(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateAllSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateAllSiteJobCount(TransactionManager transactionManager)
		{
			 CustomUpdateAllSiteJobCount(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateAllSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomUpdateAllSiteJobCount(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Jobs_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region Jobs_Update 
		
		/// <summary>
		///	This method wrap the 'Jobs_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			 Update(null, 0, int.MaxValue , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			 Update(null, start, pageLength , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region Jobs_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(System.Int32? jobId)
		{
			return GetByJobId(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(TransactionManager transactionManager, System.Int32? jobId)
		{
			return GetByJobId(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_GetByLastModifiedByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByLastModifiedByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetByLastModifiedByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedByAdvertiserUserId);
		
		#endregion
		
		#region Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(System.Int32? workTypeId, System.Int32? jobId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(null, 0, int.MaxValue , workTypeId, jobId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(int start, int pageLength, System.Int32? workTypeId, System.Int32? jobId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(null, start, pageLength , workTypeId, jobId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, expired, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(TransactionManager transactionManager, System.Int32? workTypeId, System.Int32? jobId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(transactionManager, 0, int.MaxValue , workTypeId, jobId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId, System.Int32? jobId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? expired, System.DateTime? expiryDate);
		
		#endregion
		
		#region Jobs_GetJobApplicationAndViewsDetail 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetJobApplicationAndViewsDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="duration"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobApplicationAndViewsDetail(System.Int32? siteId, System.DateTime? fromDate, System.Int32? duration)
		{
			return GetJobApplicationAndViewsDetail(null, 0, int.MaxValue , siteId, fromDate, duration);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetJobApplicationAndViewsDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="duration"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobApplicationAndViewsDetail(int start, int pageLength, System.Int32? siteId, System.DateTime? fromDate, System.Int32? duration)
		{
			return GetJobApplicationAndViewsDetail(null, start, pageLength , siteId, fromDate, duration);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetJobApplicationAndViewsDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="duration"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetJobApplicationAndViewsDetail(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? fromDate, System.Int32? duration)
		{
			return GetJobApplicationAndViewsDetail(transactionManager, 0, int.MaxValue , siteId, fromDate, duration);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetJobApplicationAndViewsDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="duration"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetJobApplicationAndViewsDetail(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? fromDate, System.Int32? duration);
		
		#endregion
		
		#region Jobs_CustomGetBySiteIdStatusIDs 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetBySiteIdStatusIDs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="statusIds"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIdStatusIDs(System.Int32? siteId, System.String statusIds, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return CustomGetBySiteIdStatusIDs(null, 0, int.MaxValue , siteId, statusIds, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetBySiteIdStatusIDs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="statusIds"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIdStatusIDs(int start, int pageLength, System.Int32? siteId, System.String statusIds, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return CustomGetBySiteIdStatusIDs(null, start, pageLength , siteId, statusIds, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetBySiteIdStatusIDs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="statusIds"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIdStatusIDs(TransactionManager transactionManager, System.Int32? siteId, System.String statusIds, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return CustomGetBySiteIdStatusIDs(transactionManager, 0, int.MaxValue , siteId, statusIds, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetBySiteIdStatusIDs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="statusIds"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteIdStatusIDs(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String statusIds, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Jobs_CustomArchiveXML 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomArchiveXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomArchiveXML(System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, System.String clientIpAddress, ref System.Int32? webServiceLogId)
		{
			 CustomArchiveXML(null, 0, int.MaxValue , advertiserId, advertiserUserName, xmlFeed, clientIpAddress, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomArchiveXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomArchiveXML(int start, int pageLength, System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, System.String clientIpAddress, ref System.Int32? webServiceLogId)
		{
			 CustomArchiveXML(null, start, pageLength , advertiserId, advertiserUserName, xmlFeed, clientIpAddress, ref webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomArchiveXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomArchiveXML(TransactionManager transactionManager, System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, System.String clientIpAddress, ref System.Int32? webServiceLogId)
		{
			 CustomArchiveXML(transactionManager, 0, int.MaxValue , advertiserId, advertiserUserName, xmlFeed, clientIpAddress, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomArchiveXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomArchiveXML(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, System.String clientIpAddress, ref System.Int32? webServiceLogId);
		
		#endregion
		
		#region Jobs_GetAdvertiserJobs 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetAdvertiserJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="type"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserJobs(System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String type, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetAdvertiserJobs(null, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, type, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetAdvertiserJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="type"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserJobs(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String type, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetAdvertiserJobs(null, start, pageLength , siteId, advertiserId, enteredByAdvertiserUserId, type, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetAdvertiserJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="type"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserJobs(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String type, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetAdvertiserJobs(transactionManager, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, type, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetAdvertiserJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="type"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAdvertiserJobs(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String type, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Jobs_JobsPurge 
		
		/// <summary>
		///	This method wrap the 'Jobs_JobsPurge' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobsPurge()
		{
			 JobsPurge(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobsPurge' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobsPurge(int start, int pageLength)
		{
			 JobsPurge(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_JobsPurge' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobsPurge(TransactionManager transactionManager)
		{
			 JobsPurge(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobsPurge' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void JobsPurge(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Jobs_GetStatistics 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetStatistics(System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetStatistics(null, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetStatistics(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetStatistics(null, start, pageLength , siteId, advertiserId, enteredByAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetStatistics(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetStatistics(transactionManager, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetStatistics(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId);
		
		#endregion
		
		#region Jobs_GetByExpiredAdvertiserIdExpiryDate 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredAdvertiserIdExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredAdvertiserIdExpiryDate(System.Int32? expired, System.Int32? advertiserId, System.DateTime? expiryDate)
		{
			return GetByExpiredAdvertiserIdExpiryDate(null, 0, int.MaxValue , expired, advertiserId, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredAdvertiserIdExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredAdvertiserIdExpiryDate(int start, int pageLength, System.Int32? expired, System.Int32? advertiserId, System.DateTime? expiryDate)
		{
			return GetByExpiredAdvertiserIdExpiryDate(null, start, pageLength , expired, advertiserId, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredAdvertiserIdExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredAdvertiserIdExpiryDate(TransactionManager transactionManager, System.Int32? expired, System.Int32? advertiserId, System.DateTime? expiryDate)
		{
			return GetByExpiredAdvertiserIdExpiryDate(transactionManager, 0, int.MaxValue , expired, advertiserId, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredAdvertiserIdExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByExpiredAdvertiserIdExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? expired, System.Int32? advertiserId, System.DateTime? expiryDate);
		
		#endregion
		
		#region Jobs_JobUnarchive 
		
		/// <summary>
		///	This method wrap the 'Jobs_JobUnarchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobUnarchive(System.Int32? jobId)
		{
			 JobUnarchive(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobUnarchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobUnarchive(int start, int pageLength, System.Int32? jobId)
		{
			 JobUnarchive(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_JobUnarchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobUnarchive(TransactionManager transactionManager, System.Int32? jobId)
		{
			 JobUnarchive(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobUnarchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void JobUnarchive(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_CustomGetJobByExternalJobId 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetJobByExternalJobId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalJobId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobByExternalJobId(System.Int32? siteId, System.Int32? advertiserId, System.String externalJobId)
		{
			return CustomGetJobByExternalJobId(null, 0, int.MaxValue , siteId, advertiserId, externalJobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetJobByExternalJobId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalJobId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobByExternalJobId(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.String externalJobId)
		{
			return CustomGetJobByExternalJobId(null, start, pageLength , siteId, advertiserId, externalJobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetJobByExternalJobId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalJobId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetJobByExternalJobId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.String externalJobId)
		{
			return CustomGetJobByExternalJobId(transactionManager, 0, int.MaxValue , siteId, advertiserId, externalJobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetJobByExternalJobId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalJobId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetJobByExternalJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.String externalJobId);
		
		#endregion
		
		#region Jobs_GetByJobTemplateId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobTemplateId(int start, int pageLength, System.Int32? jobTemplateId)
		{
			return GetByJobTemplateId(null, start, pageLength , jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobTemplateId);
		
		#endregion
		
		#region Jobs_Get_List 
		
		/// <summary>
		///	This method wrap the 'Jobs_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Get_List' stored procedure. 
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
		///	This method wrap the 'Jobs_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Jobs_GetByWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeId(System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeId(int start, int pageLength, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, start, pageLength , workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeId(TransactionManager transactionManager, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(transactionManager, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId);
		
		#endregion
		
		#region Jobs_GetByCurrencyId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCurrencyId(System.Int32? currencyId)
		{
			return GetByCurrencyId(null, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByCurrencyId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCurrencyId(TransactionManager transactionManager, System.Int32? currencyId)
		{
			return GetByCurrencyId(transactionManager, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCurrencyId(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#region Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Boolean? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, 0, int.MaxValue , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(int start, int pageLength, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Boolean? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, start, pageLength , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Boolean? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(transactionManager, 0, int.MaxValue , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Boolean? expired, System.DateTime? expiryDate);
		
		#endregion
		
		#region Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(System.Boolean? expired, System.DateTime? expiryDate, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryUpperBand, System.Decimal? salaryLowerBand, System.Int32? workTypeId)
		{
			return GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(null, 0, int.MaxValue , expired, expiryDate, advertiserId, currencyId, salaryUpperBand, salaryLowerBand, workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(int start, int pageLength, System.Boolean? expired, System.DateTime? expiryDate, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryUpperBand, System.Decimal? salaryLowerBand, System.Int32? workTypeId)
		{
			return GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(null, start, pageLength , expired, expiryDate, advertiserId, currencyId, salaryUpperBand, salaryLowerBand, workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(TransactionManager transactionManager, System.Boolean? expired, System.DateTime? expiryDate, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryUpperBand, System.Decimal? salaryLowerBand, System.Int32? workTypeId)
		{
			return GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(transactionManager, 0, int.MaxValue , expired, expiryDate, advertiserId, currencyId, salaryUpperBand, salaryLowerBand, workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Boolean? expired, System.DateTime? expiryDate, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryUpperBand, System.Decimal? salaryLowerBand, System.Int32? workTypeId);
		
		#endregion
		
		#region Jobs_CustomGetGeoAddressToUpdate 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetGeoAddressToUpdate' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetGeoAddressToUpdate()
		{
			return CustomGetGeoAddressToUpdate(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetGeoAddressToUpdate' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetGeoAddressToUpdate(int start, int pageLength)
		{
			return CustomGetGeoAddressToUpdate(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetGeoAddressToUpdate' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetGeoAddressToUpdate(TransactionManager transactionManager)
		{
			return CustomGetGeoAddressToUpdate(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomGetGeoAddressToUpdate' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetGeoAddressToUpdate(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Jobs_GetByExpiredBilledExpiryDate 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredBilledExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredBilledExpiryDate(System.Int32? expired, System.Boolean? billed, System.DateTime? expiryDate)
		{
			return GetByExpiredBilledExpiryDate(null, 0, int.MaxValue , expired, billed, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredBilledExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredBilledExpiryDate(int start, int pageLength, System.Int32? expired, System.Boolean? billed, System.DateTime? expiryDate)
		{
			return GetByExpiredBilledExpiryDate(null, start, pageLength , expired, billed, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredBilledExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredBilledExpiryDate(TransactionManager transactionManager, System.Int32? expired, System.Boolean? billed, System.DateTime? expiryDate)
		{
			return GetByExpiredBilledExpiryDate(transactionManager, 0, int.MaxValue , expired, billed, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredBilledExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByExpiredBilledExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? expired, System.Boolean? billed, System.DateTime? expiryDate);
		
		#endregion
		
		#region Jobs_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetPaged' stored procedure. 
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
		///	This method wrap the 'Jobs_GetPaged' stored procedure. 
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
		///	This method wrap the 'Jobs_GetPaged' stored procedure. 
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
		///	This method wrap the 'Jobs_GetPaged' stored procedure. 
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
		
		#region Jobs_GetCurrentJobStatistics 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetCurrentJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCurrentJobStatistics(System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String sortField, System.Boolean? sortAsc)
		{
			return GetCurrentJobStatistics(null, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, sortField, sortAsc);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetCurrentJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCurrentJobStatistics(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String sortField, System.Boolean? sortAsc)
		{
			return GetCurrentJobStatistics(null, start, pageLength , siteId, advertiserId, enteredByAdvertiserUserId, sortField, sortAsc);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetCurrentJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetCurrentJobStatistics(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String sortField, System.Boolean? sortAsc)
		{
			return GetCurrentJobStatistics(transactionManager, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, sortField, sortAsc);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetCurrentJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetCurrentJobStatistics(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.String sortField, System.Boolean? sortAsc);
		
		#endregion
		
		#region Jobs_CustomUpdateSiteJobCount 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateSiteJobCount(System.Int32? siteId)
		{
			 CustomUpdateSiteJobCount(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateSiteJobCount(int start, int pageLength, System.Int32? siteId)
		{
			 CustomUpdateSiteJobCount(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomUpdateSiteJobCount(TransactionManager transactionManager, System.Int32? siteId)
		{
			 CustomUpdateSiteJobCount(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateSiteJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomUpdateSiteJobCount(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Jobs_GetBySalaryTypeId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySalaryTypeId(System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySalaryTypeId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySalaryTypeId(TransactionManager transactionManager, System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(transactionManager, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region Jobs_JobArchive 
		
		/// <summary>
		///	This method wrap the 'Jobs_JobArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobArchive(System.Int32? jobId)
		{
			 JobArchive(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobArchive(int start, int pageLength, System.Int32? jobId)
		{
			 JobArchive(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_JobArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobArchive(TransactionManager transactionManager, System.Int32? jobId)
		{
			 JobArchive(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void JobArchive(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_GetByLastModifiedByAdminUserId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByLastModifiedByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedByAdminUserId(int start, int pageLength, System.Int32? lastModifiedByAdminUserId)
		{
			return GetByLastModifiedByAdminUserId(null, start, pageLength , lastModifiedByAdminUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByLastModifiedByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedByAdminUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedByAdminUserId);
		
		#endregion
		
		#region Jobs_JobX_SubmitQueue 
		
		/// <summary>
		///	This method wrap the 'Jobs_JobX_SubmitQueue' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobX_SubmitQueue(System.Int32? jobId)
		{
			 JobX_SubmitQueue(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobX_SubmitQueue' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobX_SubmitQueue(int start, int pageLength, System.Int32? jobId)
		{
			 JobX_SubmitQueue(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_JobX_SubmitQueue' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void JobX_SubmitQueue(TransactionManager transactionManager, System.Int32? jobId)
		{
			 JobX_SubmitQueue(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_JobX_SubmitQueue' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void JobX_SubmitQueue(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_GetHistoricalJobStatistics 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetHistoricalJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetHistoricalJobStatistics(System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.String sortField, System.Boolean? sortAsc)
		{
			return GetHistoricalJobStatistics(null, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, dateFrom, dateTo, sortField, sortAsc);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetHistoricalJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetHistoricalJobStatistics(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.String sortField, System.Boolean? sortAsc)
		{
			return GetHistoricalJobStatistics(null, start, pageLength , siteId, advertiserId, enteredByAdvertiserUserId, dateFrom, dateTo, sortField, sortAsc);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetHistoricalJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetHistoricalJobStatistics(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.String sortField, System.Boolean? sortAsc)
		{
			return GetHistoricalJobStatistics(transactionManager, 0, int.MaxValue , siteId, advertiserId, enteredByAdvertiserUserId, dateFrom, dateTo, sortField, sortAsc);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetHistoricalJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sortField"> A <c>System.String</c> instance.</param>
		/// <param name="sortAsc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetHistoricalJobStatistics(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.String sortField, System.Boolean? sortAsc);
		
		#endregion
		
		#region Jobs_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Jobs_GetByExpiredExpiryDate 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDate(System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByExpiredExpiryDate(null, 0, int.MaxValue , expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDate(int start, int pageLength, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByExpiredExpiryDate(null, start, pageLength , expired, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByExpiredExpiryDate(TransactionManager transactionManager, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByExpiredExpiryDate(transactionManager, 0, int.MaxValue , expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByExpiredExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? expired, System.DateTime? expiryDate);
		
		#endregion
		
		#region Jobs_CustomCalculateJobCount 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomCalculateJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="addJob"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomCalculateJobCount(System.Int32? siteId, System.Int32? jobId, System.Boolean? addJob)
		{
			 CustomCalculateJobCount(null, 0, int.MaxValue , siteId, jobId, addJob);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomCalculateJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="addJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomCalculateJobCount(int start, int pageLength, System.Int32? siteId, System.Int32? jobId, System.Boolean? addJob)
		{
			 CustomCalculateJobCount(null, start, pageLength , siteId, jobId, addJob);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomCalculateJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="addJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomCalculateJobCount(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobId, System.Boolean? addJob)
		{
			 CustomCalculateJobCount(transactionManager, 0, int.MaxValue , siteId, jobId, addJob);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomCalculateJobCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="addJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomCalculateJobCount(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobId, System.Boolean? addJob);
		
		#endregion
		
		#region Jobs_GetArchivedJobs 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetArchivedJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentOrderBy"> A <c>System.String</c> instance.</param>
		/// <param name="currentPageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentPageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetArchivedJobs(System.Int32? siteId, System.Int32? advertiserId, System.String currentOrderBy, System.Int32? currentPageIndex, System.Int32? currentPageSize)
		{
			return GetArchivedJobs(null, 0, int.MaxValue , siteId, advertiserId, currentOrderBy, currentPageIndex, currentPageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetArchivedJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentOrderBy"> A <c>System.String</c> instance.</param>
		/// <param name="currentPageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentPageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetArchivedJobs(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.String currentOrderBy, System.Int32? currentPageIndex, System.Int32? currentPageSize)
		{
			return GetArchivedJobs(null, start, pageLength , siteId, advertiserId, currentOrderBy, currentPageIndex, currentPageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetArchivedJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentOrderBy"> A <c>System.String</c> instance.</param>
		/// <param name="currentPageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentPageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetArchivedJobs(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.String currentOrderBy, System.Int32? currentPageIndex, System.Int32? currentPageSize)
		{
			return GetArchivedJobs(transactionManager, 0, int.MaxValue , siteId, advertiserId, currentOrderBy, currentPageIndex, currentPageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetArchivedJobs' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentOrderBy"> A <c>System.String</c> instance.</param>
		/// <param name="currentPageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currentPageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetArchivedJobs(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.String currentOrderBy, System.Int32? currentPageIndex, System.Int32? currentPageSize);
		
		#endregion
		
		#region Jobs_GetByJobItemTypeId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemTypeId(System.Int32? jobItemTypeId)
		{
			return GetByJobItemTypeId(null, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemTypeId(int start, int pageLength, System.Int32? jobItemTypeId)
		{
			return GetByJobItemTypeId(null, start, pageLength , jobItemTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemTypeId(TransactionManager transactionManager, System.Int32? jobItemTypeId)
		{
			return GetByJobItemTypeId(transactionManager, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobItemTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId);
		
		#endregion
		
		#region Jobs_CustomUpdateGeoLocations 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateGeoLocations' stored procedure. 
		/// </summary>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomUpdateGeoLocations(string xmlFeed)
		{
			return CustomUpdateGeoLocations(null, 0, int.MaxValue , xmlFeed);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateGeoLocations' stored procedure. 
		/// </summary>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomUpdateGeoLocations(int start, int pageLength, string xmlFeed)
		{
			return CustomUpdateGeoLocations(null, start, pageLength , xmlFeed);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateGeoLocations' stored procedure. 
		/// </summary>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomUpdateGeoLocations(TransactionManager transactionManager, string xmlFeed)
		{
			return CustomUpdateGeoLocations(transactionManager, 0, int.MaxValue , xmlFeed);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomUpdateGeoLocations' stored procedure. 
		/// </summary>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomUpdateGeoLocations(TransactionManager transactionManager, int start, int pageLength , string xmlFeed);
		
		#endregion
		
		#region Jobs_GetBySiteIdBilledAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdBilledAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserId(System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId)
		{
			return GetBySiteIdBilledAdvertiserId(null, 0, int.MaxValue , siteId, billed, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdBilledAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserId(int start, int pageLength, System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId)
		{
			return GetBySiteIdBilledAdvertiserId(null, start, pageLength , siteId, billed, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdBilledAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId)
		{
			return GetBySiteIdBilledAdvertiserId(transactionManager, 0, int.MaxValue , siteId, billed, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdBilledAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId);
		
		#endregion
		
		#region Jobs_Insert 
		
		/// <summary>
		///	This method wrap the 'Jobs_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId, ref System.Int32? jobId)
		{
			 Insert(null, 0, int.MaxValue , siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId, ref jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId, ref System.Int32? jobId)
		{
			 Insert(null, start, pageLength , siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId, ref jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId, ref System.Int32? jobId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId, ref jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId, ref System.Int32? jobId);
		
		#endregion
		
		#region Jobs_Delete 
		
		/// <summary>
		///	This method wrap the 'Jobs_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobId)
		{
			 Delete(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobId)
		{
			 Delete(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_GetByJobIdWithArchive 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobIdWithArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobIdWithArchive(System.Int32? jobId)
		{
			return GetByJobIdWithArchive(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobIdWithArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobIdWithArchive(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobIdWithArchive(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobIdWithArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobIdWithArchive(TransactionManager transactionManager, System.Int32? jobId)
		{
			return GetByJobIdWithArchive(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByJobIdWithArchive' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobIdWithArchive(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(System.Int32? siteId, System.Int32? expired, System.Boolean? billed, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(null, 0, int.MaxValue , siteId, expired, billed, advertiserId, enteredByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(int start, int pageLength, System.Int32? siteId, System.Int32? expired, System.Boolean? billed, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(null, start, pageLength , siteId, expired, billed, advertiserId, enteredByAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? expired, System.Boolean? billed, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId)
		{
			return GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(transactionManager, 0, int.MaxValue , siteId, expired, billed, advertiserId, enteredByAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? expired, System.Boolean? billed, System.Int32? advertiserId, System.Int32? enteredByAdvertiserUserId);
		
		#endregion
		
		#region Jobs_Find 
		
		/// <summary>
		///	This method wrap the 'Jobs_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus, jobExternalId, screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobName"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="webServiceProcessed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="refNo"> A <c>System.String</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemPrice"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showSalaryDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryText"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="applicationUrl"> A <c>System.String</c> instance.</param>
		/// <param name="uploadMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchFieldExtension"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="hashValue"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="requireLogonForExternalApplications"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLocationDetails"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicTransport"> A <c>System.String</c> instance.</param>
		/// <param name="address"> A <c>System.String</c> instance.</param>
		/// <param name="contactDetails"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="jobContactName"> A <c>System.String</c> instance.</param>
		/// <param name="qualificationsRecognised"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="residentOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="documentLink"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint1"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint2"> A <c>System.String</c> instance.</param>
		/// <param name="bulletPoint3"> A <c>System.String</c> instance.</param>
		/// <param name="hotJob"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="showSalaryRange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enteredByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLatitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="jobLongitude"> A <c>System.Double?</c> instance.</param>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExternalId"> A <c>System.String</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus, System.String jobExternalId, System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region Jobs_CustomPostXML 
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomPostXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="errorList"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="archiveMissingJobs"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomPostXML(System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, string errorList, System.String clientIpAddress, System.Boolean? archiveMissingJobs, ref System.Int32? webServiceLogId)
		{
			 CustomPostXML(null, 0, int.MaxValue , advertiserId, advertiserUserName, xmlFeed, errorList, clientIpAddress, archiveMissingJobs, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomPostXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="errorList"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="archiveMissingJobs"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomPostXML(int start, int pageLength, System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, string errorList, System.String clientIpAddress, System.Boolean? archiveMissingJobs, ref System.Int32? webServiceLogId)
		{
			 CustomPostXML(null, start, pageLength , advertiserId, advertiserUserName, xmlFeed, errorList, clientIpAddress, archiveMissingJobs, ref webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'Jobs_CustomPostXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="errorList"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="archiveMissingJobs"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomPostXML(TransactionManager transactionManager, System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, string errorList, System.String clientIpAddress, System.Boolean? archiveMissingJobs, ref System.Int32? webServiceLogId)
		{
			 CustomPostXML(transactionManager, 0, int.MaxValue , advertiserId, advertiserUserName, xmlFeed, errorList, clientIpAddress, archiveMissingJobs, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'Jobs_CustomPostXML' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserName"> A <c>System.String</c> instance.</param>
		/// <param name="xmlFeed"> A <c>string</c> instance.</param>
		/// <param name="errorList"> A <c>string</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="archiveMissingJobs"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomPostXML(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.String advertiserUserName, string xmlFeed, string errorList, System.String clientIpAddress, System.Boolean? archiveMissingJobs, ref System.Int32? webServiceLogId);
		
		#endregion
		
		#region Jobs_GetByScreeningQuestionsTemplateId 
		
		/// <summary>
		///	This method wrap the 'Jobs_GetByScreeningQuestionsTemplateId' stored procedure. 
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
		///	This method wrap the 'Jobs_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Jobs&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Jobs&gt;"/></returns>
		public static TList<Jobs> Fill(IDataReader reader, TList<Jobs> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Jobs c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Jobs")
					.Append("|").Append((System.Int32)reader[((int)JobsColumn.JobId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Jobs>(
					key.ToString(), // EntityTrackingKey
					"Jobs",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Jobs();
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
					c.JobId = (System.Int32)reader[((int)JobsColumn.JobId - 1)];
					c.SiteId = (System.Int32)reader[((int)JobsColumn.SiteId - 1)];
					c.WorkTypeId = (System.Int32)reader[((int)JobsColumn.WorkTypeId - 1)];
					c.JobName = (System.String)reader[((int)JobsColumn.JobName - 1)];
					c.Description = (System.String)reader[((int)JobsColumn.Description - 1)];
					c.FullDescription = (System.String)reader[((int)JobsColumn.FullDescription - 1)];
					c.WebServiceProcessed = (System.Boolean)reader[((int)JobsColumn.WebServiceProcessed - 1)];
					c.ApplicationEmailAddress = (System.String)reader[((int)JobsColumn.ApplicationEmailAddress - 1)];
					c.RefNo = (reader.IsDBNull(((int)JobsColumn.RefNo - 1)))?null:(System.String)reader[((int)JobsColumn.RefNo - 1)];
					c.Visible = (System.Boolean)reader[((int)JobsColumn.Visible - 1)];
					c.DatePosted = (System.DateTime)reader[((int)JobsColumn.DatePosted - 1)];
					c.ExpiryDate = (System.DateTime)reader[((int)JobsColumn.ExpiryDate - 1)];
					c.Expired = (reader.IsDBNull(((int)JobsColumn.Expired - 1)))?null:(System.Int32?)reader[((int)JobsColumn.Expired - 1)];
					c.JobItemPrice = (reader.IsDBNull(((int)JobsColumn.JobItemPrice - 1)))?null:(System.Decimal?)reader[((int)JobsColumn.JobItemPrice - 1)];
					c.Billed = (System.Boolean)reader[((int)JobsColumn.Billed - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobsColumn.LastModified - 1)];
					c.ShowSalaryDetails = (System.Boolean)reader[((int)JobsColumn.ShowSalaryDetails - 1)];
					c.SalaryText = (reader.IsDBNull(((int)JobsColumn.SalaryText - 1)))?null:(System.String)reader[((int)JobsColumn.SalaryText - 1)];
					c.AdvertiserId = (reader.IsDBNull(((int)JobsColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AdvertiserId - 1)];
					c.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)JobsColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.LastModifiedByAdvertiserUserId - 1)];
					c.LastModifiedByAdminUserId = (reader.IsDBNull(((int)JobsColumn.LastModifiedByAdminUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.LastModifiedByAdminUserId - 1)];
					c.JobItemTypeId = (reader.IsDBNull(((int)JobsColumn.JobItemTypeId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.JobItemTypeId - 1)];
					c.ApplicationMethod = (reader.IsDBNull(((int)JobsColumn.ApplicationMethod - 1)))?null:(System.Int32?)reader[((int)JobsColumn.ApplicationMethod - 1)];
					c.ApplicationUrl = (reader.IsDBNull(((int)JobsColumn.ApplicationUrl - 1)))?null:(System.String)reader[((int)JobsColumn.ApplicationUrl - 1)];
					c.UploadMethod = (reader.IsDBNull(((int)JobsColumn.UploadMethod - 1)))?null:(System.Int32?)reader[((int)JobsColumn.UploadMethod - 1)];
					c.Tags = (reader.IsDBNull(((int)JobsColumn.Tags - 1)))?null:(System.String)reader[((int)JobsColumn.Tags - 1)];
					c.JobTemplateId = (reader.IsDBNull(((int)JobsColumn.JobTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.JobTemplateId - 1)];
					c.SearchFieldExtension = (System.String)reader[((int)JobsColumn.SearchFieldExtension - 1)];
					c.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)JobsColumn.AdvertiserJobTemplateLogoId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AdvertiserJobTemplateLogoId - 1)];
					c.CompanyName = (reader.IsDBNull(((int)JobsColumn.CompanyName - 1)))?null:(System.String)reader[((int)JobsColumn.CompanyName - 1)];
					c.HashValue = (reader.IsDBNull(((int)JobsColumn.HashValue - 1)))?null:(System.Byte[])reader[((int)JobsColumn.HashValue - 1)];
					c.RequireLogonForExternalApplications = (System.Boolean)reader[((int)JobsColumn.RequireLogonForExternalApplications - 1)];
					c.ShowLocationDetails = (reader.IsDBNull(((int)JobsColumn.ShowLocationDetails - 1)))?null:(System.Boolean?)reader[((int)JobsColumn.ShowLocationDetails - 1)];
					c.PublicTransport = (reader.IsDBNull(((int)JobsColumn.PublicTransport - 1)))?null:(System.String)reader[((int)JobsColumn.PublicTransport - 1)];
					c.Address = (reader.IsDBNull(((int)JobsColumn.Address - 1)))?null:(System.String)reader[((int)JobsColumn.Address - 1)];
					c.ContactDetails = (System.String)reader[((int)JobsColumn.ContactDetails - 1)];
					c.JobContactPhone = (reader.IsDBNull(((int)JobsColumn.JobContactPhone - 1)))?null:(System.String)reader[((int)JobsColumn.JobContactPhone - 1)];
					c.JobContactName = (reader.IsDBNull(((int)JobsColumn.JobContactName - 1)))?null:(System.String)reader[((int)JobsColumn.JobContactName - 1)];
					c.QualificationsRecognised = (System.Boolean)reader[((int)JobsColumn.QualificationsRecognised - 1)];
					c.ResidentOnly = (System.Boolean)reader[((int)JobsColumn.ResidentOnly - 1)];
					c.DocumentLink = (reader.IsDBNull(((int)JobsColumn.DocumentLink - 1)))?null:(System.String)reader[((int)JobsColumn.DocumentLink - 1)];
					c.BulletPoint1 = (reader.IsDBNull(((int)JobsColumn.BulletPoint1 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint1 - 1)];
					c.BulletPoint2 = (reader.IsDBNull(((int)JobsColumn.BulletPoint2 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint2 - 1)];
					c.BulletPoint3 = (reader.IsDBNull(((int)JobsColumn.BulletPoint3 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint3 - 1)];
					c.HotJob = (System.Boolean)reader[((int)JobsColumn.HotJob - 1)];
					c.JobFriendlyName = (reader.IsDBNull(((int)JobsColumn.JobFriendlyName - 1)))?null:(System.String)reader[((int)JobsColumn.JobFriendlyName - 1)];
					c.SearchField = (reader.IsDBNull(((int)JobsColumn.SearchField - 1)))?null:(System.String)reader[((int)JobsColumn.SearchField - 1)];
					c.ShowSalaryRange = (System.Boolean)reader[((int)JobsColumn.ShowSalaryRange - 1)];
					c.SalaryLowerBand = (System.Decimal)reader[((int)JobsColumn.SalaryLowerBand - 1)];
					c.SalaryUpperBand = (System.Decimal)reader[((int)JobsColumn.SalaryUpperBand - 1)];
					c.CurrencyId = (System.Int32)reader[((int)JobsColumn.CurrencyId - 1)];
					c.SalaryTypeId = (System.Int32)reader[((int)JobsColumn.SalaryTypeId - 1)];
					c.EnteredByAdvertiserUserId = (reader.IsDBNull(((int)JobsColumn.EnteredByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.EnteredByAdvertiserUserId - 1)];
					c.JobLatitude = (reader.IsDBNull(((int)JobsColumn.JobLatitude - 1)))?null:(System.Double?)reader[((int)JobsColumn.JobLatitude - 1)];
					c.JobLongitude = (reader.IsDBNull(((int)JobsColumn.JobLongitude - 1)))?null:(System.Double?)reader[((int)JobsColumn.JobLongitude - 1)];
					c.AddressStatus = (reader.IsDBNull(((int)JobsColumn.AddressStatus - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AddressStatus - 1)];
					c.JobExternalId = (reader.IsDBNull(((int)JobsColumn.JobExternalId - 1)))?null:(System.String)reader[((int)JobsColumn.JobExternalId - 1)];
					c.ScreeningQuestionsTemplateId = (reader.IsDBNull(((int)JobsColumn.ScreeningQuestionsTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.ScreeningQuestionsTemplateId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Jobs"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Jobs"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Jobs entity)
		{
			if (!reader.Read()) return;
			
			entity.JobId = (System.Int32)reader[((int)JobsColumn.JobId - 1)];
			entity.SiteId = (System.Int32)reader[((int)JobsColumn.SiteId - 1)];
			entity.WorkTypeId = (System.Int32)reader[((int)JobsColumn.WorkTypeId - 1)];
			entity.JobName = (System.String)reader[((int)JobsColumn.JobName - 1)];
			entity.Description = (System.String)reader[((int)JobsColumn.Description - 1)];
			entity.FullDescription = (System.String)reader[((int)JobsColumn.FullDescription - 1)];
			entity.WebServiceProcessed = (System.Boolean)reader[((int)JobsColumn.WebServiceProcessed - 1)];
			entity.ApplicationEmailAddress = (System.String)reader[((int)JobsColumn.ApplicationEmailAddress - 1)];
			entity.RefNo = (reader.IsDBNull(((int)JobsColumn.RefNo - 1)))?null:(System.String)reader[((int)JobsColumn.RefNo - 1)];
			entity.Visible = (System.Boolean)reader[((int)JobsColumn.Visible - 1)];
			entity.DatePosted = (System.DateTime)reader[((int)JobsColumn.DatePosted - 1)];
			entity.ExpiryDate = (System.DateTime)reader[((int)JobsColumn.ExpiryDate - 1)];
			entity.Expired = (reader.IsDBNull(((int)JobsColumn.Expired - 1)))?null:(System.Int32?)reader[((int)JobsColumn.Expired - 1)];
			entity.JobItemPrice = (reader.IsDBNull(((int)JobsColumn.JobItemPrice - 1)))?null:(System.Decimal?)reader[((int)JobsColumn.JobItemPrice - 1)];
			entity.Billed = (System.Boolean)reader[((int)JobsColumn.Billed - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobsColumn.LastModified - 1)];
			entity.ShowSalaryDetails = (System.Boolean)reader[((int)JobsColumn.ShowSalaryDetails - 1)];
			entity.SalaryText = (reader.IsDBNull(((int)JobsColumn.SalaryText - 1)))?null:(System.String)reader[((int)JobsColumn.SalaryText - 1)];
			entity.AdvertiserId = (reader.IsDBNull(((int)JobsColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AdvertiserId - 1)];
			entity.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)JobsColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.LastModifiedByAdvertiserUserId - 1)];
			entity.LastModifiedByAdminUserId = (reader.IsDBNull(((int)JobsColumn.LastModifiedByAdminUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.LastModifiedByAdminUserId - 1)];
			entity.JobItemTypeId = (reader.IsDBNull(((int)JobsColumn.JobItemTypeId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.JobItemTypeId - 1)];
			entity.ApplicationMethod = (reader.IsDBNull(((int)JobsColumn.ApplicationMethod - 1)))?null:(System.Int32?)reader[((int)JobsColumn.ApplicationMethod - 1)];
			entity.ApplicationUrl = (reader.IsDBNull(((int)JobsColumn.ApplicationUrl - 1)))?null:(System.String)reader[((int)JobsColumn.ApplicationUrl - 1)];
			entity.UploadMethod = (reader.IsDBNull(((int)JobsColumn.UploadMethod - 1)))?null:(System.Int32?)reader[((int)JobsColumn.UploadMethod - 1)];
			entity.Tags = (reader.IsDBNull(((int)JobsColumn.Tags - 1)))?null:(System.String)reader[((int)JobsColumn.Tags - 1)];
			entity.JobTemplateId = (reader.IsDBNull(((int)JobsColumn.JobTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.JobTemplateId - 1)];
			entity.SearchFieldExtension = (System.String)reader[((int)JobsColumn.SearchFieldExtension - 1)];
			entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)JobsColumn.AdvertiserJobTemplateLogoId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AdvertiserJobTemplateLogoId - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)JobsColumn.CompanyName - 1)))?null:(System.String)reader[((int)JobsColumn.CompanyName - 1)];
			entity.HashValue = (reader.IsDBNull(((int)JobsColumn.HashValue - 1)))?null:(System.Byte[])reader[((int)JobsColumn.HashValue - 1)];
			entity.RequireLogonForExternalApplications = (System.Boolean)reader[((int)JobsColumn.RequireLogonForExternalApplications - 1)];
			entity.ShowLocationDetails = (reader.IsDBNull(((int)JobsColumn.ShowLocationDetails - 1)))?null:(System.Boolean?)reader[((int)JobsColumn.ShowLocationDetails - 1)];
			entity.PublicTransport = (reader.IsDBNull(((int)JobsColumn.PublicTransport - 1)))?null:(System.String)reader[((int)JobsColumn.PublicTransport - 1)];
			entity.Address = (reader.IsDBNull(((int)JobsColumn.Address - 1)))?null:(System.String)reader[((int)JobsColumn.Address - 1)];
			entity.ContactDetails = (System.String)reader[((int)JobsColumn.ContactDetails - 1)];
			entity.JobContactPhone = (reader.IsDBNull(((int)JobsColumn.JobContactPhone - 1)))?null:(System.String)reader[((int)JobsColumn.JobContactPhone - 1)];
			entity.JobContactName = (reader.IsDBNull(((int)JobsColumn.JobContactName - 1)))?null:(System.String)reader[((int)JobsColumn.JobContactName - 1)];
			entity.QualificationsRecognised = (System.Boolean)reader[((int)JobsColumn.QualificationsRecognised - 1)];
			entity.ResidentOnly = (System.Boolean)reader[((int)JobsColumn.ResidentOnly - 1)];
			entity.DocumentLink = (reader.IsDBNull(((int)JobsColumn.DocumentLink - 1)))?null:(System.String)reader[((int)JobsColumn.DocumentLink - 1)];
			entity.BulletPoint1 = (reader.IsDBNull(((int)JobsColumn.BulletPoint1 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint1 - 1)];
			entity.BulletPoint2 = (reader.IsDBNull(((int)JobsColumn.BulletPoint2 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint2 - 1)];
			entity.BulletPoint3 = (reader.IsDBNull(((int)JobsColumn.BulletPoint3 - 1)))?null:(System.String)reader[((int)JobsColumn.BulletPoint3 - 1)];
			entity.HotJob = (System.Boolean)reader[((int)JobsColumn.HotJob - 1)];
			entity.JobFriendlyName = (reader.IsDBNull(((int)JobsColumn.JobFriendlyName - 1)))?null:(System.String)reader[((int)JobsColumn.JobFriendlyName - 1)];
			entity.SearchField = (reader.IsDBNull(((int)JobsColumn.SearchField - 1)))?null:(System.String)reader[((int)JobsColumn.SearchField - 1)];
			entity.ShowSalaryRange = (System.Boolean)reader[((int)JobsColumn.ShowSalaryRange - 1)];
			entity.SalaryLowerBand = (System.Decimal)reader[((int)JobsColumn.SalaryLowerBand - 1)];
			entity.SalaryUpperBand = (System.Decimal)reader[((int)JobsColumn.SalaryUpperBand - 1)];
			entity.CurrencyId = (System.Int32)reader[((int)JobsColumn.CurrencyId - 1)];
			entity.SalaryTypeId = (System.Int32)reader[((int)JobsColumn.SalaryTypeId - 1)];
			entity.EnteredByAdvertiserUserId = (reader.IsDBNull(((int)JobsColumn.EnteredByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.EnteredByAdvertiserUserId - 1)];
			entity.JobLatitude = (reader.IsDBNull(((int)JobsColumn.JobLatitude - 1)))?null:(System.Double?)reader[((int)JobsColumn.JobLatitude - 1)];
			entity.JobLongitude = (reader.IsDBNull(((int)JobsColumn.JobLongitude - 1)))?null:(System.Double?)reader[((int)JobsColumn.JobLongitude - 1)];
			entity.AddressStatus = (reader.IsDBNull(((int)JobsColumn.AddressStatus - 1)))?null:(System.Int32?)reader[((int)JobsColumn.AddressStatus - 1)];
			entity.JobExternalId = (reader.IsDBNull(((int)JobsColumn.JobExternalId - 1)))?null:(System.String)reader[((int)JobsColumn.JobExternalId - 1)];
			entity.ScreeningQuestionsTemplateId = (reader.IsDBNull(((int)JobsColumn.ScreeningQuestionsTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsColumn.ScreeningQuestionsTemplateId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Jobs"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Jobs"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Jobs entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobId = (System.Int32)dataRow["JobID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.WorkTypeId = (System.Int32)dataRow["WorkTypeID"];
			entity.JobName = (System.String)dataRow["JobName"];
			entity.Description = (System.String)dataRow["Description"];
			entity.FullDescription = (System.String)dataRow["FullDescription"];
			entity.WebServiceProcessed = (System.Boolean)dataRow["WebServiceProcessed"];
			entity.ApplicationEmailAddress = (System.String)dataRow["ApplicationEmailAddress"];
			entity.RefNo = Convert.IsDBNull(dataRow["RefNo"]) ? null : (System.String)dataRow["RefNo"];
			entity.Visible = (System.Boolean)dataRow["Visible"];
			entity.DatePosted = (System.DateTime)dataRow["DatePosted"];
			entity.ExpiryDate = (System.DateTime)dataRow["ExpiryDate"];
			entity.Expired = Convert.IsDBNull(dataRow["Expired"]) ? null : (System.Int32?)dataRow["Expired"];
			entity.JobItemPrice = Convert.IsDBNull(dataRow["JobItemPrice"]) ? null : (System.Decimal?)dataRow["JobItemPrice"];
			entity.Billed = (System.Boolean)dataRow["Billed"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.ShowSalaryDetails = (System.Boolean)dataRow["ShowSalaryDetails"];
			entity.SalaryText = Convert.IsDBNull(dataRow["SalaryText"]) ? null : (System.String)dataRow["SalaryText"];
			entity.AdvertiserId = Convert.IsDBNull(dataRow["AdvertiserID"]) ? null : (System.Int32?)dataRow["AdvertiserID"];
			entity.LastModifiedByAdvertiserUserId = Convert.IsDBNull(dataRow["LastModifiedByAdvertiserUserId"]) ? null : (System.Int32?)dataRow["LastModifiedByAdvertiserUserId"];
			entity.LastModifiedByAdminUserId = Convert.IsDBNull(dataRow["LastModifiedByAdminUserId"]) ? null : (System.Int32?)dataRow["LastModifiedByAdminUserId"];
			entity.JobItemTypeId = Convert.IsDBNull(dataRow["JobItemTypeID"]) ? null : (System.Int32?)dataRow["JobItemTypeID"];
			entity.ApplicationMethod = Convert.IsDBNull(dataRow["ApplicationMethod"]) ? null : (System.Int32?)dataRow["ApplicationMethod"];
			entity.ApplicationUrl = Convert.IsDBNull(dataRow["ApplicationURL"]) ? null : (System.String)dataRow["ApplicationURL"];
			entity.UploadMethod = Convert.IsDBNull(dataRow["UploadMethod"]) ? null : (System.Int32?)dataRow["UploadMethod"];
			entity.Tags = Convert.IsDBNull(dataRow["Tags"]) ? null : (System.String)dataRow["Tags"];
			entity.JobTemplateId = Convert.IsDBNull(dataRow["JobTemplateID"]) ? null : (System.Int32?)dataRow["JobTemplateID"];
			entity.SearchFieldExtension = (System.String)dataRow["SearchFieldExtension"];
			entity.AdvertiserJobTemplateLogoId = Convert.IsDBNull(dataRow["AdvertiserJobTemplateLogoID"]) ? null : (System.Int32?)dataRow["AdvertiserJobTemplateLogoID"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.HashValue = Convert.IsDBNull(dataRow["HashValue"]) ? null : (System.Byte[])dataRow["HashValue"];
			entity.RequireLogonForExternalApplications = (System.Boolean)dataRow["RequireLogonForExternalApplications"];
			entity.ShowLocationDetails = Convert.IsDBNull(dataRow["ShowLocationDetails"]) ? null : (System.Boolean?)dataRow["ShowLocationDetails"];
			entity.PublicTransport = Convert.IsDBNull(dataRow["PublicTransport"]) ? null : (System.String)dataRow["PublicTransport"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.ContactDetails = (System.String)dataRow["ContactDetails"];
			entity.JobContactPhone = Convert.IsDBNull(dataRow["JobContactPhone"]) ? null : (System.String)dataRow["JobContactPhone"];
			entity.JobContactName = Convert.IsDBNull(dataRow["JobContactName"]) ? null : (System.String)dataRow["JobContactName"];
			entity.QualificationsRecognised = (System.Boolean)dataRow["QualificationsRecognised"];
			entity.ResidentOnly = (System.Boolean)dataRow["ResidentOnly"];
			entity.DocumentLink = Convert.IsDBNull(dataRow["DocumentLink"]) ? null : (System.String)dataRow["DocumentLink"];
			entity.BulletPoint1 = Convert.IsDBNull(dataRow["BulletPoint1"]) ? null : (System.String)dataRow["BulletPoint1"];
			entity.BulletPoint2 = Convert.IsDBNull(dataRow["BulletPoint2"]) ? null : (System.String)dataRow["BulletPoint2"];
			entity.BulletPoint3 = Convert.IsDBNull(dataRow["BulletPoint3"]) ? null : (System.String)dataRow["BulletPoint3"];
			entity.HotJob = (System.Boolean)dataRow["HotJob"];
			entity.JobFriendlyName = Convert.IsDBNull(dataRow["JobFriendlyName"]) ? null : (System.String)dataRow["JobFriendlyName"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.ShowSalaryRange = (System.Boolean)dataRow["ShowSalaryRange"];
			entity.SalaryLowerBand = (System.Decimal)dataRow["SalaryLowerBand"];
			entity.SalaryUpperBand = (System.Decimal)dataRow["SalaryUpperBand"];
			entity.CurrencyId = (System.Int32)dataRow["CurrencyID"];
			entity.SalaryTypeId = (System.Int32)dataRow["SalaryTypeID"];
			entity.EnteredByAdvertiserUserId = Convert.IsDBNull(dataRow["EnteredByAdvertiserUserID"]) ? null : (System.Int32?)dataRow["EnteredByAdvertiserUserID"];
			entity.JobLatitude = Convert.IsDBNull(dataRow["JobLatitude"]) ? null : (System.Double?)dataRow["JobLatitude"];
			entity.JobLongitude = Convert.IsDBNull(dataRow["JobLongitude"]) ? null : (System.Double?)dataRow["JobLongitude"];
			entity.AddressStatus = Convert.IsDBNull(dataRow["AddressStatus"]) ? null : (System.Int32?)dataRow["AddressStatus"];
			entity.JobExternalId = Convert.IsDBNull(dataRow["JobExternalId"]) ? null : (System.String)dataRow["JobExternalId"];
			entity.ScreeningQuestionsTemplateId = Convert.IsDBNull(dataRow["ScreeningQuestionsTemplateId"]) ? null : (System.Int32?)dataRow["ScreeningQuestionsTemplateId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Jobs"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Jobs Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Jobs entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserIdSource	
			if (CanDeepLoad(entity, "Advertisers|AdvertiserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AdvertiserId ?? (int)0);
				Advertisers tmpEntity = EntityManager.LocateEntity<Advertisers>(EntityLocator.ConstructKeyFromPkItems(typeof(Advertisers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserIdSource = tmpEntity;
				else
					entity.AdvertiserIdSource = DataRepository.AdvertisersProvider.GetByAdvertiserId(transactionManager, (entity.AdvertiserId ?? (int)0));		
				
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

			#region CurrencyIdSource	
			if (CanDeepLoad(entity, "Currencies|CurrencyIdSource", deepLoadType, innerList) 
				&& entity.CurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CurrencyId;
				Currencies tmpEntity = EntityManager.LocateEntity<Currencies>(EntityLocator.ConstructKeyFromPkItems(typeof(Currencies), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyIdSource = tmpEntity;
				else
					entity.CurrencyIdSource = DataRepository.CurrenciesProvider.GetByCurrencyId(transactionManager, entity.CurrencyId);		
				
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

			#region JobTemplateIdSource	
			if (CanDeepLoad(entity, "JobTemplates|JobTemplateIdSource", deepLoadType, innerList) 
				&& entity.JobTemplateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobTemplateId ?? (int)0);
				JobTemplates tmpEntity = EntityManager.LocateEntity<JobTemplates>(EntityLocator.ConstructKeyFromPkItems(typeof(JobTemplates), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobTemplateIdSource = tmpEntity;
				else
					entity.JobTemplateIdSource = DataRepository.JobTemplatesProvider.GetByJobTemplateId(transactionManager, (entity.JobTemplateId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobTemplateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobTemplateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobTemplatesProvider.DeepLoad(transactionManager, entity.JobTemplateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobTemplateIdSource

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

			#region LastModifiedByAdminUserIdSource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedByAdminUserIdSource", deepLoadType, innerList) 
				&& entity.LastModifiedByAdminUserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastModifiedByAdminUserId ?? (int)0);
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedByAdminUserIdSource = tmpEntity;
				else
					entity.LastModifiedByAdminUserIdSource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, (entity.LastModifiedByAdminUserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedByAdminUserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedByAdminUserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.LastModifiedByAdminUserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedByAdminUserIdSource

			#region SalaryTypeIdSource	
			if (CanDeepLoad(entity, "SalaryType|SalaryTypeIdSource", deepLoadType, innerList) 
				&& entity.SalaryTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SalaryTypeId;
				SalaryType tmpEntity = EntityManager.LocateEntity<SalaryType>(EntityLocator.ConstructKeyFromPkItems(typeof(SalaryType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalaryTypeIdSource = tmpEntity;
				else
					entity.SalaryTypeIdSource = DataRepository.SalaryTypeProvider.GetBySalaryTypeId(transactionManager, entity.SalaryTypeId);		
				
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

			#region ScreeningQuestionsTemplateIdSource	
			if (CanDeepLoad(entity, "ScreeningQuestionsTemplates|ScreeningQuestionsTemplateIdSource", deepLoadType, innerList) 
				&& entity.ScreeningQuestionsTemplateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ScreeningQuestionsTemplateId ?? (int)0);
				ScreeningQuestionsTemplates tmpEntity = EntityManager.LocateEntity<ScreeningQuestionsTemplates>(EntityLocator.ConstructKeyFromPkItems(typeof(ScreeningQuestionsTemplates), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ScreeningQuestionsTemplateIdSource = tmpEntity;
				else
					entity.ScreeningQuestionsTemplateIdSource = DataRepository.ScreeningQuestionsTemplatesProvider.GetByScreeningQuestionsTemplateId(transactionManager, (entity.ScreeningQuestionsTemplateId ?? (int)0));		
				
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

			#region WorkTypeIdSource	
			if (CanDeepLoad(entity, "WorkType|WorkTypeIdSource", deepLoadType, innerList) 
				&& entity.WorkTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.WorkTypeId;
				WorkType tmpEntity = EntityManager.LocateEntity<WorkType>(EntityLocator.ConstructKeyFromPkItems(typeof(WorkType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WorkTypeIdSource = tmpEntity;
				else
					entity.WorkTypeIdSource = DataRepository.WorkTypeProvider.GetByWorkTypeId(transactionManager, entity.WorkTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WorkTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.WorkTypeProvider.DeepLoad(transactionManager, entity.WorkTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WorkTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByJobId methods when available
			
			#region InvoiceItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<InvoiceItem>|InvoiceItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceItemCollection = DataRepository.InvoiceItemProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.InvoiceItemCollection.Count > 0)
				{
					deepHandles.Add("InvoiceItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<InvoiceItem>) DataRepository.InvoiceItemProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceItemCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobApplicationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplication>|JobApplicationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationCollection = DataRepository.JobApplicationProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.JobApplicationCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplication>) DataRepository.JobApplicationProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsSavedCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsSaved>|JobsSavedCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsSavedCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsSavedCollection = DataRepository.JobsSavedProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.JobsSavedCollection.Count > 0)
				{
					deepHandles.Add("JobsSavedCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsSaved>) DataRepository.JobsSavedProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsSavedCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobViewsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobViews>|JobViewsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobViewsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobViewsCollection = DataRepository.JobViewsProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.JobViewsCollection.Count > 0)
				{
					deepHandles.Add("JobViewsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobViews>) DataRepository.JobViewsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobViewsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobRoles>|JobRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobRolesCollection = DataRepository.JobRolesProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.JobRolesCollection.Count > 0)
				{
					deepHandles.Add("JobRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobRoles>) DataRepository.JobRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobRolesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobAreaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobArea>|JobAreaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobAreaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobAreaCollection = DataRepository.JobAreaProvider.GetByJobId(transactionManager, entity.JobId);

				if (deep && entity.JobAreaCollection.Count > 0)
				{
					deepHandles.Add("JobAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobArea>) DataRepository.JobAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.JobAreaCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobScreeningQuestionsCollection = DataRepository.JobScreeningQuestionsProvider.GetByJobId(transactionManager, entity.JobId);

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Jobs object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Jobs instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Jobs Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Jobs entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CurrencyIdSource
			if (CanDeepSave(entity, "Currencies|CurrencyIdSource", deepSaveType, innerList) 
				&& entity.CurrencyIdSource != null)
			{
				DataRepository.CurrenciesProvider.Save(transactionManager, entity.CurrencyIdSource);
				entity.CurrencyId = entity.CurrencyIdSource.CurrencyId;
			}
			#endregion 
			
			#region JobTemplateIdSource
			if (CanDeepSave(entity, "JobTemplates|JobTemplateIdSource", deepSaveType, innerList) 
				&& entity.JobTemplateIdSource != null)
			{
				DataRepository.JobTemplatesProvider.Save(transactionManager, entity.JobTemplateIdSource);
				entity.JobTemplateId = entity.JobTemplateIdSource.JobTemplateId;
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
			
			#region LastModifiedByAdminUserIdSource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedByAdminUserIdSource", deepSaveType, innerList) 
				&& entity.LastModifiedByAdminUserIdSource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedByAdminUserIdSource);
				entity.LastModifiedByAdminUserId = entity.LastModifiedByAdminUserIdSource.AdminUserId;
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
			
			#region ScreeningQuestionsTemplateIdSource
			if (CanDeepSave(entity, "ScreeningQuestionsTemplates|ScreeningQuestionsTemplateIdSource", deepSaveType, innerList) 
				&& entity.ScreeningQuestionsTemplateIdSource != null)
			{
				DataRepository.ScreeningQuestionsTemplatesProvider.Save(transactionManager, entity.ScreeningQuestionsTemplateIdSource);
				entity.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
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
			
			#region WorkTypeIdSource
			if (CanDeepSave(entity, "WorkType|WorkTypeIdSource", deepSaveType, innerList) 
				&& entity.WorkTypeIdSource != null)
			{
				DataRepository.WorkTypeProvider.Save(transactionManager, entity.WorkTypeIdSource);
				entity.WorkTypeId = entity.WorkTypeIdSource.WorkTypeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<InvoiceItem>
				if (CanDeepSave(entity.InvoiceItemCollection, "List<InvoiceItem>|InvoiceItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(InvoiceItem child in entity.InvoiceItemCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.InvoiceItemCollection.Count > 0 || entity.InvoiceItemCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceItemProvider.Save(transactionManager, entity.InvoiceItemCollection);
						
						deepHandles.Add("InvoiceItemCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< InvoiceItem >) DataRepository.InvoiceItemProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceItemCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobApplication>
				if (CanDeepSave(entity.JobApplicationCollection, "List<JobApplication>|JobApplicationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplication child in entity.JobApplicationCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.JobApplicationCollection.Count > 0 || entity.JobApplicationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationProvider.Save(transactionManager, entity.JobApplicationCollection);
						
						deepHandles.Add("JobApplicationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplication >) DataRepository.JobApplicationProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobsSaved>
				if (CanDeepSave(entity.JobsSavedCollection, "List<JobsSaved>|JobsSavedCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsSaved child in entity.JobsSavedCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.JobsSavedCollection.Count > 0 || entity.JobsSavedCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsSavedProvider.Save(transactionManager, entity.JobsSavedCollection);
						
						deepHandles.Add("JobsSavedCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsSaved >) DataRepository.JobsSavedProvider.DeepSave,
							new object[] { transactionManager, entity.JobsSavedCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobViews>
				if (CanDeepSave(entity.JobViewsCollection, "List<JobViews>|JobViewsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobViews child in entity.JobViewsCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.JobViewsCollection.Count > 0 || entity.JobViewsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobViewsProvider.Save(transactionManager, entity.JobViewsCollection);
						
						deepHandles.Add("JobViewsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobViews >) DataRepository.JobViewsProvider.DeepSave,
							new object[] { transactionManager, entity.JobViewsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobRoles>
				if (CanDeepSave(entity.JobRolesCollection, "List<JobRoles>|JobRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobRoles child in entity.JobRolesCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.JobRolesCollection.Count > 0 || entity.JobRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobRolesProvider.Save(transactionManager, entity.JobRolesCollection);
						
						deepHandles.Add("JobRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobRoles >) DataRepository.JobRolesProvider.DeepSave,
							new object[] { transactionManager, entity.JobRolesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobArea>
				if (CanDeepSave(entity.JobAreaCollection, "List<JobArea>|JobAreaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobArea child in entity.JobAreaCollection)
					{
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
						}

					}

					if (entity.JobAreaCollection.Count > 0 || entity.JobAreaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobAreaProvider.Save(transactionManager, entity.JobAreaCollection);
						
						deepHandles.Add("JobAreaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobArea >) DataRepository.JobAreaProvider.DeepSave,
							new object[] { transactionManager, entity.JobAreaCollection, deepSaveType, childTypes, innerList }
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
						if(child.JobIdSource != null)
						{
							child.JobId = child.JobIdSource.JobId;
						}
						else
						{
							child.JobId = entity.JobId;
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
	
	#region JobsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Jobs</c>
	///</summary>
	public enum JobsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>Currencies</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currencies))]
		Currencies,
			
		///<summary>
		/// Composite Property for <c>JobTemplates</c> at JobTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(JobTemplates))]
		JobTemplates,
			
		///<summary>
		/// Composite Property for <c>AdvertiserUsers</c> at LastModifiedByAdvertiserUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserUsers))]
		AdvertiserUsers,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedByAdminUserIdSource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>SalaryType</c> at SalaryTypeIdSource
		///</summary>
		[ChildEntityType(typeof(SalaryType))]
		SalaryType,
			
		///<summary>
		/// Composite Property for <c>ScreeningQuestionsTemplates</c> at ScreeningQuestionsTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(ScreeningQuestionsTemplates))]
		ScreeningQuestionsTemplates,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
			
		///<summary>
		/// Composite Property for <c>WorkType</c> at WorkTypeIdSource
		///</summary>
		[ChildEntityType(typeof(WorkType))]
		WorkType,
	
		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for InvoiceItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceItem>))]
		InvoiceItemCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobApplicationCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplication>))]
		JobApplicationCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobsSavedCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsSaved>))]
		JobsSavedCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobViewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobViews>))]
		JobViewsCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobRoles>))]
		JobRolesCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobArea>))]
		JobAreaCollection,

		///<summary>
		/// Collection of <c>Jobs</c> as OneToMany for JobScreeningQuestionsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobScreeningQuestions>))]
		JobScreeningQuestionsCollection,
	}
	
	#endregion JobsChildEntityTypes
	
	#region JobsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsFilterBuilder : SqlFilterBuilder<JobsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsFilterBuilder class.
		/// </summary>
		public JobsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsFilterBuilder
	
	#region JobsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsParameterBuilder : ParameterizedSqlFilterBuilder<JobsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsParameterBuilder class.
		/// </summary>
		public JobsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsParameterBuilder
	
	#region JobsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobsSortBuilder : SqlSortBuilder<JobsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSqlSortBuilder class.
		/// </summary>
		public JobsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobsSortBuilder
	
} // end namespace
