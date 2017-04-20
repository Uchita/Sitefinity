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
	/// This class is the base class for any <see cref="GlobalSettingsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GlobalSettingsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.GlobalSettings, JXTPortal.Entities.GlobalSettingsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.GlobalSettingsKey key)
		{
			return Delete(transactionManager, key.GlobalSettingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_globalSettingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _globalSettingId)
		{
			return Delete(null, _globalSettingId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_globalSettingId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _globalSettingId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		FK__GlobalSet__Defau__0445F0DF Description: 
		/// </summary>
		/// <param name="_defaultCountryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultCountryId(System.Int32? _defaultCountryId)
		{
			int count = -1;
			return GetByDefaultCountryId(_defaultCountryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		FK__GlobalSet__Defau__0445F0DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId)
		{
			int count = -1;
			return GetByDefaultCountryId(transactionManager, _defaultCountryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		FK__GlobalSet__Defau__0445F0DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultCountryId(transactionManager, _defaultCountryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		fkGlobalSetDefau0445f0Df Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultCountryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultCountryId(System.Int32? _defaultCountryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultCountryId(null, _defaultCountryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		fkGlobalSetDefau0445f0Df Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultCountryId(System.Int32? _defaultCountryId, int start, int pageLength,out int count)
		{
			return GetByDefaultCountryId(null, _defaultCountryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__0445F0DF key.
		///		FK__GlobalSet__Defau__0445F0DF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		FK__GlobalSet__Defau__5772F790 Description: 
		/// </summary>
		/// <param name="_defaultLanguageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultLanguageId(System.Int32 _defaultLanguageId)
		{
			int count = -1;
			return GetByDefaultLanguageId(_defaultLanguageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		FK__GlobalSet__Defau__5772F790 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLanguageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByDefaultLanguageId(TransactionManager transactionManager, System.Int32 _defaultLanguageId)
		{
			int count = -1;
			return GetByDefaultLanguageId(transactionManager, _defaultLanguageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		FK__GlobalSet__Defau__5772F790 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultLanguageId(TransactionManager transactionManager, System.Int32 _defaultLanguageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultLanguageId(transactionManager, _defaultLanguageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		fkGlobalSetDefau5772f790 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultLanguageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultLanguageId(System.Int32 _defaultLanguageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultLanguageId(null, _defaultLanguageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		fkGlobalSetDefau5772f790 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultLanguageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultLanguageId(System.Int32 _defaultLanguageId, int start, int pageLength,out int count)
		{
			return GetByDefaultLanguageId(null, _defaultLanguageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__5772F790 key.
		///		FK__GlobalSet__Defau__5772F790 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByDefaultLanguageId(TransactionManager transactionManager, System.Int32 _defaultLanguageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		FK__GlobalSet__Defau__58671BC9 Description: 
		/// </summary>
		/// <param name="_defaultDynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultDynamicPageId(System.Int32? _defaultDynamicPageId)
		{
			int count = -1;
			return GetByDefaultDynamicPageId(_defaultDynamicPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		FK__GlobalSet__Defau__58671BC9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultDynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByDefaultDynamicPageId(TransactionManager transactionManager, System.Int32? _defaultDynamicPageId)
		{
			int count = -1;
			return GetByDefaultDynamicPageId(transactionManager, _defaultDynamicPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		FK__GlobalSet__Defau__58671BC9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultDynamicPageId(TransactionManager transactionManager, System.Int32? _defaultDynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultDynamicPageId(transactionManager, _defaultDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		fkGlobalSetDefau58671Bc9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultDynamicPageId(System.Int32? _defaultDynamicPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultDynamicPageId(null, _defaultDynamicPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		fkGlobalSetDefau58671Bc9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultDynamicPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByDefaultDynamicPageId(System.Int32? _defaultDynamicPageId, int start, int pageLength,out int count)
		{
			return GetByDefaultDynamicPageId(null, _defaultDynamicPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Defau__58671BC9 key.
		///		FK__GlobalSet__Defau__58671BC9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByDefaultDynamicPageId(TransactionManager transactionManager, System.Int32? _defaultDynamicPageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		FK__GlobalSet__JobAp__355AB93A Description: 
		/// </summary>
		/// <param name="_jobApplicationPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByJobApplicationPageId(System.Int32? _jobApplicationPageId)
		{
			int count = -1;
			return GetByJobApplicationPageId(_jobApplicationPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		FK__GlobalSet__JobAp__355AB93A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByJobApplicationPageId(TransactionManager transactionManager, System.Int32? _jobApplicationPageId)
		{
			int count = -1;
			return GetByJobApplicationPageId(transactionManager, _jobApplicationPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		FK__GlobalSet__JobAp__355AB93A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByJobApplicationPageId(TransactionManager transactionManager, System.Int32? _jobApplicationPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByJobApplicationPageId(transactionManager, _jobApplicationPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		fkGlobalSetJobAp355Ab93a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByJobApplicationPageId(System.Int32? _jobApplicationPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByJobApplicationPageId(null, _jobApplicationPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		fkGlobalSetJobAp355Ab93a Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_jobApplicationPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByJobApplicationPageId(System.Int32? _jobApplicationPageId, int start, int pageLength,out int count)
		{
			return GetByJobApplicationPageId(null, _jobApplicationPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__JobAp__355AB93A key.
		///		FK__GlobalSet__JobAp__355AB93A Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_jobApplicationPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByJobApplicationPageId(TransactionManager transactionManager, System.Int32? _jobApplicationPageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		FK__GlobalSet__LastM__5A4F643B Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		FK__GlobalSet__LastM__5A4F643B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		FK__GlobalSet__LastM__5A4F643B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		fkGlobalSetLastm5a4f643b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		fkGlobalSetLastm5a4f643b Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__LastM__5A4F643B key.
		///		FK__GlobalSet__LastM__5A4F643B Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		FK__GlobalSet__Membe__1A26D4BA Description: 
		/// </summary>
		/// <param name="_memberRegisterPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByMemberRegisterPageId(System.Int32? _memberRegisterPageId)
		{
			int count = -1;
			return GetByMemberRegisterPageId(_memberRegisterPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		FK__GlobalSet__Membe__1A26D4BA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberRegisterPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetByMemberRegisterPageId(TransactionManager transactionManager, System.Int32? _memberRegisterPageId)
		{
			int count = -1;
			return GetByMemberRegisterPageId(transactionManager, _memberRegisterPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		FK__GlobalSet__Membe__1A26D4BA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberRegisterPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByMemberRegisterPageId(TransactionManager transactionManager, System.Int32? _memberRegisterPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberRegisterPageId(transactionManager, _memberRegisterPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		fkGlobalSetMembe1a26d4Ba Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberRegisterPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByMemberRegisterPageId(System.Int32? _memberRegisterPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMemberRegisterPageId(null, _memberRegisterPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		fkGlobalSetMembe1a26d4Ba Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_memberRegisterPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetByMemberRegisterPageId(System.Int32? _memberRegisterPageId, int start, int pageLength,out int count)
		{
			return GetByMemberRegisterPageId(null, _memberRegisterPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__Membe__1A26D4BA key.
		///		FK__GlobalSet__Membe__1A26D4BA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberRegisterPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetByMemberRegisterPageId(TransactionManager transactionManager, System.Int32? _memberRegisterPageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		FK__GlobalSet__SiteF__5C37ACAD Description: 
		/// </summary>
		/// <param name="_siteFavIconId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteFavIconId(System.Int32? _siteFavIconId)
		{
			int count = -1;
			return GetBySiteFavIconId(_siteFavIconId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		FK__GlobalSet__SiteF__5C37ACAD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteFavIconId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetBySiteFavIconId(TransactionManager transactionManager, System.Int32? _siteFavIconId)
		{
			int count = -1;
			return GetBySiteFavIconId(transactionManager, _siteFavIconId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		FK__GlobalSet__SiteF__5C37ACAD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteFavIconId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteFavIconId(TransactionManager transactionManager, System.Int32? _siteFavIconId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteFavIconId(transactionManager, _siteFavIconId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		fkGlobalSetSitef5c37Acad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteFavIconId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteFavIconId(System.Int32? _siteFavIconId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteFavIconId(null, _siteFavIconId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		fkGlobalSetSitef5c37Acad Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteFavIconId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteFavIconId(System.Int32? _siteFavIconId, int start, int pageLength,out int count)
		{
			return GetBySiteFavIconId(null, _siteFavIconId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteF__5C37ACAD key.
		///		FK__GlobalSet__SiteF__5C37ACAD Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteFavIconId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetBySiteFavIconId(TransactionManager transactionManager, System.Int32? _siteFavIconId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		FK__GlobalSet__SiteI__125EB334 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		FK__GlobalSet__SiteI__125EB334 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		/// <remarks></remarks>
		public TList<GlobalSettings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		FK__GlobalSet__SiteI__125EB334 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		fkGlobalSetSitei125Eb334 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		fkGlobalSetSitei125Eb334 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public TList<GlobalSettings> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__GlobalSet__SiteI__125EB334 key.
		///		FK__GlobalSet__SiteI__125EB334 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.GlobalSettings objects.</returns>
		public abstract TList<GlobalSettings> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.GlobalSettings Get(TransactionManager transactionManager, JXTPortal.Entities.GlobalSettingsKey key, int start, int pageLength)
		{
			return GetByGlobalSettingId(transactionManager, key.GlobalSettingId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdGlobalSettingId(System.Int32 _siteId, System.Int32 _globalSettingId)
		{
			int count = -1;
			return GetBySiteIdGlobalSettingId(null,_siteId, _globalSettingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdGlobalSettingId(System.Int32 _siteId, System.Int32 _globalSettingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdGlobalSettingId(null, _siteId, _globalSettingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdGlobalSettingId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _globalSettingId)
		{
			int count = -1;
			return GetBySiteIdGlobalSettingId(transactionManager, _siteId, _globalSettingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdGlobalSettingId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _globalSettingId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdGlobalSettingId(transactionManager, _siteId, _globalSettingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdGlobalSettingId(System.Int32 _siteId, System.Int32 _globalSettingId, int start, int pageLength, out int count)
		{
			return GetBySiteIdGlobalSettingId(null, _siteId, _globalSettingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_GlobalSettings_7_408245105__K2_K1_55 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public abstract TList<GlobalSettings> GetBySiteIdGlobalSettingId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _globalSettingId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdPublicJobsSearch(System.Int32 _siteId, System.Boolean _publicJobsSearch)
		{
			int count = -1;
			return GetBySiteIdPublicJobsSearch(null,_siteId, _publicJobsSearch, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdPublicJobsSearch(System.Int32 _siteId, System.Boolean _publicJobsSearch, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPublicJobsSearch(null, _siteId, _publicJobsSearch, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdPublicJobsSearch(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _publicJobsSearch)
		{
			int count = -1;
			return GetBySiteIdPublicJobsSearch(transactionManager, _siteId, _publicJobsSearch, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdPublicJobsSearch(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _publicJobsSearch, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPublicJobsSearch(transactionManager, _siteId, _publicJobsSearch, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdPublicJobsSearch(System.Int32 _siteId, System.Boolean _publicJobsSearch, int start, int pageLength, out int count)
		{
			return GetBySiteIdPublicJobsSearch(null, _siteId, _publicJobsSearch, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_PublicJobsSearch index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public abstract TList<GlobalSettings> GetBySiteIdPublicJobsSearch(TransactionManager transactionManager, System.Int32 _siteId, System.Boolean _publicJobsSearch, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(System.Int32 _siteId, System.Int32 _useAdvertiserFilter)
		{
			int count = -1;
			return GetBySiteIdUseAdvertiserFilter(null,_siteId, _useAdvertiserFilter, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(System.Int32 _siteId, System.Int32 _useAdvertiserFilter, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUseAdvertiserFilter(null, _siteId, _useAdvertiserFilter, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _useAdvertiserFilter)
		{
			int count = -1;
			return GetBySiteIdUseAdvertiserFilter(transactionManager, _siteId, _useAdvertiserFilter, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _useAdvertiserFilter, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUseAdvertiserFilter(transactionManager, _siteId, _useAdvertiserFilter, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(System.Int32 _siteId, System.Int32 _useAdvertiserFilter, int start, int pageLength, out int count)
		{
			return GetBySiteIdUseAdvertiserFilter(null, _siteId, _useAdvertiserFilter, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettings_SiteID_UseAdvertiserFilter index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_useAdvertiserFilter"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public abstract TList<GlobalSettings> GetBySiteIdUseAdvertiserFilter(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _useAdvertiserFilter, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId)
		{
			int count = -1;
			return GetByPublicJobsSearchPrivateJobsSiteId(null,_publicJobsSearch, _privateJobs, _siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetByPublicJobsSearchPrivateJobsSiteId(null, _publicJobsSearch, _privateJobs, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(TransactionManager transactionManager, System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId)
		{
			int count = -1;
			return GetByPublicJobsSearchPrivateJobsSiteId(transactionManager, _publicJobsSearch, _privateJobs, _siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(TransactionManager transactionManager, System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetByPublicJobsSearchPrivateJobsSiteId(transactionManager, _publicJobsSearch, _privateJobs, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId, int start, int pageLength, out int count)
		{
			return GetByPublicJobsSearchPrivateJobsSiteId(null, _publicJobsSearch, _privateJobs, _siteId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_GlobalSettins_PublicJobsSearch_PrivateJobs_SiteID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publicJobsSearch"></param>
		/// <param name="_privateJobs"></param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;GlobalSettings&gt;"/> class.</returns>
		public abstract TList<GlobalSettings> GetByPublicJobsSearchPrivateJobsSiteId(TransactionManager transactionManager, System.Boolean _publicJobsSearch, System.Boolean _privateJobs, System.Int32 _siteId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="_globalSettingId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(System.Int32 _globalSettingId)
		{
			int count = -1;
			return GetByGlobalSettingId(null,_globalSettingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(System.Int32 _globalSettingId, int start, int pageLength)
		{
			int count = -1;
			return GetByGlobalSettingId(null, _globalSettingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_globalSettingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(TransactionManager transactionManager, System.Int32 _globalSettingId)
		{
			int count = -1;
			return GetByGlobalSettingId(transactionManager, _globalSettingId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(TransactionManager transactionManager, System.Int32 _globalSettingId, int start, int pageLength)
		{
			int count = -1;
			return GetByGlobalSettingId(transactionManager, _globalSettingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(System.Int32 _globalSettingId, int start, int pageLength, out int count)
		{
			return GetByGlobalSettingId(null, _globalSettingId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Global__408F9238 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_globalSettingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.GlobalSettings"/> class.</returns>
		public abstract JXTPortal.Entities.GlobalSettings GetByGlobalSettingId(TransactionManager transactionManager, System.Int32 _globalSettingId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region GlobalSettings_GetPaged 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetPaged' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetPaged' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetPaged' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetPaged' stored procedure. 
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
		
		#region GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId' stored procedure. 
		/// </summary>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByPublicJobsSearchPrivateJobsSiteId(System.Boolean? publicJobsSearch, System.Boolean? privateJobs, System.Int32? siteId)
		{
			return GetByPublicJobsSearchPrivateJobsSiteId(null, 0, int.MaxValue , publicJobsSearch, privateJobs, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId' stored procedure. 
		/// </summary>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByPublicJobsSearchPrivateJobsSiteId(int start, int pageLength, System.Boolean? publicJobsSearch, System.Boolean? privateJobs, System.Int32? siteId)
		{
			return GetByPublicJobsSearchPrivateJobsSiteId(null, start, pageLength , publicJobsSearch, privateJobs, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId' stored procedure. 
		/// </summary>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByPublicJobsSearchPrivateJobsSiteId(TransactionManager transactionManager, System.Boolean? publicJobsSearch, System.Boolean? privateJobs, System.Int32? siteId)
		{
			return GetByPublicJobsSearchPrivateJobsSiteId(transactionManager, 0, int.MaxValue , publicJobsSearch, privateJobs, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByPublicJobsSearchPrivateJobsSiteId' stored procedure. 
		/// </summary>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByPublicJobsSearchPrivateJobsSiteId(TransactionManager transactionManager, int start, int pageLength , System.Boolean? publicJobsSearch, System.Boolean? privateJobs, System.Int32? siteId);
		
		#endregion
		
		#region GlobalSettings_Find 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			return Find(null, start, pageLength , searchUsingOr, globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId);
		
		#endregion
		
		#region GlobalSettings_GetByGlobalSettingId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByGlobalSettingId(System.Int32? globalSettingId)
		{
			return GetByGlobalSettingId(null, 0, int.MaxValue , globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByGlobalSettingId(int start, int pageLength, System.Int32? globalSettingId)
		{
			return GetByGlobalSettingId(null, start, pageLength , globalSettingId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByGlobalSettingId(TransactionManager transactionManager, System.Int32? globalSettingId)
		{
			return GetByGlobalSettingId(transactionManager, 0, int.MaxValue , globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByGlobalSettingId(TransactionManager transactionManager, int start, int pageLength , System.Int32? globalSettingId);
		
		#endregion
		
		#region GlobalSettings_Update 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Update' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			 Update(null, 0, int.MaxValue , globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Update' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			 Update(null, start, pageLength , globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_Update' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId)
		{
			 Update(transactionManager, 0, int.MaxValue , globalSettingId, siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Update' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? globalSettingId, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId);
		
		#endregion
		
		#region GlobalSettings_GetByDefaultCountryId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultCountryId' stored procedure. 
		/// </summary>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDefaultCountryId(int start, int pageLength, System.Int32? defaultCountryId)
		{
			return GetByDefaultCountryId(null, start, pageLength , defaultCountryId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultCountryId' stored procedure. 
		/// </summary>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDefaultCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultCountryId);
		
		#endregion
		
		#region GlobalSettings_GetByMemberRegisterPageId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByMemberRegisterPageId' stored procedure. 
		/// </summary>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberRegisterPageId(int start, int pageLength, System.Int32? memberRegisterPageId)
		{
			return GetByMemberRegisterPageId(null, start, pageLength , memberRegisterPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByMemberRegisterPageId' stored procedure. 
		/// </summary>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberRegisterPageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberRegisterPageId);
		
		#endregion
		
		#region GlobalSettings_GetByDefaultLanguageId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultLanguageId' stored procedure. 
		/// </summary>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDefaultLanguageId(System.Int32? defaultLanguageId)
		{
			return GetByDefaultLanguageId(null, 0, int.MaxValue , defaultLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultLanguageId' stored procedure. 
		/// </summary>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDefaultLanguageId(int start, int pageLength, System.Int32? defaultLanguageId)
		{
			return GetByDefaultLanguageId(null, start, pageLength , defaultLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultLanguageId' stored procedure. 
		/// </summary>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDefaultLanguageId(TransactionManager transactionManager, System.Int32? defaultLanguageId)
		{
			return GetByDefaultLanguageId(transactionManager, 0, int.MaxValue , defaultLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultLanguageId' stored procedure. 
		/// </summary>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDefaultLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultLanguageId);
		
		#endregion
		
		#region GlobalSettings_Insert 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId, ref System.Int32? globalSettingId)
		{
			 Insert(null, 0, int.MaxValue , siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId, ref globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId, ref System.Int32? globalSettingId)
		{
			 Insert(null, start, pageLength , siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId, ref globalSettingId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId, ref System.Int32? globalSettingId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, defaultLanguageId, defaultDynamicPageId, publicJobsSearch, publicMembersSearch, publicCompaniesSearch, publicSponsoredAdverts, privateJobs, privateMembers, privateCompanies, lastModifiedBy, lastModified, pageTitlePrefix, pageTitleSuffix, defaultTitle, homeTitle, defaultDescription, homeDescription, defaultKeywords, homeKeywords, showFaceBookButton, useAdvertiserFilter, merchantId, showTwitterButton, showJobAlertButton, showLinkedInButton, siteFavIconId, siteDocType, currencySymbol, ftpFolderLocation, metaTags, systemMetaTags, memberRegistrationNotification, linkedInApi, linkedInLogo, linkedInCompanyId, linkedInEmail, privacySettings, wwwRedirect, allowAdvertiser, linkedInApiSecret, googleClientId, googleClientSecret, facebookAppId, facebookAppSecret, linkedInButtonSize, defaultCountryId, payPalUsername, payPalPassword, payPalSignature, securePayMerchantId, securePayPassword, usingSsl, useCustomProfessionRole, generateJobXml, isPrivateSite, privateRedirectUrl, enableJobCustomQuestionnaire, jobApplicationTypeId, jobScreeningProcess, advertiserApprovalProcess, siteType, enableSsl, gst, gstLabel, numberOfPremiumJobs, premiumJobDays, displayPremiumJobsOnResults, jobExpiryNotification, currencyId, payPalClientId, payPalClientSecret, paypalUser, paypalProPassword, paypalVendor, paypalPartner, invoiceSiteInfo, invoiceSiteFooter, enableTermsAndConditions, defaultEmailLanguageId, googleTagManager, googleAnalytics, googleWebMaster, enablePeopleSearch, globalDateFormat, timeZone, globalFolder, enableScreeningQuestions, enableExpiryDate, memberRegisterPageId, jobApplicationPageId, ref globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicMembersSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicCompaniesSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publicSponsoredAdverts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateMembers"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageTitlePrefix"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitleSuffix"> A <c>System.String</c> instance.</param>
		/// <param name="defaultTitle"> A <c>System.String</c> instance.</param>
		/// <param name="homeTitle"> A <c>System.String</c> instance.</param>
		/// <param name="defaultDescription"> A <c>System.String</c> instance.</param>
		/// <param name="homeDescription"> A <c>System.String</c> instance.</param>
		/// <param name="defaultKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="homeKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="showFaceBookButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="merchantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="showTwitterButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobAlertButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showLinkedInButton"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteDocType"> A <c>System.String</c> instance.</param>
		/// <param name="currencySymbol"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="metaTags"> A <c>System.String</c> instance.</param>
		/// <param name="systemMetaTags"> A <c>System.String</c> instance.</param>
		/// <param name="memberRegistrationNotification"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInApi"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInLogo"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInCompanyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInEmail"> A <c>System.String</c> instance.</param>
		/// <param name="privacySettings"> A <c>System.String</c> instance.</param>
		/// <param name="wwwRedirect"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="allowAdvertiser"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="linkedInApiSecret"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientId"> A <c>System.String</c> instance.</param>
		/// <param name="googleClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppId"> A <c>System.String</c> instance.</param>
		/// <param name="facebookAppSecret"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInButtonSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalUsername"> A <c>System.String</c> instance.</param>
		/// <param name="payPalPassword"> A <c>System.String</c> instance.</param>
		/// <param name="payPalSignature"> A <c>System.String</c> instance.</param>
		/// <param name="securePayMerchantId"> A <c>System.String</c> instance.</param>
		/// <param name="securePayPassword"> A <c>System.String</c> instance.</param>
		/// <param name="usingSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="generateJobXml"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="isPrivateSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="privateRedirectUrl"> A <c>System.String</c> instance.</param>
		/// <param name="enableJobCustomQuestionnaire"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobApplicationTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobScreeningProcess"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="advertiserApprovalProcess"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="enableSsl"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="gst"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="gstLabel"> A <c>System.String</c> instance.</param>
		/// <param name="numberOfPremiumJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="premiumJobDays"> A <c>System.Int32?</c> instance.</param>
		/// <param name="displayPremiumJobsOnResults"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobExpiryNotification"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="currencyId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="payPalClientId"> A <c>System.String</c> instance.</param>
		/// <param name="payPalClientSecret"> A <c>System.String</c> instance.</param>
		/// <param name="paypalUser"> A <c>System.String</c> instance.</param>
		/// <param name="paypalProPassword"> A <c>System.String</c> instance.</param>
		/// <param name="paypalVendor"> A <c>System.String</c> instance.</param>
		/// <param name="paypalPartner"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteInfo"> A <c>System.String</c> instance.</param>
		/// <param name="invoiceSiteFooter"> A <c>System.String</c> instance.</param>
		/// <param name="enableTermsAndConditions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="defaultEmailLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="googleTagManager"> A <c>System.String</c> instance.</param>
		/// <param name="googleAnalytics"> A <c>System.String</c> instance.</param>
		/// <param name="googleWebMaster"> A <c>System.String</c> instance.</param>
		/// <param name="enablePeopleSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="globalDateFormat"> A <c>System.String</c> instance.</param>
		/// <param name="timeZone"> A <c>System.String</c> instance.</param>
		/// <param name="globalFolder"> A <c>System.String</c> instance.</param>
		/// <param name="enableScreeningQuestions"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="enableExpiryDate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberRegisterPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="jobApplicationPageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? defaultLanguageId, System.Int32? defaultDynamicPageId, System.Boolean? publicJobsSearch, System.Boolean? publicMembersSearch, System.Boolean? publicCompaniesSearch, System.Boolean? publicSponsoredAdverts, System.Boolean? privateJobs, System.Boolean? privateMembers, System.Boolean? privateCompanies, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String pageTitlePrefix, System.String pageTitleSuffix, System.String defaultTitle, System.String homeTitle, System.String defaultDescription, System.String homeDescription, System.String defaultKeywords, System.String homeKeywords, System.Boolean? showFaceBookButton, System.Int32? useAdvertiserFilter, System.Int32? merchantId, System.Boolean? showTwitterButton, System.Boolean? showJobAlertButton, System.Boolean? showLinkedInButton, System.Int32? siteFavIconId, System.String siteDocType, System.String currencySymbol, System.String ftpFolderLocation, System.String metaTags, System.String systemMetaTags, System.String memberRegistrationNotification, System.String linkedInApi, System.String linkedInLogo, System.Int32? linkedInCompanyId, System.String linkedInEmail, System.String privacySettings, System.Boolean? wwwRedirect, System.Boolean? allowAdvertiser, System.String linkedInApiSecret, System.String googleClientId, System.String googleClientSecret, System.String facebookAppId, System.String facebookAppSecret, System.Int32? linkedInButtonSize, System.Int32? defaultCountryId, System.String payPalUsername, System.String payPalPassword, System.String payPalSignature, System.String securePayMerchantId, System.String securePayPassword, System.Boolean? usingSsl, System.Boolean? useCustomProfessionRole, System.Boolean? generateJobXml, System.Boolean? isPrivateSite, System.String privateRedirectUrl, System.Boolean? enableJobCustomQuestionnaire, System.Int32? jobApplicationTypeId, System.Boolean? jobScreeningProcess, System.Int32? advertiserApprovalProcess, System.Int32? siteType, System.Boolean? enableSsl, System.Decimal? gst, System.String gstLabel, System.Int32? numberOfPremiumJobs, System.Int32? premiumJobDays, System.Boolean? displayPremiumJobsOnResults, System.Boolean? jobExpiryNotification, System.Int32? currencyId, System.String payPalClientId, System.String payPalClientSecret, System.String paypalUser, System.String paypalProPassword, System.String paypalVendor, System.String paypalPartner, System.String invoiceSiteInfo, System.String invoiceSiteFooter, System.Boolean? enableTermsAndConditions, System.Int32? defaultEmailLanguageId, System.String googleTagManager, System.String googleAnalytics, System.String googleWebMaster, System.Boolean? enablePeopleSearch, System.String globalDateFormat, System.String timeZone, System.String globalFolder, System.Boolean? enableScreeningQuestions, System.Boolean? enableExpiryDate, System.Int32? memberRegisterPageId, System.Int32? jobApplicationPageId, ref System.Int32? globalSettingId);
		
		#endregion
		
		#region GlobalSettings_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region GlobalSettings_Get_List 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Get_List' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region GlobalSettings_GetBySiteFavIconId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteFavIconId' stored procedure. 
		/// </summary>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteFavIconId(int start, int pageLength, System.Int32? siteFavIconId)
		{
			return GetBySiteFavIconId(null, start, pageLength , siteFavIconId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteFavIconId' stored procedure. 
		/// </summary>
		/// <param name="siteFavIconId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteFavIconId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteFavIconId);
		
		#endregion
		
		#region GlobalSettings_CustomGetPaymentDetail 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_CustomGetPaymentDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetPaymentDetail(System.Int32? siteId)
		{
			return CustomGetPaymentDetail(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_CustomGetPaymentDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetPaymentDetail(int start, int pageLength, System.Int32? siteId)
		{
			return CustomGetPaymentDetail(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_CustomGetPaymentDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetPaymentDetail(TransactionManager transactionManager, System.Int32? siteId)
		{
			return CustomGetPaymentDetail(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_CustomGetPaymentDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetPaymentDetail(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region GlobalSettings_GetBySiteIdPublicJobsSearch 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdPublicJobsSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPublicJobsSearch(System.Int32? siteId, System.Boolean? publicJobsSearch)
		{
			return GetBySiteIdPublicJobsSearch(null, 0, int.MaxValue , siteId, publicJobsSearch);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdPublicJobsSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPublicJobsSearch(int start, int pageLength, System.Int32? siteId, System.Boolean? publicJobsSearch)
		{
			return GetBySiteIdPublicJobsSearch(null, start, pageLength , siteId, publicJobsSearch);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdPublicJobsSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPublicJobsSearch(TransactionManager transactionManager, System.Int32? siteId, System.Boolean? publicJobsSearch)
		{
			return GetBySiteIdPublicJobsSearch(transactionManager, 0, int.MaxValue , siteId, publicJobsSearch);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdPublicJobsSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="publicJobsSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdPublicJobsSearch(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Boolean? publicJobsSearch);
		
		#endregion
		
		#region GlobalSettings_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'GlobalSettings_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region GlobalSettings_Delete 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Delete' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? globalSettingId)
		{
			 Delete(null, 0, int.MaxValue , globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Delete' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? globalSettingId)
		{
			 Delete(null, start, pageLength , globalSettingId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_Delete' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? globalSettingId)
		{
			 Delete(transactionManager, 0, int.MaxValue , globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_Delete' stored procedure. 
		/// </summary>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? globalSettingId);
		
		#endregion
		
		#region GlobalSettings_GetBySiteIdGlobalSettingId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdGlobalSettingId(System.Int32? siteId, System.Int32? globalSettingId)
		{
			return GetBySiteIdGlobalSettingId(null, 0, int.MaxValue , siteId, globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdGlobalSettingId(int start, int pageLength, System.Int32? siteId, System.Int32? globalSettingId)
		{
			return GetBySiteIdGlobalSettingId(null, start, pageLength , siteId, globalSettingId);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdGlobalSettingId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? globalSettingId)
		{
			return GetBySiteIdGlobalSettingId(transactionManager, 0, int.MaxValue , siteId, globalSettingId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdGlobalSettingId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="globalSettingId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdGlobalSettingId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? globalSettingId);
		
		#endregion
		
		#region GlobalSettings_GetBySiteIdUseAdvertiserFilter 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdUseAdvertiserFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUseAdvertiserFilter(System.Int32? siteId, System.Int32? useAdvertiserFilter)
		{
			return GetBySiteIdUseAdvertiserFilter(null, 0, int.MaxValue , siteId, useAdvertiserFilter);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdUseAdvertiserFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUseAdvertiserFilter(int start, int pageLength, System.Int32? siteId, System.Int32? useAdvertiserFilter)
		{
			return GetBySiteIdUseAdvertiserFilter(null, start, pageLength , siteId, useAdvertiserFilter);
		}
				
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdUseAdvertiserFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUseAdvertiserFilter(TransactionManager transactionManager, System.Int32? siteId, System.Int32? useAdvertiserFilter)
		{
			return GetBySiteIdUseAdvertiserFilter(transactionManager, 0, int.MaxValue , siteId, useAdvertiserFilter);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetBySiteIdUseAdvertiserFilter' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="useAdvertiserFilter"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdUseAdvertiserFilter(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? useAdvertiserFilter);
		
		#endregion
		
		#region GlobalSettings_GetByDefaultDynamicPageId 
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDefaultDynamicPageId(int start, int pageLength, System.Int32? defaultDynamicPageId)
		{
			return GetByDefaultDynamicPageId(null, start, pageLength , defaultDynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'GlobalSettings_GetByDefaultDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="defaultDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDefaultDynamicPageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultDynamicPageId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;GlobalSettings&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;GlobalSettings&gt;"/></returns>
		public static TList<GlobalSettings> Fill(IDataReader reader, TList<GlobalSettings> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.GlobalSettings c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("GlobalSettings")
					.Append("|").Append((System.Int32)reader[((int)GlobalSettingsColumn.GlobalSettingId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<GlobalSettings>(
					key.ToString(), // EntityTrackingKey
					"GlobalSettings",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.GlobalSettings();
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
					c.GlobalSettingId = (System.Int32)reader[((int)GlobalSettingsColumn.GlobalSettingId - 1)];
					c.SiteId = (System.Int32)reader[((int)GlobalSettingsColumn.SiteId - 1)];
					c.DefaultLanguageId = (System.Int32)reader[((int)GlobalSettingsColumn.DefaultLanguageId - 1)];
					c.DefaultDynamicPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultDynamicPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultDynamicPageId - 1)];
					c.PublicJobsSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicJobsSearch - 1)];
					c.PublicMembersSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicMembersSearch - 1)];
					c.PublicCompaniesSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicCompaniesSearch - 1)];
					c.PublicSponsoredAdverts = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicSponsoredAdverts - 1)];
					c.PrivateJobs = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateJobs - 1)];
					c.PrivateMembers = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateMembers - 1)];
					c.PrivateCompanies = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateCompanies - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)GlobalSettingsColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)GlobalSettingsColumn.LastModified - 1)];
					c.PageTitlePrefix = (reader.IsDBNull(((int)GlobalSettingsColumn.PageTitlePrefix - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PageTitlePrefix - 1)];
					c.PageTitleSuffix = (reader.IsDBNull(((int)GlobalSettingsColumn.PageTitleSuffix - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PageTitleSuffix - 1)];
					c.DefaultTitle = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultTitle - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultTitle - 1)];
					c.HomeTitle = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeTitle - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeTitle - 1)];
					c.DefaultDescription = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultDescription - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultDescription - 1)];
					c.HomeDescription = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeDescription - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeDescription - 1)];
					c.DefaultKeywords = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultKeywords - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultKeywords - 1)];
					c.HomeKeywords = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeKeywords - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeKeywords - 1)];
					c.ShowFaceBookButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowFaceBookButton - 1)];
					c.UseAdvertiserFilter = (System.Int32)reader[((int)GlobalSettingsColumn.UseAdvertiserFilter - 1)];
					c.MerchantId = (reader.IsDBNull(((int)GlobalSettingsColumn.MerchantId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.MerchantId - 1)];
					c.ShowTwitterButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowTwitterButton - 1)];
					c.ShowJobAlertButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowJobAlertButton - 1)];
					c.ShowLinkedInButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowLinkedInButton - 1)];
					c.SiteFavIconId = (reader.IsDBNull(((int)GlobalSettingsColumn.SiteFavIconId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.SiteFavIconId - 1)];
					c.SiteDocType = (reader.IsDBNull(((int)GlobalSettingsColumn.SiteDocType - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SiteDocType - 1)];
					c.CurrencySymbol = (reader.IsDBNull(((int)GlobalSettingsColumn.CurrencySymbol - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.CurrencySymbol - 1)];
					c.FtpFolderLocation = (reader.IsDBNull(((int)GlobalSettingsColumn.FtpFolderLocation - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FtpFolderLocation - 1)];
					c.MetaTags = (reader.IsDBNull(((int)GlobalSettingsColumn.MetaTags - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.MetaTags - 1)];
					c.SystemMetaTags = (reader.IsDBNull(((int)GlobalSettingsColumn.SystemMetaTags - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SystemMetaTags - 1)];
					c.MemberRegistrationNotification = (reader.IsDBNull(((int)GlobalSettingsColumn.MemberRegistrationNotification - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.MemberRegistrationNotification - 1)];
					c.LinkedInApi = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInApi - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInApi - 1)];
					c.LinkedInLogo = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInLogo - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInLogo - 1)];
					c.LinkedInCompanyId = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInCompanyId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.LinkedInCompanyId - 1)];
					c.LinkedInEmail = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInEmail - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInEmail - 1)];
					c.PrivacySettings = (reader.IsDBNull(((int)GlobalSettingsColumn.PrivacySettings - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PrivacySettings - 1)];
					c.WwwRedirect = (System.Boolean)reader[((int)GlobalSettingsColumn.WwwRedirect - 1)];
					c.AllowAdvertiser = (System.Boolean)reader[((int)GlobalSettingsColumn.AllowAdvertiser - 1)];
					c.LinkedInApiSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInApiSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInApiSecret - 1)];
					c.GoogleClientId = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleClientId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleClientId - 1)];
					c.GoogleClientSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleClientSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleClientSecret - 1)];
					c.FacebookAppId = (reader.IsDBNull(((int)GlobalSettingsColumn.FacebookAppId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FacebookAppId - 1)];
					c.FacebookAppSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.FacebookAppSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FacebookAppSecret - 1)];
					c.LinkedInButtonSize = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInButtonSize - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.LinkedInButtonSize - 1)];
					c.DefaultCountryId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultCountryId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultCountryId - 1)];
					c.PayPalUsername = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalUsername - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalUsername - 1)];
					c.PayPalPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalPassword - 1)];
					c.PayPalSignature = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalSignature - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalSignature - 1)];
					c.SecurePayMerchantId = (reader.IsDBNull(((int)GlobalSettingsColumn.SecurePayMerchantId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SecurePayMerchantId - 1)];
					c.SecurePayPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.SecurePayPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SecurePayPassword - 1)];
					c.UsingSsl = (System.Boolean)reader[((int)GlobalSettingsColumn.UsingSsl - 1)];
					c.UseCustomProfessionRole = (System.Boolean)reader[((int)GlobalSettingsColumn.UseCustomProfessionRole - 1)];
					c.GenerateJobXml = (System.Boolean)reader[((int)GlobalSettingsColumn.GenerateJobXml - 1)];
					c.IsPrivateSite = (reader.IsDBNull(((int)GlobalSettingsColumn.IsPrivateSite - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.IsPrivateSite - 1)];
					c.PrivateRedirectUrl = (reader.IsDBNull(((int)GlobalSettingsColumn.PrivateRedirectUrl - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PrivateRedirectUrl - 1)];
					c.EnableJobCustomQuestionnaire = (reader.IsDBNull(((int)GlobalSettingsColumn.EnableJobCustomQuestionnaire - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.EnableJobCustomQuestionnaire - 1)];
					c.JobApplicationTypeId = (reader.IsDBNull(((int)GlobalSettingsColumn.JobApplicationTypeId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.JobApplicationTypeId - 1)];
					c.JobScreeningProcess = (reader.IsDBNull(((int)GlobalSettingsColumn.JobScreeningProcess - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.JobScreeningProcess - 1)];
					c.AdvertiserApprovalProcess = (reader.IsDBNull(((int)GlobalSettingsColumn.AdvertiserApprovalProcess - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.AdvertiserApprovalProcess - 1)];
					c.SiteType = (System.Int32)reader[((int)GlobalSettingsColumn.SiteType - 1)];
					c.EnableSsl = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableSsl - 1)];
					c.Gst = (System.Decimal)reader[((int)GlobalSettingsColumn.Gst - 1)];
					c.GstLabel = (reader.IsDBNull(((int)GlobalSettingsColumn.GstLabel - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GstLabel - 1)];
					c.NumberOfPremiumJobs = (System.Int32)reader[((int)GlobalSettingsColumn.NumberOfPremiumJobs - 1)];
					c.PremiumJobDays = (System.Int32)reader[((int)GlobalSettingsColumn.PremiumJobDays - 1)];
					c.DisplayPremiumJobsOnResults = (System.Boolean)reader[((int)GlobalSettingsColumn.DisplayPremiumJobsOnResults - 1)];
					c.JobExpiryNotification = (System.Boolean)reader[((int)GlobalSettingsColumn.JobExpiryNotification - 1)];
					c.CurrencyId = (System.Int32)reader[((int)GlobalSettingsColumn.CurrencyId - 1)];
					c.PayPalClientId = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalClientId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalClientId - 1)];
					c.PayPalClientSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalClientSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalClientSecret - 1)];
					c.PaypalUser = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalUser - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalUser - 1)];
					c.PaypalProPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalProPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalProPassword - 1)];
					c.PaypalVendor = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalVendor - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalVendor - 1)];
					c.PaypalPartner = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalPartner - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalPartner - 1)];
					c.InvoiceSiteInfo = (reader.IsDBNull(((int)GlobalSettingsColumn.InvoiceSiteInfo - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.InvoiceSiteInfo - 1)];
					c.InvoiceSiteFooter = (reader.IsDBNull(((int)GlobalSettingsColumn.InvoiceSiteFooter - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.InvoiceSiteFooter - 1)];
					c.EnableTermsAndConditions = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableTermsAndConditions - 1)];
					c.DefaultEmailLanguageId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultEmailLanguageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultEmailLanguageId - 1)];
					c.GoogleTagManager = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleTagManager - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleTagManager - 1)];
					c.GoogleAnalytics = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleAnalytics - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleAnalytics - 1)];
					c.GoogleWebMaster = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleWebMaster - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleWebMaster - 1)];
					c.EnablePeopleSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.EnablePeopleSearch - 1)];
					c.GlobalDateFormat = (System.String)reader[((int)GlobalSettingsColumn.GlobalDateFormat - 1)];
					c.TimeZone = (System.String)reader[((int)GlobalSettingsColumn.TimeZone - 1)];
					c.GlobalFolder = (reader.IsDBNull(((int)GlobalSettingsColumn.GlobalFolder - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GlobalFolder - 1)];
					c.EnableScreeningQuestions = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableScreeningQuestions - 1)];
					c.EnableExpiryDate = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableExpiryDate - 1)];
					c.MemberRegisterPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.MemberRegisterPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.MemberRegisterPageId - 1)];
					c.JobApplicationPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.JobApplicationPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.JobApplicationPageId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalSettings"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalSettings"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.GlobalSettings entity)
		{
			if (!reader.Read()) return;
			
			entity.GlobalSettingId = (System.Int32)reader[((int)GlobalSettingsColumn.GlobalSettingId - 1)];
			entity.SiteId = (System.Int32)reader[((int)GlobalSettingsColumn.SiteId - 1)];
			entity.DefaultLanguageId = (System.Int32)reader[((int)GlobalSettingsColumn.DefaultLanguageId - 1)];
			entity.DefaultDynamicPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultDynamicPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultDynamicPageId - 1)];
			entity.PublicJobsSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicJobsSearch - 1)];
			entity.PublicMembersSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicMembersSearch - 1)];
			entity.PublicCompaniesSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicCompaniesSearch - 1)];
			entity.PublicSponsoredAdverts = (System.Boolean)reader[((int)GlobalSettingsColumn.PublicSponsoredAdverts - 1)];
			entity.PrivateJobs = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateJobs - 1)];
			entity.PrivateMembers = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateMembers - 1)];
			entity.PrivateCompanies = (System.Boolean)reader[((int)GlobalSettingsColumn.PrivateCompanies - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)GlobalSettingsColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)GlobalSettingsColumn.LastModified - 1)];
			entity.PageTitlePrefix = (reader.IsDBNull(((int)GlobalSettingsColumn.PageTitlePrefix - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PageTitlePrefix - 1)];
			entity.PageTitleSuffix = (reader.IsDBNull(((int)GlobalSettingsColumn.PageTitleSuffix - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PageTitleSuffix - 1)];
			entity.DefaultTitle = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultTitle - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultTitle - 1)];
			entity.HomeTitle = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeTitle - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeTitle - 1)];
			entity.DefaultDescription = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultDescription - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultDescription - 1)];
			entity.HomeDescription = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeDescription - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeDescription - 1)];
			entity.DefaultKeywords = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultKeywords - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.DefaultKeywords - 1)];
			entity.HomeKeywords = (reader.IsDBNull(((int)GlobalSettingsColumn.HomeKeywords - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.HomeKeywords - 1)];
			entity.ShowFaceBookButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowFaceBookButton - 1)];
			entity.UseAdvertiserFilter = (System.Int32)reader[((int)GlobalSettingsColumn.UseAdvertiserFilter - 1)];
			entity.MerchantId = (reader.IsDBNull(((int)GlobalSettingsColumn.MerchantId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.MerchantId - 1)];
			entity.ShowTwitterButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowTwitterButton - 1)];
			entity.ShowJobAlertButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowJobAlertButton - 1)];
			entity.ShowLinkedInButton = (System.Boolean)reader[((int)GlobalSettingsColumn.ShowLinkedInButton - 1)];
			entity.SiteFavIconId = (reader.IsDBNull(((int)GlobalSettingsColumn.SiteFavIconId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.SiteFavIconId - 1)];
			entity.SiteDocType = (reader.IsDBNull(((int)GlobalSettingsColumn.SiteDocType - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SiteDocType - 1)];
			entity.CurrencySymbol = (reader.IsDBNull(((int)GlobalSettingsColumn.CurrencySymbol - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.CurrencySymbol - 1)];
			entity.FtpFolderLocation = (reader.IsDBNull(((int)GlobalSettingsColumn.FtpFolderLocation - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FtpFolderLocation - 1)];
			entity.MetaTags = (reader.IsDBNull(((int)GlobalSettingsColumn.MetaTags - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.MetaTags - 1)];
			entity.SystemMetaTags = (reader.IsDBNull(((int)GlobalSettingsColumn.SystemMetaTags - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SystemMetaTags - 1)];
			entity.MemberRegistrationNotification = (reader.IsDBNull(((int)GlobalSettingsColumn.MemberRegistrationNotification - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.MemberRegistrationNotification - 1)];
			entity.LinkedInApi = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInApi - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInApi - 1)];
			entity.LinkedInLogo = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInLogo - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInLogo - 1)];
			entity.LinkedInCompanyId = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInCompanyId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.LinkedInCompanyId - 1)];
			entity.LinkedInEmail = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInEmail - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInEmail - 1)];
			entity.PrivacySettings = (reader.IsDBNull(((int)GlobalSettingsColumn.PrivacySettings - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PrivacySettings - 1)];
			entity.WwwRedirect = (System.Boolean)reader[((int)GlobalSettingsColumn.WwwRedirect - 1)];
			entity.AllowAdvertiser = (System.Boolean)reader[((int)GlobalSettingsColumn.AllowAdvertiser - 1)];
			entity.LinkedInApiSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInApiSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.LinkedInApiSecret - 1)];
			entity.GoogleClientId = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleClientId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleClientId - 1)];
			entity.GoogleClientSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleClientSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleClientSecret - 1)];
			entity.FacebookAppId = (reader.IsDBNull(((int)GlobalSettingsColumn.FacebookAppId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FacebookAppId - 1)];
			entity.FacebookAppSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.FacebookAppSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.FacebookAppSecret - 1)];
			entity.LinkedInButtonSize = (reader.IsDBNull(((int)GlobalSettingsColumn.LinkedInButtonSize - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.LinkedInButtonSize - 1)];
			entity.DefaultCountryId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultCountryId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultCountryId - 1)];
			entity.PayPalUsername = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalUsername - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalUsername - 1)];
			entity.PayPalPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalPassword - 1)];
			entity.PayPalSignature = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalSignature - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalSignature - 1)];
			entity.SecurePayMerchantId = (reader.IsDBNull(((int)GlobalSettingsColumn.SecurePayMerchantId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SecurePayMerchantId - 1)];
			entity.SecurePayPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.SecurePayPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.SecurePayPassword - 1)];
			entity.UsingSsl = (System.Boolean)reader[((int)GlobalSettingsColumn.UsingSsl - 1)];
			entity.UseCustomProfessionRole = (System.Boolean)reader[((int)GlobalSettingsColumn.UseCustomProfessionRole - 1)];
			entity.GenerateJobXml = (System.Boolean)reader[((int)GlobalSettingsColumn.GenerateJobXml - 1)];
			entity.IsPrivateSite = (reader.IsDBNull(((int)GlobalSettingsColumn.IsPrivateSite - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.IsPrivateSite - 1)];
			entity.PrivateRedirectUrl = (reader.IsDBNull(((int)GlobalSettingsColumn.PrivateRedirectUrl - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PrivateRedirectUrl - 1)];
			entity.EnableJobCustomQuestionnaire = (reader.IsDBNull(((int)GlobalSettingsColumn.EnableJobCustomQuestionnaire - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.EnableJobCustomQuestionnaire - 1)];
			entity.JobApplicationTypeId = (reader.IsDBNull(((int)GlobalSettingsColumn.JobApplicationTypeId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.JobApplicationTypeId - 1)];
			entity.JobScreeningProcess = (reader.IsDBNull(((int)GlobalSettingsColumn.JobScreeningProcess - 1)))?null:(System.Boolean?)reader[((int)GlobalSettingsColumn.JobScreeningProcess - 1)];
			entity.AdvertiserApprovalProcess = (reader.IsDBNull(((int)GlobalSettingsColumn.AdvertiserApprovalProcess - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.AdvertiserApprovalProcess - 1)];
			entity.SiteType = (System.Int32)reader[((int)GlobalSettingsColumn.SiteType - 1)];
			entity.EnableSsl = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableSsl - 1)];
			entity.Gst = (System.Decimal)reader[((int)GlobalSettingsColumn.Gst - 1)];
			entity.GstLabel = (reader.IsDBNull(((int)GlobalSettingsColumn.GstLabel - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GstLabel - 1)];
			entity.NumberOfPremiumJobs = (System.Int32)reader[((int)GlobalSettingsColumn.NumberOfPremiumJobs - 1)];
			entity.PremiumJobDays = (System.Int32)reader[((int)GlobalSettingsColumn.PremiumJobDays - 1)];
			entity.DisplayPremiumJobsOnResults = (System.Boolean)reader[((int)GlobalSettingsColumn.DisplayPremiumJobsOnResults - 1)];
			entity.JobExpiryNotification = (System.Boolean)reader[((int)GlobalSettingsColumn.JobExpiryNotification - 1)];
			entity.CurrencyId = (System.Int32)reader[((int)GlobalSettingsColumn.CurrencyId - 1)];
			entity.PayPalClientId = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalClientId - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalClientId - 1)];
			entity.PayPalClientSecret = (reader.IsDBNull(((int)GlobalSettingsColumn.PayPalClientSecret - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PayPalClientSecret - 1)];
			entity.PaypalUser = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalUser - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalUser - 1)];
			entity.PaypalProPassword = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalProPassword - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalProPassword - 1)];
			entity.PaypalVendor = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalVendor - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalVendor - 1)];
			entity.PaypalPartner = (reader.IsDBNull(((int)GlobalSettingsColumn.PaypalPartner - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.PaypalPartner - 1)];
			entity.InvoiceSiteInfo = (reader.IsDBNull(((int)GlobalSettingsColumn.InvoiceSiteInfo - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.InvoiceSiteInfo - 1)];
			entity.InvoiceSiteFooter = (reader.IsDBNull(((int)GlobalSettingsColumn.InvoiceSiteFooter - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.InvoiceSiteFooter - 1)];
			entity.EnableTermsAndConditions = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableTermsAndConditions - 1)];
			entity.DefaultEmailLanguageId = (reader.IsDBNull(((int)GlobalSettingsColumn.DefaultEmailLanguageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.DefaultEmailLanguageId - 1)];
			entity.GoogleTagManager = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleTagManager - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleTagManager - 1)];
			entity.GoogleAnalytics = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleAnalytics - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleAnalytics - 1)];
			entity.GoogleWebMaster = (reader.IsDBNull(((int)GlobalSettingsColumn.GoogleWebMaster - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GoogleWebMaster - 1)];
			entity.EnablePeopleSearch = (System.Boolean)reader[((int)GlobalSettingsColumn.EnablePeopleSearch - 1)];
			entity.GlobalDateFormat = (System.String)reader[((int)GlobalSettingsColumn.GlobalDateFormat - 1)];
			entity.TimeZone = (System.String)reader[((int)GlobalSettingsColumn.TimeZone - 1)];
			entity.GlobalFolder = (reader.IsDBNull(((int)GlobalSettingsColumn.GlobalFolder - 1)))?null:(System.String)reader[((int)GlobalSettingsColumn.GlobalFolder - 1)];
			entity.EnableScreeningQuestions = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableScreeningQuestions - 1)];
			entity.EnableExpiryDate = (System.Boolean)reader[((int)GlobalSettingsColumn.EnableExpiryDate - 1)];
			entity.MemberRegisterPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.MemberRegisterPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.MemberRegisterPageId - 1)];
			entity.JobApplicationPageId = (reader.IsDBNull(((int)GlobalSettingsColumn.JobApplicationPageId - 1)))?null:(System.Int32?)reader[((int)GlobalSettingsColumn.JobApplicationPageId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.GlobalSettings"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalSettings"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.GlobalSettings entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GlobalSettingId = (System.Int32)dataRow["GlobalSettingID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.DefaultLanguageId = (System.Int32)dataRow["DefaultLanguageID"];
			entity.DefaultDynamicPageId = Convert.IsDBNull(dataRow["DefaultDynamicPageID"]) ? null : (System.Int32?)dataRow["DefaultDynamicPageID"];
			entity.PublicJobsSearch = (System.Boolean)dataRow["PublicJobsSearch"];
			entity.PublicMembersSearch = (System.Boolean)dataRow["PublicMembersSearch"];
			entity.PublicCompaniesSearch = (System.Boolean)dataRow["PublicCompaniesSearch"];
			entity.PublicSponsoredAdverts = (System.Boolean)dataRow["PublicSponsoredAdverts"];
			entity.PrivateJobs = (System.Boolean)dataRow["PrivateJobs"];
			entity.PrivateMembers = (System.Boolean)dataRow["PrivateMembers"];
			entity.PrivateCompanies = (System.Boolean)dataRow["PrivateCompanies"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.PageTitlePrefix = Convert.IsDBNull(dataRow["PageTitlePrefix"]) ? null : (System.String)dataRow["PageTitlePrefix"];
			entity.PageTitleSuffix = Convert.IsDBNull(dataRow["PageTitleSuffix"]) ? null : (System.String)dataRow["PageTitleSuffix"];
			entity.DefaultTitle = Convert.IsDBNull(dataRow["DefaultTitle"]) ? null : (System.String)dataRow["DefaultTitle"];
			entity.HomeTitle = Convert.IsDBNull(dataRow["HomeTitle"]) ? null : (System.String)dataRow["HomeTitle"];
			entity.DefaultDescription = Convert.IsDBNull(dataRow["DefaultDescription"]) ? null : (System.String)dataRow["DefaultDescription"];
			entity.HomeDescription = Convert.IsDBNull(dataRow["HomeDescription"]) ? null : (System.String)dataRow["HomeDescription"];
			entity.DefaultKeywords = Convert.IsDBNull(dataRow["DefaultKeywords"]) ? null : (System.String)dataRow["DefaultKeywords"];
			entity.HomeKeywords = Convert.IsDBNull(dataRow["HomeKeywords"]) ? null : (System.String)dataRow["HomeKeywords"];
			entity.ShowFaceBookButton = (System.Boolean)dataRow["ShowFaceBookButton"];
			entity.UseAdvertiserFilter = (System.Int32)dataRow["UseAdvertiserFilter"];
			entity.MerchantId = Convert.IsDBNull(dataRow["MerchantID"]) ? null : (System.Int32?)dataRow["MerchantID"];
			entity.ShowTwitterButton = (System.Boolean)dataRow["ShowTwitterButton"];
			entity.ShowJobAlertButton = (System.Boolean)dataRow["ShowJobAlertButton"];
			entity.ShowLinkedInButton = (System.Boolean)dataRow["ShowLinkedInButton"];
			entity.SiteFavIconId = Convert.IsDBNull(dataRow["SiteFavIconID"]) ? null : (System.Int32?)dataRow["SiteFavIconID"];
			entity.SiteDocType = Convert.IsDBNull(dataRow["SiteDocType"]) ? null : (System.String)dataRow["SiteDocType"];
			entity.CurrencySymbol = Convert.IsDBNull(dataRow["CurrencySymbol"]) ? null : (System.String)dataRow["CurrencySymbol"];
			entity.FtpFolderLocation = Convert.IsDBNull(dataRow["FtpFolderLocation"]) ? null : (System.String)dataRow["FtpFolderLocation"];
			entity.MetaTags = Convert.IsDBNull(dataRow["MetaTags"]) ? null : (System.String)dataRow["MetaTags"];
			entity.SystemMetaTags = Convert.IsDBNull(dataRow["SystemMetaTags"]) ? null : (System.String)dataRow["SystemMetaTags"];
			entity.MemberRegistrationNotification = Convert.IsDBNull(dataRow["MemberRegistrationNotification"]) ? null : (System.String)dataRow["MemberRegistrationNotification"];
			entity.LinkedInApi = Convert.IsDBNull(dataRow["LinkedInAPI"]) ? null : (System.String)dataRow["LinkedInAPI"];
			entity.LinkedInLogo = Convert.IsDBNull(dataRow["LinkedInLogo"]) ? null : (System.String)dataRow["LinkedInLogo"];
			entity.LinkedInCompanyId = Convert.IsDBNull(dataRow["LinkedInCompanyID"]) ? null : (System.Int32?)dataRow["LinkedInCompanyID"];
			entity.LinkedInEmail = Convert.IsDBNull(dataRow["LinkedInEmail"]) ? null : (System.String)dataRow["LinkedInEmail"];
			entity.PrivacySettings = Convert.IsDBNull(dataRow["PrivacySettings"]) ? null : (System.String)dataRow["PrivacySettings"];
			entity.WwwRedirect = (System.Boolean)dataRow["WWWRedirect"];
			entity.AllowAdvertiser = (System.Boolean)dataRow["AllowAdvertiser"];
			entity.LinkedInApiSecret = Convert.IsDBNull(dataRow["LinkedInAPISecret"]) ? null : (System.String)dataRow["LinkedInAPISecret"];
			entity.GoogleClientId = Convert.IsDBNull(dataRow["GoogleClientID"]) ? null : (System.String)dataRow["GoogleClientID"];
			entity.GoogleClientSecret = Convert.IsDBNull(dataRow["GoogleClientSecret"]) ? null : (System.String)dataRow["GoogleClientSecret"];
			entity.FacebookAppId = Convert.IsDBNull(dataRow["FacebookAppID"]) ? null : (System.String)dataRow["FacebookAppID"];
			entity.FacebookAppSecret = Convert.IsDBNull(dataRow["FacebookAppSecret"]) ? null : (System.String)dataRow["FacebookAppSecret"];
			entity.LinkedInButtonSize = Convert.IsDBNull(dataRow["LinkedInButtonSize"]) ? null : (System.Int32?)dataRow["LinkedInButtonSize"];
			entity.DefaultCountryId = Convert.IsDBNull(dataRow["DefaultCountryID"]) ? null : (System.Int32?)dataRow["DefaultCountryID"];
			entity.PayPalUsername = Convert.IsDBNull(dataRow["PayPalUsername"]) ? null : (System.String)dataRow["PayPalUsername"];
			entity.PayPalPassword = Convert.IsDBNull(dataRow["PayPalPassword"]) ? null : (System.String)dataRow["PayPalPassword"];
			entity.PayPalSignature = Convert.IsDBNull(dataRow["PayPalSignature"]) ? null : (System.String)dataRow["PayPalSignature"];
			entity.SecurePayMerchantId = Convert.IsDBNull(dataRow["SecurePayMerchantID"]) ? null : (System.String)dataRow["SecurePayMerchantID"];
			entity.SecurePayPassword = Convert.IsDBNull(dataRow["SecurePayPassword"]) ? null : (System.String)dataRow["SecurePayPassword"];
			entity.UsingSsl = (System.Boolean)dataRow["UsingSSL"];
			entity.UseCustomProfessionRole = (System.Boolean)dataRow["UseCustomProfessionRole"];
			entity.GenerateJobXml = (System.Boolean)dataRow["GenerateJobXML"];
			entity.IsPrivateSite = Convert.IsDBNull(dataRow["IsPrivateSite"]) ? null : (System.Boolean?)dataRow["IsPrivateSite"];
			entity.PrivateRedirectUrl = Convert.IsDBNull(dataRow["PrivateRedirectUrl"]) ? null : (System.String)dataRow["PrivateRedirectUrl"];
			entity.EnableJobCustomQuestionnaire = Convert.IsDBNull(dataRow["EnableJobCustomQuestionnaire"]) ? null : (System.Boolean?)dataRow["EnableJobCustomQuestionnaire"];
			entity.JobApplicationTypeId = Convert.IsDBNull(dataRow["JobApplicationTypeID"]) ? null : (System.Int32?)dataRow["JobApplicationTypeID"];
			entity.JobScreeningProcess = Convert.IsDBNull(dataRow["JobScreeningProcess"]) ? null : (System.Boolean?)dataRow["JobScreeningProcess"];
			entity.AdvertiserApprovalProcess = Convert.IsDBNull(dataRow["AdvertiserApprovalProcess"]) ? null : (System.Int32?)dataRow["AdvertiserApprovalProcess"];
			entity.SiteType = (System.Int32)dataRow["SiteType"];
			entity.EnableSsl = (System.Boolean)dataRow["EnableSSL"];
			entity.Gst = (System.Decimal)dataRow["GST"];
			entity.GstLabel = Convert.IsDBNull(dataRow["GSTLabel"]) ? null : (System.String)dataRow["GSTLabel"];
			entity.NumberOfPremiumJobs = (System.Int32)dataRow["NumberOfPremiumJobs"];
			entity.PremiumJobDays = (System.Int32)dataRow["PremiumJobDays"];
			entity.DisplayPremiumJobsOnResults = (System.Boolean)dataRow["DisplayPremiumJobsOnResults"];
			entity.JobExpiryNotification = (System.Boolean)dataRow["JobExpiryNotification"];
			entity.CurrencyId = (System.Int32)dataRow["CurrencyID"];
			entity.PayPalClientId = Convert.IsDBNull(dataRow["PayPalClientID"]) ? null : (System.String)dataRow["PayPalClientID"];
			entity.PayPalClientSecret = Convert.IsDBNull(dataRow["PayPalClientSecret"]) ? null : (System.String)dataRow["PayPalClientSecret"];
			entity.PaypalUser = Convert.IsDBNull(dataRow["PaypalUser"]) ? null : (System.String)dataRow["PaypalUser"];
			entity.PaypalProPassword = Convert.IsDBNull(dataRow["PaypalProPassword"]) ? null : (System.String)dataRow["PaypalProPassword"];
			entity.PaypalVendor = Convert.IsDBNull(dataRow["PaypalVendor"]) ? null : (System.String)dataRow["PaypalVendor"];
			entity.PaypalPartner = Convert.IsDBNull(dataRow["PaypalPartner"]) ? null : (System.String)dataRow["PaypalPartner"];
			entity.InvoiceSiteInfo = Convert.IsDBNull(dataRow["InvoiceSiteInfo"]) ? null : (System.String)dataRow["InvoiceSiteInfo"];
			entity.InvoiceSiteFooter = Convert.IsDBNull(dataRow["InvoiceSiteFooter"]) ? null : (System.String)dataRow["InvoiceSiteFooter"];
			entity.EnableTermsAndConditions = (System.Boolean)dataRow["EnableTermsAndConditions"];
			entity.DefaultEmailLanguageId = Convert.IsDBNull(dataRow["DefaultEmailLanguageId"]) ? null : (System.Int32?)dataRow["DefaultEmailLanguageId"];
			entity.GoogleTagManager = Convert.IsDBNull(dataRow["GoogleTagManager"]) ? null : (System.String)dataRow["GoogleTagManager"];
			entity.GoogleAnalytics = Convert.IsDBNull(dataRow["GoogleAnalytics"]) ? null : (System.String)dataRow["GoogleAnalytics"];
			entity.GoogleWebMaster = Convert.IsDBNull(dataRow["GoogleWebMaster"]) ? null : (System.String)dataRow["GoogleWebMaster"];
			entity.EnablePeopleSearch = (System.Boolean)dataRow["EnablePeopleSearch"];
			entity.GlobalDateFormat = (System.String)dataRow["GlobalDateFormat"];
			entity.TimeZone = (System.String)dataRow["TimeZone"];
			entity.GlobalFolder = Convert.IsDBNull(dataRow["GlobalFolder"]) ? null : (System.String)dataRow["GlobalFolder"];
			entity.EnableScreeningQuestions = (System.Boolean)dataRow["EnableScreeningQuestions"];
			entity.EnableExpiryDate = (System.Boolean)dataRow["EnableExpiryDate"];
			entity.MemberRegisterPageId = Convert.IsDBNull(dataRow["MemberRegisterPageID"]) ? null : (System.Int32?)dataRow["MemberRegisterPageID"];
			entity.JobApplicationPageId = Convert.IsDBNull(dataRow["JobApplicationPageID"]) ? null : (System.Int32?)dataRow["JobApplicationPageID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.GlobalSettings"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalSettings Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.GlobalSettings entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DefaultCountryIdSource	
			if (CanDeepLoad(entity, "Countries|DefaultCountryIdSource", deepLoadType, innerList) 
				&& entity.DefaultCountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DefaultCountryId ?? (int)0);
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultCountryIdSource = tmpEntity;
				else
					entity.DefaultCountryIdSource = DataRepository.CountriesProvider.GetByCountryId(transactionManager, (entity.DefaultCountryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultCountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultCountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.DefaultCountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultCountryIdSource

			#region DefaultLanguageIdSource	
			if (CanDeepLoad(entity, "Languages|DefaultLanguageIdSource", deepLoadType, innerList) 
				&& entity.DefaultLanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DefaultLanguageId;
				Languages tmpEntity = EntityManager.LocateEntity<Languages>(EntityLocator.ConstructKeyFromPkItems(typeof(Languages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultLanguageIdSource = tmpEntity;
				else
					entity.DefaultLanguageIdSource = DataRepository.LanguagesProvider.GetByLanguageId(transactionManager, entity.DefaultLanguageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultLanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultLanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguagesProvider.DeepLoad(transactionManager, entity.DefaultLanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultLanguageIdSource

			#region DefaultDynamicPageIdSource	
			if (CanDeepLoad(entity, "DynamicPages|DefaultDynamicPageIdSource", deepLoadType, innerList) 
				&& entity.DefaultDynamicPageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DefaultDynamicPageId ?? (int)0);
				DynamicPages tmpEntity = EntityManager.LocateEntity<DynamicPages>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultDynamicPageIdSource = tmpEntity;
				else
					entity.DefaultDynamicPageIdSource = DataRepository.DynamicPagesProvider.GetByDynamicPageId(transactionManager, (entity.DefaultDynamicPageId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultDynamicPageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultDynamicPageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPagesProvider.DeepLoad(transactionManager, entity.DefaultDynamicPageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultDynamicPageIdSource

			#region JobApplicationPageIdSource	
			if (CanDeepLoad(entity, "DynamicPages|JobApplicationPageIdSource", deepLoadType, innerList) 
				&& entity.JobApplicationPageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.JobApplicationPageId ?? (int)0);
				DynamicPages tmpEntity = EntityManager.LocateEntity<DynamicPages>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.JobApplicationPageIdSource = tmpEntity;
				else
					entity.JobApplicationPageIdSource = DataRepository.DynamicPagesProvider.GetByDynamicPageId(transactionManager, (entity.JobApplicationPageId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationPageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.JobApplicationPageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPagesProvider.DeepLoad(transactionManager, entity.JobApplicationPageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion JobApplicationPageIdSource

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

			#region MemberRegisterPageIdSource	
			if (CanDeepLoad(entity, "DynamicPages|MemberRegisterPageIdSource", deepLoadType, innerList) 
				&& entity.MemberRegisterPageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MemberRegisterPageId ?? (int)0);
				DynamicPages tmpEntity = EntityManager.LocateEntity<DynamicPages>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MemberRegisterPageIdSource = tmpEntity;
				else
					entity.MemberRegisterPageIdSource = DataRepository.DynamicPagesProvider.GetByDynamicPageId(transactionManager, (entity.MemberRegisterPageId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberRegisterPageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MemberRegisterPageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPagesProvider.DeepLoad(transactionManager, entity.MemberRegisterPageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MemberRegisterPageIdSource

			#region SiteFavIconIdSource	
			if (CanDeepLoad(entity, "Files|SiteFavIconIdSource", deepLoadType, innerList) 
				&& entity.SiteFavIconIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SiteFavIconId ?? (int)0);
				Files tmpEntity = EntityManager.LocateEntity<Files>(EntityLocator.ConstructKeyFromPkItems(typeof(Files), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SiteFavIconIdSource = tmpEntity;
				else
					entity.SiteFavIconIdSource = DataRepository.FilesProvider.GetByFileId(transactionManager, (entity.SiteFavIconId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteFavIconIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SiteFavIconIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FilesProvider.DeepLoad(transactionManager, entity.SiteFavIconIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SiteFavIconIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.GlobalSettings object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.GlobalSettings instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.GlobalSettings Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.GlobalSettings entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DefaultCountryIdSource
			if (CanDeepSave(entity, "Countries|DefaultCountryIdSource", deepSaveType, innerList) 
				&& entity.DefaultCountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.DefaultCountryIdSource);
				entity.DefaultCountryId = entity.DefaultCountryIdSource.CountryId;
			}
			#endregion 
			
			#region DefaultLanguageIdSource
			if (CanDeepSave(entity, "Languages|DefaultLanguageIdSource", deepSaveType, innerList) 
				&& entity.DefaultLanguageIdSource != null)
			{
				DataRepository.LanguagesProvider.Save(transactionManager, entity.DefaultLanguageIdSource);
				entity.DefaultLanguageId = entity.DefaultLanguageIdSource.LanguageId;
			}
			#endregion 
			
			#region DefaultDynamicPageIdSource
			if (CanDeepSave(entity, "DynamicPages|DefaultDynamicPageIdSource", deepSaveType, innerList) 
				&& entity.DefaultDynamicPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DefaultDynamicPageIdSource);
				entity.DefaultDynamicPageId = entity.DefaultDynamicPageIdSource.DynamicPageId;
			}
			#endregion 
			
			#region JobApplicationPageIdSource
			if (CanDeepSave(entity, "DynamicPages|JobApplicationPageIdSource", deepSaveType, innerList) 
				&& entity.JobApplicationPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.JobApplicationPageIdSource);
				entity.JobApplicationPageId = entity.JobApplicationPageIdSource.DynamicPageId;
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
			
			#region MemberRegisterPageIdSource
			if (CanDeepSave(entity, "DynamicPages|MemberRegisterPageIdSource", deepSaveType, innerList) 
				&& entity.MemberRegisterPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.MemberRegisterPageIdSource);
				entity.MemberRegisterPageId = entity.MemberRegisterPageIdSource.DynamicPageId;
			}
			#endregion 
			
			#region SiteFavIconIdSource
			if (CanDeepSave(entity, "Files|SiteFavIconIdSource", deepSaveType, innerList) 
				&& entity.SiteFavIconIdSource != null)
			{
				DataRepository.FilesProvider.Save(transactionManager, entity.SiteFavIconIdSource);
				entity.SiteFavIconId = entity.SiteFavIconIdSource.FileId;
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
	
	#region GlobalSettingsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.GlobalSettings</c>
	///</summary>
	public enum GlobalSettingsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at DefaultCountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
			
		///<summary>
		/// Composite Property for <c>Languages</c> at DefaultLanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
			
		///<summary>
		/// Composite Property for <c>DynamicPages</c> at DefaultDynamicPageIdSource
		///</summary>
		[ChildEntityType(typeof(DynamicPages))]
		DynamicPages,
			
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
			
		///<summary>
		/// Composite Property for <c>Files</c> at SiteFavIconIdSource
		///</summary>
		[ChildEntityType(typeof(Files))]
		Files,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion GlobalSettingsChildEntityTypes
	
	#region GlobalSettingsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GlobalSettingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsFilterBuilder : SqlFilterBuilder<GlobalSettingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilterBuilder class.
		/// </summary>
		public GlobalSettingsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalSettingsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalSettingsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalSettingsFilterBuilder
	
	#region GlobalSettingsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GlobalSettingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsParameterBuilder : ParameterizedSqlFilterBuilder<GlobalSettingsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsParameterBuilder class.
		/// </summary>
		public GlobalSettingsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalSettingsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalSettingsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalSettingsParameterBuilder
	
	#region GlobalSettingsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;GlobalSettingsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class GlobalSettingsSortBuilder : SqlSortBuilder<GlobalSettingsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsSqlSortBuilder class.
		/// </summary>
		public GlobalSettingsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion GlobalSettingsSortBuilder
	
} // end namespace
