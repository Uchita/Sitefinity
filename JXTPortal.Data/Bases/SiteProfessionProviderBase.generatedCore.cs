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
	/// This class is the base class for any <see cref="SiteProfessionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SiteProfessionProviderBaseCore : EntityProviderBase<JXTPortal.Entities.SiteProfession, JXTPortal.Entities.SiteProfessionKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SiteProfessionKey key)
		{
			return Delete(transactionManager, key.SiteProfessionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteProfessionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteProfessionId)
		{
			return Delete(null, _siteProfessionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteProfessionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteProfessionId);		
		
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
		public override JXTPortal.Entities.SiteProfession Get(TransactionManager transactionManager, JXTPortal.Entities.SiteProfessionKey key, int start, int pageLength)
		{
			return GetBySiteProfessionId(transactionManager, key.SiteProfessionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteIdProfessionId(System.Int32 _siteId, System.Int32 _professionId)
		{
			int count = -1;
			return GetBySiteIdProfessionId(null,_siteId, _professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteIdProfessionId(System.Int32 _siteId, System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdProfessionId(null, _siteId, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteIdProfessionId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _professionId)
		{
			int count = -1;
			return GetBySiteIdProfessionId(transactionManager, _siteId, _professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteIdProfessionId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdProfessionId(transactionManager, _siteId, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteIdProfessionId(System.Int32 _siteId, System.Int32 _professionId, int start, int pageLength, out int count)
		{
			return GetBySiteIdProfessionId(null, _siteId, _professionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the _dta_index_SiteProfession_7_224719853__K2_K3_4_10 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public abstract TList<SiteProfession> GetBySiteIdProfessionId(TransactionManager transactionManager, System.Int32 _siteId, System.Int32 _professionId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SiteProfession index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(null,_siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetBySiteId(System.Int32 _siteId, int start, int pageLength, out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public abstract TList<SiteProfession> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetByProfessionId(System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(null,_professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetByProfessionId(System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public TList<SiteProfession> GetByProfessionId(System.Int32 _professionId, int start, int pageLength, out int count)
		{
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SiteProfession_ProfessionID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SiteProfession&gt;"/> class.</returns>
		public abstract TList<SiteProfession> GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="_siteProfessionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public JXTPortal.Entities.SiteProfession GetBySiteProfessionId(System.Int32 _siteProfessionId)
		{
			int count = -1;
			return GetBySiteProfessionId(null,_siteProfessionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="_siteProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public JXTPortal.Entities.SiteProfession GetBySiteProfessionId(System.Int32 _siteProfessionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteProfessionId(null, _siteProfessionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteProfessionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public JXTPortal.Entities.SiteProfession GetBySiteProfessionId(TransactionManager transactionManager, System.Int32 _siteProfessionId)
		{
			int count = -1;
			return GetBySiteProfessionId(transactionManager, _siteProfessionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public JXTPortal.Entities.SiteProfession GetBySiteProfessionId(TransactionManager transactionManager, System.Int32 _siteProfessionId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteProfessionId(transactionManager, _siteProfessionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="_siteProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public JXTPortal.Entities.SiteProfession GetBySiteProfessionId(System.Int32 _siteProfessionId, int start, int pageLength, out int count)
		{
			return GetBySiteProfessionId(null, _siteProfessionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_SitePr__0E591826 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.SiteProfession"/> class.</returns>
		public abstract JXTPortal.Entities.SiteProfession GetBySiteProfessionId(TransactionManager transactionManager, System.Int32 _siteProfessionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region SiteProfession_CustomGetBySiteIDFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDFriendlyUrl(System.Int32? siteId, System.String siteProfessionFriendlyUrl)
		{
			return CustomGetBySiteIDFriendlyUrl(null, 0, int.MaxValue , siteId, siteProfessionFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String siteProfessionFriendlyUrl)
		{
			return CustomGetBySiteIDFriendlyUrl(null, start, pageLength , siteId, siteProfessionFriendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String siteProfessionFriendlyUrl)
		{
			return CustomGetBySiteIDFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, siteProfessionFriendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public abstract TList<SiteProfession> CustomGetBySiteIDFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteProfessionFriendlyUrl);
		
		#endregion
		
		#region SiteProfession_GetBySiteIdProfessionId 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdProfessionId(System.Int32? siteId, System.Int32? professionId)
		{
			return GetBySiteIdProfessionId(null, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdProfessionId(int start, int pageLength, System.Int32? siteId, System.Int32? professionId)
		{
			return GetBySiteIdProfessionId(null, start, pageLength , siteId, professionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdProfessionId(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId)
		{
			return GetBySiteIdProfessionId(transactionManager, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? professionId);
		
		#endregion
		
		#region SiteProfession_Insert 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteProfessionId)
		{
			 Insert(null, 0, int.MaxValue , siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl, ref siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteProfessionId)
		{
			 Insert(null, start, pageLength , siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl, ref siteProfessionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteProfessionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl, ref siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl, ref System.Int32? siteProfessionId);
		
		#endregion
		
		#region SiteProfession_GetByProfessionId 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(System.Int32? professionId)
		{
			return GetByProfessionId(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(int start, int pageLength, System.Int32? professionId)
		{
			return GetByProfessionId(null, start, pageLength , professionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(TransactionManager transactionManager, System.Int32? professionId)
		{
			return GetByProfessionId(transactionManager, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId);
		
		#endregion
		
		#region SiteProfession_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteProfession_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'SiteProfession_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region SiteProfession_Get_List 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Get_List' stored procedure. 
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
		///	This method wrap the 'SiteProfession_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region SiteProfession_GetPaged 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteProfession_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteProfession_GetPaged' stored procedure. 
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
		///	This method wrap the 'SiteProfession_GetPaged' stored procedure. 
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
		
		#region SiteProfession_GetBySiteIdFriendlyUrl 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(int start, int pageLength, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(null, start, pageLength , siteId, friendlyUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdFriendlyUrl(TransactionManager transactionManager, System.Int32? siteId, System.String friendlyUrl)
		{
			return GetBySiteIdFriendlyUrl(transactionManager, 0, int.MaxValue , siteId, friendlyUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteIdFriendlyUrl' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdFriendlyUrl(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String friendlyUrl);
		
		#endregion
		
		#region SiteProfession_CustomBulkInsert 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(System.String values)
		{
			 CustomBulkInsert(null, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(int start, int pageLength, System.String values)
		{
			 CustomBulkInsert(null, start, pageLength , values);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(TransactionManager transactionManager, System.String values)
		{
			 CustomBulkInsert(transactionManager, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkInsert(TransactionManager transactionManager, int start, int pageLength , System.String values);
		
		#endregion
		
		#region SiteProfession_CustomBulkDelete 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(System.String values)
		{
			 CustomBulkDelete(null, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(int start, int pageLength, System.String values)
		{
			 CustomBulkDelete(null, start, pageLength , values);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkDelete(TransactionManager transactionManager, System.String values)
		{
			 CustomBulkDelete(transactionManager, 0, int.MaxValue , values);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomBulkDelete' stored procedure. 
		/// </summary>
		/// <param name="values"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkDelete(TransactionManager transactionManager, int start, int pageLength , System.String values);
		
		#endregion
		
		#region SiteProfession_CustomGetBySiteIDProfessionID 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDProfessionID(System.Int32? siteId, System.Int32? professionId)
		{
			return CustomGetBySiteIDProfessionID(null, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDProfessionID(int start, int pageLength, System.Int32? siteId, System.Int32? professionId)
		{
			return CustomGetBySiteIDProfessionID(null, start, pageLength , siteId, professionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public TList<SiteProfession> CustomGetBySiteIDProfessionID(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId)
		{
			return CustomGetBySiteIDProfessionID(transactionManager, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_CustomGetBySiteIDProfessionID' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;SiteProfession&gt;"/> instance.</returns>
		public abstract TList<SiteProfession> CustomGetBySiteIDProfessionID(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? professionId);
		
		#endregion
		
		#region SiteProfession_GetBySiteProfessionId 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteProfessionId(System.Int32? siteProfessionId)
		{
			return GetBySiteProfessionId(null, 0, int.MaxValue , siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteProfessionId(int start, int pageLength, System.Int32? siteProfessionId)
		{
			return GetBySiteProfessionId(null, start, pageLength , siteProfessionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteProfessionId(TransactionManager transactionManager, System.Int32? siteProfessionId)
		{
			return GetBySiteProfessionId(transactionManager, 0, int.MaxValue , siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_GetBySiteProfessionId' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteProfessionId);
		
		#endregion
		
		#region SiteProfession_Find 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl);
		
		#endregion
		
		#region SiteProfession_Delete 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteProfessionId)
		{
			 Delete(null, 0, int.MaxValue , siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteProfessionId)
		{
			 Delete(null, start, pageLength , siteProfessionId);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteProfessionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteProfessionId);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteProfessionId);
		
		#endregion
		
		#region SiteProfession_Update 
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Update' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(null, 0, int.MaxValue , siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Update' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(null, start, pageLength , siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
				
		/// <summary>
		///	This method wrap the 'SiteProfession_Update' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , siteProfessionId, siteId, professionId, siteProfessionName, valid, metaTitle, metaKeywords, metaDescription, sequence, siteProfessionFriendlyUrl, totalJobs, canonicalUrl);
		}
		
		/// <summary>
		///	This method wrap the 'SiteProfession_Update' stored procedure. 
		/// </summary>
		/// <param name="siteProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteProfessionFriendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="totalJobs"> A <c>System.Int32?</c> instance.</param>
		/// <param name="canonicalUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteProfessionId, System.Int32? siteId, System.Int32? professionId, System.String siteProfessionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? sequence, System.String siteProfessionFriendlyUrl, System.Int32? totalJobs, System.String canonicalUrl);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SiteProfession&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SiteProfession&gt;"/></returns>
		public static TList<SiteProfession> Fill(IDataReader reader, TList<SiteProfession> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.SiteProfession c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SiteProfession")
					.Append("|").Append((System.Int32)reader[((int)SiteProfessionColumn.SiteProfessionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SiteProfession>(
					key.ToString(), // EntityTrackingKey
					"SiteProfession",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.SiteProfession();
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
					c.SiteProfessionId = (System.Int32)reader[((int)SiteProfessionColumn.SiteProfessionId - 1)];
					c.SiteId = (System.Int32)reader[((int)SiteProfessionColumn.SiteId - 1)];
					c.ProfessionId = (System.Int32)reader[((int)SiteProfessionColumn.ProfessionId - 1)];
					c.SiteProfessionName = (reader.IsDBNull(((int)SiteProfessionColumn.SiteProfessionName - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.SiteProfessionName - 1)];
					c.Valid = (System.Boolean)reader[((int)SiteProfessionColumn.Valid - 1)];
					c.MetaTitle = (System.String)reader[((int)SiteProfessionColumn.MetaTitle - 1)];
					c.MetaKeywords = (System.String)reader[((int)SiteProfessionColumn.MetaKeywords - 1)];
					c.MetaDescription = (System.String)reader[((int)SiteProfessionColumn.MetaDescription - 1)];
					c.Sequence = (System.Int32)reader[((int)SiteProfessionColumn.Sequence - 1)];
					c.SiteProfessionFriendlyUrl = (reader.IsDBNull(((int)SiteProfessionColumn.SiteProfessionFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.SiteProfessionFriendlyUrl - 1)];
					c.TotalJobs = (System.Int32)reader[((int)SiteProfessionColumn.TotalJobs - 1)];
					c.CanonicalUrl = (reader.IsDBNull(((int)SiteProfessionColumn.CanonicalUrl - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.CanonicalUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteProfession"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteProfession"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.SiteProfession entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteProfessionId = (System.Int32)reader[((int)SiteProfessionColumn.SiteProfessionId - 1)];
			entity.SiteId = (System.Int32)reader[((int)SiteProfessionColumn.SiteId - 1)];
			entity.ProfessionId = (System.Int32)reader[((int)SiteProfessionColumn.ProfessionId - 1)];
			entity.SiteProfessionName = (reader.IsDBNull(((int)SiteProfessionColumn.SiteProfessionName - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.SiteProfessionName - 1)];
			entity.Valid = (System.Boolean)reader[((int)SiteProfessionColumn.Valid - 1)];
			entity.MetaTitle = (System.String)reader[((int)SiteProfessionColumn.MetaTitle - 1)];
			entity.MetaKeywords = (System.String)reader[((int)SiteProfessionColumn.MetaKeywords - 1)];
			entity.MetaDescription = (System.String)reader[((int)SiteProfessionColumn.MetaDescription - 1)];
			entity.Sequence = (System.Int32)reader[((int)SiteProfessionColumn.Sequence - 1)];
			entity.SiteProfessionFriendlyUrl = (reader.IsDBNull(((int)SiteProfessionColumn.SiteProfessionFriendlyUrl - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.SiteProfessionFriendlyUrl - 1)];
			entity.TotalJobs = (System.Int32)reader[((int)SiteProfessionColumn.TotalJobs - 1)];
			entity.CanonicalUrl = (reader.IsDBNull(((int)SiteProfessionColumn.CanonicalUrl - 1)))?null:(System.String)reader[((int)SiteProfessionColumn.CanonicalUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.SiteProfession"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteProfession"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.SiteProfession entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteProfessionId = (System.Int32)dataRow["SiteProfessionID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.ProfessionId = (System.Int32)dataRow["ProfessionID"];
			entity.SiteProfessionName = Convert.IsDBNull(dataRow["SiteProfessionName"]) ? null : (System.String)dataRow["SiteProfessionName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.MetaTitle = (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = (System.String)dataRow["MetaDescription"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.SiteProfessionFriendlyUrl = Convert.IsDBNull(dataRow["SiteProfessionFriendlyUrl"]) ? null : (System.String)dataRow["SiteProfessionFriendlyUrl"];
			entity.TotalJobs = (System.Int32)dataRow["TotalJobs"];
			entity.CanonicalUrl = Convert.IsDBNull(dataRow["CanonicalUrl"]) ? null : (System.String)dataRow["CanonicalUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.SiteProfession"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteProfession Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.SiteProfession entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ProfessionIdSource	
			if (CanDeepLoad(entity, "Profession|ProfessionIdSource", deepLoadType, innerList) 
				&& entity.ProfessionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProfessionId;
				Profession tmpEntity = EntityManager.LocateEntity<Profession>(EntityLocator.ConstructKeyFromPkItems(typeof(Profession), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProfessionIdSource = tmpEntity;
				else
					entity.ProfessionIdSource = DataRepository.ProfessionProvider.GetByProfessionId(transactionManager, entity.ProfessionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProfessionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProfessionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProfessionProvider.DeepLoad(transactionManager, entity.ProfessionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProfessionIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.SiteProfession object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.SiteProfession instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.SiteProfession Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.SiteProfession entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProfessionIdSource
			if (CanDeepSave(entity, "Profession|ProfessionIdSource", deepSaveType, innerList) 
				&& entity.ProfessionIdSource != null)
			{
				DataRepository.ProfessionProvider.Save(transactionManager, entity.ProfessionIdSource);
				entity.ProfessionId = entity.ProfessionIdSource.ProfessionId;
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
	
	#region SiteProfessionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.SiteProfession</c>
	///</summary>
	public enum SiteProfessionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profession</c> at ProfessionIdSource
		///</summary>
		[ChildEntityType(typeof(Profession))]
		Profession,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion SiteProfessionChildEntityTypes
	
	#region SiteProfessionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SiteProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionFilterBuilder : SqlFilterBuilder<SiteProfessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilterBuilder class.
		/// </summary>
		public SiteProfessionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteProfessionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteProfessionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteProfessionFilterBuilder
	
	#region SiteProfessionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SiteProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionParameterBuilder : ParameterizedSqlFilterBuilder<SiteProfessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionParameterBuilder class.
		/// </summary>
		public SiteProfessionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteProfessionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteProfessionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteProfessionParameterBuilder
	
	#region SiteProfessionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SiteProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SiteProfessionSortBuilder : SqlSortBuilder<SiteProfessionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionSqlSortBuilder class.
		/// </summary>
		public SiteProfessionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SiteProfessionSortBuilder
	
} // end namespace
