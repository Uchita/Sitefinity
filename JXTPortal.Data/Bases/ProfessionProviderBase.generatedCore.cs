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
	/// This class is the base class for any <see cref="ProfessionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProfessionProviderBaseCore : EntityProviderBase<JXTPortal.Entities.Profession, JXTPortal.Entities.ProfessionKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.ProfessionKey key)
		{
			return Delete(transactionManager, key.ProfessionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_professionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _professionId)
		{
			return Delete(null, _professionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _professionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		FK__Professio__Refer__64049B05 Description: 
		/// </summary>
		/// <param name="_referredSiteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		public TList<Profession> GetByReferredSiteId(System.Int32? _referredSiteId)
		{
			int count = -1;
			return GetByReferredSiteId(_referredSiteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		FK__Professio__Refer__64049B05 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referredSiteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		/// <remarks></remarks>
		public TList<Profession> GetByReferredSiteId(TransactionManager transactionManager, System.Int32? _referredSiteId)
		{
			int count = -1;
			return GetByReferredSiteId(transactionManager, _referredSiteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		FK__Professio__Refer__64049B05 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referredSiteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		public TList<Profession> GetByReferredSiteId(TransactionManager transactionManager, System.Int32? _referredSiteId, int start, int pageLength)
		{
			int count = -1;
			return GetByReferredSiteId(transactionManager, _referredSiteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		fkProfessioRefer64049b05 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_referredSiteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		public TList<Profession> GetByReferredSiteId(System.Int32? _referredSiteId, int start, int pageLength)
		{
			int count =  -1;
			return GetByReferredSiteId(null, _referredSiteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		fkProfessioRefer64049b05 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_referredSiteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		public TList<Profession> GetByReferredSiteId(System.Int32? _referredSiteId, int start, int pageLength,out int count)
		{
			return GetByReferredSiteId(null, _referredSiteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Professio__Refer__64049B05 key.
		///		FK__Professio__Refer__64049B05 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_referredSiteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.Profession objects.</returns>
		public abstract TList<Profession> GetByReferredSiteId(TransactionManager transactionManager, System.Int32? _referredSiteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.Profession Get(TransactionManager transactionManager, JXTPortal.Entities.ProfessionKey key, int start, int pageLength)
		{
			return GetByProfessionId(transactionManager, key.ProfessionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Profession__2942188C index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public JXTPortal.Entities.Profession GetByProfessionId(System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(null,_professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Profession__2942188C index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public JXTPortal.Entities.Profession GetByProfessionId(System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Profession__2942188C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public JXTPortal.Entities.Profession GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Profession__2942188C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public JXTPortal.Entities.Profession GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength)
		{
			int count = -1;
			return GetByProfessionId(transactionManager, _professionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Profession__2942188C index.
		/// </summary>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public JXTPortal.Entities.Profession GetByProfessionId(System.Int32 _professionId, int start, int pageLength, out int count)
		{
			return GetByProfessionId(null, _professionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Profession__2942188C index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_professionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.Profession"/> class.</returns>
		public abstract JXTPortal.Entities.Profession GetByProfessionId(TransactionManager transactionManager, System.Int32 _professionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region Profession_GetSiteTree 
		
		/// <summary>
		///	This method wrap the 'Profession_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(System.Int32? siteId)
		{
			return GetSiteTree(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(int start, int pageLength, System.Int32? siteId)
		{
			return GetSiteTree(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSiteTree(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetSiteTree(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_GetSiteTree' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSiteTree(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region Profession_Insert 
		
		/// <summary>
		///	This method wrap the 'Profession_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId, ref System.Int32? professionId)
		{
			 Insert(null, 0, int.MaxValue , professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId, ref professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId, ref System.Int32? professionId)
		{
			 Insert(null, start, pageLength , professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId, ref professionId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId, ref System.Int32? professionId)
		{
			 Insert(transactionManager, 0, int.MaxValue , professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId, ref professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Insert' stored procedure. 
		/// </summary>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
			/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId, ref System.Int32? professionId);
		
		#endregion
		
		#region Profession_GetByProfessionId 
		
		/// <summary>
		///	This method wrap the 'Profession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByProfessionId(System.Int32? professionId)
		{
			return GetByProfessionId(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_GetByProfessionId' stored procedure. 
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
		///	This method wrap the 'Profession_GetByProfessionId' stored procedure. 
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
		///	This method wrap the 'Profession_GetByProfessionId' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId);
		
		#endregion
		
		#region Profession_Get_List 
		
		/// <summary>
		///	This method wrap the 'Profession_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Get_List' stored procedure. 
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
		///	This method wrap the 'Profession_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region Profession_GetPaged 
		
		/// <summary>
		///	This method wrap the 'Profession_GetPaged' stored procedure. 
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
		///	This method wrap the 'Profession_GetPaged' stored procedure. 
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
		///	This method wrap the 'Profession_GetPaged' stored procedure. 
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
		///	This method wrap the 'Profession_GetPaged' stored procedure. 
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
		
		#region Profession_CustomBulkInsert 
		
		/// <summary>
		///	This method wrap the 'Profession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(null, 0, int.MaxValue , siteId, xmlText);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(int start, int pageLength, System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(null, start, pageLength , siteId, xmlText);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomBulkInsert(TransactionManager transactionManager, System.Int32? siteId, System.String xmlText)
		{
			 CustomBulkInsert(transactionManager, 0, int.MaxValue , siteId, xmlText);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_CustomBulkInsert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="xmlText"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomBulkInsert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.String xmlText);
		
		#endregion
		
		#region Profession_Find 
		
		/// <summary>
		///	This method wrap the 'Profession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			return Find(null, start, pageLength , searchUsingOr, professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId);
		
		#endregion
		
		#region Profession_Delete 
		
		/// <summary>
		///	This method wrap the 'Profession_Delete' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? professionId)
		{
			 Delete(null, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Delete' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? professionId)
		{
			 Delete(null, start, pageLength , professionId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_Delete' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? professionId)
		{
			 Delete(transactionManager, 0, int.MaxValue , professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Delete' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId);
		
		#endregion
		
		#region Profession_GetDetailWithSite 
		
		/// <summary>
		///	This method wrap the 'Profession_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(System.Int32? siteId, System.Int32? professionId)
		{
			return GetDetailWithSite(null, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(int start, int pageLength, System.Int32? siteId, System.Int32? professionId)
		{
			return GetDetailWithSite(null, start, pageLength , siteId, professionId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetDetailWithSite(TransactionManager transactionManager, System.Int32? siteId, System.Int32? professionId)
		{
			return GetDetailWithSite(transactionManager, 0, int.MaxValue , siteId, professionId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_GetDetailWithSite' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetDetailWithSite(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? professionId);
		
		#endregion
		
		#region Profession_Update 
		
		/// <summary>
		///	This method wrap the 'Profession_Update' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			 Update(null, 0, int.MaxValue , professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Update' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			 Update(null, start, pageLength , professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
				
		/// <summary>
		///	This method wrap the 'Profession_Update' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId)
		{
			 Update(transactionManager, 0, int.MaxValue , professionId, professionName, valid, metaTitle, metaKeywords, metaDescription, referredSiteId);
		}
		
		/// <summary>
		///	This method wrap the 'Profession_Update' stored procedure. 
		/// </summary>
		/// <param name="professionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="professionName"> A <c>System.String</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="metaTitle"> A <c>System.String</c> instance.</param>
		/// <param name="metaKeywords"> A <c>System.String</c> instance.</param>
		/// <param name="metaDescription"> A <c>System.String</c> instance.</param>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? professionId, System.String professionName, System.Boolean? valid, System.String metaTitle, System.String metaKeywords, System.String metaDescription, System.Int32? referredSiteId);
		
		#endregion
		
		#region Profession_GetByReferredSiteId 
		
		
		/// <summary>
		///	This method wrap the 'Profession_GetByReferredSiteId' stored procedure. 
		/// </summary>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByReferredSiteId(int start, int pageLength, System.Int32? referredSiteId)
		{
			return GetByReferredSiteId(null, start, pageLength , referredSiteId);
		}
			
		
		/// <summary>
		///	This method wrap the 'Profession_GetByReferredSiteId' stored procedure. 
		/// </summary>
		/// <param name="referredSiteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByReferredSiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? referredSiteId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Profession&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Profession&gt;"/></returns>
		public static TList<Profession> Fill(IDataReader reader, TList<Profession> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.Profession c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Profession")
					.Append("|").Append((System.Int32)reader[((int)ProfessionColumn.ProfessionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Profession>(
					key.ToString(), // EntityTrackingKey
					"Profession",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.Profession();
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
					c.ProfessionId = (System.Int32)reader[((int)ProfessionColumn.ProfessionId - 1)];
					c.ProfessionName = (System.String)reader[((int)ProfessionColumn.ProfessionName - 1)];
					c.Valid = (System.Boolean)reader[((int)ProfessionColumn.Valid - 1)];
					c.MetaTitle = (System.String)reader[((int)ProfessionColumn.MetaTitle - 1)];
					c.MetaKeywords = (System.String)reader[((int)ProfessionColumn.MetaKeywords - 1)];
					c.MetaDescription = (System.String)reader[((int)ProfessionColumn.MetaDescription - 1)];
					c.ReferredSiteId = (reader.IsDBNull(((int)ProfessionColumn.ReferredSiteId - 1)))?null:(System.Int32?)reader[((int)ProfessionColumn.ReferredSiteId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Profession"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Profession"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.Profession entity)
		{
			if (!reader.Read()) return;
			
			entity.ProfessionId = (System.Int32)reader[((int)ProfessionColumn.ProfessionId - 1)];
			entity.ProfessionName = (System.String)reader[((int)ProfessionColumn.ProfessionName - 1)];
			entity.Valid = (System.Boolean)reader[((int)ProfessionColumn.Valid - 1)];
			entity.MetaTitle = (System.String)reader[((int)ProfessionColumn.MetaTitle - 1)];
			entity.MetaKeywords = (System.String)reader[((int)ProfessionColumn.MetaKeywords - 1)];
			entity.MetaDescription = (System.String)reader[((int)ProfessionColumn.MetaDescription - 1)];
			entity.ReferredSiteId = (reader.IsDBNull(((int)ProfessionColumn.ReferredSiteId - 1)))?null:(System.Int32?)reader[((int)ProfessionColumn.ReferredSiteId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.Profession"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.Profession"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.Profession entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProfessionId = (System.Int32)dataRow["ProfessionID"];
			entity.ProfessionName = (System.String)dataRow["ProfessionName"];
			entity.Valid = (System.Boolean)dataRow["Valid"];
			entity.MetaTitle = (System.String)dataRow["MetaTitle"];
			entity.MetaKeywords = (System.String)dataRow["MetaKeywords"];
			entity.MetaDescription = (System.String)dataRow["MetaDescription"];
			entity.ReferredSiteId = Convert.IsDBNull(dataRow["ReferredSiteID"]) ? null : (System.Int32?)dataRow["ReferredSiteID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.Profession"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.Profession Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.Profession entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ReferredSiteIdSource	
			if (CanDeepLoad(entity, "Sites|ReferredSiteIdSource", deepLoadType, innerList) 
				&& entity.ReferredSiteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ReferredSiteId ?? (int)0);
				Sites tmpEntity = EntityManager.LocateEntity<Sites>(EntityLocator.ConstructKeyFromPkItems(typeof(Sites), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ReferredSiteIdSource = tmpEntity;
				else
					entity.ReferredSiteIdSource = DataRepository.SitesProvider.GetBySiteId(transactionManager, (entity.ReferredSiteId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ReferredSiteIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ReferredSiteIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SitesProvider.DeepLoad(transactionManager, entity.ReferredSiteIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ReferredSiteIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProfessionId methods when available
			
			#region RolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Roles>|RolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.RolesCollection = DataRepository.RolesProvider.GetByProfessionId(transactionManager, entity.ProfessionId);

				if (deep && entity.RolesCollection.Count > 0)
				{
					deepHandles.Add("RolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Roles>) DataRepository.RolesProvider.DeepLoad,
						new object[] { transactionManager, entity.RolesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.SiteProfessionCollection = DataRepository.SiteProfessionProvider.GetByProfessionId(transactionManager, entity.ProfessionId);

				if (deep && entity.SiteProfessionCollection.Count > 0)
				{
					deepHandles.Add("SiteProfessionCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SiteProfession>) DataRepository.SiteProfessionProvider.DeepLoad,
						new object[] { transactionManager, entity.SiteProfessionCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.WidgetContainersCollection = DataRepository.WidgetContainersProvider.GetByDefaultProfessionId(transactionManager, entity.ProfessionId);

				if (deep && entity.WidgetContainersCollection.Count > 0)
				{
					deepHandles.Add("WidgetContainersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<WidgetContainers>) DataRepository.WidgetContainersProvider.DeepLoad,
						new object[] { transactionManager, entity.WidgetContainersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.Profession object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.Profession instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.Profession Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.Profession entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ReferredSiteIdSource
			if (CanDeepSave(entity, "Sites|ReferredSiteIdSource", deepSaveType, innerList) 
				&& entity.ReferredSiteIdSource != null)
			{
				DataRepository.SitesProvider.Save(transactionManager, entity.ReferredSiteIdSource);
				entity.ReferredSiteId = entity.ReferredSiteIdSource.SiteId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Roles>
				if (CanDeepSave(entity.RolesCollection, "List<Roles>|RolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Roles child in entity.RolesCollection)
					{
						if(child.ProfessionIdSource != null)
						{
							child.ProfessionId = child.ProfessionIdSource.ProfessionId;
						}
						else
						{
							child.ProfessionId = entity.ProfessionId;
						}

					}

					if (entity.RolesCollection.Count > 0 || entity.RolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.RolesProvider.Save(transactionManager, entity.RolesCollection);
						
						deepHandles.Add("RolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Roles >) DataRepository.RolesProvider.DeepSave,
							new object[] { transactionManager, entity.RolesCollection, deepSaveType, childTypes, innerList }
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
						if(child.ProfessionIdSource != null)
						{
							child.ProfessionId = child.ProfessionIdSource.ProfessionId;
						}
						else
						{
							child.ProfessionId = entity.ProfessionId;
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
				
	
			#region List<WidgetContainers>
				if (CanDeepSave(entity.WidgetContainersCollection, "List<WidgetContainers>|WidgetContainersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(WidgetContainers child in entity.WidgetContainersCollection)
					{
						if(child.DefaultProfessionIdSource != null)
						{
							child.DefaultProfessionId = child.DefaultProfessionIdSource.ProfessionId;
						}
						else
						{
							child.DefaultProfessionId = entity.ProfessionId;
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
	
	#region ProfessionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.Profession</c>
	///</summary>
	public enum ProfessionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at ReferredSiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
	
		///<summary>
		/// Collection of <c>Profession</c> as OneToMany for RolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Roles>))]
		RolesCollection,

		///<summary>
		/// Collection of <c>Profession</c> as OneToMany for SiteProfessionCollection
		///</summary>
		[ChildEntityType(typeof(TList<SiteProfession>))]
		SiteProfessionCollection,

		///<summary>
		/// Collection of <c>Profession</c> as OneToMany for WidgetContainersCollection
		///</summary>
		[ChildEntityType(typeof(TList<WidgetContainers>))]
		WidgetContainersCollection,
	}
	
	#endregion ProfessionChildEntityTypes
	
	#region ProfessionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionFilterBuilder : SqlFilterBuilder<ProfessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionFilterBuilder class.
		/// </summary>
		public ProfessionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfessionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfessionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfessionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfessionFilterBuilder
	
	#region ProfessionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionParameterBuilder : ParameterizedSqlFilterBuilder<ProfessionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionParameterBuilder class.
		/// </summary>
		public ProfessionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfessionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfessionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfessionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfessionParameterBuilder
	
	#region ProfessionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProfessionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProfessionSortBuilder : SqlSortBuilder<ProfessionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionSqlSortBuilder class.
		/// </summary>
		public ProfessionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProfessionSortBuilder
	
} // end namespace
