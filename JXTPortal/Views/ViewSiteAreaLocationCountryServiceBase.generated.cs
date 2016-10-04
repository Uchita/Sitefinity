﻿
/*
	File generated by NetTiers templates [www.NetTiers.com]
	Important: Do not modify this file. Edit the file ViewSiteAreaLocationCountry.cs instead.
*/

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;
using Entities = JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;


using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion 

namespace JXTPortal
{		
	
	///<summary>
	/// An object representation of the 'ViewSiteAreaLocationCountry' View.
	///</summary>
	/// <remarks>
	/// IMPORTANT!!! You should not modify this partial  class, modify the ViewSiteAreaLocationCountry.cs file instead.
	/// All custom implementations should be done in the <see cref="ViewSiteAreaLocationCountry"/> class.
	/// </remarks>
	[DataObject]
	public partial class ViewSiteAreaLocationCountryServiceBase : ServiceViewBase<ViewSiteAreaLocationCountry>
	{

		#region Constructors
		///<summary>
		/// Creates a new <see cref="ViewSiteAreaLocationCountry"/> instance .
		///</summary>
		public ViewSiteAreaLocationCountryServiceBase() : base()
		{
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ViewSiteAreaLocationCountry"/> instance.
		///</summary>
		///<param name="_areaId"></param>
		///<param name="_siteLocationId"></param>
		///<param name="_locationId"></param>
		///<param name="_siteAreaId"></param>
		///<param name="_siteAreaName"></param>
		///<param name="_siteLocationName"></param>
		///<param name="_siteId"></param>
		///<param name="_siteLocationSiteId"></param>
		///<param name="_siteCountrySiteId"></param>
		///<param name="_countryId"></param>
		///<param name="_siteCountryName"></param>
		///<param name="_currency"></param>
		public static ViewSiteAreaLocationCountry CreateViewSiteAreaLocationCountry(System.Int32 _areaId, System.Int32 _siteLocationId, System.Int32 _locationId, System.Int32 _siteAreaId, System.String _siteAreaName, System.String _siteLocationName, System.Int32 _siteId, System.Int32 _siteLocationSiteId, System.Int32 _siteCountrySiteId, System.Int32 _countryId, System.String _siteCountryName, System.String _currency)
		{
			ViewSiteAreaLocationCountry newEntityViewSiteAreaLocationCountry = new ViewSiteAreaLocationCountry();
			newEntityViewSiteAreaLocationCountry.AreaId  = _areaId;
			newEntityViewSiteAreaLocationCountry.SiteLocationId  = _siteLocationId;
			newEntityViewSiteAreaLocationCountry.LocationId  = _locationId;
			newEntityViewSiteAreaLocationCountry.SiteAreaId  = _siteAreaId;
			newEntityViewSiteAreaLocationCountry.SiteAreaName  = _siteAreaName;
			newEntityViewSiteAreaLocationCountry.SiteLocationName  = _siteLocationName;
			newEntityViewSiteAreaLocationCountry.SiteId  = _siteId;
			newEntityViewSiteAreaLocationCountry.SiteLocationSiteId  = _siteLocationSiteId;
			newEntityViewSiteAreaLocationCountry.SiteCountrySiteId  = _siteCountrySiteId;
			newEntityViewSiteAreaLocationCountry.CountryId  = _countryId;
			newEntityViewSiteAreaLocationCountry.SiteCountryName  = _siteCountryName;
			newEntityViewSiteAreaLocationCountry.Currency  = _currency;
			return newEntityViewSiteAreaLocationCountry;
		}
		#endregion Constructors

		#region Fields
		//private static SecurityContext<ViewSiteAreaLocationCountry> securityContext = new SecurityContext<ViewSiteAreaLocationCountry>();
		private static readonly string layerExceptionPolicy = "NoneExceptionPolicy";
		private static readonly bool noTranByDefault = false;
		private static readonly int defaultMaxRecords = 10000;
		#endregion 
		
		#region Data Access Methods
			
		#region Get 
		/// <summary>
		/// Attempts to do a parameterized version of a simple whereclause. 
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks>Does NOT Support Advanced Operations such as SubSelects.  See GetPaged for that functionality.</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public override VList<ViewSiteAreaLocationCountry> Get(string whereClause, string orderBy)
		{
			int totalCount = -1;
			return Get(whereClause, orderBy, 0, defaultMaxRecords, out totalCount);
		}

		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">out parameter to get total records for query</param>
		/// <remarks>Does NOT Support Advanced Operations such as SubSelects.  See GetPaged for that functionality.</remarks>
		/// <returns>Returns a typed collection TList{ViewSiteAreaLocationCountry} of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public override VList<ViewSiteAreaLocationCountry> Get(string whereClause, string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Get");
								
			// get this data
			VList<ViewSiteAreaLocationCountry> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.ViewSiteAreaLocationCountryProvider.Get(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
				//if borrowed tran, leave open for next call
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;
		}
		
		#endregion Get Methods
		
		#region GetAll
		/// <summary>
		/// Get a complete collection of <see cref="ViewSiteAreaLocationCountry" /> entities.
		/// </summary>
		/// <returns></returns>
		public virtual VList<ViewSiteAreaLocationCountry> GetAll() 
		{
			int totalCount = -1;
			return GetAll(0, defaultMaxRecords, out totalCount);
		}

       
		/// <summary>
		/// Get a set portion of a complete list of <see cref="ViewSiteAreaLocationCountry" /> entities
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">out parameter, number of total rows in given query.</param>
		/// <returns>a <see cref="TList{ViewSiteAreaLocationCountry}"/> </returns>
		public override VList<ViewSiteAreaLocationCountry> GetAll(int start, int pageLength, out int totalCount) 
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetAll");
			
			// get this data
			VList<ViewSiteAreaLocationCountry> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;					

				//Access repository
				list = dataProvider.ViewSiteAreaLocationCountryProvider.GetAll(transactionManager, start, pageLength, out totalCount);	
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;
		}
		#endregion GetAll

