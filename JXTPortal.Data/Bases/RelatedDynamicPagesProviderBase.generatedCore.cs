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
	/// This class is the base class for any <see cref="RelatedDynamicPagesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RelatedDynamicPagesProviderBaseCore : EntityProviderBase<JXTPortal.Entities.RelatedDynamicPages, JXTPortal.Entities.RelatedDynamicPagesKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.RelatedDynamicPagesKey key)
		{
			return Delete(transactionManager, key.DynamicPageId, key.RelatedDynamicPageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <param name="_relatedDynamicPageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId)
		{
			return Delete(null, _dynamicPageId, _relatedDynamicPageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <param name="_relatedDynamicPageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		FK__RelatedDy__Dynam__6DAF69E3 Description: 
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByDynamicPageId(System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(_dynamicPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		FK__RelatedDy__Dynam__6DAF69E3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<RelatedDynamicPages> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		FK__RelatedDy__Dynam__6DAF69E3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		fkRelatedDyDynam6Daf69e3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		fkRelatedDyDynam6Daf69e3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength,out int count)
		{
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Dynam__6DAF69E3 key.
		///		FK__RelatedDy__Dynam__6DAF69E3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public abstract TList<RelatedDynamicPages> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		FK__RelatedDy__Relat__6EA38E1C Description: 
		/// </summary>
		/// <param name="_relatedDynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByRelatedDynamicPageId(System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByRelatedDynamicPageId(_relatedDynamicPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		FK__RelatedDy__Relat__6EA38E1C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		/// <remarks></remarks>
		public TList<RelatedDynamicPages> GetByRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByRelatedDynamicPageId(transactionManager, _relatedDynamicPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		FK__RelatedDy__Relat__6EA38E1C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _relatedDynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByRelatedDynamicPageId(transactionManager, _relatedDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		fkRelatedDyRelat6Ea38e1c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByRelatedDynamicPageId(System.Int32 _relatedDynamicPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRelatedDynamicPageId(null, _relatedDynamicPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		fkRelatedDyRelat6Ea38e1c Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public TList<RelatedDynamicPages> GetByRelatedDynamicPageId(System.Int32 _relatedDynamicPageId, int start, int pageLength,out int count)
		{
			return GetByRelatedDynamicPageId(null, _relatedDynamicPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__RelatedDy__Relat__6EA38E1C key.
		///		FK__RelatedDy__Relat__6EA38E1C Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.RelatedDynamicPages objects.</returns>
		public abstract TList<RelatedDynamicPages> GetByRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _relatedDynamicPageId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.RelatedDynamicPages Get(TransactionManager transactionManager, JXTPortal.Entities.RelatedDynamicPagesKey key, int start, int pageLength)
		{
			return GetByDynamicPageIdRelatedDynamicPageId(transactionManager, key.DynamicPageId, key.RelatedDynamicPageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageIdRelatedDynamicPageId(null,_dynamicPageId, _relatedDynamicPageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdRelatedDynamicPageId(null, _dynamicPageId, _relatedDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageIdRelatedDynamicPageId(transactionManager, _dynamicPageId, _relatedDynamicPageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdRelatedDynamicPageId(transactionManager, _dynamicPageId, _relatedDynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId, int start, int pageLength, out int count)
		{
			return GetByDynamicPageIdRelatedDynamicPageId(null, _dynamicPageId, _relatedDynamicPageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__RelatedD__5DE3F83B6AD2FD38 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_relatedDynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> class.</returns>
		public abstract JXTPortal.Entities.RelatedDynamicPages GetByDynamicPageIdRelatedDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _relatedDynamicPageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region RelatedDynamicPages_CustomGetByDynamicPageID 
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomGetByDynamicPageID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageID(System.Int32? dynamicPageId)
		{
			return CustomGetByDynamicPageID(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomGetByDynamicPageID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageID(int start, int pageLength, System.Int32? dynamicPageId)
		{
			return CustomGetByDynamicPageID(null, start, pageLength , dynamicPageId);
		}
				
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomGetByDynamicPageID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageID(TransactionManager transactionManager, System.Int32? dynamicPageId)
		{
			return CustomGetByDynamicPageID(transactionManager, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomGetByDynamicPageID' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetByDynamicPageID(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region RelatedDynamicPages_CustomModify 
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomModify' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="relatedDynamicPageList"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomModify(System.Int32? dynamicPageId, System.String relatedDynamicPageList)
		{
			 CustomModify(null, 0, int.MaxValue , dynamicPageId, relatedDynamicPageList);
		}
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomModify' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="relatedDynamicPageList"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomModify(int start, int pageLength, System.Int32? dynamicPageId, System.String relatedDynamicPageList)
		{
			 CustomModify(null, start, pageLength , dynamicPageId, relatedDynamicPageList);
		}
				
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomModify' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="relatedDynamicPageList"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomModify(TransactionManager transactionManager, System.Int32? dynamicPageId, System.String relatedDynamicPageList)
		{
			 CustomModify(transactionManager, 0, int.MaxValue , dynamicPageId, relatedDynamicPageList);
		}
		
		/// <summary>
		///	This method wrap the 'RelatedDynamicPages_CustomModify' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="relatedDynamicPageList"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomModify(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.String relatedDynamicPageList);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;RelatedDynamicPages&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;RelatedDynamicPages&gt;"/></returns>
		public static TList<RelatedDynamicPages> Fill(IDataReader reader, TList<RelatedDynamicPages> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.RelatedDynamicPages c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("RelatedDynamicPages")
					.Append("|").Append((System.Int32)reader[((int)RelatedDynamicPagesColumn.DynamicPageId - 1)])
					.Append("|").Append((System.Int32)reader[((int)RelatedDynamicPagesColumn.RelatedDynamicPageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<RelatedDynamicPages>(
					key.ToString(), // EntityTrackingKey
					"RelatedDynamicPages",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.RelatedDynamicPages();
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
					c.DynamicPageId = (System.Int32)reader[((int)RelatedDynamicPagesColumn.DynamicPageId - 1)];
					c.OriginalDynamicPageId = c.DynamicPageId;
					c.RelatedDynamicPageId = (System.Int32)reader[((int)RelatedDynamicPagesColumn.RelatedDynamicPageId - 1)];
					c.OriginalRelatedDynamicPageId = c.RelatedDynamicPageId;
					c.Sequence = (System.Int32)reader[((int)RelatedDynamicPagesColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.RelatedDynamicPages"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.RelatedDynamicPages entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageId = (System.Int32)reader[((int)RelatedDynamicPagesColumn.DynamicPageId - 1)];
			entity.OriginalDynamicPageId = (System.Int32)reader["DynamicPageID"];
			entity.RelatedDynamicPageId = (System.Int32)reader[((int)RelatedDynamicPagesColumn.RelatedDynamicPageId - 1)];
			entity.OriginalRelatedDynamicPageId = (System.Int32)reader["RelatedDynamicPageID"];
			entity.Sequence = (System.Int32)reader[((int)RelatedDynamicPagesColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.RelatedDynamicPages"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.RelatedDynamicPages"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.RelatedDynamicPages entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.OriginalDynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.RelatedDynamicPageId = (System.Int32)dataRow["RelatedDynamicPageID"];
			entity.OriginalRelatedDynamicPageId = (System.Int32)dataRow["RelatedDynamicPageID"];
			entity.Sequence = (System.Int32)dataRow["Sequence"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.RelatedDynamicPages"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.RelatedDynamicPages Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.RelatedDynamicPages entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DynamicPageIdSource	
			if (CanDeepLoad(entity, "DynamicPages|DynamicPageIdSource", deepLoadType, innerList) 
				&& entity.DynamicPageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DynamicPageId;
				DynamicPages tmpEntity = EntityManager.LocateEntity<DynamicPages>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DynamicPageIdSource = tmpEntity;
				else
					entity.DynamicPageIdSource = DataRepository.DynamicPagesProvider.GetByDynamicPageId(transactionManager, entity.DynamicPageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DynamicPageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DynamicPageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPagesProvider.DeepLoad(transactionManager, entity.DynamicPageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DynamicPageIdSource

			#region RelatedDynamicPageIdSource	
			if (CanDeepLoad(entity, "DynamicPages|RelatedDynamicPageIdSource", deepLoadType, innerList) 
				&& entity.RelatedDynamicPageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RelatedDynamicPageId;
				DynamicPages tmpEntity = EntityManager.LocateEntity<DynamicPages>(EntityLocator.ConstructKeyFromPkItems(typeof(DynamicPages), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RelatedDynamicPageIdSource = tmpEntity;
				else
					entity.RelatedDynamicPageIdSource = DataRepository.DynamicPagesProvider.GetByDynamicPageId(transactionManager, entity.RelatedDynamicPageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RelatedDynamicPageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RelatedDynamicPageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DynamicPagesProvider.DeepLoad(transactionManager, entity.RelatedDynamicPageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RelatedDynamicPageIdSource
			
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.RelatedDynamicPages object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.RelatedDynamicPages instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.RelatedDynamicPages Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.RelatedDynamicPages entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DynamicPageIdSource
			if (CanDeepSave(entity, "DynamicPages|DynamicPageIdSource", deepSaveType, innerList) 
				&& entity.DynamicPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPageIdSource);
				entity.DynamicPageId = entity.DynamicPageIdSource.DynamicPageId;
			}
			#endregion 
			
			#region RelatedDynamicPageIdSource
			if (CanDeepSave(entity, "DynamicPages|RelatedDynamicPageIdSource", deepSaveType, innerList) 
				&& entity.RelatedDynamicPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.RelatedDynamicPageIdSource);
				entity.RelatedDynamicPageId = entity.RelatedDynamicPageIdSource.DynamicPageId;
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
	
	#region RelatedDynamicPagesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.RelatedDynamicPages</c>
	///</summary>
	public enum RelatedDynamicPagesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DynamicPages</c> at DynamicPageIdSource
		///</summary>
		[ChildEntityType(typeof(DynamicPages))]
		DynamicPages,
		}
	
	#endregion RelatedDynamicPagesChildEntityTypes
	
	#region RelatedDynamicPagesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RelatedDynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedDynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedDynamicPagesFilterBuilder : SqlFilterBuilder<RelatedDynamicPagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilterBuilder class.
		/// </summary>
		public RelatedDynamicPagesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedDynamicPagesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedDynamicPagesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedDynamicPagesFilterBuilder
	
	#region RelatedDynamicPagesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RelatedDynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedDynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedDynamicPagesParameterBuilder : ParameterizedSqlFilterBuilder<RelatedDynamicPagesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesParameterBuilder class.
		/// </summary>
		public RelatedDynamicPagesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedDynamicPagesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedDynamicPagesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedDynamicPagesParameterBuilder
	
	#region RelatedDynamicPagesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;RelatedDynamicPagesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedDynamicPages"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class RelatedDynamicPagesSortBuilder : SqlSortBuilder<RelatedDynamicPagesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesSqlSortBuilder class.
		/// </summary>
		public RelatedDynamicPagesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion RelatedDynamicPagesSortBuilder
	
} // end namespace
