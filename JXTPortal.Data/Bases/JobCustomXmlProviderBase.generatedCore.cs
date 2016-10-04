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
	/// This class is the base class for any <see cref="JobCustomXmlProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobCustomXmlProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobCustomXml, JXTPortal.Entities.JobCustomXmlKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobCustomXmlKey key)
		{
			return Delete(transactionManager, key.JobCustomXmlid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobCustomXmlid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobCustomXmlid)
		{
			return Delete(null, _jobCustomXmlid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomXmlid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobCustomXmlid);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		FK__JobCustom__Adver__0A6373FB Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetByAdvertiserId(System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		FK__JobCustom__Adver__0A6373FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		/// <remarks></remarks>
		public TList<JobCustomXml> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		FK__JobCustom__Adver__0A6373FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		fkJobCustomAdver0a6373Fb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		fkJobCustomAdver0a6373Fb Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetByAdvertiserId(System.Int32? _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__Adver__0A6373FB key.
		///		FK__JobCustom__Adver__0A6373FB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public abstract TList<JobCustomXml> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		FK__JobCustom__SiteI__096F4FC2 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		FK__JobCustom__SiteI__096F4FC2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		/// <remarks></remarks>
		public TList<JobCustomXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		FK__JobCustom__SiteI__096F4FC2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		fkJobCustomSitei096f4Fc2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		fkJobCustomSitei096f4Fc2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public TList<JobCustomXml> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobCustom__SiteI__096F4FC2 key.
		///		FK__JobCustom__SiteI__096F4FC2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobCustomXml objects.</returns>
		public abstract TList<JobCustomXml> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobCustomXml Get(TransactionManager transactionManager, JXTPortal.Entities.JobCustomXmlKey key, int start, int pageLength)
		{
			return GetByJobCustomXmlid(transactionManager, key.JobCustomXmlid, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="_jobCustomXmlid"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(System.Int32 _jobCustomXmlid)
		{
			int count = -1;
			return GetByJobCustomXmlid(null,_jobCustomXmlid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="_jobCustomXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(System.Int32 _jobCustomXmlid, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCustomXmlid(null, _jobCustomXmlid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomXmlid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(TransactionManager transactionManager, System.Int32 _jobCustomXmlid)
		{
			int count = -1;
			return GetByJobCustomXmlid(transactionManager, _jobCustomXmlid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(TransactionManager transactionManager, System.Int32 _jobCustomXmlid, int start, int pageLength)
		{
			int count = -1;
			return GetByJobCustomXmlid(transactionManager, _jobCustomXmlid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="_jobCustomXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(System.Int32 _jobCustomXmlid, int start, int pageLength, out int count)
		{
			return GetByJobCustomXmlid(null, _jobCustomXmlid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobCusto__D29C8AB1059EBEDE index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobCustomXmlid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobCustomXml"/> class.</returns>
		public abstract JXTPortal.Entities.JobCustomXml GetByJobCustomXmlid(TransactionManager transactionManager, System.Int32 _jobCustomXmlid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobCustomXML_Insert 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid, ref System.Int32? jobCustomXmlid)
		{
			 Insert(null, 0, int.MaxValue , siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid, ref jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid, ref System.Int32? jobCustomXmlid)
		{
			 Insert(null, start, pageLength , siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid, ref jobCustomXmlid);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid, ref System.Int32? jobCustomXmlid)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid, ref jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid, ref System.Int32? jobCustomXmlid);
		
		#endregion
		
		#region JobCustomXML_Delete 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobCustomXmlid)
		{
			 Delete(null, 0, int.MaxValue , jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobCustomXmlid)
		{
			 Delete(null, start, pageLength , jobCustomXmlid);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobCustomXmlid)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobCustomXmlid);
		
		#endregion
		
		#region JobCustomXML_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobCustomXML_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Get_List' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobCustomXML_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobCustomXML_GetPaged' stored procedure. 
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
		
		#region JobCustomXML_GetByAdvertiserId 
		
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByAdvertiserId(int start, int pageLength, System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, start, pageLength , advertiserId);
		}
			
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region JobCustomXML_Find 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid);
		
		#endregion
		
		#region JobCustomXML_GetByJobCustomXmlid 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByJobCustomXmlid' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobCustomXmlid(System.Int32? jobCustomXmlid)
		{
			return GetByJobCustomXmlid(null, 0, int.MaxValue , jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByJobCustomXmlid' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobCustomXmlid(int start, int pageLength, System.Int32? jobCustomXmlid)
		{
			return GetByJobCustomXmlid(null, start, pageLength , jobCustomXmlid);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByJobCustomXmlid' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobCustomXmlid(TransactionManager transactionManager, System.Int32? jobCustomXmlid)
		{
			return GetByJobCustomXmlid(transactionManager, 0, int.MaxValue , jobCustomXmlid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_GetByJobCustomXmlid' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobCustomXmlid(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobCustomXmlid);
		
		#endregion
		
		#region JobCustomXML_Update 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Update' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Update' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			 Update(null, start, pageLength , jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_Update' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , jobCustomXmlid, siteId, uniqueCode, customXml, customType, jobId, jobArchiveId, isDefault, advertiserId, languageIds, valid);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_Update' stored procedure. 
		/// </summary>
		/// <param name="jobCustomXmlid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="uniqueCode"> A <c>System.String</c> instance.</param>
		/// <param name="customXml"> A <c>System.String</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="isDefault"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageIds"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobCustomXmlid, System.Int32? siteId, System.String uniqueCode, System.String customXml, System.Int32? customType, System.Int32? jobId, System.Int32? jobArchiveId, System.Boolean? isDefault, System.Int32? advertiserId, System.String languageIds, System.Boolean? valid);
		
		#endregion
		
		#region JobCustomXML_CustomGetBySiteIDJobIDCustomType 
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_CustomGetBySiteIDJobIDCustomType' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobCustomXml&gt;"/> instance.</returns>
		public TList<JobCustomXml> CustomGetBySiteIDJobIDCustomType(System.Int32? siteId, System.Int32? jobId, System.Int32? customType)
		{
			return CustomGetBySiteIDJobIDCustomType(null, 0, int.MaxValue , siteId, jobId, customType);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_CustomGetBySiteIDJobIDCustomType' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobCustomXml&gt;"/> instance.</returns>
		public TList<JobCustomXml> CustomGetBySiteIDJobIDCustomType(int start, int pageLength, System.Int32? siteId, System.Int32? jobId, System.Int32? customType)
		{
			return CustomGetBySiteIDJobIDCustomType(null, start, pageLength , siteId, jobId, customType);
		}
				
		/// <summary>
		///	This method wrap the 'JobCustomXML_CustomGetBySiteIDJobIDCustomType' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobCustomXml&gt;"/> instance.</returns>
		public TList<JobCustomXml> CustomGetBySiteIDJobIDCustomType(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobId, System.Int32? customType)
		{
			return CustomGetBySiteIDJobIDCustomType(transactionManager, 0, int.MaxValue , siteId, jobId, customType);
		}
		
		/// <summary>
		///	This method wrap the 'JobCustomXML_CustomGetBySiteIDJobIDCustomType' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobCustomXml&gt;"/> instance.</returns>
		public abstract TList<JobCustomXml> CustomGetBySiteIDJobIDCustomType(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobId, System.Int32? customType);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobCustomXml&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobCustomXml&gt;"/></returns>
		public static TList<JobCustomXml> Fill(IDataReader reader, TList<JobCustomXml> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobCustomXml c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobCustomXml")
					.Append("|").Append((System.Int32)reader[((int)JobCustomXmlColumn.JobCustomXmlid - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobCustomXml>(
					key.ToString(), // EntityTrackingKey
					"JobCustomXml",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobCustomXml();
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
					c.JobCustomXmlid = (System.Int32)reader[((int)JobCustomXmlColumn.JobCustomXmlid - 1)];
					c.SiteId = (System.Int32)reader[((int)JobCustomXmlColumn.SiteId - 1)];
					c.UniqueCode = (reader.IsDBNull(((int)JobCustomXmlColumn.UniqueCode - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.UniqueCode - 1)];
					c.CustomXml = (reader.IsDBNull(((int)JobCustomXmlColumn.CustomXml - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.CustomXml - 1)];
					c.CustomType = (System.Int32)reader[((int)JobCustomXmlColumn.CustomType - 1)];
					c.JobId = (reader.IsDBNull(((int)JobCustomXmlColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.JobId - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobCustomXmlColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.JobArchiveId - 1)];
					c.IsDefault = (System.Boolean)reader[((int)JobCustomXmlColumn.IsDefault - 1)];
					c.AdvertiserId = (reader.IsDBNull(((int)JobCustomXmlColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.AdvertiserId - 1)];
					c.LanguageIds = (reader.IsDBNull(((int)JobCustomXmlColumn.LanguageIds - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.LanguageIds - 1)];
					c.Valid = (System.Boolean)reader[((int)JobCustomXmlColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobCustomXml"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomXml"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobCustomXml entity)
		{
			if (!reader.Read()) return;
			
			entity.JobCustomXmlid = (System.Int32)reader[((int)JobCustomXmlColumn.JobCustomXmlid - 1)];
			entity.SiteId = (System.Int32)reader[((int)JobCustomXmlColumn.SiteId - 1)];
			entity.UniqueCode = (reader.IsDBNull(((int)JobCustomXmlColumn.UniqueCode - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.UniqueCode - 1)];
			entity.CustomXml = (reader.IsDBNull(((int)JobCustomXmlColumn.CustomXml - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.CustomXml - 1)];
			entity.CustomType = (System.Int32)reader[((int)JobCustomXmlColumn.CustomType - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobCustomXmlColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.JobId - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobCustomXmlColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.JobArchiveId - 1)];
			entity.IsDefault = (System.Boolean)reader[((int)JobCustomXmlColumn.IsDefault - 1)];
			entity.AdvertiserId = (reader.IsDBNull(((int)JobCustomXmlColumn.AdvertiserId - 1)))?null:(System.Int32?)reader[((int)JobCustomXmlColumn.AdvertiserId - 1)];
			entity.LanguageIds = (reader.IsDBNull(((int)JobCustomXmlColumn.LanguageIds - 1)))?null:(System.String)reader[((int)JobCustomXmlColumn.LanguageIds - 1)];
			entity.Valid = (System.Boolean)reader[((int)JobCustomXmlColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobCustomXml"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomXml"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobCustomXml entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobCustomXmlid = (System.Int32)dataRow["JobCustomXMLID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.UniqueCode = Convert.IsDBNull(dataRow["UniqueCode"]) ? null : (System.String)dataRow["UniqueCode"];
			entity.CustomXml = Convert.IsDBNull(dataRow["CustomXML"]) ? null : (System.String)dataRow["CustomXML"];
			entity.CustomType = (System.Int32)dataRow["CustomType"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.IsDefault = (System.Boolean)dataRow["IsDefault"];
			entity.AdvertiserId = Convert.IsDBNull(dataRow["AdvertiserID"]) ? null : (System.Int32?)dataRow["AdvertiserID"];
			entity.LanguageIds = Convert.IsDBNull(dataRow["LanguageIDs"]) ? null : (System.String)dataRow["LanguageIDs"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobCustomXml"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobCustomXml Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobCustomXml entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserIdSource	
			if (CanDeepLoad(entity, "Advertisers|AdvertiserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AdvertiserId ?? (int)0);
				Advertisers tmpEntity = EntityManager.LocateEntity<Advertisers>(EntityLocator.ConstructKeyFromPkItems(typeof(Advertisers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserIdSource = tmpEntity;
				else
					entity.AdvertiserIdSource = DataRepository.AdvertisersProvider.GetByAdvertiserId(transactionManager, (entity.AdvertiserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AdvertiserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertisersProvider.DeepLoad(transactionManager, entity.AdvertiserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AdvertiserIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobCustomXml object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobCustomXml instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobCustomXml Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobCustomXml entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AdvertiserIdSource
			if (CanDeepSave(entity, "Advertisers|AdvertiserIdSource", deepSaveType, innerList) 
				&& entity.AdvertiserIdSource != null)
			{
				DataRepository.AdvertisersProvider.Save(transactionManager, entity.AdvertiserIdSource);
				entity.AdvertiserId = entity.AdvertiserIdSource.AdvertiserId;
			}
			#endregion 
			
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
	
	#region JobCustomXmlChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobCustomXml</c>
	///</summary>
	public enum JobCustomXmlChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion JobCustomXmlChildEntityTypes
	
	#region JobCustomXmlFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobCustomXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomXmlFilterBuilder : SqlFilterBuilder<JobCustomXmlColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilterBuilder class.
		/// </summary>
		public JobCustomXmlFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomXmlFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomXmlFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomXmlFilterBuilder
	
	#region JobCustomXmlParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobCustomXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomXmlParameterBuilder : ParameterizedSqlFilterBuilder<JobCustomXmlColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlParameterBuilder class.
		/// </summary>
		public JobCustomXmlParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomXmlParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomXmlParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomXmlParameterBuilder
	
	#region JobCustomXmlSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobCustomXmlColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomXml"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobCustomXmlSortBuilder : SqlSortBuilder<JobCustomXmlColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlSqlSortBuilder class.
		/// </summary>
		public JobCustomXmlSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobCustomXmlSortBuilder
	
} // end namespace
