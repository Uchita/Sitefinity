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
	/// This class is the base class for any <see cref="CustomWidgetCssSelectorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomWidgetCssSelectorProviderBaseCore : EntityProviderBase<JXTPortal.Entities.CustomWidgetCssSelector, JXTPortal.Entities.CustomWidgetCssSelectorKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetCssSelectorKey key)
		{
			return Delete(transactionManager, key.CustomWidgetCssSelectorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customWidgetCssSelectorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customWidgetCssSelectorId)
		{
			return Delete(null, _customWidgetCssSelectorId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		FK__CustomWid__SiteI__3355AF8A Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		public TList<CustomWidgetCssSelector> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		FK__CustomWid__SiteI__3355AF8A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		/// <remarks></remarks>
		public TList<CustomWidgetCssSelector> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		FK__CustomWid__SiteI__3355AF8A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		public TList<CustomWidgetCssSelector> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		fkCustomWidSitei3355Af8a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		public TList<CustomWidgetCssSelector> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		fkCustomWidSitei3355Af8a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		public TList<CustomWidgetCssSelector> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__3355AF8A key.
		///		FK__CustomWid__SiteI__3355AF8A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidgetCssSelector objects.</returns>
		public abstract TList<CustomWidgetCssSelector> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.CustomWidgetCssSelector Get(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetCssSelectorKey key, int start, int pageLength)
		{
			return GetByCustomWidgetCssSelectorId(transactionManager, key.CustomWidgetCssSelectorId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(null,_customWidgetCssSelectorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(null, _customWidgetCssSelectorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(transactionManager, _customWidgetCssSelectorId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(transactionManager, _customWidgetCssSelectorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId, int start, int pageLength, out int count)
		{
			return GetByCustomWidgetCssSelectorId(null, _customWidgetCssSelectorId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__CF286719316D6718 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> class.</returns>
		public abstract JXTPortal.Entities.CustomWidgetCssSelector GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region CustomWidgetCSSSelector_Insert 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId, ref System.Int32? customWidgetCssSelectorId)
		{
			 Insert(null, 0, int.MaxValue , siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId, ref customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId, ref System.Int32? customWidgetCssSelectorId)
		{
			 Insert(null, start, pageLength , siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId, ref customWidgetCssSelectorId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId, ref System.Int32? customWidgetCssSelectorId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId, ref customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId, ref System.Int32? customWidgetCssSelectorId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_GetByCustomWidgetCssSelectorId 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetCssSelectorId(System.Int32? customWidgetCssSelectorId)
		{
			return GetByCustomWidgetCssSelectorId(null, 0, int.MaxValue , customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetCssSelectorId(int start, int pageLength, System.Int32? customWidgetCssSelectorId)
		{
			return GetByCustomWidgetCssSelectorId(null, start, pageLength , customWidgetCssSelectorId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32? customWidgetCssSelectorId)
		{
			return GetByCustomWidgetCssSelectorId(transactionManager, 0, int.MaxValue , customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetCssSelectorId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_Get_List 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Get_List' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region CustomWidgetCSSSelector_GetPaged 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidgetCSSSelector_GetPaged' stored procedure. 
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
		
		#region CustomWidgetCSSSelector_Update 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_Find 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, customWidgetCssSelectorId, siteId, customWidgetCssSelectorName, customWidgetCssSelectorClassName, active, modifiedDate, modifiedBy, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorName"> A <c>System.String</c> instance.</param>
		/// <param name="customWidgetCssSelectorClassName"> A <c>System.String</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? customWidgetCssSelectorId, System.Int32? siteId, System.String customWidgetCssSelectorName, System.String customWidgetCssSelectorClassName, System.Boolean? active, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Int32? sourceId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_Delete 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? customWidgetCssSelectorId)
		{
			 Delete(null, 0, int.MaxValue , customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? customWidgetCssSelectorId)
		{
			 Delete(null, start, pageLength , customWidgetCssSelectorId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? customWidgetCssSelectorId)
		{
			 Delete(transactionManager, 0, int.MaxValue , customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetCssSelectorId);
		
		#endregion
		
		#region CustomWidgetCSSSelector_CustomGetBySiteID 
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(System.Int32? siteId)
		{
			return CustomGetBySiteID(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(int start, int pageLength, System.Int32? siteId)
		{
			return CustomGetBySiteID(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(TransactionManager transactionManager, System.Int32? siteId)
		{
			return CustomGetBySiteID(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidgetCSSSelector_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomWidgetCssSelector&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomWidgetCssSelector&gt;"/></returns>
		public static TList<CustomWidgetCssSelector> Fill(IDataReader reader, TList<CustomWidgetCssSelector> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.CustomWidgetCssSelector c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomWidgetCssSelector")
					.Append("|").Append((System.Int32)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomWidgetCssSelector>(
					key.ToString(), // EntityTrackingKey
					"CustomWidgetCssSelector",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.CustomWidgetCssSelector();
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
					c.CustomWidgetCssSelectorId = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorId - 1)];
					c.SiteId = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.SiteId - 1)];
					c.CustomWidgetCssSelectorName = (System.String)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorName - 1)];
					c.CustomWidgetCssSelectorClassName = (System.String)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorClassName - 1)];
					c.Active = (System.Boolean)reader[((int)CustomWidgetCssSelectorColumn.Active - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CustomWidgetCssSelectorColumn.ModifiedDate - 1)];
					c.ModifiedBy = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.ModifiedBy - 1)];
					c.SourceId = (reader.IsDBNull(((int)CustomWidgetCssSelectorColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)CustomWidgetCssSelectorColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.CustomWidgetCssSelector entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomWidgetCssSelectorId = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorId - 1)];
			entity.SiteId = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.SiteId - 1)];
			entity.CustomWidgetCssSelectorName = (System.String)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorName - 1)];
			entity.CustomWidgetCssSelectorClassName = (System.String)reader[((int)CustomWidgetCssSelectorColumn.CustomWidgetCssSelectorClassName - 1)];
			entity.Active = (System.Boolean)reader[((int)CustomWidgetCssSelectorColumn.Active - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CustomWidgetCssSelectorColumn.ModifiedDate - 1)];
			entity.ModifiedBy = (System.Int32)reader[((int)CustomWidgetCssSelectorColumn.ModifiedBy - 1)];
			entity.SourceId = (reader.IsDBNull(((int)CustomWidgetCssSelectorColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)CustomWidgetCssSelectorColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.CustomWidgetCssSelector entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomWidgetCssSelectorId = (System.Int32)dataRow["CustomWidgetCSSSelectorID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.CustomWidgetCssSelectorName = (System.String)dataRow["CustomWidgetCSSSelectorName"];
			entity.CustomWidgetCssSelectorClassName = (System.String)dataRow["CustomWidgetCSSSelectorClassName"];
			entity.Active = (System.Boolean)dataRow["Active"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
			entity.ModifiedBy = (System.Int32)dataRow["ModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidgetCssSelector"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomWidgetCssSelector Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetCssSelector entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			// Deep load child collections  - Call GetByCustomWidgetCssSelectorId methods when available
			
			#region CustomWidgetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomWidget>|CustomWidgetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomWidgetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomWidgetCollection = DataRepository.CustomWidgetProvider.GetByCustomWidgetCssSelectorId(transactionManager, entity.CustomWidgetCssSelectorId);

				if (deep && entity.CustomWidgetCollection.Count > 0)
				{
					deepHandles.Add("CustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomWidget>) DataRepository.CustomWidgetProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomWidgetCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.CustomWidgetCssSelector object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.CustomWidgetCssSelector instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomWidgetCssSelector Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetCssSelector entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CustomWidget>
				if (CanDeepSave(entity.CustomWidgetCollection, "List<CustomWidget>|CustomWidgetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomWidget child in entity.CustomWidgetCollection)
					{
						if(child.CustomWidgetCssSelectorIdSource != null)
						{
							child.CustomWidgetCssSelectorId = child.CustomWidgetCssSelectorIdSource.CustomWidgetCssSelectorId;
						}
						else
						{
							child.CustomWidgetCssSelectorId = entity.CustomWidgetCssSelectorId;
						}

					}

					if (entity.CustomWidgetCollection.Count > 0 || entity.CustomWidgetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomWidgetProvider.Save(transactionManager, entity.CustomWidgetCollection);
						
						deepHandles.Add("CustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomWidget >) DataRepository.CustomWidgetProvider.DeepSave,
							new object[] { transactionManager, entity.CustomWidgetCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomWidgetCssSelectorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.CustomWidgetCssSelector</c>
	///</summary>
	public enum CustomWidgetCssSelectorChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>CustomWidgetCssSelector</c> as OneToMany for CustomWidgetCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomWidget>))]
		CustomWidgetCollection,
	}
	
	#endregion CustomWidgetCssSelectorChildEntityTypes
	
	#region CustomWidgetCssSelectorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomWidgetCssSelectorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorFilterBuilder : SqlFilterBuilder<CustomWidgetCssSelectorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilterBuilder class.
		/// </summary>
		public CustomWidgetCssSelectorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetCssSelectorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetCssSelectorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetCssSelectorFilterBuilder
	
	#region CustomWidgetCssSelectorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomWidgetCssSelectorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorParameterBuilder : ParameterizedSqlFilterBuilder<CustomWidgetCssSelectorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorParameterBuilder class.
		/// </summary>
		public CustomWidgetCssSelectorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetCssSelectorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetCssSelectorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetCssSelectorParameterBuilder
	
	#region CustomWidgetCssSelectorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomWidgetCssSelectorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomWidgetCssSelectorSortBuilder : SqlSortBuilder<CustomWidgetCssSelectorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorSqlSortBuilder class.
		/// </summary>
		public CustomWidgetCssSelectorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomWidgetCssSelectorSortBuilder
	
} // end namespace
