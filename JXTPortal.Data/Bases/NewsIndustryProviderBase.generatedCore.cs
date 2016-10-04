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
	/// This class is the base class for any <see cref="NewsIndustryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NewsIndustryProviderBaseCore : EntityProviderBase<JXTPortal.Entities.NewsIndustry, JXTPortal.Entities.NewsIndustryKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.NewsIndustryKey key)
		{
			return Delete(transactionManager, key.NewsIndustryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_newsIndustryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _newsIndustryId)
		{
			return Delete(null, _newsIndustryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsIndustryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _newsIndustryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override JXTPortal.Entities.NewsIndustry Get(TransactionManager transactionManager, JXTPortal.Entities.NewsIndustryKey key, int start, int pageLength)
		{
			return GetByNewsIndustryId(transactionManager, key.NewsIndustryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="_newsIndustryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(System.Int32 _newsIndustryId)
		{
			int count = -1;
			return GetByNewsIndustryId(null,_newsIndustryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="_newsIndustryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(System.Int32 _newsIndustryId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsIndustryId(null, _newsIndustryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsIndustryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(TransactionManager transactionManager, System.Int32 _newsIndustryId)
		{
			int count = -1;
			return GetByNewsIndustryId(transactionManager, _newsIndustryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsIndustryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(TransactionManager transactionManager, System.Int32 _newsIndustryId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsIndustryId(transactionManager, _newsIndustryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="_newsIndustryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(System.Int32 _newsIndustryId, int start, int pageLength, out int count)
		{
			return GetByNewsIndustryId(null, _newsIndustryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsIndu__289B7D7C7FED0B97 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsIndustryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsIndustry"/> class.</returns>
		public abstract JXTPortal.Entities.NewsIndustry GetByNewsIndustryId(TransactionManager transactionManager, System.Int32 _newsIndustryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;NewsIndustry&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;NewsIndustry&gt;"/></returns>
		public static TList<NewsIndustry> Fill(IDataReader reader, TList<NewsIndustry> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.NewsIndustry c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("NewsIndustry")
					.Append("|").Append((System.Int32)reader[((int)NewsIndustryColumn.NewsIndustryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<NewsIndustry>(
					key.ToString(), // EntityTrackingKey
					"NewsIndustry",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.NewsIndustry();
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
					c.NewsIndustryId = (System.Int32)reader[((int)NewsIndustryColumn.NewsIndustryId - 1)];
					c.NewsIndustryName = (System.String)reader[((int)NewsIndustryColumn.NewsIndustryName - 1)];
					c.SiteId = (reader.IsDBNull(((int)NewsIndustryColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.SiteId - 1)];
					c.NewsIndustryParentId = (reader.IsDBNull(((int)NewsIndustryColumn.NewsIndustryParentId - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.NewsIndustryParentId - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)NewsIndustryColumn.GlobalTemplate - 1)];
					c.Sequence = (System.Int32)reader[((int)NewsIndustryColumn.Sequence - 1)];
					c.CustomXml = (reader.IsDBNull(((int)NewsIndustryColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsIndustryColumn.CustomXml - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)NewsIndustryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.LastModifiedBy - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)NewsIndustryColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)NewsIndustryColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsIndustry"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsIndustry"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.NewsIndustry entity)
		{
			if (!reader.Read()) return;
			
			entity.NewsIndustryId = (System.Int32)reader[((int)NewsIndustryColumn.NewsIndustryId - 1)];
			entity.NewsIndustryName = (System.String)reader[((int)NewsIndustryColumn.NewsIndustryName - 1)];
			entity.SiteId = (reader.IsDBNull(((int)NewsIndustryColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.SiteId - 1)];
			entity.NewsIndustryParentId = (reader.IsDBNull(((int)NewsIndustryColumn.NewsIndustryParentId - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.NewsIndustryParentId - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)NewsIndustryColumn.GlobalTemplate - 1)];
			entity.Sequence = (System.Int32)reader[((int)NewsIndustryColumn.Sequence - 1)];
			entity.CustomXml = (reader.IsDBNull(((int)NewsIndustryColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsIndustryColumn.CustomXml - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)NewsIndustryColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)NewsIndustryColumn.LastModifiedBy - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)NewsIndustryColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)NewsIndustryColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsIndustry"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsIndustry"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.NewsIndustry entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NewsIndustryId = (System.Int32)dataRow["NewsIndustryID"];
			entity.NewsIndustryName = (System.String)dataRow["NewsIndustryName"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.NewsIndustryParentId = Convert.IsDBNull(dataRow["NewsIndustryParentID"]) ? null : (System.Int32?)dataRow["NewsIndustryParentID"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.CustomXml = Convert.IsDBNull(dataRow["CustomXML"]) ? null : (System.String)dataRow["CustomXML"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsIndustry"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsIndustry Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.NewsIndustry entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.NewsIndustry object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.NewsIndustry instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsIndustry Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.NewsIndustry entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
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
	
	#region NewsIndustryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.NewsIndustry</c>
	///</summary>
	public enum NewsIndustryChildEntityTypes
	{
	}
	
	#endregion NewsIndustryChildEntityTypes
	
	#region NewsIndustryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NewsIndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsIndustry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsIndustryFilterBuilder : SqlFilterBuilder<NewsIndustryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilterBuilder class.
		/// </summary>
		public NewsIndustryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsIndustryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsIndustryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsIndustryFilterBuilder
	
	#region NewsIndustryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NewsIndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsIndustry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsIndustryParameterBuilder : ParameterizedSqlFilterBuilder<NewsIndustryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsIndustryParameterBuilder class.
		/// </summary>
		public NewsIndustryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsIndustryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsIndustryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsIndustryParameterBuilder
	
	#region NewsIndustrySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NewsIndustryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsIndustry"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NewsIndustrySortBuilder : SqlSortBuilder<NewsIndustryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsIndustrySqlSortBuilder class.
		/// </summary>
		public NewsIndustrySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NewsIndustrySortBuilder
	
} // end namespace
