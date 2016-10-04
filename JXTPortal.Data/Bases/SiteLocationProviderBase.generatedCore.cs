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
	/// This class is the base class for any <see cref="SiteLocationProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteLocationProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteLocation, JXTPortal.Entities.SiteLocationKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteLocationKey key)
		{
			return Delete(transactionManager, key.SiteLocationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteLocationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteLocationId)
		{
			return Delete(null, _siteLocationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLocationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteLocationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		FK__SiteLocat__Locat__505BE5AD Description: 
		/// </summary>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetByLocationId(System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(_locationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		FK__SiteLocat__Locat__505BE5AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		/// <remarks></remarks>
		public TList<SiteLocation> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		FK__SiteLocat__Locat__505BE5AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetByLocationId(transactionManager, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		fkSiteLocatLocat505Be5Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetByLocationId(System.Int32 _locationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLocationId(null, _locationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		fkSiteLocatLocat505Be5Ad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_locationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetByLocationId(System.Int32 _locationId, int start, int pageLength,out int count)
		{
			return GetByLocationId(null, _locationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__Locat__505BE5AD key.
		///		FK__SiteLocat__Locat__505BE5AD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public abstract TList<SiteLocation> GetByLocationId(TransactionManager transactionManager, System.Int32 _locationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		FK__SiteLocat__SiteI__515009E6 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		FK__SiteLocat__SiteI__515009E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		/// <remarks></remarks>
		public TList<SiteLocation> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		FK__SiteLocat__SiteI__515009E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		fkSiteLocatSitei515009e6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		fkSiteLocatSitei515009e6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public TList<SiteLocation> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLocat__SiteI__515009E6 key.
		///		FK__SiteLocat__SiteI__515009E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLocation objects.</returns>
		public abstract TList<SiteLocation> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteLocation Get(TransactionManager transactionManager, JXTPortal.Entities.SiteLocationKey key, int start, int pageLength)
		{
			return GetBySiteLocationId(transactionManager, key.SiteLocationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(System.Int32 _siteId, System.Int32 _locationId)
		{
			int count = -1;
			return GetBySiteIdLocationId(null,_siteId, _locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(System.Int32 _siteId, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLocationId(null, _siteId, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _locationId)
		{
			int count = -1;
			return GetBySiteIdLocationId(transactionManager, _siteId, _locationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _locationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLocationId(transactionManager, _siteId, _locationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(System.Int32 _siteId, System.Int32 _locationId, int start, int pageLength, out int count)
		{
			return GetBySiteIdLocationId(null, _siteId, _locationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteLocation index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_locationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public abstract JXTPortal.Entities.SiteLocation GetBySiteIdLocationId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _locationId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="_siteLocationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteLocationId(System.Int32 _siteLocationId)
		{
			int count = -1;
			return GetBySiteLocationId(null,_siteLocationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="_siteLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteLocationId(System.Int32 _siteLocationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteLocationId(null, _siteLocationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLocationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteLocationId(TransactionManager transactionManager, System.Int32 _siteLocationId)
		{
			int count = -1;
			return GetBySiteLocationId(transactionManager, _siteLocationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteLocationId(TransactionManager transactionManager, System.Int32 _siteLocationId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteLocationId(transactionManager, _siteLocationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="_siteLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public JXTPortal.Entities.SiteLocation GetBySiteLocationId(System.Int32 _siteLocationId, int start, int pageLength, out int count)
		{
			return GetBySiteLocationId(null, _siteLocationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLocation__32CB82C6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLocation"/> class.</returns>
		public abstract JXTPortal.Entities.SiteLocation GetBySiteLocationId(TransactionManager transactionManager, System.Int32 _siteLocationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteLocation_GetByCountryID 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByCountryID(System.Int32? siteId, System.Int32? countryId)
		{
			return GetByCountryID(null, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByCountryID(int start, int pageLength, System.Int32? siteId, System.Int32? countryId)
		{
			return GetByCountryID(null, start, pageLength , siteId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByCountryID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId)
		{
			return GetByCountryID(transactionManager, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetByCountryID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId);
		
		#endregion
		
		#region SiteLocation_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl, ref System.Int32? siteLocationId)
		{
			 Insert(null, 0, int.MaxValue , locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl, ref siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl, ref System.Int32? siteLocationId)
		{
			 Insert(null, start, pageLength , locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl, ref siteLocationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl, ref System.Int32? siteLocationId)
		{
			 Insert(transactionManager, 0, int.MaxValue , locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl, ref siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Insert' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl, ref System.Int32? siteLocationId);
		
		#endregion
		
		#region SiteLocation_GetByLocationId 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByLocationId(System.Int32? locationId)
		{
			return GetByLocationId(null, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByLocationId(int start, int pageLength, System.Int32? locationId)
		{
			return GetByLocationId(null, start, pageLength , locationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetByLocationId(TransactionManager transactionManager, System.Int32? locationId)
		{
			return GetByLocationId(transactionManager, 0, int.MaxValue , locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetByLocationId' stored procedure. 
		/// </summary>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetByLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? locationId);
		
		#endregion
		
		#region SiteLocation_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteLocation_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteLocation_GetBySiteIdLocationId 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdLocationId(System.Int32? siteId, System.Int32? locationId)
		{
			return GetBySiteIdLocationId(null, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdLocationId(int start, int pageLength, System.Int32? siteId, System.Int32? locationId)
		{
			return GetBySiteIdLocationId(null, start, pageLength , siteId, locationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdLocationId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? locationId)
		{
			return GetBySiteIdLocationId(transactionManager, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetBySiteIdLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? locationId);
		
		#endregion
		
		#region SiteLocation_GetBySiteIdFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdFriendlyUrl(System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, start, pageLength , siteId, friendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String friendlyUrl);
		
		#endregion
		
		#region SiteLocation_CustomDeleteBySiteIDLocationID 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomDeleteBySiteIDLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDLocationID(System.Int32? siteId, System.Int32? locationId)
		{
			 CustomDeleteBySiteIDLocationID(null, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomDeleteBySiteIDLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDLocationID(int start, int pageLength, System.Int32? siteId, System.Int32? locationId)
		{
			 CustomDeleteBySiteIDLocationID(null, start, pageLength , siteId, locationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomDeleteBySiteIDLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDLocationID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? locationId)
		{
			 CustomDeleteBySiteIDLocationID(transactionManager, 0, int.MaxValue , siteId, locationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomDeleteBySiteIDLocationID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomDeleteBySiteIDLocationID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? locationId);
		
		#endregion
		
		#region SiteLocation_GetBySiteLocationId 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteLocationId(System.Int32? siteLocationId)
		{
			return GetBySiteLocationId(null, 0, int.MaxValue , siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteLocationId(int start, int pageLength, System.Int32? siteLocationId)
		{
			return GetBySiteLocationId(null, start, pageLength , siteLocationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteLocationId(TransactionManager transactionManager, System.Int32? siteLocationId)
		{
			return GetBySiteLocationId(transactionManager, 0, int.MaxValue , siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteLocationId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetBySiteLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLocationId);
		
		#endregion
		
		#region SiteLocation_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteLocation_Update 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			 Update(null, 0, int.MaxValue , siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			 Update(null, start, pageLength , siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl);
		
		#endregion
		
		#region SiteLocation_Find 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Find(System.Boolean? searchUsingOr, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public TList<SiteLocation> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteLocationId, locationId, siteId, siteLocationName, valid, siteLocationFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLocationName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLocationFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLocation&gt;"/> instance.</returns>
		public abstract TList<SiteLocation> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteLocationId, System.Int32? locationId, System.Int32? siteId, System.String siteLocationName, System.Boolean? valid, System.String siteLocationFriendlyUrl);
		
		#endregion
		
		#region SiteLocation_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteLocationId)
		{
			 Delete(null, 0, int.MaxValue , siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteLocationId)
		{
			 Delete(null, start, pageLength , siteLocationId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteLocationId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteLocationId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLocationId);
		
		#endregion
		
		#region SiteLocation_CustomGetBySiteID 
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(System.Int32? siteId, System.Int32? countryId)
		{
			return CustomGetBySiteID(null, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(int start, int pageLength, System.Int32? siteId, System.Int32? countryId)
		{
			return CustomGetBySiteID(null, start, pageLength , siteId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId)
		{
			return CustomGetBySiteID(transactionManager, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLocation_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteLocation&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteLocation&gt;"/></returns>
		public static TList<SiteLocation> Fill(IDataReader reader, TList<SiteLocation> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteLocation c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteLocation")
					.Append("|").Append((System.Int32)reader[((int)SiteLocationColumn.SiteLocationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteLocation>(
					key.ToString(), // EntityTrackingKey
					"SiteLocation",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteLocation();
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
					c.SiteLocationId = (System.Int32)reader[((int)SiteLocationColumn.SiteLocationId - 1)];
					c.LocationId = (System.Int32)reader[((int)SiteLocationColumn.LocationId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteLocationColumn.SiteId - 1)];
					c.SiteLocationName = (reader.IsDBNull(((int)SiteLocationColumn.SiteLocationName - 1)))?null:(System.String)reader[((int)SiteLocationColumn.SiteLocationName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteLocationColumn.Valid - 1)];
					c.SiteLocationFriendlyUrl = (reader.IsDBNull(((int)SiteLocationColumn.SiteLocationFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteLocationColumn.SiteLocationFriendlyUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteLocation"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLocation"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteLocation entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteLocationId = (System.Int32)reader[((int)SiteLocationColumn.SiteLocationId - 1)];
			entity.LocationId = (System.Int32)reader[((int)SiteLocationColumn.LocationId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteLocationColumn.SiteId - 1)];
			entity.SiteLocationName = (reader.IsDBNull(((int)SiteLocationColumn.SiteLocationName - 1)))?null:(System.String)reader[((int)SiteLocationColumn.SiteLocationName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteLocationColumn.Valid - 1)];
			entity.SiteLocationFriendlyUrl = (reader.IsDBNull(((int)SiteLocationColumn.SiteLocationFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteLocationColumn.SiteLocationFriendlyUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteLocation"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLocation"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteLocation entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteLocationId = (System.Int32)dataRow["SiteLocationID"];
			entity.LocationId = (System.Int32)dataRow["LocationID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.SiteLocationName = Convert.IsDBNull(dataRow["SiteLocationName"]) ? null : (System.String)dataRow["SiteLocationName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.SiteLocationFriendlyUrl = Convert.IsDBNull(dataRow["SiteLocationFriendlyUrl"]) ? null : (System.String)dataRow["SiteLocationFriendlyUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLocation"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteLocation Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteLocation entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LocationIdSource	
			if (CanDeepLoad(entity, "Location|LocationIdSource", deepLoadType, innerList) 
				&& entity.LocationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LocationId;
				Location tmpEntity = EntityManager.LocateEntity<Location>(EntityLocator.ConstructKeyFromPkItems(typeof(Location), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LocationIdSource = tmpEntity;
				else
					entity.LocationIdSource = DataRepository.LocationProvider.GetByLocationId(transactionManager, entity.LocationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LocationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LocationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LocationProvider.DeepLoad(transactionManager, entity.LocationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LocationIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteLocation object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteLocation instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteLocation Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteLocation entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LocationIdSource
			if (CanDeepSave(entity, "Location|LocationIdSource", deepSaveType, innerList) 
				&& entity.LocationIdSource != null)
			{
				DataRepository.LocationProvider.Save(transactionManager, entity.LocationIdSource);
				entity.LocationId = entity.LocationIdSource.LocationId;
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
	
	#region SiteLocationChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteLocation</c>
	///</summary>
	public enum SiteLocationChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Location</c> at LocationIdSource
		///</summary>
		[ChildEntityType(typeof(Location))]
		Location,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteLocationChildEntityTypes
	
	#region SiteLocationFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationFilterBuilder : SqlFilterBuilder<SiteLocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilterBuilder class.
		/// </summary>
		public SiteLocationFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLocationFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLocationFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLocationFilterBuilder
	
	#region SiteLocationParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationParameterBuilder : ParameterizedSqlFilterBuilder<SiteLocationColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationParameterBuilder class.
		/// </summary>
		public SiteLocationParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLocationParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLocationParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLocationParameterBuilder
	
	#region SiteLocationSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteLocationColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteLocationSortBuilder : SqlSortBuilder<SiteLocationColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationSqlSortBuilder class.
		/// </summary>
		public SiteLocationSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteLocationSortBuilder
	
} // end namespace
