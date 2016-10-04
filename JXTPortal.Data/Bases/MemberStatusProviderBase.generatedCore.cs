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
	/// This class is the base class for any <see cref="MemberStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MemberStatusProviderBaseCore : EntityProviderBase<JXTPortal.Entities.MemberStatus, JXTPortal.Entities.MemberStatusKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MemberStatusKey key)
		{
			return Delete(transactionManager, key.MemberStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberStatusId)
		{
			return Delete(null, _memberStatusId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberStatusId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberStatusId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		FK__MemberSta__LastM__57A05EFD Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		FK__MemberSta__LastM__57A05EFD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		/// <remarks></remarks>
		public TList<MemberStatus> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		FK__MemberSta__LastM__57A05EFD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		fkMemberStaLastm57a05Efd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		fkMemberStaLastm57a05Efd Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__LastM__57A05EFD key.
		///		FK__MemberSta__LastM__57A05EFD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public abstract TList<MemberStatus> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		FK__MemberSta__SiteI__58948336 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetBySiteId(System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		FK__MemberSta__SiteI__58948336 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		/// <remarks></remarks>
		public TList<MemberStatus> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		FK__MemberSta__SiteI__58948336 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		fkMemberStaSitei58948336 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetBySiteId(System.Int32? _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		fkMemberStaSitei58948336 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public TList<MemberStatus> GetBySiteId(System.Int32? _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__MemberSta__SiteI__58948336 key.
		///		FK__MemberSta__SiteI__58948336 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.MemberStatus objects.</returns>
		public abstract TList<MemberStatus> GetBySiteId(TransactionManager transactionManager, System.Int32? _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.MemberStatus Get(TransactionManager transactionManager, JXTPortal.Entities.MemberStatusKey key, int start, int pageLength)
		{
			return GetByMemberStatusId(transactionManager, key.MemberStatusId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="_memberStatusId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public JXTPortal.Entities.MemberStatus GetByMemberStatusId(System.Int32 _memberStatusId)
		{
			int count = -1;
			return GetByMemberStatusId(null,_memberStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="_memberStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public JXTPortal.Entities.MemberStatus GetByMemberStatusId(System.Int32 _memberStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberStatusId(null, _memberStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public JXTPortal.Entities.MemberStatus GetByMemberStatusId(TransactionManager transactionManager, System.Int32 _memberStatusId)
		{
			int count = -1;
			return GetByMemberStatusId(transactionManager, _memberStatusId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public JXTPortal.Entities.MemberStatus GetByMemberStatusId(TransactionManager transactionManager, System.Int32 _memberStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberStatusId(transactionManager, _memberStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="_memberStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public JXTPortal.Entities.MemberStatus GetByMemberStatusId(System.Int32 _memberStatusId, int start, int pageLength, out int count)
		{
			return GetByMemberStatusId(null, _memberStatusId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__MemberSt__53C4FDDC54C3F252 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.MemberStatus"/> class.</returns>
		public abstract JXTPortal.Entities.MemberStatus GetByMemberStatusId(TransactionManager transactionManager, System.Int32 _memberStatusId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region MemberStatus_Insert 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid, ref System.Int32? memberStatusId)
		{
			 Insert(null, 0, int.MaxValue , siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid, ref memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid, ref System.Int32? memberStatusId)
		{
			 Insert(null, start, pageLength , siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid, ref memberStatusId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid, ref System.Int32? memberStatusId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid, ref memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid, ref System.Int32? memberStatusId);
		
		#endregion
		
		#region MemberStatus_GetBySiteId 
		
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'MemberStatus_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region MemberStatus_Get_List 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Get_List' stored procedure. 
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
		///	This method wrap the 'MemberStatus_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region MemberStatus_GetByMemberStatusId 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByMemberStatusId' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberStatusId(System.Int32? memberStatusId)
		{
			return GetByMemberStatusId(null, 0, int.MaxValue , memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByMemberStatusId' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberStatusId(int start, int pageLength, System.Int32? memberStatusId)
		{
			return GetByMemberStatusId(null, start, pageLength , memberStatusId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByMemberStatusId' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberStatusId(TransactionManager transactionManager, System.Int32? memberStatusId)
		{
			return GetByMemberStatusId(transactionManager, 0, int.MaxValue , memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByMemberStatusId' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberStatusId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberStatusId);
		
		#endregion
		
		#region MemberStatus_CustomGetBySiteID 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberStatus&gt;"/> instance.</returns>
		public TList<MemberStatus> CustomGetBySiteID(System.Int32? siteId)
		{
			return CustomGetBySiteID(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberStatus&gt;"/> instance.</returns>
		public TList<MemberStatus> CustomGetBySiteID(int start, int pageLength, System.Int32? siteId)
		{
			return CustomGetBySiteID(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberStatus&gt;"/> instance.</returns>
		public TList<MemberStatus> CustomGetBySiteID(TransactionManager transactionManager, System.Int32? siteId)
		{
			return CustomGetBySiteID(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;MemberStatus&gt;"/> instance.</returns>
		public abstract TList<MemberStatus> CustomGetBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region MemberStatus_Update 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Update' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			 Update(null, 0, int.MaxValue , memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Update' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			 Update(null, start, pageLength , memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_Update' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			 Update(transactionManager, 0, int.MaxValue , memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Update' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid);
		
		#endregion
		
		#region MemberStatus_Find 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			return Find(null, start, pageLength , searchUsingOr, memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberStatusId, siteId, memberStatusName, lastModifiedBy, lastModified, sequence, valid);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="memberStatusName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberStatusId, System.Int32? siteId, System.String memberStatusName, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.Boolean? valid);
		
		#endregion
		
		#region MemberStatus_Delete 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberStatusId)
		{
			 Delete(null, 0, int.MaxValue , memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberStatusId)
		{
			 Delete(null, start, pageLength , memberStatusId);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberStatusId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberStatusId);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberStatusId);
		
		#endregion
		
		#region MemberStatus_GetPaged 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberStatus_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberStatus_GetPaged' stored procedure. 
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
		///	This method wrap the 'MemberStatus_GetPaged' stored procedure. 
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
		
		#region MemberStatus_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'MemberStatus_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MemberStatus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MemberStatus&gt;"/></returns>
		public static TList<MemberStatus> Fill(IDataReader reader, TList<MemberStatus> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.MemberStatus c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MemberStatus")
					.Append("|").Append((System.Int32)reader[((int)MemberStatusColumn.MemberStatusId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MemberStatus>(
					key.ToString(), // EntityTrackingKey
					"MemberStatus",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.MemberStatus();
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
					c.MemberStatusId = (System.Int32)reader[((int)MemberStatusColumn.MemberStatusId - 1)];
					c.SiteId = (reader.IsDBNull(((int)MemberStatusColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)MemberStatusColumn.SiteId - 1)];
					c.MemberStatusName = (System.String)reader[((int)MemberStatusColumn.MemberStatusName - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)MemberStatusColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)MemberStatusColumn.LastModified - 1)];
					c.Sequence = (System.Int32)reader[((int)MemberStatusColumn.Sequence - 1)];
					c.Valid = (System.Boolean)reader[((int)MemberStatusColumn.Valid - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberStatus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.MemberStatus entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberStatusId = (System.Int32)reader[((int)MemberStatusColumn.MemberStatusId - 1)];
			entity.SiteId = (reader.IsDBNull(((int)MemberStatusColumn.SiteId - 1)))?null:(System.Int32?)reader[((int)MemberStatusColumn.SiteId - 1)];
			entity.MemberStatusName = (System.String)reader[((int)MemberStatusColumn.MemberStatusName - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)MemberStatusColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)MemberStatusColumn.LastModified - 1)];
			entity.Sequence = (System.Int32)reader[((int)MemberStatusColumn.Sequence - 1)];
			entity.Valid = (System.Boolean)reader[((int)MemberStatusColumn.Valid - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.MemberStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberStatus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.MemberStatus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberStatusId = (System.Int32)dataRow["MemberStatusID"];
			entity.SiteId = Convert.IsDBNull(dataRow["SiteID"]) ? null : (System.Int32?)dataRow["SiteID"];
			entity.MemberStatusName = (System.String)dataRow["MemberStatusName"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.MemberStatus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberStatus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.MemberStatus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.MemberStatus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.MemberStatus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.MemberStatus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.MemberStatus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
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
	
	#region MemberStatusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.MemberStatus</c>
	///</summary>
	public enum MemberStatusChildEntityTypes
	{
		
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
		}
	
	#endregion MemberStatusChildEntityTypes
	
	#region MemberStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MemberStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusFilterBuilder : SqlFilterBuilder<MemberStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilterBuilder class.
		/// </summary>
		public MemberStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberStatusFilterBuilder
	
	#region MemberStatusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MemberStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusParameterBuilder : ParameterizedSqlFilterBuilder<MemberStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusParameterBuilder class.
		/// </summary>
		public MemberStatusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberStatusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberStatusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberStatusParameterBuilder
	
	#region MemberStatusSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MemberStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MemberStatusSortBuilder : SqlSortBuilder<MemberStatusColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusSqlSortBuilder class.
		/// </summary>
		public MemberStatusSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MemberStatusSortBuilder
	
} // end namespace
