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
	/// This class is the base class for any <see cref="AdvertiserUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertiserUsersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdvertiserUsers, JXTPortal.Entities.AdvertiserUsersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserUsersKey key)
		{
			return Delete(transactionManager, key.AdvertiserUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserUserId)
		{
			return Delete(null, _advertiserUserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserUserId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		FK__Advertise__Adver__04659998 Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		FK__Advertise__Adver__04659998 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserUsers> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		FK__Advertise__Adver__04659998 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		fkAdvertiseAdver04659998 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		fkAdvertiseAdver04659998 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__04659998 key.
		///		FK__Advertise__Adver__04659998 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public abstract TList<AdvertiserUsers> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		FK__Advertise__Email__5FB337D6 Description: 
		/// </summary>
		/// <param name="_emailFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByEmailFormat(System.Int32 _emailFormat)
		{
			int count = -1;
			return GetByEmailFormat(_emailFormat, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		FK__Advertise__Email__5FB337D6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserUsers> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat)
		{
			int count = -1;
			return GetByEmailFormat(transactionManager, _emailFormat, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		FK__Advertise__Email__5FB337D6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailFormat(transactionManager, _emailFormat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		fkAdvertiseEmail5Fb337d6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_emailFormat"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByEmailFormat(System.Int32 _emailFormat, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmailFormat(null, _emailFormat, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		fkAdvertiseEmail5Fb337d6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_emailFormat"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByEmailFormat(System.Int32 _emailFormat, int start, int pageLength,out int count)
		{
			return GetByEmailFormat(null, _emailFormat, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Email__5FB337D6 key.
		///		FK__Advertise__Email__5FB337D6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public abstract TList<AdvertiserUsers> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		FK__Advertise__LastM__7CC477D0 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		FK__Advertise__LastM__7CC477D0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserUsers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		FK__Advertise__LastM__7CC477D0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		fkAdvertiseLastm7Cc477d0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		fkAdvertiseLastm7Cc477d0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__LastM__7CC477D0 key.
		///		FK__Advertise__LastM__7CC477D0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public abstract TList<AdvertiserUsers> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		FK__Advertise__Newsl__5EBF139D Description: 
		/// </summary>
		/// <param name="_newsletterFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByNewsletterFormat(System.Int32 _newsletterFormat)
		{
			int count = -1;
			return GetByNewsletterFormat(_newsletterFormat, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		FK__Advertise__Newsl__5EBF139D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsletterFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserUsers> GetByNewsletterFormat(TransactionManager transactionManager, System.Int32 _newsletterFormat)
		{
			int count = -1;
			return GetByNewsletterFormat(transactionManager, _newsletterFormat, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		FK__Advertise__Newsl__5EBF139D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsletterFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByNewsletterFormat(TransactionManager transactionManager, System.Int32 _newsletterFormat, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsletterFormat(transactionManager, _newsletterFormat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		fkAdvertiseNewsl5Ebf139d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_newsletterFormat"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByNewsletterFormat(System.Int32 _newsletterFormat, int start, int pageLength)
		{
			int count =  -1;
			return GetByNewsletterFormat(null, _newsletterFormat, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		fkAdvertiseNewsl5Ebf139d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_newsletterFormat"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public TList<AdvertiserUsers> GetByNewsletterFormat(System.Int32 _newsletterFormat, int start, int pageLength,out int count)
		{
			return GetByNewsletterFormat(null, _newsletterFormat, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Newsl__5EBF139D key.
		///		FK__Advertise__Newsl__5EBF139D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsletterFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserUsers objects.</returns>
		public abstract TList<AdvertiserUsers> GetByNewsletterFormat(TransactionManager transactionManager, System.Int32 _newsletterFormat, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.AdvertiserUsers Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserUsersKey key, int start, int pageLength)
		{
			return GetByAdvertiserUserId(transactionManager, key.AdvertiserUserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(System.String _userName, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByUserNameAdvertiserId(null,_userName, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(System.String _userName, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserNameAdvertiserId(null, _userName, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(TransactionManager transactionManager, System.String _userName, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByUserNameAdvertiserId(transactionManager, _userName, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(TransactionManager transactionManager, System.String _userName, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserNameAdvertiserId(transactionManager, _userName, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(System.String _userName, System.Int32 _advertiserId, int start, int pageLength, out int count)
		{
			return GetByUserNameAdvertiserId(null, _userName, _advertiserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_AdvertiserUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserUsers GetByUserNameAdvertiserId(TransactionManager transactionManager, System.String _userName, System.Int32 _advertiserId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(null,_advertiserUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserUserId(transactionManager, _advertiserUserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(System.Int32 _advertiserUserId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserUserId(null, _advertiserUserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserUsers__07F6335A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserUserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserUsers"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserUsers GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32 _advertiserUserId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdvertiserUsers_GetByUserNameAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByUserNameAdvertiserId(System.String userName, System.Int32? advertiserId)
		{
			return GetByUserNameAdvertiserId(null, 0, int.MaxValue , userName, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByUserNameAdvertiserId(int start, int pageLength, System.String userName, System.Int32? advertiserId)
		{
			return GetByUserNameAdvertiserId(null, start, pageLength , userName, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByUserNameAdvertiserId(TransactionManager transactionManager, System.String userName, System.Int32? advertiserId)
		{
			return GetByUserNameAdvertiserId(transactionManager, 0, int.MaxValue , userName, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByUserNameAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.String userName, System.Int32? advertiserId);
		
		#endregion
		
		#region AdvertiserUsers_GetByAdvertiserUserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(int start, int pageLength, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(null, start, pageLength , advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserUserId(TransactionManager transactionManager, System.Int32? advertiserUserId)
		{
			return GetByAdvertiserUserId(transactionManager, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserUserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserUserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region AdvertiserUsers_GetByNewsletterFormat 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByNewsletterFormat' stored procedure. 
		/// </summary>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsletterFormat(System.Int32? newsletterFormat)
		{
			return GetByNewsletterFormat(null, 0, int.MaxValue , newsletterFormat);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByNewsletterFormat' stored procedure. 
		/// </summary>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsletterFormat(int start, int pageLength, System.Int32? newsletterFormat)
		{
			return GetByNewsletterFormat(null, start, pageLength , newsletterFormat);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByNewsletterFormat' stored procedure. 
		/// </summary>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByNewsletterFormat(TransactionManager transactionManager, System.Int32? newsletterFormat)
		{
			return GetByNewsletterFormat(transactionManager, 0, int.MaxValue , newsletterFormat);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByNewsletterFormat' stored procedure. 
		/// </summary>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByNewsletterFormat(TransactionManager transactionManager, int start, int pageLength , System.Int32? newsletterFormat);
		
		#endregion
		
		#region AdvertiserUsers_Insert 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId, ref System.Int32? advertiserUserId)
		{
			 Insert(null, 0, int.MaxValue , advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId, ref advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId, ref System.Int32? advertiserUserId)
		{
			 Insert(null, start, pageLength , advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId, ref advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId, ref System.Int32? advertiserUserId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId, ref advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId, ref System.Int32? advertiserUserId);
		
		#endregion
		
		#region AdvertiserUsers_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Get_List' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdvertiserUsers_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetPaged' stored procedure. 
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
		
		#region AdvertiserUsers_AdminGetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.String userName, System.String firstName, System.String surname, System.String email, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, 0, int.MaxValue , siteId, advertiserId, advertiserUserId, userName, firstName, surname, email, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.String userName, System.String firstName, System.String surname, System.String email, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, start, pageLength , siteId, advertiserId, advertiserUserId, userName, firstName, surname, email, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.String userName, System.String firstName, System.String surname, System.String email, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(transactionManager, 0, int.MaxValue , siteId, advertiserId, advertiserUserId, userName, firstName, surname, email, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet AdminGetPaged(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.Int32? advertiserUserId, System.String userName, System.String firstName, System.String surname, System.String email, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region AdvertiserUsers_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region AdvertiserUsers_GetByUserNameSiteId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameSiteId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdvertiserUsers> GetByUserNameSiteId(System.String userName, System.Int32? siteId)
		{
			return GetByUserNameSiteId(null, 0, int.MaxValue , userName, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameSiteId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdvertiserUsers> GetByUserNameSiteId(int start, int pageLength, System.String userName, System.Int32? siteId)
		{
			return GetByUserNameSiteId(null, start, pageLength , userName, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameSiteId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<AdvertiserUsers> GetByUserNameSiteId(TransactionManager transactionManager, System.String userName, System.Int32? siteId)
		{
			return GetByUserNameSiteId(transactionManager, 0, int.MaxValue , userName, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByUserNameSiteId' stored procedure. 
		/// </summary>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public abstract TList<AdvertiserUsers> GetByUserNameSiteId(TransactionManager transactionManager, int start, int pageLength, System.String userName, System.Int32? siteId);
		
		#endregion
		
		#region AdvertiserUsers_Update 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			 Update(null, 0, int.MaxValue , advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			 Update(null, start, pageLength , advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId);
		
		#endregion
		
		#region AdvertiserUsers_Find 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserUserId, advertiserId, primaryAccount, userName, userPassword, firstName, surname, email, applicationEmailAddress, phone, fax, accountStatus, newsletter, newsletterFormat, emailFormat, validated, validateGuid, description, lastLoginDate, lastModified, lastModifiedBy, jobExpiryNotification, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, externalAdvertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="primaryAccount"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="userName"> A <c>System.String</c> instance.</param>
		/// <param name="userPassword"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="applicationEmailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="accountStatus"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newsletter"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="newsletterFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="lastLoginDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="externalAdvertiserUserId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserUserId, System.Int32? advertiserId, System.Boolean? primaryAccount, System.String userName, System.String userPassword, System.String firstName, System.String surname, System.String email, System.String applicationEmailAddress, System.String phone, System.String fax, System.Int32? accountStatus, System.Boolean? newsletter, System.Int32? newsletterFormat, System.Int32? emailFormat, System.Boolean? validated, System.Guid? validateGuid, System.String description, System.DateTime? lastLoginDate, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? jobExpiryNotification, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.String externalAdvertiserUserId);
		
		#endregion
		
		#region AdvertiserUsers_Delete 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserUserId)
		{
			 Delete(null, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserUserId)
		{
			 Delete(null, start, pageLength , advertiserUserId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserUserId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserUserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserUserId);
		
		#endregion
		
		#region AdvertiserUsers_GetByEmailFormat 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(System.Int32? emailFormat)
		{
			return GetByEmailFormat(null, 0, int.MaxValue , emailFormat);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(int start, int pageLength, System.Int32? emailFormat)
		{
			return GetByEmailFormat(null, start, pageLength , emailFormat);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(TransactionManager transactionManager, System.Int32? emailFormat)
		{
			return GetByEmailFormat(transactionManager, 0, int.MaxValue , emailFormat);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByEmailFormat(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailFormat);
		
		#endregion
		
		#region AdvertiserUsers_GetAdvertiserUserPassword 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetAdvertiserUserPassword' stored procedure. 
		/// </summary>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserUsers&gt;"/> instance.</returns>
		public TList<AdvertiserUsers> GetAdvertiserUserPassword(System.String username, System.String email, System.Int32? siteId)
		{
			return GetAdvertiserUserPassword(null, 0, int.MaxValue , username, email, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetAdvertiserUserPassword' stored procedure. 
		/// </summary>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserUsers&gt;"/> instance.</returns>
		public TList<AdvertiserUsers> GetAdvertiserUserPassword(int start, int pageLength, System.String username, System.String email, System.Int32? siteId)
		{
			return GetAdvertiserUserPassword(null, start, pageLength , username, email, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetAdvertiserUserPassword' stored procedure. 
		/// </summary>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserUsers&gt;"/> instance.</returns>
		public TList<AdvertiserUsers> GetAdvertiserUserPassword(TransactionManager transactionManager, System.String username, System.String email, System.Int32? siteId)
		{
			return GetAdvertiserUserPassword(transactionManager, 0, int.MaxValue , username, email, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetAdvertiserUserPassword' stored procedure. 
		/// </summary>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;AdvertiserUsers&gt;"/> instance.</returns>
		public abstract TList<AdvertiserUsers> GetAdvertiserUserPassword(TransactionManager transactionManager, int start, int pageLength , System.String username, System.String email, System.Int32? siteId);
		
		#endregion
		
		#region AdvertiserUsers_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserUsers_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'AdvertiserUsers_GetByLastModifiedBy' stored procedure. 
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
		/// Fill a TList&lt;AdvertiserUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdvertiserUsers&gt;"/></returns>
		public static TList<AdvertiserUsers> Fill(IDataReader reader, TList<AdvertiserUsers> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdvertiserUsers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdvertiserUsers")
					.Append("|").Append((System.Int32)reader[((int)AdvertiserUsersColumn.AdvertiserUserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdvertiserUsers>(
					key.ToString(), // EntityTrackingKey
					"AdvertiserUsers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdvertiserUsers();
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
					c.AdvertiserUserId = (System.Int32)reader[((int)AdvertiserUsersColumn.AdvertiserUserId - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)AdvertiserUsersColumn.AdvertiserId - 1)];
					c.PrimaryAccount = (System.Boolean)reader[((int)AdvertiserUsersColumn.PrimaryAccount - 1)];
					c.UserName = (System.String)reader[((int)AdvertiserUsersColumn.UserName - 1)];
					c.UserPassword = (System.String)reader[((int)AdvertiserUsersColumn.UserPassword - 1)];
					c.FirstName = (System.String)reader[((int)AdvertiserUsersColumn.FirstName - 1)];
					c.Surname = (System.String)reader[((int)AdvertiserUsersColumn.Surname - 1)];
					c.Email = (System.String)reader[((int)AdvertiserUsersColumn.Email - 1)];
					c.ApplicationEmailAddress = (reader.IsDBNull(((int)AdvertiserUsersColumn.ApplicationEmailAddress - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.ApplicationEmailAddress - 1)];
					c.Phone = (reader.IsDBNull(((int)AdvertiserUsersColumn.Phone - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Phone - 1)];
					c.Fax = (reader.IsDBNull(((int)AdvertiserUsersColumn.Fax - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Fax - 1)];
					c.AccountStatus = (reader.IsDBNull(((int)AdvertiserUsersColumn.AccountStatus - 1)))?null:(System.Int32?)reader[((int)AdvertiserUsersColumn.AccountStatus - 1)];
					c.Newsletter = (System.Boolean)reader[((int)AdvertiserUsersColumn.Newsletter - 1)];
					c.NewsletterFormat = (System.Int32)reader[((int)AdvertiserUsersColumn.NewsletterFormat - 1)];
					c.EmailFormat = (System.Int32)reader[((int)AdvertiserUsersColumn.EmailFormat - 1)];
					c.Validated = (reader.IsDBNull(((int)AdvertiserUsersColumn.Validated - 1)))?null:(System.Boolean?)reader[((int)AdvertiserUsersColumn.Validated - 1)];
					c.ValidateGuid = (reader.IsDBNull(((int)AdvertiserUsersColumn.ValidateGuid - 1)))?null:(System.Guid?)reader[((int)AdvertiserUsersColumn.ValidateGuid - 1)];
					c.Description = (reader.IsDBNull(((int)AdvertiserUsersColumn.Description - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Description - 1)];
					c.LastLoginDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastLoginDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastLoginDate - 1)];
					c.LastModified = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)AdvertiserUsersColumn.LastModifiedBy - 1)];
					c.JobExpiryNotification = (System.Boolean)reader[((int)AdvertiserUsersColumn.JobExpiryNotification - 1)];
					c.LoginAttempts = (System.Int32)reader[((int)AdvertiserUsersColumn.LoginAttempts - 1)];
					c.LastAttemptDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastAttemptDate - 1)];
					c.Status = (System.Int32)reader[((int)AdvertiserUsersColumn.Status - 1)];
					c.LastTermsAndConditionsDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastTermsAndConditionsDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastTermsAndConditionsDate - 1)];
					c.DefaultLanguageId = (reader.IsDBNull(((int)AdvertiserUsersColumn.DefaultLanguageId - 1)))?null:(System.Int32?)reader[((int)AdvertiserUsersColumn.DefaultLanguageId - 1)];
					c.ExternalAdvertiserUserId = (reader.IsDBNull(((int)AdvertiserUsersColumn.ExternalAdvertiserUserId - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.ExternalAdvertiserUserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdvertiserUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserUserId = (System.Int32)reader[((int)AdvertiserUsersColumn.AdvertiserUserId - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)AdvertiserUsersColumn.AdvertiserId - 1)];
			entity.PrimaryAccount = (System.Boolean)reader[((int)AdvertiserUsersColumn.PrimaryAccount - 1)];
			entity.UserName = (System.String)reader[((int)AdvertiserUsersColumn.UserName - 1)];
			entity.UserPassword = (System.String)reader[((int)AdvertiserUsersColumn.UserPassword - 1)];
			entity.FirstName = (System.String)reader[((int)AdvertiserUsersColumn.FirstName - 1)];
			entity.Surname = (System.String)reader[((int)AdvertiserUsersColumn.Surname - 1)];
			entity.Email = (System.String)reader[((int)AdvertiserUsersColumn.Email - 1)];
			entity.ApplicationEmailAddress = (reader.IsDBNull(((int)AdvertiserUsersColumn.ApplicationEmailAddress - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.ApplicationEmailAddress - 1)];
			entity.Phone = (reader.IsDBNull(((int)AdvertiserUsersColumn.Phone - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Phone - 1)];
			entity.Fax = (reader.IsDBNull(((int)AdvertiserUsersColumn.Fax - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Fax - 1)];
			entity.AccountStatus = (reader.IsDBNull(((int)AdvertiserUsersColumn.AccountStatus - 1)))?null:(System.Int32?)reader[((int)AdvertiserUsersColumn.AccountStatus - 1)];
			entity.Newsletter = (System.Boolean)reader[((int)AdvertiserUsersColumn.Newsletter - 1)];
			entity.NewsletterFormat = (System.Int32)reader[((int)AdvertiserUsersColumn.NewsletterFormat - 1)];
			entity.EmailFormat = (System.Int32)reader[((int)AdvertiserUsersColumn.EmailFormat - 1)];
			entity.Validated = (reader.IsDBNull(((int)AdvertiserUsersColumn.Validated - 1)))?null:(System.Boolean?)reader[((int)AdvertiserUsersColumn.Validated - 1)];
			entity.ValidateGuid = (reader.IsDBNull(((int)AdvertiserUsersColumn.ValidateGuid - 1)))?null:(System.Guid?)reader[((int)AdvertiserUsersColumn.ValidateGuid - 1)];
			entity.Description = (reader.IsDBNull(((int)AdvertiserUsersColumn.Description - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.Description - 1)];
			entity.LastLoginDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastLoginDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastLoginDate - 1)];
			entity.LastModified = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)AdvertiserUsersColumn.LastModifiedBy - 1)];
			entity.JobExpiryNotification = (System.Boolean)reader[((int)AdvertiserUsersColumn.JobExpiryNotification - 1)];
			entity.LoginAttempts = (System.Int32)reader[((int)AdvertiserUsersColumn.LoginAttempts - 1)];
			entity.LastAttemptDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastAttemptDate - 1)];
			entity.Status = (System.Int32)reader[((int)AdvertiserUsersColumn.Status - 1)];
			entity.LastTermsAndConditionsDate = (reader.IsDBNull(((int)AdvertiserUsersColumn.LastTermsAndConditionsDate - 1)))?null:(System.DateTime?)reader[((int)AdvertiserUsersColumn.LastTermsAndConditionsDate - 1)];
			entity.DefaultLanguageId = (reader.IsDBNull(((int)AdvertiserUsersColumn.DefaultLanguageId - 1)))?null:(System.Int32?)reader[((int)AdvertiserUsersColumn.DefaultLanguageId - 1)];
			entity.ExternalAdvertiserUserId = (reader.IsDBNull(((int)AdvertiserUsersColumn.ExternalAdvertiserUserId - 1)))?null:(System.String)reader[((int)AdvertiserUsersColumn.ExternalAdvertiserUserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdvertiserUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserUserId = (System.Int32)dataRow["AdvertiserUserID"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.PrimaryAccount = (System.Boolean)dataRow["PrimaryAccount"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.UserPassword = (System.String)dataRow["UserPassword"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.Surname = (System.String)dataRow["Surname"];
			entity.Email = (System.String)dataRow["Email"];
			entity.ApplicationEmailAddress = Convert.IsDBNull(dataRow["ApplicationEmailAddress"]) ? null : (System.String)dataRow["ApplicationEmailAddress"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.AccountStatus = Convert.IsDBNull(dataRow["AccountStatus"]) ? null : (System.Int32?)dataRow["AccountStatus"];
			entity.Newsletter = (System.Boolean)dataRow["Newsletter"];
			entity.NewsletterFormat = (System.Int32)dataRow["NewsletterFormat"];
			entity.EmailFormat = (System.Int32)dataRow["EmailFormat"];
			entity.Validated = Convert.IsDBNull(dataRow["Validated"]) ? null : (System.Boolean?)dataRow["Validated"];
			entity.ValidateGuid = Convert.IsDBNull(dataRow["ValidateGUID"]) ? null : (System.Guid?)dataRow["ValidateGUID"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.LastLoginDate = Convert.IsDBNull(dataRow["LastLoginDate"]) ? null : (System.DateTime?)dataRow["LastLoginDate"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.JobExpiryNotification = (System.Boolean)dataRow["JobExpiryNotification"];
			entity.LoginAttempts = (System.Int32)dataRow["LoginAttempts"];
			entity.LastAttemptDate = Convert.IsDBNull(dataRow["LastAttemptDate"]) ? null : (System.DateTime?)dataRow["LastAttemptDate"];
			entity.Status = (System.Int32)dataRow["Status"];
			entity.LastTermsAndConditionsDate = Convert.IsDBNull(dataRow["LastTermsAndConditionsDate"]) ? null : (System.DateTime?)dataRow["LastTermsAndConditionsDate"];
			entity.DefaultLanguageId = Convert.IsDBNull(dataRow["DefaultLanguageId"]) ? null : (System.Int32?)dataRow["DefaultLanguageId"];
			entity.ExternalAdvertiserUserId = Convert.IsDBNull(dataRow["ExternalAdvertiserUserID"]) ? null : (System.String)dataRow["ExternalAdvertiserUserID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region EmailFormatSource	
			if (CanDeepLoad(entity, "EmailFormats|EmailFormatSource", deepLoadType, innerList) 
				&& entity.EmailFormatSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmailFormat;
				EmailFormats tmpEntity = EntityManager.LocateEntity<EmailFormats>(EntityLocator.ConstructKeyFromPkItems(typeof(EmailFormats), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmailFormatSource = tmpEntity;
				else
					entity.EmailFormatSource = DataRepository.EmailFormatsProvider.GetByEmailFormatId(transactionManager, entity.EmailFormat);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailFormatSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmailFormatSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmailFormatsProvider.DeepLoad(transactionManager, entity.EmailFormatSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmailFormatSource

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

			#region NewsletterFormatSource	
			if (CanDeepLoad(entity, "EmailFormats|NewsletterFormatSource", deepLoadType, innerList) 
				&& entity.NewsletterFormatSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.NewsletterFormat;
				EmailFormats tmpEntity = EntityManager.LocateEntity<EmailFormats>(EntityLocator.ConstructKeyFromPkItems(typeof(EmailFormats), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.NewsletterFormatSource = tmpEntity;
				else
					entity.NewsletterFormatSource = DataRepository.EmailFormatsProvider.GetByEmailFormatId(transactionManager, entity.NewsletterFormat);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsletterFormatSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.NewsletterFormatSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmailFormatsProvider.DeepLoad(transactionManager, entity.NewsletterFormatSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion NewsletterFormatSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAdvertiserUserId methods when available
			
			#region JobApplicationNotesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationNotesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationNotesCollection = DataRepository.JobApplicationNotesProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

				if (deep && entity.JobApplicationNotesCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplicationNotes>) DataRepository.JobApplicationNotesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationNotesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region InvoiceItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<InvoiceItem>|InvoiceItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceItemCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceItemCollection = DataRepository.InvoiceItemProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

				if (deep && entity.InvoiceItemCollection.Count > 0)
				{
					deepHandles.Add("InvoiceItemCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<InvoiceItem>) DataRepository.InvoiceItemProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceItemCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsCollection = DataRepository.JobsProvider.GetByLastModifiedByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region InvoiceOrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<InvoiceOrder>|InvoiceOrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceOrderCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceOrderCollection = DataRepository.InvoiceOrderProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

				if (deep && entity.InvoiceOrderCollection.Count > 0)
				{
					deepHandles.Add("InvoiceOrderCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<InvoiceOrder>) DataRepository.InvoiceOrderProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceOrderCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region InvoiceCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Invoice>|InvoiceCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'InvoiceCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.InvoiceCollection = DataRepository.InvoiceProvider.GetByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

				if (deep && entity.InvoiceCollection.Count > 0)
				{
					deepHandles.Add("InvoiceCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Invoice>) DataRepository.InvoiceProvider.DeepLoad,
						new object[] { transactionManager, entity.InvoiceCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByLastModifiedByAdvertiserUserId(transactionManager, entity.AdvertiserUserId);

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdvertiserUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdvertiserUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region EmailFormatSource
			if (CanDeepSave(entity, "EmailFormats|EmailFormatSource", deepSaveType, innerList) 
				&& entity.EmailFormatSource != null)
			{
				DataRepository.EmailFormatsProvider.Save(transactionManager, entity.EmailFormatSource);
				entity.EmailFormat = entity.EmailFormatSource.EmailFormatId;
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
			
			#region NewsletterFormatSource
			if (CanDeepSave(entity, "EmailFormats|NewsletterFormatSource", deepSaveType, innerList) 
				&& entity.NewsletterFormatSource != null)
			{
				DataRepository.EmailFormatsProvider.Save(transactionManager, entity.NewsletterFormatSource);
				entity.NewsletterFormat = entity.NewsletterFormatSource.EmailFormatId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<JobApplicationNotes>
				if (CanDeepSave(entity.JobApplicationNotesCollection, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplicationNotes child in entity.JobApplicationNotesCollection)
					{
						if(child.AdvertiserUserIdSource != null)
						{
							child.AdvertiserUserId = child.AdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.AdvertiserUserId = entity.AdvertiserUserId;
						}

					}

					if (entity.JobApplicationNotesCollection.Count > 0 || entity.JobApplicationNotesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationNotesProvider.Save(transactionManager, entity.JobApplicationNotesCollection);
						
						deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplicationNotes >) DataRepository.JobApplicationNotesProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationNotesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<InvoiceItem>
				if (CanDeepSave(entity.InvoiceItemCollection, "List<InvoiceItem>|InvoiceItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(InvoiceItem child in entity.InvoiceItemCollection)
					{
						if(child.AdvertiserUserIdSource != null)
						{
							child.AdvertiserUserId = child.AdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.AdvertiserUserId = entity.AdvertiserUserId;
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
				
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.LastModifiedByAdvertiserUserIdSource != null)
						{
							child.LastModifiedByAdvertiserUserId = child.LastModifiedByAdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.LastModifiedByAdvertiserUserId = entity.AdvertiserUserId;
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
				
	
			#region List<InvoiceOrder>
				if (CanDeepSave(entity.InvoiceOrderCollection, "List<InvoiceOrder>|InvoiceOrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(InvoiceOrder child in entity.InvoiceOrderCollection)
					{
						if(child.AdvertiserUserIdSource != null)
						{
							child.AdvertiserUserId = child.AdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.AdvertiserUserId = entity.AdvertiserUserId;
						}

					}

					if (entity.InvoiceOrderCollection.Count > 0 || entity.InvoiceOrderCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceOrderProvider.Save(transactionManager, entity.InvoiceOrderCollection);
						
						deepHandles.Add("InvoiceOrderCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< InvoiceOrder >) DataRepository.InvoiceOrderProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceOrderCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Invoice>
				if (CanDeepSave(entity.InvoiceCollection, "List<Invoice>|InvoiceCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Invoice child in entity.InvoiceCollection)
					{
						if(child.AdvertiserUserIdSource != null)
						{
							child.AdvertiserUserId = child.AdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.AdvertiserUserId = entity.AdvertiserUserId;
						}

					}

					if (entity.InvoiceCollection.Count > 0 || entity.InvoiceCollection.DeletedItems.Count > 0)
					{
						//DataRepository.InvoiceProvider.Save(transactionManager, entity.InvoiceCollection);
						
						deepHandles.Add("InvoiceCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Invoice >) DataRepository.InvoiceProvider.DeepSave,
							new object[] { transactionManager, entity.InvoiceCollection, deepSaveType, childTypes, innerList }
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
						if(child.LastModifiedByAdvertiserUserIdSource != null)
						{
							child.LastModifiedByAdvertiserUserId = child.LastModifiedByAdvertiserUserIdSource.AdvertiserUserId;
						}
						else
						{
							child.LastModifiedByAdvertiserUserId = entity.AdvertiserUserId;
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
	
	#region AdvertiserUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdvertiserUsers</c>
	///</summary>
	public enum AdvertiserUsersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>EmailFormats</c> at EmailFormatSource
		///</summary>
		[ChildEntityType(typeof(EmailFormats))]
		EmailFormats,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
	
		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for JobApplicationNotesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplicationNotes>))]
		JobApplicationNotesCollection,

		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for InvoiceItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceItem>))]
		InvoiceItemCollection,

		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for InvoiceOrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<InvoiceOrder>))]
		InvoiceOrderCollection,

		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for InvoiceCollection
		///</summary>
		[ChildEntityType(typeof(TList<Invoice>))]
		InvoiceCollection,

		///<summary>
		/// Collection of <c>AdvertiserUsers</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,
	}
	
	#endregion AdvertiserUsersChildEntityTypes
	
	#region AdvertiserUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertiserUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersFilterBuilder : SqlFilterBuilder<AdvertiserUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilterBuilder class.
		/// </summary>
		public AdvertiserUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserUsersFilterBuilder
	
	#region AdvertiserUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertiserUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersParameterBuilder : ParameterizedSqlFilterBuilder<AdvertiserUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersParameterBuilder class.
		/// </summary>
		public AdvertiserUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserUsersParameterBuilder
	
	#region AdvertiserUsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertiserUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertiserUsersSortBuilder : SqlSortBuilder<AdvertiserUsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersSqlSortBuilder class.
		/// </summary>
		public AdvertiserUsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertiserUsersSortBuilder
	
} // end namespace
