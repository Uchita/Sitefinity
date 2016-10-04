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
	/// This class is the base class for any <see cref="EmailTemplatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailTemplatesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.EmailTemplates, JXTPortal.Entities.EmailTemplatesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.EmailTemplatesKey key)
		{
			return Delete(transactionManager, key.EmailTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_emailTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _emailTemplateId)
		{
			return Delete(null, _emailTemplateId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailTemplateId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _emailTemplateId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		FK__EmailTemp__LastM__2E3BD7D3 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		FK__EmailTemp__LastM__2E3BD7D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<EmailTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		FK__EmailTemp__LastM__2E3BD7D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		fkEmailTempLastm2e3Bd7d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		fkEmailTempLastm2e3Bd7d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__LastM__2E3BD7D3 key.
		///		FK__EmailTemp__LastM__2E3BD7D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public abstract TList<EmailTemplates> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		FK__EmailTemp__SiteI__08D548FA Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		FK__EmailTemp__SiteI__08D548FA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<EmailTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		FK__EmailTemp__SiteI__08D548FA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		fkEmailTempSitei08d548Fa Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		fkEmailTempSitei08d548Fa Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__EmailTemp__SiteI__08D548FA key.
		///		FK__EmailTemp__SiteI__08D548FA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public abstract TList<EmailTemplates> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		FK_EmailTemplates_LanguageID Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLanguageId(System.Int32? _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		FK_EmailTemplates_LanguageID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		/// <remarks></remarks>
		public TList<EmailTemplates> GetByLanguageId(TransactionManager transactionManager, System.Int32? _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		FK_EmailTemplates_LanguageID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLanguageId(TransactionManager transactionManager, System.Int32? _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		fkEmailTemplatesLanguageId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLanguageId(System.Int32? _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		fkEmailTemplatesLanguageId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public TList<EmailTemplates> GetByLanguageId(System.Int32? _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailTemplates_LanguageID key.
		///		FK_EmailTemplates_LanguageID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.EmailTemplates objects.</returns>
		public abstract TList<EmailTemplates> GetByLanguageId(TransactionManager transactionManager, System.Int32? _languageId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.EmailTemplates Get(TransactionManager transactionManager, JXTPortal.Entities.EmailTemplatesKey key, int start, int pageLength)
		{
			return GetByEmailTemplateId(transactionManager, key.EmailTemplateId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId)
		{
			int count = -1;
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(null,_siteId, _emailCode, _globalTemplate, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(null, _siteId, _emailCode, _globalTemplate, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId)
		{
			int count = -1;
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(transactionManager, _siteId, _emailCode, _globalTemplate, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(transactionManager, _siteId, _emailCode, _globalTemplate, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId, int start, int pageLength, out int count)
		{
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(null, _siteId, _emailCode, _globalTemplate, _languageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_EmailTemplates index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailCode"></param>
		/// <param name="_globalTemplate"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public abstract JXTPortal.Entities.EmailTemplates GetBySiteIdEmailCodeGlobalTemplateLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailCode, System.Boolean _globalTemplate, System.Int32? _languageId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="_emailTemplateId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(System.Int32 _emailTemplateId)
		{
			int count = -1;
			return GetByEmailTemplateId(null,_emailTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="_emailTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(System.Int32 _emailTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailTemplateId(null, _emailTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(TransactionManager transactionManager, System.Int32 _emailTemplateId)
		{
			int count = -1;
			return GetByEmailTemplateId(transactionManager, _emailTemplateId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(TransactionManager transactionManager, System.Int32 _emailTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailTemplateId(transactionManager, _emailTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="_emailTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(System.Int32 _emailTemplateId, int start, int pageLength, out int count)
		{
			return GetByEmailTemplateId(null, _emailTemplateId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_EmailT__2C538F61 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.EmailTemplates"/> class.</returns>
		public abstract JXTPortal.Entities.EmailTemplates GetByEmailTemplateId(TransactionManager transactionManager, System.Int32 _emailTemplateId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region EmailTemplates_GetBySiteIdEmailCodeGlobalTemplateLanguageId 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplateLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplateLanguageId(System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate, System.Int32? languageId)
		{
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(null, 0, int.MaxValue , siteId, emailCode, globalTemplate, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplateLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplateLanguageId(int start, int pageLength, System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate, System.Int32? languageId)
		{
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(null, start, pageLength , siteId, emailCode, globalTemplate, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplateLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplateLanguageId(TransactionManager transactionManager, System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate, System.Int32? languageId)
		{
			return GetBySiteIdEmailCodeGlobalTemplateLanguageId(transactionManager, 0, int.MaxValue , siteId, emailCode, globalTemplate, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplateLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdEmailCodeGlobalTemplateLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate, System.Int32? languageId);
		
		#endregion
		
		#region EmailTemplates_GetBySiteIdEmailCode 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<EmailTemplates> GetBySiteIdEmailCode(System.Int32? siteId, System.String emailCode)
		{
			return GetBySiteIdEmailCode(null, 0, int.MaxValue , siteId, emailCode);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<EmailTemplates> GetBySiteIdEmailCode(int start, int pageLength, System.Int32? siteId, System.String emailCode)
		{
			return GetBySiteIdEmailCode(null, start, pageLength , siteId, emailCode);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<EmailTemplates> GetBySiteIdEmailCode(TransactionManager transactionManager, System.Int32? siteId, System.String emailCode)
		{
			return GetBySiteIdEmailCode(transactionManager, 0, int.MaxValue , siteId, emailCode);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCode' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public abstract TList<EmailTemplates> GetBySiteIdEmailCode(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteId, System.String emailCode);
		
		#endregion
		
		#region EmailTemplates_GetBySiteIdEmailCodeGlobalTemplate 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplate(System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate)
		{
			return GetBySiteIdEmailCodeGlobalTemplate(null, 0, int.MaxValue , siteId, emailCode, globalTemplate);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplate(int start, int pageLength, System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate)
		{
			return GetBySiteIdEmailCodeGlobalTemplate(null, start, pageLength , siteId, emailCode, globalTemplate);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailCodeGlobalTemplate(TransactionManager transactionManager, System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate)
		{
			return GetBySiteIdEmailCodeGlobalTemplate(transactionManager, 0, int.MaxValue , siteId, emailCode, globalTemplate);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteIdEmailCodeGlobalTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdEmailCodeGlobalTemplate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String emailCode, System.Boolean? globalTemplate);
		
		#endregion
		
		#region EmailTemplates_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region EmailTemplates_GetByLanguageId 
		
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(int start, int pageLength, System.Int32? languageId)
		{
			return GetByLanguageId(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region EmailTemplates_GetPaged 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetPaged' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetPaged' stored procedure. 
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
		
		#region EmailTemplates_Insert 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId, ref System.Int32? emailTemplateId)
		{
			 Insert(null, 0, int.MaxValue , siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId, ref emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId, ref System.Int32? emailTemplateId)
		{
			 Insert(null, start, pageLength , siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId, ref emailTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId, ref System.Int32? emailTemplateId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId, ref emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId, ref System.Int32? emailTemplateId);
		
		#endregion
		
		#region EmailTemplates_GetByEmailTemplateId 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByEmailTemplateId' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailTemplateId(System.Int32? emailTemplateId)
		{
			return GetByEmailTemplateId(null, 0, int.MaxValue , emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByEmailTemplateId' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailTemplateId(int start, int pageLength, System.Int32? emailTemplateId)
		{
			return GetByEmailTemplateId(null, start, pageLength , emailTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByEmailTemplateId' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailTemplateId(TransactionManager transactionManager, System.Int32? emailTemplateId)
		{
			return GetByEmailTemplateId(transactionManager, 0, int.MaxValue , emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByEmailTemplateId' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByEmailTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailTemplateId);
		
		#endregion
		
		#region EmailTemplates_Get_List 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Get_List' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region EmailTemplates_Update 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			 Update(null, 0, int.MaxValue , emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			 Update(null, start, pageLength , emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			 Update(transactionManager, 0, int.MaxValue , emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Update' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId);
		
		#endregion
		
		#region EmailTemplates_Find 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			return Find(null, start, pageLength , searchUsingOr, emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, emailTemplateId, siteId, emailTemplateParentId, emailCode, emailDescription, emailSubject, emailBodyText, emailBodyHtml, emailFields, emailAddressName, emailAddressFrom, emailAddressCc, emailAddressBcc, globalTemplate, lastModifiedBy, lastModified, emailAddressTo, emailAddressToName, emailAddressToMandatory, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailTemplateParentId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="emailDescription"> A <c>System.String</c> instance.</param>
		/// <param name="emailSubject"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyText"> A <c>System.String</c> instance.</param>
		/// <param name="emailBodyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="emailFields"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressFrom"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressCc"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressBcc"> A <c>System.String</c> instance.</param>
		/// <param name="globalTemplate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="emailAddressTo"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToName"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddressToMandatory"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? emailTemplateId, System.Int32? siteId, System.Int32? emailTemplateParentId, System.String emailCode, System.String emailDescription, System.String emailSubject, System.String emailBodyText, System.String emailBodyHtml, System.String emailFields, System.String emailAddressName, System.String emailAddressFrom, System.String emailAddressCc, System.String emailAddressBcc, System.Boolean? globalTemplate, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.String emailAddressTo, System.String emailAddressToName, System.Boolean? emailAddressToMandatory, System.Int32? languageId);
		
		#endregion
		
		#region EmailTemplates_Delete 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? emailTemplateId)
		{
			 Delete(null, 0, int.MaxValue , emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? emailTemplateId)
		{
			 Delete(null, start, pageLength , emailTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? emailTemplateId)
		{
			 Delete(transactionManager, 0, int.MaxValue , emailTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_Delete' stored procedure. 
		/// </summary>
		/// <param name="emailTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailTemplateId);
		
		#endregion
		
		#region EmailTemplates_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'EmailTemplates_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region EmailTemplates_CustomGetByEmailCode 
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_CustomGetByEmailCode' stored procedure. 
		/// </summary>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplates&gt;"/> instance.</returns>
		public TList<EmailTemplates> CustomGetByEmailCode(System.String emailCode)
		{
			return CustomGetByEmailCode(null, 0, int.MaxValue , emailCode);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_CustomGetByEmailCode' stored procedure. 
		/// </summary>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplates&gt;"/> instance.</returns>
		public TList<EmailTemplates> CustomGetByEmailCode(int start, int pageLength, System.String emailCode)
		{
			return CustomGetByEmailCode(null, start, pageLength , emailCode);
		}
				
		/// <summary>
		///	This method wrap the 'EmailTemplates_CustomGetByEmailCode' stored procedure. 
		/// </summary>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplates&gt;"/> instance.</returns>
		public TList<EmailTemplates> CustomGetByEmailCode(TransactionManager transactionManager, System.String emailCode)
		{
			return CustomGetByEmailCode(transactionManager, 0, int.MaxValue , emailCode);
		}
		
		/// <summary>
		///	This method wrap the 'EmailTemplates_CustomGetByEmailCode' stored procedure. 
		/// </summary>
		/// <param name="emailCode"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;EmailTemplates&gt;"/> instance.</returns>
		public abstract TList<EmailTemplates> CustomGetByEmailCode(TransactionManager transactionManager, int start, int pageLength , System.String emailCode);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmailTemplates&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmailTemplates&gt;"/></returns>
		public static TList<EmailTemplates> Fill(IDataReader reader, TList<EmailTemplates> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.EmailTemplates c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmailTemplates")
					.Append("|").Append((System.Int32)reader[((int)EmailTemplatesColumn.EmailTemplateId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmailTemplates>(
					key.ToString(), // EntityTrackingKey
					"EmailTemplates",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.EmailTemplates();
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
					c.EmailTemplateId = (System.Int32)reader[((int)EmailTemplatesColumn.EmailTemplateId - 1)];
					c.SiteId = (System.Int32)reader[((int)EmailTemplatesColumn.SiteId - 1)];
					c.EmailTemplateParentId = (System.Int32)reader[((int)EmailTemplatesColumn.EmailTemplateParentId - 1)];
					c.EmailCode = (System.String)reader[((int)EmailTemplatesColumn.EmailCode - 1)];
					c.EmailDescription = (System.String)reader[((int)EmailTemplatesColumn.EmailDescription - 1)];
					c.EmailSubject = (System.String)reader[((int)EmailTemplatesColumn.EmailSubject - 1)];
					c.EmailBodyText = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailBodyText - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailBodyText - 1)];
					c.EmailBodyHtml = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailBodyHtml - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailBodyHtml - 1)];
					c.EmailFields = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailFields - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailFields - 1)];
					c.EmailAddressName = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressName - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressName - 1)];
					c.EmailAddressFrom = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressFrom - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressFrom - 1)];
					c.EmailAddressCc = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressCc - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressCc - 1)];
					c.EmailAddressBcc = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressBcc - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressBcc - 1)];
					c.GlobalTemplate = (System.Boolean)reader[((int)EmailTemplatesColumn.GlobalTemplate - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)EmailTemplatesColumn.LastModifiedBy - 1)];
					c.LastModified = (System.DateTime)reader[((int)EmailTemplatesColumn.LastModified - 1)];
					c.EmailAddressTo = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressTo - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressTo - 1)];
					c.EmailAddressToName = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressToName - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressToName - 1)];
					c.EmailAddressToMandatory = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressToMandatory - 1)))?null:(System.Boolean?)reader[((int)EmailTemplatesColumn.EmailAddressToMandatory - 1)];
					c.LanguageId = (reader.IsDBNull(((int)EmailTemplatesColumn.LanguageId - 1)))?null:(System.Int32?)reader[((int)EmailTemplatesColumn.LanguageId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.EmailTemplates"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailTemplates"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.EmailTemplates entity)
		{
			if (!reader.Read()) return;
			
			entity.EmailTemplateId = (System.Int32)reader[((int)EmailTemplatesColumn.EmailTemplateId - 1)];
			entity.SiteId = (System.Int32)reader[((int)EmailTemplatesColumn.SiteId - 1)];
			entity.EmailTemplateParentId = (System.Int32)reader[((int)EmailTemplatesColumn.EmailTemplateParentId - 1)];
			entity.EmailCode = (System.String)reader[((int)EmailTemplatesColumn.EmailCode - 1)];
			entity.EmailDescription = (System.String)reader[((int)EmailTemplatesColumn.EmailDescription - 1)];
			entity.EmailSubject = (System.String)reader[((int)EmailTemplatesColumn.EmailSubject - 1)];
			entity.EmailBodyText = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailBodyText - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailBodyText - 1)];
			entity.EmailBodyHtml = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailBodyHtml - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailBodyHtml - 1)];
			entity.EmailFields = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailFields - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailFields - 1)];
			entity.EmailAddressName = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressName - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressName - 1)];
			entity.EmailAddressFrom = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressFrom - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressFrom - 1)];
			entity.EmailAddressCc = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressCc - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressCc - 1)];
			entity.EmailAddressBcc = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressBcc - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressBcc - 1)];
			entity.GlobalTemplate = (System.Boolean)reader[((int)EmailTemplatesColumn.GlobalTemplate - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)EmailTemplatesColumn.LastModifiedBy - 1)];
			entity.LastModified = (System.DateTime)reader[((int)EmailTemplatesColumn.LastModified - 1)];
			entity.EmailAddressTo = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressTo - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressTo - 1)];
			entity.EmailAddressToName = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressToName - 1)))?null:(System.String)reader[((int)EmailTemplatesColumn.EmailAddressToName - 1)];
			entity.EmailAddressToMandatory = (reader.IsDBNull(((int)EmailTemplatesColumn.EmailAddressToMandatory - 1)))?null:(System.Boolean?)reader[((int)EmailTemplatesColumn.EmailAddressToMandatory - 1)];
			entity.LanguageId = (reader.IsDBNull(((int)EmailTemplatesColumn.LanguageId - 1)))?null:(System.Int32?)reader[((int)EmailTemplatesColumn.LanguageId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.EmailTemplates"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailTemplates"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.EmailTemplates entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmailTemplateId = (System.Int32)dataRow["EmailTemplateID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.EmailTemplateParentId = (System.Int32)dataRow["EmailTemplateParentID"];
			entity.EmailCode = (System.String)dataRow["EmailCode"];
			entity.EmailDescription = (System.String)dataRow["EmailDescription"];
			entity.EmailSubject = (System.String)dataRow["EmailSubject"];
			entity.EmailBodyText = Convert.IsDBNull(dataRow["EmailBodyText"]) ? null : (System.String)dataRow["EmailBodyText"];
			entity.EmailBodyHtml = Convert.IsDBNull(dataRow["EmailBodyHTML"]) ? null : (System.String)dataRow["EmailBodyHTML"];
			entity.EmailFields = Convert.IsDBNull(dataRow["EmailFields"]) ? null : (System.String)dataRow["EmailFields"];
			entity.EmailAddressName = Convert.IsDBNull(dataRow["EmailAddressName"]) ? null : (System.String)dataRow["EmailAddressName"];
			entity.EmailAddressFrom = Convert.IsDBNull(dataRow["EmailAddressFrom"]) ? null : (System.String)dataRow["EmailAddressFrom"];
			entity.EmailAddressCc = Convert.IsDBNull(dataRow["EmailAddressCC"]) ? null : (System.String)dataRow["EmailAddressCC"];
			entity.EmailAddressBcc = Convert.IsDBNull(dataRow["EmailAddressBCC"]) ? null : (System.String)dataRow["EmailAddressBCC"];
			entity.GlobalTemplate = (System.Boolean)dataRow["GlobalTemplate"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.EmailAddressTo = Convert.IsDBNull(dataRow["EmailAddressTo"]) ? null : (System.String)dataRow["EmailAddressTo"];
			entity.EmailAddressToName = Convert.IsDBNull(dataRow["EmailAddressToName"]) ? null : (System.String)dataRow["EmailAddressToName"];
			entity.EmailAddressToMandatory = Convert.IsDBNull(dataRow["EmailAddressToMandatory"]) ? null : (System.Boolean?)dataRow["EmailAddressToMandatory"];
			entity.LanguageId = Convert.IsDBNull(dataRow["LanguageID"]) ? null : (System.Int32?)dataRow["LanguageID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.EmailTemplates"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.EmailTemplates Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.EmailTemplates entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Languages|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LanguageId ?? (int)0);
				Languages tmpEntity = EntityManager.LocateEntity<Languages>(EntityLocator.ConstructKeyFromPkItems(typeof(Languages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguagesProvider.GetByLanguageId(transactionManager, (entity.LanguageId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LanguageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LanguageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguagesProvider.DeepLoad(transactionManager, entity.LanguageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LanguageIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.EmailTemplates object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.EmailTemplates instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.EmailTemplates Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.EmailTemplates entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Languages|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguagesProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.LanguageId;
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
	
	#region EmailTemplatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.EmailTemplates</c>
	///</summary>
	public enum EmailTemplatesChildEntityTypes
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
			
		///<summary>
		/// Composite Property for <c>Languages</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
		}
	
	#endregion EmailTemplatesChildEntityTypes
	
	#region EmailTemplatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmailTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesFilterBuilder : SqlFilterBuilder<EmailTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilterBuilder class.
		/// </summary>
		public EmailTemplatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplatesFilterBuilder
	
	#region EmailTemplatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmailTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesParameterBuilder : ParameterizedSqlFilterBuilder<EmailTemplatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesParameterBuilder class.
		/// </summary>
		public EmailTemplatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplatesParameterBuilder
	
	#region EmailTemplatesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmailTemplatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmailTemplatesSortBuilder : SqlSortBuilder<EmailTemplatesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesSqlSortBuilder class.
		/// </summary>
		public EmailTemplatesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmailTemplatesSortBuilder
	
} // end namespace
