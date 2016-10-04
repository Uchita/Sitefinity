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
	/// This class is the base class for any <see cref="JobViewsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobViewsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobViews, JXTPortal.Entities.JobViewsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobViewsKey key)
		{
			return Delete(transactionManager, key.JobViewId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobViewId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobViewId)
		{
			return Delete(null, _jobViewId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobViewId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobViewId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		FK__JobViews__SiteID__462A06AB Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		public TList<JobViews> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		FK__JobViews__SiteID__462A06AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		/// <remarks></remarks>
		public TList<JobViews> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		FK__JobViews__SiteID__462A06AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		public TList<JobViews> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		fkJobViewsSiteId462a06Ab Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		public TList<JobViews> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		fkJobViewsSiteId462a06Ab Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		public TList<JobViews> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobViews__SiteID__462A06AB key.
		///		FK__JobViews__SiteID__462A06AB Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobViews objects.</returns>
		public abstract TList<JobViews> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobViews Get(TransactionManager transactionManager, JXTPortal.Entities.JobViewsKey key, int start, int pageLength)
		{
			return GetByJobViewId(transactionManager, key.JobViewId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(null,_jobArchiveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength, out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobArchiveID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public abstract TList<JobViews> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_JobViews_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(null,_jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobID index.
		/// </summary>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public TList<JobViews> GetByJobId(System.Int32? _jobId, int start, int pageLength, out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_JobViews_JobID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;JobViews&gt;"/> class.</returns>
		public abstract TList<JobViews> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_JobViews index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate)
		{
			int count = -1;
			return GetBySiteIdJobIdJobArchiveIdViewDate(null,_siteId, _jobId, _jobArchiveId, _viewDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_JobViews index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdJobIdJobArchiveIdViewDate(null, _siteId, _jobId, _jobArchiveId, _viewDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_JobViews index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate)
		{
			int count = -1;
			return GetBySiteIdJobIdJobArchiveIdViewDate(transactionManager, _siteId, _jobId, _jobArchiveId, _viewDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_JobViews index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdJobIdJobArchiveIdViewDate(transactionManager, _siteId, _jobId, _jobArchiveId, _viewDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_JobViews index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate, int start, int pageLength, out int count)
		{
			return GetBySiteIdJobIdJobArchiveIdViewDate(null, _siteId, _jobId, _jobArchiveId, _viewDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_JobViews index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_jobId"></param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="_viewDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public abstract JXTPortal.Entities.JobViews GetBySiteIdJobIdJobArchiveIdViewDate(TransactionManager transactionManager, System.Int32 _siteId, System.Int32? _jobId, System.Int32? _jobArchiveId, System.DateTime _viewDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="_jobViewId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetByJobViewId(System.Int32 _jobViewId)
		{
			int count = -1;
			return GetByJobViewId(null,_jobViewId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="_jobViewId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetByJobViewId(System.Int32 _jobViewId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobViewId(null, _jobViewId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobViewId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetByJobViewId(TransactionManager transactionManager, System.Int32 _jobViewId)
		{
			int count = -1;
			return GetByJobViewId(transactionManager, _jobViewId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobViewId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetByJobViewId(TransactionManager transactionManager, System.Int32 _jobViewId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobViewId(transactionManager, _jobViewId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="_jobViewId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public JXTPortal.Entities.JobViews GetByJobViewId(System.Int32 _jobViewId, int start, int pageLength, out int count)
		{
			return GetByJobViewId(null, _jobViewId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobViews__4535E272 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobViewId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobViews"/> class.</returns>
		public abstract JXTPortal.Entities.JobViews GetByJobViewId(TransactionManager transactionManager, System.Int32 _jobViewId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobViews_GetByDate 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDate(System.Int32? siteId, System.DateTime? viewDate)
		{
			return GetByDate(null, 0, int.MaxValue , siteId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDate(int start, int pageLength, System.Int32? siteId, System.DateTime? viewDate)
		{
			return GetByDate(null, start, pageLength , siteId, viewDate);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_GetByDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDate(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? viewDate)
		{
			return GetByDate(transactionManager, 0, int.MaxValue , siteId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? viewDate);
		
		#endregion
		
		#region JobViews_Insert 
		
		/// <summary>
		///	This method wrap the 'JobViews_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
			/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral, ref System.Int32? jobViewId)
		{
			 Insert(null, 0, int.MaxValue , siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral, ref jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
			/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral, ref System.Int32? jobViewId)
		{
			 Insert(null, start, pageLength , siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral, ref jobViewId);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
			/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral, ref System.Int32? jobViewId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral, ref jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
			/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral, ref System.Int32? jobViewId);
		
		#endregion
		
		#region JobViews_GetByJobId 
		
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobViews_GetBySiteIdJobIdJobArchiveIdViewDate 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdJobArchiveIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdJobArchiveIdViewDate(System.Int32? siteId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdJobArchiveIdViewDate(null, 0, int.MaxValue , siteId, jobId, jobArchiveId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdJobArchiveIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdJobArchiveIdViewDate(int start, int pageLength, System.Int32? siteId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdJobArchiveIdViewDate(null, start, pageLength , siteId, jobId, jobArchiveId, viewDate);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdJobArchiveIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdJobArchiveIdViewDate(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdJobArchiveIdViewDate(transactionManager, 0, int.MaxValue , siteId, jobId, jobArchiveId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdJobArchiveIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdJobIdJobArchiveIdViewDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobId, System.Int32? jobArchiveId, System.DateTime? viewDate);
		
		#endregion
		
		#region JobViews_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobViews_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'JobViews_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region JobViews_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobViews_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Get_List' stored procedure. 
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
		///	This method wrap the 'JobViews_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobViews_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobViews_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobViews_GetPaged' stored procedure. 
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
		///	This method wrap the 'JobViews_GetPaged' stored procedure. 
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
		
		#region JobViews_UpdateCounter 
		
		/// <summary>
		///	This method wrap the 'JobViews_UpdateCounter' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateCounter(System.Int32? jobId, System.Int32? siteId, System.String domainReferral, System.DateTime? viewDate)
		{
			 UpdateCounter(null, 0, int.MaxValue , jobId, siteId, domainReferral, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_UpdateCounter' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateCounter(int start, int pageLength, System.Int32? jobId, System.Int32? siteId, System.String domainReferral, System.DateTime? viewDate)
		{
			 UpdateCounter(null, start, pageLength , jobId, siteId, domainReferral, viewDate);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_UpdateCounter' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateCounter(TransactionManager transactionManager, System.Int32? jobId, System.Int32? siteId, System.String domainReferral, System.DateTime? viewDate)
		{
			 UpdateCounter(transactionManager, 0, int.MaxValue , jobId, siteId, domainReferral, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_UpdateCounter' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateCounter(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? siteId, System.String domainReferral, System.DateTime? viewDate);
		
		#endregion
		
		#region JobViews_GetBySiteIdJobIdViewDate 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdViewDate(System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdViewDate(null, 0, int.MaxValue , siteId, jobId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdViewDate(int start, int pageLength, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdViewDate(null, start, pageLength , siteId, jobId, viewDate);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdJobIdViewDate(TransactionManager transactionManager, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate)
		{
			return GetBySiteIdJobIdViewDate(transactionManager, 0, int.MaxValue , siteId, jobId, viewDate);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetBySiteIdJobIdViewDate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdJobIdViewDate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate);
		
		#endregion
		
		#region JobViews_Update 
		
		/// <summary>
		///	This method wrap the 'JobViews_Update' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			 Update(null, 0, int.MaxValue , jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Update' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			 Update(null, start, pageLength , jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_Update' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			 Update(transactionManager, 0, int.MaxValue , jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Update' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral);
		
		#endregion
		
		#region JobViews_Find 
		
		/// <summary>
		///	This method wrap the 'JobViews_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			return Find(null, start, pageLength , searchUsingOr, jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobViewId, siteId, jobId, viewDate, totalView, jobArchiveId, domainReferral);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="viewDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="totalView"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="domainReferral"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobViewId, System.Int32? siteId, System.Int32? jobId, System.DateTime? viewDate, System.Int32? totalView, System.Int32? jobArchiveId, System.String domainReferral);
		
		#endregion
		
		#region JobViews_Delete 
		
		/// <summary>
		///	This method wrap the 'JobViews_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobViewId)
		{
			 Delete(null, 0, int.MaxValue , jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobViewId)
		{
			 Delete(null, start, pageLength , jobViewId);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobViewId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobViewId);
		
		#endregion
		
		#region JobViews_GetGroupByDateRange 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetGroupByDateRange' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetGroupByDateRange(System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo)
		{
			return GetGroupByDateRange(null, 0, int.MaxValue , siteId, dateFrom, dateTo);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetGroupByDateRange' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetGroupByDateRange(int start, int pageLength, System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo)
		{
			return GetGroupByDateRange(null, start, pageLength , siteId, dateFrom, dateTo);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_GetGroupByDateRange' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetGroupByDateRange(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo)
		{
			return GetGroupByDateRange(transactionManager, 0, int.MaxValue , siteId, dateFrom, dateTo);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetGroupByDateRange' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetGroupByDateRange(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo);
		
		#endregion
		
		#region JobViews_GetByJobArchiveId 
		
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobViews_GetByJobViewId 
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobViewId' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobViewId(System.Int32? jobViewId)
		{
			return GetByJobViewId(null, 0, int.MaxValue , jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobViewId' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobViewId(int start, int pageLength, System.Int32? jobViewId)
		{
			return GetByJobViewId(null, start, pageLength , jobViewId);
		}
				
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobViewId' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByJobViewId(TransactionManager transactionManager, System.Int32? jobViewId)
		{
			return GetByJobViewId(transactionManager, 0, int.MaxValue , jobViewId);
		}
		
		/// <summary>
		///	This method wrap the 'JobViews_GetByJobViewId' stored procedure. 
		/// </summary>
		/// <param name="jobViewId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByJobViewId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobViewId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobViews&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobViews&gt;"/></returns>
		public static TList<JobViews> Fill(IDataReader reader, TList<JobViews> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobViews c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobViews")
					.Append("|").Append((System.Int32)reader[((int)JobViewsColumn.JobViewId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobViews>(
					key.ToString(), // EntityTrackingKey
					"JobViews",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobViews();
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
					c.JobViewId = (System.Int32)reader[((int)JobViewsColumn.JobViewId - 1)];
					c.SiteId = (System.Int32)reader[((int)JobViewsColumn.SiteId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobViewsColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobViewsColumn.JobId - 1)];
					c.ViewDate = (System.DateTime)reader[((int)JobViewsColumn.ViewDate - 1)];
					c.TotalView = (System.Int32)reader[((int)JobViewsColumn.TotalView - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobViewsColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobViewsColumn.JobArchiveId - 1)];
					c.DomainReferral = (reader.IsDBNull(((int)JobViewsColumn.DomainReferral - 1)))?null:(System.String)reader[((int)JobViewsColumn.DomainReferral - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobViews"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobViews"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobViews entity)
		{
			if (!reader.Read()) return;
			
			entity.JobViewId = (System.Int32)reader[((int)JobViewsColumn.JobViewId - 1)];
			entity.SiteId = (System.Int32)reader[((int)JobViewsColumn.SiteId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobViewsColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobViewsColumn.JobId - 1)];
			entity.ViewDate = (System.DateTime)reader[((int)JobViewsColumn.ViewDate - 1)];
			entity.TotalView = (System.Int32)reader[((int)JobViewsColumn.TotalView - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobViewsColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobViewsColumn.JobArchiveId - 1)];
			entity.DomainReferral = (reader.IsDBNull(((int)JobViewsColumn.DomainReferral - 1)))?null:(System.String)reader[((int)JobViewsColumn.DomainReferral - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobViews"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobViews"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobViews entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobViewId = (System.Int32)dataRow["JobViewID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.ViewDate = (System.DateTime)dataRow["ViewDate"];
			entity.TotalView = (System.Int32)dataRow["TotalView"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.DomainReferral = Convert.IsDBNull(dataRow["DomainReferral"]) ? null : (System.String)dataRow["DomainReferral"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobViews"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobViews Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobViews entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region JobArchiveIdSource	
			if (CanDeepLoad(entity, "JobsArchive|JobArchiveIdSource", deepLoadType, innerList) 
				&& entity.JobArchiveIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobArchiveId ?? (int)0);
				JobsArchive tmpEntity = EntityManager.LocateEntity<JobsArchive>(EntityLocator.ConstructKeyFromPkItems(typeof(JobsArchive), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobArchiveIdSource = tmpEntity;
				else
					entity.JobArchiveIdSource = DataRepository.JobsArchiveProvider.GetByJobId(transactionManager, (entity.JobArchiveId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobArchiveIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobArchiveIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsArchiveProvider.DeepLoad(transactionManager, entity.JobArchiveIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobArchiveIdSource

			#region JobIdSource	
			if (CanDeepLoad(entity, "Jobs|JobIdSource", deepLoadType, innerList) 
				&& entity.JobIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobId ?? (int)0);
				Jobs tmpEntity = EntityManager.LocateEntity<Jobs>(EntityLocator.ConstructKeyFromPkItems(typeof(Jobs), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobIdSource = tmpEntity;
				else
					entity.JobIdSource = DataRepository.JobsProvider.GetByJobId(transactionManager, (entity.JobId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.JobsProvider.DeepLoad(transactionManager, entity.JobIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobViews object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobViews instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobViews Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobViews entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region JobArchiveIdSource
			if (CanDeepSave(entity, "JobsArchive|JobArchiveIdSource", deepSaveType, innerList) 
				&& entity.JobArchiveIdSource != null)
			{
				DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobArchiveIdSource);
				entity.JobArchiveId = entity.JobArchiveIdSource.JobId;
			}
			#endregion 
			
			#region JobIdSource
			if (CanDeepSave(entity, "Jobs|JobIdSource", deepSaveType, innerList) 
				&& entity.JobIdSource != null)
			{
				DataRepository.JobsProvider.Save(transactionManager, entity.JobIdSource);
				entity.JobId = entity.JobIdSource.JobId;
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
	
	#region JobViewsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobViews</c>
	///</summary>
	public enum JobViewsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>JobsArchive</c> at JobArchiveIdSource
		///</summary>
		[ChildEntityType(typeof(JobsArchive))]
		JobsArchive,
			
		///<summary>
		/// Composite Property for <c>Jobs</c> at JobIdSource
		///</summary>
		[ChildEntityType(typeof(Jobs))]
		Jobs,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion JobViewsChildEntityTypes
	
	#region JobViewsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobViewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobViews"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobViewsFilterBuilder : SqlFilterBuilder<JobViewsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobViewsFilterBuilder class.
		/// </summary>
		public JobViewsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobViewsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobViewsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobViewsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobViewsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobViewsFilterBuilder
	
	#region JobViewsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobViewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobViews"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobViewsParameterBuilder : ParameterizedSqlFilterBuilder<JobViewsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobViewsParameterBuilder class.
		/// </summary>
		public JobViewsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobViewsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobViewsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobViewsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobViewsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobViewsParameterBuilder
	
	#region JobViewsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobViewsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobViews"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobViewsSortBuilder : SqlSortBuilder<JobViewsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobViewsSqlSortBuilder class.
		/// </summary>
		public JobViewsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobViewsSortBuilder
	
} // end namespace
