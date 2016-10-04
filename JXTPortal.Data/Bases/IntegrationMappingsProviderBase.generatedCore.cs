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
	/// This class is the base class for any <see cref="IntegrationMappingsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IntegrationMappingsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.IntegrationMappings, JXTPortal.Entities.IntegrationMappingsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.IntegrationMappingsKey key)
		{
			return Delete(transactionManager, key.IntegrationMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_integrationMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _integrationMappingId)
		{
			return Delete(null, _integrationMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _integrationMappingId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		FK_IntegrationMappings_SiteID Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		public TList<IntegrationMappings> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		FK_IntegrationMappings_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		/// <remarks></remarks>
		public TList<IntegrationMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		FK_IntegrationMappings_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		public TList<IntegrationMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		fkIntegrationMappingsSiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		public TList<IntegrationMappings> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		fkIntegrationMappingsSiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		public TList<IntegrationMappings> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_IntegrationMappings_SiteID key.
		///		FK_IntegrationMappings_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.IntegrationMappings objects.</returns>
		public abstract TList<IntegrationMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.IntegrationMappings Get(TransactionManager transactionManager, JXTPortal.Entities.IntegrationMappingsKey key, int start, int pageLength)
		{
			return GetByIntegrationMappingId(transactionManager, key.IntegrationMappingId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="_integrationMappingId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(System.Int32 _integrationMappingId)
		{
			int count = -1;
			return GetByIntegrationMappingId(null,_integrationMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="_integrationMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(System.Int32 _integrationMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetByIntegrationMappingId(null, _integrationMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationMappingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(TransactionManager transactionManager, System.Int32 _integrationMappingId)
		{
			int count = -1;
			return GetByIntegrationMappingId(transactionManager, _integrationMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(TransactionManager transactionManager, System.Int32 _integrationMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetByIntegrationMappingId(transactionManager, _integrationMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="_integrationMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(System.Int32 _integrationMappingId, int start, int pageLength, out int count)
		{
			return GetByIntegrationMappingId(null, _integrationMappingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Integrat__0C56D1007E497E51 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_integrationMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.IntegrationMappings"/> class.</returns>
		public abstract JXTPortal.Entities.IntegrationMappings GetByIntegrationMappingId(TransactionManager transactionManager, System.Int32 _integrationMappingId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region IntegrationMappings_Insert 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate, ref System.Int32? integrationMappingId)
		{
			 Insert(null, 0, int.MaxValue , siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate, ref integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate, ref System.Int32? integrationMappingId)
		{
			 Insert(null, start, pageLength , siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate, ref integrationMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate, ref System.Int32? integrationMappingId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate, ref integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
			/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate, ref System.Int32? integrationMappingId);
		
		#endregion
		
		#region IntegrationMappings_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region IntegrationMappings_Get_List 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Get_List' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region IntegrationMappings_GetPaged 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_GetPaged' stored procedure. 
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
		///	This method wrap the 'IntegrationMappings_GetPaged' stored procedure. 
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
		
		#region IntegrationMappings_GetByIntegrationMappingId 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetByIntegrationMappingId' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationMappingId(System.Int32? integrationMappingId)
		{
			return GetByIntegrationMappingId(null, 0, int.MaxValue , integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetByIntegrationMappingId' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationMappingId(int start, int pageLength, System.Int32? integrationMappingId)
		{
			return GetByIntegrationMappingId(null, start, pageLength , integrationMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetByIntegrationMappingId' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByIntegrationMappingId(TransactionManager transactionManager, System.Int32? integrationMappingId)
		{
			return GetByIntegrationMappingId(transactionManager, 0, int.MaxValue , integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_GetByIntegrationMappingId' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByIntegrationMappingId(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationMappingId);
		
		#endregion
		
		#region IntegrationMappings_Find 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			return Find(null, start, pageLength , searchUsingOr, integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region IntegrationMappings_Delete 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? integrationMappingId)
		{
			 Delete(null, 0, int.MaxValue , integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? integrationMappingId)
		{
			 Delete(null, start, pageLength , integrationMappingId);
		}
				
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? integrationMappingId)
		{
			 Delete(transactionManager, 0, int.MaxValue , integrationMappingId);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Delete' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationMappingId);
		
		#endregion
		
		#region IntegrationMappings_Update 
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			 Update(null, 0, int.MaxValue , integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			 Update(null, start, pageLength , integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate)
		{
			 Update(transactionManager, 0, int.MaxValue , integrationMappingId, siteId, integrationMappingTypeId, jxtEntity, jxtColumn, jxtType, jxtSize, thirdPartyEntity, thirdPartyColumn, thirdPartyType, thirdPartySize, sequence, sync, globalMapping, lastModifiedBy, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'IntegrationMappings_Update' stored procedure. 
		/// </summary>
		/// <param name="integrationMappingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="integrationMappingTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jxtEntity"> A <c>System.String</c> instance.</param>
		/// <param name="jxtColumn"> A <c>System.String</c> instance.</param>
		/// <param name="jxtType"> A <c>System.String</c> instance.</param>
		/// <param name="jxtSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="thirdPartyEntity"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyColumn"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartyType"> A <c>System.String</c> instance.</param>
		/// <param name="thirdPartySize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sync"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalMapping"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? integrationMappingId, System.Int32? siteId, System.Int32? integrationMappingTypeId, System.String jxtEntity, System.String jxtColumn, System.String jxtType, System.Int32? jxtSize, System.String thirdPartyEntity, System.String thirdPartyColumn, System.String thirdPartyType, System.Int32? thirdPartySize, System.Int32? sequence, System.Int32? sync, System.Boolean? globalMapping, System.Int32? lastModifiedBy, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;IntegrationMappings&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;IntegrationMappings&gt;"/></returns>
		public static TList<IntegrationMappings> Fill(IDataReader reader, TList<IntegrationMappings> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.IntegrationMappings c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("IntegrationMappings")
					.Append("|").Append((System.Int32)reader[((int)IntegrationMappingsColumn.IntegrationMappingId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<IntegrationMappings>(
					key.ToString(), // EntityTrackingKey
					"IntegrationMappings",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.IntegrationMappings();
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
					c.IntegrationMappingId = (System.Int32)reader[((int)IntegrationMappingsColumn.IntegrationMappingId - 1)];
					c.SiteId = (System.Int32)reader[((int)IntegrationMappingsColumn.SiteId - 1)];
					c.IntegrationMappingTypeId = (reader.IsDBNull(((int)IntegrationMappingsColumn.IntegrationMappingTypeId - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.IntegrationMappingTypeId - 1)];
					c.JxtEntity = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtEntity - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtEntity - 1)];
					c.JxtColumn = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtColumn - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtColumn - 1)];
					c.JxtType = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtType - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtType - 1)];
					c.JxtSize = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtSize - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.JxtSize - 1)];
					c.ThirdPartyEntity = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyEntity - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyEntity - 1)];
					c.ThirdPartyColumn = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyColumn - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyColumn - 1)];
					c.ThirdPartyType = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyType - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyType - 1)];
					c.ThirdPartySize = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartySize - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.ThirdPartySize - 1)];
					c.Sequence = (reader.IsDBNull(((int)IntegrationMappingsColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.Sequence - 1)];
					c.Sync = (reader.IsDBNull(((int)IntegrationMappingsColumn.Sync - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.Sync - 1)];
					c.GlobalMapping = (reader.IsDBNull(((int)IntegrationMappingsColumn.GlobalMapping - 1)))?null:(System.Boolean?)reader[((int)IntegrationMappingsColumn.GlobalMapping - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)IntegrationMappingsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.LastModifiedBy - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)IntegrationMappingsColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)IntegrationMappingsColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.IntegrationMappings"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.IntegrationMappings"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.IntegrationMappings entity)
		{
			if (!reader.Read()) return;
			
			entity.IntegrationMappingId = (System.Int32)reader[((int)IntegrationMappingsColumn.IntegrationMappingId - 1)];
			entity.SiteId = (System.Int32)reader[((int)IntegrationMappingsColumn.SiteId - 1)];
			entity.IntegrationMappingTypeId = (reader.IsDBNull(((int)IntegrationMappingsColumn.IntegrationMappingTypeId - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.IntegrationMappingTypeId - 1)];
			entity.JxtEntity = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtEntity - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtEntity - 1)];
			entity.JxtColumn = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtColumn - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtColumn - 1)];
			entity.JxtType = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtType - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.JxtType - 1)];
			entity.JxtSize = (reader.IsDBNull(((int)IntegrationMappingsColumn.JxtSize - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.JxtSize - 1)];
			entity.ThirdPartyEntity = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyEntity - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyEntity - 1)];
			entity.ThirdPartyColumn = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyColumn - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyColumn - 1)];
			entity.ThirdPartyType = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartyType - 1)))?null:(System.String)reader[((int)IntegrationMappingsColumn.ThirdPartyType - 1)];
			entity.ThirdPartySize = (reader.IsDBNull(((int)IntegrationMappingsColumn.ThirdPartySize - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.ThirdPartySize - 1)];
			entity.Sequence = (reader.IsDBNull(((int)IntegrationMappingsColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.Sequence - 1)];
			entity.Sync = (reader.IsDBNull(((int)IntegrationMappingsColumn.Sync - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.Sync - 1)];
			entity.GlobalMapping = (reader.IsDBNull(((int)IntegrationMappingsColumn.GlobalMapping - 1)))?null:(System.Boolean?)reader[((int)IntegrationMappingsColumn.GlobalMapping - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)IntegrationMappingsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IntegrationMappingsColumn.LastModifiedBy - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)IntegrationMappingsColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)IntegrationMappingsColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.IntegrationMappings"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.IntegrationMappings"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.IntegrationMappings entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IntegrationMappingId = (System.Int32)dataRow["IntegrationMappingID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.IntegrationMappingTypeId = Convert.IsDBNull(dataRow["IntegrationMappingTypeID"]) ? null : (System.Int32?)dataRow["IntegrationMappingTypeID"];
			entity.JxtEntity = Convert.IsDBNull(dataRow["JXTEntity"]) ? null : (System.String)dataRow["JXTEntity"];
			entity.JxtColumn = Convert.IsDBNull(dataRow["JXTColumn"]) ? null : (System.String)dataRow["JXTColumn"];
			entity.JxtType = Convert.IsDBNull(dataRow["JXTType"]) ? null : (System.String)dataRow["JXTType"];
			entity.JxtSize = Convert.IsDBNull(dataRow["JXTSize"]) ? null : (System.Int32?)dataRow["JXTSize"];
			entity.ThirdPartyEntity = Convert.IsDBNull(dataRow["ThirdPartyEntity"]) ? null : (System.String)dataRow["ThirdPartyEntity"];
			entity.ThirdPartyColumn = Convert.IsDBNull(dataRow["ThirdPartyColumn"]) ? null : (System.String)dataRow["ThirdPartyColumn"];
			entity.ThirdPartyType = Convert.IsDBNull(dataRow["ThirdPartyType"]) ? null : (System.String)dataRow["ThirdPartyType"];
			entity.ThirdPartySize = Convert.IsDBNull(dataRow["ThirdPartySize"]) ? null : (System.Int32?)dataRow["ThirdPartySize"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
			entity.Sync = Convert.IsDBNull(dataRow["Sync"]) ? null : (System.Int32?)dataRow["Sync"];
			entity.GlobalMapping = Convert.IsDBNull(dataRow["GlobalMapping"]) ? null : (System.Boolean?)dataRow["GlobalMapping"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModifiedDate = Convert.IsDBNull(dataRow["LastModifiedDate"]) ? null : (System.DateTime?)dataRow["LastModifiedDate"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.IntegrationMappings"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.IntegrationMappings Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.IntegrationMappings entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.IntegrationMappings object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.IntegrationMappings instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.IntegrationMappings Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.IntegrationMappings entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region IntegrationMappingsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.IntegrationMappings</c>
	///</summary>
	public enum IntegrationMappingsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion IntegrationMappingsChildEntityTypes
	
	#region IntegrationMappingsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IntegrationMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IntegrationMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationMappingsFilterBuilder : SqlFilterBuilder<IntegrationMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilterBuilder class.
		/// </summary>
		public IntegrationMappingsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationMappingsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationMappingsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationMappingsFilterBuilder
	
	#region IntegrationMappingsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IntegrationMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IntegrationMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationMappingsParameterBuilder : ParameterizedSqlFilterBuilder<IntegrationMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsParameterBuilder class.
		/// </summary>
		public IntegrationMappingsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationMappingsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationMappingsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationMappingsParameterBuilder
	
	#region IntegrationMappingsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IntegrationMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IntegrationMappings"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IntegrationMappingsSortBuilder : SqlSortBuilder<IntegrationMappingsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsSqlSortBuilder class.
		/// </summary>
		public IntegrationMappingsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IntegrationMappingsSortBuilder
	
} // end namespace
