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
	/// This class is the base class for any <see cref="JobItemsTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobItemsTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobItemsType, JXTPortal.Entities.JobItemsTypeKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByAdvertiserIdFromAdvertiserJobPricing
		
		/// <summary>
		///		Gets JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JobItemsType objects.</returns>
		public TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserIdFromAdvertiserJobPricing(null,_advertiserId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets JXTPortal.Entities.JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of JobItemsType objects.</returns>
		public TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdFromAdvertiserJobPricing(null, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JobItemsType objects.</returns>
		public TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserIdFromAdvertiserJobPricing(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JobItemsType objects.</returns>
		public TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32 _advertiserId,int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdFromAdvertiserJobPricing(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JobItemsType objects.</returns>
		public TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(System.Int32 _advertiserId,int start, int pageLength, out int count)
		{
			
			return GetByAdvertiserIdFromAdvertiserJobPricing(null, _advertiserId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets JobItemsType objects from the datasource by AdvertiserID in the
		///		AdvertiserJobPricing table. Table JobItemsType is related to table Advertisers
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of JobItemsType objects.</returns>
		public abstract TList<JobItemsType> GetByAdvertiserIdFromAdvertiserJobPricing(TransactionManager transactionManager,System.Int32 _advertiserId, int start, int pageLength, out int count);
		
		#endregion GetByAdvertiserIdFromAdvertiserJobPricing
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobItemsTypeKey key)
		{
			return Delete(transactionManager, key.JobItemTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobItemTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobItemTypeId)
		{
			return Delete(null, _jobItemTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobItemTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		FK__JobItemsT__LastM__5D21AF45 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		FK__JobItemsT__LastM__5D21AF45 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		/// <remarks></remarks>
		public TList<JobItemsType> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		FK__JobItemsT__LastM__5D21AF45 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		fkJobItemstLastm5d21Af45 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		fkJobItemstLastm5d21Af45 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__LastM__5D21AF45 key.
		///		FK__JobItemsT__LastM__5D21AF45 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public abstract TList<JobItemsType> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		FK__JobItemsT__SiteI__5B3966D3 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		FK__JobItemsT__SiteI__5B3966D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		/// <remarks></remarks>
		public TList<JobItemsType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		FK__JobItemsT__SiteI__5B3966D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		fkJobItemstSitei5b3966d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		fkJobItemstSitei5b3966d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public TList<JobItemsType> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobItemsT__SiteI__5B3966D3 key.
		///		FK__JobItemsT__SiteI__5B3966D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobItemsType objects.</returns>
		public abstract TList<JobItemsType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobItemsType Get(TransactionManager transactionManager, JXTPortal.Entities.JobItemsTypeKey key, int start, int pageLength)
		{
			return GetByJobItemTypeId(transactionManager, key.JobItemTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="_jobItemTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public JXTPortal.Entities.JobItemsType GetByJobItemTypeId(System.Int32 _jobItemTypeId)
		{
			int count = -1;
			return GetByJobItemTypeId(null,_jobItemTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="_jobItemTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public JXTPortal.Entities.JobItemsType GetByJobItemTypeId(System.Int32 _jobItemTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobItemTypeId(null, _jobItemTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public JXTPortal.Entities.JobItemsType GetByJobItemTypeId(TransactionManager transactionManager, System.Int32 _jobItemTypeId)
		{
			int count = -1;
			return GetByJobItemTypeId(transactionManager, _jobItemTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public JXTPortal.Entities.JobItemsType GetByJobItemTypeId(TransactionManager transactionManager, System.Int32 _jobItemTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobItemTypeId(transactionManager, _jobItemTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="_jobItemTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public JXTPortal.Entities.JobItemsType GetByJobItemTypeId(System.Int32 _jobItemTypeId, int start, int pageLength, out int count)
		{
			return GetByJobItemTypeId(null, _jobItemTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobItemsType__5A45429A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobItemsType"/> class.</returns>
		public abstract JXTPortal.Entities.JobItemsType GetByJobItemTypeId(TransactionManager transactionManager, System.Int32 _jobItemTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobItemsType_GetByJobItemTypeId 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemTypeId(System.Int32? jobItemTypeId)
		{
			return GetByJobItemTypeId(null, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByJobItemTypeId' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetByJobItemTypeId' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetByJobItemTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobItemTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId);
		
		#endregion
		
		#region JobItemsType_Insert 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
			/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription, ref System.Int32? jobItemTypeId)
		{
			 Insert(null, 0, int.MaxValue , siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription, ref jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
			/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription, ref System.Int32? jobItemTypeId)
		{
			 Insert(null, start, pageLength , siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription, ref jobItemTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
			/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription, ref System.Int32? jobItemTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription, ref jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
			/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription, ref System.Int32? jobItemTypeId);
		
		#endregion
		
		#region JobItemsType_GetByAdvertiserIdFromAdvertiserJobPricing 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByAdvertiserIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdFromAdvertiserJobPricing(System.Int32? advertiserId)
		{
			return GetByAdvertiserIdFromAdvertiserJobPricing(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByAdvertiserIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdFromAdvertiserJobPricing(int start, int pageLength, System.Int32? advertiserId)
		{
			return GetByAdvertiserIdFromAdvertiserJobPricing(null, start, pageLength , advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByAdvertiserIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32? advertiserId)
		{
			return GetByAdvertiserIdFromAdvertiserJobPricing(transactionManager, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByAdvertiserIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdFromAdvertiserJobPricing(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region JobItemsType_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobItemsType_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Get_List' stored procedure. 
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
		///	This method wrap the 'JobItemsType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobItemsType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobItemsType_GetPaged' stored procedure. 
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
		
		#region JobItemsType_CustomGetBySiteID 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobItemsType&gt;"/> instance.</returns>
		public TList<JobItemsType> CustomGetBySiteID(System.Int32? siteId)
		{
			return CustomGetBySiteID(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobItemsType&gt;"/> instance.</returns>
		public TList<JobItemsType> CustomGetBySiteID(int start, int pageLength, System.Int32? siteId)
		{
			return CustomGetBySiteID(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobItemsType&gt;"/> instance.</returns>
		public TList<JobItemsType> CustomGetBySiteID(TransactionManager transactionManager, System.Int32? siteId)
		{
			return CustomGetBySiteID(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobItemsType&gt;"/> instance.</returns>
		public abstract TList<JobItemsType> CustomGetBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobItemsType_Update 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Update' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			 Update(null, 0, int.MaxValue , jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Update' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			 Update(null, start, pageLength , jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_Update' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			 Update(transactionManager, 0, int.MaxValue , jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Update' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription);
		
		#endregion
		
		#region JobItemsType_Find 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			return Find(null, start, pageLength , searchUsingOr, jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobItemTypeId, siteId, jobItemTypeParentId, jobItemTypeDescription, lastModifiedBy, lastModified, totalAmount, daysActive, sequence, valid, discountAmount, totalNumberOfJobs, shortDescription);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemTypeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="daysActive"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="discountAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="totalNumberOfJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobItemTypeId, System.Int32? siteId, System.Int32? jobItemTypeParentId, System.String jobItemTypeDescription, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Decimal? totalAmount, System.Int32? daysActive, System.Int32? sequence, System.Boolean? valid, System.Decimal? discountAmount, System.Int32? totalNumberOfJobs, System.String shortDescription);
		
		#endregion
		
		#region JobItemsType_Delete 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobItemTypeId)
		{
			 Delete(null, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobItemTypeId)
		{
			 Delete(null, start, pageLength , jobItemTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobItemTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobItemTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobItemTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemTypeId);
		
		#endregion
		
		#region JobItemsType_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'JobItemsType_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobItemsType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobItemsType&gt;"/></returns>
		public static TList<JobItemsType> Fill(IDataReader reader, TList<JobItemsType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobItemsType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobItemsType")
					.Append("|").Append((System.Int32)reader[((int)JobItemsTypeColumn.JobItemTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobItemsType>(
					key.ToString(), // EntityTrackingKey
					"JobItemsType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobItemsType();
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
					c.JobItemTypeId = (System.Int32)reader[((int)JobItemsTypeColumn.JobItemTypeId - 1)];
					c.SiteId = (System.Int32)reader[((int)JobItemsTypeColumn.SiteId - 1)];
					c.JobItemTypeParentId = (System.Int32)reader[((int)JobItemsTypeColumn.JobItemTypeParentId - 1)];
					c.JobItemTypeDescription = (reader.IsDBNull(((int)JobItemsTypeColumn.JobItemTypeDescription - 1)))?null:(System.String)reader[((int)JobItemsTypeColumn.JobItemTypeDescription - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)JobItemsTypeColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobItemsTypeColumn.LastModified - 1)];
					c.TotalAmount = (reader.IsDBNull(((int)JobItemsTypeColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)JobItemsTypeColumn.TotalAmount - 1)];
					c.DaysActive = (System.Int32)reader[((int)JobItemsTypeColumn.DaysActive - 1)];
					c.Sequence = (System.Int32)reader[((int)JobItemsTypeColumn.Sequence - 1)];
					c.Valid = (System.Boolean)reader[((int)JobItemsTypeColumn.Valid - 1)];
					c.DiscountAmount = (reader.IsDBNull(((int)JobItemsTypeColumn.DiscountAmount - 1)))?null:(System.Decimal?)reader[((int)JobItemsTypeColumn.DiscountAmount - 1)];
					c.TotalNumberOfJobs = (System.Int32)reader[((int)JobItemsTypeColumn.TotalNumberOfJobs - 1)];
					c.ShortDescription = (reader.IsDBNull(((int)JobItemsTypeColumn.ShortDescription - 1)))?null:(System.String)reader[((int)JobItemsTypeColumn.ShortDescription - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobItemsType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobItemsType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobItemsType entity)
		{
			if (!reader.Read()) return;
			
			entity.JobItemTypeId = (System.Int32)reader[((int)JobItemsTypeColumn.JobItemTypeId - 1)];
			entity.SiteId = (System.Int32)reader[((int)JobItemsTypeColumn.SiteId - 1)];
			entity.JobItemTypeParentId = (System.Int32)reader[((int)JobItemsTypeColumn.JobItemTypeParentId - 1)];
			entity.JobItemTypeDescription = (reader.IsDBNull(((int)JobItemsTypeColumn.JobItemTypeDescription - 1)))?null:(System.String)reader[((int)JobItemsTypeColumn.JobItemTypeDescription - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)JobItemsTypeColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobItemsTypeColumn.LastModified - 1)];
			entity.TotalAmount = (reader.IsDBNull(((int)JobItemsTypeColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)JobItemsTypeColumn.TotalAmount - 1)];
			entity.DaysActive = (System.Int32)reader[((int)JobItemsTypeColumn.DaysActive - 1)];
			entity.Sequence = (System.Int32)reader[((int)JobItemsTypeColumn.Sequence - 1)];
			entity.Valid = (System.Boolean)reader[((int)JobItemsTypeColumn.Valid - 1)];
			entity.DiscountAmount = (reader.IsDBNull(((int)JobItemsTypeColumn.DiscountAmount - 1)))?null:(System.Decimal?)reader[((int)JobItemsTypeColumn.DiscountAmount - 1)];
			entity.TotalNumberOfJobs = (System.Int32)reader[((int)JobItemsTypeColumn.TotalNumberOfJobs - 1)];
			entity.ShortDescription = (reader.IsDBNull(((int)JobItemsTypeColumn.ShortDescription - 1)))?null:(System.String)reader[((int)JobItemsTypeColumn.ShortDescription - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobItemsType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobItemsType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobItemsType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobItemTypeId = (System.Int32)dataRow["JobItemTypeID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.JobItemTypeParentId = (System.Int32)dataRow["JobItemTypeParentID"];
			entity.JobItemTypeDescription = Convert.IsDBNull(dataRow["JobItemTypeDescription"]) ? null : (System.String)dataRow["JobItemTypeDescription"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.TotalAmount = Convert.IsDBNull(dataRow["TotalAmount"]) ? null : (System.Decimal?)dataRow["TotalAmount"];
			entity.DaysActive = (System.Int32)dataRow["DaysActive"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.DiscountAmount = Convert.IsDBNull(dataRow["DiscountAmount"]) ? null : (System.Decimal?)dataRow["DiscountAmount"];
			entity.TotalNumberOfJobs = (System.Int32)dataRow["TotalNumberOfJobs"];
			entity.ShortDescription = Convert.IsDBNull(dataRow["ShortDescription"]) ? null : (System.String)dataRow["ShortDescription"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobItemsType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobItemsType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobItemsType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LastModifiedBy;
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, entity.LastModifiedBy);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedBySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedBySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.LastModifiedBySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedBySource

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
			// Deep load child collections  - Call GetByJobItemTypeId methods when available
			
			#region AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Advertisers>|AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing", deepLoadType, innerList))
			{
				entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing = DataRepository.AdvertisersProvider.GetByJobItemsTypeIdFromAdvertiserJobPricing(transactionManager, entity.JobItemTypeId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing != null)
				{
					deepHandles.Add("AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Advertisers >) DataRepository.AdvertisersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region AdvertiserJobPricingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserJobPricing>|AdvertiserJobPricingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserJobPricingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserJobPricingCollection = DataRepository.AdvertiserJobPricingProvider.GetByJobItemsTypeId(transactionManager, entity.JobItemTypeId);

				if (deep && entity.AdvertiserJobPricingCollection.Count > 0)
				{
					deepHandles.Add("AdvertiserJobPricingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserJobPricing>) DataRepository.AdvertiserJobPricingProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserJobPricingCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobItemsType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobItemsType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobItemsType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobItemsType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
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

			#region AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing>
			if (CanDeepSave(entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing, "List<Advertisers>|AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing", deepSaveType, innerList))
			{
				if (entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing.Count > 0 || entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing.DeletedItems.Count > 0)
				{
					DataRepository.AdvertisersProvider.Save(transactionManager, entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing); 
					deepHandles.Add("AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Advertisers>) DataRepository.AdvertisersProvider.DeepSave,
						new object[] { transactionManager, entity.AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<AdvertiserJobPricing>
				if (CanDeepSave(entity.AdvertiserJobPricingCollection, "List<AdvertiserJobPricing>|AdvertiserJobPricingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserJobPricing child in entity.AdvertiserJobPricingCollection)
					{
						if(child.JobItemsTypeIdSource != null)
						{
								child.JobItemsTypeId = child.JobItemsTypeIdSource.JobItemTypeId;
						}

						if(child.AdvertiserIdSource != null)
						{
								child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}

					}

					if (entity.AdvertiserJobPricingCollection.Count > 0 || entity.AdvertiserJobPricingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserJobPricingProvider.Save(transactionManager, entity.AdvertiserJobPricingCollection);
						
						deepHandles.Add("AdvertiserJobPricingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserJobPricing >) DataRepository.AdvertiserJobPricingProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserJobPricingCollection, deepSaveType, childTypes, innerList }
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
	
	#region JobItemsTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobItemsType</c>
	///</summary>
	public enum JobItemsTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>JobItemsType</c> as ManyToMany for AdvertisersCollection_From_AdvertiserJobPricing
		///</summary>
		[ChildEntityType(typeof(TList<Advertisers>))]
		AdvertiserIdAdvertisersCollection_From_AdvertiserJobPricing,

		///<summary>
		/// Collection of <c>JobItemsType</c> as OneToMany for AdvertiserJobPricingCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserJobPricing>))]
		AdvertiserJobPricingCollection,
	}
	
	#endregion JobItemsTypeChildEntityTypes
	
	#region JobItemsTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobItemsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeFilterBuilder : SqlFilterBuilder<JobItemsTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilterBuilder class.
		/// </summary>
		public JobItemsTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobItemsTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobItemsTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobItemsTypeFilterBuilder
	
	#region JobItemsTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobItemsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeParameterBuilder : ParameterizedSqlFilterBuilder<JobItemsTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeParameterBuilder class.
		/// </summary>
		public JobItemsTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobItemsTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobItemsTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobItemsTypeParameterBuilder
	
	#region JobItemsTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobItemsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobItemsTypeSortBuilder : SqlSortBuilder<JobItemsTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeSqlSortBuilder class.
		/// </summary>
		public JobItemsTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobItemsTypeSortBuilder
	
} // end namespace
