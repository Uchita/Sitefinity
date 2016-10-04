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
	/// This class is the base class for any <see cref="DefaultResourcesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DefaultResourcesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DefaultResources, JXTPortal.Entities.DefaultResourcesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DefaultResourcesKey key)
		{
			return Delete(transactionManager, key.DefaultResourceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_defaultResourceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _defaultResourceId)
		{
			return Delete(null, _defaultResourceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultResourceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _defaultResourceId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		FK__DefaultRe__LastM__7DB89C09 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		FK__DefaultRe__LastM__7DB89C09 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		/// <remarks></remarks>
		public TList<DefaultResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		FK__DefaultRe__LastM__7DB89C09 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		fkDefaultReLastm7Db89c09 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		fkDefaultReLastm7Db89c09 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__LastM__7DB89C09 key.
		///		FK__DefaultRe__LastM__7DB89C09 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public abstract TList<DefaultResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		FK__DefaultRe__Resou__5D2BD0E6 Description: 
		/// </summary>
		/// <param name="_resourceFileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByResourceFileId(System.Int32? _resourceFileId)
		{
			int count = -1;
			return GetByResourceFileId(_resourceFileId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		FK__DefaultRe__Resou__5D2BD0E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		/// <remarks></remarks>
		public TList<DefaultResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId)
		{
			int count = -1;
			return GetByResourceFileId(transactionManager, _resourceFileId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		FK__DefaultRe__Resou__5D2BD0E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceFileId(transactionManager, _resourceFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		fkDefaultReResou5d2Bd0e6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceFileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByResourceFileId(System.Int32? _resourceFileId, int start, int pageLength)
		{
			int count =  -1;
			return GetByResourceFileId(null, _resourceFileId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		fkDefaultReResou5d2Bd0e6 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public TList<DefaultResources> GetByResourceFileId(System.Int32? _resourceFileId, int start, int pageLength,out int count)
		{
			return GetByResourceFileId(null, _resourceFileId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DefaultRe__Resou__5D2BD0E6 key.
		///		FK__DefaultRe__Resou__5D2BD0E6 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DefaultResources objects.</returns>
		public abstract TList<DefaultResources> GetByResourceFileId(TransactionManager transactionManager, System.Int32? _resourceFileId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DefaultResources Get(TransactionManager transactionManager, JXTPortal.Entities.DefaultResourcesKey key, int start, int pageLength)
		{
			return GetByDefaultResourceId(transactionManager, key.DefaultResourceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="_resourceCode"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByResourceCode(System.String _resourceCode)
		{
			int count = -1;
			return GetByResourceCode(null,_resourceCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByResourceCode(System.String _resourceCode, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceCode(null, _resourceCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode)
		{
			int count = -1;
			return GetByResourceCode(transactionManager, _resourceCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode, int start, int pageLength)
		{
			int count = -1;
			return GetByResourceCode(transactionManager, _resourceCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByResourceCode(System.String _resourceCode, int start, int pageLength, out int count)
		{
			return GetByResourceCode(null, _resourceCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_UK_DefaultResources_ResourceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resourceCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public abstract JXTPortal.Entities.DefaultResources GetByResourceCode(TransactionManager transactionManager, System.String _resourceCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="_defaultResourceId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByDefaultResourceId(System.Int32 _defaultResourceId)
		{
			int count = -1;
			return GetByDefaultResourceId(null,_defaultResourceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="_defaultResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByDefaultResourceId(System.Int32 _defaultResourceId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultResourceId(null, _defaultResourceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultResourceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByDefaultResourceId(TransactionManager transactionManager, System.Int32 _defaultResourceId)
		{
			int count = -1;
			return GetByDefaultResourceId(transactionManager, _defaultResourceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByDefaultResourceId(TransactionManager transactionManager, System.Int32 _defaultResourceId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultResourceId(transactionManager, _defaultResourceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="_defaultResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public JXTPortal.Entities.DefaultResources GetByDefaultResourceId(System.Int32 _defaultResourceId, int start, int pageLength, out int count)
		{
			return GetByDefaultResourceId(null, _defaultResourceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DefaultResources__50C5FA01 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultResourceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DefaultResources"/> class.</returns>
		public abstract JXTPortal.Entities.DefaultResources GetByDefaultResourceId(TransactionManager transactionManager, System.Int32 _defaultResourceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DefaultResources_Insert 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? defaultResourceId)
		{
			 Insert(null, 0, int.MaxValue , resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy, ref defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? defaultResourceId)
		{
			 Insert(null, start, pageLength , resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy, ref defaultResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? defaultResourceId)
		{
			 Insert(transactionManager, 0, int.MaxValue , resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy, ref defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Insert' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
			/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy, ref System.Int32? defaultResourceId);
		
		#endregion
		
		#region DefaultResources_Get_List 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DefaultResources_GetByResourceCode 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByResourceCode' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByResourceCode(int start, int pageLength, System.String resourceCode)
		{
			return GetByResourceCode(null, start, pageLength , resourceCode);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByResourceCode' stored procedure. 
		/// </summary>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> GetByResourceCode(TransactionManager transactionManager, int start, int pageLength , System.String resourceCode);
		
		#endregion
		
		#region DefaultResources_GetByDefaultResourceId 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByDefaultResourceId' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByDefaultResourceId(System.Int32? defaultResourceId)
		{
			return GetByDefaultResourceId(null, 0, int.MaxValue , defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByDefaultResourceId' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByDefaultResourceId(int start, int pageLength, System.Int32? defaultResourceId)
		{
			return GetByDefaultResourceId(null, start, pageLength , defaultResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByDefaultResourceId' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByDefaultResourceId(TransactionManager transactionManager, System.Int32? defaultResourceId)
		{
			return GetByDefaultResourceId(transactionManager, 0, int.MaxValue , defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByDefaultResourceId' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> GetByDefaultResourceId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultResourceId);
		
		#endregion
		
		#region DefaultResources_Update 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Update' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, 0, int.MaxValue , defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Update' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(null, start, pageLength , defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_Update' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			 Update(transactionManager, 0, int.MaxValue , defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Update' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region DefaultResources_Find 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Find(System.Boolean? searchUsingOr, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(null, start, pageLength , searchUsingOr, defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, defaultResourceId, resourceCode, resourceFileId, resourceText, resourceDescription, lastModified, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceCode"> A <c>System.String</c> instance.</param>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="resourceText"> A <c>System.String</c> instance.</param>
		/// <param name="resourceDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? defaultResourceId, System.String resourceCode, System.Int32? resourceFileId, System.String resourceText, System.String resourceDescription, System.DateTime? lastModified, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region DefaultResources_Delete 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? defaultResourceId)
		{
			 Delete(null, 0, int.MaxValue , defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? defaultResourceId)
		{
			 Delete(null, start, pageLength , defaultResourceId);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? defaultResourceId)
		{
			 Delete(transactionManager, 0, int.MaxValue , defaultResourceId);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_Delete' stored procedure. 
		/// </summary>
		/// <param name="defaultResourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultResourceId);
		
		#endregion
		
		#region DefaultResources_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region DefaultResources_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(int start, int pageLength, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, start, pageLength , lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(transactionManager, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region DefaultResources_GetByResourceFileId 
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByResourceFileId' stored procedure. 
		/// </summary>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public TList<DefaultResources> GetByResourceFileId(int start, int pageLength, System.Int32? resourceFileId)
		{
			return GetByResourceFileId(null, start, pageLength , resourceFileId);
		}
				
		
		/// <summary>
		///	This method wrap the 'DefaultResources_GetByResourceFileId' stored procedure. 
		/// </summary>
		/// <param name="resourceFileId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DefaultResources&gt;"/> instance.</returns>
		public abstract TList<DefaultResources> GetByResourceFileId(TransactionManager transactionManager, int start, int pageLength , System.Int32? resourceFileId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DefaultResources&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DefaultResources&gt;"/></returns>
		public static TList<DefaultResources> Fill(IDataReader reader, TList<DefaultResources> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DefaultResources c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DefaultResources")
					.Append("|").Append((System.Int32)reader[((int)DefaultResourcesColumn.DefaultResourceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DefaultResources>(
					key.ToString(), // EntityTrackingKey
					"DefaultResources",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DefaultResources();
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
					c.DefaultResourceId = (System.Int32)reader[((int)DefaultResourcesColumn.DefaultResourceId - 1)];
					c.ResourceCode = (System.String)reader[((int)DefaultResourcesColumn.ResourceCode - 1)];
					c.ResourceFileId = (reader.IsDBNull(((int)DefaultResourcesColumn.ResourceFileId - 1)))?null:(System.Int32?)reader[((int)DefaultResourcesColumn.ResourceFileId - 1)];
					c.ResourceText = (reader.IsDBNull(((int)DefaultResourcesColumn.ResourceText - 1)))?null:(System.String)reader[((int)DefaultResourcesColumn.ResourceText - 1)];
					c.ResourceDescription = (System.String)reader[((int)DefaultResourcesColumn.ResourceDescription - 1)];
					c.LastModified = (System.DateTime)reader[((int)DefaultResourcesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)DefaultResourcesColumn.LastModifiedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DefaultResources"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DefaultResources"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DefaultResources entity)
		{
			if (!reader.Read()) return;
			
			entity.DefaultResourceId = (System.Int32)reader[((int)DefaultResourcesColumn.DefaultResourceId - 1)];
			entity.ResourceCode = (System.String)reader[((int)DefaultResourcesColumn.ResourceCode - 1)];
			entity.ResourceFileId = (reader.IsDBNull(((int)DefaultResourcesColumn.ResourceFileId - 1)))?null:(System.Int32?)reader[((int)DefaultResourcesColumn.ResourceFileId - 1)];
			entity.ResourceText = (reader.IsDBNull(((int)DefaultResourcesColumn.ResourceText - 1)))?null:(System.String)reader[((int)DefaultResourcesColumn.ResourceText - 1)];
			entity.ResourceDescription = (System.String)reader[((int)DefaultResourcesColumn.ResourceDescription - 1)];
			entity.LastModified = (System.DateTime)reader[((int)DefaultResourcesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)DefaultResourcesColumn.LastModifiedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DefaultResources"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DefaultResources"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DefaultResources entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DefaultResourceId = (System.Int32)dataRow["DefaultResourceID"];
			entity.ResourceCode = (System.String)dataRow["ResourceCode"];
			entity.ResourceFileId = Convert.IsDBNull(dataRow["ResourceFileID"]) ? null : (System.Int32?)dataRow["ResourceFileID"];
			entity.ResourceText = Convert.IsDBNull(dataRow["ResourceText"]) ? null : (System.String)dataRow["ResourceText"];
			entity.ResourceDescription = (System.String)dataRow["ResourceDescription"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DefaultResources"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DefaultResources Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DefaultResources entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region ResourceFileIdSource	
			if (CanDeepLoad(entity, "Files|ResourceFileIdSource", deepLoadType, innerList) 
				&& entity.ResourceFileIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ResourceFileId ?? (int)0);
				Files tmpEntity = EntityManager.LocateEntity<Files>(EntityLocator.ConstructKeyFromPkItems(typeof(Files), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ResourceFileIdSource = tmpEntity;
				else
					entity.ResourceFileIdSource = DataRepository.FilesProvider.GetByFileId(transactionManager, (entity.ResourceFileId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResourceFileIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ResourceFileIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FilesProvider.DeepLoad(transactionManager, entity.ResourceFileIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ResourceFileIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDefaultResourceId methods when available
			
			#region SiteResourcesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollection = DataRepository.SiteResourcesProvider.GetByResourceCode(transactionManager, entity.ResourceCode);

				if (deep && entity.SiteResourcesCollection.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DefaultResources object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DefaultResources instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DefaultResources Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DefaultResources entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region ResourceFileIdSource
			if (CanDeepSave(entity, "Files|ResourceFileIdSource", deepSaveType, innerList) 
				&& entity.ResourceFileIdSource != null)
			{
				DataRepository.FilesProvider.Save(transactionManager, entity.ResourceFileIdSource);
				entity.ResourceFileId = entity.ResourceFileIdSource.FileId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollection, "List<SiteResources>|SiteResourcesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollection)
					{
						if(child.ResourceCodeSource != null)
						{
							child.ResourceCode = child.ResourceCodeSource.ResourceCode;
						}
						else
						{
							child.ResourceCode = entity.ResourceCode;
						}

					}

					if (entity.SiteResourcesCollection.Count > 0 || entity.SiteResourcesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollection);
						
						deepHandles.Add("SiteResourcesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollection, deepSaveType, childTypes, innerList }
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
	
	#region DefaultResourcesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DefaultResources</c>
	///</summary>
	public enum DefaultResourcesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Files</c> at ResourceFileIdSource
		///</summary>
		[ChildEntityType(typeof(Files))]
		Files,
	
		///<summary>
		/// Collection of <c>DefaultResources</c> as OneToMany for SiteResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResources>))]
		SiteResourcesCollection,
	}
	
	#endregion DefaultResourcesChildEntityTypes
	
	#region DefaultResourcesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DefaultResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesFilterBuilder : SqlFilterBuilder<DefaultResourcesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilterBuilder class.
		/// </summary>
		public DefaultResourcesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DefaultResourcesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DefaultResourcesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DefaultResourcesFilterBuilder
	
	#region DefaultResourcesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DefaultResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesParameterBuilder : ParameterizedSqlFilterBuilder<DefaultResourcesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesParameterBuilder class.
		/// </summary>
		public DefaultResourcesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DefaultResourcesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DefaultResourcesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DefaultResourcesParameterBuilder
	
	#region DefaultResourcesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DefaultResourcesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DefaultResourcesSortBuilder : SqlSortBuilder<DefaultResourcesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesSqlSortBuilder class.
		/// </summary>
		public DefaultResourcesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DefaultResourcesSortBuilder
	
} // end namespace
