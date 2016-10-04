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
	/// This class is the base class for any <see cref="EmailFormatsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailFormatsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.EmailFormats, JXTPortal.Entities.EmailFormatsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.EmailFormatsKey key)
		{
			return Delete(transactionManager, key.EmailFormatId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_emailFormatId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _emailFormatId)
		{
			return Delete(null, _emailFormatId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormatId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _emailFormatId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override JXTPortal.Entities.EmailFormats Get(TransactionManager transactionManager, JXTPortal.Entities.EmailFormatsKey key, int start, int pageLength)
		{
			return GetByEmailFormatId(transactionManager, key.EmailFormatId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="_emailFormatId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public JXTPortal.Entities.EmailFormats GetByEmailFormatId(System.Int32 _emailFormatId)
		{
			int count = -1;
			return GetByEmailFormatId(null,_emailFormatId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="_emailFormatId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public JXTPortal.Entities.EmailFormats GetByEmailFormatId(System.Int32 _emailFormatId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailFormatId(null, _emailFormatId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormatId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public JXTPortal.Entities.EmailFormats GetByEmailFormatId(TransactionManager transactionManager, System.Int32 _emailFormatId)
		{
			int count = -1;
			return GetByEmailFormatId(transactionManager, _emailFormatId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormatId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public JXTPortal.Entities.EmailFormats GetByEmailFormatId(TransactionManager transactionManager, System.Int32 _emailFormatId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailFormatId(transactionManager, _emailFormatId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="_emailFormatId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public JXTPortal.Entities.EmailFormats GetByEmailFormatId(System.Int32 _emailFormatId, int start, int pageLength, out int count)
		{
			return GetByEmailFormatId(null, _emailFormatId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__EmailFormats__173876EA index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormatId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailFormats"/> class.</returns>
		public abstract JXTPortal.Entities.EmailFormats GetByEmailFormatId(TransactionManager transactionManager, System.Int32 _emailFormatId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region EmailFormats_GetPaged 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public abstract TList<EmailFormats> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region EmailFormats_Delete 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? emailFormatId)
		{
			 Delete(null, 0, int.MaxValue , emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? emailFormatId)
		{
			 Delete(null, start, pageLength , emailFormatId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? emailFormatId)
		{
			 Delete(transactionManager, 0, int.MaxValue , emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailFormatId);
		
		#endregion
		
		#region EmailFormats_Update 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Update' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? emailFormatId, System.String emailFormatName)
		{
			 Update(null, 0, int.MaxValue , emailFormatId, emailFormatName);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Update' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? emailFormatId, System.String emailFormatName)
		{
			 Update(null, start, pageLength , emailFormatId, emailFormatName);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_Update' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? emailFormatId, System.String emailFormatName)
		{
			 Update(transactionManager, 0, int.MaxValue , emailFormatId, emailFormatName);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Update' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailFormatId, System.String emailFormatName);
		
		#endregion
		
		#region EmailFormats_Insert 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Insert' stored procedure. 
		/// </summary>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
			/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String emailFormatName, ref System.Int32? emailFormatId)
		{
			 Insert(null, 0, int.MaxValue , emailFormatName, ref emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Insert' stored procedure. 
		/// </summary>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
			/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String emailFormatName, ref System.Int32? emailFormatId)
		{
			 Insert(null, start, pageLength , emailFormatName, ref emailFormatId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_Insert' stored procedure. 
		/// </summary>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
			/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String emailFormatName, ref System.Int32? emailFormatId)
		{
			 Insert(transactionManager, 0, int.MaxValue , emailFormatName, ref emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Insert' stored procedure. 
		/// </summary>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
			/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String emailFormatName, ref System.Int32? emailFormatId);
		
		#endregion
		
		#region EmailFormats_Get_List 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public abstract TList<EmailFormats> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region EmailFormats_GetByEmailFormatId 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetByEmailFormatId' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetByEmailFormatId(System.Int32? emailFormatId)
		{
			return GetByEmailFormatId(null, 0, int.MaxValue , emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetByEmailFormatId' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetByEmailFormatId(int start, int pageLength, System.Int32? emailFormatId)
		{
			return GetByEmailFormatId(null, start, pageLength , emailFormatId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_GetByEmailFormatId' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> GetByEmailFormatId(TransactionManager transactionManager, System.Int32? emailFormatId)
		{
			return GetByEmailFormatId(transactionManager, 0, int.MaxValue , emailFormatId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_GetByEmailFormatId' stored procedure. 
		/// </summary>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public abstract TList<EmailFormats> GetByEmailFormatId(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailFormatId);
		
		#endregion
		
		#region EmailFormats_Find 
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Find(System.Boolean? searchUsingOr, System.Int32? emailFormatId, System.String emailFormatName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, emailFormatId, emailFormatName);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? emailFormatId, System.String emailFormatName)
		{
			return Find(null, start, pageLength , searchUsingOr, emailFormatId, emailFormatName);
		}
				
		/// <summary>
		///	This method wrap the 'EmailFormats_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public TList<EmailFormats> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? emailFormatId, System.String emailFormatName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, emailFormatId, emailFormatName);
		}
		
		/// <summary>
		///	This method wrap the 'EmailFormats_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormatId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailFormatName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailFormats&gt;"/> instance.</returns>
		public abstract TList<EmailFormats> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? emailFormatId, System.String emailFormatName);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmailFormats&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmailFormats&gt;"/></returns>
		public static TList<EmailFormats> Fill(IDataReader reader, TList<EmailFormats> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.EmailFormats c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmailFormats")
					.Append("|").Append((System.Int32)reader[((int)EmailFormatsColumn.EmailFormatId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmailFormats>(
					key.ToString(), // EntityTrackingKey
					"EmailFormats",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.EmailFormats();
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
					c.EmailFormatId = (System.Int32)reader[((int)EmailFormatsColumn.EmailFormatId - 1)];
					c.EmailFormatName = (System.String)reader[((int)EmailFormatsColumn.EmailFormatName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.EmailFormats"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailFormats"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.EmailFormats entity)
		{
			if (!reader.Read()) return;
			
			entity.EmailFormatId = (System.Int32)reader[((int)EmailFormatsColumn.EmailFormatId - 1)];
			entity.EmailFormatName = (System.String)reader[((int)EmailFormatsColumn.EmailFormatName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.EmailFormats"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailFormats"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.EmailFormats entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmailFormatId = (System.Int32)dataRow["EmailFormatID"];
			entity.EmailFormatName = (System.String)dataRow["EmailFormatName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailFormats"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.EmailFormats Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.EmailFormats entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByEmailFormatId methods when available
			
			#region MembersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Members>|MembersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MembersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MembersCollection = DataRepository.MembersProvider.GetByEmailFormat(transactionManager, entity.EmailFormatId);

				if (deep && entity.MembersCollection.Count > 0)
				{
					deepHandles.Add("MembersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Members>) DataRepository.MembersProvider.DeepLoad,
						new object[] { transactionManager, entity.MembersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertiserUsersCollectionGetByEmailFormat
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserUsers>|AdvertiserUsersCollectionGetByEmailFormat", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUsersCollectionGetByEmailFormat' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserUsersCollectionGetByEmailFormat = DataRepository.AdvertiserUsersProvider.GetByEmailFormat(transactionManager, entity.EmailFormatId);

				if (deep && entity.AdvertiserUsersCollectionGetByEmailFormat.Count > 0)
				{
					deepHandles.Add("AdvertiserUsersCollectionGetByEmailFormat",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserUsers>) DataRepository.AdvertiserUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserUsersCollectionGetByEmailFormat, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertiserUsersCollectionGetByNewsletterFormat
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdvertiserUsers>|AdvertiserUsersCollectionGetByNewsletterFormat", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertiserUsersCollectionGetByNewsletterFormat' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertiserUsersCollectionGetByNewsletterFormat = DataRepository.AdvertiserUsersProvider.GetByNewsletterFormat(transactionManager, entity.EmailFormatId);

				if (deep && entity.AdvertiserUsersCollectionGetByNewsletterFormat.Count > 0)
				{
					deepHandles.Add("AdvertiserUsersCollectionGetByNewsletterFormat",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdvertiserUsers>) DataRepository.AdvertiserUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertiserUsersCollectionGetByNewsletterFormat, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.EmailFormats object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.EmailFormats instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.EmailFormats Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.EmailFormats entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Members>
				if (CanDeepSave(entity.MembersCollection, "List<Members>|MembersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Members child in entity.MembersCollection)
					{
						if(child.EmailFormatSource != null)
						{
							child.EmailFormat = child.EmailFormatSource.EmailFormatId;
						}
						else
						{
							child.EmailFormat = entity.EmailFormatId;
						}

					}

					if (entity.MembersCollection.Count > 0 || entity.MembersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MembersProvider.Save(transactionManager, entity.MembersCollection);
						
						deepHandles.Add("MembersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Members >) DataRepository.MembersProvider.DeepSave,
							new object[] { transactionManager, entity.MembersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AdvertiserUsers>
				if (CanDeepSave(entity.AdvertiserUsersCollectionGetByEmailFormat, "List<AdvertiserUsers>|AdvertiserUsersCollectionGetByEmailFormat", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserUsers child in entity.AdvertiserUsersCollectionGetByEmailFormat)
					{
						if(child.EmailFormatSource != null)
						{
							child.EmailFormat = child.EmailFormatSource.EmailFormatId;
						}
						else
						{
							child.EmailFormat = entity.EmailFormatId;
						}

					}

					if (entity.AdvertiserUsersCollectionGetByEmailFormat.Count > 0 || entity.AdvertiserUsersCollectionGetByEmailFormat.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUsersCollectionGetByEmailFormat);
						
						deepHandles.Add("AdvertiserUsersCollectionGetByEmailFormat",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserUsers >) DataRepository.AdvertiserUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserUsersCollectionGetByEmailFormat, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AdvertiserUsers>
				if (CanDeepSave(entity.AdvertiserUsersCollectionGetByNewsletterFormat, "List<AdvertiserUsers>|AdvertiserUsersCollectionGetByNewsletterFormat", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdvertiserUsers child in entity.AdvertiserUsersCollectionGetByNewsletterFormat)
					{
						if(child.NewsletterFormatSource != null)
						{
							child.NewsletterFormat = child.NewsletterFormatSource.EmailFormatId;
						}
						else
						{
							child.NewsletterFormat = entity.EmailFormatId;
						}

					}

					if (entity.AdvertiserUsersCollectionGetByNewsletterFormat.Count > 0 || entity.AdvertiserUsersCollectionGetByNewsletterFormat.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertiserUsersProvider.Save(transactionManager, entity.AdvertiserUsersCollectionGetByNewsletterFormat);
						
						deepHandles.Add("AdvertiserUsersCollectionGetByNewsletterFormat",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdvertiserUsers >) DataRepository.AdvertiserUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertiserUsersCollectionGetByNewsletterFormat, deepSaveType, childTypes, innerList }
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
	
	#region EmailFormatsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.EmailFormats</c>
	///</summary>
	public enum EmailFormatsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>EmailFormats</c> as OneToMany for MembersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Members>))]
		MembersCollection,

		///<summary>
		/// Collection of <c>EmailFormats</c> as OneToMany for AdvertiserUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserUsers>))]
		AdvertiserUsersCollectionGetByEmailFormat,

		///<summary>
		/// Collection of <c>EmailFormats</c> as OneToMany for AdvertiserUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdvertiserUsers>))]
		AdvertiserUsersCollectionGetByNewsletterFormat,
	}
	
	#endregion EmailFormatsChildEntityTypes
	
	#region EmailFormatsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmailFormatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsFilterBuilder : SqlFilterBuilder<EmailFormatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilterBuilder class.
		/// </summary>
		public EmailFormatsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailFormatsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailFormatsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailFormatsFilterBuilder
	
	#region EmailFormatsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmailFormatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsParameterBuilder : ParameterizedSqlFilterBuilder<EmailFormatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsParameterBuilder class.
		/// </summary>
		public EmailFormatsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailFormatsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailFormatsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailFormatsParameterBuilder
	
	#region EmailFormatsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmailFormatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmailFormatsSortBuilder : SqlSortBuilder<EmailFormatsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsSqlSortBuilder class.
		/// </summary>
		public EmailFormatsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmailFormatsSortBuilder
	
} // end namespace
