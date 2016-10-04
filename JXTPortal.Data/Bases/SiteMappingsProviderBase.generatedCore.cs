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
	/// This class is the base class for any <see cref="SiteMappingsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteMappingsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteMappings, JXTPortal.Entities.SiteMappingsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteMappingsKey key)
		{
			return Delete(transactionManager, key.SiteMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteMappingId)
		{
			return Delete(null, _siteMappingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteMappingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteMappingId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		FK__SiteMappi__Maste__6201483D Description: 
		/// </summary>
		/// <param name="_masterSiteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetByMasterSiteId(System.Int32 _masterSiteId)
		{
			int count = -1;
			return GetByMasterSiteId(_masterSiteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		FK__SiteMappi__Maste__6201483D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_masterSiteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		/// <remarks></remarks>
		public TList<SiteMappings> GetByMasterSiteId(TransactionManager transactionManager, System.Int32 _masterSiteId)
		{
			int count = -1;
			return GetByMasterSiteId(transactionManager, _masterSiteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		FK__SiteMappi__Maste__6201483D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_masterSiteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetByMasterSiteId(TransactionManager transactionManager, System.Int32 _masterSiteId, int start, int pageLength)
		{
			int count = -1;
			return GetByMasterSiteId(transactionManager, _masterSiteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		fkSiteMappiMaste6201483d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_masterSiteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetByMasterSiteId(System.Int32 _masterSiteId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMasterSiteId(null, _masterSiteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		fkSiteMappiMaste6201483d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_masterSiteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetByMasterSiteId(System.Int32 _masterSiteId, int start, int pageLength,out int count)
		{
			return GetByMasterSiteId(null, _masterSiteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__Maste__6201483D key.
		///		FK__SiteMappi__Maste__6201483D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_masterSiteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public abstract TList<SiteMappings> GetByMasterSiteId(TransactionManager transactionManager, System.Int32 _masterSiteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		FK__SiteMappi__SiteI__610D2404 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		FK__SiteMappi__SiteI__610D2404 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		/// <remarks></remarks>
		public TList<SiteMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		FK__SiteMappi__SiteI__610D2404 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		fkSiteMappiSitei610d2404 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		fkSiteMappiSitei610d2404 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public TList<SiteMappings> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteMappi__SiteI__610D2404 key.
		///		FK__SiteMappi__SiteI__610D2404 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteMappings objects.</returns>
		public abstract TList<SiteMappings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteMappings Get(TransactionManager transactionManager, JXTPortal.Entities.SiteMappingsKey key, int start, int pageLength)
		{
			return GetBySiteMappingId(transactionManager, key.SiteMappingId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="_siteMappingId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public JXTPortal.Entities.SiteMappings GetBySiteMappingId(System.Int32 _siteMappingId)
		{
			int count = -1;
			return GetBySiteMappingId(null,_siteMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="_siteMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public JXTPortal.Entities.SiteMappings GetBySiteMappingId(System.Int32 _siteMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteMappingId(null, _siteMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteMappingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public JXTPortal.Entities.SiteMappings GetBySiteMappingId(TransactionManager transactionManager, System.Int32 _siteMappingId)
		{
			int count = -1;
			return GetBySiteMappingId(transactionManager, _siteMappingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public JXTPortal.Entities.SiteMappings GetBySiteMappingId(TransactionManager transactionManager, System.Int32 _siteMappingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteMappingId(transactionManager, _siteMappingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="_siteMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public JXTPortal.Entities.SiteMappings GetBySiteMappingId(System.Int32 _siteMappingId, int start, int pageLength, out int count)
		{
			return GetBySiteMappingId(null, _siteMappingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteMapp__C583615F5F24DB92 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteMappingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteMappings"/> class.</returns>
		public abstract JXTPortal.Entities.SiteMappings GetBySiteMappingId(TransactionManager transactionManager, System.Int32 _siteMappingId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteMappings&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteMappings&gt;"/></returns>
		public static TList<SiteMappings> Fill(IDataReader reader, TList<SiteMappings> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteMappings c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteMappings")
					.Append("|").Append((System.Int32)reader[((int)SiteMappingsColumn.SiteMappingId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteMappings>(
					key.ToString(), // EntityTrackingKey
					"SiteMappings",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteMappings();
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
					c.SiteMappingId = (System.Int32)reader[((int)SiteMappingsColumn.SiteMappingId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteMappingsColumn.SiteId - 1)];
					c.MasterSiteId = (System.Int32)reader[((int)SiteMappingsColumn.MasterSiteId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteMappings"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteMappings"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteMappings entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteMappingId = (System.Int32)reader[((int)SiteMappingsColumn.SiteMappingId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteMappingsColumn.SiteId - 1)];
			entity.MasterSiteId = (System.Int32)reader[((int)SiteMappingsColumn.MasterSiteId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteMappings"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteMappings"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteMappings entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteMappingId = (System.Int32)dataRow["SiteMappingID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.MasterSiteId = (System.Int32)dataRow["MasterSiteID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteMappings"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteMappings Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteMappings entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region MasterSiteIdSource	
			if (CanDeepLoad(entity, "Sites|MasterSiteIdSource", deepLoadType, innerList) 
				&& entity.MasterSiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.MasterSiteId;
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MasterSiteIdSource = tmpEntity;
				else
					entity.MasterSiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, entity.MasterSiteId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MasterSiteIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MasterSiteIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SitesProvider.DeepLoad(transactionManager, entity.MasterSiteIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MasterSiteIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteMappings object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteMappings instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteMappings Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteMappings entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region MasterSiteIdSource
			if (CanDeepSave(entity, "Sites|MasterSiteIdSource", deepSaveType, innerList) 
				&& entity.MasterSiteIdSource != null)
			{
				DataRepository.SitesProvider.Save(transactionManager, entity.MasterSiteIdSource);
				entity.MasterSiteId = entity.MasterSiteIdSource.SiteId;
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
	
	#region SiteMappingsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteMappings</c>
	///</summary>
	public enum SiteMappingsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at MasterSiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteMappingsChildEntityTypes
	
	#region SiteMappingsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteMappingsFilterBuilder : SqlFilterBuilder<SiteMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilterBuilder class.
		/// </summary>
		public SiteMappingsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteMappingsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteMappingsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteMappingsFilterBuilder
	
	#region SiteMappingsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteMappingsParameterBuilder : ParameterizedSqlFilterBuilder<SiteMappingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteMappingsParameterBuilder class.
		/// </summary>
		public SiteMappingsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteMappingsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteMappingsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteMappingsParameterBuilder
	
	#region SiteMappingsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteMappingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteMappings"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteMappingsSortBuilder : SqlSortBuilder<SiteMappingsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteMappingsSqlSortBuilder class.
		/// </summary>
		public SiteMappingsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteMappingsSortBuilder
	
} // end namespace
