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
	/// This class is the base class for any <see cref="JobCustomQuestionnaireProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobCustomQuestionnaireProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobCustomQuestionnaire, JXTPortal.Entities.JobCustomQuestionnaireKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobCustomQuestionnaireKey key)
		{
			return Delete(transactionManager, key.JobCustomQuestionnaireId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobCustomQuestionnaireId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobCustomQuestionnaireId)
		{
			return Delete(null, _jobCustomQuestionnaireId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomQuestionnaireId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobCustomQuestionnaireId);		
		
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
		public override JXTPortal.Entities.JobCustomQuestionnaire Get(TransactionManager transactionManager, JXTPortal.Entities.JobCustomQuestionnaireKey key, int start, int pageLength)
		{
			return GetByJobCustomQuestionnaireId(transactionManager, key.JobCustomQuestionnaireId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(System.Int32 _jobCustomQuestionnaireId)
		{
			int count = -1;
			return GetByJobCustomQuestionnaireId(null,_jobCustomQuestionnaireId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(System.Int32 _jobCustomQuestionnaireId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCustomQuestionnaireId(null, _jobCustomQuestionnaireId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(TransactionManager transactionManager, System.Int32 _jobCustomQuestionnaireId)
		{
			int count = -1;
			return GetByJobCustomQuestionnaireId(transactionManager, _jobCustomQuestionnaireId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(TransactionManager transactionManager, System.Int32 _jobCustomQuestionnaireId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCustomQuestionnaireId(transactionManager, _jobCustomQuestionnaireId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(System.Int32 _jobCustomQuestionnaireId, int start, int pageLength, out int count)
		{
			return GetByJobCustomQuestionnaireId(null, _jobCustomQuestionnaireId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__69184A567081E6B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomQuestionnaireId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> class.</returns>
		public abstract JXTPortal.Entities.JobCustomQuestionnaire GetByJobCustomQuestionnaireId(TransactionManager transactionManager, System.Int32 _jobCustomQuestionnaireId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobCustomQuestionnaire&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobCustomQuestionnaire&gt;"/></returns>
		public static TList<JobCustomQuestionnaire> Fill(IDataReader reader, TList<JobCustomQuestionnaire> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobCustomQuestionnaire c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobCustomQuestionnaire")
					.Append("|").Append((System.Int32)reader[((int)JobCustomQuestionnaireColumn.JobCustomQuestionnaireId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobCustomQuestionnaire>(
					key.ToString(), // EntityTrackingKey
					"JobCustomQuestionnaire",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobCustomQuestionnaire();
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
					c.JobCustomQuestionnaireId = (System.Int32)reader[((int)JobCustomQuestionnaireColumn.JobCustomQuestionnaireId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobCustomQuestionnaireColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobCustomQuestionnaireColumn.JobId - 1)];
					c.FormXml = (reader.IsDBNull(((int)JobCustomQuestionnaireColumn.FormXml - 1)))?null:(System.String)reader[((int)JobCustomQuestionnaireColumn.FormXml - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobCustomQuestionnaire entity)
		{
			if (!reader.Read()) return;
			
			entity.JobCustomQuestionnaireId = (System.Int32)reader[((int)JobCustomQuestionnaireColumn.JobCustomQuestionnaireId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobCustomQuestionnaireColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobCustomQuestionnaireColumn.JobId - 1)];
			entity.FormXml = (reader.IsDBNull(((int)JobCustomQuestionnaireColumn.FormXml - 1)))?null:(System.String)reader[((int)JobCustomQuestionnaireColumn.FormXml - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobCustomQuestionnaire entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCustomQuestionnaireId = (System.Int32)dataRow["JobCustomQuestionnaireID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.FormXml = Convert.IsDBNull(dataRow["FormXML"]) ? null : (System.String)dataRow["FormXML"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomQuestionnaire"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobCustomQuestionnaire Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobCustomQuestionnaire entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobCustomQuestionnaire object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobCustomQuestionnaire instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobCustomQuestionnaire Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobCustomQuestionnaire entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region JobCustomQuestionnaireChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobCustomQuestionnaire</c>
	///</summary>
	public enum JobCustomQuestionnaireChildEntityTypes
	{
	}
	
	#endregion JobCustomQuestionnaireChildEntityTypes
	
	#region JobCustomQuestionnaireFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobCustomQuestionnaireColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomQuestionnaire"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomQuestionnaireFilterBuilder : SqlFilterBuilder<JobCustomQuestionnaireColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilterBuilder class.
		/// </summary>
		public JobCustomQuestionnaireFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomQuestionnaireFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomQuestionnaireFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomQuestionnaireFilterBuilder
	
	#region JobCustomQuestionnaireParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobCustomQuestionnaireColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomQuestionnaire"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomQuestionnaireParameterBuilder : ParameterizedSqlFilterBuilder<JobCustomQuestionnaireColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireParameterBuilder class.
		/// </summary>
		public JobCustomQuestionnaireParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomQuestionnaireParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomQuestionnaireParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomQuestionnaireParameterBuilder
	
	#region JobCustomQuestionnaireSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobCustomQuestionnaireColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomQuestionnaire"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobCustomQuestionnaireSortBuilder : SqlSortBuilder<JobCustomQuestionnaireColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireSqlSortBuilder class.
		/// </summary>
		public JobCustomQuestionnaireSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobCustomQuestionnaireSortBuilder
	
} // end namespace
