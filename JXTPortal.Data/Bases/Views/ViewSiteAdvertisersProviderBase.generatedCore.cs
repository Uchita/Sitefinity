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
	/// This class is the base class for any <see cref="ViewSiteAdvertisersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ViewSiteAdvertisersProviderBaseCore : EntityViewProviderBase<ViewSiteAdvertisers>
	{
		#region Custom Methods
		
		
		#region ViewSiteAdvertisers_Get_List
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get_List' stored procedure. 
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
		///	This method wrap the 'ViewSiteAdvertisers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion

		
		#region ViewSiteAdvertisers_Get
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Get(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 Get(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Get(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 Get(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Get(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 Get(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSiteAdvertisers_Get' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Get(TransactionManager transactionManager, int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ViewSiteAdvertisers&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ViewSiteAdvertisers&gt;"/></returns>
		protected static VList&lt;ViewSiteAdvertisers&gt; Fill(DataSet dataSet, VList<ViewSiteAdvertisers> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ViewSiteAdvertisers>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ViewSiteAdvertisers&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ViewSiteAdvertisers>"/></returns>
		protected static VList&lt;ViewSiteAdvertisers&gt; Fill(DataTable dataTable, VList<ViewSiteAdvertisers> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ViewSiteAdvertisers c = new ViewSiteAdvertisers();
					c.AdvertiserId = (Convert.IsDBNull(row["AdvertiserID"]))?(int)0:(System.Int32)row["AdvertiserID"];
					c.SiteId = (Convert.IsDBNull(row["SiteID"]))?(int)0:(System.Int32?)row["SiteID"];
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
		/// Fill an <see cref="VList&lt;ViewSiteAdvertisers&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ViewSiteAdvertisers&gt;"/></returns>
		protected VList<ViewSiteAdvertisers> Fill(IDataReader reader, VList<ViewSiteAdvertisers> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ViewSiteAdvertisers entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ViewSiteAdvertisers>("ViewSiteAdvertisers",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ViewSiteAdvertisers();
					}
					
					entity.SuppressEntityEvents = true;

					entity.AdvertiserId = (System.Int32)reader[((int)ViewSiteAdvertisersColumn.AdvertiserId)];
					//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32)reader["AdvertiserID"];
					entity.SiteId = (reader.IsDBNull(((int)ViewSiteAdvertisersColumn.SiteId)))?null:(System.Int32?)reader[((int)ViewSiteAdvertisersColumn.SiteId)];
					//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32?)reader["SiteID"];
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
		/// Refreshes the <see cref="ViewSiteAdvertisers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSiteAdvertisers"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ViewSiteAdvertisers entity)
		{
			reader.Read();
			entity.AdvertiserId = (System.Int32)reader[((int)ViewSiteAdvertisersColumn.AdvertiserId)];
			//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32)reader["AdvertiserID"];
			entity.SiteId = (reader.IsDBNull(((int)ViewSiteAdvertisersColumn.SiteId)))?null:(System.Int32?)reader[((int)ViewSiteAdvertisersColumn.SiteId)];
			//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32?)reader["SiteID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ViewSiteAdvertisers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSiteAdvertisers"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ViewSiteAdvertisers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AdvertiserId = (Convert.IsDBNull(dataRow["AdvertiserID"]))?(int)0:(System.Int32)dataRow["AdvertiserID"];
			entity.SiteId = (Convert.IsDBNull(dataRow["SiteID"]))?(int)0:(System.Int32?)dataRow["SiteID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ViewSiteAdvertisersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersFilterBuilder : SqlFilterBuilder<ViewSiteAdvertisersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilterBuilder class.
		/// </summary>
		public ViewSiteAdvertisersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAdvertisersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAdvertisersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAdvertisersFilterBuilder

	#region ViewSiteAdvertisersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersParameterBuilder : ParameterizedSqlFilterBuilder<ViewSiteAdvertisersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersParameterBuilder class.
		/// </summary>
		public ViewSiteAdvertisersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAdvertisersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAdvertisersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAdvertisersParameterBuilder
	
	#region ViewSiteAdvertisersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ViewSiteAdvertisersSortBuilder : SqlSortBuilder<ViewSiteAdvertisersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersSqlSortBuilder class.
		/// </summary>
		public ViewSiteAdvertisersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ViewSiteAdvertisersSortBuilder

} // end namespace
