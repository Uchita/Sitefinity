#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JXTPortal.Entities;
using JXTPortal.Data;

#endregion

namespace JXTPortal.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ViewJobSearchProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ViewJobSearchProviderBaseCore : EntityViewProviderBase<ViewJobSearch>
	{
		#region Custom Methods
		
		
		#region ViewJobSearch_GetBySearchFilter
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilter' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilter(System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String jobTypeIds)
		{
			return GetBySearchFilter(null, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, pageIndex, pageSize, orderBy, jobTypeIds);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilter' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilter(int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String jobTypeIds)
		{
			return GetBySearchFilter(null, start, pageLength , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, pageIndex, pageSize, orderBy, jobTypeIds);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilter' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilter(TransactionManager transactionManager, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String jobTypeIds)
		{
			return GetBySearchFilter(transactionManager, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, pageIndex, pageSize, orderBy, jobTypeIds);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilter' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public abstract VList<ViewJobSearch> GetBySearchFilter(TransactionManager transactionManager, int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy, System.String jobTypeIds);
		
		#endregion

		
		#region ViewJobSearch_GetPremiumSearchFilter
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetPremiumSearchFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetPremiumSearchFilter(System.Int32? siteId, System.Int32? professionId, System.String roleId, System.String orderBy, System.Int32? pageSize)
		{
			return GetPremiumSearchFilter(null, 0, int.MaxValue , siteId, professionId, roleId, orderBy, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetPremiumSearchFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetPremiumSearchFilter(int start, int pageLength, System.Int32? siteId, System.Int32? professionId, System.String roleId, System.String orderBy, System.Int32? pageSize)
		{
			return GetPremiumSearchFilter(null, start, pageLength , siteId, professionId, roleId, orderBy, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetPremiumSearchFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetPremiumSearchFilter(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId, System.String roleId, System.String orderBy, System.Int32? pageSize)
		{
			return GetPremiumSearchFilter(transactionManager, 0, int.MaxValue , siteId, professionId, roleId, orderBy, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetPremiumSearchFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public abstract VList<ViewJobSearch> GetPremiumSearchFilter(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteId, System.Int32? professionId, System.String roleId, System.String orderBy, System.Int32? pageSize);
		
		#endregion

		
		#region ViewJobSearch_Get_List
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion

		
		#region ViewJobSearch_GetBySearchFilterGoogleMap
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterGoogleMap' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="northEastLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="northEastLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLng"> A <c>System.Double?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilterGoogleMap(System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.String orderBy, System.String jobTypeIds, System.Double? northEastLat, System.Double? northEastLng, System.Double? southWestLat, System.Double? southWestLng)
		{
			return GetBySearchFilterGoogleMap(null, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, orderBy, jobTypeIds, northEastLat, northEastLng, southWestLat, southWestLng);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterGoogleMap' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="northEastLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="northEastLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilterGoogleMap(int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.String orderBy, System.String jobTypeIds, System.Double? northEastLat, System.Double? northEastLng, System.Double? southWestLat, System.Double? southWestLng)
		{
			return GetBySearchFilterGoogleMap(null, start, pageLength , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, orderBy, jobTypeIds, northEastLat, northEastLng, southWestLat, southWestLng);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterGoogleMap' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="northEastLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="northEastLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLng"> A <c>System.Double?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public VList<ViewJobSearch> GetBySearchFilterGoogleMap(TransactionManager transactionManager, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.String orderBy, System.String jobTypeIds, System.Double? northEastLat, System.Double? northEastLng, System.Double? southWestLat, System.Double? southWestLng)
		{
			return GetBySearchFilterGoogleMap(transactionManager, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, orderBy, jobTypeIds, northEastLat, northEastLng, southWestLat, southWestLng);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterGoogleMap' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="northEastLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="northEastLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLat"> A <c>System.Double?</c> instance.</param>
		/// <param name="southWestLng"> A <c>System.Double?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobSearch&gt;"/> instance.</returns>
		public abstract VList<ViewJobSearch> GetBySearchFilterGoogleMap(TransactionManager transactionManager, int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.String orderBy, System.String jobTypeIds, System.Double? northEastLat, System.Double? northEastLng, System.Double? southWestLat, System.Double? southWestLng);
		
		#endregion

		
		#region ViewJobSearch_GetBySearchFilterRedefine
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterRedefine' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySearchFilterRedefine(System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.String jobTypeIds)
		{
			return GetBySearchFilterRedefine(null, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, jobTypeIds);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterRedefine' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySearchFilterRedefine(int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.String jobTypeIds)
		{
			return GetBySearchFilterRedefine(null, start, pageLength , keyword, siteId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, jobTypeIds);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterRedefine' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySearchFilterRedefine(TransactionManager transactionManager, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.String jobTypeIds)
		{
			return GetBySearchFilterRedefine(transactionManager, 0, int.MaxValue , keyword, siteId, advertiserId, currencyId, salaryTypeId, salaryLowerBand, salaryUpperBand, workTypeId, professionId, roleId, countryId, locationId, areaId, dateFrom, jobTypeIds);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_GetBySearchFilterRedefine' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTypeIds"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySearchFilterRedefine(TransactionManager transactionManager, int start, int pageLength, System.String keyword, System.Int32? siteId, System.Int32? advertiserId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? workTypeId, System.Int32? professionId, System.String roleId, System.Int32? countryId, System.Int32? locationId, System.String areaId, System.DateTime? dateFrom, System.String jobTypeIds);
		
		#endregion

		
		#region ViewJobSearch_Get
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(System.String whereClause, System.String orderBy)
		{
			return Get(null, 0, int.MaxValue , whereClause, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(int start, int pageLength, System.String whereClause, System.String orderBy)
		{
			return Get(null, start, pageLength , whereClause, orderBy);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(TransactionManager transactionManager, System.String whereClause, System.String orderBy)
		{
			return Get(transactionManager, 0, int.MaxValue , whereClause, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobSearch_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get(TransactionManager transactionManager, int start, int pageLength, System.String whereClause, System.String orderBy);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ViewJobSearch&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ViewJobSearch&gt;"/></returns>
		protected static VList&lt;ViewJobSearch&gt; Fill(DataSet dataSet, VList<ViewJobSearch> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ViewJobSearch>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ViewJobSearch&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ViewJobSearch>"/></returns>
		protected static VList&lt;ViewJobSearch&gt; Fill(DataTable dataTable, VList<ViewJobSearch> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ViewJobSearch c = new ViewJobSearch();
					c.JobId = (Convert.IsDBNull(row["JobId"]))?(int)0:(System.Int32)row["JobId"];
					c.SiteId = (Convert.IsDBNull(row["SiteID"]))?(int)0:(System.Int32)row["SiteID"];
					c.JobName = (Convert.IsDBNull(row["JobName"]))?string.Empty:(System.String)row["JobName"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.FullDescription = (Convert.IsDBNull(row["FullDescription"]))?string.Empty:(System.String)row["FullDescription"];
					c.DatePosted = (Convert.IsDBNull(row["DatePosted"]))?DateTime.MinValue:(System.DateTime)row["DatePosted"];
					c.Visible = (Convert.IsDBNull(row["Visible"]))?false:(System.Boolean)row["Visible"];
					c.Expired = (Convert.IsDBNull(row["Expired"]))?(int)0:(System.Int32?)row["Expired"];
					c.ShowSalaryDetails = (Convert.IsDBNull(row["ShowSalaryDetails"]))?false:(System.Boolean)row["ShowSalaryDetails"];
					c.ShowSalaryRange = (Convert.IsDBNull(row["ShowSalaryRange"]))?false:(System.Boolean)row["ShowSalaryRange"];
					c.SalaryText = (Convert.IsDBNull(row["SalaryText"]))?string.Empty:(System.String)row["SalaryText"];
					c.AdvertiserId = (Convert.IsDBNull(row["AdvertiserID"]))?(int)0:(System.Int32?)row["AdvertiserID"];
					c.ApplicationMethod = (Convert.IsDBNull(row["ApplicationMethod"]))?(int)0:(System.Int32?)row["ApplicationMethod"];
					c.ApplicationUrl = (Convert.IsDBNull(row["ApplicationURL"]))?string.Empty:(System.String)row["ApplicationURL"];
					c.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(row["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)row["AdvertiserJobTemplateLogoID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.ShowLocationDetails = (Convert.IsDBNull(row["ShowLocationDetails"]))?false:(System.Boolean?)row["ShowLocationDetails"];
					c.BulletPoint1 = (Convert.IsDBNull(row["BulletPoint1"]))?string.Empty:(System.String)row["BulletPoint1"];
					c.BulletPoint2 = (Convert.IsDBNull(row["BulletPoint2"]))?string.Empty:(System.String)row["BulletPoint2"];
					c.BulletPoint3 = (Convert.IsDBNull(row["BulletPoint3"]))?string.Empty:(System.String)row["BulletPoint3"];
					c.HotJob = (Convert.IsDBNull(row["HotJob"]))?false:(System.Boolean)row["HotJob"];
					c.ApplicationEmailAddress = (Convert.IsDBNull(row["ApplicationEmailAddress"]))?string.Empty:(System.String)row["ApplicationEmailAddress"];
					c.ExpiryDate = (Convert.IsDBNull(row["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)row["ExpiryDate"];
					c.ContactDetails = (Convert.IsDBNull(row["ContactDetails"]))?string.Empty:(System.String)row["ContactDetails"];
					c.RefNo = (Convert.IsDBNull(row["RefNo"]))?string.Empty:(System.String)row["RefNo"];
					c.AdvertiserName = (Convert.IsDBNull(row["AdvertiserName"]))?string.Empty:(System.String)row["AdvertiserName"];
					c.CurrencySymbol = (Convert.IsDBNull(row["CurrencySymbol"]))?string.Empty:(System.String)row["CurrencySymbol"];
					c.SalaryUpperBand = (Convert.IsDBNull(row["SalaryUpperBand"]))?0.0m:(System.Decimal)row["SalaryUpperBand"];
					c.SalaryLowerBand = (Convert.IsDBNull(row["SalaryLowerBand"]))?0.0m:(System.Decimal)row["SalaryLowerBand"];
					c.SalaryTypeId = (Convert.IsDBNull(row["SalaryTypeID"]))?(int)0:(System.Int32)row["SalaryTypeID"];
					c.SalaryTypeName = (Convert.IsDBNull(row["SalaryTypeName"]))?string.Empty:(System.String)row["SalaryTypeName"];
					c.WorkTypeName = (Convert.IsDBNull(row["WorkTypeName"]))?string.Empty:(System.String)row["WorkTypeName"];
					c.CountryId = (Convert.IsDBNull(row["CountryID"]))?(int)0:(System.Int32)row["CountryID"];
					c.LocationId = (Convert.IsDBNull(row["LocationID"]))?(int)0:(System.Int32)row["LocationID"];
					c.AreaId = (Convert.IsDBNull(row["AreaID"]))?(int)0:(System.Int32)row["AreaID"];
					c.CountryName = (Convert.IsDBNull(row["CountryName"]))?string.Empty:(System.String)row["CountryName"];
					c.LocationName = (Convert.IsDBNull(row["LocationName"]))?string.Empty:(System.String)row["LocationName"];
					c.AreaName = (Convert.IsDBNull(row["AreaName"]))?string.Empty:(System.String)row["AreaName"];
					c.ProfessionId = (Convert.IsDBNull(row["ProfessionID"]))?(int)0:(System.Int32)row["ProfessionID"];
					c.RoleId = (Convert.IsDBNull(row["RoleID"]))?(int)0:(System.Int32)row["RoleID"];
					c.SiteProfessionName = (Convert.IsDBNull(row["SiteProfessionName"]))?string.Empty:(System.String)row["SiteProfessionName"];
					c.SiteRoleName = (Convert.IsDBNull(row["SiteRoleName"]))?string.Empty:(System.String)row["SiteRoleName"];
					c.BreadCrumbNavigation = (Convert.IsDBNull(row["BreadCrumbNavigation"]))?string.Empty:(System.String)row["BreadCrumbNavigation"];
					c.WorkTypeId = (Convert.IsDBNull(row["WorkTypeID"]))?(int)0:(System.Int32)row["WorkTypeID"];
					c.JobFriendlyName = (Convert.IsDBNull(row["JobFriendlyName"]))?string.Empty:(System.String)row["JobFriendlyName"];
					c.SalaryDisplay = (Convert.IsDBNull(row["SalaryDisplay"]))?string.Empty:(System.String)row["SalaryDisplay"];
					c.JobItemTypeId = (Convert.IsDBNull(row["JobItemTypeID"]))?(int)0:(System.Int32?)row["JobItemTypeID"];
					c.JobLatitude = (Convert.IsDBNull(row["JobLatitude"]))?0.0f:(System.Double?)row["JobLatitude"];
					c.JobLongitude = (Convert.IsDBNull(row["JobLongitude"]))?0.0f:(System.Double?)row["JobLongitude"];
					c.AddressStatus = (Convert.IsDBNull(row["AddressStatus"]))?(int)0:(System.Int32?)row["AddressStatus"];
					c.HasAdvertiserLogo = (Convert.IsDBNull(row["HasAdvertiserLogo"]))?(int)0:(System.Int32)row["HasAdvertiserLogo"];
					c.CustomXml = (Convert.IsDBNull(row["CustomXML"]))?string.Empty:(System.String)row["CustomXML"];
					c.Address = (Convert.IsDBNull(row["Address"]))?string.Empty:(System.String)row["Address"];
					c.PublicTransport = (Convert.IsDBNull(row["PublicTransport"]))?string.Empty:(System.String)row["PublicTransport"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;ViewJobSearch&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ViewJobSearch&gt;"/></returns>
		protected VList<ViewJobSearch> Fill(IDataReader reader, VList<ViewJobSearch> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ViewJobSearch entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ViewJobSearch>("ViewJobSearch",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ViewJobSearch();
					}
					
					entity.SuppressEntityEvents = true;

					entity.JobId = (System.Int32)reader[((int)ViewJobSearchColumn.JobId)];
					//entity.JobId = (Convert.IsDBNull(reader["JobId"]))?(int)0:(System.Int32)reader["JobId"];
					entity.SiteId = (System.Int32)reader[((int)ViewJobSearchColumn.SiteId)];
					//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
					entity.JobName = (System.String)reader[((int)ViewJobSearchColumn.JobName)];
					//entity.JobName = (Convert.IsDBNull(reader["JobName"]))?string.Empty:(System.String)reader["JobName"];
					entity.Description = (System.String)reader[((int)ViewJobSearchColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.FullDescription = (System.String)reader[((int)ViewJobSearchColumn.FullDescription)];
					//entity.FullDescription = (Convert.IsDBNull(reader["FullDescription"]))?string.Empty:(System.String)reader["FullDescription"];
					entity.DatePosted = (System.DateTime)reader[((int)ViewJobSearchColumn.DatePosted)];
					//entity.DatePosted = (Convert.IsDBNull(reader["DatePosted"]))?DateTime.MinValue:(System.DateTime)reader["DatePosted"];
					entity.Visible = (System.Boolean)reader[((int)ViewJobSearchColumn.Visible)];
					//entity.Visible = (Convert.IsDBNull(reader["Visible"]))?false:(System.Boolean)reader["Visible"];
					entity.Expired = (reader.IsDBNull(((int)ViewJobSearchColumn.Expired)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.Expired)];
					//entity.Expired = (Convert.IsDBNull(reader["Expired"]))?(int)0:(System.Int32?)reader["Expired"];
					entity.ShowSalaryDetails = (System.Boolean)reader[((int)ViewJobSearchColumn.ShowSalaryDetails)];
					//entity.ShowSalaryDetails = (Convert.IsDBNull(reader["ShowSalaryDetails"]))?false:(System.Boolean)reader["ShowSalaryDetails"];
					entity.ShowSalaryRange = (System.Boolean)reader[((int)ViewJobSearchColumn.ShowSalaryRange)];
					//entity.ShowSalaryRange = (Convert.IsDBNull(reader["ShowSalaryRange"]))?false:(System.Boolean)reader["ShowSalaryRange"];
					entity.SalaryText = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryText)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryText)];
					//entity.SalaryText = (Convert.IsDBNull(reader["SalaryText"]))?string.Empty:(System.String)reader["SalaryText"];
					entity.AdvertiserId = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AdvertiserId)];
					//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32?)reader["AdvertiserID"];
					entity.ApplicationMethod = (reader.IsDBNull(((int)ViewJobSearchColumn.ApplicationMethod)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.ApplicationMethod)];
					//entity.ApplicationMethod = (Convert.IsDBNull(reader["ApplicationMethod"]))?(int)0:(System.Int32?)reader["ApplicationMethod"];
					entity.ApplicationUrl = (reader.IsDBNull(((int)ViewJobSearchColumn.ApplicationUrl)))?null:(System.String)reader[((int)ViewJobSearchColumn.ApplicationUrl)];
					//entity.ApplicationUrl = (Convert.IsDBNull(reader["ApplicationURL"]))?string.Empty:(System.String)reader["ApplicationURL"];
					entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserJobTemplateLogoId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AdvertiserJobTemplateLogoId)];
					//entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(reader["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)reader["AdvertiserJobTemplateLogoID"];
					entity.CompanyName = (reader.IsDBNull(((int)ViewJobSearchColumn.CompanyName)))?null:(System.String)reader[((int)ViewJobSearchColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.ShowLocationDetails = (reader.IsDBNull(((int)ViewJobSearchColumn.ShowLocationDetails)))?null:(System.Boolean?)reader[((int)ViewJobSearchColumn.ShowLocationDetails)];
					//entity.ShowLocationDetails = (Convert.IsDBNull(reader["ShowLocationDetails"]))?false:(System.Boolean?)reader["ShowLocationDetails"];
					entity.BulletPoint1 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint1)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint1)];
					//entity.BulletPoint1 = (Convert.IsDBNull(reader["BulletPoint1"]))?string.Empty:(System.String)reader["BulletPoint1"];
					entity.BulletPoint2 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint2)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint2)];
					//entity.BulletPoint2 = (Convert.IsDBNull(reader["BulletPoint2"]))?string.Empty:(System.String)reader["BulletPoint2"];
					entity.BulletPoint3 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint3)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint3)];
					//entity.BulletPoint3 = (Convert.IsDBNull(reader["BulletPoint3"]))?string.Empty:(System.String)reader["BulletPoint3"];
					entity.HotJob = (System.Boolean)reader[((int)ViewJobSearchColumn.HotJob)];
					//entity.HotJob = (Convert.IsDBNull(reader["HotJob"]))?false:(System.Boolean)reader["HotJob"];
					entity.ApplicationEmailAddress = (System.String)reader[((int)ViewJobSearchColumn.ApplicationEmailAddress)];
					//entity.ApplicationEmailAddress = (Convert.IsDBNull(reader["ApplicationEmailAddress"]))?string.Empty:(System.String)reader["ApplicationEmailAddress"];
					entity.ExpiryDate = (System.DateTime)reader[((int)ViewJobSearchColumn.ExpiryDate)];
					//entity.ExpiryDate = (Convert.IsDBNull(reader["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)reader["ExpiryDate"];
					entity.ContactDetails = (System.String)reader[((int)ViewJobSearchColumn.ContactDetails)];
					//entity.ContactDetails = (Convert.IsDBNull(reader["ContactDetails"]))?string.Empty:(System.String)reader["ContactDetails"];
					entity.RefNo = (reader.IsDBNull(((int)ViewJobSearchColumn.RefNo)))?null:(System.String)reader[((int)ViewJobSearchColumn.RefNo)];
					//entity.RefNo = (Convert.IsDBNull(reader["RefNo"]))?string.Empty:(System.String)reader["RefNo"];
					entity.AdvertiserName = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserName)))?null:(System.String)reader[((int)ViewJobSearchColumn.AdvertiserName)];
					//entity.AdvertiserName = (Convert.IsDBNull(reader["AdvertiserName"]))?string.Empty:(System.String)reader["AdvertiserName"];
					entity.CurrencySymbol = (reader.IsDBNull(((int)ViewJobSearchColumn.CurrencySymbol)))?null:(System.String)reader[((int)ViewJobSearchColumn.CurrencySymbol)];
					//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
					entity.SalaryUpperBand = (System.Decimal)reader[((int)ViewJobSearchColumn.SalaryUpperBand)];
					//entity.SalaryUpperBand = (Convert.IsDBNull(reader["SalaryUpperBand"]))?0.0m:(System.Decimal)reader["SalaryUpperBand"];
					entity.SalaryLowerBand = (System.Decimal)reader[((int)ViewJobSearchColumn.SalaryLowerBand)];
					//entity.SalaryLowerBand = (Convert.IsDBNull(reader["SalaryLowerBand"]))?0.0m:(System.Decimal)reader["SalaryLowerBand"];
					entity.SalaryTypeId = (System.Int32)reader[((int)ViewJobSearchColumn.SalaryTypeId)];
					//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeID"]))?(int)0:(System.Int32)reader["SalaryTypeID"];
					entity.SalaryTypeName = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryTypeName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryTypeName)];
					//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
					entity.WorkTypeName = (System.String)reader[((int)ViewJobSearchColumn.WorkTypeName)];
					//entity.WorkTypeName = (Convert.IsDBNull(reader["WorkTypeName"]))?string.Empty:(System.String)reader["WorkTypeName"];
					entity.CountryId = (System.Int32)reader[((int)ViewJobSearchColumn.CountryId)];
					//entity.CountryId = (Convert.IsDBNull(reader["CountryID"]))?(int)0:(System.Int32)reader["CountryID"];
					entity.LocationId = (System.Int32)reader[((int)ViewJobSearchColumn.LocationId)];
					//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
					entity.AreaId = (System.Int32)reader[((int)ViewJobSearchColumn.AreaId)];
					//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
					entity.CountryName = (reader.IsDBNull(((int)ViewJobSearchColumn.CountryName)))?null:(System.String)reader[((int)ViewJobSearchColumn.CountryName)];
					//entity.CountryName = (Convert.IsDBNull(reader["CountryName"]))?string.Empty:(System.String)reader["CountryName"];
					entity.LocationName = (reader.IsDBNull(((int)ViewJobSearchColumn.LocationName)))?null:(System.String)reader[((int)ViewJobSearchColumn.LocationName)];
					//entity.LocationName = (Convert.IsDBNull(reader["LocationName"]))?string.Empty:(System.String)reader["LocationName"];
					entity.AreaName = (reader.IsDBNull(((int)ViewJobSearchColumn.AreaName)))?null:(System.String)reader[((int)ViewJobSearchColumn.AreaName)];
					//entity.AreaName = (Convert.IsDBNull(reader["AreaName"]))?string.Empty:(System.String)reader["AreaName"];
					entity.ProfessionId = (System.Int32)reader[((int)ViewJobSearchColumn.ProfessionId)];
					//entity.ProfessionId = (Convert.IsDBNull(reader["ProfessionID"]))?(int)0:(System.Int32)reader["ProfessionID"];
					entity.RoleId = (System.Int32)reader[((int)ViewJobSearchColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32)reader["RoleID"];
					entity.SiteProfessionName = (reader.IsDBNull(((int)ViewJobSearchColumn.SiteProfessionName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SiteProfessionName)];
					//entity.SiteProfessionName = (Convert.IsDBNull(reader["SiteProfessionName"]))?string.Empty:(System.String)reader["SiteProfessionName"];
					entity.SiteRoleName = (reader.IsDBNull(((int)ViewJobSearchColumn.SiteRoleName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SiteRoleName)];
					//entity.SiteRoleName = (Convert.IsDBNull(reader["SiteRoleName"]))?string.Empty:(System.String)reader["SiteRoleName"];
					entity.BreadCrumbNavigation = (reader.IsDBNull(((int)ViewJobSearchColumn.BreadCrumbNavigation)))?null:(System.String)reader[((int)ViewJobSearchColumn.BreadCrumbNavigation)];
					//entity.BreadCrumbNavigation = (Convert.IsDBNull(reader["BreadCrumbNavigation"]))?string.Empty:(System.String)reader["BreadCrumbNavigation"];
					entity.WorkTypeId = (System.Int32)reader[((int)ViewJobSearchColumn.WorkTypeId)];
					//entity.WorkTypeId = (Convert.IsDBNull(reader["WorkTypeID"]))?(int)0:(System.Int32)reader["WorkTypeID"];
					entity.JobFriendlyName = (System.String)reader[((int)ViewJobSearchColumn.JobFriendlyName)];
					//entity.JobFriendlyName = (Convert.IsDBNull(reader["JobFriendlyName"]))?string.Empty:(System.String)reader["JobFriendlyName"];
					entity.SalaryDisplay = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryDisplay)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryDisplay)];
					//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
					entity.JobItemTypeId = (reader.IsDBNull(((int)ViewJobSearchColumn.JobItemTypeId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.JobItemTypeId)];
					//entity.JobItemTypeId = (Convert.IsDBNull(reader["JobItemTypeID"]))?(int)0:(System.Int32?)reader["JobItemTypeID"];
					entity.JobLatitude = (reader.IsDBNull(((int)ViewJobSearchColumn.JobLatitude)))?null:(System.Double?)reader[((int)ViewJobSearchColumn.JobLatitude)];
					//entity.JobLatitude = (Convert.IsDBNull(reader["JobLatitude"]))?0.0f:(System.Double?)reader["JobLatitude"];
					entity.JobLongitude = (reader.IsDBNull(((int)ViewJobSearchColumn.JobLongitude)))?null:(System.Double?)reader[((int)ViewJobSearchColumn.JobLongitude)];
					//entity.JobLongitude = (Convert.IsDBNull(reader["JobLongitude"]))?0.0f:(System.Double?)reader["JobLongitude"];
					entity.AddressStatus = (reader.IsDBNull(((int)ViewJobSearchColumn.AddressStatus)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AddressStatus)];
					//entity.AddressStatus = (Convert.IsDBNull(reader["AddressStatus"]))?(int)0:(System.Int32?)reader["AddressStatus"];
					entity.HasAdvertiserLogo = (System.Int32)reader[((int)ViewJobSearchColumn.HasAdvertiserLogo)];
					//entity.HasAdvertiserLogo = (Convert.IsDBNull(reader["HasAdvertiserLogo"]))?(int)0:(System.Int32)reader["HasAdvertiserLogo"];
					entity.CustomXml = (reader.IsDBNull(((int)ViewJobSearchColumn.CustomXml)))?null:(System.String)reader[((int)ViewJobSearchColumn.CustomXml)];
					//entity.CustomXml = (Convert.IsDBNull(reader["CustomXML"]))?string.Empty:(System.String)reader["CustomXML"];
					entity.Address = (reader.IsDBNull(((int)ViewJobSearchColumn.Address)))?null:(System.String)reader[((int)ViewJobSearchColumn.Address)];
					//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
					entity.PublicTransport = (reader.IsDBNull(((int)ViewJobSearchColumn.PublicTransport)))?null:(System.String)reader[((int)ViewJobSearchColumn.PublicTransport)];
					//entity.PublicTransport = (Convert.IsDBNull(reader["PublicTransport"]))?string.Empty:(System.String)reader["PublicTransport"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="ViewJobSearch"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewJobSearch"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ViewJobSearch entity)
		{
			reader.Read();
			entity.JobId = (System.Int32)reader[((int)ViewJobSearchColumn.JobId)];
			//entity.JobId = (Convert.IsDBNull(reader["JobId"]))?(int)0:(System.Int32)reader["JobId"];
			entity.SiteId = (System.Int32)reader[((int)ViewJobSearchColumn.SiteId)];
			//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
			entity.JobName = (System.String)reader[((int)ViewJobSearchColumn.JobName)];
			//entity.JobName = (Convert.IsDBNull(reader["JobName"]))?string.Empty:(System.String)reader["JobName"];
			entity.Description = (System.String)reader[((int)ViewJobSearchColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.FullDescription = (System.String)reader[((int)ViewJobSearchColumn.FullDescription)];
			//entity.FullDescription = (Convert.IsDBNull(reader["FullDescription"]))?string.Empty:(System.String)reader["FullDescription"];
			entity.DatePosted = (System.DateTime)reader[((int)ViewJobSearchColumn.DatePosted)];
			//entity.DatePosted = (Convert.IsDBNull(reader["DatePosted"]))?DateTime.MinValue:(System.DateTime)reader["DatePosted"];
			entity.Visible = (System.Boolean)reader[((int)ViewJobSearchColumn.Visible)];
			//entity.Visible = (Convert.IsDBNull(reader["Visible"]))?false:(System.Boolean)reader["Visible"];
			entity.Expired = (reader.IsDBNull(((int)ViewJobSearchColumn.Expired)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.Expired)];
			//entity.Expired = (Convert.IsDBNull(reader["Expired"]))?(int)0:(System.Int32?)reader["Expired"];
			entity.ShowSalaryDetails = (System.Boolean)reader[((int)ViewJobSearchColumn.ShowSalaryDetails)];
			//entity.ShowSalaryDetails = (Convert.IsDBNull(reader["ShowSalaryDetails"]))?false:(System.Boolean)reader["ShowSalaryDetails"];
			entity.ShowSalaryRange = (System.Boolean)reader[((int)ViewJobSearchColumn.ShowSalaryRange)];
			//entity.ShowSalaryRange = (Convert.IsDBNull(reader["ShowSalaryRange"]))?false:(System.Boolean)reader["ShowSalaryRange"];
			entity.SalaryText = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryText)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryText)];
			//entity.SalaryText = (Convert.IsDBNull(reader["SalaryText"]))?string.Empty:(System.String)reader["SalaryText"];
			entity.AdvertiserId = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AdvertiserId)];
			//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32?)reader["AdvertiserID"];
			entity.ApplicationMethod = (reader.IsDBNull(((int)ViewJobSearchColumn.ApplicationMethod)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.ApplicationMethod)];
			//entity.ApplicationMethod = (Convert.IsDBNull(reader["ApplicationMethod"]))?(int)0:(System.Int32?)reader["ApplicationMethod"];
			entity.ApplicationUrl = (reader.IsDBNull(((int)ViewJobSearchColumn.ApplicationUrl)))?null:(System.String)reader[((int)ViewJobSearchColumn.ApplicationUrl)];
			//entity.ApplicationUrl = (Convert.IsDBNull(reader["ApplicationURL"]))?string.Empty:(System.String)reader["ApplicationURL"];
			entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserJobTemplateLogoId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AdvertiserJobTemplateLogoId)];
			//entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(reader["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)reader["AdvertiserJobTemplateLogoID"];
			entity.CompanyName = (reader.IsDBNull(((int)ViewJobSearchColumn.CompanyName)))?null:(System.String)reader[((int)ViewJobSearchColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.ShowLocationDetails = (reader.IsDBNull(((int)ViewJobSearchColumn.ShowLocationDetails)))?null:(System.Boolean?)reader[((int)ViewJobSearchColumn.ShowLocationDetails)];
			//entity.ShowLocationDetails = (Convert.IsDBNull(reader["ShowLocationDetails"]))?false:(System.Boolean?)reader["ShowLocationDetails"];
			entity.BulletPoint1 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint1)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint1)];
			//entity.BulletPoint1 = (Convert.IsDBNull(reader["BulletPoint1"]))?string.Empty:(System.String)reader["BulletPoint1"];
			entity.BulletPoint2 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint2)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint2)];
			//entity.BulletPoint2 = (Convert.IsDBNull(reader["BulletPoint2"]))?string.Empty:(System.String)reader["BulletPoint2"];
			entity.BulletPoint3 = (reader.IsDBNull(((int)ViewJobSearchColumn.BulletPoint3)))?null:(System.String)reader[((int)ViewJobSearchColumn.BulletPoint3)];
			//entity.BulletPoint3 = (Convert.IsDBNull(reader["BulletPoint3"]))?string.Empty:(System.String)reader["BulletPoint3"];
			entity.HotJob = (System.Boolean)reader[((int)ViewJobSearchColumn.HotJob)];
			//entity.HotJob = (Convert.IsDBNull(reader["HotJob"]))?false:(System.Boolean)reader["HotJob"];
			entity.ApplicationEmailAddress = (System.String)reader[((int)ViewJobSearchColumn.ApplicationEmailAddress)];
			//entity.ApplicationEmailAddress = (Convert.IsDBNull(reader["ApplicationEmailAddress"]))?string.Empty:(System.String)reader["ApplicationEmailAddress"];
			entity.ExpiryDate = (System.DateTime)reader[((int)ViewJobSearchColumn.ExpiryDate)];
			//entity.ExpiryDate = (Convert.IsDBNull(reader["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)reader["ExpiryDate"];
			entity.ContactDetails = (System.String)reader[((int)ViewJobSearchColumn.ContactDetails)];
			//entity.ContactDetails = (Convert.IsDBNull(reader["ContactDetails"]))?string.Empty:(System.String)reader["ContactDetails"];
			entity.RefNo = (reader.IsDBNull(((int)ViewJobSearchColumn.RefNo)))?null:(System.String)reader[((int)ViewJobSearchColumn.RefNo)];
			//entity.RefNo = (Convert.IsDBNull(reader["RefNo"]))?string.Empty:(System.String)reader["RefNo"];
			entity.AdvertiserName = (reader.IsDBNull(((int)ViewJobSearchColumn.AdvertiserName)))?null:(System.String)reader[((int)ViewJobSearchColumn.AdvertiserName)];
			//entity.AdvertiserName = (Convert.IsDBNull(reader["AdvertiserName"]))?string.Empty:(System.String)reader["AdvertiserName"];
			entity.CurrencySymbol = (reader.IsDBNull(((int)ViewJobSearchColumn.CurrencySymbol)))?null:(System.String)reader[((int)ViewJobSearchColumn.CurrencySymbol)];
			//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
			entity.SalaryUpperBand = (System.Decimal)reader[((int)ViewJobSearchColumn.SalaryUpperBand)];
			//entity.SalaryUpperBand = (Convert.IsDBNull(reader["SalaryUpperBand"]))?0.0m:(System.Decimal)reader["SalaryUpperBand"];
			entity.SalaryLowerBand = (System.Decimal)reader[((int)ViewJobSearchColumn.SalaryLowerBand)];
			//entity.SalaryLowerBand = (Convert.IsDBNull(reader["SalaryLowerBand"]))?0.0m:(System.Decimal)reader["SalaryLowerBand"];
			entity.SalaryTypeId = (System.Int32)reader[((int)ViewJobSearchColumn.SalaryTypeId)];
			//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeID"]))?(int)0:(System.Int32)reader["SalaryTypeID"];
			entity.SalaryTypeName = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryTypeName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryTypeName)];
			//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
			entity.WorkTypeName = (System.String)reader[((int)ViewJobSearchColumn.WorkTypeName)];
			//entity.WorkTypeName = (Convert.IsDBNull(reader["WorkTypeName"]))?string.Empty:(System.String)reader["WorkTypeName"];
			entity.CountryId = (System.Int32)reader[((int)ViewJobSearchColumn.CountryId)];
			//entity.CountryId = (Convert.IsDBNull(reader["CountryID"]))?(int)0:(System.Int32)reader["CountryID"];
			entity.LocationId = (System.Int32)reader[((int)ViewJobSearchColumn.LocationId)];
			//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
			entity.AreaId = (System.Int32)reader[((int)ViewJobSearchColumn.AreaId)];
			//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
			entity.CountryName = (reader.IsDBNull(((int)ViewJobSearchColumn.CountryName)))?null:(System.String)reader[((int)ViewJobSearchColumn.CountryName)];
			//entity.CountryName = (Convert.IsDBNull(reader["CountryName"]))?string.Empty:(System.String)reader["CountryName"];
			entity.LocationName = (reader.IsDBNull(((int)ViewJobSearchColumn.LocationName)))?null:(System.String)reader[((int)ViewJobSearchColumn.LocationName)];
			//entity.LocationName = (Convert.IsDBNull(reader["LocationName"]))?string.Empty:(System.String)reader["LocationName"];
			entity.AreaName = (reader.IsDBNull(((int)ViewJobSearchColumn.AreaName)))?null:(System.String)reader[((int)ViewJobSearchColumn.AreaName)];
			//entity.AreaName = (Convert.IsDBNull(reader["AreaName"]))?string.Empty:(System.String)reader["AreaName"];
			entity.ProfessionId = (System.Int32)reader[((int)ViewJobSearchColumn.ProfessionId)];
			//entity.ProfessionId = (Convert.IsDBNull(reader["ProfessionID"]))?(int)0:(System.Int32)reader["ProfessionID"];
			entity.RoleId = (System.Int32)reader[((int)ViewJobSearchColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32)reader["RoleID"];
			entity.SiteProfessionName = (reader.IsDBNull(((int)ViewJobSearchColumn.SiteProfessionName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SiteProfessionName)];
			//entity.SiteProfessionName = (Convert.IsDBNull(reader["SiteProfessionName"]))?string.Empty:(System.String)reader["SiteProfessionName"];
			entity.SiteRoleName = (reader.IsDBNull(((int)ViewJobSearchColumn.SiteRoleName)))?null:(System.String)reader[((int)ViewJobSearchColumn.SiteRoleName)];
			//entity.SiteRoleName = (Convert.IsDBNull(reader["SiteRoleName"]))?string.Empty:(System.String)reader["SiteRoleName"];
			entity.BreadCrumbNavigation = (reader.IsDBNull(((int)ViewJobSearchColumn.BreadCrumbNavigation)))?null:(System.String)reader[((int)ViewJobSearchColumn.BreadCrumbNavigation)];
			//entity.BreadCrumbNavigation = (Convert.IsDBNull(reader["BreadCrumbNavigation"]))?string.Empty:(System.String)reader["BreadCrumbNavigation"];
			entity.WorkTypeId = (System.Int32)reader[((int)ViewJobSearchColumn.WorkTypeId)];
			//entity.WorkTypeId = (Convert.IsDBNull(reader["WorkTypeID"]))?(int)0:(System.Int32)reader["WorkTypeID"];
			entity.JobFriendlyName = (System.String)reader[((int)ViewJobSearchColumn.JobFriendlyName)];
			//entity.JobFriendlyName = (Convert.IsDBNull(reader["JobFriendlyName"]))?string.Empty:(System.String)reader["JobFriendlyName"];
			entity.SalaryDisplay = (reader.IsDBNull(((int)ViewJobSearchColumn.SalaryDisplay)))?null:(System.String)reader[((int)ViewJobSearchColumn.SalaryDisplay)];
			//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
			entity.JobItemTypeId = (reader.IsDBNull(((int)ViewJobSearchColumn.JobItemTypeId)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.JobItemTypeId)];
			//entity.JobItemTypeId = (Convert.IsDBNull(reader["JobItemTypeID"]))?(int)0:(System.Int32?)reader["JobItemTypeID"];
			entity.JobLatitude = (reader.IsDBNull(((int)ViewJobSearchColumn.JobLatitude)))?null:(System.Double?)reader[((int)ViewJobSearchColumn.JobLatitude)];
			//entity.JobLatitude = (Convert.IsDBNull(reader["JobLatitude"]))?0.0f:(System.Double?)reader["JobLatitude"];
			entity.JobLongitude = (reader.IsDBNull(((int)ViewJobSearchColumn.JobLongitude)))?null:(System.Double?)reader[((int)ViewJobSearchColumn.JobLongitude)];
			//entity.JobLongitude = (Convert.IsDBNull(reader["JobLongitude"]))?0.0f:(System.Double?)reader["JobLongitude"];
			entity.AddressStatus = (reader.IsDBNull(((int)ViewJobSearchColumn.AddressStatus)))?null:(System.Int32?)reader[((int)ViewJobSearchColumn.AddressStatus)];
			//entity.AddressStatus = (Convert.IsDBNull(reader["AddressStatus"]))?(int)0:(System.Int32?)reader["AddressStatus"];
			entity.HasAdvertiserLogo = (System.Int32)reader[((int)ViewJobSearchColumn.HasAdvertiserLogo)];
			//entity.HasAdvertiserLogo = (Convert.IsDBNull(reader["HasAdvertiserLogo"]))?(int)0:(System.Int32)reader["HasAdvertiserLogo"];
			entity.CustomXml = (reader.IsDBNull(((int)ViewJobSearchColumn.CustomXml)))?null:(System.String)reader[((int)ViewJobSearchColumn.CustomXml)];
			//entity.CustomXml = (Convert.IsDBNull(reader["CustomXML"]))?string.Empty:(System.String)reader["CustomXML"];
			entity.Address = (reader.IsDBNull(((int)ViewJobSearchColumn.Address)))?null:(System.String)reader[((int)ViewJobSearchColumn.Address)];
			//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
			entity.PublicTransport = (reader.IsDBNull(((int)ViewJobSearchColumn.PublicTransport)))?null:(System.String)reader[((int)ViewJobSearchColumn.PublicTransport)];
			//entity.PublicTransport = (Convert.IsDBNull(reader["PublicTransport"]))?string.Empty:(System.String)reader["PublicTransport"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ViewJobSearch"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewJobSearch"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ViewJobSearch entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobId = (Convert.IsDBNull(dataRow["JobId"]))?(int)0:(System.Int32)dataRow["JobId"];
			entity.SiteId = (Convert.IsDBNull(dataRow["SiteID"]))?(int)0:(System.Int32)dataRow["SiteID"];
			entity.JobName = (Convert.IsDBNull(dataRow["JobName"]))?string.Empty:(System.String)dataRow["JobName"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.FullDescription = (Convert.IsDBNull(dataRow["FullDescription"]))?string.Empty:(System.String)dataRow["FullDescription"];
			entity.DatePosted = (Convert.IsDBNull(dataRow["DatePosted"]))?DateTime.MinValue:(System.DateTime)dataRow["DatePosted"];
			entity.Visible = (Convert.IsDBNull(dataRow["Visible"]))?false:(System.Boolean)dataRow["Visible"];
			entity.Expired = (Convert.IsDBNull(dataRow["Expired"]))?(int)0:(System.Int32?)dataRow["Expired"];
			entity.ShowSalaryDetails = (Convert.IsDBNull(dataRow["ShowSalaryDetails"]))?false:(System.Boolean)dataRow["ShowSalaryDetails"];
			entity.ShowSalaryRange = (Convert.IsDBNull(dataRow["ShowSalaryRange"]))?false:(System.Boolean)dataRow["ShowSalaryRange"];
			entity.SalaryText = (Convert.IsDBNull(dataRow["SalaryText"]))?string.Empty:(System.String)dataRow["SalaryText"];
			entity.AdvertiserId = (Convert.IsDBNull(dataRow["AdvertiserID"]))?(int)0:(System.Int32?)dataRow["AdvertiserID"];
			entity.ApplicationMethod = (Convert.IsDBNull(dataRow["ApplicationMethod"]))?(int)0:(System.Int32?)dataRow["ApplicationMethod"];
			entity.ApplicationUrl = (Convert.IsDBNull(dataRow["ApplicationURL"]))?string.Empty:(System.String)dataRow["ApplicationURL"];
			entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(dataRow["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)dataRow["AdvertiserJobTemplateLogoID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.ShowLocationDetails = (Convert.IsDBNull(dataRow["ShowLocationDetails"]))?false:(System.Boolean?)dataRow["ShowLocationDetails"];
			entity.BulletPoint1 = (Convert.IsDBNull(dataRow["BulletPoint1"]))?string.Empty:(System.String)dataRow["BulletPoint1"];
			entity.BulletPoint2 = (Convert.IsDBNull(dataRow["BulletPoint2"]))?string.Empty:(System.String)dataRow["BulletPoint2"];
			entity.BulletPoint3 = (Convert.IsDBNull(dataRow["BulletPoint3"]))?string.Empty:(System.String)dataRow["BulletPoint3"];
			entity.HotJob = (Convert.IsDBNull(dataRow["HotJob"]))?false:(System.Boolean)dataRow["HotJob"];
			entity.ApplicationEmailAddress = (Convert.IsDBNull(dataRow["ApplicationEmailAddress"]))?string.Empty:(System.String)dataRow["ApplicationEmailAddress"];
			entity.ExpiryDate = (Convert.IsDBNull(dataRow["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ExpiryDate"];
			entity.ContactDetails = (Convert.IsDBNull(dataRow["ContactDetails"]))?string.Empty:(System.String)dataRow["ContactDetails"];
			entity.RefNo = (Convert.IsDBNull(dataRow["RefNo"]))?string.Empty:(System.String)dataRow["RefNo"];
			entity.AdvertiserName = (Convert.IsDBNull(dataRow["AdvertiserName"]))?string.Empty:(System.String)dataRow["AdvertiserName"];
			entity.CurrencySymbol = (Convert.IsDBNull(dataRow["CurrencySymbol"]))?string.Empty:(System.String)dataRow["CurrencySymbol"];
			entity.SalaryUpperBand = (Convert.IsDBNull(dataRow["SalaryUpperBand"]))?0.0m:(System.Decimal)dataRow["SalaryUpperBand"];
			entity.SalaryLowerBand = (Convert.IsDBNull(dataRow["SalaryLowerBand"]))?0.0m:(System.Decimal)dataRow["SalaryLowerBand"];
			entity.SalaryTypeId = (Convert.IsDBNull(dataRow["SalaryTypeID"]))?(int)0:(System.Int32)dataRow["SalaryTypeID"];
			entity.SalaryTypeName = (Convert.IsDBNull(dataRow["SalaryTypeName"]))?string.Empty:(System.String)dataRow["SalaryTypeName"];
			entity.WorkTypeName = (Convert.IsDBNull(dataRow["WorkTypeName"]))?string.Empty:(System.String)dataRow["WorkTypeName"];
			entity.CountryId = (Convert.IsDBNull(dataRow["CountryID"]))?(int)0:(System.Int32)dataRow["CountryID"];
			entity.LocationId = (Convert.IsDBNull(dataRow["LocationID"]))?(int)0:(System.Int32)dataRow["LocationID"];
			entity.AreaId = (Convert.IsDBNull(dataRow["AreaID"]))?(int)0:(System.Int32)dataRow["AreaID"];
			entity.CountryName = (Convert.IsDBNull(dataRow["CountryName"]))?string.Empty:(System.String)dataRow["CountryName"];
			entity.LocationName = (Convert.IsDBNull(dataRow["LocationName"]))?string.Empty:(System.String)dataRow["LocationName"];
			entity.AreaName = (Convert.IsDBNull(dataRow["AreaName"]))?string.Empty:(System.String)dataRow["AreaName"];
			entity.ProfessionId = (Convert.IsDBNull(dataRow["ProfessionID"]))?(int)0:(System.Int32)dataRow["ProfessionID"];
			entity.RoleId = (Convert.IsDBNull(dataRow["RoleID"]))?(int)0:(System.Int32)dataRow["RoleID"];
			entity.SiteProfessionName = (Convert.IsDBNull(dataRow["SiteProfessionName"]))?string.Empty:(System.String)dataRow["SiteProfessionName"];
			entity.SiteRoleName = (Convert.IsDBNull(dataRow["SiteRoleName"]))?string.Empty:(System.String)dataRow["SiteRoleName"];
			entity.BreadCrumbNavigation = (Convert.IsDBNull(dataRow["BreadCrumbNavigation"]))?string.Empty:(System.String)dataRow["BreadCrumbNavigation"];
			entity.WorkTypeId = (Convert.IsDBNull(dataRow["WorkTypeID"]))?(int)0:(System.Int32)dataRow["WorkTypeID"];
			entity.JobFriendlyName = (Convert.IsDBNull(dataRow["JobFriendlyName"]))?string.Empty:(System.String)dataRow["JobFriendlyName"];
			entity.SalaryDisplay = (Convert.IsDBNull(dataRow["SalaryDisplay"]))?string.Empty:(System.String)dataRow["SalaryDisplay"];
			entity.JobItemTypeId = (Convert.IsDBNull(dataRow["JobItemTypeID"]))?(int)0:(System.Int32?)dataRow["JobItemTypeID"];
			entity.JobLatitude = (Convert.IsDBNull(dataRow["JobLatitude"]))?0.0f:(System.Double?)dataRow["JobLatitude"];
			entity.JobLongitude = (Convert.IsDBNull(dataRow["JobLongitude"]))?0.0f:(System.Double?)dataRow["JobLongitude"];
			entity.AddressStatus = (Convert.IsDBNull(dataRow["AddressStatus"]))?(int)0:(System.Int32?)dataRow["AddressStatus"];
			entity.HasAdvertiserLogo = (Convert.IsDBNull(dataRow["HasAdvertiserLogo"]))?(int)0:(System.Int32)dataRow["HasAdvertiserLogo"];
			entity.CustomXml = (Convert.IsDBNull(dataRow["CustomXML"]))?string.Empty:(System.String)dataRow["CustomXML"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?string.Empty:(System.String)dataRow["Address"];
			entity.PublicTransport = (Convert.IsDBNull(dataRow["PublicTransport"]))?string.Empty:(System.String)dataRow["PublicTransport"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ViewJobSearchFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchFilterBuilder : SqlFilterBuilder<ViewJobSearchColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilterBuilder class.
		/// </summary>
		public ViewJobSearchFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobSearchFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobSearchFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobSearchFilterBuilder

	#region ViewJobSearchParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchParameterBuilder : ParameterizedSqlFilterBuilder<ViewJobSearchColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchParameterBuilder class.
		/// </summary>
		public ViewJobSearchParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobSearchParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobSearchParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobSearchParameterBuilder
	
	#region ViewJobSearchSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ViewJobSearchSortBuilder : SqlSortBuilder<ViewJobSearchColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchSqlSortBuilder class.
		/// </summary>
		public ViewJobSearchSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ViewJobSearchSortBuilder

} // end namespace
