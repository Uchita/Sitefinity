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
	/// This class is the base class for any <see cref="IntegrationsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IntegrationsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Integrations, JXTPortal.Entities.IntegrationsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.IntegrationsKey key)
		{
			return Delete(transactionManager, key.IntegrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_integrationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _integrationId)
		{
			return Delete(null, _integrationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _integrationId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fk_SiteID Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		public TList<Integrations> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fk_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		/// <remarks></remarks>
		public TList<Integrations> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fk_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		public TList<Integrations> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fkSiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		public TList<Integrations> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fkSiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		public TList<Integrations> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the fk_SiteID key.
		///		fk_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Integrations objects.</returns>
		public abstract TList<Integrations> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Integrations Get(TransactionManager transactionManager, JXTPortal.Entities.IntegrationsKey key, int start, int pageLength)
		{
			return GetByIntegrationId(transactionManager, key.IntegrationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="_integrationId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public JXTPortal.Entities.Integrations GetByIntegrationId(System.Int32 _integrationId)
		{
			int count = -1;
			return GetByIntegrationId(null,_integrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="_integrationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public JXTPortal.Entities.Integrations GetByIntegrationId(System.Int32 _integrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIntegrationId(null, _integrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public JXTPortal.Entities.Integrations GetByIntegrationId(TransactionManager transactionManager, System.Int32 _integrationId)
		{
			int count = -1;
			return GetByIntegrationId(transactionManager, _integrationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public JXTPortal.Entities.Integrations GetByIntegrationId(TransactionManager transactionManager, System.Int32 _integrationId, int start, int pageLength)
		{
			int count = -1;
			return GetByIntegrationId(transactionManager, _integrationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="_integrationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public JXTPortal.Entities.Integrations GetByIntegrationId(System.Int32 _integrationId, int start, int pageLength, out int count)
		{
			return GetByIntegrationId(null, _integrationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__D89568553E4E0868 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Integrations"/> class.</returns>
		public abstract JXTPortal.Entities.Integrations GetByIntegrationId(TransactionManager transactionManager, System.Int32 _integrationId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Integrations_Insert 
		
		/// <summary>
		///	This method wrap the 'Integrations_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid, ref System.Int32? integrationId)
		{
			 Insert(null, 0, int.MaxValue , siteId, integrationType, jsonText, valid, ref integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid, ref System.Int32? integrationId)
		{
			 Insert(null, start, pageLength , siteId, integrationType, jsonText, valid, ref integrationId);
		}
				
		/// <summary>
		///	This method wrap the 'Integrations_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid, ref System.Int32? integrationId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, integrationType, jsonText, valid, ref integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid, ref System.Int32? integrationId);
		
		#endregion
		
		#region Integrations_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Integrations_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Integrations_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Integrations_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Integrations_Get_List 
		
		/// <summary>
		///	This method wrap the 'Integrations_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Get_List' stored procedure. 
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
		///	This method wrap the 'Integrations_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Integrations_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Integrations_GetPaged' stored procedure. 
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
		///	This method wrap the 'Integrations_GetPaged' stored procedure. 
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
		///	This method wrap the 'Integrations_GetPaged' stored procedure. 
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
		///	This method wrap the 'Integrations_GetPaged' stored procedure. 
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
		
		#region Integrations_GetByIntegrationId 
		
		/// <summary>
		///	This method wrap the 'Integrations_GetByIntegrationId' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationId(System.Int32? integrationId)
		{
			return GetByIntegrationId(null, 0, int.MaxValue , integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_GetByIntegrationId' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationId(int start, int pageLength, System.Int32? integrationId)
		{
			return GetByIntegrationId(null, start, pageLength , integrationId);
		}
				
		/// <summary>
		///	This method wrap the 'Integrations_GetByIntegrationId' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationId(TransactionManager transactionManager, System.Int32? integrationId)
		{
			return GetByIntegrationId(transactionManager, 0, int.MaxValue , integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_GetByIntegrationId' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByIntegrationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationId);
		
		#endregion
		
		#region Integrations_Find 
		
		/// <summary>
		///	This method wrap the 'Integrations_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, integrationId, siteId, integrationType, jsonText, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, integrationId, siteId, integrationType, jsonText, valid);
		}
				
		/// <summary>
		///	This method wrap the 'Integrations_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, integrationId, siteId, integrationType, jsonText, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid);
		
		#endregion
		
		#region Integrations_Delete 
		
		/// <summary>
		///	This method wrap the 'Integrations_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? integrationId)
		{
			 Delete(null, 0, int.MaxValue , integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? integrationId)
		{
			 Delete(null, start, pageLength , integrationId);
		}
				
		/// <summary>
		///	This method wrap the 'Integrations_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? integrationId)
		{
			 Delete(transactionManager, 0, int.MaxValue , integrationId);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationId);
		
		#endregion
		
		#region Integrations_Update 
		
		/// <summary>
		///	This method wrap the 'Integrations_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , integrationId, siteId, integrationType, jsonText, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			 Update(null, start, pageLength , integrationId, siteId, integrationType, jsonText, valid);
		}
				
		/// <summary>
		///	This method wrap the 'Integrations_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , integrationId, siteId, integrationType, jsonText, valid);
		}
		
		/// <summary>
		///	This method wrap the 'Integrations_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jsonText"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationId, System.Int32? siteId, System.Int32? integrationType, System.String jsonText, System.Boolean? valid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Integrations&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Integrations&gt;"/></returns>
		public static TList<Integrations> Fill(IDataReader reader, TList<Integrations> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Integrations c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Integrations")
					.Append("|").Append((System.Int32)reader[((int)IntegrationsColumn.IntegrationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Integrations>(
					key.ToString(), // EntityTrackingKey
					"Integrations",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Integrations();
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
					c.IntegrationId = (System.Int32)reader[((int)IntegrationsColumn.IntegrationId - 1)];
					c.SiteId = (System.Int32)reader[((int)IntegrationsColumn.SiteId - 1)];
					c.IntegrationType = (reader.IsDBNull(((int)IntegrationsColumn.IntegrationType - 1)))?null:(System.Int32?)reader[((int)IntegrationsColumn.IntegrationType - 1)];
					c.JsonText = (reader.IsDBNull(((int)IntegrationsColumn.JsonText - 1)))?null:(System.String)reader[((int)IntegrationsColumn.JsonText - 1)];
					c.Valid = (System.Boolean)reader[((int)IntegrationsColumn.Valid - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)IntegrationsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)IntegrationsColumn.CreatedDate - 1)];
					c.LastModified = (reader.IsDBNull(((int)IntegrationsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)IntegrationsColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)IntegrationsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IntegrationsColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Integrations"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Integrations"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Integrations entity)
		{
			if (!reader.Read()) return;
			
			entity.IntegrationId = (System.Int32)reader[((int)IntegrationsColumn.IntegrationId - 1)];
			entity.SiteId = (System.Int32)reader[((int)IntegrationsColumn.SiteId - 1)];
			entity.IntegrationType = (reader.IsDBNull(((int)IntegrationsColumn.IntegrationType - 1)))?null:(System.Int32?)reader[((int)IntegrationsColumn.IntegrationType - 1)];
			entity.JsonText = (reader.IsDBNull(((int)IntegrationsColumn.JsonText - 1)))?null:(System.String)reader[((int)IntegrationsColumn.JsonText - 1)];
			entity.Valid = (System.Boolean)reader[((int)IntegrationsColumn.Valid - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)IntegrationsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)IntegrationsColumn.CreatedDate - 1)];
			entity.LastModified = (reader.IsDBNull(((int)IntegrationsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)IntegrationsColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)IntegrationsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IntegrationsColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Integrations"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Integrations"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Integrations entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IntegrationId = (System.Int32)dataRow["IntegrationID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.IntegrationType = Convert.IsDBNull(dataRow["IntegrationType"]) ? null : (System.Int32?)dataRow["IntegrationType"];
			entity.JsonText = Convert.IsDBNull(dataRow["JSONText"]) ? null : (System.String)dataRow["JSONText"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Integrations"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Integrations Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Integrations entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Integrations object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Integrations instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Integrations Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Integrations entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
	#region IntegrationsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Integrations</c>
	///</summary>
	public enum IntegrationsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion IntegrationsChildEntityTypes
	
	#region IntegrationsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IntegrationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Integrations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationsFilterBuilder : SqlFilterBuilder<IntegrationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilterBuilder class.
		/// </summary>
		public IntegrationsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationsFilterBuilder
	
	#region IntegrationsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IntegrationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Integrations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationsParameterBuilder : ParameterizedSqlFilterBuilder<IntegrationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationsParameterBuilder class.
		/// </summary>
		public IntegrationsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationsParameterBuilder
	
	#region IntegrationsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IntegrationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Integrations"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IntegrationsSortBuilder : SqlSortBuilder<IntegrationsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationsSqlSortBuilder class.
		/// </summary>
		public IntegrationsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IntegrationsSortBuilder
	
} // end namespace
