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
	/// This class is the base class for any <see cref="WebServiceLogProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WebServiceLogProviderBaseCore : EntityProviderBase<JXTPortal.Entities.WebServiceLog, JXTPortal.Entities.WebServiceLogKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.WebServiceLogKey key)
		{
			return Delete(transactionManager, key.WebServiceLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_webServiceLogId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _webServiceLogId)
		{
			return Delete(null, _webServiceLogId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_webServiceLogId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _webServiceLogId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		FK__WebServic__SiteI__68AD1FA9 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		public TList<WebServiceLog> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		FK__WebServic__SiteI__68AD1FA9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		/// <remarks></remarks>
		public TList<WebServiceLog> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		FK__WebServic__SiteI__68AD1FA9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		public TList<WebServiceLog> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		fkWebServicSitei68Ad1Fa9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		public TList<WebServiceLog> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		fkWebServicSitei68Ad1Fa9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		public TList<WebServiceLog> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WebServic__SiteI__68AD1FA9 key.
		///		FK__WebServic__SiteI__68AD1FA9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WebServiceLog objects.</returns>
		public abstract TList<WebServiceLog> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.WebServiceLog Get(TransactionManager transactionManager, JXTPortal.Entities.WebServiceLogKey key, int start, int pageLength)
		{
			return GetByWebServiceLogId(transactionManager, key.WebServiceLogId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="_webServiceLogId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(System.Int32 _webServiceLogId)
		{
			int count = -1;
			return GetByWebServiceLogId(null,_webServiceLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="_webServiceLogId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(System.Int32 _webServiceLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByWebServiceLogId(null, _webServiceLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_webServiceLogId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(TransactionManager transactionManager, System.Int32 _webServiceLogId)
		{
			int count = -1;
			return GetByWebServiceLogId(transactionManager, _webServiceLogId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_webServiceLogId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(TransactionManager transactionManager, System.Int32 _webServiceLogId, int start, int pageLength)
		{
			int count = -1;
			return GetByWebServiceLogId(transactionManager, _webServiceLogId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="_webServiceLogId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(System.Int32 _webServiceLogId, int start, int pageLength, out int count)
		{
			return GetByWebServiceLogId(null, _webServiceLogId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WebServi__129E5DA9486A6D49 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_webServiceLogId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WebServiceLog"/> class.</returns>
		public abstract JXTPortal.Entities.WebServiceLog GetByWebServiceLogId(TransactionManager transactionManager, System.Int32 _webServiceLogId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region WebServiceLog_Insert 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Insert' stored procedure. 
		/// </summary>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted, ref System.Int32? webServiceLogId)
		{
			 Insert(null, 0, int.MaxValue , clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Insert' stored procedure. 
		/// </summary>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted, ref System.Int32? webServiceLogId)
		{
			 Insert(null, start, pageLength , clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted, ref webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_Insert' stored procedure. 
		/// </summary>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted, ref System.Int32? webServiceLogId)
		{
			 Insert(transactionManager, 0, int.MaxValue , clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted, ref webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Insert' stored procedure. 
		/// </summary>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
			/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted, ref System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_Find 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			return Find(null, start, pageLength , searchUsingOr, webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted);
		
		#endregion
		
		#region WebServiceLog_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region WebServiceLog_Get_List 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region WebServiceLog_CustomGetInputXML 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInputXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInputXML(System.Int32? webServiceLogId)
		{
			return CustomGetInputXML(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInputXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInputXML(int start, int pageLength, System.Int32? webServiceLogId)
		{
			return CustomGetInputXML(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInputXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInputXML(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			return CustomGetInputXML(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInputXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetInputXML(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_CustomGetExportList 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetExportList' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExportList(System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetExportList(null, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetExportList' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExportList(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetExportList(null, start, pageLength , siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetExportList' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetExportList(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId)
		{
			return CustomGetExportList(transactionManager, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetExportList' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetExportList(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#region WebServiceLog_CustomGetWebServiceLogPaged 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showFailedOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetWebServiceLogPaged(System.Int32? siteId, System.Int32? advertiserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? showFailedOnly, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetWebServiceLogPaged(null, 0, int.MaxValue , siteId, advertiserId, dateFrom, dateTo, showFailedOnly, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showFailedOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetWebServiceLogPaged(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? showFailedOnly, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetWebServiceLogPaged(null, start, pageLength , siteId, advertiserId, dateFrom, dateTo, showFailedOnly, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showFailedOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetWebServiceLogPaged(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? showFailedOnly, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return CustomGetWebServiceLogPaged(transactionManager, 0, int.MaxValue , siteId, advertiserId, dateFrom, dateTo, showFailedOnly, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogPaged' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="showFailedOnly"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetWebServiceLogPaged(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? showFailedOnly, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region WebServiceLog_CustomGetWebServiceLogByID 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogByID' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WebServiceLog&gt;"/> instance.</returns>
		public TList<WebServiceLog> CustomGetWebServiceLogByID(System.Int32? webServiceLogId)
		{
			return CustomGetWebServiceLogByID(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogByID' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WebServiceLog&gt;"/> instance.</returns>
		public TList<WebServiceLog> CustomGetWebServiceLogByID(int start, int pageLength, System.Int32? webServiceLogId)
		{
			return CustomGetWebServiceLogByID(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogByID' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WebServiceLog&gt;"/> instance.</returns>
		public TList<WebServiceLog> CustomGetWebServiceLogByID(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			return CustomGetWebServiceLogByID(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetWebServiceLogByID' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WebServiceLog&gt;"/> instance.</returns>
		public abstract TList<WebServiceLog> CustomGetWebServiceLogByID(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_CustomGetOutputResponse 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetOutputResponse' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetOutputResponse(System.Int32? webServiceLogId)
		{
			return CustomGetOutputResponse(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetOutputResponse' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetOutputResponse(int start, int pageLength, System.Int32? webServiceLogId)
		{
			return CustomGetOutputResponse(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetOutputResponse' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetOutputResponse(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			return CustomGetOutputResponse(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetOutputResponse' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetOutputResponse(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_CustomGetInvalidXML 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInvalidXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInvalidXML(System.Int32? webServiceLogId)
		{
			return CustomGetInvalidXML(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInvalidXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInvalidXML(int start, int pageLength, System.Int32? webServiceLogId)
		{
			return CustomGetInvalidXML(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInvalidXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetInvalidXML(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			return CustomGetInvalidXML(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_CustomGetInvalidXML' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetInvalidXML(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_GetPaged 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region WebServiceLog_Update 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Update' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			 Update(null, 0, int.MaxValue , webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Update' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			 Update(null, start, pageLength , webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_Update' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted)
		{
			 Update(transactionManager, 0, int.MaxValue , webServiceLogId, clientIpAddress, advertiserId, advertiserUserId, createdDate, methodInvoked, inputXml, outputResponse, invalidXml, totalSent, totalUpdated, totalArchived, totalFailed, siteId, finishedDate, totalInserted);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Update' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="clientIpAddress"> A <c>System.String</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserUserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="methodInvoked"> A <c>System.String</c> instance.</param>
		/// <param name="inputXml"> A <c>string</c> instance.</param>
		/// <param name="outputResponse"> A <c>string</c> instance.</param>
		/// <param name="invalidXml"> A <c>System.String</c> instance.</param>
		/// <param name="totalSent"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalUpdated"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalArchived"> A <c>System.Int32?</c> instance.</param>
		/// <param name="totalFailed"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="finishedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalInserted"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId, System.String clientIpAddress, System.Int32? advertiserId, System.Int32? advertiserUserId, System.DateTime? createdDate, System.String methodInvoked, string inputXml, string outputResponse, System.String invalidXml, System.Int32? totalSent, System.Int32? totalUpdated, System.Int32? totalArchived, System.Int32? totalFailed, System.Int32? siteId, System.DateTime? finishedDate, System.Int32? totalInserted);
		
		#endregion
		
		#region WebServiceLog_GetByWebServiceLogId 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetByWebServiceLogId' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWebServiceLogId(System.Int32? webServiceLogId)
		{
			return GetByWebServiceLogId(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetByWebServiceLogId' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWebServiceLogId(int start, int pageLength, System.Int32? webServiceLogId)
		{
			return GetByWebServiceLogId(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetByWebServiceLogId' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByWebServiceLogId(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			return GetByWebServiceLogId(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_GetByWebServiceLogId' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByWebServiceLogId(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#region WebServiceLog_Delete 
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Delete' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? webServiceLogId)
		{
			 Delete(null, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Delete' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? webServiceLogId)
		{
			 Delete(null, start, pageLength , webServiceLogId);
		}
				
		/// <summary>
		///	This method wrap the 'WebServiceLog_Delete' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? webServiceLogId)
		{
			 Delete(transactionManager, 0, int.MaxValue , webServiceLogId);
		}
		
		/// <summary>
		///	This method wrap the 'WebServiceLog_Delete' stored procedure. 
		/// </summary>
		/// <param name="webServiceLogId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? webServiceLogId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WebServiceLog&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WebServiceLog&gt;"/></returns>
		public static TList<WebServiceLog> Fill(IDataReader reader, TList<WebServiceLog> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.WebServiceLog c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WebServiceLog")
					.Append("|").Append((System.Int32)reader[((int)WebServiceLogColumn.WebServiceLogId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WebServiceLog>(
					key.ToString(), // EntityTrackingKey
					"WebServiceLog",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.WebServiceLog();
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
					c.WebServiceLogId = (System.Int32)reader[((int)WebServiceLogColumn.WebServiceLogId - 1)];
					c.ClientIpAddress = (reader.IsDBNull(((int)WebServiceLogColumn.ClientIpAddress - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.ClientIpAddress - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)WebServiceLogColumn.AdvertiserId - 1)];
					c.AdvertiserUserId = (reader.IsDBNull(((int)WebServiceLogColumn.AdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.AdvertiserUserId - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)WebServiceLogColumn.CreatedDate - 1)];
					c.MethodInvoked = (reader.IsDBNull(((int)WebServiceLogColumn.MethodInvoked - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.MethodInvoked - 1)];
					c.InputXml = (reader.IsDBNull(((int)WebServiceLogColumn.InputXml - 1)))?null:(string)reader[((int)WebServiceLogColumn.InputXml - 1)];
					c.OutputResponse = (reader.IsDBNull(((int)WebServiceLogColumn.OutputResponse - 1)))?null:(string)reader[((int)WebServiceLogColumn.OutputResponse - 1)];
					c.InvalidXml = (reader.IsDBNull(((int)WebServiceLogColumn.InvalidXml - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.InvalidXml - 1)];
					c.TotalSent = (reader.IsDBNull(((int)WebServiceLogColumn.TotalSent - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalSent - 1)];
					c.TotalUpdated = (reader.IsDBNull(((int)WebServiceLogColumn.TotalUpdated - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalUpdated - 1)];
					c.TotalArchived = (reader.IsDBNull(((int)WebServiceLogColumn.TotalArchived - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalArchived - 1)];
					c.TotalFailed = (reader.IsDBNull(((int)WebServiceLogColumn.TotalFailed - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalFailed - 1)];
					c.SiteId = (System.Int32)reader[((int)WebServiceLogColumn.SiteId - 1)];
					c.FinishedDate = (reader.IsDBNull(((int)WebServiceLogColumn.FinishedDate - 1)))?null:(System.DateTime?)reader[((int)WebServiceLogColumn.FinishedDate - 1)];
					c.TotalInserted = (System.Int32)reader[((int)WebServiceLogColumn.TotalInserted - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WebServiceLog"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WebServiceLog"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.WebServiceLog entity)
		{
			if (!reader.Read()) return;
			
			entity.WebServiceLogId = (System.Int32)reader[((int)WebServiceLogColumn.WebServiceLogId - 1)];
			entity.ClientIpAddress = (reader.IsDBNull(((int)WebServiceLogColumn.ClientIpAddress - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.ClientIpAddress - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)WebServiceLogColumn.AdvertiserId - 1)];
			entity.AdvertiserUserId = (reader.IsDBNull(((int)WebServiceLogColumn.AdvertiserUserId - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.AdvertiserUserId - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)WebServiceLogColumn.CreatedDate - 1)];
			entity.MethodInvoked = (reader.IsDBNull(((int)WebServiceLogColumn.MethodInvoked - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.MethodInvoked - 1)];
			entity.InputXml = (reader.IsDBNull(((int)WebServiceLogColumn.InputXml - 1)))?null:(string)reader[((int)WebServiceLogColumn.InputXml - 1)];
			entity.OutputResponse = (reader.IsDBNull(((int)WebServiceLogColumn.OutputResponse - 1)))?null:(string)reader[((int)WebServiceLogColumn.OutputResponse - 1)];
			entity.InvalidXml = (reader.IsDBNull(((int)WebServiceLogColumn.InvalidXml - 1)))?null:(System.String)reader[((int)WebServiceLogColumn.InvalidXml - 1)];
			entity.TotalSent = (reader.IsDBNull(((int)WebServiceLogColumn.TotalSent - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalSent - 1)];
			entity.TotalUpdated = (reader.IsDBNull(((int)WebServiceLogColumn.TotalUpdated - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalUpdated - 1)];
			entity.TotalArchived = (reader.IsDBNull(((int)WebServiceLogColumn.TotalArchived - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalArchived - 1)];
			entity.TotalFailed = (reader.IsDBNull(((int)WebServiceLogColumn.TotalFailed - 1)))?null:(System.Int32?)reader[((int)WebServiceLogColumn.TotalFailed - 1)];
			entity.SiteId = (System.Int32)reader[((int)WebServiceLogColumn.SiteId - 1)];
			entity.FinishedDate = (reader.IsDBNull(((int)WebServiceLogColumn.FinishedDate - 1)))?null:(System.DateTime?)reader[((int)WebServiceLogColumn.FinishedDate - 1)];
			entity.TotalInserted = (System.Int32)reader[((int)WebServiceLogColumn.TotalInserted - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WebServiceLog"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WebServiceLog"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.WebServiceLog entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WebServiceLogId = (System.Int32)dataRow["WebServiceLogId"];
			entity.ClientIpAddress = Convert.IsDBNull(dataRow["ClientIPAddress"]) ? null : (System.String)dataRow["ClientIPAddress"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserId"];
			entity.AdvertiserUserId = Convert.IsDBNull(dataRow["AdvertiserUserID"]) ? null : (System.Int32?)dataRow["AdvertiserUserID"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.MethodInvoked = Convert.IsDBNull(dataRow["MethodInvoked"]) ? null : (System.String)dataRow["MethodInvoked"];
			entity.InputXml = Convert.IsDBNull(dataRow["InputXML"]) ? null : (string)dataRow["InputXML"];
			entity.OutputResponse = Convert.IsDBNull(dataRow["OutputResponse"]) ? null : (string)dataRow["OutputResponse"];
			entity.InvalidXml = Convert.IsDBNull(dataRow["InvalidXML"]) ? null : (System.String)dataRow["InvalidXML"];
			entity.TotalSent = Convert.IsDBNull(dataRow["TotalSent"]) ? null : (System.Int32?)dataRow["TotalSent"];
			entity.TotalUpdated = Convert.IsDBNull(dataRow["TotalUpdated"]) ? null : (System.Int32?)dataRow["TotalUpdated"];
			entity.TotalArchived = Convert.IsDBNull(dataRow["TotalArchived"]) ? null : (System.Int32?)dataRow["TotalArchived"];
			entity.TotalFailed = Convert.IsDBNull(dataRow["TotalFailed"]) ? null : (System.Int32?)dataRow["TotalFailed"];
			entity.SiteId = (System.Int32)dataRow["SiteId"];
			entity.FinishedDate = Convert.IsDBNull(dataRow["FinishedDate"]) ? null : (System.DateTime?)dataRow["FinishedDate"];
			entity.TotalInserted = (System.Int32)dataRow["TotalInserted"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.WebServiceLog"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.WebServiceLog Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.WebServiceLog entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.WebServiceLog object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.WebServiceLog instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.WebServiceLog Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.WebServiceLog entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region WebServiceLogChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.WebServiceLog</c>
	///</summary>
	public enum WebServiceLogChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion WebServiceLogChildEntityTypes
	
	#region WebServiceLogFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WebServiceLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogFilterBuilder : SqlFilterBuilder<WebServiceLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilterBuilder class.
		/// </summary>
		public WebServiceLogFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WebServiceLogFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WebServiceLogFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WebServiceLogFilterBuilder
	
	#region WebServiceLogParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WebServiceLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogParameterBuilder : ParameterizedSqlFilterBuilder<WebServiceLogColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogParameterBuilder class.
		/// </summary>
		public WebServiceLogParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WebServiceLogParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WebServiceLogParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WebServiceLogParameterBuilder
	
	#region WebServiceLogSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WebServiceLogColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WebServiceLogSortBuilder : SqlSortBuilder<WebServiceLogColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogSqlSortBuilder class.
		/// </summary>
		public WebServiceLogSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WebServiceLogSortBuilder
	
} // end namespace
