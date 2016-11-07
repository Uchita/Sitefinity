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
	/// This class is the base class for any <see cref="AdvertiserJobTemplateLogoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AdvertiserJobTemplateLogoProviderBaseCore : EntityProviderBase<JXTPortal.Entities.AdvertiserJobTemplateLogo, JXTPortal.Entities.AdvertiserJobTemplateLogoKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobTemplateLogoKey key)
		{
			return Delete(transactionManager, key.AdvertiserJobTemplateLogoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_advertiserJobTemplateLogoId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _advertiserJobTemplateLogoId)
		{
			return Delete(null, _advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserJobTemplateLogoId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _advertiserJobTemplateLogoId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		FK__Advertise__Adver__6C9A93AD Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		public TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		FK__Advertise__Adver__6C9A93AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		/// <remarks></remarks>
		public TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		FK__Advertise__Adver__6C9A93AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		public TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		fkAdvertiseAdver6c9a93Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		public TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		fkAdvertiseAdver6c9a93Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		public TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Advertise__Adver__6C9A93AD key.
		///		FK__Advertise__Adver__6C9A93AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.AdvertiserJobTemplateLogo objects.</returns>
		public abstract TList<AdvertiserJobTemplateLogo> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.AdvertiserJobTemplateLogo Get(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobTemplateLogoKey key, int start, int pageLength)
		{
			return GetByAdvertiserJobTemplateLogoId(transactionManager, key.AdvertiserJobTemplateLogoId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(System.Int32 _advertiserJobTemplateLogoId)
		{
			int count = -1;
			return GetByAdvertiserJobTemplateLogoId(null,_advertiserJobTemplateLogoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(System.Int32 _advertiserJobTemplateLogoId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserJobTemplateLogoId(null, _advertiserJobTemplateLogoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(TransactionManager transactionManager, System.Int32 _advertiserJobTemplateLogoId)
		{
			int count = -1;
			return GetByAdvertiserJobTemplateLogoId(transactionManager, _advertiserJobTemplateLogoId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(TransactionManager transactionManager, System.Int32 _advertiserJobTemplateLogoId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserJobTemplateLogoId(transactionManager, _advertiserJobTemplateLogoId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(System.Int32 _advertiserJobTemplateLogoId, int start, int pageLength, out int count)
		{
			return GetByAdvertiserJobTemplateLogoId(null, _advertiserJobTemplateLogoId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__AdvertiserJobTem__6BA66F74 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserJobTemplateLogoId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> class.</returns>
		public abstract JXTPortal.Entities.AdvertiserJobTemplateLogo GetByAdvertiserJobTemplateLogoId(TransactionManager transactionManager, System.Int32 _advertiserJobTemplateLogoId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region AdvertiserJobTemplateLogo_Insert 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl, ref System.Int32? advertiserJobTemplateLogoId)
		{
			 Insert(null, 0, int.MaxValue , advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl, ref advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl, ref System.Int32? advertiserJobTemplateLogoId)
		{
			 Insert(null, start, pageLength , advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl, ref advertiserJobTemplateLogoId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl, ref System.Int32? advertiserJobTemplateLogoId)
		{
			 Insert(transactionManager, 0, int.MaxValue , advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl, ref advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Insert' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl, ref System.Int32? advertiserJobTemplateLogoId);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_Get_List 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Get_List' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_GetPaged 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPaged' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPaged' stored procedure. 
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
		
		#region AdvertiserJobTemplateLogo_GetPagingByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPagingByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByAdvertiserId(System.Int32? advertiserId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByAdvertiserId(null, 0, int.MaxValue , advertiserId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPagingByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByAdvertiserId(int start, int pageLength, System.Int32? advertiserId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByAdvertiserId(null, start, pageLength , advertiserId, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPagingByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPagingByAdvertiserId(TransactionManager transactionManager, System.Int32? advertiserId, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPagingByAdvertiserId(transactionManager, 0, int.MaxValue , advertiserId, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetPagingByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetPagingByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserJobTemplateLogoId(System.Int32? advertiserJobTemplateLogoId)
		{
			return GetByAdvertiserJobTemplateLogoId(null, 0, int.MaxValue , advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserJobTemplateLogoId(int start, int pageLength, System.Int32? advertiserJobTemplateLogoId)
		{
			return GetByAdvertiserJobTemplateLogoId(null, start, pageLength , advertiserJobTemplateLogoId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserJobTemplateLogoId(TransactionManager transactionManager, System.Int32? advertiserJobTemplateLogoId)
		{
			return GetByAdvertiserJobTemplateLogoId(transactionManager, 0, int.MaxValue , advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_GetByAdvertiserJobTemplateLogoId' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserJobTemplateLogoId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserJobTemplateLogoId);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_Find 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_Delete 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? advertiserJobTemplateLogoId)
		{
			 Delete(null, 0, int.MaxValue , advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? advertiserJobTemplateLogoId)
		{
			 Delete(null, start, pageLength , advertiserJobTemplateLogoId);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? advertiserJobTemplateLogoId)
		{
			 Delete(transactionManager, 0, int.MaxValue , advertiserJobTemplateLogoId);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Delete' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserJobTemplateLogoId);
		
		#endregion
		
		#region AdvertiserJobTemplateLogo_Update 
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			 Update(null, 0, int.MaxValue , advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			 Update(null, start, pageLength , advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , advertiserJobTemplateLogoId, advertiserId, jobLogoName, jobTemplateLogo, jobTemplateLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'AdvertiserJobTemplateLogo_Update' stored procedure. 
		/// </summary>
		/// <param name="advertiserJobTemplateLogoId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobLogoName"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="jobTemplateLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserJobTemplateLogoId, System.Int32? advertiserId, System.String jobLogoName, System.Byte[] jobTemplateLogo, System.String jobTemplateLogoUrl);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AdvertiserJobTemplateLogo&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AdvertiserJobTemplateLogo&gt;"/></returns>
		public static TList<AdvertiserJobTemplateLogo> Fill(IDataReader reader, TList<AdvertiserJobTemplateLogo> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.AdvertiserJobTemplateLogo c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AdvertiserJobTemplateLogo")
					.Append("|").Append((System.Int32)reader[((int)AdvertiserJobTemplateLogoColumn.AdvertiserJobTemplateLogoId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AdvertiserJobTemplateLogo>(
					key.ToString(), // EntityTrackingKey
					"AdvertiserJobTemplateLogo",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.AdvertiserJobTemplateLogo();
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
					c.AdvertiserJobTemplateLogoId = (System.Int32)reader[((int)AdvertiserJobTemplateLogoColumn.AdvertiserJobTemplateLogoId - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)AdvertiserJobTemplateLogoColumn.AdvertiserId - 1)];
					c.JobLogoName = (System.String)reader[((int)AdvertiserJobTemplateLogoColumn.JobLogoName - 1)];
					c.JobTemplateLogo = (System.Byte[])reader[((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogo - 1)];
					c.JobTemplateLogoUrl = (reader.IsDBNull(((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogoUrl - 1)))?null:(System.String)reader[((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogoUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.AdvertiserJobTemplateLogo entity)
		{
			if (!reader.Read()) return;
			
			entity.AdvertiserJobTemplateLogoId = (System.Int32)reader[((int)AdvertiserJobTemplateLogoColumn.AdvertiserJobTemplateLogoId - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)AdvertiserJobTemplateLogoColumn.AdvertiserId - 1)];
			entity.JobLogoName = (System.String)reader[((int)AdvertiserJobTemplateLogoColumn.JobLogoName - 1)];
			entity.JobTemplateLogo = (System.Byte[])reader[((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogo - 1)];
			entity.JobTemplateLogoUrl = (reader.IsDBNull(((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogoUrl - 1)))?null:(System.String)reader[((int)AdvertiserJobTemplateLogoColumn.JobTemplateLogoUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.AdvertiserJobTemplateLogo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserJobTemplateLogoId = (System.Int32)dataRow["AdvertiserJobTemplateLogoID"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.JobLogoName = (System.String)dataRow["JobLogoName"];
			entity.JobTemplateLogo = (System.Byte[])dataRow["JobTemplateLogo"];
			entity.JobTemplateLogoUrl = Convert.IsDBNull(dataRow["JobTemplateLogoUrl"]) ? null : (System.String)dataRow["JobTemplateLogoUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.AdvertiserJobTemplateLogo"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserJobTemplateLogo Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobTemplateLogo entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.AdvertiserJobTemplateLogo object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.AdvertiserJobTemplateLogo instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.AdvertiserJobTemplateLogo Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.AdvertiserJobTemplateLogo entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AdvertiserJobTemplateLogoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.AdvertiserJobTemplateLogo</c>
	///</summary>
	public enum AdvertiserJobTemplateLogoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
		}
	
	#endregion AdvertiserJobTemplateLogoChildEntityTypes
	
	#region AdvertiserJobTemplateLogoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AdvertiserJobTemplateLogoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobTemplateLogo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobTemplateLogoFilterBuilder : SqlFilterBuilder<AdvertiserJobTemplateLogoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilterBuilder class.
		/// </summary>
		public AdvertiserJobTemplateLogoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobTemplateLogoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobTemplateLogoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobTemplateLogoFilterBuilder
	
	#region AdvertiserJobTemplateLogoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AdvertiserJobTemplateLogoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobTemplateLogo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobTemplateLogoParameterBuilder : ParameterizedSqlFilterBuilder<AdvertiserJobTemplateLogoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoParameterBuilder class.
		/// </summary>
		public AdvertiserJobTemplateLogoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobTemplateLogoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobTemplateLogoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobTemplateLogoParameterBuilder
	
	#region AdvertiserJobTemplateLogoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AdvertiserJobTemplateLogoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobTemplateLogo"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AdvertiserJobTemplateLogoSortBuilder : SqlSortBuilder<AdvertiserJobTemplateLogoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoSqlSortBuilder class.
		/// </summary>
		public AdvertiserJobTemplateLogoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AdvertiserJobTemplateLogoSortBuilder
	
} // end namespace
