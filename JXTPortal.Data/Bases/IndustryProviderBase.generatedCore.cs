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
	/// This class is the base class for any <see cref="IndustryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IndustryProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Industry, JXTPortal.Entities.IndustryKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.IndustryKey key)
		{
			return Delete(transactionManager, key.IndustryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_industryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _industryId)
		{
			return Delete(null, _industryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_industryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _industryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		FK_Industry_SiteID Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		public TList<Industry> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		FK_Industry_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		/// <remarks></remarks>
		public TList<Industry> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		FK_Industry_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		public TList<Industry> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		fkIndustrySiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		public TList<Industry> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		fkIndustrySiteId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		public TList<Industry> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Industry_SiteID key.
		///		FK_Industry_SiteID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Industry objects.</returns>
		public abstract TList<Industry> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Industry Get(TransactionManager transactionManager, JXTPortal.Entities.IndustryKey key, int start, int pageLength)
		{
			return GetByIndustryId(transactionManager, key.IndustryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="_industryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public JXTPortal.Entities.Industry GetByIndustryId(System.Int32 _industryId)
		{
			int count = -1;
			return GetByIndustryId(null,_industryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="_industryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public JXTPortal.Entities.Industry GetByIndustryId(System.Int32 _industryId, int start, int pageLength)
		{
			int count = -1;
			return GetByIndustryId(null, _industryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_industryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public JXTPortal.Entities.Industry GetByIndustryId(TransactionManager transactionManager, System.Int32 _industryId)
		{
			int count = -1;
			return GetByIndustryId(transactionManager, _industryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_industryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public JXTPortal.Entities.Industry GetByIndustryId(TransactionManager transactionManager, System.Int32 _industryId, int start, int pageLength)
		{
			int count = -1;
			return GetByIndustryId(transactionManager, _industryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="_industryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public JXTPortal.Entities.Industry GetByIndustryId(System.Int32 _industryId, int start, int pageLength, out int count)
		{
			return GetByIndustryId(null, _industryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Industry__808DEC2C1D4306BD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_industryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Industry"/> class.</returns>
		public abstract JXTPortal.Entities.Industry GetByIndustryId(TransactionManager transactionManager, System.Int32 _industryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Industry&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Industry&gt;"/></returns>
		public static TList<Industry> Fill(IDataReader reader, TList<Industry> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Industry c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Industry")
					.Append("|").Append((System.Int32)reader[((int)IndustryColumn.IndustryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Industry>(
					key.ToString(), // EntityTrackingKey
					"Industry",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Industry();
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
					c.IndustryId = (System.Int32)reader[((int)IndustryColumn.IndustryId - 1)];
					c.SiteId = (System.Int32)reader[((int)IndustryColumn.SiteId - 1)];
					c.IndustryName = (reader.IsDBNull(((int)IndustryColumn.IndustryName - 1)))?null:(System.String)reader[((int)IndustryColumn.IndustryName - 1)];
					c.Sequence = (reader.IsDBNull(((int)IndustryColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)IndustryColumn.Sequence - 1)];
					c.Valid = (System.Boolean)reader[((int)IndustryColumn.Valid - 1)];
					c.IndustryLanguageXml = (reader.IsDBNull(((int)IndustryColumn.IndustryLanguageXml - 1)))?null:(System.String)reader[((int)IndustryColumn.IndustryLanguageXml - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)IndustryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IndustryColumn.LastModifiedBy - 1)];
					c.LastModified = (reader.IsDBNull(((int)IndustryColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)IndustryColumn.LastModified - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Industry"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Industry"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Industry entity)
		{
			if (!reader.Read()) return;
			
			entity.IndustryId = (System.Int32)reader[((int)IndustryColumn.IndustryId - 1)];
			entity.SiteId = (System.Int32)reader[((int)IndustryColumn.SiteId - 1)];
			entity.IndustryName = (reader.IsDBNull(((int)IndustryColumn.IndustryName - 1)))?null:(System.String)reader[((int)IndustryColumn.IndustryName - 1)];
			entity.Sequence = (reader.IsDBNull(((int)IndustryColumn.Sequence - 1)))?null:(System.Int32?)reader[((int)IndustryColumn.Sequence - 1)];
			entity.Valid = (System.Boolean)reader[((int)IndustryColumn.Valid - 1)];
			entity.IndustryLanguageXml = (reader.IsDBNull(((int)IndustryColumn.IndustryLanguageXml - 1)))?null:(System.String)reader[((int)IndustryColumn.IndustryLanguageXml - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)IndustryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)IndustryColumn.LastModifiedBy - 1)];
			entity.LastModified = (reader.IsDBNull(((int)IndustryColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)IndustryColumn.LastModified - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Industry"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Industry"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Industry entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IndustryId = (System.Int32)dataRow["IndustryID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.IndustryName = Convert.IsDBNull(dataRow["IndustryName"]) ? null : (System.String)dataRow["IndustryName"];
			entity.Sequence = Convert.IsDBNull(dataRow["Sequence"]) ? null : (System.Int32?)dataRow["Sequence"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.IndustryLanguageXml = Convert.IsDBNull(dataRow["IndustryLanguageXML"]) ? null : (System.String)dataRow["IndustryLanguageXML"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Industry"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Industry Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Industry entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Industry object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Industry instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Industry Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Industry entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region IndustryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Industry</c>
	///</summary>
	public enum IndustryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion IndustryChildEntityTypes
	
	#region IndustryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Industry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndustryFilterBuilder : SqlFilterBuilder<IndustryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndustryFilterBuilder class.
		/// </summary>
		public IndustryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndustryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndustryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndustryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndustryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndustryFilterBuilder
	
	#region IndustryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Industry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndustryParameterBuilder : ParameterizedSqlFilterBuilder<IndustryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndustryParameterBuilder class.
		/// </summary>
		public IndustryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndustryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndustryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndustryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndustryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndustryParameterBuilder
	
	#region IndustrySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Industry"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IndustrySortBuilder : SqlSortBuilder<IndustryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndustrySqlSortBuilder class.
		/// </summary>
		public IndustrySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IndustrySortBuilder
	
} // end namespace
