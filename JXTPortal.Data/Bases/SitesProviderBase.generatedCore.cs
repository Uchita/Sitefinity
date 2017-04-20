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
	/// This class is the base class for any <see cref="SitesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SitesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Sites, JXTPortal.Entities.SitesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.SitesKey key)
		{
			return Delete(transactionManager, key.SiteId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_siteId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _siteId)
		{
			return Delete(null, _siteId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _siteId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		FK__Sites__LastModif__153B1FDF Description: 
		/// </summary>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		public TList<Sites> GetByLastModifiedBy(System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(_lastModifiedBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		FK__Sites__LastModif__153B1FDF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		/// <remarks></remarks>
		public TList<Sites> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		FK__Sites__LastModif__153B1FDF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		public TList<Sites> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count = -1;
			return GetByLastModifiedBy(transactionManager, _lastModifiedBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		fkSitesLastModif153b1Fdf Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		public TList<Sites> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		fkSitesLastModif153b1Fdf Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		public TList<Sites> GetByLastModifiedBy(System.Int32? _lastModifiedBy, int start, int pageLength,out int count)
		{
			return GetByLastModifiedBy(null, _lastModifiedBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Sites__LastModif__153B1FDF key.
		///		FK__Sites__LastModif__153B1FDF Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastModifiedBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Sites objects.</returns>
		public abstract TList<Sites> GetByLastModifiedBy(TransactionManager transactionManager, System.Int32? _lastModifiedBy, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Sites Get(TransactionManager transactionManager, JXTPortal.Entities.SitesKey key, int start, int pageLength)
		{
			return GetBySiteId(transactionManager, key.SiteId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(null,_siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetBySiteId(System.Int32 _siteId, int start, int pageLength, out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__tmp_ms_xx_Sites__0504B816 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public abstract JXTPortal.Entities.Sites GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="_mobileUrl"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetByMobileUrl(System.String _mobileUrl)
		{
			int count = -1;
			return GetByMobileUrl(null,_mobileUrl, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="_mobileUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetByMobileUrl(System.String _mobileUrl, int start, int pageLength)
		{
			int count = -1;
			return GetByMobileUrl(null, _mobileUrl, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mobileUrl"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetByMobileUrl(TransactionManager transactionManager, System.String _mobileUrl)
		{
			int count = -1;
			return GetByMobileUrl(transactionManager, _mobileUrl, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mobileUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetByMobileUrl(TransactionManager transactionManager, System.String _mobileUrl, int start, int pageLength)
		{
			int count = -1;
			return GetByMobileUrl(transactionManager, _mobileUrl, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="_mobileUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public JXTPortal.Entities.Sites GetByMobileUrl(System.String _mobileUrl, int start, int pageLength, out int count)
		{
			return GetByMobileUrl(null, _mobileUrl, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UX_Sites_MobileUrl index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mobileUrl"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Sites"/> class.</returns>
		public abstract JXTPortal.Entities.Sites GetByMobileUrl(TransactionManager transactionManager, System.String _mobileUrl, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Sites_Create 
		
		/// <summary>
		///	This method wrap the 'Sites_Create' stored procedure. 
		/// </summary>
		/// <param name="sourceSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Create(System.Int32? sourceSiteId, System.Int32? languageId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Int32? lastModifiedBy)
		{
			return Create(null, 0, int.MaxValue , sourceSiteId, languageId, siteName, siteUrl, siteDescription, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Create' stored procedure. 
		/// </summary>
		/// <param name="sourceSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Create(int start, int pageLength, System.Int32? sourceSiteId, System.Int32? languageId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Int32? lastModifiedBy)
		{
			return Create(null, start, pageLength , sourceSiteId, languageId, siteName, siteUrl, siteDescription, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Create' stored procedure. 
		/// </summary>
		/// <param name="sourceSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Create(TransactionManager transactionManager, System.Int32? sourceSiteId, System.Int32? languageId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Int32? lastModifiedBy)
		{
			return Create(transactionManager, 0, int.MaxValue , sourceSiteId, languageId, siteName, siteUrl, siteDescription, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Create' stored procedure. 
		/// </summary>
		/// <param name="sourceSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Create(TransactionManager transactionManager, int start, int pageLength , System.Int32? sourceSiteId, System.Int32? languageId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region Sites_Insert 
		
		/// <summary>
		///	This method wrap the 'Sites_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl, ref System.Int32? siteId)
		{
			 Insert(null, 0, int.MaxValue , siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl, ref siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl, ref System.Int32? siteId)
		{
			 Insert(null, start, pageLength , siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl, ref siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl, ref System.Int32? siteId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl, ref siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
			/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl, ref System.Int32? siteId);
		
		#endregion
		
		#region Sites_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Sites_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Sites_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Sites_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Sites_Get_List 
		
		/// <summary>
		///	This method wrap the 'Sites_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Get_List' stored procedure. 
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
		///	This method wrap the 'Sites_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Sites_GetByMobileUrl 
		
		/// <summary>
		///	This method wrap the 'Sites_GetByMobileUrl' stored procedure. 
		/// </summary>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMobileUrl(int start, int pageLength, System.String mobileUrl)
		{
			return GetByMobileUrl(null, start, pageLength , mobileUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_GetByMobileUrl' stored procedure. 
		/// </summary>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMobileUrl(TransactionManager transactionManager, int start, int pageLength , System.String mobileUrl);
		
		#endregion
		
		#region Sites_FindSite 
		
		/// <summary>
		///	This method wrap the 'Sites_FindSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet FindSite(System.Int32? siteId, System.String siteUrl)
		{
			return FindSite(null, 0, int.MaxValue , siteId, siteUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_FindSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet FindSite(int start, int pageLength, System.Int32? siteId, System.String siteUrl)
		{
			return FindSite(null, start, pageLength , siteId, siteUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_FindSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet FindSite(TransactionManager transactionManager, System.Int32? siteId, System.String siteUrl)
		{
			return FindSite(transactionManager, 0, int.MaxValue , siteId, siteUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_FindSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet FindSite(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteUrl);
		
		#endregion
		
		#region Sites_Update 
		
		/// <summary>
		///	This method wrap the 'Sites_Update' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			 Update(null, 0, int.MaxValue , siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Update' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			 Update(null, start, pageLength , siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Update' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Update' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl);
		
		#endregion
		
		#region Sites_Remove 
		
		/// <summary>
		///	This method wrap the 'Sites_Remove' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Remove(System.Int32? siteId)
		{
			 Remove(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Remove' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Remove(int start, int pageLength, System.Int32? siteId)
		{
			 Remove(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Remove' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Remove(TransactionManager transactionManager, System.Int32? siteId)
		{
			 Remove(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Remove' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Remove(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Sites_GetPaging 
		
		/// <summary>
		///	This method wrap the 'Sites_GetPaging' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaging(System.Int32? siteId, System.String siteName, System.String siteUrl, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPaging(null, 0, int.MaxValue , siteId, siteName, siteUrl, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_GetPaging' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaging(int start, int pageLength, System.Int32? siteId, System.String siteName, System.String siteUrl, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPaging(null, start, pageLength , siteId, siteName, siteUrl, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_GetPaging' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetPaging(TransactionManager transactionManager, System.Int32? siteId, System.String siteName, System.String siteUrl, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return GetPaging(transactionManager, 0, int.MaxValue , siteId, siteName, siteUrl, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_GetPaging' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetPaging(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteName, System.String siteUrl, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region Sites_Find 
		
		/// <summary>
		///	This method wrap the 'Sites_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, siteId, siteName, siteUrl, siteDescription, siteAdminLogo, lastModified, lastModifiedBy, live, mobileEnabled, mobileUrl, siteAdminLogoUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogo"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="live"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileEnabled"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="mobileUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteAdminLogoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.Byte[] siteAdminLogo, System.DateTime? lastModified, System.Int32? lastModifiedBy, System.Boolean? live, System.Boolean? mobileEnabled, System.String mobileUrl, System.String siteAdminLogoUrl);
		
		#endregion
		
		#region Sites_Copy 
		
		/// <summary>
		///	This method wrap the 'Sites_Copy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="copyGlobalSettings"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyJobTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySiteLocation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyProfessionRoles"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySalaryTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWorkTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEducation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyAvailableStatus"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWebParts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWidgets"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEmailTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="selectedLanguages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedDynamicPages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedFiles"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Copy(System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.String ftpFolderLocation, System.Boolean? copyGlobalSettings, System.Boolean? copyJobTemplates, System.Boolean? copySiteLocation, System.Boolean? copyProfessionRoles, System.Boolean? useCustomProfessionRole, System.Boolean? copySalaryTypes, System.Boolean? copyWorkTypes, System.Boolean? copyEducation, System.Boolean? copyAvailableStatus, System.Boolean? copyWebParts, System.Boolean? copyWidgets, System.Boolean? copyEmailTemplates, System.String selectedLanguages, System.String selectedDynamicPages, System.String selectedFiles, System.Int32? lastModifiedBy)
		{
			return Copy(null, 0, int.MaxValue , siteId, siteName, siteUrl, siteDescription, ftpFolderLocation, copyGlobalSettings, copyJobTemplates, copySiteLocation, copyProfessionRoles, useCustomProfessionRole, copySalaryTypes, copyWorkTypes, copyEducation, copyAvailableStatus, copyWebParts, copyWidgets, copyEmailTemplates, selectedLanguages, selectedDynamicPages, selectedFiles, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Copy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="copyGlobalSettings"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyJobTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySiteLocation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyProfessionRoles"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySalaryTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWorkTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEducation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyAvailableStatus"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWebParts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWidgets"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEmailTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="selectedLanguages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedDynamicPages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedFiles"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Copy(int start, int pageLength, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.String ftpFolderLocation, System.Boolean? copyGlobalSettings, System.Boolean? copyJobTemplates, System.Boolean? copySiteLocation, System.Boolean? copyProfessionRoles, System.Boolean? useCustomProfessionRole, System.Boolean? copySalaryTypes, System.Boolean? copyWorkTypes, System.Boolean? copyEducation, System.Boolean? copyAvailableStatus, System.Boolean? copyWebParts, System.Boolean? copyWidgets, System.Boolean? copyEmailTemplates, System.String selectedLanguages, System.String selectedDynamicPages, System.String selectedFiles, System.Int32? lastModifiedBy)
		{
			return Copy(null, start, pageLength , siteId, siteName, siteUrl, siteDescription, ftpFolderLocation, copyGlobalSettings, copyJobTemplates, copySiteLocation, copyProfessionRoles, useCustomProfessionRole, copySalaryTypes, copyWorkTypes, copyEducation, copyAvailableStatus, copyWebParts, copyWidgets, copyEmailTemplates, selectedLanguages, selectedDynamicPages, selectedFiles, lastModifiedBy);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Copy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="copyGlobalSettings"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyJobTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySiteLocation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyProfessionRoles"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySalaryTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWorkTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEducation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyAvailableStatus"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWebParts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWidgets"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEmailTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="selectedLanguages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedDynamicPages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedFiles"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Copy(TransactionManager transactionManager, System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.String ftpFolderLocation, System.Boolean? copyGlobalSettings, System.Boolean? copyJobTemplates, System.Boolean? copySiteLocation, System.Boolean? copyProfessionRoles, System.Boolean? useCustomProfessionRole, System.Boolean? copySalaryTypes, System.Boolean? copyWorkTypes, System.Boolean? copyEducation, System.Boolean? copyAvailableStatus, System.Boolean? copyWebParts, System.Boolean? copyWidgets, System.Boolean? copyEmailTemplates, System.String selectedLanguages, System.String selectedDynamicPages, System.String selectedFiles, System.Int32? lastModifiedBy)
		{
			return Copy(transactionManager, 0, int.MaxValue , siteId, siteName, siteUrl, siteDescription, ftpFolderLocation, copyGlobalSettings, copyJobTemplates, copySiteLocation, copyProfessionRoles, useCustomProfessionRole, copySalaryTypes, copyWorkTypes, copyEducation, copyAvailableStatus, copyWebParts, copyWidgets, copyEmailTemplates, selectedLanguages, selectedDynamicPages, selectedFiles, lastModifiedBy);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Copy' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteName"> A <c>System.String</c> instance.</param>
		/// <param name="siteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="siteDescription"> A <c>System.String</c> instance.</param>
		/// <param name="ftpFolderLocation"> A <c>System.String</c> instance.</param>
		/// <param name="copyGlobalSettings"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyJobTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySiteLocation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyProfessionRoles"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="useCustomProfessionRole"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copySalaryTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWorkTypes"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEducation"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyAvailableStatus"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWebParts"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyWidgets"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="copyEmailTemplates"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="selectedLanguages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedDynamicPages"> A <c>System.String</c> instance.</param>
		/// <param name="selectedFiles"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Copy(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String siteName, System.String siteUrl, System.String siteDescription, System.String ftpFolderLocation, System.Boolean? copyGlobalSettings, System.Boolean? copyJobTemplates, System.Boolean? copySiteLocation, System.Boolean? copyProfessionRoles, System.Boolean? useCustomProfessionRole, System.Boolean? copySalaryTypes, System.Boolean? copyWorkTypes, System.Boolean? copyEducation, System.Boolean? copyAvailableStatus, System.Boolean? copyWebParts, System.Boolean? copyWidgets, System.Boolean? copyEmailTemplates, System.String selectedLanguages, System.String selectedDynamicPages, System.String selectedFiles, System.Int32? lastModifiedBy);
		
		#endregion
		
		#region Sites_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Sites_GetPaged' stored procedure. 
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
		///	This method wrap the 'Sites_GetPaged' stored procedure. 
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
		///	This method wrap the 'Sites_GetPaged' stored procedure. 
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
		///	This method wrap the 'Sites_GetPaged' stored procedure. 
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
		
		#region Sites_GetByLastModifiedBy 
		
		/// <summary>
		///	This method wrap the 'Sites_GetByLastModifiedBy' stored procedure. 
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
		///	This method wrap the 'Sites_GetByLastModifiedBy' stored procedure. 
		/// </summary>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByLastModifiedBy(TransactionManager transactionManager, int start, int pageLength , System.Int32? lastModifiedBy);
		
		#endregion
		
		#region Sites_Delete 
		
		/// <summary>
		///	This method wrap the 'Sites_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? siteId)
		{
			 Delete(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? siteId)
		{
			 Delete(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Sites_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? siteId)
		{
			 Delete(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Sites_Delete' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Sites&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Sites&gt;"/></returns>
		public static TList<Sites> Fill(IDataReader reader, TList<Sites> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Sites c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Sites")
					.Append("|").Append((System.Int32)reader[((int)SitesColumn.SiteId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Sites>(
					key.ToString(), // EntityTrackingKey
					"Sites",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Sites();
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
					c.SiteId = (System.Int32)reader[((int)SitesColumn.SiteId - 1)];
					c.SiteName = (reader.IsDBNull(((int)SitesColumn.SiteName - 1)))?null:(System.String)reader[((int)SitesColumn.SiteName - 1)];
					c.SiteUrl = (reader.IsDBNull(((int)SitesColumn.SiteUrl - 1)))?null:(System.String)reader[((int)SitesColumn.SiteUrl - 1)];
					c.SiteDescription = (reader.IsDBNull(((int)SitesColumn.SiteDescription - 1)))?null:(System.String)reader[((int)SitesColumn.SiteDescription - 1)];
					c.SiteAdminLogo = (reader.IsDBNull(((int)SitesColumn.SiteAdminLogo - 1)))?null:(System.Byte[])reader[((int)SitesColumn.SiteAdminLogo - 1)];
					c.LastModified = (System.DateTime)reader[((int)SitesColumn.LastModified - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)SitesColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SitesColumn.LastModifiedBy - 1)];
					c.Live = (reader.IsDBNull(((int)SitesColumn.Live - 1)))?null:(System.Boolean?)reader[((int)SitesColumn.Live - 1)];
					c.MobileEnabled = (System.Boolean)reader[((int)SitesColumn.MobileEnabled - 1)];
					c.MobileUrl = (System.String)reader[((int)SitesColumn.MobileUrl - 1)];
					c.SiteAdminLogoUrl = (reader.IsDBNull(((int)SitesColumn.SiteAdminLogoUrl - 1)))?null:(System.String)reader[((int)SitesColumn.SiteAdminLogoUrl - 1)];
					c.SiteUrlAlias = (reader.IsDBNull(((int)SitesColumn.SiteUrlAlias - 1)))?null:(System.String)reader[((int)SitesColumn.SiteUrlAlias - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Sites"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Sites"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Sites entity)
		{
			if (!reader.Read()) return;
			
			entity.SiteId = (System.Int32)reader[((int)SitesColumn.SiteId - 1)];
			entity.SiteName = (reader.IsDBNull(((int)SitesColumn.SiteName - 1)))?null:(System.String)reader[((int)SitesColumn.SiteName - 1)];
			entity.SiteUrl = (reader.IsDBNull(((int)SitesColumn.SiteUrl - 1)))?null:(System.String)reader[((int)SitesColumn.SiteUrl - 1)];
			entity.SiteDescription = (reader.IsDBNull(((int)SitesColumn.SiteDescription - 1)))?null:(System.String)reader[((int)SitesColumn.SiteDescription - 1)];
			entity.SiteAdminLogo = (reader.IsDBNull(((int)SitesColumn.SiteAdminLogo - 1)))?null:(System.Byte[])reader[((int)SitesColumn.SiteAdminLogo - 1)];
			entity.LastModified = (System.DateTime)reader[((int)SitesColumn.LastModified - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)SitesColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)SitesColumn.LastModifiedBy - 1)];
			entity.Live = (reader.IsDBNull(((int)SitesColumn.Live - 1)))?null:(System.Boolean?)reader[((int)SitesColumn.Live - 1)];
			entity.MobileEnabled = (System.Boolean)reader[((int)SitesColumn.MobileEnabled - 1)];
			entity.MobileUrl = (System.String)reader[((int)SitesColumn.MobileUrl - 1)];
			entity.SiteAdminLogoUrl = (reader.IsDBNull(((int)SitesColumn.SiteAdminLogoUrl - 1)))?null:(System.String)reader[((int)SitesColumn.SiteAdminLogoUrl - 1)];
			entity.SiteUrlAlias = (reader.IsDBNull(((int)SitesColumn.SiteUrlAlias - 1)))?null:(System.String)reader[((int)SitesColumn.SiteUrlAlias - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Sites"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Sites"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Sites entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.SiteName = Convert.IsDBNull(dataRow["SiteName"]) ? null : (System.String)dataRow["SiteName"];
			entity.SiteUrl = Convert.IsDBNull(dataRow["SiteURL"]) ? null : (System.String)dataRow["SiteURL"];
			entity.SiteDescription = Convert.IsDBNull(dataRow["SiteDescription"]) ? null : (System.String)dataRow["SiteDescription"];
			entity.SiteAdminLogo = Convert.IsDBNull(dataRow["SiteAdminLogo"]) ? null : (System.Byte[])dataRow["SiteAdminLogo"];
			entity.LastModified = (System.DateTime)dataRow["LastModified"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.Live = Convert.IsDBNull(dataRow["Live"]) ? null : (System.Boolean?)dataRow["Live"];
			entity.MobileEnabled = (System.Boolean)dataRow["MobileEnabled"];
			entity.MobileUrl = (System.String)dataRow["MobileUrl"];
			entity.SiteAdminLogoUrl = Convert.IsDBNull(dataRow["SiteAdminLogoUrl"]) ? null : (System.String)dataRow["SiteAdminLogoUrl"];
			entity.SiteUrlAlias = Convert.IsDBNull(dataRow["SiteURLAlias"]) ? null : (System.String)dataRow["SiteURLAlias"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Sites"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Sites Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Sites entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySiteId methods when available
			
			#region AvailableStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AvailableStatus>|AvailableStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AvailableStatusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AvailableStatusCollection = DataRepository.AvailableStatusProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.AvailableStatusCollection.Count > 0)
				{
					deepHandles.Add("AvailableStatusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AvailableStatus>) DataRepository.AvailableStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.AvailableStatusCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobApplicationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplication>|JobApplicationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationCollection = DataRepository.JobApplicationProvider.GetBySiteIdReferral(transactionManager, entity.SiteId);

				if (deep && entity.JobApplicationCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplication>) DataRepository.JobApplicationProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobViewsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobViews>|JobViewsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobViewsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobViewsCollection = DataRepository.JobViewsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobViewsCollection.Count > 0)
				{
					deepHandles.Add("JobViewsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobViews>) DataRepository.JobViewsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobViewsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region IntegrationMappingsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<IntegrationMappings>|IntegrationMappingsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IntegrationMappingsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IntegrationMappingsCollection = DataRepository.IntegrationMappingsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.IntegrationMappingsCollection.Count > 0)
				{
					deepHandles.Add("IntegrationMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<IntegrationMappings>) DataRepository.IntegrationMappingsProvider.DeepLoad,
						new object[] { transactionManager, entity.IntegrationMappingsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteResourcesCollectionGetBySiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollectionGetBySiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollectionGetBySiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollectionGetBySiteId = DataRepository.SiteResourcesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteResourcesCollectionGetBySiteId.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollectionGetBySiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmailTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmailTemplates>|EmailTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmailTemplatesCollection = DataRepository.EmailTemplatesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.EmailTemplatesCollection.Count > 0)
				{
					deepHandles.Add("EmailTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmailTemplates>) DataRepository.EmailTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmailTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MembersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Members>|MembersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MembersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MembersCollection = DataRepository.MembersProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.MembersCollection.Count > 0)
				{
					deepHandles.Add("MembersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Members>) DataRepository.MembersProvider.DeepLoad,
						new object[] { transactionManager, entity.MembersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Jobs>|JobsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsCollection = DataRepository.JobsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobsCollection.Count > 0)
				{
					deepHandles.Add("JobsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Jobs>) DataRepository.JobsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPageFilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageFiles>|DynamicPageFilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageFilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageFilesCollection = DataRepository.DynamicPageFilesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.DynamicPageFilesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageFilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageFiles>) DataRepository.DynamicPageFilesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageFilesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteMappingsCollectionGetByMasterSiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteMappings>|SiteMappingsCollectionGetByMasterSiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteMappingsCollectionGetByMasterSiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteMappingsCollectionGetByMasterSiteId = DataRepository.SiteMappingsProvider.GetByMasterSiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteMappingsCollectionGetByMasterSiteId.Count > 0)
				{
					deepHandles.Add("SiteMappingsCollectionGetByMasterSiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteMappings>) DataRepository.SiteMappingsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteMappingsCollectionGetByMasterSiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteWebPartsCollectionGetBySiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartsCollectionGetBySiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWebPartsCollectionGetBySiteId = DataRepository.SiteWebPartsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteWebPartsCollectionGetBySiteId.Count > 0)
				{
					deepHandles.Add("SiteWebPartsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWebParts>) DataRepository.SiteWebPartsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobCustomXmlCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobCustomXml>|JobCustomXmlCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobCustomXmlCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobCustomXmlCollection = DataRepository.JobCustomXmlProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobCustomXmlCollection.Count > 0)
				{
					deepHandles.Add("JobCustomXmlCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobCustomXml>) DataRepository.JobCustomXmlProvider.DeepLoad,
						new object[] { transactionManager, entity.JobCustomXmlCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPageWebPartTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPageWebPartTemplates>|DynamicPageWebPartTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageWebPartTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPageWebPartTemplatesCollection = DataRepository.DynamicPageWebPartTemplatesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.DynamicPageWebPartTemplatesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPageWebPartTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPageWebPartTemplates>) DataRepository.DynamicPageWebPartTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPageWebPartTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicPagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicPages>|DynamicPagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicPagesCollection = DataRepository.DynamicPagesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.DynamicPagesCollection.Count > 0)
				{
					deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicPages>) DataRepository.DynamicPagesProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicPagesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region NewsCategoriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<NewsCategories>|NewsCategoriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCategoriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NewsCategoriesCollection = DataRepository.NewsCategoriesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.NewsCategoriesCollection.Count > 0)
				{
					deepHandles.Add("NewsCategoriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<NewsCategories>) DataRepository.NewsCategoriesProvider.DeepLoad,
						new object[] { transactionManager, entity.NewsCategoriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteAdvertiserFilterCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteAdvertiserFilter>|SiteAdvertiserFilterCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteAdvertiserFilterCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteAdvertiserFilterCollection = DataRepository.SiteAdvertiserFilterProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteAdvertiserFilterCollection.Count > 0)
				{
					deepHandles.Add("SiteAdvertiserFilterCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteAdvertiserFilter>) DataRepository.SiteAdvertiserFilterProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteAdvertiserFilterCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberMembershipsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberMemberships>|MemberMembershipsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberMembershipsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberMembershipsCollection = DataRepository.MemberMembershipsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.MemberMembershipsCollection.Count > 0)
				{
					deepHandles.Add("MemberMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberMemberships>) DataRepository.MemberMembershipsProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberMembershipsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobTemplates>|JobTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobTemplatesCollection = DataRepository.JobTemplatesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobTemplatesCollection.Count > 0)
				{
					deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobTemplates>) DataRepository.JobTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteCountriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteCountries>|SiteCountriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteCountriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteCountriesCollection = DataRepository.SiteCountriesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteCountriesCollection.Count > 0)
				{
					deepHandles.Add("SiteCountriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteCountries>) DataRepository.SiteCountriesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteCountriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WebServiceLogCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WebServiceLog>|WebServiceLogCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WebServiceLogCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WebServiceLogCollection = DataRepository.WebServiceLogProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.WebServiceLogCollection.Count > 0)
				{
					deepHandles.Add("WebServiceLogCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WebServiceLog>) DataRepository.WebServiceLogProvider.DeepLoad,
						new object[] { transactionManager, entity.WebServiceLogCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteLocationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteLocation>|SiteLocationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteLocationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteLocationCollection = DataRepository.SiteLocationProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteLocationCollection.Count > 0)
				{
					deepHandles.Add("SiteLocationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteLocation>) DataRepository.SiteLocationProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteLocationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteProfessionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteProfession>|SiteProfessionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteProfessionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteProfessionCollection = DataRepository.SiteProfessionProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteProfessionCollection.Count > 0)
				{
					deepHandles.Add("SiteProfessionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteProfession>) DataRepository.SiteProfessionProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteProfessionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberWizardCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberWizard>|MemberWizardCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberWizardCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberWizardCollection = DataRepository.MemberWizardProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.MemberWizardCollection.Count > 0)
				{
					deepHandles.Add("MemberWizardCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberWizard>) DataRepository.MemberWizardProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberWizardCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region IndustryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Industry>|IndustryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IndustryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IndustryCollection = DataRepository.IndustryProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.IndustryCollection.Count > 0)
				{
					deepHandles.Add("IndustryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Industry>) DataRepository.IndustryProvider.DeepLoad,
						new object[] { transactionManager, entity.IndustryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ConsultantsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Consultants>|ConsultantsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ConsultantsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ConsultantsCollection = DataRepository.ConsultantsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.ConsultantsCollection.Count > 0)
				{
					deepHandles.Add("ConsultantsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Consultants>) DataRepository.ConsultantsProvider.DeepLoad,
						new object[] { transactionManager, entity.ConsultantsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Files>|FilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FilesCollection = DataRepository.FilesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.FilesCollection.Count > 0)
				{
					deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Files>) DataRepository.FilesProvider.DeepLoad,
						new object[] { transactionManager, entity.FilesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteResourcesXmlCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResourcesXml>|SiteResourcesXmlCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesXmlCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesXmlCollection = DataRepository.SiteResourcesXmlProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteResourcesXmlCollection.Count > 0)
				{
					deepHandles.Add("SiteResourcesXmlCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResourcesXml>) DataRepository.SiteResourcesXmlProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesXmlCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdvertisersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Advertisers>|AdvertisersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdvertisersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdvertisersCollection = DataRepository.AdvertisersProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.AdvertisersCollection.Count > 0)
				{
					deepHandles.Add("AdvertisersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Advertisers>) DataRepository.AdvertisersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdvertisersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberStatus>|MemberStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberStatusCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberStatusCollection = DataRepository.MemberStatusProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.MemberStatusCollection.Count > 0)
				{
					deepHandles.Add("MemberStatusCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberStatus>) DataRepository.MemberStatusProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberStatusCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region WidgetContainersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<WidgetContainers>|WidgetContainersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'WidgetContainersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.WidgetContainersCollection = DataRepository.WidgetContainersProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.WidgetContainersCollection.Count > 0)
				{
					deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WidgetContainers>) DataRepository.WidgetContainersProvider.DeepLoad,
						new object[] { transactionManager, entity.WidgetContainersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region FoldersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Folders>|FoldersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FoldersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.FoldersCollection = DataRepository.FoldersProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.FoldersCollection.Count > 0)
				{
					deepHandles.Add("FoldersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Folders>) DataRepository.FoldersProvider.DeepLoad,
						new object[] { transactionManager, entity.FoldersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteCustomMappingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteCustomMapping>|SiteCustomMappingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteCustomMappingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteCustomMappingCollection = DataRepository.SiteCustomMappingProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteCustomMappingCollection.Count > 0)
				{
					deepHandles.Add("SiteCustomMappingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteCustomMapping>) DataRepository.SiteCustomMappingProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteCustomMappingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProfessionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Profession>|ProfessionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProfessionCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProfessionCollection = DataRepository.ProfessionProvider.GetByReferredSiteId(transactionManager, entity.SiteId);

				if (deep && entity.ProfessionCollection.Count > 0)
				{
					deepHandles.Add("ProfessionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Profession>) DataRepository.ProfessionProvider.DeepLoad,
						new object[] { transactionManager, entity.ProfessionCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AdminUsersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AdminUsers>|AdminUsersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AdminUsersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AdminUsersCollection = DataRepository.AdminUsersProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.AdminUsersCollection.Count > 0)
				{
					deepHandles.Add("AdminUsersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AdminUsers>) DataRepository.AdminUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AdminUsersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobAlertsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobAlerts>|JobAlertsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobAlertsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobAlertsCollection = DataRepository.JobAlertsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobAlertsCollection.Count > 0)
				{
					deepHandles.Add("JobAlertsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobAlerts>) DataRepository.JobAlertsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobAlertsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobApplicationTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplicationType>|JobApplicationTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationTypeCollection = DataRepository.JobApplicationTypeProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobApplicationTypeCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplicationType>) DataRepository.JobApplicationTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomWidgetCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomWidget>|CustomWidgetCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomWidgetCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomWidgetCollection = DataRepository.CustomWidgetProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.CustomWidgetCollection.Count > 0)
				{
					deepHandles.Add("CustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomWidget>) DataRepository.CustomWidgetProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomWidgetCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteMappingsCollectionGetBySiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteMappings>|SiteMappingsCollectionGetBySiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteMappingsCollectionGetBySiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteMappingsCollectionGetBySiteId = DataRepository.SiteMappingsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteMappingsCollectionGetBySiteId.Count > 0)
				{
					deepHandles.Add("SiteMappingsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteMappings>) DataRepository.SiteMappingsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteMappingsCollectionGetBySiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteWebPartsCollectionGetBySiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWebPartsCollectionGetBySiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWebPartsCollectionGetBySiteId = DataRepository.SiteWebPartsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteWebPartsCollectionGetBySiteId.Count > 0)
				{
					deepHandles.Add("SiteWebPartsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWebParts>) DataRepository.SiteWebPartsProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteRoles>|SiteRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteRolesCollection = DataRepository.SiteRolesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteRolesCollection.Count > 0)
				{
					deepHandles.Add("SiteRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteRoles>) DataRepository.SiteRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteRolesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomPaymentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomPayment>|CustomPaymentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomPaymentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomPaymentCollection = DataRepository.CustomPaymentProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.CustomPaymentCollection.Count > 0)
				{
					deepHandles.Add("CustomPaymentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomPayment>) DataRepository.CustomPaymentProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomPaymentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region IntegrationsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Integrations>|IntegrationsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IntegrationsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.IntegrationsCollection = DataRepository.IntegrationsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.IntegrationsCollection.Count > 0)
				{
					deepHandles.Add("IntegrationsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Integrations>) DataRepository.IntegrationsProvider.DeepLoad,
						new object[] { transactionManager, entity.IntegrationsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EnquiriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Enquiries>|EnquiriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EnquiriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EnquiriesCollection = DataRepository.EnquiriesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.EnquiriesCollection.Count > 0)
				{
					deepHandles.Add("EnquiriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Enquiries>) DataRepository.EnquiriesProvider.DeepLoad,
						new object[] { transactionManager, entity.EnquiriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteAreaCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteArea>|SiteAreaCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteAreaCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteAreaCollection = DataRepository.SiteAreaProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteAreaCollection.Count > 0)
				{
					deepHandles.Add("SiteAreaCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteArea>) DataRepository.SiteAreaProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteAreaCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteResourcesCollectionGetBySiteId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteResources>|SiteResourcesCollectionGetBySiteId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteResourcesCollectionGetBySiteId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteResourcesCollectionGetBySiteId = DataRepository.SiteResourcesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteResourcesCollectionGetBySiteId.Count > 0)
				{
					deepHandles.Add("SiteResourcesCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteResources>) DataRepository.SiteResourcesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteResourcesCollectionGetBySiteId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region NewsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<News>|NewsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'NewsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.NewsCollection = DataRepository.NewsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.NewsCollection.Count > 0)
				{
					deepHandles.Add("NewsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<News>) DataRepository.NewsProvider.DeepLoad,
						new object[] { transactionManager, entity.NewsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteCurrenciesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteCurrencies>|SiteCurrenciesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteCurrenciesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteCurrenciesCollection = DataRepository.SiteCurrenciesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteCurrenciesCollection.Count > 0)
				{
					deepHandles.Add("SiteCurrenciesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteCurrencies>) DataRepository.SiteCurrenciesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteCurrenciesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteWorkTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteWorkType>|SiteWorkTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteWorkTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteWorkTypeCollection = DataRepository.SiteWorkTypeProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteWorkTypeCollection.Count > 0)
				{
					deepHandles.Add("SiteWorkTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteWorkType>) DataRepository.SiteWorkTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteWorkTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DynamicContentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DynamicContent>|DynamicContentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicContentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DynamicContentCollection = DataRepository.DynamicContentProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.DynamicContentCollection.Count > 0)
				{
					deepHandles.Add("DynamicContentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DynamicContent>) DataRepository.DynamicContentProvider.DeepLoad,
						new object[] { transactionManager, entity.DynamicContentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobItemsTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobItemsType>|JobItemsTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobItemsTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobItemsTypeCollection = DataRepository.JobItemsTypeProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobItemsTypeCollection.Count > 0)
				{
					deepHandles.Add("JobItemsTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobItemsType>) DataRepository.JobItemsTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.JobItemsTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteSalaryTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteSalaryType>|SiteSalaryTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteSalaryTypeCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteSalaryTypeCollection = DataRepository.SiteSalaryTypeProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteSalaryTypeCollection.Count > 0)
				{
					deepHandles.Add("SiteSalaryTypeCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteSalaryType>) DataRepository.SiteSalaryTypeProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteSalaryTypeCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ScreeningQuestionsTemplatesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ScreeningQuestionsTemplates>|ScreeningQuestionsTemplatesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ScreeningQuestionsTemplatesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ScreeningQuestionsTemplatesCollection = DataRepository.ScreeningQuestionsTemplatesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.ScreeningQuestionsTemplatesCollection.Count > 0)
				{
					deepHandles.Add("ScreeningQuestionsTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ScreeningQuestionsTemplates>) DataRepository.ScreeningQuestionsTemplatesProvider.DeepLoad,
						new object[] { transactionManager, entity.ScreeningQuestionsTemplatesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobsArchiveCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsArchive>|JobsArchiveCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsArchiveCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsArchiveCollection = DataRepository.JobsArchiveProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.JobsArchiveCollection.Count > 0)
				{
					deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsArchive>) DataRepository.JobsArchiveProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsArchiveCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SiteLanguagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SiteLanguages>|SiteLanguagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SiteLanguagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SiteLanguagesCollection = DataRepository.SiteLanguagesProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.SiteLanguagesCollection.Count > 0)
				{
					deepHandles.Add("SiteLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteLanguages>) DataRepository.SiteLanguagesProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteLanguagesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomWidgetCssSelectorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomWidgetCssSelector>|CustomWidgetCssSelectorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomWidgetCssSelectorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomWidgetCssSelectorCollection = DataRepository.CustomWidgetCssSelectorProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.CustomWidgetCssSelectorCollection.Count > 0)
				{
					deepHandles.Add("CustomWidgetCssSelectorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomWidgetCssSelector>) DataRepository.CustomWidgetCssSelectorProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomWidgetCssSelectorCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EducationsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Educations>|EducationsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EducationsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EducationsCollection = DataRepository.EducationsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.EducationsCollection.Count > 0)
				{
					deepHandles.Add("EducationsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Educations>) DataRepository.EducationsProvider.DeepLoad,
						new object[] { transactionManager, entity.EducationsCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.GlobalSettingsCollection = DataRepository.GlobalSettingsProvider.GetBySiteId(transactionManager, entity.SiteId);

				if (deep && entity.GlobalSettingsCollection.Count > 0)
				{
					deepHandles.Add("GlobalSettingsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<GlobalSettings>) DataRepository.GlobalSettingsProvider.DeepLoad,
						new object[] { transactionManager, entity.GlobalSettingsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Sites object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Sites instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Sites Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Sites entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<AvailableStatus>
				if (CanDeepSave(entity.AvailableStatusCollection, "List<AvailableStatus>|AvailableStatusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AvailableStatus child in entity.AvailableStatusCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.AvailableStatusCollection.Count > 0 || entity.AvailableStatusCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AvailableStatusProvider.Save(transactionManager, entity.AvailableStatusCollection);
						
						deepHandles.Add("AvailableStatusCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AvailableStatus >) DataRepository.AvailableStatusProvider.DeepSave,
							new object[] { transactionManager, entity.AvailableStatusCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobApplication>
				if (CanDeepSave(entity.JobApplicationCollection, "List<JobApplication>|JobApplicationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplication child in entity.JobApplicationCollection)
					{
						if(child.SiteIdReferralSource != null)
						{
							child.SiteIdReferral = child.SiteIdReferralSource.SiteId;
						}
						else
						{
							child.SiteIdReferral = entity.SiteId;
						}

					}

					if (entity.JobApplicationCollection.Count > 0 || entity.JobApplicationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationProvider.Save(transactionManager, entity.JobApplicationCollection);
						
						deepHandles.Add("JobApplicationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplication >) DataRepository.JobApplicationProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobViews>
				if (CanDeepSave(entity.JobViewsCollection, "List<JobViews>|JobViewsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobViews child in entity.JobViewsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobViewsCollection.Count > 0 || entity.JobViewsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobViewsProvider.Save(transactionManager, entity.JobViewsCollection);
						
						deepHandles.Add("JobViewsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobViews >) DataRepository.JobViewsProvider.DeepSave,
							new object[] { transactionManager, entity.JobViewsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<IntegrationMappings>
				if (CanDeepSave(entity.IntegrationMappingsCollection, "List<IntegrationMappings>|IntegrationMappingsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(IntegrationMappings child in entity.IntegrationMappingsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.IntegrationMappingsCollection.Count > 0 || entity.IntegrationMappingsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IntegrationMappingsProvider.Save(transactionManager, entity.IntegrationMappingsCollection);
						
						deepHandles.Add("IntegrationMappingsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< IntegrationMappings >) DataRepository.IntegrationMappingsProvider.DeepSave,
							new object[] { transactionManager, entity.IntegrationMappingsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollectionGetBySiteId, "List<SiteResources>|SiteResourcesCollectionGetBySiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollectionGetBySiteId)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteResourcesCollectionGetBySiteId.Count > 0 || entity.SiteResourcesCollectionGetBySiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollectionGetBySiteId);
						
						deepHandles.Add("SiteResourcesCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollectionGetBySiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmailTemplates>
				if (CanDeepSave(entity.EmailTemplatesCollection, "List<EmailTemplates>|EmailTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmailTemplates child in entity.EmailTemplatesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.EmailTemplatesCollection.Count > 0 || entity.EmailTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmailTemplatesProvider.Save(transactionManager, entity.EmailTemplatesCollection);
						
						deepHandles.Add("EmailTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmailTemplates >) DataRepository.EmailTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.EmailTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Members>
				if (CanDeepSave(entity.MembersCollection, "List<Members>|MembersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Members child in entity.MembersCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
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
				
	
			#region List<Jobs>
				if (CanDeepSave(entity.JobsCollection, "List<Jobs>|JobsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Jobs child in entity.JobsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
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
				
	
			#region List<DynamicPageFiles>
				if (CanDeepSave(entity.DynamicPageFilesCollection, "List<DynamicPageFiles>|DynamicPageFilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageFiles child in entity.DynamicPageFilesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.DynamicPageFilesCollection.Count > 0 || entity.DynamicPageFilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageFilesProvider.Save(transactionManager, entity.DynamicPageFilesCollection);
						
						deepHandles.Add("DynamicPageFilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageFiles >) DataRepository.DynamicPageFilesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageFilesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteMappings>
				if (CanDeepSave(entity.SiteMappingsCollectionGetByMasterSiteId, "List<SiteMappings>|SiteMappingsCollectionGetByMasterSiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteMappings child in entity.SiteMappingsCollectionGetByMasterSiteId)
					{
						if(child.MasterSiteIdSource != null)
						{
							child.MasterSiteId = child.MasterSiteIdSource.SiteId;
						}
						else
						{
							child.MasterSiteId = entity.SiteId;
						}

					}

					if (entity.SiteMappingsCollectionGetByMasterSiteId.Count > 0 || entity.SiteMappingsCollectionGetByMasterSiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteMappingsProvider.Save(transactionManager, entity.SiteMappingsCollectionGetByMasterSiteId);
						
						deepHandles.Add("SiteMappingsCollectionGetByMasterSiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteMappings >) DataRepository.SiteMappingsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteMappingsCollectionGetByMasterSiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteWebParts>
				if (CanDeepSave(entity.SiteWebPartsCollectionGetBySiteId, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWebParts child in entity.SiteWebPartsCollectionGetBySiteId)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteWebPartsCollectionGetBySiteId.Count > 0 || entity.SiteWebPartsCollectionGetBySiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWebPartsProvider.Save(transactionManager, entity.SiteWebPartsCollectionGetBySiteId);
						
						deepHandles.Add("SiteWebPartsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWebParts >) DataRepository.SiteWebPartsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobCustomXml>
				if (CanDeepSave(entity.JobCustomXmlCollection, "List<JobCustomXml>|JobCustomXmlCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobCustomXml child in entity.JobCustomXmlCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobCustomXmlCollection.Count > 0 || entity.JobCustomXmlCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobCustomXmlProvider.Save(transactionManager, entity.JobCustomXmlCollection);
						
						deepHandles.Add("JobCustomXmlCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobCustomXml >) DataRepository.JobCustomXmlProvider.DeepSave,
							new object[] { transactionManager, entity.JobCustomXmlCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPageWebPartTemplates>
				if (CanDeepSave(entity.DynamicPageWebPartTemplatesCollection, "List<DynamicPageWebPartTemplates>|DynamicPageWebPartTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPageWebPartTemplates child in entity.DynamicPageWebPartTemplatesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.DynamicPageWebPartTemplatesCollection.Count > 0 || entity.DynamicPageWebPartTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPageWebPartTemplatesProvider.Save(transactionManager, entity.DynamicPageWebPartTemplatesCollection);
						
						deepHandles.Add("DynamicPageWebPartTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPageWebPartTemplates >) DataRepository.DynamicPageWebPartTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPageWebPartTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicPages>
				if (CanDeepSave(entity.DynamicPagesCollection, "List<DynamicPages>|DynamicPagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicPages child in entity.DynamicPagesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.DynamicPagesCollection.Count > 0 || entity.DynamicPagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPagesCollection);
						
						deepHandles.Add("DynamicPagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicPages >) DataRepository.DynamicPagesProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicPagesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<NewsCategories>
				if (CanDeepSave(entity.NewsCategoriesCollection, "List<NewsCategories>|NewsCategoriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(NewsCategories child in entity.NewsCategoriesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.NewsCategoriesCollection.Count > 0 || entity.NewsCategoriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NewsCategoriesProvider.Save(transactionManager, entity.NewsCategoriesCollection);
						
						deepHandles.Add("NewsCategoriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< NewsCategories >) DataRepository.NewsCategoriesProvider.DeepSave,
							new object[] { transactionManager, entity.NewsCategoriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteAdvertiserFilter>
				if (CanDeepSave(entity.SiteAdvertiserFilterCollection, "List<SiteAdvertiserFilter>|SiteAdvertiserFilterCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteAdvertiserFilter child in entity.SiteAdvertiserFilterCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteAdvertiserFilterCollection.Count > 0 || entity.SiteAdvertiserFilterCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteAdvertiserFilterProvider.Save(transactionManager, entity.SiteAdvertiserFilterCollection);
						
						deepHandles.Add("SiteAdvertiserFilterCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteAdvertiserFilter >) DataRepository.SiteAdvertiserFilterProvider.DeepSave,
							new object[] { transactionManager, entity.SiteAdvertiserFilterCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberMemberships>
				if (CanDeepSave(entity.MemberMembershipsCollection, "List<MemberMemberships>|MemberMembershipsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberMemberships child in entity.MemberMembershipsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.MemberMembershipsCollection.Count > 0 || entity.MemberMembershipsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberMembershipsProvider.Save(transactionManager, entity.MemberMembershipsCollection);
						
						deepHandles.Add("MemberMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberMemberships >) DataRepository.MemberMembershipsProvider.DeepSave,
							new object[] { transactionManager, entity.MemberMembershipsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobTemplates>
				if (CanDeepSave(entity.JobTemplatesCollection, "List<JobTemplates>|JobTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobTemplates child in entity.JobTemplatesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobTemplatesCollection.Count > 0 || entity.JobTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobTemplatesProvider.Save(transactionManager, entity.JobTemplatesCollection);
						
						deepHandles.Add("JobTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobTemplates >) DataRepository.JobTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.JobTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteCountries>
				if (CanDeepSave(entity.SiteCountriesCollection, "List<SiteCountries>|SiteCountriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteCountries child in entity.SiteCountriesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteCountriesCollection.Count > 0 || entity.SiteCountriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteCountriesProvider.Save(transactionManager, entity.SiteCountriesCollection);
						
						deepHandles.Add("SiteCountriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteCountries >) DataRepository.SiteCountriesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteCountriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<WebServiceLog>
				if (CanDeepSave(entity.WebServiceLogCollection, "List<WebServiceLog>|WebServiceLogCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WebServiceLog child in entity.WebServiceLogCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.WebServiceLogCollection.Count > 0 || entity.WebServiceLogCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WebServiceLogProvider.Save(transactionManager, entity.WebServiceLogCollection);
						
						deepHandles.Add("WebServiceLogCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WebServiceLog >) DataRepository.WebServiceLogProvider.DeepSave,
							new object[] { transactionManager, entity.WebServiceLogCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteLocation>
				if (CanDeepSave(entity.SiteLocationCollection, "List<SiteLocation>|SiteLocationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteLocation child in entity.SiteLocationCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteLocationCollection.Count > 0 || entity.SiteLocationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteLocationProvider.Save(transactionManager, entity.SiteLocationCollection);
						
						deepHandles.Add("SiteLocationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteLocation >) DataRepository.SiteLocationProvider.DeepSave,
							new object[] { transactionManager, entity.SiteLocationCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteProfession>
				if (CanDeepSave(entity.SiteProfessionCollection, "List<SiteProfession>|SiteProfessionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteProfession child in entity.SiteProfessionCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteProfessionCollection.Count > 0 || entity.SiteProfessionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteProfessionProvider.Save(transactionManager, entity.SiteProfessionCollection);
						
						deepHandles.Add("SiteProfessionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteProfession >) DataRepository.SiteProfessionProvider.DeepSave,
							new object[] { transactionManager, entity.SiteProfessionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberWizard>
				if (CanDeepSave(entity.MemberWizardCollection, "List<MemberWizard>|MemberWizardCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberWizard child in entity.MemberWizardCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.MemberWizardCollection.Count > 0 || entity.MemberWizardCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberWizardProvider.Save(transactionManager, entity.MemberWizardCollection);
						
						deepHandles.Add("MemberWizardCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberWizard >) DataRepository.MemberWizardProvider.DeepSave,
							new object[] { transactionManager, entity.MemberWizardCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Industry>
				if (CanDeepSave(entity.IndustryCollection, "List<Industry>|IndustryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Industry child in entity.IndustryCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.IndustryCollection.Count > 0 || entity.IndustryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IndustryProvider.Save(transactionManager, entity.IndustryCollection);
						
						deepHandles.Add("IndustryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Industry >) DataRepository.IndustryProvider.DeepSave,
							new object[] { transactionManager, entity.IndustryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Consultants>
				if (CanDeepSave(entity.ConsultantsCollection, "List<Consultants>|ConsultantsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Consultants child in entity.ConsultantsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.ConsultantsCollection.Count > 0 || entity.ConsultantsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ConsultantsProvider.Save(transactionManager, entity.ConsultantsCollection);
						
						deepHandles.Add("ConsultantsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Consultants >) DataRepository.ConsultantsProvider.DeepSave,
							new object[] { transactionManager, entity.ConsultantsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Files>
				if (CanDeepSave(entity.FilesCollection, "List<Files>|FilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Files child in entity.FilesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.FilesCollection.Count > 0 || entity.FilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FilesProvider.Save(transactionManager, entity.FilesCollection);
						
						deepHandles.Add("FilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Files >) DataRepository.FilesProvider.DeepSave,
							new object[] { transactionManager, entity.FilesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteResourcesXml>
				if (CanDeepSave(entity.SiteResourcesXmlCollection, "List<SiteResourcesXml>|SiteResourcesXmlCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResourcesXml child in entity.SiteResourcesXmlCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteResourcesXmlCollection.Count > 0 || entity.SiteResourcesXmlCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesXmlProvider.Save(transactionManager, entity.SiteResourcesXmlCollection);
						
						deepHandles.Add("SiteResourcesXmlCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResourcesXml >) DataRepository.SiteResourcesXmlProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesXmlCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Advertisers>
				if (CanDeepSave(entity.AdvertisersCollection, "List<Advertisers>|AdvertisersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Advertisers child in entity.AdvertisersCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.AdvertisersCollection.Count > 0 || entity.AdvertisersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdvertisersProvider.Save(transactionManager, entity.AdvertisersCollection);
						
						deepHandles.Add("AdvertisersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Advertisers >) DataRepository.AdvertisersProvider.DeepSave,
							new object[] { transactionManager, entity.AdvertisersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberStatus>
				if (CanDeepSave(entity.MemberStatusCollection, "List<MemberStatus>|MemberStatusCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberStatus child in entity.MemberStatusCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.MemberStatusCollection.Count > 0 || entity.MemberStatusCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberStatusProvider.Save(transactionManager, entity.MemberStatusCollection);
						
						deepHandles.Add("MemberStatusCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberStatus >) DataRepository.MemberStatusProvider.DeepSave,
							new object[] { transactionManager, entity.MemberStatusCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<WidgetContainers>
				if (CanDeepSave(entity.WidgetContainersCollection, "List<WidgetContainers>|WidgetContainersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WidgetContainers child in entity.WidgetContainersCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.WidgetContainersCollection.Count > 0 || entity.WidgetContainersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.WidgetContainersProvider.Save(transactionManager, entity.WidgetContainersCollection);
						
						deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< WidgetContainers >) DataRepository.WidgetContainersProvider.DeepSave,
							new object[] { transactionManager, entity.WidgetContainersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Folders>
				if (CanDeepSave(entity.FoldersCollection, "List<Folders>|FoldersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Folders child in entity.FoldersCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.FoldersCollection.Count > 0 || entity.FoldersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.FoldersProvider.Save(transactionManager, entity.FoldersCollection);
						
						deepHandles.Add("FoldersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Folders >) DataRepository.FoldersProvider.DeepSave,
							new object[] { transactionManager, entity.FoldersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteCustomMapping>
				if (CanDeepSave(entity.SiteCustomMappingCollection, "List<SiteCustomMapping>|SiteCustomMappingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteCustomMapping child in entity.SiteCustomMappingCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteCustomMappingCollection.Count > 0 || entity.SiteCustomMappingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteCustomMappingProvider.Save(transactionManager, entity.SiteCustomMappingCollection);
						
						deepHandles.Add("SiteCustomMappingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteCustomMapping >) DataRepository.SiteCustomMappingProvider.DeepSave,
							new object[] { transactionManager, entity.SiteCustomMappingCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Profession>
				if (CanDeepSave(entity.ProfessionCollection, "List<Profession>|ProfessionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Profession child in entity.ProfessionCollection)
					{
						if(child.ReferredSiteIdSource != null)
						{
							child.ReferredSiteId = child.ReferredSiteIdSource.SiteId;
						}
						else
						{
							child.ReferredSiteId = entity.SiteId;
						}

					}

					if (entity.ProfessionCollection.Count > 0 || entity.ProfessionCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProfessionProvider.Save(transactionManager, entity.ProfessionCollection);
						
						deepHandles.Add("ProfessionCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Profession >) DataRepository.ProfessionProvider.DeepSave,
							new object[] { transactionManager, entity.ProfessionCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AdminUsers>
				if (CanDeepSave(entity.AdminUsersCollection, "List<AdminUsers>|AdminUsersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AdminUsers child in entity.AdminUsersCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.AdminUsersCollection.Count > 0 || entity.AdminUsersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AdminUsersProvider.Save(transactionManager, entity.AdminUsersCollection);
						
						deepHandles.Add("AdminUsersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AdminUsers >) DataRepository.AdminUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AdminUsersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobAlerts>
				if (CanDeepSave(entity.JobAlertsCollection, "List<JobAlerts>|JobAlertsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobAlerts child in entity.JobAlertsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobAlertsCollection.Count > 0 || entity.JobAlertsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobAlertsProvider.Save(transactionManager, entity.JobAlertsCollection);
						
						deepHandles.Add("JobAlertsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobAlerts >) DataRepository.JobAlertsProvider.DeepSave,
							new object[] { transactionManager, entity.JobAlertsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobApplicationType>
				if (CanDeepSave(entity.JobApplicationTypeCollection, "List<JobApplicationType>|JobApplicationTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplicationType child in entity.JobApplicationTypeCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobApplicationTypeCollection.Count > 0 || entity.JobApplicationTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationTypeProvider.Save(transactionManager, entity.JobApplicationTypeCollection);
						
						deepHandles.Add("JobApplicationTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplicationType >) DataRepository.JobApplicationTypeProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomWidget>
				if (CanDeepSave(entity.CustomWidgetCollection, "List<CustomWidget>|CustomWidgetCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomWidget child in entity.CustomWidgetCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.CustomWidgetCollection.Count > 0 || entity.CustomWidgetCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomWidgetProvider.Save(transactionManager, entity.CustomWidgetCollection);
						
						deepHandles.Add("CustomWidgetCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomWidget >) DataRepository.CustomWidgetProvider.DeepSave,
							new object[] { transactionManager, entity.CustomWidgetCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteMappings>
				if (CanDeepSave(entity.SiteMappingsCollectionGetBySiteId, "List<SiteMappings>|SiteMappingsCollectionGetBySiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteMappings child in entity.SiteMappingsCollectionGetBySiteId)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteMappingsCollectionGetBySiteId.Count > 0 || entity.SiteMappingsCollectionGetBySiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteMappingsProvider.Save(transactionManager, entity.SiteMappingsCollectionGetBySiteId);
						
						deepHandles.Add("SiteMappingsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteMappings >) DataRepository.SiteMappingsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteMappingsCollectionGetBySiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteWebParts>
				if (CanDeepSave(entity.SiteWebPartsCollectionGetBySiteId, "List<SiteWebParts>|SiteWebPartsCollectionGetBySiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWebParts child in entity.SiteWebPartsCollectionGetBySiteId)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteWebPartsCollectionGetBySiteId.Count > 0 || entity.SiteWebPartsCollectionGetBySiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWebPartsProvider.Save(transactionManager, entity.SiteWebPartsCollectionGetBySiteId);
						
						deepHandles.Add("SiteWebPartsCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWebParts >) DataRepository.SiteWebPartsProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWebPartsCollectionGetBySiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteRoles>
				if (CanDeepSave(entity.SiteRolesCollection, "List<SiteRoles>|SiteRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteRoles child in entity.SiteRolesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteRolesCollection.Count > 0 || entity.SiteRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteRolesProvider.Save(transactionManager, entity.SiteRolesCollection);
						
						deepHandles.Add("SiteRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteRoles >) DataRepository.SiteRolesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteRolesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomPayment>
				if (CanDeepSave(entity.CustomPaymentCollection, "List<CustomPayment>|CustomPaymentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomPayment child in entity.CustomPaymentCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.CustomPaymentCollection.Count > 0 || entity.CustomPaymentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomPaymentProvider.Save(transactionManager, entity.CustomPaymentCollection);
						
						deepHandles.Add("CustomPaymentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomPayment >) DataRepository.CustomPaymentProvider.DeepSave,
							new object[] { transactionManager, entity.CustomPaymentCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Integrations>
				if (CanDeepSave(entity.IntegrationsCollection, "List<Integrations>|IntegrationsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Integrations child in entity.IntegrationsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.IntegrationsCollection.Count > 0 || entity.IntegrationsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.IntegrationsProvider.Save(transactionManager, entity.IntegrationsCollection);
						
						deepHandles.Add("IntegrationsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Integrations >) DataRepository.IntegrationsProvider.DeepSave,
							new object[] { transactionManager, entity.IntegrationsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Enquiries>
				if (CanDeepSave(entity.EnquiriesCollection, "List<Enquiries>|EnquiriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Enquiries child in entity.EnquiriesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.EnquiriesCollection.Count > 0 || entity.EnquiriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EnquiriesProvider.Save(transactionManager, entity.EnquiriesCollection);
						
						deepHandles.Add("EnquiriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Enquiries >) DataRepository.EnquiriesProvider.DeepSave,
							new object[] { transactionManager, entity.EnquiriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteArea>
				if (CanDeepSave(entity.SiteAreaCollection, "List<SiteArea>|SiteAreaCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteArea child in entity.SiteAreaCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteAreaCollection.Count > 0 || entity.SiteAreaCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteAreaProvider.Save(transactionManager, entity.SiteAreaCollection);
						
						deepHandles.Add("SiteAreaCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteArea >) DataRepository.SiteAreaProvider.DeepSave,
							new object[] { transactionManager, entity.SiteAreaCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteResources>
				if (CanDeepSave(entity.SiteResourcesCollectionGetBySiteId, "List<SiteResources>|SiteResourcesCollectionGetBySiteId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteResources child in entity.SiteResourcesCollectionGetBySiteId)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteResourcesCollectionGetBySiteId.Count > 0 || entity.SiteResourcesCollectionGetBySiteId.DeletedItems.Count > 0)
					{
						//DataRepository.SiteResourcesProvider.Save(transactionManager, entity.SiteResourcesCollectionGetBySiteId);
						
						deepHandles.Add("SiteResourcesCollectionGetBySiteId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteResources >) DataRepository.SiteResourcesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteResourcesCollectionGetBySiteId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<News>
				if (CanDeepSave(entity.NewsCollection, "List<News>|NewsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(News child in entity.NewsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.NewsCollection.Count > 0 || entity.NewsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.NewsProvider.Save(transactionManager, entity.NewsCollection);
						
						deepHandles.Add("NewsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< News >) DataRepository.NewsProvider.DeepSave,
							new object[] { transactionManager, entity.NewsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteCurrencies>
				if (CanDeepSave(entity.SiteCurrenciesCollection, "List<SiteCurrencies>|SiteCurrenciesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteCurrencies child in entity.SiteCurrenciesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteCurrenciesCollection.Count > 0 || entity.SiteCurrenciesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteCurrenciesProvider.Save(transactionManager, entity.SiteCurrenciesCollection);
						
						deepHandles.Add("SiteCurrenciesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteCurrencies >) DataRepository.SiteCurrenciesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteCurrenciesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteWorkType>
				if (CanDeepSave(entity.SiteWorkTypeCollection, "List<SiteWorkType>|SiteWorkTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteWorkType child in entity.SiteWorkTypeCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteWorkTypeCollection.Count > 0 || entity.SiteWorkTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteWorkTypeProvider.Save(transactionManager, entity.SiteWorkTypeCollection);
						
						deepHandles.Add("SiteWorkTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteWorkType >) DataRepository.SiteWorkTypeProvider.DeepSave,
							new object[] { transactionManager, entity.SiteWorkTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DynamicContent>
				if (CanDeepSave(entity.DynamicContentCollection, "List<DynamicContent>|DynamicContentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DynamicContent child in entity.DynamicContentCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.DynamicContentCollection.Count > 0 || entity.DynamicContentCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DynamicContentProvider.Save(transactionManager, entity.DynamicContentCollection);
						
						deepHandles.Add("DynamicContentCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DynamicContent >) DataRepository.DynamicContentProvider.DeepSave,
							new object[] { transactionManager, entity.DynamicContentCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobItemsType>
				if (CanDeepSave(entity.JobItemsTypeCollection, "List<JobItemsType>|JobItemsTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobItemsType child in entity.JobItemsTypeCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobItemsTypeCollection.Count > 0 || entity.JobItemsTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobItemsTypeProvider.Save(transactionManager, entity.JobItemsTypeCollection);
						
						deepHandles.Add("JobItemsTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobItemsType >) DataRepository.JobItemsTypeProvider.DeepSave,
							new object[] { transactionManager, entity.JobItemsTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteSalaryType>
				if (CanDeepSave(entity.SiteSalaryTypeCollection, "List<SiteSalaryType>|SiteSalaryTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteSalaryType child in entity.SiteSalaryTypeCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteSalaryTypeCollection.Count > 0 || entity.SiteSalaryTypeCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteSalaryTypeProvider.Save(transactionManager, entity.SiteSalaryTypeCollection);
						
						deepHandles.Add("SiteSalaryTypeCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteSalaryType >) DataRepository.SiteSalaryTypeProvider.DeepSave,
							new object[] { transactionManager, entity.SiteSalaryTypeCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ScreeningQuestionsTemplates>
				if (CanDeepSave(entity.ScreeningQuestionsTemplatesCollection, "List<ScreeningQuestionsTemplates>|ScreeningQuestionsTemplatesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ScreeningQuestionsTemplates child in entity.ScreeningQuestionsTemplatesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.ScreeningQuestionsTemplatesCollection.Count > 0 || entity.ScreeningQuestionsTemplatesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ScreeningQuestionsTemplatesProvider.Save(transactionManager, entity.ScreeningQuestionsTemplatesCollection);
						
						deepHandles.Add("ScreeningQuestionsTemplatesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ScreeningQuestionsTemplates >) DataRepository.ScreeningQuestionsTemplatesProvider.DeepSave,
							new object[] { transactionManager, entity.ScreeningQuestionsTemplatesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobsArchive>
				if (CanDeepSave(entity.JobsArchiveCollection, "List<JobsArchive>|JobsArchiveCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsArchive child in entity.JobsArchiveCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.JobsArchiveCollection.Count > 0 || entity.JobsArchiveCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsArchiveProvider.Save(transactionManager, entity.JobsArchiveCollection);
						
						deepHandles.Add("JobsArchiveCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsArchive >) DataRepository.JobsArchiveProvider.DeepSave,
							new object[] { transactionManager, entity.JobsArchiveCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SiteLanguages>
				if (CanDeepSave(entity.SiteLanguagesCollection, "List<SiteLanguages>|SiteLanguagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SiteLanguages child in entity.SiteLanguagesCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.SiteLanguagesCollection.Count > 0 || entity.SiteLanguagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SiteLanguagesProvider.Save(transactionManager, entity.SiteLanguagesCollection);
						
						deepHandles.Add("SiteLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SiteLanguages >) DataRepository.SiteLanguagesProvider.DeepSave,
							new object[] { transactionManager, entity.SiteLanguagesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<CustomWidgetCssSelector>
				if (CanDeepSave(entity.CustomWidgetCssSelectorCollection, "List<CustomWidgetCssSelector>|CustomWidgetCssSelectorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomWidgetCssSelector child in entity.CustomWidgetCssSelectorCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.CustomWidgetCssSelectorCollection.Count > 0 || entity.CustomWidgetCssSelectorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomWidgetCssSelectorProvider.Save(transactionManager, entity.CustomWidgetCssSelectorCollection);
						
						deepHandles.Add("CustomWidgetCssSelectorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomWidgetCssSelector >) DataRepository.CustomWidgetCssSelectorProvider.DeepSave,
							new object[] { transactionManager, entity.CustomWidgetCssSelectorCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Educations>
				if (CanDeepSave(entity.EducationsCollection, "List<Educations>|EducationsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Educations child in entity.EducationsCollection)
					{
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
						}

					}

					if (entity.EducationsCollection.Count > 0 || entity.EducationsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EducationsProvider.Save(transactionManager, entity.EducationsCollection);
						
						deepHandles.Add("EducationsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Educations >) DataRepository.EducationsProvider.DeepSave,
							new object[] { transactionManager, entity.EducationsCollection, deepSaveType, childTypes, innerList }
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
						if(child.SiteIdSource != null)
						{
							child.SiteId = child.SiteIdSource.SiteId;
						}
						else
						{
							child.SiteId = entity.SiteId;
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
	
	#region SitesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Sites</c>
	///</summary>
	public enum SitesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AdminUsers</c> at LastModifiedBySource
		///</summary>
		[ChildEntityType(typeof(AdminUsers))]
		AdminUsers,
	
		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for AvailableStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<AvailableStatus>))]
		AvailableStatusCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobApplicationCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplication>))]
		JobApplicationCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobViewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobViews>))]
		JobViewsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for IntegrationMappingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<IntegrationMappings>))]
		IntegrationMappingsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteResourcesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResources>))]
		SiteResourcesCollectionGetBySiteId,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for EmailTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmailTemplates>))]
		EmailTemplatesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for MembersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Members>))]
		MembersCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Jobs>))]
		JobsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for DynamicPageFilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageFiles>))]
		DynamicPageFilesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteMappingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteMappings>))]
		SiteMappingsCollectionGetByMasterSiteId,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteWebPartsCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteWebParts>))]
		SiteWebPartsCollectionGetBySiteId,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobCustomXmlCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobCustomXml>))]
		JobCustomXmlCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for DynamicPageWebPartTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPageWebPartTemplates>))]
		DynamicPageWebPartTemplatesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for DynamicPagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicPages>))]
		DynamicPagesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for NewsCategoriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<NewsCategories>))]
		NewsCategoriesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteAdvertiserFilterCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteAdvertiserFilter>))]
		SiteAdvertiserFilterCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for MemberMembershipsCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberMemberships>))]
		MemberMembershipsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobTemplates>))]
		JobTemplatesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteCountriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteCountries>))]
		SiteCountriesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for WebServiceLogCollection
		///</summary>
		[ChildEntityType(typeof(TList<WebServiceLog>))]
		WebServiceLogCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteLocationCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteLocation>))]
		SiteLocationCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteProfessionCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteProfession>))]
		SiteProfessionCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for MemberWizardCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberWizard>))]
		MemberWizardCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for IndustryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Industry>))]
		IndustryCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for ConsultantsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Consultants>))]
		ConsultantsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for FilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Files>))]
		FilesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteResourcesXmlCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteResourcesXml>))]
		SiteResourcesXmlCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for AdvertisersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Advertisers>))]
		AdvertisersCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for MemberStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberStatus>))]
		MemberStatusCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for WidgetContainersCollection
		///</summary>
		[ChildEntityType(typeof(TList<WidgetContainers>))]
		WidgetContainersCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for FoldersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Folders>))]
		FoldersCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteCustomMappingCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteCustomMapping>))]
		SiteCustomMappingCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for ProfessionCollection
		///</summary>
		[ChildEntityType(typeof(TList<Profession>))]
		ProfessionCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for AdminUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AdminUsers>))]
		AdminUsersCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobAlertsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobAlerts>))]
		JobAlertsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobApplicationTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplicationType>))]
		JobApplicationTypeCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for CustomWidgetCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomWidget>))]
		CustomWidgetCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteMappingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteMappings>))]
		SiteMappingsCollectionGetBySiteId,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteRoles>))]
		SiteRolesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for CustomPaymentCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomPayment>))]
		CustomPaymentCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for IntegrationsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Integrations>))]
		IntegrationsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for EnquiriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Enquiries>))]
		EnquiriesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteAreaCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteArea>))]
		SiteAreaCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for NewsCollection
		///</summary>
		[ChildEntityType(typeof(TList<News>))]
		NewsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteCurrenciesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteCurrencies>))]
		SiteCurrenciesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteWorkTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteWorkType>))]
		SiteWorkTypeCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for DynamicContentCollection
		///</summary>
		[ChildEntityType(typeof(TList<DynamicContent>))]
		DynamicContentCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobItemsTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobItemsType>))]
		JobItemsTypeCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteSalaryTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteSalaryType>))]
		SiteSalaryTypeCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for ScreeningQuestionsTemplatesCollection
		///</summary>
		[ChildEntityType(typeof(TList<ScreeningQuestionsTemplates>))]
		ScreeningQuestionsTemplatesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for JobsArchiveCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsArchive>))]
		JobsArchiveCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for SiteLanguagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteLanguages>))]
		SiteLanguagesCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for CustomWidgetCssSelectorCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomWidgetCssSelector>))]
		CustomWidgetCssSelectorCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for EducationsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Educations>))]
		EducationsCollection,

		///<summary>
		/// Collection of <c>Sites</c> as OneToMany for GlobalSettingsCollection
		///</summary>
		[ChildEntityType(typeof(TList<GlobalSettings>))]
		GlobalSettingsCollection,
	}
	
	#endregion SitesChildEntityTypes
	
	#region SitesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SitesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesFilterBuilder : SqlFilterBuilder<SitesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesFilterBuilder class.
		/// </summary>
		public SitesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SitesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SitesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SitesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SitesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SitesFilterBuilder
	
	#region SitesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SitesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesParameterBuilder : ParameterizedSqlFilterBuilder<SitesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesParameterBuilder class.
		/// </summary>
		public SitesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SitesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SitesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SitesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SitesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SitesParameterBuilder
	
	#region SitesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SitesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SitesSortBuilder : SqlSortBuilder<SitesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesSqlSortBuilder class.
		/// </summary>
		public SitesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SitesSortBuilder
	
} // end namespace
