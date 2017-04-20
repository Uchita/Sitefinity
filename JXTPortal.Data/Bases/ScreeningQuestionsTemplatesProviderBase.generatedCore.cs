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
	/// This class is the base class for any <see cref="ScreeningQuestionsTemplatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ScreeningQuestionsTemplatesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.ScreeningQuestionsTemplates, JXTPortal.Entities.ScreeningQuestionsTemplatesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplatesKey key)
		{
			return Delete(transactionManager, key.ScreeningQuestionsTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _screeningQuestionsTemplateId)
		{
			return Delete(null, _screeningQuestionsTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		FK__Screening__Creat__1E8A0076 Description: 
		/// </summary>
		/// <param name="_createdByAdvertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(System.Int32? _createdByAdvertiserId)
		{
			int count = -1;
			return GetByCreatedByAdvertiserId(_createdByAdvertiserId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		FK__Screening__Creat__1E8A0076 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_createdByAdvertiserId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(TransactionManager transactionManager, System.Int32? _createdByAdvertiserId)
		{
			int count = -1;
			return GetByCreatedByAdvertiserId(transactionManager, _createdByAdvertiserId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		FK__Screening__Creat__1E8A0076 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_createdByAdvertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(TransactionManager transactionManager, System.Int32? _createdByAdvertiserId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreatedByAdvertiserId(transactionManager, _createdByAdvertiserId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		fkScreeningCreat1e8a0076 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_createdByAdvertiserId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(System.Int32? _createdByAdvertiserId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCreatedByAdvertiserId(null, _createdByAdvertiserId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		fkScreeningCreat1e8a0076 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_createdByAdvertiserId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(System.Int32? _createdByAdvertiserId, int start, int pageLength,out int count)
		{
			return GetByCreatedByAdvertiserId(null, _createdByAdvertiserId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__Creat__1E8A0076 key.
		///		FK__Screening__Creat__1E8A0076 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_createdByAdvertiserId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public abstract TList<ScreeningQuestionsTemplates> GetByCreatedByAdvertiserId(TransactionManager transactionManager, System.Int32? _createdByAdvertiserId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		FK__Screening__LastM__7A4CA000 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		FK__Screening__LastM__7A4CA000 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		FK__Screening__LastM__7A4CA000 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		fkScreeningLastm7a4Ca000 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		fkScreeningLastm7a4Ca000 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__LastM__7A4CA000 key.
		///		FK__Screening__LastM__7A4CA000 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public abstract TList<ScreeningQuestionsTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		FK__Screening__SiteI__25549791 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		FK__Screening__SiteI__25549791 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<ScreeningQuestionsTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		FK__Screening__SiteI__25549791 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		fkScreeningSitei25549791 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		fkScreeningSitei25549791 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public TList<ScreeningQuestionsTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Screening__SiteI__25549791 key.
		///		FK__Screening__SiteI__25549791 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.ScreeningQuestionsTemplates objects.</returns>
		public abstract TList<ScreeningQuestionsTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.ScreeningQuestionsTemplates Get(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplatesKey key, int start, int pageLength)
		{
			return GetByScreeningQuestionsTemplateId(transactionManager, key.ScreeningQuestionsTemplateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(null,_screeningQuestionsTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByScreeningQuestionsTemplateId(transactionManager, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(System.Int32 _screeningQuestionsTemplateId, int start, int pageLength, out int count)
		{
			return GetByScreeningQuestionsTemplateId(null, _screeningQuestionsTemplateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Screenin__E518A093236C4F1F index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_screeningQuestionsTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> class.</returns>
		public abstract JXTPortal.Entities.ScreeningQuestionsTemplates GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32 _screeningQuestionsTemplateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region ScreeningQuestionsTemplates_Insert 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId, ref System.Int32? screeningQuestionsTemplateId)
		{
			 Insert(null, 0, int.MaxValue , templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId, ref screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId, ref System.Int32? screeningQuestionsTemplateId)
		{
			 Insert(null, start, pageLength , templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId, ref screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId, ref System.Int32? screeningQuestionsTemplateId)
		{
			 Insert(transactionManager, 0, int.MaxValue , templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId, ref screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId, ref System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_Get_List 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Get_List' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region ScreeningQuestionsTemplates_GetPaged 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetPaged' stored procedure. 
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
		
		#region ScreeningQuestionsTemplates_GetByScreeningQuestionsTemplateId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(null, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(int start, int pageLength, System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(null, start, pageLength , screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId)
		{
			return GetByScreeningQuestionsTemplateId(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByScreeningQuestionsTemplateId' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByScreeningQuestionsTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_GetByCreatedByAdvertiserId 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByCreatedByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCreatedByAdvertiserId(int start, int pageLength, System.Int32? createdByAdvertiserId)
		{
			return GetByCreatedByAdvertiserId(null, start, pageLength , createdByAdvertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByCreatedByAdvertiserId' stored procedure. 
		/// </summary>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCreatedByAdvertiserId(TransactionManager transactionManager, int start, int pageLength , System.Int32? createdByAdvertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_Update 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			 Update(null, 0, int.MaxValue , screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			 Update(null, start, pageLength , screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			 Update(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_Find 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			return Find(null, start, pageLength , searchUsingOr, screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, screeningQuestionsTemplateId, templateName, siteId, visible, lastModified, lastModifiedBy, createdByAdvertiserId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="templateName"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="createdByAdvertiserId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? screeningQuestionsTemplateId, System.String templateName, System.Int32? siteId, System.Boolean? visible, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Int32? createdByAdvertiserId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_Delete 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? screeningQuestionsTemplateId)
		{
			 Delete(null, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? screeningQuestionsTemplateId)
		{
			 Delete(null, start, pageLength , screeningQuestionsTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? screeningQuestionsTemplateId)
		{
			 Delete(transactionManager, 0, int.MaxValue , screeningQuestionsTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="screeningQuestionsTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? screeningQuestionsTemplateId);
		
		#endregion
		
		#region ScreeningQuestionsTemplates_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'ScreeningQuestionsTemplates_GetByLastModifiedBy' stored procedure. 
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
		/// Fill a TList&lt;ScreeningQuestionsTemplates&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ScreeningQuestionsTemplates&gt;"/></returns>
		public static TList<ScreeningQuestionsTemplates> Fill(IDataReader reader, TList<ScreeningQuestionsTemplates> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.ScreeningQuestionsTemplates c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ScreeningQuestionsTemplates")
					.Append("|").Append((System.Int32)reader[((int)ScreeningQuestionsTemplatesColumn.ScreeningQuestionsTemplateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ScreeningQuestionsTemplates>(
					key.ToString(), // EntityTrackingKey
					"ScreeningQuestionsTemplates",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.ScreeningQuestionsTemplates();
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
					c.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsTemplatesColumn.ScreeningQuestionsTemplateId - 1)];
					c.TemplateName = (System.String)reader[((int)ScreeningQuestionsTemplatesColumn.TemplateName - 1)];
					c.SiteId = (System.Int32)reader[((int)ScreeningQuestionsTemplatesColumn.SiteId - 1)];
					c.Visible = (System.Boolean)reader[((int)ScreeningQuestionsTemplatesColumn.Visible - 1)];
					c.LastModified = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ScreeningQuestionsTemplatesColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsTemplatesColumn.LastModifiedBy - 1)];
					c.CreatedByAdvertiserId = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.CreatedByAdvertiserId - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsTemplatesColumn.CreatedByAdvertiserId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.ScreeningQuestionsTemplates entity)
		{
			if (!reader.Read()) return;
			
			entity.ScreeningQuestionsTemplateId = (System.Int32)reader[((int)ScreeningQuestionsTemplatesColumn.ScreeningQuestionsTemplateId - 1)];
			entity.TemplateName = (System.String)reader[((int)ScreeningQuestionsTemplatesColumn.TemplateName - 1)];
			entity.SiteId = (System.Int32)reader[((int)ScreeningQuestionsTemplatesColumn.SiteId - 1)];
			entity.Visible = (System.Boolean)reader[((int)ScreeningQuestionsTemplatesColumn.Visible - 1)];
			entity.LastModified = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ScreeningQuestionsTemplatesColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsTemplatesColumn.LastModifiedBy - 1)];
			entity.CreatedByAdvertiserId = (reader.IsDBNull(((int)ScreeningQuestionsTemplatesColumn.CreatedByAdvertiserId - 1)))?null:(System.Int32?)reader[((int)ScreeningQuestionsTemplatesColumn.CreatedByAdvertiserId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.ScreeningQuestionsTemplates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ScreeningQuestionsTemplateId = (System.Int32)dataRow["ScreeningQuestionsTemplateId"];
			entity.TemplateName = (System.String)dataRow["TemplateName"];
			entity.SiteId = (System.Int32)dataRow["SiteId"];
			entity.Visible = (System.Boolean)dataRow["Visible"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.CreatedByAdvertiserId = Convert.IsDBNull(dataRow["CreatedByAdvertiserId"]) ? null : (System.Int32?)dataRow["CreatedByAdvertiserId"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.ScreeningQuestionsTemplates"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsTemplates Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplates entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CreatedByAdvertiserIdSource	
			if (CanDeepLoad(entity, "Advertisers|CreatedByAdvertiserIdSource", deepLoadType, innerList) 
				&& entity.CreatedByAdvertiserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CreatedByAdvertiserId ?? (int)0);
				Advertisers tmpEntity = EntityManager.LocateEntity<Advertisers>(EntityLocator.ConstructKeyFromPkItems(typeof(Advertisers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CreatedByAdvertiserIdSource = tmpEntity;
				else
					entity.CreatedByAdvertiserIdSource = DataRepository.AdvertisersProvider.GetByAdvertiserId(transactionManager, (entity.CreatedByAdvertiserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CreatedByAdvertiserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CreatedByAdvertiserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AdvertisersProvider.DeepLoad(transactionManager, entity.CreatedByAdvertiserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CreatedByAdvertiserIdSource

			#region LastModifiedBySource	
			if (CanDeepLoad(entity, "AdminUsers|LastModifiedBySource", deepLoadType, innerList) 
				&& entity.LastModifiedBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastModifiedBy ?? (int)0);
				AdminUsers tmpEntity = EntityManager.LocateEntity<AdminUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AdminUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastModifiedBySource = tmpEntity;
				else
					entity.LastModifiedBySource = DataRepository.AdminUsersProvider.GetByAdminUserId(transactionManager, (entity.LastModifiedBy ?? (int)0));		
				
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
			// Deep load child collections  - Call GetByScreeningQuestionsTemplateId methods when available
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetByScreeningQuestionsTemplateId(transactionManager, entity.ScreeningQuestionsTemplateId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ScreeningQuestionsMappingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ScreeningQuestionsMappings>|ScreeningQuestionsMappingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionsMappingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ScreeningQuestionsMappingsCollection = DataRepository.ScreeningQuestionsMappingsProvider.GetByScreeningQuestionsTemplateId(transactionManager, entity.ScreeningQuestionsTemplateId);

				if (deep && entity.ScreeningQuestionsMappingsCollection.Count > 0)
				{
					deepHandles.Add("ScreeningQuestionsMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ScreeningQuestionsMappings>) DataRepository.ScreeningQuestionsMappingsProvider.DeepLoad,
						new object[] { transactionManager, entity.ScreeningQuestionsMappingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ScreeningQuestionsTemplateOwnersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ScreeningQuestionsTemplateOwners>|ScreeningQuestionsTemplateOwnersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionsTemplateOwnersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ScreeningQuestionsTemplateOwnersCollection = DataRepository.ScreeningQuestionsTemplateOwnersProvider.GetByScreeningQuestionsTemplateId(transactionManager, entity.ScreeningQuestionsTemplateId);

				if (deep && entity.ScreeningQuestionsTemplateOwnersCollection.Count > 0)
				{
					deepHandles.Add("ScreeningQuestionsTemplateOwnersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ScreeningQuestionsTemplateOwners>) DataRepository.ScreeningQuestionsTemplateOwnersProvider.DeepLoad,
						new object[] { transactionManager, entity.ScreeningQuestionsTemplateOwnersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.ScreeningQuestionsTemplates object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.ScreeningQuestionsTemplates instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.ScreeningQuestionsTemplates Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.ScreeningQuestionsTemplates entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CreatedByAdvertiserIdSource
			if (CanDeepSave(entity, "Advertisers|CreatedByAdvertiserIdSource", deepSaveType, innerList) 
				&& entity.CreatedByAdvertiserIdSource != null)
			{
				DataRepository.AdvertisersProvider.Save(transactionManager, entity.CreatedByAdvertiserIdSource);
				entity.CreatedByAdvertiserId = entity.CreatedByAdvertiserIdSource.AdvertiserId;
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
						if(child.ScreeningQuestionsTemplateIdSource != null)
						{
							child.ScreeningQuestionsTemplateId = child.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
						}
						else
						{
							child.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateId;
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
				
	
			#region List<ScreeningQuestionsMappings>
				if (CanDeepSave(entity.ScreeningQuestionsMappingsCollection, "List<ScreeningQuestionsMappings>|ScreeningQuestionsMappingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ScreeningQuestionsMappings child in entity.ScreeningQuestionsMappingsCollection)
					{
						if(child.ScreeningQuestionsTemplateIdSource != null)
						{
							child.ScreeningQuestionsTemplateId = child.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
						}
						else
						{
							child.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateId;
						}

					}

					if (entity.ScreeningQuestionsMappingsCollection.Count > 0 || entity.ScreeningQuestionsMappingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ScreeningQuestionsMappingsProvider.Save(transactionManager, entity.ScreeningQuestionsMappingsCollection);
						
						deepHandles.Add("ScreeningQuestionsMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ScreeningQuestionsMappings >) DataRepository.ScreeningQuestionsMappingsProvider.DeepSave,
							new object[] { transactionManager, entity.ScreeningQuestionsMappingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ScreeningQuestionsTemplateOwners>
				if (CanDeepSave(entity.ScreeningQuestionsTemplateOwnersCollection, "List<ScreeningQuestionsTemplateOwners>|ScreeningQuestionsTemplateOwnersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ScreeningQuestionsTemplateOwners child in entity.ScreeningQuestionsTemplateOwnersCollection)
					{
						if(child.ScreeningQuestionsTemplateIdSource != null)
						{
							child.ScreeningQuestionsTemplateId = child.ScreeningQuestionsTemplateIdSource.ScreeningQuestionsTemplateId;
						}
						else
						{
							child.ScreeningQuestionsTemplateId = entity.ScreeningQuestionsTemplateId;
						}

					}

					if (entity.ScreeningQuestionsTemplateOwnersCollection.Count > 0 || entity.ScreeningQuestionsTemplateOwnersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ScreeningQuestionsTemplateOwnersProvider.Save(transactionManager, entity.ScreeningQuestionsTemplateOwnersCollection);
						
						deepHandles.Add("ScreeningQuestionsTemplateOwnersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ScreeningQuestionsTemplateOwners >) DataRepository.ScreeningQuestionsTemplateOwnersProvider.DeepSave,
							new object[] { transactionManager, entity.ScreeningQuestionsTemplateOwnersCollection, deepSaveType, childTypes, innerList }
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
	
	#region ScreeningQuestionsTemplatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.ScreeningQuestionsTemplates</c>
	///</summary>
	public enum ScreeningQuestionsTemplatesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Advertisers</c> at CreatedByAdvertiserIdSource
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
		/// Collection of <c>ScreeningQuestionsTemplates</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>ScreeningQuestionsTemplates</c> as OneToMany for ScreeningQuestionsMappingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<ScreeningQuestionsMappings>))]
		ScreeningQuestionsMappingsCollection,

		///<summary>
		/// Collection of <c>ScreeningQuestionsTemplates</c> as OneToMany for ScreeningQuestionsTemplateOwnersCollection
		///</summary>
		[ChildEntityType(typeof(TList<ScreeningQuestionsTemplateOwners>))]
		ScreeningQuestionsTemplateOwnersCollection,
	}
	
	#endregion ScreeningQuestionsTemplatesChildEntityTypes
	
	#region ScreeningQuestionsTemplatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ScreeningQuestionsTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplatesFilterBuilder : SqlFilterBuilder<ScreeningQuestionsTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilterBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplatesFilterBuilder
	
	#region ScreeningQuestionsTemplatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ScreeningQuestionsTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplatesParameterBuilder : ParameterizedSqlFilterBuilder<ScreeningQuestionsTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesParameterBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplatesParameterBuilder
	
	#region ScreeningQuestionsTemplatesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ScreeningQuestionsTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplates"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ScreeningQuestionsTemplatesSortBuilder : SqlSortBuilder<ScreeningQuestionsTemplatesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesSqlSortBuilder class.
		/// </summary>
		public ScreeningQuestionsTemplatesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ScreeningQuestionsTemplatesSortBuilder
	
} // end namespace
