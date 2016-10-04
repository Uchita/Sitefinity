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
	/// This class is the base class for any <see cref="SiteCurrenciesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteCurrenciesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteCurrencies, JXTPortal.Entities.SiteCurrenciesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteCurrenciesKey key)
		{
			return Delete(transactionManager, key.SiteCurrencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteCurrencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteCurrencyId)
		{
			return Delete(null, _siteCurrencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCurrencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteCurrencyId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		FK__SiteCurre__Curre__2BE2B892 Description: 
		/// </summary>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetByCurrencyId(System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(_currencyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		FK__SiteCurre__Curre__2BE2B892 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		/// <remarks></remarks>
		public TList<SiteCurrencies> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		FK__SiteCurre__Curre__2BE2B892 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyId(transactionManager, _currencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		fkSiteCurreCurre2Be2b892 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyId(null, _currencyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		fkSiteCurreCurre2Be2b892 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetByCurrencyId(System.Int32 _currencyId, int start, int pageLength,out int count)
		{
			return GetByCurrencyId(null, _currencyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__Curre__2BE2B892 key.
		///		FK__SiteCurre__Curre__2BE2B892 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public abstract TList<SiteCurrencies> GetByCurrencyId(TransactionManager transactionManager, System.Int32 _currencyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		FK__SiteCurre__SiteI__2AEE9459 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		FK__SiteCurre__SiteI__2AEE9459 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		/// <remarks></remarks>
		public TList<SiteCurrencies> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		FK__SiteCurre__SiteI__2AEE9459 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		fkSiteCurreSitei2Aee9459 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		fkSiteCurreSitei2Aee9459 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public TList<SiteCurrencies> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteCurre__SiteI__2AEE9459 key.
		///		FK__SiteCurre__SiteI__2AEE9459 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteCurrencies objects.</returns>
		public abstract TList<SiteCurrencies> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteCurrencies Get(TransactionManager transactionManager, JXTPortal.Entities.SiteCurrenciesKey key, int start, int pageLength)
		{
			return GetBySiteCurrencyId(transactionManager, key.SiteCurrencyId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="_siteCurrencyId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(System.Int32 _siteCurrencyId)
		{
			int count = -1;
			return GetBySiteCurrencyId(null,_siteCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="_siteCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(System.Int32 _siteCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteCurrencyId(null, _siteCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCurrencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(TransactionManager transactionManager, System.Int32 _siteCurrencyId)
		{
			int count = -1;
			return GetBySiteCurrencyId(transactionManager, _siteCurrencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(TransactionManager transactionManager, System.Int32 _siteCurrencyId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteCurrencyId(transactionManager, _siteCurrencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="_siteCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(System.Int32 _siteCurrencyId, int start, int pageLength, out int count)
		{
			return GetBySiteCurrencyId(null, _siteCurrencyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteCurrencies__29FA7020 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteCurrencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteCurrencies"/> class.</returns>
		public abstract JXTPortal.Entities.SiteCurrencies GetBySiteCurrencyId(TransactionManager transactionManager, System.Int32 _siteCurrencyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteCurrencies&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteCurrencies&gt;"/></returns>
		public static TList<SiteCurrencies> Fill(IDataReader reader, TList<SiteCurrencies> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteCurrencies c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteCurrencies")
					.Append("|").Append((System.Int32)reader[((int)SiteCurrenciesColumn.SiteCurrencyId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteCurrencies>(
					key.ToString(), // EntityTrackingKey
					"SiteCurrencies",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteCurrencies();
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
					c.SiteCurrencyId = (System.Int32)reader[((int)SiteCurrenciesColumn.SiteCurrencyId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteCurrenciesColumn.SiteId - 1)];
					c.CurrencyId = (System.Int32)reader[((int)SiteCurrenciesColumn.CurrencyId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteCurrencies"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCurrencies"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteCurrencies entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteCurrencyId = (System.Int32)reader[((int)SiteCurrenciesColumn.SiteCurrencyId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteCurrenciesColumn.SiteId - 1)];
			entity.CurrencyId = (System.Int32)reader[((int)SiteCurrenciesColumn.CurrencyId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteCurrencies"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCurrencies"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteCurrencies entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteCurrencyId = (System.Int32)dataRow["SiteCurrencyID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.CurrencyId = (System.Int32)dataRow["CurrencyID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteCurrencies"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteCurrencies Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteCurrencies entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CurrencyIdSource	
			if (CanDeepLoad(entity, "Currencies|CurrencyIdSource", deepLoadType, innerList) 
				&& entity.CurrencyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CurrencyId;
				Currencies tmpEntity = EntityManager.LocateEntity<Currencies>(EntityLocator.ConstructKeyFromPkItems(typeof(Currencies), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyIdSource = tmpEntity;
				else
					entity.CurrencyIdSource = DataRepository.CurrenciesProvider.GetByCurrencyId(transactionManager, entity.CurrencyId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrenciesProvider.DeepLoad(transactionManager, entity.CurrencyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurrencyIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteCurrencies object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteCurrencies instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteCurrencies Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteCurrencies entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CurrencyIdSource
			if (CanDeepSave(entity, "Currencies|CurrencyIdSource", deepSaveType, innerList) 
				&& entity.CurrencyIdSource != null)
			{
				DataRepository.CurrenciesProvider.Save(transactionManager, entity.CurrencyIdSource);
				entity.CurrencyId = entity.CurrencyIdSource.CurrencyId;
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
	
	#region SiteCurrenciesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteCurrencies</c>
	///</summary>
	public enum SiteCurrenciesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Currencies</c> at CurrencyIdSource
		///</summary>
		[ChildEntityType(typeof(Currencies))]
		Currencies,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteCurrenciesChildEntityTypes
	
	#region SiteCurrenciesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteCurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCurrencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCurrenciesFilterBuilder : SqlFilterBuilder<SiteCurrenciesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilterBuilder class.
		/// </summary>
		public SiteCurrenciesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCurrenciesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCurrenciesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCurrenciesFilterBuilder
	
	#region SiteCurrenciesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteCurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCurrencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCurrenciesParameterBuilder : ParameterizedSqlFilterBuilder<SiteCurrenciesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesParameterBuilder class.
		/// </summary>
		public SiteCurrenciesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCurrenciesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCurrenciesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCurrenciesParameterBuilder
	
	#region SiteCurrenciesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteCurrenciesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCurrencies"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteCurrenciesSortBuilder : SqlSortBuilder<SiteCurrenciesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesSqlSortBuilder class.
		/// </summary>
		public SiteCurrenciesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteCurrenciesSortBuilder
	
} // end namespace
