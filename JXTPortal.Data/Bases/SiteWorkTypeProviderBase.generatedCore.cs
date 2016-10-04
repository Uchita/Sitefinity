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
	/// This class is the base class for any <see cref="SiteWorkTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteWorkTypeProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteWorkType, JXTPortal.Entities.SiteWorkTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteWorkTypeKey key)
		{
			return Delete(transactionManager, key.SiteWorkTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteWorkTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteWorkTypeId)
		{
			return Delete(null, _siteWorkTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWorkTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteWorkTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		FK__SiteWorkT__SiteI__216BEC9A Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		FK__SiteWorkT__SiteI__216BEC9A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		/// <remarks></remarks>
		public TList<SiteWorkType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		FK__SiteWorkT__SiteI__216BEC9A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		fkSiteWorktSitei216Bec9a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		fkSiteWorktSitei216Bec9a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__SiteI__216BEC9A key.
		///		FK__SiteWorkT__SiteI__216BEC9A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public abstract TList<SiteWorkType> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		FK__SiteWorkT__WorkT__2077C861 Description: 
		/// </summary>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(_workTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		FK__SiteWorkT__WorkT__2077C861 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		/// <remarks></remarks>
		public TList<SiteWorkType> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		FK__SiteWorkT__WorkT__2077C861 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByWorkTypeId(transactionManager, _workTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		fkSiteWorktWorkt2077c861 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByWorkTypeId(null, _workTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		fkSiteWorktWorkt2077c861 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_workTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(System.Int32 _workTypeId, int start, int pageLength,out int count)
		{
			return GetByWorkTypeId(null, _workTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWorkT__WorkT__2077C861 key.
		///		FK__SiteWorkT__WorkT__2077C861 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_workTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWorkType objects.</returns>
		public abstract TList<SiteWorkType> GetByWorkTypeId(TransactionManager transactionManager, System.Int32 _workTypeId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteWorkType Get(TransactionManager transactionManager, JXTPortal.Entities.SiteWorkTypeKey key, int start, int pageLength)
		{
			return GetBySiteWorkTypeId(transactionManager, key.SiteWorkTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="_siteWorkTypeId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(System.Int32 _siteWorkTypeId)
		{
			int count = -1;
			return GetBySiteWorkTypeId(null,_siteWorkTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="_siteWorkTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(System.Int32 _siteWorkTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWorkTypeId(null, _siteWorkTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWorkTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(TransactionManager transactionManager, System.Int32 _siteWorkTypeId)
		{
			int count = -1;
			return GetBySiteWorkTypeId(transactionManager, _siteWorkTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWorkTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(TransactionManager transactionManager, System.Int32 _siteWorkTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWorkTypeId(transactionManager, _siteWorkTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="_siteWorkTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(System.Int32 _siteWorkTypeId, int start, int pageLength, out int count)
		{
			return GetBySiteWorkTypeId(null, _siteWorkTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SiteWo__17E28260 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWorkTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWorkType"/> class.</returns>
		public abstract JXTPortal.Entities.SiteWorkType GetBySiteWorkTypeId(TransactionManager transactionManager, System.Int32 _siteWorkTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteWorkType_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl, ref System.Int32? siteWorkTypeId)
		{
			 Insert(null, 0, int.MaxValue , siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl, ref siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl, ref System.Int32? siteWorkTypeId)
		{
			 Insert(null, start, pageLength , siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl, ref siteWorkTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl, ref System.Int32? siteWorkTypeId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl, ref siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl, ref System.Int32? siteWorkTypeId);
		
		#endregion
		
		#region SiteWorkType_GetByWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(int start, int pageLength, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(null, start, pageLength , workTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetByWorkTypeId(TransactionManager transactionManager, System.Int32? workTypeId)
		{
			return GetByWorkTypeId(transactionManager, 0, int.MaxValue , workTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetByWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> GetByWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? workTypeId);
		
		#endregion
		
		#region SiteWorkType_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteWorkType_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteWorkType_GetBySiteIdFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteIdFriendlyUrl(System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteIdFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, start, pageLength , siteId, friendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> GetBySiteIdFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String friendlyUrl);
		
		#endregion
		
		#region SiteWorkType_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteWorkType_GetBySiteWorkTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteWorkTypeId(System.Int32? siteWorkTypeId)
		{
			return GetBySiteWorkTypeId(null, 0, int.MaxValue , siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteWorkTypeId(int start, int pageLength, System.Int32? siteWorkTypeId)
		{
			return GetBySiteWorkTypeId(null, start, pageLength , siteWorkTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> GetBySiteWorkTypeId(TransactionManager transactionManager, System.Int32? siteWorkTypeId)
		{
			return GetBySiteWorkTypeId(transactionManager, 0, int.MaxValue , siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_GetBySiteWorkTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> GetBySiteWorkTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWorkTypeId);
		
		#endregion
		
		#region SiteWorkType_Find 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Find(System.Boolean? searchUsingOr, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public TList<SiteWorkType> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWorkType&gt;"/> instance.</returns>
		public abstract TList<SiteWorkType> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl);
		
		#endregion
		
		#region SiteWorkType_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteWorkTypeId)
		{
			 Delete(null, 0, int.MaxValue , siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteWorkTypeId)
		{
			 Delete(null, start, pageLength , siteWorkTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteWorkTypeId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteWorkTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWorkTypeId);
		
		#endregion
		
		#region SiteWorkType_Update 
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			 Update(null, 0, int.MaxValue , siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			 Update(null, start, pageLength , siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , siteWorkTypeId, siteId, workTypeId, siteWorkTypeName, valid, sequence, siteWorkTypeFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWorkType_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWorkTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWorkTypeFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWorkTypeId, System.Int32? siteId, System.Int32? workTypeId, System.String siteWorkTypeName, System.Boolean? valid, System.Int32? sequence, System.String siteWorkTypeFriendlyUrl);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteWorkType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteWorkType&gt;"/></returns>
		public static TList<SiteWorkType> Fill(IDataReader reader, TList<SiteWorkType> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteWorkType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteWorkType")
					.Append("|").Append((System.Int32)reader[((int)SiteWorkTypeColumn.SiteWorkTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteWorkType>(
					key.ToString(), // EntityTrackingKey
					"SiteWorkType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteWorkType();
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
					c.SiteWorkTypeId = (System.Int32)reader[((int)SiteWorkTypeColumn.SiteWorkTypeId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteWorkTypeColumn.SiteId - 1)];
					c.WorkTypeId = (System.Int32)reader[((int)SiteWorkTypeColumn.WorkTypeId - 1)];
					c.SiteWorkTypeName = (reader.IsDBNull(((int)SiteWorkTypeColumn.SiteWorkTypeName - 1)))?null:(System.String)reader[((int)SiteWorkTypeColumn.SiteWorkTypeName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteWorkTypeColumn.Valid - 1)];
					c.Sequence = (System.Int32)reader[((int)SiteWorkTypeColumn.Sequence - 1)];
					c.SiteWorkTypeFriendlyUrl = (reader.IsDBNull(((int)SiteWorkTypeColumn.SiteWorkTypeFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteWorkTypeColumn.SiteWorkTypeFriendlyUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWorkType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWorkType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteWorkType entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteWorkTypeId = (System.Int32)reader[((int)SiteWorkTypeColumn.SiteWorkTypeId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteWorkTypeColumn.SiteId - 1)];
			entity.WorkTypeId = (System.Int32)reader[((int)SiteWorkTypeColumn.WorkTypeId - 1)];
			entity.SiteWorkTypeName = (reader.IsDBNull(((int)SiteWorkTypeColumn.SiteWorkTypeName - 1)))?null:(System.String)reader[((int)SiteWorkTypeColumn.SiteWorkTypeName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteWorkTypeColumn.Valid - 1)];
			entity.Sequence = (System.Int32)reader[((int)SiteWorkTypeColumn.Sequence - 1)];
			entity.SiteWorkTypeFriendlyUrl = (reader.IsDBNull(((int)SiteWorkTypeColumn.SiteWorkTypeFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteWorkTypeColumn.SiteWorkTypeFriendlyUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWorkType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWorkType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteWorkType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteWorkTypeId = (System.Int32)dataRow["SiteWorkTypeID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.WorkTypeId = (System.Int32)dataRow["WorkTypeID"];
			entity.SiteWorkTypeName = Convert.IsDBNull(dataRow["SiteWorkTypeName"]) ? null : (System.String)dataRow["SiteWorkTypeName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.SiteWorkTypeFriendlyUrl = Convert.IsDBNull(dataRow["SiteWorkTypeFriendlyUrl"]) ? null : (System.String)dataRow["SiteWorkTypeFriendlyUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWorkType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWorkType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteWorkType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region WorkTypeIdSource	
			if (CanDeepLoad(entity, "WorkType|WorkTypeIdSource", deepLoadType, innerList) 
				&& entity.WorkTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.WorkTypeId;
				WorkType tmpEntity = EntityManager.LocateEntity<WorkType>(EntityLocator.ConstructKeyFromPkItems(typeof(WorkType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.WorkTypeIdSource = tmpEntity;
				else
					entity.WorkTypeIdSource = DataRepository.WorkTypeProvider.GetByWorkTypeId(transactionManager, entity.WorkTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WorkTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.WorkTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.WorkTypeProvider.DeepLoad(transactionManager, entity.WorkTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion WorkTypeIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteWorkType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteWorkType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWorkType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteWorkType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region WorkTypeIdSource
			if (CanDeepSave(entity, "WorkType|WorkTypeIdSource", deepSaveType, innerList) 
				&& entity.WorkTypeIdSource != null)
			{
				DataRepository.WorkTypeProvider.Save(transactionManager, entity.WorkTypeIdSource);
				entity.WorkTypeId = entity.WorkTypeIdSource.WorkTypeId;
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
	
	#region SiteWorkTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteWorkType</c>
	///</summary>
	public enum SiteWorkTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
			
		///<summary>
		/// Composite Property for <c>WorkType</c> at WorkTypeIdSource
		///</summary>
		[ChildEntityType(typeof(WorkType))]
		WorkType,
		}
	
	#endregion SiteWorkTypeChildEntityTypes
	
	#region SiteWorkTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteWorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeFilterBuilder : SqlFilterBuilder<SiteWorkTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilterBuilder class.
		/// </summary>
		public SiteWorkTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWorkTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWorkTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWorkTypeFilterBuilder
	
	#region SiteWorkTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteWorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeParameterBuilder : ParameterizedSqlFilterBuilder<SiteWorkTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeParameterBuilder class.
		/// </summary>
		public SiteWorkTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWorkTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWorkTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWorkTypeParameterBuilder
	
	#region SiteWorkTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteWorkTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteWorkTypeSortBuilder : SqlSortBuilder<SiteWorkTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeSqlSortBuilder class.
		/// </summary>
		public SiteWorkTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteWorkTypeSortBuilder
	
} // end namespace
