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
	/// This class is the base class for any <see cref="SiteCountriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteCountriesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteCountries, JXTPortal.Entities.SiteCountriesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteCountriesKey key)
		{
			return Delete(transactionManager, key.SiteCountryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteCountryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteCountryId)
		{
			return Delete(null, _siteCountryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCountryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteCountryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		FK__SiteCount__Count__781FBE44 Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetByCountryId(System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		FK__SiteCount__Count__781FBE44 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		/// <remarks></remarks>
		public TList<SiteCountries> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		FK__SiteCount__Count__781FBE44 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		fkSiteCountCount781Fbe44 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetByCountryId(System.Int32 _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		fkSiteCountCount781Fbe44 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetByCountryId(System.Int32 _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__Count__781FBE44 key.
		///		FK__SiteCount__Count__781FBE44 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public abstract TList<SiteCountries> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		FK__SiteCount__SiteI__7913E27D Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		FK__SiteCount__SiteI__7913E27D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		/// <remarks></remarks>
		public TList<SiteCountries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		FK__SiteCount__SiteI__7913E27D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		fkSiteCountSitei7913e27d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		fkSiteCountSitei7913e27d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public TList<SiteCountries> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCount__SiteI__7913E27D key.
		///		FK__SiteCount__SiteI__7913E27D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCountries objects.</returns>
		public abstract TList<SiteCountries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteCountries Get(TransactionManager transactionManager, JXTPortal.Entities.SiteCountriesKey key, int start, int pageLength)
		{
			return GetBySiteCountryId(transactionManager, key.SiteCountryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(System.Int32 _siteId, System.Int32 _countryId)
		{
			int count = -1;
			return GetBySiteIdCountryId(null,_siteId, _countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(System.Int32 _siteId, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdCountryId(null, _siteId, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _countryId)
		{
			int count = -1;
			return GetBySiteIdCountryId(transactionManager, _siteId, _countryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdCountryId(transactionManager, _siteId, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(System.Int32 _siteId, System.Int32 _countryId, int start, int pageLength, out int count)
		{
			return GetBySiteIdCountryId(null, _siteId, _countryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_SiteCountries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public abstract JXTPortal.Entities.SiteCountries GetBySiteIdCountryId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _countryId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="_siteCountryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteCountryId(System.Int32 _siteCountryId)
		{
			int count = -1;
			return GetBySiteCountryId(null,_siteCountryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="_siteCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteCountryId(System.Int32 _siteCountryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteCountryId(null, _siteCountryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCountryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteCountryId(TransactionManager transactionManager, System.Int32 _siteCountryId)
		{
			int count = -1;
			return GetBySiteCountryId(transactionManager, _siteCountryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteCountryId(TransactionManager transactionManager, System.Int32 _siteCountryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteCountryId(transactionManager, _siteCountryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="_siteCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public JXTPortal.Entities.SiteCountries GetBySiteCountryId(System.Int32 _siteCountryId, int start, int pageLength, out int count)
		{
			return GetBySiteCountryId(null, _siteCountryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteCo__772B9A0B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCountries"/> class.</returns>
		public abstract JXTPortal.Entities.SiteCountries GetBySiteCountryId(TransactionManager transactionManager, System.Int32 _siteCountryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteCountries_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence, ref System.Int32? siteCountryId)
		{
			 Insert(null, 0, int.MaxValue , siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence, ref siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence, ref System.Int32? siteCountryId)
		{
			 Insert(null, start, pageLength , siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence, ref siteCountryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence, ref System.Int32? siteCountryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence, ref siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence, ref System.Int32? siteCountryId);
		
		#endregion
		
		#region SiteCountries_GetBySiteIdCountryId 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdCountryId(System.Int32? siteId, System.Int32? countryId)
		{
			return GetBySiteIdCountryId(null, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdCountryId(int start, int pageLength, System.Int32? siteId, System.Int32? countryId)
		{
			return GetBySiteIdCountryId(null, start, pageLength , siteId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdCountryId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId)
		{
			return GetBySiteIdCountryId(transactionManager, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId);
		
		#endregion
		
		#region SiteCountries_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteCountries_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteCountries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteCountries_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Get_List' stored procedure. 
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
		///	This method wrap the 'SiteCountries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteCountries_GetBySiteCountryId 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteCountryId(System.Int32? siteCountryId)
		{
			return GetBySiteCountryId(null, 0, int.MaxValue , siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteCountryId(int start, int pageLength, System.Int32? siteCountryId)
		{
			return GetBySiteCountryId(null, start, pageLength , siteCountryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteCountryId(TransactionManager transactionManager, System.Int32? siteCountryId)
		{
			return GetBySiteCountryId(transactionManager, 0, int.MaxValue , siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteCountryId' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteCountryId);
		
		#endregion
		
		#region SiteCountries_GetBySiteIdFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, start, pageLength , siteId, friendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String friendlyUrl);
		
		#endregion
		
		#region SiteCountries_CustomDeleteBySiteIDCountryID 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_CustomDeleteBySiteIDCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDCountryID(System.Int32? siteId, System.Int32? countryId)
		{
			 CustomDeleteBySiteIDCountryID(null, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_CustomDeleteBySiteIDCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDCountryID(int start, int pageLength, System.Int32? siteId, System.Int32? countryId)
		{
			 CustomDeleteBySiteIDCountryID(null, start, pageLength , siteId, countryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_CustomDeleteBySiteIDCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDeleteBySiteIDCountryID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? countryId)
		{
			 CustomDeleteBySiteIDCountryID(transactionManager, 0, int.MaxValue , siteId, countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_CustomDeleteBySiteIDCountryID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomDeleteBySiteIDCountryID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? countryId);
		
		#endregion
		
		#region SiteCountries_GetByCountryId 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(System.Int32? countryId)
		{
			return GetByCountryId(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(int start, int pageLength, System.Int32? countryId)
		{
			return GetByCountryId(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(TransactionManager transactionManager, System.Int32? countryId)
		{
			return GetByCountryId(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId);
		
		#endregion
		
		#region SiteCountries_Find 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			return Find(null, start, pageLength , searchUsingOr, siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence);
		
		#endregion
		
		#region SiteCountries_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteCountryId)
		{
			 Delete(null, 0, int.MaxValue , siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteCountryId)
		{
			 Delete(null, start, pageLength , siteCountryId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteCountryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteCountryId);
		
		#endregion
		
		#region SiteCountries_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteCountries_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteCountries_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteCountries_GetPaged' stored procedure. 
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
		
		#region SiteCountries_Update 
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Update' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			 Update(null, 0, int.MaxValue , siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Update' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			 Update(null, start, pageLength , siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'SiteCountries_Update' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence)
		{
			 Update(transactionManager, 0, int.MaxValue , siteCountryId, siteId, countryId, siteCountryName, siteCountryFriendlyUrl, currency, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'SiteCountries_Update' stored procedure. 
		/// </summary>
		/// <param name="siteCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="siteCountryFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="currency"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteCountryId, System.Int32? siteId, System.Int32? countryId, System.String siteCountryName, System.String siteCountryFriendlyUrl, System.String currency, System.Int32? sequence);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteCountries&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteCountries&gt;"/></returns>
		public static TList<SiteCountries> Fill(IDataReader reader, TList<SiteCountries> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteCountries c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteCountries")
					.Append("|").Append((System.Int32)reader[((int)SiteCountriesColumn.SiteCountryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteCountries>(
					key.ToString(), // EntityTrackingKey
					"SiteCountries",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteCountries();
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
					c.SiteCountryId = (System.Int32)reader[((int)SiteCountriesColumn.SiteCountryId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteCountriesColumn.SiteId - 1)];
					c.CountryId = (System.Int32)reader[((int)SiteCountriesColumn.CountryId - 1)];
					c.SiteCountryName = (reader.IsDBNull(((int)SiteCountriesColumn.SiteCountryName - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.SiteCountryName - 1)];
					c.SiteCountryFriendlyUrl = (reader.IsDBNull(((int)SiteCountriesColumn.SiteCountryFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.SiteCountryFriendlyUrl - 1)];
					c.Currency = (reader.IsDBNull(((int)SiteCountriesColumn.Currency - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.Currency - 1)];
					c.Sequence = (System.Int32)reader[((int)SiteCountriesColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteCountries"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCountries"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteCountries entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteCountryId = (System.Int32)reader[((int)SiteCountriesColumn.SiteCountryId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteCountriesColumn.SiteId - 1)];
			entity.CountryId = (System.Int32)reader[((int)SiteCountriesColumn.CountryId - 1)];
			entity.SiteCountryName = (reader.IsDBNull(((int)SiteCountriesColumn.SiteCountryName - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.SiteCountryName - 1)];
			entity.SiteCountryFriendlyUrl = (reader.IsDBNull(((int)SiteCountriesColumn.SiteCountryFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.SiteCountryFriendlyUrl - 1)];
			entity.Currency = (reader.IsDBNull(((int)SiteCountriesColumn.Currency - 1)))?null:(System.String)reader[((int)SiteCountriesColumn.Currency - 1)];
			entity.Sequence = (System.Int32)reader[((int)SiteCountriesColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteCountries"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCountries"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteCountries entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteCountryId = (System.Int32)dataRow["SiteCountryID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.CountryId = (System.Int32)dataRow["CountryID"];
			entity.SiteCountryName = Convert.IsDBNull(dataRow["SiteCountryName"]) ? null : (System.String)dataRow["SiteCountryName"];
			entity.SiteCountryFriendlyUrl = Convert.IsDBNull(dataRow["SiteCountryFriendlyUrl"]) ? null : (System.String)dataRow["SiteCountryFriendlyUrl"];
			entity.Currency = Convert.IsDBNull(dataRow["Currency"]) ? null : (System.String)dataRow["Currency"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCountries"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteCountries Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteCountries entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Countries|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CountryId;
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountriesProvider.GetByCountryId(transactionManager, entity.CountryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.CountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteCountries object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteCountries instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteCountries Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteCountries entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Countries|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.CountryId;
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
	
	#region SiteCountriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteCountries</c>
	///</summary>
	public enum SiteCountriesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteCountriesChildEntityTypes
	
	#region SiteCountriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteCountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesFilterBuilder : SqlFilterBuilder<SiteCountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilterBuilder class.
		/// </summary>
		public SiteCountriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCountriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCountriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCountriesFilterBuilder
	
	#region SiteCountriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteCountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesParameterBuilder : ParameterizedSqlFilterBuilder<SiteCountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesParameterBuilder class.
		/// </summary>
		public SiteCountriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCountriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCountriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCountriesParameterBuilder
	
	#region SiteCountriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteCountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteCountriesSortBuilder : SqlSortBuilder<SiteCountriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesSqlSortBuilder class.
		/// </summary>
		public SiteCountriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteCountriesSortBuilder
	
} // end namespace
