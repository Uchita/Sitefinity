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
	/// This class is the base class for any <see cref="ViewSalaryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ViewSalaryProviderBaseCore : EntityViewProviderBase<ViewSalary>
	{
		#region Custom Methods
		
		
		#region ViewSalary_Get_List
		
		/// <summary>
		///	This method wrap the 'ViewSalary_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'ViewSalary_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public abstract VList<ViewSalary> Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion

		
		#region ViewSalary_GetCustomSalaryTo
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryTo' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amountFrom"> A <c>System.Decimal?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryTo(System.Int32? siteId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? amountFrom)
		{
			return GetCustomSalaryTo(null, 0, int.MaxValue , siteId, currencyId, salaryTypeId, amountFrom);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryTo' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amountFrom"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryTo(int start, int pageLength, System.Int32? siteId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? amountFrom)
		{
			return GetCustomSalaryTo(null, start, pageLength , siteId, currencyId, salaryTypeId, amountFrom);
		}
				
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryTo' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amountFrom"> A <c>System.Decimal?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryTo(TransactionManager transactionManager, System.Int32? siteId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? amountFrom)
		{
			return GetCustomSalaryTo(transactionManager, 0, int.MaxValue , siteId, currencyId, salaryTypeId, amountFrom);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryTo' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="amountFrom"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public abstract VList<ViewSalary> GetCustomSalaryTo(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteId, System.Int32? currencyId, System.Int32? salaryTypeId, System.Decimal? amountFrom);
		
		#endregion

		
		#region ViewSalary_GetCustomSalaryFrom
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryFrom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryFrom(System.Int32? siteId, System.Int32? salaryTypeId)
		{
			return GetCustomSalaryFrom(null, 0, int.MaxValue , siteId, salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryFrom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryFrom(int start, int pageLength, System.Int32? siteId, System.Int32? salaryTypeId)
		{
			return GetCustomSalaryFrom(null, start, pageLength , siteId, salaryTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryFrom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public VList<ViewSalary> GetCustomSalaryFrom(TransactionManager transactionManager, System.Int32? siteId, System.Int32? salaryTypeId)
		{
			return GetCustomSalaryFrom(transactionManager, 0, int.MaxValue , siteId, salaryTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewSalary_GetCustomSalaryFrom' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewSalary&gt;"/> instance.</returns>
		public abstract VList<ViewSalary> GetCustomSalaryFrom(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteId, System.Int32? salaryTypeId);
		
		#endregion

		
		#region ViewSalary_Get
		
		/// <summary>
		///	This method wrap the 'ViewSalary_Get' stored procedure. 
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
		///	This method wrap the 'ViewSalary_Get' stored procedure. 
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
		///	This method wrap the 'ViewSalary_Get' stored procedure. 
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
		///	This method wrap the 'ViewSalary_Get' stored procedure. 
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
		/// Fill an VList&lt;ViewSalary&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ViewSalary&gt;"/></returns>
		protected static VList&lt;ViewSalary&gt; Fill(DataSet dataSet, VList<ViewSalary> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ViewSalary>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ViewSalary&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ViewSalary>"/></returns>
		protected static VList&lt;ViewSalary&gt; Fill(DataTable dataTable, VList<ViewSalary> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ViewSalary c = new ViewSalary();
					c.SalaryId = (Convert.IsDBNull(row["SalaryID"]))?(int)0:(System.Int32)row["SalaryID"];
					c.SalaryTypeId = (Convert.IsDBNull(row["SalaryTypeId"]))?(int)0:(System.Int32?)row["SalaryTypeId"];
					c.SalaryTypeName = (Convert.IsDBNull(row["SalaryTypeName"]))?string.Empty:(System.String)row["SalaryTypeName"];
					c.Amount = (Convert.IsDBNull(row["Amount"]))?0.0m:(System.Decimal)row["Amount"];
					c.IsFrom = (Convert.IsDBNull(row["IsFrom"]))?false:(System.Boolean)row["IsFrom"];
					c.CurrencyId = (Convert.IsDBNull(row["CurrencyID"]))?(int)0:(System.Int32?)row["CurrencyID"];
					c.CurrencySymbol = (Convert.IsDBNull(row["CurrencySymbol"]))?string.Empty:(System.String)row["CurrencySymbol"];
					c.SalaryDisplay = (Convert.IsDBNull(row["SalaryDisplay"]))?string.Empty:(System.String)row["SalaryDisplay"];
					c.SiteId = (Convert.IsDBNull(row["SiteID"]))?(int)0:(System.Int32)row["SiteID"];
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
		/// Fill an <see cref="VList&lt;ViewSalary&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ViewSalary&gt;"/></returns>
		protected VList<ViewSalary> Fill(IDataReader reader, VList<ViewSalary> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ViewSalary entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ViewSalary>("ViewSalary",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ViewSalary();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SalaryId = (System.Int32)reader[((int)ViewSalaryColumn.SalaryId)];
					//entity.SalaryId = (Convert.IsDBNull(reader["SalaryID"]))?(int)0:(System.Int32)reader["SalaryID"];
					entity.SalaryTypeId = (reader.IsDBNull(((int)ViewSalaryColumn.SalaryTypeId)))?null:(System.Int32?)reader[((int)ViewSalaryColumn.SalaryTypeId)];
					//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeId"]))?(int)0:(System.Int32?)reader["SalaryTypeId"];
					entity.SalaryTypeName = (System.String)reader[((int)ViewSalaryColumn.SalaryTypeName)];
					//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
					entity.Amount = (System.Decimal)reader[((int)ViewSalaryColumn.Amount)];
					//entity.Amount = (Convert.IsDBNull(reader["Amount"]))?0.0m:(System.Decimal)reader["Amount"];
					entity.IsFrom = (System.Boolean)reader[((int)ViewSalaryColumn.IsFrom)];
					//entity.IsFrom = (Convert.IsDBNull(reader["IsFrom"]))?false:(System.Boolean)reader["IsFrom"];
					entity.CurrencyId = (reader.IsDBNull(((int)ViewSalaryColumn.CurrencyId)))?null:(System.Int32?)reader[((int)ViewSalaryColumn.CurrencyId)];
					//entity.CurrencyId = (Convert.IsDBNull(reader["CurrencyID"]))?(int)0:(System.Int32?)reader["CurrencyID"];
					entity.CurrencySymbol = (System.String)reader[((int)ViewSalaryColumn.CurrencySymbol)];
					//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
					entity.SalaryDisplay = (System.String)reader[((int)ViewSalaryColumn.SalaryDisplay)];
					//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
					entity.SiteId = (System.Int32)reader[((int)ViewSalaryColumn.SiteId)];
					//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
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
		/// Refreshes the <see cref="ViewSalary"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSalary"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ViewSalary entity)
		{
			reader.Read();
			entity.SalaryId = (System.Int32)reader[((int)ViewSalaryColumn.SalaryId)];
			//entity.SalaryId = (Convert.IsDBNull(reader["SalaryID"]))?(int)0:(System.Int32)reader["SalaryID"];
			entity.SalaryTypeId = (reader.IsDBNull(((int)ViewSalaryColumn.SalaryTypeId)))?null:(System.Int32?)reader[((int)ViewSalaryColumn.SalaryTypeId)];
			//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeId"]))?(int)0:(System.Int32?)reader["SalaryTypeId"];
			entity.SalaryTypeName = (System.String)reader[((int)ViewSalaryColumn.SalaryTypeName)];
			//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
			entity.Amount = (System.Decimal)reader[((int)ViewSalaryColumn.Amount)];
			//entity.Amount = (Convert.IsDBNull(reader["Amount"]))?0.0m:(System.Decimal)reader["Amount"];
			entity.IsFrom = (System.Boolean)reader[((int)ViewSalaryColumn.IsFrom)];
			//entity.IsFrom = (Convert.IsDBNull(reader["IsFrom"]))?false:(System.Boolean)reader["IsFrom"];
			entity.CurrencyId = (reader.IsDBNull(((int)ViewSalaryColumn.CurrencyId)))?null:(System.Int32?)reader[((int)ViewSalaryColumn.CurrencyId)];
			//entity.CurrencyId = (Convert.IsDBNull(reader["CurrencyID"]))?(int)0:(System.Int32?)reader["CurrencyID"];
			entity.CurrencySymbol = (System.String)reader[((int)ViewSalaryColumn.CurrencySymbol)];
			//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
			entity.SalaryDisplay = (System.String)reader[((int)ViewSalaryColumn.SalaryDisplay)];
			//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
			entity.SiteId = (System.Int32)reader[((int)ViewSalaryColumn.SiteId)];
			//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ViewSalary"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewSalary"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ViewSalary entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalaryId = (Convert.IsDBNull(dataRow["SalaryID"]))?(int)0:(System.Int32)dataRow["SalaryID"];
			entity.SalaryTypeId = (Convert.IsDBNull(dataRow["SalaryTypeId"]))?(int)0:(System.Int32?)dataRow["SalaryTypeId"];
			entity.SalaryTypeName = (Convert.IsDBNull(dataRow["SalaryTypeName"]))?string.Empty:(System.String)dataRow["SalaryTypeName"];
			entity.Amount = (Convert.IsDBNull(dataRow["Amount"]))?0.0m:(System.Decimal)dataRow["Amount"];
			entity.IsFrom = (Convert.IsDBNull(dataRow["IsFrom"]))?false:(System.Boolean)dataRow["IsFrom"];
			entity.CurrencyId = (Convert.IsDBNull(dataRow["CurrencyID"]))?(int)0:(System.Int32?)dataRow["CurrencyID"];
			entity.CurrencySymbol = (Convert.IsDBNull(dataRow["CurrencySymbol"]))?string.Empty:(System.String)dataRow["CurrencySymbol"];
			entity.SalaryDisplay = (Convert.IsDBNull(dataRow["SalaryDisplay"]))?string.Empty:(System.String)dataRow["SalaryDisplay"];
			entity.SiteId = (Convert.IsDBNull(dataRow["SiteID"]))?(int)0:(System.Int32)dataRow["SiteID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ViewSalaryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSalaryFilterBuilder : SqlFilterBuilder<ViewSalaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilterBuilder class.
		/// </summary>
		public ViewSalaryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSalaryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSalaryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSalaryFilterBuilder

	#region ViewSalaryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSalaryParameterBuilder : ParameterizedSqlFilterBuilder<ViewSalaryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSalaryParameterBuilder class.
		/// </summary>
		public ViewSalaryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSalaryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSalaryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSalaryParameterBuilder
	
	#region ViewSalarySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSalary"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ViewSalarySortBuilder : SqlSortBuilder<ViewSalaryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSalarySqlSortBuilder class.
		/// </summary>
		public ViewSalarySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ViewSalarySortBuilder

} // end namespace
