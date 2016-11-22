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
	/// This class is the base class for any <see cref="AdvertisersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertisersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Advertisers, JXTPortal.Entities.AdvertisersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByJobItemsTypeIdFromAdvertiserJobPricing
		
		/// <summary>
		///		Gets Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="_jobItemsTypeId"></param>
		/// <returns>Returns a typed collection of Advertisers objects.</returns>
		public TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(null,_jobItemsTypeId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets JXTPortal.Entities.Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Advertisers objects.</returns>
		public TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(System.Int32 _jobItemsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(null, _jobItemsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Advertisers objects.</returns>
		public TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32 _jobItemsTypeId)
		{
			int count = -1;
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(transactionManager, _jobItemsTypeId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Advertisers objects.</returns>
		public TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32 _jobItemsTypeId,int start, int pageLength)
		{
			int count = -1;
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(transactionManager, _jobItemsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="_jobItemsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Advertisers objects.</returns>
		public TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(System.Int32 _jobItemsTypeId,int start, int pageLength, out int count)
		{
			
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(null, _jobItemsTypeId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Advertisers objects from the datasource by JobItemsTypeID in the
		///		AdvertiserJobPricing table. Table Advertisers is related to table JobItemsType
		///		through the (M:N) relationship defined in the AdvertiserJobPricing table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_jobItemsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Advertisers objects.</returns>
		public abstract TList<Advertisers> GetByJobItemsTypeIdFromAdvertiserJobPricing(TransactionManager transactionManager,System.Int32 _jobItemsTypeId, int start, int pageLength, out int count);
		
		#endregion GetByJobItemsTypeIdFromAdvertiserJobPricing
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertisersKey key)
		{
			return Delete(transactionManager, key.AdvertiserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserId)
		{
			return Delete(null, _advertiserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		FK__Advertise__Adver__0559BDD1 Description: 
		/// </summary>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountStatusId(System.Int32 _advertiserAccountStatusId)
		{
			int count = -1;
			return GetByAdvertiserAccountStatusId(_advertiserAccountStatusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		FK__Advertise__Adver__0559BDD1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		/// <remarks></remarks>
		public TList<Advertisers> GetByAdvertiserAccountStatusId(TransactionManager transactionManager, System.Int32 _advertiserAccountStatusId)
		{
			int count = -1;
			return GetByAdvertiserAccountStatusId(transactionManager, _advertiserAccountStatusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		FK__Advertise__Adver__0559BDD1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountStatusId(TransactionManager transactionManager, System.Int32 _advertiserAccountStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserAccountStatusId(transactionManager, _advertiserAccountStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		fkAdvertiseAdver0559Bdd1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountStatusId(System.Int32 _advertiserAccountStatusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserAccountStatusId(null, _advertiserAccountStatusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		fkAdvertiseAdver0559Bdd1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountStatusId(System.Int32 _advertiserAccountStatusId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserAccountStatusId(null, _advertiserAccountStatusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__0559BDD1 key.
		///		FK__Advertise__Adver__0559BDD1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public abstract TList<Advertisers> GetByAdvertiserAccountStatusId(TransactionManager transactionManager, System.Int32 _advertiserAccountStatusId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		FK__Advertise__Adver__064DE20A Description: 
		/// </summary>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(_advertiserBusinessTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		FK__Advertise__Adver__064DE20A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		/// <remarks></remarks>
		public TList<Advertisers> GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(transactionManager, _advertiserBusinessTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		FK__Advertise__Adver__064DE20A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserBusinessTypeId(transactionManager, _advertiserBusinessTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		fkAdvertiseAdver064De20a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserBusinessTypeId(null, _advertiserBusinessTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		fkAdvertiseAdver064De20a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserBusinessTypeId(System.Int32 _advertiserBusinessTypeId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserBusinessTypeId(null, _advertiserBusinessTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__064DE20A key.
		///		FK__Advertise__Adver__064DE20A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserBusinessTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public abstract TList<Advertisers> GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32 _advertiserBusinessTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		FK__Advertise__Adver__07420643 Description: 
		/// </summary>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(_advertiserAccountTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		FK__Advertise__Adver__07420643 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		/// <remarks></remarks>
		public TList<Advertisers> GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(transactionManager, _advertiserAccountTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		FK__Advertise__Adver__07420643 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserAccountTypeId(transactionManager, _advertiserAccountTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		fkAdvertiseAdver07420643 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserAccountTypeId(null, _advertiserAccountTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		fkAdvertiseAdver07420643 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByAdvertiserAccountTypeId(System.Int32 _advertiserAccountTypeId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserAccountTypeId(null, _advertiserAccountTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__07420643 key.
		///		FK__Advertise__Adver__07420643 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserAccountTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public abstract TList<Advertisers> GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32 _advertiserAccountTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		FK__Advertise__LastM__092A4EB5 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		FK__Advertise__LastM__092A4EB5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		/// <remarks></remarks>
		public TList<Advertisers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		FK__Advertise__LastM__092A4EB5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		fkAdvertiseLastm092a4Eb5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		fkAdvertiseLastm092a4Eb5 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__092A4EB5 key.
		///		FK__Advertise__LastM__092A4EB5 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public abstract TList<Advertisers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		FK__Advertise__SiteI__08362A7C Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetBySiteId(System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		FK__Advertise__SiteI__08362A7C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		/// <remarks></remarks>
		public TList<Advertisers> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		FK__Advertise__SiteI__08362A7C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		fkAdvertiseSitei08362a7c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetBySiteId(System.Int32? _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		fkAdvertiseSitei08362a7c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public TList<Advertisers> GetBySiteId(System.Int32? _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__SiteI__08362A7C key.
		///		FK__Advertise__SiteI__08362A7C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Advertisers objects.</returns>
		public abstract TList<Advertisers> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Advertisers Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertisersKey key, int start, int pageLength)
		{
			return GetByAdvertiserId(transactionManager, key.AdvertiserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public JXTPortal.Entities.Advertisers GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(null,_advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public JXTPortal.Entities.Advertisers GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public JXTPortal.Entities.Advertisers GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public JXTPortal.Entities.Advertisers GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public JXTPortal.Entities.Advertisers GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Advert__01892CED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Advertisers"/> class.</returns>
		public abstract JXTPortal.Entities.Advertisers GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Advertisers_CustomGetActivityReport 
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetActivityReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="isDesc"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetActivityReport(System.Int32? siteId, System.String keyword, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.Boolean? isDesc)
		{
			return CustomGetActivityReport(null, 0, int.MaxValue , siteId, keyword, dateFrom, dateTo, pageIndex, pageSize, orderBy, isDesc);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetActivityReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="isDesc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetActivityReport(int start, int pageLength, System.Int32? siteId, System.String keyword, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.Boolean? isDesc)
		{
			return CustomGetActivityReport(null, start, pageLength , siteId, keyword, dateFrom, dateTo, pageIndex, pageSize, orderBy, isDesc);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetActivityReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="isDesc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetActivityReport(TransactionManager transactionManager, System.Int32? siteId, System.String keyword, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.Boolean? isDesc)
		{
			return CustomGetActivityReport(transactionManager, 0, int.MaxValue , siteId, keyword, dateFrom, dateTo, pageIndex, pageSize, orderBy, isDesc);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetActivityReport' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="isDesc"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetActivityReport(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String keyword, System.DateTime? dateFrom, System.DateTime? dateTo, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.Boolean? isDesc);
		
		#endregion
		
		#region Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeIdFromAdvertiserJobPricing(System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(null, 0, int.MaxValue , jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeIdFromAdvertiserJobPricing(int start, int pageLength, System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(null, start, pageLength , jobItemsTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobItemsTypeIdFromAdvertiserJobPricing(TransactionManager transactionManager, System.Int32? jobItemsTypeId)
		{
			return GetByJobItemsTypeIdFromAdvertiserJobPricing(transactionManager, 0, int.MaxValue , jobItemsTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByJobItemsTypeIdFromAdvertiserJobPricing' stored procedure. 
		/// </summary>
		/// <param name="jobItemsTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobItemsTypeIdFromAdvertiserJobPricing(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobItemsTypeId);
		
		#endregion
		
		#region Advertisers_Find 
		
		/// <summary>
		///	This method wrap the 'Advertisers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl);
		
		#endregion
		
		#region Advertisers_Update 
		
		/// <summary>
		///	This method wrap the 'Advertisers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			 Update(null, 0, int.MaxValue , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			 Update(null, start, pageLength , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl);
		
		#endregion
		
		#region Advertisers_GetAdvertisersNotPostedSince 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertisersNotPostedSince' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="daysSinceLastPost"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertisersNotPostedSince(System.Int32? siteId, System.Int32? daysSinceLastPost)
		{
			return GetAdvertisersNotPostedSince(null, 0, int.MaxValue , siteId, daysSinceLastPost);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertisersNotPostedSince' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="daysSinceLastPost"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertisersNotPostedSince(int start, int pageLength, System.Int32? siteId, System.Int32? daysSinceLastPost)
		{
			return GetAdvertisersNotPostedSince(null, start, pageLength , siteId, daysSinceLastPost);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertisersNotPostedSince' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="daysSinceLastPost"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertisersNotPostedSince(TransactionManager transactionManager, System.Int32? siteId, System.Int32? daysSinceLastPost)
		{
			return GetAdvertisersNotPostedSince(transactionManager, 0, int.MaxValue , siteId, daysSinceLastPost);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertisersNotPostedSince' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="daysSinceLastPost"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAdvertisersNotPostedSince(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? daysSinceLastPost);
		
		#endregion
		
		#region Advertisers_GetAdvertiserTypeStatistics 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserTypeStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserTypeStatistics(System.Int32? siteId)
		{
			return GetAdvertiserTypeStatistics(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserTypeStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserTypeStatistics(int start, int pageLength, System.Int32? siteId)
		{
			return GetAdvertiserTypeStatistics(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserTypeStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserTypeStatistics(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetAdvertiserTypeStatistics(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserTypeStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAdvertiserTypeStatistics(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Advertisers_AdminGetPaged 
		
		/// <summary>
		///	This method wrap the 'Advertisers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, 0, int.MaxValue , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(int start, int pageLength, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, start, pageLength , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(transactionManager, 0, int.MaxValue , advertiserId, siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet AdminGetPaged(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region Advertisers_GetByAdvertiserAccountStatusId 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountStatusId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountStatusId(System.Int32? advertiserAccountStatusId)
		{
			return GetByAdvertiserAccountStatusId(null, 0, int.MaxValue , advertiserAccountStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountStatusId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountStatusId(int start, int pageLength, System.Int32? advertiserAccountStatusId)
		{
			return GetByAdvertiserAccountStatusId(null, start, pageLength , advertiserAccountStatusId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountStatusId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountStatusId(TransactionManager transactionManager, System.Int32? advertiserAccountStatusId)
		{
			return GetByAdvertiserAccountStatusId(transactionManager, 0, int.MaxValue , advertiserAccountStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountStatusId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserAccountStatusId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserAccountStatusId);
		
		#endregion
		
		#region Advertisers_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetPaged' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetPaged' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetPaged' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetPaged' stored procedure. 
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
		
		#region Advertisers_Delete 
		
		/// <summary>
		///	This method wrap the 'Advertisers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserId)
		{
			 Delete(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserId)
		{
			 Delete(null, start, pageLength , advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region Advertisers_Insert 
		
		/// <summary>
		///	This method wrap the 'Advertisers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl, ref System.Int32? advertiserId)
		{
			 Insert(null, 0, int.MaxValue , siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl, ref advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl, ref System.Int32? advertiserId)
		{
			 Insert(null, start, pageLength , siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl, ref advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl, ref System.Int32? advertiserId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, advertiserAccountTypeId, advertiserBusinessTypeId, advertiserAccountStatusId, companyName, businessNumber, streetAddress1, streetAddress2, lastModified, lastModifiedBy, postalAddress1, postalAddress2, webAddress, noOfEmployees, firstApprovedDate, profile, charityNumber, searchField, freeTrialStartDate, freeTrialEndDate, accountsPayableEmail, requireLogonForExternalApplication, advertiserLogo, linkedInLogo, linkedInCompanyId, linkedInEmail, registerDate, externalAdvertiserId, videoLink, industry, nominatedCompanyRole, nominatedCompanyFirstName, nominatedCompanyLastName, nominatedCompanyEmailAddress, nominatedCompanyPhone, preferredContactMethod, advertiserLogoUrl, ref advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserAccountStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="companyName"> A <c>System.String</c> instance.</param>
		/// <param name="businessNumber"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="streetAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="postalAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="postalAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="webAddress"> A <c>System.String</c> instance.</param>
		/// <param name="noOfEmployees"> A <c>System.String</c> instance.</param>
		/// <param name="firstApprovedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="profile"> A <c>System.String</c> instance.</param>
		/// <param name="charityNumber"> A <c>System.String</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="freeTrialStartDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="freeTrialEndDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="accountsPayableEmail"> A <c>System.String</c> instance.</param>
		/// <param name="requireLogonForExternalApplication"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="registerDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="externalAdvertiserId"> A <c>System.String</c> instance.</param>
		/// <param name="videoLink"> A <c>System.String</c> instance.</param>
		/// <param name="industry"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyRole"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyLastName"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="nominatedCompanyPhone"> A <c>System.String</c> instance.</param>
		/// <param name="preferredContactMethod"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserAccountTypeId, System.Int32? advertiserBusinessTypeId, System.Int32? advertiserAccountStatusId, System.String companyName, System.String businessNumber, System.String streetAddress1, System.String streetAddress2, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String postalAddress1, System.String postalAddress2, System.String webAddress, System.String noOfEmployees, System.DateTime? firstApprovedDate, System.String profile, System.String charityNumber, System.String searchField, System.DateTime? freeTrialStartDate, System.DateTime? freeTrialEndDate, System.String accountsPayableEmail, System.Boolean? requireLogonForExternalApplication, System.Byte[] advertiserLogo, System.String linkedInLogo, System.String linkedInCompanyId, System.String linkedInEmail, System.DateTime? registerDate, System.String externalAdvertiserId, System.String videoLink, System.String industry, System.String nominatedCompanyRole, System.String nominatedCompanyFirstName, System.String nominatedCompanyLastName, System.String nominatedCompanyEmailAddress, System.String nominatedCompanyPhone, System.Int32? preferredContactMethod, System.String advertiserLogoUrl, ref System.Int32? advertiserId);
		
		#endregion
		
		#region Advertisers_CustomGetAllAdvertisers 
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAllAdvertisers(System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetAllAdvertisers(null, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAllAdvertisers(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetAllAdvertisers(null, start, pageLength , siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetAllAdvertisers(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetAllAdvertisers(transactionManager, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetAllAdvertisers(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#region Advertisers_GetAllAdvertisers 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAdvertisers(System.Int32? siteId)
		{
			return GetAllAdvertisers(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAdvertisers(int start, int pageLength, System.Int32? siteId)
		{
			return GetAllAdvertisers(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllAdvertisers(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetAllAdvertisers(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllAdvertisers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAllAdvertisers(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Advertisers_GetAllJobStatistics 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllJobStatistics(System.Int32? siteId)
		{
			return GetAllJobStatistics(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllJobStatistics(int start, int pageLength, System.Int32? siteId)
		{
			return GetAllJobStatistics(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAllJobStatistics(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetAllJobStatistics(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAllJobStatistics' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAllJobStatistics(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Advertisers_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region Advertisers_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region Advertisers_GetAdvertiserCount 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserCount(System.Int32? siteId)
		{
			return GetAdvertiserCount(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserCount(int start, int pageLength, System.Int32? siteId)
		{
			return GetAdvertiserCount(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetAdvertiserCount(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetAdvertiserCount(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetAdvertiserCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetAdvertiserCount(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Advertisers_CustomGetExpiringJobAdvertiser 
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetExpiringJobAdvertiser' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="withInDays"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExpiringJobAdvertiser(System.Int32? siteId, System.Int32? withInDays)
		{
			return CustomGetExpiringJobAdvertiser(null, 0, int.MaxValue , siteId, withInDays);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetExpiringJobAdvertiser' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="withInDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExpiringJobAdvertiser(int start, int pageLength, System.Int32? siteId, System.Int32? withInDays)
		{
			return CustomGetExpiringJobAdvertiser(null, start, pageLength , siteId, withInDays);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetExpiringJobAdvertiser' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="withInDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExpiringJobAdvertiser(TransactionManager transactionManager, System.Int32? siteId, System.Int32? withInDays)
		{
			return CustomGetExpiringJobAdvertiser(transactionManager, 0, int.MaxValue , siteId, withInDays);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_CustomGetExpiringJobAdvertiser' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="withInDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetExpiringJobAdvertiser(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? withInDays);
		
		#endregion
		
		#region Advertisers_GetByAdvertiserBusinessTypeId 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(null, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(int start, int pageLength, System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(null, start, pageLength , advertiserBusinessTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, System.Int32? advertiserBusinessTypeId)
		{
			return GetByAdvertiserBusinessTypeId(transactionManager, 0, int.MaxValue , advertiserBusinessTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserBusinessTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserBusinessTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserBusinessTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserBusinessTypeId);
		
		#endregion
		
		#region Advertisers_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Advertisers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Advertisers_GetByAdvertiserAccountTypeId 
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountTypeId(System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(null, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountTypeId(int start, int pageLength, System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(null, start, pageLength , advertiserAccountTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserAccountTypeId(TransactionManager transactionManager, System.Int32? advertiserAccountTypeId)
		{
			return GetByAdvertiserAccountTypeId(transactionManager, 0, int.MaxValue , advertiserAccountTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_GetByAdvertiserAccountTypeId' stored procedure. 
		/// </summary>
		/// <param name="advertiserAccountTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserAccountTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserAccountTypeId);
		
		#endregion
		
		#region Advertisers_Get_List 
		
		/// <summary>
		///	This method wrap the 'Advertisers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Get_List' stored procedure. 
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
		///	This method wrap the 'Advertisers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Advertisers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Advertisers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Advertisers&gt;"/></returns>
		public static TList<Advertisers> Fill(IDataReader reader, TList<Advertisers> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Advertisers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Advertisers")
					.Append("|").Append((System.Int32)reader[((int)AdvertisersColumn.AdvertiserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Advertisers>(
					key.ToString(), // EntityTrackingKey
					"Advertisers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Advertisers();
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
					c.AdvertiserId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserId - 1)];
					c.SiteId = (reader.IsDBNull(((int)AdvertisersColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)AdvertisersColumn.SiteId - 1)];
					c.AdvertiserAccountTypeId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserAccountTypeId - 1)];
					c.AdvertiserBusinessTypeId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserBusinessTypeId - 1)];
					c.AdvertiserAccountStatusId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserAccountStatusId - 1)];
					c.CompanyName = (reader.IsDBNull(((int)AdvertisersColumn.CompanyName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.CompanyName - 1)];
					c.BusinessNumber = (reader.IsDBNull(((int)AdvertisersColumn.BusinessNumber - 1)))?null:(System.String)reader[((int)AdvertisersColumn.BusinessNumber - 1)];
					c.StreetAddress1 = (reader.IsDBNull(((int)AdvertisersColumn.StreetAddress1 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.StreetAddress1 - 1)];
					c.StreetAddress2 = (reader.IsDBNull(((int)AdvertisersColumn.StreetAddress2 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.StreetAddress2 - 1)];
					c.LastModified = (System.DateTime)reader[((int)AdvertisersColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)AdvertisersColumn.LastModifiedBy - 1)];
					c.PostalAddress1 = (reader.IsDBNull(((int)AdvertisersColumn.PostalAddress1 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.PostalAddress1 - 1)];
					c.PostalAddress2 = (reader.IsDBNull(((int)AdvertisersColumn.PostalAddress2 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.PostalAddress2 - 1)];
					c.WebAddress = (reader.IsDBNull(((int)AdvertisersColumn.WebAddress - 1)))?null:(System.String)reader[((int)AdvertisersColumn.WebAddress - 1)];
					c.NoOfEmployees = (reader.IsDBNull(((int)AdvertisersColumn.NoOfEmployees - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NoOfEmployees - 1)];
					c.FirstApprovedDate = (reader.IsDBNull(((int)AdvertisersColumn.FirstApprovedDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FirstApprovedDate - 1)];
					c.Profile = (reader.IsDBNull(((int)AdvertisersColumn.Profile - 1)))?null:(System.String)reader[((int)AdvertisersColumn.Profile - 1)];
					c.CharityNumber = (reader.IsDBNull(((int)AdvertisersColumn.CharityNumber - 1)))?null:(System.String)reader[((int)AdvertisersColumn.CharityNumber - 1)];
					c.SearchField = (reader.IsDBNull(((int)AdvertisersColumn.SearchField - 1)))?null:(System.String)reader[((int)AdvertisersColumn.SearchField - 1)];
					c.FreeTrialStartDate = (reader.IsDBNull(((int)AdvertisersColumn.FreeTrialStartDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FreeTrialStartDate - 1)];
					c.FreeTrialEndDate = (reader.IsDBNull(((int)AdvertisersColumn.FreeTrialEndDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FreeTrialEndDate - 1)];
					c.AccountsPayableEmail = (reader.IsDBNull(((int)AdvertisersColumn.AccountsPayableEmail - 1)))?null:(System.String)reader[((int)AdvertisersColumn.AccountsPayableEmail - 1)];
					c.RequireLogonForExternalApplication = (System.Boolean)reader[((int)AdvertisersColumn.RequireLogonForExternalApplication - 1)];
					c.AdvertiserLogo = (reader.IsDBNull(((int)AdvertisersColumn.AdvertiserLogo - 1)))?null:(System.Byte[])reader[((int)AdvertisersColumn.AdvertiserLogo - 1)];
					c.LinkedInLogo = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInLogo - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInLogo - 1)];
					c.LinkedInCompanyId = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInCompanyId - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInCompanyId - 1)];
					c.LinkedInEmail = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInEmail - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInEmail - 1)];
					c.RegisterDate = (reader.IsDBNull(((int)AdvertisersColumn.RegisterDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.RegisterDate - 1)];
					c.ExternalAdvertiserId = (reader.IsDBNull(((int)AdvertisersColumn.ExternalAdvertiserId - 1)))?null:(System.String)reader[((int)AdvertisersColumn.ExternalAdvertiserId - 1)];
					c.VideoLink = (reader.IsDBNull(((int)AdvertisersColumn.VideoLink - 1)))?null:(System.String)reader[((int)AdvertisersColumn.VideoLink - 1)];
					c.Industry = (reader.IsDBNull(((int)AdvertisersColumn.Industry - 1)))?null:(System.String)reader[((int)AdvertisersColumn.Industry - 1)];
					c.NominatedCompanyRole = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyRole - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyRole - 1)];
					c.NominatedCompanyFirstName = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyFirstName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyFirstName - 1)];
					c.NominatedCompanyLastName = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyLastName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyLastName - 1)];
					c.NominatedCompanyEmailAddress = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyEmailAddress - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyEmailAddress - 1)];
					c.NominatedCompanyPhone = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyPhone - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyPhone - 1)];
					c.PreferredContactMethod = (reader.IsDBNull(((int)AdvertisersColumn.PreferredContactMethod - 1)))?null:(System.Int32?)reader[((int)AdvertisersColumn.PreferredContactMethod - 1)];
					c.AdvertiserLogoUrl = (reader.IsDBNull(((int)AdvertisersColumn.AdvertiserLogoUrl - 1)))?null:(System.String)reader[((int)AdvertisersColumn.AdvertiserLogoUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Advertisers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Advertisers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Advertisers entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserId - 1)];
			entity.SiteId = (reader.IsDBNull(((int)AdvertisersColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)AdvertisersColumn.SiteId - 1)];
			entity.AdvertiserAccountTypeId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserAccountTypeId - 1)];
			entity.AdvertiserBusinessTypeId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserBusinessTypeId - 1)];
			entity.AdvertiserAccountStatusId = (System.Int32)reader[((int)AdvertisersColumn.AdvertiserAccountStatusId - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)AdvertisersColumn.CompanyName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.CompanyName - 1)];
			entity.BusinessNumber = (reader.IsDBNull(((int)AdvertisersColumn.BusinessNumber - 1)))?null:(System.String)reader[((int)AdvertisersColumn.BusinessNumber - 1)];
			entity.StreetAddress1 = (reader.IsDBNull(((int)AdvertisersColumn.StreetAddress1 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.StreetAddress1 - 1)];
			entity.StreetAddress2 = (reader.IsDBNull(((int)AdvertisersColumn.StreetAddress2 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.StreetAddress2 - 1)];
			entity.LastModified = (System.DateTime)reader[((int)AdvertisersColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)AdvertisersColumn.LastModifiedBy - 1)];
			entity.PostalAddress1 = (reader.IsDBNull(((int)AdvertisersColumn.PostalAddress1 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.PostalAddress1 - 1)];
			entity.PostalAddress2 = (reader.IsDBNull(((int)AdvertisersColumn.PostalAddress2 - 1)))?null:(System.String)reader[((int)AdvertisersColumn.PostalAddress2 - 1)];
			entity.WebAddress = (reader.IsDBNull(((int)AdvertisersColumn.WebAddress - 1)))?null:(System.String)reader[((int)AdvertisersColumn.WebAddress - 1)];
			entity.NoOfEmployees = (reader.IsDBNull(((int)AdvertisersColumn.NoOfEmployees - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NoOfEmployees - 1)];
			entity.FirstApprovedDate = (reader.IsDBNull(((int)AdvertisersColumn.FirstApprovedDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FirstApprovedDate - 1)];
			entity.Profile = (reader.IsDBNull(((int)AdvertisersColumn.Profile - 1)))?null:(System.String)reader[((int)AdvertisersColumn.Profile - 1)];
			entity.CharityNumber = (reader.IsDBNull(((int)AdvertisersColumn.CharityNumber - 1)))?null:(System.String)reader[((int)AdvertisersColumn.CharityNumber - 1)];
			entity.SearchField = (reader.IsDBNull(((int)AdvertisersColumn.SearchField - 1)))?null:(System.String)reader[((int)AdvertisersColumn.SearchField - 1)];
			entity.FreeTrialStartDate = (reader.IsDBNull(((int)AdvertisersColumn.FreeTrialStartDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FreeTrialStartDate - 1)];
			entity.FreeTrialEndDate = (reader.IsDBNull(((int)AdvertisersColumn.FreeTrialEndDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.FreeTrialEndDate - 1)];
			entity.AccountsPayableEmail = (reader.IsDBNull(((int)AdvertisersColumn.AccountsPayableEmail - 1)))?null:(System.String)reader[((int)AdvertisersColumn.AccountsPayableEmail - 1)];
			entity.RequireLogonForExternalApplication = (System.Boolean)reader[((int)AdvertisersColumn.RequireLogonForExternalApplication - 1)];
			entity.AdvertiserLogo = (reader.IsDBNull(((int)AdvertisersColumn.AdvertiserLogo - 1)))?null:(System.Byte[])reader[((int)AdvertisersColumn.AdvertiserLogo - 1)];
			entity.LinkedInLogo = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInLogo - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInLogo - 1)];
			entity.LinkedInCompanyId = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInCompanyId - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInCompanyId - 1)];
			entity.LinkedInEmail = (reader.IsDBNull(((int)AdvertisersColumn.LinkedInEmail - 1)))?null:(System.String)reader[((int)AdvertisersColumn.LinkedInEmail - 1)];
			entity.RegisterDate = (reader.IsDBNull(((int)AdvertisersColumn.RegisterDate - 1)))?null:(System.DateTime?)reader[((int)AdvertisersColumn.RegisterDate - 1)];
			entity.ExternalAdvertiserId = (reader.IsDBNull(((int)AdvertisersColumn.ExternalAdvertiserId - 1)))?null:(System.String)reader[((int)AdvertisersColumn.ExternalAdvertiserId - 1)];
			entity.VideoLink = (reader.IsDBNull(((int)AdvertisersColumn.VideoLink - 1)))?null:(System.String)reader[((int)AdvertisersColumn.VideoLink - 1)];
			entity.Industry = (reader.IsDBNull(((int)AdvertisersColumn.Industry - 1)))?null:(System.String)reader[((int)AdvertisersColumn.Industry - 1)];
			entity.NominatedCompanyRole = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyRole - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyRole - 1)];
			entity.NominatedCompanyFirstName = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyFirstName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyFirstName - 1)];
			entity.NominatedCompanyLastName = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyLastName - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyLastName - 1)];
			entity.NominatedCompanyEmailAddress = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyEmailAddress - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyEmailAddress - 1)];
			entity.NominatedCompanyPhone = (reader.IsDBNull(((int)AdvertisersColumn.NominatedCompanyPhone - 1)))?null:(System.String)reader[((int)AdvertisersColumn.NominatedCompanyPhone - 1)];
			entity.PreferredContactMethod = (reader.IsDBNull(((int)AdvertisersColumn.PreferredContactMethod - 1)))?null:(System.Int32?)reader[((int)AdvertisersColumn.PreferredContactMethod - 1)];
			entity.AdvertiserLogoUrl = (reader.IsDBNull(((int)AdvertisersColumn.AdvertiserLogoUrl - 1)))?null:(System.String)reader[((int)AdvertisersColumn.AdvertiserLogoUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Advertisers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Advertisers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Advertisers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.AdvertiserAccountTypeId = (System.Int32)dataRow["AdvertiserAccountTypeID"];
			entity.AdvertiserBusinessTypeId = (System.Int32)dataRow["AdvertiserBusinessTypeID"];
			entity.AdvertiserAccountStatusId = (System.Int32)dataRow["AdvertiserAccountStatusID"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.BusinessNumber = Convert.IsDBNull(dataRow["BusinessNumber"]) ? null : (System.String)dataRow["BusinessNumber"];
			entity.StreetAddress1 = Convert.IsDBNull(dataRow["StreetAddress1"]) ? null : (System.String)dataRow["StreetAddress1"];
			entity.StreetAddress2 = Convert.IsDBNull(dataRow["StreetAddress2"]) ? null : (System.String)dataRow["StreetAddress2"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.PostalAddress1 = Convert.IsDBNull(dataRow["PostalAddress1"]) ? null : (System.String)dataRow["PostalAddress1"];
			entity.PostalAddress2 = Convert.IsDBNull(dataRow["PostalAddress2"]) ? null : (System.String)dataRow["PostalAddress2"];
			entity.WebAddress = Convert.IsDBNull(dataRow["WebAddress"]) ? null : (System.String)dataRow["WebAddress"];
			entity.NoOfEmployees = Convert.IsDBNull(dataRow["NoOfEmployees"]) ? null : (System.String)dataRow["NoOfEmployees"];
			entity.FirstApprovedDate = Convert.IsDBNull(dataRow["FirstApprovedDate"]) ? null : (System.DateTime?)dataRow["FirstApprovedDate"];
			entity.Profile = Convert.IsDBNull(dataRow["Profile"]) ? null : (System.String)dataRow["Profile"];
			entity.CharityNumber = Convert.IsDBNull(dataRow["CharityNumber"]) ? null : (System.String)dataRow["CharityNumber"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.FreeTrialStartDate = Convert.IsDBNull(dataRow["FreeTrialStartDate"]) ? null : (System.DateTime?)dataRow["FreeTrialStartDate"];
			entity.FreeTrialEndDate = Convert.IsDBNull(dataRow["FreeTrialEndDate"]) ? null : (System.DateTime?)dataRow["FreeTrialEndDate"];
			entity.AccountsPayableEmail = Convert.IsDBNull(dataRow["AccountsPayableEmail"]) ? null : (System.String)dataRow["AccountsPayableEmail"];
			entity.RequireLogonForExternalApplication = (System.Boolean)dataRow["RequireLogonForExternalApplication"];
			entity.AdvertiserLogo = Convert.IsDBNull(dataRow["AdvertiserLogo"]) ? null : (System.Byte[])dataRow["AdvertiserLogo"];
			entity.LinkedInLogo = Convert.IsDBNull(dataRow["LinkedInLogo"]) ? null : (System.String)dataRow["LinkedInLogo"];
			entity.LinkedInCompanyId = Convert.IsDBNull(dataRow["LinkedInCompanyId"]) ? null : (System.String)dataRow["LinkedInCompanyId"];
			entity.LinkedInEmail = Convert.IsDBNull(dataRow["LinkedInEmail"]) ? null : (System.String)dataRow["LinkedInEmail"];
			entity.RegisterDate = Convert.IsDBNull(dataRow["RegisterDate"]) ? null : (System.DateTime?)dataRow["RegisterDate"];
			entity.ExternalAdvertiserId = Convert.IsDBNull(dataRow["ExternalAdvertiserID"]) ? null : (System.String)dataRow["ExternalAdvertiserID"];
			entity.VideoLink = Convert.IsDBNull(dataRow["VideoLink"]) ? null : (System.String)dataRow["VideoLink"];
			entity.Industry = Convert.IsDBNull(dataRow["Industry"]) ? null : (System.String)dataRow["Industry"];
			entity.NominatedCompanyRole = Convert.IsDBNull(dataRow["NominatedCompanyRole"]) ? null : (System.String)dataRow["NominatedCompanyRole"];
			entity.NominatedCompanyFirstName = Convert.IsDBNull(dataRow["NominatedCompanyFirstName"]) ? null : (System.String)dataRow["NominatedCompanyFirstName"];
			entity.NominatedCompanyLastName = Convert.IsDBNull(dataRow["NominatedCompanyLastName"]) ? null : (System.String)dataRow["NominatedCompanyLastName"];
			entity.NominatedCompanyEmailAddress = Convert.IsDBNull(dataRow["NominatedCompanyEmailAddress"]) ? null : (System.String)dataRow["NominatedCompanyEmailAddress"];
			entity.NominatedCompanyPhone = Convert.IsDBNull(dataRow["NominatedCompanyPhone"]) ? null : (System.String)dataRow["NominatedCompanyPhone"];
			entity.PreferredContactMethod = Convert.IsDBNull(dataRow["PreferredContactMethod"]) ? null : (System.Int32?)dataRow["PreferredContactMethod"];
			entity.AdvertiserLogoUrl = Convert.IsDBNull(dataRow["AdvertiserLogoUrl"]) ? null : (System.String)dataRow["AdvertiserLogoUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Advertisers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Advertisers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Advertisers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserAccountStatusIdSource	
			if (CanDeepLoad(entity, "AdvertiserAccountStatus|AdvertiserAccountStatusIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserAccountStatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserAccountStatusId;
				AdvertiserAccountStatus tmpEntity = EntityManager.LocateEntity<AdvertiserAccountStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserAccountStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserAccountStatusIdSource = tmpEntity;
				else
					entity.AdvertiserAccountStatusIdSource = DataRepository.AdvertiserAccountStatusProvider.GetByAdvertiserAccountStatusId(transactionManager, entity.AdvertiserAccountStatusId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserAccountStatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserAccountStatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserAccountStatusProvider.DeepLoad(transactionManager, entity.AdvertiserAccountStatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserAccountStatusIdSource

			#region AdvertiserBusinessTypeIdSource	
			if (CanDeepLoad(entity, "AdvertiserBusinessType|AdvertiserBusinessTypeIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserBusinessTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserBusinessTypeId;
				AdvertiserBusinessType tmpEntity = EntityManager.LocateEntity<AdvertiserBusinessType>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserBusinessType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserBusinessTypeIdSource = tmpEntity;
				else
					entity.AdvertiserBusinessTypeIdSource = DataRepository.AdvertiserBusinessTypeProvider.GetByAdvertiserBusinessTypeId(transactionManager, entity.AdvertiserBusinessTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserBusinessTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserBusinessTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserBusinessTypeProvider.DeepLoad(transactionManager, entity.AdvertiserBusinessTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserBusinessTypeIdSource

			#region AdvertiserAccountTypeIdSource	
			if (CanDeepLoad(entity, "AdvertiserAccountType|AdvertiserAccountTypeIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserAccountTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserAccountTypeId;
				AdvertiserAccountType tmpEntity = EntityManager.LocateEntity<AdvertiserAccountType>(EntityLocator.ConstructKeyFromPkItems(typeof(AdvertiserAccountType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserAccountTypeIdSource = tmpEntity;
				else
					entity.AdvertiserAccountTypeIdSource = DataRepository.AdvertiserAccountTypeProvider.GetByAdvertiserAccountTypeId(transactionManager, entity.AdvertiserAccountTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserAccountTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserAccountTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertiserAccountTypeProvider.DeepLoad(transactionManager, entity.AdvertiserAccountTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserAccountTypeIdSource

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
				pkItems[0] = (entity.SiteId ?? (int)0);
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdSource = tmpEntity;
				else
					entity.SiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, (entity.SiteId ?? (int)0));		
				
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
			// Deep load child collections  - Call GetByAdvertiserId methods when available
			
			#region AdvertiserUsersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserUsers>|AdvertiserUsersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUsersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserUsersCollection = DataRepository.AdvertiserUsersProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.AdvertiserUsersCollection.Count > 0)
				{
					deepHandles.Add("AdvertiserUsersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserUsers>) DataRepository.AdvertiserUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserUsersCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsCollection = DataRepository.JobsProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteAdvertiserFilterCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteAdvertiserFilter>|SiteAdvertiserFilterCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteAdvertiserFilterCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteAdvertiserFilterCollection = DataRepository.SiteAdvertiserFilterProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.SiteAdvertiserFilterCollection.Count > 0)
				{
					deepHandles.Add("SiteAdvertiserFilterCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteAdvertiserFilter>) DataRepository.SiteAdvertiserFilterProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteAdvertiserFilterCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<JobItemsType>|JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing", deepLoadType, innerList))
			{
				entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing = DataRepository.JobItemsTypeProvider.GetByAdvertiserIdFromAdvertiserJobPricing(transactionManager, entity.AdvertiserId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing != null)
				{
					deepHandles.Add("JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< JobItemsType >) DataRepository.JobItemsTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing, deep, deepLoadType, childTypes, innerList }
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

				entity.AdvertiserJobPricingCollection = DataRepository.AdvertiserJobPricingProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.AdvertiserJobPricingCollection.Count > 0)
				{
					deepHandles.Add("AdvertiserJobPricingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserJobPricing>) DataRepository.AdvertiserJobPricingProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserJobPricingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobCustomXmlCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobCustomXml>|JobCustomXmlCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobCustomXmlCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobCustomXmlCollection = DataRepository.JobCustomXmlProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.JobCustomXmlCollection.Count > 0)
				{
					deepHandles.Add("JobCustomXmlCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobCustomXml>) DataRepository.JobCustomXmlProvider.DeepLoad,
						new object[] { transactionManager, entity.JobCustomXmlCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertiserJobTemplateLogoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserJobTemplateLogo>|AdvertiserJobTemplateLogoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserJobTemplateLogoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserJobTemplateLogoCollection = DataRepository.AdvertiserJobTemplateLogoProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.AdvertiserJobTemplateLogoCollection.Count > 0)
				{
					deepHandles.Add("AdvertiserJobTemplateLogoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserJobTemplateLogo>) DataRepository.AdvertiserJobTemplateLogoProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserJobTemplateLogoCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobTemplates>|JobTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobTemplatesCollection = DataRepository.JobTemplatesProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

				if (deep && entity.JobTemplatesCollection.Count > 0)
				{
					deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobTemplates>) DataRepository.JobTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobTemplatesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Advertisers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Advertisers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Advertisers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Advertisers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdvertiserAccountStatusIdSource
			if (CanDeepSave(entity, "AdvertiserAccountStatus|AdvertiserAccountStatusIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserAccountStatusIdSource != null)
			{
				DataRepository.AdvertiserAccountStatusProvider.Save(transactionManager, entity.AdvertiserAccountStatusIdSource);
				entity.AdvertiserAccountStatusId = entity.AdvertiserAccountStatusIdSource.AdvertiserAccountStatusId;
			}
			#endregion 
			
			#region AdvertiserBusinessTypeIdSource
			if (CanDeepSave(entity, "AdvertiserBusinessType|AdvertiserBusinessTypeIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserBusinessTypeIdSource != null)
			{
				DataRepository.AdvertiserBusinessTypeProvider.Save(transactionManager, entity.AdvertiserBusinessTypeIdSource);
				entity.AdvertiserBusinessTypeId = entity.AdvertiserBusinessTypeIdSource.AdvertiserBusinessTypeId;
			}
			#endregion 
			
			#region AdvertiserAccountTypeIdSource
			if (CanDeepSave(entity, "AdvertiserAccountType|AdvertiserAccountTypeIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserAccountTypeIdSource != null)
			{
				DataRepository.AdvertiserAccountTypeProvider.Save(transactionManager, entity.AdvertiserAccountTypeIdSource);
				entity.AdvertiserAccountTypeId = entity.AdvertiserAccountTypeIdSource.AdvertiserAccountTypeId;
			}
			#endregion 
			
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

			#region JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing>
			if (CanDeepSave(entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing, "List<JobItemsType>|JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing", deepSaveType, innerList))
			{
				if (entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing.Count > 0 || entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing.DeletedItems.Count > 0)
				{
					DataRepository.JobItemsTypeProvider.Save(transactionManager, entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing); 
					deepHandles.Add("JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<JobItemsType>) DataRepository.JobItemsTypeProvider.DeepSave,
						new object[] { transactionManager, entity.JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<AdvertiserUsers>
				if (CanDeepSave(entity.AdvertiserUsersCollection, "List<AdvertiserUsers>|AdvertiserUsersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserUsers child in entity.AdvertiserUsersCollection)
					{
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
						}

					}

					if (entity.AdvertiserUsersCollection.Count > 0 || entity.AdvertiserUsersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUsersCollection);
						
						deepHandles.Add("AdvertiserUsersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserUsers >) DataRepository.AdvertiserUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserUsersCollection, deepSaveType, childTypes, innerList }
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
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
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
				
	
			#region List<SiteAdvertiserFilter>
				if (CanDeepSave(entity.SiteAdvertiserFilterCollection, "List<SiteAdvertiserFilter>|SiteAdvertiserFilterCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteAdvertiserFilter child in entity.SiteAdvertiserFilterCollection)
					{
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
						}

					}

					if (entity.SiteAdvertiserFilterCollection.Count > 0 || entity.SiteAdvertiserFilterCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteAdvertiserFilterProvider.Save(transactionManager, entity.SiteAdvertiserFilterCollection);
						
						deepHandles.Add("SiteAdvertiserFilterCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteAdvertiserFilter >) DataRepository.SiteAdvertiserFilterProvider.DeepSave,
							new object[] { transactionManager, entity.SiteAdvertiserFilterCollection, deepSaveType, childTypes, innerList }
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
						if(child.AdvertiserIdSource != null)
						{
								child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}

						if(child.JobItemsTypeIdSource != null)
						{
								child.JobItemsTypeId = child.JobItemsTypeIdSource.JobItemTypeId;
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
				
	
			#region List<JobCustomXml>
				if (CanDeepSave(entity.JobCustomXmlCollection, "List<JobCustomXml>|JobCustomXmlCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobCustomXml child in entity.JobCustomXmlCollection)
					{
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
						}

					}

					if (entity.JobCustomXmlCollection.Count > 0 || entity.JobCustomXmlCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobCustomXmlProvider.Save(transactionManager, entity.JobCustomXmlCollection);
						
						deepHandles.Add("JobCustomXmlCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobCustomXml >) DataRepository.JobCustomXmlProvider.DeepSave,
							new object[] { transactionManager, entity.JobCustomXmlCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AdvertiserJobTemplateLogo>
				if (CanDeepSave(entity.AdvertiserJobTemplateLogoCollection, "List<AdvertiserJobTemplateLogo>|AdvertiserJobTemplateLogoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserJobTemplateLogo child in entity.AdvertiserJobTemplateLogoCollection)
					{
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
						}

					}

					if (entity.AdvertiserJobTemplateLogoCollection.Count > 0 || entity.AdvertiserJobTemplateLogoCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserJobTemplateLogoProvider.Save(transactionManager, entity.AdvertiserJobTemplateLogoCollection);
						
						deepHandles.Add("AdvertiserJobTemplateLogoCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserJobTemplateLogo >) DataRepository.AdvertiserJobTemplateLogoProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserJobTemplateLogoCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobTemplates>
				if (CanDeepSave(entity.JobTemplatesCollection, "List<JobTemplates>|JobTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobTemplates child in entity.JobTemplatesCollection)
					{
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
						}

					}

					if (entity.JobTemplatesCollection.Count > 0 || entity.JobTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobTemplatesProvider.Save(transactionManager, entity.JobTemplatesCollection);
						
						deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobTemplates >) DataRepository.JobTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.JobTemplatesCollection, deepSaveType, childTypes, innerList }
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
						if(child.AdvertiserIdSource != null)
						{
							child.AdvertiserId = child.AdvertiserIdSource.AdvertiserId;
						}
						else
						{
							child.AdvertiserId = entity.AdvertiserId;
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
	
	#region AdvertisersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Advertisers</c>
	///</summary>
	public enum AdvertisersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdvertiserAccountStatus</c> at AdvertiserAccountStatusIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserAccountStatus))]
		AdvertiserAccountStatus,
			
		///<summary>
		/// Composite Property for <c>AdvertiserBusinessType</c> at AdvertiserBusinessTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserBusinessType))]
		AdvertiserBusinessType,
			
		///<summary>
		/// Composite Property for <c>AdvertiserAccountType</c> at AdvertiserAccountTypeIdSource
		///</summary>
		[ChildEntityType(typeof(AdvertiserAccountType))]
		AdvertiserAccountType,
			
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
		/// Collection of <c>Advertisers</c> as OneToMany for AdvertiserUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserUsers>))]
		AdvertiserUsersCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for SiteAdvertiserFilterCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteAdvertiserFilter>))]
		SiteAdvertiserFilterCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as ManyToMany for JobItemsTypeCollection_From_AdvertiserJobPricing
		///</summary>
		[ChildEntityType(typeof(TList<JobItemsType>))]
		JobItemsTypeIdJobItemsTypeCollection_From_AdvertiserJobPricing,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for AdvertiserJobPricingCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserJobPricing>))]
		AdvertiserJobPricingCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for JobCustomXmlCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobCustomXml>))]
		JobCustomXmlCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for AdvertiserJobTemplateLogoCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserJobTemplateLogo>))]
		AdvertiserJobTemplateLogoCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for JobTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobTemplates>))]
		JobTemplatesCollection,

		///<summary>
		/// Collection of <c>Advertisers</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,
	}
	
	#endregion AdvertisersChildEntityTypes
	
	#region AdvertisersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertisersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersFilterBuilder : SqlFilterBuilder<AdvertisersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilterBuilder class.
		/// </summary>
		public AdvertisersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertisersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertisersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertisersFilterBuilder
	
	#region AdvertisersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertisersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersParameterBuilder : ParameterizedSqlFilterBuilder<AdvertisersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersParameterBuilder class.
		/// </summary>
		public AdvertisersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertisersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertisersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertisersParameterBuilder
	
	#region AdvertisersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertisersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertisersSortBuilder : SqlSortBuilder<AdvertisersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersSqlSortBuilder class.
		/// </summary>
		public AdvertisersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertisersSortBuilder
	
} // end namespace
