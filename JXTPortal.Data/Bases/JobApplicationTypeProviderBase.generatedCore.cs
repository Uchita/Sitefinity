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
	/// This class is the base class for any <see cref="JobApplicationTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobApplicationTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobApplicationType, JXTPortal.Entities.JobApplicationTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationTypeKey key)
		{
			return Delete(transactionManager, key.JobApplicationTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobApplicationTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobApplicationTypeId)
		{
			return Delete(null, _jobApplicationTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobApplicationTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		FK__JobApplic__SiteI__6BBD319A Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		public TList<JobApplicationType> GetBySiteId(System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		FK__JobApplic__SiteI__6BBD319A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		/// <remarks></remarks>
		public TList<JobApplicationType> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		FK__JobApplic__SiteI__6BBD319A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		public TList<JobApplicationType> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		fkJobApplicSitei6Bbd319a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		public TList<JobApplicationType> GetBySiteId(System.Int32? _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		fkJobApplicSitei6Bbd319a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		public TList<JobApplicationType> GetBySiteId(System.Int32? _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobApplic__SiteI__6BBD319A key.
		///		FK__JobApplic__SiteI__6BBD319A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobApplicationType objects.</returns>
		public abstract TList<JobApplicationType> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobApplicationType Get(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationTypeKey key, int start, int pageLength)
		{
			return GetByJobApplicationTypeId(transactionManager, key.JobApplicationTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="_jobApplicationTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(System.Int32 _jobApplicationTypeId)
		{
			int count = -1;
			return GetByJobApplicationTypeId(null,_jobApplicationTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="_jobApplicationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(System.Int32 _jobApplicationTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationTypeId(null, _jobApplicationTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(TransactionManager transactionManager, System.Int32 _jobApplicationTypeId)
		{
			int count = -1;
			return GetByJobApplicationTypeId(transactionManager, _jobApplicationTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(TransactionManager transactionManager, System.Int32 _jobApplicationTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationTypeId(transactionManager, _jobApplicationTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="_jobApplicationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(System.Int32 _jobApplicationTypeId, int start, int pageLength, out int count)
		{
			return GetByJobApplicationTypeId(null, _jobApplicationTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobAppli__BF72967968E0C4EF index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobApplicationType"/> class.</returns>
		public abstract JXTPortal.Entities.JobApplicationType GetByJobApplicationTypeId(TransactionManager transactionManager, System.Int32 _jobApplicationTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobApplicationType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobApplicationType&gt;"/></returns>
		public static TList<JobApplicationType> Fill(IDataReader reader, TList<JobApplicationType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobApplicationType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobApplicationType")
					.Append("|").Append((System.Int32)reader[((int)JobApplicationTypeColumn.JobApplicationTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobApplicationType>(
					key.ToString(), // EntityTrackingKey
					"JobApplicationType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobApplicationType();
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
					c.JobApplicationTypeId = (System.Int32)reader[((int)JobApplicationTypeColumn.JobApplicationTypeId - 1)];
					c.JobApplicationTypeParentId = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeParentId - 1)))?null:(System.Int32?)reader[((int)JobApplicationTypeColumn.JobApplicationTypeParentId - 1)];
					c.SiteId = (reader.IsDBNull(((int)JobApplicationTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)JobApplicationTypeColumn.SiteId - 1)];
					c.JobApplicationTypeName = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeName - 1)))?null:(System.String)reader[((int)JobApplicationTypeColumn.JobApplicationTypeName - 1)];
					c.JobApplicationTypeUrl = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeUrl - 1)))?null:(System.String)reader[((int)JobApplicationTypeColumn.JobApplicationTypeUrl - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)JobApplicationTypeColumn.GlobalTemplate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobApplicationType entity)
		{
			if (!reader.Read()) return;
			
			entity.JobApplicationTypeId = (System.Int32)reader[((int)JobApplicationTypeColumn.JobApplicationTypeId - 1)];
			entity.JobApplicationTypeParentId = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeParentId - 1)))?null:(System.Int32?)reader[((int)JobApplicationTypeColumn.JobApplicationTypeParentId - 1)];
			entity.SiteId = (reader.IsDBNull(((int)JobApplicationTypeColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)JobApplicationTypeColumn.SiteId - 1)];
			entity.JobApplicationTypeName = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeName - 1)))?null:(System.String)reader[((int)JobApplicationTypeColumn.JobApplicationTypeName - 1)];
			entity.JobApplicationTypeUrl = (reader.IsDBNull(((int)JobApplicationTypeColumn.JobApplicationTypeUrl - 1)))?null:(System.String)reader[((int)JobApplicationTypeColumn.JobApplicationTypeUrl - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)JobApplicationTypeColumn.GlobalTemplate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobApplicationType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobApplicationType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobApplicationTypeId = (System.Int32)dataRow["JobApplicationTypeID"];
			entity.JobApplicationTypeParentId = Convert.IsDBNull(dataRow["JobApplicationTypeParentID"]) ? null : (System.Int32?)dataRow["JobApplicationTypeParentID"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.JobApplicationTypeName = Convert.IsDBNull(dataRow["JobApplicationTypeName"]) ? null : (System.String)dataRow["JobApplicationTypeName"];
			entity.JobApplicationTypeUrl = Convert.IsDBNull(dataRow["JobApplicationTypeUrl"]) ? null : (System.String)dataRow["JobApplicationTypeUrl"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobApplicationType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SiteIdSource	
			if (CanDeepLoad(entity, "Sites|SiteIdSource", deepLoadType, innerList) 
				&& entity.SiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SiteId ?? (int)0);
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteIdSource = tmpEntity;
				else
					entity.SiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, (entity.SiteId ?? (int)0));		
				
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobApplicationType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobApplicationType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobApplicationType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobApplicationType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region JobApplicationTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobApplicationType</c>
	///</summary>
	public enum JobApplicationTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion JobApplicationTypeChildEntityTypes
	
	#region JobApplicationTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobApplicationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationTypeFilterBuilder : SqlFilterBuilder<JobApplicationTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilterBuilder class.
		/// </summary>
		public JobApplicationTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationTypeFilterBuilder
	
	#region JobApplicationTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobApplicationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationTypeParameterBuilder : ParameterizedSqlFilterBuilder<JobApplicationTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeParameterBuilder class.
		/// </summary>
		public JobApplicationTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationTypeParameterBuilder
	
	#region JobApplicationTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobApplicationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobApplicationTypeSortBuilder : SqlSortBuilder<JobApplicationTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeSqlSortBuilder class.
		/// </summary>
		public JobApplicationTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobApplicationTypeSortBuilder
	
} // end namespace