		#region GetPaged
		/// <summary>
		/// Gets a page of <see cref="TList{ViewSiteAreaLocationCountry}" /> rows from the DataSource.
		/// </summary>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public virtual VList<ViewSiteAreaLocationCountry> GetPaged(out int totalCount)
		{
			return GetPaged(null, null, 0, defaultMaxRecords, out totalCount);
		}
		
		/// <summary>
		/// Gets a page of <see cref="TList{ViewSiteAreaLocationCountry}" /> rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public virtual VList<ViewSiteAreaLocationCountry> GetPaged(int start, int pageLength, out int totalCount)
		{
			return GetPaged(null, null, start, pageLength, out totalCount);
		}

		/// <summary>
		/// Gets a page of entity rows with a <see cref="TList{ViewSiteAreaLocationCountry}" /> from the DataSource with a where clause and order by clause.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public override VList<ViewSiteAreaLocationCountry> GetPaged(string whereClause,string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetPaged");
			
			// get this data
			VList<ViewSiteAreaLocationCountry> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.ViewSiteAreaLocationCountryProvider.GetPaged(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
				//if borrowed tran, leave open for next call
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;			
		}
		
		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// This method is only provided as a workaround for the ObjectDataSource's need to 
		/// execute another method to discover the total count instead of using another param, like our out param.  
		/// This method should be avoided if using the ObjectDataSource or another method.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="totalCount">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		public int GetTotalItems(string whereClause, out int totalCount)
		{
			GetPaged(whereClause, null, 0, defaultMaxRecords, out totalCount);
			return totalCount;
		}
		#endregion GetPaged	

		#region Find Methods

		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public virtual VList<ViewSiteAreaLocationCountry> Find(IFilterParameterCollection parameters)
		{
			return Find(parameters, null);
		}
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public virtual VList<ViewSiteAreaLocationCountry> Find(IFilterParameterCollection parameters, string orderBy)
		{
			int count = 0;
			return Find(parameters, orderBy, 0, defaultMaxRecords, out count);
		}
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of <c>ViewSiteAreaLocationCountry</c> objects.</returns>
		public override VList<ViewSiteAreaLocationCountry> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Find");
								
			// get this data
			TransactionManager transactionManager = null; 
			VList<ViewSiteAreaLocationCountry> list = null;
			count = -1;
			
			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.ViewSiteAreaLocationCountryProvider.Find(transactionManager, parameters, orderBy, start, pageLength, out count);
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			
			return list;
		}
		
		#endregion Find Methods
		
		#region Custom Methods
		
		#region ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public virtual void GetBySiteLocationIdSiteAreaId(System.Int32? siteLocationId, System.Int32? siteAreaId)
		{
			 GetBySiteLocationIdSiteAreaId( siteLocationId, siteAreaId, 0, defaultMaxRecords );
		}
	
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public virtual void GetBySiteLocationIdSiteAreaId(System.Int32? siteLocationId, System.Int32? siteAreaId, int start, int pageLength)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetBySiteLocationIdSiteAreaId");
			
		
			 
			TransactionManager transactionManager = null; 
			
			try
            {
				bool isBorrowedTransaction = ConnectionScope.Current.HasTransaction;				
				
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction();
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                
				//Call Custom Procedure from Repository
				dataProvider.ViewSiteAreaLocationCountryProvider.GetBySiteLocationIdSiteAreaId(transactionManager, start, pageLength , siteLocationId, siteAreaId);
	        
				//If success, Commit
				if(!isBorrowedTransaction && transactionManager != null && transactionManager.IsOpen)
					transactionManager.Commit();
            	
			}
            catch (Exception exc)
            {
				//if open, rollback
                if (transactionManager != null && transactionManager.IsOpen)
                        transactionManager.Rollback();
                    
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
            }
			
			return ;
		}
		#endregion 
		
		#region ViewSiteAreaLocationCountry_Get_List
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public virtual DataSet Get_List()
		{
			return Get_List( 0, defaultMaxRecords );
		}
	
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public virtual DataSet Get_List(int start, int pageLength)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Get_List");
			
		
			DataSet result = null; 
			TransactionManager transactionManager = null; 
			
			try
            {
				bool isBorrowedTransaction = ConnectionScope.Current.HasTransaction;				
				
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                
				//Call Custom Procedure from Repository
				result = dataProvider.ViewSiteAreaLocationCountryProvider.Get_List(transactionManager, start, pageLength );
	        
            	
			}
            catch (Exception exc)
            {
				//if open, rollback
                if (transactionManager != null && transactionManager.IsOpen)
                        transactionManager.Rollback();
                    
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
            }
			
			return result;
		}
		#endregion 
		
		#region ViewSiteAreaLocationCountry_Get
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public virtual DataSet Get(System.String whereClause, System.String orderBy, int start, int pageLength)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Get");
			
		
			DataSet result = null; 
			TransactionManager transactionManager = null; 
			
			try
            {
				bool isBorrowedTransaction = ConnectionScope.Current.HasTransaction;				
				
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                
				//Call Custom Procedure from Repository
				result = dataProvider.ViewSiteAreaLocationCountryProvider.Get(transactionManager, start, pageLength , whereClause, orderBy);
	        
            	
			}
            catch (Exception exc)
            {
				//if open, rollback
                if (transactionManager != null && transactionManager.IsOpen)
                        transactionManager.Rollback();
                    
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
            }
			
			return result;
		}
		#endregion 
		#endregion
		
		#endregion Data Access Methods
		
	
	}//End Class
} // end namespace



