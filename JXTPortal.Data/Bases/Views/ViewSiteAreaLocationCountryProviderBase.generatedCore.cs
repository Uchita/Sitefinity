#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JXTPortal.Entities;
using JXTPortal.Data;

#endregion

namespace JXTPortal.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ViewSiteAreaLocationCountryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ViewSiteAreaLocationCountryProviderBaseCore : EntityViewProviderBase<ViewSiteAreaLocationCountry>
	{
		#region Custom Methods
		
		
		#region ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetBySiteLocationIdSiteAreaId(System.Int32? siteLocationId, System.Int32? siteAreaId)
		{
			 GetBySiteLocationIdSiteAreaId(null, 0, int.MaxValue , siteLocationId, siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetBySiteLocationIdSiteAreaId(int start, int pageLength, System.Int32? siteLocationId, System.Int32? siteAreaId)
		{
			 GetBySiteLocationIdSiteAreaId(null, start, pageLength , siteLocationId, siteAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void GetBySiteLocationIdSiteAreaId(TransactionManager transactionManager, System.Int32? siteLocationId, System.Int32? siteAreaId)
		{
			 GetBySiteLocationIdSiteAreaId(transactionManager, 0, int.MaxValue , siteLocationId, siteAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_GetBySiteLocationIdSiteAreaId' stored procedure. 
		/// </summary>
		/// <param name="siteLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void GetBySiteLocationIdSiteAreaId(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteLocationId, System.Int32? siteAreaId);
		
		#endregion

		
		#region ViewSiteAreaLocationCountry_Get_List
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion

		
		#region ViewSiteAreaLocationCountry_Get
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(System.String whereClause, System.String orderBy)
		{
			return Get(null, 0, int.MaxValue , whereClause, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(int start, int pageLength, System.String whereClause, System.String orderBy)
		{
			return Get(null, start, pageLength , whereClause, orderBy);
		}
				
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get(TransactionManager transactionManager, System.String whereClause, System.String orderBy)
		{
			return Get(transactionManager, 0, int.MaxValue , whereClause, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAreaLocationCountry_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get(TransactionManager transactionManager, int start, int pageLength, System.String whereClause, System.String orderBy);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ViewSiteAreaLocationCountry&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ViewSiteAreaLocationCountry&gt;"/></returns>
		protected static VList&lt;ViewSiteAreaLocationCountry&gt; Fill(DataSet dataSet, VList<ViewSiteAreaLocationCountry> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ViewSiteAreaLocationCountry>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ViewSiteAreaLocationCountry&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ViewSiteAreaLocationCountry>"/></returns>
		protected static VList&lt;ViewSiteAreaLocationCountry&gt; Fill(DataTable dataTable, VList<ViewSiteAreaLocationCountry> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ViewSiteAreaLocationCountry c = new ViewSiteAreaLocationCountry();
					c.AreaId = (Convert.IsDBNull(row["AreaID"]))?(int)0:(System.Int32)row["AreaID"];
					c.SiteLocationId = (Convert.IsDBNull(row["SiteLocationID"]))?(int)0:(System.Int32)row["SiteLocationID"];
					c.LocationId = (Convert.IsDBNull(row["LocationID"]))?(int)0:(System.Int32)row["LocationID"];
					c.SiteAreaId = (Convert.IsDBNull(row["SiteAreaID"]))?(int)0:(System.Int32)row["SiteAreaID"];
					c.SiteAreaName = (Convert.IsDBNull(row["SiteAreaName"]))?string.Empty:(System.String)row["SiteAreaName"];
					c.SiteLocationName = (Convert.IsDBNull(row["SiteLocationName"]))?string.Empty:(System.String)row["SiteLocationName"];
					c.SiteId = (Convert.IsDBNull(row["SiteID"]))?(int)0:(System.Int32)row["SiteID"];
					c.SiteLocationSiteId = (Convert.IsDBNull(row["SiteLocationSiteId"]))?(int)0:(System.Int32)row["SiteLocationSiteId"];
					c.SiteCountrySiteId = (Convert.IsDBNull(row["SiteCountrySiteId"]))?(int)0:(System.Int32)row["SiteCountrySiteId"];
					c.CountryId = (Convert.IsDBNull(row["CountryID"]))?(int)0:(System.Int32)row["CountryID"];
					c.SiteCountryName = (Convert.IsDBNull(row["SiteCountryName"]))?string.Empty:(System.String)row["SiteCountryName"];
					c.Currency = (Convert.IsDBNull(row["Currency"]))?string.Empty:(System.String)row["Currency"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;ViewSiteAreaLocationCountry&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ViewSiteAreaLocationCountry&gt;"/></returns>
		protected VList<ViewSiteAreaLocationCountry> Fill(IDataReader reader, VList<ViewSiteAreaLocationCountry> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ViewSiteAreaLocationCountry entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ViewSiteAreaLocationCountry>("ViewSiteAreaLocationCountry",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ViewSiteAreaLocationCountry();
					}
					
					entity.SuppressEntityEvents = true;

					entity.AreaId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.AreaId)];
					//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
					entity.SiteLocationId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationId)];
					//entity.SiteLocationId = (Convert.IsDBNull(reader["SiteLocationID"]))?(int)0:(System.Int32)reader["SiteLocationID"];
					entity.LocationId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.LocationId)];
					//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
					entity.SiteAreaId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteAreaId)];
					//entity.SiteAreaId = (Convert.IsDBNull(reader["SiteAreaID"]))?(int)0:(System.Int32)reader["SiteAreaID"];
					entity.SiteAreaName = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.SiteAreaName)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteAreaName)];
					//entity.SiteAreaName = (Convert.IsDBNull(reader["SiteAreaName"]))?string.Empty:(System.String)reader["SiteAreaName"];
					entity.SiteLocationName = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.SiteLocationName)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationName)];
					//entity.SiteLocationName = (Convert.IsDBNull(reader["SiteLocationName"]))?string.Empty:(System.String)reader["SiteLocationName"];
					entity.SiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteId)];
					//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
					entity.SiteLocationSiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationSiteId)];
					//entity.SiteLocationSiteId = (Convert.IsDBNull(reader["SiteLocationSiteId"]))?(int)0:(System.Int32)reader["SiteLocationSiteId"];
					entity.SiteCountrySiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteCountrySiteId)];
					//entity.SiteCountrySiteId = (Convert.IsDBNull(reader["SiteCountrySiteId"]))?(int)0:(System.Int32)reader["SiteCountrySiteId"];
					entity.CountryId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.CountryId)];
					//entity.CountryId = (Convert.IsDBNull(reader["CountryID"]))?(int)0:(System.Int32)reader["CountryID"];
					entity.SiteCountryName = (System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteCountryName)];
					//entity.SiteCountryName = (Convert.IsDBNull(reader["SiteCountryName"]))?string.Empty:(System.String)reader["SiteCountryName"];
					entity.Currency = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.Currency)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.Currency)];
					//entity.Currency = (Convert.IsDBNull(reader["Currency"]))?string.Empty:(System.String)reader["Currency"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="ViewSiteAreaLocationCountry"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSiteAreaLocationCountry"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ViewSiteAreaLocationCountry entity)
		{
			reader.Read();
			entity.AreaId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.AreaId)];
			//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
			entity.SiteLocationId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationId)];
			//entity.SiteLocationId = (Convert.IsDBNull(reader["SiteLocationID"]))?(int)0:(System.Int32)reader["SiteLocationID"];
			entity.LocationId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.LocationId)];
			//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
			entity.SiteAreaId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteAreaId)];
			//entity.SiteAreaId = (Convert.IsDBNull(reader["SiteAreaID"]))?(int)0:(System.Int32)reader["SiteAreaID"];
			entity.SiteAreaName = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.SiteAreaName)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteAreaName)];
			//entity.SiteAreaName = (Convert.IsDBNull(reader["SiteAreaName"]))?string.Empty:(System.String)reader["SiteAreaName"];
			entity.SiteLocationName = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.SiteLocationName)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationName)];
			//entity.SiteLocationName = (Convert.IsDBNull(reader["SiteLocationName"]))?string.Empty:(System.String)reader["SiteLocationName"];
			entity.SiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteId)];
			//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
			entity.SiteLocationSiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteLocationSiteId)];
			//entity.SiteLocationSiteId = (Convert.IsDBNull(reader["SiteLocationSiteId"]))?(int)0:(System.Int32)reader["SiteLocationSiteId"];
			entity.SiteCountrySiteId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.SiteCountrySiteId)];
			//entity.SiteCountrySiteId = (Convert.IsDBNull(reader["SiteCountrySiteId"]))?(int)0:(System.Int32)reader["SiteCountrySiteId"];
			entity.CountryId = (System.Int32)reader[((int)ViewSiteAreaLocationCountryColumn.CountryId)];
			//entity.CountryId = (Convert.IsDBNull(reader["CountryID"]))?(int)0:(System.Int32)reader["CountryID"];
			entity.SiteCountryName = (System.String)reader[((int)ViewSiteAreaLocationCountryColumn.SiteCountryName)];
			//entity.SiteCountryName = (Convert.IsDBNull(reader["SiteCountryName"]))?string.Empty:(System.String)reader["SiteCountryName"];
			entity.Currency = (reader.IsDBNull(((int)ViewSiteAreaLocationCountryColumn.Currency)))?null:(System.String)reader[((int)ViewSiteAreaLocationCountryColumn.Currency)];
			//entity.Currency = (Convert.IsDBNull(reader["Currency"]))?string.Empty:(System.String)reader["Currency"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ViewSiteAreaLocationCountry"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSiteAreaLocationCountry"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ViewSiteAreaLocationCountry entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AreaId = (Convert.IsDBNull(dataRow["AreaID"]))?(int)0:(System.Int32)dataRow["AreaID"];
			entity.SiteLocationId = (Convert.IsDBNull(dataRow["SiteLocationID"]))?(int)0:(System.Int32)dataRow["SiteLocationID"];
			entity.LocationId = (Convert.IsDBNull(dataRow["LocationID"]))?(int)0:(System.Int32)dataRow["LocationID"];
			entity.SiteAreaId = (Convert.IsDBNull(dataRow["SiteAreaID"]))?(int)0:(System.Int32)dataRow["SiteAreaID"];
			entity.SiteAreaName = (Convert.IsDBNull(dataRow["SiteAreaName"]))?string.Empty:(System.String)dataRow["SiteAreaName"];
			entity.SiteLocationName = (Convert.IsDBNull(dataRow["SiteLocationName"]))?string.Empty:(System.String)dataRow["SiteLocationName"];
			entity.SiteId = (Convert.IsDBNull(dataRow["SiteID"]))?(int)0:(System.Int32)dataRow["SiteID"];
			entity.SiteLocationSiteId = (Convert.IsDBNull(dataRow["SiteLocationSiteId"]))?(int)0:(System.Int32)dataRow["SiteLocationSiteId"];
			entity.SiteCountrySiteId = (Convert.IsDBNull(dataRow["SiteCountrySiteId"]))?(int)0:(System.Int32)dataRow["SiteCountrySiteId"];
			entity.CountryId = (Convert.IsDBNull(dataRow["CountryID"]))?(int)0:(System.Int32)dataRow["CountryID"];
			entity.SiteCountryName = (Convert.IsDBNull(dataRow["SiteCountryName"]))?string.Empty:(System.String)dataRow["SiteCountryName"];
			entity.Currency = (Convert.IsDBNull(dataRow["Currency"]))?string.Empty:(System.String)dataRow["Currency"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ViewSiteAreaLocationCountryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAreaLocationCountry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAreaLocationCountryFilterBuilder : SqlFilterBuilder<ViewSiteAreaLocationCountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilterBuilder class.
		/// </summary>
		public ViewSiteAreaLocationCountryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAreaLocationCountryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAreaLocationCountryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAreaLocationCountryFilterBuilder

	#region ViewSiteAreaLocationCountryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAreaLocationCountry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAreaLocationCountryParameterBuilder : ParameterizedSqlFilterBuilder<ViewSiteAreaLocationCountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryParameterBuilder class.
		/// </summary>
		public ViewSiteAreaLocationCountryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAreaLocationCountryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAreaLocationCountryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAreaLocationCountryParameterBuilder
	
	#region ViewSiteAreaLocationCountrySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAreaLocationCountry"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ViewSiteAreaLocationCountrySortBuilder : SqlSortBuilder<ViewSiteAreaLocationCountryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountrySqlSortBuilder class.
		/// </summary>
		public ViewSiteAreaLocationCountrySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ViewSiteAreaLocationCountrySortBuilder

} // end namespace
