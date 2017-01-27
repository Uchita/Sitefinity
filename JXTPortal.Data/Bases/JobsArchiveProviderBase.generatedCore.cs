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
	/// This class is the base class for any <see cref="JobsArchiveProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobsArchiveProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobsArchive, JXTPortal.Entities.JobsArchiveKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobsArchiveKey key)
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
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		FK__JobsArchi__Adver__015F0FBB Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByAdvertiserId(System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		FK__JobsArchi__Adver__015F0FBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		FK__JobsArchi__Adver__015F0FBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		fkJobsArchiAdver015f0Fbb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		fkJobsArchiAdver015f0Fbb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Adver__015F0FBB key.
		///		FK__JobsArchi__Adver__015F0FBB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		FK__JobsArchi__Curre__473D8CE8 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByCurrencyId(System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		FK__JobsArchi__Curre__473D8CE8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		FK__JobsArchi__Curre__473D8CE8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		fkJobsArchiCurre473d8Ce8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		fkJobsArchiCurre473d8Ce8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Curre__473D8CE8 key.
		///		FK__JobsArchi__Curre__473D8CE8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		FK__JobsArchi__JobTe__052FA09F Description: 
		/// </summary>
		/// <param name="_jobTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByJobTemplateId(System.Int32? _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(_jobTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		FK__JobsArchi__JobTe__052FA09F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		FK__JobsArchi__JobTe__052FA09F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		fkJobsArchiJobTe052Fa09f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByJobTemplateId(System.Int32? _jobTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		fkJobsArchiJobTe052Fa09f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByJobTemplateId(System.Int32? _jobTemplateId, int start, int pageLength,out int count)
		{
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__JobTe__052FA09F key.
		///		FK__JobsArchi__JobTe__052FA09F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? _jobTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		FK__JobsArchi__LastM__025333F4 Description: 
		/// </summary>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(_lastModifiedByAdvertiserUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		FK__JobsArchi__LastM__025333F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		FK__JobsArchi__LastM__025333F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedByAdvertiserUserId(transactionManager, _lastModifiedByAdvertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		fkJobsArchiLastm025333f4 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		fkJobsArchiLastm025333f4 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength,out int count)
		{
			return GetByLastModifiedByAdvertiserUserId(null, _lastModifiedByAdvertiserUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__025333F4 key.
		///		FK__JobsArchi__LastM__025333F4 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdvertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdvertiserUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		FK__JobsArchi__LastM__0347582D Description: 
		/// </summary>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(_lastModifiedByAdminUserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		FK__JobsArchi__LastM__0347582D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(transactionManager, _lastModifiedByAdminUserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		FK__JobsArchi__LastM__0347582D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedByAdminUserId(transactionManager, _lastModifiedByAdminUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		fkJobsArchiLastm0347582d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedByAdminUserId(null, _lastModifiedByAdminUserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		fkJobsArchiLastm0347582d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByLastModifiedByAdminUserId(System.Int32? _lastModifiedByAdminUserId, int start, int pageLength,out int count)
		{
			return GetByLastModifiedByAdminUserId(null, _lastModifiedByAdminUserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__LastM__0347582D key.
		///		FK__JobsArchi__LastM__0347582D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedByAdminUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByLastModifiedByAdminUserId(TransactionManager transactionManager, System.Int32? _lastModifiedByAdminUserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		FK__JobsArchi__Salar__4831B121 Description: 
		/// </summary>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySalaryTypeId(System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(_salaryTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		FK__JobsArchi__Salar__4831B121 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		FK__JobsArchi__Salar__4831B121 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalaryTypeId(transactionManager, _salaryTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		fkJobsArchiSalar4831b121 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		fkJobsArchiSalar4831b121 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySalaryTypeId(System.Int32 _salaryTypeId, int start, int pageLength,out int count)
		{
			return GetBySalaryTypeId(null, _salaryTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__Salar__4831B121 key.
		///		FK__JobsArchi__Salar__4831B121 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetBySalaryTypeId(TransactionManager transactionManager, System.Int32 _salaryTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		FK__JobsArchi__SiteI__79BDEDF3 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		FK__JobsArchi__SiteI__79BDEDF3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		FK__JobsArchi__SiteI__79BDEDF3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		fkJobsArchiSitei79Bdedf3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		fkJobsArchiSitei79Bdedf3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__SiteI__79BDEDF3 key.
		///		FK__JobsArchi__SiteI__79BDEDF3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		FK__JobsArchi__WorkT__7AB2122C Description: 
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByWorkTypeId(System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(_workTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		FK__JobsArchi__WorkT__7AB2122C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		/// <remarks></remarks>
		public TList<JobsArchive> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		FK__JobsArchi__WorkT__7AB2122C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		fkJobsArchiWorkt7Ab2122c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWorkTypeId(null, _workTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		fkJobsArchiWorkt7Ab2122c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public TList<JobsArchive> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength,out int count)
		{
			return GetByWorkTypeId(null, _workTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobsArchi__WorkT__7AB2122C key.
		///		FK__JobsArchi__WorkT__7AB2122C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobsArchive objects.</returns>
		public abstract TList<JobsArchive> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobsArchive Get(TransactionManager transactionManager, JXTPortal.Entities.JobsArchiveKey key, int start, int pageLength)
		{
			return GetByJobId(transactionManager, key.JobId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="_addressStatus"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAddressStatus(System.Int32? _addressStatus)
		{
			int count = -1;
			return GetByAddressStatus(null,_addressStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="_addressStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAddressStatus(System.Int32? _addressStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressStatus(null, _addressStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressStatus"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAddressStatus(TransactionManager transactionManager, System.Int32? _addressStatus)
		{
			int count = -1;
			return GetByAddressStatus(transactionManager, _addressStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAddressStatus(TransactionManager transactionManager, System.Int32? _addressStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressStatus(transactionManager, _addressStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="_addressStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAddressStatus(System.Int32? _addressStatus, int start, int pageLength, out int count)
		{
			return GetByAddressStatus(null, _addressStatus, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_AddressSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public abstract TList<JobsArchive> GetByAddressStatus(TransactionManager transactionManager, System.Int32? _addressStatus, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null,_advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate)
		{
			int count = -1;
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(transactionManager, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired, _expiryDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(transactionManager, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired, _expiryDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, _advertiserId, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired, _expiryDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_Search index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_currencyId"></param>
		/// <param name="_salaryTypeId"></param>
		/// <param name="_salaryLowerBand"></param>
		/// <param name="_salaryUpperBand"></param>
		/// <param name="_workTypeId"></param>
		/// <param name="_expired"></param>
		/// <param name="_expiryDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public abstract TList<JobsArchive> GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, System.Int32? _advertiserId, System.Int32 _currencyId, System.Int32 _salaryTypeId, System.Decimal _salaryLowerBand, System.Decimal _salaryUpperBand, System.Int32 _workTypeId, System.Int32? _expired, System.DateTime _expiryDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(null,_siteId, _billed, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(null, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(transactionManager, _siteId, _billed, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserId(transactionManager, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserId(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength, out int count)
		{
			return GetBySiteIdBilledAdvertiserId(null, _siteId, _billed, _advertiserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public abstract TList<JobsArchive> GetBySiteIdBilledAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserIdDatePosted(null,_siteId, _billed, _advertiserId, _datePosted, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserIdDatePosted(null, _siteId, _billed, _advertiserId, _datePosted, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserIdDatePosted(transactionManager, _siteId, _billed, _advertiserId, _datePosted, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdBilledAdvertiserIdDatePosted(transactionManager, _siteId, _billed, _advertiserId, _datePosted, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted, int start, int pageLength, out int count)
		{
			return GetBySiteIdBilledAdvertiserIdDatePosted(null, _siteId, _billed, _advertiserId, _datePosted, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobsArchive_SiteID_Billed_AdvertiserID_DatePosted index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_billed"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="_datePosted"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobsArchive&gt;"/> class.</returns>
		public abstract TList<JobsArchive> GetBySiteIdBilledAdvertiserIdDatePosted(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _billed, System.Int32? _advertiserId, System.DateTime _datePosted, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public JXTPortal.Entities.JobsArchive GetByJobId(System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(null,_jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public JXTPortal.Entities.JobsArchive GetByJobId(System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public JXTPortal.Entities.JobsArchive GetByJobId(TransactionManager transactionManager, System.Int32 _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public JXTPortal.Entities.JobsArchive GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public JXTPortal.Entities.JobsArchive GetByJobId(System.Int32 _jobId, int start, int pageLength, out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobsArchive__78C9C9BA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobsArchive"/> class.</returns>
		public abstract JXTPortal.Entities.JobsArchive GetByJobId(TransactionManager transactionManager, System.Int32 _jobId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobsArchive_GetBySalaryTypeId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySalaryTypeId(System.Int32? salaryTypeId)
		{
			return GetBySalaryTypeId(null, 0, int.MaxValue , salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySalaryTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySalaryTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySalaryTypeId' stored procedure. 
		/// </summary>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySalaryTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? salaryTypeId);
		
		#endregion
		
		#region JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserIdDatePosted(System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId, System.DateTime? datePosted)
		{
			return GetBySiteIdBilledAdvertiserIdDatePosted(null, 0, int.MaxValue , siteId, billed, advertiserId, datePosted);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserIdDatePosted(int start, int pageLength, System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId, System.DateTime? datePosted)
		{
			return GetBySiteIdBilledAdvertiserIdDatePosted(null, start, pageLength , siteId, billed, advertiserId, datePosted);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdBilledAdvertiserIdDatePosted(TransactionManager transactionManager, System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId, System.DateTime? datePosted)
		{
			return GetBySiteIdBilledAdvertiserIdDatePosted(transactionManager, 0, int.MaxValue , siteId, billed, advertiserId, datePosted);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserIdDatePosted' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="billed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="datePosted"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdBilledAdvertiserIdDatePosted(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Boolean? billed, System.Int32? advertiserId, System.DateTime? datePosted);
		
		#endregion
		
		#region JobsArchive_Update 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobId"> A <c>System.Int32?</c> instance.</param>
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
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobId, System.Int32? originalJobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Update(null, 0, int.MaxValue , jobId, originalJobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobId"> A <c>System.Int32?</c> instance.</param>
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobId, System.Int32? originalJobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Update(null, start, pageLength , jobId, originalJobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobId"> A <c>System.Int32?</c> instance.</param>
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
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobId, System.Int32? originalJobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Update(transactionManager, 0, int.MaxValue , jobId, originalJobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Update' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobId"> A <c>System.Int32?</c> instance.</param>
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? originalJobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus);
		
		#endregion
		
		#region JobsArchive_Find 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Find' stored procedure. 
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
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Find(System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Find(null, 0, int.MaxValue , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Find' stored procedure. 
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Find(null, start, pageLength , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_Find' stored procedure. 
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
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Find' stored procedure. 
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus);
		
		#endregion
		
		#region JobsArchive_GetByAddressStatus 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAddressStatus' stored procedure. 
		/// </summary>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAddressStatus(int start, int pageLength, System.Int32? addressStatus)
		{
			return GetByAddressStatus(null, start, pageLength , addressStatus);
		}

		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAddressStatus' stored procedure. 
		/// </summary>
		/// <param name="addressStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAddressStatus(TransactionManager transactionManager, int start, int pageLength , System.Int32? addressStatus);
		
		#endregion
		
		#region JobsArchive_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(System.Int32? jobId)
		{
			return GetByJobId(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByJobId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByJobId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobsArchive_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Get_List' stored procedure. 
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
		///	This method wrap the 'JobsArchive_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobsArchive_GetByProfessionId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByProfessionId(System.Int32? professionId)
		{
			 GetByProfessionId(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByProfessionId(int start, int pageLength, System.Int32? professionId)
		{
			 GetByProfessionId(null, start, pageLength , professionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByProfessionId(TransactionManager transactionManager, System.Int32? professionId)
		{
			 GetByProfessionId(transactionManager, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetByProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId);
		
		#endregion
		
		
		#region JobsArchive_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetPaged' stored procedure. 
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
		
		#region JobsArchive_Delete 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobId)
		{
			 Delete(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Delete' stored procedure. 
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
		///	This method wrap the 'JobsArchive_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobsArchive_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByLocationId(System.Int32? locationId)
		{
			 GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByLocationId(int start, int pageLength, System.Int32? locationId)
		{
			 GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByLocationId(TransactionManager transactionManager, System.Int32? locationId)
		{
			 GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region JobsArchive_GetBySiteIdBilledAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySiteIdBilledAdvertiserId' stored procedure. 
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
		
		#region JobsArchive_Insert 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Insert' stored procedure. 
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
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Insert(null, 0, int.MaxValue , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Insert' stored procedure. 
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Insert(null, start, pageLength , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_Insert' stored procedure. 
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
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobId, siteId, workTypeId, jobName, description, fullDescription, webServiceProcessed, applicationEmailAddress, refNo, visible, datePosted, expiryDate, expired, jobItemPrice, billed, lastModified, showSalaryDetails, salaryText, advertiserId, lastModifiedByAdvertiserUserId, lastModifiedByAdminUserId, jobItemTypeId, applicationMethod, applicationUrl, uploadMethod, tags, jobTemplateId, searchFieldExtension, advertiserJobTemplateLogoId, companyName, hashValue, requireLogonForExternalApplications, showLocationDetails, publicTransport, address, contactDetails, jobContactPhone, jobContactName, qualificationsRecognised, residentOnly, documentLink, bulletPoint1, bulletPoint2, bulletPoint3, hotJob, jobFriendlyName, searchField, showSalaryRange, salaryLowerBand, salaryUpperBand, currencyId, salaryTypeId, enteredByAdvertiserUserId, jobLatitude, jobLongitude, addressStatus);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_Insert' stored procedure. 
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
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? siteId, System.Int32? workTypeId, System.String jobName, System.String description, System.String fullDescription, System.Boolean? webServiceProcessed, System.String applicationEmailAddress, System.String refNo, System.Boolean? visible, System.DateTime? datePosted, System.DateTime? expiryDate, System.Int32? expired, System.Decimal? jobItemPrice, System.Boolean? billed, System.DateTime? lastModified, System.Boolean? showSalaryDetails, System.String salaryText, System.Int32? advertiserId, System.Int32? lastModifiedByAdvertiserUserId, System.Int32? lastModifiedByAdminUserId, System.Int32? jobItemTypeId, System.Int32? applicationMethod, System.String applicationUrl, System.Int32? uploadMethod, System.String tags, System.Int32? jobTemplateId, System.String searchFieldExtension, System.Int32? advertiserJobTemplateLogoId, System.String companyName, System.Byte[] hashValue, System.Boolean? requireLogonForExternalApplications, System.Boolean? showLocationDetails, System.String publicTransport, System.String address, System.String contactDetails, System.String jobContactPhone, System.String jobContactName, System.Boolean? qualificationsRecognised, System.Boolean? residentOnly, System.String documentLink, System.String bulletPoint1, System.String bulletPoint2, System.String bulletPoint3, System.Boolean? hotJob, System.String jobFriendlyName, System.String searchField, System.Boolean? showSalaryRange, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? currencyId, System.Int32? salaryTypeId, System.Int32? enteredByAdvertiserUserId, System.Double? jobLatitude, System.Double? jobLongitude, System.Int32? addressStatus);
		
		#endregion
		
		#region JobsArchive_GetByLastModifiedByAdminUserId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLastModifiedByAdminUserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByLastModifiedByAdminUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdminUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedByAdminUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedByAdminUserId);
		
		#endregion
		
		#region JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, 0, int.MaxValue , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(int start, int pageLength, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(null, start, pageLength , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? expired, System.DateTime? expiryDate)
		{
			return GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(transactionManager, 0, int.MaxValue , advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, expired, expiryDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expired"> A <c>System.Int32?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? expired, System.DateTime? expiryDate);
		
		#endregion
		
		#region JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByExpiredExpiryDateAdvertiserIdCurrencyIdSalaryUpperBandSalaryLowerBandWorkTypeId' stored procedure. 
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
		
		#region JobsArchive_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region JobsArchive_GetByWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWorkTypeId(System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByWorkTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByWorkTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId);
		
		#endregion
		
		#region JobsArchive_GetByAreaId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByAreaId(System.Int32? areaId)
		{
			 GetByAreaId(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByAreaId(int start, int pageLength, System.Int32? areaId)
		{
			 GetByAreaId(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByAreaId(TransactionManager transactionManager, System.Int32? areaId)
		{
			 GetByAreaId(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetByAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region JobsArchive_GetByJobItemTypeId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemTypeId(System.Int32? jobItemTypeId)
		{
			return GetByJobItemTypeId(null, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByJobItemTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByJobItemTypeId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobItemTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId);
		
		#endregion
		
		#region JobsArchive_GetByLastModifiedByAdvertiserUserId 
		
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByLastModifiedByAdvertiserUserId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByLastModifiedByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedByAdvertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedByAdvertiserUserId);
		
		#endregion
		
		#region JobsArchive_GetByJobTemplateId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByJobTemplateId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobTemplateId);
		
		#endregion
		
		#region JobsArchive_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobsArchive_GetByCurrencyId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCurrencyId(System.Int32? currencyId)
		{
			return GetByCurrencyId(null, 0, int.MaxValue , currencyId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByCurrencyId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByCurrencyId' stored procedure. 
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
		///	This method wrap the 'JobsArchive_GetByCurrencyId' stored procedure. 
		/// </summary>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCurrencyId(TransactionManager transactionManager, int start, int pageLength , System.Int32? currencyId);
		
		#endregion
		
		#region JobsArchive_GetByRoleId 
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByRoleId(System.Int32? roleId)
		{
			 GetByRoleId(null, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByRoleId(int start, int pageLength, System.Int32? roleId)
		{
			 GetByRoleId(null, start, pageLength , roleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetByRoleId(TransactionManager transactionManager, System.Int32? roleId)
		{
			 GetByRoleId(transactionManager, 0, int.MaxValue , roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobsArchive_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetByRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? roleId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobsArchive&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobsArchive&gt;"/></returns>
		public static TList<JobsArchive> Fill(IDataReader reader, TList<JobsArchive> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobsArchive c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobsArchive")
					.Append("|").Append((System.Int32)reader[((int)JobsArchiveColumn.JobId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobsArchive>(
					key.ToString(), // EntityTrackingKey
					"JobsArchive",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobsArchive();
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
					c.JobId = (System.Int32)reader[((int)JobsArchiveColumn.JobId - 1)];
					c.OriginalJobId = c.JobId;
					c.SiteId = (System.Int32)reader[((int)JobsArchiveColumn.SiteId - 1)];
					c.WorkTypeId = (System.Int32)reader[((int)JobsArchiveColumn.WorkTypeId - 1)];
					c.JobName = (System.String)reader[((int)JobsArchiveColumn.JobName - 1)];
					c.Description = (System.String)reader[((int)JobsArchiveColumn.Description - 1)];
					c.FullDescription = (System.String)reader[((int)JobsArchiveColumn.FullDescription - 1)];
					c.WebServiceProcessed = (System.Boolean)reader[((int)JobsArchiveColumn.WebServiceProcessed - 1)];
					c.ApplicationEmailAddress = (System.String)reader[((int)JobsArchiveColumn.ApplicationEmailAddress - 1)];
					c.RefNo = (reader.IsDBNull(((int)JobsArchiveColumn.RefNo - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.RefNo - 1)];
					c.Visible = (System.Boolean)reader[((int)JobsArchiveColumn.Visible - 1)];
					c.DatePosted = (System.DateTime)reader[((int)JobsArchiveColumn.DatePosted - 1)];
					c.ExpiryDate = (System.DateTime)reader[((int)JobsArchiveColumn.ExpiryDate - 1)];
					c.Expired = (reader.IsDBNull(((int)JobsArchiveColumn.Expired - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.Expired - 1)];
					c.JobItemPrice = (reader.IsDBNull(((int)JobsArchiveColumn.JobItemPrice - 1)))?null:(System.Decimal?)reader[((int)JobsArchiveColumn.JobItemPrice - 1)];
					c.Billed = (System.Boolean)reader[((int)JobsArchiveColumn.Billed - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobsArchiveColumn.LastModified - 1)];
					c.ShowSalaryDetails = (System.Boolean)reader[((int)JobsArchiveColumn.ShowSalaryDetails - 1)];
					c.SalaryText = (reader.IsDBNull(((int)JobsArchiveColumn.SalaryText - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.SalaryText - 1)];
					c.AdvertiserId = (reader.IsDBNull(((int)JobsArchiveColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AdvertiserId - 1)];
					c.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)JobsArchiveColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.LastModifiedByAdvertiserUserId - 1)];
					c.LastModifiedByAdminUserId = (reader.IsDBNull(((int)JobsArchiveColumn.LastModifiedByAdminUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.LastModifiedByAdminUserId - 1)];
					c.JobItemTypeId = (reader.IsDBNull(((int)JobsArchiveColumn.JobItemTypeId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.JobItemTypeId - 1)];
					c.ApplicationMethod = (reader.IsDBNull(((int)JobsArchiveColumn.ApplicationMethod - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.ApplicationMethod - 1)];
					c.ApplicationUrl = (reader.IsDBNull(((int)JobsArchiveColumn.ApplicationUrl - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.ApplicationUrl - 1)];
					c.UploadMethod = (reader.IsDBNull(((int)JobsArchiveColumn.UploadMethod - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.UploadMethod - 1)];
					c.Tags = (reader.IsDBNull(((int)JobsArchiveColumn.Tags - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.Tags - 1)];
					c.JobTemplateId = (reader.IsDBNull(((int)JobsArchiveColumn.JobTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.JobTemplateId - 1)];
					c.SearchFieldExtension = (System.String)reader[((int)JobsArchiveColumn.SearchFieldExtension - 1)];
					c.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)JobsArchiveColumn.AdvertiserJobTemplateLogoId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AdvertiserJobTemplateLogoId - 1)];
					c.CompanyName = (reader.IsDBNull(((int)JobsArchiveColumn.CompanyName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.CompanyName - 1)];
					c.HashValue = (reader.IsDBNull(((int)JobsArchiveColumn.HashValue - 1)))?null:(System.Byte[])reader[((int)JobsArchiveColumn.HashValue - 1)];
					c.RequireLogonForExternalApplications = (System.Boolean)reader[((int)JobsArchiveColumn.RequireLogonForExternalApplications - 1)];
					c.ShowLocationDetails = (reader.IsDBNull(((int)JobsArchiveColumn.ShowLocationDetails - 1)))?null:(System.Boolean?)reader[((int)JobsArchiveColumn.ShowLocationDetails - 1)];
					c.PublicTransport = (reader.IsDBNull(((int)JobsArchiveColumn.PublicTransport - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.PublicTransport - 1)];
					c.Address = (reader.IsDBNull(((int)JobsArchiveColumn.Address - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.Address - 1)];
					c.ContactDetails = (System.String)reader[((int)JobsArchiveColumn.ContactDetails - 1)];
					c.JobContactPhone = (reader.IsDBNull(((int)JobsArchiveColumn.JobContactPhone - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobContactPhone - 1)];
					c.JobContactName = (reader.IsDBNull(((int)JobsArchiveColumn.JobContactName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobContactName - 1)];
					c.QualificationsRecognised = (System.Boolean)reader[((int)JobsArchiveColumn.QualificationsRecognised - 1)];
					c.ResidentOnly = (System.Boolean)reader[((int)JobsArchiveColumn.ResidentOnly - 1)];
					c.DocumentLink = (reader.IsDBNull(((int)JobsArchiveColumn.DocumentLink - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.DocumentLink - 1)];
					c.BulletPoint1 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint1 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint1 - 1)];
					c.BulletPoint2 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint2 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint2 - 1)];
					c.BulletPoint3 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint3 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint3 - 1)];
					c.HotJob = (System.Boolean)reader[((int)JobsArchiveColumn.HotJob - 1)];
					c.JobFriendlyName = (reader.IsDBNull(((int)JobsArchiveColumn.JobFriendlyName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobFriendlyName - 1)];
					c.SearchField = (reader.IsDBNull(((int)JobsArchiveColumn.SearchField - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.SearchField - 1)];
					c.ShowSalaryRange = (System.Boolean)reader[((int)JobsArchiveColumn.ShowSalaryRange - 1)];
					c.SalaryLowerBand = (System.Decimal)reader[((int)JobsArchiveColumn.SalaryLowerBand - 1)];
					c.SalaryUpperBand = (System.Decimal)reader[((int)JobsArchiveColumn.SalaryUpperBand - 1)];
					c.CurrencyId = (System.Int32)reader[((int)JobsArchiveColumn.CurrencyId - 1)];
					c.SalaryTypeId = (System.Int32)reader[((int)JobsArchiveColumn.SalaryTypeId - 1)];
					c.EnteredByAdvertiserUserId = (reader.IsDBNull(((int)JobsArchiveColumn.EnteredByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.EnteredByAdvertiserUserId - 1)];
					c.JobLatitude = (reader.IsDBNull(((int)JobsArchiveColumn.JobLatitude - 1)))?null:(System.Double?)reader[((int)JobsArchiveColumn.JobLatitude - 1)];
					c.JobLongitude = (reader.IsDBNull(((int)JobsArchiveColumn.JobLongitude - 1)))?null:(System.Double?)reader[((int)JobsArchiveColumn.JobLongitude - 1)];
					c.AddressStatus = (reader.IsDBNull(((int)JobsArchiveColumn.AddressStatus - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AddressStatus - 1)];
					c.JobExternalId = (reader.IsDBNull(((int)JobsArchiveColumn.JobExternalId - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobExternalId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobsArchive"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsArchive"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobsArchive entity)
		{
			if (!reader.Read()) return;
			
			entity.JobId = (System.Int32)reader[((int)JobsArchiveColumn.JobId - 1)];
			entity.OriginalJobId = (System.Int32)reader["JobID"];
			entity.SiteId = (System.Int32)reader[((int)JobsArchiveColumn.SiteId - 1)];
			entity.WorkTypeId = (System.Int32)reader[((int)JobsArchiveColumn.WorkTypeId - 1)];
			entity.JobName = (System.String)reader[((int)JobsArchiveColumn.JobName - 1)];
			entity.Description = (System.String)reader[((int)JobsArchiveColumn.Description - 1)];
			entity.FullDescription = (System.String)reader[((int)JobsArchiveColumn.FullDescription - 1)];
			entity.WebServiceProcessed = (System.Boolean)reader[((int)JobsArchiveColumn.WebServiceProcessed - 1)];
			entity.ApplicationEmailAddress = (System.String)reader[((int)JobsArchiveColumn.ApplicationEmailAddress - 1)];
			entity.RefNo = (reader.IsDBNull(((int)JobsArchiveColumn.RefNo - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.RefNo - 1)];
			entity.Visible = (System.Boolean)reader[((int)JobsArchiveColumn.Visible - 1)];
			entity.DatePosted = (System.DateTime)reader[((int)JobsArchiveColumn.DatePosted - 1)];
			entity.ExpiryDate = (System.DateTime)reader[((int)JobsArchiveColumn.ExpiryDate - 1)];
			entity.Expired = (reader.IsDBNull(((int)JobsArchiveColumn.Expired - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.Expired - 1)];
			entity.JobItemPrice = (reader.IsDBNull(((int)JobsArchiveColumn.JobItemPrice - 1)))?null:(System.Decimal?)reader[((int)JobsArchiveColumn.JobItemPrice - 1)];
			entity.Billed = (System.Boolean)reader[((int)JobsArchiveColumn.Billed - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobsArchiveColumn.LastModified - 1)];
			entity.ShowSalaryDetails = (System.Boolean)reader[((int)JobsArchiveColumn.ShowSalaryDetails - 1)];
			entity.SalaryText = (reader.IsDBNull(((int)JobsArchiveColumn.SalaryText - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.SalaryText - 1)];
			entity.AdvertiserId = (reader.IsDBNull(((int)JobsArchiveColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AdvertiserId - 1)];
			entity.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)JobsArchiveColumn.LastModifiedByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.LastModifiedByAdvertiserUserId - 1)];
			entity.LastModifiedByAdminUserId = (reader.IsDBNull(((int)JobsArchiveColumn.LastModifiedByAdminUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.LastModifiedByAdminUserId - 1)];
			entity.JobItemTypeId = (reader.IsDBNull(((int)JobsArchiveColumn.JobItemTypeId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.JobItemTypeId - 1)];
			entity.ApplicationMethod = (reader.IsDBNull(((int)JobsArchiveColumn.ApplicationMethod - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.ApplicationMethod - 1)];
			entity.ApplicationUrl = (reader.IsDBNull(((int)JobsArchiveColumn.ApplicationUrl - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.ApplicationUrl - 1)];
			entity.UploadMethod = (reader.IsDBNull(((int)JobsArchiveColumn.UploadMethod - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.UploadMethod - 1)];
			entity.Tags = (reader.IsDBNull(((int)JobsArchiveColumn.Tags - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.Tags - 1)];
			entity.JobTemplateId = (reader.IsDBNull(((int)JobsArchiveColumn.JobTemplateId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.JobTemplateId - 1)];
			entity.SearchFieldExtension = (System.String)reader[((int)JobsArchiveColumn.SearchFieldExtension - 1)];
			entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)JobsArchiveColumn.AdvertiserJobTemplateLogoId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AdvertiserJobTemplateLogoId - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)JobsArchiveColumn.CompanyName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.CompanyName - 1)];
			entity.HashValue = (reader.IsDBNull(((int)JobsArchiveColumn.HashValue - 1)))?null:(System.Byte[])reader[((int)JobsArchiveColumn.HashValue - 1)];
			entity.RequireLogonForExternalApplications = (System.Boolean)reader[((int)JobsArchiveColumn.RequireLogonForExternalApplications - 1)];
			entity.ShowLocationDetails = (reader.IsDBNull(((int)JobsArchiveColumn.ShowLocationDetails - 1)))?null:(System.Boolean?)reader[((int)JobsArchiveColumn.ShowLocationDetails - 1)];
			entity.PublicTransport = (reader.IsDBNull(((int)JobsArchiveColumn.PublicTransport - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.PublicTransport - 1)];
			entity.Address = (reader.IsDBNull(((int)JobsArchiveColumn.Address - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.Address - 1)];
			entity.ContactDetails = (System.String)reader[((int)JobsArchiveColumn.ContactDetails - 1)];
			entity.JobContactPhone = (reader.IsDBNull(((int)JobsArchiveColumn.JobContactPhone - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobContactPhone - 1)];
			entity.JobContactName = (reader.IsDBNull(((int)JobsArchiveColumn.JobContactName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobContactName - 1)];
			entity.QualificationsRecognised = (System.Boolean)reader[((int)JobsArchiveColumn.QualificationsRecognised - 1)];
			entity.ResidentOnly = (System.Boolean)reader[((int)JobsArchiveColumn.ResidentOnly - 1)];
			entity.DocumentLink = (reader.IsDBNull(((int)JobsArchiveColumn.DocumentLink - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.DocumentLink - 1)];
			entity.BulletPoint1 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint1 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint1 - 1)];
			entity.BulletPoint2 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint2 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint2 - 1)];
			entity.BulletPoint3 = (reader.IsDBNull(((int)JobsArchiveColumn.BulletPoint3 - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.BulletPoint3 - 1)];
			entity.HotJob = (System.Boolean)reader[((int)JobsArchiveColumn.HotJob - 1)];
			entity.JobFriendlyName = (reader.IsDBNull(((int)JobsArchiveColumn.JobFriendlyName - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobFriendlyName - 1)];
			entity.SearchField = (reader.IsDBNull(((int)JobsArchiveColumn.SearchField - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.SearchField - 1)];
			entity.ShowSalaryRange = (System.Boolean)reader[((int)JobsArchiveColumn.ShowSalaryRange - 1)];
			entity.SalaryLowerBand = (System.Decimal)reader[((int)JobsArchiveColumn.SalaryLowerBand - 1)];
			entity.SalaryUpperBand = (System.Decimal)reader[((int)JobsArchiveColumn.SalaryUpperBand - 1)];
			entity.CurrencyId = (System.Int32)reader[((int)JobsArchiveColumn.CurrencyId - 1)];
			entity.SalaryTypeId = (System.Int32)reader[((int)JobsArchiveColumn.SalaryTypeId - 1)];
			entity.EnteredByAdvertiserUserId = (reader.IsDBNull(((int)JobsArchiveColumn.EnteredByAdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.EnteredByAdvertiserUserId - 1)];
			entity.JobLatitude = (reader.IsDBNull(((int)JobsArchiveColumn.JobLatitude - 1)))?null:(System.Double?)reader[((int)JobsArchiveColumn.JobLatitude - 1)];
			entity.JobLongitude = (reader.IsDBNull(((int)JobsArchiveColumn.JobLongitude - 1)))?null:(System.Double?)reader[((int)JobsArchiveColumn.JobLongitude - 1)];
			entity.AddressStatus = (reader.IsDBNull(((int)JobsArchiveColumn.AddressStatus - 1)))?null:(System.Int32?)reader[((int)JobsArchiveColumn.AddressStatus - 1)];
			entity.JobExternalId = (reader.IsDBNull(((int)JobsArchiveColumn.JobExternalId - 1)))?null:(System.String)reader[((int)JobsArchiveColumn.JobExternalId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobsArchive"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsArchive"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobsArchive entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobId = (System.Int32)dataRow["JobID"];
			entity.OriginalJobId = (System.Int32)dataRow["JobID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobsArchive"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobsArchive Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobsArchive entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

				entity.InvoiceItemCollection = DataRepository.InvoiceItemProvider.GetByJobArchiveId(transactionManager, entity.JobId);

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

				entity.JobApplicationCollection = DataRepository.JobApplicationProvider.GetByJobArchiveId(transactionManager, entity.JobId);

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

				entity.JobsSavedCollection = DataRepository.JobsSavedProvider.GetByJobArchiveId(transactionManager, entity.JobId);

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

				entity.JobViewsCollection = DataRepository.JobViewsProvider.GetByJobArchiveId(transactionManager, entity.JobId);

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

				entity.JobRolesCollection = DataRepository.JobRolesProvider.GetByJobArchiveId(transactionManager, entity.JobId);

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

				entity.JobAreaCollection = DataRepository.JobAreaProvider.GetByJobArchiveId(transactionManager, entity.JobId);

				if (deep && entity.JobAreaCollection.Count > 0)
				{
					deepHandles.Add("JobAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobArea>) DataRepository.JobAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.JobAreaCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobsArchive object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobsArchive instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobsArchive Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobsArchive entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
						if(child.JobArchiveIdSource != null)
						{
							child.JobArchiveId = child.JobArchiveIdSource.JobId;
						}
						else
						{
							child.JobArchiveId = entity.JobId;
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
	
	#region JobsArchiveChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobsArchive</c>
	///</summary>
	public enum JobsArchiveChildEntityTypes
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
		/// Collection of <c>JobsArchive</c> as OneToMany for InvoiceItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceItem>))]
		InvoiceItemCollection,

		///<summary>
		/// Collection of <c>JobsArchive</c> as OneToMany for JobApplicationCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplication>))]
		JobApplicationCollection,

		///<summary>
		/// Collection of <c>JobsArchive</c> as OneToMany for JobsSavedCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsSaved>))]
		JobsSavedCollection,

		///<summary>
		/// Collection of <c>JobsArchive</c> as OneToMany for JobViewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobViews>))]
		JobViewsCollection,

		///<summary>
		/// Collection of <c>JobsArchive</c> as OneToMany for JobRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobRoles>))]
		JobRolesCollection,

		///<summary>
		/// Collection of <c>JobsArchive</c> as OneToMany for JobAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobArea>))]
		JobAreaCollection,
	}
	
	#endregion JobsArchiveChildEntityTypes
	
	#region JobsArchiveFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobsArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveFilterBuilder : SqlFilterBuilder<JobsArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilterBuilder class.
		/// </summary>
		public JobsArchiveFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsArchiveFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsArchiveFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsArchiveFilterBuilder
	
	#region JobsArchiveParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobsArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveParameterBuilder : ParameterizedSqlFilterBuilder<JobsArchiveColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveParameterBuilder class.
		/// </summary>
		public JobsArchiveParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsArchiveParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsArchiveParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsArchiveParameterBuilder
	
	#region JobsArchiveSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobsArchiveColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobsArchiveSortBuilder : SqlSortBuilder<JobsArchiveColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveSqlSortBuilder class.
		/// </summary>
		public JobsArchiveSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobsArchiveSortBuilder
	
} // end namespace
