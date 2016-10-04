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
	/// This class is the base class for any <see cref="SiteAdvertiserFilterProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteAdvertiserFilterProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteAdvertiserFilter, JXTPortal.Entities.SiteAdvertiserFilterKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteAdvertiserFilterKey key)
		{
			return Delete(transactionManager, key.SiteAdvertiserFilterId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteAdvertiserFilterId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteAdvertiserFilterId)
		{
			return Delete(null, _siteAdvertiserFilterId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAdvertiserFilterId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteAdvertiserFilterId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		FK__SiteAdver__Adver__1F997E18 Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		FK__SiteAdver__Adver__1F997E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		/// <remarks></remarks>
		public TList<SiteAdvertiserFilter> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		FK__SiteAdver__Adver__1F997E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		fkSiteAdverAdver1f997e18 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		fkSiteAdverAdver1f997e18 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__Adver__1F997E18 key.
		///		FK__SiteAdver__Adver__1F997E18 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public abstract TList<SiteAdvertiserFilter> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		FK__SiteAdver__SiteI__1EA559DF Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		FK__SiteAdver__SiteI__1EA559DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		/// <remarks></remarks>
		public TList<SiteAdvertiserFilter> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		FK__SiteAdver__SiteI__1EA559DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		fkSiteAdverSitei1Ea559Df Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		fkSiteAdverSitei1Ea559Df Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public TList<SiteAdvertiserFilter> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteAdver__SiteI__1EA559DF key.
		///		FK__SiteAdver__SiteI__1EA559DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteAdvertiserFilter objects.</returns>
		public abstract TList<SiteAdvertiserFilter> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteAdvertiserFilter Get(TransactionManager transactionManager, JXTPortal.Entities.SiteAdvertiserFilterKey key, int start, int pageLength)
		{
			return GetBySiteAdvertiserFilterId(transactionManager, key.SiteAdvertiserFilterId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(System.Int32 _siteId, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetBySiteIdAdvertiserId(null,_siteId, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(System.Int32 _siteId, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdAdvertiserId(null, _siteId, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetBySiteIdAdvertiserId(transactionManager, _siteId, _advertiserId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdAdvertiserId(transactionManager, _siteId, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(System.Int32 _siteId, System.Int32 _advertiserId, int start, int pageLength, out int count)
		{
			return GetBySiteIdAdvertiserId(null, _siteId, _advertiserId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public abstract JXTPortal.Entities.SiteAdvertiserFilter GetBySiteIdAdvertiserId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _advertiserId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(System.Int32 _siteAdvertiserFilterId)
		{
			int count = -1;
			return GetBySiteAdvertiserFilterId(null,_siteAdvertiserFilterId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(System.Int32 _siteAdvertiserFilterId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteAdvertiserFilterId(null, _siteAdvertiserFilterId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(TransactionManager transactionManager, System.Int32 _siteAdvertiserFilterId)
		{
			int count = -1;
			return GetBySiteAdvertiserFilterId(transactionManager, _siteAdvertiserFilterId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(TransactionManager transactionManager, System.Int32 _siteAdvertiserFilterId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteAdvertiserFilterId(transactionManager, _siteAdvertiserFilterId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(System.Int32 _siteAdvertiserFilterId, int start, int pageLength, out int count)
		{
			return GetBySiteAdvertiserFilterId(null, _siteAdvertiserFilterId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteAdvertiserFi__1DB135A6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteAdvertiserFilterId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> class.</returns>
		public abstract JXTPortal.Entities.SiteAdvertiserFilter GetBySiteAdvertiserFilterId(TransactionManager transactionManager, System.Int32 _siteAdvertiserFilterId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteAdvertiserFilter_GetNameBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetNameBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetNameBySiteId(System.Int32? siteId)
		{
			return GetNameBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetNameBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetNameBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetNameBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetNameBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetNameBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetNameBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetNameBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetNameBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteAdvertiserFilter_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? advertiserId, ref System.Int32? siteAdvertiserFilterId)
		{
			 Insert(null, 0, int.MaxValue , siteId, advertiserId, ref siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, ref System.Int32? siteAdvertiserFilterId)
		{
			 Insert(null, start, pageLength , siteId, advertiserId, ref siteAdvertiserFilterId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, ref System.Int32? siteAdvertiserFilterId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, advertiserId, ref siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, ref System.Int32? siteAdvertiserFilterId);
		
		#endregion
		
		#region SiteAdvertiserFilter_GetBySiteIdAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteIdAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdAdvertiserId(System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetBySiteIdAdvertiserId(null, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteIdAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdAdvertiserId(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetBySiteIdAdvertiserId(null, start, pageLength , siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteIdAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdAdvertiserId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetBySiteIdAdvertiserId(transactionManager, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteIdAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#region SiteAdvertiserFilter_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteAdvertiserFilter_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Get_List' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteAdvertiserFilter_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetPaged' stored procedure. 
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
		
		#region SiteAdvertiserFilter_GetBySiteAdvertiserFilterId 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteAdvertiserFilterId' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteAdvertiserFilterId(System.Int32? siteAdvertiserFilterId)
		{
			return GetBySiteAdvertiserFilterId(null, 0, int.MaxValue , siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteAdvertiserFilterId' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteAdvertiserFilterId(int start, int pageLength, System.Int32? siteAdvertiserFilterId)
		{
			return GetBySiteAdvertiserFilterId(null, start, pageLength , siteAdvertiserFilterId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteAdvertiserFilterId' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteAdvertiserFilterId(TransactionManager transactionManager, System.Int32? siteAdvertiserFilterId)
		{
			return GetBySiteAdvertiserFilterId(transactionManager, 0, int.MaxValue , siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetBySiteAdvertiserFilterId' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteAdvertiserFilterId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAdvertiserFilterId);
		
		#endregion
		
		#region SiteAdvertiserFilter_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetByAdvertiserId' stored procedure. 
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
		///	This method wrap the 'SiteAdvertiserFilter_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region SiteAdvertiserFilter_Find 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteAdvertiserFilterId, siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			return Find(null, start, pageLength , searchUsingOr, siteAdvertiserFilterId, siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteAdvertiserFilterId, siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#region SiteAdvertiserFilter_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteAdvertiserFilterId)
		{
			 Delete(null, 0, int.MaxValue , siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteAdvertiserFilterId)
		{
			 Delete(null, start, pageLength , siteAdvertiserFilterId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteAdvertiserFilterId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteAdvertiserFilterId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAdvertiserFilterId);
		
		#endregion
		
		#region SiteAdvertiserFilter_Update 
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			 Update(null, 0, int.MaxValue , siteAdvertiserFilterId, siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			 Update(null, start, pageLength , siteAdvertiserFilterId, siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId)
		{
			 Update(transactionManager, 0, int.MaxValue , siteAdvertiserFilterId, siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteAdvertiserFilter_Update' stored procedure. 
		/// </summary>
		/// <param name="siteAdvertiserFilterId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteAdvertiserFilterId, System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteAdvertiserFilter&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteAdvertiserFilter&gt;"/></returns>
		public static TList<SiteAdvertiserFilter> Fill(IDataReader reader, TList<SiteAdvertiserFilter> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteAdvertiserFilter c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteAdvertiserFilter")
					.Append("|").Append((System.Int32)reader[((int)SiteAdvertiserFilterColumn.SiteAdvertiserFilterId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteAdvertiserFilter>(
					key.ToString(), // EntityTrackingKey
					"SiteAdvertiserFilter",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteAdvertiserFilter();
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
					c.SiteAdvertiserFilterId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.SiteAdvertiserFilterId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.SiteId - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.AdvertiserId - 1)];
					c.Status = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.Status - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteAdvertiserFilter entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteAdvertiserFilterId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.SiteAdvertiserFilterId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.SiteId - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.AdvertiserId - 1)];
			entity.Status = (System.Int32)reader[((int)SiteAdvertiserFilterColumn.Status - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteAdvertiserFilter entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteAdvertiserFilterId = (System.Int32)dataRow["SiteAdvertiserFilterID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
			entity.Status = (System.Int32)dataRow["Status"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteAdvertiserFilter"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteAdvertiserFilter Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteAdvertiserFilter entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteAdvertiserFilter object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteAdvertiserFilter instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteAdvertiserFilter Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteAdvertiserFilter entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SiteAdvertiserFilterChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteAdvertiserFilter</c>
	///</summary>
	public enum SiteAdvertiserFilterChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteAdvertiserFilterChildEntityTypes
	
	#region SiteAdvertiserFilterFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteAdvertiserFilterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterFilterBuilder : SqlFilterBuilder<SiteAdvertiserFilterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilterBuilder class.
		/// </summary>
		public SiteAdvertiserFilterFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAdvertiserFilterFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAdvertiserFilterFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAdvertiserFilterFilterBuilder
	
	#region SiteAdvertiserFilterParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteAdvertiserFilterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterParameterBuilder : ParameterizedSqlFilterBuilder<SiteAdvertiserFilterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterParameterBuilder class.
		/// </summary>
		public SiteAdvertiserFilterParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAdvertiserFilterParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAdvertiserFilterParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAdvertiserFilterParameterBuilder
	
	#region SiteAdvertiserFilterSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteAdvertiserFilterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteAdvertiserFilterSortBuilder : SqlSortBuilder<SiteAdvertiserFilterColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterSqlSortBuilder class.
		/// </summary>
		public SiteAdvertiserFilterSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteAdvertiserFilterSortBuilder
	
} // end namespace
