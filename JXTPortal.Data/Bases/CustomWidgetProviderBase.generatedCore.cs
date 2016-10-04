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
	/// This class is the base class for any <see cref="CustomWidgetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomWidgetProviderBaseCore : EntityProviderBase<JXTPortal.Entities.CustomWidget, JXTPortal.Entities.CustomWidgetKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetKey key)
		{
			return Delete(transactionManager, key.CustomWidgetId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customWidgetId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customWidgetId)
		{
			return Delete(null, _customWidgetId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customWidgetId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		FK__CustomWid__Custo__3A02AD19 Description: 
		/// </summary>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(_customWidgetCssSelectorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		FK__CustomWid__Custo__3A02AD19 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		/// <remarks></remarks>
		public TList<CustomWidget> GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(transactionManager, _customWidgetCssSelectorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		FK__CustomWid__Custo__3A02AD19 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetCssSelectorId(transactionManager, _customWidgetCssSelectorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		fkCustomWidCusto3a02Ad19 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomWidgetCssSelectorId(null, _customWidgetCssSelectorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		fkCustomWidCusto3a02Ad19 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetByCustomWidgetCssSelectorId(System.Int32 _customWidgetCssSelectorId, int start, int pageLength,out int count)
		{
			return GetByCustomWidgetCssSelectorId(null, _customWidgetCssSelectorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__Custo__3A02AD19 key.
		///		FK__CustomWid__Custo__3A02AD19 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetCssSelectorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public abstract TList<CustomWidget> GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, System.Int32 _customWidgetCssSelectorId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		FK__CustomWid__SiteI__390E88E0 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		FK__CustomWid__SiteI__390E88E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		/// <remarks></remarks>
		public TList<CustomWidget> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		FK__CustomWid__SiteI__390E88E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		fkCustomWidSitei390e88e0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		fkCustomWidSitei390e88e0 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public TList<CustomWidget> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__CustomWid__SiteI__390E88E0 key.
		///		FK__CustomWid__SiteI__390E88E0 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomWidget objects.</returns>
		public abstract TList<CustomWidget> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.CustomWidget Get(TransactionManager transactionManager, JXTPortal.Entities.CustomWidgetKey key, int start, int pageLength)
		{
			return GetByCustomWidgetId(transactionManager, key.CustomWidgetId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="_customWidgetId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public JXTPortal.Entities.CustomWidget GetByCustomWidgetId(System.Int32 _customWidgetId)
		{
			int count = -1;
			return GetByCustomWidgetId(null,_customWidgetId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public JXTPortal.Entities.CustomWidget GetByCustomWidgetId(System.Int32 _customWidgetId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetId(null, _customWidgetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public JXTPortal.Entities.CustomWidget GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId)
		{
			int count = -1;
			return GetByCustomWidgetId(transactionManager, _customWidgetId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public JXTPortal.Entities.CustomWidget GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetId(transactionManager, _customWidgetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public JXTPortal.Entities.CustomWidget GetByCustomWidgetId(System.Int32 _customWidgetId, int start, int pageLength, out int count)
		{
			return GetByCustomWidgetId(null, _customWidgetId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__CustomWi__4C35670E3726406E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomWidget"/> class.</returns>
		public abstract JXTPortal.Entities.CustomWidget GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region CustomWidget_Insert 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId, ref System.Int32? customWidgetId)
		{
			 Insert(null, 0, int.MaxValue , siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId, ref customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId, ref System.Int32? customWidgetId)
		{
			 Insert(null, start, pageLength , siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId, ref customWidgetId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId, ref System.Int32? customWidgetId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId, ref customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId, ref System.Int32? customWidgetId);
		
		#endregion
		
		#region CustomWidget_GetByCustomWidgetCssSelectorId 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetCssSelectorId(System.Int32? customWidgetCssSelectorId)
		{
			return GetByCustomWidgetCssSelectorId(null, 0, int.MaxValue , customWidgetCssSelectorId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetCssSelectorId' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetByCustomWidgetCssSelectorId' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetByCustomWidgetCssSelectorId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCustomWidgetCssSelectorId(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetCssSelectorId);
		
		#endregion
		
		#region CustomWidget_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region CustomWidget_Get_List 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Get_List' stored procedure. 
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
		///	This method wrap the 'CustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region CustomWidget_GetPaged 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'CustomWidget_GetPaged' stored procedure. 
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
		
		#region CustomWidget_Update 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			 Update(null, 0, int.MaxValue , customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			 Update(null, start, pageLength , customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			 Update(transactionManager, 0, int.MaxValue , customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId);
		
		#endregion
		
		#region CustomWidget_GetByCustomWidgetId 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(null, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(int start, int pageLength, System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(null, start, pageLength , customWidgetId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(TransactionManager transactionManager, System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(transactionManager, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCustomWidgetId(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetId);
		
		#endregion
		
		#region CustomWidget_Find 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			return Find(null, start, pageLength , searchUsingOr, customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, customWidgetId, siteId, customWidgetCssSelectorId, customWidgetName, content, dateCreated, modifiedDate, modifiedBy, active, sourceId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetCssSelectorId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetName"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="dateCreated"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="modifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="active"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? customWidgetId, System.Int32? siteId, System.Int32? customWidgetCssSelectorId, System.String customWidgetName, System.String content, System.DateTime? dateCreated, System.DateTime? modifiedDate, System.Int32? modifiedBy, System.Boolean? active, System.Int32? sourceId);
		
		#endregion
		
		#region CustomWidget_Delete 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? customWidgetId)
		{
			 Delete(null, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? customWidgetId)
		{
			 Delete(null, start, pageLength , customWidgetId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? customWidgetId)
		{
			 Delete(transactionManager, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetId);
		
		#endregion
		
		#region CustomWidget_GetByDynamicPageIdFromDynamicpagesCustomWidget 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByDynamicPageIdFromDynamicpagesCustomWidget' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromDynamicpagesCustomWidget(System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromDynamicpagesCustomWidget(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByDynamicPageIdFromDynamicpagesCustomWidget' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromDynamicpagesCustomWidget(int start, int pageLength, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromDynamicpagesCustomWidget(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByDynamicPageIdFromDynamicpagesCustomWidget' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromDynamicpagesCustomWidget(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromDynamicpagesCustomWidget(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_GetByDynamicPageIdFromDynamicpagesCustomWidget' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageIdFromDynamicpagesCustomWidget(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region CustomWidget_CustomGetBySiteID 
		
		/// <summary>
		///	This method wrap the 'CustomWidget_CustomGetBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteID(System.Int32? siteId)
		{
			return CustomGetBySiteID(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'CustomWidget_CustomGetBySiteID' stored procedure. 
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
		///	This method wrap the 'CustomWidget_CustomGetBySiteID' stored procedure. 
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
		///	This method wrap the 'CustomWidget_CustomGetBySiteID' stored procedure. 
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
		/// Fill a TList&lt;CustomWidget&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomWidget&gt;"/></returns>
		public static TList<CustomWidget> Fill(IDataReader reader, TList<CustomWidget> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.CustomWidget c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomWidget")
					.Append("|").Append((System.Int32)reader[((int)CustomWidgetColumn.CustomWidgetId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomWidget>(
					key.ToString(), // EntityTrackingKey
					"CustomWidget",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.CustomWidget();
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
					c.CustomWidgetId = (System.Int32)reader[((int)CustomWidgetColumn.CustomWidgetId - 1)];
					c.SiteId = (System.Int32)reader[((int)CustomWidgetColumn.SiteId - 1)];
					c.CustomWidgetCssSelectorId = (System.Int32)reader[((int)CustomWidgetColumn.CustomWidgetCssSelectorId - 1)];
					c.CustomWidgetName = (System.String)reader[((int)CustomWidgetColumn.CustomWidgetName - 1)];
					c.Content = (System.String)reader[((int)CustomWidgetColumn.Content - 1)];
					c.DateCreated = (System.DateTime)reader[((int)CustomWidgetColumn.DateCreated - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)CustomWidgetColumn.ModifiedDate - 1)];
					c.ModifiedBy = (System.Int32)reader[((int)CustomWidgetColumn.ModifiedBy - 1)];
					c.Active = (System.Boolean)reader[((int)CustomWidgetColumn.Active - 1)];
					c.SourceId = (reader.IsDBNull(((int)CustomWidgetColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)CustomWidgetColumn.SourceId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomWidget"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidget"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.CustomWidget entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomWidgetId = (System.Int32)reader[((int)CustomWidgetColumn.CustomWidgetId - 1)];
			entity.SiteId = (System.Int32)reader[((int)CustomWidgetColumn.SiteId - 1)];
			entity.CustomWidgetCssSelectorId = (System.Int32)reader[((int)CustomWidgetColumn.CustomWidgetCssSelectorId - 1)];
			entity.CustomWidgetName = (System.String)reader[((int)CustomWidgetColumn.CustomWidgetName - 1)];
			entity.Content = (System.String)reader[((int)CustomWidgetColumn.Content - 1)];
			entity.DateCreated = (System.DateTime)reader[((int)CustomWidgetColumn.DateCreated - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)CustomWidgetColumn.ModifiedDate - 1)];
			entity.ModifiedBy = (System.Int32)reader[((int)CustomWidgetColumn.ModifiedBy - 1)];
			entity.Active = (System.Boolean)reader[((int)CustomWidgetColumn.Active - 1)];
			entity.SourceId = (reader.IsDBNull(((int)CustomWidgetColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)CustomWidgetColumn.SourceId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomWidget"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidget"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.CustomWidget entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomWidgetId = (System.Int32)dataRow["CustomWidgetID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.CustomWidgetCssSelectorId = (System.Int32)dataRow["CustomWidgetCSSSelectorID"];
			entity.CustomWidgetName = (System.String)dataRow["CustomWidgetName"];
			entity.Content = (System.String)dataRow["Content"];
			entity.DateCreated = (System.DateTime)dataRow["DateCreated"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
			entity.ModifiedBy = (System.Int32)dataRow["ModifiedBy"];
			entity.Active = (System.Boolean)dataRow["Active"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomWidget"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomWidget Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.CustomWidget entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomWidgetCssSelectorIdSource	
			if (CanDeepLoad(entity, "CustomWidgetCssSelector|CustomWidgetCssSelectorIdSource", deepLoadType, innerList) 
				&& entity.CustomWidgetCssSelectorIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomWidgetCssSelectorId;
				CustomWidgetCssSelector tmpEntity = EntityManager.LocateEntity<CustomWidgetCssSelector>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomWidgetCssSelector), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomWidgetCssSelectorIdSource = tmpEntity;
				else
					entity.CustomWidgetCssSelectorIdSource = DataRepository.CustomWidgetCssSelectorProvider.GetByCustomWidgetCssSelectorId(transactionManager, entity.CustomWidgetCssSelectorId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomWidgetCssSelectorIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomWidgetCssSelectorIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomWidgetCssSelectorProvider.DeepLoad(transactionManager, entity.CustomWidgetCssSelectorIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomWidgetCssSelectorIdSource

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
			// Deep load child collections  - Call GetByCustomWidgetId methods when available
			
			#region DynamicpagesCustomWidgetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicpagesCustomWidget>|DynamicpagesCustomWidgetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicpagesCustomWidgetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicpagesCustomWidgetCollection = DataRepository.DynamicpagesCustomWidgetProvider.GetByCustomWidgetId(transactionManager, entity.CustomWidgetId);

				if (deep && entity.DynamicpagesCustomWidgetCollection.Count > 0)
				{
					deepHandles.Add("DynamicpagesCustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicpagesCustomWidget>) DataRepository.DynamicpagesCustomWidgetProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicpagesCustomWidgetCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.CustomWidget object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.CustomWidget instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomWidget Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.CustomWidget entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomWidgetCssSelectorIdSource
			if (CanDeepSave(entity, "CustomWidgetCssSelector|CustomWidgetCssSelectorIdSource", deepSaveType, innerList) 
				&& entity.CustomWidgetCssSelectorIdSource != null)
			{
				DataRepository.CustomWidgetCssSelectorProvider.Save(transactionManager, entity.CustomWidgetCssSelectorIdSource);
				entity.CustomWidgetCssSelectorId = entity.CustomWidgetCssSelectorIdSource.CustomWidgetCssSelectorId;
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
	
			#region List<DynamicpagesCustomWidget>
				if (CanDeepSave(entity.DynamicpagesCustomWidgetCollection, "List<DynamicpagesCustomWidget>|DynamicpagesCustomWidgetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicpagesCustomWidget child in entity.DynamicpagesCustomWidgetCollection)
					{
						if(child.CustomWidgetIdSource != null)
						{
							child.CustomWidgetId = child.CustomWidgetIdSource.CustomWidgetId;
						}
						else
						{
							child.CustomWidgetId = entity.CustomWidgetId;
						}

					}

					if (entity.DynamicpagesCustomWidgetCollection.Count > 0 || entity.DynamicpagesCustomWidgetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicpagesCustomWidgetProvider.Save(transactionManager, entity.DynamicpagesCustomWidgetCollection);
						
						deepHandles.Add("DynamicpagesCustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicpagesCustomWidget >) DataRepository.DynamicpagesCustomWidgetProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicpagesCustomWidgetCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomWidgetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.CustomWidget</c>
	///</summary>
	public enum CustomWidgetChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CustomWidgetCssSelector</c> at CustomWidgetCssSelectorIdSource
		///</summary>
		[ChildEntityType(typeof(CustomWidgetCssSelector))]
		CustomWidgetCssSelector,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>CustomWidget</c> as OneToMany for DynamicpagesCustomWidgetCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicpagesCustomWidget>))]
		DynamicpagesCustomWidgetCollection,
	}
	
	#endregion CustomWidgetChildEntityTypes
	
	#region CustomWidgetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetFilterBuilder : SqlFilterBuilder<CustomWidgetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilterBuilder class.
		/// </summary>
		public CustomWidgetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetFilterBuilder
	
	#region CustomWidgetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetParameterBuilder : ParameterizedSqlFilterBuilder<CustomWidgetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetParameterBuilder class.
		/// </summary>
		public CustomWidgetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetParameterBuilder
	
	#region CustomWidgetSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomWidgetSortBuilder : SqlSortBuilder<CustomWidgetColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetSqlSortBuilder class.
		/// </summary>
		public CustomWidgetSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomWidgetSortBuilder
	
} // end namespace
