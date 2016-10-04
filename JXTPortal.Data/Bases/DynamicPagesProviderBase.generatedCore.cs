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
	/// This class is the base class for any <see cref="DynamicPagesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicPagesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicPages, JXTPortal.Entities.DynamicPagesKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByRelatedDynamicPageIdFromRelatedDynamicPages
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="_relatedDynamicPageId"></param>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(null,_relatedDynamicPageId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets JXTPortal.Entities.DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(System.Int32 _relatedDynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(null, _relatedDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(transactionManager, _relatedDynamicPageId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32 _relatedDynamicPageId,int start, int pageLength)
		{
			int count = -1;
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(transactionManager, _relatedDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(System.Int32 _relatedDynamicPageId,int start, int pageLength, out int count)
		{
			
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(null, _relatedDynamicPageId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets DynamicPages objects from the datasource by RelatedDynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetByRelatedDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager,System.Int32 _relatedDynamicPageId, int start, int pageLength, out int count);
		
		#endregion GetByRelatedDynamicPageIdFromRelatedDynamicPages
		
		#region GetByDynamicPageIdFromRelatedDynamicPages
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageIdFromRelatedDynamicPages(null,_dynamicPageId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets JXTPortal.Entities.DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdFromRelatedDynamicPages(null, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageIdFromRelatedDynamicPages(transactionManager, _dynamicPageId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32 _dynamicPageId,int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdFromRelatedDynamicPages(transactionManager, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(System.Int32 _dynamicPageId,int start, int pageLength, out int count)
		{
			
			return GetByDynamicPageIdFromRelatedDynamicPages(null, _dynamicPageId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets DynamicPages objects from the datasource by DynamicPageID in the
		///		RelatedDynamicPages table. Table DynamicPages is related to table DynamicPages
		///		through the (M:N) relationship defined in the RelatedDynamicPages table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetByDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager,System.Int32 _dynamicPageId, int start, int pageLength, out int count);
		
		#endregion GetByDynamicPageIdFromRelatedDynamicPages
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicPagesKey key)
		{
			return Delete(transactionManager, key.DynamicPageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageId)
		{
			return Delete(null, _dynamicPageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		FK__DynamicPa__Dynam__619B8048 Description: 
		/// </summary>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageWebPartTemplateId(System.Int32? _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(_dynamicPageWebPartTemplateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		FK__DynamicPa__Dynam__619B8048 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPages> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32? _dynamicPageWebPartTemplateId)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		FK__DynamicPa__Dynam__619B8048 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32? _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageWebPartTemplateId(transactionManager, _dynamicPageWebPartTemplateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		fkDynamicPaDynam619b8048 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageWebPartTemplateId(System.Int32? _dynamicPageWebPartTemplateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		fkDynamicPaDynam619b8048 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByDynamicPageWebPartTemplateId(System.Int32? _dynamicPageWebPartTemplateId, int start, int pageLength,out int count)
		{
			return GetByDynamicPageWebPartTemplateId(null, _dynamicPageWebPartTemplateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Dynam__619B8048 key.
		///		FK__DynamicPa__Dynam__619B8048 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageWebPartTemplateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, System.Int32? _dynamicPageWebPartTemplateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		FK__DynamicPa__Langu__60A75C0F Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		FK__DynamicPa__Langu__60A75C0F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		FK__DynamicPa__Langu__60A75C0F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		fkDynamicPaLangu60a75c0f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		fkDynamicPaLangu60a75c0f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLanguageId(System.Int32 _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__Langu__60A75C0F key.
		///		FK__DynamicPa__Langu__60A75C0F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		FK__DynamicPa__LastM__628FA481 Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLastModifiedBy(System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		FK__DynamicPa__LastM__628FA481 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPages> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		FK__DynamicPa__LastM__628FA481 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		fkDynamicPaLastm628Fa481 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		fkDynamicPaLastm628Fa481 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetByLastModifiedBy(System.Int32 _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__DynamicPa__LastM__628FA481 key.
		///		FK__DynamicPa__LastM__628FA481 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32 _lastModifiedBy, int start, int pageLength, out int count);
		
	

				
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		FK_DynamicPages_Sites Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		FK_DynamicPages_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicPages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		FK_DynamicPages_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		fkDynamicPagesSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		fkDynamicPagesSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public TList<DynamicPages> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DynamicPages_Sites key.
		///		FK_DynamicPages_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicPages objects.</returns>
		public abstract TList<DynamicPages> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicPages Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicPagesKey key, int start, int pageLength)
		{
			return GetByDynamicPageId(transactionManager, key.DynamicPageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(System.Int32 _siteId, System.String _pageName, System.Int32 _languageId)
		{
			int count = -1;
			return GetBySiteIdPageNameLanguageId(null,_siteId, _pageName, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(System.Int32 _siteId, System.String _pageName, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPageNameLanguageId(null, _siteId, _pageName, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _languageId)
		{
			int count = -1;
			return GetBySiteIdPageNameLanguageId(transactionManager, _siteId, _pageName, _languageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdPageNameLanguageId(transactionManager, _siteId, _pageName, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(System.Int32 _siteId, System.String _pageName, System.Int32 _languageId, int start, int pageLength, out int count)
		{
			return GetBySiteIdPageNameLanguageId(null, _siteId, _pageName, _languageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_pageName"></param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPages GetBySiteIdPageNameLanguageId(TransactionManager transactionManager, System.Int32 _siteId, System.String _pageName, System.Int32 _languageId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName)
		{
			int count = -1;
			return GetBySiteIdLanguageIdPageFriendlyName(null,_siteId, _languageId, _pageFriendlyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageIdPageFriendlyName(null, _siteId, _languageId, _pageFriendlyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName)
		{
			int count = -1;
			return GetBySiteIdLanguageIdPageFriendlyName(transactionManager, _siteId, _languageId, _pageFriendlyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdLanguageIdPageFriendlyName(transactionManager, _siteId, _languageId, _pageFriendlyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName, int start, int pageLength, out int count)
		{
			return GetBySiteIdLanguageIdPageFriendlyName(null, _siteId, _languageId, _pageFriendlyName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_DynamicPages_FriendlyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_languageId"></param>
		/// <param name="_pageFriendlyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPages GetBySiteIdLanguageIdPageFriendlyName(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _languageId, System.String _pageFriendlyName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetByDynamicPageId(System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(null,_dynamicPageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public JXTPortal.Entities.DynamicPages GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__DynamicPages__0BC6C43E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicPages"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicPages GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicPages_GetSiteMissingSystemPagesByName 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSiteMissingSystemPagesByName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteMissingSystemPagesByName(System.Int32? siteId, System.String pageName)
		{
			return GetSiteMissingSystemPagesByName(null, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSiteMissingSystemPagesByName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteMissingSystemPagesByName(int start, int pageLength, System.Int32? siteId, System.String pageName)
		{
			return GetSiteMissingSystemPagesByName(null, start, pageLength , siteId, pageName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSiteMissingSystemPagesByName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteMissingSystemPagesByName(TransactionManager transactionManager, System.Int32? siteId, System.String pageName)
		{
			return GetSiteMissingSystemPagesByName(transactionManager, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSiteMissingSystemPagesByName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSiteMissingSystemPagesByName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName);
		
		#endregion
		
		#region DynamicPages_GetBySiteIdPageNameLanguageId 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageNameLanguageId(System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageId(null, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageNameLanguageId(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageId(null, start, pageLength , siteId, pageName, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageNameLanguageId(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageId(transactionManager, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdPageNameLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? languageId);
		
		#endregion
		
		#region DynamicPages_GetByKeywords 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByKeywords' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keywords"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searhable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByKeywords(System.Int32? siteId, System.String keywords, System.Int32? languageId, System.Boolean? searhable, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetByKeywords(null, 0, int.MaxValue , siteId, keywords, languageId, searhable, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByKeywords' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keywords"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searhable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByKeywords(int start, int pageLength, System.Int32? siteId, System.String keywords, System.Int32? languageId, System.Boolean? searhable, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetByKeywords(null, start, pageLength , siteId, keywords, languageId, searhable, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByKeywords' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keywords"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searhable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByKeywords(TransactionManager transactionManager, System.Int32? siteId, System.String keywords, System.Int32? languageId, System.Boolean? searhable, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetByKeywords(transactionManager, 0, int.MaxValue , siteId, keywords, languageId, searhable, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByKeywords' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keywords"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searhable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetByKeywords(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String keywords, System.Int32? languageId, System.Boolean? searhable, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region DynamicPages_GetNavigation 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetNavigation' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onMainNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onDynamicPageNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onFooterNav"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetNavigation(System.Int32? siteId, System.Int32? languageId, System.Boolean? onMainNavigation, System.Boolean? onDynamicPageNavigation, System.Boolean? onFooterNav)
		{
			return GetNavigation(null, 0, int.MaxValue , siteId, languageId, onMainNavigation, onDynamicPageNavigation, onFooterNav);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetNavigation' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onMainNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onDynamicPageNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onFooterNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetNavigation(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Boolean? onMainNavigation, System.Boolean? onDynamicPageNavigation, System.Boolean? onFooterNav)
		{
			return GetNavigation(null, start, pageLength , siteId, languageId, onMainNavigation, onDynamicPageNavigation, onFooterNav);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetNavigation' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onMainNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onDynamicPageNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onFooterNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetNavigation(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Boolean? onMainNavigation, System.Boolean? onDynamicPageNavigation, System.Boolean? onFooterNav)
		{
			return GetNavigation(transactionManager, 0, int.MaxValue , siteId, languageId, onMainNavigation, onDynamicPageNavigation, onFooterNav);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetNavigation' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onMainNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onDynamicPageNavigation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onFooterNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetNavigation(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Boolean? onMainNavigation, System.Boolean? onDynamicPageNavigation, System.Boolean? onFooterNav);
		
		#endregion
		
		#region DynamicPages_GetBySiteIdPageName 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetBySiteIdPageName(System.Int32? siteId, System.String pageName)
		{
			return GetBySiteIdPageName(null, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetBySiteIdPageName(int start, int pageLength, System.Int32? siteId, System.String pageName)
		{
			return GetBySiteIdPageName(null, start, pageLength , siteId, pageName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetBySiteIdPageName(TransactionManager transactionManager, System.Int32? siteId, System.String pageName)
		{
			return GetBySiteIdPageName(transactionManager, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetBySiteIdPageName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName);
		
		#endregion
		
		#region DynamicPages_CopyDynamicPagesForNewLangauge 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopyDynamicPagesForNewLangauge' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CopyDynamicPagesForNewLangauge(System.Int32? siteId, System.Int32? languageId, System.Int32? newSiteId, System.Int32? newLanguageId, System.Int32? dynamicPageWebPartTemplateId)
		{
			return CopyDynamicPagesForNewLangauge(null, 0, int.MaxValue , siteId, languageId, newSiteId, newLanguageId, dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopyDynamicPagesForNewLangauge' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CopyDynamicPagesForNewLangauge(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? newSiteId, System.Int32? newLanguageId, System.Int32? dynamicPageWebPartTemplateId)
		{
			return CopyDynamicPagesForNewLangauge(null, start, pageLength , siteId, languageId, newSiteId, newLanguageId, dynamicPageWebPartTemplateId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_CopyDynamicPagesForNewLangauge' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CopyDynamicPagesForNewLangauge(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? newSiteId, System.Int32? newLanguageId, System.Int32? dynamicPageWebPartTemplateId)
		{
			return CopyDynamicPagesForNewLangauge(transactionManager, 0, int.MaxValue , siteId, languageId, newSiteId, newLanguageId, dynamicPageWebPartTemplateId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopyDynamicPagesForNewLangauge' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="newLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CopyDynamicPagesForNewLangauge(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? newSiteId, System.Int32? newLanguageId, System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPages_GetByDynamicPageWebPartTemplateId 
		
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageWebPartTemplateId(int start, int pageLength, System.Int32? dynamicPageWebPartTemplateId)
		{
			return GetByDynamicPageWebPartTemplateId(null, start, pageLength , dynamicPageWebPartTemplateId);
		}
				
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageWebPartTemplateId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageWebPartTemplateId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageWebPartTemplateId);
		
		#endregion
		
		#region DynamicPages_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			 Update(null, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			 Update(null, start, pageLength , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible);
		
		#endregion
		
		#region DynamicPages_GetByDynamicPageId 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(int start, int pageLength, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetDetail 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetail(System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetDetail(null, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetail(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetDetail(null, start, pageLength , siteId, pageName, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetail(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetDetail(transactionManager, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetDetail' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetDetail(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName, System.Int32? languageId);
		
		#endregion
		
		#region DynamicPages_CustomGetValidHierarchy 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetValidHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> CustomGetValidHierarchy(System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage)
		{
			return CustomGetValidHierarchy(null, 0, int.MaxValue , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetValidHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> CustomGetValidHierarchy(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage)
		{
			return CustomGetValidHierarchy(null, start, pageLength , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetValidHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> CustomGetValidHierarchy(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage)
		{
			return CustomGetValidHierarchy(transactionManager, 0, int.MaxValue , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetValidHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> CustomGetValidHierarchy(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage);
		
		#endregion
		
		#region DynamicPages_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Get_List' stored procedure. 
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
		///	This method wrap the 'DynamicPages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicPages_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageId)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageId)
		{
			 Delete(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetHierarchyByChild 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchyByChild' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchyByChild(System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId)
		{
			return GetHierarchyByChild(null, 0, int.MaxValue , siteId, languageId, dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchyByChild' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchyByChild(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId)
		{
			return GetHierarchyByChild(null, start, pageLength , siteId, languageId, dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchyByChild' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchyByChild(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId)
		{
			return GetHierarchyByChild(transactionManager, 0, int.MaxValue , siteId, languageId, dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchyByChild' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetHierarchyByChild(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetSystemPagesBySiteIDPageName 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetSystemPagesBySiteIDPageName(System.Int32? siteId, System.String pageName)
		{
			return GetSystemPagesBySiteIDPageName(null, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetSystemPagesBySiteIDPageName(int start, int pageLength, System.Int32? siteId, System.String pageName)
		{
			return GetSystemPagesBySiteIDPageName(null, start, pageLength , siteId, pageName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetSystemPagesBySiteIDPageName(TransactionManager transactionManager, System.Int32? siteId, System.String pageName)
		{
			return GetSystemPagesBySiteIDPageName(transactionManager, 0, int.MaxValue , siteId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDPageName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetSystemPagesBySiteIDPageName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageName);
		
		#endregion
		
		#region DynamicPages_UpdateWebPartTemplate 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_UpdateWebPartTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateChildPages"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateWebPartTemplate(System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Int32? dynamicPageWebPartTemplateId, System.Boolean? updateChildPages)
		{
			 UpdateWebPartTemplate(null, 0, int.MaxValue , siteId, languageId, dynamicPageId, dynamicPageWebPartTemplateId, updateChildPages);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_UpdateWebPartTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateChildPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateWebPartTemplate(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Int32? dynamicPageWebPartTemplateId, System.Boolean? updateChildPages)
		{
			 UpdateWebPartTemplate(null, start, pageLength , siteId, languageId, dynamicPageId, dynamicPageWebPartTemplateId, updateChildPages);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_UpdateWebPartTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateChildPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateWebPartTemplate(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Int32? dynamicPageWebPartTemplateId, System.Boolean? updateChildPages)
		{
			 UpdateWebPartTemplate(transactionManager, 0, int.MaxValue , siteId, languageId, dynamicPageId, dynamicPageWebPartTemplateId, updateChildPages);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_UpdateWebPartTemplate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="updateChildPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateWebPartTemplate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Int32? dynamicPageWebPartTemplateId, System.Boolean? updateChildPages);
		
		#endregion
		
		#region DynamicPages_CopySystemPage 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopySystemPage' stored procedure. 
		/// </summary>
		/// <param name="masterSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultAdminId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CopySystemPage(System.Int32? masterSiteId, System.Int32? siteId, System.String pageName, System.Int32? defaultLanguageId, System.Int32? defaultAdminId)
		{
			 CopySystemPage(null, 0, int.MaxValue , masterSiteId, siteId, pageName, defaultLanguageId, defaultAdminId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopySystemPage' stored procedure. 
		/// </summary>
		/// <param name="masterSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultAdminId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CopySystemPage(int start, int pageLength, System.Int32? masterSiteId, System.Int32? siteId, System.String pageName, System.Int32? defaultLanguageId, System.Int32? defaultAdminId)
		{
			 CopySystemPage(null, start, pageLength , masterSiteId, siteId, pageName, defaultLanguageId, defaultAdminId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_CopySystemPage' stored procedure. 
		/// </summary>
		/// <param name="masterSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultAdminId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CopySystemPage(TransactionManager transactionManager, System.Int32? masterSiteId, System.Int32? siteId, System.String pageName, System.Int32? defaultLanguageId, System.Int32? defaultAdminId)
		{
			 CopySystemPage(transactionManager, 0, int.MaxValue , masterSiteId, siteId, pageName, defaultLanguageId, defaultAdminId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CopySystemPage' stored procedure. 
		/// </summary>
		/// <param name="masterSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultAdminId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CopySystemPage(TransactionManager transactionManager, int start, int pageLength , System.Int32? masterSiteId, System.Int32? siteId, System.String pageName, System.Int32? defaultLanguageId, System.Int32? defaultAdminId);
		
		#endregion
		
		#region DynamicPages_GetByDynamicPageIdFromRelatedDynamicPages 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromRelatedDynamicPages(System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromRelatedDynamicPages(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromRelatedDynamicPages(int start, int pageLength, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromRelatedDynamicPages(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			return GetByDynamicPageIdFromRelatedDynamicPages(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetPaged' stored procedure. 
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
		
		#region DynamicPages_GetMissingSystemPagesBySiteID 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetMissingSystemPagesBySiteID' stored procedure. 
		/// </summary>
		/// <param name="defaultSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMissingSystemPagesBySiteID(System.Int32? defaultSiteId, System.Int32? siteId)
		{
			return GetMissingSystemPagesBySiteID(null, 0, int.MaxValue , defaultSiteId, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetMissingSystemPagesBySiteID' stored procedure. 
		/// </summary>
		/// <param name="defaultSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMissingSystemPagesBySiteID(int start, int pageLength, System.Int32? defaultSiteId, System.Int32? siteId)
		{
			return GetMissingSystemPagesBySiteID(null, start, pageLength , defaultSiteId, siteId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetMissingSystemPagesBySiteID' stored procedure. 
		/// </summary>
		/// <param name="defaultSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMissingSystemPagesBySiteID(TransactionManager transactionManager, System.Int32? defaultSiteId, System.Int32? siteId)
		{
			return GetMissingSystemPagesBySiteID(transactionManager, 0, int.MaxValue , defaultSiteId, siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetMissingSystemPagesBySiteID' stored procedure. 
		/// </summary>
		/// <param name="defaultSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetMissingSystemPagesBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultSiteId, System.Int32? siteId);
		
		#endregion
		
		#region DynamicPages_GetBySiteIdLanguageIdPageFriendlyName 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdLanguageIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdLanguageIdPageFriendlyName(System.Int32? siteId, System.Int32? languageId, System.String pageFriendlyName)
		{
			return GetBySiteIdLanguageIdPageFriendlyName(null, 0, int.MaxValue , siteId, languageId, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdLanguageIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdLanguageIdPageFriendlyName(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String pageFriendlyName)
		{
			return GetBySiteIdLanguageIdPageFriendlyName(null, start, pageLength , siteId, languageId, pageFriendlyName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdLanguageIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdLanguageIdPageFriendlyName(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String pageFriendlyName)
		{
			return GetBySiteIdLanguageIdPageFriendlyName(transactionManager, 0, int.MaxValue , siteId, languageId, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdLanguageIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdLanguageIdPageFriendlyName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String pageFriendlyName);
		
		#endregion
		
		#region DynamicPages_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region DynamicPages_GetByRelatedDynamicPageIdFromRelatedDynamicPages 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByRelatedDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="relatedDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRelatedDynamicPageIdFromRelatedDynamicPages(System.Int32? relatedDynamicPageId)
		{
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(null, 0, int.MaxValue , relatedDynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByRelatedDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="relatedDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRelatedDynamicPageIdFromRelatedDynamicPages(int start, int pageLength, System.Int32? relatedDynamicPageId)
		{
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(null, start, pageLength , relatedDynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByRelatedDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="relatedDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByRelatedDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, System.Int32? relatedDynamicPageId)
		{
			return GetByRelatedDynamicPageIdFromRelatedDynamicPages(transactionManager, 0, int.MaxValue , relatedDynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByRelatedDynamicPageIdFromRelatedDynamicPages' stored procedure. 
		/// </summary>
		/// <param name="relatedDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByRelatedDynamicPageIdFromRelatedDynamicPages(TransactionManager transactionManager, int start, int pageLength , System.Int32? relatedDynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetSystemPagesBySiteIDLanguageID 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesBySiteIDLanguageID(System.Int32? siteId, System.Int32? languageId, System.String pageName)
		{
			return GetSystemPagesBySiteIDLanguageID(null, 0, int.MaxValue , siteId, languageId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesBySiteIDLanguageID(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String pageName)
		{
			return GetSystemPagesBySiteIDLanguageID(null, start, pageLength , siteId, languageId, pageName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesBySiteIDLanguageID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String pageName)
		{
			return GetSystemPagesBySiteIDLanguageID(transactionManager, 0, int.MaxValue , siteId, languageId, pageName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSystemPagesBySiteIDLanguageID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String pageName);
		
		#endregion
		
		#region DynamicPages_GetBySiteIdPageFriendlyName 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageFriendlyName(System.Int32? siteId, System.String pageFriendlyName)
		{
			return GetBySiteIdPageFriendlyName(null, 0, int.MaxValue , siteId, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageFriendlyName(int start, int pageLength, System.Int32? siteId, System.String pageFriendlyName)
		{
			return GetBySiteIdPageFriendlyName(null, start, pageLength , siteId, pageFriendlyName);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdPageFriendlyName(TransactionManager transactionManager, System.Int32? siteId, System.String pageFriendlyName)
		{
			return GetBySiteIdPageFriendlyName(transactionManager, 0, int.MaxValue , siteId, pageFriendlyName);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageFriendlyName' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdPageFriendlyName(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String pageFriendlyName);
		
		#endregion
		
		#region DynamicPages_GetByDynamicPageIdLanguageId 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByDynamicPageIdLanguageId(System.Int32? siteId, System.Int32? dynamicPageId, System.Int32? languageId)
		{
			return GetByDynamicPageIdLanguageId(null, 0, int.MaxValue , siteId, dynamicPageId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByDynamicPageIdLanguageId(int start, int pageLength, System.Int32? siteId, System.Int32? dynamicPageId, System.Int32? languageId)
		{
			return GetByDynamicPageIdLanguageId(null, start, pageLength , siteId, dynamicPageId, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetByDynamicPageIdLanguageId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? dynamicPageId, System.Int32? languageId)
		{
			return GetByDynamicPageIdLanguageId(transactionManager, 0, int.MaxValue , siteId, dynamicPageId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByDynamicPageIdLanguageId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetByDynamicPageIdLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? dynamicPageId, System.Int32? languageId);
		
		#endregion
		
		#region DynamicPages_BulkUpdate 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_BulkUpdate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="from"> A <c>System.String</c> instance.</param>
		/// <param name="to"> A <c>System.String</c> instance.</param>
		/// <param name="updateSystemPages"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkUpdate(System.Int32? siteId, System.String from, System.String to, System.Boolean? updateSystemPages)
		{
			return BulkUpdate(null, 0, int.MaxValue , siteId, from, to, updateSystemPages);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_BulkUpdate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="from"> A <c>System.String</c> instance.</param>
		/// <param name="to"> A <c>System.String</c> instance.</param>
		/// <param name="updateSystemPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkUpdate(int start, int pageLength, System.Int32? siteId, System.String from, System.String to, System.Boolean? updateSystemPages)
		{
			return BulkUpdate(null, start, pageLength , siteId, from, to, updateSystemPages);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_BulkUpdate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="from"> A <c>System.String</c> instance.</param>
		/// <param name="to"> A <c>System.String</c> instance.</param>
		/// <param name="updateSystemPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet BulkUpdate(TransactionManager transactionManager, System.Int32? siteId, System.String from, System.String to, System.Boolean? updateSystemPages)
		{
			return BulkUpdate(transactionManager, 0, int.MaxValue , siteId, from, to, updateSystemPages);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_BulkUpdate' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="from"> A <c>System.String</c> instance.</param>
		/// <param name="to"> A <c>System.String</c> instance.</param>
		/// <param name="updateSystemPages"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet BulkUpdate(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String from, System.String to, System.Boolean? updateSystemPages);
		
		#endregion
		
		#region DynamicPages_GetHierarchy 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showAll"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchy(System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage, System.Boolean? showAll)
		{
			return GetHierarchy(null, 0, int.MaxValue , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage, showAll);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showAll"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchy(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage, System.Boolean? showAll)
		{
			return GetHierarchy(null, start, pageLength , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage, showAll);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showAll"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public TList<DynamicPages> GetHierarchy(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage, System.Boolean? showAll)
		{
			return GetHierarchy(transactionManager, 0, int.MaxValue , siteId, languageId, dynamicPageId, onSiteMap, nonSystemPage, showAll);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetHierarchy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="nonSystemPage"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showAll"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicPages&gt;"/> instance.</returns>
		public abstract TList<DynamicPages> GetHierarchy(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? dynamicPageId, System.Boolean? onSiteMap, System.Boolean? nonSystemPage, System.Boolean? showAll);
		
		#endregion
		
		#region DynamicPages_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLastModifiedBy(System.Int32? lastModifiedBy)
		{
			return GetByLastModifiedBy(null, 0, int.MaxValue , lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region DynamicPages_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible, ref System.Int32? dynamicPageId)
		{
			 Insert(null, 0, int.MaxValue , siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible, ref dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible, ref System.Int32? dynamicPageId)
		{
			 Insert(null, start, pageLength , siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible, ref dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible, ref System.Int32? dynamicPageId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible, ref dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible, ref System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicPages_GetSystemPagesNameBySiteID 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesNameBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesNameBySiteID(System.Int32? siteId)
		{
			return GetSystemPagesNameBySiteID(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesNameBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesNameBySiteID(int start, int pageLength, System.Int32? siteId)
		{
			return GetSystemPagesNameBySiteID(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesNameBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSystemPagesNameBySiteID(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetSystemPagesNameBySiteID(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetSystemPagesNameBySiteID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSystemPagesNameBySiteID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region DynamicPages_CustomGetBySiteIDLanguageID 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDLanguageID(System.Int32? siteId, System.Int32? languageId)
		{
			return CustomGetBySiteIDLanguageID(null, 0, int.MaxValue , siteId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDLanguageID(int start, int pageLength, System.Int32? siteId, System.Int32? languageId)
		{
			return CustomGetBySiteIDLanguageID(null, start, pageLength , siteId, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetBySiteIDLanguageID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId)
		{
			return CustomGetBySiteIDLanguageID(transactionManager, 0, int.MaxValue , siteId, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_CustomGetBySiteIDLanguageID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetBySiteIDLanguageID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId);
		
		#endregion
		
		#region DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<DynamicPages> GetBySiteIdPageNameLanguageIdWithRoot(System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageIdWithRoot(null, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<DynamicPages> GetBySiteIdPageNameLanguageIdWithRoot(int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageIdWithRoot(null, start, pageLength , siteId, pageName, languageId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public TList<DynamicPages> GetBySiteIdPageNameLanguageIdWithRoot(TransactionManager transactionManager, System.Int32? siteId, System.String pageName, System.Int32? languageId)
		{
			return GetBySiteIdPageNameLanguageIdWithRoot(transactionManager, 0, int.MaxValue , siteId, pageName, languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetBySiteIdPageNameLanguageIdWithRoot' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
        public abstract TList<DynamicPages> GetBySiteIdPageNameLanguageIdWithRoot(TransactionManager transactionManager, int start, int pageLength, System.Int32? siteId, System.String pageName, System.Int32? languageId);
		
		#endregion
		
		#region DynamicPages_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicPages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageId, siteId, languageId, parentDynamicPageId, pageName, pageTitle, pageContent, dynamicPageWebPartTemplateId, hyperLink, valid, openInNewWindow, sequence, fullScreen, onTopNav, onLeftNav, onBottomNav, onSiteMap, searchable, metaKeywords, metaDescription, pageFriendlyName, lastModified, lastModifiedBy, searchField, sourceId, secured, customUrl, metaTitle, generateBreadcrumb, publishOn, visible);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="parentDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageName"> A <c>System.String</c> instance.</param>
		/// <param name="pageTitle"> A <c>System.String</c> instance.</param>
		/// <param name="pageContent"> A <c>System.String</c> instance.</param>
		/// <param name="dynamicPageWebPartTemplateId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="hyperLink"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="openInNewWindow"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="fullScreen"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onTopNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onLeftNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onBottomNav"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="onSiteMap"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="searchable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="pageFriendlyName"> A <c>System.String</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="sourceId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="secured"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="customUrl"> A <c>System.String</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="generateBreadcrumb"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="publishOn"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="visible"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? siteId, System.Int32? languageId, System.Int32? parentDynamicPageId, System.String pageName, System.String pageTitle, System.String pageContent, System.Int32? dynamicPageWebPartTemplateId, System.String hyperLink, System.Boolean? valid, System.Boolean? openInNewWindow, System.Int32? sequence, System.Boolean? fullScreen, System.Boolean? onTopNav, System.Boolean? onLeftNav, System.Boolean? onBottomNav, System.Boolean? onSiteMap, System.Boolean? searchable, System.String metaKeywords, System.String metaDescription, System.String pageFriendlyName, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.String searchField, System.Int32? sourceId, System.Boolean? secured, System.String customUrl, System.String metaTitle, System.Boolean? generateBreadcrumb, System.DateTime? publishOn, System.Boolean? visible);
		
		#endregion
		
		#region DynamicPages_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByLanguageId' stored procedure. 
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
		///	This method wrap the 'DynamicPages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByLanguageId(TransactionManager transactionManager, System.Int32? languageId)
		{
			return GetByLanguageId(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicPages_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicPages&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicPages&gt;"/></returns>
		public static TList<DynamicPages> Fill(IDataReader reader, TList<DynamicPages> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicPages c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicPages")
					.Append("|").Append((System.Int32)reader[((int)DynamicPagesColumn.DynamicPageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicPages>(
					key.ToString(), // EntityTrackingKey
					"DynamicPages",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicPages();
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
					c.DynamicPageId = (System.Int32)reader[((int)DynamicPagesColumn.DynamicPageId - 1)];
					c.SiteId = (System.Int32)reader[((int)DynamicPagesColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)DynamicPagesColumn.LanguageId - 1)];
					c.ParentDynamicPageId = (System.Int32)reader[((int)DynamicPagesColumn.ParentDynamicPageId - 1)];
					c.PageName = (System.String)reader[((int)DynamicPagesColumn.PageName - 1)];
					c.PageTitle = (reader.IsDBNull(((int)DynamicPagesColumn.PageTitle - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.PageTitle - 1)];
					c.PageContent = (System.String)reader[((int)DynamicPagesColumn.PageContent - 1)];
					c.DynamicPageWebPartTemplateId = (reader.IsDBNull(((int)DynamicPagesColumn.DynamicPageWebPartTemplateId - 1)))?null:(System.Int32?)reader[((int)DynamicPagesColumn.DynamicPageWebPartTemplateId - 1)];
					c.HyperLink = (System.String)reader[((int)DynamicPagesColumn.HyperLink - 1)];
					c.Valid = (System.Boolean)reader[((int)DynamicPagesColumn.Valid - 1)];
					c.OpenInNewWindow = (System.Boolean)reader[((int)DynamicPagesColumn.OpenInNewWindow - 1)];
					c.Sequence = (System.Int32)reader[((int)DynamicPagesColumn.Sequence - 1)];
					c.FullScreen = (System.Boolean)reader[((int)DynamicPagesColumn.FullScreen - 1)];
					c.OnTopNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnTopNav - 1)];
					c.OnLeftNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnLeftNav - 1)];
					c.OnBottomNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnBottomNav - 1)];
					c.OnSiteMap = (System.Boolean)reader[((int)DynamicPagesColumn.OnSiteMap - 1)];
					c.Searchable = (System.Boolean)reader[((int)DynamicPagesColumn.Searchable - 1)];
					c.MetaKeywords = (reader.IsDBNull(((int)DynamicPagesColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaKeywords - 1)];
					c.MetaDescription = (reader.IsDBNull(((int)DynamicPagesColumn.MetaDescription - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaDescription - 1)];
					c.PageFriendlyName = (System.String)reader[((int)DynamicPagesColumn.PageFriendlyName - 1)];
					c.LastModified = (System.DateTime)reader[((int)DynamicPagesColumn.LastModified - 1)];
					c.LastModifiedBy = (System.Int32)reader[((int)DynamicPagesColumn.LastModifiedBy - 1)];
					c.SearchField = (reader.IsDBNull(((int)DynamicPagesColumn.SearchField - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.SearchField - 1)];
					c.SourceId = (reader.IsDBNull(((int)DynamicPagesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPagesColumn.SourceId - 1)];
					c.Secured = (System.Boolean)reader[((int)DynamicPagesColumn.Secured - 1)];
					c.CustomUrl = (reader.IsDBNull(((int)DynamicPagesColumn.CustomUrl - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.CustomUrl - 1)];
					c.MetaTitle = (reader.IsDBNull(((int)DynamicPagesColumn.MetaTitle - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaTitle - 1)];
					c.GenerateBreadcrumb = (System.Boolean)reader[((int)DynamicPagesColumn.GenerateBreadcrumb - 1)];
					c.PublishOn = (reader.IsDBNull(((int)DynamicPagesColumn.PublishOn - 1)))?null:(System.DateTime?)reader[((int)DynamicPagesColumn.PublishOn - 1)];
					c.Visible = (System.Boolean)reader[((int)DynamicPagesColumn.Visible - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPages"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPages"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicPages entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageId = (System.Int32)reader[((int)DynamicPagesColumn.DynamicPageId - 1)];
			entity.SiteId = (System.Int32)reader[((int)DynamicPagesColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)DynamicPagesColumn.LanguageId - 1)];
			entity.ParentDynamicPageId = (System.Int32)reader[((int)DynamicPagesColumn.ParentDynamicPageId - 1)];
			entity.PageName = (System.String)reader[((int)DynamicPagesColumn.PageName - 1)];
			entity.PageTitle = (reader.IsDBNull(((int)DynamicPagesColumn.PageTitle - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.PageTitle - 1)];
			entity.PageContent = (System.String)reader[((int)DynamicPagesColumn.PageContent - 1)];
			entity.DynamicPageWebPartTemplateId = (reader.IsDBNull(((int)DynamicPagesColumn.DynamicPageWebPartTemplateId - 1)))?null:(System.Int32?)reader[((int)DynamicPagesColumn.DynamicPageWebPartTemplateId - 1)];
			entity.HyperLink = (System.String)reader[((int)DynamicPagesColumn.HyperLink - 1)];
			entity.Valid = (System.Boolean)reader[((int)DynamicPagesColumn.Valid - 1)];
			entity.OpenInNewWindow = (System.Boolean)reader[((int)DynamicPagesColumn.OpenInNewWindow - 1)];
			entity.Sequence = (System.Int32)reader[((int)DynamicPagesColumn.Sequence - 1)];
			entity.FullScreen = (System.Boolean)reader[((int)DynamicPagesColumn.FullScreen - 1)];
			entity.OnTopNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnTopNav - 1)];
			entity.OnLeftNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnLeftNav - 1)];
			entity.OnBottomNav = (System.Boolean)reader[((int)DynamicPagesColumn.OnBottomNav - 1)];
			entity.OnSiteMap = (System.Boolean)reader[((int)DynamicPagesColumn.OnSiteMap - 1)];
			entity.Searchable = (System.Boolean)reader[((int)DynamicPagesColumn.Searchable - 1)];
			entity.MetaKeywords = (reader.IsDBNull(((int)DynamicPagesColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaKeywords - 1)];
			entity.MetaDescription = (reader.IsDBNull(((int)DynamicPagesColumn.MetaDescription - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaDescription - 1)];
			entity.PageFriendlyName = (System.String)reader[((int)DynamicPagesColumn.PageFriendlyName - 1)];
			entity.LastModified = (System.DateTime)reader[((int)DynamicPagesColumn.LastModified - 1)];
			entity.LastModifiedBy = (System.Int32)reader[((int)DynamicPagesColumn.LastModifiedBy - 1)];
			entity.SearchField = (reader.IsDBNull(((int)DynamicPagesColumn.SearchField - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.SearchField - 1)];
			entity.SourceId = (reader.IsDBNull(((int)DynamicPagesColumn.SourceId - 1)))?null:(System.Int32?)reader[((int)DynamicPagesColumn.SourceId - 1)];
			entity.Secured = (System.Boolean)reader[((int)DynamicPagesColumn.Secured - 1)];
			entity.CustomUrl = (reader.IsDBNull(((int)DynamicPagesColumn.CustomUrl - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.CustomUrl - 1)];
			entity.MetaTitle = (reader.IsDBNull(((int)DynamicPagesColumn.MetaTitle - 1)))?null:(System.String)reader[((int)DynamicPagesColumn.MetaTitle - 1)];
			entity.GenerateBreadcrumb = (System.Boolean)reader[((int)DynamicPagesColumn.GenerateBreadcrumb - 1)];
			entity.PublishOn = (reader.IsDBNull(((int)DynamicPagesColumn.PublishOn - 1)))?null:(System.DateTime?)reader[((int)DynamicPagesColumn.PublishOn - 1)];
			entity.Visible = (System.Boolean)reader[((int)DynamicPagesColumn.Visible - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicPages"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPages"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicPages entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.ParentDynamicPageId = (System.Int32)dataRow["ParentDynamicPageID"];
			entity.PageName = (System.String)dataRow["PageName"];
			entity.PageTitle = Convert.IsDBNull(dataRow["PageTitle"]) ? null : (System.String)dataRow["PageTitle"];
			entity.PageContent = (System.String)dataRow["PageContent"];
			entity.DynamicPageWebPartTemplateId = Convert.IsDBNull(dataRow["DynamicPageWebPartTemplateID"]) ? null : (System.Int32?)dataRow["DynamicPageWebPartTemplateID"];
			entity.HyperLink = (System.String)dataRow["HyperLink"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.OpenInNewWindow = (System.Boolean)dataRow["OpenInNewWindow"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.FullScreen = (System.Boolean)dataRow["FullScreen"];
			entity.OnTopNav = (System.Boolean)dataRow["OnTopNav"];
			entity.OnLeftNav = (System.Boolean)dataRow["OnLeftNav"];
			entity.OnBottomNav = (System.Boolean)dataRow["OnBottomNav"];
			entity.OnSiteMap = (System.Boolean)dataRow["OnSiteMap"];
			entity.Searchable = (System.Boolean)dataRow["Searchable"];
			entity.MetaKeywords = Convert.IsDBNull(dataRow["MetaKeywords"]) ? null : (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = Convert.IsDBNull(dataRow["MetaDescription"]) ? null : (System.String)dataRow["MetaDescription"];
			entity.PageFriendlyName = (System.String)dataRow["PageFriendlyName"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = (System.Int32)dataRow["LastModifiedBy"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.SourceId = Convert.IsDBNull(dataRow["SourceID"]) ? null : (System.Int32?)dataRow["SourceID"];
			entity.Secured = (System.Boolean)dataRow["Secured"];
			entity.CustomUrl = Convert.IsDBNull(dataRow["CustomUrl"]) ? null : (System.String)dataRow["CustomUrl"];
			entity.MetaTitle = Convert.IsDBNull(dataRow["MetaTitle"]) ? null : (System.String)dataRow["MetaTitle"];
			entity.GenerateBreadcrumb = (System.Boolean)dataRow["GenerateBreadcrumb"];
			entity.PublishOn = Convert.IsDBNull(dataRow["PublishOn"]) ? null : (System.DateTime?)dataRow["PublishOn"];
			entity.Visible = (System.Boolean)dataRow["Visible"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicPages"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPages Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicPages entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DynamicPageWebPartTemplateIdSource	
			if (CanDeepLoad(entity, "DynamicPageWebPartTemplates|DynamicPageWebPartTemplateIdSource", deepLoadType, innerList) 
				&& entity.DynamicPageWebPartTemplateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DynamicPageWebPartTemplateId ?? (int)0);
				DynamicPageWebPartTemplates tmpEntity = EntityManager.LocateEntity<DynamicPageWebPartTemplates>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPageWebPartTemplates), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DynamicPageWebPartTemplateIdSource = tmpEntity;
				else
					entity.DynamicPageWebPartTemplateIdSource = DataRepository.DynamicPageWebPartTemplatesProvider.GetByDynamicPageWebPartTemplateId(transactionManager, (entity.DynamicPageWebPartTemplateId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DynamicPageWebPartTemplateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPageWebPartTemplatesProvider.DeepLoad(transactionManager, entity.DynamicPageWebPartTemplateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DynamicPageWebPartTemplateIdSource

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDynamicPageId methods when available
			
			#region RelatedDynamicPagesCollectionGetByDynamicPageId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RelatedDynamicPages>|RelatedDynamicPagesCollectionGetByDynamicPageId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RelatedDynamicPagesCollectionGetByDynamicPageId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RelatedDynamicPagesCollectionGetByDynamicPageId = DataRepository.RelatedDynamicPagesProvider.GetByDynamicPageId(transactionManager, entity.DynamicPageId);

				if (deep && entity.RelatedDynamicPagesCollectionGetByDynamicPageId.Count > 0)
				{
					deepHandles.Add("RelatedDynamicPagesCollectionGetByDynamicPageId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RelatedDynamicPages>) DataRepository.RelatedDynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.RelatedDynamicPagesCollectionGetByDynamicPageId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages", deepLoadType, innerList))
			{
				entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages = DataRepository.DynamicPagesProvider.GetByRelatedDynamicPageIdFromRelatedDynamicPages(transactionManager, entity.DynamicPageId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages != null)
				{
					deepHandles.Add("DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<DynamicPages>|RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages", deepLoadType, innerList))
			{
				entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages = DataRepository.DynamicPagesProvider.GetByDynamicPageIdFromRelatedDynamicPages(transactionManager, entity.DynamicPageId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages != null)
				{
					deepHandles.Add("RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region GlobalSettingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<GlobalSettings>|GlobalSettingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GlobalSettingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetByDefaultDynamicPageId(transactionManager, entity.DynamicPageId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicpagesCustomWidgetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicpagesCustomWidget>|DynamicpagesCustomWidgetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicpagesCustomWidgetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicpagesCustomWidgetCollection = DataRepository.DynamicpagesCustomWidgetProvider.GetByDynamicPageId(transactionManager, entity.DynamicPageId);

				if (deep && entity.DynamicpagesCustomWidgetCollection.Count > 0)
				{
					deepHandles.Add("DynamicpagesCustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicpagesCustomWidget>) DataRepository.DynamicpagesCustomWidgetProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicpagesCustomWidgetCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region RelatedDynamicPagesCollectionGetByRelatedDynamicPageId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<RelatedDynamicPages>|RelatedDynamicPagesCollectionGetByRelatedDynamicPageId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RelatedDynamicPagesCollectionGetByRelatedDynamicPageId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId = DataRepository.RelatedDynamicPagesProvider.GetByRelatedDynamicPageId(transactionManager, entity.DynamicPageId);

				if (deep && entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId.Count > 0)
				{
					deepHandles.Add("RelatedDynamicPagesCollectionGetByRelatedDynamicPageId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<RelatedDynamicPages>) DataRepository.RelatedDynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicPages object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicPages instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicPages Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicPages entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DynamicPageWebPartTemplateIdSource
			if (CanDeepSave(entity, "DynamicPageWebPartTemplates|DynamicPageWebPartTemplateIdSource", deepSaveType, innerList) 
				&& entity.DynamicPageWebPartTemplateIdSource != null)
			{
				DataRepository.DynamicPageWebPartTemplatesProvider.Save(transactionManager, entity.DynamicPageWebPartTemplateIdSource);
				entity.DynamicPageWebPartTemplateId = entity.DynamicPageWebPartTemplateIdSource.DynamicPageWebPartTemplateId;
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

			#region DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages>
			if (CanDeepSave(entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, "List<DynamicPages>|DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages", deepSaveType, innerList))
			{
				if (entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages.Count > 0 || entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages.DeletedItems.Count > 0)
				{
					DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages); 
					deepHandles.Add("DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepSave,
						new object[] { transactionManager, entity.DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages>
			if (CanDeepSave(entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, "List<DynamicPages>|RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages", deepSaveType, innerList))
			{
				if (entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages.Count > 0 || entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages.DeletedItems.Count > 0)
				{
					DataRepository.DynamicPagesProvider.Save(transactionManager, entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages); 
					deepHandles.Add("RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepSave,
						new object[] { transactionManager, entity.RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<RelatedDynamicPages>
				if (CanDeepSave(entity.RelatedDynamicPagesCollectionGetByDynamicPageId, "List<RelatedDynamicPages>|RelatedDynamicPagesCollectionGetByDynamicPageId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RelatedDynamicPages child in entity.RelatedDynamicPagesCollectionGetByDynamicPageId)
					{
						if(child.RelatedDynamicPageIdSource != null)
						{
								child.RelatedDynamicPageId = child.RelatedDynamicPageIdSource.DynamicPageId;
						}

						if(child.DynamicPageIdSource != null)
						{
								child.DynamicPageId = child.DynamicPageIdSource.DynamicPageId;
						}

					}

					if (entity.RelatedDynamicPagesCollectionGetByDynamicPageId.Count > 0 || entity.RelatedDynamicPagesCollectionGetByDynamicPageId.DeletedItems.Count > 0)
					{
						//DataRepository.RelatedDynamicPagesProvider.Save(transactionManager, entity.RelatedDynamicPagesCollectionGetByDynamicPageId);
						
						deepHandles.Add("RelatedDynamicPagesCollectionGetByDynamicPageId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RelatedDynamicPages >) DataRepository.RelatedDynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.RelatedDynamicPagesCollectionGetByDynamicPageId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<GlobalSettings>
				if (CanDeepSave(entity.GlobalSettingsCollection, "List<GlobalSettings>|GlobalSettingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(GlobalSettings child in entity.GlobalSettingsCollection)
					{
						if(child.DefaultDynamicPageIdSource != null)
						{
							child.DefaultDynamicPageId = child.DefaultDynamicPageIdSource.DynamicPageId;
						}
						else
						{
							child.DefaultDynamicPageId = entity.DynamicPageId;
						}

					}

					if (entity.GlobalSettingsCollection.Count > 0 || entity.GlobalSettingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.GlobalSettingsProvider.Save(transactionManager, entity.GlobalSettingsCollection);
						
						deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< GlobalSettings >) DataRepository.GlobalSettingsProvider.DeepSave,
							new object[] { transactionManager, entity.GlobalSettingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicpagesCustomWidget>
				if (CanDeepSave(entity.DynamicpagesCustomWidgetCollection, "List<DynamicpagesCustomWidget>|DynamicpagesCustomWidgetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicpagesCustomWidget child in entity.DynamicpagesCustomWidgetCollection)
					{
						if(child.DynamicPageIdSource != null)
						{
							child.DynamicPageId = child.DynamicPageIdSource.DynamicPageId;
						}
						else
						{
							child.DynamicPageId = entity.DynamicPageId;
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
				
	
			#region List<RelatedDynamicPages>
				if (CanDeepSave(entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId, "List<RelatedDynamicPages>|RelatedDynamicPagesCollectionGetByRelatedDynamicPageId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(RelatedDynamicPages child in entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId)
					{
						if(child.RelatedDynamicPageIdSource != null)
						{
								child.RelatedDynamicPageId = child.RelatedDynamicPageIdSource.DynamicPageId;
						}

						if(child.DynamicPageIdSource != null)
						{
								child.DynamicPageId = child.DynamicPageIdSource.DynamicPageId;
						}

					}

					if (entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId.Count > 0 || entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId.DeletedItems.Count > 0)
					{
						//DataRepository.RelatedDynamicPagesProvider.Save(transactionManager, entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId);
						
						deepHandles.Add("RelatedDynamicPagesCollectionGetByRelatedDynamicPageId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< RelatedDynamicPages >) DataRepository.RelatedDynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.RelatedDynamicPagesCollectionGetByRelatedDynamicPageId, deepSaveType, childTypes, innerList }
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
	
	#region DynamicPagesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicPages</c>
	///</summary>
	public enum DynamicPagesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DynamicPageWebPartTemplates</c> at DynamicPageWebPartTemplateIdSource
		///</summary>
		[ChildEntityType(typeof(DynamicPageWebPartTemplates))]
		DynamicPageWebPartTemplates,
			
		///<summary>
		/// Composite Property for <c>Languages</c> at LanguageIdSource
		///</summary>
		[ChildEntityType(typeof(Languages))]
		Languages,
			
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
		/// Collection of <c>DynamicPages</c> as OneToMany for RelatedDynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<RelatedDynamicPages>))]
		RelatedDynamicPagesCollectionGetByDynamicPageId,

		///<summary>
		/// Collection of <c>DynamicPages</c> as ManyToMany for DynamicPagesCollection_From_RelatedDynamicPages
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		DynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages,

		///<summary>
		/// Collection of <c>DynamicPages</c> as ManyToMany for DynamicPagesCollection_From_RelatedDynamicPages
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		RelatedDynamicPageIdDynamicPagesCollection_From_RelatedDynamicPages,

		///<summary>
		/// Collection of <c>DynamicPages</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,

		///<summary>
		/// Collection of <c>DynamicPages</c> as OneToMany for DynamicpagesCustomWidgetCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicpagesCustomWidget>))]
		DynamicpagesCustomWidgetCollection,

		///<summary>
		/// Collection of <c>DynamicPages</c> as OneToMany for RelatedDynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<RelatedDynamicPages>))]
		RelatedDynamicPagesCollectionGetByRelatedDynamicPageId,
	}
	
	#endregion DynamicPagesChildEntityTypes
	
	#region DynamicPagesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesFilterBuilder : SqlFilterBuilder<DynamicPagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilterBuilder class.
		/// </summary>
		public DynamicPagesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPagesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPagesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPagesFilterBuilder
	
	#region DynamicPagesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesParameterBuilder : ParameterizedSqlFilterBuilder<DynamicPagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesParameterBuilder class.
		/// </summary>
		public DynamicPagesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPagesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPagesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPagesParameterBuilder
	
	#region DynamicPagesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicPagesSortBuilder : SqlSortBuilder<DynamicPagesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesSqlSortBuilder class.
		/// </summary>
		public DynamicPagesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicPagesSortBuilder
	
} // end namespace
