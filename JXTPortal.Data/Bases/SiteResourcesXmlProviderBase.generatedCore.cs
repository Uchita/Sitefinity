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
	/// This class is the base class for any <see cref="SiteResourcesXmlProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteResourcesXmlProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteResourcesXml, JXTPortal.Entities.SiteResourcesXmlKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesXmlKey key)
		{
			return Delete(transactionManager, key.SiteResourceXmlid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteResourceXmlid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteResourceXmlid)
		{
			return Delete(null, _siteResourceXmlid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceXmlid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteResourceXmlid);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		FK__SiteResou__SiteI__3BBD6C3C Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		public TList<SiteResourcesXml> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		FK__SiteResou__SiteI__3BBD6C3C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		/// <remarks></remarks>
		public TList<SiteResourcesXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		FK__SiteResou__SiteI__3BBD6C3C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		public TList<SiteResourcesXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		fkSiteResouSitei3Bbd6c3c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		public TList<SiteResourcesXml> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		fkSiteResouSitei3Bbd6c3c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		public TList<SiteResourcesXml> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteResou__SiteI__3BBD6C3C key.
		///		FK__SiteResou__SiteI__3BBD6C3C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteResourcesXml objects.</returns>
		public abstract TList<SiteResourcesXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteResourcesXml Get(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesXmlKey key, int start, int pageLength)
		{
			return GetBySiteResourceXmlid(transactionManager, key.SiteResourceXmlid, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="_siteResourceXmlid"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(System.Int32 _siteResourceXmlid)
		{
			int count = -1;
			return GetBySiteResourceXmlid(null,_siteResourceXmlid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="_siteResourceXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(System.Int32 _siteResourceXmlid, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteResourceXmlid(null, _siteResourceXmlid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceXmlid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(TransactionManager transactionManager, System.Int32 _siteResourceXmlid)
		{
			int count = -1;
			return GetBySiteResourceXmlid(transactionManager, _siteResourceXmlid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(TransactionManager transactionManager, System.Int32 _siteResourceXmlid, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteResourceXmlid(transactionManager, _siteResourceXmlid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="_siteResourceXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(System.Int32 _siteResourceXmlid, int start, int pageLength, out int count)
		{
			return GetBySiteResourceXmlid(null, _siteResourceXmlid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteReso__C3575D8A39D523CA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteResourceXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteResourcesXml"/> class.</returns>
		public abstract JXTPortal.Entities.SiteResourcesXml GetBySiteResourceXmlid(TransactionManager transactionManager, System.Int32 _siteResourceXmlid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteResourcesXml&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteResourcesXml&gt;"/></returns>
		public static TList<SiteResourcesXml> Fill(IDataReader reader, TList<SiteResourcesXml> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteResourcesXml c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteResourcesXml")
					.Append("|").Append((System.Int32)reader[((int)SiteResourcesXmlColumn.SiteResourceXmlid - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteResourcesXml>(
					key.ToString(), // EntityTrackingKey
					"SiteResourcesXml",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteResourcesXml();
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
					c.SiteResourceXmlid = (System.Int32)reader[((int)SiteResourcesXmlColumn.SiteResourceXmlid - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteResourcesXmlColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)SiteResourcesXmlColumn.LanguageId - 1)];
					c.ResourceType = (System.Int32)reader[((int)SiteResourcesXmlColumn.ResourceType - 1)];
					c.ResourceXml = (reader.IsDBNull(((int)SiteResourcesXmlColumn.ResourceXml - 1)))?null:(System.String)reader[((int)SiteResourcesXmlColumn.ResourceXml - 1)];
					c.LastModified = (reader.IsDBNull(((int)SiteResourcesXmlColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)SiteResourcesXmlColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)SiteResourcesXmlColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SiteResourcesXmlColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteResourcesXml"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResourcesXml"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteResourcesXml entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteResourceXmlid = (System.Int32)reader[((int)SiteResourcesXmlColumn.SiteResourceXmlid - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteResourcesXmlColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)SiteResourcesXmlColumn.LanguageId - 1)];
			entity.ResourceType = (System.Int32)reader[((int)SiteResourcesXmlColumn.ResourceType - 1)];
			entity.ResourceXml = (reader.IsDBNull(((int)SiteResourcesXmlColumn.ResourceXml - 1)))?null:(System.String)reader[((int)SiteResourcesXmlColumn.ResourceXml - 1)];
			entity.LastModified = (reader.IsDBNull(((int)SiteResourcesXmlColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)SiteResourcesXmlColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)SiteResourcesXmlColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SiteResourcesXmlColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteResourcesXml"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResourcesXml"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteResourcesXml entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteResourceXmlid = (System.Int32)dataRow["SiteResourceXMLID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.ResourceType = (System.Int32)dataRow["ResourceType"];
			entity.ResourceXml = Convert.IsDBNull(dataRow["ResourceXML"]) ? null : (System.String)dataRow["ResourceXML"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteResourcesXml"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteResourcesXml Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesXml entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteResourcesXml object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteResourcesXml instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteResourcesXml Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteResourcesXml entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region SiteResourcesXmlChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteResourcesXml</c>
	///</summary>
	public enum SiteResourcesXmlChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteResourcesXmlChildEntityTypes
	
	#region SiteResourcesXmlFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteResourcesXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResourcesXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesXmlFilterBuilder : SqlFilterBuilder<SiteResourcesXmlColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilterBuilder class.
		/// </summary>
		public SiteResourcesXmlFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesXmlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesXmlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesXmlFilterBuilder
	
	#region SiteResourcesXmlParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteResourcesXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResourcesXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesXmlParameterBuilder : ParameterizedSqlFilterBuilder<SiteResourcesXmlColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlParameterBuilder class.
		/// </summary>
		public SiteResourcesXmlParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesXmlParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesXmlParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesXmlParameterBuilder
	
	#region SiteResourcesXmlSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteResourcesXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResourcesXml"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteResourcesXmlSortBuilder : SqlSortBuilder<SiteResourcesXmlColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlSqlSortBuilder class.
		/// </summary>
		public SiteResourcesXmlSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteResourcesXmlSortBuilder
	
} // end namespace
