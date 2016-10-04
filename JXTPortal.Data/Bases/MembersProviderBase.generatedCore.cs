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
	/// This class is the base class for any <see cref="MembersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MembersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Members, JXTPortal.Entities.MembersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.MembersKey key)
		{
			return Delete(transactionManager, key.MemberId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_memberId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _memberId)
		{
			return Delete(null, _memberId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _memberId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		FK__Members__Country__797309D9 Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByCountryId(System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		FK__Members__Country__797309D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		/// <remarks></remarks>
		public TList<Members> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		FK__Members__Country__797309D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		fkMembersCountry797309d9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByCountryId(System.Int32 _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		fkMembersCountry797309d9 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByCountryId(System.Int32 _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Country__797309D9 key.
		///		FK__Members__Country__797309D9 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public abstract TList<Members> GetByCountryId(TransactionManager transactionManager, System.Int32 _countryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		FK__Members__Educati__2215F810 Description: 
		/// </summary>
		/// <param name="_educationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEducationId(System.Int32? _educationId)
		{
			int count = -1;
			return GetByEducationId(_educationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		FK__Members__Educati__2215F810 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		/// <remarks></remarks>
		public TList<Members> GetByEducationId(TransactionManager transactionManager, System.Int32? _educationId)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		FK__Members__Educati__2215F810 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEducationId(TransactionManager transactionManager, System.Int32? _educationId, int start, int pageLength)
		{
			int count = -1;
			return GetByEducationId(transactionManager, _educationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		fkMembersEducati2215f810 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_educationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEducationId(System.Int32? _educationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEducationId(null, _educationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		fkMembersEducati2215f810 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_educationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEducationId(System.Int32? _educationId, int start, int pageLength,out int count)
		{
			return GetByEducationId(null, _educationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__Educati__2215F810 key.
		///		FK__Members__Educati__2215F810 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_educationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public abstract TList<Members> GetByEducationId(TransactionManager transactionManager, System.Int32? _educationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		FK__Members__EmailFo__7A672E12 Description: 
		/// </summary>
		/// <param name="_emailFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEmailFormat(System.Int32 _emailFormat)
		{
			int count = -1;
			return GetByEmailFormat(_emailFormat, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		FK__Members__EmailFo__7A672E12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		/// <remarks></remarks>
		public TList<Members> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat)
		{
			int count = -1;
			return GetByEmailFormat(transactionManager, _emailFormat, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		FK__Members__EmailFo__7A672E12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailFormat(transactionManager, _emailFormat, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		fkMembersEmailFo7a672e12 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_emailFormat"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEmailFormat(System.Int32 _emailFormat, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmailFormat(null, _emailFormat, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		fkMembersEmailFo7a672e12 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_emailFormat"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetByEmailFormat(System.Int32 _emailFormat, int start, int pageLength,out int count)
		{
			return GetByEmailFormat(null, _emailFormat, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__EmailFo__7A672E12 key.
		///		FK__Members__EmailFo__7A672E12 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_emailFormat"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public abstract TList<Members> GetByEmailFormat(TransactionManager transactionManager, System.Int32 _emailFormat, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		FK__Members__SiteID__0ABD916C Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		FK__Members__SiteID__0ABD916C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		/// <remarks></remarks>
		public TList<Members> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		FK__Members__SiteID__0ABD916C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		fkMembersSiteId0Abd916c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		fkMembersSiteId0Abd916c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public TList<Members> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Members__SiteID__0ABD916C key.
		///		FK__Members__SiteID__0ABD916C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Members objects.</returns>
		public abstract TList<Members> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Members Get(TransactionManager transactionManager, JXTPortal.Entities.MembersKey key, int start, int pageLength)
		{
			return GetByMemberId(transactionManager, key.MemberId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_Members index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdEmailAddress(System.Int32 _siteId, System.String _emailAddress)
		{
			int count = -1;
			return GetBySiteIdEmailAddress(null,_siteId, _emailAddress, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdEmailAddress(System.Int32 _siteId, System.String _emailAddress, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdEmailAddress(null, _siteId, _emailAddress, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdEmailAddress(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailAddress)
		{
			int count = -1;
			return GetBySiteIdEmailAddress(transactionManager, _siteId, _emailAddress, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdEmailAddress(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailAddress, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdEmailAddress(transactionManager, _siteId, _emailAddress, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdEmailAddress(System.Int32 _siteId, System.String _emailAddress, int start, int pageLength, out int count)
		{
			return GetBySiteIdEmailAddress(null, _siteId, _emailAddress, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_emailAddress"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public abstract JXTPortal.Entities.Members GetBySiteIdEmailAddress(TransactionManager transactionManager, System.Int32 _siteId, System.String _emailAddress, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdUsername(System.Int32 _siteId, System.String _username)
		{
			int count = -1;
			return GetBySiteIdUsername(null,_siteId, _username, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdUsername(System.Int32 _siteId, System.String _username, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUsername(null, _siteId, _username, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdUsername(TransactionManager transactionManager, System.Int32 _siteId, System.String _username)
		{
			int count = -1;
			return GetBySiteIdUsername(transactionManager, _siteId, _username, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdUsername(TransactionManager transactionManager, System.Int32 _siteId, System.String _username, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteIdUsername(transactionManager, _siteId, _username, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetBySiteIdUsername(System.Int32 _siteId, System.String _username, int start, int pageLength, out int count)
		{
			return GetBySiteIdUsername(null, _siteId, _username, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Unique_Members_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="_username"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public abstract JXTPortal.Entities.Members GetBySiteIdUsername(TransactionManager transactionManager, System.Int32 _siteId, System.String _username, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetByMemberId(System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(null,_memberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetByMemberId(System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(null, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength)
		{
			int count = -1;
			return GetByMemberId(transactionManager, _memberId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public JXTPortal.Entities.Members GetByMemberId(System.Int32 _memberId, int start, int pageLength, out int count)
		{
			return GetByMemberId(null, _memberId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Members__2A4B4B5E index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_memberId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Members"/> class.</returns>
		public abstract JXTPortal.Entities.Members GetByMemberId(TransactionManager transactionManager, System.Int32 _memberId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Members_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Members_GetPaged' stored procedure. 
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
		///	This method wrap the 'Members_GetPaged' stored procedure. 
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
		///	This method wrap the 'Members_GetPaged' stored procedure. 
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
		///	This method wrap the 'Members_GetPaged' stored procedure. 
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
		
		#region Members_GetByMemberId 
		
		/// <summary>
		///	This method wrap the 'Members_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(System.Int32? memberId)
		{
			return GetByMemberId(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(int start, int pageLength, System.Int32? memberId)
		{
			return GetByMemberId(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByMemberId(TransactionManager transactionManager, System.Int32? memberId)
		{
			return GetByMemberId(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByMemberId' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByMemberId(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region Members_GetBySiteIdEmailAddress 
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdEmailAddress' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailAddress(System.Int32? siteId, System.String emailAddress)
		{
			return GetBySiteIdEmailAddress(null, 0, int.MaxValue , siteId, emailAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdEmailAddress' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailAddress(int start, int pageLength, System.Int32? siteId, System.String emailAddress)
		{
			return GetBySiteIdEmailAddress(null, start, pageLength , siteId, emailAddress);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdEmailAddress' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdEmailAddress(TransactionManager transactionManager, System.Int32? siteId, System.String emailAddress)
		{
			return GetBySiteIdEmailAddress(transactionManager, 0, int.MaxValue , siteId, emailAddress);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdEmailAddress' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdEmailAddress(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String emailAddress);
		
		#endregion
		
		#region Members_Find 
		
		/// <summary>
		///	This method wrap the 'Members_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			return Find(null, start, pageLength , searchUsingOr, memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
				
		/// <summary>
		///	This method wrap the 'Members_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml);
		
		#endregion
		
		#region Members_Update 
		
		/// <summary>
		///	This method wrap the 'Members_Update' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			 Update(null, 0, int.MaxValue , memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Update' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			 Update(null, start, pageLength , memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
				
		/// <summary>
		///	This method wrap the 'Members_Update' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml)
		{
			 Update(transactionManager, 0, int.MaxValue , memberId, siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Update' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml);
		
		#endregion
		
		#region Members_GetBySiteIdUsername 
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdUsername' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUsername(System.Int32? siteId, System.String username)
		{
			return GetBySiteIdUsername(null, 0, int.MaxValue , siteId, username);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdUsername' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUsername(int start, int pageLength, System.Int32? siteId, System.String username)
		{
			return GetBySiteIdUsername(null, start, pageLength , siteId, username);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdUsername' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteIdUsername(TransactionManager transactionManager, System.Int32? siteId, System.String username)
		{
			return GetBySiteIdUsername(transactionManager, 0, int.MaxValue , siteId, username);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteIdUsername' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteIdUsername(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String username);
		
		#endregion
		
		#region Members_GetByCountryId 
		
		/// <summary>
		///	This method wrap the 'Members_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(System.Int32? countryId)
		{
			return GetByCountryId(null, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(int start, int pageLength, System.Int32? countryId)
		{
			return GetByCountryId(null, start, pageLength , countryId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCountryId(TransactionManager transactionManager, System.Int32? countryId)
		{
			return GetByCountryId(transactionManager, 0, int.MaxValue , countryId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByCountryId' stored procedure. 
		/// </summary>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? countryId);
		
		#endregion
		
		#region Members_AdminGetPaged 
		
		/// <summary>
		///	This method wrap the 'Members_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(System.Int32? memberId, System.Int32? siteId, System.String firstName, System.String surname, System.String emailAddress, System.String username, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, 0, int.MaxValue , memberId, siteId, firstName, surname, emailAddress, username, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Members_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(int start, int pageLength, System.Int32? memberId, System.Int32? siteId, System.String firstName, System.String surname, System.String emailAddress, System.String username, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(null, start, pageLength , memberId, siteId, firstName, surname, emailAddress, username, pageSize, pageNumber);
		}
				
		/// <summary>
		///	This method wrap the 'Members_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet AdminGetPaged(TransactionManager transactionManager, System.Int32? memberId, System.Int32? siteId, System.String firstName, System.String surname, System.String emailAddress, System.String username, System.Int32? pageSize, System.Int32? pageNumber)
		{
			return AdminGetPaged(transactionManager, 0, int.MaxValue , memberId, siteId, firstName, surname, emailAddress, username, pageSize, pageNumber);
		}
		
		/// <summary>
		///	This method wrap the 'Members_AdminGetPaged' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageNumber"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet AdminGetPaged(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId, System.Int32? siteId, System.String firstName, System.String surname, System.String emailAddress, System.String username, System.Int32? pageSize, System.Int32? pageNumber);
		
		#endregion
		
		#region Members_Insert 
		
		/// <summary>
		///	This method wrap the 'Members_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml, ref System.Int32? memberId)
		{
			 Insert(null, 0, int.MaxValue , siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml, ref memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml, ref System.Int32? memberId)
		{
			 Insert(null, start, pageLength , siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml, ref memberId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml, ref System.Int32? memberId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, username, password, title, firstName, surname, emailAddress, company, position, homePhone, workPhone, mobilePhone, fax, address1, address2, locationId, areaId, countryId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, subscribed, monthlyUpdate, referringMemberId, lastModifiedDate, valid, emailFormat, lastLogon, dateOfBirth, gender, tags, validated, validateGuid, memberUrlExtension, websiteUrl, availabilityId, availabilityFromDate, mySpaceHeading, mySpaceContent, urlReferrer, requiredPasswordChange, preferredJobTitle, preferredAvailability, preferredAvailabilityType, preferredSalaryFrom, preferredSalaryTo, currentSalaryFrom, currentSalaryTo, lookingFor, experience, skills, reasons, comments, profileType, educationId, searchField, registeredDate, states, suburb, postCode, profilePicture, shortBio, workTypeId, memberships, memberStatusId, linkedInAccessToken, externalMemberId, passportNo, mailingAddress1, mailingAddress2, mailingStates, mailingSuburb, mailingPostCode, mailingCountryId, countryName, mailingCountryName, loginAttempts, lastAttemptDate, status, lastTermsAndConditionsDate, defaultLanguageId, referringSiteId, multiLingualFirstName, multiLingualSurame, secondaryEmail, candidateData, eligibleToWorkIn, referenceUponRequest, preferredLine, videoUrl, profileDataXml, ref memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="username"> A <c>System.String</c> instance.</param>
		/// <param name="password"> A <c>System.String</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="surname"> A <c>System.String</c> instance.</param>
		/// <param name="emailAddress"> A <c>System.String</c> instance.</param>
		/// <param name="company"> A <c>System.String</c> instance.</param>
		/// <param name="position"> A <c>System.String</c> instance.</param>
		/// <param name="homePhone"> A <c>System.String</c> instance.</param>
		/// <param name="workPhone"> A <c>System.String</c> instance.</param>
		/// <param name="mobilePhone"> A <c>System.String</c> instance.</param>
		/// <param name="fax"> A <c>System.String</c> instance.</param>
		/// <param name="address1"> A <c>System.String</c> instance.</param>
		/// <param name="address2"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="subscribed"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="monthlyUpdate"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="referringMemberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastLogon"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateOfBirth"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="gender"> A <c>System.String</c> instance.</param>
		/// <param name="tags"> A <c>System.String</c> instance.</param>
		/// <param name="validated"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="validateGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="memberUrlExtension"> A <c>System.String</c> instance.</param>
		/// <param name="websiteUrl"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="mySpaceHeading"> A <c>System.String</c> instance.</param>
		/// <param name="mySpaceContent"> A <c>System.String</c> instance.</param>
		/// <param name="urlReferrer"> A <c>System.String</c> instance.</param>
		/// <param name="requiredPasswordChange"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredJobTitle"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailability"> A <c>System.String</c> instance.</param>
		/// <param name="preferredAvailabilityType"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="preferredSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryFrom"> A <c>System.String</c> instance.</param>
		/// <param name="currentSalaryTo"> A <c>System.String</c> instance.</param>
		/// <param name="lookingFor"> A <c>System.String</c> instance.</param>
		/// <param name="experience"> A <c>System.String</c> instance.</param>
		/// <param name="skills"> A <c>System.String</c> instance.</param>
		/// <param name="reasons"> A <c>System.String</c> instance.</param>
		/// <param name="comments"> A <c>System.String</c> instance.</param>
		/// <param name="profileType"> A <c>System.String</c> instance.</param>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchField"> A <c>System.String</c> instance.</param>
		/// <param name="registeredDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="states"> A <c>System.String</c> instance.</param>
		/// <param name="suburb"> A <c>System.String</c> instance.</param>
		/// <param name="postCode"> A <c>System.String</c> instance.</param>
		/// <param name="profilePicture"> A <c>System.String</c> instance.</param>
		/// <param name="shortBio"> A <c>System.String</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="memberships"> A <c>System.String</c> instance.</param>
		/// <param name="memberStatusId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="linkedInAccessToken"> A <c>System.String</c> instance.</param>
		/// <param name="externalMemberId"> A <c>System.String</c> instance.</param>
		/// <param name="passportNo"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress1"> A <c>System.String</c> instance.</param>
		/// <param name="mailingAddress2"> A <c>System.String</c> instance.</param>
		/// <param name="mailingStates"> A <c>System.String</c> instance.</param>
		/// <param name="mailingSuburb"> A <c>System.String</c> instance.</param>
		/// <param name="mailingPostCode"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryName"> A <c>System.String</c> instance.</param>
		/// <param name="mailingCountryName"> A <c>System.String</c> instance.</param>
		/// <param name="loginAttempts"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastAttemptDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="status"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastTermsAndConditionsDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="defaultLanguageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="referringSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="multiLingualFirstName"> A <c>System.String</c> instance.</param>
		/// <param name="multiLingualSurame"> A <c>System.String</c> instance.</param>
		/// <param name="secondaryEmail"> A <c>System.String</c> instance.</param>
		/// <param name="candidateData"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="referenceUponRequest"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="preferredLine"> A <c>System.Int32?</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="profileDataXml"> A <c>System.String</c> instance.</param>
			/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String username, System.String password, System.String title, System.String firstName, System.String surname, System.String emailAddress, System.String company, System.String position, System.String homePhone, System.String workPhone, System.String mobilePhone, System.String fax, System.String address1, System.String address2, System.String locationId, System.String areaId, System.Int32? countryId, System.String preferredCategoryId, System.String preferredSubCategoryId, System.Int32? preferredSalaryId, System.Boolean? subscribed, System.Boolean? monthlyUpdate, System.Int32? referringMemberId, System.DateTime? lastModifiedDate, System.Boolean? valid, System.Int32? emailFormat, System.DateTime? lastLogon, System.DateTime? dateOfBirth, System.String gender, System.String tags, System.Boolean? validated, System.Guid? validateGuid, System.String memberUrlExtension, System.String websiteUrl, System.Int32? availabilityId, System.DateTime? availabilityFromDate, System.String mySpaceHeading, System.String mySpaceContent, System.String urlReferrer, System.Boolean? requiredPasswordChange, System.String preferredJobTitle, System.String preferredAvailability, System.Int32? preferredAvailabilityType, System.String preferredSalaryFrom, System.String preferredSalaryTo, System.String currentSalaryFrom, System.String currentSalaryTo, System.String lookingFor, System.String experience, System.String skills, System.String reasons, System.String comments, System.String profileType, System.Int32? educationId, System.String searchField, System.DateTime? registeredDate, System.String states, System.String suburb, System.String postCode, System.String profilePicture, System.String shortBio, System.String workTypeId, System.String memberships, System.Int32? memberStatusId, System.String linkedInAccessToken, System.String externalMemberId, System.String passportNo, System.String mailingAddress1, System.String mailingAddress2, System.String mailingStates, System.String mailingSuburb, System.String mailingPostCode, System.Int32? mailingCountryId, System.String countryName, System.String mailingCountryName, System.Int32? loginAttempts, System.DateTime? lastAttemptDate, System.Int32? status, System.DateTime? lastTermsAndConditionsDate, System.Int32? defaultLanguageId, System.Int32? referringSiteId, System.String multiLingualFirstName, System.String multiLingualSurame, System.String secondaryEmail, System.String candidateData, System.String eligibleToWorkIn, System.Boolean? referenceUponRequest, System.Int32? preferredLine, System.String videoUrl, System.String profileDataXml, ref System.Int32? memberId);
		
		#endregion
		
		#region Members_GetByEducationId 
		
		
		/// <summary>
		///	This method wrap the 'Members_GetByEducationId' stored procedure. 
		/// </summary>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEducationId(int start, int pageLength, System.Int32? educationId)
		{
			return GetByEducationId(null, start, pageLength , educationId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByEducationId' stored procedure. 
		/// </summary>
		/// <param name="educationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByEducationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? educationId);
		
		#endregion
		
		#region Members_Delete 
		
		/// <summary>
		///	This method wrap the 'Members_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? memberId)
		{
			 Delete(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? memberId)
		{
			 Delete(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? memberId)
		{
			 Delete(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_Delete' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region Members_GetByKeyword 
		
		/// <summary>
		///	This method wrap the 'Members_GetByKeyword' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKeyword(System.Int32? siteId, System.String keyword)
		{
			return GetByKeyword(null, 0, int.MaxValue , siteId, keyword);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByKeyword' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKeyword(int start, int pageLength, System.Int32? siteId, System.String keyword)
		{
			return GetByKeyword(null, start, pageLength , siteId, keyword);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetByKeyword' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByKeyword(TransactionManager transactionManager, System.Int32? siteId, System.String keyword)
		{
			return GetByKeyword(transactionManager, 0, int.MaxValue , siteId, keyword);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByKeyword' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByKeyword(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String keyword);
		
		#endregion
		
		#region Members_CustomGetNewValidMembers 
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidMembers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidMembers(System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidMembers(null, 0, int.MaxValue , siteId, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidMembers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidMembers(int start, int pageLength, System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidMembers(null, start, pageLength , siteId, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidMembers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidMembers(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidMembers(transactionManager, 0, int.MaxValue , siteId, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidMembers' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetNewValidMembers(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region Members_Get_List 
		
		/// <summary>
		///	This method wrap the 'Members_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Members_Get_List' stored procedure. 
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
		///	This method wrap the 'Members_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Members_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Members_CustomGetCV 
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetCV' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetCV(System.Int32? memberId)
		{
			return CustomGetCV(null, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetCV' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetCV(int start, int pageLength, System.Int32? memberId)
		{
			return CustomGetCV(null, start, pageLength , memberId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_CustomGetCV' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetCV(TransactionManager transactionManager, System.Int32? memberId)
		{
			return CustomGetCV(transactionManager, 0, int.MaxValue , memberId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetCV' stored procedure. 
		/// </summary>
		/// <param name="memberId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetCV(TransactionManager transactionManager, int start, int pageLength , System.Int32? memberId);
		
		#endregion
		
		#region Members_GetByEmailFormat 
		
		/// <summary>
		///	This method wrap the 'Members_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(System.Int32? emailFormat)
		{
			return GetByEmailFormat(null, 0, int.MaxValue , emailFormat);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(int start, int pageLength, System.Int32? emailFormat)
		{
			return GetByEmailFormat(null, start, pageLength , emailFormat);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByEmailFormat(TransactionManager transactionManager, System.Int32? emailFormat)
		{
			return GetByEmailFormat(transactionManager, 0, int.MaxValue , emailFormat);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetByEmailFormat' stored procedure. 
		/// </summary>
		/// <param name="emailFormat"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByEmailFormat(TransactionManager transactionManager, int start, int pageLength , System.Int32? emailFormat);
		
		#endregion
		
		#region Members_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Members_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Members_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Members_CustomPeopleSearch 
		
		/// <summary>
		///	This method wrap the 'Members_CustomPeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPeopleSearch(System.String keyword, System.Int32? siteId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.String workTypeId, System.String professionId, System.String roleId, System.String countryId, System.String locationId, System.String areaId, System.String eligibleToWorkIn, System.DateTime? availabilityFromDate, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy)
		{
			return CustomPeopleSearch(null, 0, int.MaxValue , keyword, siteId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, eligibleToWorkIn, availabilityFromDate, pageIndex, pageSize, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomPeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPeopleSearch(int start, int pageLength, System.String keyword, System.Int32? siteId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.String workTypeId, System.String professionId, System.String roleId, System.String countryId, System.String locationId, System.String areaId, System.String eligibleToWorkIn, System.DateTime? availabilityFromDate, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy)
		{
			return CustomPeopleSearch(null, start, pageLength , keyword, siteId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, eligibleToWorkIn, availabilityFromDate, pageIndex, pageSize, orderBy);
		}
				
		/// <summary>
		///	This method wrap the 'Members_CustomPeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomPeopleSearch(TransactionManager transactionManager, System.String keyword, System.Int32? siteId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.String workTypeId, System.String professionId, System.String roleId, System.String countryId, System.String locationId, System.String areaId, System.String eligibleToWorkIn, System.DateTime? availabilityFromDate, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy)
		{
			return CustomPeopleSearch(transactionManager, 0, int.MaxValue , keyword, siteId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId, roleId, countryId, locationId, areaId, eligibleToWorkIn, availabilityFromDate, pageIndex, pageSize, orderBy);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomPeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="keyword"> A <c>System.String</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryTypeId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="workTypeId"> A <c>System.String</c> instance.</param>
		/// <param name="professionId"> A <c>System.String</c> instance.</param>
		/// <param name="roleId"> A <c>System.String</c> instance.</param>
		/// <param name="countryId"> A <c>System.String</c> instance.</param>
		/// <param name="locationId"> A <c>System.String</c> instance.</param>
		/// <param name="areaId"> A <c>System.String</c> instance.</param>
		/// <param name="eligibleToWorkIn"> A <c>System.String</c> instance.</param>
		/// <param name="availabilityFromDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomPeopleSearch(TransactionManager transactionManager, int start, int pageLength , System.String keyword, System.Int32? siteId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? salaryTypeId, System.String workTypeId, System.String professionId, System.String roleId, System.String countryId, System.String locationId, System.String areaId, System.String eligibleToWorkIn, System.DateTime? availabilityFromDate, System.Int32? pageIndex, System.Int32? pageSize, System.String orderBy);
		
		#endregion
		
		#region Members_GetMemberCount 
		
		/// <summary>
		///	This method wrap the 'Members_GetMemberCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMemberCount(System.Int32? siteId)
		{
			return GetMemberCount(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetMemberCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMemberCount(int start, int pageLength, System.Int32? siteId)
		{
			return GetMemberCount(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Members_GetMemberCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetMemberCount(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetMemberCount(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Members_GetMemberCount' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetMemberCount(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Members_CustomGetNewValidProfiles 
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidProfiles' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidProfiles(System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidProfiles(null, 0, int.MaxValue , siteId, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidProfiles' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidProfiles(int start, int pageLength, System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidProfiles(null, start, pageLength , siteId, lastModifiedDate);
		}
				
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidProfiles' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetNewValidProfiles(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? lastModifiedDate)
		{
			return CustomGetNewValidProfiles(transactionManager, 0, int.MaxValue , siteId, lastModifiedDate);
		}
		
		/// <summary>
		///	This method wrap the 'Members_CustomGetNewValidProfiles' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModifiedDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetNewValidProfiles(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? lastModifiedDate);
		
		#endregion
		
		#region Members_PeopleSearch 
		
		/// <summary>
		///	This method wrap the 'Members_PeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchExpression"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet PeopleSearch(System.Int32? siteId, System.Int32? preferredCategoryId, System.Int32? preferredSubCategoryId, System.Int32? preferredSalaryId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? availabilityId, System.Int32? countryId, System.Int32? locationId, System.Int32? areaId, System.String searchExpression, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return PeopleSearch(null, 0, int.MaxValue , siteId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, salaryLowerBand, salaryUpperBand, availabilityId, countryId, locationId, areaId, searchExpression, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Members_PeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchExpression"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet PeopleSearch(int start, int pageLength, System.Int32? siteId, System.Int32? preferredCategoryId, System.Int32? preferredSubCategoryId, System.Int32? preferredSalaryId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? availabilityId, System.Int32? countryId, System.Int32? locationId, System.Int32? areaId, System.String searchExpression, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return PeopleSearch(null, start, pageLength , siteId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, salaryLowerBand, salaryUpperBand, availabilityId, countryId, locationId, areaId, searchExpression, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'Members_PeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchExpression"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet PeopleSearch(TransactionManager transactionManager, System.Int32? siteId, System.Int32? preferredCategoryId, System.Int32? preferredSubCategoryId, System.Int32? preferredSalaryId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? availabilityId, System.Int32? countryId, System.Int32? locationId, System.Int32? areaId, System.String searchExpression, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return PeopleSearch(transactionManager, 0, int.MaxValue , siteId, preferredCategoryId, preferredSubCategoryId, preferredSalaryId, salaryLowerBand, salaryUpperBand, availabilityId, countryId, locationId, areaId, searchExpression, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'Members_PeopleSearch' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSubCategoryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="preferredSalaryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="salaryLowerBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="salaryUpperBand"> A <c>System.Decimal?</c> instance.</param>
		/// <param name="availabilityId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="countryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="locationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="areaId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="searchExpression"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet PeopleSearch(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? preferredCategoryId, System.Int32? preferredSubCategoryId, System.Int32? preferredSalaryId, System.Decimal? salaryLowerBand, System.Decimal? salaryUpperBand, System.Int32? availabilityId, System.Int32? countryId, System.Int32? locationId, System.Int32? areaId, System.String searchExpression, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Members&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Members&gt;"/></returns>
		public static TList<Members> Fill(IDataReader reader, TList<Members> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Members c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Members")
					.Append("|").Append((System.Int32)reader[((int)MembersColumn.MemberId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Members>(
					key.ToString(), // EntityTrackingKey
					"Members",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Members();
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
					c.MemberId = (System.Int32)reader[((int)MembersColumn.MemberId - 1)];
					c.SiteId = (System.Int32)reader[((int)MembersColumn.SiteId - 1)];
					c.Username = (reader.IsDBNull(((int)MembersColumn.Username - 1)))?null:(System.String)reader[((int)MembersColumn.Username - 1)];
					c.Password = (System.String)reader[((int)MembersColumn.Password - 1)];
					c.Title = (reader.IsDBNull(((int)MembersColumn.Title - 1)))?null:(System.String)reader[((int)MembersColumn.Title - 1)];
					c.FirstName = (reader.IsDBNull(((int)MembersColumn.FirstName - 1)))?null:(System.String)reader[((int)MembersColumn.FirstName - 1)];
					c.Surname = (reader.IsDBNull(((int)MembersColumn.Surname - 1)))?null:(System.String)reader[((int)MembersColumn.Surname - 1)];
					c.EmailAddress = (reader.IsDBNull(((int)MembersColumn.EmailAddress - 1)))?null:(System.String)reader[((int)MembersColumn.EmailAddress - 1)];
					c.Company = (reader.IsDBNull(((int)MembersColumn.Company - 1)))?null:(System.String)reader[((int)MembersColumn.Company - 1)];
					c.Position = (reader.IsDBNull(((int)MembersColumn.Position - 1)))?null:(System.String)reader[((int)MembersColumn.Position - 1)];
					c.HomePhone = (reader.IsDBNull(((int)MembersColumn.HomePhone - 1)))?null:(System.String)reader[((int)MembersColumn.HomePhone - 1)];
					c.WorkPhone = (reader.IsDBNull(((int)MembersColumn.WorkPhone - 1)))?null:(System.String)reader[((int)MembersColumn.WorkPhone - 1)];
					c.MobilePhone = (reader.IsDBNull(((int)MembersColumn.MobilePhone - 1)))?null:(System.String)reader[((int)MembersColumn.MobilePhone - 1)];
					c.Fax = (reader.IsDBNull(((int)MembersColumn.Fax - 1)))?null:(System.String)reader[((int)MembersColumn.Fax - 1)];
					c.Address1 = (reader.IsDBNull(((int)MembersColumn.Address1 - 1)))?null:(System.String)reader[((int)MembersColumn.Address1 - 1)];
					c.Address2 = (reader.IsDBNull(((int)MembersColumn.Address2 - 1)))?null:(System.String)reader[((int)MembersColumn.Address2 - 1)];
					c.LocationId = (reader.IsDBNull(((int)MembersColumn.LocationId - 1)))?null:(System.String)reader[((int)MembersColumn.LocationId - 1)];
					c.AreaId = (reader.IsDBNull(((int)MembersColumn.AreaId - 1)))?null:(System.String)reader[((int)MembersColumn.AreaId - 1)];
					c.CountryId = (System.Int32)reader[((int)MembersColumn.CountryId - 1)];
					c.PreferredCategoryId = (reader.IsDBNull(((int)MembersColumn.PreferredCategoryId - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredCategoryId - 1)];
					c.PreferredSubCategoryId = (reader.IsDBNull(((int)MembersColumn.PreferredSubCategoryId - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSubCategoryId - 1)];
					c.PreferredSalaryId = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.PreferredSalaryId - 1)];
					c.Subscribed = (System.Boolean)reader[((int)MembersColumn.Subscribed - 1)];
					c.MonthlyUpdate = (System.Boolean)reader[((int)MembersColumn.MonthlyUpdate - 1)];
					c.ReferringMemberId = (reader.IsDBNull(((int)MembersColumn.ReferringMemberId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.ReferringMemberId - 1)];
					c.LastModifiedDate = (reader.IsDBNull(((int)MembersColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastModifiedDate - 1)];
					c.Valid = (System.Boolean)reader[((int)MembersColumn.Valid - 1)];
					c.EmailFormat = (System.Int32)reader[((int)MembersColumn.EmailFormat - 1)];
					c.LastLogon = (reader.IsDBNull(((int)MembersColumn.LastLogon - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastLogon - 1)];
					c.DateOfBirth = (reader.IsDBNull(((int)MembersColumn.DateOfBirth - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.DateOfBirth - 1)];
					c.Gender = (reader.IsDBNull(((int)MembersColumn.Gender - 1)))?null:(System.String)reader[((int)MembersColumn.Gender - 1)];
					c.Tags = (reader.IsDBNull(((int)MembersColumn.Tags - 1)))?null:(System.String)reader[((int)MembersColumn.Tags - 1)];
					c.Validated = (System.Boolean)reader[((int)MembersColumn.Validated - 1)];
					c.ValidateGuid = (reader.IsDBNull(((int)MembersColumn.ValidateGuid - 1)))?null:(System.Guid?)reader[((int)MembersColumn.ValidateGuid - 1)];
					c.MemberUrlExtension = (reader.IsDBNull(((int)MembersColumn.MemberUrlExtension - 1)))?null:(System.String)reader[((int)MembersColumn.MemberUrlExtension - 1)];
					c.WebsiteUrl = (reader.IsDBNull(((int)MembersColumn.WebsiteUrl - 1)))?null:(System.String)reader[((int)MembersColumn.WebsiteUrl - 1)];
					c.AvailabilityId = (reader.IsDBNull(((int)MembersColumn.AvailabilityId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.AvailabilityId - 1)];
					c.AvailabilityFromDate = (reader.IsDBNull(((int)MembersColumn.AvailabilityFromDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.AvailabilityFromDate - 1)];
					c.MySpaceHeading = (reader.IsDBNull(((int)MembersColumn.MySpaceHeading - 1)))?null:(System.String)reader[((int)MembersColumn.MySpaceHeading - 1)];
					c.MySpaceContent = (reader.IsDBNull(((int)MembersColumn.MySpaceContent - 1)))?null:(System.String)reader[((int)MembersColumn.MySpaceContent - 1)];
					c.UrlReferrer = (reader.IsDBNull(((int)MembersColumn.UrlReferrer - 1)))?null:(System.String)reader[((int)MembersColumn.UrlReferrer - 1)];
					c.RequiredPasswordChange = (reader.IsDBNull(((int)MembersColumn.RequiredPasswordChange - 1)))?null:(System.Boolean?)reader[((int)MembersColumn.RequiredPasswordChange - 1)];
					c.PreferredJobTitle = (reader.IsDBNull(((int)MembersColumn.PreferredJobTitle - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredJobTitle - 1)];
					c.PreferredAvailability = (reader.IsDBNull(((int)MembersColumn.PreferredAvailability - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredAvailability - 1)];
					c.PreferredAvailabilityType = (reader.IsDBNull(((int)MembersColumn.PreferredAvailabilityType - 1)))?null:(System.Int32?)reader[((int)MembersColumn.PreferredAvailabilityType - 1)];
					c.PreferredSalaryFrom = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryFrom - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSalaryFrom - 1)];
					c.PreferredSalaryTo = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryTo - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSalaryTo - 1)];
					c.CurrentSalaryFrom = (reader.IsDBNull(((int)MembersColumn.CurrentSalaryFrom - 1)))?null:(System.String)reader[((int)MembersColumn.CurrentSalaryFrom - 1)];
					c.CurrentSalaryTo = (reader.IsDBNull(((int)MembersColumn.CurrentSalaryTo - 1)))?null:(System.String)reader[((int)MembersColumn.CurrentSalaryTo - 1)];
					c.LookingFor = (reader.IsDBNull(((int)MembersColumn.LookingFor - 1)))?null:(System.String)reader[((int)MembersColumn.LookingFor - 1)];
					c.Experience = (reader.IsDBNull(((int)MembersColumn.Experience - 1)))?null:(System.String)reader[((int)MembersColumn.Experience - 1)];
					c.Skills = (reader.IsDBNull(((int)MembersColumn.Skills - 1)))?null:(System.String)reader[((int)MembersColumn.Skills - 1)];
					c.Reasons = (reader.IsDBNull(((int)MembersColumn.Reasons - 1)))?null:(System.String)reader[((int)MembersColumn.Reasons - 1)];
					c.Comments = (reader.IsDBNull(((int)MembersColumn.Comments - 1)))?null:(System.String)reader[((int)MembersColumn.Comments - 1)];
					c.ProfileType = (reader.IsDBNull(((int)MembersColumn.ProfileType - 1)))?null:(System.String)reader[((int)MembersColumn.ProfileType - 1)];
					c.EducationId = (reader.IsDBNull(((int)MembersColumn.EducationId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.EducationId - 1)];
					c.SearchField = (reader.IsDBNull(((int)MembersColumn.SearchField - 1)))?null:(System.String)reader[((int)MembersColumn.SearchField - 1)];
					c.RegisteredDate = (System.DateTime)reader[((int)MembersColumn.RegisteredDate - 1)];
					c.States = (reader.IsDBNull(((int)MembersColumn.States - 1)))?null:(System.String)reader[((int)MembersColumn.States - 1)];
					c.Suburb = (reader.IsDBNull(((int)MembersColumn.Suburb - 1)))?null:(System.String)reader[((int)MembersColumn.Suburb - 1)];
					c.PostCode = (reader.IsDBNull(((int)MembersColumn.PostCode - 1)))?null:(System.String)reader[((int)MembersColumn.PostCode - 1)];
					c.ProfilePicture = (reader.IsDBNull(((int)MembersColumn.ProfilePicture - 1)))?null:(System.String)reader[((int)MembersColumn.ProfilePicture - 1)];
					c.ShortBio = (reader.IsDBNull(((int)MembersColumn.ShortBio - 1)))?null:(System.String)reader[((int)MembersColumn.ShortBio - 1)];
					c.WorkTypeId = (reader.IsDBNull(((int)MembersColumn.WorkTypeId - 1)))?null:(System.String)reader[((int)MembersColumn.WorkTypeId - 1)];
					c.Memberships = (reader.IsDBNull(((int)MembersColumn.Memberships - 1)))?null:(System.String)reader[((int)MembersColumn.Memberships - 1)];
					c.MemberStatusId = (reader.IsDBNull(((int)MembersColumn.MemberStatusId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.MemberStatusId - 1)];
					c.LinkedInAccessToken = (reader.IsDBNull(((int)MembersColumn.LinkedInAccessToken - 1)))?null:(System.String)reader[((int)MembersColumn.LinkedInAccessToken - 1)];
					c.ExternalMemberId = (reader.IsDBNull(((int)MembersColumn.ExternalMemberId - 1)))?null:(System.String)reader[((int)MembersColumn.ExternalMemberId - 1)];
					c.PassportNo = (reader.IsDBNull(((int)MembersColumn.PassportNo - 1)))?null:(System.String)reader[((int)MembersColumn.PassportNo - 1)];
					c.MailingAddress1 = (reader.IsDBNull(((int)MembersColumn.MailingAddress1 - 1)))?null:(System.String)reader[((int)MembersColumn.MailingAddress1 - 1)];
					c.MailingAddress2 = (reader.IsDBNull(((int)MembersColumn.MailingAddress2 - 1)))?null:(System.String)reader[((int)MembersColumn.MailingAddress2 - 1)];
					c.MailingStates = (reader.IsDBNull(((int)MembersColumn.MailingStates - 1)))?null:(System.String)reader[((int)MembersColumn.MailingStates - 1)];
					c.MailingSuburb = (reader.IsDBNull(((int)MembersColumn.MailingSuburb - 1)))?null:(System.String)reader[((int)MembersColumn.MailingSuburb - 1)];
					c.MailingPostCode = (reader.IsDBNull(((int)MembersColumn.MailingPostCode - 1)))?null:(System.String)reader[((int)MembersColumn.MailingPostCode - 1)];
					c.MailingCountryId = (reader.IsDBNull(((int)MembersColumn.MailingCountryId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.MailingCountryId - 1)];
					c.CountryName = (reader.IsDBNull(((int)MembersColumn.CountryName - 1)))?null:(System.String)reader[((int)MembersColumn.CountryName - 1)];
					c.MailingCountryName = (reader.IsDBNull(((int)MembersColumn.MailingCountryName - 1)))?null:(System.String)reader[((int)MembersColumn.MailingCountryName - 1)];
					c.LoginAttempts = (System.Int32)reader[((int)MembersColumn.LoginAttempts - 1)];
					c.LastAttemptDate = (reader.IsDBNull(((int)MembersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastAttemptDate - 1)];
					c.Status = (reader.IsDBNull(((int)MembersColumn.Status - 1)))?null:(System.Int32?)reader[((int)MembersColumn.Status - 1)];
					c.LastTermsAndConditionsDate = (reader.IsDBNull(((int)MembersColumn.LastTermsAndConditionsDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastTermsAndConditionsDate - 1)];
					c.DefaultLanguageId = (reader.IsDBNull(((int)MembersColumn.DefaultLanguageId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.DefaultLanguageId - 1)];
					c.ReferringSiteId = (reader.IsDBNull(((int)MembersColumn.ReferringSiteId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.ReferringSiteId - 1)];
					c.MultiLingualFirstName = (reader.IsDBNull(((int)MembersColumn.MultiLingualFirstName - 1)))?null:(System.String)reader[((int)MembersColumn.MultiLingualFirstName - 1)];
					c.MultiLingualSurame = (reader.IsDBNull(((int)MembersColumn.MultiLingualSurame - 1)))?null:(System.String)reader[((int)MembersColumn.MultiLingualSurame - 1)];
					c.SecondaryEmail = (reader.IsDBNull(((int)MembersColumn.SecondaryEmail - 1)))?null:(System.String)reader[((int)MembersColumn.SecondaryEmail - 1)];
					c.CandidateData = (reader.IsDBNull(((int)MembersColumn.CandidateData - 1)))?null:(System.String)reader[((int)MembersColumn.CandidateData - 1)];
					c.EligibleToWorkIn = (reader.IsDBNull(((int)MembersColumn.EligibleToWorkIn - 1)))?null:(System.String)reader[((int)MembersColumn.EligibleToWorkIn - 1)];
					c.ReferenceUponRequest = (reader.IsDBNull(((int)MembersColumn.ReferenceUponRequest - 1)))?null:(System.Boolean?)reader[((int)MembersColumn.ReferenceUponRequest - 1)];
					c.PreferredLine = (System.Int32)reader[((int)MembersColumn.PreferredLine - 1)];
					c.VideoUrl = (reader.IsDBNull(((int)MembersColumn.VideoUrl - 1)))?null:(System.String)reader[((int)MembersColumn.VideoUrl - 1)];
					c.ProfileDataXml = (reader.IsDBNull(((int)MembersColumn.ProfileDataXml - 1)))?null:(System.String)reader[((int)MembersColumn.ProfileDataXml - 1)];
					c.LastProfileSubmittedDate = (reader.IsDBNull(((int)MembersColumn.LastProfileSubmittedDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastProfileSubmittedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Members"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Members"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Members entity)
		{
			if (!reader.Read()) return;
			
			entity.MemberId = (System.Int32)reader[((int)MembersColumn.MemberId - 1)];
			entity.SiteId = (System.Int32)reader[((int)MembersColumn.SiteId - 1)];
			entity.Username = (reader.IsDBNull(((int)MembersColumn.Username - 1)))?null:(System.String)reader[((int)MembersColumn.Username - 1)];
			entity.Password = (System.String)reader[((int)MembersColumn.Password - 1)];
			entity.Title = (reader.IsDBNull(((int)MembersColumn.Title - 1)))?null:(System.String)reader[((int)MembersColumn.Title - 1)];
			entity.FirstName = (reader.IsDBNull(((int)MembersColumn.FirstName - 1)))?null:(System.String)reader[((int)MembersColumn.FirstName - 1)];
			entity.Surname = (reader.IsDBNull(((int)MembersColumn.Surname - 1)))?null:(System.String)reader[((int)MembersColumn.Surname - 1)];
			entity.EmailAddress = (reader.IsDBNull(((int)MembersColumn.EmailAddress - 1)))?null:(System.String)reader[((int)MembersColumn.EmailAddress - 1)];
			entity.Company = (reader.IsDBNull(((int)MembersColumn.Company - 1)))?null:(System.String)reader[((int)MembersColumn.Company - 1)];
			entity.Position = (reader.IsDBNull(((int)MembersColumn.Position - 1)))?null:(System.String)reader[((int)MembersColumn.Position - 1)];
			entity.HomePhone = (reader.IsDBNull(((int)MembersColumn.HomePhone - 1)))?null:(System.String)reader[((int)MembersColumn.HomePhone - 1)];
			entity.WorkPhone = (reader.IsDBNull(((int)MembersColumn.WorkPhone - 1)))?null:(System.String)reader[((int)MembersColumn.WorkPhone - 1)];
			entity.MobilePhone = (reader.IsDBNull(((int)MembersColumn.MobilePhone - 1)))?null:(System.String)reader[((int)MembersColumn.MobilePhone - 1)];
			entity.Fax = (reader.IsDBNull(((int)MembersColumn.Fax - 1)))?null:(System.String)reader[((int)MembersColumn.Fax - 1)];
			entity.Address1 = (reader.IsDBNull(((int)MembersColumn.Address1 - 1)))?null:(System.String)reader[((int)MembersColumn.Address1 - 1)];
			entity.Address2 = (reader.IsDBNull(((int)MembersColumn.Address2 - 1)))?null:(System.String)reader[((int)MembersColumn.Address2 - 1)];
			entity.LocationId = (reader.IsDBNull(((int)MembersColumn.LocationId - 1)))?null:(System.String)reader[((int)MembersColumn.LocationId - 1)];
			entity.AreaId = (reader.IsDBNull(((int)MembersColumn.AreaId - 1)))?null:(System.String)reader[((int)MembersColumn.AreaId - 1)];
			entity.CountryId = (System.Int32)reader[((int)MembersColumn.CountryId - 1)];
			entity.PreferredCategoryId = (reader.IsDBNull(((int)MembersColumn.PreferredCategoryId - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredCategoryId - 1)];
			entity.PreferredSubCategoryId = (reader.IsDBNull(((int)MembersColumn.PreferredSubCategoryId - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSubCategoryId - 1)];
			entity.PreferredSalaryId = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.PreferredSalaryId - 1)];
			entity.Subscribed = (System.Boolean)reader[((int)MembersColumn.Subscribed - 1)];
			entity.MonthlyUpdate = (System.Boolean)reader[((int)MembersColumn.MonthlyUpdate - 1)];
			entity.ReferringMemberId = (reader.IsDBNull(((int)MembersColumn.ReferringMemberId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.ReferringMemberId - 1)];
			entity.LastModifiedDate = (reader.IsDBNull(((int)MembersColumn.LastModifiedDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastModifiedDate - 1)];
			entity.Valid = (System.Boolean)reader[((int)MembersColumn.Valid - 1)];
			entity.EmailFormat = (System.Int32)reader[((int)MembersColumn.EmailFormat - 1)];
			entity.LastLogon = (reader.IsDBNull(((int)MembersColumn.LastLogon - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastLogon - 1)];
			entity.DateOfBirth = (reader.IsDBNull(((int)MembersColumn.DateOfBirth - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.DateOfBirth - 1)];
			entity.Gender = (reader.IsDBNull(((int)MembersColumn.Gender - 1)))?null:(System.String)reader[((int)MembersColumn.Gender - 1)];
			entity.Tags = (reader.IsDBNull(((int)MembersColumn.Tags - 1)))?null:(System.String)reader[((int)MembersColumn.Tags - 1)];
			entity.Validated = (System.Boolean)reader[((int)MembersColumn.Validated - 1)];
			entity.ValidateGuid = (reader.IsDBNull(((int)MembersColumn.ValidateGuid - 1)))?null:(System.Guid?)reader[((int)MembersColumn.ValidateGuid - 1)];
			entity.MemberUrlExtension = (reader.IsDBNull(((int)MembersColumn.MemberUrlExtension - 1)))?null:(System.String)reader[((int)MembersColumn.MemberUrlExtension - 1)];
			entity.WebsiteUrl = (reader.IsDBNull(((int)MembersColumn.WebsiteUrl - 1)))?null:(System.String)reader[((int)MembersColumn.WebsiteUrl - 1)];
			entity.AvailabilityId = (reader.IsDBNull(((int)MembersColumn.AvailabilityId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.AvailabilityId - 1)];
			entity.AvailabilityFromDate = (reader.IsDBNull(((int)MembersColumn.AvailabilityFromDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.AvailabilityFromDate - 1)];
			entity.MySpaceHeading = (reader.IsDBNull(((int)MembersColumn.MySpaceHeading - 1)))?null:(System.String)reader[((int)MembersColumn.MySpaceHeading - 1)];
			entity.MySpaceContent = (reader.IsDBNull(((int)MembersColumn.MySpaceContent - 1)))?null:(System.String)reader[((int)MembersColumn.MySpaceContent - 1)];
			entity.UrlReferrer = (reader.IsDBNull(((int)MembersColumn.UrlReferrer - 1)))?null:(System.String)reader[((int)MembersColumn.UrlReferrer - 1)];
			entity.RequiredPasswordChange = (reader.IsDBNull(((int)MembersColumn.RequiredPasswordChange - 1)))?null:(System.Boolean?)reader[((int)MembersColumn.RequiredPasswordChange - 1)];
			entity.PreferredJobTitle = (reader.IsDBNull(((int)MembersColumn.PreferredJobTitle - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredJobTitle - 1)];
			entity.PreferredAvailability = (reader.IsDBNull(((int)MembersColumn.PreferredAvailability - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredAvailability - 1)];
			entity.PreferredAvailabilityType = (reader.IsDBNull(((int)MembersColumn.PreferredAvailabilityType - 1)))?null:(System.Int32?)reader[((int)MembersColumn.PreferredAvailabilityType - 1)];
			entity.PreferredSalaryFrom = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryFrom - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSalaryFrom - 1)];
			entity.PreferredSalaryTo = (reader.IsDBNull(((int)MembersColumn.PreferredSalaryTo - 1)))?null:(System.String)reader[((int)MembersColumn.PreferredSalaryTo - 1)];
			entity.CurrentSalaryFrom = (reader.IsDBNull(((int)MembersColumn.CurrentSalaryFrom - 1)))?null:(System.String)reader[((int)MembersColumn.CurrentSalaryFrom - 1)];
			entity.CurrentSalaryTo = (reader.IsDBNull(((int)MembersColumn.CurrentSalaryTo - 1)))?null:(System.String)reader[((int)MembersColumn.CurrentSalaryTo - 1)];
			entity.LookingFor = (reader.IsDBNull(((int)MembersColumn.LookingFor - 1)))?null:(System.String)reader[((int)MembersColumn.LookingFor - 1)];
			entity.Experience = (reader.IsDBNull(((int)MembersColumn.Experience - 1)))?null:(System.String)reader[((int)MembersColumn.Experience - 1)];
			entity.Skills = (reader.IsDBNull(((int)MembersColumn.Skills - 1)))?null:(System.String)reader[((int)MembersColumn.Skills - 1)];
			entity.Reasons = (reader.IsDBNull(((int)MembersColumn.Reasons - 1)))?null:(System.String)reader[((int)MembersColumn.Reasons - 1)];
			entity.Comments = (reader.IsDBNull(((int)MembersColumn.Comments - 1)))?null:(System.String)reader[((int)MembersColumn.Comments - 1)];
			entity.ProfileType = (reader.IsDBNull(((int)MembersColumn.ProfileType - 1)))?null:(System.String)reader[((int)MembersColumn.ProfileType - 1)];
			entity.EducationId = (reader.IsDBNull(((int)MembersColumn.EducationId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.EducationId - 1)];
			entity.SearchField = (reader.IsDBNull(((int)MembersColumn.SearchField - 1)))?null:(System.String)reader[((int)MembersColumn.SearchField - 1)];
			entity.RegisteredDate = (System.DateTime)reader[((int)MembersColumn.RegisteredDate - 1)];
			entity.States = (reader.IsDBNull(((int)MembersColumn.States - 1)))?null:(System.String)reader[((int)MembersColumn.States - 1)];
			entity.Suburb = (reader.IsDBNull(((int)MembersColumn.Suburb - 1)))?null:(System.String)reader[((int)MembersColumn.Suburb - 1)];
			entity.PostCode = (reader.IsDBNull(((int)MembersColumn.PostCode - 1)))?null:(System.String)reader[((int)MembersColumn.PostCode - 1)];
			entity.ProfilePicture = (reader.IsDBNull(((int)MembersColumn.ProfilePicture - 1)))?null:(System.String)reader[((int)MembersColumn.ProfilePicture - 1)];
			entity.ShortBio = (reader.IsDBNull(((int)MembersColumn.ShortBio - 1)))?null:(System.String)reader[((int)MembersColumn.ShortBio - 1)];
			entity.WorkTypeId = (reader.IsDBNull(((int)MembersColumn.WorkTypeId - 1)))?null:(System.String)reader[((int)MembersColumn.WorkTypeId - 1)];
			entity.Memberships = (reader.IsDBNull(((int)MembersColumn.Memberships - 1)))?null:(System.String)reader[((int)MembersColumn.Memberships - 1)];
			entity.MemberStatusId = (reader.IsDBNull(((int)MembersColumn.MemberStatusId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.MemberStatusId - 1)];
			entity.LinkedInAccessToken = (reader.IsDBNull(((int)MembersColumn.LinkedInAccessToken - 1)))?null:(System.String)reader[((int)MembersColumn.LinkedInAccessToken - 1)];
			entity.ExternalMemberId = (reader.IsDBNull(((int)MembersColumn.ExternalMemberId - 1)))?null:(System.String)reader[((int)MembersColumn.ExternalMemberId - 1)];
			entity.PassportNo = (reader.IsDBNull(((int)MembersColumn.PassportNo - 1)))?null:(System.String)reader[((int)MembersColumn.PassportNo - 1)];
			entity.MailingAddress1 = (reader.IsDBNull(((int)MembersColumn.MailingAddress1 - 1)))?null:(System.String)reader[((int)MembersColumn.MailingAddress1 - 1)];
			entity.MailingAddress2 = (reader.IsDBNull(((int)MembersColumn.MailingAddress2 - 1)))?null:(System.String)reader[((int)MembersColumn.MailingAddress2 - 1)];
			entity.MailingStates = (reader.IsDBNull(((int)MembersColumn.MailingStates - 1)))?null:(System.String)reader[((int)MembersColumn.MailingStates - 1)];
			entity.MailingSuburb = (reader.IsDBNull(((int)MembersColumn.MailingSuburb - 1)))?null:(System.String)reader[((int)MembersColumn.MailingSuburb - 1)];
			entity.MailingPostCode = (reader.IsDBNull(((int)MembersColumn.MailingPostCode - 1)))?null:(System.String)reader[((int)MembersColumn.MailingPostCode - 1)];
			entity.MailingCountryId = (reader.IsDBNull(((int)MembersColumn.MailingCountryId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.MailingCountryId - 1)];
			entity.CountryName = (reader.IsDBNull(((int)MembersColumn.CountryName - 1)))?null:(System.String)reader[((int)MembersColumn.CountryName - 1)];
			entity.MailingCountryName = (reader.IsDBNull(((int)MembersColumn.MailingCountryName - 1)))?null:(System.String)reader[((int)MembersColumn.MailingCountryName - 1)];
			entity.LoginAttempts = (System.Int32)reader[((int)MembersColumn.LoginAttempts - 1)];
			entity.LastAttemptDate = (reader.IsDBNull(((int)MembersColumn.LastAttemptDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastAttemptDate - 1)];
			entity.Status = (reader.IsDBNull(((int)MembersColumn.Status - 1)))?null:(System.Int32?)reader[((int)MembersColumn.Status - 1)];
			entity.LastTermsAndConditionsDate = (reader.IsDBNull(((int)MembersColumn.LastTermsAndConditionsDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastTermsAndConditionsDate - 1)];
			entity.DefaultLanguageId = (reader.IsDBNull(((int)MembersColumn.DefaultLanguageId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.DefaultLanguageId - 1)];
			entity.ReferringSiteId = (reader.IsDBNull(((int)MembersColumn.ReferringSiteId - 1)))?null:(System.Int32?)reader[((int)MembersColumn.ReferringSiteId - 1)];
			entity.MultiLingualFirstName = (reader.IsDBNull(((int)MembersColumn.MultiLingualFirstName - 1)))?null:(System.String)reader[((int)MembersColumn.MultiLingualFirstName - 1)];
			entity.MultiLingualSurame = (reader.IsDBNull(((int)MembersColumn.MultiLingualSurame - 1)))?null:(System.String)reader[((int)MembersColumn.MultiLingualSurame - 1)];
			entity.SecondaryEmail = (reader.IsDBNull(((int)MembersColumn.SecondaryEmail - 1)))?null:(System.String)reader[((int)MembersColumn.SecondaryEmail - 1)];
			entity.CandidateData = (reader.IsDBNull(((int)MembersColumn.CandidateData - 1)))?null:(System.String)reader[((int)MembersColumn.CandidateData - 1)];
			entity.EligibleToWorkIn = (reader.IsDBNull(((int)MembersColumn.EligibleToWorkIn - 1)))?null:(System.String)reader[((int)MembersColumn.EligibleToWorkIn - 1)];
			entity.ReferenceUponRequest = (reader.IsDBNull(((int)MembersColumn.ReferenceUponRequest - 1)))?null:(System.Boolean?)reader[((int)MembersColumn.ReferenceUponRequest - 1)];
			entity.PreferredLine = (System.Int32)reader[((int)MembersColumn.PreferredLine - 1)];
			entity.VideoUrl = (reader.IsDBNull(((int)MembersColumn.VideoUrl - 1)))?null:(System.String)reader[((int)MembersColumn.VideoUrl - 1)];
			entity.ProfileDataXml = (reader.IsDBNull(((int)MembersColumn.ProfileDataXml - 1)))?null:(System.String)reader[((int)MembersColumn.ProfileDataXml - 1)];
			entity.LastProfileSubmittedDate = (reader.IsDBNull(((int)MembersColumn.LastProfileSubmittedDate - 1)))?null:(System.DateTime?)reader[((int)MembersColumn.LastProfileSubmittedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Members"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Members"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Members entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MemberId = (System.Int32)dataRow["MemberID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.Username = Convert.IsDBNull(dataRow["Username"]) ? null : (System.String)dataRow["Username"];
			entity.Password = (System.String)dataRow["Password"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.Surname = Convert.IsDBNull(dataRow["Surname"]) ? null : (System.String)dataRow["Surname"];
			entity.EmailAddress = Convert.IsDBNull(dataRow["EmailAddress"]) ? null : (System.String)dataRow["EmailAddress"];
			entity.Company = Convert.IsDBNull(dataRow["Company"]) ? null : (System.String)dataRow["Company"];
			entity.Position = Convert.IsDBNull(dataRow["Position"]) ? null : (System.String)dataRow["Position"];
			entity.HomePhone = Convert.IsDBNull(dataRow["HomePhone"]) ? null : (System.String)dataRow["HomePhone"];
			entity.WorkPhone = Convert.IsDBNull(dataRow["WorkPhone"]) ? null : (System.String)dataRow["WorkPhone"];
			entity.MobilePhone = Convert.IsDBNull(dataRow["MobilePhone"]) ? null : (System.String)dataRow["MobilePhone"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.Address1 = Convert.IsDBNull(dataRow["Address1"]) ? null : (System.String)dataRow["Address1"];
			entity.Address2 = Convert.IsDBNull(dataRow["Address2"]) ? null : (System.String)dataRow["Address2"];
			entity.LocationId = Convert.IsDBNull(dataRow["LocationID"]) ? null : (System.String)dataRow["LocationID"];
			entity.AreaId = Convert.IsDBNull(dataRow["AreaID"]) ? null : (System.String)dataRow["AreaID"];
			entity.CountryId = (System.Int32)dataRow["CountryID"];
			entity.PreferredCategoryId = Convert.IsDBNull(dataRow["PreferredCategoryID"]) ? null : (System.String)dataRow["PreferredCategoryID"];
			entity.PreferredSubCategoryId = Convert.IsDBNull(dataRow["PreferredSubCategoryID"]) ? null : (System.String)dataRow["PreferredSubCategoryID"];
			entity.PreferredSalaryId = Convert.IsDBNull(dataRow["PreferredSalaryID"]) ? null : (System.Int32?)dataRow["PreferredSalaryID"];
			entity.Subscribed = (System.Boolean)dataRow["Subscribed"];
			entity.MonthlyUpdate = (System.Boolean)dataRow["MonthlyUpdate"];
			entity.ReferringMemberId = Convert.IsDBNull(dataRow["ReferringMemberID"]) ? null : (System.Int32?)dataRow["ReferringMemberID"];
			entity.LastModifiedDate = Convert.IsDBNull(dataRow["LastModifiedDate"]) ? null : (System.DateTime?)dataRow["LastModifiedDate"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.EmailFormat = (System.Int32)dataRow["EmailFormat"];
			entity.LastLogon = Convert.IsDBNull(dataRow["LastLogon"]) ? null : (System.DateTime?)dataRow["LastLogon"];
			entity.DateOfBirth = Convert.IsDBNull(dataRow["DateOfBirth"]) ? null : (System.DateTime?)dataRow["DateOfBirth"];
			entity.Gender = Convert.IsDBNull(dataRow["Gender"]) ? null : (System.String)dataRow["Gender"];
			entity.Tags = Convert.IsDBNull(dataRow["Tags"]) ? null : (System.String)dataRow["Tags"];
			entity.Validated = (System.Boolean)dataRow["Validated"];
			entity.ValidateGuid = Convert.IsDBNull(dataRow["ValidateGUID"]) ? null : (System.Guid?)dataRow["ValidateGUID"];
			entity.MemberUrlExtension = Convert.IsDBNull(dataRow["MemberURLExtension"]) ? null : (System.String)dataRow["MemberURLExtension"];
			entity.WebsiteUrl = Convert.IsDBNull(dataRow["WebsiteURL"]) ? null : (System.String)dataRow["WebsiteURL"];
			entity.AvailabilityId = Convert.IsDBNull(dataRow["AvailabilityID"]) ? null : (System.Int32?)dataRow["AvailabilityID"];
			entity.AvailabilityFromDate = Convert.IsDBNull(dataRow["AvailabilityFromDate"]) ? null : (System.DateTime?)dataRow["AvailabilityFromDate"];
			entity.MySpaceHeading = Convert.IsDBNull(dataRow["MySpaceHeading"]) ? null : (System.String)dataRow["MySpaceHeading"];
			entity.MySpaceContent = Convert.IsDBNull(dataRow["MySpaceContent"]) ? null : (System.String)dataRow["MySpaceContent"];
			entity.UrlReferrer = Convert.IsDBNull(dataRow["URLReferrer"]) ? null : (System.String)dataRow["URLReferrer"];
			entity.RequiredPasswordChange = Convert.IsDBNull(dataRow["RequiredPasswordChange"]) ? null : (System.Boolean?)dataRow["RequiredPasswordChange"];
			entity.PreferredJobTitle = Convert.IsDBNull(dataRow["PreferredJobTitle"]) ? null : (System.String)dataRow["PreferredJobTitle"];
			entity.PreferredAvailability = Convert.IsDBNull(dataRow["PreferredAvailability"]) ? null : (System.String)dataRow["PreferredAvailability"];
			entity.PreferredAvailabilityType = Convert.IsDBNull(dataRow["PreferredAvailabilityType"]) ? null : (System.Int32?)dataRow["PreferredAvailabilityType"];
			entity.PreferredSalaryFrom = Convert.IsDBNull(dataRow["PreferredSalaryFrom"]) ? null : (System.String)dataRow["PreferredSalaryFrom"];
			entity.PreferredSalaryTo = Convert.IsDBNull(dataRow["PreferredSalaryTo"]) ? null : (System.String)dataRow["PreferredSalaryTo"];
			entity.CurrentSalaryFrom = Convert.IsDBNull(dataRow["CurrentSalaryFrom"]) ? null : (System.String)dataRow["CurrentSalaryFrom"];
			entity.CurrentSalaryTo = Convert.IsDBNull(dataRow["CurrentSalaryTo"]) ? null : (System.String)dataRow["CurrentSalaryTo"];
			entity.LookingFor = Convert.IsDBNull(dataRow["LookingFor"]) ? null : (System.String)dataRow["LookingFor"];
			entity.Experience = Convert.IsDBNull(dataRow["Experience"]) ? null : (System.String)dataRow["Experience"];
			entity.Skills = Convert.IsDBNull(dataRow["Skills"]) ? null : (System.String)dataRow["Skills"];
			entity.Reasons = Convert.IsDBNull(dataRow["Reasons"]) ? null : (System.String)dataRow["Reasons"];
			entity.Comments = Convert.IsDBNull(dataRow["Comments"]) ? null : (System.String)dataRow["Comments"];
			entity.ProfileType = Convert.IsDBNull(dataRow["ProfileType"]) ? null : (System.String)dataRow["ProfileType"];
			entity.EducationId = Convert.IsDBNull(dataRow["EducationID"]) ? null : (System.Int32?)dataRow["EducationID"];
			entity.SearchField = Convert.IsDBNull(dataRow["SearchField"]) ? null : (System.String)dataRow["SearchField"];
			entity.RegisteredDate = (System.DateTime)dataRow["RegisteredDate"];
			entity.States = Convert.IsDBNull(dataRow["States"]) ? null : (System.String)dataRow["States"];
			entity.Suburb = Convert.IsDBNull(dataRow["Suburb"]) ? null : (System.String)dataRow["Suburb"];
			entity.PostCode = Convert.IsDBNull(dataRow["PostCode"]) ? null : (System.String)dataRow["PostCode"];
			entity.ProfilePicture = Convert.IsDBNull(dataRow["ProfilePicture"]) ? null : (System.String)dataRow["ProfilePicture"];
			entity.ShortBio = Convert.IsDBNull(dataRow["ShortBio"]) ? null : (System.String)dataRow["ShortBio"];
			entity.WorkTypeId = Convert.IsDBNull(dataRow["WorkTypeID"]) ? null : (System.String)dataRow["WorkTypeID"];
			entity.Memberships = Convert.IsDBNull(dataRow["Memberships"]) ? null : (System.String)dataRow["Memberships"];
			entity.MemberStatusId = Convert.IsDBNull(dataRow["MemberStatusID"]) ? null : (System.Int32?)dataRow["MemberStatusID"];
			entity.LinkedInAccessToken = Convert.IsDBNull(dataRow["LinkedInAccessToken"]) ? null : (System.String)dataRow["LinkedInAccessToken"];
			entity.ExternalMemberId = Convert.IsDBNull(dataRow["ExternalMemberID"]) ? null : (System.String)dataRow["ExternalMemberID"];
			entity.PassportNo = Convert.IsDBNull(dataRow["PassportNo"]) ? null : (System.String)dataRow["PassportNo"];
			entity.MailingAddress1 = Convert.IsDBNull(dataRow["MailingAddress1"]) ? null : (System.String)dataRow["MailingAddress1"];
			entity.MailingAddress2 = Convert.IsDBNull(dataRow["MailingAddress2"]) ? null : (System.String)dataRow["MailingAddress2"];
			entity.MailingStates = Convert.IsDBNull(dataRow["MailingStates"]) ? null : (System.String)dataRow["MailingStates"];
			entity.MailingSuburb = Convert.IsDBNull(dataRow["MailingSuburb"]) ? null : (System.String)dataRow["MailingSuburb"];
			entity.MailingPostCode = Convert.IsDBNull(dataRow["MailingPostCode"]) ? null : (System.String)dataRow["MailingPostCode"];
			entity.MailingCountryId = Convert.IsDBNull(dataRow["MailingCountryID"]) ? null : (System.Int32?)dataRow["MailingCountryID"];
			entity.CountryName = Convert.IsDBNull(dataRow["CountryName"]) ? null : (System.String)dataRow["CountryName"];
			entity.MailingCountryName = Convert.IsDBNull(dataRow["MailingCountryName"]) ? null : (System.String)dataRow["MailingCountryName"];
			entity.LoginAttempts = (System.Int32)dataRow["LoginAttempts"];
			entity.LastAttemptDate = Convert.IsDBNull(dataRow["LastAttemptDate"]) ? null : (System.DateTime?)dataRow["LastAttemptDate"];
			entity.Status = Convert.IsDBNull(dataRow["Status"]) ? null : (System.Int32?)dataRow["Status"];
			entity.LastTermsAndConditionsDate = Convert.IsDBNull(dataRow["LastTermsAndConditionsDate"]) ? null : (System.DateTime?)dataRow["LastTermsAndConditionsDate"];
			entity.DefaultLanguageId = Convert.IsDBNull(dataRow["DefaultLanguageId"]) ? null : (System.Int32?)dataRow["DefaultLanguageId"];
			entity.ReferringSiteId = Convert.IsDBNull(dataRow["ReferringSiteID"]) ? null : (System.Int32?)dataRow["ReferringSiteID"];
			entity.MultiLingualFirstName = Convert.IsDBNull(dataRow["MultiLingualFirstName"]) ? null : (System.String)dataRow["MultiLingualFirstName"];
			entity.MultiLingualSurame = Convert.IsDBNull(dataRow["MultiLingualSurame"]) ? null : (System.String)dataRow["MultiLingualSurame"];
			entity.SecondaryEmail = Convert.IsDBNull(dataRow["SecondaryEmail"]) ? null : (System.String)dataRow["SecondaryEmail"];
			entity.CandidateData = Convert.IsDBNull(dataRow["CandidateData"]) ? null : (System.String)dataRow["CandidateData"];
			entity.EligibleToWorkIn = Convert.IsDBNull(dataRow["EligibleToWorkIn"]) ? null : (System.String)dataRow["EligibleToWorkIn"];
			entity.ReferenceUponRequest = Convert.IsDBNull(dataRow["ReferenceUponRequest"]) ? null : (System.Boolean?)dataRow["ReferenceUponRequest"];
			entity.PreferredLine = (System.Int32)dataRow["PreferredLine"];
			entity.VideoUrl = Convert.IsDBNull(dataRow["VideoURL"]) ? null : (System.String)dataRow["VideoURL"];
			entity.ProfileDataXml = Convert.IsDBNull(dataRow["ProfileDataXML"]) ? null : (System.String)dataRow["ProfileDataXML"];
			entity.LastProfileSubmittedDate = Convert.IsDBNull(dataRow["LastProfileSubmittedDate"]) ? null : (System.DateTime?)dataRow["LastProfileSubmittedDate"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Members"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Members Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Members entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Countries|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CountryId;
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountriesProvider.GetByCountryId(transactionManager, entity.CountryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.CountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryIdSource

			#region EducationIdSource	
			if (CanDeepLoad(entity, "Educations|EducationIdSource", deepLoadType, innerList) 
				&& entity.EducationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.EducationId ?? (int)0);
				Educations tmpEntity = EntityManager.LocateEntity<Educations>(EntityLocator.ConstructKeyFromPkItems(typeof(Educations), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EducationIdSource = tmpEntity;
				else
					entity.EducationIdSource = DataRepository.EducationsProvider.GetByEducationId(transactionManager, (entity.EducationId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EducationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EducationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EducationsProvider.DeepLoad(transactionManager, entity.EducationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EducationIdSource

			#region EmailFormatSource	
			if (CanDeepLoad(entity, "EmailFormats|EmailFormatSource", deepLoadType, innerList) 
				&& entity.EmailFormatSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmailFormat;
				EmailFormats tmpEntity = EntityManager.LocateEntity<EmailFormats>(EntityLocator.ConstructKeyFromPkItems(typeof(EmailFormats), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmailFormatSource = tmpEntity;
				else
					entity.EmailFormatSource = DataRepository.EmailFormatsProvider.GetByEmailFormatId(transactionManager, entity.EmailFormat);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmailFormatSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmailFormatSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmailFormatsProvider.DeepLoad(transactionManager, entity.EmailFormatSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmailFormatSource

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
			// Deep load child collections  - Call GetByMemberId methods when available
			
			#region JobsSavedCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobsSaved>|JobsSavedCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobsSavedCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobsSavedCollection = DataRepository.JobsSavedProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.JobsSavedCollection.Count > 0)
				{
					deepHandles.Add("JobsSavedCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobsSaved>) DataRepository.JobsSavedProvider.DeepLoad,
						new object[] { transactionManager, entity.JobsSavedCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberLanguagesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberLanguages>|MemberLanguagesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberLanguagesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberLanguagesCollection = DataRepository.MemberLanguagesProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberLanguagesCollection.Count > 0)
				{
					deepHandles.Add("MemberLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberLanguages>) DataRepository.MemberLanguagesProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberLanguagesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberQualificationCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberQualification>|MemberQualificationCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberQualificationCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberQualificationCollection = DataRepository.MemberQualificationProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberQualificationCollection.Count > 0)
				{
					deepHandles.Add("MemberQualificationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberQualification>) DataRepository.MemberQualificationProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberQualificationCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobApplicationCollection = DataRepository.JobApplicationProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.JobApplicationCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplication>) DataRepository.JobApplicationProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberReferencesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberReferences>|MemberReferencesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberReferencesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberReferencesCollection = DataRepository.MemberReferencesProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberReferencesCollection.Count > 0)
				{
					deepHandles.Add("MemberReferencesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberReferences>) DataRepository.MemberReferencesProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberReferencesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberCertificateMembershipsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberCertificateMemberships>|MemberCertificateMembershipsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberCertificateMembershipsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberCertificateMembershipsCollection = DataRepository.MemberCertificateMembershipsProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberCertificateMembershipsCollection.Count > 0)
				{
					deepHandles.Add("MemberCertificateMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberCertificateMemberships>) DataRepository.MemberCertificateMembershipsProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberCertificateMembershipsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberPositionsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberPositions>|MemberPositionsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberPositionsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberPositionsCollection = DataRepository.MemberPositionsProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberPositionsCollection.Count > 0)
				{
					deepHandles.Add("MemberPositionsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberPositions>) DataRepository.MemberPositionsProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberPositionsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberLicensesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberLicenses>|MemberLicensesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberLicensesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberLicensesCollection = DataRepository.MemberLicensesProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberLicensesCollection.Count > 0)
				{
					deepHandles.Add("MemberLicensesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberLicenses>) DataRepository.MemberLicensesProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberLicensesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region MemberFilesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<MemberFiles>|MemberFilesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MemberFilesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.MemberFilesCollection = DataRepository.MemberFilesProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.MemberFilesCollection.Count > 0)
				{
					deepHandles.Add("MemberFilesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<MemberFiles>) DataRepository.MemberFilesProvider.DeepLoad,
						new object[] { transactionManager, entity.MemberFilesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region JobApplicationNotesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'JobApplicationNotesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.JobApplicationNotesCollection = DataRepository.JobApplicationNotesProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.JobApplicationNotesCollection.Count > 0)
				{
					deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobApplicationNotes>) DataRepository.JobApplicationNotesProvider.DeepLoad,
						new object[] { transactionManager, entity.JobApplicationNotesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.JobAlertsCollection = DataRepository.JobAlertsProvider.GetByMemberId(transactionManager, entity.MemberId);

				if (deep && entity.JobAlertsCollection.Count > 0)
				{
					deepHandles.Add("JobAlertsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<JobAlerts>) DataRepository.JobAlertsProvider.DeepLoad,
						new object[] { transactionManager, entity.JobAlertsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Members object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Members instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Members Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Members entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Countries|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.CountryId;
			}
			#endregion 
			
			#region EducationIdSource
			if (CanDeepSave(entity, "Educations|EducationIdSource", deepSaveType, innerList) 
				&& entity.EducationIdSource != null)
			{
				DataRepository.EducationsProvider.Save(transactionManager, entity.EducationIdSource);
				entity.EducationId = entity.EducationIdSource.EducationId;
			}
			#endregion 
			
			#region EmailFormatSource
			if (CanDeepSave(entity, "EmailFormats|EmailFormatSource", deepSaveType, innerList) 
				&& entity.EmailFormatSource != null)
			{
				DataRepository.EmailFormatsProvider.Save(transactionManager, entity.EmailFormatSource);
				entity.EmailFormat = entity.EmailFormatSource.EmailFormatId;
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
	
			#region List<JobsSaved>
				if (CanDeepSave(entity.JobsSavedCollection, "List<JobsSaved>|JobsSavedCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobsSaved child in entity.JobsSavedCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.JobsSavedCollection.Count > 0 || entity.JobsSavedCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobsSavedProvider.Save(transactionManager, entity.JobsSavedCollection);
						
						deepHandles.Add("JobsSavedCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobsSaved >) DataRepository.JobsSavedProvider.DeepSave,
							new object[] { transactionManager, entity.JobsSavedCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberLanguages>
				if (CanDeepSave(entity.MemberLanguagesCollection, "List<MemberLanguages>|MemberLanguagesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberLanguages child in entity.MemberLanguagesCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberLanguagesCollection.Count > 0 || entity.MemberLanguagesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberLanguagesProvider.Save(transactionManager, entity.MemberLanguagesCollection);
						
						deepHandles.Add("MemberLanguagesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberLanguages >) DataRepository.MemberLanguagesProvider.DeepSave,
							new object[] { transactionManager, entity.MemberLanguagesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberQualification>
				if (CanDeepSave(entity.MemberQualificationCollection, "List<MemberQualification>|MemberQualificationCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberQualification child in entity.MemberQualificationCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberQualificationCollection.Count > 0 || entity.MemberQualificationCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberQualificationProvider.Save(transactionManager, entity.MemberQualificationCollection);
						
						deepHandles.Add("MemberQualificationCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberQualification >) DataRepository.MemberQualificationProvider.DeepSave,
							new object[] { transactionManager, entity.MemberQualificationCollection, deepSaveType, childTypes, innerList }
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
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
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
				
	
			#region List<MemberReferences>
				if (CanDeepSave(entity.MemberReferencesCollection, "List<MemberReferences>|MemberReferencesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberReferences child in entity.MemberReferencesCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberReferencesCollection.Count > 0 || entity.MemberReferencesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberReferencesProvider.Save(transactionManager, entity.MemberReferencesCollection);
						
						deepHandles.Add("MemberReferencesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberReferences >) DataRepository.MemberReferencesProvider.DeepSave,
							new object[] { transactionManager, entity.MemberReferencesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberCertificateMemberships>
				if (CanDeepSave(entity.MemberCertificateMembershipsCollection, "List<MemberCertificateMemberships>|MemberCertificateMembershipsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberCertificateMemberships child in entity.MemberCertificateMembershipsCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberCertificateMembershipsCollection.Count > 0 || entity.MemberCertificateMembershipsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberCertificateMembershipsProvider.Save(transactionManager, entity.MemberCertificateMembershipsCollection);
						
						deepHandles.Add("MemberCertificateMembershipsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberCertificateMemberships >) DataRepository.MemberCertificateMembershipsProvider.DeepSave,
							new object[] { transactionManager, entity.MemberCertificateMembershipsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberPositions>
				if (CanDeepSave(entity.MemberPositionsCollection, "List<MemberPositions>|MemberPositionsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberPositions child in entity.MemberPositionsCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberPositionsCollection.Count > 0 || entity.MemberPositionsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberPositionsProvider.Save(transactionManager, entity.MemberPositionsCollection);
						
						deepHandles.Add("MemberPositionsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberPositions >) DataRepository.MemberPositionsProvider.DeepSave,
							new object[] { transactionManager, entity.MemberPositionsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberLicenses>
				if (CanDeepSave(entity.MemberLicensesCollection, "List<MemberLicenses>|MemberLicensesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberLicenses child in entity.MemberLicensesCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberLicensesCollection.Count > 0 || entity.MemberLicensesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberLicensesProvider.Save(transactionManager, entity.MemberLicensesCollection);
						
						deepHandles.Add("MemberLicensesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberLicenses >) DataRepository.MemberLicensesProvider.DeepSave,
							new object[] { transactionManager, entity.MemberLicensesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<MemberFiles>
				if (CanDeepSave(entity.MemberFilesCollection, "List<MemberFiles>|MemberFilesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(MemberFiles child in entity.MemberFilesCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.MemberFilesCollection.Count > 0 || entity.MemberFilesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.MemberFilesProvider.Save(transactionManager, entity.MemberFilesCollection);
						
						deepHandles.Add("MemberFilesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< MemberFiles >) DataRepository.MemberFilesProvider.DeepSave,
							new object[] { transactionManager, entity.MemberFilesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<JobApplicationNotes>
				if (CanDeepSave(entity.JobApplicationNotesCollection, "List<JobApplicationNotes>|JobApplicationNotesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(JobApplicationNotes child in entity.JobApplicationNotesCollection)
					{
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
						}

					}

					if (entity.JobApplicationNotesCollection.Count > 0 || entity.JobApplicationNotesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.JobApplicationNotesProvider.Save(transactionManager, entity.JobApplicationNotesCollection);
						
						deepHandles.Add("JobApplicationNotesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< JobApplicationNotes >) DataRepository.JobApplicationNotesProvider.DeepSave,
							new object[] { transactionManager, entity.JobApplicationNotesCollection, deepSaveType, childTypes, innerList }
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
						if(child.MemberIdSource != null)
						{
							child.MemberId = child.MemberIdSource.MemberId;
						}
						else
						{
							child.MemberId = entity.MemberId;
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
	
	#region MembersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Members</c>
	///</summary>
	public enum MembersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
			
		///<summary>
		/// Composite Property for <c>Educations</c> at EducationIdSource
		///</summary>
		[ChildEntityType(typeof(Educations))]
		Educations,
			
		///<summary>
		/// Composite Property for <c>EmailFormats</c> at EmailFormatSource
		///</summary>
		[ChildEntityType(typeof(EmailFormats))]
		EmailFormats,
			
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>Members</c> as OneToMany for JobsSavedCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobsSaved>))]
		JobsSavedCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberLanguagesCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberLanguages>))]
		MemberLanguagesCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberQualificationCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberQualification>))]
		MemberQualificationCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for JobApplicationCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplication>))]
		JobApplicationCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberReferencesCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberReferences>))]
		MemberReferencesCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberCertificateMembershipsCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberCertificateMemberships>))]
		MemberCertificateMembershipsCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberPositionsCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberPositions>))]
		MemberPositionsCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberLicensesCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberLicenses>))]
		MemberLicensesCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for MemberFilesCollection
		///</summary>
		[ChildEntityType(typeof(TList<MemberFiles>))]
		MemberFilesCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for JobApplicationNotesCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobApplicationNotes>))]
		JobApplicationNotesCollection,

		///<summary>
		/// Collection of <c>Members</c> as OneToMany for JobAlertsCollection
		///</summary>
		[ChildEntityType(typeof(TList<JobAlerts>))]
		JobAlertsCollection,
	}
	
	#endregion MembersChildEntityTypes
	
	#region MembersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MembersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersFilterBuilder : SqlFilterBuilder<MembersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersFilterBuilder class.
		/// </summary>
		public MembersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MembersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MembersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MembersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MembersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MembersFilterBuilder
	
	#region MembersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MembersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersParameterBuilder : ParameterizedSqlFilterBuilder<MembersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersParameterBuilder class.
		/// </summary>
		public MembersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MembersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MembersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MembersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MembersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MembersParameterBuilder
	
	#region MembersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MembersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MembersSortBuilder : SqlSortBuilder<MembersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersSqlSortBuilder class.
		/// </summary>
		public MembersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MembersSortBuilder
	
} // end namespace
