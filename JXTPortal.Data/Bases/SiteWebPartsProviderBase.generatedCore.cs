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
	/// This class is the base class for any <see cref="SiteWebPartsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteWebPartsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteWebParts, JXTPortal.Entities.SiteWebPartsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartsKey key)
		{
			return Delete(transactionManager, key.SiteWebPartId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteWebPartId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteWebPartId)
		{
			return Delete(null, _siteWebPartId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteWebPartId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		FK__SiteWebPa__SiteI__1446FBA6 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		FK__SiteWebPa__SiteI__1446FBA6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		/// <remarks></remarks>
		public TList<SiteWebParts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		FK__SiteWebPa__SiteI__1446FBA6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		fkSiteWebPaSitei1446Fba6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		fkSiteWebPaSitei1446Fba6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteI__1446FBA6 key.
		///		FK__SiteWebPa__SiteI__1446FBA6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public abstract TList<SiteWebParts> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		FK__SiteWebPa__SiteW__02FC7413 Description: 
		/// </summary>
		/// <param name="_siteWebPartTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(_siteWebPartTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		FK__SiteWebPa__SiteW__02FC7413 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		/// <remarks></remarks>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(transactionManager, _siteWebPartTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		FK__SiteWebPa__SiteW__02FC7413 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartTypeId(transactionManager, _siteWebPartTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		fkSiteWebPaSitew02Fc7413 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteWebPartTypeId(null, _siteWebPartTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		fkSiteWebPaSitew02Fc7413 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(System.Int32 _siteWebPartTypeId, int start, int pageLength,out int count)
		{
			return GetBySiteWebPartTypeId(null, _siteWebPartTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteWebPa__SiteW__02FC7413 key.
		///		FK__SiteWebPa__SiteW__02FC7413 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteWebParts objects.</returns>
		public abstract TList<SiteWebParts> GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32 _siteWebPartTypeId, int start, int pageLength, out int count);
		
		
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
		public override JXTPortal.Entities.SiteWebParts Get(TransactionManager transactionManager, JXTPortal.Entities.SiteWebPartsKey key, int start, int pageLength)
		{
			return GetBySiteWebPartId(transactionManager, key.SiteWebPartId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="_siteWebPartId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetBySiteWebPartId(null,_siteWebPartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartId(null, _siteWebPartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId)
		{
			int count = -1;
			return GetBySiteWebPartId(transactionManager, _siteWebPartId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteWebPartId(transactionManager, _siteWebPartId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(System.Int32 _siteWebPartId, int start, int pageLength, out int count)
		{
			return GetBySiteWebPartId(null, _siteWebPartId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteWebParts__33D4B598 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteWebPartId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteWebParts"/> class.</returns>
		public abstract JXTPortal.Entities.SiteWebParts GetBySiteWebPartId(TransactionManager transactionManager, System.Int32 _siteWebPartId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteWebParts_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId, ref System.Int32? siteWebPartId)
		{
			 Insert(null, 0, int.MaxValue , siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId, ref siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId, ref System.Int32? siteWebPartId)
		{
			 Insert(null, start, pageLength , siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId, ref siteWebPartId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId, ref System.Int32? siteWebPartId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId, ref siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId, ref System.Int32? siteWebPartId);
		
		#endregion
		
		#region SiteWebParts_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteWebParts_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteWebParts_GetByDynamicPageWebPartTemplatesLink 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageWebPartTemplatesLink' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageWebPartTemplatesLink(System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplatesLink(null, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageWebPartTemplatesLink' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageWebPartTemplatesLink(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplatesLink(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageWebPartTemplatesLink' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageWebPartTemplatesLink(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplatesLink(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageWebPartTemplatesLink' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageWebPartTemplatesLink(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region SiteWebParts_GetBySiteWebPartTypeId 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(null, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(int start, int pageLength, System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(null, start, pageLength , siteWebPartTypeId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartTypeId(TransactionManager transactionManager, System.Int32? siteWebPartTypeId)
		{
			return GetBySiteWebPartTypeId(transactionManager, 0, int.MaxValue , siteWebPartTypeId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartTypeId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> GetBySiteWebPartTypeId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartTypeId);
		
		#endregion
		
		#region SiteWebParts_GetByDynamicPageContainerID 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageContainerID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetByDynamicPageContainerID(System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageContainerID(null, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageContainerID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetByDynamicPageContainerID(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageContainerID(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageContainerID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetByDynamicPageContainerID(TransactionManager transactionManager, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageContainerID(transactionManager, 0, int.MaxValue , dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetByDynamicPageContainerID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> GetByDynamicPageContainerID(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region SiteWebParts_Find 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Find(System.Boolean? searchUsingOr, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId);
		
		#endregion
		
		#region SiteWebParts_GetBySiteWebPartId 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartId(System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(null, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartId(int start, int pageLength, System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(null, start, pageLength , siteWebPartId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetBySiteWebPartId(TransactionManager transactionManager, System.Int32? siteWebPartId)
		{
			return GetBySiteWebPartId(transactionManager, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetBySiteWebPartId' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> GetBySiteWebPartId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartId);
		
		#endregion
		
		#region SiteWebParts_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public TList<SiteWebParts> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteWebParts&gt;"/> instance.</returns>
		public abstract TList<SiteWebParts> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteWebParts_Update 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , siteWebPartId, siteId, siteWebPartName, siteWebPartTypeId, siteWebPartHtml, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Update' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartName"> A <c>System.String</c> instance.</param>
		/// <param name="siteWebPartTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteWebPartHtml"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartId, System.Int32? siteId, System.String siteWebPartName, System.Int32? siteWebPartTypeId, System.String siteWebPartHtml, System.Int32? sourceId);
		
		#endregion
		
		#region SiteWebParts_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteWebPartId)
		{
			 Delete(null, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteWebPartId)
		{
			 Delete(null, start, pageLength , siteWebPartId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteWebParts_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteWebPartId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteWebPartId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteWebParts_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteWebPartId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteWebPartId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteWebParts&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteWebParts&gt;"/></returns>
		public static TList<SiteWebParts> Fill(IDataReader reader, TList<SiteWebParts> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteWebParts c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteWebParts")
					.Append("|").Append((System.Int32)reader[((int)SiteWebPartsColumn.SiteWebPartId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteWebParts>(
					key.ToString(), // EntityTrackingKey
					"SiteWebParts",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteWebParts();
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
					c.SiteWebPartId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteWebPartId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteId - 1)];
					c.SiteWebPartName = (System.String)reader[((int)SiteWebPartsColumn.SiteWebPartName - 1)];
					c.SiteWebPartTypeId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteWebPartTypeId - 1)];
					c.SiteWebPartHtml = (reader.IsDBNull(((int)SiteWebPartsColumn.SiteWebPartHtml - 1)))?null:(System.String)reader[((int)SiteWebPartsColumn.SiteWebPartHtml - 1)];
					c.SourceId = (reader.IsDBNull(((int)SiteWebPartsColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)SiteWebPartsColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWebParts"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebParts"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteWebParts entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteWebPartId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteWebPartId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteId - 1)];
			entity.SiteWebPartName = (System.String)reader[((int)SiteWebPartsColumn.SiteWebPartName - 1)];
			entity.SiteWebPartTypeId = (System.Int32)reader[((int)SiteWebPartsColumn.SiteWebPartTypeId - 1)];
			entity.SiteWebPartHtml = (reader.IsDBNull(((int)SiteWebPartsColumn.SiteWebPartHtml - 1)))?null:(System.String)reader[((int)SiteWebPartsColumn.SiteWebPartHtml - 1)];
			entity.SourceId = (reader.IsDBNull(((int)SiteWebPartsColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)SiteWebPartsColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteWebParts"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebParts"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteWebParts entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteWebPartId = (System.Int32)dataRow["SiteWebPartID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.SiteWebPartName = (System.String)dataRow["SiteWebPartName"];
			entity.SiteWebPartTypeId = (System.Int32)dataRow["SiteWebPartTypeID"];
			entity.SiteWebPartHtml = Convert.IsDBNull(dataRow["SiteWebPartHTML"]) ? null : (System.String)dataRow["SiteWebPartHTML"];
			entity.SourceId = Convert.IsDBNull(dataRow["SourceID"]) ? null : (System.Int32?)dataRow["SourceID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteWebParts"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWebParts Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteWebParts entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region SiteWebPartTypeIdSource	
			if (CanDeepLoad(entity, "SiteWebPartTypes|SiteWebPartTypeIdSource", deepLoadType, innerList) 
				&& entity.SiteWebPartTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SiteWebPartTypeId;
				SiteWebPartTypes tmpEntity = EntityManager.LocateEntity<SiteWebPartTypes>(EntityLocator.ConstructKeyFromPkItems(typeof(SiteWebPartTypes), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteWebPartTypeIdSource = tmpEntity;
				else
					entity.SiteWebPartTypeIdSource = DataRepository.SiteWebPartTypesProvider.GetBySiteWebPartTypeId(transactionManager, entity.SiteWebPartTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteWebPartTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SiteWebPartTypesProvider.DeepLoad(transactionManager, entity.SiteWebPartTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteWebPartTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySiteWebPartId methods when available
			
			#region DynamicPageWebPartTemplatesLinkCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageWebPartTemplatesLink>|DynamicPageWebPartTemplatesLinkCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplatesLinkCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageWebPartTemplatesLinkCollection = DataRepository.DynamicPageWebPartTemplatesLinkProvider.GetBySiteWebPartId(transactionManager, entity.SiteWebPartId);

				if (deep && entity.DynamicPageWebPartTemplatesLinkCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageWebPartTemplatesLinkCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageWebPartTemplatesLink>) DataRepository.DynamicPageWebPartTemplatesLinkProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteWebParts object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteWebParts instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteWebParts Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteWebParts entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region SiteWebPartTypeIdSource
			if (CanDeepSave(entity, "SiteWebPartTypes|SiteWebPartTypeIdSource", deepSaveType, innerList) 
				&& entity.SiteWebPartTypeIdSource != null)
			{
				DataRepository.SiteWebPartTypesProvider.Save(transactionManager, entity.SiteWebPartTypeIdSource);
				entity.SiteWebPartTypeId = entity.SiteWebPartTypeIdSource.SiteWebPartTypeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<DynamicPageWebPartTemplatesLink>
				if (CanDeepSave(entity.DynamicPageWebPartTemplatesLinkCollection, "List<DynamicPageWebPartTemplatesLink>|DynamicPageWebPartTemplatesLinkCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageWebPartTemplatesLink child in entity.DynamicPageWebPartTemplatesLinkCollection)
					{
						if(child.SiteWebPartIdSource != null)
						{
							child.SiteWebPartId = child.SiteWebPartIdSource.SiteWebPartId;
						}
						else
						{
							child.SiteWebPartId = entity.SiteWebPartId;
						}

					}

					if (entity.DynamicPageWebPartTemplatesLinkCollection.Count > 0 || entity.DynamicPageWebPartTemplatesLinkCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageWebPartTemplatesLinkProvider.Save(transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection);
						
						deepHandles.Add("DynamicPageWebPartTemplatesLinkCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageWebPartTemplatesLink >) DataRepository.DynamicPageWebPartTemplatesLinkProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageWebPartTemplatesLinkCollection, deepSaveType, childTypes, innerList }
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
	
	#region SiteWebPartsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteWebParts</c>
	///</summary>
	public enum SiteWebPartsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
			
		///<summary>
		/// Composite Property for <c>SiteWebPartTypes</c> at SiteWebPartTypeIdSource
		///</summary>
		[ChildEntityType(typeof(SiteWebPartTypes))]
		SiteWebPartTypes,
	
		///<summary>
		/// Collection of <c>SiteWebParts</c> as OneToMany for DynamicPageWebPartTemplatesLinkCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageWebPartTemplatesLink>))]
		DynamicPageWebPartTemplatesLinkCollection,
	}
	
	#endregion SiteWebPartsChildEntityTypes
	
	#region SiteWebPartsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteWebPartsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsFilterBuilder : SqlFilterBuilder<SiteWebPartsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilterBuilder class.
		/// </summary>
		public SiteWebPartsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartsFilterBuilder
	
	#region SiteWebPartsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteWebPartsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsParameterBuilder : ParameterizedSqlFilterBuilder<SiteWebPartsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsParameterBuilder class.
		/// </summary>
		public SiteWebPartsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartsParameterBuilder
	
	#region SiteWebPartsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteWebPartsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteWebPartsSortBuilder : SqlSortBuilder<SiteWebPartsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsSqlSortBuilder class.
		/// </summary>
		public SiteWebPartsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteWebPartsSortBuilder
	
} // end namespace
