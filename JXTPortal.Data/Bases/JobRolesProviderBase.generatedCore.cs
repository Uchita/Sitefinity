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
	/// This class is the base class for any <see cref="JobRolesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class JobRolesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.JobRoles, JXTPortal.Entities.JobRolesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.JobRolesKey key)
		{
			return Delete(transactionManager, key.JobRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_jobRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _jobRoleId)
		{
			return Delete(null, _jobRoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobRoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _jobRoleId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		FK__JobRoles__JobArc__1471E42F Description: 
		/// </summary>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobArchiveId(System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(_jobArchiveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		FK__JobRoles__JobArc__1471E42F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		/// <remarks></remarks>
		public TList<JobRoles> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		FK__JobRoles__JobArc__1471E42F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobArchiveId(transactionManager, _jobArchiveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		fkJobRolesJobArc1471e42f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		fkJobRolesJobArc1471e42f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobArchiveId(System.Int32? _jobArchiveId, int start, int pageLength,out int count)
		{
			return GetByJobArchiveId(null, _jobArchiveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobArc__1471E42F key.
		///		FK__JobRoles__JobArc__1471E42F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobArchiveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public abstract TList<JobRoles> GetByJobArchiveId(TransactionManager transactionManager, System.Int32? _jobArchiveId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		FK__JobRoles__JobID__137DBFF6 Description: 
		/// </summary>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobId(System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(_jobId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		FK__JobRoles__JobID__137DBFF6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		/// <remarks></remarks>
		public TList<JobRoles> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		FK__JobRoles__JobID__137DBFF6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobId(transactionManager, _jobId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		fkJobRolesJobId137Dbff6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobId(System.Int32? _jobId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobId(null, _jobId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		fkJobRolesJobId137Dbff6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByJobId(System.Int32? _jobId, int start, int pageLength,out int count)
		{
			return GetByJobId(null, _jobId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__JobID__137DBFF6 key.
		///		FK__JobRoles__JobID__137DBFF6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public abstract TList<JobRoles> GetByJobId(TransactionManager transactionManager, System.Int32? _jobId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		FK__JobRoles__RoleID__15660868 Description: 
		/// </summary>
		/// <param name="_roleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByRoleId(System.Int32? _roleId)
		{
			int count = -1;
			return GetByRoleId(_roleId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		FK__JobRoles__RoleID__15660868 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		/// <remarks></remarks>
		public TList<JobRoles> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		FK__JobRoles__RoleID__15660868 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		fkJobRolesRoleId15660868 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByRoleId(System.Int32? _roleId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRoleId(null, _roleId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		fkJobRolesRoleId15660868 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public TList<JobRoles> GetByRoleId(System.Int32? _roleId, int start, int pageLength,out int count)
		{
			return GetByRoleId(null, _roleId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__JobRoles__RoleID__15660868 key.
		///		FK__JobRoles__RoleID__15660868 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.JobRoles objects.</returns>
		public abstract TList<JobRoles> GetByRoleId(TransactionManager transactionManager, System.Int32? _roleId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.JobRoles Get(TransactionManager transactionManager, JXTPortal.Entities.JobRolesKey key, int start, int pageLength)
		{
			return GetByJobRoleId(transactionManager, key.JobRoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="_jobRoleId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public JXTPortal.Entities.JobRoles GetByJobRoleId(System.Int32 _jobRoleId)
		{
			int count = -1;
			return GetByJobRoleId(null,_jobRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="_jobRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public JXTPortal.Entities.JobRoles GetByJobRoleId(System.Int32 _jobRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobRoleId(null, _jobRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobRoleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public JXTPortal.Entities.JobRoles GetByJobRoleId(TransactionManager transactionManager, System.Int32 _jobRoleId)
		{
			int count = -1;
			return GetByJobRoleId(transactionManager, _jobRoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public JXTPortal.Entities.JobRoles GetByJobRoleId(TransactionManager transactionManager, System.Int32 _jobRoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobRoleId(transactionManager, _jobRoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="_jobRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public JXTPortal.Entities.JobRoles GetByJobRoleId(System.Int32 _jobRoleId, int start, int pageLength, out int count)
		{
			return GetByJobRoleId(null, _jobRoleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__JobRoles__12899BBD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobRoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.JobRoles"/> class.</returns>
		public abstract JXTPortal.Entities.JobRoles GetByJobRoleId(TransactionManager transactionManager, System.Int32 _jobRoleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region JobRoles_Insert 
		
		/// <summary>
		///	This method wrap the 'JobRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId, ref System.Int32? jobRoleId)
		{
			 Insert(null, 0, int.MaxValue , jobId, jobArchiveId, roleId, ref jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId, ref System.Int32? jobRoleId)
		{
			 Insert(null, start, pageLength , jobId, jobArchiveId, roleId, ref jobRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId, ref System.Int32? jobRoleId)
		{
			 Insert(transactionManager, 0, int.MaxValue , jobId, jobArchiveId, roleId, ref jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Insert' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId, ref System.Int32? jobRoleId);
		
		#endregion
		
		#region JobRoles_GetByJobId 
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobId(int start, int pageLength, System.Int32? jobId)
		{
			return GetByJobId(null, start, pageLength , jobId);
		}
				
				
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetByJobId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId);
		
		#endregion
		
		#region JobRoles_GetByJobRoleId 
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobRoleId' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobRoleId(System.Int32? jobRoleId)
		{
			return GetByJobRoleId(null, 0, int.MaxValue , jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobRoleId' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobRoleId(int start, int pageLength, System.Int32? jobRoleId)
		{
			return GetByJobRoleId(null, start, pageLength , jobRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobRoleId' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobRoleId(TransactionManager transactionManager, System.Int32? jobRoleId)
		{
			return GetByJobRoleId(transactionManager, 0, int.MaxValue , jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobRoleId' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetByJobRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobRoleId);
		
		#endregion
		
		#region JobRoles_Get_List 
		
		/// <summary>
		///	This method wrap the 'JobRoles_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region JobRoles_GetPaged 
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region JobRoles_GetByRoleId 
		
			
		/// <summary>
		///	This method wrap the 'JobRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByRoleId(int start, int pageLength, System.Int32? roleId)
		{
			return GetByRoleId(null, start, pageLength , roleId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByRoleId' stored procedure. 
		/// </summary>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetByRoleId(TransactionManager transactionManager, int start, int pageLength , System.Int32? roleId);
		
		#endregion
		
		#region JobRoles_Update 
		
		/// <summary>
		///	This method wrap the 'JobRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			 Update(null, 0, int.MaxValue , jobRoleId, jobId, jobArchiveId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			 Update(null, start, pageLength , jobRoleId, jobId, jobArchiveId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			 Update(transactionManager, 0, int.MaxValue , jobRoleId, jobId, jobArchiveId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Update' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId);
		
		#endregion
		
		#region JobRoles_Find 
		
		/// <summary>
		///	This method wrap the 'JobRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Find(System.Boolean? searchUsingOr, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, jobRoleId, jobId, jobArchiveId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			return Find(null, start, pageLength , searchUsingOr, jobRoleId, jobId, jobArchiveId, roleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, jobRoleId, jobId, jobArchiveId, roleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="roleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? jobRoleId, System.Int32? jobId, System.Int32? jobArchiveId, System.Int32? roleId);
		
		#endregion
		
		#region JobRoles_Delete 
		
		/// <summary>
		///	This method wrap the 'JobRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? jobRoleId)
		{
			 Delete(null, 0, int.MaxValue , jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? jobRoleId)
		{
			 Delete(null, start, pageLength , jobRoleId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? jobRoleId)
		{
			 Delete(transactionManager, 0, int.MaxValue , jobRoleId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_Delete' stored procedure. 
		/// </summary>
		/// <param name="jobRoleId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobRoleId);
		
		#endregion
		
		#region JobRoles_GetByJobArchiveId 
		
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobArchiveId(int start, int pageLength, System.Int32? jobArchiveId)
		{
			return GetByJobArchiveId(null, start, pageLength , jobArchiveId);
		}
				
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobArchiveId' stored procedure. 
		/// </summary>
		/// <param name="jobArchiveId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetByJobArchiveId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobArchiveId);
		
		#endregion
		
		#region JobRoles_GetByJobIdProfessionId 
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobIdProfessionId(System.Int32? jobId, System.Int32? professionId)
		{
			return GetByJobIdProfessionId(null, 0, int.MaxValue , jobId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobIdProfessionId(int start, int pageLength, System.Int32? jobId, System.Int32? professionId)
		{
			return GetByJobIdProfessionId(null, start, pageLength , jobId, professionId);
		}
				
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public TList<JobRoles> GetByJobIdProfessionId(TransactionManager transactionManager, System.Int32? jobId, System.Int32? professionId)
		{
			return GetByJobIdProfessionId(transactionManager, 0, int.MaxValue , jobId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'JobRoles_GetByJobIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="jobId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;JobRoles&gt;"/> instance.</returns>
		public abstract TList<JobRoles> GetByJobIdProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? jobId, System.Int32? professionId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;JobRoles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;JobRoles&gt;"/></returns>
		public static TList<JobRoles> Fill(IDataReader reader, TList<JobRoles> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.JobRoles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("JobRoles")
					.Append("|").Append((System.Int32)reader[((int)JobRolesColumn.JobRoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<JobRoles>(
					key.ToString(), // EntityTrackingKey
					"JobRoles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.JobRoles();
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
					c.JobRoleId = (System.Int32)reader[((int)JobRolesColumn.JobRoleId - 1)];
					c.JobId = (reader.IsDBNull(((int)JobRolesColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.JobId - 1)];
					c.JobArchiveId = (reader.IsDBNull(((int)JobRolesColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.JobArchiveId - 1)];
					c.RoleId = (reader.IsDBNull(((int)JobRolesColumn.RoleId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.RoleId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobRoles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobRoles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.JobRoles entity)
		{
			if (!reader.Read()) return;
			
			entity.JobRoleId = (System.Int32)reader[((int)JobRolesColumn.JobRoleId - 1)];
			entity.JobId = (reader.IsDBNull(((int)JobRolesColumn.JobId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.JobId - 1)];
			entity.JobArchiveId = (reader.IsDBNull(((int)JobRolesColumn.JobArchiveId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.JobArchiveId - 1)];
			entity.RoleId = (reader.IsDBNull(((int)JobRolesColumn.RoleId - 1)))?null:(System.Int32?)reader[((int)JobRolesColumn.RoleId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.JobRoles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobRoles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.JobRoles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.JobRoleId = (System.Int32)dataRow["JobRoleID"];
			entity.JobId = Convert.IsDBNull(dataRow["JobID"]) ? null : (System.Int32?)dataRow["JobID"];
			entity.JobArchiveId = Convert.IsDBNull(dataRow["JobArchiveID"]) ? null : (System.Int32?)dataRow["JobArchiveID"];
			entity.RoleId = Convert.IsDBNull(dataRow["RoleID"]) ? null : (System.Int32?)dataRow["RoleID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.JobRoles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobRoles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.JobRoles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region RoleIdSource	
			if (CanDeepLoad(entity, "Roles|RoleIdSource", deepLoadType, innerList) 
				&& entity.RoleIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.RoleId ?? (int)0);
				Roles tmpEntity = EntityManager.LocateEntity<Roles>(EntityLocator.ConstructKeyFromPkItems(typeof(Roles), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RoleIdSource = tmpEntity;
				else
					entity.RoleIdSource = DataRepository.RolesProvider.GetByRoleId(transactionManager, (entity.RoleId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RoleIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RoleIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RolesProvider.DeepLoad(transactionManager, entity.RoleIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RoleIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.JobRoles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.JobRoles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.JobRoles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.JobRoles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region RoleIdSource
			if (CanDeepSave(entity, "Roles|RoleIdSource", deepSaveType, innerList) 
				&& entity.RoleIdSource != null)
			{
				DataRepository.RolesProvider.Save(transactionManager, entity.RoleIdSource);
				entity.RoleId = entity.RoleIdSource.RoleId;
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
	
	#region JobRolesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.JobRoles</c>
	///</summary>
	public enum JobRolesChildEntityTypes
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
		/// Composite Property for <c>Roles</c> at RoleIdSource
		///</summary>
		[ChildEntityType(typeof(Roles))]
		Roles,
		}
	
	#endregion JobRolesChildEntityTypes
	
	#region JobRolesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;JobRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesFilterBuilder : SqlFilterBuilder<JobRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesFilterBuilder class.
		/// </summary>
		public JobRolesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobRolesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobRolesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobRolesFilterBuilder
	
	#region JobRolesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;JobRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesParameterBuilder : ParameterizedSqlFilterBuilder<JobRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesParameterBuilder class.
		/// </summary>
		public JobRolesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobRolesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobRolesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobRolesParameterBuilder
	
	#region JobRolesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;JobRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class JobRolesSortBuilder : SqlSortBuilder<JobRolesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesSqlSortBuilder class.
		/// </summary>
		public JobRolesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion JobRolesSortBuilder
	
} // end namespace
