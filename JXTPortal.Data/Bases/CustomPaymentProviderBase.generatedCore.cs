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
	/// This class is the base class for any <see cref="CustomPaymentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomPaymentProviderBaseCore : EntityProviderBase<JXTPortal.Entities.CustomPayment, JXTPortal.Entities.CustomPaymentKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.CustomPaymentKey key)
		{
			return Delete(transactionManager, key.CustomPaymentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customPaymentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customPaymentId)
		{
			return Delete(null, _customPaymentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customPaymentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customPaymentId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		FK_CustomPayment_Sites Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		public TList<CustomPayment> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		FK_CustomPayment_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		/// <remarks></remarks>
		public TList<CustomPayment> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		FK_CustomPayment_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		public TList<CustomPayment> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		fkCustomPaymentSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		public TList<CustomPayment> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		fkCustomPaymentSites Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		public TList<CustomPayment> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomPayment_Sites key.
		///		FK_CustomPayment_Sites Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.CustomPayment objects.</returns>
		public abstract TList<CustomPayment> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.CustomPayment Get(TransactionManager transactionManager, JXTPortal.Entities.CustomPaymentKey key, int start, int pageLength)
		{
			return GetByCustomPaymentId(transactionManager, key.CustomPaymentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomPayment index.
		/// </summary>
		/// <param name="_customPaymentId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public JXTPortal.Entities.CustomPayment GetByCustomPaymentId(System.Int32 _customPaymentId)
		{
			int count = -1;
			return GetByCustomPaymentId(null,_customPaymentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomPayment index.
		/// </summary>
		/// <param name="_customPaymentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public JXTPortal.Entities.CustomPayment GetByCustomPaymentId(System.Int32 _customPaymentId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomPaymentId(null, _customPaymentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomPayment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customPaymentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public JXTPortal.Entities.CustomPayment GetByCustomPaymentId(TransactionManager transactionManager, System.Int32 _customPaymentId)
		{
			int count = -1;
			return GetByCustomPaymentId(transactionManager, _customPaymentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomPayment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customPaymentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public JXTPortal.Entities.CustomPayment GetByCustomPaymentId(TransactionManager transactionManager, System.Int32 _customPaymentId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomPaymentId(transactionManager, _customPaymentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomPayment index.
		/// </summary>
		/// <param name="_customPaymentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public JXTPortal.Entities.CustomPayment GetByCustomPaymentId(System.Int32 _customPaymentId, int start, int pageLength, out int count)
		{
			return GetByCustomPaymentId(null, _customPaymentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomPayment index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customPaymentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.CustomPayment"/> class.</returns>
		public abstract JXTPortal.Entities.CustomPayment GetByCustomPaymentId(TransactionManager transactionManager, System.Int32 _customPaymentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region CustomPayment_CustomGetOrderDetails 
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetOrderDetails' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="paymentType"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetOrderDetails(System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? isPaid, System.String paymentType, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 CustomGetOrderDetails(null, 0, int.MaxValue , siteId, dateFrom, dateTo, isPaid, paymentType, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetOrderDetails' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="paymentType"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetOrderDetails(int start, int pageLength, System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? isPaid, System.String paymentType, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 CustomGetOrderDetails(null, start, pageLength , siteId, dateFrom, dateTo, isPaid, paymentType, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetOrderDetails' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="paymentType"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomGetOrderDetails(TransactionManager transactionManager, System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? isPaid, System.String paymentType, System.Int32? pageIndex, System.Int32? pageSize)
		{
			 CustomGetOrderDetails(transactionManager, 0, int.MaxValue , siteId, dateFrom, dateTo, isPaid, paymentType, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetOrderDetails' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="dateFrom"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="dateTo"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="isPaid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="paymentType"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomGetOrderDetails(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.DateTime? dateFrom, System.DateTime? dateTo, System.Boolean? isPaid, System.String paymentType, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region CustomPayment_CustomGetByGuid 
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetByGuid' stored procedure. 
		/// </summary>
		/// <param name="customPaymentGuid"> A <c>System.Guid?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByGuid(System.Guid? customPaymentGuid)
		{
			return CustomGetByGuid(null, 0, int.MaxValue , customPaymentGuid);
		}
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetByGuid' stored procedure. 
		/// </summary>
		/// <param name="customPaymentGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByGuid(int start, int pageLength, System.Guid? customPaymentGuid)
		{
			return CustomGetByGuid(null, start, pageLength , customPaymentGuid);
		}
				
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetByGuid' stored procedure. 
		/// </summary>
		/// <param name="customPaymentGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByGuid(TransactionManager transactionManager, System.Guid? customPaymentGuid)
		{
			return CustomGetByGuid(transactionManager, 0, int.MaxValue , customPaymentGuid);
		}
		
		/// <summary>
		///	This method wrap the 'CustomPayment_CustomGetByGuid' stored procedure. 
		/// </summary>
		/// <param name="customPaymentGuid"> A <c>System.Guid?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetByGuid(TransactionManager transactionManager, int start, int pageLength , System.Guid? customPaymentGuid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomPayment&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomPayment&gt;"/></returns>
		public static TList<CustomPayment> Fill(IDataReader reader, TList<CustomPayment> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.CustomPayment c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomPayment")
					.Append("|").Append((System.Int32)reader[((int)CustomPaymentColumn.CustomPaymentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomPayment>(
					key.ToString(), // EntityTrackingKey
					"CustomPayment",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.CustomPayment();
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
					c.CustomPaymentId = (System.Int32)reader[((int)CustomPaymentColumn.CustomPaymentId - 1)];
					c.CustomPaymentGuid = (System.Guid)reader[((int)CustomPaymentColumn.CustomPaymentGuid - 1)];
					c.Name = (System.String)reader[((int)CustomPaymentColumn.Name - 1)];
					c.EmailAddress = (System.String)reader[((int)CustomPaymentColumn.EmailAddress - 1)];
					c.InvoiceNumber = (System.String)reader[((int)CustomPaymentColumn.InvoiceNumber - 1)];
					c.Amount = (System.Decimal)reader[((int)CustomPaymentColumn.Amount - 1)];
					c.Comments = (reader.IsDBNull(((int)CustomPaymentColumn.Comments - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.Comments - 1)];
					c.CreatedDate = (System.DateTime)reader[((int)CustomPaymentColumn.CreatedDate - 1)];
					c.IpAddress = (reader.IsDBNull(((int)CustomPaymentColumn.IpAddress - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.IpAddress - 1)];
					c.Response = (reader.IsDBNull(((int)CustomPaymentColumn.Response - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.Response - 1)];
					c.SecurePay = (System.Boolean)reader[((int)CustomPaymentColumn.SecurePay - 1)];
					c.Paypal = (System.Boolean)reader[((int)CustomPaymentColumn.Paypal - 1)];
					c.Paid = (System.Boolean)reader[((int)CustomPaymentColumn.Paid - 1)];
					c.PaymentNameOnCard = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentNameOnCard - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentNameOnCard - 1)];
					c.PaymentCardNumber = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentCardNumber - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentCardNumber - 1)];
					c.PaymentCcv = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentCcv - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentCcv - 1)];
					c.PaymentExpiry = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentExpiry - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentExpiry - 1)];
					c.PaymentType = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentType - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentType - 1)];
					c.SiteId = (System.Int32)reader[((int)CustomPaymentColumn.SiteId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomPayment"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomPayment"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.CustomPayment entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomPaymentId = (System.Int32)reader[((int)CustomPaymentColumn.CustomPaymentId - 1)];
			entity.CustomPaymentGuid = (System.Guid)reader[((int)CustomPaymentColumn.CustomPaymentGuid - 1)];
			entity.Name = (System.String)reader[((int)CustomPaymentColumn.Name - 1)];
			entity.EmailAddress = (System.String)reader[((int)CustomPaymentColumn.EmailAddress - 1)];
			entity.InvoiceNumber = (System.String)reader[((int)CustomPaymentColumn.InvoiceNumber - 1)];
			entity.Amount = (System.Decimal)reader[((int)CustomPaymentColumn.Amount - 1)];
			entity.Comments = (reader.IsDBNull(((int)CustomPaymentColumn.Comments - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.Comments - 1)];
			entity.CreatedDate = (System.DateTime)reader[((int)CustomPaymentColumn.CreatedDate - 1)];
			entity.IpAddress = (reader.IsDBNull(((int)CustomPaymentColumn.IpAddress - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.IpAddress - 1)];
			entity.Response = (reader.IsDBNull(((int)CustomPaymentColumn.Response - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.Response - 1)];
			entity.SecurePay = (System.Boolean)reader[((int)CustomPaymentColumn.SecurePay - 1)];
			entity.Paypal = (System.Boolean)reader[((int)CustomPaymentColumn.Paypal - 1)];
			entity.Paid = (System.Boolean)reader[((int)CustomPaymentColumn.Paid - 1)];
			entity.PaymentNameOnCard = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentNameOnCard - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentNameOnCard - 1)];
			entity.PaymentCardNumber = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentCardNumber - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentCardNumber - 1)];
			entity.PaymentCcv = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentCcv - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentCcv - 1)];
			entity.PaymentExpiry = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentExpiry - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentExpiry - 1)];
			entity.PaymentType = (reader.IsDBNull(((int)CustomPaymentColumn.PaymentType - 1)))?null:(System.String)reader[((int)CustomPaymentColumn.PaymentType - 1)];
			entity.SiteId = (System.Int32)reader[((int)CustomPaymentColumn.SiteId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.CustomPayment"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomPayment"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.CustomPayment entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomPaymentId = (System.Int32)dataRow["CustomPaymentID"];
			entity.CustomPaymentGuid = (System.Guid)dataRow["CustomPaymentGuid"];
			entity.Name = (System.String)dataRow["Name"];
			entity.EmailAddress = (System.String)dataRow["EmailAddress"];
			entity.InvoiceNumber = (System.String)dataRow["InvoiceNumber"];
			entity.Amount = (System.Decimal)dataRow["Amount"];
			entity.Comments = Convert.IsDBNull(dataRow["Comments"]) ? null : (System.String)dataRow["Comments"];
			entity.CreatedDate = (System.DateTime)dataRow["CreatedDate"];
			entity.IpAddress = Convert.IsDBNull(dataRow["IpAddress"]) ? null : (System.String)dataRow["IpAddress"];
			entity.Response = Convert.IsDBNull(dataRow["Response"]) ? null : (System.String)dataRow["Response"];
			entity.SecurePay = (System.Boolean)dataRow["SecurePay"];
			entity.Paypal = (System.Boolean)dataRow["Paypal"];
			entity.Paid = (System.Boolean)dataRow["Paid"];
			entity.PaymentNameOnCard = Convert.IsDBNull(dataRow["PaymentNameOnCard"]) ? null : (System.String)dataRow["PaymentNameOnCard"];
			entity.PaymentCardNumber = Convert.IsDBNull(dataRow["PaymentCardNumber"]) ? null : (System.String)dataRow["PaymentCardNumber"];
			entity.PaymentCcv = Convert.IsDBNull(dataRow["PaymentCCV"]) ? null : (System.String)dataRow["PaymentCCV"];
			entity.PaymentExpiry = Convert.IsDBNull(dataRow["PaymentExpiry"]) ? null : (System.String)dataRow["PaymentExpiry"];
			entity.PaymentType = Convert.IsDBNull(dataRow["PaymentType"]) ? null : (System.String)dataRow["PaymentType"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.CustomPayment"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomPayment Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.CustomPayment entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the JXTPortal.Entities.CustomPayment object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.CustomPayment instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.CustomPayment Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.CustomPayment entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CustomPaymentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.CustomPayment</c>
	///</summary>
	public enum CustomPaymentChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Sites</c> at SiteIdSource
		///</summary>
		[ChildEntityType(typeof(Sites))]
		Sites,
		}
	
	#endregion CustomPaymentChildEntityTypes
	
	#region CustomPaymentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomPaymentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomPayment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomPaymentFilterBuilder : SqlFilterBuilder<CustomPaymentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilterBuilder class.
		/// </summary>
		public CustomPaymentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomPaymentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomPaymentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomPaymentFilterBuilder
	
	#region CustomPaymentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomPaymentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomPayment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomPaymentParameterBuilder : ParameterizedSqlFilterBuilder<CustomPaymentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomPaymentParameterBuilder class.
		/// </summary>
		public CustomPaymentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomPaymentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomPaymentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomPaymentParameterBuilder
	
	#region CustomPaymentSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomPaymentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomPayment"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomPaymentSortBuilder : SqlSortBuilder<CustomPaymentColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomPaymentSqlSortBuilder class.
		/// </summary>
		public CustomPaymentSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomPaymentSortBuilder
	
} // end namespace
