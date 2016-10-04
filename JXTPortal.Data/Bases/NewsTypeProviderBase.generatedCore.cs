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
	/// This class is the base class for any <see cref="NewsTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NewsTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.NewsType, JXTPortal.Entities.NewsTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.NewsTypeKey key)
		{
			return Delete(transactionManager, key.NewsTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_newsTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _newsTypeId)
		{
			return Delete(null, _newsTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _newsTypeId);		
		
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
		public override JXTPortal.Entities.NewsType Get(TransactionManager transactionManager, JXTPortal.Entities.NewsTypeKey key, int start, int pageLength)
		{
			return GetByNewsTypeId(transactionManager, key.NewsTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="_newsTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public JXTPortal.Entities.NewsType GetByNewsTypeId(System.Int32 _newsTypeId)
		{
			int count = -1;
			return GetByNewsTypeId(null,_newsTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="_newsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public JXTPortal.Entities.NewsType GetByNewsTypeId(System.Int32 _newsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsTypeId(null, _newsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public JXTPortal.Entities.NewsType GetByNewsTypeId(TransactionManager transactionManager, System.Int32 _newsTypeId)
		{
			int count = -1;
			return GetByNewsTypeId(transactionManager, _newsTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public JXTPortal.Entities.NewsType GetByNewsTypeId(TransactionManager transactionManager, System.Int32 _newsTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByNewsTypeId(transactionManager, _newsTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="_newsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public JXTPortal.Entities.NewsType GetByNewsTypeId(System.Int32 _newsTypeId, int start, int pageLength, out int count)
		{
			return GetByNewsTypeId(null, _newsTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__NewsType__9013FE2A05A5E4ED index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_newsTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.NewsType"/> class.</returns>
		public abstract JXTPortal.Entities.NewsType GetByNewsTypeId(TransactionManager transactionManager, System.Int32 _newsTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;NewsType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;NewsType&gt;"/></returns>
		public static TList<NewsType> Fill(IDataReader reader, TList<NewsType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.NewsType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("NewsType")
					.Append("|").Append((System.Int32)reader[((int)NewsTypeColumn.NewsTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<NewsType>(
					key.ToString(), // EntityTrackingKey
					"NewsType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.NewsType();
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
					c.NewsTypeId = (System.Int32)reader[((int)NewsTypeColumn.NewsTypeId - 1)];
					c.NewsTypeName = (System.String)reader[((int)NewsTypeColumn.NewsTypeName - 1)];
					c.SiteId = (reader.IsDBNull(((int)NewsTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.SiteId - 1)];
					c.NewsTypeParentId = (reader.IsDBNull(((int)NewsTypeColumn.NewsTypeParentId - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.NewsTypeParentId - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)NewsTypeColumn.GlobalTemplate - 1)];
					c.Sequence = (System.Int32)reader[((int)NewsTypeColumn.Sequence - 1)];
					c.ImageUrl = (reader.IsDBNull(((int)NewsTypeColumn.ImageUrl - 1)))?null:(System.String)reader[((int)NewsTypeColumn.ImageUrl - 1)];
					c.CustomXml = (reader.IsDBNull(((int)NewsTypeColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsTypeColumn.CustomXml - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)NewsTypeColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.LastModifiedBy - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)NewsTypeColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)NewsTypeColumn.LastModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.NewsType entity)
		{
			if (!reader.Read()) return;
			
			entity.NewsTypeId = (System.Int32)reader[((int)NewsTypeColumn.NewsTypeId - 1)];
			entity.NewsTypeName = (System.String)reader[((int)NewsTypeColumn.NewsTypeName - 1)];
			entity.SiteId = (reader.IsDBNull(((int)NewsTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.SiteId - 1)];
			entity.NewsTypeParentId = (reader.IsDBNull(((int)NewsTypeColumn.NewsTypeParentId - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.NewsTypeParentId - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)NewsTypeColumn.GlobalTemplate - 1)];
			entity.Sequence = (System.Int32)reader[((int)NewsTypeColumn.Sequence - 1)];
			entity.ImageUrl = (reader.IsDBNull(((int)NewsTypeColumn.ImageUrl - 1)))?null:(System.String)reader[((int)NewsTypeColumn.ImageUrl - 1)];
			entity.CustomXml = (reader.IsDBNull(((int)NewsTypeColumn.CustomXml - 1)))?null:(System.String)reader[((int)NewsTypeColumn.CustomXml - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)NewsTypeColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)NewsTypeColumn.LastModifiedBy - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)NewsTypeColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)NewsTypeColumn.LastModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.NewsType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.NewsType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NewsTypeId = (System.Int32)dataRow["NewsTypeID"];
			entity.NewsTypeName = (System.String)dataRow["NewsTypeName"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.NewsTypeParentId = Convert.IsDBNull(dataRow["NewsTypeParentID"]) ? null : (System.Int32?)dataRow["NewsTypeParentID"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.ImageUrl = Convert.IsDBNull(dataRow["ImageURL"]) ? null : (System.String)dataRow["ImageURL"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.NewsType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.NewsType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.NewsType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.NewsType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.NewsType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.NewsType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region NewsTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.NewsType</c>
	///</summary>
	public enum NewsTypeChildEntityTypes
	{
	}
	
	#endregion NewsTypeChildEntityTypes
	
	#region NewsTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;NewsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsTypeFilterBuilder : SqlFilterBuilder<NewsTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilterBuilder class.
		/// </summary>
		public NewsTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsTypeFilterBuilder
	
	#region NewsTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;NewsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsTypeParameterBuilder : ParameterizedSqlFilterBuilder<NewsTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsTypeParameterBuilder class.
		/// </summary>
		public NewsTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsTypeParameterBuilder
	
	#region NewsTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;NewsTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class NewsTypeSortBuilder : SqlSortBuilder<NewsTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsTypeSqlSortBuilder class.
		/// </summary>
		public NewsTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion NewsTypeSortBuilder
	
} // end namespace
