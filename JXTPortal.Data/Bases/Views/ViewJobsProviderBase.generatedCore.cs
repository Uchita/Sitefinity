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
	/// This class is the base class for any <see cref="ViewJobsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ViewJobsProviderBaseCore : EntityViewProviderBase<ViewJobs>
	{
		#region Custom Methods
		
		
		#region ViewJobs_GetByID
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetByID' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobs&gt;"/> instance.</returns>
		public VList<ViewJobs> GetByID(System.Int32? jobId, System.Int32? siteId)
		{
			return GetByID(null, 0, int.MaxValue , jobId, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetByID' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobs&gt;"/> instance.</returns>
		public VList<ViewJobs> GetByID(int start, int pageLength, System.Int32? jobId, System.Int32? siteId)
		{
			return GetByID(null, start, pageLength , jobId, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobs_GetByID' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="VList&lt;ViewJobs&gt;"/> instance.</returns>
		public VList<ViewJobs> GetByID(TransactionManager transactionManager, System.Int32? jobId, System.Int32? siteId)
		{
			return GetByID(transactionManager, 0, int.MaxValue , jobId, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetByID' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="VList&lt;ViewJobs&gt;"/> instance.</returns>
		public abstract VList<ViewJobs> GetByID(TransactionManager transactionManager, int start, int pageLength, System.Int32? jobId, System.Int32? siteId);
		
		#endregion

		
		#region ViewJobs_GetViewCount
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetViewCount' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetViewCount(System.Int32? jobId)
		{
			return GetViewCount(null, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetViewCount' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetViewCount(int start, int pageLength, System.Int32? jobId)
		{
			return GetViewCount(null, start, pageLength , jobId);
		}
				
		/// <summary>
		///	This method wrap the 'ViewJobs_GetViewCount' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetViewCount(TransactionManager transactionManager, System.Int32? jobId)
		{
			return GetViewCount(transactionManager, 0, int.MaxValue , jobId);
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_GetViewCount' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetViewCount(TransactionManager transactionManager, int start, int pageLength, System.Int32? jobId);
		
		#endregion

		
		#region ViewJobs_Get_List
		
		/// <summary>
		///	This method wrap the 'ViewJobs_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_Get_List' stored procedure. 
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
		///	This method wrap the 'ViewJobs_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ViewJobs_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength);
		
		#endregion

		
		#region ViewJobs_Get
		
		/// <summary>
		///	This method wrap the 'ViewJobs_Get' stored procedure. 
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
		///	This method wrap the 'ViewJobs_Get' stored procedure. 
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
		///	This method wrap the 'ViewJobs_Get' stored procedure. 
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
		///	This method wrap the 'ViewJobs_Get' stored procedure. 
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
		/// Fill an VList&lt;ViewJobs&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ViewJobs&gt;"/></returns>
		protected static VList&lt;ViewJobs&gt; Fill(DataSet dataSet, VList<ViewJobs> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ViewJobs>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ViewJobs&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ViewJobs>"/></returns>
		protected static VList&lt;ViewJobs&gt; Fill(DataTable dataTable, VList<ViewJobs> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ViewJobs c = new ViewJobs();
					c.JobId = (Convert.IsDBNull(row["JobID"]))?(int)0:(System.Int32)row["JobID"];
					c.SiteId = (Convert.IsDBNull(row["SiteID"]))?(int)0:(System.Int32)row["SiteID"];
					c.WorkTypeId = (Convert.IsDBNull(row["WorkTypeID"]))?(int)0:(System.Int32)row["WorkTypeID"];
					c.JobName = (Convert.IsDBNull(row["JobName"]))?string.Empty:(System.String)row["JobName"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.FullDescription = (Convert.IsDBNull(row["FullDescription"]))?string.Empty:(System.String)row["FullDescription"];
					c.WebServiceProcessed = (Convert.IsDBNull(row["WebServiceProcessed"]))?false:(System.Boolean)row["WebServiceProcessed"];
					c.ApplicationEmailAddress = (Convert.IsDBNull(row["ApplicationEmailAddress"]))?string.Empty:(System.String)row["ApplicationEmailAddress"];
					c.RefNo = (Convert.IsDBNull(row["RefNo"]))?string.Empty:(System.String)row["RefNo"];
					c.Visible = (Convert.IsDBNull(row["Visible"]))?false:(System.Boolean)row["Visible"];
					c.DatePosted = (Convert.IsDBNull(row["DatePosted"]))?DateTime.MinValue:(System.DateTime)row["DatePosted"];
					c.ExpiryDate = (Convert.IsDBNull(row["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)row["ExpiryDate"];
					c.Expired = (Convert.IsDBNull(row["Expired"]))?(int)0:(System.Int32?)row["Expired"];
					c.JobItemPrice = (Convert.IsDBNull(row["JobItemPrice"]))?0:(System.Decimal?)row["JobItemPrice"];
					c.Billed = (Convert.IsDBNull(row["Billed"]))?false:(System.Boolean)row["Billed"];
					c.LastModified = (Convert.IsDBNull(row["LastModified"]))?DateTime.MinValue:(System.DateTime)row["LastModified"];
					c.ShowSalaryDetails = (Convert.IsDBNull(row["ShowSalaryDetails"]))?false:(System.Boolean)row["ShowSalaryDetails"];
					c.ShowSalaryRange = (Convert.IsDBNull(row["ShowSalaryRange"]))?false:(System.Boolean)row["ShowSalaryRange"];
					c.SalaryText = (Convert.IsDBNull(row["SalaryText"]))?string.Empty:(System.String)row["SalaryText"];
					c.AdvertiserId = (Convert.IsDBNull(row["AdvertiserID"]))?(int)0:(System.Int32?)row["AdvertiserID"];
					c.LastModifiedByAdvertiserUserId = (Convert.IsDBNull(row["LastModifiedByAdvertiserUserId"]))?(int)0:(System.Int32?)row["LastModifiedByAdvertiserUserId"];
					c.LastModifiedByAdminUserId = (Convert.IsDBNull(row["LastModifiedByAdminUserId"]))?(int)0:(System.Int32?)row["LastModifiedByAdminUserId"];
					c.JobItemTypeId = (Convert.IsDBNull(row["JobItemTypeID"]))?(int)0:(System.Int32?)row["JobItemTypeID"];
					c.ApplicationMethod = (Convert.IsDBNull(row["ApplicationMethod"]))?(int)0:(System.Int32?)row["ApplicationMethod"];
					c.ApplicationUrl = (Convert.IsDBNull(row["ApplicationUrl"]))?string.Empty:(System.String)row["ApplicationUrl"];
					c.UploadMethod = (Convert.IsDBNull(row["UploadMethod"]))?(int)0:(System.Int32?)row["UploadMethod"];
					c.Tags = (Convert.IsDBNull(row["Tags"]))?string.Empty:(System.String)row["Tags"];
					c.JobTemplateId = (Convert.IsDBNull(row["JobTemplateID"]))?(int)0:(System.Int32?)row["JobTemplateID"];
					c.SearchField = (Convert.IsDBNull(row["SearchField"]))?string.Empty:(System.String)row["SearchField"];
					c.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(row["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)row["AdvertiserJobTemplateLogoID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.HashValue = (Convert.IsDBNull(row["HashValue"]))?new byte[] {}:(System.Byte[])row["HashValue"];
					c.RequireLogonForExternalApplications = (Convert.IsDBNull(row["RequireLogonForExternalApplications"]))?false:(System.Boolean)row["RequireLogonForExternalApplications"];
					c.ShowLocationDetails = (Convert.IsDBNull(row["ShowLocationDetails"]))?false:(System.Boolean?)row["ShowLocationDetails"];
					c.PublicTransport = (Convert.IsDBNull(row["PublicTransport"]))?string.Empty:(System.String)row["PublicTransport"];
					c.Address = (Convert.IsDBNull(row["Address"]))?string.Empty:(System.String)row["Address"];
					c.ContactDetails = (Convert.IsDBNull(row["ContactDetails"]))?string.Empty:(System.String)row["ContactDetails"];
					c.JobContactPhone = (Convert.IsDBNull(row["JobContactPhone"]))?string.Empty:(System.String)row["JobContactPhone"];
					c.JobContactName = (Convert.IsDBNull(row["JobContactName"]))?string.Empty:(System.String)row["JobContactName"];
					c.QualificationsRecognised = (Convert.IsDBNull(row["QualificationsRecognised"]))?false:(System.Boolean)row["QualificationsRecognised"];
					c.ResidentOnly = (Convert.IsDBNull(row["ResidentOnly"]))?false:(System.Boolean)row["ResidentOnly"];
					c.DocumentLink = (Convert.IsDBNull(row["DocumentLink"]))?string.Empty:(System.String)row["DocumentLink"];
					c.BulletPoint1 = (Convert.IsDBNull(row["BulletPoint1"]))?string.Empty:(System.String)row["BulletPoint1"];
					c.BulletPoint2 = (Convert.IsDBNull(row["BulletPoint2"]))?string.Empty:(System.String)row["BulletPoint2"];
					c.BulletPoint3 = (Convert.IsDBNull(row["BulletPoint3"]))?string.Empty:(System.String)row["BulletPoint3"];
					c.HotJob = (Convert.IsDBNull(row["HotJob"]))?false:(System.Boolean)row["HotJob"];
					c.AdvertiserCompanyName = (Convert.IsDBNull(row["AdvertiserCompanyName"]))?string.Empty:(System.String)row["AdvertiserCompanyName"];
					c.BusinessNumber = (Convert.IsDBNull(row["BusinessNumber"]))?string.Empty:(System.String)row["BusinessNumber"];
					c.StreetAddress1 = (Convert.IsDBNull(row["StreetAddress1"]))?string.Empty:(System.String)row["StreetAddress1"];
					c.StreetAddress2 = (Convert.IsDBNull(row["StreetAddress2"]))?string.Empty:(System.String)row["StreetAddress2"];
					c.WebAddress = (Convert.IsDBNull(row["WebAddress"]))?string.Empty:(System.String)row["WebAddress"];
					c.Profile = (Convert.IsDBNull(row["Profile"]))?string.Empty:(System.String)row["Profile"];
					c.RequireLogonForExternalApplication = (Convert.IsDBNull(row["RequireLogonForExternalApplication"]))?false:(System.Boolean)row["RequireLogonForExternalApplication"];
					c.AdvertiserLogo = (Convert.IsDBNull(row["AdvertiserLogo"]))?new byte[] {}:(System.Byte[])row["AdvertiserLogo"];
					c.AdvertiserLogoUrl = (Convert.IsDBNull(row["AdvertiserLogoUrl"]))?string.Empty:(System.String)row["AdvertiserLogoUrl"];
					c.SiteWorkTypeName = (Convert.IsDBNull(row["SiteWorkTypeName"]))?string.Empty:(System.String)row["SiteWorkTypeName"];
					c.CurrencySymbol = (Convert.IsDBNull(row["CurrencySymbol"]))?string.Empty:(System.String)row["CurrencySymbol"];
					c.SalaryUpperBand = (Convert.IsDBNull(row["SalaryUpperBand"]))?0.0m:(System.Decimal)row["SalaryUpperBand"];
					c.SalaryLowerBand = (Convert.IsDBNull(row["SalaryLowerBand"]))?0.0m:(System.Decimal)row["SalaryLowerBand"];
					c.SalaryTypeId = (Convert.IsDBNull(row["SalaryTypeID"]))?(int)0:(System.Int32)row["SalaryTypeID"];
					c.JobTemplateHtml = (Convert.IsDBNull(row["JobTemplateHTML"]))?string.Empty:(System.String)row["JobTemplateHTML"];
					c.SalaryTypeName = (Convert.IsDBNull(row["SalaryTypeName"]))?string.Empty:(System.String)row["SalaryTypeName"];
					c.SiteAreaName = (Convert.IsDBNull(row["SiteAreaName"]))?string.Empty:(System.String)row["SiteAreaName"];
					c.SiteLocationName = (Convert.IsDBNull(row["SiteLocationName"]))?string.Empty:(System.String)row["SiteLocationName"];
					c.SiteRoleName = (Convert.IsDBNull(row["SiteRoleName"]))?string.Empty:(System.String)row["SiteRoleName"];
					c.SiteRoleCanonicalUrl = (Convert.IsDBNull(row["SiteRoleCanonicalUrl"]))?string.Empty:(System.String)row["SiteRoleCanonicalUrl"];
					c.SiteProfessionName = (Convert.IsDBNull(row["SiteProfessionName"]))?string.Empty:(System.String)row["SiteProfessionName"];
					c.SiteProfessionCanonicalUrl = (Convert.IsDBNull(row["SiteProfessionCanonicalUrl"]))?string.Empty:(System.String)row["SiteProfessionCanonicalUrl"];
					c.JobFriendlyName = (Convert.IsDBNull(row["JobFriendlyName"]))?string.Empty:(System.String)row["JobFriendlyName"];
					c.ProfessionId = (Convert.IsDBNull(row["ProfessionID"]))?(int)0:(System.Int32)row["ProfessionID"];
					c.RoleId = (Convert.IsDBNull(row["RoleID"]))?(int)0:(System.Int32)row["RoleID"];
					c.LocationId = (Convert.IsDBNull(row["LocationID"]))?(int)0:(System.Int32)row["LocationID"];
					c.AreaId = (Convert.IsDBNull(row["AreaID"]))?(int)0:(System.Int32)row["AreaID"];
					c.SalaryDisplay = (Convert.IsDBNull(row["SalaryDisplay"]))?string.Empty:(System.String)row["SalaryDisplay"];
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
		/// Fill an <see cref="VList&lt;ViewJobs&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ViewJobs&gt;"/></returns>
		protected VList<ViewJobs> Fill(IDataReader reader, VList<ViewJobs> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ViewJobs entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ViewJobs>("ViewJobs",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ViewJobs();
					}
					
					entity.SuppressEntityEvents = true;

					entity.JobId = (System.Int32)reader[((int)ViewJobsColumn.JobId)];
					//entity.JobId = (Convert.IsDBNull(reader["JobID"]))?(int)0:(System.Int32)reader["JobID"];
					entity.SiteId = (System.Int32)reader[((int)ViewJobsColumn.SiteId)];
					//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
					entity.WorkTypeId = (System.Int32)reader[((int)ViewJobsColumn.WorkTypeId)];
					//entity.WorkTypeId = (Convert.IsDBNull(reader["WorkTypeID"]))?(int)0:(System.Int32)reader["WorkTypeID"];
					entity.JobName = (System.String)reader[((int)ViewJobsColumn.JobName)];
					//entity.JobName = (Convert.IsDBNull(reader["JobName"]))?string.Empty:(System.String)reader["JobName"];
					entity.Description = (System.String)reader[((int)ViewJobsColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.FullDescription = (System.String)reader[((int)ViewJobsColumn.FullDescription)];
					//entity.FullDescription = (Convert.IsDBNull(reader["FullDescription"]))?string.Empty:(System.String)reader["FullDescription"];
					entity.WebServiceProcessed = (System.Boolean)reader[((int)ViewJobsColumn.WebServiceProcessed)];
					//entity.WebServiceProcessed = (Convert.IsDBNull(reader["WebServiceProcessed"]))?false:(System.Boolean)reader["WebServiceProcessed"];
					entity.ApplicationEmailAddress = (System.String)reader[((int)ViewJobsColumn.ApplicationEmailAddress)];
					//entity.ApplicationEmailAddress = (Convert.IsDBNull(reader["ApplicationEmailAddress"]))?string.Empty:(System.String)reader["ApplicationEmailAddress"];
					entity.RefNo = (reader.IsDBNull(((int)ViewJobsColumn.RefNo)))?null:(System.String)reader[((int)ViewJobsColumn.RefNo)];
					//entity.RefNo = (Convert.IsDBNull(reader["RefNo"]))?string.Empty:(System.String)reader["RefNo"];
					entity.Visible = (System.Boolean)reader[((int)ViewJobsColumn.Visible)];
					//entity.Visible = (Convert.IsDBNull(reader["Visible"]))?false:(System.Boolean)reader["Visible"];
					entity.DatePosted = (System.DateTime)reader[((int)ViewJobsColumn.DatePosted)];
					//entity.DatePosted = (Convert.IsDBNull(reader["DatePosted"]))?DateTime.MinValue:(System.DateTime)reader["DatePosted"];
					entity.ExpiryDate = (System.DateTime)reader[((int)ViewJobsColumn.ExpiryDate)];
					//entity.ExpiryDate = (Convert.IsDBNull(reader["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)reader["ExpiryDate"];
					entity.Expired = (reader.IsDBNull(((int)ViewJobsColumn.Expired)))?null:(System.Int32?)reader[((int)ViewJobsColumn.Expired)];
					//entity.Expired = (Convert.IsDBNull(reader["Expired"]))?(int)0:(System.Int32?)reader["Expired"];
					entity.JobItemPrice = (reader.IsDBNull(((int)ViewJobsColumn.JobItemPrice)))?null:(System.Decimal?)reader[((int)ViewJobsColumn.JobItemPrice)];
					//entity.JobItemPrice = (Convert.IsDBNull(reader["JobItemPrice"]))?0:(System.Decimal?)reader["JobItemPrice"];
					entity.Billed = (System.Boolean)reader[((int)ViewJobsColumn.Billed)];
					//entity.Billed = (Convert.IsDBNull(reader["Billed"]))?false:(System.Boolean)reader["Billed"];
					entity.LastModified = (System.DateTime)reader[((int)ViewJobsColumn.LastModified)];
					//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
					entity.ShowSalaryDetails = (System.Boolean)reader[((int)ViewJobsColumn.ShowSalaryDetails)];
					//entity.ShowSalaryDetails = (Convert.IsDBNull(reader["ShowSalaryDetails"]))?false:(System.Boolean)reader["ShowSalaryDetails"];
					entity.ShowSalaryRange = (System.Boolean)reader[((int)ViewJobsColumn.ShowSalaryRange)];
					//entity.ShowSalaryRange = (Convert.IsDBNull(reader["ShowSalaryRange"]))?false:(System.Boolean)reader["ShowSalaryRange"];
					entity.SalaryText = (reader.IsDBNull(((int)ViewJobsColumn.SalaryText)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryText)];
					//entity.SalaryText = (Convert.IsDBNull(reader["SalaryText"]))?string.Empty:(System.String)reader["SalaryText"];
					entity.AdvertiserId = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.AdvertiserId)];
					//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32?)reader["AdvertiserID"];
					entity.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)ViewJobsColumn.LastModifiedByAdvertiserUserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.LastModifiedByAdvertiserUserId)];
					//entity.LastModifiedByAdvertiserUserId = (Convert.IsDBNull(reader["LastModifiedByAdvertiserUserId"]))?(int)0:(System.Int32?)reader["LastModifiedByAdvertiserUserId"];
					entity.LastModifiedByAdminUserId = (reader.IsDBNull(((int)ViewJobsColumn.LastModifiedByAdminUserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.LastModifiedByAdminUserId)];
					//entity.LastModifiedByAdminUserId = (Convert.IsDBNull(reader["LastModifiedByAdminUserId"]))?(int)0:(System.Int32?)reader["LastModifiedByAdminUserId"];
					entity.JobItemTypeId = (reader.IsDBNull(((int)ViewJobsColumn.JobItemTypeId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.JobItemTypeId)];
					//entity.JobItemTypeId = (Convert.IsDBNull(reader["JobItemTypeID"]))?(int)0:(System.Int32?)reader["JobItemTypeID"];
					entity.ApplicationMethod = (reader.IsDBNull(((int)ViewJobsColumn.ApplicationMethod)))?null:(System.Int32?)reader[((int)ViewJobsColumn.ApplicationMethod)];
					//entity.ApplicationMethod = (Convert.IsDBNull(reader["ApplicationMethod"]))?(int)0:(System.Int32?)reader["ApplicationMethod"];
					entity.ApplicationUrl = (reader.IsDBNull(((int)ViewJobsColumn.ApplicationUrl)))?null:(System.String)reader[((int)ViewJobsColumn.ApplicationUrl)];
					//entity.ApplicationUrl = (Convert.IsDBNull(reader["ApplicationUrl"]))?string.Empty:(System.String)reader["ApplicationUrl"];
					entity.UploadMethod = (reader.IsDBNull(((int)ViewJobsColumn.UploadMethod)))?null:(System.Int32?)reader[((int)ViewJobsColumn.UploadMethod)];
					//entity.UploadMethod = (Convert.IsDBNull(reader["UploadMethod"]))?(int)0:(System.Int32?)reader["UploadMethod"];
					entity.Tags = (reader.IsDBNull(((int)ViewJobsColumn.Tags)))?null:(System.String)reader[((int)ViewJobsColumn.Tags)];
					//entity.Tags = (Convert.IsDBNull(reader["Tags"]))?string.Empty:(System.String)reader["Tags"];
					entity.JobTemplateId = (reader.IsDBNull(((int)ViewJobsColumn.JobTemplateId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.JobTemplateId)];
					//entity.JobTemplateId = (Convert.IsDBNull(reader["JobTemplateID"]))?(int)0:(System.Int32?)reader["JobTemplateID"];
					entity.SearchField = (reader.IsDBNull(((int)ViewJobsColumn.SearchField)))?null:(System.String)reader[((int)ViewJobsColumn.SearchField)];
					//entity.SearchField = (Convert.IsDBNull(reader["SearchField"]))?string.Empty:(System.String)reader["SearchField"];
					entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserJobTemplateLogoId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.AdvertiserJobTemplateLogoId)];
					//entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(reader["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)reader["AdvertiserJobTemplateLogoID"];
					entity.CompanyName = (reader.IsDBNull(((int)ViewJobsColumn.CompanyName)))?null:(System.String)reader[((int)ViewJobsColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.HashValue = (reader.IsDBNull(((int)ViewJobsColumn.HashValue)))?null:(System.Byte[])reader[((int)ViewJobsColumn.HashValue)];
					//entity.HashValue = (Convert.IsDBNull(reader["HashValue"]))?new byte[] {}:(System.Byte[])reader["HashValue"];
					entity.RequireLogonForExternalApplications = (System.Boolean)reader[((int)ViewJobsColumn.RequireLogonForExternalApplications)];
					//entity.RequireLogonForExternalApplications = (Convert.IsDBNull(reader["RequireLogonForExternalApplications"]))?false:(System.Boolean)reader["RequireLogonForExternalApplications"];
					entity.ShowLocationDetails = (reader.IsDBNull(((int)ViewJobsColumn.ShowLocationDetails)))?null:(System.Boolean?)reader[((int)ViewJobsColumn.ShowLocationDetails)];
					//entity.ShowLocationDetails = (Convert.IsDBNull(reader["ShowLocationDetails"]))?false:(System.Boolean?)reader["ShowLocationDetails"];
					entity.PublicTransport = (reader.IsDBNull(((int)ViewJobsColumn.PublicTransport)))?null:(System.String)reader[((int)ViewJobsColumn.PublicTransport)];
					//entity.PublicTransport = (Convert.IsDBNull(reader["PublicTransport"]))?string.Empty:(System.String)reader["PublicTransport"];
					entity.Address = (reader.IsDBNull(((int)ViewJobsColumn.Address)))?null:(System.String)reader[((int)ViewJobsColumn.Address)];
					//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
					entity.ContactDetails = (System.String)reader[((int)ViewJobsColumn.ContactDetails)];
					//entity.ContactDetails = (Convert.IsDBNull(reader["ContactDetails"]))?string.Empty:(System.String)reader["ContactDetails"];
					entity.JobContactPhone = (reader.IsDBNull(((int)ViewJobsColumn.JobContactPhone)))?null:(System.String)reader[((int)ViewJobsColumn.JobContactPhone)];
					//entity.JobContactPhone = (Convert.IsDBNull(reader["JobContactPhone"]))?string.Empty:(System.String)reader["JobContactPhone"];
					entity.JobContactName = (reader.IsDBNull(((int)ViewJobsColumn.JobContactName)))?null:(System.String)reader[((int)ViewJobsColumn.JobContactName)];
					//entity.JobContactName = (Convert.IsDBNull(reader["JobContactName"]))?string.Empty:(System.String)reader["JobContactName"];
					entity.QualificationsRecognised = (System.Boolean)reader[((int)ViewJobsColumn.QualificationsRecognised)];
					//entity.QualificationsRecognised = (Convert.IsDBNull(reader["QualificationsRecognised"]))?false:(System.Boolean)reader["QualificationsRecognised"];
					entity.ResidentOnly = (System.Boolean)reader[((int)ViewJobsColumn.ResidentOnly)];
					//entity.ResidentOnly = (Convert.IsDBNull(reader["ResidentOnly"]))?false:(System.Boolean)reader["ResidentOnly"];
					entity.DocumentLink = (reader.IsDBNull(((int)ViewJobsColumn.DocumentLink)))?null:(System.String)reader[((int)ViewJobsColumn.DocumentLink)];
					//entity.DocumentLink = (Convert.IsDBNull(reader["DocumentLink"]))?string.Empty:(System.String)reader["DocumentLink"];
					entity.BulletPoint1 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint1)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint1)];
					//entity.BulletPoint1 = (Convert.IsDBNull(reader["BulletPoint1"]))?string.Empty:(System.String)reader["BulletPoint1"];
					entity.BulletPoint2 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint2)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint2)];
					//entity.BulletPoint2 = (Convert.IsDBNull(reader["BulletPoint2"]))?string.Empty:(System.String)reader["BulletPoint2"];
					entity.BulletPoint3 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint3)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint3)];
					//entity.BulletPoint3 = (Convert.IsDBNull(reader["BulletPoint3"]))?string.Empty:(System.String)reader["BulletPoint3"];
					entity.HotJob = (System.Boolean)reader[((int)ViewJobsColumn.HotJob)];
					//entity.HotJob = (Convert.IsDBNull(reader["HotJob"]))?false:(System.Boolean)reader["HotJob"];
					entity.AdvertiserCompanyName = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserCompanyName)))?null:(System.String)reader[((int)ViewJobsColumn.AdvertiserCompanyName)];
					//entity.AdvertiserCompanyName = (Convert.IsDBNull(reader["AdvertiserCompanyName"]))?string.Empty:(System.String)reader["AdvertiserCompanyName"];
					entity.BusinessNumber = (reader.IsDBNull(((int)ViewJobsColumn.BusinessNumber)))?null:(System.String)reader[((int)ViewJobsColumn.BusinessNumber)];
					//entity.BusinessNumber = (Convert.IsDBNull(reader["BusinessNumber"]))?string.Empty:(System.String)reader["BusinessNumber"];
					entity.StreetAddress1 = (reader.IsDBNull(((int)ViewJobsColumn.StreetAddress1)))?null:(System.String)reader[((int)ViewJobsColumn.StreetAddress1)];
					//entity.StreetAddress1 = (Convert.IsDBNull(reader["StreetAddress1"]))?string.Empty:(System.String)reader["StreetAddress1"];
					entity.StreetAddress2 = (reader.IsDBNull(((int)ViewJobsColumn.StreetAddress2)))?null:(System.String)reader[((int)ViewJobsColumn.StreetAddress2)];
					//entity.StreetAddress2 = (Convert.IsDBNull(reader["StreetAddress2"]))?string.Empty:(System.String)reader["StreetAddress2"];
					entity.WebAddress = (reader.IsDBNull(((int)ViewJobsColumn.WebAddress)))?null:(System.String)reader[((int)ViewJobsColumn.WebAddress)];
					//entity.WebAddress = (Convert.IsDBNull(reader["WebAddress"]))?string.Empty:(System.String)reader["WebAddress"];
					entity.Profile = (reader.IsDBNull(((int)ViewJobsColumn.Profile)))?null:(System.String)reader[((int)ViewJobsColumn.Profile)];
					//entity.Profile = (Convert.IsDBNull(reader["Profile"]))?string.Empty:(System.String)reader["Profile"];
					entity.RequireLogonForExternalApplication = (System.Boolean)reader[((int)ViewJobsColumn.RequireLogonForExternalApplication)];
					//entity.RequireLogonForExternalApplication = (Convert.IsDBNull(reader["RequireLogonForExternalApplication"]))?false:(System.Boolean)reader["RequireLogonForExternalApplication"];
					entity.AdvertiserLogo = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserLogo)))?null:(System.Byte[])reader[((int)ViewJobsColumn.AdvertiserLogo)];
					//entity.AdvertiserLogo = (Convert.IsDBNull(reader["AdvertiserLogo"]))?new byte[] {}:(System.Byte[])reader["AdvertiserLogo"];
					entity.AdvertiserLogoUrl = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserLogoUrl)))?null:(System.String)reader[((int)ViewJobsColumn.AdvertiserLogoUrl)];
					//entity.AdvertiserLogoUrl = (Convert.IsDBNull(reader["AdvertiserLogoUrl"]))?string.Empty:(System.String)reader["AdvertiserLogoUrl"];
					entity.SiteWorkTypeName = (reader.IsDBNull(((int)ViewJobsColumn.SiteWorkTypeName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteWorkTypeName)];
					//entity.SiteWorkTypeName = (Convert.IsDBNull(reader["SiteWorkTypeName"]))?string.Empty:(System.String)reader["SiteWorkTypeName"];
					entity.CurrencySymbol = (System.String)reader[((int)ViewJobsColumn.CurrencySymbol)];
					//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
					entity.SalaryUpperBand = (System.Decimal)reader[((int)ViewJobsColumn.SalaryUpperBand)];
					//entity.SalaryUpperBand = (Convert.IsDBNull(reader["SalaryUpperBand"]))?0.0m:(System.Decimal)reader["SalaryUpperBand"];
					entity.SalaryLowerBand = (System.Decimal)reader[((int)ViewJobsColumn.SalaryLowerBand)];
					//entity.SalaryLowerBand = (Convert.IsDBNull(reader["SalaryLowerBand"]))?0.0m:(System.Decimal)reader["SalaryLowerBand"];
					entity.SalaryTypeId = (System.Int32)reader[((int)ViewJobsColumn.SalaryTypeId)];
					//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeID"]))?(int)0:(System.Int32)reader["SalaryTypeID"];
					entity.JobTemplateHtml = (reader.IsDBNull(((int)ViewJobsColumn.JobTemplateHtml)))?null:(System.String)reader[((int)ViewJobsColumn.JobTemplateHtml)];
					//entity.JobTemplateHtml = (Convert.IsDBNull(reader["JobTemplateHTML"]))?string.Empty:(System.String)reader["JobTemplateHTML"];
					entity.SalaryTypeName = (reader.IsDBNull(((int)ViewJobsColumn.SalaryTypeName)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryTypeName)];
					//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
					entity.SiteAreaName = (reader.IsDBNull(((int)ViewJobsColumn.SiteAreaName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteAreaName)];
					//entity.SiteAreaName = (Convert.IsDBNull(reader["SiteAreaName"]))?string.Empty:(System.String)reader["SiteAreaName"];
					entity.SiteLocationName = (reader.IsDBNull(((int)ViewJobsColumn.SiteLocationName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteLocationName)];
					//entity.SiteLocationName = (Convert.IsDBNull(reader["SiteLocationName"]))?string.Empty:(System.String)reader["SiteLocationName"];
					entity.SiteRoleName = (reader.IsDBNull(((int)ViewJobsColumn.SiteRoleName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteRoleName)];
					//entity.SiteRoleName = (Convert.IsDBNull(reader["SiteRoleName"]))?string.Empty:(System.String)reader["SiteRoleName"];
					entity.SiteRoleCanonicalUrl = (reader.IsDBNull(((int)ViewJobsColumn.SiteRoleCanonicalUrl)))?null:(System.String)reader[((int)ViewJobsColumn.SiteRoleCanonicalUrl)];
					//entity.SiteRoleCanonicalUrl = (Convert.IsDBNull(reader["SiteRoleCanonicalUrl"]))?string.Empty:(System.String)reader["SiteRoleCanonicalUrl"];
					entity.SiteProfessionName = (reader.IsDBNull(((int)ViewJobsColumn.SiteProfessionName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteProfessionName)];
					//entity.SiteProfessionName = (Convert.IsDBNull(reader["SiteProfessionName"]))?string.Empty:(System.String)reader["SiteProfessionName"];
					entity.SiteProfessionCanonicalUrl = (reader.IsDBNull(((int)ViewJobsColumn.SiteProfessionCanonicalUrl)))?null:(System.String)reader[((int)ViewJobsColumn.SiteProfessionCanonicalUrl)];
					//entity.SiteProfessionCanonicalUrl = (Convert.IsDBNull(reader["SiteProfessionCanonicalUrl"]))?string.Empty:(System.String)reader["SiteProfessionCanonicalUrl"];
					entity.JobFriendlyName = (System.String)reader[((int)ViewJobsColumn.JobFriendlyName)];
					//entity.JobFriendlyName = (Convert.IsDBNull(reader["JobFriendlyName"]))?string.Empty:(System.String)reader["JobFriendlyName"];
					entity.ProfessionId = (System.Int32)reader[((int)ViewJobsColumn.ProfessionId)];
					//entity.ProfessionId = (Convert.IsDBNull(reader["ProfessionID"]))?(int)0:(System.Int32)reader["ProfessionID"];
					entity.RoleId = (System.Int32)reader[((int)ViewJobsColumn.RoleId)];
					//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32)reader["RoleID"];
					entity.LocationId = (System.Int32)reader[((int)ViewJobsColumn.LocationId)];
					//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
					entity.AreaId = (System.Int32)reader[((int)ViewJobsColumn.AreaId)];
					//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
					entity.SalaryDisplay = (reader.IsDBNull(((int)ViewJobsColumn.SalaryDisplay)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryDisplay)];
					//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
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
		/// Refreshes the <see cref="ViewJobs"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewJobs"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ViewJobs entity)
		{
			reader.Read();
			entity.JobId = (System.Int32)reader[((int)ViewJobsColumn.JobId)];
			//entity.JobId = (Convert.IsDBNull(reader["JobID"]))?(int)0:(System.Int32)reader["JobID"];
			entity.SiteId = (System.Int32)reader[((int)ViewJobsColumn.SiteId)];
			//entity.SiteId = (Convert.IsDBNull(reader["SiteID"]))?(int)0:(System.Int32)reader["SiteID"];
			entity.WorkTypeId = (System.Int32)reader[((int)ViewJobsColumn.WorkTypeId)];
			//entity.WorkTypeId = (Convert.IsDBNull(reader["WorkTypeID"]))?(int)0:(System.Int32)reader["WorkTypeID"];
			entity.JobName = (System.String)reader[((int)ViewJobsColumn.JobName)];
			//entity.JobName = (Convert.IsDBNull(reader["JobName"]))?string.Empty:(System.String)reader["JobName"];
			entity.Description = (System.String)reader[((int)ViewJobsColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.FullDescription = (System.String)reader[((int)ViewJobsColumn.FullDescription)];
			//entity.FullDescription = (Convert.IsDBNull(reader["FullDescription"]))?string.Empty:(System.String)reader["FullDescription"];
			entity.WebServiceProcessed = (System.Boolean)reader[((int)ViewJobsColumn.WebServiceProcessed)];
			//entity.WebServiceProcessed = (Convert.IsDBNull(reader["WebServiceProcessed"]))?false:(System.Boolean)reader["WebServiceProcessed"];
			entity.ApplicationEmailAddress = (System.String)reader[((int)ViewJobsColumn.ApplicationEmailAddress)];
			//entity.ApplicationEmailAddress = (Convert.IsDBNull(reader["ApplicationEmailAddress"]))?string.Empty:(System.String)reader["ApplicationEmailAddress"];
			entity.RefNo = (reader.IsDBNull(((int)ViewJobsColumn.RefNo)))?null:(System.String)reader[((int)ViewJobsColumn.RefNo)];
			//entity.RefNo = (Convert.IsDBNull(reader["RefNo"]))?string.Empty:(System.String)reader["RefNo"];
			entity.Visible = (System.Boolean)reader[((int)ViewJobsColumn.Visible)];
			//entity.Visible = (Convert.IsDBNull(reader["Visible"]))?false:(System.Boolean)reader["Visible"];
			entity.DatePosted = (System.DateTime)reader[((int)ViewJobsColumn.DatePosted)];
			//entity.DatePosted = (Convert.IsDBNull(reader["DatePosted"]))?DateTime.MinValue:(System.DateTime)reader["DatePosted"];
			entity.ExpiryDate = (System.DateTime)reader[((int)ViewJobsColumn.ExpiryDate)];
			//entity.ExpiryDate = (Convert.IsDBNull(reader["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)reader["ExpiryDate"];
			entity.Expired = (reader.IsDBNull(((int)ViewJobsColumn.Expired)))?null:(System.Int32?)reader[((int)ViewJobsColumn.Expired)];
			//entity.Expired = (Convert.IsDBNull(reader["Expired"]))?(int)0:(System.Int32?)reader["Expired"];
			entity.JobItemPrice = (reader.IsDBNull(((int)ViewJobsColumn.JobItemPrice)))?null:(System.Decimal?)reader[((int)ViewJobsColumn.JobItemPrice)];
			//entity.JobItemPrice = (Convert.IsDBNull(reader["JobItemPrice"]))?0:(System.Decimal?)reader["JobItemPrice"];
			entity.Billed = (System.Boolean)reader[((int)ViewJobsColumn.Billed)];
			//entity.Billed = (Convert.IsDBNull(reader["Billed"]))?false:(System.Boolean)reader["Billed"];
			entity.LastModified = (System.DateTime)reader[((int)ViewJobsColumn.LastModified)];
			//entity.LastModified = (Convert.IsDBNull(reader["LastModified"]))?DateTime.MinValue:(System.DateTime)reader["LastModified"];
			entity.ShowSalaryDetails = (System.Boolean)reader[((int)ViewJobsColumn.ShowSalaryDetails)];
			//entity.ShowSalaryDetails = (Convert.IsDBNull(reader["ShowSalaryDetails"]))?false:(System.Boolean)reader["ShowSalaryDetails"];
			entity.ShowSalaryRange = (System.Boolean)reader[((int)ViewJobsColumn.ShowSalaryRange)];
			//entity.ShowSalaryRange = (Convert.IsDBNull(reader["ShowSalaryRange"]))?false:(System.Boolean)reader["ShowSalaryRange"];
			entity.SalaryText = (reader.IsDBNull(((int)ViewJobsColumn.SalaryText)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryText)];
			//entity.SalaryText = (Convert.IsDBNull(reader["SalaryText"]))?string.Empty:(System.String)reader["SalaryText"];
			entity.AdvertiserId = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.AdvertiserId)];
			//entity.AdvertiserId = (Convert.IsDBNull(reader["AdvertiserID"]))?(int)0:(System.Int32?)reader["AdvertiserID"];
			entity.LastModifiedByAdvertiserUserId = (reader.IsDBNull(((int)ViewJobsColumn.LastModifiedByAdvertiserUserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.LastModifiedByAdvertiserUserId)];
			//entity.LastModifiedByAdvertiserUserId = (Convert.IsDBNull(reader["LastModifiedByAdvertiserUserId"]))?(int)0:(System.Int32?)reader["LastModifiedByAdvertiserUserId"];
			entity.LastModifiedByAdminUserId = (reader.IsDBNull(((int)ViewJobsColumn.LastModifiedByAdminUserId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.LastModifiedByAdminUserId)];
			//entity.LastModifiedByAdminUserId = (Convert.IsDBNull(reader["LastModifiedByAdminUserId"]))?(int)0:(System.Int32?)reader["LastModifiedByAdminUserId"];
			entity.JobItemTypeId = (reader.IsDBNull(((int)ViewJobsColumn.JobItemTypeId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.JobItemTypeId)];
			//entity.JobItemTypeId = (Convert.IsDBNull(reader["JobItemTypeID"]))?(int)0:(System.Int32?)reader["JobItemTypeID"];
			entity.ApplicationMethod = (reader.IsDBNull(((int)ViewJobsColumn.ApplicationMethod)))?null:(System.Int32?)reader[((int)ViewJobsColumn.ApplicationMethod)];
			//entity.ApplicationMethod = (Convert.IsDBNull(reader["ApplicationMethod"]))?(int)0:(System.Int32?)reader["ApplicationMethod"];
			entity.ApplicationUrl = (reader.IsDBNull(((int)ViewJobsColumn.ApplicationUrl)))?null:(System.String)reader[((int)ViewJobsColumn.ApplicationUrl)];
			//entity.ApplicationUrl = (Convert.IsDBNull(reader["ApplicationUrl"]))?string.Empty:(System.String)reader["ApplicationUrl"];
			entity.UploadMethod = (reader.IsDBNull(((int)ViewJobsColumn.UploadMethod)))?null:(System.Int32?)reader[((int)ViewJobsColumn.UploadMethod)];
			//entity.UploadMethod = (Convert.IsDBNull(reader["UploadMethod"]))?(int)0:(System.Int32?)reader["UploadMethod"];
			entity.Tags = (reader.IsDBNull(((int)ViewJobsColumn.Tags)))?null:(System.String)reader[((int)ViewJobsColumn.Tags)];
			//entity.Tags = (Convert.IsDBNull(reader["Tags"]))?string.Empty:(System.String)reader["Tags"];
			entity.JobTemplateId = (reader.IsDBNull(((int)ViewJobsColumn.JobTemplateId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.JobTemplateId)];
			//entity.JobTemplateId = (Convert.IsDBNull(reader["JobTemplateID"]))?(int)0:(System.Int32?)reader["JobTemplateID"];
			entity.SearchField = (reader.IsDBNull(((int)ViewJobsColumn.SearchField)))?null:(System.String)reader[((int)ViewJobsColumn.SearchField)];
			//entity.SearchField = (Convert.IsDBNull(reader["SearchField"]))?string.Empty:(System.String)reader["SearchField"];
			entity.AdvertiserJobTemplateLogoId = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserJobTemplateLogoId)))?null:(System.Int32?)reader[((int)ViewJobsColumn.AdvertiserJobTemplateLogoId)];
			//entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(reader["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)reader["AdvertiserJobTemplateLogoID"];
			entity.CompanyName = (reader.IsDBNull(((int)ViewJobsColumn.CompanyName)))?null:(System.String)reader[((int)ViewJobsColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.HashValue = (reader.IsDBNull(((int)ViewJobsColumn.HashValue)))?null:(System.Byte[])reader[((int)ViewJobsColumn.HashValue)];
			//entity.HashValue = (Convert.IsDBNull(reader["HashValue"]))?new byte[] {}:(System.Byte[])reader["HashValue"];
			entity.RequireLogonForExternalApplications = (System.Boolean)reader[((int)ViewJobsColumn.RequireLogonForExternalApplications)];
			//entity.RequireLogonForExternalApplications = (Convert.IsDBNull(reader["RequireLogonForExternalApplications"]))?false:(System.Boolean)reader["RequireLogonForExternalApplications"];
			entity.ShowLocationDetails = (reader.IsDBNull(((int)ViewJobsColumn.ShowLocationDetails)))?null:(System.Boolean?)reader[((int)ViewJobsColumn.ShowLocationDetails)];
			//entity.ShowLocationDetails = (Convert.IsDBNull(reader["ShowLocationDetails"]))?false:(System.Boolean?)reader["ShowLocationDetails"];
			entity.PublicTransport = (reader.IsDBNull(((int)ViewJobsColumn.PublicTransport)))?null:(System.String)reader[((int)ViewJobsColumn.PublicTransport)];
			//entity.PublicTransport = (Convert.IsDBNull(reader["PublicTransport"]))?string.Empty:(System.String)reader["PublicTransport"];
			entity.Address = (reader.IsDBNull(((int)ViewJobsColumn.Address)))?null:(System.String)reader[((int)ViewJobsColumn.Address)];
			//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
			entity.ContactDetails = (System.String)reader[((int)ViewJobsColumn.ContactDetails)];
			//entity.ContactDetails = (Convert.IsDBNull(reader["ContactDetails"]))?string.Empty:(System.String)reader["ContactDetails"];
			entity.JobContactPhone = (reader.IsDBNull(((int)ViewJobsColumn.JobContactPhone)))?null:(System.String)reader[((int)ViewJobsColumn.JobContactPhone)];
			//entity.JobContactPhone = (Convert.IsDBNull(reader["JobContactPhone"]))?string.Empty:(System.String)reader["JobContactPhone"];
			entity.JobContactName = (reader.IsDBNull(((int)ViewJobsColumn.JobContactName)))?null:(System.String)reader[((int)ViewJobsColumn.JobContactName)];
			//entity.JobContactName = (Convert.IsDBNull(reader["JobContactName"]))?string.Empty:(System.String)reader["JobContactName"];
			entity.QualificationsRecognised = (System.Boolean)reader[((int)ViewJobsColumn.QualificationsRecognised)];
			//entity.QualificationsRecognised = (Convert.IsDBNull(reader["QualificationsRecognised"]))?false:(System.Boolean)reader["QualificationsRecognised"];
			entity.ResidentOnly = (System.Boolean)reader[((int)ViewJobsColumn.ResidentOnly)];
			//entity.ResidentOnly = (Convert.IsDBNull(reader["ResidentOnly"]))?false:(System.Boolean)reader["ResidentOnly"];
			entity.DocumentLink = (reader.IsDBNull(((int)ViewJobsColumn.DocumentLink)))?null:(System.String)reader[((int)ViewJobsColumn.DocumentLink)];
			//entity.DocumentLink = (Convert.IsDBNull(reader["DocumentLink"]))?string.Empty:(System.String)reader["DocumentLink"];
			entity.BulletPoint1 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint1)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint1)];
			//entity.BulletPoint1 = (Convert.IsDBNull(reader["BulletPoint1"]))?string.Empty:(System.String)reader["BulletPoint1"];
			entity.BulletPoint2 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint2)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint2)];
			//entity.BulletPoint2 = (Convert.IsDBNull(reader["BulletPoint2"]))?string.Empty:(System.String)reader["BulletPoint2"];
			entity.BulletPoint3 = (reader.IsDBNull(((int)ViewJobsColumn.BulletPoint3)))?null:(System.String)reader[((int)ViewJobsColumn.BulletPoint3)];
			//entity.BulletPoint3 = (Convert.IsDBNull(reader["BulletPoint3"]))?string.Empty:(System.String)reader["BulletPoint3"];
			entity.HotJob = (System.Boolean)reader[((int)ViewJobsColumn.HotJob)];
			//entity.HotJob = (Convert.IsDBNull(reader["HotJob"]))?false:(System.Boolean)reader["HotJob"];
			entity.AdvertiserCompanyName = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserCompanyName)))?null:(System.String)reader[((int)ViewJobsColumn.AdvertiserCompanyName)];
			//entity.AdvertiserCompanyName = (Convert.IsDBNull(reader["AdvertiserCompanyName"]))?string.Empty:(System.String)reader["AdvertiserCompanyName"];
			entity.BusinessNumber = (reader.IsDBNull(((int)ViewJobsColumn.BusinessNumber)))?null:(System.String)reader[((int)ViewJobsColumn.BusinessNumber)];
			//entity.BusinessNumber = (Convert.IsDBNull(reader["BusinessNumber"]))?string.Empty:(System.String)reader["BusinessNumber"];
			entity.StreetAddress1 = (reader.IsDBNull(((int)ViewJobsColumn.StreetAddress1)))?null:(System.String)reader[((int)ViewJobsColumn.StreetAddress1)];
			//entity.StreetAddress1 = (Convert.IsDBNull(reader["StreetAddress1"]))?string.Empty:(System.String)reader["StreetAddress1"];
			entity.StreetAddress2 = (reader.IsDBNull(((int)ViewJobsColumn.StreetAddress2)))?null:(System.String)reader[((int)ViewJobsColumn.StreetAddress2)];
			//entity.StreetAddress2 = (Convert.IsDBNull(reader["StreetAddress2"]))?string.Empty:(System.String)reader["StreetAddress2"];
			entity.WebAddress = (reader.IsDBNull(((int)ViewJobsColumn.WebAddress)))?null:(System.String)reader[((int)ViewJobsColumn.WebAddress)];
			//entity.WebAddress = (Convert.IsDBNull(reader["WebAddress"]))?string.Empty:(System.String)reader["WebAddress"];
			entity.Profile = (reader.IsDBNull(((int)ViewJobsColumn.Profile)))?null:(System.String)reader[((int)ViewJobsColumn.Profile)];
			//entity.Profile = (Convert.IsDBNull(reader["Profile"]))?string.Empty:(System.String)reader["Profile"];
			entity.RequireLogonForExternalApplication = (System.Boolean)reader[((int)ViewJobsColumn.RequireLogonForExternalApplication)];
			//entity.RequireLogonForExternalApplication = (Convert.IsDBNull(reader["RequireLogonForExternalApplication"]))?false:(System.Boolean)reader["RequireLogonForExternalApplication"];
			entity.AdvertiserLogo = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserLogo)))?null:(System.Byte[])reader[((int)ViewJobsColumn.AdvertiserLogo)];
			//entity.AdvertiserLogo = (Convert.IsDBNull(reader["AdvertiserLogo"]))?new byte[] {}:(System.Byte[])reader["AdvertiserLogo"];
			entity.AdvertiserLogoUrl = (reader.IsDBNull(((int)ViewJobsColumn.AdvertiserLogoUrl)))?null:(System.String)reader[((int)ViewJobsColumn.AdvertiserLogoUrl)];
			//entity.AdvertiserLogoUrl = (Convert.IsDBNull(reader["AdvertiserLogoUrl"]))?string.Empty:(System.String)reader["AdvertiserLogoUrl"];
			entity.SiteWorkTypeName = (reader.IsDBNull(((int)ViewJobsColumn.SiteWorkTypeName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteWorkTypeName)];
			//entity.SiteWorkTypeName = (Convert.IsDBNull(reader["SiteWorkTypeName"]))?string.Empty:(System.String)reader["SiteWorkTypeName"];
			entity.CurrencySymbol = (System.String)reader[((int)ViewJobsColumn.CurrencySymbol)];
			//entity.CurrencySymbol = (Convert.IsDBNull(reader["CurrencySymbol"]))?string.Empty:(System.String)reader["CurrencySymbol"];
			entity.SalaryUpperBand = (System.Decimal)reader[((int)ViewJobsColumn.SalaryUpperBand)];
			//entity.SalaryUpperBand = (Convert.IsDBNull(reader["SalaryUpperBand"]))?0.0m:(System.Decimal)reader["SalaryUpperBand"];
			entity.SalaryLowerBand = (System.Decimal)reader[((int)ViewJobsColumn.SalaryLowerBand)];
			//entity.SalaryLowerBand = (Convert.IsDBNull(reader["SalaryLowerBand"]))?0.0m:(System.Decimal)reader["SalaryLowerBand"];
			entity.SalaryTypeId = (System.Int32)reader[((int)ViewJobsColumn.SalaryTypeId)];
			//entity.SalaryTypeId = (Convert.IsDBNull(reader["SalaryTypeID"]))?(int)0:(System.Int32)reader["SalaryTypeID"];
			entity.JobTemplateHtml = (reader.IsDBNull(((int)ViewJobsColumn.JobTemplateHtml)))?null:(System.String)reader[((int)ViewJobsColumn.JobTemplateHtml)];
			//entity.JobTemplateHtml = (Convert.IsDBNull(reader["JobTemplateHTML"]))?string.Empty:(System.String)reader["JobTemplateHTML"];
			entity.SalaryTypeName = (reader.IsDBNull(((int)ViewJobsColumn.SalaryTypeName)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryTypeName)];
			//entity.SalaryTypeName = (Convert.IsDBNull(reader["SalaryTypeName"]))?string.Empty:(System.String)reader["SalaryTypeName"];
			entity.SiteAreaName = (reader.IsDBNull(((int)ViewJobsColumn.SiteAreaName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteAreaName)];
			//entity.SiteAreaName = (Convert.IsDBNull(reader["SiteAreaName"]))?string.Empty:(System.String)reader["SiteAreaName"];
			entity.SiteLocationName = (reader.IsDBNull(((int)ViewJobsColumn.SiteLocationName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteLocationName)];
			//entity.SiteLocationName = (Convert.IsDBNull(reader["SiteLocationName"]))?string.Empty:(System.String)reader["SiteLocationName"];
			entity.SiteRoleName = (reader.IsDBNull(((int)ViewJobsColumn.SiteRoleName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteRoleName)];
			//entity.SiteRoleName = (Convert.IsDBNull(reader["SiteRoleName"]))?string.Empty:(System.String)reader["SiteRoleName"];
			entity.SiteRoleCanonicalUrl = (reader.IsDBNull(((int)ViewJobsColumn.SiteRoleCanonicalUrl)))?null:(System.String)reader[((int)ViewJobsColumn.SiteRoleCanonicalUrl)];
			//entity.SiteRoleCanonicalUrl = (Convert.IsDBNull(reader["SiteRoleCanonicalUrl"]))?string.Empty:(System.String)reader["SiteRoleCanonicalUrl"];
			entity.SiteProfessionName = (reader.IsDBNull(((int)ViewJobsColumn.SiteProfessionName)))?null:(System.String)reader[((int)ViewJobsColumn.SiteProfessionName)];
			//entity.SiteProfessionName = (Convert.IsDBNull(reader["SiteProfessionName"]))?string.Empty:(System.String)reader["SiteProfessionName"];
			entity.SiteProfessionCanonicalUrl = (reader.IsDBNull(((int)ViewJobsColumn.SiteProfessionCanonicalUrl)))?null:(System.String)reader[((int)ViewJobsColumn.SiteProfessionCanonicalUrl)];
			//entity.SiteProfessionCanonicalUrl = (Convert.IsDBNull(reader["SiteProfessionCanonicalUrl"]))?string.Empty:(System.String)reader["SiteProfessionCanonicalUrl"];
			entity.JobFriendlyName = (System.String)reader[((int)ViewJobsColumn.JobFriendlyName)];
			//entity.JobFriendlyName = (Convert.IsDBNull(reader["JobFriendlyName"]))?string.Empty:(System.String)reader["JobFriendlyName"];
			entity.ProfessionId = (System.Int32)reader[((int)ViewJobsColumn.ProfessionId)];
			//entity.ProfessionId = (Convert.IsDBNull(reader["ProfessionID"]))?(int)0:(System.Int32)reader["ProfessionID"];
			entity.RoleId = (System.Int32)reader[((int)ViewJobsColumn.RoleId)];
			//entity.RoleId = (Convert.IsDBNull(reader["RoleID"]))?(int)0:(System.Int32)reader["RoleID"];
			entity.LocationId = (System.Int32)reader[((int)ViewJobsColumn.LocationId)];
			//entity.LocationId = (Convert.IsDBNull(reader["LocationID"]))?(int)0:(System.Int32)reader["LocationID"];
			entity.AreaId = (System.Int32)reader[((int)ViewJobsColumn.AreaId)];
			//entity.AreaId = (Convert.IsDBNull(reader["AreaID"]))?(int)0:(System.Int32)reader["AreaID"];
			entity.SalaryDisplay = (reader.IsDBNull(((int)ViewJobsColumn.SalaryDisplay)))?null:(System.String)reader[((int)ViewJobsColumn.SalaryDisplay)];
			//entity.SalaryDisplay = (Convert.IsDBNull(reader["SalaryDisplay"]))?string.Empty:(System.String)reader["SalaryDisplay"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ViewJobs"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ViewJobs"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ViewJobs entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobId = (Convert.IsDBNull(dataRow["JobID"]))?(int)0:(System.Int32)dataRow["JobID"];
			entity.SiteId = (Convert.IsDBNull(dataRow["SiteID"]))?(int)0:(System.Int32)dataRow["SiteID"];
			entity.WorkTypeId = (Convert.IsDBNull(dataRow["WorkTypeID"]))?(int)0:(System.Int32)dataRow["WorkTypeID"];
			entity.JobName = (Convert.IsDBNull(dataRow["JobName"]))?string.Empty:(System.String)dataRow["JobName"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.FullDescription = (Convert.IsDBNull(dataRow["FullDescription"]))?string.Empty:(System.String)dataRow["FullDescription"];
			entity.WebServiceProcessed = (Convert.IsDBNull(dataRow["WebServiceProcessed"]))?false:(System.Boolean)dataRow["WebServiceProcessed"];
			entity.ApplicationEmailAddress = (Convert.IsDBNull(dataRow["ApplicationEmailAddress"]))?string.Empty:(System.String)dataRow["ApplicationEmailAddress"];
			entity.RefNo = (Convert.IsDBNull(dataRow["RefNo"]))?string.Empty:(System.String)dataRow["RefNo"];
			entity.Visible = (Convert.IsDBNull(dataRow["Visible"]))?false:(System.Boolean)dataRow["Visible"];
			entity.DatePosted = (Convert.IsDBNull(dataRow["DatePosted"]))?DateTime.MinValue:(System.DateTime)dataRow["DatePosted"];
			entity.ExpiryDate = (Convert.IsDBNull(dataRow["ExpiryDate"]))?DateTime.MinValue:(System.DateTime)dataRow["ExpiryDate"];
			entity.Expired = (Convert.IsDBNull(dataRow["Expired"]))?(int)0:(System.Int32?)dataRow["Expired"];
			entity.JobItemPrice = (Convert.IsDBNull(dataRow["JobItemPrice"]))?0:(System.Decimal?)dataRow["JobItemPrice"];
			entity.Billed = (Convert.IsDBNull(dataRow["Billed"]))?false:(System.Boolean)dataRow["Billed"];
			entity.LastModified = (Convert.IsDBNull(dataRow["LastModified"]))?DateTime.MinValue:(System.DateTime)dataRow["LastModified"];
			entity.ShowSalaryDetails = (Convert.IsDBNull(dataRow["ShowSalaryDetails"]))?false:(System.Boolean)dataRow["ShowSalaryDetails"];
			entity.ShowSalaryRange = (Convert.IsDBNull(dataRow["ShowSalaryRange"]))?false:(System.Boolean)dataRow["ShowSalaryRange"];
			entity.SalaryText = (Convert.IsDBNull(dataRow["SalaryText"]))?string.Empty:(System.String)dataRow["SalaryText"];
			entity.AdvertiserId = (Convert.IsDBNull(dataRow["AdvertiserID"]))?(int)0:(System.Int32?)dataRow["AdvertiserID"];
			entity.LastModifiedByAdvertiserUserId = (Convert.IsDBNull(dataRow["LastModifiedByAdvertiserUserId"]))?(int)0:(System.Int32?)dataRow["LastModifiedByAdvertiserUserId"];
			entity.LastModifiedByAdminUserId = (Convert.IsDBNull(dataRow["LastModifiedByAdminUserId"]))?(int)0:(System.Int32?)dataRow["LastModifiedByAdminUserId"];
			entity.JobItemTypeId = (Convert.IsDBNull(dataRow["JobItemTypeID"]))?(int)0:(System.Int32?)dataRow["JobItemTypeID"];
			entity.ApplicationMethod = (Convert.IsDBNull(dataRow["ApplicationMethod"]))?(int)0:(System.Int32?)dataRow["ApplicationMethod"];
			entity.ApplicationUrl = (Convert.IsDBNull(dataRow["ApplicationUrl"]))?string.Empty:(System.String)dataRow["ApplicationUrl"];
			entity.UploadMethod = (Convert.IsDBNull(dataRow["UploadMethod"]))?(int)0:(System.Int32?)dataRow["UploadMethod"];
			entity.Tags = (Convert.IsDBNull(dataRow["Tags"]))?string.Empty:(System.String)dataRow["Tags"];
			entity.JobTemplateId = (Convert.IsDBNull(dataRow["JobTemplateID"]))?(int)0:(System.Int32?)dataRow["JobTemplateID"];
			entity.SearchField = (Convert.IsDBNull(dataRow["SearchField"]))?string.Empty:(System.String)dataRow["SearchField"];
			entity.AdvertiserJobTemplateLogoId = (Convert.IsDBNull(dataRow["AdvertiserJobTemplateLogoID"]))?(int)0:(System.Int32?)dataRow["AdvertiserJobTemplateLogoID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.HashValue = (Convert.IsDBNull(dataRow["HashValue"]))?new byte[] {}:(System.Byte[])dataRow["HashValue"];
			entity.RequireLogonForExternalApplications = (Convert.IsDBNull(dataRow["RequireLogonForExternalApplications"]))?false:(System.Boolean)dataRow["RequireLogonForExternalApplications"];
			entity.ShowLocationDetails = (Convert.IsDBNull(dataRow["ShowLocationDetails"]))?false:(System.Boolean?)dataRow["ShowLocationDetails"];
			entity.PublicTransport = (Convert.IsDBNull(dataRow["PublicTransport"]))?string.Empty:(System.String)dataRow["PublicTransport"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?string.Empty:(System.String)dataRow["Address"];
			entity.ContactDetails = (Convert.IsDBNull(dataRow["ContactDetails"]))?string.Empty:(System.String)dataRow["ContactDetails"];
			entity.JobContactPhone = (Convert.IsDBNull(dataRow["JobContactPhone"]))?string.Empty:(System.String)dataRow["JobContactPhone"];
			entity.JobContactName = (Convert.IsDBNull(dataRow["JobContactName"]))?string.Empty:(System.String)dataRow["JobContactName"];
			entity.QualificationsRecognised = (Convert.IsDBNull(dataRow["QualificationsRecognised"]))?false:(System.Boolean)dataRow["QualificationsRecognised"];
			entity.ResidentOnly = (Convert.IsDBNull(dataRow["ResidentOnly"]))?false:(System.Boolean)dataRow["ResidentOnly"];
			entity.DocumentLink = (Convert.IsDBNull(dataRow["DocumentLink"]))?string.Empty:(System.String)dataRow["DocumentLink"];
			entity.BulletPoint1 = (Convert.IsDBNull(dataRow["BulletPoint1"]))?string.Empty:(System.String)dataRow["BulletPoint1"];
			entity.BulletPoint2 = (Convert.IsDBNull(dataRow["BulletPoint2"]))?string.Empty:(System.String)dataRow["BulletPoint2"];
			entity.BulletPoint3 = (Convert.IsDBNull(dataRow["BulletPoint3"]))?string.Empty:(System.String)dataRow["BulletPoint3"];
			entity.HotJob = (Convert.IsDBNull(dataRow["HotJob"]))?false:(System.Boolean)dataRow["HotJob"];
			entity.AdvertiserCompanyName = (Convert.IsDBNull(dataRow["AdvertiserCompanyName"]))?string.Empty:(System.String)dataRow["AdvertiserCompanyName"];
			entity.BusinessNumber = (Convert.IsDBNull(dataRow["BusinessNumber"]))?string.Empty:(System.String)dataRow["BusinessNumber"];
			entity.StreetAddress1 = (Convert.IsDBNull(dataRow["StreetAddress1"]))?string.Empty:(System.String)dataRow["StreetAddress1"];
			entity.StreetAddress2 = (Convert.IsDBNull(dataRow["StreetAddress2"]))?string.Empty:(System.String)dataRow["StreetAddress2"];
			entity.WebAddress = (Convert.IsDBNull(dataRow["WebAddress"]))?string.Empty:(System.String)dataRow["WebAddress"];
			entity.Profile = (Convert.IsDBNull(dataRow["Profile"]))?string.Empty:(System.String)dataRow["Profile"];
			entity.RequireLogonForExternalApplication = (Convert.IsDBNull(dataRow["RequireLogonForExternalApplication"]))?false:(System.Boolean)dataRow["RequireLogonForExternalApplication"];
			entity.AdvertiserLogo = (Convert.IsDBNull(dataRow["AdvertiserLogo"]))?new byte[] {}:(System.Byte[])dataRow["AdvertiserLogo"];
			entity.AdvertiserLogoUrl = (Convert.IsDBNull(dataRow["AdvertiserLogoUrl"]))?string.Empty:(System.String)dataRow["AdvertiserLogoUrl"];
			entity.SiteWorkTypeName = (Convert.IsDBNull(dataRow["SiteWorkTypeName"]))?string.Empty:(System.String)dataRow["SiteWorkTypeName"];
			entity.CurrencySymbol = (Convert.IsDBNull(dataRow["CurrencySymbol"]))?string.Empty:(System.String)dataRow["CurrencySymbol"];
			entity.SalaryUpperBand = (Convert.IsDBNull(dataRow["SalaryUpperBand"]))?0.0m:(System.Decimal)dataRow["SalaryUpperBand"];
			entity.SalaryLowerBand = (Convert.IsDBNull(dataRow["SalaryLowerBand"]))?0.0m:(System.Decimal)dataRow["SalaryLowerBand"];
			entity.SalaryTypeId = (Convert.IsDBNull(dataRow["SalaryTypeID"]))?(int)0:(System.Int32)dataRow["SalaryTypeID"];
			entity.JobTemplateHtml = (Convert.IsDBNull(dataRow["JobTemplateHTML"]))?string.Empty:(System.String)dataRow["JobTemplateHTML"];
			entity.SalaryTypeName = (Convert.IsDBNull(dataRow["SalaryTypeName"]))?string.Empty:(System.String)dataRow["SalaryTypeName"];
			entity.SiteAreaName = (Convert.IsDBNull(dataRow["SiteAreaName"]))?string.Empty:(System.String)dataRow["SiteAreaName"];
			entity.SiteLocationName = (Convert.IsDBNull(dataRow["SiteLocationName"]))?string.Empty:(System.String)dataRow["SiteLocationName"];
			entity.SiteRoleName = (Convert.IsDBNull(dataRow["SiteRoleName"]))?string.Empty:(System.String)dataRow["SiteRoleName"];
			entity.SiteRoleCanonicalUrl = (Convert.IsDBNull(dataRow["SiteRoleCanonicalUrl"]))?string.Empty:(System.String)dataRow["SiteRoleCanonicalUrl"];
			entity.SiteProfessionName = (Convert.IsDBNull(dataRow["SiteProfessionName"]))?string.Empty:(System.String)dataRow["SiteProfessionName"];
			entity.SiteProfessionCanonicalUrl = (Convert.IsDBNull(dataRow["SiteProfessionCanonicalUrl"]))?string.Empty:(System.String)dataRow["SiteProfessionCanonicalUrl"];
			entity.JobFriendlyName = (Convert.IsDBNull(dataRow["JobFriendlyName"]))?string.Empty:(System.String)dataRow["JobFriendlyName"];
			entity.ProfessionId = (Convert.IsDBNull(dataRow["ProfessionID"]))?(int)0:(System.Int32)dataRow["ProfessionID"];
			entity.RoleId = (Convert.IsDBNull(dataRow["RoleID"]))?(int)0:(System.Int32)dataRow["RoleID"];
			entity.LocationId = (Convert.IsDBNull(dataRow["LocationID"]))?(int)0:(System.Int32)dataRow["LocationID"];
			entity.AreaId = (Convert.IsDBNull(dataRow["AreaID"]))?(int)0:(System.Int32)dataRow["AreaID"];
			entity.SalaryDisplay = (Convert.IsDBNull(dataRow["SalaryDisplay"]))?string.Empty:(System.String)dataRow["SalaryDisplay"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ViewJobsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsFilterBuilder : SqlFilterBuilder<ViewJobsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilterBuilder class.
		/// </summary>
		public ViewJobsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsFilterBuilder

	#region ViewJobsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsParameterBuilder : ParameterizedSqlFilterBuilder<ViewJobsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsParameterBuilder class.
		/// </summary>
		public ViewJobsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsParameterBuilder
	
	#region ViewJobsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ViewJobsSortBuilder : SqlSortBuilder<ViewJobsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsSqlSortBuilder class.
		/// </summary>
		public ViewJobsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ViewJobsSortBuilder

} // end namespace
