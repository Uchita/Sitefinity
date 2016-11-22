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
	/// This class is the base class for any <see cref="JobTemplatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobTemplatesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobTemplates, JXTPortal.Entities.JobTemplatesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobTemplatesKey key)
		{
			return Delete(transactionManager, key.JobTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobTemplateId)
		{
			return Delete(null, _jobTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobTemplateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		FK__JobTempla__Adver__2C5C4C1E Description: 
		/// </summary>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByAdvertiserId(System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(_advertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		FK__JobTempla__Adver__2C5C4C1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<JobTemplates> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		FK__JobTempla__Adver__2C5C4C1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByAdvertiserId(transactionManager, _advertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		fkJobTemplaAdver2c5c4c1e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAdvertiserId(null, _advertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		fkJobTemplaAdver2c5c4c1e Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_advertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByAdvertiserId(System.Int32 _advertiserId, int start, int pageLength,out int count)
		{
			return GetByAdvertiserId(null, _advertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__Adver__2C5C4C1E key.
		///		FK__JobTempla__Adver__2C5C4C1E Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_advertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public abstract TList<JobTemplates> GetByAdvertiserId(TransactionManager transactionManager, System.Int32 _advertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		FK__JobTempla__LastM__61E66462 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		FK__JobTempla__LastM__61E66462 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<JobTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		FK__JobTempla__LastM__61E66462 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		fkJobTemplaLastm61e66462 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		fkJobTemplaLastm61e66462 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__LastM__61E66462 key.
		///		FK__JobTempla__LastM__61E66462 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public abstract TList<JobTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		FK__JobTempla__SiteI__5FFE1BF0 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetBySiteId(System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		FK__JobTempla__SiteI__5FFE1BF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<JobTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		FK__JobTempla__SiteI__5FFE1BF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		fkJobTemplaSitei5Ffe1Bf0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetBySiteId(System.Int32? _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		fkJobTemplaSitei5Ffe1Bf0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public TList<JobTemplates> GetBySiteId(System.Int32? _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobTempla__SiteI__5FFE1BF0 key.
		///		FK__JobTempla__SiteI__5FFE1BF0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobTemplates objects.</returns>
		public abstract TList<JobTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobTemplates Get(TransactionManager transactionManager, JXTPortal.Entities.JobTemplatesKey key, int start, int pageLength)
		{
			return GetByJobTemplateId(transactionManager, key.JobTemplateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="_jobTemplateId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public JXTPortal.Entities.JobTemplates GetByJobTemplateId(System.Int32 _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(null,_jobTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public JXTPortal.Entities.JobTemplates GetByJobTemplateId(System.Int32 _jobTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public JXTPortal.Entities.JobTemplates GetByJobTemplateId(TransactionManager transactionManager, System.Int32 _jobTemplateId)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public JXTPortal.Entities.JobTemplates GetByJobTemplateId(TransactionManager transactionManager, System.Int32 _jobTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobTemplateId(transactionManager, _jobTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public JXTPortal.Entities.JobTemplates GetByJobTemplateId(System.Int32 _jobTemplateId, int start, int pageLength, out int count)
		{
			return GetByJobTemplateId(null, _jobTemplateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobTemplates__5F09F7B7 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobTemplates"/> class.</returns>
		public abstract JXTPortal.Entities.JobTemplates GetByJobTemplateId(TransactionManager transactionManager, System.Int32 _jobTemplateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobTemplates_Insert 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId, ref System.Int32? jobTemplateId)
		{
			 Insert(null, 0, int.MaxValue , siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId, ref jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId, ref System.Int32? jobTemplateId)
		{
			 Insert(null, start, pageLength , siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId, ref jobTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId, ref System.Int32? jobTemplateId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId, ref jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId, ref System.Int32? jobTemplateId);
		
		#endregion
		
		#region JobTemplates_GetBySiteId 
		
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobTemplates_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobTemplates_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region JobTemplates_GetByJobTemplateId 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByJobTemplateId(System.Int32? jobTemplateId)
		{
			return GetByJobTemplateId(null, 0, int.MaxValue , jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByJobTemplateId(int start, int pageLength, System.Int32? jobTemplateId)
		{
			return GetByJobTemplateId(null, start, pageLength , jobTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByJobTemplateId(TransactionManager transactionManager, System.Int32? jobTemplateId)
		{
			return GetByJobTemplateId(transactionManager, 0, int.MaxValue , jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByJobTemplateId' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetByJobTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobTemplateId);
		
		#endregion
		
		#region JobTemplates_GetByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByAdvertiserId(System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByAdvertiserId(int start, int pageLength, System.Int32? advertiserId)
		{
			return GetByAdvertiserId(null, start, pageLength , advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByAdvertiserId(TransactionManager transactionManager, System.Int32? advertiserId)
		{
			return GetByAdvertiserId(transactionManager, 0, int.MaxValue , advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? advertiserId);
		
		#endregion
		
		#region JobTemplates_GetAdvertiserJobTemplates 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetAdvertiserJobTemplates' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetAdvertiserJobTemplates(System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetAdvertiserJobTemplates(null, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetAdvertiserJobTemplates' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetAdvertiserJobTemplates(int start, int pageLength, System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetAdvertiserJobTemplates(null, start, pageLength , siteId, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetAdvertiserJobTemplates' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetAdvertiserJobTemplates(TransactionManager transactionManager, System.Int32? siteId, System.Int32? advertiserId)
		{
			return GetAdvertiserJobTemplates(transactionManager, 0, int.MaxValue , siteId, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetAdvertiserJobTemplates' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetAdvertiserJobTemplates(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? advertiserId);
		
		#endregion
		
		#region JobTemplates_Update 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			 Update(null, 0, int.MaxValue , jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			 Update(null, start, pageLength , jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId);
		
		#endregion
		
		#region JobTemplates_Find 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Find(System.Boolean? searchUsingOr, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobTemplateId, siteId, jobTemplateDescription, jobTemplateHtml, globalTemplate, lastModifiedBy, lastModified, jobTemplateLogo, advertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobTemplateDescription"> A <c>System.String</c> instance.</param>
		/// <param name="jobTemplateHtml"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="jobTemplateLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="advertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobTemplateId, System.Int32? siteId, System.String jobTemplateDescription, System.String jobTemplateHtml, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Byte[] jobTemplateLogo, System.Int32? advertiserId);
		
		#endregion
		
		#region JobTemplates_Delete 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobTemplateId)
		{
			 Delete(null, 0, int.MaxValue , jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobTemplateId)
		{
			 Delete(null, start, pageLength , jobTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobTemplateId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobTemplateId);
		
		#endregion
		
		#region JobTemplates_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public TList<JobTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'JobTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobTemplates&gt;"/> instance.</returns>
		public abstract TList<JobTemplates> GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobTemplates&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobTemplates&gt;"/></returns>
		public static TList<JobTemplates> Fill(IDataReader reader, TList<JobTemplates> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobTemplates c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobTemplates")
					.Append("|").Append((System.Int32)reader[((int)JobTemplatesColumn.JobTemplateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobTemplates>(
					key.ToString(), // EntityTrackingKey
					"JobTemplates",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobTemplates();
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
					c.JobTemplateId = (System.Int32)reader[((int)JobTemplatesColumn.JobTemplateId - 1)];
					c.SiteId = (reader.IsDBNull(((int)JobTemplatesColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)JobTemplatesColumn.SiteId - 1)];
					c.JobTemplateDescription = (System.String)reader[((int)JobTemplatesColumn.JobTemplateDescription - 1)];
					c.JobTemplateHtml = (reader.IsDBNull(((int)JobTemplatesColumn.JobTemplateHtml - 1)))?null:(System.String)reader[((int)JobTemplatesColumn.JobTemplateHtml - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)JobTemplatesColumn.GlobalTemplate - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)JobTemplatesColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)JobTemplatesColumn.LastModified - 1)];
					c.JobTemplateLogo = (reader.IsDBNull(((int)JobTemplatesColumn.JobTemplateLogo - 1)))?null:(System.Byte[])reader[((int)JobTemplatesColumn.JobTemplateLogo - 1)];
					c.AdvertiserId = (System.Int32)reader[((int)JobTemplatesColumn.AdvertiserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobTemplates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobTemplates"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobTemplates entity)
		{
			if (!reader.Read()) return;
			
			entity.JobTemplateId = (System.Int32)reader[((int)JobTemplatesColumn.JobTemplateId - 1)];
			entity.SiteId = (reader.IsDBNull(((int)JobTemplatesColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)JobTemplatesColumn.SiteId - 1)];
			entity.JobTemplateDescription = (System.String)reader[((int)JobTemplatesColumn.JobTemplateDescription - 1)];
			entity.JobTemplateHtml = (reader.IsDBNull(((int)JobTemplatesColumn.JobTemplateHtml - 1)))?null:(System.String)reader[((int)JobTemplatesColumn.JobTemplateHtml - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)JobTemplatesColumn.GlobalTemplate - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)JobTemplatesColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)JobTemplatesColumn.LastModified - 1)];
			entity.JobTemplateLogo = (reader.IsDBNull(((int)JobTemplatesColumn.JobTemplateLogo - 1)))?null:(System.Byte[])reader[((int)JobTemplatesColumn.JobTemplateLogo - 1)];
			entity.AdvertiserId = (System.Int32)reader[((int)JobTemplatesColumn.AdvertiserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobTemplates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobTemplates"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobTemplates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobTemplateId = (System.Int32)dataRow["JobTemplateID"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.JobTemplateDescription = (System.String)dataRow["JobTemplateDescription"];
			entity.JobTemplateHtml = Convert.IsDBNull(dataRow["JobTemplateHTML"]) ? null : (System.String)dataRow["JobTemplateHTML"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.JobTemplateLogo = Convert.IsDBNull(dataRow["JobTemplateLogo"]) ? null : (System.Byte[])dataRow["JobTemplateLogo"];
			entity.AdvertiserId = (System.Int32)dataRow["AdvertiserID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobTemplates"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobTemplates Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobTemplates entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AdvertiserIdSource	
			if (CanDeepLoad(entity, "Advertisers|AdvertiserIdSource", deepLoadType, innerList) 
				&& entity.AdvertiserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AdvertiserId;
				Advertisers tmpEntity = EntityManager.LocateEntity<Advertisers>(EntityLocator.ConstructKeyFromPkItems(typeof(Advertisers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AdvertiserIdSource = tmpEntity;
				else
					entity.AdvertiserIdSource = DataRepository.AdvertisersProvider.GetByAdvertiserId(transactionManager, entity.AdvertiserId);		
				
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

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LastModifiedBy;
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, entity.LastModifiedBy);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastModifiedBySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastModifiedBySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdminUsersProvider.DeepLoad(transactionManager, entity.LastModifiedBySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastModifiedBySource

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
			// Deep load child collections  - Call GetByJobTemplateId methods when available
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetByJobTemplateId(transactionManager, entity.JobTemplateId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsArchiveCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsArchive>|JobsArchiveCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsArchiveCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetByJobTemplateId(transactionManager, entity.JobTemplateId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobTemplates object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobTemplates instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobTemplates Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobTemplates entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region LastModifiedBySource
			if (CanDeepSave(entity, "AdminUsers|LastModifiedBySource", deepSaveType, innerList) 
				&& entity.LastModifiedBySource != null)
			{
				DataRepository.AdminUsersProvider.Save(transactionManager, entity.LastModifiedBySource);
				entity.LastModifiedBy = entity.LastModifiedBySource.AdminUserId;
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
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.JobTemplateIdSource != null)
						{
							child.JobTemplateId = child.JobTemplateIdSource.JobTemplateId;
						}
						else
						{
							child.JobTemplateId = entity.JobTemplateId;
						}

					}

					if (entity.JobsCollection.Count > 0 || entity.JobsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsProvider.Save(transactionManager, entity.JobsCollection);
						
						deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Jobs >) DataRepository.JobsProvider.DeepSave,
							new object[] { transactionManager, entity.JobsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobsArchive>
				if (CanDeepSave(entity.JobsArchiveCollection, "List<JobsArchive>|JobsArchiveCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsArchive child in entity.JobsArchiveCollection)
					{
						if(child.JobTemplateIdSource != null)
						{
							child.JobTemplateId = child.JobTemplateIdSource.JobTemplateId;
						}
						else
						{
							child.JobTemplateId = entity.JobTemplateId;
						}

					}

					if (entity.JobsArchiveCollection.Count > 0 || entity.JobsArchiveCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobsArchiveCollection);
						
						deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsArchive >) DataRepository.JobsArchiveProvider.DeepSave,
							new object[] { transactionManager, entity.JobsArchiveCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
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
	
	#region JobTemplatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobTemplates</c>
	///</summary>
	public enum JobTemplatesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at AdvertiserIdSource
		///</summary>
		[ChildEntityType(typeof(Advertisers))]
		Advertisers,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>JobTemplates</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>JobTemplates</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,
	}
	
	#endregion JobTemplatesChildEntityTypes
	
	#region JobTemplatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesFilterBuilder : SqlFilterBuilder<JobTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilterBuilder class.
		/// </summary>
		public JobTemplatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobTemplatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobTemplatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobTemplatesFilterBuilder
	
	#region JobTemplatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesParameterBuilder : ParameterizedSqlFilterBuilder<JobTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesParameterBuilder class.
		/// </summary>
		public JobTemplatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobTemplatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobTemplatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobTemplatesParameterBuilder
	
	#region JobTemplatesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobTemplatesSortBuilder : SqlSortBuilder<JobTemplatesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesSqlSortBuilder class.
		/// </summary>
		public JobTemplatesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobTemplatesSortBuilder
	
} // end namespace
