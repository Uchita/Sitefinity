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
	/// This class is the base class for any <see cref="DynamicContentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicContentProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicContent, JXTPortal.Entities.DynamicContentKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicContentKey key)
		{
			return Delete(transactionManager, key.DynamicContentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicContentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicContentId)
		{
			return Delete(null, _dynamicContentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicContentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicContentId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		FK__DynamicCo__LastM__63A73788 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetByLastModifiedBy(System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		FK__DynamicCo__LastM__63A73788 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicContent> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		FK__DynamicCo__LastM__63A73788 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		fkDynamicCoLastm63a73788 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		fkDynamicCoLastm63a73788 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__LastM__63A73788 key.
		///		FK__DynamicCo__LastM__63A73788 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public abstract TList<DynamicContent> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		FK__DynamicCo__SiteI__62B3134F Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		FK__DynamicCo__SiteI__62B3134F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicContent> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		FK__DynamicCo__SiteI__62B3134F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		fkDynamicCoSitei62b3134f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		fkDynamicCoSitei62b3134f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public TList<DynamicContent> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicCo__SiteI__62B3134F key.
		///		FK__DynamicCo__SiteI__62B3134F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicContent objects.</returns>
		public abstract TList<DynamicContent> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicContent Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicContentKey key, int start, int pageLength)
		{
			return GetByDynamicContentId(transactionManager, key.DynamicContentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="_dynamicContentId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public JXTPortal.Entities.DynamicContent GetByDynamicContentId(System.Int32 _dynamicContentId)
		{
			int count = -1;
			return GetByDynamicContentId(null,_dynamicContentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="_dynamicContentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public JXTPortal.Entities.DynamicContent GetByDynamicContentId(System.Int32 _dynamicContentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicContentId(null, _dynamicContentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicContentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public JXTPortal.Entities.DynamicContent GetByDynamicContentId(TransactionManager transactionManager, System.Int32 _dynamicContentId)
		{
			int count = -1;
			return GetByDynamicContentId(transactionManager, _dynamicContentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicContentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public JXTPortal.Entities.DynamicContent GetByDynamicContentId(TransactionManager transactionManager, System.Int32 _dynamicContentId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicContentId(transactionManager, _dynamicContentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="_dynamicContentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public JXTPortal.Entities.DynamicContent GetByDynamicContentId(System.Int32 _dynamicContentId, int start, int pageLength, out int count)
		{
			return GetByDynamicContentId(null, _dynamicContentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicC__6A79B03A5FD6A6A4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicContentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicContent"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicContent GetByDynamicContentId(TransactionManager transactionManager, System.Int32 _dynamicContentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicContent&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicContent&gt;"/></returns>
		public static TList<DynamicContent> Fill(IDataReader reader, TList<DynamicContent> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicContent c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicContent")
					.Append("|").Append((System.Int32)reader[((int)DynamicContentColumn.DynamicContentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicContent>(
					key.ToString(), // EntityTrackingKey
					"DynamicContent",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicContent();
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
					c.DynamicContentId = (System.Int32)reader[((int)DynamicContentColumn.DynamicContentId - 1)];
					c.SiteId = (System.Int32)reader[((int)DynamicContentColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)DynamicContentColumn.LanguageId - 1)];
					c.DynamicContentType = (System.Int32)reader[((int)DynamicContentColumn.DynamicContentType - 1)];
					c.Title = (reader.IsDBNull(((int)DynamicContentColumn.Title - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Title - 1)];
					c.Introduction = (reader.IsDBNull(((int)DynamicContentColumn.Introduction - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Introduction - 1)];
					c.Description = (reader.IsDBNull(((int)DynamicContentColumn.Description - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Description - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)DynamicContentColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)DynamicContentColumn.LastModifiedBy - 1)];
					c.LastModifiedDate = (System.DateTime)reader[((int)DynamicContentColumn.LastModifiedDate - 1)];
					c.Active = (System.Boolean)reader[((int)DynamicContentColumn.Active - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicContent"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicContent"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicContent entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicContentId = (System.Int32)reader[((int)DynamicContentColumn.DynamicContentId - 1)];
			entity.SiteId = (System.Int32)reader[((int)DynamicContentColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)DynamicContentColumn.LanguageId - 1)];
			entity.DynamicContentType = (System.Int32)reader[((int)DynamicContentColumn.DynamicContentType - 1)];
			entity.Title = (reader.IsDBNull(((int)DynamicContentColumn.Title - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Title - 1)];
			entity.Introduction = (reader.IsDBNull(((int)DynamicContentColumn.Introduction - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Introduction - 1)];
			entity.Description = (reader.IsDBNull(((int)DynamicContentColumn.Description - 1)))?null:(System.String)reader[((int)DynamicContentColumn.Description - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)DynamicContentColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)DynamicContentColumn.LastModifiedBy - 1)];
			entity.LastModifiedDate = (System.DateTime)reader[((int)DynamicContentColumn.LastModifiedDate - 1)];
			entity.Active = (System.Boolean)reader[((int)DynamicContentColumn.Active - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicContent"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicContent"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicContent entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicContentId = (System.Int32)dataRow["DynamicContentID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.DynamicContentType = (System.Int32)dataRow["DynamicContentType"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.Introduction = Convert.IsDBNull(dataRow["Introduction"]) ? null : (System.String)dataRow["Introduction"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModifiedDate = (System.DateTime)dataRow["LastModifiedDate"];
			entity.Active = (System.Boolean)dataRow["Active"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicContent"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicContent Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicContent entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastModifiedBy ?? (int)0);
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, (entity.LastModifiedBy ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedBySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedBySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.LastModifiedBySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedBySource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicContent object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicContent instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicContent Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicContent entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
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
	
	#region DynamicContentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicContent</c>
	///</summary>
	public enum DynamicContentChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion DynamicContentChildEntityTypes
	
	#region DynamicContentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicContentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicContent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicContentFilterBuilder : SqlFilterBuilder<DynamicContentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilterBuilder class.
		/// </summary>
		public DynamicContentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicContentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicContentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicContentFilterBuilder
	
	#region DynamicContentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicContentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicContent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicContentParameterBuilder : ParameterizedSqlFilterBuilder<DynamicContentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicContentParameterBuilder class.
		/// </summary>
		public DynamicContentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicContentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicContentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicContentParameterBuilder
	
	#region DynamicContentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicContentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicContent"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicContentSortBuilder : SqlSortBuilder<DynamicContentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicContentSqlSortBuilder class.
		/// </summary>
		public DynamicContentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicContentSortBuilder
	
} // end namespace
