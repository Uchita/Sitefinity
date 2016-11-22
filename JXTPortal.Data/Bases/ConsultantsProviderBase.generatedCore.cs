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
	/// This class is the base class for any <see cref="ConsultantsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ConsultantsProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Consultants, JXTPortal.Entities.ConsultantsKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ConsultantsKey key)
		{
			return Delete(transactionManager, key.ConsultantId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_consultantId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _consultantId)
		{
			return Delete(null, _consultantId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_consultantId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _consultantId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		FK__Consultan__SiteI__777D1EBE Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		public TList<Consultants> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		FK__Consultan__SiteI__777D1EBE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		/// <remarks></remarks>
		public TList<Consultants> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		FK__Consultan__SiteI__777D1EBE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		public TList<Consultants> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		fkConsultanSitei777d1Ebe Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		public TList<Consultants> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		fkConsultanSitei777d1Ebe Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		public TList<Consultants> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Consultan__SiteI__777D1EBE key.
		///		FK__Consultan__SiteI__777D1EBE Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Consultants objects.</returns>
		public abstract TList<Consultants> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Consultants Get(TransactionManager transactionManager, JXTPortal.Entities.ConsultantsKey key, int start, int pageLength)
		{
			return GetByConsultantId(transactionManager, key.ConsultantId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="_consultantId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public JXTPortal.Entities.Consultants GetByConsultantId(System.Int32 _consultantId)
		{
			int count = -1;
			return GetByConsultantId(null,_consultantId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="_consultantId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public JXTPortal.Entities.Consultants GetByConsultantId(System.Int32 _consultantId, int start, int pageLength)
		{
			int count = -1;
			return GetByConsultantId(null, _consultantId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_consultantId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public JXTPortal.Entities.Consultants GetByConsultantId(TransactionManager transactionManager, System.Int32 _consultantId)
		{
			int count = -1;
			return GetByConsultantId(transactionManager, _consultantId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_consultantId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public JXTPortal.Entities.Consultants GetByConsultantId(TransactionManager transactionManager, System.Int32 _consultantId, int start, int pageLength)
		{
			int count = -1;
			return GetByConsultantId(transactionManager, _consultantId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="_consultantId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public JXTPortal.Entities.Consultants GetByConsultantId(System.Int32 _consultantId, int start, int pageLength, out int count)
		{
			return GetByConsultantId(null, _consultantId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Consulta__E5B83F397594D64C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_consultantId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Consultants"/> class.</returns>
		public abstract JXTPortal.Entities.Consultants GetByConsultantId(TransactionManager transactionManager, System.Int32 _consultantId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Consultants_Insert 
		
		/// <summary>
		///	This method wrap the 'Consultants_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
			/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl, ref System.Int32? consultantId)
		{
			 Insert(null, 0, int.MaxValue , siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl, ref consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
			/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl, ref System.Int32? consultantId)
		{
			 Insert(null, start, pageLength , siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl, ref consultantId);
		}
				
		/// <summary>
		///	This method wrap the 'Consultants_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
			/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl, ref System.Int32? consultantId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl, ref consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
			/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl, ref System.Int32? consultantId);
		
		#endregion
		
		#region Consultants_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'Consultants_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Consultants_GetBySiteId' stored procedure. 
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
		///	This method wrap the 'Consultants_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Consultants_Get_List 
		
		/// <summary>
		///	This method wrap the 'Consultants_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Get_List' stored procedure. 
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
		///	This method wrap the 'Consultants_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Consultants_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Consultants_GetPaged' stored procedure. 
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
		///	This method wrap the 'Consultants_GetPaged' stored procedure. 
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
		///	This method wrap the 'Consultants_GetPaged' stored procedure. 
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
		///	This method wrap the 'Consultants_GetPaged' stored procedure. 
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
		
		#region Consultants_GetByConsultantId 
		
		/// <summary>
		///	This method wrap the 'Consultants_GetByConsultantId' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByConsultantId(System.Int32? consultantId)
		{
			return GetByConsultantId(null, 0, int.MaxValue , consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_GetByConsultantId' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByConsultantId(int start, int pageLength, System.Int32? consultantId)
		{
			return GetByConsultantId(null, start, pageLength , consultantId);
		}
				
		/// <summary>
		///	This method wrap the 'Consultants_GetByConsultantId' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByConsultantId(TransactionManager transactionManager, System.Int32? consultantId)
		{
			return GetByConsultantId(transactionManager, 0, int.MaxValue , consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_GetByConsultantId' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByConsultantId(TransactionManager transactionManager, int start, int pageLength , System.Int32? consultantId);
		
		#endregion
		
		#region Consultants_Find 
		
		/// <summary>
		///	This method wrap the 'Consultants_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			return Find(null, start, pageLength , searchUsingOr, consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Consultants_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl);
		
		#endregion
		
		#region Consultants_Delete 
		
		/// <summary>
		///	This method wrap the 'Consultants_Delete' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? consultantId)
		{
			 Delete(null, 0, int.MaxValue , consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Delete' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? consultantId)
		{
			 Delete(null, start, pageLength , consultantId);
		}
				
		/// <summary>
		///	This method wrap the 'Consultants_Delete' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? consultantId)
		{
			 Delete(transactionManager, 0, int.MaxValue , consultantId);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Delete' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? consultantId);
		
		#endregion
		
		#region Consultants_Update 
		
		/// <summary>
		///	This method wrap the 'Consultants_Update' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			 Update(null, 0, int.MaxValue , consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Update' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			 Update(null, start, pageLength , consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
				
		/// <summary>
		///	This method wrap the 'Consultants_Update' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl)
		{
			 Update(transactionManager, 0, int.MaxValue , consultantId, siteId, languageId, title, firstName, email, phone, mobile, positionTitle, officeLocation, categories, location, friendlyUrl, shortDescription, testimonial, fullDescription, consultantData, linkedInUrl, twitterUrl, facebookUrl, googleUrl, link, wechatUrl, featuredTeamMember, imageUrl, videoUrl, blogRss, newsRss, jobRss, testimonialsRss, valid, metaTitle, metaDescription, metaKeywords, lastModifiedBy, lastModified, sequence, lastName, consultantsXml, consultantImageUrl);
		}
		
		/// <summary>
		///	This method wrap the 'Consultants_Update' stored procedure. 
		/// </summary>
		/// <param name="consultantId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="title"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="email"> A <c>System.String</c> instance.</param>
		/// <param name="phone"> A <c>System.String</c> instance.</param>
		/// <param name="mobile"> A <c>System.String</c> instance.</param>
		/// <param name="positionTitle"> A <c>System.String</c> instance.</param>
		/// <param name="officeLocation"> A <c>System.String</c> instance.</param>
		/// <param name="categories"> A <c>System.String</c> instance.</param>
		/// <param name="location"> A <c>System.String</c> instance.</param>
		/// <param name="friendlyUrl"> A <c>System.String</c> instance.</param>
		/// <param name="shortDescription"> A <c>System.String</c> instance.</param>
		/// <param name="testimonial"> A <c>System.String</c> instance.</param>
		/// <param name="fullDescription"> A <c>System.String</c> instance.</param>
		/// <param name="consultantData"> A <c>System.String</c> instance.</param>
		/// <param name="linkedInUrl"> A <c>System.String</c> instance.</param>
		/// <param name="twitterUrl"> A <c>System.String</c> instance.</param>
		/// <param name="facebookUrl"> A <c>System.String</c> instance.</param>
		/// <param name="googleUrl"> A <c>System.String</c> instance.</param>
		/// <param name="link"> A <c>System.String</c> instance.</param>
		/// <param name="wechatUrl"> A <c>System.String</c> instance.</param>
		/// <param name="featuredTeamMember"> A <c>System.Int32?</c> instance.</param>
		/// <param name="imageUrl"> A <c>System.Byte[]</c> instance.</param>
		/// <param name="videoUrl"> A <c>System.String</c> instance.</param>
		/// <param name="blogRss"> A <c>System.String</c> instance.</param>
		/// <param name="newsRss"> A <c>System.String</c> instance.</param>
		/// <param name="jobRss"> A <c>System.String</c> instance.</param>
		/// <param name="testimonialsRss"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Int32?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="lastModifiedBy"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastModified"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="consultantsXml"> A <c>System.String</c> instance.</param>
		/// <param name="consultantImageUrl"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? consultantId, System.Int32? siteId, System.Int32? languageId, System.String title, System.String firstName, System.String email, System.String phone, System.String mobile, System.String positionTitle, System.String officeLocation, System.String categories, System.String location, System.String friendlyUrl, System.String shortDescription, System.String testimonial, System.String fullDescription, System.String consultantData, System.String linkedInUrl, System.String twitterUrl, System.String facebookUrl, System.String googleUrl, System.String link, System.String wechatUrl, System.Int32? featuredTeamMember, System.Byte[] imageUrl, System.String videoUrl, System.String blogRss, System.String newsRss, System.String jobRss, System.String testimonialsRss, System.Int32? valid, System.String metaTitle, System.String metaDescription, System.String metaKeywords, System.Int32? lastModifiedBy, System.DateTime? lastModified, System.Int32? sequence, System.String lastName, System.String consultantsXml, System.String consultantImageUrl);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Consultants&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Consultants&gt;"/></returns>
		public static TList<Consultants> Fill(IDataReader reader, TList<Consultants> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Consultants c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Consultants")
					.Append("|").Append((System.Int32)reader[((int)ConsultantsColumn.ConsultantId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Consultants>(
					key.ToString(), // EntityTrackingKey
					"Consultants",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Consultants();
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
					c.ConsultantId = (System.Int32)reader[((int)ConsultantsColumn.ConsultantId - 1)];
					c.SiteId = (System.Int32)reader[((int)ConsultantsColumn.SiteId - 1)];
					c.LanguageId = (reader.IsDBNull(((int)ConsultantsColumn.LanguageId - 1)))?null:(System.Int32?)reader[((int)ConsultantsColumn.LanguageId - 1)];
					c.Title = (reader.IsDBNull(((int)ConsultantsColumn.Title - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Title - 1)];
					c.FirstName = (reader.IsDBNull(((int)ConsultantsColumn.FirstName - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FirstName - 1)];
					c.Email = (reader.IsDBNull(((int)ConsultantsColumn.Email - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Email - 1)];
					c.Phone = (reader.IsDBNull(((int)ConsultantsColumn.Phone - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Phone - 1)];
					c.Mobile = (reader.IsDBNull(((int)ConsultantsColumn.Mobile - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Mobile - 1)];
					c.PositionTitle = (reader.IsDBNull(((int)ConsultantsColumn.PositionTitle - 1)))?null:(System.String)reader[((int)ConsultantsColumn.PositionTitle - 1)];
					c.OfficeLocation = (reader.IsDBNull(((int)ConsultantsColumn.OfficeLocation - 1)))?null:(System.String)reader[((int)ConsultantsColumn.OfficeLocation - 1)];
					c.Categories = (reader.IsDBNull(((int)ConsultantsColumn.Categories - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Categories - 1)];
					c.Location = (reader.IsDBNull(((int)ConsultantsColumn.Location - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Location - 1)];
					c.FriendlyUrl = (reader.IsDBNull(((int)ConsultantsColumn.FriendlyUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FriendlyUrl - 1)];
					c.ShortDescription = (reader.IsDBNull(((int)ConsultantsColumn.ShortDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ShortDescription - 1)];
					c.Testimonial = (reader.IsDBNull(((int)ConsultantsColumn.Testimonial - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Testimonial - 1)];
					c.FullDescription = (reader.IsDBNull(((int)ConsultantsColumn.FullDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FullDescription - 1)];
					c.ConsultantData = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantData - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantData - 1)];
					c.LinkedInUrl = (reader.IsDBNull(((int)ConsultantsColumn.LinkedInUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.LinkedInUrl - 1)];
					c.TwitterUrl = (reader.IsDBNull(((int)ConsultantsColumn.TwitterUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.TwitterUrl - 1)];
					c.FacebookUrl = (reader.IsDBNull(((int)ConsultantsColumn.FacebookUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FacebookUrl - 1)];
					c.GoogleUrl = (reader.IsDBNull(((int)ConsultantsColumn.GoogleUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.GoogleUrl - 1)];
					c.Link = (reader.IsDBNull(((int)ConsultantsColumn.Link - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Link - 1)];
					c.WechatUrl = (reader.IsDBNull(((int)ConsultantsColumn.WechatUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.WechatUrl - 1)];
					c.FeaturedTeamMember = (System.Int32)reader[((int)ConsultantsColumn.FeaturedTeamMember - 1)];
					c.ImageUrl = (reader.IsDBNull(((int)ConsultantsColumn.ImageUrl - 1)))?null:(System.Byte[])reader[((int)ConsultantsColumn.ImageUrl - 1)];
					c.VideoUrl = (reader.IsDBNull(((int)ConsultantsColumn.VideoUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.VideoUrl - 1)];
					c.BlogRss = (reader.IsDBNull(((int)ConsultantsColumn.BlogRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.BlogRss - 1)];
					c.NewsRss = (reader.IsDBNull(((int)ConsultantsColumn.NewsRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.NewsRss - 1)];
					c.JobRss = (reader.IsDBNull(((int)ConsultantsColumn.JobRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.JobRss - 1)];
					c.TestimonialsRss = (reader.IsDBNull(((int)ConsultantsColumn.TestimonialsRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.TestimonialsRss - 1)];
					c.Valid = (System.Int32)reader[((int)ConsultantsColumn.Valid - 1)];
					c.MetaTitle = (reader.IsDBNull(((int)ConsultantsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaTitle - 1)];
					c.MetaDescription = (reader.IsDBNull(((int)ConsultantsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaDescription - 1)];
					c.MetaKeywords = (reader.IsDBNull(((int)ConsultantsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaKeywords - 1)];
					c.LastModifiedBy = (reader.IsDBNull(((int)ConsultantsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ConsultantsColumn.LastModifiedBy - 1)];
					c.LastModified = (reader.IsDBNull(((int)ConsultantsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ConsultantsColumn.LastModified - 1)];
					c.Sequence = (System.Int32)reader[((int)ConsultantsColumn.Sequence - 1)];
					c.LastName = (reader.IsDBNull(((int)ConsultantsColumn.LastName - 1)))?null:(System.String)reader[((int)ConsultantsColumn.LastName - 1)];
					c.ConsultantsXml = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantsXml - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantsXml - 1)];
					c.ConsultantImageUrl = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantImageUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantImageUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Consultants"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Consultants"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Consultants entity)
		{
			if (!reader.Read()) return;
			
			entity.ConsultantId = (System.Int32)reader[((int)ConsultantsColumn.ConsultantId - 1)];
			entity.SiteId = (System.Int32)reader[((int)ConsultantsColumn.SiteId - 1)];
			entity.LanguageId = (reader.IsDBNull(((int)ConsultantsColumn.LanguageId - 1)))?null:(System.Int32?)reader[((int)ConsultantsColumn.LanguageId - 1)];
			entity.Title = (reader.IsDBNull(((int)ConsultantsColumn.Title - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Title - 1)];
			entity.FirstName = (reader.IsDBNull(((int)ConsultantsColumn.FirstName - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FirstName - 1)];
			entity.Email = (reader.IsDBNull(((int)ConsultantsColumn.Email - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Email - 1)];
			entity.Phone = (reader.IsDBNull(((int)ConsultantsColumn.Phone - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Phone - 1)];
			entity.Mobile = (reader.IsDBNull(((int)ConsultantsColumn.Mobile - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Mobile - 1)];
			entity.PositionTitle = (reader.IsDBNull(((int)ConsultantsColumn.PositionTitle - 1)))?null:(System.String)reader[((int)ConsultantsColumn.PositionTitle - 1)];
			entity.OfficeLocation = (reader.IsDBNull(((int)ConsultantsColumn.OfficeLocation - 1)))?null:(System.String)reader[((int)ConsultantsColumn.OfficeLocation - 1)];
			entity.Categories = (reader.IsDBNull(((int)ConsultantsColumn.Categories - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Categories - 1)];
			entity.Location = (reader.IsDBNull(((int)ConsultantsColumn.Location - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Location - 1)];
			entity.FriendlyUrl = (reader.IsDBNull(((int)ConsultantsColumn.FriendlyUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FriendlyUrl - 1)];
			entity.ShortDescription = (reader.IsDBNull(((int)ConsultantsColumn.ShortDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ShortDescription - 1)];
			entity.Testimonial = (reader.IsDBNull(((int)ConsultantsColumn.Testimonial - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Testimonial - 1)];
			entity.FullDescription = (reader.IsDBNull(((int)ConsultantsColumn.FullDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FullDescription - 1)];
			entity.ConsultantData = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantData - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantData - 1)];
			entity.LinkedInUrl = (reader.IsDBNull(((int)ConsultantsColumn.LinkedInUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.LinkedInUrl - 1)];
			entity.TwitterUrl = (reader.IsDBNull(((int)ConsultantsColumn.TwitterUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.TwitterUrl - 1)];
			entity.FacebookUrl = (reader.IsDBNull(((int)ConsultantsColumn.FacebookUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.FacebookUrl - 1)];
			entity.GoogleUrl = (reader.IsDBNull(((int)ConsultantsColumn.GoogleUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.GoogleUrl - 1)];
			entity.Link = (reader.IsDBNull(((int)ConsultantsColumn.Link - 1)))?null:(System.String)reader[((int)ConsultantsColumn.Link - 1)];
			entity.WechatUrl = (reader.IsDBNull(((int)ConsultantsColumn.WechatUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.WechatUrl - 1)];
			entity.FeaturedTeamMember = (System.Int32)reader[((int)ConsultantsColumn.FeaturedTeamMember - 1)];
			entity.ImageUrl = (reader.IsDBNull(((int)ConsultantsColumn.ImageUrl - 1)))?null:(System.Byte[])reader[((int)ConsultantsColumn.ImageUrl - 1)];
			entity.VideoUrl = (reader.IsDBNull(((int)ConsultantsColumn.VideoUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.VideoUrl - 1)];
			entity.BlogRss = (reader.IsDBNull(((int)ConsultantsColumn.BlogRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.BlogRss - 1)];
			entity.NewsRss = (reader.IsDBNull(((int)ConsultantsColumn.NewsRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.NewsRss - 1)];
			entity.JobRss = (reader.IsDBNull(((int)ConsultantsColumn.JobRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.JobRss - 1)];
			entity.TestimonialsRss = (reader.IsDBNull(((int)ConsultantsColumn.TestimonialsRss - 1)))?null:(System.String)reader[((int)ConsultantsColumn.TestimonialsRss - 1)];
			entity.Valid = (System.Int32)reader[((int)ConsultantsColumn.Valid - 1)];
			entity.MetaTitle = (reader.IsDBNull(((int)ConsultantsColumn.MetaTitle - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaTitle - 1)];
			entity.MetaDescription = (reader.IsDBNull(((int)ConsultantsColumn.MetaDescription - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaDescription - 1)];
			entity.MetaKeywords = (reader.IsDBNull(((int)ConsultantsColumn.MetaKeywords - 1)))?null:(System.String)reader[((int)ConsultantsColumn.MetaKeywords - 1)];
			entity.LastModifiedBy = (reader.IsDBNull(((int)ConsultantsColumn.LastModifiedBy - 1)))?null:(System.Int32?)reader[((int)ConsultantsColumn.LastModifiedBy - 1)];
			entity.LastModified = (reader.IsDBNull(((int)ConsultantsColumn.LastModified - 1)))?null:(System.DateTime?)reader[((int)ConsultantsColumn.LastModified - 1)];
			entity.Sequence = (System.Int32)reader[((int)ConsultantsColumn.Sequence - 1)];
			entity.LastName = (reader.IsDBNull(((int)ConsultantsColumn.LastName - 1)))?null:(System.String)reader[((int)ConsultantsColumn.LastName - 1)];
			entity.ConsultantsXml = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantsXml - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantsXml - 1)];
			entity.ConsultantImageUrl = (reader.IsDBNull(((int)ConsultantsColumn.ConsultantImageUrl - 1)))?null:(System.String)reader[((int)ConsultantsColumn.ConsultantImageUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Consultants"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Consultants"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Consultants entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ConsultantId = (System.Int32)dataRow["ConsultantID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = Convert.IsDBNull(dataRow["LanguageID"]) ? null : (System.Int32?)dataRow["LanguageID"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
			entity.PositionTitle = Convert.IsDBNull(dataRow["PositionTitle"]) ? null : (System.String)dataRow["PositionTitle"];
			entity.OfficeLocation = Convert.IsDBNull(dataRow["OfficeLocation"]) ? null : (System.String)dataRow["OfficeLocation"];
			entity.Categories = Convert.IsDBNull(dataRow["Categories"]) ? null : (System.String)dataRow["Categories"];
			entity.Location = Convert.IsDBNull(dataRow["Location"]) ? null : (System.String)dataRow["Location"];
			entity.FriendlyUrl = Convert.IsDBNull(dataRow["FriendlyURL"]) ? null : (System.String)dataRow["FriendlyURL"];
			entity.ShortDescription = Convert.IsDBNull(dataRow["ShortDescription"]) ? null : (System.String)dataRow["ShortDescription"];
			entity.Testimonial = Convert.IsDBNull(dataRow["Testimonial"]) ? null : (System.String)dataRow["Testimonial"];
			entity.FullDescription = Convert.IsDBNull(dataRow["FullDescription"]) ? null : (System.String)dataRow["FullDescription"];
			entity.ConsultantData = Convert.IsDBNull(dataRow["ConsultantData"]) ? null : (System.String)dataRow["ConsultantData"];
			entity.LinkedInUrl = Convert.IsDBNull(dataRow["LinkedInURL"]) ? null : (System.String)dataRow["LinkedInURL"];
			entity.TwitterUrl = Convert.IsDBNull(dataRow["TwitterURL"]) ? null : (System.String)dataRow["TwitterURL"];
			entity.FacebookUrl = Convert.IsDBNull(dataRow["FacebookURL"]) ? null : (System.String)dataRow["FacebookURL"];
			entity.GoogleUrl = Convert.IsDBNull(dataRow["GoogleURL"]) ? null : (System.String)dataRow["GoogleURL"];
			entity.Link = Convert.IsDBNull(dataRow["Link"]) ? null : (System.String)dataRow["Link"];
			entity.WechatUrl = Convert.IsDBNull(dataRow["WechatURL"]) ? null : (System.String)dataRow["WechatURL"];
			entity.FeaturedTeamMember = (System.Int32)dataRow["FeaturedTeamMember"];
			entity.ImageUrl = Convert.IsDBNull(dataRow["ImageURL"]) ? null : (System.Byte[])dataRow["ImageURL"];
			entity.VideoUrl = Convert.IsDBNull(dataRow["VideoURL"]) ? null : (System.String)dataRow["VideoURL"];
			entity.BlogRss = Convert.IsDBNull(dataRow["BlogRSS"]) ? null : (System.String)dataRow["BlogRSS"];
			entity.NewsRss = Convert.IsDBNull(dataRow["NewsRSS"]) ? null : (System.String)dataRow["NewsRSS"];
			entity.JobRss = Convert.IsDBNull(dataRow["JobRSS"]) ? null : (System.String)dataRow["JobRSS"];
			entity.TestimonialsRss = Convert.IsDBNull(dataRow["TestimonialsRSS"]) ? null : (System.String)dataRow["TestimonialsRSS"];
			entity.Valid = (System.Int32)dataRow["Valid"];
			entity.MetaTitle = Convert.IsDBNull(dataRow["MetaTitle"]) ? null : (System.String)dataRow["MetaTitle"];
			entity.MetaDescription = Convert.IsDBNull(dataRow["MetaDescription"]) ? null : (System.String)dataRow["MetaDescription"];
			entity.MetaKeywords = Convert.IsDBNull(dataRow["MetaKeywords"]) ? null : (System.String)dataRow["MetaKeywords"];
			entity.LastModifiedBy = Convert.IsDBNull(dataRow["LastModifiedBy"]) ? null : (System.Int32?)dataRow["LastModifiedBy"];
			entity.LastModified = Convert.IsDBNull(dataRow["LastModified"]) ? null : (System.DateTime?)dataRow["LastModified"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
			entity.LastName = Convert.IsDBNull(dataRow["LastName"]) ? null : (System.String)dataRow["LastName"];
			entity.ConsultantsXml = Convert.IsDBNull(dataRow["ConsultantsXML"]) ? null : (System.String)dataRow["ConsultantsXML"];
			entity.ConsultantImageUrl = Convert.IsDBNull(dataRow["ConsultantImageUrl"]) ? null : (System.String)dataRow["ConsultantImageUrl"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Consultants"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Consultants Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Consultants entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Consultants object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Consultants instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Consultants Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Consultants entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ConsultantsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Consultants</c>
	///</summary>
	public enum ConsultantsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion ConsultantsChildEntityTypes
	
	#region ConsultantsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ConsultantsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Consultants"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConsultantsFilterBuilder : SqlFilterBuilder<ConsultantsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilterBuilder class.
		/// </summary>
		public ConsultantsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConsultantsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConsultantsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConsultantsFilterBuilder
	
	#region ConsultantsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ConsultantsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Consultants"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConsultantsParameterBuilder : ParameterizedSqlFilterBuilder<ConsultantsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConsultantsParameterBuilder class.
		/// </summary>
		public ConsultantsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConsultantsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConsultantsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConsultantsParameterBuilder
	
	#region ConsultantsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ConsultantsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Consultants"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ConsultantsSortBuilder : SqlSortBuilder<ConsultantsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConsultantsSqlSortBuilder class.
		/// </summary>
		public ConsultantsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ConsultantsSortBuilder
	
} // end namespace
