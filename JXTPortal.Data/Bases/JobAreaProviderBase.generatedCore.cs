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
	/// This class is the base class for any <see cref="JobAreaProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobAreaProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobArea, JXTPortal.Entities.JobAreaKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobAreaKey key)
		{
			return Delete(transactionManager, key.JobAreaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobAreaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobAreaId)
		{
			return Delete(null, _jobAreaId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAreaId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobAreaId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		FK__JobArea__AreaID__10A1534B Description: 
		/// </summary>
		/// <param name="_areaId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByAreaId(System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(_areaId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		FK__JobArea__AreaID__10A1534B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		/// <remarks></remarks>
		public TList<JobArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		FK__JobArea__AreaID__10A1534B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength)
		{
			int count = -1;
			return GetByAreaId(transactionManager, _areaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		fkJobAreaAreaId10a1534b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_areaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByAreaId(System.Int32 _areaId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAreaId(null, _areaId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		fkJobAreaAreaId10a1534b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_areaId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByAreaId(System.Int32 _areaId, int start, int pageLength,out int count)
		{
			return GetByAreaId(null, _areaId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__AreaID__10A1534B key.
		///		FK__JobArea__AreaID__10A1534B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_areaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public abstract TList<JobArea> GetByAreaId(TransactionManager transactionManager, System.Int32 _areaId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		FK__JobArea__JobArch__0FAD2F12 Description: 
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(_jobArchiveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		FK__JobArea__JobArch__0FAD2F12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		/// <remarks></remarks>
		public TList<JobArea> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		FK__JobArea__JobArch__0FAD2F12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		fkJobAreaJobArch0Fad2f12 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		fkJobAreaJobArch0Fad2f12 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength,out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobArch__0FAD2F12 key.
		///		FK__JobArea__JobArch__0FAD2F12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public abstract TList<JobArea> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		FK__JobArea__JobID__0EB90AD9 Description: 
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(_jobId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		FK__JobArea__JobID__0EB90AD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		/// <remarks></remarks>
		public TList<JobArea> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		FK__JobArea__JobID__0EB90AD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		fkJobAreaJobId0Eb90Ad9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobId(null, _jobId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		fkJobAreaJobId0Eb90Ad9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public TList<JobArea> GetByJobId(System.Int32? _jobId, int start, int pageLength,out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobArea__JobID__0EB90AD9 key.
		///		FK__JobArea__JobID__0EB90AD9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobArea objects.</returns>
		public abstract TList<JobArea> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobArea Get(TransactionManager transactionManager, JXTPortal.Entities.JobAreaKey key, int start, int pageLength)
		{
			return GetByJobAreaId(transactionManager, key.JobAreaId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="_jobAreaId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public JXTPortal.Entities.JobArea GetByJobAreaId(System.Int32 _jobAreaId)
		{
			int count = -1;
			return GetByJobAreaId(null,_jobAreaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="_jobAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public JXTPortal.Entities.JobArea GetByJobAreaId(System.Int32 _jobAreaId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobAreaId(null, _jobAreaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAreaId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public JXTPortal.Entities.JobArea GetByJobAreaId(TransactionManager transactionManager, System.Int32 _jobAreaId)
		{
			int count = -1;
			return GetByJobAreaId(transactionManager, _jobAreaId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public JXTPortal.Entities.JobArea GetByJobAreaId(TransactionManager transactionManager, System.Int32 _jobAreaId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobAreaId(transactionManager, _jobAreaId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="_jobAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public JXTPortal.Entities.JobArea GetByJobAreaId(System.Int32 _jobAreaId, int start, int pageLength, out int count)
		{
			return GetByJobAreaId(null, _jobAreaId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobArea__0DC4E6A0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobAreaId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobArea"/> class.</returns>
		public abstract JXTPortal.Entities.JobArea GetByJobAreaId(TransactionManager transactionManager, System.Int32 _jobAreaId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobArea_Insert 
		
		/// <summary>
		///	This method wrap the 'JobArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId, ref System.Int32? jobAreaId)
		{
			 Insert(null, 0, int.MaxValue , jobId, jobArchiveId, areaId, ref jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId, ref System.Int32? jobAreaId)
		{
			 Insert(null, start, pageLength , jobId, jobArchiveId, areaId, ref jobAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId, ref System.Int32? jobAreaId)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobId, jobArchiveId, areaId, ref jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId, ref System.Int32? jobAreaId);
		
		#endregion
		
		#region JobArea_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobArea_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobArea_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobArea_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region JobArea_Update 
		
		/// <summary>
		///	This method wrap the 'JobArea_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			 Update(null, 0, int.MaxValue , jobAreaId, jobId, jobArchiveId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			 Update(null, start, pageLength , jobAreaId, jobId, jobArchiveId, areaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobAreaId, jobId, jobArchiveId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Update' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId);
		
		#endregion
		
		#region JobArea_Find 
		
		/// <summary>
		///	This method wrap the 'JobArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Find(System.Boolean? searchUsingOr, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobAreaId, jobId, jobArchiveId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobAreaId, jobId, jobArchiveId, areaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobAreaId, jobId, jobArchiveId, areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobAreaId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? areaId);
		
		#endregion
		
		#region JobArea_Delete 
		
		/// <summary>
		///	This method wrap the 'JobArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobAreaId)
		{
			 Delete(null, 0, int.MaxValue , jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobAreaId)
		{
			 Delete(null, start, pageLength , jobAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobAreaId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAreaId);
		
		#endregion
		
		#region JobArea_GetByAreaId 
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByAreaId(System.Int32? areaId)
		{
			return GetByAreaId(null, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByAreaId(int start, int pageLength, System.Int32? areaId)
		{
			return GetByAreaId(null, start, pageLength , areaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByAreaId(TransactionManager transactionManager, System.Int32? areaId)
		{
			return GetByAreaId(transactionManager, 0, int.MaxValue , areaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByAreaId' stored procedure. 
		/// </summary>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> GetByAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? areaId);
		
		#endregion
		
		#region JobArea_GetByJobArchiveId 
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobArea_GetByJobAreaId 
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobAreaId' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByJobAreaId(System.Int32? jobAreaId)
		{
			return GetByJobAreaId(null, 0, int.MaxValue , jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobAreaId' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByJobAreaId(int start, int pageLength, System.Int32? jobAreaId)
		{
			return GetByJobAreaId(null, start, pageLength , jobAreaId);
		}
				
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobAreaId' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public TList<JobArea> GetByJobAreaId(TransactionManager transactionManager, System.Int32? jobAreaId)
		{
			return GetByJobAreaId(transactionManager, 0, int.MaxValue , jobAreaId);
		}
		
		/// <summary>
		///	This method wrap the 'JobArea_GetByJobAreaId' stored procedure. 
		/// </summary>
		/// <param name="jobAreaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobArea&gt;"/> instance.</returns>
		public abstract TList<JobArea> GetByJobAreaId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobAreaId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobArea&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobArea&gt;"/></returns>
		public static TList<JobArea> Fill(IDataReader reader, TList<JobArea> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobArea c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobArea")
					.Append("|").Append((System.Int32)reader[((int)JobAreaColumn.JobAreaId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobArea>(
					key.ToString(), // EntityTrackingKey
					"JobArea",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobArea();
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
					c.JobAreaId = (System.Int32)reader[((int)JobAreaColumn.JobAreaId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobAreaColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobAreaColumn.JobId - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobAreaColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobAreaColumn.JobArchiveId - 1)];
					c.AreaId = (System.Int32)reader[((int)JobAreaColumn.AreaId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobArea"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobArea"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobArea entity)
		{
			if (!reader.Read()) return;
			
			entity.JobAreaId = (System.Int32)reader[((int)JobAreaColumn.JobAreaId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobAreaColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobAreaColumn.JobId - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobAreaColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobAreaColumn.JobArchiveId - 1)];
			entity.AreaId = (System.Int32)reader[((int)JobAreaColumn.AreaId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobArea"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobArea"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobArea entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobAreaId = (System.Int32)dataRow["JobAreaID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.AreaId = (System.Int32)dataRow["AreaID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobArea"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobArea Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobArea entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AreaIdSource	
			if (CanDeepLoad(entity, "Area|AreaIdSource", deepLoadType, innerList) 
				&& entity.AreaIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AreaId;
				Area tmpEntity = EntityManager.LocateEntity<Area>(EntityLocator.ConstructKeyFromPkItems(typeof(Area), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AreaIdSource = tmpEntity;
				else
					entity.AreaIdSource = DataRepository.AreaProvider.GetByAreaId(transactionManager, entity.AreaId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AreaIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AreaIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AreaProvider.DeepLoad(transactionManager, entity.AreaIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AreaIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobArea object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobArea instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobArea Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobArea entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AreaIdSource
			if (CanDeepSave(entity, "Area|AreaIdSource", deepSaveType, innerList) 
				&& entity.AreaIdSource != null)
			{
				DataRepository.AreaProvider.Save(transactionManager, entity.AreaIdSource);
				entity.AreaId = entity.AreaIdSource.AreaId;
			}
			#endregion 
			
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
	
	#region JobAreaChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobArea</c>
	///</summary>
	public enum JobAreaChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Area</c> at AreaIdSource
		///</summary>
		[ChildEntityType(typeof(Area))]
		Area,
			
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
		}
	
	#endregion JobAreaChildEntityTypes
	
	#region JobAreaFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaFilterBuilder : SqlFilterBuilder<JobAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaFilterBuilder class.
		/// </summary>
		public JobAreaFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAreaFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAreaFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAreaFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAreaFilterBuilder
	
	#region JobAreaParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaParameterBuilder : ParameterizedSqlFilterBuilder<JobAreaColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaParameterBuilder class.
		/// </summary>
		public JobAreaParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAreaParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAreaParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAreaParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAreaParameterBuilder
	
	#region JobAreaSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobAreaColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobAreaSortBuilder : SqlSortBuilder<JobAreaColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaSqlSortBuilder class.
		/// </summary>
		public JobAreaSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobAreaSortBuilder
	
} // end namespace
