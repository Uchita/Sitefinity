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
	/// This class is the base class for any <see cref="SiteLanguagesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteLanguagesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteLanguages, JXTPortal.Entities.SiteLanguagesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteLanguagesKey key)
		{
			return Delete(transactionManager, key.SiteLanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteLanguageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteLanguageId)
		{
			return Delete(null, _siteLanguageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLanguageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteLanguageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		FK__SiteLangu__Langu__00200768 Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		FK__SiteLangu__Langu__00200768 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		/// <remarks></remarks>
		public TList<SiteLanguages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		FK__SiteLangu__Langu__00200768 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		fkSiteLanguLangu00200768 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		fkSiteLanguLangu00200768 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetByLanguageId(System.Int32 _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__Langu__00200768 key.
		///		FK__SiteLangu__Langu__00200768 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public abstract TList<SiteLanguages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		FK__SiteLangu__SiteI__162F4418 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		FK__SiteLangu__SiteI__162F4418 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		/// <remarks></remarks>
		public TList<SiteLanguages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		FK__SiteLangu__SiteI__162F4418 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		fkSiteLanguSitei162f4418 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		fkSiteLanguSitei162f4418 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public TList<SiteLanguages> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__SiteLangu__SiteI__162F4418 key.
		///		FK__SiteLangu__SiteI__162F4418 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.SiteLanguages objects.</returns>
		public abstract TList<SiteLanguages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.SiteLanguages Get(TransactionManager transactionManager, JXTPortal.Entities.SiteLanguagesKey key, int start, int pageLength)
		{
			return GetBySiteLanguageId(transactionManager, key.SiteLanguageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(System.Int32 _siteId, System.Int32 _languageId)
		{
			int count = -1;
			return GetBySiteIdLanguageId(null,_siteId, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(System.Int32 _siteId, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageId(null, _siteId, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId)
		{
			int count = -1;
			return GetBySiteIdLanguageId(transactionManager, _siteId, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageId(transactionManager, _siteId, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(System.Int32 _siteId, System.Int32 _languageId, int start, int pageLength, out int count)
		{
			return GetBySiteIdLanguageId(null, _siteId, _languageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_SiteLanguages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public abstract JXTPortal.Entities.SiteLanguages GetBySiteIdLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="_siteLanguageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(System.Int32 _siteLanguageId)
		{
			int count = -1;
			return GetBySiteLanguageId(null,_siteLanguageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="_siteLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(System.Int32 _siteLanguageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteLanguageId(null, _siteLanguageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLanguageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(TransactionManager transactionManager, System.Int32 _siteLanguageId)
		{
			int count = -1;
			return GetBySiteLanguageId(transactionManager, _siteLanguageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(TransactionManager transactionManager, System.Int32 _siteLanguageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteLanguageId(transactionManager, _siteLanguageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="_siteLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(System.Int32 _siteLanguageId, int start, int pageLength, out int count)
		{
			return GetBySiteLanguageId(null, _siteLanguageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__SiteLanguages__300424B4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteLanguageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteLanguages"/> class.</returns>
		public abstract JXTPortal.Entities.SiteLanguages GetBySiteLanguageId(TransactionManager transactionManager, System.Int32 _siteLanguageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteLanguages_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
			/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName, ref System.Int32? siteLanguageId)
		{
			 Insert(null, 0, int.MaxValue , siteId, languageId, siteLanguageName, ref siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
			/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName, ref System.Int32? siteLanguageId)
		{
			 Insert(null, start, pageLength , siteId, languageId, siteLanguageName, ref siteLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
			/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName, ref System.Int32? siteLanguageId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, languageId, siteLanguageName, ref siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
			/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName, ref System.Int32? siteLanguageId);
		
		#endregion
		
		#region SiteLanguages_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteLanguageId)
		{
			 Delete(null, 0, int.MaxValue , siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteLanguageId)
		{
			 Delete(null, start, pageLength , siteLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteLanguageId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLanguageId);
		
		#endregion
		
		#region SiteLanguages_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteLanguages_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteLanguages_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region SiteLanguages_Find 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Find(System.Boolean? searchUsingOr, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteLanguageId, siteId, languageId, siteLanguageName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			return Find(null, start, pageLength , searchUsingOr, siteLanguageId, siteId, languageId, siteLanguageName);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteLanguageId, siteId, languageId, siteLanguageName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName);
		
		#endregion
		
		#region SiteLanguages_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetByLanguageId(int start, int pageLength, System.Int32? languageId)
		{
			return GetByLanguageId(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetByLanguageId(TransactionManager transactionManager, System.Int32? languageId)
		{
			return GetByLanguageId(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region SiteLanguages_Update 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			 Update(null, 0, int.MaxValue , siteLanguageId, siteId, languageId, siteLanguageName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			 Update(null, start, pageLength , siteLanguageId, siteId, languageId, siteLanguageName);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName)
		{
			 Update(transactionManager, 0, int.MaxValue , siteLanguageId, siteId, languageId, siteLanguageName);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_Update' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteLanguageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLanguageId, System.Int32? siteId, System.Int32? languageId, System.String siteLanguageName);
		
		#endregion
		
		#region SiteLanguages_GetBySiteLanguageId 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteLanguageId(System.Int32? siteLanguageId)
		{
			return GetBySiteLanguageId(null, 0, int.MaxValue , siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteLanguageId(int start, int pageLength, System.Int32? siteLanguageId)
		{
			return GetBySiteLanguageId(null, start, pageLength , siteLanguageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteLanguageId(TransactionManager transactionManager, System.Int32? siteLanguageId)
		{
			return GetBySiteLanguageId(transactionManager, 0, int.MaxValue , siteLanguageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> GetBySiteLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteLanguageId);
		
		#endregion
		
		#region SiteLanguages_GetBySiteIdLanguageId 
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteIdLanguageId(System.Int32? siteId, System.Int32? languageId)
		{
			return GetBySiteIdLanguageId(null, 0, int.MaxValue , siteId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteIdLanguageId(int start, int pageLength, System.Int32? siteId, System.Int32? languageId)
		{
			return GetBySiteIdLanguageId(null, start, pageLength , siteId, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public TList<SiteLanguages> GetBySiteIdLanguageId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId)
		{
			return GetBySiteIdLanguageId(transactionManager, 0, int.MaxValue , siteId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteLanguages_GetBySiteIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteLanguages&gt;"/> instance.</returns>
		public abstract TList<SiteLanguages> GetBySiteIdLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteLanguages&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteLanguages&gt;"/></returns>
		public static TList<SiteLanguages> Fill(IDataReader reader, TList<SiteLanguages> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteLanguages c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteLanguages")
					.Append("|").Append((System.Int32)reader[((int)SiteLanguagesColumn.SiteLanguageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteLanguages>(
					key.ToString(), // EntityTrackingKey
					"SiteLanguages",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteLanguages();
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
					c.SiteLanguageId = (System.Int32)reader[((int)SiteLanguagesColumn.SiteLanguageId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteLanguagesColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)SiteLanguagesColumn.LanguageId - 1)];
					c.SiteLanguageName = (System.String)reader[((int)SiteLanguagesColumn.SiteLanguageName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteLanguages"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLanguages"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteLanguages entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteLanguageId = (System.Int32)reader[((int)SiteLanguagesColumn.SiteLanguageId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteLanguagesColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)SiteLanguagesColumn.LanguageId - 1)];
			entity.SiteLanguageName = (System.String)reader[((int)SiteLanguagesColumn.SiteLanguageName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteLanguages"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLanguages"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteLanguages entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteLanguageId = (System.Int32)dataRow["SiteLanguageID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.SiteLanguageName = (System.String)dataRow["SiteLanguageName"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteLanguages"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteLanguages Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteLanguages entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region LanguageIdSource	
			if (CanDeepLoad(entity, "Languages|LanguageIdSource", deepLoadType, innerList) 
				&& entity.LanguageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.LanguageId;
				Languages tmpEntity = EntityManager.LocateEntity<Languages>(EntityLocator.ConstructKeyFromPkItems(typeof(Languages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LanguageIdSource = tmpEntity;
				else
					entity.LanguageIdSource = DataRepository.LanguagesProvider.GetByLanguageId(transactionManager, entity.LanguageId);		
				
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteLanguages object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteLanguages instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteLanguages Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteLanguages entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region LanguageIdSource
			if (CanDeepSave(entity, "Languages|LanguageIdSource", deepSaveType, innerList) 
				&& entity.LanguageIdSource != null)
			{
				DataRepository.LanguagesProvider.Save(transactionManager, entity.LanguageIdSource);
				entity.LanguageId = entity.LanguageIdSource.LanguageId;
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
	
	#region SiteLanguagesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteLanguages</c>
	///</summary>
	public enum SiteLanguagesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Languages</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteLanguagesChildEntityTypes
	
	#region SiteLanguagesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLanguagesFilterBuilder : SqlFilterBuilder<SiteLanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilterBuilder class.
		/// </summary>
		public SiteLanguagesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLanguagesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLanguagesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLanguagesFilterBuilder
	
	#region SiteLanguagesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLanguagesParameterBuilder : ParameterizedSqlFilterBuilder<SiteLanguagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesParameterBuilder class.
		/// </summary>
		public SiteLanguagesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLanguagesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLanguagesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLanguagesParameterBuilder
	
	#region SiteLanguagesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteLanguagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLanguages"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteLanguagesSortBuilder : SqlSortBuilder<SiteLanguagesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesSqlSortBuilder class.
		/// </summary>
		public SiteLanguagesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteLanguagesSortBuilder
	
} // end namespace
