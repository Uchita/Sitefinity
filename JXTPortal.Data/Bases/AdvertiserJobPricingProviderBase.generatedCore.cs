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
	/// This class is the base class for any <see cref="AdvertiserJobPricingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertiserJobPricingProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdvertiserJobPricing, JXTPortal.Entities.AdvertiserJobPricingKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobPricingKey key)
		{
			return Delete(transactionManager, key.AdvertiserId, key.JobItemsTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserId">. Primary Key.</param>
		/// <param name="_jobItemsTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserId, System.Int32 _jobItemsTypeId)
		{
			return Delete(null, _advertiserId, _jobItemsTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId">. Primary Key.</param>
		/// <param name="_jobItemsTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserId, System.Int32 _jobItemsTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		FK__Advertise__Adver__1C3CAE6F Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		FK__Advertise__Adver__1C3CAE6F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserJobPricing> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		FK__Advertise__Adver__1C3CAE6F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		fkAdvertiseAdver1c3Cae6f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		fkAdvertiseAdver1c3Cae6f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__1C3CAE6F key.
		///		FK__Advertise__Adver__1C3CAE6F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public abstract TList<AdvertiserJobPricing> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		FK__Advertise__JobIt__1D30D2A8 Description: 
		/// </summary>
		/// <param name="_jobItemsTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByJobItemsTypeId(System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByJobItemsTypeId(_jobItemsTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		FK__Advertise__JobIt__1D30D2A8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserJobPricing> GetByJobItemsTypeId(TransactionManager transactionManager, System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByJobItemsTypeId(transactionManager, _jobItemsTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		FK__Advertise__JobIt__1D30D2A8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByJobItemsTypeId(TransactionManager transactionManager, System.Int32 _jobItemsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobItemsTypeId(transactionManager, _jobItemsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		fkAdvertiseJobIt1d30d2a8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByJobItemsTypeId(System.Int32 _jobItemsTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobItemsTypeId(null, _jobItemsTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		fkAdvertiseJobIt1d30d2a8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public TList<AdvertiserJobPricing> GetByJobItemsTypeId(System.Int32 _jobItemsTypeId, int start, int pageLength,out int count)
		{
			return GetByJobItemsTypeId(null, _jobItemsTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__JobIt__1D30D2A8 key.
		///		FK__Advertise__JobIt__1D30D2A8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobPricing objects.</returns>
		public abstract TList<AdvertiserJobPricing> GetByJobItemsTypeId(TransactionManager transactionManager, System.Int32 _jobItemsTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.AdvertiserJobPricing Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobPricingKey key, int start, int pageLength)
		{
			return GetByAdvertiserIdJobItemsTypeId(transactionManager, key.AdvertiserId, key.JobItemsTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(System.Int32 _advertiserId, System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByAdvertiserIdJobItemsTypeId(null,_advertiserId, _jobItemsTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(System.Int32 _advertiserId, System.Int32 _jobItemsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdJobItemsTypeId(null, _advertiserId, _jobItemsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(TransactionManager transactionManager, System.Int32 _advertiserId, System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByAdvertiserIdJobItemsTypeId(transactionManager, _advertiserId, _jobItemsTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(TransactionManager transactionManager, System.Int32 _advertiserId, System.Int32 _jobItemsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserIdJobItemsTypeId(transactionManager, _advertiserId, _jobItemsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(System.Int32 _advertiserId, System.Int32 _jobItemsTypeId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserIdJobItemsTypeId(null, _advertiserId, _jobItemsTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Advertis__93477E8A196041C4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserJobPricing GetByAdvertiserIdJobItemsTypeId(TransactionManager transactionManager, System.Int32 _advertiserId, System.Int32 _jobItemsTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdvertiserJobPricing_Insert 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Insert(null, 0, int.MaxValue , advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Insert(null, start, pageLength , advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region AdvertiserJobPricing_CustomGetByAdvertiserIDJobItemsTypeID 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_CustomGetByAdvertiserIDJobItemsTypeID' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByAdvertiserIDJobItemsTypeID(System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return CustomGetByAdvertiserIDJobItemsTypeID(null, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_CustomGetByAdvertiserIDJobItemsTypeID' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByAdvertiserIDJobItemsTypeID(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return CustomGetByAdvertiserIDJobItemsTypeID(null, start, pageLength , advertiserId, jobItemsTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_CustomGetByAdvertiserIDJobItemsTypeID' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByAdvertiserIDJobItemsTypeID(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return CustomGetByAdvertiserIDJobItemsTypeID(transactionManager, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_CustomGetByAdvertiserIDJobItemsTypeID' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetByAdvertiserIDJobItemsTypeID(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobItemsTypeId);
		
		#endregion
		
		#region AdvertiserJobPricing_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Get_List' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdvertiserJobPricing_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_GetPaged' stored procedure. 
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
		
		#region AdvertiserJobPricing_GetByJobItemsTypeId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeId(System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeId(null, 0, int.MaxValue , jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeId(int start, int pageLength, System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeId(null, start, pageLength , jobItemsTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeId(TransactionManager transactionManager, System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeId(transactionManager, 0, int.MaxValue , jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobItemsTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemsTypeId);
		
		#endregion
		
		#region AdvertiserJobPricing_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region AdvertiserJobPricing_GetByAdvertiserIdJobItemsTypeId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserIdJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobItemsTypeId(System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return GetByAdvertiserIdJobItemsTypeId(null, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserIdJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobItemsTypeId(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return GetByAdvertiserIdJobItemsTypeId(null, start, pageLength , advertiserId, jobItemsTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserIdJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserIdJobItemsTypeId(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			return GetByAdvertiserIdJobItemsTypeId(transactionManager, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_GetByAdvertiserIdJobItemsTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserIdJobItemsTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobItemsTypeId);
		
		#endregion
		
		#region AdvertiserJobPricing_Find 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserId, jobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? jobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region AdvertiserJobPricing_Delete 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			 Delete(null, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			 Delete(null, start, pageLength , advertiserId, jobItemsTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? jobItemsTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserId, jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? jobItemsTypeId);
		
		#endregion
		
		#region AdvertiserJobPricing_Update 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserId, System.Int32? originalAdvertiserId, System.Int32? jobItemsTypeId, System.Int32? originalJobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, 0, int.MaxValue , advertiserId, originalAdvertiserId, jobItemsTypeId, originalJobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserId, System.Int32? originalAdvertiserId, System.Int32? jobItemsTypeId, System.Int32? originalJobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, start, pageLength , advertiserId, originalAdvertiserId, jobItemsTypeId, originalJobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? originalAdvertiserId, System.Int32? jobItemsTypeId, System.Int32? originalJobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserId, originalAdvertiserId, jobItemsTypeId, originalJobItemsTypeId, totalAmount, startDate, expiryDate, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobPricing_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalJobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalAmount"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="startDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="expiryDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? originalAdvertiserId, System.Int32? jobItemsTypeId, System.Int32? originalJobItemsTypeId, System.Decimal? totalAmount, System.DateTime? startDate, System.DateTime? expiryDate, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdvertiserJobPricing&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdvertiserJobPricing&gt;"/></returns>
		public static TList<AdvertiserJobPricing> Fill(IDataReader reader, TList<AdvertiserJobPricing> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdvertiserJobPricing c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdvertiserJobPricing")
					.Append("|").Append((System.Int32)reader[((int)AdvertiserJobPricingColumn.AdvertiserId - 1)])
					.Append("|").Append((System.Int32)reader[((int)AdvertiserJobPricingColumn.JobItemsTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdvertiserJobPricing>(
					key.ToString(), // EntityTrackingKey
					"AdvertiserJobPricing",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdvertiserJobPricing();
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
					c.AdvertiserId = (System.Int32)reader[((int)AdvertiserJobPricingColumn.AdvertiserId - 1)];
					c.OriginalAdvertiserId = c.AdvertiserId;
					c.JobItemsTypeId = (System.Int32)reader[((int)AdvertiserJobPricingColumn.JobItemsTypeId - 1)];
					c.OriginalJobItemsTypeId = c.JobItemsTypeId;
					c.TotalAmount = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)AdvertiserJobPricingColumn.TotalAmount - 1)];
					c.StartDate = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserJobPricingColumn.StartDate - 1)];
					c.ExpiryDate = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.ExpiryDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserJobPricingColumn.ExpiryDate - 1)];
					c.LastModified = (System.DateTime)reader[((int)AdvertiserJobPricingColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)AdvertiserJobPricingColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdvertiserJobPricing entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserId = (System.Int32)reader[((int)AdvertiserJobPricingColumn.AdvertiserId - 1)];
			entity.OriginalAdvertiserId = (System.Int32)reader["AdvertiserID"];
			entity.JobItemsTypeId = (System.Int32)reader[((int)AdvertiserJobPricingColumn.JobItemsTypeId - 1)];
			entity.OriginalJobItemsTypeId = (System.Int32)reader["JobItemsTypeID"];
			entity.TotalAmount = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.TotalAmount - 1)))?null:(System.Decimal?)reader[((int)AdvertiserJobPricingColumn.TotalAmount - 1)];
			entity.StartDate = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.StartDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserJobPricingColumn.StartDate - 1)];
			entity.ExpiryDate = (reader.IsDBNull(((int)AdvertiserJobPricingColumn.ExpiryDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserJobPricingColumn.ExpiryDate - 1)];
			entity.LastModified = (System.DateTime)reader[((int)AdvertiserJobPricingColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)AdvertiserJobPricingColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdvertiserJobPricing entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.OriginalAdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.JobItemsTypeId = (System.Int32)dataRow["JobItemsTypeID"];
			entity.OriginalJobItemsTypeId = (System.Int32)dataRow["JobItemsTypeID"];
			entity.TotalAmount = Convert.IsDBNull(dataRow["TotalAmount"]) ? null : (System.Decimal?)dataRow["TotalAmount"];
			entity.StartDate = Convert.IsDBNull(dataRow["StartDate"]) ? null : (System.DateTime?)dataRow["StartDate"];
			entity.ExpiryDate = Convert.IsDBNull(dataRow["ExpiryDate"]) ? null : (System.DateTime?)dataRow["ExpiryDate"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobPricing"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserJobPricing Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobPricing entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region JobItemsTypeIdSource	
			if (CanDeepLoad(entity, "JobItemsType|JobItemsTypeIdSource", deepLoadType, innerList) 
				&& entity.JobItemsTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.JobItemsTypeId;
				JobItemsType tmpEntity = EntityManager.LocateEntity<JobItemsType>(EntityLocator.ConstructKeyFromPkItems(typeof(JobItemsType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobItemsTypeIdSource = tmpEntity;
				else
					entity.JobItemsTypeIdSource = DataRepository.JobItemsTypeProvider.GetByJobItemTypeId(transactionManager, entity.JobItemsTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobItemsTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobItemsTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobItemsTypeProvider.DeepLoad(transactionManager, entity.JobItemsTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobItemsTypeIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdvertiserJobPricing object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdvertiserJobPricing instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserJobPricing Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobPricing entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region JobItemsTypeIdSource
			if (CanDeepSave(entity, "JobItemsType|JobItemsTypeIdSource", deepSaveType, innerList) 
				&& entity.JobItemsTypeIdSource != null)
			{
				DataRepository.JobItemsTypeProvider.Save(transactionManager, entity.JobItemsTypeIdSource);
				entity.JobItemsTypeId = entity.JobItemsTypeIdSource.JobItemTypeId;
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
	
	#region AdvertiserJobPricingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdvertiserJobPricing</c>
	///</summary>
	public enum AdvertiserJobPricingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>JobItemsType</c> at JobItemsTypeIdSource
		///</summary>
		[ChildEntityType(typeof(JobItemsType))]
		JobItemsType,
		}
	
	#endregion AdvertiserJobPricingChildEntityTypes
	
	#region AdvertiserJobPricingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertiserJobPricingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingFilterBuilder : SqlFilterBuilder<AdvertiserJobPricingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilterBuilder class.
		/// </summary>
		public AdvertiserJobPricingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobPricingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobPricingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobPricingFilterBuilder
	
	#region AdvertiserJobPricingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertiserJobPricingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingParameterBuilder : ParameterizedSqlFilterBuilder<AdvertiserJobPricingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingParameterBuilder class.
		/// </summary>
		public AdvertiserJobPricingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobPricingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobPricingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobPricingParameterBuilder
	
	#region AdvertiserJobPricingSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertiserJobPricingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertiserJobPricingSortBuilder : SqlSortBuilder<AdvertiserJobPricingColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingSqlSortBuilder class.
		/// </summary>
		public AdvertiserJobPricingSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertiserJobPricingSortBuilder
	
} // end namespace
