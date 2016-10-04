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
	/// This class is the base class for any <see cref="EnquiriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EnquiriesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Enquiries, JXTPortal.Entities.EnquiriesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.EnquiriesKey key)
		{
			return Delete(transactionManager, key.EnquiryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_enquiryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _enquiryId)
		{
			return Delete(null, _enquiryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_enquiryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _enquiryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		FK__Enquiries__SiteI__0D99FE17 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		public TList<Enquiries> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		FK__Enquiries__SiteI__0D99FE17 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		/// <remarks></remarks>
		public TList<Enquiries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		FK__Enquiries__SiteI__0D99FE17 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		public TList<Enquiries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		fkEnquiriesSitei0d99Fe17 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		public TList<Enquiries> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		fkEnquiriesSitei0d99Fe17 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		public TList<Enquiries> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Enquiries__SiteI__0D99FE17 key.
		///		FK__Enquiries__SiteI__0D99FE17 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Enquiries objects.</returns>
		public abstract TList<Enquiries> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Enquiries Get(TransactionManager transactionManager, JXTPortal.Entities.EnquiriesKey key, int start, int pageLength)
		{
			return GetByEnquiryId(transactionManager, key.EnquiryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="_enquiryId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public JXTPortal.Entities.Enquiries GetByEnquiryId(System.Int32 _enquiryId)
		{
			int count = -1;
			return GetByEnquiryId(null,_enquiryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="_enquiryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public JXTPortal.Entities.Enquiries GetByEnquiryId(System.Int32 _enquiryId, int start, int pageLength)
		{
			int count = -1;
			return GetByEnquiryId(null, _enquiryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_enquiryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public JXTPortal.Entities.Enquiries GetByEnquiryId(TransactionManager transactionManager, System.Int32 _enquiryId)
		{
			int count = -1;
			return GetByEnquiryId(transactionManager, _enquiryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_enquiryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public JXTPortal.Entities.Enquiries GetByEnquiryId(TransactionManager transactionManager, System.Int32 _enquiryId, int start, int pageLength)
		{
			int count = -1;
			return GetByEnquiryId(transactionManager, _enquiryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="_enquiryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public JXTPortal.Entities.Enquiries GetByEnquiryId(System.Int32 _enquiryId, int start, int pageLength, out int count)
		{
			return GetByEnquiryId(null, _enquiryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Enquiries__1920BF5C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_enquiryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Enquiries"/> class.</returns>
		public abstract JXTPortal.Entities.Enquiries GetByEnquiryId(TransactionManager transactionManager, System.Int32 _enquiryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Enquiries_Insert 
		
		/// <summary>
		///	This method wrap the 'Enquiries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
			/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress, ref System.Int32? enquiryId)
		{
			 Insert(null, 0, int.MaxValue , siteId, name, email, contactPhone, content, date, ipAddress, ref enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
			/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress, ref System.Int32? enquiryId)
		{
			 Insert(null, start, pageLength , siteId, name, email, contactPhone, content, date, ipAddress, ref enquiryId);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
			/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress, ref System.Int32? enquiryId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, name, email, contactPhone, content, date, ipAddress, ref enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
			/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress, ref System.Int32? enquiryId);
		
		#endregion
		
		#region Enquiries_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public abstract TList<Enquiries> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Enquiries_Get_List 
		
		/// <summary>
		///	This method wrap the 'Enquiries_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public abstract TList<Enquiries> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Enquiries_GetByEnquiryId 
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetByEnquiryId' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetByEnquiryId(System.Int32? enquiryId)
		{
			return GetByEnquiryId(null, 0, int.MaxValue , enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetByEnquiryId' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetByEnquiryId(int start, int pageLength, System.Int32? enquiryId)
		{
			return GetByEnquiryId(null, start, pageLength , enquiryId);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_GetByEnquiryId' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetByEnquiryId(TransactionManager transactionManager, System.Int32? enquiryId)
		{
			return GetByEnquiryId(transactionManager, 0, int.MaxValue , enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetByEnquiryId' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public abstract TList<Enquiries> GetByEnquiryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? enquiryId);
		
		#endregion
		
		#region Enquiries_Find 
		
		/// <summary>
		///	This method wrap the 'Enquiries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Find(System.Boolean? searchUsingOr, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			return Find(null, start, pageLength , searchUsingOr, enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public abstract TList<Enquiries> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress);
		
		#endregion
		
		#region Enquiries_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public TList<Enquiries> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;Enquiries&gt;"/> instance.</returns>
		public abstract TList<Enquiries> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region Enquiries_Update 
		
		/// <summary>
		///	This method wrap the 'Enquiries_Update' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			 Update(null, 0, int.MaxValue , enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Update' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			 Update(null, start, pageLength , enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_Update' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress)
		{
			 Update(transactionManager, 0, int.MaxValue , enquiryId, siteId, name, email, contactPhone, content, date, ipAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Update' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="name"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="contactPhone"> A <c>System.String</c> instance.</param>
		/// <param name="content"> A <c>System.String</c> instance.</param>
		/// <param name="date"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="ipAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? enquiryId, System.Int32? siteId, System.String name, System.String email, System.String contactPhone, System.String content, System.DateTime? date, System.String ipAddress);
		
		#endregion
		
		#region Enquiries_Delete 
		
		/// <summary>
		///	This method wrap the 'Enquiries_Delete' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? enquiryId)
		{
			 Delete(null, 0, int.MaxValue , enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Delete' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? enquiryId)
		{
			 Delete(null, start, pageLength , enquiryId);
		}
				
		/// <summary>
		///	This method wrap the 'Enquiries_Delete' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? enquiryId)
		{
			 Delete(transactionManager, 0, int.MaxValue , enquiryId);
		}
		
		/// <summary>
		///	This method wrap the 'Enquiries_Delete' stored procedure. 
		/// </summary>
		/// <param name="enquiryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? enquiryId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Enquiries&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Enquiries&gt;"/></returns>
		public static TList<Enquiries> Fill(IDataReader reader, TList<Enquiries> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Enquiries c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Enquiries")
					.Append("|").Append((System.Int32)reader[((int)EnquiriesColumn.EnquiryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Enquiries>(
					key.ToString(), // EntityTrackingKey
					"Enquiries",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Enquiries();
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
					c.EnquiryId = (System.Int32)reader[((int)EnquiriesColumn.EnquiryId - 1)];
					c.SiteId = (System.Int32)reader[((int)EnquiriesColumn.SiteId - 1)];
					c.Name = (System.String)reader[((int)EnquiriesColumn.Name - 1)];
					c.Email = (reader.IsDBNull(((int)EnquiriesColumn.Email - 1)))?null:(System.String)reader[((int)EnquiriesColumn.Email - 1)];
					c.ContactPhone = (reader.IsDBNull(((int)EnquiriesColumn.ContactPhone - 1)))?null:(System.String)reader[((int)EnquiriesColumn.ContactPhone - 1)];
					c.Content = (reader.IsDBNull(((int)EnquiriesColumn.Content - 1)))?null:(System.String)reader[((int)EnquiriesColumn.Content - 1)];
					c.Date = (System.DateTime)reader[((int)EnquiriesColumn.Date - 1)];
					c.IpAddress = (System.String)reader[((int)EnquiriesColumn.IpAddress - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Enquiries"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Enquiries"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Enquiries entity)
		{
			if (!reader.Read()) return;
			
			entity.EnquiryId = (System.Int32)reader[((int)EnquiriesColumn.EnquiryId - 1)];
			entity.SiteId = (System.Int32)reader[((int)EnquiriesColumn.SiteId - 1)];
			entity.Name = (System.String)reader[((int)EnquiriesColumn.Name - 1)];
			entity.Email = (reader.IsDBNull(((int)EnquiriesColumn.Email - 1)))?null:(System.String)reader[((int)EnquiriesColumn.Email - 1)];
			entity.ContactPhone = (reader.IsDBNull(((int)EnquiriesColumn.ContactPhone - 1)))?null:(System.String)reader[((int)EnquiriesColumn.ContactPhone - 1)];
			entity.Content = (reader.IsDBNull(((int)EnquiriesColumn.Content - 1)))?null:(System.String)reader[((int)EnquiriesColumn.Content - 1)];
			entity.Date = (System.DateTime)reader[((int)EnquiriesColumn.Date - 1)];
			entity.IpAddress = (System.String)reader[((int)EnquiriesColumn.IpAddress - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Enquiries"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Enquiries"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Enquiries entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EnquiryId = (System.Int32)dataRow["EnquiryID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.ContactPhone = Convert.IsDBNull(dataRow["ContactPhone"]) ? null : (System.String)dataRow["ContactPhone"];
			entity.Content = Convert.IsDBNull(dataRow["Content"]) ? null : (System.String)dataRow["Content"];
			entity.Date = (System.DateTime)dataRow["Date"];
			entity.IpAddress = (System.String)dataRow["IpAddress"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Enquiries"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Enquiries Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Enquiries entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Enquiries object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Enquiries instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Enquiries Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Enquiries entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region EnquiriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Enquiries</c>
	///</summary>
	public enum EnquiriesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion EnquiriesChildEntityTypes
	
	#region EnquiriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EnquiriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesFilterBuilder : SqlFilterBuilder<EnquiriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilterBuilder class.
		/// </summary>
		public EnquiriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EnquiriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EnquiriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EnquiriesFilterBuilder
	
	#region EnquiriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EnquiriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesParameterBuilder : ParameterizedSqlFilterBuilder<EnquiriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesParameterBuilder class.
		/// </summary>
		public EnquiriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EnquiriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EnquiriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EnquiriesParameterBuilder
	
	#region EnquiriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EnquiriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EnquiriesSortBuilder : SqlSortBuilder<EnquiriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesSqlSortBuilder class.
		/// </summary>
		public EnquiriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EnquiriesSortBuilder
	
} // end namespace
